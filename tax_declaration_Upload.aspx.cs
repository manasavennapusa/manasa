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

public partial class tax_declaration_Upload : System.Web.UI.Page
{
    int a;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                diverror.InnerHtml = "";
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    int iferror = 0;
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        diverror.InnerHtml = "";
        string Version = "none";

        string Path = "";

        if (flEmployee.HasFile)
        {
            if (UploadDocument(ref Version, ref Path))
            {
                string ConnectionString = GetConnection(Version, Path);
                DataTable[] dt = new DataTable[5];

                dt[0] = GetExcelDate("SELECT * FROM [declaration_detail$]", ConnectionString);
                dt[1] = GetExcelDate("SELECT * FROM [Rent_details$]", ConnectionString);
                dt[2] = GetExcelDate("SELECT * FROM [Section_6A$]", ConnectionString);
                dt[3] = GetExcelDate("SELECT * FROM [salary$]", ConnectionString);
                dt[4] = GetExcelDate("SELECT * FROM [letout$]", ConnectionString);
               
                flEmployee.Dispose();
                InsertEmployeeDetails(dt);
                if (iferror > 0)
                {
                    Common.Console.Output.Show("Tax Declaration information Not uploaded successfully.Please Contact Administrator for Error.");
                }
                else
                {

                    Common.Console.Output.Show("Tax Declaration information uploaded successfully.");
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
        SavedeclarationDetails(dtEmp[0]);
        if (iferror > 0)
        {
            
        }
        else
        {
            SaveChildDetails(dtEmp[0]);
            SaverentDetails(dtEmp[1]);
            SaveSectionDetails(dtEmp[2]);
            SavePer_salDetails(dtEmp[3]);
            SaveLetOutDetails(dtEmp[4]);
           // Common.Console.Output.Show("Employee information uploaded successfully.");
        }
    }


    #region declaration Details
    private void SavedeclarationDetails(DataTable dt)
    {
        Decimal ramnt = 0, aamnt = 0, namnt = 0;
        int nchild = 0;

        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            nchild = convert_nochild(dt.Rows[i]["children"].ToString()) * 12;
            decimal rent = convert_decimalamnt(dt.Rows[i]["rent"].ToString());
            ramnt = (rent) + (rent) + (rent) + (rent) + (rent) + (rent) + (rent) + (rent) + (rent) + (rent) + (rent) + (rent);
            aamnt = aamnt + convert_decimalamnt(dt.Rows[i]["80C"].ToString()) + convert_decimalamnt(dt.Rows[i]["80CCC"].ToString()) + convert_decimalamnt(dt.Rows[i]["80CCD"].ToString()) + convert_decimalamnt(dt.Rows[i]["80D"].ToString()) +
                    convert_decimalamnt(dt.Rows[i]["80E"].ToString()) + convert_decimalamnt(dt.Rows[i]["80DD"].ToString()) + convert_decimalamnt(dt.Rows[i]["80G"].ToString()) + convert_decimalamnt(dt.Rows[i]["80CF"].ToString());

            try
            {
                if (dt.Rows[i]["Empcode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["Empcode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_payroll_employee_declaration set ";
                        if (dt.Rows[i]["Financialyr"].ToString().Trim() != "")
                        {
                            Query = Query + " financialyr =  '" + dt.Rows[i]["Financialyr"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["metro"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",metro = '" + dt.Rows[i]["metro"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "metro = '" + dt.Rows[i]["metro"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["rent"].ToString().Trim() != "")
                        {                          

                            if (First == 1)
                                Query = Query + ",rent = '" + ramnt.ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "rent = '" + ramnt.ToString().Trim() + "'";
                                First = 1;
                            }
                        }



                        if (dt.Rows[i]["children"].ToString().Trim() != "")
                        {
                          
                            if (First == 1)
                                Query = Query + ",children = '" + nchild.ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "children = '" + nchild.ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (aamnt.ToString() != "")
                        {
                            if (First == 1)
                                Query = Query + ",chapter6A = " + aamnt.ToString().Trim();
                            else
                            {
                                Query = Query + "chapter6A = " + aamnt.ToString().Trim();
                                First = 1;
                            }

                        }
                        if (dt.Rows[i]["NSC"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",nsc = " + dt.Rows[i]["NSC"].ToString().Trim();
                            else
                            {
                                Query = Query + "nsc = " + dt.Rows[i]["NSC"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["hself_occupied"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",hself_occupied = " + dt.Rows[i]["hself_occupied"].ToString().Trim();
                            else
                            {
                                Query = Query + "hself_occupied = " + dt.Rows[i]["hself_occupied"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["hloan_borrowed"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",hloan_borrowed = " + dt.Rows[i]["hloan_borrowed"].ToString().Trim();
                            else
                            {
                                Query = Query + "hloan_borrowed = " + dt.Rows[i]["hloan_borrowed"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["interest_house"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",interest_house = " + dt.Rows[i]["interest_house"].ToString().Trim();
                            else
                            {
                                Query = Query + " interest_house = " + dt.Rows[i]["interest_house"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["80C"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80C = " + dt.Rows[i]["80C"].ToString().Trim();
                            else
                            {
                                Query = Query + "80C = " + dt.Rows[i]["80C"].ToString().Trim();
                                First = 1;
                            }
                        }



                        if (dt.Rows[i]["80CCC"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80CCC = " + dt.Rows[i]["80CCC"].ToString().Trim();
                            else
                            {
                                Query = Query + "80CCC = " + dt.Rows[i]["80CCC"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["80CCD"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80CCD = '" + dt.Rows[i]["80CCD"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "80CCD = '" + dt.Rows[i]["80CCD"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["80D"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80D = '" + dt.Rows[i]["80D"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "80D = '" + dt.Rows[i]["80D"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["80E"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80E = '" + dt.Rows[i]["80E"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "80E = '" + dt.Rows[i]["80E"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["80DD"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80DD = '" + dt.Rows[i]["80DD"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "80DD = '" + dt.Rows[i]["80DD"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["80G"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80G = '" + dt.Rows[i]["80G"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "80G = '" + dt.Rows[i]["80G"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["80CF"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",80CF = '" + dt.Rows[i]["80CF"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "80CF = '" + dt.Rows[i]["80CF"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["status"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",status = '" + dt.Rows[i]["status"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "status = '" + dt.Rows[i]["status"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["otherCity"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",OtherCity = '" + dt.Rows[i]["otherCity"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "OtherCity = '" + dt.Rows[i]["otherCity"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        Query = Query + " where empcode = '" + dt.Rows[i]["Empcode"].ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // if not exists


                        SqlParameter[] p = new SqlParameter[20];

                        p[0] = new SqlParameter("@financialyr", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Financialyr"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["Financialyr"].ToString().Trim();

                        }

                        p[1] = new SqlParameter("@metro", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["metro"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["metro"].ToString().Trim();
                        }

                        p[2] = new SqlParameter("@rent", SqlDbType.VarChar, 50);
                        if (ramnt.ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = ramnt.ToString().Trim();
                        }

                        p[3] = new SqlParameter("@children", SqlDbType.VarChar, 50);
                        if (nchild.ToString() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = nchild.ToString().Trim();

                        }
                        p[4] = new SqlParameter("@chapter6A", SqlDbType.VarChar, 50);
                        if (aamnt.ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[4].Value = aamnt.ToString().Trim();
                        }
                        p[5] = new SqlParameter("@nsc", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["NSC"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["NSC"].ToString().Trim();

                        }
                        p[6] = new SqlParameter("@hself_occupied", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["hself_occupied"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["hself_occupied"].ToString().Trim();
                        }
                        p[7] = new SqlParameter("@hloan_borrowed", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["hloan_borrowed"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["hloan_borrowed"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@80C", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80C"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["80C"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@80CCC", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80CCC"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["80CCC"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@80CCD", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80CCD"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["80CCD"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@80D", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80D"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["80D"].ToString().Trim();
                        }
                        p[12] = new SqlParameter("@80E", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80E"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["80E"].ToString().Trim();
                        }
                        p[13] = new SqlParameter("@80DD", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80DD"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["80DD"].ToString().Trim();
                        }
                        p[14] = new SqlParameter("@80G", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80G"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["80G"].ToString().Trim();
                        }
                        p[15] = new SqlParameter("@interest_house", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["interest_house"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["interest_house"].ToString().Trim();
                        }

                        p[16] = new SqlParameter("@80cf", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["80CF"].ToString().Trim() == "")
                        {
                            p[16].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[16].Value = dt.Rows[i]["80CF"].ToString().Trim();
                        }

                        p[17] = new SqlParameter("@status", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["status"].ToString().Trim() == "")
                        {
                            p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[17].Value = dt.Rows[i]["status"].ToString().Trim();
                        }


                        p[18] = new SqlParameter("@otherCity", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["otherCity"].ToString().Trim() == "")
                        {
                            p[18].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[18].Value = dt.Rows[i]["otherCity"].ToString().Trim();
                        }

                        p[19] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                        {
                            p[19].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[19].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                        }

                        a = (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_declaration_upload", p)));
                     // a =  DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_declaration_upload", p);

                        //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Rent Details
    private void SaverentDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
          
            decimal rent = convert_decimalamnt(dt.Rows[i]["jan_amnt"].ToString()) +  convert_decimalamnt(dt.Rows[i]["feb_amnt"].ToString()) +  convert_decimalamnt(dt.Rows[i]["mar_amnt"].ToString()) +  convert_decimalamnt(dt.Rows[i]["apr_amnt"].ToString())+ convert_decimalamnt(dt.Rows[i]["may_amnt"].ToString()) + convert_decimalamnt(dt.Rows[i]["jun_amnt"].ToString()) + convert_decimalamnt(dt.Rows[i]["jul_amnt"].ToString())+ convert_decimalamnt(dt.Rows[i]["aug_amnt"].ToString()) +
                 convert_decimalamnt(dt.Rows[i]["sep_amnt"].ToString()) +  convert_decimalamnt(dt.Rows[i]["oct_amnt"].ToString())+ convert_decimalamnt(dt.Rows[i]["nov_amnt"].ToString())+ convert_decimalamnt(dt.Rows[i]["dec_amnt"].ToString());

            try
            {
                if (dt.Rows[i]["Empcode"].ToString().Trim() != "")
                {
                    if (refnoExists(dt.Rows[i]["Empcode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_payroll_employee_rentpaid_detail set ";
                        if (dt.Rows[i]["jan_amnt"].ToString().Trim() != "")
                        {
                            Query = Query + " jan_amnt =  '" + dt.Rows[i]["jan_amnt"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["feb_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",feb_amnt = '" + dt.Rows[i]["feb_amnt"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "feb_amnt = '" + dt.Rows[i]["feb_amnt"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["mar_amnt"].ToString().Trim() != "")
                        {

                            if (First == 1)
                                Query = Query + ",mar_amnt = '" + dt.Rows[i]["mar_amnt"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "mar_amnt = '" + dt.Rows[i]["mar_amnt"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }



                        if (dt.Rows[i]["apr_amnt"].ToString().Trim() != "")
                        {

                            if (First == 1)
                                Query = Query + ",apr_amnt = '" + dt.Rows[i]["apr_amnt"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "apr_amnt = '" + dt.Rows[i]["apr_amnt"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["may_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",may_amnt = '" + dt.Rows[i]["may_amnt"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "may_amnt = '" + dt.Rows[i]["may_amnt"].ToString().Trim() + "'";
                                First = 1;
                            }

                        }
                        if (dt.Rows[i]["jun_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",jun_amnt = " + dt.Rows[i]["jun_amnt"].ToString().Trim();
                            else
                            {
                                Query = Query + "jun_amnt = " + dt.Rows[i]["jun_amnt"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["jul_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",jul_amnt = " + dt.Rows[i]["jul_amnt"].ToString().Trim();
                            else
                            {
                                Query = Query + "jul_amnt = " + dt.Rows[i]["jul_amnt"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["aug_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",aug_amnt = " + dt.Rows[i]["aug_amnt"].ToString().Trim();
                            else
                            {
                                Query = Query + "aug_amnt = " + dt.Rows[i]["aug_amnt"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["sep_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",sep_amnt = " + dt.Rows[i]["sep_amnt"].ToString().Trim();
                            else
                            {
                                Query = Query + " sep_amnt = " + dt.Rows[i]["sep_amnt"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["oct_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",oct_amnt = " + dt.Rows[i]["oct_amnt"].ToString().Trim();
                            else
                            {
                                Query = Query + "oct_amnt = " + dt.Rows[i]["oct_amnt"].ToString().Trim();
                                First = 1;
                            }
                        }



                        if (dt.Rows[i]["nov_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",nov_amnt = " + dt.Rows[i]["nov_amnt"].ToString().Trim();
                            else
                            {
                                Query = Query + "nov_amnt = " + dt.Rows[i]["nov_amnt"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["dec_amnt"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",dec_amnt = '" + dt.Rows[i]["dec_amnt"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "dec_amnt = '" + dt.Rows[i]["dec_amnt"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        Query = Query + " where ref_no = '" + a.ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // if not exists


                        SqlParameter[] p = new SqlParameter[15];

                        p[0] = new SqlParameter("@jan_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["jan_amnt"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["jan_amnt"].ToString().Trim();

                        }

                        p[1] = new SqlParameter("@feb_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["feb_amnt"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["feb_amnt"].ToString().Trim();
                        }

                        p[2] = new SqlParameter("@mar_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["mar_amnt"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["mar_amnt"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@apr_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["apr_amnt"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["apr_amnt"].ToString().Trim();

                        }
                        p[4] = new SqlParameter("@may_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["may_amnt"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["may_amnt"].ToString().Trim();
                        }
                        p[5] = new SqlParameter("@jun_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["jun_amnt"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["jun_amnt"].ToString().Trim();

                        }
                        p[6] = new SqlParameter("@jul_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["jul_amnt"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["jul_amnt"].ToString().Trim();
                        }
                        p[7] = new SqlParameter("@aug_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["aug_amnt"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["aug_amnt"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@sep_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["sep_amnt"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["sep_amnt"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@oct_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["oct_amnt"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["oct_amnt"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@nov_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["nov_amnt"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["nov_amnt"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@dec_amnt", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["dec_amnt"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["dec_amnt"].ToString().Trim();
                        }

                        p[12] = new SqlParameter("@ref_no", SqlDbType.VarChar, 50);
                        if (a.ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[12].Value = a.ToString().Trim();
                        }

                        p[13] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                        if (a.ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[13].Value = Session["name"].ToString();
                        }

                        p[14] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_rent_detail", p);

                        //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                //Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region child Details
    private void SaveChildDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["Empcode"].ToString().Trim() != "")
                {
                    if (refnoExists_child(dt.Rows[i]["Empcode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_payroll_employee_childrenstudying_detail set ";

                        if (dt.Rows[i]["children"].ToString().Trim() != "")
                        {
                            if (First == 1)
                            {
                                Query = Query + ",feb_no = '" + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + " jan_no =  '" + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "feb_no = '" + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "mar_no = '" + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "apr_no = '" + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "may_no = '" + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "jun_no = " + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "jul_no = " + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "aug_no = " + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + " sep_no = " + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "oct_no = " + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "nov_no = " + dt.Rows[i]["children"].ToString().Trim() + "'";
                                Query = Query + "dec_no = '" + dt.Rows[i]["children"].ToString().Trim() + "'";
                            }
                            else
                            {
                                Query = Query + " jan_no =  '" + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "feb_no = '" + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "mar_no = '" + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "apr_no = '" + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "may_no = '" + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "jun_no = " + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "jul_no = " + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "aug_no = " + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + " sep_no = " + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "oct_no = " + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "nov_no = " + dt.Rows[i]["children"].ToString().Trim();
                                Query = Query + "dec_no = '" + dt.Rows[i]["children"].ToString().Trim();
                                First = 1;
                            }
                        }
                        Query = Query + " where ref_no = '" + a.ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // if not exists


                        SqlParameter[] p = new SqlParameter[15];

                        p[0] = new SqlParameter("@jan_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["children"].ToString().Trim();

                        }

                        p[1] = new SqlParameter("@feb_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["children"].ToString().Trim();
                        }

                        p[2] = new SqlParameter("@mar_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["children"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@apr_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["children"].ToString().Trim();

                        }
                        p[4] = new SqlParameter("@may_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["children"].ToString().Trim();
                        }
                        p[5] = new SqlParameter("@jun_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["children"].ToString().Trim();

                        }
                        p[6] = new SqlParameter("@jul_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["children"].ToString().Trim();
                        }
                        p[7] = new SqlParameter("@aug_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["children"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@sep_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["children"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@oct_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["children"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@nov_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["children"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@dec_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["children"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["children"].ToString().Trim();
                        }

                        p[12] = new SqlParameter("@ref_no", SqlDbType.VarChar, 50);
                        if (a.ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[12].Value = a.ToString().Trim();
                        }

                        p[13] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                        if (a.ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[13].Value = Session["name"].ToString();
                        }

                        p[14] = new SqlParameter("empcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["Empcode"].ToString().Trim();

                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_children_detail", p);

                        //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                //Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region 6A Details
    private void SaveSectionDetails(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["Empcode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["Empcode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from tbl_payroll_employee_6A_detail where empcode = '" + dt.Rows[i]["Empcode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "    Method:  Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["Empcode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["Empcode"].ToString().Trim()))
                    {
                        SqlParameter[] p = new SqlParameter[5];

                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@section_name", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Section_Name"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Section_Name"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@section_detail", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["Section_details"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Section_details"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@a_amount", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Amount"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["Amount"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@ref_no", SqlDbType.VarChar, 50);
                        if (a.ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = a.ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_6A_detail_upload", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method:                 Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }

    #endregion

    #region Pervious Salary Details
    private void SavePer_salDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["Empcode"].ToString().Trim() != "")
                {
                    if (EmployeeExists_Salary(dt.Rows[i]["Empcode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_payroll_taxdeclaration_pre_empsalary set ";
                        if (dt.Rows[i]["Income_after_Section_10"].ToString().Trim() != "")
                        {
                            Query = Query + " income_after_exemption =  '" + dt.Rows[i]["Income_after_Section_10"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["Professional_Tax_Paid"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",prof_tax_paid = '" + dt.Rows[i]["Professional_Tax_Paid"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "prof_tax_paid = '" + dt.Rows[i]["Professional_Tax_Paid"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Provident_Fund_Paid"].ToString().Trim() != "")
                        {

                            if (First == 1)
                                Query = Query + ",fund_paid = '" + dt.Rows[i]["Provident_Fund_Paid"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "fund_paid = '" + dt.Rows[i]["Provident_Fund_Paid"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Income_Tax_Paid"].ToString().Trim() != "")
                        {

                            if (First == 1)
                                Query = Query + ",tax_paid = '" + dt.Rows[i]["Income_Tax_Paid"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "tax_paid = '" + dt.Rows[i]["Income_Tax_Paid"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        Query = Query + " where ref_no = '" + a.ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // if not exists
                        SqlParameter[] p = new SqlParameter[6];

                        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["Empcode"].ToString().Trim();

                        }

                        p[1] = new SqlParameter("@income_after_exemption", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Income_after_Section_10"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Income_after_Section_10"].ToString().Trim();
                        }

                        p[2] = new SqlParameter("@prof_tax_paid", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Professional_Tax_Paid"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Professional_Tax_Paid"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@fund_paid", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Provident_Fund_Paid"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["Provident_Fund_Paid"].ToString().Trim();

                        }
                        p[4] = new SqlParameter("@tax_paid", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Income_Tax_Paid"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["Income_Tax_Paid"].ToString().Trim();
                        }
                        p[5] = new SqlParameter("@ref_no", SqlDbType.VarChar, 50);
                        if (a.ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[5].Value = a.ToString().Trim();

                        }


                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_taxdeclaration_pre_empsalary", p);

                        //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                //Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Let Out Details
    private void SaveLetOutDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["Empcode"].ToString().Trim() != "")
                {
                    if (refnoExists_letout(dt.Rows[i]["Empcode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_payroll_declaration_letout set ";
                        if (dt.Rows[i]["Rent_Received"].ToString().Trim() != "")
                        {
                            Query = Query + " Rent_Received =  '" + dt.Rows[i]["Rent_Received"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["Less_paid"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",less_paid = '" + dt.Rows[i]["Less_paid"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "less_paid = '" + dt.Rows[i]["Less_paid"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Tax_housing"].ToString().Trim() != "")
                        {

                            if (First == 1)
                                Query = Query + ",tax_housing = '" + dt.Rows[i]["Tax_housing"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "tax_housing = '" + dt.Rows[i]["Tax_housing"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        Query = Query + " where ref_no = '" + a.ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // if not exists
                        SqlParameter[] p = new SqlParameter[5];

                        p[0] = new SqlParameter("@Rent_Received", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Rent_Received"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["Rent_Received"].ToString().Trim();

                        }

                        p[1] = new SqlParameter("@less_paid", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Less_paid"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Less_paid"].ToString().Trim();
                        }

                        p[2] = new SqlParameter("@tax_housing", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Tax_housing"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Tax_housing"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@ref_no", SqlDbType.VarChar, 50);
                        if (a.ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[3].Value = a.ToString().Trim();

                        }

                        p[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Empcode"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["Empcode"].ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_declaration_letout", p);

                        //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                //Log("Employee Code : " + dt.Rows[i]["Empcode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Upload Excel Document
    protected bool UploadDocument(ref string version, ref string path)
    {
        try
        {
            string file_name, fn, ftype;
            bool flag = false;
            if (flEmployee.PostedFile.FileName.ToString() != "")
            {
                fn = System.IO.Path.GetFileName(flEmployee.PostedFile.FileName.ToString());
                ftype = System.IO.Path.GetExtension(fn);
                switch (ftype)
                {
                    case ".xls":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(flEmployee.PostedFile.FileName);
                            flEmployee.PostedFile.SaveAs(file_name);
                            ViewState.Add("file_name", fn.ToString());
                            flag = true;
                            version = "4.0";
                            path = file_name;
                            break;
                        }
                    case ".xlsx":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(flEmployee.PostedFile.FileName);
                            //  file_name = Server.MapPath(".") + "\\upload\\" + flEmployee.FileName + DateTime.Now.ToString();
                            flEmployee.PostedFile.SaveAs(file_name);
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

    protected Decimal convert_decimalamnt(string str)
    {
        Decimal damnt;
        if (str == "")
            damnt = 0;
        else
            damnt = Convert.ToDecimal(str);
        return damnt;
    }

    protected int convert_nochild(string str2)
    {
        int n;
        if (str2 == "")
            n = 0;
        else
            n = Convert.ToInt16(str2);
        return n;
    }

    #region EmployeeExists
    private bool EmployeeExists(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_EmployeeExists_declaration", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool refnoExists(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_RefExists_declaration", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool refnoExists_child(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_RefExists_child", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool EmployeeExists_Salary(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_EmployeeExists_declaration_salary", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool refnoExists_letout(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_RefExists_letout", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }
    #endregion
}