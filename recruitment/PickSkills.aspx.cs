using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_PickSkills : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
            bindddlskillcode();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Skill Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_skillmaster";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdSkills.DataSource = ds;
        grdSkills.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        string selectedskills = "";
        foreach (GridViewRow row in grdSkills.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            Label skill = (Label)row.FindControl("lblskillname");
            
            if (ChkBoxRows.Checked == true)
            {
                selectedskills = selectedskills + skill.Text + " , ";
            }
        }
        if (selectedskills != "")
            selectedskills = selectedskills.Substring(0, selectedskills.Length - 2);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(up_skills, up_skills.GetType(), "Script", "selectSkills('"+selectedskills+"');", true); 
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

                string sqlstr = "delete from tbl_recruitment_skillmaster where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txt_search.Text != "")
        {
            string skill = txt_search.Text;
            string sqlstr = "select * from tbl_recruitment_skillmaster where skill_name like '%" + skill + "%'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdSkills.DataSource = ds;
            grdSkills.DataBind();
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txt_search.Text = "";
    }

    protected void bindddlskillcode()
    {
        string sqlstr = "select * from tbl_recruitment_skillmaster";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_skillcode.DataTextField = "code";
        ddl_skillcode.DataValueField = "id";
        ddl_skillcode.DataSource = ds;
        ddl_skillcode.DataBind();
        ddl_skillcode.Items.Insert(0, new ListItem("--Select Code--", "0"));
    }
    protected void ddl_skillcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_skillcode.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddl_skillcode.SelectedValue);
            string sqlstr = "select * from tbl_recruitment_skillmaster where id= '" + id + "'";
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
}