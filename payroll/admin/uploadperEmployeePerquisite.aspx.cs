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
using Utilities;
using System.Data.SqlClient;
using System.Text;
using System.Data.OleDb;

public partial class payroll_admin_uploadperEmployeePerquisite : System.Web.UI.Page
{
    string  _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
        message.InnerHtml = "";
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        exceldocument();
    }

    protected bool uploaddocument()
    {
        string file_name, fn, ftype;
        if (fupload.PostedFile.FileName.ToString() != "")
        {
            fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
            ftype = System.IO.Path.GetExtension(fn);
            switch (ftype)
            {
                case ".xls":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\Perquisite.xls";
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());


                        return true;
                        //break;
                    }
                case ".xlsx":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\Perquisite.xlsx";
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());


                        return true;
                        //break;
                    }
                default:
                    {

                        return false;
                        //break;
                    }
            }
            return true;
        }
        return true;
    }

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }

    private void exceldocument()
    {
        try
        {
            if (uploaddocument())
            {

                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    string file = Server.MapPath(".") + "\\upload\\Perquisite.xls";
                    String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                    OleDbConnection objconn = new OleDbConnection(strConn);
                    objconn.Open();
                    OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [Perquisite$]", objconn);
                    OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                    objadapter1.SelectCommand = objcmdselect;
                    DataSet dds = new DataSet();
                    objadapter1.Fill(dds, "Perquisite");
                    objconn.Close();


                    for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                    {
                        SqlParameter[] sqlparm = new SqlParameter[6];
                        sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["Empcode"].ToString());
                        sqlparm[1] = new SqlParameter("@fyear", dds.Tables[0].Rows[i]["Year"].ToString());
                        sqlparm[2] = new SqlParameter("@perqusite_id", dds.Tables[0].Rows[i]["Perqusite_id"].ToString());
                        sqlparm[3] = new SqlParameter("@amount", dds.Tables[0].Rows[i]["Amount"].ToString());
                        sqlparm[4] = new SqlParameter("@amount_received", dds.Tables[0].Rows[i]["Amount_Received"].ToString());
                        sqlparm[5] = new SqlParameter("@createdby", _userCode.ToString());

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite", sqlparm);
                    }

                }

                ShowAlertMessage("Perquisite for Employee has been created successfully");


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}