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
using System.Security.Cryptography;
using System.IO;
using Common.Data;
using Common.Console;

public partial class UploadFrom16A : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    string defaultUpload1 = "";
     string  _userCode, _companyId;
     DataActivity activity = new DataActivity();
     SqlConnection connection = new SqlConnection();
     SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        message.InnerHtml = "";

        if (!IsPostBack)
        {
        
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

            Session.Remove("deduction");
            
        }        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        connection = activity.OpenConnection();
       // string defaultUpload1 = "";
        if (flEmployee.HasFile)
        {
            string strFileName;
            string file_name = System.IO.Path.GetFileName(flEmployee.PostedFile.FileName.ToString());
            strFileName = flEmployee.FileName;
            try
            {
                flEmployee.PostedFile.SaveAs(Server.MapPath("~/payroll/admin/doc/" + file_name));
                defaultUpload1 = file_name;
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload1 = "";
        }
        try
        {
            SqlParameter[] sqlParam = new SqlParameter[2];

            sqlParam[0] = new SqlParameter("@default1", SqlDbType.VarChar, 1000);
            sqlParam[0].Value = defaultUpload1;

            sqlParam[1] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
            sqlParam[1].Value = _userCode.ToString();

            SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_upload_form16A", sqlParam);
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Output.Show("Form 16A uploaded successfully");
            activity.CloseConnection();
        }      
    }


    
}