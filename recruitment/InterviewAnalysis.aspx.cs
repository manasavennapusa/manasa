using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Configuration;
using Common.Console;

public partial class recruitment_InterviewAnalysis : System.Web.UI.Page
{
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            bindgrid();
            bindddlrrfcode();
        }
        if (Request.QueryString["Submit"] != null)
        {
            Output.Show("Submitted Successfully.");
        }
    }

    protected void bindddlrrfcode()
    {
        // string sqlstr = "select * from tbl_recruitment_requisition_form";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
        ddlrrfcode.DataTextField = "newrffcode";
        ddlrrfcode.DataValueField = "id";
        ddlrrfcode.DataSource = ds;
        ddlrrfcode.DataBind();
        ddlrrfcode.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //protected void ddlrrfcode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlrrfcode.SelectedValue != "0")
    //    {
    //        int id = Convert.ToInt32(ddlrrfcode.SelectedValue);
    //        SqlParameter[] sqlParam = new SqlParameter[1];

    //        //Output.AssignParameter(sqlParam, 0, "@id", "Int", 0, id.ToString());
    //        //Output.AssignParameter(sqlParam, 1, "@empcode", "String", 50, UserCode);

    //        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
    //        sqlParam[0].Value = id;

    //        //string sqlstr = "select * from tbl_recruitment_requisition_form where id='" + id + "'";
    //        DataSet ds = new DataSet();
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_for_Round2byRRFCODE", sqlParam);
    //        grdcandidates.DataSource = ds;
    //        grdcandidates.DataBind();
    //        //foreach (GridViewRow row in grdcandidates.Rows)
    //        //{
    //        //    DropDownList drpstatus = (DropDownList)row.FindControl("ddlstatus");
    //        //    drpstatus.SelectedValue = ((Label)row.FindControl("lblstatus")).Text;

    //        //    TextBox marks = (TextBox)row.FindControl("txtmarks");
    //        //    marks.Text = ((Label)row.FindControl("lblmarks2")).Text;
    //        //}
    //        //bind_ddlpaper();
    //    }
    //    else
    //    {
    //        bindgrid();
    //    }
    //}

    //protected void bind_ddlpaper()
    //{
    //    string sqlstr = "select id,papercode,papername from tbl_recruitment_paper_master";
    //    DataSet ds = new DataSet();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //    foreach (GridViewRow row in grdcandidates.Rows)
    //    {
    //        DropDownList ddlpaper = (DropDownList)row.FindControl("ddlpaper");
    //        ddlpaper.DataTextField = "papername";
    //        ddlpaper.DataValueField = "id";
    //        ddlpaper.DataSource = ds;
    //        ddlpaper.DataBind();
    //        ddlpaper.Items.Insert(0, new ListItem("---Select---", "0"));
    //    }
    //}

    protected void bindgrid()
    {

        SqlParameter[] param = new SqlParameter[1];

        Output.AssignParameter(param, 0, "@empcode", "String", 50, UserCode);
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_for_finalround", param);
        grdcandidates.DataSource = ds;
        grdcandidates.DataBind();
    }

    protected void lbtnview_Command(object sender, CommandEventArgs e)
    {
        string filepath = e.CommandArgument.ToString();
        Session["FileData"] = Server.MapPath("~/recruitment/upload/" + filepath);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Script", " JavaScript:newPopup1('viewresume.aspx');", true);
    }

    //protected void btnSelect_Click(object sender, EventArgs e)
    //{

    //}
    protected void grdcandidates_PreRender(object sender, EventArgs e)
    {
        if (grdcandidates.Rows.Count > 0)
        {
            grdcandidates.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void ddlrrfcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrrfcode.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddlrrfcode.SelectedValue);
            SqlParameter[] sqlParam = new SqlParameter[2];

            Output.AssignParameter(sqlParam, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(sqlParam, 1, "@empcode", "String", 50, UserCode);

            //string sqlstr = "select * from tbl_recruitment_requisition_form where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_finalround_topanel", sqlParam);
            grdcandidates.DataSource = ds;
            grdcandidates.DataBind();
        }
    }
}