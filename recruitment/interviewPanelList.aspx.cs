using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_interviewPanelList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
            bindddl_panel();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Panel Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_panel_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdPanel.DataSource = ds;
        grdPanel.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("createpanel.aspx");
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdPanel.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = true;
        }
    }
    protected void btnDeselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdPanel.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdPanel.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");

                string sqlstr = "delete from tbl_recruitment_panel_master where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string panel = txt_search.Text;

        string sqlstr = "select * from tbl_recruitment_panel_master where Panelname like '%" + panel + "%'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdPanel.DataSource = ds;
        grdPanel.DataBind();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txt_search.Text = "";
        ddl_panel.SelectedValue = "0";
    }

    protected void bindddl_panel()
    {
        string sqlstr = "select * from tbl_recruitment_panel_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_panel.DataTextField = "Panelname";
        ddl_panel.DataValueField = "id";
        ddl_panel.DataSource = ds;
        ddl_panel.DataBind();
        ddl_panel.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddl_panel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_panel.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddl_panel.SelectedValue);
            string sqlstr = "select * from tbl_recruitment_panel_master where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdPanel.DataSource = ds;
            grdPanel.DataBind();
        }
        else
        {
            bindGrid();
        }
    }
  
}