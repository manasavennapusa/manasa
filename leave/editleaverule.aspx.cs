using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class leave_editleaverule : System.Web.UI.Page
{
    DataSet _ds = new DataSet();
    string _companyId;
    SqlConnection _connection;
    string sqlstr = "";
    Common.Data.DataActivity Activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindLeaveRule(Convert.ToInt32(_companyId));

                if (Request.QueryString["edit_adjust"] != null)
                {
                    Common.Console.Output.Show(" Leave adjustment updated successfully ");
                }

                if (Request.QueryString["updated"] != null)
                {
                    Common.Console.Output.Show("Leave rule updated successfully.");
                }


                if (Request.QueryString["edit_club"] != null)
                {
                    Common.Console.Output.Show("Leave clubbing updated successfully");
                }
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }

    }

    protected void rulegrid_PreRender(object sender, EventArgs e)
    {
        if (rulegrid.Rows.Count > 0)
            rulegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void BindLeaveRule(int companyId)
    {
        try
        {
            _connection = Activity.OpenConnection();
            sqlstr = @"select tbl_leave_createdefaultrule.leaveid,tbl_leave_createdefaultrule.id,tbl_leave_createleave.leavetype,tbl_leave_createdefaultrule.policyid,tbl_leave_createleavepolicy.policyname from tbl_leave_createdefaultrule INNER JOIN tbl_leave_createleavepolicy ON tbl_leave_createdefaultrule.policyid=tbl_leave_createleavepolicy.policyid
                              INNER JOIN tbl_leave_createleave ON tbl_leave_createdefaultrule.leaveid=tbl_leave_createleave.leaveid  where tbl_leave_createdefaultrule.status=1 and tbl_leave_createdefaultrule.company_id=" + companyId + " order by policyname,leavetype";
            _ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, sqlstr);
            rulegrid.DataSource = _ds;
            rulegrid.DataBind();
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
    }
}
