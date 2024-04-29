 using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EDB_Details_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Branch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["role"] != null)
            {

                if (fpEDB.PostedFile.FileName.ToString() != "")
                {
                    string file = Server.MapPath(".") + "\\upload\\EDBDetails.xlsx";
                    fpEDB.PostedFile.SaveAs(file);
                    try
                    {

                        insert_Job_detail(file);


                        insert_Payroll_Detail(file);
                        Insert_Educational_Qualification(file);
                        Insert_Professional_Qualification(file);

                        Insert_Expriece_detail(file);

                        insert_Training_details(file);
                        insert_personal_detail(file);

                        insert_contact_detail(file);
                        ShowAlertMessage("Uploaded Successfully.");
                    }
                    catch (Exception ex)
                    {
                        //ShowAlertMessage("Please check Excel format.There must be four fields named BR_Branch_Name,BR_Branch_Code,CL_Col_Id and Category_Id with sheet named SHEET1.There should not be blank data.");
                    }

                }
            }
        }

        catch (Exception ex)
        {
            //ShowAlertMessage("Please check Excel format.There must be four fields named BR_Branch_Name,BR_Branch_Code,CL_Col_Id and Category_Id with sheet named SHEET1.There should not be blank data.");
        }

    }


    protected void insert_Job_detail(string file)
    {
        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\EDBDetails.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [Employee_job_Details$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "JobDetails");
                objconn.Close();



                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {

                    SqlParameter[] sqlparam = new SqlParameter[46];
                    sqlparam[0] = new SqlParameter("@emp_code", SqlDbType.VarChar, 50);
                    sqlparam[0].Value = dds.Tables[0].Rows[i]["EmployeeCode"].ToString().Trim();

                    sqlparam[1] = new SqlParameter("@card_no", SqlDbType.VarChar, 100);
                    sqlparam[1].Value = dds.Tables[0].Rows[i]["EmployeeCardNo"].ToString().Trim();

                    sqlparam[2] = new SqlParameter("@emp_gender", SqlDbType.VarChar, 10);
                    sqlparam[2].Value = dds.Tables[0].Rows[i]["Gender"].ToString().Trim();

                    sqlparam[3] = new SqlParameter("@emp_fname", SqlDbType.VarChar, 50);
                    sqlparam[3].Value = dds.Tables[0].Rows[i]["FirstName"].ToString();

                    sqlparam[4] = new SqlParameter("@emp_m_name", SqlDbType.VarChar, 50);
                    sqlparam[4].Value = "";// dds.Tables[0].Rows[i]["MiddleName"].ToString();

                    sqlparam[5] = new SqlParameter("@emp_l_name", SqlDbType.VarChar, 50);
                    sqlparam[5].Value = "";// dds.Tables[0].Rows[i]["LastName"].ToString();

                    sqlparam[6] = new SqlParameter("@emp_status", SqlDbType.Int);
                    sqlparam[6].Value = dds.Tables[0].Rows[i]["EmployeeStatus"].ToString();

                    sqlparam[7] = new SqlParameter("@dept_id", SqlDbType.Int);
                    sqlparam[7].Value = dds.Tables[0].Rows[i]["Department"].ToString();

                    sqlparam[8] = new SqlParameter("@division_id", SqlDbType.Int);
                    sqlparam[8].Value = dds.Tables[0].Rows[i]["SubDepartment"].ToString();

                    sqlparam[9] = new SqlParameter("@degination_id", SqlDbType.Int);
                    sqlparam[9].Value = dds.Tables[0].Rows[i]["Designation"].ToString();

                    sqlparam[10] = new SqlParameter("@Grade", SqlDbType.Int);
                    if ((dds.Tables[0].Rows[i]["Grade"].ToString() == "0") || (dds.Tables[0].Rows[i]["Grade"].ToString() == ""))
                    {
                        sqlparam[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                    }
                    else
                    {
                        sqlparam[10].Value = dds.Tables[0].Rows[i]["Grade"].ToString();
                    }

                    sqlparam[11] = new SqlParameter("@branch_id", SqlDbType.Int);
                    if ((dds.Tables[0].Rows[i]["BranchName"].ToString() == "0") || (dds.Tables[0].Rows[i]["BranchName"].ToString() == ""))
                    {
                        sqlparam[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                    }
                    else
                    {
                        sqlparam[11].Value = dds.Tables[0].Rows[i]["BranchName"].ToString();
                    }

                    sqlparam[12] = new SqlParameter("@emp_doj", SqlDbType.DateTime);
                    if (dds.Tables[0].Rows[i]["Dateofjoining"].ToString() == "")
                        sqlparam[12].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    else
                        sqlparam[12].Value = dds.Tables[0].Rows[i]["Dateofjoining"].ToString();
                    //sqlparam[12].Value = Convert.ToDateTime((doj.Text.Trim()=="")? "1/1/1900" : doj.Text.Trim());
                    sqlparam[13] = new SqlParameter("@ext_number", SqlDbType.VarChar, 50);
                    if (dds.Tables[0].Rows[i]["Ext_Number"].ToString() == "")
                        sqlparam[13].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    else

                        sqlparam[13].Value = dds.Tables[0].Rows[i]["Ext_Number"].ToString();

                    sqlparam[14] = new SqlParameter("@photo", SqlDbType.VarChar, 100);
                    sqlparam[14].Value = "";

                    sqlparam[15] = new SqlParameter("@salary_cal_from", SqlDbType.DateTime);
                    if (dds.Tables[0].Rows[i]["SalaryCalculationFrom"].ToString() == "")
                        sqlparam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    else
                        sqlparam[15].Value = Convert.ToDateTime(dds.Tables[0].Rows[i]["SalaryCalculationFrom"].ToString());

                    sqlparam[16] = new SqlParameter("@emp_doleaving", SqlDbType.DateTime);
                    //if (dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString() == "")
                    sqlparam[16].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    //else
                    //  sqlparam[16].Value = Convert.ToDateTime(dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString());

                    sqlparam[17] = new SqlParameter("@reason_leaving", SqlDbType.VarChar, 200);
                    sqlparam[17].Value = "";//dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString();

                    sqlparam[18] = new SqlParameter("@salutation", SqlDbType.VarChar, 3);
                    sqlparam[18].Value = dds.Tables[0].Rows[i]["Salutation"].ToString();


                    sqlparam[19] = new SqlParameter("@probationperiod", SqlDbType.Int);
                    sqlparam[20] = new SqlParameter("@probationenddate", SqlDbType.Int);
                    //if (dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString() == "Probation")
                    //{
                    //    sqlparam[19].Value = Convert.ToInt32(dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString());
                    //    sqlparam[20].Value = dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString();
                    //}
                    //else
                    //{
                    sqlparam[19].Value = System.Data.SqlTypes.SqlInt32.Null;
                    sqlparam[20].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    // }


                    sqlparam[21] = new SqlParameter("@deputationstartdate", SqlDbType.DateTime);
                    sqlparam[22] = new SqlParameter("@deputationenddate", SqlDbType.DateTime);
                    //if (dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString() == "Contractual")
                    //{
                    //    sqlparam[21].Value = dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString();
                    //    sqlparam[22].Value = dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString();
                    //}
                    //else
                    //{
                    sqlparam[21].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    sqlparam[22].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    // }

                    sqlparam[23] = new SqlParameter("@subgroupid", SqlDbType.Int);
                    //if ((ddl_subgroup.SelectedValue == "0") || (ddl_subgroup.SelectedValue == ""))
                    //{
                    //    sqlparam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    sqlparam[23].Value = System.Data.SqlTypes.SqlInt32.Null;// ddl_subgroup.SelectedValue;
                    //}

                    sqlparam[24] = new SqlParameter("@broadgroupid", SqlDbType.Int);
                    if ((dds.Tables[0].Rows[i]["BroadGroup"].ToString() == "0") || (dds.Tables[0].Rows[i]["BroadGroup"].ToString() == ""))
                    {
                        sqlparam[24].Value = System.Data.SqlTypes.SqlInt32.Null;
                    }
                    else
                    {
                        sqlparam[24].Value = dds.Tables[0].Rows[i]["BroadGroup"].ToString();
                    }

                    sqlparam[25] = new SqlParameter("@entityid", SqlDbType.Int);
                    // if ((ddl_entity.SelectedValue == "0") || (ddl_entity.SelectedValue == ""))
                    //{
                    sqlparam[25].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    //    sqlparam[25].Value = ddl_entity.SelectedValue;
                    //}

                    sqlparam[26] = new SqlParameter("@gradetype", SqlDbType.VarChar, 1);
                    if ((dds.Tables[0].Rows[i]["GradeType"].ToString() == "0") || (dds.Tables[0].Rows[i]["GradeType"].ToString() == ""))
                    {
                        sqlparam[26].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlparam[26].Value = dds.Tables[0].Rows[i]["GradeType"].ToString();
                    }
                    sqlparam[27] = new SqlParameter("@official_mob_no", SqlDbType.VarChar, 50);
                    sqlparam[27].Value = dds.Tables[0].Rows[i]["OfficialMobileNo"].ToString();

                    sqlparam[28] = new SqlParameter("@official_email_id", SqlDbType.VarChar, 50);
                    sqlparam[28].Value = dds.Tables[0].Rows[i]["OfficalEmailId"].ToString();

                    sqlparam[29] = new SqlParameter("@supervisorcode", SqlDbType.VarChar, 50);
                    if ((dds.Tables[0].Rows[i]["ImmediateSupervisorName"].ToString() == "0") || (dds.Tables[0].Rows[i]["ImmediateSupervisorName"].ToString() == ""))
                    {
                        sqlparam[29].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlparam[29].Value = dds.Tables[0].Rows[i]["ImmediateSupervisorName"].ToString();

                    }

                    sqlparam[30] = new SqlParameter("@hodcode", SqlDbType.VarChar, 50);
                    if ((dds.Tables[0].Rows[i]["ManagerName"].ToString() == "0") || (dds.Tables[0].Rows[i]["ManagerName"].ToString() == ""))
                    {
                        sqlparam[30].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlparam[30].Value = dds.Tables[0].Rows[i]["ManagerName"].ToString();
                    }

                    sqlparam[31] = new SqlParameter("@corporatereportingcode", SqlDbType.VarChar, 50);
                    if ((dds.Tables[0].Rows[i]["CorporateReportingName"].ToString() == "0") || (dds.Tables[0].Rows[i]["CorporateReportingName"].ToString() == ""))
                    {
                        sqlparam[31].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlparam[31].Value = dds.Tables[0].Rows[i]["CorporateReportingName"].ToString();
                    }
                    //============================================================COST CENTER===========================================
                    sqlparam[32] = new SqlParameter("@cost_center_group_id", SqlDbType.Int);
                    //if ((dds.Tables[0].Rows[i]["CostCenterGroup"].ToString() == "0") || (dds.Tables[0].Rows[i]["CostCenterGroup"].ToString() == ""))
                    //{
                    sqlparam[32].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    //    sqlparam[32].Value = Convert.ToInt32(dds.Tables[0].Rows[i]["CostCenterGroup"].ToString());
                    //}
                    sqlparam[33] = new SqlParameter("@cost_center_code", SqlDbType.Int);
                    //if ((dds.Tables[0].Rows[i]["CostCenterCode"].ToString() == "0") || (dds.Tables[0].Rows[i]["CostCenterCode"].ToString() == ""))
                    //{
                    sqlparam[33].Value = System.Data.SqlTypes.SqlInt32.Null;


                    //}
                    //else
                    //{
                    //    sqlparam[33].Value = Convert.ToInt32(dds.Tables[0].Rows[i]["CostCenterCode"].ToString());
                    //}
                    //if ((dds.Tables[0].Rows[i]["CostCenterCode"].ToString() == "0") || (dds.Tables[0].Rows[i]["CostCenterCode"].ToString() == ""))
                    //{
                    sqlparam[34] = new SqlParameter("@country", SqlDbType.Int);
                    sqlparam[34].Value = System.Data.SqlTypes.SqlInt32.Null;

                    sqlparam[35] = new SqlParameter("@state", SqlDbType.Int);
                    sqlparam[35].Value = System.Data.SqlTypes.SqlInt32.Null;

                    sqlparam[36] = new SqlParameter("@city", SqlDbType.Int);
                    sqlparam[36].Value = System.Data.SqlTypes.SqlInt32.Null;

                    sqlparam[37] = new SqlParameter("@location", SqlDbType.VarChar, 100);
                    sqlparam[37].Value = System.Data.SqlTypes.SqlString.Null;
                    //}
                    //else
                    //{
                    //    string sqlstr1 = "select id,country,state,city,  from tbl_intranet_cost_center where id='" + Convert.ToInt32(dds.Tables[0].Rows[i]["CostCenterCode"].ToString().Trim()) + "'";
                    //    DataSet ds1 = new DataSet();
                    //    ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);


                    //    sqlparam[34] = new SqlParameter("@country", SqlDbType.Int);
                    //    if ((ds1.Tables[0].Rows[i]["country"].ToString() == "0") || (ds1.Tables[0].Rows[i]["country"].ToString() == ""))
                    //    {
                    //        sqlparam[34].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[34].Value = Convert.ToInt32(ds1.Tables[0].Rows[i]["country"].ToString());
                    //    }

                    //    sqlparam[35] = new SqlParameter("@state", SqlDbType.Int);
                    //    if ((ds1.Tables[0].Rows[i]["state"].ToString() == "0") || (ds1.Tables[0].Rows[i]["state"].ToString() == ""))
                    //    {
                    //        sqlparam[35].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[35].Value = Convert.ToInt32(ds1.Tables[0].Rows[i]["state"].ToString());
                    //    }
                    //    sqlparam[36] = new SqlParameter("@city", SqlDbType.Int);
                    //    if ((ds1.Tables[0].Rows[i]["city"].ToString() == "0") || (ds1.Tables[0].Rows[i]["city"].ToString() == ""))
                    //    {
                    //        sqlparam[36].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[36].Value = Convert.ToInt32(ds1.Tables[0].Rows[i]["city"].ToString());
                    //    }

                    //    sqlparam[37] = new SqlParameter("@location", SqlDbType.VarChar, 100);
                    //    if ((ds1.Tables[0].Rows[i]["location"].ToString() == "0") || (ds1.Tables[0].Rows[i]["location"].ToString() == ""))
                    //    {
                    //        sqlparam[37].Value = System.Data.SqlTypes.SqlString.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[37].Value = ds1.Tables[0].Rows[i]["location"].ToString();
                    //    }
                    //}
                    sqlparam[38] = new SqlParameter("@add_cost_center_group_id", SqlDbType.Int);
                    // if ((dds.Tables[0].Rows[i]["AddCostCenterGroup"].ToString() == "0") || (dds.Tables[0].Rows[i]["AddCostCenterGroup"].ToString() == ""))
                    // {
                    sqlparam[38].Value = System.Data.SqlTypes.SqlInt32.Null;
                    // }
                    // else
                    // {
                    //     sqlparam[38].Value = "";// Convert.ToInt32(dds.Tables[0].Rows[i]["AddCostCenterGroup"].ToString());
                    // }
                    sqlparam[39] = new SqlParameter("@add_cost_center_code", SqlDbType.Int);
                    //   if ((dds.Tables[0].Rows[i]["Add_CostCenterCode"].ToString() == "0") || (dds.Tables[0].Rows[i]["Add_CostCenterCode"].ToString() == ""))
                    // {
                    sqlparam[39].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    //    sqlparam[39].Value =  Convert.ToInt32(dds.Tables[0].Rows[i]["Add_CostCenterCode"].ToString().Trim());
                    //}
                    //if ((dds.Tables[0].Rows[i]["Add_CostCenterCode"].ToString() == "0") || (dds.Tables[0].Rows[i]["Add_CostCenterCode"].ToString() == ""))
                    //{
                    sqlparam[40] = new SqlParameter("@add_country", SqlDbType.Int);
                    sqlparam[40].Value = System.Data.SqlTypes.SqlInt32.Null;
                    sqlparam[41] = new SqlParameter("@add_state", SqlDbType.Int);
                    sqlparam[41].Value = System.Data.SqlTypes.SqlInt32.Null;
                    sqlparam[42] = new SqlParameter("@add_city", SqlDbType.Int);
                    sqlparam[42].Value = System.Data.SqlTypes.SqlInt32.Null;
                    sqlparam[43] = new SqlParameter("@add_location", SqlDbType.VarChar, 100);
                    sqlparam[43].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    //    string sqlstr2 = "select id,country,state,city, location from tbl_intranet_cost_center where id='" + Convert.ToInt32(dds.Tables[0].Rows[i]["Add_CostCenterCode"].ToString().Trim()) + "'";
                    //    DataSet ds2 = new DataSet();
                    //    ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);

                    //    sqlparam[40] = new SqlParameter("@add_country", SqlDbType.Int);
                    //    if ((ds2.Tables[0].Rows[i]["country"].ToString() == "0") || (ds2.Tables[0].Rows[i]["country"].ToString() == ""))
                    //    {
                    //        sqlparam[40].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[40].Value = Convert.ToInt32(ds2.Tables[0].Rows[i]["country"].ToString());
                    //    }

                    //    sqlparam[41] = new SqlParameter("@add_state", SqlDbType.Int);
                    //    if ((ds2.Tables[0].Rows[i]["state"].ToString() == "0") || (ds2.Tables[0].Rows[i]["state"].ToString() == ""))
                    //    {
                    //        sqlparam[41].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[41].Value = Convert.ToInt32(ds2.Tables[0].Rows[i]["state"].ToString());
                    //    }

                    //    sqlparam[42] = new SqlParameter("@add_city", SqlDbType.Int);
                    //    if ((ds2.Tables[0].Rows[i]["city"].ToString() == "0") || (ds2.Tables[0].Rows[i]["city"].ToString() == ""))
                    //    {
                    //        sqlparam[42].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[42].Value = Convert.ToInt32(ds2.Tables[0].Rows[i]["city"].ToString());
                    //    }

                    //    sqlparam[43] = new SqlParameter("@add_location", SqlDbType.VarChar, 100);
                    //    if ((ds2.Tables[0].Rows[i]["location"].ToString() == "0") || (ds2.Tables[0].Rows[i]["location"].ToString() == ""))
                    //    {
                    //        sqlparam[43].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //    }
                    //    else
                    //    {
                    //        sqlparam[43].Value = ds2.Tables[0].Rows[i]["location"].ToString();
                    //    }
                    //}
                    sqlparam[44] = new SqlParameter("@confirmationdate", SqlDbType.DateTime);
                    // if (dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString() == "")
                    //{
                    sqlparam[44].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    //}
                    //else
                    //{
                    //sqlparam[44].Value = dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString();
                    // }

                    sqlparam[45] = new SqlParameter("@noticeperiod", SqlDbType.Int);
                    //if (dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString() == "")
                    //{
                    sqlparam[45].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    //    sqlparam[45].Value = Convert.ToInt32(dds.Tables[0].Rows[i]["BR_Branch_Name"].ToString());
                    //}



                    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_jobdetails", sqlparam);

                    //--------------insert login details---------    
                    int saltSize = 5;
                    string salt = CreateSalt(saltSize);
                    string passwordHash = CreatePasswordHash(dds.Tables[0].Rows[i]["LoginPassword"].ToString(), salt);

                    SqlParameter[] sqlparam1 = new SqlParameter[4];

                    sqlparam1[0] = new SqlParameter("@loginid", SqlDbType.VarChar, 50);
                    sqlparam1[0].Value = dds.Tables[0].Rows[i]["EmployeeCode"].ToString();

                    sqlparam1[1] = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
                    sqlparam1[1].Value = passwordHash.Trim().ToString();

                    sqlparam1[2] = new SqlParameter("@role", SqlDbType.TinyInt);
                    sqlparam1[2].Value = dds.Tables[0].Rows[i]["EmployeeRole"].ToString();

                    sqlparam1[3] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparam1[3].Value = dds.Tables[0].Rows[i]["EmployeeCode"].ToString();

                    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_employee_login", sqlparam1);




                }
            }

        }

        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format.There must be 13 fields named EmployeeCode,Salutation,FirstName ,LoginPassword,Gender,BranchName,Department,SubDepartment,Designation,EmployeeRole,EmployeeStatus,Dateofjoining,SalaryCalculationFrom with sheet named Employee_job_Details.There should not be blank data.");
        }



    }





    //--------------------Insert Payroll Details-----------------------

    protected void insert_Payroll_Detail(string file)
    {
        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\BranchMaster.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [Employee_Payroll_Details$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "PayRollDetails");
                objconn.Close();



                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {


                    SqlParameter[] sqlparam2 = new SqlParameter[8];

                    sqlparam2[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparam2[0].Value = dds.Tables[0].Rows[i]["EmployeeCode"].ToString();


                    sqlparam2[1] = new SqlParameter("@esi_no", SqlDbType.VarChar, 50);
                    sqlparam2[1].Value = dds.Tables[0].Rows[i]["ESI_Number"].ToString().Trim();


                    sqlparam2[2] = new SqlParameter("@esi_disp", SqlDbType.VarChar, 100);
                    sqlparam2[2].Value = dds.Tables[0].Rows[i]["ESI_Dispensary"].ToString().Trim();

                    sqlparam2[3] = new SqlParameter("@pf_no", SqlDbType.VarChar, 50);
                    sqlparam2[3].Value = dds.Tables[0].Rows[i]["PF_Number"].ToString().Trim();

                    sqlparam2[4] = new SqlParameter("@pf_no_dept", SqlDbType.VarChar, 50);
                    sqlparam2[4].Value = dds.Tables[0].Rows[i]["PF_Region_Office"].ToString().Trim();

                    sqlparam2[5] = new SqlParameter("@pan_no", SqlDbType.VarChar, 50);
                    sqlparam2[5].Value = dds.Tables[0].Rows[i]["PAN_Number"].ToString().Trim();

                    sqlparam2[6] = new SqlParameter("@ward", SqlDbType.VarChar, 100);
                    sqlparam2[6].Value = "";

                    sqlparam2[7] = new SqlParameter("@ptno", SqlDbType.VarChar, 50);
                    sqlparam2[7].Value = "";
                    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_payrolldetails]", sqlparam2);

                }
            }
        }
        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format. sheet must be named Employee_Payroll_Details.");
        }
    }

    protected void Insert_Educational_Qualification(string file)
    {
        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\BranchMaster.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [Educational_Qualification$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "EducationDetails");
                objconn.Close();

                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {

                    SqlParameter[] sqlParam = new SqlParameter[7];

                    sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlParam[0].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                    sqlParam[1].Value = dds.Tables[0].Rows[i]["Education"].ToString();

                    sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                    sqlParam[2].Value = dds.Tables[0].Rows[i]["School/Institute/UniversityName"].ToString();

                    sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                    sqlParam[3].Value = dds.Tables[0].Rows[i]["Grade/Percentage"].ToString();

                    sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                    sqlParam[4].Value = dds.Tables[0].Rows[i]["FromYear"].ToString();

                    sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                    sqlParam[5].Value = dds.Tables[0].Rows[i]["ToYear"].ToString();

                    sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                    sqlParam[6].Value = dds.Tables[0].Rows[i]["Specialization"].ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_employee_insert_educationqualification]", sqlParam);
                }
            }
        }
        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format.sheet must be named Educational_Qualification.");
        }
    }

    protected void Insert_Professional_Qualification(string file)
    {
        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\BranchMaster.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [Professional_Qualification$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "ProfessionalDetails");
                objconn.Close();



                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {

                    SqlParameter[] sqlParam = new SqlParameter[7];

                    sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlParam[0].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                    sqlParam[1].Value = dds.Tables[0].Rows[i]["Education"].ToString();

                    sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                    sqlParam[2].Value = dds.Tables[0].Rows[i]["Institute/UniversityName"].ToString();

                    sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                    sqlParam[3].Value = dds.Tables[0].Rows[i]["Grade/Percentage"].ToString();

                    sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                    sqlParam[4].Value = dds.Tables[0].Rows[i]["FromYear"].ToString();

                    sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                    sqlParam[5].Value = dds.Tables[0].Rows[i]["ToYear"].ToString();

                    sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                    sqlParam[6].Value = dds.Tables[0].Rows[i]["Specialization"].ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_employee_insert_professionalqualification]", sqlParam);
                }
            }
        }
        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format.sheet must be named Professional_Qualification.");
        }
    }



    protected void Insert_Expriece_detail(string file)
    {
        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\BranchMaster.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [Experience_Details$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "ExperienceDetails");
                objconn.Close();


                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {

                    SqlParameter[] sqlParam = new SqlParameter[7];

                    sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlParam[0].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[1] = new SqlParameter("@companyname", SqlDbType.VarChar, 50);
                    sqlParam[1].Value = dds.Tables[0].Rows[i]["CompanyName"].ToString();

                    sqlParam[2] = new SqlParameter("@location", SqlDbType.VarChar, 150);
                    sqlParam[2].Value = dds.Tables[0].Rows[i]["Location"].ToString();

                    sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                    sqlParam[3].Value = dds.Tables[0].Rows[i]["TotalExperience"].ToString();

                    sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                    sqlParam[4].Value = dds.Tables[0].Rows[i]["FromYear"].ToString();

                    sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                    sqlParam[5].Value = dds.Tables[0].Rows[i]["ToYear"].ToString();

                    sqlParam[6] = new SqlParameter("@designation", SqlDbType.VarChar, 50);
                    sqlParam[6].Value = dds.Tables[0].Rows[i]["Designation"].ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_employee_insert_experiencedetails]", sqlParam);
                }
            }
        }

        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format.sheet must be named Experience_Details.");
        }
    }
    protected void insert_Training_details(string file)
    {
        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\BranchMaster.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [TraingDetails$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "TraingDetails");
                objconn.Close();


                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {

                    SqlParameter[] sqlParam = new SqlParameter[6];

                    sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlParam[0].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[1] = new SqlParameter("@trainingname", SqlDbType.VarChar, 50);
                    sqlParam[1].Value = dds.Tables[0].Rows[i]["TrainingName"].ToString();

                    sqlParam[2] = new SqlParameter("@personname", SqlDbType.VarChar, 50);
                    sqlParam[2].Value = dds.Tables[0].Rows[i]["Conducteby"].ToString();

                    sqlParam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
                    sqlParam[3].Value = dds.Tables[0].Rows[i]["FromDate"].ToString();

                    sqlParam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
                    sqlParam[4].Value = dds.Tables[0].Rows[i]["ToDate"].ToString();

                    sqlParam[5] = new SqlParameter("@remarks", SqlDbType.VarChar, 500);
                    sqlParam[5].Value = dds.Tables[0].Rows[i]["Remarks"].ToString();



                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_emp_training]", sqlParam);
                }
            }
        }

        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format.sheet must be named TraingDetails");
        }
    }

    protected void insert_personal_detail(string file)
    {

        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\BranchMaster.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [PersonalDetails$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "PersonalDetails");
                objconn.Close();


                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {
                    // int paymentmode = 0;
                    SqlParameter[] sqlParam = new SqlParameter[31];

                    sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlParam[0].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[1] = new SqlParameter("@f_fname", SqlDbType.VarChar, 50);
                    sqlParam[1].Value = dds.Tables[0].Rows[i]["FatherName"].ToString();

                    sqlParam[2] = new SqlParameter("@f_mname", SqlDbType.VarChar, 50);
                    sqlParam[2].Value = "";// dds.Tables[0].Rows[i]["MotherName"].ToString();

                    sqlParam[3] = new SqlParameter("@f_lname", SqlDbType.VarChar, 50);
                    sqlParam[3].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[4] = new SqlParameter("@m_fname", SqlDbType.VarChar, 50);
                    sqlParam[4].Value = dds.Tables[0].Rows[i]["MotherName"].ToString();

                    sqlParam[5] = new SqlParameter("@m_lname", SqlDbType.VarChar, 50);
                    sqlParam[5].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[6] = new SqlParameter("@m_mname", SqlDbType.VarChar, 50);
                    sqlParam[6].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[7] = new SqlParameter("@bloodgrp", SqlDbType.VarChar, 50);
                    sqlParam[7].Value = dds.Tables[0].Rows[i]["BloodGroup"].ToString();

                    sqlParam[8] = new SqlParameter("@maritalstatus", SqlDbType.VarChar, 50);
                    sqlParam[8].Value = dds.Tables[0].Rows[i]["MaritalStatus"].ToString();

                    sqlParam[9] = new SqlParameter("@religion", SqlDbType.VarChar, 50);
                    sqlParam[9].Value = dds.Tables[0].Rows[i]["Religion"].ToString();

                    sqlParam[10] = new SqlParameter("@doa", SqlDbType.DateTime);
                    if (dds.Tables[0].Rows[i]["DateOfAnniversary"].ToString() == "")
                        sqlParam[10].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    else
                        sqlParam[10].Value = dds.Tables[0].Rows[i]["DateOfAnniversary"].ToString();

                    sqlParam[11] = new SqlParameter("@dlno", SqlDbType.VarChar, 50);
                    sqlParam[11].Value = dds.Tables[0].Rows[i]["DLNo"].ToString();

                    sqlParam[12] = new SqlParameter("@s_fname", SqlDbType.VarChar, 50);
                    sqlParam[12].Value = "";// dds.Tables[0].Rows[i]["SpouseName"].ToString();

                    sqlParam[13] = new SqlParameter("@s_mname", SqlDbType.VarChar, 50);
                    sqlParam[13].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[14] = new SqlParameter("@s_lname", SqlDbType.VarChar, 50);
                    sqlParam[14].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[15] = new SqlParameter("@s_dob", SqlDbType.DateTime);
                    if (dds.Tables[0].Rows[i]["DateofBirth"].ToString() == "")
                        sqlParam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    else
                        sqlParam[15].Value = dds.Tables[0].Rows[i]["DateofBirth"].ToString();

                    sqlParam[16] = new SqlParameter("@s_gender", SqlDbType.VarChar, 50);
                    sqlParam[16].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[17] = new SqlParameter("@no_child", SqlDbType.Int);
                    sqlParam[17].Value = 0;

                    sqlParam[18] = new SqlParameter("@mobile_no", SqlDbType.VarChar, 50);
                    sqlParam[18].Value = dds.Tables[0].Rows[i]["MobileNumber"].ToString();

                    sqlParam[19] = new SqlParameter("@email_id", SqlDbType.VarChar, 50);
                    sqlParam[19].Value = dds.Tables[0].Rows[i]["EmailId"].ToString();

                    sqlParam[20] = new SqlParameter("@bank_name", SqlDbType.VarChar, 50);
                    sqlParam[20].Value = dds.Tables[0].Rows[i]["BankNameforSalary"].ToString();

                    sqlParam[21] = new SqlParameter("@ac_number", SqlDbType.VarChar, 50);
                    sqlParam[21].Value = dds.Tables[0].Rows[i]["AccountNoforSalary"].ToString();

                    sqlParam[22] = new SqlParameter("@passport_number", SqlDbType.VarChar, 50);
                    sqlParam[22].Value = dds.Tables[0].Rows[i]["PassportNo"].ToString();

                    sqlParam[23] = new SqlParameter("@DOB", SqlDbType.DateTime);
                    if (dds.Tables[0].Rows[i]["DateofBirth"].ToString() == "")
                        sqlParam[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    else
                        sqlParam[23].Value = Convert.ToDateTime(dds.Tables[0].Rows[i]["DateofBirth"].ToString());

                    //if (rbtnbank.Checked)
                    //    paymentmode = 0;

                    //if (rbtncheque.Checked)
                    //    paymentmode = 1;

                    //if (rbtncash.Checked)
                    //    paymentmode = 2;

                    sqlParam[24] = new SqlParameter("@paymentmode", SqlDbType.Int);
                    sqlParam[24].Value = dds.Tables[0].Rows[i]["PaymentMode"].ToString();

                    sqlParam[25] = new SqlParameter("@bank_name_reimbursement", SqlDbType.VarChar, 50);
                    sqlParam[25].Value = "";// dds.Tables[0].Rows[i]["BankNameforReimbursement"].ToString();

                    sqlParam[26] = new SqlParameter("@ac_number_reimbursement", SqlDbType.VarChar, 50);
                    sqlParam[26].Value = "";// dds.Tables[0].Rows[i]["AccountNoforReimbursement"].ToString();

                    sqlParam[27] = new SqlParameter("@bankbranch", SqlDbType.VarChar, 50);
                    sqlParam[27].Value ="";

                    sqlParam[28] = new SqlParameter("@ifsc", SqlDbType.VarChar, 50);
                    sqlParam[28].Value = dds.Tables[0].Rows[i]["IFSC_code"].ToString();

                    sqlParam[29] = new SqlParameter("@passportissuedate", SqlDbType.DateTime);
                    //if (dds.Tables[0].Rows[i]["EmpCode"].ToString() == "")
                    //{
                    sqlParam[29].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    //}
                    //else
                    //{
                    //    sqlParam[29].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();
                    //}
                    sqlParam[30] = new SqlParameter("@passportexpiraydate", SqlDbType.DateTime);
                    //if (dds.Tables[0].Rows[i]["EmpCode"].ToString() == "")
                    //{
                    sqlParam[30].Value = System.Data.SqlTypes.SqlDateTime.Null;
                    //}
                    //else
                    //{
                    //    sqlParam[30].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();
                    //}
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_personaldetails]", sqlParam);
                }
            }
        }

        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format.sheet must be named PersonalDetails.");
        }
    }
    protected void insert_contact_detail(string file)
    {
        try
        {
            if (fpEDB.PostedFile.FileName.ToString() != "")
            {
                //string file = Server.MapPath(".") + "\\upload\\BranchMaster.xlsx";
                //fpEDB.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [ContactDetails$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "ContactDetails");
                objconn.Close();


                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                {
                    SqlParameter[] sqlParam = new SqlParameter[26];

                    sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlParam[0].Value = dds.Tables[0].Rows[i]["EmpCode"].ToString();
                    sqlParam[1] = new SqlParameter("@pre_add1", SqlDbType.VarChar, 500);
                    sqlParam[1].Value = dds.Tables[0].Rows[i]["PresentAddress1"].ToString();
                    sqlParam[2] = new SqlParameter("@pre_Add2", SqlDbType.VarChar, 500);
                    sqlParam[2].Value = dds.Tables[0].Rows[i]["PresentAddress2"].ToString();
                    sqlParam[3] = new SqlParameter("@pre_city", SqlDbType.VarChar, 100);
                    if ((dds.Tables[0].Rows[i]["PresentCity"].ToString() == "0") || (dds.Tables[0].Rows[i]["PresentCity"].ToString() == ""))
                    {
                        sqlParam[3].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlParam[3].Value = dds.Tables[0].Rows[i]["PresentCity"].ToString();
                    }

                    sqlParam[4] = new SqlParameter("@pre_state", SqlDbType.VarChar, 50);
                    if ((dds.Tables[0].Rows[i]["PresentState"].ToString() == "0") || (dds.Tables[0].Rows[i]["PresentState"].ToString() == ""))
                    {
                        sqlParam[4].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlParam[4].Value = dds.Tables[0].Rows[i]["PresentState"].ToString();
                    }
                    sqlParam[5] = new SqlParameter("@pre_country", SqlDbType.VarChar, 50);
                    if ((dds.Tables[0].Rows[i]["PresentCountry"].ToString() == "0") || (dds.Tables[0].Rows[i]["PresentCountry"].ToString() == ""))
                    {
                        sqlParam[5].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlParam[5].Value = dds.Tables[0].Rows[i]["PresentCountry"].ToString();
                    }
                    sqlParam[6] = new SqlParameter("@pre_zip", SqlDbType.VarChar, 50);
                    sqlParam[6].Value = dds.Tables[0].Rows[i]["PresentZipcode"].ToString();
                    sqlParam[7] = new SqlParameter("@pre_phone", SqlDbType.VarChar, 50);
                    sqlParam[7].Value = dds.Tables[0].Rows[i]["PresentPhoneNo"].ToString();
                    sqlParam[8] = new SqlParameter("@per_add1", SqlDbType.VarChar, 500);
                    sqlParam[8].Value = dds.Tables[0].Rows[i]["PermanentAddress1"].ToString();
                    sqlParam[9] = new SqlParameter("@per_add2", SqlDbType.VarChar, 500);
                    sqlParam[9].Value = dds.Tables[0].Rows[i]["PermanentAddress2"].ToString();
                    sqlParam[10] = new SqlParameter("@per_city", SqlDbType.VarChar, 100);
                    if ((dds.Tables[0].Rows[i]["PermanentCity"].ToString() == "0") || (dds.Tables[0].Rows[i]["PermanentCity"].ToString() == ""))
                    {
                        sqlParam[10].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlParam[10].Value = dds.Tables[0].Rows[i]["PermanentCity"].ToString();
                    }
                    sqlParam[11] = new SqlParameter("@per_state", SqlDbType.VarChar, 50);
                    if ((dds.Tables[0].Rows[i]["PermanentState"].ToString() == "0") || (dds.Tables[0].Rows[i]["PermanentState"].ToString() == ""))
                    {
                        sqlParam[11].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlParam[11].Value = dds.Tables[0].Rows[i]["PermanentState"].ToString();
                    }
                    sqlParam[12] = new SqlParameter("@per_country", SqlDbType.VarChar, 50);
                    if ((dds.Tables[0].Rows[i]["PermanentCountry"].ToString() == "0") || (dds.Tables[0].Rows[i]["PermanentCountry"].ToString() == ""))
                    {
                        sqlParam[12].Value = System.Data.SqlTypes.SqlString.Null;
                    }
                    else
                    {
                        sqlParam[12].Value = dds.Tables[0].Rows[i]["PermanentCountry"].ToString();
                    }
                    sqlParam[13] = new SqlParameter("@per_zip", SqlDbType.VarChar, 50);
                    sqlParam[13].Value = dds.Tables[0].Rows[i]["PermanentZipCode"].ToString();
                    sqlParam[14] = new SqlParameter("@per_phone", SqlDbType.VarChar, 50);
                    sqlParam[14].Value = dds.Tables[0].Rows[i]["PermanentPhoneNo"].ToString();
                    sqlParam[15] = new SqlParameter("@mode", SqlDbType.TinyInt);
                    if (dds.Tables[0].Rows[i]["ModeofTransport"].ToString() == "")
                    {
                        sqlParam[15].Value = 1;
                    }
                    else
                    {
                        sqlParam[15].Value = dds.Tables[0].Rows[i]["ModeofTransport"].ToString();
                    }

                    //if (optcompany.Checked)
                    //{
                    //    sqlParam[15].Value = 1;
                    //}

                    //if (optown.Checked)
                    //{
                    //    sqlParam[15].Value = 0;
                    //}

                    sqlParam[16] = new SqlParameter("@modeoftransport", SqlDbType.VarChar, 50);
                    sqlParam[16].Value = dds.Tables[0].Rows[i]["PickupPoint"].ToString().Trim();

                    sqlParam[17] = new SqlParameter("@emergency_contact_no", SqlDbType.VarChar, 50);
                    sqlParam[17].Value = System.Data.SqlTypes.SqlInt32.Null;// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[18] = new SqlParameter("@emergency_name", SqlDbType.VarChar, 50);
                    sqlParam[18].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[19] = new SqlParameter("@emergency_relation", SqlDbType.VarChar, 50);
                    sqlParam[19].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[20] = new SqlParameter("@emergency_address1", SqlDbType.VarChar, 500);
                    sqlParam[20].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[21] = new SqlParameter("@emergency_address2", SqlDbType.VarChar, 500);
                    sqlParam[21].Value = "";// dds.Tables[0].Rows[i]["EmpCode"].ToString();

                    sqlParam[22] = new SqlParameter("@emergency_city", SqlDbType.Int);
                    //if ((dds.Tables[0].Rows[i]["EmpCode"].ToString() == "0") || (dds.Tables[0].Rows[i]["EmpCode"].ToString() == ""))
                    //{
                    sqlParam[22].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    //    sqlParam[22].Value = Convert.ToInt32(dds.Tables[0].Rows[i]["EmpCode"].ToString());
                    //}

                    sqlParam[23] = new SqlParameter("@emergency_state", SqlDbType.Int);
                    //if ((dds.Tables[0].Rows[i]["EmpCode"].ToString() == "0") || (dds.Tables[0].Rows[i]["EmpCode"].ToString() == ""))
                    //{
                    sqlParam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
                    //}
                    //else
                    //{
                    //    sqlParam[23].Value = Convert.ToInt32(dds.Tables[0].Rows[i]["EmpCode"].ToString());
                    //}
                    sqlParam[24] = new SqlParameter("@emergency_country", SqlDbType.VarChar, 50);
                    //if ((dds.Tables[0].Rows[i]["EmpCode"].ToString() == "0") || (dds.Tables[0].Rows[i]["EmpCode"].ToString() == ""))
                    //{
                    sqlParam[24].Value = System.Data.SqlTypes.SqlString.Null;
                    //}
                    //else
                    //{
                    //    sqlParam[24].Value = System.Data.SqlTypes.SqlString.Null;//dds.Tables[0].Rows[i]["EmpCode"].ToString();
                    //}

                    sqlParam[25] = new SqlParameter("@emergency_zip", SqlDbType.VarChar, 50);
                    sqlParam[25].Value = System.Data.SqlTypes.SqlString.Null;

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_contactdetails]", sqlParam);
                }
            }
        }

        catch (Exception ex)
        {
            ShowAlertMessage("Please check Excel format.sheet must be named ContactDetails.");
        }
    }

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

    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
}