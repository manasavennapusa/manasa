using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_paperSetList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
            bindddl_paper();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Panel Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select p.id, p.papercode,p.noofquestion,p.passmarks,p.papertype,p.duration,sub.subject_code as subjectid from tbl_recruitment_paper_master p inner join tbl_recruitment_subject_master sub on p.subjectid= sub.id";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdpaper.DataSource = ds;
        grdpaper.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("createpaper.aspx");
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdpaper.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = true;
        }
    }
    protected void btnDeselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdpaper.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdpaper.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");

                string sqlstr = "delete from tbl_recruitment_paper_master where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string subcode = txt_search.Text;

        string sqlstr = "select p.id, p.papercode,p.noofquestion,p.passmarks,p.papertype,p.duration,sub.subject_code as subjectid from tbl_recruitment_paper_master p inner join tbl_recruitment_subject_master sub on p.subjectid= sub.id where sub.subject_code like '%" + subcode + "%'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdpaper.DataSource = ds;
        grdpaper.DataBind();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void bindddl_paper()
    {
        string sqlstr = "select * from tbl_recruitment_paper_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_paper.DataTextField = "Papercode";
        ddl_paper.DataValueField = "id";
        ddl_paper.DataSource = ds;
        ddl_paper.DataBind();
        ddl_paper.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddl_paper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_paper.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddl_paper.SelectedValue);
            string sqlstr = "select p.id, p.papercode,p.noofquestion,p.passmarks,p.papertype,p.duration,sub.subject_code as subjectid from tbl_recruitment_paper_master p inner join tbl_recruitment_subject_master sub on p.subjectid= sub.id where p.id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdpaper.DataSource = ds;
            grdpaper.DataBind();
        }
        else
        {
            bindGrid();
        }
    }

    private void cleartext()
    {
        txt_search.Text = "";
        ddl_paper.SelectedValue = "0";
    }
}