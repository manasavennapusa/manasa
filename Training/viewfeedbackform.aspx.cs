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

public partial class Training_viewfeedbackform : System.Web.UI.Page
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

            if (Request.QueryString["empcode"] != null)
            {
                bindDetails();
            }

        }
    }

    protected void bindDetails()
    {
        string empcode = Request.QueryString["empcode"].ToString();
        string sqlstr = @"select * from tbl_training_participants_feedback_form where empcode='" + empcode + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionstring"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0]["objective_of_program_1"].ToString() == "1")
            {
                RadioButton1.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["objective_of_program_1"].ToString() == "2")
            {
                RadioButton2.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["objective_of_program_1"].ToString() == "3")
            {
                RadioButton3.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["objective_of_program_1"].ToString() == "4")
            {
                RadioButton4.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["objective_of_program_1"].ToString() == "5")
            {
                RadioButton5.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["objective_of_program_1"].ToString() == "6")
            {
                RadioButton6.Checked = true;
            }
            else 
            {
                RadioButton7.Checked = true;
            }

            if (ds.Tables[0].Rows[0]["subject_matter_2"].ToString() == "1")
            {
                RadioButton8.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["subject_matter_2"].ToString() == "2")
            {
                RadioButton9.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["subject_matter_2"].ToString() == "3")
            {
                RadioButton10.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["subject_matter_2"].ToString() == "4")
            {
                RadioButton11.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["subject_matter_2"].ToString() == "5")
            {
                RadioButton12.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["subject_matter_2"].ToString() == "6")
            {
                RadioButton13.Checked = true;
            }
            else
            {
                RadioButton14.Checked = true;
            }


            if (ds.Tables[0].Rows[0]["able_to_learning_3"].ToString() == "1")
            {
                RadioButton15.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["able_to_learning_3"].ToString() == "2")
            {
                RadioButton16.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["able_to_learning_3"].ToString() == "3")
            {
                RadioButton17.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["able_to_learning_3"].ToString() == "4")
            {
                RadioButton18.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["able_to_learning_3"].ToString() == "5")
            {
                RadioButton19.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["able_to_learning_3"].ToString() == "6")
            {
                RadioButton20.Checked = true;
            }
            else
            {
                RadioButton21.Checked = true;
            }


            if (ds.Tables[0].Rows[0]["effective_communicator_4"].ToString() == "1")
            {
                RadioButton22.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["effective_communicator_4"].ToString() == "2")
            {
                RadioButton23.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["effective_communicator_4"].ToString() == "3")
            {
                RadioButton24.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["effective_communicator_4"].ToString() == "4")
            {
                RadioButton25.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["effective_communicator_4"].ToString() == "5")
            {
                RadioButton26.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["effective_communicator_4"].ToString() == "6")
            {
                RadioButton27.Checked = true;
            }
            else
            {
                RadioButton28.Checked = true;
            }


            if (ds.Tables[0].Rows[0]["well_prepared_5"].ToString() == "1")
            {
                RadioButton29.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["well_prepared_5"].ToString() == "2")
            {
                RadioButton30.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["well_prepared_5"].ToString() == "3")
            {
                RadioButton31.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["well_prepared_5"].ToString() == "4")
            {
                RadioButton32.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["well_prepared_5"].ToString() == "5")
            {
                RadioButton33.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["well_prepared_5"].ToString() == "6")
            {
                RadioButton34.Checked = true;
            }
            else
            {
                RadioButton35.Checked = true;
            }




            if (ds.Tables[0].Rows[0]["trainer_approachable_6"].ToString() == "1")
            {
                RadioButton36.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["trainer_approachable_6"].ToString() == "2")
            {
                RadioButton37.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["trainer_approachable_6"].ToString() == "3")
            {
                RadioButton38.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["trainer_approachable_6"].ToString() == "4")
            {
                RadioButton39.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["trainer_approachable_6"].ToString() == "5")
            {
                RadioButton40.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["trainer_approachable_6"].ToString() == "6")
            {
                RadioButton41.Checked = true;
            }
            else
            {
                RadioButton42.Checked = true;
            }




            if (ds.Tables[0].Rows[0]["training_content_7"].ToString() == "1")
            {
                RadioButton43.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["training_content_7"].ToString() == "2")
            {
                RadioButton44.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["training_content_7"].ToString() == "3")
            {
                RadioButton45.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["training_content_7"].ToString() == "4")
            {
                RadioButton46.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["training_content_7"].ToString() == "5")
            {
                RadioButton47.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["training_content_7"].ToString() == "6")
            {
                RadioButton48.Checked = true;
            }
            else
            {
                RadioButton49.Checked = true;
            }




            if (ds.Tables[0].Rows[0]["balance_between_presentation_involvement_8"].ToString() == "1")
            {
                RadioButton50.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["balance_between_presentation_involvement_8"].ToString() == "2")
            {
                RadioButton51.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["balance_between_presentation_involvement_8"].ToString() == "3")
            {
                RadioButton52.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["balance_between_presentation_involvement_8"].ToString() == "4")
            {
                RadioButton53.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["balance_between_presentation_involvement_8"].ToString() == "5")
            {
                RadioButton54.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["balance_between_presentation_involvement_8"].ToString() == "6")
            {
                RadioButton55.Checked = true;
            }
            else
            {
                RadioButton56.Checked = true;
            }




            if (ds.Tables[0].Rows[0]["doubts_answered_9"].ToString() == "1")
            {
                RadioButton57.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["doubts_answered_9"].ToString() == "2")
            {
                RadioButton58.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["doubts_answered_9"].ToString() == "3")
            {
                RadioButton59.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["doubts_answered_9"].ToString() == "4")
            {
                RadioButton60.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["doubts_answered_9"].ToString() == "5")
            {
                RadioButton61.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["doubts_answered_9"].ToString() == "6")
            {
                RadioButton62.Checked = true;
            }
            else
            {
                RadioButton63.Checked = true;
            }

            Text4.Text = ds.Tables[0].Rows[0]["suggestiion_for_improvement_program_10"].ToString();
            Text1.Text = ds.Tables[0].Rows[0]["faculty_description"].ToString();
            Text2.Text = ds.Tables[0].Rows[0]["any_other"].ToString(); 
        }

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewfeedback.aspx");
    }
}