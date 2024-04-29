using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;


public partial class leave_editleavepolicy : System.Web.UI.Page
{
    string _sqlstr;
    DataSet _ds = new DataSet();
    string _companyId;
    //================================= Created by Ramu Nunna on 10-11-14 purpose of Bind Leave Policy Details =============//
    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindPolicy(Convert.ToInt32(_companyId));
                if (Request.QueryString["updated"] != null)
                    Output.Show("Leave policy updated successfully.");
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }

    #endregion
    #region Bind Policy Details

    protected void BindPolicy(int companyId)
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            _sqlstr = "select policyid,policyname,policy_file_name+ policy_file_type as policy_file_name, policy_file_type,(CASE WHEN date='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), date, 103) END)date from tbl_leave_createleavepolicy where status=1 and company_id=" + companyId + " order by policyid ";
            _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, _sqlstr);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            policygrid.DataSource = _ds;
            policygrid.DataBind();

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

    #endregion
    #region Grid Delete & PreRender Events
    protected void policygird_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        var activity = new DataActivity();
        try
        {
            int a;
            a = (int)policygrid.DataKeys[e.RowIndex].Value;
            SqlConnection connection = activity.OpenConnection();
            string strcheck1 = "select policyid from tbl_leave_createdefaultrule where policyid=" + a + "";
            _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, strcheck1);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                Output.Show("You can not delete this policy as it is used in leave system");
            }
            else
            {
                string strcheck = "update tbl_leave_createleavepolicy set status=0 where policyid=" + a + "";
                int i = SQLServer.ExecuteNonQuery(connection, CommandType.Text, strcheck);
                BindPolicy(Convert.ToInt32(_companyId));
                if (i > 0)
                {
                    Output.Show("Leave Policy Deleted Sucessfully.");
                }
            }

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
    protected void policygrid_PreRender(object sender, EventArgs e)
    {
        if (policygrid.Rows.Count > 0)
            policygrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    #endregion
}