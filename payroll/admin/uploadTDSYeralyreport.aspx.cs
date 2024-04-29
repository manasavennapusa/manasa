using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using DataAccessLayer;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Web.Security;
using Common.Console;



public partial class payroll_admin_uploadTDSYeralyreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_fyear();
            if (Session["role"] != null)
            {
                //diverror.InnerHtml = "";
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }

    }

    protected void bind_fyear()
    {

        int year = DateTime.Now.Year, count = 1;
        lbl_fyear.Items.Insert(0, new ListItem("---select---"));

        for (int i = year - 1; i < year + 5; i++)
        {
            lbl_fyear.Items.Insert(count, new ListItem(i.ToString() + "-" + (i + 1).ToString()));
            count++;
        }
        //DateTime dt = DateTime.Now;

        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        //if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
        //    lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        //else
        //    lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
      
    }
    int iferror = 0;
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        // diverror.InnerHtml = "";
        string Version = "none";

        string Path = "";

        if (fupload.HasFile)
        {
            if (UploadDocument(ref Version, ref Path))
            {
                string ConnectionString = GetConnection(Version, Path);
                DataTable[] dt = new DataTable[4];

                dt[0] = GetExcelDate("SELECT * FROM [Description$]", ConnectionString);
                dt[1] = GetExcelDate("SELECT * FROM [Deduction$]", ConnectionString);
                dt[2] = GetExcelDate("SELECT * FROM [Investment$]", ConnectionString);
                dt[3] = GetExcelDate("SELECT * FROM [Exemption$]", ConnectionString);

                fupload.Dispose();
                InsertEmployeeDetails(dt);
                if (iferror > 0)
                {
                    Common.Console.Output.Show("Employee information Not uploaded successfully.Please Contact Administrator for Error.");
                }
                else
                {
                    Common.Console.Output.Show("Transaction Completed Successfully!!!");
                }
            }
            else
            {
                //Error Message.
            }
        }
        else
        {
            Common.Console.Output.Show("Please Upload the file.");
        }
    }

    private void InsertEmployeeDetails(DataTable[] dtEmp)
    {
        SaveDescription(dtEmp[0]);
        SaveDeduction(dtEmp[1]);
        SaveInvestment(dtEmp[2]);
        SaveExemption(dtEmp[3]);
    }

    #region Description Details
    private void SaveDescription(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {

                SqlParameter[] p = new SqlParameter[15];


                p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                {
                    p[0].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[0].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                }

                p[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                if (lbl_fyear.Text == "")
                {
                    p[1].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[1].Value = lbl_fyear.Text;

                }

                p[2] = new SqlParameter("@BONUS", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["BONUS"].ToString().Trim() == "")
                {
                    p[2].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[2].Value = dt.Rows[i]["BONUS"].ToString().Trim();
                }

                p[3] = new SqlParameter("@PolicyNumber", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["PolicyNumber"].ToString().Trim() == "")
                {
                    p[3].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[3].Value = dt.Rows[i]["PolicyNumber"].ToString().Trim();
                }

                p[4] = new SqlParameter("@BP_ALL", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["B&P_ALL"].ToString().Trim() == "")
                {
                    p[4].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[4].Value = p[4].Value = dt.Rows[i]["B&P_ALL"].ToString().Trim();

                }
                p[5] = new SqlParameter("@PRV_EMP_SAL", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["PRV_EMP_SAL"].ToString().Trim() == "")
                {
                    p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[5].Value = dt.Rows[i]["PRV_EMP_SAL"].ToString().Trim();
                }
                p[6] = new SqlParameter("@Rent_Paid", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Rent_Paid"].ToString().Trim() == "")
                {
                    p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[6].Value = dt.Rows[i]["Rent_Paid"].ToString().Trim();

                }
                p[7] = new SqlParameter("@From_date", SqlDbType.VarChar,50);
                if (dt.Rows[i]["From"].ToString().Trim() == "")
                {
                    p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[7].Value = dt.Rows[i]["From"].ToString().Trim();
                }
                p[8] = new SqlParameter("@To_date", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["To"].ToString().Trim() == "")
                {
                    p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[8].Value = dt.Rows[i]["To"].ToString().Trim();
                }
                p[9] = new SqlParameter("@Actual_HRA", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Actual_HRA"].ToString().Trim() == "")
                {
                    p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[9].Value = dt.Rows[i]["Actual_HRA"].ToString().Trim();

                }
                p[10] = new SqlParameter("@Basicof40or50", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["40%or50%ofBasic"].ToString().Trim() == "")
                {
                    p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[10].Value = dt.Rows[i]["40%or50%ofBasic"].ToString().Trim();

                }
                p[11] = new SqlParameter("@Rent10Basic", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Rent>10%Basic"].ToString().Trim() == "")
                {
                    p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[11].Value = dt.Rows[i]["Rent>10%Basic"].ToString().Trim();

                }
                p[12] = new SqlParameter("@Leastaboveexempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Least_of_above_is_exempt"].ToString().Trim() == "")
                {
                    p[12].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[12].Value = dt.Rows[i]["Least_of_above_is_exempt"].ToString().Trim();
                }
                p[13] = new SqlParameter("@Taxable_HRA", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Taxable_HRA"].ToString().Trim() == "")
                {
                    p[13].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[13].Value = dt.Rows[i]["Taxable_HRA"].ToString().Trim();
                }

                p[14] = new SqlParameter("@Month_Id", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Month_Id"].ToString().Trim() == "")
                {
                    p[14].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[14].Value = dt.Rows[i]["Month_Id"].ToString().Trim();
                }
               

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_upload_tdsreport_Y1", p);

                //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";


            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Deduction Details
    private void SaveDeduction(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {

                SqlParameter[] p = new SqlParameter[20];


                p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                {
                    p[0].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[0].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                }

                p[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                if (lbl_fyear.Text == "")
                {
                    p[1].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[1].Value = lbl_fyear.Text;

                }

                p[2] = new SqlParameter("@Previous_EmployerProfessionalTax", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Previous_EmployerProfessionalTax"].ToString().Trim() == "")
                {
                    p[2].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[2].Value = dt.Rows[i]["Previous_EmployerProfessionalTax"].ToString().Trim();
                }

                p[3] = new SqlParameter("@Professional_Tax", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Professional_Tax"].ToString().Trim() == "")
                {
                    p[3].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[3].Value = dt.Rows[i]["Professional_Tax"].ToString().Trim();
                }

                p[4] = new SqlParameter("@UnderChapterVI_A", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["UnderChapterVI_A"].ToString().Trim() == "")
                {
                    p[4].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[4].Value = p[4].Value = dt.Rows[i]["UnderChapterVI_A"].ToString().Trim();

                }
                p[5] = new SqlParameter("@AnyOtherIncome", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["AnyOtherIncome"].ToString().Trim() == "")
                {
                    p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[5].Value = dt.Rows[i]["AnyOtherIncome"].ToString().Trim();
                }
                p[6] = new SqlParameter("@Interest_on_HousingLoan", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Interest_on_HousingLoan"].ToString().Trim() == "")
                {
                    p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[6].Value = dt.Rows[i]["Interest_on_HousingLoan"].ToString().Trim();

                }
                p[7] = new SqlParameter("@Taxable_Income", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Taxable_Income"].ToString().Trim() == "")
                {
                    p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[7].Value = dt.Rows[i]["Taxable_Income"].ToString().Trim();
                }
                p[8] = new SqlParameter("@Total_Tax", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Total_Tax"].ToString().Trim() == "")
                {
                    p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[8].Value = dt.Rows[i]["Total_Tax"].ToString().Trim();
                }
                p[9] = new SqlParameter("@Tax_Due", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Tax_Due"].ToString().Trim() == "")
                {
                    p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[9].Value = dt.Rows[i]["Tax_Due"].ToString().Trim();

                }
                p[10] = new SqlParameter("@Educational_Cess", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Educational_Cess"].ToString().Trim() == "")
                {
                    p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[10].Value = dt.Rows[i]["Educational_Cess"].ToString().Trim();

                }
                p[11] = new SqlParameter("@Net_Tax", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Net_Tax"].ToString().Trim() == "")
                {
                    p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[11].Value = dt.Rows[i]["Net_Tax"].ToString().Trim();

                }
                p[12] = new SqlParameter("@TaxDeducted_Till_Date", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["TaxDeducted_Till_Date"].ToString().Trim() == "")
                {
                    p[12].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[12].Value = dt.Rows[i]["TaxDeducted_Till_Date"].ToString().Trim();
                }
                p[13] = new SqlParameter("@Tax_to_be_Deducted", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Tax_to_be_Deducted"].ToString().Trim() == "")
                {
                    p[13].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[13].Value = dt.Rows[i]["Tax_to_be_Deducted"].ToString().Trim();
                }
                p[14] = new SqlParameter("@Tax_Month", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Tax_Month"].ToString().Trim() == "")
                {
                    p[14].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[14].Value = dt.Rows[i]["Tax_Month"].ToString().Trim();
                }
                p[15] = new SqlParameter("@TaxDeductionforthis_month", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["TaxDeduction_for_this_month"].ToString().Trim() == "")
                {
                    p[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[15].Value = dt.Rows[i]["TaxDeduction_for_this_month"].ToString().Trim();
                }
                p[16] = new SqlParameter("@Surcharge", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Surcharge"].ToString().Trim() == "")
                {
                    p[16].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[16].Value = dt.Rows[i]["Surcharge"].ToString().Trim();
                }
                p[17] = new SqlParameter("@TaxDeducted_PreviousEmployer", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["TaxDeducted(PreviousEmployer)"].ToString().Trim() == "")
                {
                    p[17].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[17].Value = dt.Rows[i]["TaxDeducted(PreviousEmployer)"].ToString().Trim();
                }
                p[18] = new SqlParameter("@Tax_Non_Recurring_Earnings", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Tax_on_Non_Recurring_Earnings"].ToString().Trim() == "")
                {
                    p[18].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[18].Value = dt.Rows[i]["Tax_on_Non_Recurring_Earnings"].ToString().Trim();
                }


                p[19] = new SqlParameter("@Month_Id", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Month_Id"].ToString().Trim() == "")
                {
                    p[19].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[19].Value = dt.Rows[i]["Month_Id"].ToString().Trim();
                }

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_upload_tdsreport_Y2", p);

                //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";


            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Investment 
    private void SaveInvestment(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {

                SqlParameter[] p = new SqlParameter[18];


                p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                {
                    p[0].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[0].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                }

                p[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                if (lbl_fyear.Text == "")
                {
                    p[1].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[1].Value = lbl_fyear.Text;

                }

                p[2] = new SqlParameter("@LIP", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["LIP"].ToString().Trim() == "")
                {
                    p[2].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[2].Value = dt.Rows[i]["LIP"].ToString().Trim();
                }

                p[3] = new SqlParameter("@PPF", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["PPF"].ToString().Trim() == "")
                {
                    p[3].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[3].Value = dt.Rows[i]["PPF"].ToString().Trim();
                }

                p[4] = new SqlParameter("@INV_FD", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["INV_FD"].ToString().Trim() == "")
                {
                    p[4].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[4].Value = p[4].Value = dt.Rows[i]["INV_FD"].ToString().Trim();

                }
                p[5] = new SqlParameter("@CEF", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["CEF"].ToString().Trim() == "")
                {
                    p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[5].Value = dt.Rows[i]["CEF"].ToString().Trim();
                }
                p[6] = new SqlParameter("@NSC", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["NSC"].ToString().Trim() == "")
                {
                    p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[6].Value = dt.Rows[i]["NSC"].ToString().Trim();

                }
                p[7] = new SqlParameter("@ELSS", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["ELSS"].ToString().Trim() == "")
                {
                    p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[7].Value = dt.Rows[i]["ELSS"].ToString().Trim();
                }
                p[8] = new SqlParameter("@HOUSE_PRIN", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["HOUSE_PRIN"].ToString().Trim() == "")
                {
                    p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[8].Value = dt.Rows[i]["HOUSE_PRIN"].ToString().Trim();
                }
                p[9] = new SqlParameter("@ULIP", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["ULIP"].ToString().Trim() == "")
                {
                    p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[9].Value = dt.Rows[i]["ULIP"].ToString().Trim();

                }
                p[10] = new SqlParameter("@NSC_INT", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["NSC_INT"].ToString().Trim() == "")
                {
                    p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[10].Value = dt.Rows[i]["NSC_INT"].ToString().Trim();

                }
                p[11] = new SqlParameter("@US_80C", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["US_80C"].ToString().Trim() == "")
                {
                    p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[11].Value = dt.Rows[i]["US_80C"].ToString().Trim();

                }
                p[12] = new SqlParameter("@US_80D", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["US_80D_SELF"].ToString().Trim() == "")
                {
                    p[12].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[12].Value = dt.Rows[i]["US_80D_SELF"].ToString().Trim();
                }
                p[13] = new SqlParameter("@CCD80_1B", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["80CCD(1B)"].ToString().Trim() == "")
                {
                    p[13].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[13].Value = dt.Rows[i]["80CCD(1B)"].ToString().Trim();
                }

                p[14] = new SqlParameter("@DED_80G", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["DED_80G"].ToString().Trim() == "")
                {
                    p[14].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[14].Value = dt.Rows[i]["DED_80G"].ToString().Trim();
                }

                p[15] = new SqlParameter("@DED_80E", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["DED_80E"].ToString().Trim() == "")
                {
                    p[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[15].Value = dt.Rows[i]["DED_80E"].ToString().Trim();
                }

                p[16] = new SqlParameter("@US_80D_P", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["US_80D_PARENT"].ToString().Trim() == "")
                {
                    p[16].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[16].Value = dt.Rows[i]["US_80D_PARENT"].ToString().Trim();
                }

                p[17] = new SqlParameter("@Month_Id", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Month_Id"].ToString().Trim() == "")
                {
                    p[17].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[17].Value = dt.Rows[i]["Month_Id"].ToString().Trim();
                }


                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_upload_tdsreport_Y3", p);

                //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";


            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Exemption Details
    private void SaveExemption(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {

                SqlParameter[] p = new SqlParameter[12];


                p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                {
                    p[0].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[0].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                }

                p[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                if (lbl_fyear.Text == "")
                {
                    p[1].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[1].Value = lbl_fyear.Text;

                }

                p[2] = new SqlParameter("@B_Exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Basic_Exempt"].ToString().Trim() == "")
                {
                    p[2].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[2].Value = dt.Rows[i]["Basic_Exempt"].ToString().Trim();
                }

                p[3] = new SqlParameter("@HRA_Exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["HRA_Exempt"].ToString().Trim() == "")
                {
                    p[3].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[3].Value = dt.Rows[i]["HRA_Exempt"].ToString().Trim();
                }

                p[4] = new SqlParameter("@Conv_Exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["CONVEYANCE_Exempt"].ToString().Trim() == "")
                {
                    p[4].Value = System.Data.SqlTypes.SqlString.Null;
                }
                else
                {
                    p[4].Value = p[4].Value = dt.Rows[i]["CONVEYANCE_Exempt"].ToString().Trim();

                }
                p[5] = new SqlParameter("@SP_Exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["SPL_ALLOW_Exempt"].ToString().Trim() == "")
                {
                    p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[5].Value = dt.Rows[i]["SPL_ALLOW_Exempt"].ToString().Trim();
                }
                p[6] = new SqlParameter("@med_Exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["MED_ALLOW_Exempt"].ToString().Trim() == "")
                {
                    p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[6].Value = dt.Rows[i]["MED_ALLOW_Exempt"].ToString().Trim();

                }
                p[7] = new SqlParameter("@bouns_exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["BONUS_Exempt"].ToString().Trim() == "")
                {
                    p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[7].Value = dt.Rows[i]["BONUS_Exempt"].ToString().Trim();
                }
                p[8] = new SqlParameter("@BP_exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["BP_ALL_Exempt"].ToString().Trim() == "")
                {
                    p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[8].Value = dt.Rows[i]["BP_ALL_Exempt"].ToString().Trim();
                }
                p[9] = new SqlParameter("@Per_sal_exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["PRV_EMP_SAL_Exempt"].ToString().Trim() == "")
                {
                    p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[9].Value = dt.Rows[i]["PRV_EMP_SAL_Exempt"].ToString().Trim();

                }

                p[10] = new SqlParameter("@LTA_Exempt", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["LTA_Exempt"].ToString().Trim() == "")
                {
                    p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[10].Value = dt.Rows[i]["LTA_Exempt"].ToString().Trim();

                }


                p[11] = new SqlParameter("@Month_Id", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Month_Id"].ToString().Trim() == "")
                {
                    p[11].Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    p[11].Value = dt.Rows[i]["Month_Id"].ToString().Trim();
                }

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_upload_tdsreport_Y4", p);

                //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";


            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Connection
    private string GetConnection(string version, string Path)
    {

        if (version == "4.0")
        {
            // I will add later.
            return "";
        }
        else if (version == "12.0")
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Trim() + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
        }
        else
        {
            // Display message - Suitable version needed.
            return "";
        }
    }
    #endregion

    #region Excel Date
    private DataTable GetExcelDate(string Command, string ConnectionString)
    {
        DataSet ds = new DataSet();

        try
        {
            OleDbConnection Connection = new OleDbConnection(ConnectionString);
            Connection.Open();
            OleDbCommand Cmd = new OleDbCommand(Command, Connection);
            OleDbDataAdapter oda = new OleDbDataAdapter(Cmd);
            oda.Fill(ds);
        }
        catch (Exception ex)
        {
            Log("During GetExcelData: " + ex.Message + ".    " + DateTime.Now);
        }
        DataTable dt = new DataTable();
        dt = null;
        if (ds.Tables.Count > 0)
            dt = ds.Tables[0];
        return dt;


    }
    #endregion

    #region Upload Excel Document
    protected bool UploadDocument(ref string version, ref string path)
    {
        try
        {
            string file_name, fn, ftype;
            bool flag = false;
            if (fupload.PostedFile.FileName.ToString() != "")
            {
                fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
                ftype = System.IO.Path.GetExtension(fn);
                switch (ftype)
                {
                    case ".xls":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                            fupload.PostedFile.SaveAs(file_name);
                            ViewState.Add("file_name", fn.ToString());
                            flag = true;
                            version = "4.0";
                            path = file_name;
                            break;
                        }
                    case ".xlsx":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                            //  file_name = Server.MapPath(".") + "\\upload\\" + flEmployee.FileName + DateTime.Now.ToString();
                            fupload.PostedFile.SaveAs(file_name);
                            ViewState.Add("file_name", fn.ToString());
                            version = "12.0";
                            path = file_name;
                            flag = true;
                            break;

                        }
                    default:
                        {
                            version = "none";
                            path = "";
                            flag = false;
                            break;
                        }
                }

            }
            return flag;
        }
        catch (Exception ex)
        {
            iferror++;
            Log("During UploadDocument: " + ex.Message + ".    " + DateTime.Now);
            return false;
        }

    }
    #endregion

    #region Log File
    private static void Log(string s)
    {
        if (!System.IO.Directory.Exists("C:\\Error"))
            System.IO.Directory.CreateDirectory("C:\\Error");

        System.IO.FileStream fs = new System.IO.FileStream(@"C:\Error\Log.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
        sw.BaseStream.Seek(0, System.IO.SeekOrigin.End);
        sw.WriteLine(s);
        sw.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------");
        sw.Flush();
        sw.Close();
    }
    #endregion

}