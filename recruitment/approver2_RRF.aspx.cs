using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;
using Smart.HR.Common.Mail.Module;

public partial class recruitment_approver2_RRF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            if (Request.QueryString["id"] != null)
            {
                bindDetails();
                bindpreviouscomments();
            }
            bind_RRF();
        }

        if (Request.QueryString["id"] != null)
        {
            tbl_list.Visible = false;
            tbl_status.Visible = true;
            bindapproversgrid();
        }
        if (Request.QueryString["Approved"] != null)
        {
            Output.Show("Requisition Form Approved Successfully");
        }
        if (Request.QueryString["Rejected"] != null)
        {
            Output.Show("Requisition Form Rejected Successfully");
        }
    }

    protected void bind_RRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRFs_by_approver2", sqlparam);
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }

    protected void bindDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        sqlParam[0] = new SqlParameter("@ids", SqlDbType.Int);
        sqlParam[0].Value = id;
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_byIDs", sqlParam);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            lbl_rrfcode.Text = ds.Tables[0].Rows[0]["rrf_code"].ToString();
            lbl_requestedby.Text = ds.Tables[0].Rows[0]["requestedby"].ToString();
            lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_Posts.Text = ds.Tables[0].Rows[0]["total_no_posts"].ToString();
            // txt_Posts.Text = ds.Tables[0].Rows[0]["total_no_posts"].ToString();
            lbl_requestType.Text = ds.Tables[0].Rows[0]["requesttype"].ToString();
            lbl_vacancyType.Text = ds.Tables[0].Rows[0]["vacancytype"].ToString();
            lbl_temparary.Text = ds.Tables[0].Rows[0]["temporary"].ToString();
            lbl_incentive.Text = ds.Tables[0].Rows[0]["expectedCTC"].ToString();
            lbl_workinghours.Text = ds.Tables[0].Rows[0]["working_hours"].ToString();
            lbl_reasons.Text = ds.Tables[0].Rows[0]["reasons_of_request"].ToString();
            lbl_costcenter.Text = ds.Tables[0].Rows[0]["division_name"].ToString();
            //lbl_budget.Text = ds.Tables[0].Rows[0]["budget"].ToString();
            lbl_location.Text = ds.Tables[0].Rows[0]["location"].ToString();
            lbl_grosssalary.Text = ds.Tables[0].Rows[0]["gross_salary"].ToString();
            lbl_tctc.Text = ds.Tables[0].Rows[0]["ctc"].ToString();
            lbl_shifthours.Text = ds.Tables[0].Rows[0]["shift_hours"].ToString();
            lblQualifiers.Text = ds.Tables[0].Rows[0]["additional_qualifiers"].ToString();
            lbl_industries.Text = ds.Tables[0].Rows[0]["industries_preferred"].ToString();
            lbl_jobdesc.Text = ds.Tables[0].Rows[0]["job_description"].ToString();
            lbl_skills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
            lbl_edu.Text = ds.Tables[0].Rows[0]["educational_qualifications"].ToString();
            lbl_Exp.Text = ds.Tables[0].Rows[0]["experience"].ToString();
            
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[3];

        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;

        //sqlParam[1] = new SqlParameter("@total_no_posts", SqlDbType.Int);
        //sqlParam[1].Value = txt_Posts.Text;

        sqlParam[1] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
        sqlParam[1].Value = "A";

        sqlParam[2] = new SqlParameter("@Approvelevel", SqlDbType.VarChar, 1);
        sqlParam[2].Value = "2";
        insertapprovedcomments(id);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_update_approver2", sqlParam);

        RecruitmentApprovers objEmail = new RecruitmentApprovers();
        string rrfCode = objEmail.GetRRFId(id);
        //if (objEmail.CheckStatusOfHRBPAndMD(rrfCode))
        //{
            SendEmailHRTA(rrfCode);
        //}

        Response.Redirect("approver2_RRF.aspx?Approved=RRF" + id);

    }

    protected void insertapprovedcomments(int id)
    {
        SqlParameter[] sqlparam = new SqlParameter[6];
        sqlparam[0] = new SqlParameter("@rrf_id", SqlDbType.Int);
        sqlparam[0].Value = id;
        sqlparam[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();
        sqlparam[2] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
        sqlparam[2].Value = "A";
        sqlparam[3] = new SqlParameter("@approverlevel", SqlDbType.VarChar, 1);
        sqlparam[3].Value = "2";
        sqlparam[4] = new SqlParameter("@comments", SqlDbType.VarChar, 8000);
        sqlparam[4].Value = txtComments.Text;
        sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[5].Value = Session["empcode"].ToString();

        int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_approver_comments", sqlparam);

    }

    protected void btn_reject_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[3];
        try
        {
            sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[0].Value = id;

            sqlParam[1] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
            sqlParam[1].Value = "R";

            sqlParam[2] = new SqlParameter("@Approvelevel", SqlDbType.VarChar, 1);
            sqlParam[2].Value = "2";
            insertrejectcomments(id);
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_Reject_approver2", sqlParam);

            RecruitmentApprovers objEmail = new RecruitmentApprovers();
            SendEmailLM(objEmail.GetRRFId(id));

            Response.Redirect("approver2_RRF.aspx?Rejected=RRF" + id);
        }

        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        //int id = Convert.ToInt32(Request.QueryString["id"]);
        //string sqlstr = "update tbl_recruitment_requisition_form set approver2_status='R' where id='" + id + "'";
        //DataSet ds = new DataSet();
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //Response.Redirect("approver2_RRF.aspx?Rejected=RRF" + id);
    }

    protected void insertrejectcomments(int id)
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@rrf_id", SqlDbType.Int);
        sqlparam[0].Value = id;
        sqlparam[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();
        sqlparam[2] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
        sqlparam[2].Value = "R";
        sqlparam[3] = new SqlParameter("@approverlevel", SqlDbType.VarChar, 1);
        sqlparam[3].Value = "2";
        sqlparam[4] = new SqlParameter("@comments", SqlDbType.VarChar, 8000);
        sqlparam[4].Value = txtComments.Text;
        sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[5].Value = Session["empcode"].ToString();

        int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_approver_comments", sqlparam);

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("approver2_RRF.aspx");
    }

    protected void grdRRF_PreRender(object sender, EventArgs e)
    {
        if (grdRRF.Rows.Count > 0)
        {
            grdRRF.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bindpreviouscomments()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        SqlParameter[] sqlParam = new SqlParameter[1];
        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_comments", sqlParam);
        if (ds.Tables.Count > 0)
        {
            Gridcomments.DataSource = ds;
            Gridcomments.DataBind();
        }
    }

    protected void bindapproversgrid()
    {
        IBase Lib = null;
        Lib = new Base();

        string Query = @"

select 
F.id, 
F.rrf_code, 
A.ApproverCode, 
isnull(J.emp_fname,'')+''+isnull(J.emp_m_name,'')+''+isnull(J.emp_l_name,'') ApproverName,
A.Approvelevel,
case 
when A.Approvelevel = 1 then 'BH'
when A.Approvelevel = 2 then 'HR-BP'
when A.Approvelevel = 3 then 'MD'
when A.Approvelevel = 4 then 'HR-TA' end ApproverRole
, 
case 
when A.ApproverStatus = 'H' then 'Pending'
when A.ApproverStatus = 'A' then 'Approved'
when A.ApproverStatus = 'R' then 'Rejected' end ApproverStatus
 from tbl_recruitment_requisition_form F
  inner join tbl_recruitment_master_approvers A on F.rrf_code = A.rrf_code
  inner join tbl_intranet_employee_jobDetails J on A.ApproverCode = J.empcode
   where F.id = " + Request.QueryString["id"].Trim() + " order by A.Approvelevel";

        Lib.Bee.WBindGrid(Query, grdapprovers);

    }

    void SendEmailLM(string rrfId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedLM();
        EmailClient client = new EmailClient(email);
        RecruitmentApprovers objEmail = new RecruitmentApprovers();
        DataRow rowEmp = objEmail.GetRecruitmentRaisedEmployee(rrfId);

        client.toEmailId = rowEmp["officialemailid"].ToString().Trim();
        client.empCode = rowEmp["empcode"].ToString();
        client.employeeName = rowEmp["empname"].ToString().Trim();
        client.requestNumber = rrfId;
        client.Send();
    }

    void SendEmailHRTA(string rrfId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedHRTA();
        EmailClient client = new EmailClient(email);
        RecruitmentApprovers objEmail = new RecruitmentApprovers();

        DataSet ds = objEmail.GetRecruitmentApprovers(rrfId);

        DataRow rowApp = ds.Tables[0].Rows[3];
        DataRow rowEmp = ds.Tables[1].Rows[0];

        client.toEmailId = rowApp["officialemailid"].ToString().Trim();
        client.empCode = rowApp["empcode"].ToString();
        client.employeeName = rowApp["empname"].ToString().Trim();
        client.requestNumber = rrfId;
        client.fromDate = rowEmp["empname"].ToString().Trim() + " ( " + rowEmp["empcode"].ToString().Trim() + " ) ";
        client.toDate = "HR-BP";
        client.Send();
    }

}