using Common.Console;
using Common.Data;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_leaveapprovalproxy : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection _connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (!IsPostBack)
            {
                BindProxyDetails();
            }

        }
        else
            Response.Redirect("~/notlogged.aspx");
    }

    private void BindProxyDetails()
    {
        try
        {
            _connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(_connection, CommandType.StoredProcedure, "sp_leave_getproxyleavedetails");
            leave_approval_grid.DataSource = ds;
            leave_approval_grid.DataBind();
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #region Approve Link of Leave Details
    protected string linkleave(string empcode, string leavename, int id)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
            return "<a href='ViewLeaveApprover.aspx?q=" + encoded + "' title='view detail' class='lable lable-info'>" + leavename + "</a>";

        else
            return "<a href='ViewLeaveHR.aspx?q=" + encoded + "' title='view detail' class='lable lable-info'>" + leavename + " </a>";

    }
    #endregion
    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void leave_approval_grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        SqlTransaction transaction = null;
        var row = leave_approval_grid.Rows[e.RowIndex];
        var lblempcode = (Label)row.FindControl("lblempcode");
        var lblapproverid = (Label)row.FindControl("lblapprovercode");
        var level = (Label)row.FindControl("lbllevel");
        var assignempcode = (TextBox)row.FindControl("txt_employee");
        var applyleaveid = (Label)row.FindControl("lblapplyid");
        int flag = 0;
        if (assignempcode.Text != null && assignempcode.Text != "")
        {
            if (lblapproverid.Text.Trim() != assignempcode.Text.Trim())
            {
                try
                {

                    string sqlstr = @"insert into tbl_leave_employee_hierarchy_proxy(apply_leave_id,employeecode,approverid,proxy_approverid,level,status,createdby,createddate) ";
                    sqlstr = sqlstr + "values('" + applyleaveid.Text + "','" + lblempcode.Text + "','" + lblapproverid.Text + "','" + assignempcode.Text + "','" + level.Text + "',1,'" + Session["empcode"].ToString() + "',getdate())";

                    string sqlstr1 = @"update  tbl_leave_employee_hierarchy set flag=0  where employeecode='" + lblempcode.Text + "' and approverid='" + lblapproverid.Text + "' and approverpriority='" + level.Text + "'";


                    _connection = activity.OpenConnection();
                    transaction = _connection.BeginTransaction();
                    flag = SQLServer.ExecuteNonQuery(_connection, CommandType.Text, transaction, sqlstr);
                    flag += SQLServer.ExecuteNonQuery(_connection, CommandType.Text, transaction, sqlstr1);


                    if (leave_approval_grid.Rows.Count > 1)
                    {
                        for (int i = 1; i <= leave_approval_grid.Rows.Count - 1; i++)
                        {
                            GridViewRow rowduplicate = leave_approval_grid.Rows[i];
                            var dupapplyleaveid = (Label)rowduplicate.FindControl("lblapplyid");
                            var duplicateempcode = (Label)rowduplicate.FindControl("lblempcode");
                            if (lblempcode.Text == duplicateempcode.Text)
                            {
                                sqlstr = @"insert into tbl_leave_employee_hierarchy_proxy(apply_leave_id,employeecode,approverid,proxy_approverid,level,status,createdby,createddate) ";
                                sqlstr = sqlstr + "values('" + dupapplyleaveid.Text + "','" + lblempcode.Text + "','" + lblapproverid.Text + "','" + assignempcode.Text + "','" + level.Text + "',1,'" + Session["empcode"].ToString() + "',getdate())";
                                flag = SQLServer.ExecuteNonQuery(_connection, CommandType.Text, transaction, sqlstr);
                            }
                        }
                    }
                    transaction.Commit();
                    ArrayList list = new ArrayList();
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        mailtoemployee(list, lblempcode.Text.Trim().ToString(), lblapproverid.Text.Trim().ToString(), assignempcode.Text.Trim().ToString());

                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                if (flag > 0)
                {
                    Output.Show("Dotted Approver assigned successfully.");
                    BindProxyDetails();
                }
                else
                {
                    Output.Show("Dotted Approver not assigned successfully.Please contact Admin.");
                }

            }
            else Common.Console.Output.Show("Approver & Dotted Approved should not equal.please select anthor approver.");
        }
        else Common.Console.Output.Show("Please select dotted Approver");

        
    }
    private void mailtoemployee(ArrayList list, string empcode, string approverid, string dottedapprover)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + approverid + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

        string subject = "";
        string bodyContent = "";

        subject = "Proxy Leave Request.";
        bodyContent = "Time line for " + approverid.ToString() + "  Line Manager is expired.Therefore this " + empcode + " leave request has been forwarded to you.Kindly go through application & respond to same.";

        string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
        if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
        {
            try
            {
                Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
            }
            catch
            {
                list.Add("Leave Approved Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
            }
        }
        else
        {
            list.Add("Leave Approved Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
        }
        activity.CloseConnection();
    }

}