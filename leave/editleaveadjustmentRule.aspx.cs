using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_editleaveadjustmentRule : System.Web.UI.Page
{
    SqlTransaction transaction = null;
    SqlConnection _connection;
    DataTable dtable = new DataTable();
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    string strsql, _companyId, _userCode;
    int flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                Session.Remove("aleave");
                BindLeaveType(Convert.ToInt32(_companyId));
                populateadjustmentleave();
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }

    }
    protected void BindLeaveType(int companyId)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            strsql = "SELECT leaveid, leavetype FROM tbl_leave_createleave where leaveid!=0 and status=1 and company_id=" + companyId;
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, strsql);
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
    protected void grid_aleave_PreRender(object sender, EventArgs e)
    {
        if (grid_aleave.Rows.Count > 0)
            grid_aleave.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void populateadjustmentleave()
    {
        DataSet ds;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[3];
        Output.AssignParameter(sqlparm, 0, "@leaveid", "Int", 10, Request.QueryString["leaveid"].ToString());
        Output.AssignParameter(sqlparm, 1, "@policyid", "Int", 0, Request.QueryString["policyid"].ToString());
        Output.AssignParameter(sqlparm, 2, "@comapnyid", "Int", 0, _companyId.ToString());
        hiddenvalue.Value = Request.QueryString["leaveid"].ToString();
        hidden_policy.Value = Request.QueryString["policyid"].ToString();
        SqlConnection connection = activity.OpenConnection();
        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_update_adjustment_rule", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_leave.Text = ds.Tables[0].Rows[0][0].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            lbl_policy.Text = ds.Tables[1].Rows[0][0].ToString();
        }

        if (Session["aleave"] == null)
        {
            createatable();
        }
        DataRow dr;
        DataTable sdata;

        sdata = (DataTable)Session["aleave"];

        for (int i = 0; ds.Tables[2].Rows.Count > i; i++)
        {
            dr = sdata.NewRow();
            dr["aleaveid"] = (ds.Tables[2].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[2].Rows[i]["adjust_leave"].ToString()) : 0;
            dr["aleavename"] = (ds.Tables[2].Rows[i]["leavetype"] != null) ? ds.Tables[2].Rows[i]["leavetype"].ToString() : "";
            sdata.Rows.Add(dr);
        }
        Session["aleave"] = sdata;
        bindadjustleave();
    }


    protected void drp_aleave_DataBound(object sender, EventArgs e)
    {
        drp_aleave.Items.Insert(0, new ListItem("--Select Leave--", "100"));
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            dtable = (DataTable)Session["aleave"];
            if (dtable.Rows.Count > 0)
            {
                SqlConnection connection = activity.OpenConnection();
                transaction = connection.BeginTransaction();
                string strsql1 = "delete from tbl_leave_adjust_rule where leaveid=" + hiddenvalue.Value + " and policyid=" + hidden_policy.Value;
                flag = SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, strsql1);
                SqlParameter[] parm1;
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    parm1 = new SqlParameter[7];
                    Output.AssignParameter(parm1, 0, "@leaveid", "Int", 10, hiddenvalue.Value);
                    Output.AssignParameter(parm1, 1, "@adjust_leave", "Int", 0, dtable.Rows[i]["aleaveid"].ToString());
                    Output.AssignParameter(parm1, 2, "@priority", "Int", 0, i.ToString());

                    Output.AssignParameter(parm1, 3, "@createddate", "DateTime", 10, DateTime.Now.ToString());
                    Output.AssignParameter(parm1, 4, "@createdby", "String", 0, _userCode);
                    Output.AssignParameter(parm1, 5, "@modifiedby", "String", 0, _userCode);
                    Output.AssignParameter(parm1, 6, "@policyid", "Int", 0, hidden_policy.Value);

                    strsql = "insert into tbl_leave_adjust_rule(leaveid,policyid,adjust_leave,priority,createddate,createdby,modifiedby) values (@leaveid,@policyid,@adjust_leave,@priority,@createddate,@createdby,@modifiedby)";
                    flag += SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, strsql, parm1);
                }
            }


            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        Response.Redirect("EditLeaveRule.aspx?edit_adjust=true");
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
        if (drp_aleave.SelectedValue.ToString() != lbl_leave.Text)
        {

            adjustleave();
        }
        else
            Output.Show("Adjusting leave cannot be added to adjusting leave queue");
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

        if (drp_aleave.SelectedItem.Text != lbl_leave.Text)
        {
            if (drfind != null)
            {
                Output.Show("Leave already in adjustment queue");
            }
            else
            {
                dr = dtable.NewRow();
                dr["aleaveid"] = drp_aleave.SelectedValue.ToString();
                dr["aleavename"] = drp_aleave.SelectedItem.Text.ToString();
                dtable.Rows.Add(dr);
            }
        }
        else
        {
            Output.Show("Leave can not be adjusted to itself");
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

    protected void reset()
    {
        drp_aleave.SelectedIndex = -1;
        grid_aleave.DataSource = null;
        grid_aleave.DataBind();
    }

    protected void btnrst_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditLeaveRule.aspx");
        //reset();
    }

}
