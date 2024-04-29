using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using System.Net.Mail;
using System.Configuration;

public partial class admin_editmyprofile : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    public int i;
    DataSet ds = new DataSet();
    string sqlstr, emp_code;
    string hrcode;
    string qry;
    DataTable dtable = new DataTable();
    DataView dview;
    string _Name, _Email, _Name1, _Email2;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_msg.Text = "";
        if (Session["empcode"] != null)
        {

            emp_code = Session["empcode"].ToString();
            //emp_code = Request.QueryString["empcode"].ToString();

            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {
                   
                }
                else
                    Response.Redirect("~/notlogged.aspx");
                //TabContainer1.ActiveTabIndex = 0;

                if (Session["Child"] != null)
                {
                    Session.Remove("Child");
                }
                if (Session["acc_education"] != null)
                {
                    Session.Remove("acc_education");
                }
                if (Session["Pro_education"] != null)
                {
                    Session.Remove("Pro_education");
                }
                if (Session["exp"] != null)
                {
                    Session.Remove("exp");
                }
                if (Session["exp"] != null)
                {
                    Session.Remove("exp");
                }
                if (Session["training"] != null)
                {
                    Session.Remove("training");
                }
                if (Session["emg_contact"] != null)
                {
                    Session.Remove("emg_contact");
                }
                if (Session["Other_upload"] != null)
                {
                    Session.Remove("Other_upload");
                }
                if (Session["Address_upload"] != null)
                {
                    Session.Remove("Address_upload");
                }
                if (Session["upload"] != null)
                {
                    Session.Remove("upload");
                }

                if (Session["role"].ToString() == "1")
                {
                    others.Visible = false;
                    //fu_dft1.Visible = false;
                    //fu_dft2.Visible = false;
                    //fu_dft3.Visible = false;
                    //fu_dft4.Visible = false;
                    //fu_dft5.Visible = false;
                    //fu_dft6.Visible = false;
                    //fu_dft7.Visible = false;
                    //fu_dft8.Visible = false;
                    //fu_dft9.Visible = false;
                    //fu_dft10.Visible = false;
                    //fu_dft11.Visible = false;
                    //fu_dft12.Visible = false;
                    //fu_dft13.Visible = false;
                    //fu_dft14.Visible = false;
                    //fu_dft15.Visible = false;
                    //fu_dft16.Visible = false;
                    //fu_dft17.Visible = false;
                    //fu_dft18.Visible = false;
                    //fu_dft19.Visible = false;
                    //fu_dft20.Visible = false;
                    //fu_dft21.Visible = false;
                    //fu_dft22.Visible = false;
                    //fu_dft23.Visible = false;
                    
                    //Label1.Visible = false;
                    //Label5.Visible = false;
                    //Label6.Visible = false;
                    //Label7.Visible = false;
                    //Label8.Visible = false;
                    //Label9.Visible = false;
                    //Label10.Visible = false;
                    //Label11.Visible = false;
                    //Label12.Visible = false;
                    //Label13.Visible = false;
                    //Label14.Visible = false;
                    //Label15.Visible = false;
                    //Label16.Visible = false;
                    //Label17.Visible = false;
                    //Label18.Visible = false;
                    //Label21.Visible = false;
                    //Label24.Visible = false;
                    //Label27.Visible = false;
                    //Label30.Visible = false;
                    //Label33.Visible = false;
                    //Label36.Visible = false;
                    //Label39.Visible = false;
                    //Label42.Visible = false;
                }


                //bind_personalinfo(emp_code);
                //bind_child(emp_code);
                //bind_Education_Qualification(emp_code);
                //bind_Professional_Qualification(emp_code);
                //bind_Exp_detail(emp_code);
                //bind_Training_detail(emp_code);
                //bind_payrolldetails(emp_code);
                //bind_emp_doc(emp_code);
                //Getdefaultlable();
                //BindEmgContactDetails(emp_code);
                //BindApproverDetails(emp_code);



                //bind_emp();
                bind_emp_doc(emp_code);
                bind_job_detail(emp_code);
                bind_contactdetails(emp_code);
                bind_personalinfo(emp_code);
                bind_child(emp_code);
                bind_Education_Qualification(emp_code);
                bind_Professional_Qualification(emp_code);
                bind_Exp_detail(emp_code);
                bind_Training_detail(emp_code);
                bind_payrolldetails(emp_code);
                Getdefaultlable();
                BindEmgContactDetails(emp_code);
                BindApproverDetails(emp_code);
                Bind_IdType();
                bind_PhotoId(emp_code);
                bind_addressproof(emp_code);
                bind_OtherDocument(emp_code);
                //Bindhealth(emp_code);
                //BindEmpHistory(emp_code);
                div_Edu_Qual_others.Visible = false;

                if (Request.QueryString["updated"] != null)
                {
                    Output.Show("Submitted Successfully");
                }
            }
        }
    }

    //    private void BindEmpHistory(string emp_code)
    //    {
    //        string EmpQry = @"SELECT     dbo.EmpHistory.EmpCode, dbo.tbl_intranet_designation.designationname, dbo.tbl_internate_departmentdetails.department_name, dbo.tbl_intranet_role.role, 
    //                          dbo.EmpHistory.UpdatedBy, dbo.EmpHistory.DateAdded, COALESCE (dbo.tbl_intranet_employee_jobDetails.emp_fname, '')+ COALESCE (dbo.tbl_intranet_employee_jobDetails.emp_m_name, '') + COALESCE (dbo.tbl_intranet_employee_jobDetails.emp_l_name, '') AS Name
    //                FROM      dbo.EmpHistory INNER JOIN dbo.tbl_intranet_role ON dbo.EmpHistory.EmpRole = dbo.tbl_intranet_role.id INNER JOIN dbo.tbl_intranet_designation ON dbo.EmpHistory.DesignationId = dbo.tbl_intranet_designation.id INNER JOIN
    //                          dbo.tbl_internate_departmentdetails ON dbo.EmpHistory.DepartmentId = dbo.tbl_internate_departmentdetails.departmentid INNER JOIN dbo.tbl_intranet_employee_jobDetails ON dbo.EmpHistory.EmpCode = dbo.tbl_intranet_employee_jobDetails.empcode where dbo.EmpHistory.Empcode='" + emp_code.Trim().ToString() + "'";
    //        DataSet ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, EmpQry);
    //        if (ds3.Tables[0].Rows.Count < 1)
    //            return;

    //        EmpHistGrid.DataSource = ds3;
    //        EmpHistGrid.DataBind();

    private void bind_OtherDocument(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select * from Emp_Other_Doc where empcode = '" + emp_code + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["Other_upload"] == null)
            {
                create_Otherdoc_upload_table();
            }

            DataRow dr;
            DataTable dtable;
            dtable = (DataTable)Session["Other_upload"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["Others"] = ds.Tables[0].Rows[i]["DocName"].ToString();
                dr["File"] = ds.Tables[0].Rows[i]["f_name"].ToString();

                dtable.Rows.Add(dr);
            }
            Session["Other_upload"] = dtable;
            BindList_Otherdoc_Upload();

        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void bind_addressproof(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select * from Emp_Address_Doc where empcode = '" + emp_code + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["Address_upload"] == null)
            {
                create_Address_upload_table();
            }

            DataRow dr;
            DataTable dtable;
            dtable = (DataTable)Session["Address_upload"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["ID_Type"] = ds.Tables[0].Rows[i]["id_type"].ToString();
                dr["Others"] = ds.Tables[0].Rows[i]["Others"].ToString();
                dr["Address_Type"] = ds.Tables[0].Rows[i]["Address_details"].ToString();
                dr["File"] = ds.Tables[0].Rows[i]["f_name"].ToString();
                dtable.Rows.Add(dr);
            }
            Session["Address_upload"] = dtable;
            BindList_Address_Upload();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void bind_PhotoId(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select * from Emp_PhotoId_Doc where empcode = '" + emp_code + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["upload"] == null)
            {
                create_upload_table();
            }

            DataRow dr;
            DataTable dtable;
            dtable = (DataTable)Session["upload"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["ID_Type"] = ds.Tables[0].Rows[i]["id_type"].ToString();
                dr["Others"] = ds.Tables[0].Rows[i]["Others"].ToString();
                dr["Address_Type"] = ds.Tables[0].Rows[i]["Address_details"].ToString();
                dr["File"] = ds.Tables[0].Rows[i]["f_name"].ToString();
                dtable.Rows.Add(dr);
            }
            Session["upload"] = dtable;
            BindList_PhotoUpload();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void Bind_IdType()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id, name from tbl_Internet_AddressProof order by id asc";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList25.DataSource = ds;
                DropDownList25.DataValueField = "id";
                DropDownList25.DataTextField = "name";
                DropDownList25.DataBind();

                DropDownList27.DataSource = ds;
                DropDownList27.DataValueField = "id";
                DropDownList27.DataTextField = "name";
                DropDownList27.DataBind();
            }
            DropDownList25.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList27.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void BindEmgContactDetails(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select * from tbl_intranet_employee_emgcontact_details where empcode ='" + emp_code + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["emg_contact"] == null)
            {
                create_emg_contact_table();
            }
            DataRow dr;
            DataTable dtable;
            dtable = (DataTable)Session["emg_contact"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();
                dtable = (DataTable)Session["emg_contact"];

                DataRow drfind = dtable.Rows.Find(txt_emergency_name.Text);
                if (drfind != null)
                {
                }
                else
                {
                    dr = dtable.NewRow();
                    dr["emg_name"] = ds.Tables[0].Rows[i]["emg_name"].ToString();
                    dr["emg_relation"] = ds.Tables[0].Rows[i]["emg_relation"].ToString();
                    dr["emg_contactno"] = ds.Tables[0].Rows[i]["emg_contactno"].ToString();
                    dr["emg_landlineno"] = ds.Tables[0].Rows[i]["emg_landlineno"].ToString();
                    dtable.Rows.Add(dr);
                }
            }
            Session["emg_contact"] = dtable;
            BindList_Emg_Contact();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    private void BindApproverDetails(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"select 
app_finance+'>'+FNemp_fname app_finance,
app_admin+'>'+ADemp_fname app_admin,
app_reportingmanager+'>'+RMemp_fname app_reportingmanager,
app_management+'>'+MNGemp_fname app_management,
app_hr+'>'+HRemp_fname app_hr,
app_businesshead+'>'+BHemp_fname app_businesshead,
app_hrd+'>'+HRDemp_fname app_hrd,
clr_department+'>'+DPTemp_fname clr_department,
clr_generaladmin+'>'+GNLemp_fname clr_generaladmin,
clr_accountsdept+'>'+ACCemp_fname clr_accountsdept,
clr_networkdept+'>'+NWemp_fname clr_networkdept,
clr_hr+'>'+HRCemp_fname clr_hr,
clr_useraccountdeletion+'>'+UADemp_fname clr_useraccountdeletion,
app_dotted_linemanager+'>'+LMemp_fname app_dotted_linemanager,
app_hr_cb+'>'+HRCBemp_fname app_hr_cb



from
(
select 
app_finance,
app_admin,
app_reportingmanager,
app_management,
app_hr,
app_businesshead,
app_hrd,
clr_department,
clr_generaladmin,
clr_accountsdept,
clr_networkdept,
clr_hr,
clr_useraccountdeletion,
app_dotted_linemanager,
app_hr_cb,
FN.emp_fname FNemp_fname,
AD.emp_fname ADemp_fname,
RM.emp_fname RMemp_fname, 
MNG.emp_fname MNGemp_fname, 
HR.emp_fname HRemp_fname,  
BH.emp_fname BHemp_fname, 
HRD.emp_fname HRDemp_fname, 
DPT.emp_fname DPTemp_fname, 
GNL.emp_fname GNLemp_fname, 
ACC.emp_fname ACCemp_fname, 
NW.emp_fname NWemp_fname, 
HRC.emp_fname HRCemp_fname, 
UAD.emp_fname UADemp_fname,
LM.emp_fname LMemp_fname,
HRCB.emp_fname HRCBemp_fname
 from tbl_employee_approvers A
 left join tbl_intranet_employee_jobDetails FN on A.app_finance = FN.empcode
 left join tbl_intranet_employee_jobDetails AD on A.app_admin = AD.empcode
 left join tbl_intranet_employee_jobDetails RM on A.app_reportingmanager = RM.empcode
 left join tbl_intranet_employee_jobDetails MNG on A.app_management = MNG.empcode
 left join tbl_intranet_employee_jobDetails HR on A.app_hr = HR.empcode
 left join tbl_intranet_employee_jobDetails BH on A.app_businesshead = BH.empcode
 left join tbl_intranet_employee_jobDetails HRD on A.app_hrd = HRD.empcode
 left join tbl_intranet_employee_jobDetails DPT on A.clr_department = DPT.empcode
 left join tbl_intranet_employee_jobDetails GNL on A.clr_generaladmin = GNL.empcode
 left join tbl_intranet_employee_jobDetails ACC on A.clr_accountsdept = ACC.empcode
 left join tbl_intranet_employee_jobDetails NW on A.clr_networkdept = NW.empcode
 left join tbl_intranet_employee_jobDetails HRC on A.clr_hr = HRC.empcode
 left join tbl_intranet_employee_jobDetails UAD on A.clr_useraccountdeletion = UAD.empcode
 left join tbl_intranet_employee_jobDetails LM on A.app_dotted_linemanager = LM.empcode
 left join tbl_intranet_employee_jobDetails HRCB on A.app_hr_cb = HRCB.empcode
 
  where A.empcode = '" + emp_code + "' ) T";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtreportmanager.Text = ds.Tables[0].Rows[0]["app_reportingmanager"].ToString();
            txtbusinesshead.Text = ds.Tables[0].Rows[0]["app_businesshead"].ToString();
            txtfncmang.Text = ds.Tables[0].Rows[0]["app_finance"].ToString();
            txtadmin.Text = ds.Tables[0].Rows[0]["app_admin"].ToString();
            txthr.Text = ds.Tables[0].Rows[0]["app_hr"].ToString();
            txthrd.Text = ds.Tables[0].Rows[0]["app_hrd"].ToString();
            txtmng.Text = ds.Tables[0].Rows[0]["app_management"].ToString();

            txtdeptclr.Text = ds.Tables[0].Rows[0]["clr_department"].ToString();
            txtadminclr.Text = ds.Tables[0].Rows[0]["clr_generaladmin"].ToString();
            txtaccdeptclr.Text = ds.Tables[0].Rows[0]["clr_accountsdept"].ToString();
            txtnetworkclr.Text = ds.Tables[0].Rows[0]["clr_networkdept"].ToString();
            txthrdeptclr.Text = ds.Tables[0].Rows[0]["clr_hr"].ToString();
            txtaccdeleclr.Text = ds.Tables[0].Rows[0]["clr_useraccountdeletion"].ToString();
            txtdottedlinemanager.Text = ds.Tables[0].Rows[0]["app_dotted_linemanager"].ToString();
            txthrcb.Text = ds.Tables[0].Rows[0]["app_hr_cb"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_job_detail(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            //   string sqlstr = "SELECT tbl_login_1.empcode, tbl_intranet_employee_jobDetails.uid,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender, tbl_intranet_employee_jobDetails.emp_fname,tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name, tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_roll, tbl_intranet_employee_jobDetails.dept_id, tbl_intranet_employee_jobDetails.division_id,tbl_intranet_employee_jobDetails.degination_id, tbl_intranet_employee_jobDetails.Grade, tbl_intranet_employee_jobDetails.branch_id,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END)emp_doj, tbl_intranet_employee_jobDetails.ext_number, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.Status, tbl_login_1.login_id,tbl_login_1.role  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_login_1.empcode = tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
            string sqlstr = @"SELECT tbl_intranet_employee_jobDetails.empcode, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender,tbl_intranet_employee_jobDetails.emp_fname, tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name,tbl_intranet_employee_status.employeestatus,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(50),tbl_intranet_employee_jobDetails.emp_doj, 106) END) doj  , tbl_intranet_employee_jobDetails.ext_number,tbl_intranet_employee_jobDetails.Status, tbl_intranet_branch_detail.branch_name, tbl_intranet_grade.gradename, tbl_login.login_id,tbl_intranet_designation.designationname, tbl_intranet_division.division_name, tbl_intranet_role.role,tbl_internate_departmentdetails.department_name,(CASE WHEN tbl_intranet_employee_jobDetails.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(50),tbl_intranet_employee_jobDetails.salary_cal_from, 106) END)salary_cal_from,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(41), tbl_intranet_employee_jobDetails.emp_doleaving, 106) END)emp_doleaving,tbl_intranet_employee_jobDetails.reason_leaving,tbl_intranet_employee_jobDetails.salutation ,tbl_intranet_employee_jobDetails.official_email_id,tbl_intranet_employee_jobDetails.official_mob_no,tbl_internate_employee_subtype.emp_subtype_name,tbl_internate_employee_type.emp_type_name,tbl_internate_department_type.dept_type_name,
  tbl_intranet_employee_jobDetails.cost_center_group_id,tbl_intranet_employee_jobDetails.cost_center_code,tbl_intranet_employee_jobDetails.country,
  tbl_intranet_employee_jobDetails.state,tbl_intranet_employee_jobDetails.city,tbl_intranet_employee_jobDetails.location,
  tbl_intranet_employee_jobDetails.add_cost_center_group_id,tbl_intranet_employee_jobDetails.add_cost_center_code,
  tbl_intranet_employee_jobDetails.add_country,tbl_intranet_employee_jobDetails.add_state,tbl_intranet_employee_jobDetails.add_city,
  tbl_intranet_employee_jobDetails.add_location,tbl_intranet_employee_jobDetails.subgroupid,tbl_intranet_employee_jobDetails.broadgroupid,
  tbl_intranet_employee_jobDetails.entityid,tbl_intranet_employee_jobDetails.supervisorcode,tbl_intranet_employee_jobDetails.hodcode,
  tbl_intranet_employee_jobDetails.corporatereportingcode,tbl_intranet_employee_jobDetails.probationperiod, tbl_intranet_employee_jobDetails.probationenddate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationstartdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(50), tbl_intranet_employee_jobDetails.deputationstartdate, 106) END)deputationstartdate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationenddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(50), tbl_intranet_employee_jobDetails.deputationenddate, 106) END)deputationenddate ,tbl_intranet_employee_jobDetails.gradetype,tbl_intranet_employee_jobDetails.noticeperiod,(CASE WHEN tbl_intranet_employee_jobDetails.confirmationdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), tbl_intranet_employee_jobDetails.confirmationdate, 106) END)confirmationdate   
  FROM  tbl_intranet_employee_jobDetails
  INNER JOIN tbl_login ON tbl_intranet_employee_jobDetails.empcode = tbl_login.empcode 
  left JOIN tbl_intranet_grade on tbl_intranet_grade.id = tbl_intranet_employee_jobDetails.Grade 
  INNER JOIN tbl_intranet_role ON tbl_login.role = tbl_intranet_role.id 
  left JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id = tbl_intranet_branch_detail.Branch_Id 
  left JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id = tbl_intranet_designation.id 
  left JOIN tbl_intranet_division ON tbl_intranet_employee_jobDetails.division_id = tbl_intranet_division.ID 
  left join tbl_internate_departmentdetails ON tbl_internate_departmentdetails.departmentid = tbl_intranet_employee_jobDetails.dept_id 
  left JOIN tbl_intranet_employee_status ON tbl_intranet_employee_status.id = tbl_intranet_employee_jobDetails.emp_status
  left join tbl_internate_employee_subtype on tbl_internate_employee_subtype.emp_subtype_id=tbl_intranet_employee_jobDetails.sub_emp_type 
  left join tbl_internate_employee_type on tbl_internate_employee_type.emp_type_id=tbl_intranet_employee_jobDetails.employee_type
  left join tbl_internate_department_type on tbl_internate_department_type.dept_type_id=tbl_intranet_employee_jobDetails.dep_type_id
      where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";


            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            txt_card_no.Text = ds.Tables[0].Rows[0]["card_no"].ToString();
            lbl_gender.Text = (ds.Tables[0].Rows[0]["emp_gender"].ToString() == "0") ? "---" : ds.Tables[0].Rows[0]["emp_gender"].ToString();
            txtfirstname.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
            txtmiddlename.Text = ds.Tables[0].Rows[0]["emp_m_name"].ToString();
            txtlastname.Text = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
            drpempstatus.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();

            lbl_branch_name.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_desigination.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_dept_name.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_dept_type.Text = ds.Tables[0].Rows[0]["dept_type_name"].ToString();
            lbl_division_name.Text = ds.Tables[0].Rows[0]["division_name"].ToString();

            lbl_emp_role.Text = ds.Tables[0].Rows[0]["role"].ToString();

            lbl_grade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            if (ds.Tables[0].Rows[0]["doj"].ToString() != "")
                doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["doj"].ToString()).ToString("dd-MMM-yyyy");
            else doj.Text = "";
            txtext.Text = ds.Tables[0].Rows[0]["ext_number"].ToString();
            txt_login_id.Text = ds.Tables[0].Rows[0]["login_id"].ToString();
            if (ds.Tables[0].Rows[0]["emp_doleaving"].ToString() != "")
                txtdol.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doleaving"].ToString()).ToString("dd-MMM-yyyy");
            if (ds.Tables[0].Rows[0]["salary_cal_from"].ToString() != "")
                txtsalary.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["salary_cal_from"].ToString()).ToString("dd-MMM-yyyy");

            txtreason.Text = ds.Tables[0].Rows[0]["reason_leaving"].ToString();
            //  drprole.SelectedValue = ds.Tables[0].Rows[0]["role"].ToString();
            //============added on 17-12-13======
            lblSalutation.Text = ds.Tables[0].Rows[0]["salutation"].ToString();
            drpempstatus.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();
            txtoff_mobileno.Text = ds.Tables[0].Rows[0]["official_mob_no"].ToString();
            txt_officialemail.Text = ds.Tables[0].Rows[0]["official_email_id"].ToString();
            txremployee_type.Text = ds.Tables[0].Rows[0]["emp_type_name"].ToString();
            txtsubemployeetype.Text = ds.Tables[0].Rows[0]["emp_subtype_name"].ToString();

            if (ds.Tables[0].Rows[0]["employeestatus"].ToString() == "Probationer")
            {
                lblprob.Text = "Probation End date";
                //trprobationperiod.Visible = true;
                //trprobationdate.Visible = true;
                //trprobationdate2.Visible = true;
                trconforimdate.Visible = true;

                //trduptstart.Visible = false;
                //trduptenddate.Visible = false;


                trDOL.Visible = false;
                trReasonL.Visible = false;

            }
            else
                if (ds.Tables[0].Rows[0]["employeestatus"].ToString() == "Confirmed")
                {
                    lblprob.Text = "Confirmation Date";
                    //trprobationperiod.Visible = true;
                    //trprobationdate.Visible = true;
                    //trprobationdate2.Visible = true;
                    trconforimdate.Visible = true;

                    //trduptstart.Visible = false;
                    //trduptenddate.Visible = false;


                    trDOL.Visible = false;
                    trReasonL.Visible = false;
                }
                else
                    if (ds.Tables[0].Rows[0]["employeestatus"].ToString() == "Trainee")
                    {
                        //trprobationperiod.Visible = false;
                        //trprobationdate.Visible = false;
                        //trprobationdate2.Visible = false;
                        //trprobationdate3.Visible = false;
                        //trduptstart.Visible = true;
                        //trduptenddate.Visible = true;
                        //trDOL.Visible = false;
                        //trReasonL.Visible = false;
                    }
                    else
                        if (ds.Tables[0].Rows[0]["employeestatus"].ToString() == "resigned" || ds.Tables[0].Rows[0]["employeestatus"].ToString() == "VOLUNTARY RETIREMENT" || ds.Tables[0].Rows[0]["employeestatus"].ToString() == "RETIRED")
                        {
                            trprobationperiod.Visible = false;
                            trprobationdate.Visible = false;
                            // trprobationdate2.Visible = false;
                            trconforimdate.Visible = false;
                            trduptstart.Visible = false;
                            trduptenddate.Visible = false;
                            trReasonL.Visible = true;
                            trDOL.Visible = true;
                        }
                        else
                        {
                            trprobationperiod.Visible = false;
                            trprobationdate.Visible = false;
                            // trprobationdate2.Visible = false;
                            trconforimdate.Visible = false;
                            trduptstart.Visible = false;
                            trduptenddate.Visible = false;
                            trDOL.Visible = false;
                            trReasonL.Visible = false;
                            trDOL.Visible = false;

                        }
            lblphoto.Text = (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["photo"].ToString()) != true) ? "<a href='../upload/photo/" + ds.Tables[0].Rows[0]["photo"].ToString() +
                "' target='_blank'>View</a>" : "No photo found";
            if ((ds.Tables[0].Rows[0]["confirmationdate"].ToString() == "0") || (ds.Tables[0].Rows[0]["confirmationdate"].ToString() == ""))
            {
                txt_confirmationdate.Text = "";
            }
            else
            {
                txt_confirmationdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["confirmationdate"].ToString()).ToString("dd-MMM-yyyy");

            }

            if ((ds.Tables[0].Rows[0]["noticeperiod"].ToString() == "0") || (ds.Tables[0].Rows[0]["noticeperiod"].ToString() == ""))
            {
                txt_noticePeriod.Text = "";
            }
            else
            {
                txt_noticePeriod.Text = ds.Tables[0].Rows[0]["noticeperiod"].ToString();
            }

            // SubGroup
            //string sqlstr_subgroup = "select id,subgroup_name from tbl_intranet_subgroup where id='" + Convert.ToInt32(ds.Tables[0].Rows[0]["subgroupid"]) + "'";
            //DataSet ds_sb = new DataSet();
            //ds_sb = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_subgroup);
            //if (ds_sb.Tables[0].Rows.Count < 1)
            //{
            //    lbl_subgroup.Text = "";
            //}
            //else
            //{
            //    lbl_subgroup.Text = ds_sb.Tables[0].Rows[0]["subgroup_name"].ToString();
            //}
            // Broad Group
            if (ds.Tables[0].Rows[0]["broadgroupid"].ToString() != "")
            {
                sqlstr = "select id,broadgroup_name from tbl_intranet_broadgroup where id='" + Convert.ToInt32(ds.Tables[0].Rows[0]["broadgroupid"]) + "'";
                DataSet ds_bg = new DataSet();
                ds_bg = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                if (ds_bg.Tables[0].Rows.Count < 1)
                {
                    lbl_broadgroup.Text = "";
                }
                else
                {
                    lbl_broadgroup.Text = ds_bg.Tables[0].Rows[0]["broadgroup_name"].ToString();
                }
            }

            // Entity
            //string sqlstr_entity = "select id,entity from entity where id='" + Convert.ToInt32(ds.Tables[0].Rows[0]["entityid"]) + "'";
            //DataSet ds_entity = new DataSet();
            //ds_entity = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_entity);
            //if (ds_entity.Tables[0].Rows.Count < 1)
            //{
            //    lbl_entity.Text = "";
            //}
            //else
            //{
            //    lbl_entity.Text = ds_entity.Tables[0].Rows[0]["entity"].ToString();
            //}
            if (ds.Tables[0].Rows[0]["gradetype"].ToString() == "A")
            {
                lbl_gradetype.Text = "Administration";
            }
            else
                if ((ds.Tables[0].Rows[0]["gradetype"].ToString() == "T"))
                {
                    lbl_gradetype.Text = "Techinical";
                }


                else
                {
                    lbl_gradetype.Text = "";
                }
            // supervisor Name

            //if ((ds.Tables[0].Rows[0]["supervisorcode"] == null) || (ds.Tables[0].Rows[0]["supervisorcode"].ToString() == "") || (ds.Tables[0].Rows[0]["supervisorcode"].ToString() == "0"))
            //{
            //    lbl_supervisor.Text = "";
            //}
            //else
            //{
            lbl_supervisor.Text = ds.Tables[0].Rows[0]["supervisorcode"].ToString();//get_EmpName(ds.Tables[0].Rows[0]["supervisorcode"].ToString());
            //  }

            // HOD Name
            //if ((ds.Tables[0].Rows[0]["hodcode"] == null) || (ds.Tables[0].Rows[0]["hodcode"].ToString() == "") || (ds.Tables[0].Rows[0]["hodcode"].ToString() == "0"))
            //{
            //    lbl_hod.Text = "";
            //}
            //else
            //{
            lbl_hod.Text = ds.Tables[0].Rows[0]["hodcode"].ToString();//get_EmpName(ds.Tables[0].Rows[0]["hodcode"].ToString());
            //  }


            // corporate reporting  Name
            //if ((ds.Tables[0].Rows[0]["corporatereportingcode"].ToString() == "") || (ds.Tables[0].Rows[0]["corporatereportingcode"].ToString() == "0"))
            //{
            lbl_corp_report_name.Text = "";
            //}
            //else
            //{
            lbl_corp_report_name.Text = ds.Tables[0].Rows[0]["corporatereportingcode"].ToString();//get_EmpName(ds.Tables[0].Rows[0]["corporatereportingcode"].ToString());
            // }
            //cost center group name
            if ((ds.Tables[0].Rows[0]["cost_center_group_id"] == null) || (ds.Tables[0].Rows[0]["cost_center_group_id"].ToString() == "0") || (ds.Tables[0].Rows[0]["cost_center_group_id"].ToString() == ""))
            {
                lbl_cc_groupid.Text = "";
            }
            else
            {
                sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group where id='" + Convert.ToInt32(ds.Tables[0].Rows[0]["cost_center_group_id"]) + "'";
                DataSet ds_accg = new DataSet();
                ds_accg = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                if (ds_accg.Tables[0].Rows.Count < 1)
                {
                    lbl_cc_groupid.Text = "";
                }
                else
                {
                    lbl_cc_groupid.Text = ds_accg.Tables[0].Rows[0]["cost_center_group_name"].ToString();
                }
            }
            //cost center code
            if ((ds.Tables[0].Rows[0]["cost_center_code"] == null) || (ds.Tables[0].Rows[0]["cost_center_code"].ToString() == "0") || (ds.Tables[0].Rows[0]["cost_center_code"].ToString() == ""))
            {
                lbl_cc_code.Text = "";
                trcc.Visible = false;
            }
            else
            {
                string sqlstr1 = "select cost_center_code from tbl_intranet_cost_center where id='" + Convert.ToInt32(ds.Tables[0].Rows[0]["cost_center_code"]) + "'";
                DataSet dset3 = new DataSet();
                dset3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
                lbl_cc_code.Text = dset3.Tables[0].Rows[0]["cost_center_code"].ToString();
                trcc.Visible = true;
            }
            //cost center coutry
            if ((ds.Tables[0].Rows[0]["country"] == null) || (ds.Tables[0].Rows[0]["country"].ToString() == "0") || (ds.Tables[0].Rows[0]["country"].ToString() == ""))
            {
                lbl_cc_country.Text = "";
            }
            else
            {
                string sqlstr2 = "select cid,countryname  from tbl_intranet_country_master where cid='" + Convert.ToInt32(ds.Tables[0].Rows[0]["country"]) + "'";
                DataSet ds3 = new DataSet();
                ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr2);
                if (ds3.Tables[0].Rows.Count < 1)
                {
                    lbl_cc_country.Text = "";
                }
                else
                {
                    lbl_cc_country.Text = ds3.Tables[0].Rows[0]["countryname"].ToString();
                }
            }
            //cost center state
            if ((ds.Tables[0].Rows[0]["state"] == null) || (ds.Tables[0].Rows[0]["state"].ToString() == "0") || (ds.Tables[0].Rows[0]["state"].ToString() == ""))
            {
                lbl_cc_state.Text = "";
            }
            else
            {
                string sqlstr3 = "select ID,state from tbl_intranet_state_master where ID='" + Convert.ToInt32(ds.Tables[0].Rows[0]["state"]) + "' ";
                DataSet ds4 = new DataSet();
                ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr3);
                if (ds4.Tables[0].Rows.Count < 1)
                {
                    lbl_cc_state.Text = "";
                }
                else
                {
                    lbl_cc_state.Text = ds4.Tables[0].Rows[0]["state"].ToString();
                }
            }
            //cost center city
            if ((ds.Tables[0].Rows[0]["city"] == null) || (ds.Tables[0].Rows[0]["city"].ToString() == "0") || (ds.Tables[0].Rows[0]["city"].ToString() == ""))
            {
                lbl_cc_city.Text = "";
            }
            else
            {
                sqlstr = "select cid,stateid,city from tbl_intranet_city where cid='" + Convert.ToInt32(ds.Tables[0].Rows[0]["city"]) + "'";
                DataSet ds5 = new DataSet();
                ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                if (ds5.Tables[0].Rows.Count < 1)
                {
                    lbl_cc_city.Text = "";
                }
                else
                {
                    lbl_cc_city.Text = ds5.Tables[0].Rows[0]["city"].ToString();
                }
            }
            if ((ds.Tables[0].Rows[0]["location"] == null) || (ds.Tables[0].Rows[0]["location"].ToString() == "0") || (ds.Tables[0].Rows[0]["location"].ToString() == ""))
            {
                lbl_cc_location.Text = "";
            }
            else
            {
                lbl_cc_location.Text = ds.Tables[0].Rows[0]["location"].ToString();
            }

            //addtitonal cost center group
            if ((ds.Tables[0].Rows[0]["add_cost_center_group_id"] == null) || (ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString() == ""))
            {
                lbl_acc_groupid.Text = "";
            }
            else
            {
                sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group where id='" + Convert.ToInt32(ds.Tables[0].Rows[0]["add_cost_center_group_id"]) + "'";
                DataSet ds_accg2 = new DataSet();
                ds_accg2 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                if (ds_accg2.Tables[0].Rows.Count < 1)
                {
                    lbl_acc_groupid.Text = "";
                }
                else
                {
                    lbl_acc_groupid.Text = ds_accg2.Tables[0].Rows[0]["cost_center_group_name"].ToString();
                }
            }
            //addtitonal cost center code
            if ((ds.Tables[0].Rows[0]["add_cost_center_code"] == null) || (ds.Tables[0].Rows[0]["add_cost_center_code"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_cost_center_code"].ToString() == ""))
            {
                lbl_acc_code.Text = "";
                traddcc.Visible = false;
            }
            else
            {
                string sqlstr1 = "select cost_center_code from tbl_intranet_cost_center where id='" + Convert.ToInt32(ds.Tables[0].Rows[0]["add_cost_center_code"]) + "'";
                DataSet dset3 = new DataSet();
                dset3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
                lbl_acc_code.Text = dset3.Tables[0].Rows[0]["cost_center_code"].ToString();
                traddcc.Visible = true;
            }

            //addtitonal cost center country
            if ((ds.Tables[0].Rows[0]["add_country"] == null) || (ds.Tables[0].Rows[0]["add_country"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_country"].ToString() == ""))
            {
                lbl_acc_country.Text = "";
            }
            else
            {
                sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + Convert.ToInt32(ds.Tables[0].Rows[0]["add_country"]) + "'";
                DataSet ds7 = new DataSet();
                ds7 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                if (ds7.Tables[0].Rows.Count < 1)
                {
                    lbl_acc_country.Text = "";
                }
                else
                {
                    lbl_acc_country.Text = ds7.Tables[0].Rows[0]["countryname"].ToString();
                }
            }
            //addtitonal cost center state
            if ((ds.Tables[0].Rows[0]["add_state"] == null) || (ds.Tables[0].Rows[0]["add_state"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_state"].ToString() == ""))
            {
                lbl_acc_state.Text = "";
            }
            else
            {
                sqlstr = "select ID,state from tbl_intranet_state_master where ID='" + Convert.ToInt32(ds.Tables[0].Rows[0]["add_state"]) + "' ";
                DataSet ds8 = new DataSet();
                ds8 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                if (ds8.Tables[0].Rows.Count < 1)
                {
                    lbl_acc_state.Text = "";
                }
                else
                {
                    lbl_acc_state.Text = ds8.Tables[0].Rows[0]["state"].ToString();
                }
            }
            //addtitonal cost center city
            if ((ds.Tables[0].Rows[0]["add_city"] == null) || (ds.Tables[0].Rows[0]["add_city"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_city"].ToString() == ""))
            {
                lbl_acc_city.Text = "";
            }
            else
            {
                sqlstr = "select cid,stateid,city from tbl_intranet_city where cid='" + Convert.ToInt32(ds.Tables[0].Rows[0]["add_city"]) + "'";
                DataSet ds9 = new DataSet();
                ds9 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                if (ds9.Tables[0].Rows.Count < 1)
                {
                    lbl_acc_city.Text = "";
                }
                else
                {
                    lbl_acc_city.Text = ds9.Tables[0].Rows[0]["city"].ToString();
                }
            }
            if ((ds.Tables[0].Rows[0]["add_location"] == null) || (ds.Tables[0].Rows[0]["add_location"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_location"].ToString() == ""))
            {
                lbl_acc_location.Text = "";
            }
            else
            {
                lbl_acc_location.Text = ds.Tables[0].Rows[0]["add_location"].ToString();
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_payrolldetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "SELECT empcode,esi_no,esi_disp,pf_no,pf_no_dept,pan_no,ward,ptno FROM tbl_intranet_employee_payrollDetails  WHERE empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            esino.Text = ds.Tables[0].Rows[0]["esi_no"].ToString();
            esidesp.Text = ds.Tables[0].Rows[0]["esi_disp"].ToString();
            pfno.Text = ds.Tables[0].Rows[0]["pf_no"].ToString();
            pfno_dept.Text = ds.Tables[0].Rows[0]["pf_no_dept"].ToString();
            panno.Text = ds.Tables[0].Rows[0]["pan_no"].ToString();
            ward.Text = ds.Tables[0].Rows[0]["ward"].ToString();
            txt_ptno.Text = ds.Tables[0].Rows[0]["ptno"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_contactdetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT pre_add1, pre_Add2, pre_city, pre_state, pre_country, pre_zip, pre_phone, per_add1, per_add2, per_city, per_state, per_country, per_zip, per_phone, empcode,mode,modeoftransport,emergency_contact_no,emergency_name,emergency_relation,emergency_address1,emergency_address2,emergency_city,emergency_state,emergency_country,emergency_zip FROM tbl_intranet_employee_contactlist where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
            {
                ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                txt_pre_add1.Text = ds.Tables[0].Rows[0]["pre_add1"].ToString();
                txt_pre_Add2.Text = ds.Tables[0].Rows[0]["pre_Add2"].ToString();
                if ((ds.Tables[0].Rows[0]["pre_country"] == null) || (ds.Tables[0].Rows[0]["pre_country"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_country"].ToString() == "0"))
                {

                }
                else
                {
                    ddl_pre_country.SelectedValue = ds.Tables[0].Rows[0]["pre_country"].ToString();
                    bind_pre_state(ddl_pre_country.SelectedValue);

                    if ((ds.Tables[0].Rows[0]["pre_state"] == null) || (ds.Tables[0].Rows[0]["pre_state"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_state"].ToString() == "0"))
                    {
                        ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddl_pre_state.SelectedValue = ds.Tables[0].Rows[0]["pre_state"].ToString();
                        bind_pre_city(Convert.ToInt32(ddl_pre_state.SelectedValue));
                    }
                    if ((ds.Tables[0].Rows[0]["pre_city"] == null) || (ds.Tables[0].Rows[0]["pre_city"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_city"].ToString() == "0"))
                    {
                        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddl_pre_city.SelectedValue = ds.Tables[0].Rows[0]["pre_city"].ToString();
                    }
                }
                txt_pre_zip.Text = ds.Tables[0].Rows[0]["pre_zip"].ToString();
                txt_pre_phone.Text = ds.Tables[0].Rows[0]["pre_phone"].ToString();
                txt_per_add1.Text = ds.Tables[0].Rows[0]["per_add1"].ToString();
                txt_per_add2.Text = ds.Tables[0].Rows[0]["per_add2"].ToString();
                if ((ds.Tables[0].Rows[0]["per_country"] == null) || (ds.Tables[0].Rows[0]["per_country"].ToString() == "") || (ds.Tables[0].Rows[0]["per_country"].ToString() == "0"))
                {
                    ddl_per_country.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_per_country.SelectedValue = ds.Tables[0].Rows[0]["per_country"].ToString();
                    bind_per_state(ddl_per_country.SelectedValue);

                }
                if ((ds.Tables[0].Rows[0]["per_state"] == null) || (ds.Tables[0].Rows[0]["per_state"].ToString() == "") || (ds.Tables[0].Rows[0]["per_state"].ToString() == "0"))
                {
                    ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_per_state.SelectedValue = ds.Tables[0].Rows[0]["per_state"].ToString();
                    //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
                }

                if ((ds.Tables[0].Rows[0]["per_city"] == null) || (ds.Tables[0].Rows[0]["per_city"].ToString() == "") || (ds.Tables[0].Rows[0]["per_city"].ToString() == "0"))
                {
                    ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_per_city.SelectedValue = ds.Tables[0].Rows[0]["per_city"].ToString();
                }
                txt_per_zip.Text = ds.Tables[0].Rows[0]["per_zip"].ToString();
                txt_per_phone.Text = ds.Tables[0].Rows[0]["per_phone"].ToString();

                if (ds.Tables[0].Rows[0]["mode"].ToString() == "1")
                {
                    optown.Checked = false;
                    optcompany.Checked = true;
                    txtmodeoftransport.Text = ds.Tables[0].Rows[0]["modeoftransport"].ToString();
                    txtmodeoftransport.Visible = true;
                }
                else
                {
                    optcompany.Checked = false;
                    optown.Checked = true;
                    txtmodeoftransport.Text = "";
                    txtmodeoftransport.Visible = false;
                }
                txt_emergency_contactno.Text = ds.Tables[0].Rows[0]["emergency_contact_no"].ToString();
                txt_emergency_name.Text = ds.Tables[0].Rows[0]["emergency_name"].ToString();
                drp_emg_relation.SelectedValue = ds.Tables[0].Rows[0]["emergency_relation"].ToString();
                txt_emergency_address.Text = ds.Tables[0].Rows[0]["emergency_address1"].ToString();
                txt_emergency_address2.Text = ds.Tables[0].Rows[0]["emergency_address2"].ToString();
                if ((ds.Tables[0].Rows[0]["emergency_country"] == null) || (ds.Tables[0].Rows[0]["emergency_country"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_country"].ToString() == "0"))
                {
                }
                else
                {
                    ddl_emergency_country.SelectedValue = ds.Tables[0].Rows[0]["emergency_country"].ToString();
                    bind_Emergency_state(ddl_emergency_country.SelectedValue);
                }
                if (ds.Tables[0].Rows[0]["emergency_state"].ToString() != "")
                {

                    if ((ds.Tables[0].Rows[0]["emergency_state"] == null) || (ds.Tables[0].Rows[0]["emergency_state"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_state"].ToString() == "0"))
                    {
                        ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddl_emergency_state.SelectedValue = ds.Tables[0].Rows[0]["emergency_state"].ToString();
                        //bind_Emergency_city(Convert.ToInt32(ddl_emergency_state.SelectedValue));
                    }
                }
                if ((ds.Tables[0].Rows[0]["emergency_city"] == null) || (ds.Tables[0].Rows[0]["emergency_city"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_city"].ToString() == "0"))
                {
                    ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_emergency_city.SelectedValue = ds.Tables[0].Rows[0]["emergency_city"].ToString();
                }
                txt_emergency_zipcode.Text = ds.Tables[0].Rows[0]["emergency_zip"].ToString();

            }
        }
        catch (Exception ex)
        {
            Output.Log("During contact: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_personalinfo(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,bankbranch,ifsc,passportissuedate,passportexpiraydate,(CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(50), dob, 106) END) dob, (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(50), doa, 106) END) doa, dlno, s_fname, s_mname, s_lname,(CASE WHEN s_dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(50), s_dob, 106) END) s_dob, s_gender, no_child, mobile_no, email_id,bank_name,ac_number,passport_number,paymentmode,bank_name_reimbursement,ac_number_reimbursement,driving_lic_no,dribing_lic_iss_date,driving_lic_exp_date,landlineno FROM tbl_intranet_employee_personalDetails where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count < 1)
                return;
            // created by ramu i am not creating any columns in db.i just add to empfathermiddlename and empfatherlastname why because we not using these col's. 
            ddl_ShirtSize.SelectedValue = ds.Tables[0].Rows[0]["f_lname"].ToString();
            ddl_Tshirt.SelectedValue = ds.Tables[0].Rows[0]["f_mname"].ToString();
            txt_f_mname.Text = "";
            txt_f_l_name.Text = "";
            //---- end 
            txt_f_f_name.Text = ds.Tables[0].Rows[0]["f_fname"].ToString();

            txt_m_fname.Text = ds.Tables[0].Rows[0]["m_fname"].ToString();
            txt_m_l_name.Text = ds.Tables[0].Rows[0]["m_lname"].ToString();
            txt_m_mname.Text = ds.Tables[0].Rows[0]["m_mname"].ToString();
            ddlbloodgrp.SelectedValue = ds.Tables[0].Rows[0]["bloodgrp"].ToString();
            ddlpersonalstatus.SelectedValue = ds.Tables[0].Rows[0]["maritalstatus"].ToString();
            txtrelg.Text = ds.Tables[0].Rows[0]["religion"].ToString();
            if (ds.Tables[0].Rows[0]["doa"].ToString() != "")
                txt_doa.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["doa"].ToString()).ToString("dd-MMM-yyyy");
            else txt_doa.Text = "";
            txt_dl_no.Text = ds.Tables[0].Rows[0]["dlno"].ToString();
            txt_sp_fname.Text = ds.Tables[0].Rows[0]["s_fname"].ToString();
            txt_sp_mname.Text = ds.Tables[0].Rows[0]["s_mname"].ToString();
            txt_sp_lname.Text = ds.Tables[0].Rows[0]["s_lname"].ToString();
            if (ds.Tables[0].Rows[0]["s_dob"].ToString() != "")
                txt_s_DOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["s_dob"].ToString()).ToString("dd-MMM-yyyy");
            else txt_s_DOB.Text = "";
            ddl_s_gender.SelectedValue = ds.Tables[0].Rows[0]["s_gender"].ToString();
            if (ds.Tables[0].Rows[0]["dob"].ToString() != "")
                txt_DOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"].ToString()).ToString("dd-MMM-yyyy");
            else txt_DOB.Text = "";
            string offmobno = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            if (offmobno != "")
            {
                string[] mob = offmobno.Split('-');
                if (mob.Length <= 1)
                {
                    txtccode.Text = "";
                    txtmobileno.Text = mob[0].ToString();
                }
                else
                {
                    txtccode.Text = mob[0].ToString();
                    txtmobileno.Text = mob[1].ToString();
                }
            }
            else
            {
                txtccode.Text = "";
                txtmobileno.Text = "";
            }

            string offmobno1 = ds.Tables[0].Rows[0]["landlineno"].ToString();
            if (offmobno1 != "")
            {
                string[] mob = offmobno1.Split('-');
                if (mob.Length <= 1)
                {
                    txtperccode.Text = "";
                    txtperstdcode.Text = "";
                    txtperlandno.Text = mob[0].ToString();
                }
                else
                {
                    txtperccode.Text = mob[0].ToString();
                    txtperstdcode.Text = mob[1].ToString();
                    txtperlandno.Text = mob[2].ToString();
                }
            }
            else
            {
                txtperccode.Text = "";
                txtperstdcode.Text = "";
                txtperlandno.Text = "";
            }
            txt_email.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
            //txt_bank_name.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
            //txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
            txt_passportno.Text = ds.Tables[0].Rows[0]["passport_number"].ToString();
            if ((ddlpersonalstatus.SelectedValue.ToString() == "MARRIED") || (ddlpersonalstatus.SelectedValue.ToString() == "DIVORCEE") || (ddlpersonalstatus.SelectedValue.ToString() == "WIDOW") || (ddlpersonalstatus.SelectedValue.ToString() == "WIDOWER"))
            {
                tbl1.Visible = true;
            }
            else if ((ddlpersonalstatus.SelectedValue.ToString() == "UNMARRIED") || (ddlpersonalstatus.SelectedValue == "0"))
            {
                tbl1.Visible = false;
            }


            if (ds.Tables[0].Rows[0]["paymentmode"] != DBNull.Value)
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["paymentmode"]) == 0)
                {
                    rbtnbank.Checked = true;
                    rbtncheque.Checked = false;
                    rbtncash.Checked = false;

                    paymentmode.Visible = true;

                    if ((ds.Tables[0].Rows[0]["bank_name"].ToString() != "") && (ds.Tables[0].Rows[0]["bank_name"].ToString() != "0"))
                    {
                        ddl_bank_name.SelectedValue = ds.Tables[0].Rows[0]["bank_name"].ToString();
                    }
                    txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();

                    ddl_bank_name_reimbursement.SelectedValue = ds.Tables[0].Rows[0]["bank_name_reimbursement"].ToString();
                    txt_bank_ac_reimbursement.Text = ds.Tables[0].Rows[0]["ac_number_reimbursement"].ToString();
                }
                else
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["paymentmode"]) == 1)
                    {
                        rbtnbank.Checked = false;
                        rbtncheque.Checked = true;
                        rbtncash.Checked = false;
                        paymentmode.Visible = false;
                    }
                    else
                    {
                        rbtnbank.Checked = false;
                        rbtncheque.Checked = false;
                        rbtncash.Checked = true;
                        paymentmode.Visible = false;
                    }
                }

            txt_bankbrachname.Text = ds.Tables[0].Rows[0]["bankbranch"].ToString();
            txt_ifsc.Text = ds.Tables[0].Rows[0]["ifsc"].ToString();
            if (ds.Tables[0].Rows[0]["passportissuedate"].ToString() == "")
            {
                txt_passportissueddate.Text = "";
            }
            else
            {
                txt_passportissueddate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportissuedate"]).ToString("dd-MMM-yyyy");
            }
            if (ds.Tables[0].Rows[0]["passportexpiraydate"].ToString() == "")
            {
                txt_passportexpdate.Text = "";
            }
            else
            {
                txt_passportexpdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportexpiraydate"]).ToString("dd-MMM-yyyy");
            }
            txt_drli_no.Text = ds.Tables[0].Rows[0]["driving_lic_no"].ToString();
            if (ds.Tables[0].Rows[0]["dribing_lic_iss_date"].ToString() == "")
            {
                txt_dr_iss_date.Text = "";
            }
            else
            {
                txt_dr_iss_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dribing_lic_iss_date"]).ToString("dd-MMM-yyyy");
            }
            if (ds.Tables[0].Rows[0]["driving_lic_exp_date"].ToString() == "")
            {
                txt_dr_exp_date.Text = "";
            }
            else
            {
                txt_dr_exp_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["driving_lic_exp_date"]).ToString("dd-MMM-yyyy");
            }
        }
        catch (Exception ex)
        {
            Output.Log("During personal: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void create_child_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("child_name", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["child_name"] };
        dtable.Columns.Add("gender", typeof(string));
        dtable.Columns.Add(new DataColumn("child_DOB", typeof(string)));
        Session["child"] = dtable;
    }

    protected void bind_child(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select id,child_name,gender ,(CASE WHEN childdob='01/01/1900' THEN '' ELSE CONVERT(CHAR(50), childdob, 106) END)child_dob from tbl_intranet_employee_childrendetail where empcode ='" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["child"] == null)
            {
                create_child_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["child"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();


                dr["child_name"] = ds.Tables[0].Rows[i]["child_name"].ToString();
                dr["child_dob"] = ds.Tables[0].Rows[i]["child_dob"].ToString();
                dr["gender"] = ds.Tables[0].Rows[i]["gender"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }
            Session["child"] = dtable;
            BindList_child();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void ddlpersonalstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlpersonalstatus.SelectedValue.ToString() == "UNMARRIED") || (ddlpersonalstatus.SelectedValue == "0"))
        {
            tbl1.Visible = false;
            // cv_s_dob.Enabled = false;
        }
        else
        {
            tbl1.Visible = true;
            //  cv_s_dob.Enabled = true;
        }
    }

    protected void BindList_child()
    {
        if (Session["child"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["child"];
            dview = new DataView(dtable);
            dview.Sort = "Child_name";
        }
        grid_child.DataSource = dview;
        grid_child.DataBind();
    }

    protected void bind_Professional_Qualification(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year,specialization  FROM tbl_employee_professionalqualifications where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);


            if (ds.Tables[0].Rows.Count < 1)
                return;

            if (Session["Pro_education"] == null)
            {
                create_Pro_edu_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["Pro_education"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["education"] = ds.Tables[0].Rows[i]["education"].ToString();
                dr["school"] = ds.Tables[0].Rows[i]["school"].ToString();
                dr["percentage"] = ds.Tables[0].Rows[i]["percentage"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();
                dr["specialization"] = ds.Tables[0].Rows[i]["specialization"].ToString();

                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }
            Session["Pro_education"] = dtable;
            BindList_pro_edu();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void BindList_pro_edu()
    {
        if (Session["Pro_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Pro_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_Pro_education.DataSource = dview;
        grid_Pro_education.DataBind();
    }

    protected void create_Pro_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("specialization", typeof(string)));

        Session["Pro_education"] = dtable;
    }

    protected void bind_Exp_detail(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT [id],empcode,[companyname]as comp_name,[location]as location ,[totalexperience] as total_exp ,[yearfrom] as from_year,[yearto]as to_year,designation FROM tbl_employee_experiencedetails where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["exp"] == null)
            {
                create_exp_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["exp"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["comp_name"] = ds.Tables[0].Rows[i]["comp_name"].ToString();
                dr["location"] = ds.Tables[0].Rows[i]["location"].ToString();
                dr["total_exp"] = ds.Tables[0].Rows[i]["total_exp"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();
                dr["designation"] = ds.Tables[0].Rows[i]["designation"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";

                dtable.Rows.Add(dr);
            }
            Session["exp"] = dtable;
            BindList_exp();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void BindList_exp()
    {
        if (Session["exp"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["exp"];
            dview = new DataView(dtable);
            dview.Sort = "from_year";
        }
        grid_exp.DataSource = dview;
        grid_exp.DataBind();
    }

    protected void create_exp_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("comp_name", typeof(string));
        dtable.Columns.Add(new DataColumn("location", typeof(string)));
        dtable.Columns.Add(new DataColumn("total_exp", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("designation", typeof(string)));


        Session["exp"] = dtable;
    }

    protected void bind_Training_detail(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT trainingname,personname,(CASE WHEN fromdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(50), fromdate, 106) END)fromdate,(CASE WHEN todate='01/01/1900' THEN '' ELSE CONVERT(CHAR(50), todate, 106) END)todate,remarks  FROM tbl_intranet_employee_trainingdetail where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["training"] == null)
            {
                create_Training_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["training"];
            dtable.Clear();
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();
                dr["trainingname"] = ds.Tables[0].Rows[i]["trainingname"].ToString();
                dr["personname"] = ds.Tables[0].Rows[i]["personname"].ToString();
                dr["fromdate"] = ds.Tables[0].Rows[i]["fromdate"].ToString();
                dr["todate"] = ds.Tables[0].Rows[i]["todate"].ToString();
                dr["remarks"] = ds.Tables[0].Rows[i]["remarks"].ToString();
                dtable.Rows.Add(dr);
            }
            Session["training"] = dtable;
            BindList_Training();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void add_Training()
    {
        DataRow dr;
        if (Session["training"] == null)
        {
            create_Training_table();
        }
        dtable = (DataTable)Session["training"];

        DataRow drfind = dtable.Rows.Find(txt_TrProgram.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();

            dr["trainingname"] = txt_TrProgram.Text;
            dr["personname"] = txt_TrConductedBy.Text;
            dr["fromdate"] = txtFromdate.Text;
            dr["todate"] = txtToDate.Text;
            dr["remarks"] = txtTrRemarks.Text;
            dtable.Rows.Add(dr);
        }
        Session["training"] = dtable;
        BindList_Training();
    }

    protected void bind_pre_state(string stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_pre_state.DataTextField = "state";
            ddl_pre_state.DataValueField = "ID";
            ddl_pre_state.DataSource = ds4;
            ddl_pre_state.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindList_Training()
    {
        if (Session["training"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["training"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridTraning.DataSource = dview;
        GridTraning.DataBind();
    }

    protected void create_Training_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("trainingname", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["trainingname"] };
        dtable.Columns.Add(new DataColumn("personname", typeof(string)));
        dtable.Columns.Add(new DataColumn("fromdate", typeof(string)));
        dtable.Columns.Add(new DataColumn("todate", typeof(string)));
        dtable.Columns.Add(new DataColumn("remarks", typeof(string)));
        Session["training"] = dtable;
    }

    protected void create_acc_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("specialization", typeof(string)));


        Session["acc_education"] = dtable;
    }

    protected void bind_Education_Qualification(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year,specialization  FROM tbl_employee_edcationalqualifications  where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["acc_education"] == null)
            {
                create_acc_edu_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["acc_education"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["education"] = ds.Tables[0].Rows[i]["education"].ToString();
                dr["school"] = ds.Tables[0].Rows[i]["school"].ToString();
                dr["percentage"] = ds.Tables[0].Rows[i]["percentage"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();
                dr["specialization"] = ds.Tables[0].Rows[i]["specialization"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }
            Session["acc_education"] = dtable;
            BindList_acc_edu();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindList_acc_edu()
    {
        if (Session["acc_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["acc_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_edu_education.DataSource = dview;
        grid_edu_education.DataBind();
    }

    //----------------------Add default lables

    private void Getdefaultlable()
    {
        try
        {
            connection = activity.OpenConnection();
            //  string sqlstr = "select id, labelname from staticlabel";
            // ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            string sqlstr = "select labelname from staticlabel";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            lbl_Default1.Text = ds.Tables[0].Rows[0]["labelname"].ToString();
            lbl_Default2.Text = ds.Tables[0].Rows[1]["labelname"].ToString();
            lbl_Default3.Text = ds.Tables[0].Rows[2]["labelname"].ToString();
            lbl_Default4.Text = ds.Tables[0].Rows[3]["labelname"].ToString();
            lbl_Default5.Text = ds.Tables[0].Rows[4]["labelname"].ToString();
            lbl_Default6.Text = ds.Tables[0].Rows[5]["labelname"].ToString();
            lbl_Default7.Text = ds.Tables[0].Rows[6]["labelname"].ToString();
            lbl_Default8.Text = ds.Tables[0].Rows[7]["labelname"].ToString();
            lbl_Default9.Text = ds.Tables[0].Rows[8]["labelname"].ToString();
            lbl_Default10.Text = ds.Tables[0].Rows[9]["labelname"].ToString();
            lbl_Default11.Text = ds.Tables[0].Rows[10]["labelname"].ToString();
            lbl_Default12.Text = ds.Tables[0].Rows[11]["labelname"].ToString();
            lbl_Default13.Text = ds.Tables[0].Rows[12]["labelname"].ToString();
            lbl_Default14.Text = ds.Tables[0].Rows[13]["labelname"].ToString();
            lbl_Default15.Text = ds.Tables[0].Rows[16]["labelname"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    //------------------------------------Bind Emp Document Details---------------------------------------------


    //protected void bind_emp_doc(string empcode)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "SELECT empcode,default1,default2,default3,default4,default5,default6,default7,default8,default9,default10,default11,default12,default13,default14 FROM tbl_intranet_employee_docupload where empcode = '" + empcode + "'";
    //        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (ds.Tables[0].Rows.Count < 1)
    //        {
    //            lbldft1.Text = "no file";
    //            dftlink1.HRef = "#";
    //            lbldft2.Text = "no file";
    //            dftlink2.HRef = "#";
    //            lbldft3.Text = "no file";
    //            dftlink3.HRef = "#";
    //            lbldft4.Text = "no file";
    //            dftlink4.HRef = "#";
    //            lbldft5.Text = "no file";
    //            dftlink5.HRef = "#";
    //            lbldft6.Text = "no file";
    //            dftlink6.HRef = "#";
    //            lbldft7.Text = "no file";
    //            dftlink7.HRef = "#";
    //            lbldft8.Text = "no file";
    //            dftlink8.HRef = "#";
    //            lbldft9.Text = "no file";
    //            dftlink9.HRef = "#";
    //            lbldft10.Text = "no file";
    //            dftlink10.HRef = "#";
    //            lbldft11.Text = "no file";
    //            dftlink11.HRef = "#";
    //            lbldft12.Text = "no file";
    //            dftlink12.HRef = "#";
    //            lbldft13.Text = "no file";
    //            dftlink13.HRef = "#";
    //            lbldft14.Text = "no file";
    //            dftlink14.HRef = "#";
    //            return;
    //        }
    //        if (ds.Tables[0].Rows[0]["default1"].ToString() == "")
    //        {
    //            lbldft1.Text = "no file";
    //            dftlink1.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink1.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default1"].ToString();
    //            dftlink1.Target = "_blank";
    //            lbldft1.Text = "view";

    //        }

    //        if (ds.Tables[0].Rows[0]["default2"].ToString() == "")
    //        {
    //            lbldft2.Text = "no file";
    //            dftlink2.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink2.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default2"].ToString();
    //            dftlink2.Target = "_blank";
    //            lbldft2.Text = "view";
    //        }

    //        if (ds.Tables[0].Rows[0]["default3"].ToString() == "")
    //        {
    //            lbldft3.Text = "no file";
    //            dftlink3.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink3.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default3"].ToString();
    //            dftlink3.Target = "_blank";
    //            lbldft3.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default4"].ToString() == "")
    //        {
    //            lbldft4.Text = "no file";
    //            dftlink4.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink4.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default4"].ToString();
    //            dftlink4.Target = "_blank";
    //            lbldft4.Text = "view";
    //        }

    //        if (ds.Tables[0].Rows[0]["default5"].ToString() == "")
    //        {
    //            lbldft5.Text = "no file";
    //            dftlink5.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink5.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default5"].ToString();
    //            dftlink5.Target = "_blank";
    //            lbldft5.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default6"].ToString() == "")
    //        {
    //            lbldft6.Text = "no file";
    //            dftlink6.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink6.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default6"].ToString();
    //            dftlink6.Target = "_blank";
    //            lbldft6.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default7"].ToString() == "")
    //        {
    //            lbldft7.Text = "no file";
    //            dftlink7.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink7.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default7"].ToString();
    //            dftlink7.Target = "_blank";
    //            lbldft7.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default8"].ToString() == "")
    //        {
    //            lbldft8.Text = "no file";
    //            dftlink8.HRef = "#";

    //        }
    //        else
    //        {
    //            dftlink8.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default8"].ToString();
    //            dftlink8.Target = "_blank";
    //            lbldft8.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default9"].ToString() == "")
    //        {
    //            lbldft9.Text = "no file";
    //            dftlink9.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink9.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default9"].ToString();
    //            dftlink9.Target = "_blank";
    //            lbldft9.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default10"].ToString() == "")
    //        {
    //            lbldft10.Text = "no file";
    //            dftlink10.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink10.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default10"].ToString();
    //            dftlink10.Target = "_blank";
    //            lbldft10.Text = "view";
    //        }

    //        if (ds.Tables[0].Rows[0]["default11"].ToString() == "")
    //        {
    //            lbldft11.Text = "no file";
    //            dftlink11.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink11.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default11"].ToString();
    //            dftlink11.Target = "_blank";
    //            lbldft11.Text = "view";
    //        }

    //        if (ds.Tables[0].Rows[0]["default12"].ToString() == "")
    //        {
    //            lbldft12.Text = "no file";
    //            dftlink12.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink12.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default12"].ToString();
    //            dftlink12.Target = "_blank";
    //            lbldft12.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default13"].ToString() == "")
    //        {
    //            lbldft13.Text = "no file";
    //            dftlink13.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink13.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default13"].ToString();
    //            dftlink13.Target = "_blank";
    //            lbldft13.Text = "view";
    //        }
    //        if (ds.Tables[0].Rows[0]["default14"].ToString() == "")
    //        {
    //            lbldft14.Text = "no file";
    //            dftlink14.HRef = "#";
    //        }
    //        else
    //        {
    //            dftlink14.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default14"].ToString();
    //            dftlink14.Target = "_blank";
    //            lbldft14.Text = "view";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}
    //-------------------------------------End---------------------------------------------------------

    protected void bind_emp_doc(string emp_code)
    {


        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT empcode,default1,default2,default3,default4,default5,default6,default7,default8,default9,default10,default11,default12,default13,default14,default15 FROM tbl_intranet_employee_docupload where empcode = '" + emp_code + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_file1.Text = (ds.Tables[0].Rows[0]["default1"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default1"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default1"].ToString() + "</a>" : "No exisitng file found";

                lbl_file2.Text = (ds.Tables[0].Rows[0]["default2"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default2"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default2"].ToString() + "</a>" : "No exisitng file found";
                lbl_file3.Text = (ds.Tables[0].Rows[0]["default3"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default3"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default3"].ToString() + "</a>" : "No exisitng file found";
                lbl_file4.Text = (ds.Tables[0].Rows[0]["default4"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default4"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default4"].ToString() + "</a>" : "No exisitng file found";
                lbl_file5.Text = (ds.Tables[0].Rows[0]["default5"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default5"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default5"].ToString() + "</a>" : "No exisitng file found";
                lbl_file6.Text = (ds.Tables[0].Rows[0]["default6"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default6"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default6"].ToString() + "</a>" : "No exisitng file found";
                lbl_file7.Text = (ds.Tables[0].Rows[0]["default7"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default7"].ToString() +
                    "' target='_blank>" + ds.Tables[0].Rows[0]["default7"].ToString() + "</a>" : "No exisitng file found";
                lbl_file8.Text = (ds.Tables[0].Rows[0]["default8"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default8"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default8"].ToString() + "</a>" : "No exisitng file found";
                lbl_file9.Text = (ds.Tables[0].Rows[0]["default9"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default9"].ToString() +
                    "' target='_blank'>" + ds.Tables[0].Rows[0]["default9"].ToString() + "</a>" : "No exisitng file found";
                lbl_file10.Text = (ds.Tables[0].Rows[0]["default10"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default10"].ToString() +
                 "' target='_blank'>" + ds.Tables[0].Rows[0]["default10"].ToString() + "</a>" : "No exisitng file found";

                lbl_file11.Text = (ds.Tables[0].Rows[0]["default11"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default11"].ToString() +
               "' target='_blank'>" + ds.Tables[0].Rows[0]["default11"].ToString() + "</a>" : "No exisitng file found";

                lbl_file12.Text = (ds.Tables[0].Rows[0]["default12"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default12"].ToString() +
               "' target='_blank'>" + ds.Tables[0].Rows[0]["default12"].ToString() + "</a>" : "No exisitng file found";

                lbl_file13.Text = (ds.Tables[0].Rows[0]["default13"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default13"].ToString() +
              "' target='_blank'>" + ds.Tables[0].Rows[0]["default13"].ToString() + "</a>" : "No exisitng file found";

                lbl_file14.Text = (ds.Tables[0].Rows[0]["default14"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default14"].ToString() +
              "' target='_blank'>" + ds.Tables[0].Rows[0]["default14"].ToString() + "</a>" : "No exisitng file found";
                lbl_file15.Text = (ds.Tables[0].Rows[0]["default15"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default15"].ToString() +
              "' target='_blank'>" + ds.Tables[0].Rows[0]["default15"].ToString() + "</a>" : "No exisitng file found";
            }

        }
        catch (Exception ex)
        {
            //message.InnerHtml = "";
            //Utilities.LogError(ex);
            activity.CloseConnection();
        }
    }

    protected void edit_emp_documents(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        string defaultUpload1 = "";
        string defaultUpload2 = "";
        string defaultUpload3 = "";
        string defaultUpload4 = "";
        string defaultUpload5 = "";
        string defaultUpload6 = "";
        string defaultUpload7 = "";
        string defaultUpload8 = "";
        string defaultUpload9 = "";
        string defaultUpload10 = "";
        string defaultUpload11 = "";
        string defaultUpload12 = "";
        string defaultUpload13 = "";
        string defaultUpload14 = "";
        string defaultUpload15 = "";

        sqlstr = "SELECT empcode,default1,default2,default3,default4,default5,default6,default7,default8,default9,default10,default11,default12,default13,default14,default15 FROM tbl_Edit_employee_docupload where empcode = '" + empcode + "'";
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr);


        SqlParameter[] sqlParam = new SqlParameter[16];
        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;

        sqlParam[1] = new SqlParameter("@default1", SqlDbType.VarChar, 100);
        if (fu_dft1.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft1.FileName;
            try
            {
                fu_dft1.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload1 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[1].Value = defaultUpload1;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[1].Value = "";
            }
            else
            {
                sqlParam[1].Value = ds.Tables[0].Rows[0]["default1"].ToString();
            }

        }

        sqlParam[2] = new SqlParameter("@default2", SqlDbType.VarChar, 100);

        if (fu_dft2.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft2.FileName;
            try
            {
                fu_dft2.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload2 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[2].Value = defaultUpload2;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[2].Value = "";
            }
            else
            {
                sqlParam[2].Value = ds.Tables[0].Rows[0]["default2"].ToString();
            }

        }


        sqlParam[3] = new SqlParameter("@default3", SqlDbType.VarChar, 100);

        if (fu_dft3.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft3.FileName;
            try
            {
                fu_dft3.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload3 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[3].Value = defaultUpload2;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[3].Value = "";
            }
            else
            {
                sqlParam[3].Value = ds.Tables[0].Rows[0]["default3"].ToString();
            }

        }


        sqlParam[4] = new SqlParameter("@default4", SqlDbType.VarChar, 100);

        if (fu_dft4.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft4.FileName;
            try
            {
                fu_dft4.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload4 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[4].Value = defaultUpload4;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[4].Value = "";
            }
            else
            {
                sqlParam[4].Value = ds.Tables[0].Rows[0]["default4"].ToString();
            }

        }



        sqlParam[5] = new SqlParameter("@default5", SqlDbType.VarChar, 100);

        if (fu_dft5.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft5.FileName;
            try
            {
                fu_dft5.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload5 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[5].Value = defaultUpload5;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[5].Value = "";
            }
            else
            {
                sqlParam[5].Value = ds.Tables[0].Rows[0]["default5"].ToString();
            }

        }

        sqlParam[6] = new SqlParameter("@default6", SqlDbType.VarChar, 100);

        if (fu_dft6.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft6.FileName;
            try
            {
                fu_dft6.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload6 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[6].Value = defaultUpload6;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[6].Value = "";
            }
            else
            {
                sqlParam[6].Value = ds.Tables[0].Rows[0]["default6"].ToString();
            }

        }

        sqlParam[7] = new SqlParameter("@default7", SqlDbType.VarChar, 100);

        if (fu_dft7.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft7.FileName;
            try
            {
                fu_dft7.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload7 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[7].Value = defaultUpload7;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[7].Value = "";
            }
            else
            {
                sqlParam[7].Value = ds.Tables[0].Rows[0]["default7"].ToString();
            }

        }


        sqlParam[8] = new SqlParameter("@default8", SqlDbType.VarChar, 100);

        if (fu_dft8.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft8.FileName;
            try
            {
                fu_dft8.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload8 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[8].Value = defaultUpload8;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[8].Value = "";
            }
            else
            {
                sqlParam[8].Value = ds.Tables[0].Rows[0]["default8"].ToString();
            }

        }


        sqlParam[9] = new SqlParameter("@default9", SqlDbType.VarChar, 100);

        if (fu_dft9.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft9.FileName;
            try
            {
                fu_dft9.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload9 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[9].Value = defaultUpload9;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[9].Value = "";
            }
            else
            {
                sqlParam[9].Value = ds.Tables[0].Rows[0]["default9"].ToString();
            }

        }


        sqlParam[10] = new SqlParameter("@default10", SqlDbType.VarChar, 100);

        if (fu_dft10.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft10.FileName;
            try
            {
                fu_dft10.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload10 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[10].Value = defaultUpload10;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[10].Value = "";
            }
            else
            {
                sqlParam[10].Value = ds.Tables[0].Rows[0]["default10"].ToString();
            }

        }

        sqlParam[11] = new SqlParameter("@default11", SqlDbType.VarChar, 100);

        if (fu_dft11.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft11.FileName;
            try
            {
                fu_dft11.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload11 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[11].Value = defaultUpload11;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[11].Value = "";
            }
            else
            {
                sqlParam[11].Value = ds.Tables[0].Rows[0]["default11"].ToString();
            }

        }


        sqlParam[12] = new SqlParameter("@default12", SqlDbType.VarChar, 100);

        if (fu_dft12.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft12.FileName;
            try
            {
                fu_dft12.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload12 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[12].Value = defaultUpload12;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[12].Value = "";
            }
            else
            {
                sqlParam[12].Value = ds.Tables[0].Rows[0]["default12"].ToString();
            }

        }


        sqlParam[13] = new SqlParameter("@default13", SqlDbType.VarChar, 100);

        if (fu_dft13.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft13.FileName;
            try
            {
                fu_dft13.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload13 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[13].Value = defaultUpload13;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[13].Value = "";
            }
            else
            {
                sqlParam[13].Value = ds.Tables[0].Rows[0]["default13"].ToString();
            }

        }


        sqlParam[14] = new SqlParameter("@default14", SqlDbType.VarChar, 100);

        if (fu_dft14.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft14.FileName;
            try
            {
                fu_dft14.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload14 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[14].Value = defaultUpload14;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[14].Value = "";
            }
            else
            {
                sqlParam[14].Value = ds.Tables[0].Rows[0]["default14"].ToString();
            }

        }
        sqlParam[15] = new SqlParameter("@default15", SqlDbType.VarChar, 100);

        if (fu_dft15.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft15.FileName;
            try
            {
                fu_dft15.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload15 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[15].Value = defaultUpload15;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[15].Value = "";
            }
            else
            {
                sqlParam[15].Value = ds.Tables[0].Rows[0]["default15"].ToString();
            }

        }

        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_Edit_emp_doc_upload", sqlParam);


    }

    protected string get_state(int stateid)
    {
        string state = "";
        try
        {
            connection = activity.OpenConnection();

            string sqlstr = "select ID,state from tbl_intranet_state_master where ID='" + stateid + "' ";
            DataSet ds4 = new DataSet();

            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds4.Tables[0].Rows.Count < 1)
                state = "";
            else
                state = ds4.Tables[0].Rows[0]["state"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return state;
    }

    protected string get_city(int cityid)
    {
        string city = "";
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select cid,stateid,city from tbl_intranet_city where cid='" + cityid + "'";
            DataSet ds_city = new DataSet();

            ds_city = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds_city.Tables[0].Rows.Count < 1)
                city = "";
            else
                city = ds_city.Tables[0].Rows[0]["city"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return city;

    }

    protected string get_EmpName(string Empcode)
    {
        string Name = "";
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select empcode,isnull(emp_fname,'')+' '+isnull(emp_m_name,'')+' '+isnull(emp_l_name,'') as emp_fname from tbl_intranet_employee_jobDetails where empcode='" + Empcode + "'";
            DataSet ds_emp = new DataSet();
            ds_emp = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds_emp.Tables[0].Rows.Count < 1)
                Name = "";
            else
                Name = ds_emp.Tables[0].Rows[0]["emp_fname"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return Name;

    }

    protected void bind_pre_city(int stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
            DataSet ds5 = new DataSet();
            ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            ddl_pre_city.DataSource = ds5;
            ddl_pre_city.DataTextField = "city";
            ddl_pre_city.DataValueField = "cid";
            ddl_pre_city.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void bind_per_state(string stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_per_state.DataTextField = "state";
            ddl_per_state.DataValueField = "ID";
            ddl_per_state.DataSource = ds4;
            ddl_per_state.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_Emergency_state(string stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_emergency_state.DataTextField = "state";
            ddl_emergency_state.DataValueField = "ID";
            ddl_emergency_state.DataSource = ds4;
            ddl_emergency_state.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void btncontact_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();

            transaction = connection.BeginTransaction();

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();
                edit_contact_detail(emplyee_Code, connection, transaction);
                Insert_Emg_Contact_detail(emplyee_Code, connection, transaction);
                transaction.Commit();
                //  resetcontact();

                //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                string str = "<script> alert('Saved successfully')</script>";
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "xx", str, false);
                //TabContainer1.ActiveTabIndex = 0;
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void edit_contact_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        string st1 = "select app_hrd from tbl_employee_approvers where empcode ='" + emp_code + "'";
        DataSet dsx = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, st1);
        if (dsx.Tables[0].Rows.Count < 1)
        {
            Output.Show("Approver not updated");
            return;
        }
        hrcode = dsx.Tables[0].Rows[0]["app_hrd"].ToString();
        SqlParameter[] sqlParam = new SqlParameter[28];

        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;
        sqlParam[1] = new SqlParameter("@pre_add1", SqlDbType.VarChar, 500);
        sqlParam[1].Value = txt_pre_add1.Text;
        sqlParam[2] = new SqlParameter("@pre_Add2", SqlDbType.VarChar, 500);
        sqlParam[2].Value = txt_pre_Add2.Text;
        sqlParam[3] = new SqlParameter("@pre_city", SqlDbType.VarChar, 100);
        if ((ddl_pre_city.SelectedValue == "0") || (ddl_pre_city.SelectedValue == ""))
        {
            sqlParam[3].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[3].Value = ddl_pre_city.SelectedValue;
        }
        sqlParam[4] = new SqlParameter("@pre_state", SqlDbType.VarChar, 50);
        if ((ddl_pre_state.SelectedValue == "0") || (ddl_pre_state.SelectedValue == ""))
        {
            sqlParam[4].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[4].Value = ddl_pre_state.SelectedValue;
        }
        sqlParam[5] = new SqlParameter("@pre_country", SqlDbType.VarChar, 50);
        if ((ddl_pre_country.SelectedValue == "0") || (ddl_pre_country.SelectedValue == ""))
        {
            sqlParam[5].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[5].Value = ddl_pre_country.SelectedValue;
        }
        sqlParam[6] = new SqlParameter("@pre_zip", SqlDbType.VarChar, 50);
        sqlParam[6].Value = txt_pre_zip.Text;
        sqlParam[7] = new SqlParameter("@pre_phone", SqlDbType.VarChar, 50);
        sqlParam[7].Value = txt_pre_phone.Text;
        sqlParam[8] = new SqlParameter("@per_add1", SqlDbType.VarChar, 500);
        sqlParam[8].Value = txt_per_add1.Text;
        sqlParam[9] = new SqlParameter("@per_add2", SqlDbType.VarChar, 500);
        sqlParam[9].Value = txt_per_add2.Text;
        sqlParam[10] = new SqlParameter("@per_city", SqlDbType.VarChar, 100);
        if ((ddl_per_city.SelectedValue == "0") || (ddl_per_city.SelectedValue == ""))
        {
            sqlParam[10].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[10].Value = ddl_per_city.SelectedValue;
        }
        sqlParam[11] = new SqlParameter("@per_state", SqlDbType.VarChar, 50);
        if ((ddl_per_state.SelectedValue == "0") || (ddl_per_state.SelectedValue == ""))
        {
            sqlParam[11].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[11].Value = ddl_per_state.SelectedValue;
        }
        sqlParam[12] = new SqlParameter("@per_country", SqlDbType.VarChar, 50);
        if ((ddl_per_country.SelectedValue == "0") || (ddl_per_country.SelectedValue == ""))
        {
            sqlParam[12].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[12].Value = ddl_per_country.SelectedValue;
        }
        sqlParam[13] = new SqlParameter("@per_zip", SqlDbType.VarChar, 50);
        sqlParam[13].Value = txt_per_zip.Text;
        sqlParam[14] = new SqlParameter("@per_phone", SqlDbType.VarChar, 50);
        sqlParam[14].Value = txt_per_phone.Text;
        sqlParam[15] = new SqlParameter("@mode", SqlDbType.TinyInt);

        if (optcompany.Checked)
        {
            sqlParam[15].Value = 1;
        }

        else if (optown.Checked)
        {
            sqlParam[15].Value = 0;
        }
        else
        {
            sqlParam[15].Value = System.Data.SqlTypes.SqlString.Null;
        }

        sqlParam[16] = new SqlParameter("@modeoftransport", SqlDbType.VarChar, 50);
        sqlParam[16].Value = txtmodeoftransport.Text;

        sqlParam[17] = new SqlParameter("@emergency_contact_no", SqlDbType.VarChar, 50);
        sqlParam[17].Value = txt_emergency_contactno.Text;

        sqlParam[18] = new SqlParameter("@emergency_name", SqlDbType.VarChar, 50);
        sqlParam[18].Value = txt_emergency_name.Text;

        sqlParam[19] = new SqlParameter("@emergency_relation", SqlDbType.VarChar, 50);
        sqlParam[19].Value = drp_emg_relation.SelectedValue;

        sqlParam[20] = new SqlParameter("@emergency_address1", SqlDbType.VarChar, 500);
        sqlParam[20].Value = txt_emergency_address.Text;

        sqlParam[21] = new SqlParameter("@emergency_address2", SqlDbType.VarChar, 500);
        sqlParam[21].Value = txt_emergency_address2.Text;

        sqlParam[22] = new SqlParameter("@emergency_city", SqlDbType.Int);
        if ((ddl_emergency_city.SelectedValue == "0") || (ddl_emergency_city.SelectedValue == ""))
        {
            sqlParam[22].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlParam[22].Value = Convert.ToInt32(ddl_emergency_city.SelectedValue);
        }

        sqlParam[23] = new SqlParameter("@emergency_state", SqlDbType.Int);
        if ((ddl_emergency_state.SelectedValue == "0") || (ddl_emergency_state.SelectedValue == ""))
        {
            sqlParam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlParam[23].Value = Convert.ToInt32(ddl_emergency_state.SelectedValue);
        }
        sqlParam[24] = new SqlParameter("@emergency_country", SqlDbType.VarChar, 50);
        if ((ddl_emergency_country.SelectedValue == "0") || (ddl_emergency_country.SelectedValue == ""))
        {
            sqlParam[24].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[24].Value = ddl_emergency_country.SelectedValue;
        }

        sqlParam[25] = new SqlParameter("@emergency_zip", SqlDbType.VarChar, 50);
        sqlParam[25].Value = txt_emergency_zipcode.Text;

        sqlParam[26] = new SqlParameter("@Approvercode", SqlDbType.VarChar, 50);
        sqlParam[26].Value = hrcode;
        sqlParam[27] = new SqlParameter("@Approverstatus", SqlDbType.Int);
        sqlParam[27].Value = 0;


        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_contact_edit_details]", sqlParam);
    }

    protected void optcompany_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = true;
        lblpickuppoint.Visible = true;
    }

    protected void optown_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = false;
        lblpickuppoint.Visible = false;
    }

    protected void gvemgcontact_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["emg_contact"];

        DataRow drfind_child = dtable.Rows.Find(Convert.ToString(gvemgcontact.DataKeys[e.RowIndex].Value));
        if (drfind_child != null)
        {
            drfind_child.Delete();
            Session["emg_contact"] = dtable;
            BindList_Emg_Contact();
        }
    }

    protected void BindList_Emg_Contact()
    {
        if (Session["emg_contact"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["emg_contact"];
            dview = new DataView(dtable);
            dview.Sort = "emg_name";
        }
        gvemgcontact.DataSource = dview;
        gvemgcontact.DataBind();
    }

    protected void Insert_Emg_Contact_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        string sqlstr1 = "delete from tbl_employee_emgcontact_details where empcode ='" + emp_code + "'";
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1);
        if (Session["emg_contact"] != null)
        {
            dtable = (DataTable)Session["emg_contact"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                string sqlstr = @"insert into tbl_employee_emgcontact_details(empcode,emg_name ,emg_relation,emg_contactno,emg_landlineno ) values('" + emp_code + "','" + dtable.Rows[i]["emg_name"].ToString() + "','" + dtable.Rows[i]["emg_relation"].ToString() + "','" + dtable.Rows[i]["emg_contactno"].ToString() + "','" + dtable.Rows[i]["emg_landlineno"].ToString() + "')";
                SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            }
        }
    }

    protected void btnemgcontact_Click(object sender, EventArgs e)
    {
        Emg_Conatct_grid();
        txt_emergency_name.Text = "";
        txt_emg_ccode.Text = "";
        drp_emg_relation.SelectedValue = "0";
        txt_emergency_contactno.Text = "";
        txt_emg_landlinestdcode.Text = "";
        txt_emg_landlineno.Text = "";
        txt_emg_landcode.Text = "";
    }

    protected void Emg_Conatct_grid()
    {
        DataRow dr;
        if (Session["emg_contact"] == null)
        {
            create_emg_contact_table();
        }
        dtable = (DataTable)Session["emg_contact"];

        DataRow drfind = dtable.Rows.Find(txt_emergency_name.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["emg_name"] = txt_emergency_name.Text;
            dr["emg_relation"] = drp_emg_relation.SelectedValue;
            dr["emg_contactno"] = txt_emg_ccode.Text + "-" + txt_emergency_contactno.Text;
            dr["emg_landlineno"] = txt_emg_landcode.Text + "-" + txt_emg_landlinestdcode.Text + "-" + txt_emg_landlineno.Text;

            dtable.Rows.Add(dr);
        }
        Session["emg_contact"] = dtable;
        BindList_Emg_Contact();
    }

    protected void create_emg_contact_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("emg_name", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["emg_name"] };
        dtable.Columns.Add("emg_relation", typeof(string));
        dtable.Columns.Add(new DataColumn("emg_contactno", typeof(string)));
        dtable.Columns.Add(new DataColumn("emg_landlineno", typeof(string)));
        Session["emg_contact"] = dtable;
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            //if ((ddl_pre_country.SelectedValue == "0") || (ddl_pre_state.SelectedValue == "0") || (ddl_pre_city.SelectedValue == "0"))
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please Select Country,State and City in Present Address');", true);
            //    CheckBox1.Checked = false;
            //}
            //else
            //{
            txt_per_add1.Text = txt_pre_add1.Text;
            //txt_per_add2.Text = txt_pre_Add2.Text;
            //ddl_per_country.SelectedValue = ddl_pre_country.SelectedValue;
            //bind_per_state(ddl_per_country.SelectedValue);
            //ddl_per_state.SelectedValue = ddl_pre_state.SelectedValue;
            //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
            //ddl_per_city.SelectedValue = ddl_pre_city.SelectedValue;
            //txt_per_zip.Text = txt_pre_zip.Text;
            //txt_per_phone.Text = txt_pre_phone.Text;
            txt_per_add1.Enabled = false;
            txt_per_add2.Enabled = false;
            ddl_per_city.Enabled = false;
            ddl_per_state.Enabled = false;
            ddl_per_country.Enabled = false;
            txt_per_zip.Enabled = false;
            txt_per_phone.Enabled = false;
            // }
        }
        else
        {
            txt_per_add1.Enabled = true;
            txt_per_add2.Enabled = true;
            ddl_per_city.Enabled = true;
            ddl_per_state.Enabled = true;
            ddl_per_country.Enabled = true;
            txt_per_zip.Enabled = true;
            txt_per_phone.Enabled = true;
            txt_per_add1.Text = "";
            txt_per_add2.Text = "";
            ddl_per_country.SelectedValue = "0";
            ddl_per_state.DataSource = "";
            ddl_per_state.DataBind();
            ddl_per_city.DataSource = "";
            ddl_per_city.DataBind();
            txt_per_zip.Text = "";
            txt_per_phone.Text = "";
        }
    }

    protected void btnprop_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();

            transaction = connection.BeginTransaction();

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();
                Edit_Educational_Qualification(emplyee_Code, connection, transaction);
                edit_Professional_Qualification(emplyee_Code, connection, transaction);
                edit_Expriece_detail(emplyee_Code, connection, transaction);
                edit_Training_details(emplyee_Code, connection, transaction);
                transaction.Commit();
                // reset_professional_detail();

                //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                string str = "<script> alert('Saved Successfully')</script>";
                ScriptManager.RegisterStartupScript(upedu, upedu.GetType(), "xx", str, false);
                Page.RegisterStartupScript("Employee", str.ToString());
                //TabContainer1.ActiveTabIndex = 0;
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void Edit_Educational_Qualification(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["acc_education"] != null)
        {
            sqlstr = "delete  from tbl_employee_edcational where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

            dtable = (DataTable)Session["acc_education"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["education"].ToString();

                sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["school"].ToString();

                sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["percentage"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                sqlParam[6].Value = dtable.Rows[i]["specialization"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_education]", sqlParam);
            }
        }
    }

    protected void edit_Professional_Qualification(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["Pro_education"] != null)
        {
            sqlstr = "delete from tbl_employee_professional where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

            dtable = (DataTable)Session["Pro_education"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["education"].ToString();

                sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["school"].ToString();

                sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["percentage"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                sqlParam[6].Value = dtable.Rows[i]["specialization"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_professional]", sqlParam);
            }
        }
    }

    protected void edit_Expriece_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["exp"] != null)
        {
            sqlstr = "delete from tbl_employee_experience where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

            dtable = (DataTable)Session["exp"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@companyname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["comp_name"].ToString();

                sqlParam[2] = new SqlParameter("@location", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["location"].ToString();

                sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@designation", SqlDbType.VarChar, 50);
                sqlParam[6].Value = dtable.Rows[i]["designation"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_experienc]", sqlParam);
            }
        }
    }

    protected void edit_Training_details(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["training"] != null)
        {
            sqlstr = "delete from tbl_intranet_employee_training where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["training"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[6];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@trainingname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["trainingname"].ToString();

                sqlParam[2] = new SqlParameter("@personname", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["personname"].ToString();

                sqlParam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
                sqlParam[3].Value = dtable.Rows[i]["fromdate"].ToString();

                sqlParam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
                sqlParam[4].Value = dtable.Rows[i]["todate"].ToString();

                sqlParam[5] = new SqlParameter("@remarks", SqlDbType.VarChar, 500);
                sqlParam[5].Value = dtable.Rows[i]["remarks"].ToString();



                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_emp_training]", sqlParam);
            }
        }

    }

    protected void GridTraning_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["training"];
        DataRow drfind_Training = dtable.Rows.Find(Convert.ToString(GridTraning.DataKeys[e.RowIndex].Value));
        if (drfind_Training != null)
        {
            drfind_Training.Delete();
            Session["training"] = dtable;
            BindList_Training();
        }
    }

    protected void btn_Training_Click(object sender, EventArgs e)
    {
        add_Training();
        txt_TrProgram.Text = "";
        txt_TrConductedBy.Text = "";
        txtFromdate.Text = "";
        txtToDate.Text = "";
        txtTrRemarks.Text = "";
    }

    protected void grid_exp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["exp"];
        DataRow drfind_exp = dtable.Rows.Find(Convert.ToString(grid_exp.DataKeys[e.RowIndex].Value));
        if (drfind_exp != null)
        {
            drfind_exp.Delete();
            Session["exp"] = dtable;
            BindList_exp();
        }
    }

    protected void btn_exp_add_Click(object sender, EventArgs e)
    {
        dtable = (DataTable)Session["Pro_education"];
        string anyYear = txt_exp_from.Text;
        int anyyr = Convert.ToInt32(anyYear);
        int toYearFstPg = anyyr;

        if (dtable != null)
        {
            int fromYear = Convert.ToInt32(dtable.Rows[0][4]);
            if (toYearFstPg < fromYear)
            {
                Common.Console.Output.Show("Experience year should be greater than Profestional Qual");
                return;
            }
        }

        else
        {
            int fromyear = Convert.ToInt32(txt_exp_to.Text);
            int total = fromyear - toYearFstPg;

            int totalexp = Convert.ToInt32(txt_total_exp.Text);
            if (total < totalexp)
            {
                Common.Console.Output.Show("Enter valid year in Experience details");
                return;
            }

        }

        Ins_exp();
        txtcomp1.Text = "";
        txt_com_local.Text = "";
        txt_total_exp.Text = "";
        txt_exp_from.Text = "";
        txt_exp_to.Text = "";
        txt_EXp_designation.Text = "";
    }

    protected void Ins_exp()
    {
        DataRow dr;
        if (Session["exp"] == null)
        {
            create_exp_table();
        }
        dtable = (DataTable)Session["exp"];

        //DataRow drfind = dtable.Rows.Find(txtcomp1.Text);
        //if (drfind != null)
        //{
        //}
        //else
        //{
        dr = dtable.NewRow();


        dr["comp_name"] = txtcomp1.Text;
        dr["location"] = txt_com_local.Text;
        dr["total_exp"] = txt_total_exp.Text;
        dr["from_year"] = txt_exp_from.Text;
        dr["to_year"] = txt_exp_to.Text;
        dr["designation"] = txt_EXp_designation.Text;
        dtable.Rows.Add(dr);
        //}
        Session["exp"] = dtable;
        BindList_exp();
    }

    protected void grid_Pro_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Pro_education"];
        DataRow drfind_pro_edu = dtable.Rows.Find(Convert.ToString(grid_Pro_education.DataKeys[e.RowIndex].Value));
        if (drfind_pro_edu != null)
        {
            drfind_pro_edu.Delete();
            Session["Pro_education"] = dtable;
            BindList_pro_edu();
        }
    }

    protected void btn_pro_qual_add_Click(object sender, EventArgs e)
    {
        dtable = (DataTable)Session["acc_education"];
        int toYearFstPg = Convert.ToInt32(txtfrm1.Text);

        int fromYear = Convert.ToInt32(dtable.Rows[0][4]);
        if (toYearFstPg < fromYear)
        {
            Common.Console.Output.Show("Professtional Qual year should be greater than Eduacational Qual");
            return;
        }
        Ins_Pro_edu();
        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        txtfrm1.Text = "";
        txtto1.Text = "";
        txtpro_specilazation.Text = "";
    }

    protected void Ins_Pro_edu()
    {
        DataRow dr;
        if (Session["Pro_education"] == null)
        {
            create_Pro_edu_table();
        }
        dtable = (DataTable)Session["Pro_education"];

        DataRow drfind = dtable.Rows.Find(txteduc1.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["education"] = txteduc1.Text;
            dr["school"] = txtsch1.Text;
            dr["percentage"] = txtper1.Text;
            dr["from_year"] = txtfrm1.Text;
            dr["to_year"] = txtto1.Text;
            dr["specialization"] = txtpro_specilazation.Text;

            dtable.Rows.Add(dr);
        }
        Session["Pro_education"] = dtable;
        BindList_pro_edu();
    }

    protected void grid_edu_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["acc_education"];
        DataRow drfind_acc_edu = dtable.Rows.Find(Convert.ToString(grid_edu_education.DataKeys[e.RowIndex].Value));
        if (drfind_acc_edu != null)
        {
            drfind_acc_edu.Delete();
            Session["acc_education"] = dtable;
            BindList_acc_edu();
        }

    }

    protected void drp_edu_qualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_edu_qualification.SelectedValue == "others")
            div_Edu_Qual_others.Visible = true;
        else
            div_Edu_Qual_others.Visible = false;
    }

    protected void btn_quali_add_Click(object sender, EventArgs e)
    {
        if (drp_edu_qualification.SelectedValue == "others" && txt_Edu_Qual_others.Text.Trim() == "")
        {
            Common.Console.Output.Show("Please fill OTHERS details in below text field");
        }
        else
        {
            Ins_acc_edu();
            drp_edu_qualification.SelectedValue = "0";
            txtedush.Text = "";
            txteduper.Text = "";
            txtedufrom.Text = "";
            txteduto.Text = "";
            txtedu_specilazation.Text = "";
            txt_Edu_Qual_others.Text = "";
        }
    }

    protected void Ins_acc_edu()
    {
        DataRow dr;
        if (Session["acc_education"] == null)
        {
            create_acc_edu_table();
        }

        else
        {
            dtable = (DataTable)Session["acc_education"];
            if (dtable.Rows[0][4] != null)
            {
                check_equal(dtable);
                int toYearsecPg = Convert.ToInt32(txtedufrom.Text);

                int fromfirstYear = Convert.ToInt32(dtable.Rows[0][4]);
                if (toYearsecPg < fromfirstYear)
                {
                    Common.Console.Output.Show("The Education year should be equal or greater then the end year of the previous Education year");
                    return;
                }
            }
        }
        dtable = (DataTable)Session["acc_education"];

        DataRow drfind = dtable.Rows.Find(drp_edu_qualification.SelectedItem.ToString());
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            String edu_qual = "";
            if (drp_edu_qualification.SelectedValue != "others")
                edu_qual = drp_edu_qualification.SelectedItem.ToString();
            else
                edu_qual = txt_Edu_Qual_others.Text;

            dr["education"] = edu_qual;
            dr["school"] = txtedush.Text;
            dr["percentage"] = txteduper.Text;
            dr["from_year"] = txtedufrom.Text;
            dr["to_year"] = txteduto.Text;
            dr["specialization"] = txtedu_specilazation.Text;
            dtable.Rows.Add(dr);
        }
        Session["acc_education"] = dtable;
        BindList_acc_edu();
    }

    void check_equal(DataTable dtable)
    {
        if (dtable.Rows[0][4] != null)
        {
            string secondyearedu = drp_edu_qualification.SelectedValue.Trim();
            ////string secondyearspecialization = txtedu_specilazation.Text;
            ////string secondyearschool = txtedush.Text;
            ////string percentage = txteduper.Text;
            ////int fromYearsecPg = Convert.ToInt32(txteduto.Text);
            ////int toYearsecPg = Convert.ToInt32(txtedufrom.Text);
            //string xx = (dtable.Rows[0][0]).ToString();

            ////string xx1 = (dtable.Rows[0][1]).ToString();
            ////string xx2 = (dtable.Rows[0][2]).ToString();
            ////int xx3 =Convert.ToInt32(dtable.Rows[0][3]);
            ////int xx4 =Convert.ToInt32(dtable.Rows[0][4]);
            //if ((secondyearedu == xx))
            //{
            //    Common.Console.Output.Show("Record Already Inserted");
            //    return;
            //}
            for (int i = 0; i <= dtable.Rows.Count - 1; i++)
            {
                if (dtable.Rows[i][0].ToString() == secondyearedu)
                {
                    Common.Console.Output.Show("Record Already Inserted");
                    return;
                }

            }



        }
    }

    protected void btnpersonal_Click(object sender, EventArgs e)
    {
        if (txt_DOB.Text != "")
        {
            if (Convert.ToDateTime(txt_DOB.Text) > DateTime.Now)
            {
                Output.Show("Date of birth should be less than or  equal to current date");
                return;

            }

        }
        if (txt_s_DOB.Text != "")
        {
            if (Convert.ToDateTime(txt_s_DOB.Text) > DateTime.Now)
            {
                Output.Show("Spouse Date of birth should be less than or  equal to current date");
                return;
            }
        }
        if (txt_child_Dob.Text != "")
        {
            if (Convert.ToDateTime(txt_child_Dob.Text) > DateTime.Now)
            {
                Output.Show("Children Date of birth should be less than or equal to current date");
                return;
            }
        }

        try
        {
            connection = activity.OpenConnection();

            transaction = connection.BeginTransaction();

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();
                edit_personal_detail(emplyee_Code, connection, transaction);
                edit_Children_detail(emplyee_Code, connection, transaction);
                transaction.Commit();
                // resetPersonalDetails();
                string str = "<script> alert('Saved Successfully')</script>";
                ScriptManager.RegisterStartupScript(updatepanel8, updatepanel8.GetType(), "xx", str, false);
                Page.RegisterStartupScript("Employee", str.ToString());
                //TabContainer1.ActiveTabIndex = 0;
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void edit_Children_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {

        sqlstr = "delete from tbl_employee_childrendetail where empcode ='" + emp_code + "'";
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

        if (Session["child"] != null)
        {
            dtable = (DataTable)Session["child"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DateTime dob;
                if (dtable.Rows[i]["child_dob"].ToString() != "")
                {
                    dob = Convert.ToDateTime(dtable.Rows[i]["child_dob"]);
                }
                else
                    dob = Convert.ToDateTime("01/01/1900");
                //System.Data.SqlTypes.SqlDateTime.Null;

                SqlParameter[] sqlParam = new SqlParameter[4];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@child_name", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["child_name"].ToString();

                sqlParam[2] = new SqlParameter("@childdob", SqlDbType.DateTime);
                sqlParam[2].Value = dob;

                sqlParam[3] = new SqlParameter("@gender", SqlDbType.VarChar, 10);
                sqlParam[3].Value = dtable.Rows[i]["gender"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_insert_childrendetail]", sqlParam);
            }
        }
    }

    protected void edit_personal_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {

        int paymentmode = 0;
        SqlParameter[] sqlParam = new SqlParameter[35];

        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;
        sqlParam[1] = new SqlParameter("@f_fname", SqlDbType.VarChar, 50);
        sqlParam[1].Value = txt_f_f_name.Text;
        sqlParam[2] = new SqlParameter("@f_mname", SqlDbType.VarChar, 50);
        //---------changes by ramu nunna for update shirt and t-shirt Details
        sqlParam[2].Value = ddl_Tshirt.SelectedValue;//txt_f_mname.Text;
        sqlParam[3] = new SqlParameter("@f_lname", SqlDbType.VarChar, 50);
        sqlParam[3].Value = ddl_ShirtSize.SelectedValue;// txt_f_l_name.Text;
        //end --------------------------------------------
        sqlParam[4] = new SqlParameter("@m_fname", SqlDbType.VarChar, 50);
        sqlParam[4].Value = txt_m_fname.Text;
        sqlParam[5] = new SqlParameter("@m_lname", SqlDbType.VarChar, 50);
        sqlParam[5].Value = txt_m_l_name.Text;
        sqlParam[6] = new SqlParameter("@m_mname", SqlDbType.VarChar, 50);
        sqlParam[6].Value = txt_m_mname.Text;
        sqlParam[7] = new SqlParameter("@bloodgrp", SqlDbType.VarChar, 50);
        sqlParam[7].Value = ddlbloodgrp.SelectedValue;
        sqlParam[8] = new SqlParameter("@maritalstatus", SqlDbType.VarChar, 50);
        sqlParam[8].Value = ddlpersonalstatus.SelectedValue;
        sqlParam[9] = new SqlParameter("@religion", SqlDbType.VarChar, 50);
        sqlParam[9].Value = txtrelg.Text;
        sqlParam[10] = new SqlParameter("@doa", SqlDbType.DateTime);
        if (txt_doa.Text == "")
            sqlParam[10].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[10].Value = txt_doa.Text; // Utility.dataformat(txt_doa.Text);
        sqlParam[11] = new SqlParameter("@dlno", SqlDbType.VarChar, 50);
        sqlParam[11].Value = txt_dl_no.Text;
        sqlParam[12] = new SqlParameter("@s_fname", SqlDbType.VarChar, 50);
        sqlParam[12].Value = txt_sp_fname.Text;
        sqlParam[13] = new SqlParameter("@s_mname", SqlDbType.VarChar, 50);
        sqlParam[13].Value = txt_sp_mname.Text;
        sqlParam[14] = new SqlParameter("@s_lname", SqlDbType.VarChar, 50);
        sqlParam[14].Value = txt_sp_lname.Text;
        sqlParam[15] = new SqlParameter("@s_dob", SqlDbType.DateTime);
        if (txt_s_DOB.Text == "")

            sqlParam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[15].Value = txt_s_DOB.Text; //Utility.dataformat(txt_s_DOB.Text);

        sqlParam[16] = new SqlParameter("@s_gender", SqlDbType.VarChar, 50);
        sqlParam[16].Value = ddl_s_gender.SelectedValue;
        sqlParam[17] = new SqlParameter("@no_child", SqlDbType.Int);
        sqlParam[17].Value = 3;
        sqlParam[18] = new SqlParameter("@mobile_no", SqlDbType.VarChar, 50);
        sqlParam[18].Value = txtccode.Text + " - " + txtmobileno.Text;
        sqlParam[19] = new SqlParameter("@email_id", SqlDbType.VarChar, 50);
        sqlParam[19].Value = txt_email.Text;
        sqlParam[20] = new SqlParameter("@bank_name", SqlDbType.VarChar, 50);
        sqlParam[20].Value = ddl_bank_name.SelectedValue;
        sqlParam[21] = new SqlParameter("@ac_number", SqlDbType.VarChar, 50);
        sqlParam[21].Value = txt_bank_ac.Text;
        sqlParam[22] = new SqlParameter("@passport_number", SqlDbType.VarChar, 50);
        sqlParam[22].Value = txt_passportno.Text;

        sqlParam[23] = new SqlParameter("@DOB", SqlDbType.DateTime);
        if (txt_DOB.Text == "")
            sqlParam[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[23].Value = txt_DOB.Text;// Utility.dataformat(txt_DOB.Text);

        if (rbtnbank.Checked)
            paymentmode = 0;

        if (rbtncheque.Checked)
            paymentmode = 1;

        if (rbtncash.Checked)
            paymentmode = 2;

        sqlParam[24] = new SqlParameter("@paymentmode", SqlDbType.Int);
        sqlParam[24].Value = paymentmode;

        sqlParam[25] = new SqlParameter("@bank_name_reimbursement", SqlDbType.VarChar, 50);
        sqlParam[25].Value = ddl_bank_name_reimbursement.SelectedValue;
        sqlParam[26] = new SqlParameter("@ac_number_reimbursement", SqlDbType.VarChar, 50);
        sqlParam[26].Value = txt_bank_ac_reimbursement.Text.Trim();

        sqlParam[27] = new SqlParameter("@bankbranch", SqlDbType.VarChar, 50);
        sqlParam[27].Value = txt_bankbrachname.Text;
        sqlParam[28] = new SqlParameter("@ifsc", SqlDbType.VarChar, 50);
        sqlParam[28].Value = txt_ifsc.Text;
        sqlParam[29] = new SqlParameter("@passportissuedate", SqlDbType.DateTime);
        if (txt_passportissueddate.Text == "")
        {
            sqlParam[29].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[29].Value = Convert.ToDateTime(txt_passportissueddate.Text);
        }
        sqlParam[30] = new SqlParameter("@passportexpiraydate", SqlDbType.DateTime);
        if (txt_passportexpdate.Text == "")
        {
            sqlParam[30].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[30].Value = Convert.ToDateTime(txt_passportexpdate.Text);
        }

        sqlParam[31] = new SqlParameter("@dl_number", SqlDbType.VarChar, 50);
        sqlParam[31].Value = txt_drli_no.Text;

        sqlParam[32] = new SqlParameter("@dlissuedate", SqlDbType.DateTime);
        if (txt_dr_iss_date.Text == "")
        {
            sqlParam[32].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[32].Value = Convert.ToDateTime(txt_dr_iss_date.Text);
        }


        sqlParam[33] = new SqlParameter("@dlexpiraydate", SqlDbType.DateTime);
        if (txt_dr_exp_date.Text == "")
        {
            sqlParam[33].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[33].Value = Convert.ToDateTime(txt_dr_exp_date.Text);
        }
        sqlParam[34] = new SqlParameter("@landlineno", SqlDbType.VarChar);
        sqlParam[34].Value = txtperccode.Text + "-" + txtperstdcode.Text + "-" + txtperlandno.Text;


        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_Edit_personaldetails]", sqlParam);
    }

    protected void grid_child_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["child"];
        DataRow drfind_child = dtable.Rows.Find(Convert.ToString(grid_child.DataKeys[e.RowIndex].Value));
        if (drfind_child != null)
        {
            drfind_child.Delete();
            Session["child"] = dtable;
            BindList_child();
        }
    }

    protected void btn_child_Add_Click(object sender, EventArgs e)
    {
        Child_grid();
        txt_child_name.Text = "";
        txt_child_Dob.Text = "";
    }

    protected void Child_grid()
    {
        DataRow dr;
        if (Session["child"] == null)
        {
            create_child_table();
        }
        dtable = (DataTable)Session["child"];

        DataRow drfind = dtable.Rows.Find(txt_child_name.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["child_name"] = txt_child_name.Text;
            dr["gender"] = ddl_child_gender.SelectedValue;
            dr["child_dob"] = txt_child_Dob.Text;

            dtable.Rows.Add(dr);
        }
        Session["child"] = dtable;
        BindList_child();
    }

    protected void ddl_bank_name_reimbursement_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name_reimbursement.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void rbtncash_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }

    protected void rbtncheque_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }

    protected void rbtnbank_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = true;
    }

    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {

        try
        {
            connection = activity.OpenConnection();
            string file_name = "";


            transaction = connection.BeginTransaction();

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            string st1 = "select app_hrd from tbl_employee_approvers where empcode ='" + emp_code + "'";
            DataSet dsx = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, st1);
            if (dsx.Tables[0].Rows.Count < 1)
            {
                Output.Show("Approver not updated");
                return;
            }



            //Edit_Educational_Qualification(emp_code, connection, transaction);
            //edit_Professional_Qualification(emp_code, connection, transaction);
            //edit_Expriece_detail(emp_code, connection, transaction);
            edit_personal_detail(emp_code, connection, transaction);
            edit_Children_detail(emp_code, connection, transaction);
            edit_contact_detail(emp_code, connection, transaction);
            Insert_Emg_Contact_detail(emp_code, connection, transaction);
            edit_emp_documents(emp_code, connection, transaction);
            Insert_PhotoIDProof_detail(emp_code, connection, transaction);
            Insert_Addressdoc_detail(emp_code, connection, transaction);
            Insert_otherdoc_detail(emp_code, connection, transaction);

            //edit_Training_details(emp_code, connection, transaction);
            transaction.Commit();
            sendmail();


        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            Common.Console.Output.Show("Employee Detail has sucessfully Updated");
        }


        //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
        string str = "<script> alert('Employee Detail has sucessfully Updated')</script>";
        Page.RegisterStartupScript("Employee", str.ToString());

        Response.Redirect("editmyprofile.aspx?updated=" + emp_code);
    }

    private void sendmail()
    {
        try
        {


            SqlDataAdapter sq = new SqlDataAdapter("select distinct app.app_hrd,job.emp_fname,job.official_email_id from tbl_employee_approvers app inner join dbo.tbl_intranet_employee_jobDetails job on job.empcode=app.app_hrd where  app.empcode='" + emp_code.ToString() + "'", connection);
            DataTable dt = new DataTable();
            sq.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                string _Name = dt.Rows[0][1].ToString();
                string _Email = dt.Rows[0][2].ToString();
                sendmail_Template1(_Name, _Email, emp_code, txtfirstname.Text.Trim());

            }

        }
        catch
        {

        }
    }

    public bool sendmail_Template1(string _Name, string _Email, string empcode, string empname)
    {
       
        try
        {

            string senderId = ConfigurationManager.AppSettings["fromEmail"]; // Sender EmailID
            string senderPassword = ConfigurationManager.AppSettings["pwd"]; // Sender Password      

            string Template = EmailTemplate(_Name, empname, empcode);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(_Email);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Profile Information - Pending";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;



            mailMessage.Priority = MailPriority.High;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            smtpClient.Host = ConfigurationManager.AppSettings["smtp"];
            smtpClient.EnableSsl = true;

            object userState = mailMessage;

            try
            {
                smtpClient.Send(mailMessage);
                if (IsAttachment)
                {
                    attachment.ContentStream.Close();

                }
                return true;
            }
            catch (System.Net.Mail.SmtpException)
            {
                return false;
            }
        }


        catch (Exception)
        {
            return false;
        }
    }

    public string EmailTemplate(string _Name, string empname, string empcode)
    {
        string appr = _Name.ToString();
        string emp = empname.ToString();
        string empcod = empcode.ToString();
        string EmailFormat = @"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>" +
                    "<html lang='en'>" +
"<head>" +

    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +

    "<style type='text/css'>" +
        "body, td, div, p, a, input" +
        "{" +
            "font-family: arial, sans-serif;" +
        "}" +
    "</style>" +

    "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
    "<title>OD Application</title>" +
    "<style type='text/css'>" +
        "body, td" +
        "{" +
            "font-size: 13px;" +
        "}" +

        "a:link, a:active" +
        "{" +
            "color: #1155CC;" +
            "text-decoration: none;" +
        "}" +

        "a:hover" +
       "{" +
            "text-decoration: underline;" +
            "cursor: pointer;" +
        "}" +

        "a:visited" +
        "{" +
            "color: #6611CC;" +
        "}" +

        "img" +
        "{" +
            "border: 0px;" +
        "}" +

        "pre" +
        "{" +
            "white-space: pre;" +
            "white-space: -moz-pre-wrap;" +
            "white-space: -o-pre-wrap;" +
            "white-space: pre-wrap;" +
           "word-wrap: break-word;" +
           "max-width: 800px;" +
            "overflow: auto;" +
        "}" +

        ".logo" +
        "{" +
            "left: -7px;" +
            "position: relative;" +
        "}" +
    "</style>" +
"</head>" +
"<body>" +
    "<div class='bodycontainer'>" +


        "<div class='maincontent'>" +

            "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>" +
                "<tr>" +

                    "<tr>" +
                        "<td colspan='2'><font size='-1' class='recipient'>" +
                            "<div></div>" +
                        "</font>" +
                           " <tr>" +
                                "<td colspan='2'>" +
                                    "<table width='100%' cellpadding='12' cellspacing='0' border='0'>" +
                                        "<tr>" +
                                            "<td>" +
                                                "<div style='overflow: hidden;'>" +
                                                    "<font size='-1'>" +
                                                        "<div id='leaveid'>" +
            //"<table width='100%'>" +
            //    "<tbody>" +

                                                            //        "<tr>" +
            //            "<td style='border-bottom: 1px solid #ccc; font: 12px arial'>" +
            //                "<div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Holiday Work Application</span></div>" +
            //            "</td>" +
            //            "<td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>" +
            //        "</tr>" +
            //    "</tbody>" +
            //"</table>" +
            //"<br>" +
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + " You have a pending Employee Profile Information submitted by " + emp + " - " + empcod + ".</p>" +

                                                            "<p>Click here - https://escalon.sdlapps.com </p>" +

                                                            "<p>" +
                                                                "<b>Regards,<br><br>" +
                                                                    "HR<br><br>" +
                                                                "</b>" +
                                                            "</p>" +
                                                            "<br>" +

                                                            "<table width='100%'>" +
                                                                "<tbody>" +
                                                                    "<tr>" +
                                                                        "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                            "<b>This is a system generated mail. Please do not reply to this email ID." +
                                                                            
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                        "</td>" +
                                                                    "</tr>" +
                                                                "</tbody>" +
                                                            "</table>" +

                                                        "</div>" +
                                                    "</font>" +
                                                "</div>" +
                                    "</table>" +
            "</table>" +
        "</div>" +
    "</div>" +

"</body>" +
"</html>";

        return EmailFormat;
    }

    protected void ddl_emergency_country_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //    protected void resetexperiencedetails()
    //    {
    //        txtcomp1.Text = "";
    //        txt_total_exp.Text = "";
    //        txt_exp_from.Text = "";
    //        txt_exp_to.Text = "";
    //    }
    // protected void resetcontact()
    //    {
    //        txt_pre_add1.Text = "";
    //        txt_pre_Add2.Text = "";

    //        //ddl_pre_city.SelectedValue = "0";
    //        //ddl_pre_state.SelectedValue = "0";
    //        //ddl_pre_country.SelectedValue = "0";
    //        txt_pre_zip.Text = "";
    //        txt_pre_phone.Text = "";
    //        txt_per_add1.Text = "";
    //        txt_per_add2.Text = "";
    //        //ddl_per_city.SelectedValue = "0";
    //        //ddl_per_state.SelectedValue = "0";
    //        //ddl_per_country.SelectedValue = "0";
    //        txt_per_zip.Text = "";
    //        txt_per_phone.Text = "";

    //    }
    //    protected void resetPersonalDetails()
    //    {

    //        txt_DOB.Text = "";
    //        txt_passportno.Text = "";
    //        txt_dl_no.Text = "";
    //        txt_email.Text = "";
    //        //txt_bank_name.Text = "";
    //        txt_bank_ac.Text = "";
    //        ddlbloodgrp.SelectedValue = "0";
    //        txtrelg.Text = "";
    //        txtmobileno.Text = "";
    //        txt_f_f_name.Text = "";
    //        txt_f_mname.Text = "";
    //        txt_f_l_name.Text = "";
    //        txt_m_fname.Text = "";
    //        txt_m_mname.Text = "";
    //        txt_m_l_name.Text = "";
    //        ddlpersonalstatus.SelectedValue = "0";
    //        tbl1.Visible = false;
    //        txt_s_DOB.Text = "";
    //        ddl_s_gender.SelectedValue = "0";
    //        txt_sp_fname.Text = "";
    //        txt_sp_mname.Text = "";
    //        txt_doa.Text = "";
    //        txt_sp_lname.Text = "";
    //        txt_child_name.Text = "";
    //        txt_child_Dob.Text = "";
    //        Session.Remove("Child");
    //        grid_child.DataSource = "";
    //        grid_child.DataBind();
    //    }
    //    protected void reset_professional_detail()
    //    {
    //        Session.Remove("acc_education");
    //        Session.Remove("Pro_education");
    //        Session.Remove("exp");
    //        Session.Remove("training");

    //        GridTraning.DataSource = "";
    //        GridTraning.DataBind();

    //        grid_edu_education.DataSource = "";
    //        grid_edu_education.DataBind();

    //        grid_Pro_education.DataSource = "";
    //        grid_Pro_education.DataBind();

    //        grid_exp.DataSource = "";
    //        grid_exp.DataBind();
    //        ddlpersonalstatus.SelectedValue = "0";
    //    }
    //}

    #region PhotoIdProof
    protected void Button2_Click(object sender, EventArgs e)
    {
        add_upload();
        // DropDownList25.SelectedIndex = -1;
        // DropDownList26.SelectedIndex = -1;
        RadioButton10.Checked = false;
        RadioButton11.Checked = false;
    }

    protected void add_upload()
    {
        DataRow dr;
        if (Session["upload"] == null)
        {
            create_upload_table();
        }
        dtable = (DataTable)Session["upload"];


        dr = dtable.NewRow();
        string file = "";
        if (FileUpload2.HasFile)
        {
            file = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
            string File_Ext = System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName);
            try
            {
                FileUpload2.PostedFile.SaveAs(Server.MapPath("../upload/employeedocuments/" + file));

            }
            catch (Exception exc)
            {
            }
        }
        string ss = "";
        if (RadioButton10.Checked)
        {
            ss = "Current Residential Address";
        }
        if (RadioButton11.Checked)
        {
            ss = "Current Permanent Address";
        }

        dr["ID_Type"] = DropDownList25.SelectedItem.Text;
        dr["Others"] = TextBox6.Text;
        dr["Address_Type"] = ss;
        dr["File"] = file;
        dtable.Rows.Add(dr);
        //}
        Session["upload"] = dtable;
        BindList_PhotoUpload();
    }

    protected void BindList_PhotoUpload()
    {
        if (Session["upload"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["upload"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridView3.DataSource = dview;
        GridView3.DataBind();
    }

    protected void create_upload_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("ID_Type", typeof(string));
        dtable.Columns.Add(new DataColumn("Others", typeof(string)));
        dtable.Columns.Add(new DataColumn("Address_Type", typeof(string)));
        dtable.Columns.Add(new DataColumn("File", typeof(string)));

        Session["upload"] = dtable;
    }
    protected void GridPhotoUpload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["upload"];
        DataRow drfind_upload = dtable.Rows.Find(Convert.ToString(GridView3.DataKeys[e.RowIndex].Value));
        if (drfind_upload != null)
        {
            drfind_upload.Delete();
            Session["upload"] = dtable;
            BindList_PhotoUpload();
        }
    }
    protected void Insert_PhotoIDProof_detail(string emplyee_Code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["upload"] != null)
        {
            sqlstr = "delete from Emp_PhotoId_Docedit where empcode ='" + emplyee_Code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["upload"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[5];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlParam[0].Value = emplyee_Code;

                sqlParam[1] = new SqlParameter("@id_type", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["ID_Type"].ToString();

                sqlParam[2] = new SqlParameter("@Others", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["Others"].ToString();

                //sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                //sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();

                sqlParam[3] = new SqlParameter("@Address_details", SqlDbType.VarChar, 100);
                sqlParam[3].Value = dtable.Rows[i]["Address_Type"].ToString();

                sqlParam[4] = new SqlParameter("@filename", SqlDbType.VarChar, 2000);
                sqlParam[4].Value = dtable.Rows[i]["File"].ToString();




                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_update_emp_Photoid_uploadedit]", sqlParam);
            }
        }
    }
    #endregion

    #region Addressdoc Upload
    protected void Button3_Click(object sender, EventArgs e)
    {
        add_Address_upload();

        DropDownList27.SelectedIndex = -1;
        TextBox74.Text = "";
        RadioButton10.Checked = false;
        RadioButton11.Checked = false;
    }

    protected void add_Address_upload()
    {
        DataRow dr;
        if (Session["Address_upload"] == null)
        {
            create_Address_upload_table();
        }
        dtable = (DataTable)Session["Address_upload"];


        dr = dtable.NewRow();
        string file = "";
        if (FileUpload3.HasFile)
        {
            file = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
            string File_Ext = System.IO.Path.GetExtension(FileUpload3.PostedFile.FileName);

            try
            {
                FileUpload3.PostedFile.SaveAs(Server.MapPath("../upload/employeedocuments/" + file));

            }
            catch (Exception exc)
            {
            }
        }
        string ss = "";
        if (RadioButton12.Checked)
        {
            ss = "Current Residential Address";
        }
        if (RadioButton13.Checked)
        {
            ss = "Current Permanent Address";
        }

        dr["ID_Type"] = DropDownList27.SelectedItem.Text;
        dr["Others"] = TextBox74.Text;
        dr["Address_Type"] = ss;
        dr["File"] = file;
        dtable.Rows.Add(dr);
        //}
        Session["Address_upload"] = dtable;
        BindList_Address_Upload();
    }

    protected void BindList_Address_Upload()
    {
        if (Session["Address_upload"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Address_upload"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridView8.DataSource = dview;
        GridView8.DataBind();
    }

    protected void create_Address_upload_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("ID_Type", typeof(string));
        dtable.Columns.Add(new DataColumn("Others", typeof(string)));
        dtable.Columns.Add(new DataColumn("Address_Type", typeof(string)));
        dtable.Columns.Add(new DataColumn("File", typeof(string)));

        Session["Address_upload"] = dtable;
    }
    protected void GridAddressUpload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Address_upload"];
        DataRow drfind_upload = dtable.Rows.Find(Convert.ToString(GridView8.DataKeys[e.RowIndex].Value));
        if (drfind_upload != null)
        {
            drfind_upload.Delete();
            Session["Address_upload"] = dtable;
            BindList_Address_Upload();
        }
    }
    protected void Insert_Addressdoc_detail(string emplyee_Code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["Address_upload"] != null)
        {
            sqlstr = "delete from Emp_Address_Docedit where empcode ='" + emplyee_Code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["Address_upload"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[5];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlParam[0].Value = emplyee_Code;

                sqlParam[1] = new SqlParameter("@id_type", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["ID_Type"].ToString();

                sqlParam[2] = new SqlParameter("@Others", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["Others"].ToString();

                //sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                //sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();

                sqlParam[3] = new SqlParameter("@Address_details", SqlDbType.VarChar, 100);
                sqlParam[3].Value = dtable.Rows[i]["Address_Type"].ToString();

                sqlParam[4] = new SqlParameter("@filename", SqlDbType.VarChar, 2000);
                sqlParam[4].Value = dtable.Rows[i]["File"].ToString();




                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_update_emp_Address_uploadedit]", sqlParam);
            }
        }
    }
    #endregion
    #region Otherdocumentupload
    protected void Button4_Click(object sender, EventArgs e)
    {
        add_Other_upload();


        TextBox73.Text = "";

    }

    protected void add_Other_upload()
    {
        DataRow dr;
        if (Session["Other_upload"] == null)
        {
            create_Otherdoc_upload_table();
        }
        dtable = (DataTable)Session["Other_upload"];

        ////DataRow drfind = dtable.Rows.Find(txt_TrProgram.Text);
        //if (drfind != null)
        //{
        //}
        //else
        //{
        dr = dtable.NewRow();
        string file = "";
        if (FileUpload4.HasFile)
        {
            file = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
            string File_Ext = System.IO.Path.GetExtension(FileUpload4.PostedFile.FileName);


            try
            {
                FileUpload4.PostedFile.SaveAs(Server.MapPath("../upload/employeedocuments/" + file));

            }
            catch (Exception exc)
            {
            }

        }



        dr["Others"] = TextBox73.Text;
        dr["File"] = file;
        dtable.Rows.Add(dr);
        //}
        Session["Other_upload"] = dtable;
        BindList_Otherdoc_Upload();
    }

    protected void BindList_Otherdoc_Upload()
    {
        if (Session["Other_upload"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Other_upload"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridView9.DataSource = dview;
        GridView9.DataBind();
    }

    protected void create_Otherdoc_upload_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("Others", typeof(string));
        dtable.Columns.Add(new DataColumn("File", typeof(string)));

        Session["Other_upload"] = dtable;
    }
    protected void GridOtherDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Other_upload"];
        DataRow drfind_upload = dtable.Rows.Find(Convert.ToString(GridView9.DataKeys[e.RowIndex].Value));
        if (drfind_upload != null)
        {
            drfind_upload.Delete();
            Session["Other_upload"] = dtable;
            BindList_Otherdoc_Upload();
        }
    }
    protected void Insert_otherdoc_detail(string emplyee_Code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["Other_upload"] != null)
        {
            sqlstr = "delete from Emp_Other_Docedit where empcode ='" + emplyee_Code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["Other_upload"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[3];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlParam[0].Value = emplyee_Code;

                sqlParam[1] = new SqlParameter("@Docname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["Others"].ToString();

                sqlParam[2] = new SqlParameter("@filename", SqlDbType.VarChar, 2000);
                sqlParam[2].Value = dtable.Rows[i]["File"].ToString();

                //sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                //sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();






                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_update_emp_otherdoc_uploadedit]", sqlParam);
            }
        }
    }
    #endregion


    protected void DropDownList25_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList25.SelectedItem.Text.ToString() == "Others")
        {
            tdother.Visible = true;
            textother.Visible = true;
        }
        else
        {
            tdother.Visible = false;
            textother.Visible = false;
        }
    }
    protected void DropDownList27_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList27.SelectedItem.Text.ToString() == "Others")
        {
            other2.Visible = true;
            txtother2.Visible = true;
        }
        else
        {
            other2.Visible = false;
            txtother2.Visible = false;
        }
    }

}
