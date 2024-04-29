using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;

public partial class createsubject : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //    Response.Redirect("~/Authenticate.aspx");
        }
        else

            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            bindGrid();

            if (Request.QueryString["id"] != null)
            {
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
            }
            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Updated Successfully");
            }
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


    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            update_Subject();
        }
        else
        {
            insert_Subject();
        }
        bindGrid();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createsubject.aspx");
        }


    }

    protected void insert_Subject()
    {
        SqlParameter[] sqlParam = new SqlParameter[3];
        int i = 0;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@subject_name", "String", 50, txt_subname.Text);
            Output.AssignParameter(sqlParam, 1, "@sub_subject_name", "String", 50, txt_sub_subject.Text);
            Output.AssignParameter(sqlParam, 2, "@createby", "String", 50, UserCode);

            i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_subject]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        if (i <= 0)
        {
            Output.Show("Function Area is already exists try another name.");
        }
        else
        {
            Output.Show("Created Successfully");
            cleartext();
        }
    }

    protected void update_Subject()
    {
        SqlParameter[] sqlParam = new SqlParameter[4];
        int i = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@subject_name", "String", 50, txt_subname.Text);
            Output.AssignParameter(sqlParam, 1, "@sub_subject_name", "String", 50, txt_sub_subject.Text);
            Output.AssignParameter(sqlParam, 2, "@updateby", "String", 50, UserCode);
            Output.AssignParameter(sqlParam, 3, "@id", "Int", 0, id.ToString());

            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_subject]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through Log file.");
        }

        if (i < 0)
        {
            Output.Show("Function Area is already exists try another name.");
        }
        else
        {
            Response.Redirect("createsubject.aspx?updated=true");
            cleartext();
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_subject_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_subname.Text = ds.Tables[0].Rows[0]["subject_name"].ToString();
        txt_sub_subject.Text = ds.Tables[0].Rows[0]["sub_subject_name"].ToString();

    }


    private void cleartext()
    {
        //txt_subcode.Text = "";
        txt_subname.Text = "";
        txt_sub_subject.Text = "";
    }

    protected void grdsubject_PreRender(object sender, EventArgs e)
    {
        if (grdsubject.Rows.Count > 0)
        {
            grdsubject.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

  

    protected void grdsubject_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdsubject.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_subject_master where id=" + ChildMenu;
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