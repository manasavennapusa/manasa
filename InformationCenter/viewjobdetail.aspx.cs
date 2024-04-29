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
using System.Reflection;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class InformationCenter_viewjobdetail : System.Web.UI.Page
{
    string _userCode, _companyId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                BindPayHead();
            }
        }
    }

    private void BindPayHead()
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "select id, job_summary,job_reposability,job_requirement from tbl_Information_job  WHERE id=" + Request.QueryString["id"].ToString() + "";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_name.Text = ds.Tables[0].Rows[0]["job_summary"].ToString();
                lbl_alias.Text = ds.Tables[0].Rows[0]["job_requirement"].ToString();
                lbl_payheadtype.Text = ds.Tables[0].Rows[0]["job_reposability"].ToString();
            }
            else
            {

            }


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