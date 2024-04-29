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

public partial class training_trainingmaster : System.Web.UI.Page
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
        btncalcel.Visible=false;

        if (!IsPostBack)
        {
            bindGrid2();

            if (Request.QueryString["Id"] != null)
            {
                BindTbl();
            }
            if (Request.QueryString["update"] != null)
            {
                Output.Show("Updated Successfully");
            }

        }

        if (Request.QueryString["Id"] == null)
        {
            btnSubmit.Text = "Submit";

        }
        else
        {
            btnSubmit.Text = "Update";
            btncalcel.Visible = true;
            btnreset.Visible = false;
            tbl_view.Visible = false;
            //bindGrid(Request.QueryString["Id"].ToString());
        }
        if (Request.QueryString["del"] != null)
        {
            Output.Show("Deleted Successfully");
        }
    }

    private void BindTbl()
    {
        if (Request.QueryString["Id"] != null)
        {
            lblhead.Text = "Edit";
            int ID = Convert.ToInt32(Request.QueryString["Id"]);
            sqlstr = "select * from tbl_training_master where id='" + ID + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txttrainingcode.Text = ds.Tables[0].Rows[0]["training_type_id"].ToString();
            txttrainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
        }
        else
        {
            bindGrid2();
        }
    }

    private void bindGrid2()
    {
        lblhead.Text = "Create";
        sqlstr = "select * from tbl_training_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        gridtrainingtype.DataSource = ds;
        gridtrainingtype.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["Id"] == null)
        {
            insertrequesttype();
        }
        else
        {
            editrequesttype();
        }

    }

    private void editrequesttype()
    {
        SqlParameter[] parm = new SqlParameter[4];

        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);

            Output.AssignParameter(parm, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 1, "@training_type_id", "String", 10, txttrainingcode.Text);
            Output.AssignParameter(parm, 2, "@training_name", "String", 50, txttrainingname.Text);
            Output.AssignParameter(parm, 3, "@updatedby", "String", 30, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_training_master_update", parm);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Updated. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            if (Flag > 0)
            {
                txttrainingcode.Text = "";
                txttrainingname.Text = "";
                Response.Redirect("trainingmaster.aspx?update=true");
            }
            else
            {
                Output.Show("Training Type Already Exists,Try Another Name");
            }
        }
    }

    private void insertrequesttype()
    {
        SqlParameter[] parm = new SqlParameter[3];
        int Flag = 0;
        try
        {           
            Output.AssignParameter(parm, 0, "@training_type_id", "String", 10, txttrainingcode.Text);
            Output.AssignParameter(parm, 1, "@training_name", "String", 50, txttrainingname.Text);
            Output.AssignParameter(parm, 2, "@createdby", "String", 30, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_training_master", parm);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }

        if (Flag <= 0)
        {
            Output.Show("Request Type already exists, please enter another name");
        }
        else
        {
            Output.Show("Submitted Successfully");
            txttrainingcode.Text = "";
            txttrainingname.Text = "";
            bindGrid2();
        }
    }

    protected void gridtrainingtype_PreRender(object sender, EventArgs e)
    {
        if (gridtrainingtype.Rows.Count > 0)
        {
            gridtrainingtype.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    protected void gridtrainingtype_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)gridtrainingtype.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_training_master where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                bindGrid2();
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
            Response.Redirect("trainingmaster.aspx?del=true");
        }
    }     

    protected void btnreset_Click(object sender, EventArgs e)
    {
        txttrainingcode.Text = "";
        txttrainingname.Text = "";
    }

    protected void btncalcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("trainingmaster.aspx");
    }

}