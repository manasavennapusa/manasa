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

public partial class createjobsite_consultancy : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        // message.InnerHtml = "";

        if (Session["role"] != null)
        {
          //  if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
               // Response.Redirect("~/Authenticate.aspx");
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            bindGrid();

            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Updated Successfully");
            }

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
        }

      

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_jobsite_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdjobsites.DataSource = ds;
        grdjobsites.DataBind();
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            updateConsultancy();
        }
        else
        {
            insertConsultancy();
        }
        bindGrid();
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createjobsite_consultancy.aspx");
        }
    }

    protected void insertConsultancy()
    {

        SqlParameter[] sqlParam = new SqlParameter[9];
        int Flag = 0;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@organizationname", "String", 100, txt_orgname.Text);
            Output.AssignParameter(sqlParam, 1, "@address", "String", 500, txt_address.Text);
            Output.AssignParameter(sqlParam, 2, "@contactperson", "String", 50, txt_contactperson.Text);
            Output.AssignParameter(sqlParam, 3, "@contactno", "String", 50, txt_contactno.Text);
            Output.AssignParameter(sqlParam, 4, "@email", "String", 50, txt_email.Text);
            Output.AssignParameter(sqlParam, 5, "@url", "String", 50, txt_url.Text);
            Output.AssignParameter(sqlParam, 6, "@orgtype", "String", 50, ddl_type.SelectedValue);
            Output.AssignParameter(sqlParam, 7, "@active", "Bool", 0, rbtnlactive.SelectedValue);
            Output.AssignParameter(sqlParam, 8, "@createby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_jobsite]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        if (Flag < 0)
        {
            Output.Show("Consultancy  already exists try another name.");
        }
        else
        {
            Output.Show("Created Successfully");
            clear();
        }
    }

    protected void updateConsultancy()
    {

        SqlParameter[] sqlParam = new SqlParameter[10];
        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@organizationname", "String", 100, txt_orgname.Text);
            Output.AssignParameter(sqlParam, 1, "@address", "String", 500, txt_address.Text);
            Output.AssignParameter(sqlParam, 2, "@contactperson", "String", 50, txt_contactperson.Text);
            Output.AssignParameter(sqlParam, 3, "@contactno", "String", 50, txt_contactno.Text);
            Output.AssignParameter(sqlParam, 4, "@email", "String", 50, txt_email.Text);
            Output.AssignParameter(sqlParam, 5, "@url", "String", 50, txt_url.Text);
            Output.AssignParameter(sqlParam, 6, "@orgtype", "String", 50, ddl_type.SelectedValue);
            Output.AssignParameter(sqlParam, 7, "@active", "Bool", 0, rbtnlactive.SelectedValue);
            Output.AssignParameter(sqlParam, 8, "@updateby", "String", 50, UserCode);
            Output.AssignParameter(sqlParam, 9, "@id", "Int", 0, id.ToString());

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_jobsite]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
            Output.Show("Record not updated.Please contact system admin. For error details please go through the log file.");
        }
        if (Flag < 0)
        {
            Output.Show("Consultancy/Job site Name  already exists try another name.");
        }
        else
        {
            //message.InnerHtml = "Skill Name is Updated Successfully.";
            Response.Redirect("createjobsite_consultancy.aspx?updated=true");
            clear();
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_jobsite_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_orgname.Text = ds.Tables[0].Rows[0]["organizationname"].ToString();
        txt_address.Text = ds.Tables[0].Rows[0]["address"].ToString();
        txt_contactperson.Text = ds.Tables[0].Rows[0]["contactperson"].ToString();
        txt_contactno.Text = ds.Tables[0].Rows[0]["contactno"].ToString();
        txt_email.Text = ds.Tables[0].Rows[0]["email"].ToString();
        txt_url.Text = ds.Tables[0].Rows[0]["url"].ToString();
        ddl_type.SelectedValue = ds.Tables[0].Rows[0]["orgtype"].ToString();
        rbtnlactive.SelectedValue = ds.Tables[0].Rows[0]["active"].ToString().ToLower();
    }

    protected void clear()
    {
        txt_orgname.Text = "";
        txt_contactperson.Text = "";
        txt_contactno.Text = "";
        txt_address.Text = "";
        txt_email.Text = "";
        ddl_type.SelectedValue = "0";
        rbtnlactive.SelectedIndex = -1;
        txt_url.Text = "";
    }


    protected void grdjobsites_PreRender(object sender, EventArgs e)
    {
        if (grdjobsites.Rows.Count > 0)
        {
            grdjobsites.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

   
    protected void grdjobsites_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdjobsites.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_jobsite_master  where id=" + ChildMenu;
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