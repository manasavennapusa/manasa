using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;


public partial class appraisal_AppraisalApprovers : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }


    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (ViewState["id"] != null)
        {
            EditApprover();
        }
        else
        {
            InsertApprover();
        }

    }

    protected void InsertApprover()
    {


        SqlParameter[] sqlParam = new SqlParameter[4];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, txt_employee.Text);
            Output.AssignParameter(sqlParam, 1, "@approver_code", "String", 50, txt_approver.Text);
            Output.AssignParameter(sqlParam, 2, "@approver_type", "String", 10, ddl_approvertype.SelectedValue);
            Output.AssignParameter(sqlParam, 3, "@create_by", "String", 50, Session["empcode"].ToString());

            Connection = DataActivity.OpenConnection();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "[sp_appraisal_insert_approver]", sqlParam);
            if (Flag <= 0)
            {
                Output.Show("Approver is already exists . please enter another Approver");
            }
            else
            {
                bindgrid();
                Clear();
                Output.Show("Approver  has been inserted successfully !");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }


    protected void EditApprover()
    {
        SqlParameter[] sqlParam = new SqlParameter[5];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(ViewState["id"].ToString());
            Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, txt_employee.Text);
            Output.AssignParameter(sqlParam, 1, "@approver_code", "String", 50, txt_approver.Text);
            Output.AssignParameter(sqlParam, 2, "@approver_type", "String", 10, ddl_approvertype.SelectedValue);
            Output.AssignParameter(sqlParam, 3, "@update_by", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlParam, 4, "@id", "Int", 0, id.ToString());

            Connection = DataActivity.OpenConnection();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "[sp_appraisal_update_approver]", sqlParam);
            if (Flag <= 0)
            {
                Output.Show("Approver is already exists . please enter another Approver");
            }
            else
            {
                Output.Show("Approver   has been updated successfully !");
                bindgrid();
                txt_employee.Text = "";
                Clear();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Clear();
        txt_employee.Text = "";
        gridapprovers.DataSource = null;
        gridapprovers.DataBind();
    }
    protected void gridapprovers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            int id = (int)gridapprovers.DataKeys[e.RowIndex].Value;
            string str = @"update tbl_appraisal_approvers set status=0 where id=" + id.ToString();
            int i = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, str);
            if (i > 0)
            {
                bindgrid();
                Output.Show("Approver is Deleted Successfully.");
            }
            else
            {
                Output.Show("Approver is not Deleted Successfully.");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }


    protected void Clear()
    {
        txt_approver.Text = "";
        ddl_approvertype.SelectedValue = "0";
        ViewState["id"] = null;
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            string str = @"select a.id, a.empcode, a.empcode+' - '+isnull(j1.emp_fname ,'')+' '+isnull( j1.emp_m_name,'')+ ' '+isnull( j1.emp_l_name,'') as Employee,
            a.approver_code, a.approver_code+' - '+isnull(j2.emp_fname ,'')+' '+isnull( j2.emp_m_name,'')+ ' '+isnull( j2.emp_l_name,'') as Approver, approver_type as type,
            case approver_type             when 'HR' then 'HR'        when 'LM' then 'Line Manager' when 'BH' then 'Business Head' when 'MD' then 'MD' when 'HRD' then 'HRD' end as approver_type
            from tbl_appraisal_approvers a   inner join tbl_intranet_employee_jobDetails j1 on j1.empcode=a.empcode  inner join tbl_intranet_employee_jobDetails j2 on j2.empcode=a.approver_code
            where a.empcode='" + txt_employee.Text + "'";
            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            gridapprovers.DataSource = ds;
            gridapprovers.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    protected void txt_employee_TextChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void gridapprovers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        txt_employee.Text = ((Label)gridapprovers.Rows[e.NewEditIndex].FindControl("lblempcode")).Text;
        txt_approver.Text = ((Label)gridapprovers.Rows[e.NewEditIndex].FindControl("lblapprovercode")).Text;
        ddl_approvertype.SelectedValue = ((Label)gridapprovers.Rows[e.NewEditIndex].FindControl("lbltype")).Text;
        ViewState["id"] = gridapprovers.DataKeys[e.NewEditIndex].Value.ToString();
    }
    protected void gridapprovers_PreRender(object sender, EventArgs e)
    {
        if (gridapprovers.Rows.Count > 0)
            gridapprovers.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}