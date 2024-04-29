using Common.Console;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menuconfig_Logo_upload : System.Web.UI.Page
{
    string usercode, companyId, RoleId, uploadlogo, Uploaded_logo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        usercode = Session["empcode"].ToString();
        companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(this.Request.Url.ToString());
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int i = 0;
        try
        {
            if (logoupload.HasFile)
            {
                string strFileName;
                string file_name = usercode + System.DateTime.Now.GetHashCode().ToString();
                strFileName = logoupload.FileName;
                logoupload.PostedFile.SaveAs(Server.MapPath("~/upload/logo/" + file_name + "_" + strFileName));
                uploadlogo = file_name + "_" + strFileName;

                string query = @"Insert into tbl_intranet_uploadedLogo
(Logo,createdby,createddate) Values('" + uploadlogo + "','" + usercode + "','" + System.DateTime.Now.ToString() + "')";
                i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
            }

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            if (i > 0)
            {
                //Output.Show("Logo Uploaded Successfully");
                Session["logoupload"] = uploadlogo;
                Response.Redirect("~/notlogged.aspx");
            }
            else
            {
                Output.Show("Logo Not Uploaded");
            }
        }
    }

}