using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_subjectList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindGrid();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Subject Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_subject_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdsubject.DataSource = ds;
        grdsubject.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("createsubject.aspx");
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdsubject.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = true;
        }
    }
    protected void btnDeselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdsubject.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdsubject.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");

                string sqlstr = "delete from tbl_recruitment_subject_master where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSubjectname.Text != "" || txtsub_Subjectname.Text != "")
        {
            string subject = txtSubjectname.Text;
            string sub_subject = txtsub_Subjectname.Text;
            string sqlstr;
            if (txtSubjectname.Text != "" && txtsub_Subjectname.Text != "")
                sqlstr = "select * from tbl_recruitment_subject_master where subject_name like '%"+subject+"%' or sub_subject_name like '%"+sub_subject+"%'";
            else if (txtSubjectname.Text != "")
                sqlstr = "select * from tbl_recruitment_subject_master where subject_name like '%" +subject+ "%'";
            else
                sqlstr = "select * from tbl_recruitment_subject_master where subject_name  sub_subject_name like '%"+sub_subject +"%'";
            DataSet dss = new DataSet();
            dss = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdsubject.DataSource = dss;
            grdsubject.DataBind();
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtSubjectname.Text = "";
        txtsub_Subjectname.Text = "";
    }



}