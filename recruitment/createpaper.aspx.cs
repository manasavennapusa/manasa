using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;

public partial class createpaper : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else

                Response.Redirect("~/notlogged.aspx");
            bindGrid();
            bindsubject();

            if (Request.QueryString["id"] != null)
            {
                trpapercode.Visible = true;
                bindinfomation();
                btnadd.Text = "Update";
                btnclear.Text = "Cancel";
                lblheader.Text = "Edit";
                viewgrid.Visible = false;
            }
            else
            {
                btnadd.Text = "Submit";
                btnclear.Text = "Reset";
                lblheader.Text = "Create";
                trpapercode.Visible = false;
            }

            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Updated Successfully");
            }

        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select p.id, p.papercode,p.papername,p.maximummarks,p.passmarks,p.papertype,p.duration,sub.subject_name as subjectid from tbl_recruitment_paper_master p inner join tbl_recruitment_subject_master sub on p.subjectid= sub.id";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdpaper.DataSource = ds;
        grdpaper.DataBind();

    }


    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            update_Paper();
        }
        else
        {
            insert_Paper();
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createpaper.aspx");
        }


    }

    protected void insert_Paper()
    {
        SqlParameter[] sqlParam = new SqlParameter[10];
        int i = 0;
        try
        {
            sqlParam[0] = new SqlParameter("@subjectid", SqlDbType.Int);
            sqlParam[0].Value = ddl_subject.SelectedValue;

            sqlParam[1] = new SqlParameter("@maximummarks", SqlDbType.Int);
            if (txt_maximummarks.Text == "")
                sqlParam[1].Value = System.Data.SqlTypes.SqlInt32.Null;
            else
                sqlParam[1].Value = txt_maximummarks.Text;

            sqlParam[2] = new SqlParameter("@duration", SqlDbType.Int);
            if (txt_duration.Text == "")
                sqlParam[2].Value = System.Data.SqlTypes.SqlInt32.Null;
            else
                sqlParam[2].Value = txt_duration.Text;

            sqlParam[3] = new SqlParameter("@passmarks", SqlDbType.VarChar, 500);
            if (txt_passmarks.Text == "")
                sqlParam[3].Value = System.Data.SqlTypes.SqlInt32.Null;
            else
                sqlParam[3].Value = txt_passmarks.Text;

            sqlParam[4] = new SqlParameter("@papertype", SqlDbType.Int);
            sqlParam[4].Value = ddl_type.SelectedValue;

            sqlParam[5] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            sqlParam[5].Value = Session["empcode"].ToString();

            sqlParam[6] = new SqlParameter("@createddate", SqlDbType.DateTime);
            sqlParam[6].Value = DateTime.Now;

            sqlParam[7] = new SqlParameter("@status", SqlDbType.TinyInt);
            sqlParam[7].Value = 1;

            sqlParam[8] = new SqlParameter("@flag", SqlDbType.TinyInt);
            sqlParam[8].Value = 1;

            sqlParam[9] = new SqlParameter("@papername", SqlDbType.VarChar, 50);
            sqlParam[9].Value = txt_papername.Text;

            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_paper]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file");
        }
        if (i < 0)
        {
            Output.Show("Paper is already exists try another name");
        }
        else
        {
            Output.Show("Created Successfully");
            clear();
            bindGrid();
        }
    }

    protected void update_Paper()
    {
        SqlParameter[] sqlParam = new SqlParameter[7];
        int i = 0;
        try
        {
            sqlParam[0] = new SqlParameter("@subjectid", SqlDbType.Int);
            sqlParam[0].Value = ddl_subject.SelectedValue;

            sqlParam[1] = new SqlParameter("@maximummarks", SqlDbType.Int);
            if (txt_maximummarks.Text == "")
                sqlParam[1].Value = System.Data.SqlTypes.SqlInt32.Null;
            else
                sqlParam[1].Value = txt_maximummarks.Text;

            sqlParam[2] = new SqlParameter("@duration", SqlDbType.Int);
            if (txt_duration.Text == "")
                sqlParam[2].Value = System.Data.SqlTypes.SqlInt32.Null;
            else
                sqlParam[2].Value = txt_duration.Text;

            sqlParam[3] = new SqlParameter("@passmarks", SqlDbType.VarChar, 500);
            if (txt_passmarks.Text == "")
                sqlParam[3].Value = System.Data.SqlTypes.SqlInt32.Null;
            else
                sqlParam[3].Value = txt_passmarks.Text;

            sqlParam[4] = new SqlParameter("@papertype", SqlDbType.Int);
            sqlParam[4].Value = ddl_type.SelectedValue;

            sqlParam[5] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[5].Value = Convert.ToInt32(Request.QueryString["id"]);

            sqlParam[6] = new SqlParameter("@papername", SqlDbType.VarChar, 50);
            sqlParam[6].Value = txt_papername.Text;

            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_paper]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not updated. Please contact system admin. For error details please go through log file.");
        }
        if (i < 0)
        {
            Output.Show("Paper Name already exists try another name");
        }
        else
        {
            //message.InnerHtml = "Skill Name is Updated Successfully.";
            Response.Redirect("createpaper.aspx?updated=true");
            clear();
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_paper_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_subject.SelectedValue = ds.Tables[0].Rows[0]["subjectid"].ToString();
        txt_maximummarks.Text = ds.Tables[0].Rows[0]["maximummarks"].ToString();
        txt_duration.Text = ds.Tables[0].Rows[0]["duration"].ToString();
        txt_passmarks.Text = ds.Tables[0].Rows[0]["passmarks"].ToString();
        ddl_type.SelectedValue = ds.Tables[0].Rows[0]["papertype"].ToString();
        lblpaperid.Text = ds.Tables[0].Rows[0]["papercode"].ToString();
        txt_papername.Text = ds.Tables[0].Rows[0]["papername"].ToString();
    }
    protected void clear()
    {
        lblpaperid.Text = "";
        ddl_subject.SelectedValue = "0";
        ddl_type.SelectedValue = "0";
        txt_duration.Text = "";
        txt_maximummarks.Text = "";
        txt_passmarks.Text = "";
        txt_papername.Text = "";
    }


    protected void bindsubject()
    {
        string sqlstr = "   select * from tbl_recruitment_subject_master ";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_subject.DataValueField = "id";
        ddl_subject.DataTextField = "subject_name";
        ddl_subject.DataSource = ds;
        ddl_subject.DataBind();
        ddl_subject.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void grdpaper_PreRender(object sender, EventArgs e)
    {
        if (grdpaper.Rows.Count > 0)
        {
            grdpaper.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }


    protected void grdpaper_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdpaper.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_paper_master where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Deleted Successfully");
                bindGrid();
            }
            else
            {
                Output.Show("Please select the record...");
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
}