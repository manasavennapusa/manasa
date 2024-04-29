using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_createquestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else

                Response.Redirect("~/notlogged.aspx");
            bind_ddlsubject();
            bindGrid();


            if (Request.QueryString["id"] != null)
            {
                bindinfomation();
                //btnadd.Text = "Update";
                btnclear.Text = "Cancel";
                lblheader.Text = "EDIT QUESTION";
            }
            else
            {
                //btnadd.Text = "Add";
                btnclear.Text = "Clear";
                lblheader.Text = "CREATE QUESTION";
            }
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



    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (chk_A.Checked || chk_B.Checked || chk_C.Checked || chk_D.Checked || chk_E.Checked)
        {
            if (Request.QueryString["id"] != null)
            {
               update_Question();
            }
            else
            {
               insert_Question();
            }
            bindGrid();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please Select Correct Answer');", true);

        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createquestion.aspx");
        }


    }

    protected void insert_Question()
    {
        SqlParameter[] sqlParam = new SqlParameter[20];

        sqlParam[0] = new SqlParameter("@subject_id", SqlDbType.Int);
        sqlParam[0].Value = ddl_subject.SelectedValue;

        sqlParam[1] = new SqlParameter("@sub_subject_name", SqlDbType.VarChar, 50);
        sqlParam[1].Value = ddl_sub_subject.SelectedValue;

        sqlParam[2] = new SqlParameter("@category_name", SqlDbType.VarChar, 50);
        sqlParam[2].Value = ddl_category.SelectedValue;

        sqlParam[3] = new SqlParameter("@question_desc", SqlDbType.VarChar, 500);
        sqlParam[3].Value = txt_ques_dec.Text;

        sqlParam[4] = new SqlParameter("@option_a_desc", SqlDbType.VarChar, 250);
        sqlParam[4].Value = txt_optionA.Text;

        sqlParam[5] = new SqlParameter("@option_b_desc", SqlDbType.VarChar, 250);
        sqlParam[5].Value = txt_optionB.Text;

        sqlParam[6] = new SqlParameter("@option_c_desc", SqlDbType.VarChar, 250);
        sqlParam[6].Value = txt_optionC.Text;

        sqlParam[7] = new SqlParameter("@option_d_desc", SqlDbType.VarChar, 250);
        sqlParam[7].Value = txt_optionD.Text;

        sqlParam[8] = new SqlParameter("@option_e_desc", SqlDbType.VarChar, 250);
        sqlParam[8].Value = txt_optionE.Text;

        sqlParam[9] = new SqlParameter("@option_a", SqlDbType.Bit);
        if (chk_A.Checked == true)
            sqlParam[9].Value = true;
        else
            sqlParam[9].Value = false;
        sqlParam[10] = new SqlParameter("@option_b", SqlDbType.Bit);
        if (chk_B.Checked == true)
            sqlParam[10].Value = true;
        else
            sqlParam[10].Value = false;

        sqlParam[11] = new SqlParameter("@option_c", SqlDbType.Bit);
        if (chk_C.Checked == true)
            sqlParam[11].Value = true;
        else
            sqlParam[11].Value = false;

        sqlParam[12] = new SqlParameter("@option_d", SqlDbType.Bit);
        if (chk_D.Checked == true)
            sqlParam[12].Value = true;
        else
            sqlParam[12].Value = false;

        sqlParam[13] = new SqlParameter("@option_e", SqlDbType.Bit);
        if (chk_E.Checked == true)
            sqlParam[13].Value = true;
        else
            sqlParam[13].Value = false;

        sqlParam[14] = new SqlParameter("@marks", SqlDbType.Int);
        sqlParam[14].Value = txt_marks.Text;

        sqlParam[15] = new SqlParameter("@active", SqlDbType.Bit);
        if (rbtnlactive.SelectedIndex == -1)
            sqlParam[15].Value = System.Data.SqlTypes.SqlBoolean.Null;
        else
            sqlParam[15].Value = rbtnlactive.SelectedValue;

        sqlParam[16] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
        sqlParam[16].Value = Session["empcode"].ToString();

        sqlParam[17] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlParam[17].Value = DateTime.Now;

        sqlParam[18] = new SqlParameter("@status", SqlDbType.TinyInt);
        sqlParam[18].Value = 1;

        sqlParam[19] = new SqlParameter("@flag", SqlDbType.TinyInt);
        sqlParam[19].Value = 1;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_question]", sqlParam);
        if (i < 0)
        {
            message.InnerHtml = "Qualification Name is already exists try another name.";
        }
        else
        {
            message.InnerHtml = "Qualification Name is insert Successfully.";
            clear();
        }
    }

    protected void update_Question()
    {

        SqlParameter[] sqlParam = new SqlParameter[17];

        sqlParam[0] = new SqlParameter("@subject_id", SqlDbType.Int);
        sqlParam[0].Value = ddl_subject.SelectedValue;

        sqlParam[1] = new SqlParameter("@sub_subject_name", SqlDbType.VarChar, 50);
        sqlParam[1].Value = ddl_sub_subject.SelectedValue;

        sqlParam[2] = new SqlParameter("@category_name", SqlDbType.VarChar, 50);
        sqlParam[2].Value = ddl_category.SelectedValue;

        sqlParam[3] = new SqlParameter("@question_desc", SqlDbType.VarChar, 500);
        sqlParam[3].Value = txt_ques_dec.Text;

        sqlParam[4] = new SqlParameter("@option_a_desc", SqlDbType.VarChar, 250);
        sqlParam[4].Value = txt_optionA.Text;

        sqlParam[5] = new SqlParameter("@option_b_desc", SqlDbType.VarChar, 250);
        sqlParam[5].Value = txt_optionB.Text;

        sqlParam[6] = new SqlParameter("@option_c_desc", SqlDbType.VarChar, 250);
        sqlParam[6].Value = txt_optionC.Text;

        sqlParam[7] = new SqlParameter("@option_d_desc", SqlDbType.VarChar, 250);
        sqlParam[7].Value = txt_optionD.Text;

        sqlParam[8] = new SqlParameter("@option_e_desc", SqlDbType.VarChar, 250);
        sqlParam[8].Value = txt_optionE.Text;

        sqlParam[9] = new SqlParameter("@option_a", SqlDbType.Bit);
        if (chk_A.Checked == true)
            sqlParam[9].Value = true;
        else
            sqlParam[9].Value = false;
        sqlParam[10] = new SqlParameter("@option_b", SqlDbType.Bit);
        if (chk_B.Checked == true)
            sqlParam[10].Value = true;
        else
            sqlParam[10].Value = false;

        sqlParam[11] = new SqlParameter("@option_c", SqlDbType.Bit);
        if (chk_C.Checked == true)
            sqlParam[11].Value = true;
        else
            sqlParam[11].Value = false;

        sqlParam[12] = new SqlParameter("@option_d", SqlDbType.Bit);
        if (chk_D.Checked == true)
            sqlParam[12].Value = true;
        else
            sqlParam[12].Value = false;

        sqlParam[13] = new SqlParameter("@option_e", SqlDbType.Bit);
        if (chk_E.Checked == true)
            sqlParam[13].Value = true;
        else
            sqlParam[13].Value = false;

        sqlParam[14] = new SqlParameter("@marks", SqlDbType.Int);
        sqlParam[14].Value = txt_marks.Text;

        sqlParam[15] = new SqlParameter("@active", SqlDbType.Bit);
        if (rbtnlactive.SelectedIndex == -1)
            sqlParam[15].Value = System.Data.SqlTypes.SqlBoolean.Null;
        else
            sqlParam[15].Value = rbtnlactive.SelectedValue;

        sqlParam[16] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[16].Value = Convert.ToInt32(Request.QueryString["id"]);


        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_question]", sqlParam);
        if (i < 0)
        {
            message.InnerHtml = "Qualification Name is already exists try another name.";
        }
        else
        {
            //message.InnerHtml = "Skill Name is Updated Successfully.";
            Response.Redirect("createquestion.aspx?updated=true");
            clear();
        }

    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_question_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_subject.SelectedValue = ds.Tables[0].Rows[0]["subject_id"].ToString();
        ddl_sub_subject.SelectedValue = ds.Tables[0].Rows[0]["sub_subject_name"].ToString();
        ddl_category.SelectedValue = ds.Tables[0].Rows[0]["category_name"].ToString();
        txt_ques_dec.Text = ds.Tables[0].Rows[0]["question_desc"].ToString();
        txt_optionA.Text = ds.Tables[0].Rows[0]["option_a_desc"].ToString();
        txt_optionB.Text = ds.Tables[0].Rows[0]["option_b_desc"].ToString();
        txt_optionC.Text = ds.Tables[0].Rows[0]["option_c_desc"].ToString();
        txt_optionD.Text = ds.Tables[0].Rows[0]["option_d_desc"].ToString();
        txt_optionE.Text = ds.Tables[0].Rows[0]["option_e_desc"].ToString();
        if (ds.Tables[0].Rows[0]["option_a"].ToString() == "True")
            chk_A.Checked = true;
        else
            chk_A.Checked = false;
        if (ds.Tables[0].Rows[0]["option_b"].ToString() == "True")
            chk_B.Checked = true;
        else
            chk_B.Checked = false;
        if (ds.Tables[0].Rows[0]["option_c"].ToString() == "True")
            chk_C.Checked = true;
        else
            chk_C.Checked = false;
        if (ds.Tables[0].Rows[0]["option_d"].ToString() == "True")
            chk_D.Checked = true;
        else
            chk_D.Checked = false;
        if (ds.Tables[0].Rows[0]["option_e"].ToString() == "True")
            chk_E.Checked = true;
        else
            chk_E.Checked = false;
        txt_marks.Text = ds.Tables[0].Rows[0]["marks"].ToString();
        rbtnlactive.SelectedValue = ds.Tables[0].Rows[0]["active"].ToString().ToLower();

    }


    private void clear()
    {
        ddl_subject.SelectedValue = "0";
        ddl_sub_subject.SelectedValue = "0";
        ddl_category.SelectedValue = "0";
        txt_ques_dec.Text = "";
        txt_optionA.Text = "";
        txt_optionB.Text = "";
        txt_optionC.Text = "";
        txt_optionD.Text = "";
        txt_optionE.Text = "";
        txt_marks.Text = "";
        chk_A.Checked = false;
        chk_B.Checked = false;
        chk_C.Checked = false;
        chk_D.Checked = false;
        chk_E.Checked = false;
        rbtnlactive.SelectedIndex = -1;

    }

    protected void bind_ddlsubject()
    {
        string sqlstr = "select id,subject_name,sub_subject_name from tbl_recruitment_subject_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_subject.DataTextField = "subject_name";
        ddl_subject.DataValueField = "id";
        ddl_subject.DataSource = ds;
        ddl_subject.DataBind();
        ddl_subject.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_sub_subject.DataTextField = "sub_subject_name";
        ddl_sub_subject.DataValueField = "id";
        ddl_sub_subject.DataSource = ds;
        ddl_sub_subject.DataBind();
        ddl_sub_subject.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
}