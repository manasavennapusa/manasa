using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;
using System.Web.UI.WebControls;

public partial class recruitment_r_candidatedetails : System.Web.UI.Page
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
            bindRRFDetails();
            bindCandidatedetails();
            bindInterviewDetails();
            BindPanelMembers();
            bindholdDetails();
            bindapproversgrid();
            interviewanalysis.Visible = false;
        }

        //    interviewanalysis.Visible = true;
        bindDetails();
        //}
    }

    protected void grdapprovers_PreRender(object sender, EventArgs e)
    {
        if (grdapprovers.Rows.Count > 0)
        {
            grdapprovers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bindapproversgrid()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, UserCode);
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_rrf_insert_approvers]", sqlParam);
        grdapprovers.DataSource = ds;
        grdapprovers.DataBind();
    }
    protected void bindDetails()
    {
        //interviewanalysis.Visible = true;
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());

        SqlParameter[] sqlParam = new SqlParameter[1];

        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_View_Finalform_details", sqlParam);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            //lblrrfcode.Text = ds.Tables[0].Rows[0]["rrf_code"].ToString();
            //lblCandidatename.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
            //lblQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
            //lblSkills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
            //lblExperience.Text = ds.Tables[0].Rows[0]["experience"].ToString();
            // hdcandidatecode.Value = ds.Tables[0].Rows[0]["id"].ToString();
            if (ds.Tables[0].Rows[0]["Personality"].ToString() == "5") { optionsRadios2.Checked = true; Radio1.Checked = false; Radio2.Disabled = true; Radio3.Disabled = true; Radio4.Disabled = true; }
            else if (ds.Tables[0].Rows[0]["Personality"].ToString() == "4") { Radio1.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Personality"].ToString() == "3") { Radio2.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Personality"].ToString() == "2") { Radio3.Checked = true; }
            else { Radio4.Checked = true; }
            if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "5") { Radio5.Checked = true; }
            else if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "4") { Radio6.Checked = true; }
            else if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "3") { Radio7.Checked = true; }
            else if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "2") { Radio8.Checked = true; }
            else { Radio9.Checked = true; }
            if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "5") { Radio10.Checked = true; }
            else if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "4") { Radio11.Checked = true; }
            else if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "3") { Radio12.Checked = true; }
            else if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "2") { Radio13.Checked = true; }
            else { Radio14.Checked = true; }
            if (ds.Tables[0].Rows[0]["Communication"].ToString() == "5") { Radio15.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Communication"].ToString() == "4") { Radio16.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Communication"].ToString() == "3") { Radio17.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Communication"].ToString() == "2") { Radio18.Checked = true; }
            else { Radio19.Checked = true; }
            if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "5") { Radio20.Checked = true; }
            else if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "4") { Radio21.Checked = true; }
            else if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "3") { Radio22.Checked = true; }
            else if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "2") { Radio23.Checked = true; }
            else { Radio24.Checked = true; }
            if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "5") { Radio25.Checked = true; }
            else if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "4") { Radio26.Checked = true; }
            else if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "3") { Radio27.Checked = true; }
            else if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "2") { Radio28.Checked = true; }
            else { Radio29.Checked = true; }
            if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "5") { Radio30.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "4") { Radio31.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "3") { Radio32.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "2") { Radio33.Checked = true; }
            else { Radio34.Checked = true; }
            if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "5") { Radio35.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "4") { Radio36.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "3") { Radio37.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "2") { Radio38.Checked = true; }
            else { Radio39.Checked = true; }
            if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "4") { Radio40.Checked = true; }
            else if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "3") { Radio41.Checked = true; }
            else if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "2") { Radio42.Checked = true; }
            else { Radio43.Checked = true; }
            if (ds.Tables[0].Rows[0]["PanelsRecomendation"].ToString() == "3") { Radio44.Checked = true; }
            else if (ds.Tables[0].Rows[0]["PanelsRecomendation"].ToString() == "2") { Radio45.Checked = true; }
            else { Radio46.Checked = true; }

            txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
        }
    }

    protected void bindCandidatedetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        //SqlParameter[] sqlParam = new SqlParameter[1];
        try
        {
            string sqlstr = "select * from tbl_recruitment_candidate_registration where id='" + id + "'";
            //sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            //sqlParam[0].Value = id;
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                txt_candidateName.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
                txt_phoneno.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                txt_email.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
                txt_experience.Text = ds.Tables[0].Rows[0]["experience"].ToString();
                txt_skills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
                txt_Qualifications.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
                txt_joinstatus.Text = ds.Tables[0].Rows[0]["joinstatus"].ToString();
                txt_mobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                lblexpectedsalary.Text = ds.Tables[0].Rows[0]["expectedsalary"].ToString();
                lblachievements.Text = ds.Tables[0].Rows[0]["achievements"].ToString();
                lblpassportno.Text = ds.Tables[0].Rows[0]["passportno"].ToString();
                lbldob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"]).ToString("dd MMM yyyy");
                lblnotes.Text = ds.Tables[0].Rows[0]["note"].ToString();
                lbladdress.Text = ds.Tables[0].Rows[0]["candidate_address"].ToString();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void bindRRFDetails()
    {
        int rrf_id = Convert.ToInt32(Request.QueryString["rrf_id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        try
        {
            sqlParam[0] = new SqlParameter("@ids", SqlDbType.Int);
            sqlParam[0].Value = rrf_id;
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
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void bindInterviewDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        try
        {
            sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[0].Value = id;
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_individual", sqlParam);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                lblCandidatename.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
                lblphoneno.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                lblemail.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
                lblmobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                lblpapername1.Text = ds.Tables[0].Rows[0]["papername"].ToString();
                lblpapername2.Text = ds.Tables[0].Rows[0]["Papername2"].ToString();
                lblmaxmarks.Text = ds.Tables[0].Rows[0]["maximummarks"].ToString();
                lblmaxmarks1.Text = ds.Tables[0].Rows[0]["maximummarks2"].ToString();
                lblcutoffmarks.Text = ds.Tables[0].Rows[0]["passmarks"].ToString();
                lblcutoffmarks1.Text = ds.Tables[0].Rows[0]["passmarks2"].ToString();
                if (ds.Tables[0].Rows[0]["round_1_marks"].ToString() == "")

                    txtround1marks.Text = "Pending";
                else
                    txtround1marks.Text = ds.Tables[0].Rows[0]["round_1_marks"].ToString();

                if (ds.Tables[0].Rows[0]["round_2_marks"].ToString() == "")

                    lblround2marks.Text = "Pending";
                else
                    lblround2marks.Text = ds.Tables[0].Rows[0]["round_2_marks"].ToString();

                lblr1date.Text = ds.Tables[0].Rows[0]["round1_date"].ToString();
                lblr1time.Text = ds.Tables[0].Rows[0]["round1_time"].ToString();
                lblr2date.Text = ds.Tables[0].Rows[0]["round2_date"].ToString();
                lblr2time.Text = ds.Tables[0].Rows[0]["round2_time"].ToString();
                lblr3date.Text = ds.Tables[0].Rows[0]["round3_date"].ToString();
                lblr3time.Text = ds.Tables[0].Rows[0]["round3_time"].ToString();

                if (ds.Tables[0].Rows[0]["round_1_status"].ToString() == "S") { txtround1status.Text = "Selected"; }
                else if (ds.Tables[0].Rows[0]["round_1_status"].ToString() == "") { txtround1status.Text = "Pending"; }
                else { txtround1status.Text = "Rejected"; }

                if (ds.Tables[0].Rows[0]["round_2_status"].ToString() == "S") { txtround2status.Text = "Selected"; }
                else if (ds.Tables[0].Rows[0]["round_2_status"].ToString() == "") { txtround2status.Text = "Pending"; }
                else { txtround2status.Text = "Rejected"; }

                if (ds.Tables[0].Rows[0]["status"].ToString() == "S") { txtianalysis.Text = "Selected"; }
                else if (ds.Tables[0].Rows[0]["status"].ToString() == "R") { txtianalysis.Text = "Rejected"; }
                else if (ds.Tables[0].Rows[0]["status"].ToString() == "P") { txtianalysis.Text = "Pending"; }
                else { txtianalysis.Text = "In Process"; }

            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        bindDetails();
        interviewanalysis.Visible = true;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        interviewanalysis.Visible = false;
    }

    //protected void btn_back_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("r_rrfview.aspx?id=" + Request.QueryString["rrf_id"].Trim());
    //}


    private void BindPanelMembers()
    {
        IBase Lib = null;
        string Query = "";
        Lib = new Base();
        string trow = "";

        Query = @"select panelid,P.panelcode,Panelname,resourcenames
                   from tbl_recruitment_assignpanel P
                    inner join tbl_recruitment_panel_master R on P.panelid = R.id
                   where rrf_code = " + Request.QueryString["rrf_id"].Trim() + " and P.status = 1";

        DataSet ds = Lib.Bee.WGetData(Query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow Row = ds.Tables[0].Rows[0];

            string[] PannelApprover = Row["resourcenames"].ToString().Split(',');
            foreach (string PannelAppcode in PannelApprover)
            {
                trow += "<tr>";
                trow += "<td>" + PannelAppcode + "</td>";
                trow += "<td>" + GetPannelApproverName(PannelAppcode) + "</td>";
                trow += "</tr>";
            }

            panelmembers.InnerHtml = trow;
        }
    }

    private string GetPannelApproverName(string empcode)
    {
        IBase Lib = null;
        string Query = "";
        Lib = new Base();

        Query = @"select emp_fname + ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') ename
                   from tbl_intranet_employee_jobDetails
                    where empcode = '" + empcode + "' ";

        return Lib.Bee.WGetData(Query).Tables[0].Rows[0]["ename"].ToString();
    }

    protected void bindholdDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["rrf_id"]);
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value = id;
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_holddetails", sqlparam);
        grdrrfholddetails.DataSource = ds;
        grdrrfholddetails.DataBind();
    }
}