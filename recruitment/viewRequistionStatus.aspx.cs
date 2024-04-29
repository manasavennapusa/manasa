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

public partial class recruitment_viewRequistionStatus : System.Web.UI.Page
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
            bindholdDetails();
            bindapproversgrid();
            bindpreviouscomments();
            //bindCandidatedetails();
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

//    protected void bindAssiengedGrid()
//    {
//        int rrf_id = Convert.ToInt32(Request.QueryString["rrf_id"]);

//        string sqlstr = @"select rp.*,rf.rrf_code from tbl_recruitment_panel_master rp
//                                    inner join tbl_recruitment_assignpanel ap on rp.id=ap.panelid
//                                    inner join tbl_recruitment_requisition_form rf on rf.id=ap.rrf_code
//                                    where rf.status=1 and rf.id='" + rrf_id + "'";

//        string sqlstr = @"select rp.*,rf.rrf_code,desg.designationname,emp.emp_fname from tbl_recruitment_panel_master rp
//                            inner join tbl_recruitment_assignpanel ap on rp.id=ap.panelid
//                            inner join tbl_recruitment_requisition_form rf on rf.id=ap.rrf_code
//                            inner join tbl_intranet_designation desg on desg.id=rf.designationid
//                            inner join  tbl_intranet_employee_jobDetails emp on emp.empcode=rp.resourcenames                                                      
//                            where rf.status=1 and rf.id='" + rrf_id + "'";

//        DataSet ds = new DataSet();
//        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
//        grdassigned.DataSource = ds;
//        grdassigned.DataBind();

    //}


    //protected void bindCandidatedetails()
    //{
    //    int id = Convert.ToInt32(Request.QueryString["id"]);
    //    SqlParameter[] sqlParam = new SqlParameter[1];
    //    try
    //    {
    //        //string sqlstr = "select * from tbl_recruitment_candidate_registration where id='" + id + "'";
    //        //sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
    //        //sqlParam[0].Value = id;

    //        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
    //        sqlParam[0].Value = id;
    //        DataSet ds = new DataSet();

    //        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_byID", sqlParam);
    //        if (ds.Tables[0].Rows.Count >= 1)
    //        {
    //            txt_candidateName.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
    //            txt_phoneno.Text = ds.Tables[0].Rows[0]["phone"].ToString();
    //            txt_email.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
    //            txt_experience.Text = ds.Tables[0].Rows[0]["experience"].ToString();
    //            txt_skills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
    //            txt_Qualifications.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
    //            txt_joinstatus.Text = ds.Tables[0].Rows[0]["joinstatus"].ToString();
    //            txt_mobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
    //            lblexpectedsalary.Text = ds.Tables[0].Rows[0]["expectedsalary"].ToString();
    //            lblachievements.Text = ds.Tables[0].Rows[0]["achievements"].ToString();
    //            lblpassportno.Text = ds.Tables[0].Rows[0]["passportno"].ToString();
    //            lbldob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"]).ToString("dd MMM yyyy");
    //            lblnotes.Text = ds.Tables[0].Rows[0]["note"].ToString();
    //            lbladdress.Text = ds.Tables[0].Rows[0]["candidate_address"].ToString();
    //            txt_gender.Text = ds.Tables[0].Rows[0]["gender"].ToString();
    //            //txt_applied_date.Text = ds.Tables[0].Rows[0]["Applied_Date"].ToString();
    //            if (ds.Tables[0].Rows[0]["Applied_Date"].ToString() != "")
    //                txt_applied_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Applied_Date"].ToString()).ToString("dd MMM yyyy");
    //            else txt_applied_date.Text = "";
    //            lbl_refered_by.Text = ds.Tables[0].Rows[0]["referredby"].ToString() + "-" + ds.Tables[0].Rows[0]["referrername"].ToString();
    //            txt_designation.Text = ds.Tables[0].Rows[0]["designation_id"].ToString();
    //            lbl_passport_validity.Text = ds.Tables[0].Rows[0]["passportvalidity"].ToString();
    //            lbtnview.CommandArgument = ds.Tables[0].Rows[0]["uploadresume"].ToString();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not Fetched. Please contact system admin. For error details please go through the log file.");
    //    }
    //}


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
        Response.Redirect("requisitionFormsList.aspx");
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
when A.Approvelevel = 2 then 'HR-TA'
when A.Approvelevel = 3 then 'MD'
when A.Approvelevel = 4 then 'HR-BP' end ApproverRole
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

    //protected void lbtnview_Click(object sender, EventArgs e)
    //{
    //    DownLoad(Server.MapPath("~/recruitment/upload/" + lbtnview.CommandArgument));
    //}
    //public void DownLoad(string FName)
    //{
    //    string path = FName;
    //    System.IO.FileInfo file = new System.IO.FileInfo(path);
    //    if (file.Exists)
    //    {
    //        Response.Clear();
    //        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
    //        Response.AddHeader("Content-Length", file.Length.ToString());
    //        Response.ContentType = "application/word";
    //        Response.WriteFile(file.FullName);
    //        Response.End();
    //    }
    //}
}