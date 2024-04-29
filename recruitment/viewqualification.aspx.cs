using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_viewqualification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
            bindddlqualification();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Qualification Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_qualification_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdSkills.DataSource = ds;
        grdSkills.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("createqualification.aspx");
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdSkills.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = true;
        }
    }
    protected void btnDeselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdSkills.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdSkills.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");

                string sqlstr = "delete from tbl_recruitment_qualification_master where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }
    protected void ddl_Qualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Qualification.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddl_Qualification.SelectedValue);
            string sqlstr = "select * from tbl_recruitment_qualification_master where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdSkills.DataSource = ds;
            grdSkills.DataBind();
        }
        else
        {
            bindGrid();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string qualification = txt_qualifixation.Text;

        string sqlstr = "select * from tbl_recruitment_qualification_master where edu_name like '%"+ qualification+"%'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdSkills.DataSource = ds;
        grdSkills.DataBind();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txt_qualifixation.Text = "";
    }

    protected void bindddlqualification()
    {
        string sqlstr = "select * from tbl_recruitment_qualification_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_Qualification.DataTextField = "edu_name";
        ddl_Qualification.DataValueField = "id";
        ddl_Qualification.DataSource = ds;
        ddl_Qualification.DataBind();
        ddl_Qualification.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}