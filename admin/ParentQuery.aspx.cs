using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using DataAccessLayer;

public partial class Masters_ParentQuery : System.Web.UI.Page
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
            
            bindCreatedQuery();
            btnUpdate.Visible = false;
            lblheadingedit.Visible = false;
            lblheadingcreate.Visible = true;
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
            query1 = "update tbl_master_parent_queryType set status=0 where pquery_Id=" + selectedId + "";
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
    int selqryId;
    protected void gvQuery_RowEditing(object sender, GridViewEditEventArgs e)
    {
        btnReset.Text = "Cancel";
        lblheading.Text = "Edit";
        grid_query.Visible = false;
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
            query1 = "select pquery_Id, parntquery_name  from tbl_master_parent_queryType where pquery_Id=" + selqryId + "";
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


        txtparentquery.Text = ds4.Tables[0].Rows[0]["parntquery_name"].ToString();
        lblheadingcreate.Visible = false;
        lblheadingedit.Visible = true;
        btnSubmit.Visible = false;
        btnUpdate.Visible = true;
    }

    
    protected void gvQuery_PreRender(object sender, EventArgs e)
    {
        if (gvQuery.Rows.Count > 0)
        {
            gvQuery.UseAccessibleHeader = true;
            gvQuery.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
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

            SqlParameter[] newparameter = new SqlParameter[4];

            newparameter[0] = new SqlParameter("@parntquery_name", SqlDbType.VarChar, 1000);
            newparameter[0].Value = txtparentquery.Text;

            newparameter[1] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
            newparameter[1].Value = UserCode;

            newparameter[2] = new SqlParameter("@action", SqlDbType.VarChar, 20);
            newparameter[2].Value = "Insert";

            newparameter[3] = new SqlParameter("@queryId", SqlDbType.Int);
            newparameter[3].Value = 0;

            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_insertORupdate_parentqueryType", newparameter);
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
            qry = "select pquery_Id,parntquery_name from tbl_master_parent_queryType where status=1";
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
        txtparentquery.Text = "";
        grid_query.Visible = true;
        //btnReset.Text = "Reset";
        //btnSubmit.Text = "Submit";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool u = UpdateRecords();
        if (u)
        {
            Common.Console.Output.Show("Updated Successfully");
            reset();
        }
        grid_query.Visible = true;
        lblheading.Text = "Create";
        btnSubmit.Text = "Submit";
        btnReset.Text = "Reset";
        
    }
    private bool UpdateRecords()
    {
       
        int qryid = (int)ViewState["qryIdForUpd"];
        DataSet ds2 = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();

            SqlParameter[] newparameter = new SqlParameter[4];



            newparameter[0] = new SqlParameter("@parntquery_name", SqlDbType.VarChar, 1000);
            newparameter[0].Value = txtparentquery.Text;

            newparameter[1] = new SqlParameter("@created_by", SqlDbType.VarChar, 50);
            newparameter[1].Value = UserCode;

            newparameter[2] = new SqlParameter("@action", SqlDbType.VarChar, 20);
            newparameter[2].Value = "Update";

            newparameter[3] = new SqlParameter("@queryId", SqlDbType.Int);
            newparameter[3].Value = qryid;

            ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_insertORupdate_parentqueryType", newparameter);
            bindCreatedQuery();
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            lblheadingcreate.Visible=true;
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
    
    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (btnReset.Text == "Cancel")
        {
            Response.Redirect("ParentQuery.aspx");
        }
        else
        {
            reset();
        }
    }
}