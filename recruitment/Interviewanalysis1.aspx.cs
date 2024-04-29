using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Configuration;
using Common.Data;
using Common.Console;

public partial class recruitment_Interviewanalysis1 : System.Web.UI.Page
{
    string UserCode;

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

            UserCode = Session["empcode"].ToString();
            if (Request.QueryString["id"] != null)
            {
                bindDetails();
            }

        }
    }

    protected void bindDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        SqlParameter[] sqlParam = new SqlParameter[1];

        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_finalbyID", sqlParam);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            lblrrfcode.Text = ds.Tables[0].Rows[0]["rrf_code"].ToString();
            lblCandidatename.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
            lblQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
            lblSkills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
            lblExperience.Text = ds.Tables[0].Rows[0]["experience"].ToString();
            hdcandidatecode.Value = ds.Tables[0].Rows[0]["id"].ToString();
        }

        string sqlstr1 = "select * from tbl_recruitment_interviewrrating where Candidate_id='" + Request.QueryString["id"].ToString() + "'";
        DataSet ds1 = new DataSet();
        ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            btnInsert.Visible = false;
            btnUpdate.Visible = true;
            if (ds1.Tables[0].Rows[0]["Personality"].ToString() == "6") { optionsRadios2.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Personality"].ToString() == "5") { Radio1.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Personality"].ToString() == "4") { Radio2.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Personality"].ToString() == "3") { Radio3.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Personality"].ToString() == "2") { Radio4.Checked = true; }
            else { Radio40.Checked = true; }

            if (ds1.Tables[0].Rows[0]["AcademicRecord"].ToString() == "6") { Radio5.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["AcademicRecord"].ToString() == "5") { Radio6.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["AcademicRecord"].ToString() == "4") { Radio7.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["AcademicRecord"].ToString() == "3") { Radio8.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["AcademicRecord"].ToString() == "2") { Radio9.Checked = true; }
            else { Radio41.Checked = true; }

            if (ds1.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "6") { Radio10.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "5") { Radio11.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "4") { Radio12.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "3") { Radio13.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "2") { Radio14.Checked = true; }
            else { Radio42.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Communication"].ToString() == "6") { Radio15.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Communication"].ToString() == "5") { Radio16.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Communication"].ToString() == "4") { Radio17.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Communication"].ToString() == "3") { Radio18.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Communication"].ToString() == "2") { Radio19.Checked = true; }
            else { Radio43.Checked = true; }

            if (ds1.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "6") { Radio20.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "5") { Radio21.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "4") { Radio22.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "3") { Radio23.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "2") { Radio24.Checked = true; }
            else { Radio47.Checked = true; }

            if (ds1.Tables[0].Rows[0]["LearningAbility"].ToString() == "6") { Radio25.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["LearningAbility"].ToString() == "5") { Radio26.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["LearningAbility"].ToString() == "4") { Radio27.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["LearningAbility"].ToString() == "3") { Radio28.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["LearningAbility"].ToString() == "2") { Radio29.Checked = true; }
            else { Radio48.Checked = true; }

            txtRemarks.Text = ds1.Tables[0].Rows[0]["Remarks"].ToString();

            if (ds1.Tables[0].Rows[0]["Behavior"].ToString() == "6") { Radio51.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Behavior"].ToString() == "5") { Radio52.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Behavior"].ToString() == "4") { Radio53.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Behavior"].ToString() == "3") { Radio54.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Behavior"].ToString() == "2") { Radio55.Checked = true; }
            else { Radio56.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Stability"].ToString() == "6") { Radio57.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Stability"].ToString() == "5") { Radio58.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Stability"].ToString() == "4") { Radio59.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Stability"].ToString() == "3") { Radio60.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Stability"].ToString() == "2") { Radio61.Checked = true; }
            else { Radio62.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Experience"].ToString() == "6") { Radio63.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Experience"].ToString() == "5") { Radio64.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Experience"].ToString() == "4") { Radio65.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Experience"].ToString() == "3") { Radio66.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Experience"].ToString() == "2") { Radio67.Checked = true; }
            else { Radio68.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Interest"].ToString() == "6") { Radio69.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Interest"].ToString() == "5") { Radio70.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Interest"].ToString() == "4") { Radio71.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Interest"].ToString() == "3") { Radio72.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Interest"].ToString() == "2") { Radio73.Checked = true; }
            else { Radio74.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Skills"].ToString() == "6") { Radio75.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Skills"].ToString() == "5") { Radio76.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Skills"].ToString() == "4") { Radio77.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Skills"].ToString() == "3") { Radio78.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Skills"].ToString() == "2") { Radio79.Checked = true; }
            else { Radio80.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Need"].ToString() == "6") { Radio81.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Need"].ToString() == "5") { Radio82.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Need"].ToString() == "4") { Radio83.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Need"].ToString() == "3") { Radio84.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Need"].ToString() == "2") { Radio85.Checked = true; }
            else { Radio86.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Development"].ToString() == "6") { Radio87.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Development"].ToString() == "5") { Radio88.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Development"].ToString() == "4") { Radio89.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Development"].ToString() == "3") { Radio90.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Development"].ToString() == "2") { Radio91.Checked = true; }
            else { Radio92.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Management"].ToString() == "6") { Radio93.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Management"].ToString() == "5") { Radio94.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Management"].ToString() == "4") { Radio95.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Management"].ToString() == "3") { Radio96.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Management"].ToString() == "2") { Radio97.Checked = true; }
            else { Radio98.Checked = true; }

            if (ds1.Tables[0].Rows[0]["Budget"].ToString() == "6") { Radio99.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Budget"].ToString() == "5") { Radio100.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Budget"].ToString() == "4") { Radio101.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Budget"].ToString() == "3") { Radio102.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["Budget"].ToString() == "2") { Radio103.Checked = true; }
            else { Radio104.Checked = true; }

            if (ds1.Tables[0].Rows[0]["OverallAssessment"].ToString() == "6") { Outstanding.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["OverallAssessment"].ToString() == "5") { VeryGood.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["OverallAssessment"].ToString() == "4") { Good.Checked = true; }
            //else if (ds1.Tables[0].Rows[0]["OverallAssessment"].ToString() == "3") { Fair.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["OverallAssessment"].ToString() == "2") { satisfact.Checked = true; }
            else { unsatis.Checked = true; }


            if (ds1.Tables[0].Rows[0]["PanelsRecomendation"].ToString() == "3") { Radio44.Checked = true; }
            else if (ds1.Tables[0].Rows[0]["PanelsRecomendation"].ToString() == "2") { Radio45.Checked = true; }
            else { Radio46.Checked = true; }
        }
        else
        {
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        InsertFeedback();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/recruitment/InterviewAnalysis.aspx");
    }

    protected void InsertFeedback()
    {
        string Personality = "",
        Academic = "", Goal = "", Communication = "", Knowledge = "", Learning = "", Customer = "", Culter = "", Overall = "", Recomendation = "", Behavior = "", Stability = "", Experience = "", Interest = "", Skills = "", Need = "", Development = "", Management = "", Budget="";

        SqlParameter[] sqlParam = new SqlParameter[23];
        try
        {
            if (Request.Form["Personality"] != null)
            {
                Personality = Request.Form["Personality"].ToString();
            }
            if (Request.Form["Academic"] != null)
            {
                Academic = Request.Form["Academic"].ToString();
            }
            if (Request.Form["Goal"] != null)
            {
                Goal = Request.Form["Goal"].ToString();
            }
            if (Request.Form["Communication"] != null)
            {
                Communication = Request.Form["Communication"].ToString();
            }
            if (Request.Form["Knowledge"] != null)
            {
                Knowledge = Request.Form["Knowledge"].ToString();
            }
            if (Request.Form["Learning"] != null)
            {
                Learning = Request.Form["Learning"].ToString();
            }
            if (Request.Form["Customer"] != null)
            {
                Customer = Request.Form["Customer"].ToString();
            }
            if (Request.Form["Culter"] != null)
            {
                Culter = Request.Form["Culter"].ToString();
            }
            if (Request.Form["Overall"] != null)
            {
                Overall = Request.Form["Overall"].ToString();
            }
            if (Request.Form["Recomendation"] != null)
            {
                Recomendation = Request.Form["Recomendation"].ToString();
            }
            if (Request.Form["Behavior"] != null)
            {
                Behavior = Request.Form["Behavior"].ToString();
            }
            if (Request.Form["Stability"] != null)
            {
                Stability = Request.Form["Stability"].ToString();
            }
            if (Request.Form["Experience"] != null)
            {
                Experience = Request.Form["Experience"].ToString();
            }
            if (Request.Form["Interest"] != null)
            {
                Interest = Request.Form["Interest"].ToString();
            }
            if (Request.Form["Skills"] != null)
            {
                Skills = Request.Form["Skills"].ToString();
            }
            if (Request.Form["Need"] != null)
            {
                Need = Request.Form["Need"].ToString();
            }
            if (Request.Form["Development"] != null)
            {
                Development = Request.Form["Development"].ToString();
            }
            if (Request.Form["Management"] != null)
            {
                Management = Request.Form["Management"].ToString();
            }
            if (Request.Form["Budget"] != null)
            {
                Budget = Request.Form["Budget"].ToString();
            }

            Output.AssignParameter(sqlParam, 0, "@rrf_code", "String", 50, lblrrfcode.Text);
            Output.AssignParameter(sqlParam, 1, "@candidateid", "Int", 0, hdcandidatecode.Value);
            Output.AssignParameter(sqlParam, 2, "@personality", "String", 1, Personality);
            Output.AssignParameter(sqlParam, 3, "@academicrecors", "String", 1, Academic);
            Output.AssignParameter(sqlParam, 4, "@goalorientation", "String", 1, Goal);
            Output.AssignParameter(sqlParam, 5, "@communication", "String", 1, Communication);
            Output.AssignParameter(sqlParam, 6, "@knowledge", "String", 1, Knowledge);
            Output.AssignParameter(sqlParam, 7, "@learningability", "String", 1, Learning);
            Output.AssignParameter(sqlParam, 8, "@customerorientation", "String", 1, Customer);
            Output.AssignParameter(sqlParam, 9, "@culterfit", "String", 1, Culter);
            Output.AssignParameter(sqlParam, 10, "@overallassesment", "String", 1, Overall);
            Output.AssignParameter(sqlParam, 11, "@panelsrecomendation", "String", 1, Recomendation);
            Output.AssignParameter(sqlParam, 12, "@behavior", "String", 1, Behavior);
            Output.AssignParameter(sqlParam, 13, "@stability", "String", 1, Stability);
            Output.AssignParameter(sqlParam, 14, "@experience", "String", 1, Experience);
            Output.AssignParameter(sqlParam, 15, "@interest", "String", 1, Interest);
            Output.AssignParameter(sqlParam, 16, "@skills", "String", 1, Skills);
            Output.AssignParameter(sqlParam, 17, "@need", "String", 1, Need);
            Output.AssignParameter(sqlParam, 18, "@development", "String", 1, Development);
            Output.AssignParameter(sqlParam, 19, "@management", "String", 1, Management);
            Output.AssignParameter(sqlParam, 20, "@budget", "String", 1, Budget);
            Output.AssignParameter(sqlParam, 21, "@remarks", "String", 1000, txtRemarks.Text);
            Output.AssignParameter(sqlParam, 22, "@createdby", "String", 50, UserCode);

            int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_InterviewRating", sqlParam);
            if (i < 0)
            {
                Output.Show("Interview Rating is not Submited");
            }
            else
            {
                //cleartext();
                Response.Redirect("~/recruitment/InterviewRating.aspx?Submit=True");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Personality = "",
       Academic = "", Goal = "", Communication = "", Knowledge = "", Learning = "", Customer = "", Culter = "", Overall = "", Recomendation = "", Behavior = "", Stability = "", Experience = "", Interest = "", Skills = "", Need = "", Development = "", Management = "", Budget = "";

        //SqlParameter[] sqlParam = new SqlParameter[23];
        try
        {
            if (Request.Form["Personality"] != null)
            {
                Personality = Request.Form["Personality"].ToString();
            }
            if (Request.Form["Academic"] != null)
            {
                Academic = Request.Form["Academic"].ToString();
            }
            if (Request.Form["Goal"] != null)
            {
                Goal = Request.Form["Goal"].ToString();
            }
            if (Request.Form["Communication"] != null)
            {
                Communication = Request.Form["Communication"].ToString();
            }
            if (Request.Form["Knowledge"] != null)
            {
                Knowledge = Request.Form["Knowledge"].ToString();
            }
            if (Request.Form["Learning"] != null)
            {
                Learning = Request.Form["Learning"].ToString();
            }
            if (Request.Form["Customer"] != null)
            {
                Customer = Request.Form["Customer"].ToString();
            }
            if (Request.Form["Culter"] != null)
            {
                Culter = Request.Form["Culter"].ToString();
            }
            if (Request.Form["Overall"] != null)
            {
                Overall = Request.Form["Overall"].ToString();
            }
            if (Request.Form["Recomendation"] != null)
            {
                Recomendation = Request.Form["Recomendation"].ToString();
            }
            if (Request.Form["Behavior"] != null)
            {
                Behavior = Request.Form["Behavior"].ToString();
            }
            if (Request.Form["Stability"] != null)
            {
                Stability = Request.Form["Stability"].ToString();
            }
            if (Request.Form["Experience"] != null)
            {
                Experience = Request.Form["Experience"].ToString();
            }
            if (Request.Form["Interest"] != null)
            {
                Interest = Request.Form["Interest"].ToString();
            }
            if (Request.Form["Skills"] != null)
            {
                Skills = Request.Form["Skills"].ToString();
            }
            if (Request.Form["Need"] != null)
            {
                Need = Request.Form["Need"].ToString();
            }
            if (Request.Form["Development"] != null)
            {
                Development = Request.Form["Development"].ToString();
            }
            if (Request.Form["Management"] != null)
            {
                Management = Request.Form["Management"].ToString();
            }
            if (Request.Form["Budget"] != null)
            {
                Budget = Request.Form["Budget"].ToString();
            }

            //Output.AssignParameter(sqlParam, 0, "@rrf_code", "String", 50, lblrrfcode.Text);
            //Output.AssignParameter(sqlParam, 1, "@candidateid", "Int", 0, hdcandidatecode.Value);
            //Output.AssignParameter(sqlParam, 2, "@personality", "String", 1, Personality);
            //Output.AssignParameter(sqlParam, 3, "@academicrecors", "String", 1, Academic);
            //Output.AssignParameter(sqlParam, 4, "@goalorientation", "String", 1, Goal);
            //Output.AssignParameter(sqlParam, 5, "@communication", "String", 1, Communication);
            //Output.AssignParameter(sqlParam, 6, "@knowledge", "String", 1, Knowledge);
            //Output.AssignParameter(sqlParam, 7, "@learningability", "String", 1, Learning);
            //Output.AssignParameter(sqlParam, 8, "@customerorientation", "String", 1, Customer);
            //Output.AssignParameter(sqlParam, 9, "@culterfit", "String", 1, Culter);
            //Output.AssignParameter(sqlParam, 10, "@overallassesment", "String", 1, Overall);
            //Output.AssignParameter(sqlParam, 11, "@panelsrecomendation", "String", 1, Recomendation);
            //Output.AssignParameter(sqlParam, 12, "@behavior", "String", 1, Behavior);
            //Output.AssignParameter(sqlParam, 13, "@stability", "String", 1, Stability);
            //Output.AssignParameter(sqlParam, 14, "@experience", "String", 1, Experience);
            //Output.AssignParameter(sqlParam, 15, "@interest", "String", 1, Interest);
            //Output.AssignParameter(sqlParam, 16, "@skills", "String", 1, Skills);
            //Output.AssignParameter(sqlParam, 17, "@need", "String", 1, Need);
            //Output.AssignParameter(sqlParam, 18, "@development", "String", 1, Development);
            //Output.AssignParameter(sqlParam, 19, "@management", "String", 1, Management);
            //Output.AssignParameter(sqlParam, 20, "@budget", "String", 1, Budget);
            //Output.AssignParameter(sqlParam, 21, "@remarks", "String", 1000, txtRemarks.Text);
            //Output.AssignParameter(sqlParam, 22, "@createdby", "String", 50, UserCode);

            //int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_InterviewRating", sqlParam);

            string sqlstr1 = "update tbl_recruitment_interviewrrating set Personality='" + Personality + "', AcademicRecord='" + Academic + "',GoalOrientedness='" + Goal + "',Communication='" + Communication + "',KnowledgeofGK='" + Knowledge + "',LearningAbility='" + Learning + "',Behavior='" + Behavior + "',OverallAssessment='" + Overall + "',PanelsRecomendation='" + Recomendation + "',Stability='" + Stability + "',Experience='" + Experience + "',Interest='" + Interest + "',Skills='" + Skills + "',Need='" + Need + "',Development='" + Development + "',Management='" + Management + "',Budget='" + Budget + "',Remarks='" + txtRemarks.Text.ToString() + "' where Candidate_id='" + Request.QueryString["id"].ToString() + "'";
            DataSet ds1 = new DataSet();
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
            Output.Show("Interview Rating is updated successfully");
                //cleartext();
            Response.Redirect("~/recruitment/InterviewRating.aspx?Submit=True");
               

          
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }
}