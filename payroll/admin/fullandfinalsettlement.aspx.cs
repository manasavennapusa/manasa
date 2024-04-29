using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class payroll_admin_fullandfinalsettlement : System.Web.UI.Page
{
    SqlConnection conn = null;
    SqlTransaction tran = null;
    DataSet ds1;
    #region Sql
    private void CreateConnection()
    {
        conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        conn.Open();

        tran = conn.BeginTransaction();
    }

    private void Execute(string sql, params SqlParameter[] parms)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Transaction = tran;

        if (parms != null)
        {
            if (parms.Length > 0)
            {
                foreach (SqlParameter p in parms)
                {
                    cmd.Parameters.Add(p);
                }
            }
        }

        cmd.ExecuteNonQuery();

    }

    private DataSet Read(string sql, params SqlParameter[] parms)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Transaction = tran;

        if (parms != null)
        {
            if (parms.Length > 0)
            {
                foreach (SqlParameter p in parms)
                {
                    cmd.Parameters.Add(p);
                }
            }
        }

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);

        return ds;
    }

    private void Commit()
    {
        tran.Commit();
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            CreateConnection();
        }
        else
        {

        }
    }
    protected void btnGetInfo_Click(object sender, EventArgs e)
    {
        if (!ValidateFreeze())
        {
            return;
        }

        if (!ValidateDOL())
        {
            return;
        }
        else
        {
            GetAllowance();
        }

        string sql = @"select 
J.empcode, emp_fname + ' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') empname, convert(varchar(20),emp_doj,106) as emp_doj, convert(varchar(20),emp_doleaving,106) as emp_doleaving, reason_leaving, W.branch_name, B.brnch_name,D.department_name,G.designationname,T.grosssalary
from tbl_intranet_employee_jobDetails J
left join tbl_intranet_branch_detail W on J.branch_id = W.branch_id
left join tbl_create_branch_deatils B on B.brnch_id = J.new_branch_id
left join tbl_internate_departmentdetails D on D.departmentid = J.dept_id
left join tbl_intranet_designation G on J.degination_id = G.id
left join (
select P.EMPCODE, SUM(PD.amount) grosssalary
from tbl_payroll_employee_paystructure P
inner join tbl_payroll_employee_paystructure_detail PD on P.ID = PD.paystructure_id
where P.STATUS = 1 and PD.status = 1
group by P.EMPCODE) T on T.EMPCODE = J.empcode
where J.empcode = @empcode";

        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p[0].Value = txt_employee.Text;

        DataSet ds = Read(sql, p);

        if (ds.Tables[0].Rows.Count <= 0)
        {
            return;
        }

        DataRow row = ds.Tables[0].Rows[0];

        lblName.Text = row["empname"].ToString();
        lblDOJ.Text = row["emp_doj"].ToString();
        lblBranch.Text = row["brnch_name"].ToString();
        lblDepartment.Text = row["department_name"].ToString();
        lblDesignation.Text = row["designationname"].ToString();
        lblReasonofleaving.Text = row["reason_leaving"].ToString();
        lblDOL.Text = row["emp_doleaving"].ToString();
        lblGrossSalary.Text = row["grosssalary"].ToString();

        sql = "select payabledays,leavedays,gratuitydays1,gratuitydays2,ff_status from tbl_ff_info where empcode = @empcode";
        SqlParameter[] p1 = new SqlParameter[1];
        p1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p1[0].Value = txt_employee.Text;

        DataSet dsDays = Read(sql, p1);

        if (dsDays.Tables[0].Rows.Count > 0)
        {
            txtTotalDayPayable.Text = dsDays.Tables[0].Rows[0]["payabledays"].ToString();
            txtTotalLeavePayable.Text = dsDays.Tables[0].Rows[0]["leavedays"].ToString();
            txtGratuity1to5.Text = dsDays.Tables[0].Rows[0]["gratuitydays1"].ToString();
            txtGratuity6to30.Text = dsDays.Tables[0].Rows[0]["gratuitydays2"].ToString();
        }

        sql = "select payheadid,payheadname,amount from tbl_ff_allowance where empcode = @empcode";
        SqlParameter[] p2 = new SqlParameter[1];
        p2[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p2[0].Value = txt_employee.Text;

        DataSet dsAllw = Read(sql, p2);

        if (dsAllw.Tables[0].Rows.Count > 0)
        {
            DataTable dt = CreateTable();

            foreach (DataRow rdb in dsAllw.Tables[0].Rows)
            {
                DataRow r = dt.NewRow();
                r["AllowanceId"] = rdb["payheadid"];
                r["AllowanceName"] = rdb["payheadname"];
                r["Amount"] = rdb["amount"];

                dt.Rows.Add(r);
            }

            ViewState["Allowance"] = dt;
            gridAllowance.DataSource = dt;
            gridAllowance.DataBind();
        }

        sql = @"select sd.payheadid AllowanceId, sd.payhead AllowanceName, sd.amount Amount from tbl_ff_employee_salarydetail sd inner join tbl_ff_employee_salary s on s.salaryid = sd.salaryid where s.empcode = @empcode and sd.head_type = 0;";
        sql += @"select sd.payheadid AllowanceId, sd.payhead AllowanceName, sd.amount Amount from tbl_ff_employee_salarydetail sd inner join tbl_ff_employee_salary s on s.salaryid = sd.salaryid where s.empcode = @empcode and sd.head_type = 1";

        SqlParameter[] p3 = new SqlParameter[1];
        p3[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p3[0].Value = txt_employee.Text;

        DataSet dsSal = Read(sql, p3);

        gridEarnings.DataSource = dsSal.Tables[0];
        gridEarnings.DataBind();

        gridDeduction.DataSource = dsSal.Tables[1];
        gridDeduction.DataBind();

        Commit();
        bind_Gratuity();
        leave_payable();
        bind_totalpayabledays();
    }
    private bool ValidateDOL()
    {
        string sql = "select * from tbl_intranet_employee_jobDetails where empcode = @empcode and emp_doleaving is not null";

        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p[0].Value = txt_employee.Text;

        DataSet ds = Read(sql, p);

        if (ds.Tables[0].Rows.Count <= 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "alt", "alert('Employee does not exists or he is not a resigned employee.')", true);
            return false;
        }

        return true;
    }
    private bool ValidateFreeze()
    {
        string sql = "select ff_status from tbl_ff_info where empcode = @empcode";

        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p[0].Value = txt_employee.Text;

        DataSet ds = Read(sql, p);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["ff_status"].ToString().Trim() == "A")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "alt", "alert('Full and final settlement is already processed for this employee.')", true);
                return false;
            }
            else
            {
                return true;
            }
        }

        return true;
    }
    private void GetAllowance()
    {
        string sql = @"SELECT id, payhead_name FROM tbl_payroll_payhead where status=1 and type = 3";

        DataSet ds = Read(sql);

        if (ds.Tables[0].Rows.Count <= 0)
        {
            return;
        }
        else
        {
            ddlVariableAllowance.DataSource = ds.Tables[0];
            ddlVariableAllowance.DataTextField = "payhead_name";
            ddlVariableAllowance.DataValueField = "id";
            ddlVariableAllowance.DataBind();

            ListItem li = new ListItem("--Select--", "0");
            ddlVariableAllowance.Items.Insert(0, li);
        }
    }
    protected void ddlVariableAllowance_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAmount.Text = "0.0";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlVariableAllowance.SelectedValue == "0")
            return;

        if (txtAmount.Text.Trim() == "")
            return;

        decimal result;
        decimal.TryParse(txtAmount.Text.Trim(), out result);

        if (result <= 0)
        {
            return;
        }

        DataTable dt = null;

        if (ViewState["Allowance"] == null)
            dt = CreateTable();
        else
            dt = (DataTable)ViewState["Allowance"];

        DataRow rowFind = dt.Rows.Find(ddlVariableAllowance.SelectedValue);

        if (rowFind != null)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "alt", "alert('This allowance is already added.')", true);
            return;
        }

        DataRow row = dt.NewRow();
        row["AllowanceId"] = ddlVariableAllowance.SelectedValue;
        row["AllowanceName"] = ddlVariableAllowance.SelectedItem.Text;
        row["Amount"] = result;

        dt.Rows.Add(row);
        ViewState["Allowance"] = dt;

        gridAllowance.DataSource = dt;
        gridAllowance.DataBind();
    }
    private DataTable CreateTable()
    {
        DataTable dt = new DataTable();

        DataColumn dcAllowanceId = new DataColumn();
        dcAllowanceId.AllowDBNull = false;
        dcAllowanceId.ColumnName = "AllowanceId";
        dcAllowanceId.DataType = Type.GetType("System.Int32");


        DataColumn dcAllowanceName = new DataColumn();
        dcAllowanceName.AllowDBNull = false;
        dcAllowanceName.ColumnName = "AllowanceName";
        dcAllowanceName.DataType = Type.GetType("System.String");
        dcAllowanceName.MaxLength = 100;

        DataColumn dcAmount = new DataColumn();
        dcAmount.AllowDBNull = false;
        dcAmount.ColumnName = "Amount";
        dcAmount.DataType = Type.GetType("System.Decimal");

        dt.Columns.Add(dcAllowanceId);
        dt.Columns.Add(dcAllowanceName);
        dt.Columns.Add(dcAmount);

        dt.PrimaryKey = new DataColumn[] { dcAllowanceId };

        ViewState["Allowance"] = dt;

        return dt;
    }
    protected void btnProcessSalary_Click(object sender, EventArgs e)
    {
        ProcessSalary();
    }
    private bool ProcessSalary()
    {
        
        if (!ValidateFreeze())
        {
            return false;
        }

        if (ValidateDOL())
        {
            decimal result;
            decimal.TryParse(txtTotalDayPayable.Text, out result);
        
            if (result != null)
            {
                string sql = @"CREATE TABLE #tbl_payroll_allowance_detail(allowanceid int NULL, allowancename varchar(50) NULL, amount decimal(10, 2) NULL)";
                Execute(sql);

               

                sql = "delete from tbl_ff_info where empcode = @empcode; delete from tbl_ff_allowance where empcode = @empcode;";
                SqlParameter[] p0 = new SqlParameter[1];
                p0[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                p0[0].Value = txt_employee.Text;
                Execute(sql, p0);

                sql = "insert into tbl_ff_info (empcode,payabledays,leavedays,gratuitydays1,gratuitydays2,ff_status,payment_mode_type,payment_mode_amount,approval_status) values ('" + txt_employee.Text + "'," + txtTotalDayPayable.Text + "," + txtTotalLeavePayable.Text + "," + txtGratuity1to5.Text + "," + txtGratuity6to30.Text + ",'P','" + ddl_PMode.SelectedValue + "','" + txt_amt.Text + "',0)";
                Execute(sql);

                DataTable dtAllowance = (DataTable)ViewState["Allowance"];
                if (dtAllowance != null)
                {
                    foreach (DataRow r in dtAllowance.Rows)
                    {
                        sql = "insert into tbl_ff_allowance (empcode,payheadid,payheadname,amount) values ('" + txt_employee.Text + "'," + r["AllowanceId"] + ",'" + r["AllowanceName"] + "'," + r["Amount"] + ")";
                        Execute(sql);
                    }
                    using (SqlBulkCopy s = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                    {
                        s.DestinationTableName = "#tbl_payroll_allowance_detail";
                        s.ColumnMappings.Add("AllowanceId", "allowanceid");
                        s.ColumnMappings.Add("AllowanceName", "allowancename");
                        s.ColumnMappings.Add("Amount", "amount");
                        s.WriteToServer(dtAllowance);
                    }
                }

               


                sql = "exec SP_FF_EMPLOYEE_SALARY_GENERATE '" + txt_employee.Text + "'," + txtTotalDayPayable.Text + ",30," + txtTotalLeavePayable.Text + "," + txtGratuity1to5.Text + "," + txtGratuity6to30.Text + ",'" + Session["empcode"].ToString() + "'";

                Execute(sql);

                sql = @"select sd.payheadid AllowanceId, sd.payhead AllowanceName, sd.amount Amount from tbl_ff_employee_salarydetail sd inner join tbl_ff_employee_salary s on s.salaryid = sd.salaryid where s.empcode = @empcode and sd.head_type = 0;";
                sql += @"select sd.payheadid AllowanceId, sd.payhead AllowanceName, sd.amount Amount from tbl_ff_employee_salarydetail sd inner join tbl_ff_employee_salary s on s.salaryid = sd.salaryid where s.empcode = @empcode and sd.head_type = 1";


                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                p[0].Value = txt_employee.Text;

                 DataSet ds = Read(sql, p);

                gridEarnings.DataSource = ds.Tables[0];
                gridEarnings.DataBind();

                gridDeduction.DataSource = ds.Tables[1];
                gridDeduction.DataBind();

                Commit();

                return true;

            }
        }

        //SmartHr.Common.Alert("Total days payable should not be 0");
        //gridDeduction.DataSource = null;
        //gridDeduction.DataBind();
        //gridEarnings.DataSource = null;
        //gridEarnings.DataBind();
        return false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!ValidateFreeze())
        {
            return;
        }

        // Reprocess salary
        if (ProcessSalary())
        {
            string sql = @"update tbl_ff_info set ff_status = 'P' where empcode = @empcode";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            p[0].Value = txt_employee.Text;

            Execute(sql, p);

            string msg = @"var r = confirm('Transaction completed successfully.');if (r == true) { window.location = 'fullandfinalsettlement.aspx'; } else {window.location = 'fullandfinalsettlement.aspx';}";

            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "msg", msg, true);
        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        if (conn != null)
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
    }
    protected void Page_Error(object sender, EventArgs e)
    {
        if (tran != null)
            tran.Rollback();
    }
    protected void gridEarnings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string sql = @"select gtotal, dtotal, ntotal from tbl_ff_employee_salary where empcode = @empcode";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            p[0].Value = txt_employee.Text;

            DataSet ds = Read(sql, p);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            Label lblGrossTotal = (Label)e.Row.FindControl("lblGrossTotal");

            lblGrossTotal.Text = ds.Tables[0].Rows[0]["gtotal"].ToString();
            lblNet.Text = ds.Tables[0].Rows[0]["ntotal"].ToString();

        }
    }
    protected void gridDeduction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string sql = @"select gtotal, dtotal, ntotal from tbl_ff_employee_salary where empcode = @empcode";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            p[0].Value = txt_employee.Text;

            DataSet ds = Read(sql, p);

            Label lblDeduction = (Label)e.Row.FindControl("lblDeduction");

            lblDeduction.Text = ds.Tables[0].Rows[0]["dtotal"].ToString();
        }

    }
    protected void ckd_totalleavepayable_CheckedChanged(object sender, EventArgs e)
    {
        if (ckd_totalleavepayable.Checked == true)
        {
            leave_payable();
        }
        else
        {
            txtTotalLeavePayable.Text = "";
        }
    }
    protected void ckd_salary_days_CheckedChanged(object sender, EventArgs e)
    {
        if (ckd_salary_days.Checked == true)
        {
            bind_totalpayabledays();
        }
        else
        {
            txtTotalDayPayable.Text = "";
        }
    }
    protected void bind_Gratuity()
    {

        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();


        string sql2 = "select type from tbl_intranet_employee_jobDetails where empcode = @empcode";
        SqlParameter[] p2 = new SqlParameter[1];
        p2[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p2[0].Value = txt_employee.Text;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        DataSet ds2 = Read(sql2, p2);


        string sql = "select empcode from tbl_intranet_employee_terminate where empcode = @empcode";
        SqlParameter[] p1 = new SqlParameter[1];
        p1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p1[0].Value = txt_employee.Text;
        DataSet ds1 = Read(sql, p1);

        string query = "getmonthnyear";
        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p[0].Value = txt_employee.Text;
        ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, query, p);

        string sql3 = "select empcode,renewal_status,convert(varchar(20), conttract_yrs,101) as conttract_yrs,convert(varchar(20), emp_doj,101) as emp_doj,convert(varchar(20), emp_doleaving,101) as emp_doleaving,convert(varchar(20),renewal,101) as renewal from tbl_intranet_employee_jobDetails where empcode = @empcode";
        SqlParameter[] p12 = new SqlParameter[1];
        p12[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p12[0].Value = txt_employee.Text;
        DataSet ds12 = Read(sql3, p12);


        //----------------------------------UNLIMITED CONTRACT------------------------------------------//
        if (Convert.ToInt32(ds2.Tables[0].Rows[0]["type"]) == 1)  
        {
            if (ds1.Tables[0].Rows.Count == 1) //--------------------TERMINATION - UNLIMITED CONTRACT-------------------------//
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) <= 5)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) < 1)
                    {
                        txtGratuity1to5.Text = "0";
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }
                    else
                    {

                        decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                        decimal total = (Days * 21) / 365;
                        txtGratuity1to5.Text = total.ToString(".00");
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }
                }
                else
                {
                    decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal TotalfiveYrs = 5 * 365;
                    decimal total = (TotalfiveYrs * 21) / 365;
                    txtGratuity1to5.Text = total.ToString(".00");
                    decimal Y = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal Y1 = ((Days - TotalfiveYrs) * 30) / 365;
                    txtGratuity6to30.Text = Y1.ToString(".00");
                    ckd_txtGratuity6to30.Checked = true;
                    ckd_txtGratuity1to5.Checked = true;
                }

            }
            else  //------------------------- RESIGNATION - UNLIMITED CONTRACT------------------------------
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) < 5)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) < 1)
                    {
                        txtGratuity1to5.Text = "0";
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) >= 1 && Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) < 3)
                    {

                        decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                        decimal total = (Days * 21) / 365;
                        total = total * 1 / 3;
                        txtGratuity1to5.Text = total.ToString(".00");
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) >= 3 && Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) < 5)
                    {
                        decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                        decimal total = (Days * 21) / 365;
                        total = total * 2 / 3;
                        txtGratuity1to5.Text = total.ToString(".00");
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }
                }
                else
                {
                    // decimal total = 0.00;
                    decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal TotalfiveYrs = 5*365;
                    decimal total = (TotalfiveYrs * 21) / 365;
                    txtGratuity1to5.Text = total.ToString(".00");
                    decimal Y = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal Y1 = ((Days - TotalfiveYrs) * 30) / 365;
                    txtGratuity6to30.Text = Y1.ToString(".00");
                    ckd_txtGratuity6to30.Checked = true;
                    ckd_txtGratuity1to5.Checked = true;
                }
            }
        }
        else  // ------------------------- LIMITED CONTRACT----------------------------------//
        {
            if (ds1.Tables[0].Rows.Count == 1)  //-------------------TERMINATION - LIMITED CONTRACT---------------------------//
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) <= 5)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) < 1)
                    {
                        txtGratuity1to5.Text = "0";
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }
                    else
                    {
                        decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                        decimal total = (Days * 21) / 365;
                        txtGratuity1to5.Text = total.ToString(".00");
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }

                }
                else  
                {
                    decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal TotalfiveYrs = 5 * 365;
                    decimal total = (TotalfiveYrs * 21) / 365;
                    txtGratuity1to5.Text = total.ToString(".00");
                    decimal Y = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal Y1 = ((Days - TotalfiveYrs) * 30) / 365;
                    txtGratuity6to30.Text = Y1.ToString(".00");
                    ckd_txtGratuity6to30.Checked = true;
                    ckd_txtGratuity1to5.Checked = true;
                }
            }
            else  //------------------------------ RESIGNATION - LIMITED CONTRACT--------------------------//
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) <= 5)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Years"]) < 1)
                    {
                        txtGratuity1to5.Text = "0";
                        txtGratuity6to30.Text = "0";
                        ckd_txtGratuity1to5.Checked = true;
                    }
                    else
                    {
                        if (Convert.ToInt32(ds12.Tables[0].Rows[0]["renewal_status"]) == 0)
                        {
                            if (Convert.ToDateTime(ds12.Tables[0].Rows[0]["emp_doleaving"]) >= Convert.ToDateTime(ds12.Tables[0].Rows[0]["conttract_yrs"]))
                            {
                                decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                                decimal total = (Days * 21) / 365;
                                txtGratuity1to5.Text = total.ToString(".00");
                                txtGratuity6to30.Text = "0";
                                ckd_txtGratuity1to5.Checked = true;
                            }
                            else
                            {
                                txtGratuity1to5.Text = "0";
                                txtGratuity6to30.Text = "0";
                                ckd_txtGratuity1to5.Checked = true;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(ds12.Tables[0].Rows[0]["emp_doleaving"]) >= Convert.ToDateTime(ds12.Tables[0].Rows[0]["renewal"]))
                            {
                                decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                                decimal total = (Days * 21) / 365;
                                txtGratuity1to5.Text = total.ToString(".00");
                                txtGratuity6to30.Text = "0";
                                ckd_txtGratuity1to5.Checked = true;
                            }
                            else
                            {
                                decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                                decimal total = (Days * 21) / 365;
                                txtGratuity1to5.Text = total.ToString(".00");
                                txtGratuity6to30.Text = "0";
                                ckd_txtGratuity1to5.Checked = true;
                            }
                        }

                    }

                }
                else
                {
                    // decimal total = 0.00;
                    decimal Days = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal TotalfiveYrs = 5 * 365;
                    decimal total = (TotalfiveYrs * 21) / 365;
                    txtGratuity1to5.Text = total.ToString(".00");
                    decimal Y = Convert.ToInt32(ds.Tables[0].Rows[0]["total_days"]);
                    decimal Y1 = ((Days - TotalfiveYrs) * 30) / 365;
                    txtGratuity6to30.Text = Y1.ToString(".00");
                    ckd_txtGratuity6to30.Checked = true;
                    ckd_txtGratuity1to5.Checked = true;
                }
            }
        }
    }
    protected void leave_payable()
    {
        string sql = "select Entitled_days,Used_days,(Entitled_days-Used_days) as bal_days from tbl_leave_employee_leave_master where leaveid=1 and empcode=@empcode";

        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p[0].Value = txt_employee.Text;

        DataSet ds = Read(sql, p);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        txtTotalLeavePayable.Text = ds.Tables[0].Rows[0]["bal_days"].ToString();
        ckd_totalleavepayable.Checked = true;
    }
    protected void ckd_txtGratuity6to30_CheckedChanged(object sender, EventArgs e)
    {
        if (ckd_txtGratuity6to30.Checked == true)
        {
            bind_Gratuity();
            //ckd_txtGratuity6to30.Checked = true;
        }
        else
        {
            txtGratuity6to30.Text = "";
        }
    }
    protected void ckd_txtGratuity1to5_CheckedChanged(object sender, EventArgs e)
    {
        if (ckd_txtGratuity1to5.Checked == true)
        {
            bind_Gratuity();
            //ckd_txtGratuity1to5.Checked = true;
        }
        else
        {
            txtGratuity1to5.Text = "";
        }
    }
    protected void bind_totalpayabledays()
    {
        string sql = @"select top(1) salaryID , month,year,todate,DATEDIFF(DAY, salary.todate, job.emp_doleaving) as total_days  
from TBL_PAYROLL_EMPLOYEE_SALARY salary
inner join tbl_intranet_employee_jobDetails job
on job.empcode = salary.empcode
where salary.empcode=@empcode order by salaryID desc";
        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        p[0].Value = txt_employee.Text;

        DataSet ds = Read(sql, p);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        txtTotalDayPayable.Text = ds.Tables[0].Rows[0]["total_days"].ToString();
        ckd_salary_days.Checked = true;
    }
}