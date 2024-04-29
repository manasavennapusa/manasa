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

//  ***Guru***
// Code written by Raghavendra CN - 12-Jul-2014


public partial class EDB_Details_upload : System.Web.UI.Page
{
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
                DataTable[] dt = new DataTable[10];

                dt[0] = GetExcelDate("SELECT * FROM [Employee_job_Details$]", ConnectionString);
                dt[1] = GetExcelDate("SELECT * FROM [Employee_Payroll_Details$]", ConnectionString);
                dt[2] = GetExcelDate("SELECT * FROM [Educational_Qualification$]", ConnectionString);
                dt[3] = GetExcelDate("SELECT * FROM [Professional_Qualification$]", ConnectionString);
                dt[4] = GetExcelDate("SELECT * FROM [Experience_Details$]", ConnectionString);
                dt[5] = GetExcelDate("SELECT * FROM [TraingDetails$]", ConnectionString);
                dt[6] = GetExcelDate("SELECT * FROM [PersonalDetails$]", ConnectionString);
                dt[7] = GetExcelDate("SELECT * FROM [ContactDetails$]", ConnectionString);
                dt[8] = GetExcelDate("SELECT * FROM [Approver_Details$]", ConnectionString);
                dt[9] = GetExcelDate("SELECT * FROM [EmgContactDetails$]", ConnectionString);
                flEmployee.Dispose();
                InsertEmployeeDetails(dt);
                if (iferror > 0)
                {
                    Common.Console.Output.Show("Employee information Not uploaded successfully.Please Contact Administrator for Error.");
                }
                else
                {
                    Common.Console.Output.Show("Uploaded Successfully");
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
        if (Validate(dtEmp[0]))
        {
            SaveJobDetails(dtEmp[0]);
            SavePayrollDetails(dtEmp[1]);
            SaveEducationQualificationDetails(dtEmp[2]);
            SaveProfessionalQualificationDetails(dtEmp[3]);
            SaveExperienceDetails(dtEmp[4]);
            SaveTrainingDetails(dtEmp[5]);
            SavePersonalDetails(dtEmp[6]);
            SaveContactDetails(dtEmp[7]);
            SaveApproverDetails(dtEmp[8]);
            SaveEmgContactDetails(dtEmp[9]);
        }
    }

    #region Emg. Contact Details
    private void SaveEmgContactDetails(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    string sqlstr1 = "delete from tbl_intranet_employee_emgcontact_details where empcode ='" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";
                    int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);

