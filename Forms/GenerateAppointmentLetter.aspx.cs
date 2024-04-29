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
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;
using DataAccessLayer;
using System.Net.Mail;

public partial class Forms_GenerateAppointmentLetter : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_appoint_ltr_numbr.ReadOnly = true;
        txt_appoint_ltr_numbr.BackColor = System.Drawing.SystemColors.Window;
        string toemail = Request.QueryString["toemail"];
        string name = Request.QueryString["Name"];
        if (!IsPostBack)
        {
            tbissueddate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            binddepartment();
            bindBranch_Location();
            binddesignation();
            BindAppointmentLetterNumber();
        }
        string candidate_name = Request.QueryString["CandidateName"];
        string appointment_Letter_number = Request.QueryString["Appointment_letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string Emp_address = Request.QueryString["Employee_Address"];
        string date_of_join = Request.QueryString["Date_Of_Join"];
        string ctc = Request.QueryString["CTC"];
        string issued_date = Request.QueryString["Issued_Date"];
        string terminated_service_days = Request.QueryString["Terminated_Service_Days"];
        string sum_not_exceeding_days = Request.QueryString["Sum_Not_Exceeding_Days"];
        string job_location = Request.QueryString["Job_Location"];
        string department = Request.QueryString["Department"];
        string designation = Request.QueryString["Designation"];
        string issued_by = Request.QueryString["Issued_By"];
        string email = Request.QueryString["Email_ID"];
    }

    protected void binddepartment()
    {
        string sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpdepartment.DataTextField = "department_name";
        drpdepartment.DataValueField = "departmentid";
        drpdepartment.DataSource = ds;
        drpdepartment.DataBind();
        drpdepartment.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindBranch_Location()
    {
        string sqlstr = "SELECT Branch_Id,branch_name FROM tbl_intranet_branch_detail";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpbranch.DataTextField = "branch_name";
        drpbranch.DataValueField = "Branch_Id";
        drpbranch.DataSource = ds;
        drpbranch.DataBind();
        drpbranch.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void binddesignation()
    {
        string sqlstr = "select id,designationname FROM tbl_intranet_designation";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpdesignation.DataTextField = "designationname";
        drpdesignation.DataValueField = "id";
        drpdesignation.DataSource = ds;
        drpdesignation.DataBind();
        drpdesignation.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindcandidate(string candidate)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"select distinct top 1 cr.id,rrf.rrf_code,jd.empcode,cr.candidate_name,cr.candidate_address,payroll.ward as CTC,bd.branch_name,
d.designationname,cr.emailid,rrf.locationid,rrf.designationid,dept.department_name,rrf.departmentid,jd.emp_doj
from tbl_recruitment_candidate_registration cr 
inner join tbl_recruitment_requisition_form rrf on rrf.id=cr.rrf_id
inner join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid
inner join tbl_intranet_designation d on rrf.designationid=d.id
inner join tbl_recruitment_expctc_master exp_ctc on rrf.incentive=exp_ctc.id
inner join tbl_intranet_branch_detail bd on rrf.locationid=bd.branch_id
inner join tbl_internate_departmentdetails dept on rrf.departmentid=dept.departmentid
left join tbl_intranet_employee_jobDetails jd on cr.candidate_name=jd.emp_fname
left join tbl_intranet_employee_payrollDetails payroll on jd.empcode=payroll.empcode
where (ci.round_1_status not in('R') or ci.round_1_status is  Null) and 
(ci.round_2_status not in ('R') or ci.round_2_status is  Null) and cr.id = '" + candidate + "' order by empcode desc";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            tb_emp_id.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            TextBox1_name.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
            tbemployeeaddress.Text = ds.Tables[0].Rows[0]["candidate_address"].ToString();
            if (ds.Tables[0].Rows[0]["emp_doj"].ToString() != "")
            {
                txt_join_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
            }
            txt_ctc.Text = ds.Tables[0].Rows[0]["CTC"].ToString();
            drpbranch.SelectedValue = ds.Tables[0].Rows[0]["locationid"].ToString();
            drpdepartment.SelectedValue = ds.Tables[0].Rows[0]["departmentid"].ToString();
            drpdesignation.SelectedValue = ds.Tables[0].Rows[0]["designationid"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
            
        }
        catch (Exception ex)
        {
            Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Records Not Fetching. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void btngetempdetails_Click(object sender, EventArgs e)
    {
        string candidate_code = txt_candidate_id.Text.Trim();
        bindcandidate(candidate_code);
    }

    protected void Reset()
    {
        txt_candidate_id.Text = "";
        TextBox1_name.Text = "";
        txt_appoint_ltr_numbr.Text = "";
        txt_hr_1.Text = "";
        txt_hr_2.Text = "";
        tbemployeeaddress.Text = "";
        txt_join_date.Text = "";
        txt_ctc.Text = "";
        tbissueddate.Text = "";
        drpbranch.SelectedValue = "0";
        drpdepartment.SelectedValue = "0";
        drpdesignation.SelectedValue = "0";
        tbIssuedby.Text = "";
        txt_email.Text = "";
        ddl_trmnted_service_dys.SelectedValue = "0";
        txt_sum_nt_excding_days.Text = "";

    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void btngenerateletter_Click(object sender, EventArgs e)
    {
        if (tbissueddate.Text != "" && txt_join_date.Text != "")
        {
            //if (Convert.ToDateTime(tbissueddate.Text) >= Convert.ToDateTime(txt_join_date.Text))
            //{
            //    txt_join_date.Focus();
            //    Output.Show("Enter Valid Date");      
            //}
            //else
            //{

                var parm = new SqlParameter[17];
                SqlTransaction transaction = null;
                var activity = new DataActivity();
                int flag = 0;
                try
                {
                    Output.AssignParameter(parm, 0, "@candidate_id", "String", 20, txt_candidate_id.Text);
                    Output.AssignParameter(parm, 1, "@candidate_name", "String", 60, TextBox1_name.Text);
                    Output.AssignParameter(parm, 2, "@appointment_letter_number", "String", 30, txt_appoint_ltr_numbr.Text);
                    Output.AssignParameter(parm, 3, "@hr_1", "String", 10, txt_hr_1.Text);
                    Output.AssignParameter(parm, 4, "@hr_2", "String", 10, txt_hr_2.Text);
                    Output.AssignParameter(parm, 5, "@employee_address", "String", 1000, tbemployeeaddress.Text);
                    Output.AssignParameter(parm, 6, "@date_of_join", "DateTime", 0, txt_join_date.Text);
                    Output.AssignParameter(parm, 7, "@ctc", "String", 30, txt_ctc.Text);
                    Output.AssignParameter(parm, 8, "@issued_date", "DateTime", 0, tbissueddate.Text);
                    Output.AssignParameter(parm, 9, "@terminated_service_days", "String", 20, ddl_trmnted_service_dys.SelectedItem.Text);
                    Output.AssignParameter(parm, 10, "@sum_not_exceeding_days", "String", 20, txt_sum_nt_excding_days.Text);
                    Output.AssignParameter(parm, 11, "@job_location", "String", 40, drpbranch.SelectedItem.Text);
                    Output.AssignParameter(parm, 12, "@department", "String", 40, drpdepartment.SelectedItem.Text);
                    Output.AssignParameter(parm, 13, "@designation", "String", 40, drpdesignation.SelectedItem.Text);
                    Output.AssignParameter(parm, 14, "@issued_by", "String", 40, tbIssuedby.Text);
                    Output.AssignParameter(parm, 15, "@email_address", "String", 40, txt_email.Text);
                    Output.AssignParameter(parm, 16, "@empcode", "String", 60, tb_emp_id.Text);

                    SqlConnection connection = activity.OpenConnection();
                    transaction = connection.BeginTransaction();
                    flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_insert_into_tbl_Appointment_letter_details", parm);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                if (flag > 0)
                {
                    Output.Show("Employee Details Submitted Successfully");
                }
                else
                {
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }

                BindAppointmentLetterNumber();
                Session["Address"] = tbemployeeaddress.Text.Trim().ToString();
                Session["designation"] = drpdesignation.SelectedItem.Text;
                Session["employeecode"] = tb_emp_id.Text;
                //ViewState["address"] = tbemployeeaddress.Text;
                Response.Redirect("AppointmentLetterDetails.aspx?CandidateName=" + TextBox1_name.Text + "&Appointment_letter_Number=" + txt_appoint_ltr_numbr.Text + "&Hr_1=" + txt_hr_1.Text + "&Hr_2=" + txt_hr_2.Text + "&Date_Of_Join=" + txt_join_date.Text + "&CTC=" + txt_ctc.Text + "&Issued_Date=" + tbissueddate.Text + "&Terminated_Service_Days=" + ddl_trmnted_service_dys.SelectedItem.Text + "&Sum_Not_Exceeding_Days=" + txt_sum_nt_excding_days.Text + "&Job_Location=" + drpbranch.SelectedItem.Text + "&Department=" + drpdepartment.SelectedItem.Text + "&Designation=" + drpdesignation.SelectedItem.Text + "&Issued_By=" + tbIssuedby.Text + "&Email_ID=" + txt_email.Text + "");
            //}
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        Response.Redirect("SendAppointmentLetterMail.aspx?toemail=" + txt_email.Text + "&Name=" + TextBox1_name.Text + "");
    }

    private void BindAppointmentLetterNumber()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select COUNT(@@ROWCOUNT) AS totalRows from tbl_Appointment_letter_details";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            int refnNo = Convert.ToInt32(ds.Tables[0].Rows[0]["totalRows"]) + 1;
            txt_appoint_ltr_numbr.Text = refnNo.ToString();
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

    protected void ddl_trmnted_service_dys_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_trmnted_service_dys.SelectedValue == "0")
        {
            txt_sum_nt_excding_days.Text = "";
        }
        else
        {
            txt_sum_nt_excding_days.Text = ddl_trmnted_service_dys.SelectedItem.Text;
        }
    }

}