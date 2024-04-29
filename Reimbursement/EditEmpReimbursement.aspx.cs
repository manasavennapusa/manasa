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

public partial class Reimbursement_EditEmpReimbursement : System.Web.UI.Page
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
            rid = Convert.ToInt32(Request.QueryString["rid"].ToString());
            UserCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                if (Request.QueryString["rid"] != null)
                {
                    BindReimDetails();
                }
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
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
            lblcommnets.Text = ds.Tables[1].Rows[0]["Comments"].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = ds;
                grd.DataBind();
            }
            else
            {
                Output.Show("NO Data Found");
                ScriptManager.RegisterStartupScript(updatepanel2, updatepanel2.GetType(), "RefeshWindow", "RefeshWindow();", true);

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
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Ammount"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalammount = (Label)e.Row.FindControl("lbltotalammount");
            lbltotalammount.Text = total.ToString();
        }
    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            string str = @"update tbl_Rb_Reimbursement set Level=1,IsReject=0 where   RID=" + rid.ToString() + "";
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            int flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Deleted. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
            Output.Show("Reimbursement Submitted Successfully");
            ScriptManager.RegisterStartupScript(updatepanel2, updatepanel2.GetType(), "RefeshWindow", "RefeshWindow();", true);
            BindReimDetails();
            DA.CloseConnection();
        }
    }
    protected void grd_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grd.EditIndex = e.NewEditIndex;
        BindReimDetails();
    }
    protected void grd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grd.EditIndex = -1;
        BindReimDetails();
    }
    protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtammount = (TextBox)grd.Rows[e.RowIndex].FindControl("txtammount");
        FileUpload fp = (FileUpload)grd.Rows[e.RowIndex].FindControl("fpup");
        Label file = (Label)grd.Rows[e.RowIndex].FindControl("lblAttachment1");
        Label lbl1 = (Label)grd.Rows[e.RowIndex].FindControl("lbl1");
        string defaultUpload1 = "";
        if (fp.HasFile)
        {
            string strFileName;
            string file_name = lbl1.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fp.FileName;
            try
            {
                fp.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload1 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);

            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            defaultUpload1 = file.Text;

        }

        int id = Convert.ToInt32(grd.DataKeys[e.RowIndex].Values[0]);
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {

            string str = @"update tbl_Rb_Reimbursement_Details set Ammount=" + txtammount.Text + ", Attachment='" + defaultUpload1 + "'  where   RDID=" + id + "";
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            int flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Updated. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            grd.EditIndex = -1;
            BindReimDetails();
            DA.CloseConnection();
        }
    }
    protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(grd.DataKeys[e.RowIndex].Values[0]);
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            string str = @"update tbl_Rb_Reimbursement_Details set Status=0 where   RDID=" + id + "";
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            int flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Deleted. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Output.Show("Reimbursement Deleted Sucessfully");
            grd.EditIndex = -1;
            BindReimDetails();
            DA.CloseConnection();
        }
    }
}