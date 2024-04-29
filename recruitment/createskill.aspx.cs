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

public partial class createskill : System.Web.UI.Page
{   
    string UserCode;
    string sqlstr;
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

        //message.InnerHtml = "";
        if (!IsPostBack)
        {
            bindGrid();

            if (Request.QueryString["id"] != null)
            {
                trcode.Visible = true;
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

    private void cleartext()
    {
        txt_skillname.Text = "";
        txt_code.Text = "";
        txt_desc.Text = "";
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            update_Skill();
        }
        else
        {
            insertSkill();
        }
        bindGrid();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createskill.aspx");
        }

    }

    protected void insertSkill()
    {
        SqlParameter[] sqlParam = new SqlParameter[3];

        int Flag = 0;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@skill_name", "String", 100, txt_skillname.Text);
            Output.AssignParameter(sqlParam, 1, "@skill_desc", "String", 50, txt_desc.Text);
            Output.AssignParameter(sqlParam, 2, "@createby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_skill]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        if (Flag < 0)
        {
            Output.Show("Skill Name is already exists try another name.");
        }
        else
        {
            Output.Show("Created Successfully");
            cleartext();
        }
    }

    protected void update_Skill()
    {
        SqlParameter[] sqlParam = new SqlParameter[4];

        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(sqlParam, 1, "@skill_name", "String", 100, txt_skillname.Text);
            Output.AssignParameter(sqlParam, 2, "@skill_desc", "String", 50, txt_desc.Text);
            Output.AssignParameter(sqlParam, 3, "@updateby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recriutment_update_skill]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not updated. Please contact system admin. For error details please go through log file.");
        }

        if (Flag < 0)
        {
            Output.Show("Skill Name is already exists try another name.");
        }
        else
        {
            //message.InnerHtml = "Skill Name is Updated Successfully.";
            Response.Redirect("createskill.aspx?updated=true");
            cleartext();
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_skillmaster where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_code.Text = ds.Tables[0].Rows[0]["code"].ToString();
        txt_skillname.Text = ds.Tables[0].Rows[0]["skill_name"].ToString();
        txt_desc.Text = ds.Tables[0].Rows[0]["skill_desc"].ToString();
    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_skillmaster";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdSkills.DataSource = ds;
        grdSkills.DataBind();

    }

    protected void grdSkills_PreRender(object sender, EventArgs e)
    {
        if (grdSkills.Rows.Count > 0)
        {
            grdSkills.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }


    protected void grdSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdSkills.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_skillmaster  where id=" + ChildMenu;
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