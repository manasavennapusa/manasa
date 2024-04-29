using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;

public partial class recruitment_r_viewRequistionStatus : System.Web.UI.Page
{
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {

         UserCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            

            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //Response.Redirect("~/Authenticate.aspx");
            }
            else

                Response.Redirect("~/notlogged.aspx");
            bindDetails();
            bindpreviouscomments();
            bindholdDetails();
            bindapproversgrid();
        }
    }

    protected void bindholdDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value = id;
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_holddetails", sqlparam);
        grdrrfholddetails.DataSource = ds;
        grdrrfholddetails.DataBind();
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

    protected void bindDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        try
        {
            sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[0].Value = id;
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_byID", sqlParam);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                lbl_rrfcode.Text = ds.Tables[0].Rows[0]["rrf_code"].ToString();
                lbl_requestedby.Text = ds.Tables[0].Rows[0]["requestedby"].ToString() + " ( " + ds.Tables[0].Rows[0]["empcode"].ToString() + " ) ";
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
                lbl_costcenter.Text = ds.Tables[0].Rows[0]["dept_type_name"].ToString();
                // lbl_budget.Text = ds.Tables[0].Rows[0]["budget"].ToString();
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
                lblDepartment.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
                lblDesignation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();

            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewStatusByRRF_Raiser.aspx");
    }

    protected void grdapprovers_PreRender(object sender, EventArgs e)
    {
        if (grdapprovers.Rows.Count > 0)
        {
            grdapprovers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}