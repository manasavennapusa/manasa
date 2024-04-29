using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class leave_createleaveadjustmentrule : System.Web.UI.Page
{
    string _companyId, _userCode, strsql = "", sqlstr = "";
    DataSet ds = new DataSet();
    public int i, flag;
    public decimal b;
    public decimal c;
    SqlTransaction transaction = null;
    SqlConnection _connection;
    DataTable dtable = new DataTable();
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                BindLeavePolicy(Convert.ToInt32(_companyId));
                BindLeaveType(Convert.ToInt32(_companyId));
                BindLeaveType1(Convert.ToInt32(_companyId));
                Session.Remove("aleave");
            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    protected void BindLeavePolicy(int companyId)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "SELECT [policyid], [policyname] FROM [tbl_leave_createleavepolicy] where status=1 and company_id='" + companyId+"'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dd_policy.DataSource = ds;
                dd_policy.DataTextField = "policyname";
                dd_policy.DataValueField = "policyid";
                dd_policy.DataBind();
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
    protected void BindLeaveType(int companyId)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "SELECT leaveid, leavetype FROM tbl_leave_createleave where leaveid!=0 and status=1 and company_id='" +companyId+"'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drp_leave.DataSource = ds;
                drp_leave.DataTextField = "leavetype";
                drp_leave.DataValueField = "leaveid";
                drp_leave.DataBind();
               
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


    protected void BindLeaveType1(int companyId)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "SELECT leaveid, leavetype FROM tbl_leave_createleave where leaveid!=0 and status=1 and company_id='" + companyId + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {                            
                drp_aleave.DataSource = ds;
                drp_aleave.DataTextField = "leavetype";
                drp_aleave.DataValueField = "leaveid";
                drp_aleave.DataBind();
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

    protected void drp_leave_DataBound(object sender, EventArgs e)
    {
        drp_leave.Items.Insert(0, new ListItem("--Select Leave--", "0"));
    }
    protected void drp_aleave_DataBound(object sender, EventArgs e)
    {
        drp_aleave.Items.Insert(0, new ListItem("--Select Leave--", "0"));
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (!validate())
        {
            Output.Show("Leave adjustment rule already defined for " + drp_leave.SelectedItem.Text);
            reset();
            return;
        }

        try
        {
            dtable = (DataTable)Session["aleave"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] parm1;
                int flag = 0; // Initialize flag here

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    parm1 = new SqlParameter[7];
                    Output.AssignParameter(parm1, 0, "@leaveid", "Int", 10, drp_leave.SelectedValue);
                    Output.AssignParameter(parm1, 1, "@adjust_leave", "Int", 0, dtable.Rows[i]["aleaveid"].ToString());
                    Output.AssignParameter(parm1, 2, "@priority", "Int", 0, i.ToString());

                    Output.AssignParameter(parm1, 3, "@createddate", "DateTime", 10, DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss"));
                    Output.AssignParameter(parm1, 4, "@createdby", "String", 0, _userCode);
                    Output.AssignParameter(parm1, 5, "@modifiedby", "String", 0, _userCode);
                    Output.AssignParameter(parm1, 6, "@policyid", "Int", 0, dd_policy.SelectedValue);
                    SqlConnection connection = activity.OpenConnection();
                    SqlTransaction transaction = connection.BeginTransaction(); // Initialize transaction here
                    strsql = "insert into tbl_leave_adjust_rule(leaveid,policyid,adjust_leave,priority,createddate,createdby,modifiedby) values (@leaveid,@policyid,@adjust_leave,@priority,@createddate,@createdby,@modifiedby)";
                    flag += SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, strsql, parm1);
                    transaction.Commit(); // Commit transaction inside the loop
                    connection.Close(); // Close connection inside the loop
                }

                if (flag > 0)
                {
                    Output.Show("Adjustment rule added successfully");
                    reset();
                }
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
    }





    public Boolean validate()
    {
        int i = 0;
        try
        {
            SqlConnection connection = activity.OpenConnection();
            strsql = "select count(*) from tbl_leave_adjust_rule where leaveid=" + drp_leave.SelectedValue + " AND policyid=" + dd_policy.SelectedValue;
            i = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, strsql);
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
        if (i > 0)
            return false;
        else
            return true;

    }

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("aleaveid", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["aleaveid"] };
        dtable.Columns.Add("aleavename", typeof(string));
        Session["aleave"] = dtable;
    }

    protected void btm_add_Click(object sender, EventArgs e)
    {
        if (drp_aleave.SelectedValue.ToString() != drp_leave.SelectedValue.ToString())
        {
            drp_leave.Enabled = false;
            adjustleave();
        }
        else
            Output.Show("Adjusting leave cannot be added to adjustment queue");
    }

    protected void adjustleave()
    {
        DataRow dr;
        if (Session["aleave"] == null)
        {
            createatable();
        }
        dtable = (DataTable)Session["aleave"];

        DataRow drfind = dtable.Rows.Find(drp_aleave.SelectedValue.ToString());
        if (drfind != null)
        {
            Output.Show("Leave already exists in adjustment queue");
        }
        else
        {
            dr = dtable.NewRow();
            dr["aleaveid"] = drp_aleave.SelectedValue.ToString();
            dr["aleavename"] = drp_aleave.SelectedItem.Text.ToString();
            dtable.Rows.Add(dr);
        }


        Session["aleave"] = dtable;

        bindadjustleave();
    }


    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["aleave"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();

    }
    protected void grid_aleave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["aleave"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(grid_aleave.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            Session["aleave"] = dtable;
            bindadjustleave();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();

    }
    protected void reset()
    {
        drp_leave.Enabled = true;
        drp_leave.SelectedIndex = -1;
        drp_aleave.SelectedIndex = -1;
        dd_policy.SelectedIndex = -1;
        grid_aleave.DataSource = null;
        grid_aleave.DataBind();
        Session.Remove("aleave");
    }
    protected void dd_policy_DataBound(object sender, EventArgs e)
    {
        dd_policy.Items.Insert(0, new ListItem("--Select Policy--", "0"));
    }

    protected void grid_aleave_PreRender(object sender, EventArgs e)
    {
        if (grid_aleave.Rows.Count > 0)
            grid_aleave.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
