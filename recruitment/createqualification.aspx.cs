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

public partial class recruitment_createqualification : System.Web.UI.Page
{
    string UserCode;
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();    

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
        string sqlstr = "select * from tbl_recruitment_qualification_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdSkills.DataSource = ds;
        grdSkills.DataBind();

    }

    private void cleartext()
    {
        txt_qualification.Text = "";
        txt_desc.Text = "";

    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            update_Qualification();
        }
        else
        {
            insertQualification();
        }
        bindGrid();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createqualification.aspx");
        }

    }


    protected void insertQualification()
    {
        SqlParameter[] sqlParam = new SqlParameter[3];

        int i = 0;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@edu_name", "String", 100, txt_qualification.Text);
            Output.AssignParameter(sqlParam, 1, "@edu_desc", "String", 50, txt_desc.Text);
            Output.AssignParameter(sqlParam, 2, "@createby", "String", 50, UserCode);
            i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_qualification]", sqlParam);
        }

        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

        if (i < 0)
        {
            Output.Show("Qualification Name already exists try another name");
        }
        else
        {
            Output.Show("Created Successfully");
            cleartext();
        }
    }

    protected void update_Qualification()
    {

        SqlParameter[] sqlParam = new SqlParameter[4];
        int i = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(sqlParam, 1, "@edu_name", "String", 100, txt_qualification.Text);
            Output.AssignParameter(sqlParam, 2, "@edu_desc", "String", 50, txt_desc.Text);
            Output.AssignParameter(sqlParam, 3, "@updateby", "String", 50, UserCode);

            i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recriutment_update_qualification]", sqlParam);

            if (i <= 0)
            {
                Output.Show("Qualification Name is already exists try another name");
            }
            else
            {
                //message.InnerHtml = "Skill Name is Updated Successfully.";
                Response.Redirect("createqualification.aspx?updated=true");
                cleartext();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not updated. Please contact system admin. For error details please go through log file.");
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_qualification_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_qualification.Text = ds.Tables[0].Rows[0]["edu_name"].ToString();
        txt_desc.Text = ds.Tables[0].Rows[0]["edu_desc"].ToString();
    }

    protected void grdSkills_PreRender(object sender, EventArgs e)
    {
        if (grdSkills.Rows.Count > 0)
        {
            grdSkills.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        InitializeComponents();
        base.OnInit(e);
    }

    private void InitializeComponents()
    {      
        grdSkills.RowDeleting += new GridViewDeleteEventHandler(grdSkills_RowDeleting);
    }

    protected void grdSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdSkills.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_qualification_master where id=" + ChildMenu;
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