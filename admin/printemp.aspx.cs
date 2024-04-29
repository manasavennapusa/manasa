using System;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.Configuration;
using System.IO;

public partial class admin_printemp : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    //=========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
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
            //if (Session["Visa"] != null)
            //{
            //    Session.Remove("Visa");
            //}
            //if (Session["Insurance"] != null)
            //{
            //    Session.Remove("Insurance");
            //}
            //if (Session["ResidentCard"] != null)
            //{
            //    Session.Remove("ResidentCard");
            //}

            string emp_code = Request.QueryString["empcode"].ToString();
            
            bind_job_detail(emp_code);
            bind_payrolldetails(emp_code);

            BindApproverDetails(emp_code);
            bind_contactdetails(emp_code);
            BindEmgContactDetails(emp_code);
            bind_Education_Qualification(emp_code);
            bind_Professional_Qualification(emp_code);
            bind_Exp_detail(emp_code);
            bind_Training_detail(emp_code);
            bind_personalinfo(emp_code);
            bind_emp_doc(emp_code);
            bind_child(emp_code);
            FetchPhoto(emp_code);
            DataSet dsPh = (DataSet)Session["photo"];
            //if (Session["photo"].ToString() != null)
            //    empimg.ImageUrl = "../Upload/photo/" + dsPh.Tables[0].Rows[0]["photo"].ToString();
            //else empimg.ImageUrl = "Upload/photo/image.jpg";


            if (Session["photo"].ToString() != null)
            {
                empimg.ImageUrl = "../upload/photo/" + dsPh.Tables[0].Rows[0]["photo"].ToString();

                if (File.Exists(Server.MapPath("../upload/photo/" + dsPh.Tables[0].Rows[0]["photo"].ToString())))
                {
                    empimg.ImageUrl = "../upload/photo/" + dsPh.Tables[0].Rows[0]["photo"].ToString();
                }
                else
                {
                    empimg.ImageUrl = "../upload/photo/image.jpg";
                }
            }
            else
            {
                empimg.ImageUrl = "../upload/photo/image.jpg";
            }
          
          
           // BindVisa(emp_code);
           // BindInsurance(emp_code);
          //  BindResidentCard(emp_code);

           
        }
    }

    private void FetchPhoto(string emp_code)
    {
        DataSet dsPhoto = new DataSet();
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "SELECT empcode,photo FROM tbl_intranet_employee_jobDetails WHERE empcode = '" + emp_code + "'";
            dsPhoto = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            Session["photo"] = dsPhoto;
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
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
           // txthrdeptclr.Text = ds.Tables[0].Rows[0]["clr_hr"].ToString();
            txtaccdeleclr.Text = ds.Tables[0].Rows[0]["clr_useraccountdeletion"].ToString();
            txtdottedlinemanager.Text = ds.Tables[0].Rows[0]["app_dotted_linemanager"].ToString();
            txthrcb.Text = ds.Tables[0].Rows[0]["app_hr_cb"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindEmgContactDetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select * from tbl_intranet_employee_emgcontact_details where empcode ='" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;
            gvemgcontact.DataSource = ds;
            gvemgcontact.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    //------------- bind the Job Detail of the emp master ----------------------------------------

    protected void bind_job_detail(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            //   string sqlstr = "SELECT tbl_login_1.empcode, tbl_intranet_employee_jobDetails.uid,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender, tbl_intranet_employee_jobDetails.emp_fname,tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name, tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_roll, tbl_intranet_employee_jobDetails.dept_id, tbl_intranet_employee_jobDetails.division_id,tbl_intranet_employee_jobDetails.degination_id, tbl_intranet_employee_jobDetails.Grade, tbl_intranet_employee_jobDetails.branch_id,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END)emp_doj, tbl_intranet_employee_jobDetails.ext_number, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.Status, tbl_login_1.login_id,tbl_login_1.role  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_login_1.empcode = tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
//            string sqlstr = @"SELECT tbl_intranet_employee_jobDetails.empcode, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender,tbl_intranet_employee_jobDetails.emp_fname, tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name,tbl_intranet_employee_status.employeestatus,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10),tbl_intranet_employee_jobDetails.emp_doj, 101) END) doj  , tbl_intranet_employee_jobDetails.ext_number,tbl_intranet_employee_jobDetails.Status, tbl_intranet_branch_detail.branch_name, tbl_intranet_grade.gradename, tbl_login.login_id,tbl_intranet_designation.designationname, tbl_intranet_division.division_name, tbl_intranet_role.role,tbl_internate_departmentdetails.department_name,(CASE WHEN tbl_intranet_employee_jobDetails.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10),tbl_intranet_employee_jobDetails.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(11), tbl_intranet_employee_jobDetails.emp_doleaving, 106) END)emp_doleaving,tbl_intranet_employee_jobDetails.reason_leaving,tbl_intranet_employee_jobDetails.salutation ,tbl_intranet_employee_jobDetails.official_email_id,tbl_intranet_employee_jobDetails.official_mob_no,
//  tbl_intranet_employee_jobDetails.cost_center_group_id,tbl_intranet_employee_jobDetails.notice_period,tbl_intranet_employee_jobDetails.cost_center_code,tbl_intranet_employee_jobDetails.country,
//  tbl_intranet_employee_jobDetails.state,tbl_intranet_employee_jobDetails.city,tbl_intranet_employee_jobDetails.location,
//  tbl_intranet_employee_jobDetails.add_cost_center_group_id,tbl_intranet_employee_jobDetails.add_cost_center_code,tbl_intranet_employee_jobDetails.employee_type,tbl_intranet_employee_jobDetails.sub_emp_type,
//  tbl_intranet_employee_jobDetails.add_country,tbl_intranet_employee_jobDetails.add_state,tbl_intranet_employee_jobDetails.add_city,
//  tbl_intranet_employee_jobDetails.add_location,tbl_intranet_employee_jobDetails.subgroupid,tbl_intranet_employee_jobDetails.broadgroupid,
//  tbl_intranet_employee_jobDetails.entityid,tbl_intranet_employee_jobDetails.supervisorcode,tbl_intranet_employee_jobDetails.hodcode,
//  tbl_intranet_employee_jobDetails.corporatereportingcode,tbl_intranet_employee_jobDetails.probationperiod, tbl_intranet_employee_jobDetails.probationenddate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationstartdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.deputationstartdate, 101) END)deputationstartdate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationenddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.deputationenddate, 106) END)deputationenddate ,tbl_intranet_employee_jobDetails.gradetype,tbl_intranet_employee_jobDetails.noticeperiod,(CASE WHEN tbl_intranet_employee_jobDetails.confirmationdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.confirmationdate, 101) END)confirmationdate   
//  FROM  tbl_intranet_employee_jobDetails
//  INNER JOIN tbl_login ON tbl_intranet_employee_jobDetails.empcode = tbl_login.empcode 
//  left JOIN tbl_intranet_grade on tbl_intranet_grade.id = tbl_intranet_employee_jobDetails.Grade 
//  INNER JOIN tbl_intranet_role ON tbl_login.role = tbl_intranet_role.id 
//  left JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id = tbl_intranet_branch_detail.Branch_Id 
//  left JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id = tbl_intranet_designation.id 
//  left JOIN tbl_intranet_division ON tbl_intranet_employee_jobDetails.division_id = tbl_intranet_division.ID 
//  left join tbl_internate_departmentdetails ON tbl_internate_departmentdetails.departmentid = tbl_intranet_employee_jobDetails.dept_id 
//  left JOIN tbl_intranet_employee_status ON tbl_intranet_employee_status.id = tbl_intranet_employee_jobDetails.emp_status 
//      where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";

            string sqlstr = @"SELECT tbl_intranet_employee_jobDetails.empcode, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.card_no, 
tbl_intranet_employee_jobDetails.emp_gender,tbl_intranet_employee_jobDetails.emp_fname, tbl_intranet_employee_jobDetails.emp_m_name,
tbl_intranet_employee_jobDetails.emp_l_name,tbl_intranet_employee_status.employeestatus,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(50),
tbl_intranet_employee_jobDetails.emp_doj, 106) END) doj  , tbl_intranet_employee_jobDetails.ext_number,tbl_intranet_employee_jobDetails.Status, tbl_intranet_branch_detail.branch_name,
tbl_intranet_grade.gradename, tbl_login.login_id,tbl_intranet_designation.designationname, tbl_intranet_division.division_name, tbl_intranet_role.role,tbl_internate_departmentdetails.department_name,
(CASE WHEN tbl_intranet_employee_jobDetails.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(50),tbl_intranet_employee_jobDetails.salary_cal_from, 106) END)salary_cal_from,
(CASE WHEN tbl_intranet_employee_jobDetails.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(51), tbl_intranet_employee_jobDetails.emp_doleaving, 106) END)emp_doleaving,
tbl_intranet_employee_jobDetails.reason_leaving,tbl_intranet_employee_jobDetails.salutation ,tbl_intranet_employee_jobDetails.official_email_id,tbl_intranet_employee_jobDetails.official_mob_no,
tbl_internate_employee_subtype.emp_subtype_name,tbl_internate_employee_type.emp_type_name,tbl_internate_department_type.dept_type_name,
  tbl_intranet_employee_jobDetails.cost_center_group_id,tbl_intranet_employee_jobDetails.cost_center_code,tbl_intranet_employee_jobDetails.country,
  tbl_intranet_employee_jobDetails.state,tbl_intranet_employee_jobDetails.city,tbl_intranet_employee_jobDetails.location,
  tbl_intranet_employee_jobDetails.add_cost_center_group_id,tbl_intranet_employee_jobDetails.add_cost_center_code,
  tbl_intranet_employee_jobDetails.add_country,tbl_intranet_employee_jobDetails.add_state,tbl_intranet_employee_jobDetails.add_city,
  tbl_intranet_employee_jobDetails.add_location,tbl_intranet_employee_jobDetails.subgroupid,tbl_intranet_employee_jobDetails.broadgroupid,
  tbl_intranet_employee_jobDetails.entityid,tbl_intranet_employee_jobDetails.supervisorcode,tbl_intranet_employee_jobDetails.hodcode,
  tbl_intranet_employee_jobDetails.corporatereportingcode,tbl_intranet_employee_jobDetails.probationperiod,
