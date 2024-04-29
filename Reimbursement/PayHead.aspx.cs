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


public partial class Reimbursement_PayHead : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            UserCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                BindGrid();

            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Request.QueryString["updated"] == "true")
        {
            SmartHr.Common.Alert("Deleted Successfully");
            
        }
        if (Request.QueryString["id"] != null)
        {
            btnsave.Text = "Update";
            grdpayhead.Visible = false; 
            lblhead.Text = "Edit ";

        }
        else
        {
            btnsave.Text = "Submit";
            grdpayhead.Visible = true;
            lblhead.Text = "Create ";
        }


        if (Request.QueryString["id"] == null)
        {
            VIEW.Visible = true;
            grdpayhead.Visible = true;
            btnreset.Text = "Reset";

        }
        else
        {
           
            btnreset.Text = "Cancel";
        }
    }

     

    private void BindGrid()
    {

        DataSet ds = new DataSet();
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_Rb_BindPayHead");
            grdpayhead.DataSource = ds;
            grdpayhead.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (ViewState["Pid"] != null)
        {
            Update(Convert.ToInt32(ViewState["Pid"]));
            btnsave.Text = "Submit";
            lblhead.Text = "Create ";
            btnreset.Text = "Reset";
            VIEW.Visible = true;
            grdpayhead.Visible = true;
        }
        else
        {
            Insert();
            BindGrid();
            clearfields();
        }
    }

    private void Insert()
    {
        SqlParameter[] parm = new SqlParameter[5];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@payheadname", "String", 50, txtpayhead.Text);
            Output.AssignParameter(parm, 1, "@description", "String", 2000, txtDescription.Text);
            if (chksubcat.Checked == true)
                Output.AssignParameter(parm, 2, "@isattach", "Int", 0, "1");
            else
                Output.AssignParameter(parm, 2, "@isattach", "Int", 0, "0");
            Output.AssignParameter(parm, 3, "@createby", "String", 50, UserCode);
            Output.AssignParameter(parm, 4, "@category", "Int", 0, ddlcategory.SelectedValue.ToString());
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_insert_payhead", parm);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Submitted Successfully");
            clearfields();
            BindGrid();
        }
        else
        {
            Output.Show("Payhead already exists");
        }
    }

    private void Update(int pid)
    {
        SqlParameter[] parm = new SqlParameter[6];  
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@payheadname", "String", 50, txtpayhead.Text);
            Output.AssignParameter(parm, 1, "@description", "String", 2000, txtDescription.Text);
            if (chksubcat.Checked == true)
                Output.AssignParameter(parm, 2, "@isattach", "Int", 0, "1");
            else
                Output.AssignParameter(parm, 2, "@isattach", "Int", 0, "0");
            Output.AssignParameter(parm, 3, "@createby", "String", 50, UserCode);
            Output.AssignParameter(parm, 4, "@category", "Int", 0, ddlcategory.SelectedValue.ToString());
            Output.AssignParameter(parm, 5, "@pid", "Int", 0, pid.ToString());

            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_update_payhead", parm);
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
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Updated Successfully");
           // btnsave.Text = "Submit";
           // btnreset.Text = "Reset";
            lblhead.Text = "Create ";
            VIEW.Visible = true;
            clearfields();
            BindGrid();
        }
        else
        {
            Output.Show("Updated Failed");
        }
    }

    private void clearfields()
    {
        ViewState["Pid"] = null;
        txtDescription.Text = "";
        txtpayhead.Text = "";
        chksubcat.Checked = false;
        ddlcategory.SelectedValue = "0";
    }
    protected void grdpayhead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int pid = Convert.ToInt32(grdpayhead.DataKeys[e.NewEditIndex].Value);
        BindTbl(pid);
        ViewState["Pid"] = pid;
        string countt = ViewState["Pid"].ToString();
      btnsave.Text = "Update";
        btnreset.Text = "Cancel";
        lblhead.Text = "Edit ";
        VIEW.Visible = false;
    }

    private void BindTbl(int pid)
    {
        SqlParameter[] parm = new SqlParameter[2];
        SqlConnection Connection = null;
        DataSet ds = new DataSet();
        try
        {
            Connection = DataActivity.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, @"select * from tbl_Rb_PayHead where status=1 and PID=" + pid + "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["Type"].ToString();
                txtpayhead.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["IsAttach"].ToString() == "1")
                    chksubcat.Checked = true;
                else
                    chksubcat.Checked = false;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    protected void grdpayhead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        String str;
        int pid = Convert.ToInt32(grdpayhead.DataKeys[e.RowIndex].Value);
        try
        {
            str = @"update tbl_Rb_PayHead set Status=0 where PID=" + pid + "";
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            throw ex;
        }
        finally
        {
            DataActivity.CloseConnection();
            BindGrid();
        }

        if (Flag > 0)
        {

            Output.Show("Deleted Successfully");
            Response.Redirect("PayHead.aspx?updated=true");
            BindGrid();
        }
        else
        {
            Output.Show("Deleted Failed");
        }
    }
    protected void grdpayhead_PreRender(object sender, EventArgs e)
    {
        //if (grdpayhead.Rows.Count > 0)
        //{
        //    grdpayhead.UseAccessibleHeader = true;
        //    grdpayhead.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
          
         clerr();
    }
    public void clerr()
    {
        if (Request.QueryString["id"] == null)
        {
            txtDescription.Text = "";
            txtpayhead.Text = "";
            VIEW.Visible = true;
            grdpayhead.Visible = true;
            ddlcategory.SelectedValue = "0";
        }
        else
        {
            Response.Redirect("PayHead.aspx");
           // VIEW.Visible = false;
        }
    }
}