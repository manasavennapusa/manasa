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
using System.Text;
using System.IO;
using System.Web;

public partial class Forms_GenerateOfferLetter : System.Web.UI.Page
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
        txt_offer_ltr_numbr.ReadOnly = true;
        txt_offer_ltr_numbr.BackColor = System.Drawing.SystemColors.Window;
        
        string toemail = Request.QueryString["toemail"];
        string name = Request.QueryString["Name"];
        if (!IsPostBack)
        {
            tbIssuedt.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            bindjoblocation();
            binddepartment();
            binddesignation();
            BindOfferLetterNumber();
        }
        btngenerateletter.Enabled = true;

        string candidate_name = Request.QueryString["candidatename"];
        string issued_date = Request.QueryString["issueddate"];
        string offer_letter_num = Request.QueryString["offerletternumber"];
        string hr_1 = Request.QueryString["hr1"];
        string hr_2 = Request.QueryString["hr2"];
        string address = Request.QueryString["Address"];
        string CTC = Request.QueryString["ctc"];
        string join_date = Request.QueryString["joindate"];
        string issued_by = Request.QueryString["issuedby"];
        string job_loc = Request.QueryString["jobloc"];
        string dept = Request.QueryString["department"];
        string desg = Request.QueryString["designation"];
        string last_dt_to_join  =Request.QueryString["lastdatetojoin"];
        string email_id = Request.QueryString["emailid"];
    }

    protected void btngenerateletter_Click(object sender, EventArgs e)
    {

        if (tbIssuedt.Text != "" && tbjoindt.Text != "" &&tblstdt.Text!="")
        {
            //if (Convert.ToDateTime(tbIssuedt.Text) >= Convert.ToDateTime(tbjoindt.Text))
            //{
            //    tbjoindt.Focus();
            //    imgerror.Visible = true;
            //    Output.Show("Enter Valid Date");
            //    imgerror.Visible = false;
            //}
            //else if (Convert.ToDateTime(tbjoindt.Text) >= Convert.ToDateTime(tblstdt.Text))
            //{
            //    img1.Visible = true;
            //    tblstdt.Focus();
            //    Output.Show("Enter Valid Date");
            //    img1.Visible = false;
            //}
            //else
            //{
                imgerror.Visible = false;
                img1.Visible = false;
                var parm = new SqlParameter[15];
                SqlTransaction transaction = null;
                var activity = new DataActivity();
                int flag = 0;
                try
                {
                    Output.AssignParameter(parm, 0, "@candidate_id", "Int", 0, txtcandidatename.Text);
                    Output.AssignParameter(parm, 1, "@candidate_name", "String", 60, TextBox1_name.Text);
                    Output.AssignParameter(parm, 2, "@candidate_address", "String", 500, tbaddress.Text);
                    Output.AssignParameter(parm, 3, "@ctc", "String", 50, tbctc.Text);
                    Output.AssignParameter(parm, 4, "@join_date", "DateTime", 0, tbjoindt.Text);
                    Output.AssignParameter(parm, 5, "@issued_by", "String", 50, tbissuedby.Text);
                    Output.AssignParameter(parm, 6, "@job_location", "String", 50, drpbranch.SelectedItem.Text);
                    Output.AssignParameter(parm, 7, "@designation", "String", 50, drpdesignation.SelectedItem.Text);
                    Output.AssignParameter(parm, 8, "@last_date_to_join", "DateTime", 0, tblstdt.Text);
                    Output.AssignParameter(parm, 9, "@issued_date", "DateTime", 0, tbIssuedt.Text);
                    Output.AssignParameter(parm, 10, "@email", "String", 50, tbemail.Text);
                    Output.AssignParameter(parm, 11, "@offer_letter_number", "String", 40, txt_offer_ltr_numbr.Text);
                    Output.AssignParameter(parm, 12, "@Hr_1", "String", 10, txt_hr_1.Text);
                    Output.AssignParameter(parm, 13, "@Hr_2", "String", 10, txt_hr_2.Text);
                    Output.AssignParameter(parm, 14, "@department", "String", 40, drpdepartment.SelectedItem.Text);

                    SqlConnection connection = activity.OpenConnection();
                    transaction = connection.BeginTransaction();
                    flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_insert_into_tbl_offer_letter_details", parm);
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
                    Output.Show("Candidate Details Submitted Successfully");
                }
                else
                {
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                BindOfferLetterNumber();
                //Response.Redirect("OfferLetterDetails.aspx?candidatename=" + txtcandidatename.Text.ToString() + "&address=" + tbaddress.Text.ToString() + "&designation=" + drpdesignation.SelectedItem.ToString() + "&DateOfJoin=" + tbjoindt.Text.ToString() + "&location=" + drpbranch.SelectedItem.ToString());
                Session["Department"] = drpdepartment.SelectedItem.Text;
                Session["Designation"] = drpdesignation.SelectedItem.Text;
                Response.Redirect("OfferLetterDetails.aspx?candidatename=" + TextBox1_name.Text + "&issueddate=" + tbIssuedt.Text + "&offerletternumber=" + txt_offer_ltr_numbr.Text + "&hr1=" + txt_hr_1.Text + "&hr2=" + txt_hr_2.Text + "&ctc=" + tbctc.Text + "&joindate=" + tbjoindt.Text + "&issuedby=" + tbissuedby.Text + "&jobloc=" + drpbranch.SelectedItem.Text + "&lastdatetojoin=" + tblstdt.Text + "&emailid=" + tbemail.Text + " ");
            //}
        }
      
    }

    private void BindOfferLetterNumber()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select COUNT(@@ROWCOUNT) AS totalRows from tbl_offer_letter_details";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            int refnNo = Convert.ToInt32(ds.Tables[0].Rows[0]["totalRows"]) + 1;
            txt_offer_ltr_numbr.Text = refnNo.ToString();
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

    protected void btnSend_Click(object sender, EventArgs e)
    {
        Response.Redirect("SendMail.aspx?toemail=" + tbemail.Text.ToString() + "&Name=" + TextBox1_name.Text + "");
    }

    protected void btngetcandidate_Click(object sender, EventArgs e)
    {
        string candidate_code = txtcandidatename.Text.Trim();
        bindcandidate(candidate_code);
    }

    protected void bindcandidate(string candidate)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"select distinct cr.id,rrf.rrf_code,cr.candidate_name,cr.candidate_address,exp_ctc.expectedCTC,bd.branch_name,
d.designationname,cr.emailid,rrf.locationid,rrf.designationid,dept.department_name,rrf.departmentid
from tbl_recruitment_candidate_registration cr 
left join tbl_recruitment_requisition_form rrf on rrf.id=cr.rrf_id
left join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid
left join tbl_intranet_designation d on rrf.designationid=d.id
left join tbl_recruitment_expctc_master exp_ctc on rrf.incentive=exp_ctc.id
left join tbl_intranet_branch_detail bd on rrf.locationid=bd.branch_id
left join tbl_internate_departmentdetails dept on rrf.departmentid=dept.departmentid
where (ci.round_1_status not in('R') or ci.round_1_status is  Null) and 
(ci.round_2_status not in ('R') or ci.round_2_status is  Null) and cr.id = '" + candidate + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            //txt_candidateid.Text = ds.Tables[0].Rows[0]["id"].ToString();
            TextBox1_name.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
            tbaddress.Text = ds.Tables[0].Rows[0]["candidate_address"].ToString();
            //tbctc.Text = ds.Tables[0].Rows[0]["expectedCTC"].ToString();
            drpdesignation.SelectedValue = ds.Tables[0].Rows[0]["designationid"].ToString();
            drpdepartment.SelectedValue = ds.Tables[0].Rows[0]["departmentid"].ToString();
            tbemail.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
            drpbranch.SelectedValue = ds.Tables[0].Rows[0]["locationid"].ToString();
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

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Reset();
    }   

    protected void Reset()
    {
        txtcandidatename.Text = "";
        TextBox1_name.Text = "";
        txt_offer_ltr_numbr.Text = "";
        txt_hr_1.Text = "";
        txt_hr_2.Text = "";
        txt_candidateid.Text = "";
        tbaddress.Text = "";
        tbctc.Text = "";
        tbjoindt.Text = "";
        tbissuedby.Text = "";
        drpbranch.SelectedValue = "0";
        drpdepartment.SelectedValue = "0";
        drpdesignation.SelectedValue = "0";
        tblstdt.Text = "";
        tbIssuedt.Text = "";
        tbemail.Text = "";
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

    protected void bindjoblocation()
    {
        string sqlstr = "select Branch_Id, branch_name FROM tbl_intranet_branch_detail";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpbranch.DataTextField = "branch_name";
        drpbranch.DataValueField = "Branch_Id";
        drpbranch.DataSource = ds;
        drpbranch.DataBind();
        drpbranch.Items.Insert(0, new ListItem("--Select--", "0"));
    }

}