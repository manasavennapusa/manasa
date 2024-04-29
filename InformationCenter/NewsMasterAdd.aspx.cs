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
using DataAccessLayer;
using System.Data.SqlClient;
using Common.Console;

public partial class InformationCenter_NewsMasterAdd : System.Web.UI.Page
{
    string sqlstr, file_name;
    string _companyId, _userCode, RoleId;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();
        if (Session["role"] != null)
        {

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (fupload.HasFile)
        {
            file_name = System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
            fupload.PostedFile.SaveAs(Server.MapPath("../InformationCenter/upload/" + file_name));
            ViewState.Add("file_name", file_name.ToString());
        }
        try
        {
            SqlParameter[] newparameter = new SqlParameter[6];

            newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
            newparameter[0].Value = ddlcategory.SelectedValue;

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
            newparameter[1].Value = txtheading.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
            newparameter[3].Value = ddlrunstatusg.SelectedValue;

            newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
            newparameter[4].Value = ddlpriorityg.SelectedValue;

            newparameter[5] = new SqlParameter("@upload", SqlDbType.VarChar, 200);
            if (ViewState["file_name"] != null)
            {
                newparameter[5].Value = ViewState["file_name"].ToString();
            }
            else
            {
                newparameter[5].Value = "";
            }

            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_news_sp", newparameter);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            if (i < 0)
            {
                Response.Redirect("~/DashBoard_Demo.aspx?NewsAward=1");
            }
            else
            {
                Response.Redirect("~/DashBoard_Demo.aspx?NewsAward=0");
            }
        }
    }

    private void Clear()
    {
        ddlcategory.SelectedValue = "0";
        txtheading.Text = "";
        txtdescription.Text = "";
        ddlrunstatusg.SelectedValue = "0";
        ddlpriorityg.SelectedValue = "0";
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(this.Request.Url.ToString());
    }

}