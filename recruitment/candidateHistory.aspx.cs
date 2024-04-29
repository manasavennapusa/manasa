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

public partial class recruitment_candidateHistory : System.Web.UI.Page
{
    string _path;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != null)
            {
                bindDetails();
            }
        }
        _path = HttpContext.Current.Request.Url.AbsolutePath;
        bindlabel();
    }

    protected void bindlabel()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        Output.AssignParameter(sqlparam, 0, "@path", "String", 100, _path);
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ToString(), CommandType.StoredProcedure, "sp_getmenulable", sqlparam);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            lblheader.Text = ds.Tables[0].Rows[0]["menulist"].ToString();
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
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_confirmed_candidates_individual", sqlParam);

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
                txtround1marks.Text = ds.Tables[0].Rows[0]["round_1_marks"].ToString();
                lblround2marks.Text = ds.Tables[0].Rows[0]["round_2_marks"].ToString();
                if (ds.Tables[0].Rows[0]["round_1_status"].ToString() == "S")
                    txtround1status.Text = "Selected";
                else
                    txtround1status.Text = "Rejected";

                if (ds.Tables[0].Rows[0]["round_2_status"].ToString() == "S")
                    txtround2status.Text = "Selected";
                else
                    txtround2status.Text = "Rejected";

                if (ds.Tables[0].Rows[0]["status"].ToString() == "S")
                    txtianalysis.Text = "Selected";
                if (ds.Tables[0].Rows[0]["status"].ToString() == "P")
                    txtianalysis.Text = "Pending";
                else
                    txtianalysis.Text = "Rejected";

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("candidatereport.aspx");
    }
}