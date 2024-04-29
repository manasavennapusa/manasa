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

public partial class recruitment_ConfirmationLetterDetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        txt_confrm_ltr_numbr.ReadOnly = true;
        txt_confrm_ltr_numbr.BackColor = System.Drawing.SystemColors.Window;
        string toemail = Request.QueryString["toemail"];
        string name = Request.QueryString["Name"];
        if (!IsPostBack)
        {
            tbissueddate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            binddepartment();
            binddesignation();
            BindConfirmationLetterNumber();
        }
        string candidatename = Request.QueryString["CandidateName"];
        string confirmation_number = Request.QueryString["ConfirmationNumber"];
        string hr_1= Request.QueryString["Hr1"];
        string hr_2 = Request.QueryString["Hr2"];
        string address = Request.QueryString["Address"];
        string effective_date = Request.QueryString["EffectiveDate"];
        string issued_date = Request.QueryString["IssuedDate"];
        string department = Request.QueryString["Department"];
        string designation = Request.QueryString["Designation"];
        string employee_id = Request.QueryString["EmployeeID"];
        string issued_by = Request.QueryString["IssuedBy"];
        string email = Request.QueryString["EmailID"];
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

    protected void btngenerateletter_Click(object sender, EventArgs e)
    {
        var parm = new SqlParameter[12];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@employee_id", "String", 20, tbemployee_id.Text);
            Output.AssignParameter(parm, 1, "@employee_name", "String", 60, TextBox1_name.Text);
            Output.AssignParameter(parm, 2, "@employee_address", "String", 500, tbemployeeaddress.Text);
            Output.AssignParameter(parm, 3, "@effective_date", "DateTime", 0, tbeffectivedate.Text);
            Output.AssignParameter(parm, 4, "@issued_date", "DateTime", 0, tbissueddate.Text);
            Output.AssignParameter(parm, 5, "@issued_by", "String", 50, tbIssuedby.Text);
            Output.AssignParameter(parm, 6, "@email", "String", 50, txt_email.Text);
            Output.AssignParameter(parm, 7, "@confirmation_letter_number", "String", 30, txt_confrm_ltr_numbr.Text);
            Output.AssignParameter(parm, 8, "@Hr_1", "String", 10, txt_hr_1.Text);
            Output.AssignParameter(parm, 9, "@Hr_2", "String", 10, txt_hr_2.Text);
            Output.AssignParameter(parm, 10, "@Department", "String", 30, drpdepartment.SelectedItem.Text);
            Output.AssignParameter(parm, 11, "@Designation", "String", 30, drpdesignation.SelectedItem.Text);

            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_insert_into_tbl_confirmation_letter_details", parm);
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
        BindConfirmationLetterNumber();
        //Response.Redirect("ConfirmationForm.aspx?candidatename=" + tbemployeename.Text.ToString() + "&address=" + tbemployeeaddress.Text.ToString() + "&DateOfJoin=" + tbeffectivedate.Text.ToString() + "&EmployeeId=" + tblemployeeid.Text.ToString() + "&IssuedBy=" + tbIssuedby.Text.ToString());
        Session["Department"] = drpdepartment.SelectedItem.Text;
        Session["Designation"] = drpdesignation.SelectedItem.Text;
        Response.Redirect("ConfirmationForm.aspx?CandidateName=" + TextBox1_name.Text.ToString() + "&ConfirmationNumber=" + txt_confrm_ltr_numbr.Text + "&Hr1=" + txt_hr_1.Text + "&Hr2=" + txt_hr_2.Text + "&EffectiveDate=" + tbeffectivedate.Text + "&IssuedDate=" + tbissueddate.Text + "&EmployeeID=" + tbemployee_id.Text + "&IssuedBy=" + tbIssuedby.Text + "&EmailID=" + txt_email.Text + " ");
    }

    protected void btngetempdetails_Click(object sender, EventArgs e)
    {
        string employee_id = tbemployee_id.Text.Trim();
        BindEmployee(employee_id);
    }

    protected void BindEmployee(string employee)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"SELECT DISTINCT rtrim(jd.empcode) as empcode, 
coalesce(jd.emp_fname,'') + '' + coalesce(jd.emp_m_name,'') + '' + coalesce(jd.emp_l_name,'') as employee_name,  
jd.card_no,cont.per_add1,tbl_intranet_grade.gradename grade,jd.official_email_id,    
jd.degination_id,desg.designationname,desg.id,jd.dept_id,tbl_internate_departmentdetails.department_name,
jd.dep_type_id,tbl_internate_department_type.dept_type_name,jd.branch_id,tbl_intranet_branch_detail.branch_name,    
convert(varchar(10),jd.emp_doj,101)emp_doj,tbl_intranet_role.role,jd.emp_status    
FROM tbl_intranet_employee_jobDetails jd 
left join tbl_internate_department_type on jd.dep_type_id=tbl_internate_department_type.dept_type_id
left JOIN tbl_intranet_designation desg ON jd.degination_id=desg.id    
left JOIN tbl_internate_departmentdetails ON jd.dept_id=tbl_internate_departmentdetails.departmentid    
left JOIN tbl_intranet_branch_detail ON jd.branch_id=tbl_intranet_branch_detail.Branch_id    
left outer JOIN tbl_intranet_grade ON jd.grade=tbl_intranet_grade.id
left join tbl_login on tbl_login.empcode=jd.empcode
left join tbl_intranet_role on tbl_intranet_role.id=tbl_login.role
left join tbl_intranet_employee_contactlist cont on jd.empcode=cont.empcode 
WHERE 1=1 and jd.status=1 and jd.emp_status in('1') and jd.emp_doleaving is null 
and jd.empcode = '" + employee + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            tbemployeeaddress.Text = ds.Tables[0].Rows[0]["per_add1"].ToString();
            tbeffectivedate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
            drpdepartment.SelectedValue = ds.Tables[0].Rows[0]["dept_id"].ToString();
            drpdesignation.SelectedValue = ds.Tables[0].Rows[0]["degination_id"].ToString();
            //tblemployeeid.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            TextBox1_name.Text = ds.Tables[0].Rows[0]["employee_name"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["official_email_id"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void Reset()
    {
        TextBox1_name.Text = "";
        txt_confrm_ltr_numbr.Text = "";
        txt_hr_1.Text = "";
        txt_hr_2.Text = "";
        tbemployeeaddress.Text = "";
        tbeffectivedate.Text = "";
        tbissueddate.Text = "";
        drpdepartment.SelectedValue = "0";
        drpdesignation.SelectedValue = "0";
        tbemployee_id.Text = "";
        tbIssuedby.Text = "";
        txt_email.Text = "";
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        Response.Redirect("Send_confirmed_mail.aspx?toemail=" + txt_email.Text.ToString() + "&Name=" + TextBox1_name.Text + "");
    }

    private void BindConfirmationLetterNumber()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select COUNT(@@ROWCOUNT) AS totalRows from tbl_confirmation_letter_details";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            int refnNo = Convert.ToInt32(ds.Tables[0].Rows[0]["totalRows"]) + 1;
            txt_confrm_ltr_numbr.Text = refnNo.ToString();
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

}