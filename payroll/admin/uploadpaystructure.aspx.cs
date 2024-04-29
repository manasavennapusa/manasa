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

public partial class payroll_admin_uploadpaystructure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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



    //protected void btn_sbmit_Click(object sender, EventArgs e)
    //{
       
    //    exceldocument();

    //}

    private void exceldocument()
    {
        try
        {
            if (uploaddocument())
            {

                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    string file = Server.MapPath(".") + "\\upload\\Payroll.xlsx";
                    String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                    OleDbConnection objconn = new OleDbConnection(strConn);
                    objconn.Open();
                    OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [Paystructure$]", objconn);
                    OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                    objadapter1.SelectCommand = objcmdselect;
                    DataSet dds = new DataSet();
                    objadapter1.Fill(dds, "Payroll");
                    objconn.Close();


                    for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                    {
                        SqlParameter[] sqlparm = new SqlParameter[10];
                        sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["Empcode"].ToString());
                        sqlparm[1] = new SqlParameter("@month", dds.Tables[0].Rows[i]["Applicable_From_Month"].ToString());
                        sqlparm[2] = new SqlParameter("@year", dds.Tables[0].Rows[i]["Applicable_From_Year"].ToString());
                        sqlparm[3] = new SqlParameter("@pf", dds.Tables[0].Rows[i]["PF_Applicable"].ToString().Trim());
                        sqlparm[4] = new SqlParameter("@esi", dds.Tables[0].Rows[i]["ESI_Applicable"].ToString().Trim());
                        sqlparm[5] = new SqlParameter("@usercode", Session["empcode"].ToString().Trim());
                        sqlparm[6] = new SqlParameter("@pf_mode", dds.Tables[0].Rows[i]["Pf_Mode"].ToString().Trim());
                        sqlparm[7] = new SqlParameter("@vpf", dds.Tables[0].Rows[i]["vpf"].ToString().Trim());
                        sqlparm[8] = new SqlParameter("@vpfpr", dds.Tables[0].Rows[i]["vdf_precentage"].ToString().Trim());
                        sqlparm[9] = new SqlParameter("@pt", dds.Tables[0].Rows[i]["PT"].ToString().Trim());

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_insert_paystructure", sqlparm);
                    }

                }


                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    string file = Server.MapPath(".") + "\\upload\\Payroll.xlsx";
                    String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                    OleDbConnection objconn = new OleDbConnection(strConn);
                    objconn.Open();
                    OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [payrollStructuresample$]", objconn);
                    OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                    objadapter1.SelectCommand = objcmdselect;
                    DataSet dds = new DataSet();
                    objadapter1.Fill(dds, "Payroll");
                    objconn.Close();

                    for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                    {
                        int c = dds.Tables[0].Columns.Count;


                        try
                        {
                            for (int k = 0; k < c; k += 4)                               
 
                            {
                                if (dds.Tables[0].Rows[i][k + 4].ToString().Trim() != "0")
                                {
                                    SqlParameter[] sqlparm = new SqlParameter[6];
                                    sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["Empcode"].ToString());
                                    sqlparm[1] = new SqlParameter("@payheadid", dds.Tables[0].Rows[i][k + 1].ToString());
                                    sqlparm[2] = new SqlParameter("@caltype", dds.Tables[0].Rows[i][k + 2].ToString());

                                    sqlparm[3] = new SqlParameter("@valuebase", Convert.ToDecimal(dds.Tables[0].Rows[i][k + 3].ToString().Trim()));
                                    sqlparm[3].SqlDbType = SqlDbType.Decimal;

                                    sqlparm[4] = new SqlParameter("@amount", Convert.ToDecimal(dds.Tables[0].Rows[i][k + 4].ToString().Trim()));
                                    sqlparm[4].SqlDbType = SqlDbType.Decimal;
                                    sqlparm[5] = new SqlParameter("@usercode", dds.Tables[0].Rows[i]["empcode"].ToString().Trim());

                                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_insert_paystructure_detail", sqlparm);
                                }
                            }
                        }
                        catch
                        {

                        }

                    }

                }

                ShowAlertMessage("Payroll structure uploaded successfully");


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
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
                        file_name = Server.MapPath(".") + "\\upload\\Payroll.xls";
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());


                        return true;
                        //break;
                    }
                case ".xlsx":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\Payroll.xlsx";
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


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        exceldocument();
    }
}