                    string sqlstr = @"insert into tbl_intranet_employee_emgcontact_details(empcode,emg_name ,emg_relation,emg_contactno,emg_landlineno ) values('" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "','" + dt.Rows[i]["EmergencyContactName"].ToString().Trim() + "','" + dt.Rows[i]["EmergencyRelation"].ToString().Trim() + "','" + dt.Rows[i]["EmergencyContactNo"].ToString().Trim() + "','" + dt.Rows[i]["EmergencyLandLineNo"].ToString().Trim() + "')";
                    int Flag1 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Emergency Contact Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }
    #endregion

    #region Save Approver Details
    private void SaveApproverDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (ApproversExist(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        Query = "update tbl_employee_approvers set ";

                        if (dt.Rows[i]["AccountManager"].ToString().Trim() != "")
                        {
                            if (First == 1)
                            {
                                Query = Query + " app_finance =  '" + dt.Rows[i]["AccountManager"].ToString().Trim() + "'";
                            }
                            else
                            {
                                Query = Query + " app_finance =  '" + dt.Rows[i]["AccountManager"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Admin"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_admin = '" + dt.Rows[i]["Admin"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_admin = '" + dt.Rows[i]["Admin"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["LineManager"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_reportingmanager = '" + dt.Rows[i]["LineManager"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_reportingmanager = '" + dt.Rows[i]["LineManager"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Management/MD"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_management = '" + dt.Rows[i]["Management/MD"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_management = '" + dt.Rows[i]["Management/MD"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["HRTA"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_hr = '" + dt.Rows[i]["HRTA"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "app_hr = '" + dt.Rows[i]["HRTA"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["BusinessHead"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_businesshead = '" + dt.Rows[i]["BusinessHead"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_businesshead = '" + dt.Rows[i]["BusinessHead"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["HRBP"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_hrd = '" + dt.Rows[i]["HRBP"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_hrd = '" + dt.Rows[i]["HRBP"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["DepartmentalClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_department = '" + dt.Rows[i]["DepartmentalClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_department = '" + dt.Rows[i]["DepartmentalClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_generaladmin = '" + dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_generaladmin = '" + dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_accountsdept = '" + dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_accountsdept = '" + dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_networkdept = '" + dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_networkdept = '" + dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_hr = '" + dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_hr = '" + dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_useraccountdeletion = '" + dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_useraccountdeletion = '" + dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["DottedlineManager"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_dotted_linemanager = '" + dt.Rows[i]["DottedlineManager"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_dotted_linemanager = '" + dt.Rows[i]["DottedlineManager"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["HRC&B"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_hr_cb = '" + dt.Rows[i]["HRC&B"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_hr_cb = '" + dt.Rows[i]["HRC&B"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        Query = Query + ",update_by = '" + Session["empcode"].ToString().Trim() + "'";
                        Query = Query + ",update_date = '" + DateTime.Now.ToString() + "'";


                        Query = Query + " where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";
                    }
                    else
                    {

                        SqlParameter[] p = new SqlParameter[17];


                        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@app_finance", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["AccountManager"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["AccountManager"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@app_admin", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Admin"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Admin"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@app_reportingmanager", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["LineManager"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["LineManager"].ToString().Trim();

                        }
                        p[4] = new SqlParameter("@app_management", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Management/MD"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["Management/MD"].ToString().Trim();
                        }
                       
                        
                        p[5] = new SqlParameter("@app_hr", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRTA"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["HRTA"].ToString().Trim();

                        }

                        p[6] = new SqlParameter("@app_businesshead", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BusinessHead"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["BusinessHead"].ToString().Trim();
                        }
                       
                        p[7] = new SqlParameter("@app_hrd", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRBP"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["HRBP"].ToString().Trim();
                        }
                        
                        p[8] = new SqlParameter("@clr_department", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DepartmentalClearance"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["DepartmentalClearance"].ToString().Trim();

                        }


                        p[9] = new SqlParameter("@clr_generaladmin", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim();

                        }
                        
                        p[10] = new SqlParameter("@clr_accountsdept", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim();

                        }
                       
                        p[11] = new SqlParameter("@clr_networkdept", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim();
                        }



                        //Output.AssignParameter(sqlparm1, 12, "@clr_hr", "String", 50, dt.Rows[i]["HRDepartmentClearance"].ToString().Trim());
                        //Output.AssignParameter(sqlparm1, 13, "@clr_useraccountdeletion", "String", 50, dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim());
                        //Output.AssignParameter(sqlparm1, 14, "@create_by", "String", 50, Session["empcode"].ToString());
                        //Output.AssignParameter(sqlparm1, 15, "@app_dotted_linemanager", "String", 50, dt.Rows[i]["DottedlineManager"].ToString().Trim());
                        //Output.AssignParameter(sqlparm1, 16, "@app_hr_cb", "String", 50, dt.Rows[i]["HRC&B"].ToString().Trim());

                        p[12] = new SqlParameter("@clr_hr", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["HRDepartmentClearance"].ToString().Trim();
                        }
                        p[13] = new SqlParameter("@clr_useraccountdeletion", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim();
                        }

                        p[14] = new SqlParameter("@app_dotted_linemanager", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DottedlineManager"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["DottedlineManager"].ToString().Trim();
                        }

                        p[15] = new SqlParameter("@app_hr_cb", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRC&B"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["HRC&B"].ToString().Trim();
                        }

                        p[16] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
                        p[16].Value = Session["empcode"].ToString().Trim();


                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_approvers_details", p);

                    }
                }
            }
            catch (Exception ex)
            {
                Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                throw ex;
            }
        }
    }
    #endregion

    private void ApproversEx(DataTable dt)
    {
         string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (ApproversExist(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        Query = "update tbl_intranet_employee_payrollDetails set ";
                       
                        if (dt.Rows[i]["AccountManager"].ToString().Trim() != "")
                        {
                            if (First == 1)
                            {
                                Query = Query + " app_finance =  '" + dt.Rows[i]["AccountManager"].ToString().Trim() + "'";
                            }
                            else
                            {
                                Query = Query + " app_finance =  '" + dt.Rows[i]["AccountManager"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Admin"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_admin = '" + dt.Rows[i]["Admin"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_admin = '" + dt.Rows[i]["Admin"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["LineManager"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_reportingmanager = '" + dt.Rows[i]["LineManager"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_reportingmanager = '" + dt.Rows[i]["LineManager"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Management/MD"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_management = '" + dt.Rows[i]["Management/MD"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_management = '" + dt.Rows[i]["Management/MD"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["HRTA"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_hr = '" + dt.Rows[i]["HRTA"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "app_hr = '" + dt.Rows[i]["HRTA"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["BusinessHead"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_businesshead = '" + dt.Rows[i]["BusinessHead"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_businesshead = '" + dt.Rows[i]["BusinessHead"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                       
                        if (dt.Rows[i]["HRBP"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_hrd = '" + dt.Rows[i]["HRBP"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_hrd = '" + dt.Rows[i]["HRBP"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        
                        if (dt.Rows[i]["DepartmentalClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_department = '" + dt.Rows[i]["DepartmentalClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_department = '" + dt.Rows[i]["DepartmentalClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        
                        if (dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_generaladmin = '" + dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_generaladmin = '" + dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_accountsdept = '" + dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_accountsdept = '" + dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_networkdept = '" + dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_networkdept = '" + dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_hr = '" + dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_hr = '" + dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",clr_useraccountdeletion = '" + dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " clr_useraccountdeletion = '" + dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                       if (dt.Rows[i]["DottedlineManager"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_dotted_linemanager = '" + dt.Rows[i]["DottedlineManager"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_dotted_linemanager = '" + dt.Rows[i]["DottedlineManager"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["HRC&B"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",app_hr_cb = '" + dt.Rows[i]["HRC&B"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " app_hr_cb = '" + dt.Rows[i]["HRC&B"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                            Query = Query + ",update_by = '" + Session["empcode"].ToString().Trim() + "'";
                            Query = Query + ",update_date = '" + DateTime.Now.ToString() + "'";

                        
                        Query = Query + " where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";
                    }
                    else
                    {
                       
                        SqlParameter[] p = new SqlParameter[16];


                        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@app_finance", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["AccountManager"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["AccountManager"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@app_admin", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Admin"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Admin"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@app_reportingmanager", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["LineManager"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["LineManager"].ToString().Trim();

                        }
                        p[4] = new SqlParameter("@app_management", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Management/MD"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["Management/MD"].ToString().Trim();
                        }
                        p[5] = new SqlParameter("@app_hr", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRTA"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["HRTA"].ToString().Trim();

                        }

                        p[6] = new SqlParameter("@app_businesshead", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BusinessHead"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["BusinessHead"].ToString().Trim();
                        }
                        p[7] = new SqlParameter("@app_hrd", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRBP"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["HRBP"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@clr_department", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DepartmentalClearance"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["DepartmentalClearance"].ToString().Trim();

                        }



                        p[9] = new SqlParameter("@clr_generaladmin", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["GeneralAdministartionClearance"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@clr_accountsdept", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["AccountsDepartmentClearance"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@clr_networkdept", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["NetworkAdministartionClearance"].ToString().Trim();
                        }


                       
                        //Output.AssignParameter(sqlparm1, 12, "@clr_hr", "String", 50, dt.Rows[i]["HRDepartmentClearance"].ToString().Trim());
                        //Output.AssignParameter(sqlparm1, 13, "@clr_useraccountdeletion", "String", 50, dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim());
                        //Output.AssignParameter(sqlparm1, 14, "@create_by", "String", 50, Session["empcode"].ToString());
                        //Output.AssignParameter(sqlparm1, 15, "@app_dotted_linemanager", "String", 50, dt.Rows[i]["DottedlineManager"].ToString().Trim());
                        //Output.AssignParameter(sqlparm1, 16, "@app_hr_cb", "String", 50, dt.Rows[i]["HRC&B"].ToString().Trim());

                        p[12] = new SqlParameter("@clr_hr", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRDepartmentClearance"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["HRDepartmentClearance"].ToString().Trim();
                        }
                        p[13] = new SqlParameter("@clr_useraccountdeletion", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["UserAccountDeletionRequest"].ToString().Trim();
                        }
                       
                        p[14] = new SqlParameter("@app_dotted_linemanager", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DottedlineManager"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["DottedlineManager"].ToString().Trim();
                        }

                        p[15] = new SqlParameter("@app_hr_cb", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["HRC&B"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["HRC&B"].ToString().Trim();
                        }

                        p[16] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
                        p[16].Value = Session["empcode"].ToString().Trim();


                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_approvers_details", p);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }


    #region Job Details
    private void SaveJobDetails(DataTable dt)
    {

        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_intranet_employee_jobDetails set ";
                        if (dt.Rows[i]["Title"].ToString().Trim() != "")
                        {
                            Query = Query + " salutation =  '" + dt.Rows[i]["Title"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["EmployeeName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_fname = '" + dt.Rows[i]["EmployeeName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "emp_fname = '" + dt.Rows[i]["EmployeeName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["EmployeeNo"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",card_no = '" + dt.Rows[i]["EmployeeNo"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "card_no = '" + dt.Rows[i]["EmployeeNo"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["LoginPassword"].ToString().Trim() != "")
                        {

                        }

                        if (dt.Rows[i]["Gender"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_gender = '" + dt.Rows[i]["Gender"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "emp_gender = '" + dt.Rows[i]["Gender"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Worklocation"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",branch_id = " + dt.Rows[i]["Worklocation"].ToString().Trim();
                            else
                            {
                                Query = Query + "branch_id = " + dt.Rows[i]["Worklocation"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Department"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",dept_id = " + dt.Rows[i]["Department"].ToString().Trim();
                            else
                            {
                                Query = Query + "dept_id = " + dt.Rows[i]["Department"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Costcenter"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",division_id = " + dt.Rows[i]["Costcenter"].ToString().Trim();
                            else
                            {
                                Query = Query + "division_id = " + dt.Rows[i]["Costcenter"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["BusinessUnit"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",broadgroupid = " + dt.Rows[i]["BusinessUnit"].ToString().Trim();
                            else
                            {
                                Query = Query + "broadgroupid = " + dt.Rows[i]["BusinessUnit"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Designation"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",degination_id = " + dt.Rows[i]["Designation"].ToString().Trim();
                            else
                            {
                                Query = Query + " degination_id = " + dt.Rows[i]["Designation"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Grade"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Grade = " + dt.Rows[i]["Grade"].ToString().Trim();
                            else
                            {
                                Query = Query + "Grade = " + dt.Rows[i]["Grade"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["EmployeeRole"].ToString().Trim() != "")
                        {

                        }

                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_status = " + dt.Rows[i]["EmployeeStatus"].ToString().Trim();
                            else
                            {
                                Query = Query + "emp_status = " + dt.Rows[i]["EmployeeStatus"].ToString().Trim();
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Dateofjoining"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_doj = '" + dt.Rows[i]["Dateofjoining"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "emp_doj = '" + dt.Rows[i]["Dateofjoining"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["OfficialMobileNo"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",official_mob_no = '" + dt.Rows[i]["OfficialMobileNo"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "official_mob_no = '" + dt.Rows[i]["OfficialMobileNo"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["OfficalEmailId"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",official_email_id = '" + dt.Rows[i]["OfficalEmailId"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "official_email_id = '" + dt.Rows[i]["OfficalEmailId"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Ext_Number"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",ext_number = '" + dt.Rows[i]["Ext_Number"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "ext_number = '" + dt.Rows[i]["Ext_Number"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        //  if (dt.Rows[i]["ReportingManager"].ToString().Trim() != "")
                        //   {
                        if (First == 1)
                            Query = Query + ",supervisorcode = '0'";
                        else
                        {
                            Query = Query + "supervisorcode = '0'";
                            First = 1;
                        }
                        //   }

                        //  if (dt.Rows[i]["FunctionalManager"].ToString().Trim() != "")
                        //  {
                        if (First == 1)
                            Query = Query + ",corporatereportingcode = '0'";
                        else
                        {
                            Query = Query + "corporatereportingcode = '0'";
                            First = 1;
                        }
                        //   }

                        //if (dt.Rows[i]["UnitHead"].ToString().Trim() != "")
                        // {
                        if (First == 1)
                            Query = Query + ",hodcode ='0'";
                        else
                        {
                            Query = Query + "hodcode = '0'";
                            First = 1;
                        }
                        // }

                        if (dt.Rows[i]["DateofLeaving"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_doleaving = '" + dt.Rows[i]["DateofLeaving"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "emp_doleaving = '" + dt.Rows[i]["DateofLeaving"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["ReasonforLeaving"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",reason_leaving = '" + dt.Rows[i]["ReasonforLeaving"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "reason_leaving = '" + dt.Rows[i]["ReasonforLeaving"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["EmployeeType"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",employee_type = '" + dt.Rows[i]["EmployeeType"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "employee_type = '" + dt.Rows[i]["EmployeeType"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["EmployeeSubType"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",sub_emp_type = '" + dt.Rows[i]["EmployeeSubType"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "sub_emp_type = '" + dt.Rows[i]["EmployeeSubType"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["DepartmentType"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",dep_type_id = '" + dt.Rows[i]["DepartmentType"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "dep_type_id = '" + dt.Rows[i]["DepartmentType"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "1")
                            {
                                if (dt.Rows[i]["ConfirmationDate"].ToString().Trim() != "")
                                {
                                    if (First == 1)
                                        Query = Query + ",confirmationdate = '" + dt.Rows[i]["ConfirmationDate"].ToString().Trim() + "'";
                                    else
                                    {
                                        Query = Query + "confirmationdate = '" + dt.Rows[i]["ConfirmationDate"].ToString().Trim() + "'";
                                        First = 1;
                                    }
                                }
                            }
                        }
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "2")
                            {
                                if (dt.Rows[i]["ProbationEndDate"].ToString().Trim() != "")
                                {
                                    if (First == 1)
                                        Query = Query + ",confirmationdate = '" + dt.Rows[i]["ProbationEndDate"].ToString().Trim() + "'";
                                    else
                                    {
                                        Query = Query + "confirmationdate = '" + dt.Rows[i]["ProbationEndDate"].ToString().Trim() + "'";
                                        First = 1;
                                    }
                                }
                            }
                        }
                        Query = Query + " where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";

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


                        SqlParameter[] p = new SqlParameter[27];


                        p[0] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Title"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["Title"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeName"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["EmployeeName"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeNo"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["EmployeeNo"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@LoginPassword", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["LoginPassword"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            int saltSize = 5;
                            string salt = CreateSalt(saltSize);
                            string passwordHash = CreatePasswordHash(dt.Rows[i]["LoginPassword"].ToString().Trim(), salt);
                            p[3].Value = passwordHash.ToString().Trim();
                        }

                        p[4] = new SqlParameter("@Gender", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Gender"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = p[4].Value = dt.Rows[i]["Gender"].ToString().Trim();

                        }
                        p[5] = new SqlParameter("@Worklocation", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Worklocation"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["Worklocation"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@Department", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Department"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["Department"].ToString().Trim();

                        }
                        p[7] = new SqlParameter("@Costcenter", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Costcenter"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["Costcenter"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@BusinessUnit", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BusinessUnit"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["BusinessUnit"].ToString().Trim();
                        }
                        p[9] = new SqlParameter("@Designation", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Designation"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["Designation"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@Grade", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Grade"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["Grade"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@EmployeeRole", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeRole"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["EmployeeRole"].ToString().Trim();

                        }
                        p[12] = new SqlParameter("@EmployeeStatus", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["EmployeeStatus"].ToString().Trim();
                        }
                        p[13] = new SqlParameter("@Dateofjoining", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Dateofjoining"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["Dateofjoining"].ToString().Trim();
                        }
                        p[14] = new SqlParameter("@OfficialMobileNo", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["OfficialMobileNo"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["OfficialMobileNo"].ToString().Trim();
                        }
                        p[15] = new SqlParameter("@OfficalEmailId", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["OfficalEmailId"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["OfficalEmailId"].ToString().Trim();
                        }
                        p[16] = new SqlParameter("@Ext_Number", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Ext_Number"].ToString().Trim() == "")
                        {
                            p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[16].Value = dt.Rows[i]["Ext_Number"].ToString().Trim();
                        }
                        p[17] = new SqlParameter("@ReportingManager", SqlDbType.VarChar, 50);
                        //  if (dt.Rows[i]["ReportingManager"].ToString().Trim() == "")
                        //{
                        p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        // }
                        //  else
                        //  {
                        // p[17].Value = dt.Rows[i]["ReportingManager"].ToString().Trim();
                        // }
                        p[18] = new SqlParameter("@FunctionalManager", SqlDbType.VarChar, 50);
                        //  if (dt.Rows[i]["FunctionalManager"].ToString().Trim() == "")
                        //  {
                        p[18].Value = System.Data.SqlTypes.SqlString.Null;
                        //  }
                        //  else
                        //  {
                        //      p[18].Value = dt.Rows[i]["FunctionalManager"].ToString().Trim();
                        //  }
                        p[19] = new SqlParameter("@UnitHead", SqlDbType.VarChar, 50);
                        // if (dt.Rows[i]["UnitHead"].ToString().Trim() == "")
                        // {
                        p[19].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[19].Value = dt.Rows[i]["UnitHead"].ToString().Trim();
                        //}
                        p[20] = new SqlParameter("@DateofLeaving", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DateofLeaving"].ToString().Trim() == "")
                        {
                            p[20].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[20].Value = dt.Rows[i]["DateofLeaving"].ToString().Trim();
                        }

                        p[21] = new SqlParameter("@ReasonforLeaving", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ReasonforLeaving"].ToString().Trim() == "")
                        {
                            p[21].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[21].Value = dt.Rows[i]["ReasonforLeaving"].ToString().Trim();
                        }

                        p[22] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                        p[22].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();

                        p[23] = new SqlParameter("@conformationdate", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "3")
                            {
                                if (dt.Rows[i]["ConfirmationDate"].ToString().Trim() == "")
                                {
                                    p[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
                                }
                                else
                                {
                                    p[23].Value = dt.Rows[i]["ConfirmationDate"].ToString().Trim();
                                }
                            }
                            else if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "1")
                            {
                                if (dt.Rows[i]["ProbationEndDate"].ToString().Trim() == "")
                                {
                                    p[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
                                }
                                else
                                {
                                    p[23].Value = dt.Rows[i]["ProbationEndDate"].ToString().Trim();
                                }
                            }
                        }
                        else
                            p[23].Value = System.Data.SqlTypes.SqlDateTime.Null;

                        p[24] = new SqlParameter("@employee_type", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeType"].ToString().Trim() == "")
                        {
                            p[24].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[24].Value = dt.Rows[i]["EmployeeType"].ToString().Trim();
                        }

                        p[25] = new SqlParameter("@sub_emp_type", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeSubType"].ToString().Trim() == "")
                        {
                            p[25].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[25].Value = dt.Rows[i]["EmployeeSubType"].ToString().Trim();
                        }

                        p[26] = new SqlParameter("@dep_type_id", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DepartmentType"].ToString().Trim() == "")
                        {
                            p[26].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[26].Value = dt.Rows[i]["DepartmentType"].ToString().Trim();
                        }


                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_InsertJobDetails", p);

                        //lblMessage.Text = "Employee Code: " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " -> Success.";
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Payroll Details

    private void SavePayrollDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExistsPayrollDetails(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_intranet_employee_payrollDetails set ";
                        if (dt.Rows[i]["ESI_Number"].ToString().Trim() != "")
                        {
                            Query = Query + "esi_no =  '" + dt.Rows[i]["ESI_Number"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["PF_Number"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pf_no = '" + dt.Rows[i]["PF_Number"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "pf_no = '" + dt.Rows[i]["PF_Number"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                       

                        if (dt.Rows[i]["PAN_Number"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pan_no = '" + dt.Rows[i]["PAN_Number"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " pan_no = '" + dt.Rows[i]["PAN_Number"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["ESI_Dispensary"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",esi_disp = '" + dt.Rows[i]["ESI_Dispensary"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " esi_disp = '" + dt.Rows[i]["ESI_Dispensary"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        else if (dt.Rows[i]["ESI_Dispensary"].ToString().Trim() == "")
                        {
                            Query = Query + ",esi_disp = '" + null + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["PF_Region_Office"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pf_no_dept = '" + dt.Rows[i]["PF_Region_Office"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "pf_no_dept = '" + dt.Rows[i]["PF_Region_Office"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        else if (dt.Rows[i]["PF_Region_Office"].ToString().Trim() == "")
                        {
                            Query = Query + ",pf_no_dept = '" + null + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["CTC_Per_Annum"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",ward = '" + dt.Rows[i]["CTC_Per_Annum"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " ward = '" + dt.Rows[i]["CTC_Per_Annum"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["UAN_Number"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",uan = '" + dt.Rows[i]["UAN_Number"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " uan = '" + dt.Rows[i]["UAN_Number"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }


                        Query = Query + " where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // Employee does not exists

                        SqlParameter[] p = new SqlParameter[8];


                        p[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@ESI_Number", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ESI_Number"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["ESI_Number"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@PF_Number", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PF_Number"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["PF_Number"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@PAN_Number", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PAN_Number"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["PAN_Number"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@ESI_Dispensary", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ESI_Dispensary"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["ESI_Dispensary"].ToString().Trim();

                        }
                        p[5] = new SqlParameter("@PF_Region_Office", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PF_Region_Office"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["PF_Region_Office"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@CTC_Per_Annum", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["CTC_Per_Annum"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["CTC_Per_Annum"].ToString().Trim();

                        }
                        p[7] = new SqlParameter("@UAN_Number", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["UAN_Number"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["UAN_Number"].ToString().Trim();

                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SavePayrollDetails", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Payroll Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }

    #endregion

    #region Education Qualification

    private void SaveEducationQualificationDetails(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from tbl_employee_edcationalqualifications where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting Education Qualification Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        SqlParameter[] p = new SqlParameter[7];


                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@Education", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Education"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Education"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@UniversityName", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["UniversityName"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["UniversityName"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@GradeorPercentage", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["GradeorPercentage"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["GradeorPercentage"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@FromYear", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["FromYear"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["FromYear"].ToString().Trim();

                        }

                        p[5] = new SqlParameter("@ToYear", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["ToYear"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["ToYear"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@Specialization", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["Specialization"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["Specialization"].ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveEducationQualification", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Education Qualification Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }

    #endregion

    #region Professional Qualification
    private void SaveProfessionalQualificationDetails(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from tbl_employee_professionalqualifications where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting Professional Qualification Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        SqlParameter[] p = new SqlParameter[7];


                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@Education", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Education"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Education"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@UniversityName", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["UniversityName"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["UniversityName"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@GradeorPercentage", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["GradeorPercentage"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["GradeorPercentage"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@FromYear", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["FromYear"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["FromYear"].ToString().Trim();

                        }

                        p[5] = new SqlParameter("@ToYear", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["ToYear"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["ToYear"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@Specialization", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["Specialization"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["Specialization"].ToString().Trim();
                        }
                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveProfessionalQualification", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Professional Qualification Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }
    #endregion

    #region ExperienceDetails
    private void SaveExperienceDetails(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from tbl_employee_experiencedetails where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting Experience Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        SqlParameter[] p = new SqlParameter[7];


                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@CompanyName", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["CompanyName"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["CompanyName"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@Location", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["Location"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Location"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@Designation", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Designation"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["Designation"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@TotalExperience", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["TotalExperience"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["TotalExperience"].ToString().Trim();

                        }

                        p[5] = new SqlParameter("@FromYear", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["FromYear"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["FromYear"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@ToYear", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["ToYear"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["ToYear"].ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SavePayrollInfo", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Experience Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }
    #endregion

    #region Training Details
    private void SaveTrainingDetails(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from tbl_intranet_employee_trainingdetail where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting Training Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        SqlParameter[] p = new SqlParameter[6];


                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@TrainingName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["TrainingName"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["TrainingName"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@Conducteby", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Conducteby"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Conducteby"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@Fromdate", SqlDbType.DateTime);
                        if (dt.Rows[i]["FromDate"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[3].Value = Convert.ToDateTime(dt.Rows[i]["FromDate"].ToString().Trim());
                        }
                        p[4] = new SqlParameter("@Todate", SqlDbType.DateTime);
                        if (dt.Rows[i]["ToDate"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[4].Value = Convert.ToDateTime(dt.Rows[i]["ToDate"].ToString().Trim());
                        }
                        p[5] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                        if (dt.Rows[i]["Remarks"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["Remarks"].ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveTrainingDetails", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Training Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }
    #endregion

    #region Personal Details
    private void SavePersonalDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExistsPersonalDetails(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_intranet_employee_personalDetails set ";

                        if (dt.Rows[i]["DateofBirth"].ToString().Trim() != "")
                        {
                            Query = Query + " dob =  '" + dt.Rows[i]["DateofBirth"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["Religion"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",religion = '" + dt.Rows[i]["Religion"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " religion = '" + dt.Rows[i]["Religion"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["PaymentMode"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",paymentmode = '" + dt.Rows[i]["PaymentMode"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " paymentmode = '" + dt.Rows[i]["PaymentMode"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        //if (dt.Rows[i]["DLNo"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",dlno = '" + dt.Rows[i]["DLNo"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " dlno = '" + dt.Rows[i]["DLNo"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        if (dt.Rows[i]["BankNameforSalary"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",bank_name = '" + dt.Rows[i]["BankNameforSalary"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "bank_name = '" + dt.Rows[i]["BankNameforSalary"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["AccountNoforSalary"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",ac_number = '" + dt.Rows[i]["AccountNoforSalary"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " ac_number = '" + dt.Rows[i]["AccountNoforSalary"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["EmailId"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",email_id = '" + dt.Rows[i]["EmailId"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " email_id = '" + dt.Rows[i]["EmailId"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["BloodGroup"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",bloodgrp = '" + dt.Rows[i]["BloodGroup"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " bloodgrp = '" + dt.Rows[i]["BloodGroup"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["PassportNo"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",passport_number = '" + dt.Rows[i]["PassportNo"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " passport_number = '" + dt.Rows[i]["PassportNo"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["PassPortIssueDate"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",passportissuedate = '" + dt.Rows[i]["PassPortIssueDate"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " passportissuedate = '" + dt.Rows[i]["PassPortIssueDate"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["PassPortExpiryDate"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",passportexpiraydate = '" + dt.Rows[i]["PassPortExpiryDate"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " passportexpiraydate = '" + dt.Rows[i]["PassPortExpiryDate"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }



                        if (dt.Rows[i]["DrivingLicenceNo"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",driving_lic_no = '" + dt.Rows[i]["DrivingLicenceNo"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " driving_lic_no = '" + dt.Rows[i]["DrivingLicenceNo"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",dribing_lic_iss_date = '" + dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " dribing_lic_iss_date = '" + dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",driving_lic_exp_date = '" + dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " driving_lic_exp_date = '" + dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }



                        if (dt.Rows[i]["FatherName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",f_fname = '" + dt.Rows[i]["FatherName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " f_fname = '" + dt.Rows[i]["FatherName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["MotherName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",m_fname = '" + dt.Rows[i]["MotherName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " m_fname = '" + dt.Rows[i]["MotherName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["MaritalStatus"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",maritalstatus = '" + dt.Rows[i]["MaritalStatus"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " maritalstatus = '" + dt.Rows[i]["MaritalStatus"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["SpouseName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",s_fname = '" + dt.Rows[i]["SpouseName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " s_fname = '" + dt.Rows[i]["SpouseName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["DateOfAnniversary"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",doa = '" + dt.Rows[i]["DateOfAnniversary"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " doa = '" + dt.Rows[i]["DateOfAnniversary"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["IFSC_code"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",ifsc = '" + dt.Rows[i]["IFSC_code"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " ifsc = '" + dt.Rows[i]["IFSC_code"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["TShirtSize"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",f_mname = '" + dt.Rows[i]["TShirtSize"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " f_mname = '" + dt.Rows[i]["TShirtSize"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["ShirtSize"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",f_lname = '" + dt.Rows[i]["ShirtSize"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " f_lname = '" + dt.Rows[i]["ShirtSize"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["MobileNumber"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",mobile_no = '" + dt.Rows[i]["MobileNumber"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " mobile_no = '" + dt.Rows[i]["MobileNumber"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["LandLineNo"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",landlineno = '" + dt.Rows[i]["LandLineNo"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " landlineno = '" + dt.Rows[i]["LandLineNo"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["BankBranchName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",bankbranch = '" + dt.Rows[i]["BankBranchName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " bankbranch = '" + dt.Rows[i]["BankBranchName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        Query = Query + " where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // Employee does not exists

                        SqlParameter[] p = new SqlParameter[26];


                        p[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@DateofBirth", SqlDbType.DateTime);
                        if (dt.Rows[i]["DateofBirth"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[1].Value = Convert.ToDateTime(dt.Rows[i]["DateofBirth"].ToString().Trim());
                        }

                        p[2] = new SqlParameter("@Religion", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Religion"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Religion"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@PaymentMode", SqlDbType.Int);
                        if (dt.Rows[i]["PaymentMode"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[3].Value = Convert.ToInt32(dt.Rows[i]["PaymentMode"].ToString().Trim());
                        }

                        p[4] = new SqlParameter("@DLNo", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["DLNo"].ToString().Trim() == "")
                        //{
                        p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[4].Value = dt.Rows[i]["DLNo"].ToString().Trim();

                        //}
                        p[5] = new SqlParameter("@BankNameforSalary", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BankNameforSalary"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["BankNameforSalary"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@AccountNoforSalary", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["AccountNoforSalary"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["AccountNoforSalary"].ToString().Trim();

                        }
                        p[7] = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmailId"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["EmailId"].ToString().Trim();

                        }
                        p[8] = new SqlParameter("@BloodGroup", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BloodGroup"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["BloodGroup"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@PassportNo", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PassportNo"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["PassportNo"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@FatherName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["FatherName"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["FatherName"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@MotherName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["MotherName"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["MotherName"].ToString().Trim();

                        }
                        p[12] = new SqlParameter("@MaritalStatus", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["MaritalStatus"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["MaritalStatus"].ToString().Trim();

                        }
                        p[13] = new SqlParameter("@SpouseName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["SpouseName"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["SpouseName"].ToString().Trim();

                        }
                        p[14] = new SqlParameter("@DateOfAnniversary", SqlDbType.DateTime);
                        if (dt.Rows[i]["DateOfAnniversary"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[14].Value = Convert.ToDateTime(dt.Rows[i]["DateOfAnniversary"].ToString().Trim());

                        }
                        p[15] = new SqlParameter("@IFSC_code", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["IFSC_code"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["IFSC_code"].ToString().Trim();

                        }
                        p[16] = new SqlParameter("@TShirtSize", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["TShirtSize"].ToString().Trim() == "")
                        {
                            p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[16].Value = dt.Rows[i]["TShirtSize"].ToString().Trim();

                        }
                        p[17] = new SqlParameter("@ShirtSize", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ShirtSize"].ToString().Trim() == "")
                        {
                            p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[17].Value = dt.Rows[i]["ShirtSize"].ToString().Trim();

                        }
                        p[18] = new SqlParameter("@MobileNumber", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["MobileNumber"].ToString().Trim() == "")
                        {
                            p[18].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[18].Value = dt.Rows[i]["MobileNumber"].ToString().Trim();

                        }

                        p[19] = new SqlParameter("@passportissuedate", SqlDbType.DateTime);
                        if (dt.Rows[i]["PassPortIssueDate"].ToString().Trim() == "")
                        {
                            p[19].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[19].Value = Convert.ToDateTime(dt.Rows[i]["PassPortIssueDate"].ToString().Trim());

                        }
                        p[20] = new SqlParameter("@passportexpiraydate", SqlDbType.DateTime);
                        if (dt.Rows[i]["PassPortExpiryDate"].ToString().Trim() == "")
                        {
                            p[20].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[20].Value = Convert.ToDateTime(dt.Rows[i]["PassPortExpiryDate"].ToString().Trim());

                        }

                        p[21] = new SqlParameter("@dl_number", SqlDbType.VarChar, 100);
                        p[21].Value = dt.Rows[i]["DrivingLicenceNo"].ToString().Trim();


                        p[22] = new SqlParameter("@dlissuedate", SqlDbType.DateTime);
                        if (dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() == "")
                        {
                            p[22].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[22].Value = Convert.ToDateTime(dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim());

                        }
                        p[23] = new SqlParameter("@dlexpiraydate", SqlDbType.DateTime);
                        if (dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() == "")
                        {
                            p[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[23].Value = Convert.ToDateTime(dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim());

                        }
                        p[24] = new SqlParameter("@landlineno", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["LandLineNo"].ToString().Trim() == "")
                        {
                            p[24].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[24].Value = dt.Rows[i]["LandLineNo"].ToString().Trim();

                        }
                        p[25] = new SqlParameter("@bankbranch", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BankBranchName"].ToString().Trim() == "")
                        {
                            p[25].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[25].Value = dt.Rows[i]["BankBranchName"].ToString().Trim();

                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SavePersonalDetails", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Personal Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }
    #endregion

    #region Save Contact Details
    private void SaveContactDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExistsContactDetails(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_intranet_employee_contactlist set ";

                        if (dt.Rows[i]["PresentAddress"].ToString().Trim() != "")
                        {
                            Query = Query + " pre_add1 =  '" + dt.Rows[i]["PresentAddress"].ToString().Trim() + "'";
                            First = 1;
                        }

                        //if (dt.Rows[i]["PresentAddress2"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",pre_Add2 = '" + dt.Rows[i]["PresentAddress2"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " pre_Add2 = '" + dt.Rows[i]["PresentAddress2"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        //if (dt.Rows[i]["PresentCity"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",pre_city = '" + dt.Rows[i]["PresentCity"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " pre_city = '" + dt.Rows[i]["PresentCity"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        //if (dt.Rows[i]["PresentState"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",pre_state = '" + dt.Rows[i]["PresentState"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " pre_state = '" + dt.Rows[i]["PresentState"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        //if (dt.Rows[i]["PresentCountry"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",pre_country = '" + dt.Rows[i]["PresentCountry"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " pre_country = '" + dt.Rows[i]["PresentCountry"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        //if (dt.Rows[i]["PresentZipcode"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",pre_zip = '" + dt.Rows[i]["PresentZipcode"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " pre_zip = '" + dt.Rows[i]["PresentZipcode"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["PresentPhoneNo"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",pre_phone = '" + dt.Rows[i]["PresentPhoneNo"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " pre_phone = '" + dt.Rows[i]["PresentPhoneNo"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        if (dt.Rows[i]["PermanentAddress"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",per_add1 = '" + dt.Rows[i]["PermanentAddress"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " per_add1 = '" + dt.Rows[i]["PermanentAddress"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        //if (dt.Rows[i]["PermanentAddress2"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",per_add2 = '" + dt.Rows[i]["PermanentAddress2"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " per_add2 = '" + dt.Rows[i]["PermanentAddress2"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["PermanentCity"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",per_city = '" + dt.Rows[i]["PermanentCity"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " per_city = '" + dt.Rows[i]["PermanentCity"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["PermanentState"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",per_state = '" + dt.Rows[i]["PermanentState"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " per_state = '" + dt.Rows[i]["PermanentState"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["PermanentZipCode"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",per_zip = '" + dt.Rows[i]["PermanentZipCode"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " per_zip = '" + dt.Rows[i]["PermanentZipCode"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["PermanentPhoneNo"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",per_phone = '" + dt.Rows[i]["PermanentPhoneNo"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " per_phone = '" + dt.Rows[i]["PermanentPhoneNo"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        if (dt.Rows[i]["ModeofTransport"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",mode = '" + dt.Rows[i]["ModeofTransport"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " mode = '" + dt.Rows[i]["ModeofTransport"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["PickupPoint"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",modeoftransport = '" + dt.Rows[i]["PickupPoint"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " modeoftransport = '" + dt.Rows[i]["PickupPoint"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        //if (dt.Rows[i]["EmergencyContactNo"].ToString().Trim() != "")
                        //  {
                        //if (First == 1)
                        //    Query = Query + ",emergency_contact_no = '0'";
                        //else
                        //{
                        //    Query = Query + " emergency_contact_no = '" + dt.Rows[i]["EmergencyContactNo"].ToString().Trim() + "'";
                        //    First = 1;
                        //}
                        // }
                        // if (dt.Rows[i]["EmergencyContactName"].ToString().Trim() != "")
                        // {
                        if (First == 1)
                            Query = Query + ",emergency_name = '0'";
                        else
                        {
                            Query = Query + " emergency_name = '0'";
                            First = 1;
                        }
                        // }
                        //  if (dt.Rows[i]["EmergencyRelation"].ToString().Trim() != "")
                        // {
                        if (First == 1)
                            Query = Query + ",emergency_relation = '0'";
                        else
                        {
                            Query = Query + " emergency_relation = '0'";
                            First = 1;
                        }
                        // }
                        ////if (dt.Rows[i]["PermanentCountry"].ToString().Trim() != "")
                        ////{
                        //    if (First == 1)
                        //        Query = Query + ",per_country = '" + dt.Rows[i]["PermanentCountry"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " per_country = '" + dt.Rows[i]["PermanentCountry"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        Query = Query + " where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";

                        if (First == 1)
                        {
                            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        }

                        First = 0;
                        Query = "";

                    }
                    else
                    {
                        // Employee does not exists
                        SqlParameter[] p = new SqlParameter[20];


                        p[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@PresentAddress1", SqlDbType.VarChar, 1000);
                        if (dt.Rows[i]["PresentAddress"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["PresentAddress"].ToString().Trim();
                        }

                        p[2] = new SqlParameter("@PresentAddress2", SqlDbType.VarChar, 1000);
                        // if (dt.Rows[i]["PresentAddress2"].ToString().Trim() == "")
                        // {
                        p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        //  }
                        //  else
                        //  {
                        //     p[2].Value = dt.Rows[i]["PresentAddress2"].ToString().Trim();
                        // }

                        p[3] = new SqlParameter("@PresentCity", SqlDbType.VarChar, 200);
                        //if (dt.Rows[i]["PresentCity"].ToString().Trim() == "")
                        //{
                        p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[3].Value = dt.Rows[i]["PresentCity"].ToString().Trim();
                        //}

                        p[4] = new SqlParameter("@PresentState", SqlDbType.VarChar, 200);
                        //if (dt.Rows[i]["PresentState"].ToString().Trim() == "")
                        //{
                        p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[4].Value = dt.Rows[i]["PresentState"].ToString().Trim();
                        //}
                        p[5] = new SqlParameter("@PresentCountry", SqlDbType.VarChar, 100);
                        //if (dt.Rows[i]["PresentCountry"].ToString().Trim() == "")
                        //{
                        p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[5].Value = dt.Rows[i]["PresentCountry"].ToString().Trim();
                        //}

                        p[6] = new SqlParameter("@PresentZipcode", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["PresentZipcode"].ToString().Trim() == "")
                        //{
                        p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[6].Value = dt.Rows[i]["PresentZipcode"].ToString().Trim();
                        //}
                        p[7] = new SqlParameter("@PresentPhoneNo", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["PresentPhoneNo"].ToString().Trim() == "")
                        //{
                        p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[7].Value = dt.Rows[i]["PresentPhoneNo"].ToString().Trim();

                        //}
                        p[8] = new SqlParameter("@PermanentAddress1", SqlDbType.VarChar, 1000);
                        if (dt.Rows[i]["PermanentAddress"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["PermanentAddress"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@PermanentAddress2", SqlDbType.VarChar, 1000);
                        //if (dt.Rows[i]["PermanentAddress2"].ToString().Trim() == "")
                        //{
                        p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[9].Value = dt.Rows[i]["PermanentAddress2"].ToString().Trim();

                        //}
                        p[10] = new SqlParameter("@PermanentCity", SqlDbType.VarChar, 200);
                        //if (dt.Rows[i]["PermanentCity"].ToString().Trim() == "")
                        //{
                        p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[10].Value = dt.Rows[i]["PermanentCity"].ToString().Trim();

                        //}
                        p[11] = new SqlParameter("@PermanentState", SqlDbType.VarChar, 200);
                        //if (dt.Rows[i]["PermanentState"].ToString().Trim() == "")
                        //{
                        p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[11].Value = dt.Rows[i]["PermanentState"].ToString().Trim();

                        //}
                        p[12] = new SqlParameter("@PermanentZipCode", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["PermanentZipCode"].ToString().Trim() == "")
                        //{
                        p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[12].Value = dt.Rows[i]["PermanentZipCode"].ToString().Trim();

                        //}
                        p[13] = new SqlParameter("@PermanentPhoneNo", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["PermanentPhoneNo"].ToString().Trim() == "")
                        //{
                        p[13].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[13].Value = dt.Rows[i]["PermanentPhoneNo"].ToString().Trim();

                        //}
                        p[14] = new SqlParameter("@ModeofTransport", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ModeofTransport"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[14].Value = Convert.ToInt32(dt.Rows[i]["ModeofTransport"].ToString().Trim());

                        }
                        p[15] = new SqlParameter("@PickupPoint", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PickupPoint"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["PickupPoint"].ToString().Trim();

                        }
                        p[16] = new SqlParameter("@EmergencyContactNo", SqlDbType.VarChar, 50);
                        //   if (dt.Rows[i]["EmergencyContactNo"].ToString().Trim() == "")
                        //  {
                        p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[16].Value = dt.Rows[i]["EmergencyContactNo"].ToString().Trim();

                        //}
                        p[17] = new SqlParameter("@EmergencyContactName", SqlDbType.VarChar, 50);
                        // if (dt.Rows[i]["EmergencyContactName"].ToString().Trim() == "")
                        // {
                        p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[17].Value = dt.Rows[i]["EmergencyContactName"].ToString().Trim();

                        //}
                        p[18] = new SqlParameter("@EmergencyRelation", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["EmergencyRelation"].ToString().Trim() == "")
                        //{
                        p[18].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[18].Value = dt.Rows[i]["EmergencyRelation"].ToString().Trim();

                        //}
                        p[19] = new SqlParameter("@PermanentCountry", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["PermanentCountry"].ToString().Trim() == "")
                        //{
                        p[19].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[19].Value = dt.Rows[i]["PermanentCountry"].ToString().Trim();

                        //}

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveContactDetails", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Contact Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }
    #endregion

    #region Employee Exists
    private bool EmployeeExists(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_EmployeeExists", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool ApproversExist(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "sp_EmployeeExistsApproverDetails", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool EmployeeExistsPayrollDetails(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_EmployeeExistsPayrollDetails", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool EmployeeExistsPersonalDetails(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "sp_EmployeeExistsPersonalDetails", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool EmployeeExistsContactDetails(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "sp_EmployeeExistsContactDetails", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    #endregion

    #region Validation

    private bool Validate(DataTable dt)
    {
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Worklocation"].ToString().Trim() != "")
                    if (!ValidateWorklocation(Convert.ToInt32(dt.Rows[i]["Worklocation"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid work location " + dt.Rows[i]["Worklocation"].ToString() + ".  " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid work location " + dt.Rows[i]["Worklocation"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;
                    }
                if (dt.Rows[i]["Department"].ToString().Trim() != "")
                    if (!ValidateDepartment(Convert.ToInt32(dt.Rows[i]["Department"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid department " + dt.Rows[i]["Department"].ToString() + ".    " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid department " + dt.Rows[i]["Department"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;
                    }
                if (dt.Rows[i]["Costcenter"].ToString().Trim() != "")
                    if (!ValidateCostcenter(Convert.ToInt32(dt.Rows[i]["Costcenter"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid costcenter " + dt.Rows[i]["Costcenter"].ToString() + ".    " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid costcenter " + dt.Rows[i]["Costcenter"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;
                    }
                if (dt.Rows[i]["BusinessUnit"].ToString().Trim() != "")
                    if (!ValidateBusinessUnit(Convert.ToInt32(dt.Rows[i]["BusinessUnit"].ToString().Trim()), Convert.ToInt32(dt.Rows[i]["Department"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid business unit " + dt.Rows[i]["BusinessUnit"].ToString() + ".    " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid business unit " + dt.Rows[i]["BusinessUnit"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;
                    }
                if (dt.Rows[i]["Designation"].ToString().Trim() != "")
                    if (!ValidateDesignation(Convert.ToInt32(dt.Rows[i]["Designation"].ToString().Trim()), Convert.ToInt32(dt.Rows[i]["Department"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid designation " + dt.Rows[i]["Designation"].ToString() + ".    " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid designation " + dt.Rows[i]["Designation"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;
                    }
                if (dt.Rows[i]["Grade"].ToString().Trim() != "")
                    if (!ValidateGrade(Convert.ToInt32(dt.Rows[i]["Grade"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid grade " + dt.Rows[i]["Grade"].ToString() + ".    " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid grade " + dt.Rows[i]["Grade"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;
                    }
                if (dt.Rows[i]["EmployeeRole"].ToString().Trim() != "")
                    if (!ValidateEmployeeRole(Convert.ToInt32(dt.Rows[i]["EmployeeRole"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid employee role " + dt.Rows[i]["EmployeeRole"].ToString() + ".    " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid employee role " + dt.Rows[i]["EmployeeRole"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;
                    }
                if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                    if (!ValidateEmployeeStatus(Convert.ToInt32(dt.Rows[i]["EmployeeStatus"].ToString().Trim())))
                    {
                        diverror.InnerHtml = "Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid employee status " + dt.Rows[i]["EmployeeStatus"].ToString() + ".    " + DateTime.Now;
                        Log("Employee code " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + " has invalid employee status " + dt.Rows[i]["EmployeeStatus"].ToString() + ".    " + DateTime.Now);
                        iferror++;
                        return false;

                    }
            }

            return true;
        }
        catch (Exception ex)
        {
            iferror++;
            Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            return false;
        }
    }

    private bool ValidateWorklocation(int var)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateWorklocation", var);
        if (flag == 1)
            return true;
        else
            return false;

    }

    private bool ValidateDepartment(int var)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateDepartment", var);
        if (flag == 1)
            return true;
        else
            return false;

    }
    private bool ValidateCostcenter(int var)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateCostcenter", var);
        if (flag == 1)
            return true;
        else
            return false;

    }
    private bool ValidateBusinessUnit(int var, int dept)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateBusinessUnit", var, dept);
        if (flag == 1)
            return true;
        else
            return false;

    }

    private bool ValidateDesignation(int var, int dept)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateDesignation", var, dept);
        if (flag == 1)
            return true;
        else
            return false;

    }
    private bool ValidateGrade(int var)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateGrade", var);
        if (flag == 1)
            return true;
        else
            return false;

    }
    private bool ValidateEmployeeRole(int var)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateEmployeeRole", var);
        if (flag == 1)
            return true;
        else
            return false;

    }
    private bool ValidateEmployeeStatus(int var)
    {

        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_ValidateEmployeeStatus", var);
        if (flag == 1)
            return true;
        else
            return false;

    }

    #endregion Validation

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


    private static string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
    }

}