using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;

public partial class recruitment_registrationformForExternalReference : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
               // Response.Redirect("~/Authenticate.aspx");
        }
        else

            Response.Redirect("~/notlogged.aspx");
    }

    private void cleartext()
    {
        txt_achievements.Text = "";
        txt_Address.Text = "";
        txt_candidateName.Text = "";
        txt_Dob.Text = "";
        txt_email.Text = "";
        txt_experience.Text = "";
        txt_skills.Text = "";
        txt_expSalary.Text = "";
        txt_joinstatus.Text = "";
        txt_mobileno.Text = "";
        txt_comments.Text = "";
        txt_passportno.Text = "";
        txt_passportvalidity.Text = "";
        txt_phoneno.Text = "";
        txt_Qualifications.Text = "";
        txt_relation.Text = "";
        txt_reasonsofref.Text = "";
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        insertdata();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void insertdata()
    {
        string resume = "";
        if (fp_resume.HasFile)
        {
            string strFileName;
            string file_name = "RES" + System.DateTime.Now.GetHashCode().ToString();

            strFileName = fp_resume.FileName;
            try
            {
                fp_resume.PostedFile.SaveAs(Server.MapPath("~/recruitment/upload/" + file_name + "_" + strFileName));
                resume = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            resume = "";
        }
        
        SqlParameter[] sqlparam = new SqlParameter[20];

        sqlparam[0] = new SqlParameter("@candidate_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_candidateName.Text;

        sqlparam[1] = new SqlParameter("@dob", SqlDbType.DateTime);
        sqlparam[1].Value = txt_Dob.Text;

        sqlparam[2] = new SqlParameter("@candidate_address", SqlDbType.VarChar, 1000);
        sqlparam[2].Value = txt_Address.Text;

        sqlparam[3] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
        sqlparam[3].Value = txt_phoneno.Text;

        sqlparam[4] = new SqlParameter("@mobile", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_mobileno.Text;

        sqlparam[5] = new SqlParameter("@emailid", SqlDbType.VarChar, 50);
        sqlparam[5].Value = txt_email.Text;

        sqlparam[6] = new SqlParameter("@Qualification", SqlDbType.VarChar, 50);
        sqlparam[6].Value = txt_Qualifications.Text;

        sqlparam[7] = new SqlParameter("@skills", SqlDbType.VarChar, 1000);
        sqlparam[7].Value = txt_skills.Text;

        sqlparam[8] = new SqlParameter("@experience", SqlDbType.VarChar, 20);
        sqlparam[8].Value = txt_experience.Text;

        sqlparam[9] = new SqlParameter("@joinstatus", SqlDbType.Int);
        sqlparam[9].Value = txt_joinstatus.Text;

        sqlparam[10] = new SqlParameter("@expectedsalary", SqlDbType.Decimal, 20);
        sqlparam[10].Value = txt_expSalary.Text;

        sqlparam[11] = new SqlParameter("@referredby", SqlDbType.VarChar, 50);
        sqlparam[11].Value = "Referral";

        sqlparam[12] = new SqlParameter("@referrername", SqlDbType.VarChar, 50);
        sqlparam[12].Value = Session["empcode"].ToString();

        sqlparam[13] = new SqlParameter("@achievements", SqlDbType.VarChar, 1000);
        sqlparam[13].Value = txt_achievements.Text;

        sqlparam[14] = new SqlParameter("@uploadresume", SqlDbType.VarChar, 50);
        sqlparam[14].Value = resume;

        sqlparam[15] = new SqlParameter("@passportno", SqlDbType.VarChar, 50);
        sqlparam[15].Value = txt_passportno.Text;

        sqlparam[16] = new SqlParameter("@passportvalidity", SqlDbType.VarChar, 50);
        sqlparam[16].Value = txt_passportvalidity.Text;

        sqlparam[17] = new SqlParameter("@note", SqlDbType.VarChar, 1000);
        sqlparam[17].Value = txt_comments.Text;

        sqlparam[18] = new SqlParameter("@relation_to_referrer", SqlDbType.VarChar, 50);
        sqlparam[18].Value = txt_relation.Text;

        sqlparam[19] = new SqlParameter("@reasons_of_referrence", SqlDbType.VarChar, 500);
        sqlparam[19].Value = txt_reasonsofref.Text;


        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_referral_candidate", sqlparam);


        if (i <= 0)
        {
            Output.Show("Candidate Name already exists, please enter another");
        }
        else
        {
            Output.Show("Registration form submitted successfully");
            cleartext();
        }
    }
}