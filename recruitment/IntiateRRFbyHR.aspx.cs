using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Configuration;
using Common.Data;
using Common.Console;
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;

public partial class recruitment_IntiateRRFbyHR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (Request.QueryString["id"] != null)
        {
            gridapprover1.Visible = true;
            tbl_status.Visible = true;
            bindDetails();
            bindpreviouscomments();
            bindapproversgrid();
        }

        if (Request.QueryString["Approved"] != null)
        {
            Output.Show("Initiated Successfully");
        }

        if (!IsPostBack)
        {
            bind_RRF();
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

    protected void bind_RRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRFs_by_approver_HR", sqlparam);
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }

    protected void bindDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_byID", sqlParam);
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
            lbl_costcenter.Text = ds.Tables[0].Rows[0]["dept_type_name"].ToString(); ;
            lbl_budget.Text = ds.Tables[0].Rows[0]["budget"].ToString();
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

        sqlParam[1] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
        sqlParam[1].Value = "A";

        sqlParam[2] = new SqlParameter("@Approvelevel", SqlDbType.VarChar, 1);
        sqlParam[2].Value = "2";
        insertapprovedcomments(id);
        //string sqlstr = "update tbl_recruitment_requisition_form set total_no_posts='" + txt_Posts.Text + "',approver1_status='A' where id='" + id + "'";
        //DataSet ds = new DataSet();
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_update_approver4", sqlParam);

        if (i > 0)
        {
            Response.Redirect("IntiateRRFbyHR.aspx?Approved=true");
        }
        else
        {
            Output.Show("Recruitment Not Intiated Successfully");
        }
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

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("IntiateRRFbyHR.aspx");
    }
    protected void grdRRF_PreRender(object sender, EventArgs e)
    {
        if (grdRRF.Rows.Count > 0)
        {
            grdRRF.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bindapproversgrid()
    {
        IBase Lib = null;
        Lib = new Base();

//        string Query = @"
//
//select 
//F.id, 
//F.rrf_code, 
//A.ApproverCode, 
//isnull(J.emp_fname,'')+''+isnull(J.emp_m_name,'')+''+isnull(J.emp_l_name,'') ApproverName,
//A.Approvelevel,
//case 
//when A.Approvelevel = 1 then 'BH'
//when A.Approvelevel = 2 then 'HR-BP' end ApproverRole
////when A.Approvelevel = 3 then 'MD'
////when A.Approvelevel = 4 then 'HR-TA' end ApproverRole
//, 
//case 
//when A.ApproverStatus = 'H' then 'Pending'
//when A.ApproverStatus = 'A' then 'Approved'
//when A.ApproverStatus = 'R' then 'Rejected' end ApproverStatus
// from tbl_recruitment_requisition_form F
//  inner join tbl_recruitment_master_approvers A on F.rrf_code = A.rrf_code
//  inner join tbl_intranet_employee_jobDetails J on A.ApproverCode = J.empcode
//   where F.id = " + Request.QueryString["id"].Trim() + " order by A.Approvelevel";

 string Query = @"       
select 
F.id, 
F.rrf_code, 
A.ApproverCode, 
isnull(J.emp_fname,'')+''+isnull(J.emp_m_name,'')+''+isnull(J.emp_l_name,'') ApproverName,
A.Approvelevel,
case 
when A.Approvelevel = 1 then 'BH'
when A.Approvelevel = 2 then 'HR-TA' end ApproverRole
--when A.Approvelevel = 3 then 'MD'
--when A.Approvelevel = 4 then 'HR-TA' end ApproverRole
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
}