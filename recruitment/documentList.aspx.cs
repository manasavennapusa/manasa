using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_documentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
            bindddl_document();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Document Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_document_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grddocument.DataSource = ds;
        grddocument.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("createdocument.aspx");
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grddocument.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = true;
        }
    }
    protected void btnDeselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grddocument.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grddocument.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");

                string sqlstr = "delete from tbl_recruitment_document_master where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string document = txt_documentname.Text;

        string sqlstr = "select * from tbl_recruitment_document_master where document_name like '%" + document + "%'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grddocument.DataSource = ds;
        grddocument.DataBind();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txt_documentname.Text = "";
        ddl_document.SelectedValue = "0";
    }

    protected void bindddl_document()
    {
        string sqlstr = "select * from tbl_recruitment_document_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_document.DataTextField = "document_name";
        ddl_document.DataValueField = "id";
        ddl_document.DataSource = ds;
        ddl_document.DataBind();
        ddl_document.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddl_document_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_document.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddl_document.SelectedValue);
            string sqlstr = "select * from tbl_recruitment_document_master where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grddocument.DataSource = ds;
            grddocument.DataBind();
        }
        else
        {
            bindGrid();
        }
    }
}