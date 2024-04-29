using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using Common.Console;

public partial class InformationCenter_jobdetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                BindEmployeeGrid();
            }

        }
    }

    protected void BindEmployeeGrid()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        try
        {
            string query = @"select id, job_summary,job_reposability,job_requirement from tbl_Information_job where status='1' and created_Date BETWEEN GETDATE()-30 AND GETDATE() ";

            DataSet dspay = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            grid_job.DataSource = dspay;
            grid_job.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Data not Binding. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
    }
    protected void grid_job_PreRender(object sender, EventArgs e)
    {
        if (grid_job.Rows.Count > 0)
            grid_job.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}