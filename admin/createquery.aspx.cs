using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_createquery : System.Web.UI.Page
{
    string UserCode, RoleId = "";
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        UserCode = Session["empcode"].ToString();
        RoleId = Session["role"].ToString();
        if (!IsPostBack)
        {
            bindDepartments();
            bindCreatedQuery();
            btnUpdate.Visible = false;
            lblheadingedit.Visible = false;
        }
    }

    private void bindDepartments()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select pquery_Id,parntquery_name from tbl_master_parent_queryType where status=1";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDeptName.DataSource = ds;
                ddlDeptName.DataTextField = "parntquery_name";
                ddlDeptName.DataValueField = "pquery_Id";
                ddlDeptName.DataBind();
                ddlDeptName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlDeptName.SelectedIndex = 0;
        txtQueryName.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool s = saverecords();

        if (s)
        {
            Common.Console.Output.Show("Created Successfully");
            reset();
        }
    }

    private bool saverecords()
    {
        var activity = new DataActivity();
        DataSet ds1 = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();

            SqlParameter[] newparameter = new SqlParameter[6];

            newparameter[0] = new SqlParameter("@deptId", SqlDbType.Int);
            newparameter[0].Value = ddlDeptName.SelectedIndex;

            newparameter[1] = new SqlParameter("@deptName", SqlDbType.VarChar, 100);
            newparameter[1].Value = ddlDeptName.SelectedItem.ToString();

            newparameter[2] = new SqlParameter("@queryName", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtQueryName.Text;

            newparameter[3] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
            newparameter[3].Value = UserCode;

            newparameter[4] = new SqlParameter("@action", SqlDbType.VarChar, 20);
            newparameter[4].Value = "Insert";

            newparameter[5] = new SqlParameter("@queryId", SqlDbType.Int);
            newparameter[5].Value = 0;

            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_insertORupdate_queryType", newparameter);
            bindCreatedQuery();
            return true;
        }
        catch (SqlException sql)
        {
            Common.Console.Output.Show("Some database error has been occured!");
            return false;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Show("Session has been expired! Please login again.");
            return false;
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void bindCreatedQuery()
    {
        string qry;
        DataSet ds3 = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            String empid = Session["empcode"].ToString();
            qry = "select query_Id,dept_Id,dept_name,query_name from tbl_master_queryType where status=1";
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, qry);
            gvQuery.DataSource = ds3;
            gvQuery.DataBind();
            Session["queryTypes"] = ds3;
        }
        catch (SqlException sql)
        {
            Common.Console.Output.Show(sql.Message);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Show(ex.Message);
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void reset()
    {
        ddlDeptName.SelectedIndex = 0;
        txtQueryName.Text = "";
    }
    protected void gvQuery_PreRender(object sender, EventArgs e)
    {
        if (gvQuery.Rows.Count > 0)
        {
            gvQuery.UseAccessibleHeader = true;
            gvQuery.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void gvQuery_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int selId = e.RowIndex;
        Label qryId = gvQuery.Rows[selId].Cells[0].Controls[0].FindControl("lblDeptId") as Label;
        selqryId = Convert.ToInt32(qryId.Text);
        bool d = DeleteRecords(selqryId);

        if (d)
        {
            Common.Console.Output.Show("Deleted Successfully");
            reset();
        }
    }

    private bool DeleteRecords(int selectedId)
    {
        string query1;
        DataSet ds4 = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            String empid = Session["empcode"].ToString();
            query1 = "update tbl_master_queryType set status=0 where query_Id=" + selectedId + "";
            ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, query1);
            bindCreatedQuery();
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            return true;
        }
        catch (SqlException sql)
        {
            Common.Console.Output.Show("Some database error has been occured!");
            return false;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Show("Session has been expired! Please login again.");
            return false;
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool u = UpdateRecords();
        if (u)
        {
            Common.Console.Output.Show("Updated Successfully");
            reset();
        }
    }

    private bool UpdateRecords()
    {
        //int qryID = Convert.ToInt32(Request.QueryString["query_Id"]);
        int qryid = (int)ViewState["qryIdForUpd"];
        DataSet ds2 = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();

            SqlParameter[] newparameter = new SqlParameter[6];

            newparameter[0] = new SqlParameter("@deptId", SqlDbType.Int);
            newparameter[0].Value = ddlDeptName.SelectedIndex;

            newparameter[1] = new SqlParameter("@deptName", SqlDbType.VarChar, 100);
            newparameter[1].Value = ddlDeptName.SelectedItem.ToString();

            newparameter[2] = new SqlParameter("@queryName", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtQueryName.Text;

            newparameter[3] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
            newparameter[3].Value = UserCode;

            newparameter[4] = new SqlParameter("@action", SqlDbType.VarChar, 20);
            newparameter[4].Value = "Update";

            newparameter[5] = new SqlParameter("@queryId", SqlDbType.Int);
            newparameter[5].Value = qryid;

            ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_insertORupdate_queryType", newparameter);
            bindCreatedQuery();
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            lblheadingcreate.Visible = true;
            lblheadingedit.Visible = false;
            return true;
        }
        catch (SqlException sql)
        {
            Common.Console.Output.Show("Some database error has been occured!");
            return false;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Show("Session has been expired! Please login again.");
            return false;
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    int selqryId;

    protected void gvQuery_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int seldId = e.NewEditIndex;
        //int Tid = Convert.ToInt32(grdtravelper.DataKeys[e.RowIndex].Value);
        Label qryId = gvQuery.Rows[seldId].Cells[0].Controls[0].FindControl("lblDeptId") as Label;
        selqryId = Convert.ToInt32(qryId.Text);
        ViewState["qryIdForUpd"] = selqryId;
        string query1;
        DataSet ds4 = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            String empid = Session["empcode"].ToString();
            query1 = "select dept_Id,dept_name,query_name from tbl_master_queryType where query_Id=" + selqryId + "";
            ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, query1);
            bindCreatedQuery();
        }
        catch (SqlException sql)
        {
            Common.Console.Output.Show("Some database error has been occured!");
            return;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Show("Session has been expired! Please login again.");
            return;
        }
        finally
        {
            activity.CloseConnection();
        }

        ddlDeptName.SelectedIndex = Convert.ToInt32(ds4.Tables[0].Rows[0]["dept_Id"]);
        txtQueryName.Text = ds4.Tables[0].Rows[0]["query_name"].ToString();
        lblheadingcreate.Visible = false;
        lblheadingedit.Visible = true;
        btnSubmit.Visible = false;
        btnUpdate.Visible = true;
    }
}