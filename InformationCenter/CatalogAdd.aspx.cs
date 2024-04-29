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

public partial class InformationCenter_CatalogAdd : System.Web.UI.Page
{
    string sqlstr, file_name;
    string _userCode, _companyId, RoleId;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (fupload.PostedFile.FileName.ToString() != "")
        {
            file_name = System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
            fupload.PostedFile.SaveAs(Server.MapPath("../InformationCenter/upload/catalogs/" + file_name));
            ViewState.Add("file_name", file_name.ToString());
        }
        try
        {
            SqlParameter[] newparameter = new SqlParameter[6];

            newparameter[0] = new SqlParameter("@type", SqlDbType.Int);
            newparameter[0].Value = ddltype.SelectedValue;

            newparameter[1] = new SqlParameter("@subject", SqlDbType.VarChar, 100);
            newparameter[1].Value = txtsubject.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@upload", SqlDbType.VarChar, 150);
            newparameter[3].Value = ViewState["file_name"].ToString();

            newparameter[4] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
            newparameter[4].Value = _userCode.ToString();

            newparameter[5] = new SqlParameter("@posteddate", SqlDbType.DateTime);
            newparameter[5].Value = System.DateTime.Now;

            //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_catalog_sp", newparameter);
            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_catalog_sp", newparameter);
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
                Response.Redirect("~/DashBoard_Demo.aspx?NewsUpdate=1");
            }
            else
            {
                Response.Redirect("~/DashBoard_Demo.aspx?NewsUpdate=0");
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(this.Request.Url.ToString());
    }

}