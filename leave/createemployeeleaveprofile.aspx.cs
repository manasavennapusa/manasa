using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class leave_createemployeeleaveprofile : System.Web.UI.Page
{
    string sqlstr, _companyId, _userCode;
    DataSet ds = new DataSet();
    public int i;
    int c, flag;
    DataTable dtable = new DataTable();
    DataView dview;

    SqlTransaction transaction = null;
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
                Session.Remove("hiearchy");
            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    protected void BindLeavePolicy(int companyId)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "SELECT [policyid], [policyname] FROM [tbl_leave_createleavepolicy] where status=1 and company_id=" + companyId;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drp_policy.DataSource = ds;
                drp_policy.DataTextField = "policyname";
                drp_policy.DataValueField = "policyid";
                drp_policy.DataBind();
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
    protected void create_approver_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("empcode", typeof(string));
        dtable.Columns.Add(new DataColumn("name", typeof(string)));
        dtable.Columns.Add(new DataColumn("level", typeof(int)));
        dtable.Columns.Add(new DataColumn("hr", typeof(int)));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["empcode"], dtable.Columns["hr"] };
        Session["hiearchy"] = dtable;
    }

    protected void createhiearchy()
    {
        if (Session["hiearchy"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["hiearchy"];
            dview = new DataView(dtable);
            dview.Sort = "level";
        }
    }

    protected void bindapprovallist()
    {
        dtable = (DataTable)Session["hiearchy"];
        dview = new DataView(dtable);
        dview.Sort = "level";
        approvalgrid.DataSource = dview;
        approvalgrid.DataBind();
    }
    protected void insert_approver()
    {
        DataRow dr;
        string level;
        level = hiddenlevel.Value;

        if (Session["hiearchy"] == null)
        {
            create_approver_table();
        }
        dtable = (DataTable)Session["hiearchy"];
        object[] keyArrary = new object[2];
        keyArrary[0] = txt_approver.Text;
        keyArrary[1] = 0;

        DataRow drfind = dtable.Rows.Find(keyArrary);
        if (drfind != null)
        {
            Common.Console.Output.Show("Approver already added.");
        }
        else
        {
            dr = dtable.NewRow();

            if (dtable.Rows.Count > 0)
            {
                hiddenlevel.Value = Convert.ToString(Convert.ToInt32(level) + 1);
            }

            dr["name"] = GetName(txt_approver.Text);
            dr["empcode"] = txt_approver.Text;

            dr["level"] = hiddenlevel.Value;

            dr["hr"] = 0;

            dtable.Rows.Add(dr);
        }
        txt_approver.Text = "";
        Session["hiearchy"] = dtable;

        bindapprovallist();
    }
    private string GetName(string empcode)
    {
        string sqlstr = @"SELECT tbl_intranet_employee_jobDetails.emp_fname + '' + isnull(tbl_intranet_employee_jobDetails.emp_m_name,'') + '' + isnull(tbl_intranet_employee_jobDetails.emp_l_name,'') as name FROM tbl_intranet_employee_jobDetails where empcode='" + empcode + "'";
        SqlConnection connection = activity.OpenConnection();
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0]["name"].ToString();
        else return "";
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //if ((grid_customizerule.Rows.Count > 0) && (approvalgrid.Rows.Count > 0))
        //{
       // employeehierarchy();
        if ((grid_customizerule.Rows.Count > 0))
        {
            sqlstr = "select * from tbl_leave_leaveperiod where status=1";
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                employeeleaverule(Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()));

            }
            else {
                Common.Console.Output.Show("Calender year not created");
                return;
            }
            reset();
        }
        else
        {
            //Common.Console.Output.Show("Please click on SET POLICY to configure leave rule successfully or Check Approver!");
        }

        //}
        //else
        //{
        //    Common.Console.Output.Show("Please click on SET POLICY to configure leave rule successfully or Check Approver!");
        //}
    }

    protected void employeehierarchy()
    {
        try
        {
            SqlParameter[] sqlparam1;
            sqlparam1 = new SqlParameter[1];
            Output.AssignParameter(sqlparam1, 0, "@employeecode", "String", 50, txt_employee.Text);
            sqlstr = "select count(employeecode) as employeecode from tbl_leave_employee_hierarchy where employeecode='" + txt_employee.Text.Trim().ToString() + "'";
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr, sqlparam1);
            //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam1);

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["employeecode"]) > 0)
            {
                Common.Console.Output.Show("Approval hiearchy already created for " + txt_employee.Text);
            }

            else

                if (Session["hiearchy"] == null)
                    return;

            dtable = (DataTable)Session["hiearchy"];
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

        if (dtable.Rows.Count > 0)
        {
            try
            {
                SqlParameter[] parm1;
                parm1 = new SqlParameter[9];
                Output.AssignParameter(parm1, 0, "@employeecode", "String", 100, txt_employee.Text.Trim());
                Output.AssignParameter(parm1, 1, "@approverid", "String", 100, txt_hr.Text.Trim());
                hidden_hr.Value = GetName(txt_hr.Text);
                Output.AssignParameter(parm1, 2, "@approvername", "String", 100, hidden_hr.Value);
                Output.AssignParameter(parm1, 3, "@approverpriority", "String", 10, (Convert.ToInt32(hiddenlevel.Value) + 1).ToString());
                Output.AssignParameter(parm1, 4, "@hr", "String", 10, true.ToString());
                Output.AssignParameter(parm1, 5, "@createdby", "String", 100, _userCode);
                Output.AssignParameter(parm1, 6, "@modifiedby", "String", 100, _userCode);
                Output.AssignParameter(parm1, 7, "@createddate", "DateTime", 0, DateTime.Now.ToString());
                Output.AssignParameter(parm1, 8, "@company_id", "Int", 0, _companyId.ToString());


                SqlConnection connection = activity.OpenConnection();
                transaction = connection.BeginTransaction();
                sqlstr = "insert into tbl_leave_employee_hierarchy(employeecode,approverid,approvername,approverpriority,hr,createddate,createdby,modifiedby,company_id) values (@employeecode,@approverid,@approvername,@approverpriority,@hr,@createddate,@createdby,@modifiedby,@company_id)";
                flag += SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, parm1);

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    SqlParameter[] sqlparm2;
                    sqlparm2 = new SqlParameter[9];
                    Output.AssignParameter(sqlparm2, 0, "@employeecode", "String", 100, txt_employee.Text);
                    Output.AssignParameter(sqlparm2, 1, "@approverid", "String", 100, dtable.Rows[i]["empcode"].ToString());
                    string appName = GetName(dtable.Rows[i]["empcode"].ToString());
                    Output.AssignParameter(sqlparm2, 2, "@approvername", "String", 100, appName);
                    Output.AssignParameter(sqlparm2, 3, "@approverpriority", "Int", 10, dtable.Rows[i]["level"].ToString());
                    Output.AssignParameter(sqlparm2, 4, "@hr", "String", 10, false.ToString());
                    Output.AssignParameter(sqlparm2, 5, "@createdby", "String", 100, _userCode);
                    Output.AssignParameter(sqlparm2, 6, "@modifiedby", "String", 100, _userCode);
                    Output.AssignParameter(sqlparm2, 7, "@createddate", "DateTime", 0, DateTime.Now.ToString());
                    Output.AssignParameter(sqlparm2, 8, "@company_id", "Int", 0, _companyId.ToString());
                    flag += SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, sqlparm2);
                    //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
                Common.Console.Output.Show("Approval hiearchy created for " + txt_employee.Text);
                // Common.Console.Output.Show("Approval hierachy already created for " + txt_employee.Text);

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
        }
    }
    protected void employeeleaverule(int Calenderid)
    {
        SqlParameter sqlparm;
        SqlParameter[] sqlgridparm;
        try
        {
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            for (int i = 0; i < grid_customizerule.Rows.Count; i++)
            {
                sqlparm = new SqlParameter();
                sqlgridparm = new SqlParameter[8];
                Output.AssignParameter(sqlgridparm, 0, "@policyid", "Int", 100, ((Label)grid_customizerule.Rows[i].Cells[0].FindControl("l1")).Text);
                Output.AssignParameter(sqlgridparm, 1, "@leaveid", "Int", 100, ((Label)grid_customizerule.Rows[i].Cells[1].FindControl("l2")).Text);
                Output.AssignParameter(sqlgridparm, 2, "@empcode", "String", 100, txt_employee.Text.Trim());
                Output.AssignParameter(sqlgridparm, 3, "@Entitled_days", "Decimal", 10, ((TextBox)grid_customizerule.Rows[i].Cells[4].FindControl("txt_entdays")).Text);
                Output.AssignParameter(sqlgridparm, 4, "@createdby", "String", 100, _userCode);
                Output.AssignParameter(sqlgridparm, 5, "@modifiedby", "String", 100, _userCode);
                Output.AssignParameter(sqlgridparm, 6, "@createddate", "DateTime", 0, DateTime.Now.ToString());
                Output.AssignParameter(sqlgridparm, 7, "@year", "Int", 100, Calenderid.ToString());
                flag += SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_create_customizerule", sqlgridparm);

            }

            sqlgridparm = new SqlParameter[8];

            Output.AssignParameter(sqlgridparm, 0, "@policyid", "Int", 100, ((Label)grid_customizerule.Rows[0].Cells[0].FindControl("l1")).Text);
            Output.AssignParameter(sqlgridparm, 1, "@leaveid", "Int", 100, "0");
            Output.AssignParameter(sqlgridparm, 2, "@empcode", "String", 100, txt_employee.Text.Trim());
            Output.AssignParameter(sqlgridparm, 3, "@Entitled_days", "Decimal", 10, "200.00");
            Output.AssignParameter(sqlgridparm, 4, "@createdby", "String", 100, _userCode);
            Output.AssignParameter(sqlgridparm, 5, "@modifiedby", "String", 100, _userCode);
            Output.AssignParameter(sqlgridparm, 6, "@createddate", "DateTime", 0, DateTime.Now.ToString());
            Output.AssignParameter(sqlgridparm, 7, "@year", "Int", 100, Calenderid.ToString());
            flag += SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_create_customizerule", sqlgridparm);
            //   c = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_create_customizerule", sqlgridparm);
            if (flag > 0)
            {
                Common.Console.Output.Show(" Leave Profile configured sucessfully");
            }
            else
                //Common.Console.Output.Show(" Leave Profile already configured for " + txt_employee.Text);
                Common.Console.Output.Show("Employee Leave Profile Already Exits For  " + txt_employee.Text);

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
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void reset()
    {
        txt_employee.Text = "";
        txt_hr.Text = "";
        txt_approver.Text = "";
        Session.Remove("hiearchy");
        approvalgrid.DataSource = null;
        drp_policy.SelectedIndex = -1;
        approvalgrid.DataBind();
        grid_customizerule.DataSource = null;
        grid_customizerule.DataBind();
        hiddenlevel.Value = "1";
    }
    protected void btn_greset_Click(object sender, EventArgs e)
    {
        Session.Remove("hiearchy");
        approvalgrid.DataSource = null;
        approvalgrid.DataBind();
        hiddenlevel.Value = "1";
    }
    protected void btn_policy_Click(object sender, EventArgs e)
    {
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[3];

            Output.AssignParameter(sqlparm, 0, "@policyid", "Int", 100, drp_policy.SelectedValue);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 100, txt_employee.Text);
            if (opt_prorata_yes.Checked)
                Output.AssignParameter(sqlparm, 2, "@isprorata", "Int", 100, "1");
            else
                Output.AssignParameter(sqlparm, 2, "@isprorata", "Int", 100, "0");

            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_prorata_leave", sqlparm);
            //   ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_prorata_leave", sqlparm);

            grid_customizerule.DataSource = ds;
            grid_customizerule.DataBind();
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
    protected void drp_policy_DataBound(object sender, EventArgs e)
    {
        drp_policy.Items.Insert(0, new ListItem("--Select Policy--", "0"));
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        //if(!ValidateEmployee(txt_employee.Text);
        //  return;
        insert_approver();
    }

    //private bool ValidateEmployee(string empcode)
    //{

    //}

    protected void approvalgrid_PreRender(object sender, EventArgs e)
    {
        if (approvalgrid.Rows.Count > 0)
            approvalgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
