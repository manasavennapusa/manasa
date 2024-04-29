using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_interviewRoundsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindGrid();
            bindddl_round();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Round Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_round_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdrounds.DataSource = ds;
        grdrounds.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("createround.aspx");
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdrounds.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = true;
        }
    }
    protected void btnDeselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdrounds.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdrounds.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");

                string sqlstr = "delete from tbl_recruitment_round_master where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string round = txt_search.Text;

        string sqlstr = "select * from tbl_recruitment_round_master where round_name like '%"+round+"%'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdrounds.DataSource = ds;
        grdrounds.DataBind();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txt_search.Text = "";
        ddl_round.SelectedValue = "0";
    }

    protected void bindddl_round()
    {
        string sqlstr = "select * from tbl_recruitment_round_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_round.DataTextField = "round_name";
        ddl_round.DataValueField = "id";
        ddl_round.DataSource = ds;
        ddl_round.DataBind();
        ddl_round.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddl_round_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_round.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddl_round.SelectedValue);
            string sqlstr = "select * from tbl_recruitment_round_master where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdrounds.DataSource = ds;
            grdrounds.DataBind();
        }
        else
        {
            bindGrid();
        }
    }
  
}