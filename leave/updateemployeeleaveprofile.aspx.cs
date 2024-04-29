using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_updateemployeeleaveprofile : System.Web.UI.Page
{
    string sqlstr, _companyId, _userCode;
    DataSet ds = new DataSet();
    public int i;
    int c, flag;
    DataTable dtable = new DataTable();
    DataView dview;
    Boolean add;
    SqlTransaction transaction = null;
    SqlConnection _connection;
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
                // fetchemphierarchy();
                bind_employeedata();
                lbl_empcode.Text = Request.QueryString["empcode"].ToString();
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
    protected void fetchemphierarchy()
    {
        //int level;
        //level = 0;

        //try
        //{

        //    lbl_empcode.Text = Request.QueryString["empcode"].ToString();
        //    SqlParameter[] sqlparam1;
        //    sqlparam1 = new SqlParameter[1];
        //    Output.AssignParameter(sqlparam1, 0, "@empid", "String", 50, Request.QueryString["empcode"].ToString());
        //    SqlConnection connection = activity.OpenConnection();
        //    ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchrule", sqlparam1);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        txt_hr.Text = ds.Tables[0].Rows[0]["approverid"].ToString();
        //        hidden_hr.Value = ds.Tables[0].Rows[0]["name"].ToString();
        //    }
        //    if (ds.Tables[1].Rows.Count > 0)
        //    {
        //        create_approver_table();
        //        DataRow dr;
        //        DataTable sdata;

        //        sdata = (DataTable)Session["hiearchy"];
        //        for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
        //        {
        //            dr = sdata.NewRow();
        //            dr["empcode"] = (ds.Tables[1].Rows[i]["approverid"] != null) ? ds.Tables[1].Rows[i]["approverid"].ToString() : "";
        //            dr["name"] = (ds.Tables[1].Rows[i]["name"] != null) ? ds.Tables[1].Rows[i]["name"].ToString() : "";
        //            dr["level"] = (ds.Tables[1].Rows[i]["approverpriority"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["approverpriority"].ToString()) : 0;
        //            dr["hr"] = (Convert.ToBoolean(ds.Tables[1].Rows[i]["hr"]) == true) ? 1 : 0;
        //            sdata.Rows.Add(dr);

        //            level++;
        //            hiddenlevel.Value = level.ToString();
        //        }
        //        Session["hiearchy"] = sdata;
        //        bindapprovallist();

        //    }
        //}
        //catch (Exception ex)
        //{

        //    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        //}
        //finally
        //{
        //    activity.CloseConnection();
        //}
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
        ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0]["name"].ToString();
        else return "";
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        insert_approver();
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //if ((grid_customizerule.Rows.Count > 0) && (approvalgrid.Rows.Count > 0))
        //{
        //  employeehierarchy();
        employeeleaverule();
        Response.Redirect("EditEmployeeLeaveProfile.aspx?updated=true");
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
            Output.AssignParameter(sqlparam1, 0, "@employeecode", "String", 50, lbl_empcode.Text);
            sqlstr = "delete from tbl_leave_employee_hierarchy where employeecode=@employeecode";
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr, sqlparam1);
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
                Output.AssignParameter(parm1, 0, "@employeecode", "String", 100, lbl_empcode.Text.Trim());
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
                    Output.AssignParameter(sqlparm2, 0, "@employeecode", "String", 100, lbl_empcode.Text);
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
                Common.Console.Output.Show("Approval hierachy updated for " + lbl_empcode.Text);


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

    protected void bind_employeedata()
    {
        try
        {
            SqlParameter[] sqlparam1;
            sqlparam1 = new SqlParameter[1];
            Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, lbl_empcode.Text);
            sqlstr = @"select tbl_leave_employee_leave_master.leaveid,tbl_leave_createleave.leavetype,tbl_leave_employee_leave_master.policyid,tbl_leave_employee_leave_master.entitled_days,tbl_leave_employee_leave_master.empcode,tbl_leave_createleavepolicy.policyname
              from tbl_leave_employee_leave_master
              INNER JOIN tbl_leave_createleavepolicy ON tbl_leave_employee_leave_master.policyid=tbl_leave_createleavepolicy.policyid
              INNER JOIN tbl_leave_createleave ON tbl_leave_employee_leave_master.leaveid=tbl_leave_createleave.leaveid
              where empcode='" + Request.QueryString["empcode"].ToString() + "' and tbl_leave_employee_leave_master.leaveid !='" + 0 + "'";

            SqlConnection connection = activity.OpenConnection();
            DataSet ds;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr, sqlparam1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_customizerule.DataSource = ds;
                grid_customizerule.DataBind();
                drp_policy.SelectedValue = ds.Tables[0].Rows[0]["policyid"].ToString();
            }
            else
            {
                Response.Redirect("EditEmployeeLeaveProfile.aspx?updated1=true");
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
    protected void btn_policy_Click(object sender, EventArgs e)
    {
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[3];

            Output.AssignParameter(sqlparm, 0, "@policyid", "Int", 100, drp_policy.SelectedValue);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 100, lbl_empcode.Text.ToString());
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
    protected void employeeleaverule()
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
                sqlgridparm = new SqlParameter[7];
                Output.AssignParameter(sqlgridparm, 0, "@policyid", "Int", 100, drp_policy.SelectedValue);
                Output.AssignParameter(sqlgridparm, 1, "@leaveid", "Int", 100, Convert.ToInt32(((Label)grid_customizerule.Rows[i].Cells[1].FindControl("l2")).Text).ToString());
                Output.AssignParameter(sqlgridparm, 2, "@empcode", "String", 100, lbl_empcode.Text.Trim());
                Output.AssignParameter(sqlgridparm, 3, "@Entitled_days", "Decimal", 10, Convert.ToDecimal(((TextBox)grid_customizerule.Rows[i].Cells[4].FindControl("txt_entdays")).Text).ToString());
                Output.AssignParameter(sqlgridparm, 4, "@createdby", "String", 100, _userCode);
                Output.AssignParameter(sqlgridparm, 5, "@modifiedby", "String", 100, _userCode);
                Output.AssignParameter(sqlgridparm, 6, "@createddate", "DateTime", 0, DateTime.Now.ToString());
                flag += SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_update_customizerule", sqlgridparm);
            }
            Output.Show(" Leave rule configured sucessfully for" + lbl_empcode.Text);
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
        fetchemphierarchy();
        bind_employeedata();
        //reset();
        Response.Redirect("editemployeeleaveprofile.aspx");
    }

    protected void btn_greset_Click(object sender, EventArgs e)
    {

        Session.Remove("hiearchy");
        approvalgrid.DataSource = null;
        approvalgrid.DataBind();
        hiddenlevel.Value = "1";
    }

    protected void approvalgrid_PreRender(object sender, EventArgs e)
    {
        if (approvalgrid.Rows.Count > 0)
            approvalgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void drp_policy_DataBound(object sender, EventArgs e)
    {
        drp_policy.Items.Insert(0, new ListItem("--Select Policy--", "0"));
    }
}
