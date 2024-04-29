using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class Reimbursement_PendingClosed : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DA = new DataActivity();
    int rid;
    string UserCode;
    string type;
    decimal total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        rid = Convert.ToInt32(Request.QueryString["rid"].ToString());
        if (Session["empcode"] != null)
        {
            UserCode = Session["empcode"].ToString();
            // type = Session["type"].ToString();
            if (Request.QueryString["rid"] != null)
            {
                BindReimDetails();
                BindReimApproversListDetails();
                BindAllDetails();
            }

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    private void BindAllDetails()
    {
        SqlParameter[] parm = new SqlParameter[1];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;

        try
        {
            Output.AssignParameter(parm, 0, "@rid", "Int", 0, rid.ToString());
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_get_reimbursement_LM_Details", parm);
            grdreim.DataSource = ds.Tables[2];
            grdreim.DataBind();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }

    private void BindReimDetails()
    {
        SqlParameter[] parm = new SqlParameter[1];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;

        try
        {
            Output.AssignParameter(parm, 0, "@rid", "Int", 0, rid.ToString());
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_get_reimbursement_LM_Details", parm);
            grd.DataSource = ds;
            grd.DataBind();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }
    //By using the below method I am fetching Approvers details
    private void BindReimApproversListDetails()
    {
        SqlParameter[] parm = new SqlParameter[1];
        SqlConnection Connection = null;

        try
        {

            Output.AssignParameter(parm, 0, "@rid", "String", 50, rid.ToString());
            Connection = DA.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_rmb_approverslist_proc", parm);
            grdvapprovers.DataSource = ds;
            grdvapprovers.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }

    protected void grd_PreRender(object sender, EventArgs e)
    {
        if (grd.Rows.Count > 0)
        {
            grd.UseAccessibleHeader = true;
            grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }



    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAttachment = (Label)e.Row.FindControl("lblAttachment");
            Label aViewFile = (Label)e.Row.FindControl("aViewFile");

            if (lblAttachment.Text.Trim() == "No File")
            {
                lblAttachment.Text = "No File";
                lblAttachment.Visible = false;
            }
            else
                aViewFile.Text = "View File";
            lblAttachment.Visible = false;
            //if (lblAttachment.Text.Trim() == "No File")
            //{
            //    aViewFile.Text = "No File";
            //    aViewFile.Visible = false;
            //}
            //else
            //    lblAttachment.Text = "View File";
            //lblAttachment.Visible = false;


            total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Ammount"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalammount = (Label)e.Row.FindControl("lbltotalammount");
            lbltotalammount.Text = total.ToString();
            lbltotalammount.Font.Bold = true;
        }
    }

    protected void brnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Linemanegerapprove.aspx?updated=true");
    }

}