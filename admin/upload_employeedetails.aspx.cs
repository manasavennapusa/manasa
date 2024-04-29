using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System;
using Common.Data;
using Common.Console;
using System.Globalization;
using DataAccessLayer;
using System.Text;
using System.EnterpriseServices;
using System.Data.OleDb;

public partial class admin_upload_employeedetails : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    int iferror = 0;
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
    }
    protected void btnJobdetails_Click(object sender, EventArgs e)
    {
        string Version = "none";
        string Path = "";
        if (fileuploadJob.HasFile)
        {
            if (UploadDocument(ref Version, ref Path))
            {
                string ConnectionString = GetConnection(Version, Path);
                DataTable[] dt = new DataTable[1];

                dt[0] = GetExcelDate("SELECT * FROM [Jobdetails$]", ConnectionString);

                fileuploadJob.Dispose();
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
        SaveJobDetails(dtEmp[0]);
        SavePayStructureDetails(dtEmp[0]);
        insert_audit_log(dtEmp[0]);
    }

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
            if (fileuploadJob.PostedFile.FileName.ToString() != "")
            {
                fn = System.IO.Path.GetFileName(fileuploadJob.PostedFile.FileName.ToString());
                ftype = System.IO.Path.GetExtension(fn);
                switch (ftype)
                {
                    case ".xls":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fileuploadJob.PostedFile.FileName);
                            fileuploadJob.PostedFile.SaveAs(file_name);
                            ViewState.Add("file_name", fn.ToString());
                            flag = true;
                            version = "4.0";
                            path = file_name;
                            break;
                        }
                    case ".xlsx":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fileuploadJob.PostedFile.FileName);
                            //  file_name = Server.MapPath(".") + "\\upload\\" + flEmployee.FileName + DateTime.Now.ToString();
                            fileuploadJob.PostedFile.SaveAs(file_name);
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
                        if (dt.Rows[i]["salutation"].ToString().Trim() != "")
                        {
                            Query = Query + " salutation =  '" + dt.Rows[i]["salutation"].ToString().Trim() + "'";
                            First = 1;
                        }
                        if (dt.Rows[i]["FirstName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_fname = '" + dt.Rows[i]["FirstName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "emp_fname = '" + dt.Rows[i]["FirstName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["MiddleName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_m_name = '" + dt.Rows[i]["MiddleName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "emp_m_name = '" + dt.Rows[i]["MiddleName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["LastName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",emp_l_name = '" + dt.Rows[i]["LastName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "emp_l_name = '" + dt.Rows[i]["LastName"].ToString().Trim() + "'";
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

                        if (dt.Rows[i]["Branch"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",branch_id = " + dt.Rows[i]["Branch"].ToString().Trim();
                            else
                            {
                                Query = Query + "branch_id = " + dt.Rows[i]["Branch"].ToString().Trim();
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
                                Query = Query + ",emp_doj = '" + Convert.ToDateTime(dt.Rows[i]["Dateofjoining"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                            else
                            {
                                Query = Query + "emp_doj = '" + Convert.ToDateTime(dt.Rows[i]["Dateofjoining"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
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

                      
                        if (First == 1)
                            Query = Query + ",supervisorcode = '0'";
                        else
                        {
                            Query = Query + "supervisorcode = '0'";
                            First = 1;
                        }
                      
                        if (First == 1)
                            Query = Query + ",corporatereportingcode = '0'";
                        else
                        {
                            Query = Query + "corporatereportingcode = '0'";
                            First = 1;
                        }
                       
                        if (First == 1)
                            Query = Query + ",hodcode ='0'";
                        else
                        {
                            Query = Query + "hodcode = '0'";
                            First = 1;
                        }
                       

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
                        if (dt.Rows[i]["Landno"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Landno = '" + dt.Rows[i]["Landno"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "Landno = '" + dt.Rows[i]["Landno"].ToString().Trim() + "'";
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

                        if (dt.Rows[i]["StaffType"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",staff_type = '" + dt.Rows[i]["StaffType"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "staff_type = '" + dt.Rows[i]["StaffType"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Department"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",dept_id = '" + dt.Rows[i]["Department"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "dept_id = '" + dt.Rows[i]["Department"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "2")
                            {
                                if (dt.Rows[i]["ConfirmationDate"].ToString().Trim() != "")
                                {
                                    if (First == 1)
                                        Query = Query + ",confirmationdate = '" + Convert.ToDateTime(dt.Rows[i]["ConfirmationDate"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                                    else
                                    {
                                        Query = Query + "confirmationdate = '" + Convert.ToDateTime(dt.Rows[i]["ConfirmationDate"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                                        First = 1;
                                    }
                                }
                            }
                        }
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "1")
                            {
                                if (dt.Rows[i]["ProbationEndDate"].ToString().Trim() != "")
                                {
                                    if (First == 1)
                                        Query = Query + ",probationenddate = '" + dt.Rows[i]["ProbationEndDate"].ToString().Trim() + "'";
                                    else
                                    {
                                        Query = Query + "probationenddate = '" + dt.Rows[i]["ProbationEndDate"].ToString().Trim() + "'";
                                        First = 1;
                                    }
                                }
                            }
                        }
                        if (dt.Rows[i]["Siffix"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",suffix1 = '" + dt.Rows[i]["Siffix"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "suffix1 = '" + dt.Rows[i]["Siffix"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Alias"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",alias = '" + dt.Rows[i]["Alias"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "alias = '" + dt.Rows[i]["Alias"].ToString().Trim() + "'";
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
                        // if not exists


                        SqlParameter[] p = new SqlParameter[32];


                        p[0] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["salutation"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["salutation"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@EmployeeFName", SqlDbType.VarChar, 200);
                        if (dt.Rows[i]["FirstName"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["FirstName"].ToString().Trim();

                        }
                        p[2] = new SqlParameter("@EmployeeMName", SqlDbType.VarChar, 200);
                        if (dt.Rows[i]["MiddleName"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["MiddleName"].ToString().Trim();

                        }
                        p[3] = new SqlParameter("@EmployeeLName", SqlDbType.VarChar, 200);
                        if (dt.Rows[i]["LastName"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["LastName"].ToString().Trim();

                        }
                        p[4] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["EmployeeNo"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["EmployeeNo"].ToString().Trim();
                        }

                        p[5] = new SqlParameter("@LoginPassword", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["LoginPassword"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            int saltSize = 5;
                            string salt = CreateSalt(saltSize);
                            string passwordHash = CreatePasswordHash(dt.Rows[i]["LoginPassword"].ToString().Trim(), salt);
                            p[5].Value = passwordHash.ToString().Trim();
                        }

                        p[6] = new SqlParameter("@Gender", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Gender"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = p[6].Value = dt.Rows[i]["Gender"].ToString().Trim();

                        }
                        p[7] = new SqlParameter("@Worklocation", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Branch"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["Branch"].ToString().Trim();
                        }
                        
                        p[8] = new SqlParameter("@Costcenter", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Costcenter"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["Costcenter"].ToString().Trim();
                        }
                        p[9] = new SqlParameter("@BusinessUnit", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BusinessUnit"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["BusinessUnit"].ToString().Trim();
                        }
                        p[10] = new SqlParameter("@Designation", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Designation"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["Designation"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@Grade", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Grade"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["Grade"].ToString().Trim();

                        }
                        p[12] = new SqlParameter("@EmployeeRole", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeRole"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["EmployeeRole"].ToString().Trim();

                        }
                        p[13] = new SqlParameter("@EmployeeStatus", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["EmployeeStatus"].ToString().Trim();
                        }
                        p[14] = new SqlParameter("@Dateofjoining", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Dateofjoining"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[14].Value = Convert.ToDateTime(dt.Rows[i]["Dateofjoining"].ToString().Trim()).ToString("MM-dd-yyyy");
                        }
                        p[15] = new SqlParameter("@OfficialMobileNo", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["OfficialMobileNo"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["OfficialMobileNo"].ToString().Trim();
                        }
                        p[16] = new SqlParameter("@OfficalEmailId", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["OfficalEmailId"].ToString().Trim() == "")
                        {
                            p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[16].Value = dt.Rows[i]["OfficalEmailId"].ToString().Trim();
                        }
                        p[17] = new SqlParameter("@Ext_Number", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Ext_Number"].ToString().Trim() == "")
                        {
                            p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[17].Value = dt.Rows[i]["Ext_Number"].ToString().Trim();
                        }
                        p[18] = new SqlParameter("@ReportingManager", SqlDbType.VarChar, 50);
                        p[18].Value = System.Data.SqlTypes.SqlString.Null;
                       
                        p[19] = new SqlParameter("@FunctionalManager", SqlDbType.VarChar, 50);
                        p[19].Value = System.Data.SqlTypes.SqlString.Null;
                       
                        p[20] = new SqlParameter("@UnitHead", SqlDbType.VarChar, 50);
                        p[20].Value = System.Data.SqlTypes.SqlString.Null;
                       
                        p[21] = new SqlParameter("@DateofLeaving", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DateofLeaving"].ToString().Trim() == "")
                        {
                            p[21].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[21].Value = dt.Rows[i]["DateofLeaving"].ToString().Trim();
                        }

                        p[22] = new SqlParameter("@ReasonforLeaving", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ReasonforLeaving"].ToString().Trim() == "")
                        {
                            p[22].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[22].Value = dt.Rows[i]["ReasonforLeaving"].ToString().Trim();
                        }

                        p[23] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                        p[23].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();

                        p[24] = new SqlParameter("@conformationdate", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "2")
                            {
                                if (dt.Rows[i]["ConfirmationDate"].ToString().Trim() == "")
                                {
                                    p[24].Value = System.Data.SqlTypes.SqlDateTime.Null;
                                }
                                else
                                {
                                    p[24].Value = Convert.ToDateTime(dt.Rows[i]["ConfirmationDate"].ToString().Trim()).ToString("MM-dd-yyyy");
                                }
                            }
                            else
                            {
                                p[24].Value = System.Data.SqlTypes.SqlDateTime.Null;
                            }
                        }
                        else
                            p[24].Value = System.Data.SqlTypes.SqlDateTime.Null;

                        p[25] = new SqlParameter("@employee_type", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeType"].ToString().Trim() == "")
                        {
                            p[25].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[25].Value = dt.Rows[i]["EmployeeType"].ToString().Trim();
                        }

                        p[26] = new SqlParameter("@sub_emp_type", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["StaffType"].ToString().Trim() == "")
                        {
                            p[26].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[26].Value = dt.Rows[i]["StaffType"].ToString().Trim();
                        }

                        p[27] = new SqlParameter("@dep_type_id", SqlDbType.Int);
                        if (dt.Rows[i]["Department"].ToString().Trim() == "")
                        {
                            p[27].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[27].Value = dt.Rows[i]["Department"].ToString().Trim();
                        }
                        p[28] = new SqlParameter("@Landno", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["Landno"].ToString().Trim() == "")
                        {
                            p[28].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[28].Value = dt.Rows[i]["Landno"].ToString().Trim();
                        }
                        p[29] = new SqlParameter("@Siffix", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Siffix"].ToString().Trim() == "")
                        {
                            p[29].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[29].Value = dt.Rows[i]["Siffix"].ToString().Trim();

                        }
                        p[30] = new SqlParameter("@Alias", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Alias"].ToString().Trim() == "")
                        {
                            p[30].Value = System.Data.SqlTypes.SqlInt32.Null;
                        }
                        else
                        {
                            p[30].Value = dt.Rows[i]["Alias"].ToString().Trim();

                        }
                        p[31] = new SqlParameter("@probationenddate", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["EmployeeStatus"].ToString().Trim() == "1")
                            {
                                if (dt.Rows[i]["ProbationEndDate"].ToString().Trim() == "")
                                {
                                    p[31].Value = System.Data.SqlTypes.SqlDateTime.Null;
                                }
                                else
                                {
                                    p[31].Value = dt.Rows[i]["ProbationEndDate"].ToString().Trim();
                                }
                            }
                            else
                            {
                                p[31].Value = System.Data.SqlTypes.SqlDateTime.Null;
                            }
                        }
                        else
                            p[31].Value = System.Data.SqlTypes.SqlDateTime.Null;

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_InsertJobDetail", p);//if u face any prblm just chng storeprocedure by "SP_InsertJobDetails"

                       
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

    #region Paystructure Details
    private void SavePayStructureDetails(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[3];

                p[0] = new SqlParameter("@degination_id", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Designation"].ToString().Trim() == "")
                {
                    p[0].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[0].Value = dt.Rows[i]["Designation"].ToString().Trim();

                }
                p[1] = new SqlParameter("@Grade", SqlDbType.VarChar, 50);
                if (dt.Rows[i]["Grade"].ToString().Trim() == "")
                {
                    p[1].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    p[1].Value = dt.Rows[i]["Grade"].ToString().Trim();

                }

                p[2] = new SqlParameter("@emp_code", SqlDbType.VarChar, 50);
                p[2].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();


                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_edit_paystructure", p);//if u face any prblm just chng storeprocedure by "SP_InsertJobDetails"              

            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Job Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }

    }
    #endregion

    #region Audit Log Details
    protected void insert_audit_log(DataTable dt)
    {

        string IPAdd = string.Empty;
        IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(IPAdd))
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];

        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@ip_address", SqlDbType.VarChar, 50);
        sqlparam[1].Value = IPAdd;

        sqlparam[2] = new SqlParameter("@Roles", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["role"].ToString();

        sqlparam[3] = new SqlParameter("@types", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "User Action";

        sqlparam[4] = new SqlParameter("@actions", SqlDbType.VarChar, 150);
        sqlparam[4].Value = "Insert Employee Details through Upload";

        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_audit_log]", sqlparam);

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

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        string Version = "none";
        string Path = "";
        if (fileUpload.HasFile)
        {
            if (UploadDocumentforAll(ref Version, ref Path))
            {
                string ConnectionString = GetConnection(Version, Path);
                DataTable[] dt = new DataTable[7];
          
                dt[0] = GetExcelDate("SELECT * FROM [Employee_Payroll_Details$]", ConnectionString);
                dt[1] = GetExcelDate("SELECT * FROM [ContactDetails$]", ConnectionString);
                dt[2] = GetExcelDate("SELECT * FROM [EmgContactDetails$]", ConnectionString);
                dt[3] = GetExcelDate("SELECT * FROM [Educational_Qualification$]", ConnectionString);
                dt[4] = GetExcelDate("SELECT * FROM [Experience_Details$]", ConnectionString);
                dt[5] = GetExcelDate("SELECT * FROM [PersonalDetails$]", ConnectionString);
                dt[6] = GetExcelDate("SELECT * FROM [Foreign_Citizenship$]", ConnectionString);

                fileuploadJob.Dispose();
                InsertEmployeeDetailsall(dt);
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

    #region Upload Excel Document
    protected bool UploadDocumentforAll(ref string version, ref string path)
    {
        try
        {
            string file_name, fn, ftype;
            bool flag = false;
            if (fileUpload.PostedFile.FileName.ToString() != "")
            {
                fn = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName.ToString());
                ftype = System.IO.Path.GetExtension(fn);
                switch (ftype)
                {
                    case ".xls":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);
                            fileUpload.PostedFile.SaveAs(file_name);
                            ViewState.Add("file_name", fn.ToString());
                            flag = true;
                            version = "4.0";
                            path = file_name;
                            break;
                        }
                    case ".xlsx":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);
                            //  file_name = Server.MapPath(".") + "\\upload\\" + flEmployee.FileName + DateTime.Now.ToString();
                            fileUpload.PostedFile.SaveAs(file_name);
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

    private void InsertEmployeeDetailsall(DataTable[] dtEmp)
    {           
            SavePayrollDetails(dtEmp[0]);
            SaveContactDetails(dtEmp[1]);
            SaveEmgContactDetails(dtEmp[2]);
            SaveEducationQualificationDetails(dtEmp[3]);
            SaveExperienceDetails(dtEmp[4]);
            SavePersonalDetails(dtEmp[5]);
            SaveForeignCitizenship(dtEmp[6]);
    }

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
                                Query = Query + ",pf_no= '" + dt.Rows[i]["PF_Number"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "pf_no= '" + dt.Rows[i]["PF_Number"].ToString().Trim() + "'";
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
                        if (dt.Rows[i]["Payroll_Process"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Payroll_Process= '" + dt.Rows[i]["Payroll_Process"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Payroll_Process= '" + dt.Rows[i]["Payroll_Process"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["payment_Mode"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Payment_Mode= '" + dt.Rows[i]["payment_Mode"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Payment_Mode= '" + dt.Rows[i]["payment_Mode"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Salary_A/C"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Salary_Ac= '" + dt.Rows[i]["Salary_A/C"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Salary_Ac= '" + dt.Rows[i]["Salary_A/C"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Ifce"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Ifsc_Code= '" + dt.Rows[i]["Ifce"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Ifsc_Code= '" + dt.Rows[i]["Ifce"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Acoount_type"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Account_Type= '" + dt.Rows[i]["Acoount_type"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Account_Type= '" + dt.Rows[i]["Acoount_type"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Bank_Name"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Bank_Name= '" + dt.Rows[i]["Bank_Name"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Bank_Name= '" + dt.Rows[i]["Bank_Name"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["BankBranch_Name"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Bankbranch_Name= '" + dt.Rows[i]["BankBranch_Name"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Bankbranch_Name= '" + dt.Rows[i]["BankBranch_Name"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["AdharCard"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Adhar_No= '" + dt.Rows[i]["AdharCard"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Adhar_No= '" + dt.Rows[i]["AdharCard"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Eligible_Year"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Graduity_Year= '" + dt.Rows[i]["Eligible_Year"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Graduity_Year= '" + dt.Rows[i]["Eligible_Year"].ToString().Trim() + "'";
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

                        SqlParameter[] p = new SqlParameter[17];


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
                        p[8] = new SqlParameter("@Payroll_Process", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Payroll_Process"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["Payroll_Process"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@payment_Mode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["payment_Mode"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["payment_Mode"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@salary", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Salary_A/C"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["Salary_A/C"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@Ifce", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Ifce"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["Ifce"].ToString().Trim();

                        }
                        p[12] = new SqlParameter("@Acoount_type", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Acoount_type"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["Acoount_type"].ToString().Trim();

                        }
                        p[13] = new SqlParameter("@Bank_Name", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Bank_Name"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["Bank_Name"].ToString().Trim();

                        }
                        p[14] = new SqlParameter("@BankBranch_Name", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BankBranch_Name"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["BankBranch_Name"].ToString().Trim();

                        }
                        p[15] = new SqlParameter("@Adhar_no", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["AdharCard"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["AdharCard"].ToString().Trim();

                        }
                        p[16] = new SqlParameter("@Eligible_year", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Eligible_Year"].ToString().Trim() == "")
                        {
                            p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[16].Value = dt.Rows[i]["Eligible_Year"].ToString().Trim();

                        }
                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SavePayrollDetail", p);
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
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from tbl_employee_edcationalqualifications1 where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
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
                        SqlParameter[] p = new SqlParameter[9];


                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@EducationType", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EducationType"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["EducationType"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@CertificateType", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["CertificateType"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["CertificateType"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@CertificateName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["CertificateName"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["CertificateName"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@Duration", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["Duration"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["Duration"].ToString().Trim();

                        }

                        p[5] = new SqlParameter("@DurationFormat", SqlDbType.VarChar, 20);
                        if (dt.Rows[i]["DurationFormat"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["DurationFormat"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@Institute", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["Institute"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["Institute"].ToString().Trim();
                        }
                        p[7] = new SqlParameter("@PassYear", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["PassYear"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["PassYear"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@Regd_Number", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["Regd_Number"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["Regd_Number"].ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveEducationQualifications", p);
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
                        SqlParameter[] p = new SqlParameter[12];


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

                        p[4] = new SqlParameter("@EsiNumber", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EsiNumber"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["EsiNumber"].ToString().Trim();

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
                        p[7] = new SqlParameter("@Industry", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Industry"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["Industry"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@ContactNumber", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ContactNumber"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["ContactNumber"].ToString().Trim();
                        }
                        p[9] = new SqlParameter("@ServiceDomain", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ServiceDomain"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["ServiceDomain"].ToString().Trim();
                        }
                        p[10] = new SqlParameter("@LastCTC", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["LastCTC"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["LastCTC"].ToString().Trim();
                        }
                        p[11] = new SqlParameter("@PFNumber", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PFNumber"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["PFNumber"].ToString().Trim();
                        }


                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveExperienceInfo", p);
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

    #region ForeignCitizenship
    private void SaveForeignCitizenship(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {


                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        string sqlstr1 = "delete from Foreign_Citizenship where empcode ='" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'";
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);

                        //int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete  Foreign_Citizenship where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting ForeignCitizenship Details                Error: " + ex.Message + ".          " + DateTime.Now);
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
                        SqlParameter[] p = new SqlParameter[5];


                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@Town", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["Town"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Town"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@Country", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["Country"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Country"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                        if (dt.Rows[i]["FromDate"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[3].Value = Convert.ToDateTime(dt.Rows[i]["FromDate"]).ToString("dd-MMM-yyyy").Trim();
                        }

                        p[4] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                        if (dt.Rows[i]["ToDate"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[4].Value = Convert.ToDateTime(dt.Rows[i]["ToDate"]).ToString("dd-MMM-yyyy").Trim();

                        }



                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveForeignCitigen", p);
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

    #region ForeignSojourns
    private void SaveForeigSojourns(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from Foreign_Sojourns where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting Foreign Sojourns Details                Error: " + ex.Message + ".          " + DateTime.Now);
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

                        p[1] = new SqlParameter("@Town", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["Town"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Town"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@Country", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["Country"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Country"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                        if (dt.Rows[i]["FromDate"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[3].Value = Convert.ToDateTime(dt.Rows[i]["FromDate"]).ToString("dd-MMM-yyyy").Trim();
                        }

                        p[4] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                        if (dt.Rows[i]["ToDate"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[4].Value = Convert.ToDateTime(dt.Rows[i]["ToDate"]).ToString("dd-MMM-yyyy").Trim();

                        }
                        p[5] = new SqlParameter("@Purpose", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["Purpose"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["Purpose"].ToString().Trim();
                        }


                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveForeignSojourns", p);
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

    #region DrivingLicense
    private void SaveDrivingLicense(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from Driving_lc where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting DrivingLicense Details                Error: " + ex.Message + ".          " + DateTime.Now);
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
                        SqlParameter[] p = new SqlParameter[4];


                        p[0] = new SqlParameter("@EmpCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@Dlno", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["DlNo"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["DlNo"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@IssueDate", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["IssueDate"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["IssueDate"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@ValidTill", SqlDbType.DateTime);
                        if (dt.Rows[i]["ValidTill"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[3].Value = Convert.ToDateTime(dt.Rows[i]["ValidTill"]).ToString().Trim();
                        }



                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveDl", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Driving License Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }
    #endregion

    #region VisaAvailable
    private void SaveVisaAvailable(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "delete from Visa_Available where empcode = '" + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Deleting Visa Available Details                Error: " + ex.Message + ".          " + DateTime.Now);
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

                        p[1] = new SqlParameter("@VISACountry", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["VISACountry"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["VISACountry"].ToString().Trim();

                        }



                        p[2] = new SqlParameter("@IssueDate", SqlDbType.DateTime);
                        if (dt.Rows[i]["IssueDate"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["IssueDate"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@ExpiryDate", SqlDbType.DateTime);
                        if (dt.Rows[i]["ExpiryDate"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["ExpiryDate"].ToString().Trim();

                        }
                        p[4] = new SqlParameter("@VISAType", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["VISAType"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["VISAType"].ToString().Trim();
                        }
                        p[5] = new SqlParameter("@VisaEntries", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["VisaEntries"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["VisaEntries"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@VisaNumber", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["VisaNumber"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["VisaNumber"].ToString().Trim();
                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SaveVisaAvailable", p);
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

    #region PFNomination
    private void SavePFNomination(DataTable dt)
    {

        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExistPFNominationDetails(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_employee_Pf_Nomination_Details set ";
                        if (dt.Rows[i]["NomineeName"].ToString().Trim() != "")
                        {
                            Query = Query + "Nominee_Name =  '" + dt.Rows[i]["NomineeName"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["Relationship"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Rel= '" + dt.Rows[i]["Relationship"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "Rel= '" + dt.Rows[i]["Relationship"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }


                        if (dt.Rows[i]["Address"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Address = '" + dt.Rows[i]["Address"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Address = '" + dt.Rows[i]["Address"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["DOB"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",dob = '" + dt.Rows[i]["DOB"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " dob = '" + dt.Rows[i]["DOB"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }




                        if (dt.Rows[i]["Age(Yrs)"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Age = '" + dt.Rows[i]["Age(Yrs)"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Age = '" + dt.Rows[i]["Age(Yrs)"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["ShareFund"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Share_Fund = '" + dt.Rows[i]["ShareFund"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Share_Fund = '" + dt.Rows[i]["ShareFund"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["PercentageorNumber"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Percentage= '" + dt.Rows[i]["PercentageorNumber"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Percentage= '" + dt.Rows[i]["PercentageorNumber"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["GuradianName"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",G_Name= '" + dt.Rows[i]["GuradianName"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " G_Name= '" + dt.Rows[i]["GuradianName"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["GuradianAddress"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",G_Address= '" + dt.Rows[i]["GuradianAddress"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " G_Address= '" + dt.Rows[i]["GuradianAddress"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["PaymentMode"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Payment_Mode= '" + dt.Rows[i]["PaymentMode"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Payment_Mode= '" + dt.Rows[i]["PaymentMode"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        //if (dt.Rows[i]["Acoount_type"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Account_Type= '" + dt.Rows[i]["Acoount_type"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Account_Type= '" + dt.Rows[i]["Acoount_type"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["Bank_Name"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Bank_Name= '" + dt.Rows[i]["Bank_Name"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Bank_Name= '" + dt.Rows[i]["Bank_Name"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["BankBranch_Name"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Bankbranch_Name= '" + dt.Rows[i]["BankBranch_Name"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Bankbranch_Name= '" + dt.Rows[i]["BankBranch_Name"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["AdharCard"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Adhar_No= '" + dt.Rows[i]["AdharCard"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Adhar_No= '" + dt.Rows[i]["AdharCard"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["Eligible_Year"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Graduity_Year= '" + dt.Rows[i]["Eligible_Year"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Graduity_Year= '" + dt.Rows[i]["Eligible_Year"].ToString().Trim() + "'";
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

                        SqlParameter[] p = new SqlParameter[11];


                        p[0] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["EmployeeCode"].ToString().Trim() == "")
                        {
                            p[0].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[0].Value = dt.Rows[i]["EmployeeCode"].ToString().Trim();
                        }

                        p[1] = new SqlParameter("@NomineeName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["NomineeName"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["NomineeName"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@Relationship", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Relationship"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Relationship"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@Address", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["Address"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["Address"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@DOB", SqlDbType.DateTime);
                        if (dt.Rows[i]["DOB"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["DOB"].ToString().Trim();

                        }
                        p[5] = new SqlParameter("@Age", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Age(Yrs)"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["Age(Yrs)"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@ShareFund", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ShareFund"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["ShareFund"].ToString().Trim();

                        }
                        p[7] = new SqlParameter("@PercentageorNumber", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PercentageorNumber"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["PercentageorNumber"].ToString().Trim();

                        }
                        p[8] = new SqlParameter("@GuradianName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["GuradianName"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["GuradianName"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@GuradianAddress", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["GuradianAddress"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["GuradianAddress"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@PaymentMode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PaymentMode"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["PaymentMode"].ToString().Trim();

                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SavePfNomiantion", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving PFNomiantion Details                Error: " + ex.Message + ".          " + DateTime.Now);
            }
        }
    }





    #endregion

    #region MedicalInsuranceDetails
    private void SaveMedicalInsurance(DataTable dt)
    {
        string Query = "";
        int First = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (dt.Rows[i]["EmployeeCode"].ToString().Trim() != "")
                {
                    if (EmployeeExistMedicalInsuranceDetails(dt.Rows[i]["EmployeeCode"].ToString().Trim()))
                    {
                        // if exists
                        Query = "update tbl_emp_Medical_insurance_Details set ";
                        if (dt.Rows[i]["NomineeName"].ToString().Trim() != "")
                        {
                            Query = Query + "Nominee_Name =  '" + dt.Rows[i]["NomineeName"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["Relationship"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Rel= '" + dt.Rows[i]["Relationship"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + "Rel= '" + dt.Rows[i]["Relationship"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }


                        if (dt.Rows[i]["PresentAddress"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Address_1 = '" + dt.Rows[i]["PermanentAddress"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Address_1 = '" + dt.Rows[i]["PermanentAddress"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["PermanentAddress"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Address_2 = '" + dt.Rows[i]["PresentAddress"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Address_2 = '" + dt.Rows[i]["PresentAddress"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["NearestLandMark"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Land_Mark = '" + dt.Rows[i]["NearestLandMark"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Land_Mark = '" + dt.Rows[i]["NearestLandMark"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["ResidenceCountry"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Country = '" + dt.Rows[i]["ResidenceCountry"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Country = '" + dt.Rows[i]["ResidenceCountry"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["ResidenceState"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",state = '" + dt.Rows[i]["ResidenceState"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " state = '" + dt.Rows[i]["ResidenceState"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["ZipCode"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",zipcode = '" + dt.Rows[i]["ZipCode"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " zipcode = '" + dt.Rows[i]["ZipCode"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["ResidenceCity"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",city = '" + dt.Rows[i]["ResidenceCity"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " city = '" + dt.Rows[i]["ResidenceCity"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["InsuranceAmount"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",insurance_amount = '" + dt.Rows[i]["InsuranceAmount"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " insurance_amount = '" + dt.Rows[i]["InsuranceAmount"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["DOB"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",dob = '" + dt.Rows[i]["DOB"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " dob = '" + dt.Rows[i]["DOB"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }




                        if (dt.Rows[i]["Age(Yrs)"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Age = '" + dt.Rows[i]["Age(Yrs)"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Age = '" + dt.Rows[i]["Age(Yrs)"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Gender"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",gender = '" + dt.Rows[i]["Gender"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " gender = '" + dt.Rows[i]["Gender"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["BloodGroup"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",blood_grp= '" + dt.Rows[i]["BloodGroup"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " blood_grp= '" + dt.Rows[i]["BloodGroup"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Weight"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Weight= '" + dt.Rows[i]["Weight"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Weight= '" + dt.Rows[i]["Weight"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Height"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Height= '" + dt.Rows[i]["Height"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Height= '" + dt.Rows[i]["Height"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["IdentificationMark"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",PI_Mark= '" + dt.Rows[i]["IdentificationMark"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " PI_Mark= '" + dt.Rows[i]["IdentificationMark"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["LandlineNumber"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",landno= '" + dt.Rows[i]["LandlineNumber"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " landno= '" + dt.Rows[i]["LandlineNumber"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["MobileNumber"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",mobileno= '" + dt.Rows[i]["MobileNumber"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " mobileno= '" + dt.Rows[i]["MobileNumber"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        //if (dt.Rows[i]["Acoount_type"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Account_Type= '" + dt.Rows[i]["Acoount_type"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Account_Type= '" + dt.Rows[i]["Acoount_type"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["Bank_Name"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Bank_Name= '" + dt.Rows[i]["Bank_Name"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Bank_Name= '" + dt.Rows[i]["Bank_Name"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["BankBranch_Name"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Bankbranch_Name= '" + dt.Rows[i]["BankBranch_Name"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Bankbranch_Name= '" + dt.Rows[i]["BankBranch_Name"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["AdharCard"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Adhar_No= '" + dt.Rows[i]["AdharCard"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Adhar_No= '" + dt.Rows[i]["AdharCard"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["Eligible_Year"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",Graduity_Year= '" + dt.Rows[i]["Eligible_Year"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " Graduity_Year= '" + dt.Rows[i]["Eligible_Year"].ToString().Trim() + "'";
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

                        p[1] = new SqlParameter("@NomineeName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["NomineeName"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["NomineeName"].ToString().Trim();

                        }

                        p[2] = new SqlParameter("@Relationship", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Relationship"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Relationship"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@PresentAddress", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["PresentAddress"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["PresentAddress"].ToString().Trim();
                        }
                        p[4] = new SqlParameter("@PermanentAddress", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["PermanentAddress"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["PermanentAddress"].ToString().Trim();
                        }
                        p[5] = new SqlParameter("@NearestLandMark", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["NearestLandMark"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["NearestLandMark"].ToString().Trim();
                        }
                        p[6] = new SqlParameter("@ResidenceCountry", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["ResidenceCountry"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["ResidenceCountry"].ToString().Trim();
                        }
                        p[7] = new SqlParameter("@ResidenceState", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["ResidenceState"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["ResidenceState"].ToString().Trim();
                        }
                        p[8] = new SqlParameter("@ResidenceCity", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["ResidenceCity"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["ResidenceCity"].ToString().Trim();
                        }
                        p[9] = new SqlParameter("@ZipCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["ZipCode"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["ZipCode"].ToString().Trim();
                        }
                        p[10] = new SqlParameter("@InsuranceAmount", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["InsuranceAmount"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["InsuranceAmount"].ToString().Trim();
                        }
                        p[11] = new SqlParameter("@DOB", SqlDbType.DateTime);
                        if (dt.Rows[i]["DOB"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["DOB"].ToString().Trim();

                        }
                        p[12] = new SqlParameter("@Age", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Age(Yrs)"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["Age(Yrs)"].ToString().Trim();
                        }
                        p[13] = new SqlParameter("@Gender", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Gender"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[13].Value = dt.Rows[i]["Gender"].ToString().Trim();

                        }
                        p[14] = new SqlParameter("@BloodGroup", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BloodGroup"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[14].Value = dt.Rows[i]["BloodGroup"].ToString().Trim();

                        }
                        p[15] = new SqlParameter("@Weight", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Weight"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["Weight"].ToString().Trim();

                        }
                        p[16] = new SqlParameter("@Height", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["Height"].ToString().Trim() == "")
                        {
                            p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[16].Value = dt.Rows[i]["Height"].ToString().Trim();

                        }
                        p[17] = new SqlParameter("@IdentificationMark", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["IdentificationMark"].ToString().Trim() == "")
                        {
                            p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[17].Value = dt.Rows[i]["IdentificationMark"].ToString().Trim();

                        }
                        p[18] = new SqlParameter("@LandlineNumber", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["LandlineNumber"].ToString().Trim() == "")
                        {
                            p[18].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[18].Value = dt.Rows[i]["LandlineNumber"].ToString().Trim();

                        }
                        p[19] = new SqlParameter("@MobileNumber", SqlDbType.VarChar, 250);
                        if (dt.Rows[i]["MobileNumber"].ToString().Trim() == "")
                        {
                            p[19].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[19].Value = dt.Rows[i]["MobileNumber"].ToString().Trim();

                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "Sp_Medical_Insurance", p);
                    }
                }
            }
            catch (Exception ex)
            {
                iferror++;
                Log("Employee Code : " + dt.Rows[i]["EmployeeCode"].ToString().Trim() + "                 Method: Saving Medical Insurance Details                Error: " + ex.Message + ".          " + DateTime.Now);
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
                            Query = Query + " dob =  '" + Convert.ToDateTime(dt.Rows[i]["DateofBirth"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
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
                        if (dt.Rows[i]["Nationality"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Nationality = '" + dt.Rows[i]["Nationality"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Nationality = '" + dt.Rows[i]["Nationality"].ToString().Trim() + "'";
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
                        if (dt.Rows[i]["PlaceOfBirth"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Birth_Place = '" + dt.Rows[i]["PlaceOfBirth"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Birth_Place = '" + dt.Rows[i]["PlaceOfBirth"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["PersonalEmailId"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",email_id = '" + dt.Rows[i]["PersonalEmailId"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " email_id = '" + dt.Rows[i]["PersonalEmailId"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Country"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Country = '" + dt.Rows[i]["Country"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Country = '" + dt.Rows[i]["Country"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["State"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",State = '" + dt.Rows[i]["State"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " State = '" + dt.Rows[i]["State"].ToString().Trim() + "'";
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
                        if (dt.Rows[i]["MobileNo"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",mobile_no = '" + dt.Rows[i]["MobileNo"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " mobile_no = '" + dt.Rows[i]["MobileNo"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Weight"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Weight = '" + dt.Rows[i]["Weight"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Weight = '" + dt.Rows[i]["Weight"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Height"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Height = '" + dt.Rows[i]["Height"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Height = '" + dt.Rows[i]["Height"].ToString().Trim() + "'";
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
                                Query = Query + ",passportissuedate = '" + Convert.ToDateTime(dt.Rows[i]["PassPortIssueDate"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                            else
                            {
                                Query = Query + " passportissuedate = '" + Convert.ToDateTime(dt.Rows[i]["PassPortIssueDate"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["PassPortExpiryDate"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",passportexpiraydate = '" + Convert.ToDateTime(dt.Rows[i]["PassPortExpiryDate"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                            else
                            {
                                Query = Query + " passportexpiraydate = '" + Convert.ToDateTime(dt.Rows[i]["PassPortExpiryDate"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["BirthCertificateNumber"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Birth_Cert_No = '" + dt.Rows[i]["BirthCertificateNumber"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Birth_Cert_No = '" + dt.Rows[i]["BirthCertificateNumber"].ToString().Trim() + "'";
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
                                Query = Query + ",doa = '" + Convert.ToDateTime(dt.Rows[i]["DateOfAnniversary"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                            else
                            {
                                Query = Query + " doa = '" + Convert.ToDateTime(dt.Rows[i]["DateOfAnniversary"].ToString().Trim()).ToString("MM-dd-yyyy") + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["NumberofChildren"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",no_child = '" + dt.Rows[i]["NumberofChildren"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " no_child = '" + dt.Rows[i]["NumberofChildren"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        //if (dt.Rows[i]["PaymentMode"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",paymentmode = '" + dt.Rows[i]["PaymentMode"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " paymentmode = '" + dt.Rows[i]["PaymentMode"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

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

                        //if (dt.Rows[i]["BankNameforSalary"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",bank_name = '" + dt.Rows[i]["BankNameforSalary"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + "bank_name = '" + dt.Rows[i]["BankNameforSalary"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        //if (dt.Rows[i]["AccountNoforSalary"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",ac_number = '" + dt.Rows[i]["AccountNoforSalary"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " ac_number = '" + dt.Rows[i]["AccountNoforSalary"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}










                        //if (dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",dribing_lic_iss_date = '" + dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " dribing_lic_iss_date = '" + dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        //if (dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",driving_lic_exp_date = '" + dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " driving_lic_exp_date = '" + dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}





                        //if (dt.Rows[i]["IFSC_code"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",ifsc = '" + dt.Rows[i]["IFSC_code"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " ifsc = '" + dt.Rows[i]["IFSC_code"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["TShirtSize"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",f_mname = '" + dt.Rows[i]["TShirtSize"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " f_mname = '" + dt.Rows[i]["TShirtSize"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["ShirtSize"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",f_lname = '" + dt.Rows[i]["ShirtSize"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " f_lname = '" + dt.Rows[i]["ShirtSize"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}

                        //if (dt.Rows[i]["LandLineNo"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",landlineno = '" + dt.Rows[i]["LandLineNo"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " landlineno = '" + dt.Rows[i]["LandLineNo"].ToString().Trim() + "'";
                        //        First = 1;
                        //    }
                        //}
                        //if (dt.Rows[i]["BankBranchName"].ToString().Trim() != "")
                        //{
                        //    if (First == 1)
                        //        Query = Query + ",bankbranch = '" + dt.Rows[i]["BankBranchName"].ToString().Trim() + "'";
                        //    else
                        //    {
                        //        Query = Query + " bankbranch = '" + dt.Rows[i]["BankBranchName"].ToString().Trim() + "'";
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

                        SqlParameter[] p = new SqlParameter[23];


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
                        p[3] = new SqlParameter("@Nationality", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Nationality"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["Nationality"].ToString().Trim();
                        }
                        p[4] = new SqlParameter("@BloodGroup", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BloodGroup"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["BloodGroup"].ToString().Trim();

                        }
                        p[5] = new SqlParameter("@PlaceofBirth", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PlaceOfBirth"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["PlaceOfBirth"].ToString().Trim();

                        }
                        p[6] = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PersonalEmailId"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["PersonalEmailId"].ToString().Trim();

                        }

                        p[7] = new SqlParameter("@State", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["State"].ToString().Trim() == "")
                        {
                            p[7].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[7].Value = dt.Rows[i]["State"].ToString().Trim();

                        }
                        p[8] = new SqlParameter("@dl_number", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["DrivingLicenceNo"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["DrivingLicenceNo"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@MobileNumber", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["MobileNo"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["MobileNo"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@Weight", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Weight"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["Weight"].ToString().Trim();


                        }
                        p[11] = new SqlParameter("@Height", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Height"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["Height"].ToString().Trim();

                        }
                        p[12] = new SqlParameter("@PassportNo", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["PassportNo"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["PassportNo"].ToString().Trim();

                        }
                        p[13] = new SqlParameter("@passportissuedate", SqlDbType.DateTime);
                        if (dt.Rows[i]["PassPortIssueDate"].ToString().Trim() == "")
                        {
                            p[13].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[13].Value = Convert.ToDateTime(dt.Rows[i]["PassPortIssueDate"].ToString().Trim());

                        }
                        p[14] = new SqlParameter("@passportexpiraydate", SqlDbType.DateTime);
                        if (dt.Rows[i]["PassPortExpiryDate"].ToString().Trim() == "")
                        {
                            p[14].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[14].Value = Convert.ToDateTime(dt.Rows[i]["PassPortExpiryDate"].ToString().Trim());

                        }
                        p[15] = new SqlParameter("@Bc_No", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["BirthCertificateNumber"].ToString().Trim() == "")
                        {
                            p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[15].Value = dt.Rows[i]["BirthCertificateNumber"].ToString().Trim();

                        }
                        //p[5] = new SqlParameter("@BankNameforSalary", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["BankNameforSalary"].ToString().Trim() == "")
                        //{
                        //    p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[5].Value = dt.Rows[i]["BankNameforSalary"].ToString().Trim();
                        //}
                        //p[6] = new SqlParameter("@AccountNoforSalary", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["AccountNoforSalary"].ToString().Trim() == "")
                        //{
                        //    p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[6].Value = dt.Rows[i]["AccountNoforSalary"].ToString().Trim();

                        //}



                        p[16] = new SqlParameter("@FatherName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["FatherName"].ToString().Trim() == "")
                        {
                            p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[16].Value = dt.Rows[i]["FatherName"].ToString().Trim();

                        }
                        p[17] = new SqlParameter("@MotherName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["MotherName"].ToString().Trim() == "")
                        {
                            p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[17].Value = dt.Rows[i]["MotherName"].ToString().Trim();

                        }
                        p[18] = new SqlParameter("@MaritalStatus", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["MaritalStatus"].ToString().Trim() == "")
                        {
                            p[18].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[18].Value = dt.Rows[i]["MaritalStatus"].ToString().Trim();

                        }
                        p[19] = new SqlParameter("@SpouseName", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["SpouseName"].ToString().Trim() == "")
                        {
                            p[19].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[19].Value = dt.Rows[i]["SpouseName"].ToString().Trim();

                        }
                        p[20] = new SqlParameter("@DateOfAnniversary", SqlDbType.DateTime);
                        if (dt.Rows[i]["DateOfAnniversary"].ToString().Trim() == "")
                        {
                            p[20].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        }
                        else
                        {
                            p[20].Value = Convert.ToDateTime(dt.Rows[i]["DateOfAnniversary"].ToString().Trim());

                        }
                        p[21] = new SqlParameter("@No_Child", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["NumberofChildren"].ToString().Trim() == "")
                        {
                            p[21].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[21].Value = dt.Rows[i]["NumberofChildren"].ToString().Trim();

                        }
                        p[22] = new SqlParameter("@Country", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Country"].ToString().Trim() == "")
                        {
                            p[22].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[22].Value = dt.Rows[i]["Country"].ToString().Trim();

                        }
                        //p[15] = new SqlParameter("@IFSC_code", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["IFSC_code"].ToString().Trim() == "")
                        //{
                        //    p[15].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[15].Value = dt.Rows[i]["IFSC_code"].ToString().Trim();

                        //}
                        //p[16] = new SqlParameter("@TShirtSize", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["TShirtSize"].ToString().Trim() == "")
                        //{
                        //    p[16].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[16].Value = dt.Rows[i]["TShirtSize"].ToString().Trim();

                        //}
                        //p[17] = new SqlParameter("@ShirtSize", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["ShirtSize"].ToString().Trim() == "")
                        //{
                        //    p[17].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[17].Value = dt.Rows[i]["ShirtSize"].ToString().Trim();

                        //}




                        //p[21] = new SqlParameter("@dl_number", SqlDbType.VarChar, 100);
                        //p[21].Value = dt.Rows[i]["DrivingLicenceNo"].ToString().Trim();


                        //p[22] = new SqlParameter("@dlissuedate", SqlDbType.DateTime);
                        //if (dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim() == "")
                        //{
                        //    p[22].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        //}
                        //else
                        //{
                        //    p[22].Value = Convert.ToDateTime(dt.Rows[i]["DrivingLicenceIssuedDate"].ToString().Trim());

                        //}
                        //p[23] = new SqlParameter("@dlexpiraydate", SqlDbType.DateTime);
                        //if (dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim() == "")
                        //{
                        //    p[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        //}
                        //else
                        //{
                        //    p[23].Value = Convert.ToDateTime(dt.Rows[i]["DrivingLicenceExpiryDate"].ToString().Trim());

                        //}
                        //p[24] = new SqlParameter("@landlineno", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["LandLineNo"].ToString().Trim() == "")
                        //{
                        //    p[24].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[24].Value = dt.Rows[i]["LandLineNo"].ToString().Trim();

                        //}
                        //p[25] = new SqlParameter("@bankbranch", SqlDbType.VarChar, 50);
                        //if (dt.Rows[i]["BankBranchName"].ToString().Trim() == "")
                        //{
                        //    p[25].Value = System.Data.SqlTypes.SqlString.Null;
                        //}
                        //else
                        //{
                        //    p[25].Value = dt.Rows[i]["BankBranchName"].ToString().Trim();

                        //}

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SavePersonalDetail", p);
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

                        if (dt.Rows[i]["Pre_Address1"].ToString().Trim() != "")
                        {
                            Query = Query + " pre_add1 =  '" + dt.Rows[i]["Pre_Address1"].ToString().Trim() + "'";
                            First = 1;
                        }

                        if (dt.Rows[i]["Pre_Address2"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pre_Add2 = '" + dt.Rows[i]["Pre_Address2"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " pre_Add2 = '" + dt.Rows[i]["PresentAddress2"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Pre_City"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pre_city = '" + dt.Rows[i]["Pre_City"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " pre_city = '" + dt.Rows[i]["Pre_City"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Pre_State"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pre_state = '" + dt.Rows[i]["Pre_State"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " pre_state = '" + dt.Rows[i]["Pre_State"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Pre_Country"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pre_country = '" + dt.Rows[i]["Pre_Country"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " pre_country = '" + dt.Rows[i]["Pre_Country"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }

                        if (dt.Rows[i]["Pre_ZipCode"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",pre_zip = '" + dt.Rows[i]["Pre_ZipCode"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " pre_zip = '" + dt.Rows[i]["Pre_ZipCode"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Pre_LandMark"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",Pre_LandMark = '" + dt.Rows[i]["Pre_LandMark"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " Pre_LandMark = '" + dt.Rows[i]["Pre_LandMark"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
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
                        if (dt.Rows[i]["Per_Address1"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",per_add1 = '" + dt.Rows[i]["Per_Address1"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " per_add1 = '" + dt.Rows[i]["Per_Address1"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Per_Address2"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",per_add2 = '" + dt.Rows[i]["Per_Address2"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " per_add2 = '" + dt.Rows[i]["Per_Address2"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Per_City"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",per_city = '" + dt.Rows[i]["Per_City"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " per_city = '" + dt.Rows[i]["Per_City"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Per_State"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",per_state = '" + dt.Rows[i]["Per_State"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " per_state = '" + dt.Rows[i]["Per_State"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
                        if (dt.Rows[i]["Per_ZipCode"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",per_zip = '" + dt.Rows[i]["Per_ZipCode"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " per_zip = '" + dt.Rows[i]["Per_ZipCode"].ToString().Trim() + "'";
                                First = 1;
                            }
                        }
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
                        if (dt.Rows[i]["Per_Country"].ToString().Trim() != "")
                        {
                            if (First == 1)
                                Query = Query + ",per_country = '" + dt.Rows[i]["Per_Country"].ToString().Trim() + "'";
                            else
                            {
                                Query = Query + " per_country = '" + dt.Rows[i]["Per_Country"].ToString().Trim() + "'";
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
                        SqlParameter[] p = new SqlParameter[22];


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
                        if (dt.Rows[i]["Pre_Address1"].ToString().Trim() == "")
                        {
                            p[1].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[1].Value = dt.Rows[i]["Pre_Address1"].ToString().Trim();
                        }

                        p[2] = new SqlParameter("@PresentAddress2", SqlDbType.VarChar, 1000);
                        if (dt.Rows[i]["Pre_Address2"].ToString().Trim() == "")
                        {
                            p[2].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[2].Value = dt.Rows[i]["Pre_Address2"].ToString().Trim();
                        }

                        p[3] = new SqlParameter("@PresentCity", SqlDbType.VarChar, 200);
                        if (dt.Rows[i]["Pre_City"].ToString().Trim() == "")
                        {
                            p[3].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[3].Value = dt.Rows[i]["Pre_City"].ToString().Trim();
                        }

                        p[4] = new SqlParameter("@PresentState", SqlDbType.VarChar, 200);
                        if (dt.Rows[i]["Pre_State"].ToString().Trim() == "")
                        {
                            p[4].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[4].Value = dt.Rows[i]["Pre_State"].ToString().Trim();
                        }
                        p[5] = new SqlParameter("@PresentCountry", SqlDbType.VarChar, 100);
                        if (dt.Rows[i]["Pre_Country"].ToString().Trim() == "")
                        {
                            p[5].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[5].Value = dt.Rows[i]["Pre_Country"].ToString().Trim();
                        }

                        p[6] = new SqlParameter("@PresentZipcode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Pre_ZipCode"].ToString().Trim() == "")
                        {
                            p[6].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[6].Value = dt.Rows[i]["Pre_ZipCode"].ToString().Trim();
                        }
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
                        if (dt.Rows[i]["Per_Address1"].ToString().Trim() == "")
                        {
                            p[8].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[8].Value = dt.Rows[i]["Per_Address1"].ToString().Trim();

                        }
                        p[9] = new SqlParameter("@PermanentAddress2", SqlDbType.VarChar, 1000);
                        if (dt.Rows[i]["Per_Address2"].ToString().Trim() == "")
                        {
                            p[9].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[9].Value = dt.Rows[i]["Per_Address2"].ToString().Trim();

                        }
                        p[10] = new SqlParameter("@PermanentCity", SqlDbType.VarChar, 200);
                        if (dt.Rows[i]["Per_City"].ToString().Trim() == "")
                        {
                            p[10].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[10].Value = dt.Rows[i]["Per_City"].ToString().Trim();

                        }
                        p[11] = new SqlParameter("@PermanentState", SqlDbType.VarChar, 200);
                        if (dt.Rows[i]["Per_State"].ToString().Trim() == "")
                        {
                            p[11].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[11].Value = dt.Rows[i]["Per_State"].ToString().Trim();

                        }
                        p[12] = new SqlParameter("@PermanentZipCode", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Per_ZipCode"].ToString().Trim() == "")
                        {
                            p[12].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[12].Value = dt.Rows[i]["Per_ZipCode"].ToString().Trim();

                        }
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
                        if (dt.Rows[i]["Per_Country"].ToString().Trim() == "")
                        {
                            p[19].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[19].Value = dt.Rows[i]["Per_Country"].ToString().Trim();

                        }
                        p[20] = new SqlParameter("@PresentLandMark", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Pre_LandMark"].ToString().Trim() == "")
                        {
                            p[20].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[20].Value = dt.Rows[i]["Pre_LandMark"].ToString().Trim();

                        }
                        p[21] = new SqlParameter("@PermanentLandMark", SqlDbType.VarChar, 50);
                        if (dt.Rows[i]["Per_LandMark"].ToString().Trim() == "")
                        {
                            p[21].Value = System.Data.SqlTypes.SqlString.Null;
                        }
                        else
                        {
                            p[21].Value = dt.Rows[i]["Per_LandMark"].ToString().Trim();

                        }

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_SaveContactDetail", p);
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

    #region Employee Exists
    private bool EmployeeExists(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "Sp_EmployeeExists", empcode);
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
    private bool EmployeeExistPFNominationDetails(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "EmployeeExistPFNominationDetails", empcode);
        if (flag == 1)
            return true;
        else
            return false;
    }

    private bool EmployeeExistMedicalInsuranceDetails(string empcode)
    {
        int flag = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "EmployeeExistMedicalInsuranceDetails", empcode);
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

}