using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class recruitment_createexpectedctc : System.Web.UI.Page
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
            bindgrid();

            if (Request.QueryString["id"] != null)
            {
                bindtbl();
            }
            if (Request.QueryString["update"] != null)
            {
                Output.Show("Updated Successfully");
            }
        }
        if (Request.QueryString["id"] == null)
        {
            btnSubmit.Text = "Submit";

        }
        else
        {
            btnSubmit.Text = "Update";
            btnreset.Text = "Cancel";
            viewgrid.Visible = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            updateCTCrange();
        }
        else
        {
            insertCTCrange();
        }
    }

    protected void bindgrid()
    {
        sqlstr = "select * from tbl_recruitment_expctc_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdCTCrange.DataSource = ds;
        grdCTCrange.DataBind();
    }

    protected void bindtbl()
    {

        if (Request.QueryString["id"] != null)
        {
            lblhead.Text = "Edit";
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            sqlstr = "select * from tbl_recruitment_expctc_master where id='" + ID + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtctcrange.Text = ds.Tables[0].Rows[0]["expectedCTC"].ToString();
            txtdesc.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        else
        {
            bindgrid();
        }
    }

    protected void insertCTCrange()
    {
        SqlParameter[] sqlparam = new SqlParameter[3];

        int flag = 0;
        try
        {
            Output.AssignParameter(sqlparam, 0, "@expectedCTC", "String", 100, txtctcrange.Text);
            Output.AssignParameter(sqlparam, 1, "@description", "String", 500, txtdesc.Text);
            Output.AssignParameter(sqlparam, 2, "createby", "String", 50, UserCode);

            flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_expectedctc]", sqlparam);

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During Validation:" + ex.Message + ". " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        if (flag < 0)
        {
            Output.Show("CTC range already exists try another CTC range");
        }
        else
        {
            Output.Show("Created Successfully");
            cleartext();
            bindgrid();
        }
    }

    protected void updateCTCrange()
    {
        SqlParameter[] sqlParam = new SqlParameter[4];

        int flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(sqlParam, 1, "@expectedCTC", "String", 100, txtctcrange.Text);
            Output.AssignParameter(sqlParam, 2, "@description", "String", 500, txtdesc.Text);
            Output.AssignParameter(sqlParam, 3, "@updateby", "String", 50, UserCode);

            flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_expectedCTC]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During Validation:" + ex.Message + ". " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }

        if (flag > 0)
        {
            txtctcrange.Text = "";
            txtdesc.Text = "";
            Response.Redirect("createexpectedctc.aspx?update=true");
        }
        else
        {
            Output.Show("CTC Range Already Exists,Try Another Name");
        }
    }

    protected void grdCTCrange_PreRender(object sender, EventArgs e)
    {
        if (grdCTCrange.Rows.Count > 0)
        {
            grdCTCrange.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    private void cleartext()
    {
        txtctcrange.Text = "";
        txtdesc.Text = "";
     
    }
    protected void grdCTCrange_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdCTCrange.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_expctc_master where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Deleted Successfully");
                bindgrid();
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtctcrange.Text = "";
        txtdesc.Text = "";
    }
}