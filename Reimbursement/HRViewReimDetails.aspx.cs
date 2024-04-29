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

public partial class Reimbursement_HRViewReimDetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DA = new DataActivity();
    int rid;
    string UserCode;
    decimal total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            UserCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {

                if (Request.QueryString["rid"] != null)
                {
                    rid = Convert.ToInt32(Request.QueryString["rid"].ToString());
                    hdnrid.Value = rid.ToString();
                    BindReimDetails();
                }
            }
        }
    }

    private void BindReimDetails()
    {
        SqlParameter[] parm = new SqlParameter[1];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;

        try
        {
            Output.AssignParameter(parm, 0, "@rid", "Int", 0, hdnrid.Value);
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_get_reimbursement_LM_Details", parm);
            grd.DataSource = ds;
            grd.DataBind();
            lbltype.Text = ds.Tables[1].Rows[0]["Type"].ToString();
            lblorginal.Text = ds.Tables[0].Rows[0]["Ammount"].ToString();
            if (ds.Tables[1].Rows[0]["Type"].ToString() == "1")
            {
                lblfinalammount.Text = ds.Tables[1].Rows[0]["FinalAmmount"].ToString();
                lblcomments.Text = ds.Tables[1].Rows[0]["Comments"].ToString();
                txtfinalammount.Visible = false;
                lblfinalammount.Visible = true;
                txtdesc.Visible = false;
                lblcomments.Visible = true;
                btnproceed.Visible = true;
                btnapprove.Visible = false;
                btnreject.Visible = false;
            }
            else
            {
                txtfinalammount.Visible = true;
                lblfinalammount.Visible = false;
                txtdesc.Visible = true;
                lblcomments.Visible = false;
                btnproceed.Visible = false;
                btnapprove.Visible = true;
                btnreject.Visible = true;
            }
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

    protected void grd_PreRender(object sender, EventArgs e)
    {
        if (grd.Rows.Count > 0)
        {
            grd.UseAccessibleHeader = true;
            grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {
        if (Finalaamount() == true)
        {
        SqlParameter[] parm = new SqlParameter[5];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@rid", "Int", 0, hdnrid.Value);
            Output.AssignParameter(parm, 1, "@finalammount", "Decimal", 50, txtfinalammount.Text);
            Output.AssignParameter(parm, 2, "@comments", "String", 200, txtdesc.Text);
            Output.AssignParameter(parm, 3, "@raisedby", "String", 50, UserCode);
            Output.AssignParameter(parm, 4, "@flag", "Int", 0, "1");
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_Update_reimbursement_HR", parm);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Approved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
            Output.Show("Reimbursement Approved");
            Response.Redirect("HRPendingReimbursement.aspx?updated=true");
            ScriptManager.RegisterStartupScript(updatepanel2, updatepanel2.GetType(), "RefeshWindow", "RefeshWindow();", true);
            btnreject.Enabled = false;
            btnapprove.Enabled = false;
            BindReimDetails();
        }

             }
        else
        {
            Output.Show("Enter Valid Amount");
        }
    }
    private bool Finalaamount()
    {
        Decimal Final, Orginal;
        Label lblammount = grd.FooterRow.FindControl("lbltotalammount") as Label;
        Orginal = Convert.ToDecimal(lblammount.Text);
        Final = Convert.ToDecimal(txtfinalammount.Text);
        if (Orginal >= Final)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Clearfeilds()
    {
        txtdesc.Text = "";
    }
    protected void btnreject_Click(object sender, EventArgs e)
    {

        SqlParameter[] parm = new SqlParameter[5];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@rid", "Int", 0, hdnrid.Value);
            Output.AssignParameter(parm, 1, "@finalammount", "Decimal", 50, txtfinalammount.Text);
            Output.AssignParameter(parm, 2, "@comments", "String", 200, txtdesc.Text);
            Output.AssignParameter(parm, 3, "@raisedby", "String", 50, UserCode);
            Output.AssignParameter(parm, 4, "@flag", "Int", 0, "0");

            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_Update_reimbursement_HR", parm);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Rejected. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
            Output.Show("Reimbursement Rejected");
            Response.Redirect("HRPendingReimbursement.aspx?updated1=true");
            ScriptManager.RegisterStartupScript(updatepanel2, updatepanel2.GetType(), "RefeshWindow", "RefeshWindow();", true);
           
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

            total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Ammount"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalammount = (Label)e.Row.FindControl("lbltotalammount");
            lbltotalammount.Text = total.ToString();

            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            lblTotal.Text = "Total";
        }
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        String str = null;
        try
        {

            str = @"update tbl_Rb_Reimbursement set Level=3 where RID=" + hdnrid.Value + "";
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Approved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
            Output.Show("Transaction Compeleted Successfully");
            Response.Redirect("HRPendingReimbursement.aspx?updated=true");
            ScriptManager.RegisterStartupScript(updatepanel2, updatepanel2.GetType(), "RefeshWindow", "RefeshWindow();", true);
            btnreject.Enabled = false;
            btnapprove.Enabled = false;
            BindReimDetails();
        }

    }
}