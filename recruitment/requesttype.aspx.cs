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

public partial class recruitment_requesttype : System.Web.UI.Page
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
            btnreset.Text = "Cancel";
            //bindGrid(Request.QueryString["Id"].ToString());
        }
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

    protected void editrequesttype()
    {
        SqlParameter[] parm = new SqlParameter[4];

        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);

            Output.AssignParameter(parm, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 1, "@requesttype", "String", 50, txtrequesttype.Text);
            Output.AssignParameter(parm, 2, "@description", "String", 500, txtdesc.Text);
            Output.AssignParameter(parm, 3, "@updateby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_requesttype]", parm);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Updated. Please contact system admin. For error details please go through the log file.");
        }

        if (Flag > 0)
        {
            txtrequesttype.Text = "";
            txtdesc.Text = "";
            Response.Redirect("requesttype.aspx?update=true");
        }
        else
        {
            Output.Show("Request Type Already Exists,Try Another Name");
        }

    }

    protected void bindGrid2()
    {
        //lblhead.Text = "Create Request Type ";
        lblhead.Text = "Create";
        sqlstr = "select * from tbl_recruitment_requesttype";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdRequesttype.DataSource = ds;
        grdRequesttype.DataBind();
    }

    protected void BindTbl()
    {

        if (Request.QueryString["Id"] != null)
        {
            grdRequesttype.Visible = false;
            viewgrid.Visible = false;
            lblhead.Text = "Edit";
            int ID = Convert.ToInt32(Request.QueryString["Id"]);
            sqlstr = "select * from tbl_recruitment_requesttype where id='" + ID + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtrequesttype.Text = ds.Tables[0].Rows[0]["requesttype"].ToString();
            txtdesc.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        else
        {
            bindGrid2();
        }
    }

    protected void insertrequesttype()
    {
        SqlParameter[] parm = new SqlParameter[3];
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@requesttype", "String", 50, txtrequesttype.Text);
            Output.AssignParameter(parm, 1, "@description", "String", 100, txtdesc.Text);
            Output.AssignParameter(parm, 2, "@createby", "String", 50, UserCode);
            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_requesttype]", parm);
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
            Output.Show("Created Successfully");
            txtrequesttype.Text = "";
            txtdesc.Text = "";
            bindGrid2();
        }
    }

    protected void grdRequesttype_PreRender(object sender, EventArgs e)
    {
        if (grdRequesttype.Rows.Count > 0)
        {
            grdRequesttype.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    //protected override void OnInit(EventArgs e)
    //{
    //    InitializeComponents();
    //    base.OnInit(e);
    //}


    //private void InitializeComponents()
    //{
    //    grdRequesttype.RowDeleting += new GridViewDeleteEventHandler(grdRequesttype_RowDeleting);
    //}
  
    protected void grdRequesttype_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdRequesttype.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_requesttype where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Deleted Successfully");
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
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtrequesttype.Text = "";
        txtdesc.Text = "";
    }

}