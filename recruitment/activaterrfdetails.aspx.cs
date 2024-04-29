using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.Data;
using DataAccessLayer;
using System.Configuration;

public partial class recruitment_activaterrfdetails : System.Web.UI.Page
{
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] == null)

            Response.Redirect("~/notlogged.aspx");


        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bindDetails();
            }
            bindholdDetails();
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

    protected void bindDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_holdrrf_details", sqlParam);
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

    protected void btnActivate_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlParam = new SqlParameter[2];
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@updatedby", "String", 50, UserCode);
            Output.AssignParameter(sqlParam, 1, "@rrf_id", "Int", 0, id.ToString());

            int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_rrfactivedetails]", sqlParam);

            Response.Write("<script>alert('Activated Successfully'); window.opener.location.reload(); window.close();</script>");
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }
}