tbl_intranet_employee_jobDetails.probationenddate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationstartdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(50), 
tbl_intranet_employee_jobDetails.deputationstartdate, 106) END)deputationstartdate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationenddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(50),
tbl_intranet_employee_jobDetails.deputationenddate, 106) END)deputationenddate ,
tbl_intranet_employee_jobDetails.gradetype,tbl_intranet_employee_jobDetails.noticeperiod,
(CASE WHEN tbl_intranet_employee_jobDetails.confirmationdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(50),
tbl_intranet_employee_jobDetails.confirmationdate, 106) END)confirmationdate   
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
                doj.Text = ds.Tables[0].Rows[0]["doj"].ToString();
            else doj.Text = "";
            Label3.Text = ds.Tables[0].Rows[0]["ext_number"].ToString();
            txt_login_id.Text = ds.Tables[0].Rows[0]["login_id"].ToString();
            if (ds.Tables[0].Rows[0]["emp_doleaving"].ToString() != "")
                txtdol.Text = ds.Tables[0].Rows[0]["emp_doleaving"].ToString();
            if (ds.Tables[0].Rows[0]["salary_cal_from"].ToString() != "")
                txtsalary.Text = ds.Tables[0].Rows[0]["salary_cal_from"].ToString();

            txtreason.Text = ds.Tables[0].Rows[0]["reason_leaving"].ToString();
            //  drprole.SelectedValue = ds.Tables[0].Rows[0]["role"].ToString();
            //============added on 17-12-13======
            lblSalutation.Text = ds.Tables[0].Rows[0]["salutation"].ToString();
            drpempstatus.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();
            txtoff_mobileno.Text = ds.Tables[0].Rows[0]["official_mob_no"].ToString();
            txt_officialemail.Text = ds.Tables[0].Rows[0]["official_email_id"].ToString();
            txremployee_type.Text = ds.Tables[0].Rows[0]["emp_type_name"].ToString();
            txtsubemployeetype.Text = ds.Tables[0].Rows[0]["emp_subtype_name"].ToString();
            //lbl_notice.Text = ds.Tables[0].Rows[0]["notice_period"].ToString();
            if (ds.Tables[0].Rows[0]["employeestatus"].ToString().ToLower() == "probation ")
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
                if (ds.Tables[0].Rows[0]["employeestatus"].ToString().ToLower() == "confirmed ")
                {
                    //lblprob.Text = "Confirmation Date";
                    //trprobationperiod.Visible = true;
                    //trprobationdate.Visible = true;
                    //trprobationdate2.Visible = true;
                    //trconforimdate.Visible = true;

                    //trduptstart.Visible = false;
                    //trduptenddate.Visible = false;


                    trDOL.Visible = false;
                    trReasonL.Visible = false;
                }
                else
                    if (ds.Tables[0].Rows[0]["employeestatus"].ToString().ToLower() == "contractual")
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
                        if (ds.Tables[0].Rows[0]["employeestatus"].ToString().ToLower() == "resigned" || ds.Tables[0].Rows[0]["employeestatus"].ToString().ToUpper() == "VOLUNTARY RETIREMENT" || ds.Tables[0].Rows[0]["employeestatus"].ToString().ToUpper() == "RETIRED")
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
            //lblphoto.Text = (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["photo"].ToString()) != true) ? "<a href='../upload/photo/" + ds.Tables[0].Rows[0]["photo"].ToString() +
            //    "' target='_blank'></a>" : "No photo found";
            lblphoto.Text = (ds.Tables[0].Rows[0]["photo"].ToString() != "") ? "<a href='../../upload/photo/" + ds.Tables[0].Rows[0]["photo"].ToString() +
           "'>" + ds.Tables[0].Rows[0]["photo"].ToString() + "</a>" : "No file exist";

            if ((ds.Tables[0].Rows[0]["confirmationdate"].ToString() == "0") || (ds.Tables[0].Rows[0]["confirmationdate"].ToString() == ""))
            {
                txt_confirmationdate.Text = "";
            }
            else
            {
                txt_confirmationdate.Text = ds.Tables[0].Rows[0]["confirmationdate"].ToString();

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
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    //------------Bind Payroll Details of Employee-----------------

    protected void bind_payrolldetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr =@"SELECT empcode,esi_no,esi_disp,pan_no,pf_no,uan,pf_no_dept,ward,ptno 
FROM tbl_intranet_employee_payrollDetails  WHERE empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            esino.Text = ds.Tables[0].Rows[0]["esi_no"].ToString();
            esidesp.Text = ds.Tables[0].Rows[0]["esi_disp"].ToString();
            lblpf.Text = ds.Tables[0].Rows[0]["pf_no"].ToString();
            pfno_dept.Text = ds.Tables[0].Rows[0]["pf_no_dept"].ToString();
            uanno.Text = ds.Tables[0].Rows[0]["uan"].ToString();
            ward.Text = ds.Tables[0].Rows[0]["ward"].ToString();
            txt_ptno.Text = ds.Tables[0].Rows[0]["ptno"].ToString();
            panno.Text = ds.Tables[0].Rows[0]["pan_no"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
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
            sqlstr = @"SELECT pre_add1, pre_Add2, pre_city, pre_state, pre_country, pre_zip, pre_phone, per_add1, per_add2, per_city, per_state,
per_country, per_zip, per_phone, empcode,mode,modeoftransport,emergency_contact_no,emergency_name,emergency_relation,emergency_address1,
emergency_address2,emergency_city,emergency_state,emergency_country,emergency_zip FROM tbl_intranet_employee_contactlist 
where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txt_pre_add1.InnerHtml = ds.Tables[0].Rows[0]["pre_add1"].ToString();
            txt_pre_add2.InnerHtml = ds.Tables[0].Rows[0]["pre_Add2"].ToString();
            if ((ds.Tables[0].Rows[0]["pre_city"] == null) || (ds.Tables[0].Rows[0]["pre_city"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_city"].ToString() == "0"))
            {
                txt_pre_city.Text = "";
            }
            else
            {
                txt_pre_city.Text = get_city(Convert.ToInt32(ds.Tables[0].Rows[0]["pre_city"]));
            }
            if ((ds.Tables[0].Rows[0]["pre_state"] == null) || (ds.Tables[0].Rows[0]["pre_state"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_state"].ToString() == "0"))
            {
                txt_pre_state.Text = "";
            }
            else
            {
                txt_pre_state.Text = get_state(Convert.ToInt32(ds.Tables[0].Rows[0]["pre_state"]));
            }
            txt_pre_country.Text = ds.Tables[0].Rows[0]["pre_country"].ToString();
            txt_pre_zip.Text = ds.Tables[0].Rows[0]["pre_zip"].ToString();
            txt_pre_phone.Text = ds.Tables[0].Rows[0]["pre_phone"].ToString();
            txt_per_add1.InnerHtml = ds.Tables[0].Rows[0]["per_add1"].ToString();
            txt_per_add2.InnerHtml = ds.Tables[0].Rows[0]["per_add2"].ToString();
            if ((ds.Tables[0].Rows[0]["per_city"] == null) || (ds.Tables[0].Rows[0]["per_city"].ToString() == "") || (ds.Tables[0].Rows[0]["per_city"].ToString() == "0"))
            {
                txt_per_city.Text = "";
            }
            else
            {
                txt_per_city.Text = get_city(Convert.ToInt32(ds.Tables[0].Rows[0]["per_city"]));
            }
            if ((ds.Tables[0].Rows[0]["per_state"].ToString() == "") || (ds.Tables[0].Rows[0]["per_state"].ToString() == "0"))
            {
                txt_per_state.Text = "";
            }
            else
            {
                txt_per_state.Text = get_state(Convert.ToInt32(ds.Tables[0].Rows[0]["per_state"]));
            }
            txt_per_country.Text = ds.Tables[0].Rows[0]["per_country"].ToString();
            txt_per_zip.Text = ds.Tables[0].Rows[0]["per_zip"].ToString();
            txt_per_phone.Text = ds.Tables[0].Rows[0]["per_phone"].ToString();
            if (ds.Tables[0].Rows[0]["mode"].ToString() == "1")
            {

                lblmodeoftransport.Text = "Company Vehicle";
                txtmodeoftransport.Text = ds.Tables[0].Rows[0]["modeoftransport"].ToString();
            }
            else
            {
                lblmodeoftransport.Text = "Own Vehicle";
            }

            //txt_emergency_contactno.Text = ds.Tables[0].Rows[0]["emergency_contact_no"].ToString();
            //txt_emergency_name.Text = ds.Tables[0].Rows[0]["emergency_name"].ToString();
            //txt_emergency_relation.Text = ds.Tables[0].Rows[0]["emergency_relation"].ToString();
            //txt_emergency_address.Text = ds.Tables[0].Rows[0]["emergency_address1"].ToString();
            //txt_emergency_address2.Text = ds.Tables[0].Rows[0]["emergency_address2"].ToString();
            //if ((ds.Tables[0].Rows[0]["emergency_country"] == null) || (ds.Tables[0].Rows[0]["emergency_country"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_country"].ToString() == "0"))
            //{
            //    lbl_emergency_country.Text = "";
            //}
            //else
            //{
            //    lbl_emergency_country.Text = ds.Tables[0].Rows[0]["emergency_country"].ToString();
            //}
            //if ((ds.Tables[0].Rows[0]["emergency_state"] == null) || (ds.Tables[0].Rows[0]["emergency_state"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_state"].ToString() == "0"))
            //{
            //    lbl_emergency_state.Text = "";
            //}
            //else
            //{
            //    lbl_emergency_state.Text = get_state(Convert.ToInt32(ds.Tables[0].Rows[0]["emergency_state"]));
            //}
            //if ((ds.Tables[0].Rows[0]["emergency_city"] == null) || (ds.Tables[0].Rows[0]["emergency_city"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_city"].ToString() == "0"))
            //{
            //    lbl_emergency_city.Text = "";
            //}
            //else
            //{
            //    lbl_emergency_city.Text = get_city(Convert.ToInt32(ds.Tables[0].Rows[0]["emergency_city"]));
            //}
            //txt_emergency_zipcode.Text = ds.Tables[0].Rows[0]["emergency_zip"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
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
            //sqlstr = "SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,(CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), dob, 101) END) dob, (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), doa, 101) END) doa, dlno, s_fname, s_mname, s_lname, s_dob, s_gender, no_child, mobile_no, email_id,bank_name,ac_number,passport_number,bank_name_reimbursement,ac_number_reimbursement,paymentmode as pay,(case when paymentmode=0 then 'Bank' else case when paymentmode='1' then 'Cheque' else 'Cash' end end) paymentmode FROM tbl_intranet_employee_personalDetails where empcode = '" + empcode + "'";
//            sqlstr = @"SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,
//                (CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), dob, 101) END) dob, 
//                (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), doa, 101) END) doa, 
//                dlno, s_fname, s_mname, s_lname, (CASE WHEN dependent_dob= '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), dependent_dob, 101) END) dependent_dob, (CASE WHEN s_dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), s_dob, 101) END) s_dob, s_gender, no_child, mobile_no, email_id,bankbranch,ifsc, (CASE WHEN passportissuedate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), passportissuedate, 101) END) passportissuedate ,(CASE WHEN passportexpiraydate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11),passportexpiraydate, 101) END) passportexpiraydate ,
//                b.bankname bank_name,ac_number,passport_number,b1.bankname bank_name_reimbursement,ac_number_reimbursement,paymentmode as pay,
//                (case when paymentmode=0 then 'Bank' else case when paymentmode='1' then 'Cheque' else 'Cash' end end) paymentmode 
//                ,driving_lic_no,dribing_lic_iss_date,driving_lic_exp_date,landlineno
//                FROM tbl_intranet_employee_personalDetails p
//
//                left outer join tbl_payroll_bank b on 
//                p.bank_name=b.branchcode
//
//                left outer join tbl_payroll_bank b1 on
//                p.bank_name_reimbursement=b1.branchcode
//
//                where empcode = '" + empcode + "'";


            sqlstr = @"SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,
                (CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(51), dob, 106) END) dob, 
                (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(51), doa, 106) END) doa, 
                dlno, s_fname, s_mname, s_lname, 
                --(CASE WHEN dependent_dob= '01/01/1900' THEN '' ELSE CONVERT(CHAR(50), dependent_dob, 106) END) dependent_dob, 
                (CASE WHEN s_dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(51), s_dob, 106) END) s_dob, 
                s_gender, no_child, mobile_no, email_id,bankbranch,ifsc, 
                (CASE WHEN passportissuedate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(51), passportissuedate, 106) END) passportissuedate ,
                (CASE WHEN passportexpiraydate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(51),passportexpiraydate, 106) END) passportexpiraydate ,
                b.bankname bank_name,ac_number,passport_number,b1.bankname bank_name_reimbursement,ac_number_reimbursement,paymentmode as pay,
                (case when paymentmode=0 then 'Bank' else case when paymentmode='1' then 'Cheque' else 'Cash' end end) paymentmode 
                ,driving_lic_no,dribing_lic_iss_date,driving_lic_exp_date,landlineno
                FROM tbl_intranet_employee_personalDetails p

                left outer join tbl_payroll_bank b on 
                p.bank_name=b.branchcode

                left outer join tbl_payroll_bank b1 on
                p.bank_name_reimbursement=b1.branchcode

                where empcode = '" + empcode + "'";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
            {
                paymentmode.Visible = false;
                return;
            }
            //----------------changes by ramu nunna on 6-14-2014 purpose of dispaly the t-shirt and shirt details
            if (ds.Tables[0].Rows[0]["f_mname"].ToString() != "0")
                lbl_Tshirt.Text = ds.Tables[0].Rows[0]["f_mname"].ToString();
            else lbl_Tshirt.Text = "";
            if (ds.Tables[0].Rows[0]["f_lname"].ToString() != "0")
                lbl_ShirtSize.Text = ds.Tables[0].Rows[0]["f_lname"].ToString();
            else lbl_ShirtSize.Text = "";
            txt_f_f_name.Text = ds.Tables[0].Rows[0]["f_fname"].ToString();// +' ' + ds.Tables[0].Rows[0]["f_mname"].ToString() + ' ' + ds.Tables[0].Rows[0]["f_lname"].ToString();
            //-------------------------end-----------------------
            txt_m_fname.Text = ds.Tables[0].Rows[0]["m_fname"].ToString() + ' ' + ds.Tables[0].Rows[0]["m_mname"].ToString() + ' ' + ds.Tables[0].Rows[0]["m_lname"].ToString();
            if (ds.Tables[0].Rows[0]["bloodgrp"].ToString() == "0" || ds.Tables[0].Rows[0]["bloodgrp"].ToString() == "")
                txtbloodgrp.Text = "";
            else
                txtbloodgrp.Text = ds.Tables[0].Rows[0]["bloodgrp"].ToString();
            if (ds.Tables[0].Rows[0]["dob"].ToString() != "")
            {
                txt_DOB.Text = ds.Tables[0].Rows[0]["dob"].ToString();
            }
            else
                txt_DOB.Text = " ";
            ddlpersonalstatus.Text = (ds.Tables[0].Rows[0]["maritalstatus"].ToString() == "0") ? "" : ds.Tables[0].Rows[0]["maritalstatus"].ToString();

            txtrelg.Text = ds.Tables[0].Rows[0]["religion"].ToString();
            if (ds.Tables[0].Rows[0]["doa"].ToString() != "")
            {
                txt_doa.Text = ds.Tables[0].Rows[0]["doa"].ToString();
            }
            else txt_doa.Text = "";
            txt_dl_no.Text = ds.Tables[0].Rows[0]["dlno"].ToString();
            txt_sp_fname.Text = ds.Tables[0].Rows[0]["s_fname"].ToString() + ' ' + ds.Tables[0].Rows[0]["s_mname"].ToString() + ' ' + ds.Tables[0].Rows[0]["s_lname"].ToString();
            if (ds.Tables[0].Rows[0]["s_dob"].ToString() != "")
            {
                txt_sp_dob.Text = ds.Tables[0].Rows[0]["s_dob"].ToString();
            }
            else
                txt_sp_dob.Text = " ";

            txt_sp_gender.Text = (ds.Tables[0].Rows[0]["s_gender"].ToString() == "0") ? " " : ds.Tables[0].Rows[0]["s_gender"].ToString();
            txtmobileno.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            land.Text = ds.Tables[0].Rows[0]["landlineno"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
            txt_bank_name.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
            txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
            txt_passportno.Text = ds.Tables[0].Rows[0]["passport_number"].ToString();
            if (ddlpersonalstatus.Text.ToString() == "MARRIED")
            {
                tbl1.Visible = true;
            }
            if ((ddlpersonalstatus.Text.ToString() == "Unmarried") || (ddlpersonalstatus.Text.ToString() == ""))
            {
                tbl1.Visible = false;
            }
            lblpaymentmode.Text = ds.Tables[0].Rows[0]["paymentmode"].ToString();
            //txt_bank_name_reimbursement.Text = ds.Tables[0].Rows[0]["bank_name_reimbursement"].ToString();
            //txt_bank_ac_reimbursement.Text = ds.Tables[0].Rows[0]["ac_number_reimbursement"].ToString();

            //if (Convert.ToInt32(ds.Tables[0].Rows[0]["pay"]) == 0)
            //{
            //    paymentmode.Visible = true;
            //}
            //else
            //{
            //    paymentmode.Visible = false;
            //}


            txt_bankbrachname.Text = ds.Tables[0].Rows[0]["bankbranch"].ToString();
            //lbl_dep_dob.Text = ds.Tables[0].Rows[0]["dependent_dob"].ToString();
            txt_ifsc.Text = ds.Tables[0].Rows[0]["ifsc"].ToString();
            if (ds.Tables[0].Rows[0]["passportissuedate"].ToString() == "")
            {
                txt_passportissueddate.Text = "";
            }
            else
            {
                txt_passportissueddate.Text = ds.Tables[0].Rows[0]["passportissuedate"].ToString();
            }
            if (ds.Tables[0].Rows[0]["passportexpiraydate"].ToString() == "")
            {
                txt_passportexpdate.Text = "";
            }
            else
            {
                txt_passportexpdate.Text = ds.Tables[0].Rows[0]["passportexpiraydate"].ToString();
            }
            txt_drli_no.Text = ds.Tables[0].Rows[0]["driving_lic_no"].ToString();
            if (ds.Tables[0].Rows[0]["dribing_lic_iss_date"].ToString() == "")
            {
                txt_dr_iss_date.Text = "";
            }
            else
            {
                txt_dr_iss_date.Text = ds.Tables[0].Rows[0]["dribing_lic_iss_date"].ToString();
            }
            if (ds.Tables[0].Rows[0]["driving_lic_exp_date"].ToString() == "")
            {
                txt_dr_exp_date.Text = "";
            }
            else
            {
                txt_dr_exp_date.Text = ds.Tables[0].Rows[0]["driving_lic_exp_date"].ToString();
            }

            //lbl_ShoesSize.Text = ds.Tables[0].Rows[0]["shoesize"].ToString();
            //lblBasicSalary.Text = ds.Tables[0].Rows[0]["basicsalary"].ToString();

            //if (ds.Tables[0].Rows[0]["salarytype"].ToString() == "0")
            //{
            //    lblSalaryType.Text = "";
            //}
            //else if (ds.Tables[0].Rows[0]["salarytype"].ToString() == "1")
            //{
            //    lblSalaryType.Text = "Fixed";
            //}
            //else if (ds.Tables[0].Rows[0]["salarytype"].ToString() == "2")
            //{
            //    lblSalaryType.Text = "Basic";
            //}

           // lblBankRegion.Text = ds.Tables[0].Rows[0]["regionname"].ToString();
            //txt_bankbrachname.Text = ds.Tables[0].Rows[0]["branchname"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void bind_guarantor(string empcode)
    {
        try
        {
           
            connection = activity.OpenConnection();
            string sqlstr = "select * from tbl_intranet_employee_guarantor where empcode ='" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;
            grid_gurn.DataSource = ds;
            grid_gurn.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_child(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select id,child_name,gender ,(CASE WHEN childdob='01/01/1900' THEN '' ELSE CONVERT(CHAR(50), childdob, 106) END)child_dob 
from tbl_intranet_employee_childrendetail where empcode ='" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;
            grid_child.DataSource = ds;
            grid_child.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_Education_Qualification(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year,specialization  
            FROM tbl_employee_edcationalqualifications  where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            grid_edu_education.DataSource = ds;
            grid_edu_education.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void bind_Professional_Qualification(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year,specialization  
            FROM tbl_employee_professionalqualifications where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count < 1)
                return;
            grid_Pro_education.DataSource = ds;
            grid_Pro_education.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void bind_Exp_detail(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); 
           // sqlstr = "SELECT [id],empcode,[companyname]as comp_name,[location]as location ,[yearfrom] as from_year,[yearto]as to_year,bussiness_type,departmenet,postion_starting,postion_end,R_leave,salary_start,salary_end FROM tbl_employee_experiencedetails where empcode = '" + empcode + "'";
            sqlstr = @"SELECT [id],
empcode,
[companyname]as comp_name,
[location]as location ,
[yearfrom] as from_year,[yearto]as to_year,
designation,
totalexperience
--bussiness_type,
--departmenet,
--postion_starting,
--postion_end,
--R_leave,
--salary_start,
--salary_end
 FROM tbl_employee_experiencedetails where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            grid_exp.DataSource = ds;
            grid_exp.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_Training_detail(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = @"SELECT trainingname,personname,
(CASE WHEN fromdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(51), fromdate, 106) END)fromdate ,(CASE WHEN todate='01/01/1900' THEN '' ELSE CONVERT(CHAR(51), todate, 106) END) todate,
remarks  FROM tbl_intranet_employee_trainingdetail where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            GridTraning.DataSource = ds;
            GridTraning.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
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
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
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
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
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
            sqlstr = @"select empcode,isnull(emp_fname,'')+' '+isnull(emp_m_name,'')+' '+isnull(emp_l_name,'') as emp_fname 
            from tbl_intranet_employee_jobDetails where empcode='" + Empcode + "'";
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
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return Name;

    }

    //void BindVisa(string empcode)
    //{
    //    connection = activity.OpenConnection();

    //    sqlstr = "select id as Id,visanumber VisaNumber,dbo.FormatDate(visaissuedate) VisaIssueDate,dbo.FormatDate(visaexpirydate) VisaExpiryDate from tbl_employee_visainfo where empcode = '" + empcode + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;

    //    if (Session["Visa"] == null)
    //    {
    //        Session["Visa"] = ds.Tables[0];
    //        GridVisa.DataSource = ds.Tables[0];
    //        GridVisa.DataBind();
    //    }

    //}

    void BindInsurance(string empcode)
    {
        connection = activity.OpenConnection();

        sqlstr = @"select id as Id,insurancenumber InsuranceNumber,dbo.FormatDate(insuranceissuedate) InsuranceIssueDate, 
dbo.FormatDate(insuranceexpirydate) InsuranceExpiryDate from tbl_employee_insuranceinfo where empcode = '" + empcode + "'";
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;

        if (Session["Insurance"] == null)
        {
            Session["Insurance"] = ds.Tables[0];
            GridInsurance.DataSource = ds.Tables[0];
            GridInsurance.DataBind();
        }
    }

    //void BindResidentCard(string empcode)
    //{
    //    connection = activity.OpenConnection();

    //    sqlstr = "select id as Id,residentcardnumber ResidentCardNumber,dbo.FormatDate(residentcardissuedate) ResidentCardIssueDate,dbo.FormatDate(residentcardexpirydate) ResidentCardExpiryDate from tbl_employee_residentcardinfo  where empcode = '" + empcode + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;

    //    if (Session["ResidentCard"] == null)
    //    {
    //        Session["ResidentCard"] = ds.Tables[0];
    //        GridResidentCard.DataSource = ds.Tables[0];
    //        GridResidentCard.DataBind();
    //    }
    //}

   

    //protected void btnprint_Click(object sender, EventArgs e)
    //{
    //    Session["ctrl"] = UpdatePanel6;
    //    ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=1000px,scrollbars=1');</script>");
    //}
    //protected void btnprint_Click1(object sender, EventArgs e)
    ////{
    //    Session["ctrl"] = panlprint;
    //    ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=1000px,scrollbars=1');</script>");
    //}

    //private void Getdefaultlable()
    //{
    //    //  string sqlstr = "select id, labelname from staticlabel";
    //    // ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    string sqlstr = "select labelname from staticlabel";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    lbl_Default1.Text = ds.Tables[0].Rows[0]["labelname"].ToString();
    //    lbl_Default2.Text = ds.Tables[0].Rows[1]["labelname"].ToString();
    //    lbl_Default3.Text = ds.Tables[0].Rows[2]["labelname"].ToString();
    //    lbl_Default4.Text = ds.Tables[0].Rows[3]["labelname"].ToString();
    //    lbl_Default5.Text = ds.Tables[0].Rows[4]["labelname"].ToString();
    //    lbl_Default6.Text = ds.Tables[0].Rows[5]["labelname"].ToString();
    //    lbl_Default7.Text = ds.Tables[0].Rows[6]["labelname"].ToString();
    //    lbl_Default8.Text = ds.Tables[0].Rows[7]["labelname"].ToString();
    //    lbl_Default9.Text = ds.Tables[0].Rows[8]["labelname"].ToString();
    //    lbl_Default10.Text = ds.Tables[0].Rows[9]["labelname"].ToString();
    //    lbl_Default11.Text = ds.Tables[0].Rows[10]["labelname"].ToString();
    //    lbl_Default12.Text = ds.Tables[0].Rows[11]["labelname"].ToString();
    //    lbl_Default13.Text = ds.Tables[0].Rows[12]["labelname"].ToString();
    //    lbl_Default14.Text = ds.Tables[0].Rows[13]["labelname"].ToString();

    //}

    protected void bind_emp_doc(string emp_code)
    {
       
        try
        {
            sqlstr = @"SELECT empcode,default1,default2,default3,default4,default5,default6,default7,default8,default9,default10,default11,
default12,default13,default14,default15 FROM tbl_intranet_employee_docupload where empcode = '" + emp_code + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["default1"] != "")
                {
                    lbldft1.Text = (ds.Tables[0].Rows[0]["default1"].ToString());
                }
                else
                {
                    lbldft1.Text = "No exisitng file found"; 
                }
                
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default1"].ToString() +
                  //  "' target='_blank'>" + ds.Tables[0].Rows[0]["default1"].ToString() + "</a>" : "No exisitng file found";

                if (ds.Tables[0].Rows[0]["default2"]!="")
                {
                lbldft2.Text = (ds.Tables[0].Rows[0]["default2"].ToString());
                }
                else
                {
                    lbldft2.Text = "No exisitng file found"; 
                }
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default2"].ToString() +
                  //  "' target='_blank'>" + ds.Tables[0].Rows[0]["default2"].ToString() + "</a>" : "No exisitng file found";

                if (ds.Tables[0].Rows[0]["default3"]!="")
                {
                lbldft3.Text = (ds.Tables[0].Rows[0]["default3"].ToString());
                }
                else
                {
                    lbldft3.Text = "No exisitng file found"; 
                }
                
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default3"].ToString() +
                 //  "' target='_blank'>" + ds.Tables[0].Rows[0]["default3"].ToString() + "</a>" : "No exisitng file found";

                if (ds.Tables[0].Rows[0]["default4"]!="")
                {
                lbldft4.Text = (ds.Tables[0].Rows[0]["default4"].ToString());
                }
                else
                {
                    lbldft4.Text = "No exisitng file found"; 
                }
                
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default4"].ToString() +
                 //  "' target='_blank'>" + ds.Tables[0].Rows[0]["default4"].ToString() + "</a>" : "No exisitng file found";


                if (ds.Tables[0].Rows[0]["default5"]!="")
                {
                lbldft5.Text = (ds.Tables[0].Rows[0]["default5"].ToString());
                }
                else
                {
                    lbldft5.Text = "No exisitng file found";
                }
                
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default5"].ToString() +
                 //   "' target='_blank'>" + ds.Tables[0].Rows[0]["default5"].ToString() + "</a>" : "No exisitng file found";

                if (ds.Tables[0].Rows[0]["default6"]!="")
                {
                 lbldft6.Text = (ds.Tables[0].Rows[0]["default6"].ToString());
                }
                else
                {
                    lbldft6.Text = "No exisitng file found";
                }
                
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default6"].ToString() +
                 //"' target='_blank'>" + ds.Tables[0].Rows[0]["default6"].ToString() + "</a>" : "No exisitng file found";

                if (ds.Tables[0].Rows[0]["default7"]!="")
                {
                lbldft7.Text = (ds.Tables[0].Rows[0]["default7"].ToString());
                }
                else
                {
                    lbldft7.Text = "No exisitng file found";
                }
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default7"].ToString() +
                //"' target='_blank>" + ds.Tables[0].Rows[0]["default7"].ToString() + "</a>" : "No exisitng file found";
                if (ds.Tables[0].Rows[0]["default8"]!="")
                {
                lbldft8.Text = (ds.Tables[0].Rows[0]["default8"].ToString());
                }
                else
                {
                    lbldft8.Text = "No exisitng file found";
                }
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default8"].ToString() +
                 //"' target='_blank'>" + ds.Tables[0].Rows[0]["default8"].ToString() + "</a>" : "No exisitng file found";

                if(ds.Tables[0].Rows[0]["default9"] != "")
                {

                lbldft9.Text = (ds.Tables[0].Rows[0]["default9"].ToString() );
                }
                else
                {
                    lbldft9.Text = "No exisitng file found";
                }
                
                
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default9"].ToString() +
                 //"' target='_blank'>" + ds.Tables[0].Rows[0]["default9"].ToString() + "</a>" : "No exisitng file found";


                if (ds.Tables[0].Rows[0]["default10"] != "")
                {
                lbldft10.Text = (ds.Tables[0].Rows[0]["default10"].ToString());
                }
                else
                {
                    lbldft10.Text = "No exisitng file found";
                }


                    //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default10"].ToString() +
                 //"' target='_blank'>" + ds.Tables[0].Rows[0]["default10"].ToString() + "</a>" : "No exisitng file found";
                if (ds.Tables[0].Rows[0]["default11"]!="")
                {
                lbldft11.Text = (ds.Tables[0].Rows[0]["default11"].ToString());
                }
                else
                {
                    lbldft11.Text = "No exisitng file found";
                }
                
                // != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default11"].ToString() +
               //"' target='_blank'>" + ds.Tables[0].Rows[0]["default11"].ToString() + "</a>" : "No exisitng file found";
                if (ds.Tables[0].Rows[0]["default12"]!="")
                {

                lbldft12.Text = (ds.Tables[0].Rows[0]["default12"].ToString());
                
                }
                else
                {
                    lbldft12.Text = "No exisitng file found";
                }
                
                
                // != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default12"].ToString() +
              // "' target='_blank'>" + ds.Tables[0].Rows[0]["default12"].ToString() + "</a>" : "No exisitng file found";


                if (ds.Tables[0].Rows[0]["default13"]!="")
                {
                lbldft13.Text = (ds.Tables[0].Rows[0]["default13"].ToString()); 
                }
                else
                {
                    lbldft13.Text = "No exisitng file found";
                }
                
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default13"].ToString() +
            //  "' target='_blank'>" + ds.Tables[0].Rows[0]["default13"].ToString() + "</a>" : "No exisitng file found";
                if (ds.Tables[0].Rows[0]["default14"] != "")
                {
                    lbldft14.Text = (ds.Tables[0].Rows[0]["default14"].ToString());
                }
                else
                {
                    lbldft14.Text = "No exisitng file found";
                }
                //!= "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default14"].ToString() +
              //"' target='_blank'>" + ds.Tables[0].Rows[0]["default14"].ToString() + "</a>" : "No exisitng file found";
                if (ds.Tables[0].Rows[0]["default15"] != "")
                {
                    Label6.Text = (ds.Tables[0].Rows[0]["default15"].ToString());
                }
                else
                {
                    Label6.Text = "No exisitng file found";
                }
                

            }



        }
     

            //lbldft2.Text = (ds.Tables[0].Rows[0]["default2"].ToString() != "") ? "<a target='_blank' href='Upload/Doc/" + ds.Tables[0].Rows[0]["default2"].ToString() +
            //     "'>" + ds.Tables[0].Rows[0]["default2"].ToString() + "</a>" : "No exisitng file found";
            //lbldft1.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default1"].ToString();
            //lbldft2.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default2"].ToString();
            //lbldft3.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default3"].ToString();
            //lbldft4.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default4"].ToString();
            //lbldft5.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default5"].ToString();
            //lbldft6.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default6"].ToString();
            //lbldft7.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default7"].ToString();
            //lbldft8.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default8"].ToString();
            //lbldft9.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default9"].ToString();
            //lbldft10.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default10"].ToString();
            //lbldft11.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default11"].ToString();
            //lbldft12.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default12"].ToString();
            //lbldft13.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default13"].ToString();
            //lbldft14.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default14"].ToString();
            //    lbldft1.Text = "no file";
            //    dftlink1.HRef = "#";
            //    lbldft2.Text = "no file";
            //    dftlink2.HRef = "#";
            //    lbldft3.Text = "no file";
            //    dftlink3.HRef = "#";
            //    lbldft4.Text = "no file";
            //    dftlink4.HRef = "#";
            //    lbldft5.Text = "no file";
            //    dftlink5.HRef = "#";
            //    lbldft6.Text = "no file";
            //    dftlink6.HRef = "#";
            //    lbldft7.Text = "no file";
            //    dftlink7.HRef = "#";
            //    lbldft8.Text = "no file";
            //    dftlink8.HRef = "#";
            //    lbldft9.Text = "no file";
            //    dftlink9.HRef = "#";
            //    lbldft10.Text = "no file";
            //    dftlink10.HRef = "#";
            //    lbldft11.Text = "no file";
            //    dftlink11.HRef = "#";
            //    lbldft12.Text = "no file";
            //    dftlink12.HRef = "#";
            //    lbldft13.Text = "no file";
            //    dftlink13.HRef = "#";
            //    lbldft14.Text = "no file";
            //    dftlink14.HRef = "#";
            //    return;
            //}
            //if (ds.Tables[0].Rows[0]["default1"].ToString() == "")
            //{
            //    lbldft1.Text = "no file";
            //    dftlink1.HRef = "#";
            //}
            //else
            //{
            //    lbldft1.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default1"].ToString();
            //    dftlink1.Target = "_blank";
            //    //lbldft1.Text = "view";

            //}

            //if (ds.Tables[0].Rows[0]["default2"].ToString() == "")
            //{
            //    lbldft2.Text = "no file";
            //    dftlink2.HRef = "#";
            //}
            //else
            //{
            //    lbldft2.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default2"].ToString();
            //    dftlink2.Target = "_blank";
            //    //lbldft2.Text = "view";
            //}

            //if (ds.Tables[0].Rows[0]["default3"].ToString() == "")
            //{
            //    lbldft3.Text = "no file";
            //    dftlink3.HRef = "#";
            //}
            //else
            //{
            //    lbldft3.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default3"].ToString();
            //    dftlink3.Target = "_blank";
            //    //lbldft3.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default4"].ToString() == "")
            //{
            //    lbldft4.Text = "no file";
            //    dftlink4.HRef = "#";
            //}
            //else
            //{
            //    lbldft4.Text = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default4"].ToString();
            //    dftlink4.Target = "_blank";
            //    //lbldft4.Text = "view";
            //}

            //if (ds.Tables[0].Rows[0]["default5"].ToString() == "")
            //{
            //    lbldft5.Text = "no file";
            //    dftlink5.HRef = "#";
            //}
            //else
            //{
            //    dftlink5.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default5"].ToString();
            //    dftlink5.Target = "_blank";
            //    //lbldft5.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default6"].ToString() == "")
            //{
            //    lbldft6.Text = "no file";
            //    dftlink6.HRef = "#";
            //}
            //else
            //{
            //    dftlink6.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default6"].ToString();
            //    dftlink6.Target = "_blank";
            //    //lbldft6.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default7"].ToString() == "")
            //{
            //    lbldft7.Text = "no file";
            //    dftlink7.HRef = "#";
            //}
            //else
            //{
            //    dftlink7.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default7"].ToString();
            //    dftlink7.Target = "_blank";
            //    //lbldft7.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default8"].ToString() == "")
            //{
            //    lbldft8.Text = "no file";
            //    dftlink8.HRef = "#";

            //}
            //else
            //{
            //    dftlink8.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default8"].ToString();
            //    dftlink8.Target = "_blank";
            //    //lbldft8.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default9"].ToString() == "")
            //{
            //    lbldft9.Text = "no file";
            //    dftlink9.HRef = "#";
            //}
            //else
            //{
            //    dftlink9.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default9"].ToString();
            //    dftlink9.Target = "_blank";
            //    lbldft9.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default10"].ToString() == "")
            //{
            //    lbldft10.Text = "no file";
            //    dftlink10.HRef = "#";
            //}
            //else
            //{
            //    dftlink10.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default10"].ToString();
            //    dftlink10.Target = "_blank";
            //    lbldft10.Text = "view";
            //}

            //if (ds.Tables[0].Rows[0]["default11"].ToString() == "")
            //{
            //    lbldft11.Text = "no file";
            //    dftlink11.HRef = "#";
            //}
            //else
            //{
            //    dftlink11.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default11"].ToString();
            //    dftlink11.Target = "_blank";
            //    lbldft11.Text = "view";
            //}

            //if (ds.Tables[0].Rows[0]["default12"].ToString() == "")
            //{
            //    lbldft12.Text = "no file";
            //    dftlink12.HRef = "#";
            //}
            //else
            //{
            //    dftlink12.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default12"].ToString();
            //    dftlink12.Target = "_blank";
            //    lbldft12.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default13"].ToString() == "")
            //{
            //    lbldft13.Text = "no file";
            //    dftlink13.HRef = "#";
            //}
            //else
            //{
            //    dftlink13.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default13"].ToString();
            //    dftlink13.Target = "_blank";
            //    lbldft13.Text = "view";
            //}
            //if (ds.Tables[0].Rows[0]["default14"].ToString() == "")
            //{
            //    lbldft14.Text = "no file";
            //    dftlink14.HRef = "#";
            //}
            //else
            //{
            //    dftlink14.HRef = "../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default14"].ToString();
            //    dftlink14.Target = "_blank";
            //    lbldft14.Text = "view";
            //}
        
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["ctrl"] = panlprint;
        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=1000px,scrollbars=1');</script>");

    }

}

