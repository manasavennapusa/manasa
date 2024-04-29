using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_fillApplicants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else

                Response.Redirect("~/notlogged.aspx");

            if (Request.QueryString["id"] != null)
            {
                bindgrid();
            }
        }
    }
    protected void bindgrid()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_byID", sqlParam);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            lblnoposts.Text = ds.Tables[0].Rows[0]["total_no_posts"].ToString();
            lblfilledposts.Text = ds.Tables[0].Rows[0]["no_of_posts_filled"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["no_of_posts_filled"].ToString();
        }
        DataSet ds1 = new DataSet();
        ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_by_rrfID", sqlParam);
        grdvacancy.DataSource = ds1;
        grdvacancy.DataBind();
        ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates", sqlParam);
        Grdcandidates.DataSource = ds1;
        Grdcandidates.DataBind();
        
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["id"]);
        int count = 0;
        if (grdvacancy.Rows.Count > 0)
        {
            foreach (GridViewRow row in grdvacancy.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                if (chk.Checked)
                {
                    count++;
                    Label name = (Label)row.FindControl("lblname");
                }
            }
        }

        if (count > 0)
        {
            if (Convert.ToInt32(lblfilledposts.Text) + count <= Convert.ToInt32(lblnoposts.Text))
            {
               
                foreach (GridViewRow row in grdvacancy.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chk");
                    if (chk.Checked)
                    {
                        TextBox doj = (TextBox)row.FindControl("txt_doj");
                        HiddenField hdf = (HiddenField)row.FindControl("hdf");
                        string sqlstr2 = "update tbl_recruitment_candidate_interview set dateofjoin='" + doj.Text + "' where candidateid='" + hdf.Value + "'";
                        DataSet ds3 = new DataSet();
                        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                    }
                }
                string sqlstr = "update tbl_recruitment_requisition_form set no_of_posts_filled=coalesce(no_of_posts_filled,0)+'" + count + "' where id='" + id + "'";
                DataSet ds2 = new DataSet();
                ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                bindgrid();
            }
            else
            {
                message.InnerHtml = "Please check the Vacancies";
            }
        }

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("closeVacancy.aspx");
    }
}