using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_questionList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindGrid();
            bind_ddlsubsubject();
        }

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Question is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select q.id, q.category_name,q.question_code,q.question_desc,q.option_a,q.option_b,q.option_c,q.option_d,q.option_e,q.marks,q.active,q.option_a_desc,q.option_b_desc,q.option_c_desc,q.option_d_desc,q.option_e_desc,s.sub_subject_name,s.subject_name from tbl_recruitment_question_master q inner join tbl_recruitment_subject_master s on q.subject_id=s.id ";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdQuestion.DataSource = ds;
        grdQuestion.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("createquestion.aspx");
    }


    protected void btnselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdQuestion.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = true;
        }
    }


    protected void btnDeselectall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdQuestion.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            ChkBoxRows.Checked = false;
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdQuestion.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");

                string sqlstr = "delete from tbl_recruitment_question_master where id='" + id.Value + "'";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            }
        }
        bindGrid();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txt_search.Text != "" || ddl_subsubject.SelectedValue != "0" || ddl_category.SelectedValue != "0")
        {
            string question_code = txt_search.Text;
            string sub_subject_name = ddl_subsubject.SelectedValue;
            string category_name = ddl_category.SelectedValue;
            string sqlstr;
            //---question code and sub subject and category
            if (txt_search.Text != "" && ddl_subsubject.SelectedValue != "0" && ddl_category.SelectedValue != "0")
                sqlstr = "select * from tbl_recruitment_question_master where question_code like '%" + question_code + "%' and sub_subject_name  like '%" + sub_subject_name + "%' and category_name  like '%" + category_name + "%'";
            //---question code and sub subject 

            else if (txt_search.Text != "" && ddl_subsubject.SelectedValue != "0" )
                sqlstr = "select * from tbl_recruitment_question_master where question_code like '%" + question_code + "%' and sub_subject_name  like '%" + sub_subject_name + "%'";

            //---sub subject and category
            else if ( ddl_subsubject.SelectedValue != "0" && ddl_category.SelectedValue != "0")
                sqlstr = "select * from tbl_recruitment_question_master where  sub_subject_name  like '%" + sub_subject_name + "%' and category_name  like '%" + category_name + "%'";

            //---question code and category
            else if (txt_search.Text != "" &&  ddl_category.SelectedValue != "0")
                sqlstr = "select * from tbl_recruitment_question_master where question_code like '%" + question_code + "%'  and category_name  like '%" + category_name + "%'";

            //---question code 
            else if (txt_search.Text != "" )
                sqlstr = "select * from tbl_recruitment_question_master where question_code like '%" + question_code + "%'";

            //---sub subject
            else if (ddl_subsubject.SelectedValue != "0")
                sqlstr = "select * from tbl_recruitment_question_master where  sub_subject_name  like '%" + sub_subject_name + "%'";

            //---category
                else if (ddl_category.SelectedValue != "0")
                sqlstr = "select * from tbl_recruitment_question_master where  category_name  like '%" + category_name + "%'";

            else
                sqlstr = "select * from tbl_recruitment_question_master";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdQuestion.DataSource = ds;
            grdQuestion.DataBind();
        }
    }


    protected void btnclear_Click(object sender, EventArgs e)
    {
        txt_search.Text = "";
        ddl_category.SelectedValue = "0";
        ddl_subsubject.SelectedValue = "0";
    }

    protected void bind_ddlsubsubject()
    {
        string sqlstr = "select id,subject_name,sub_subject_name from tbl_recruitment_subject_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_subsubject.DataTextField = "sub_subject_name";
        ddl_subsubject.DataValueField = "id";
        ddl_subsubject.DataSource = ds;
        ddl_subsubject.DataBind();
        ddl_subsubject.Items.Insert(0, new ListItem("--Select--", "0"));


    }


    protected void ddl_skillcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_subsubject.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddl_subsubject.SelectedValue);
            string sqlstr = "select * from tbl_recruitment_question_master where id= '" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdQuestion.DataSource = ds;
            grdQuestion.DataBind();
        }
        else
        {
            bindGrid();
        }
    }
}