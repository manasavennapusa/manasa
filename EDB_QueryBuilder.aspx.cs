using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
using System.IO;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Collections;
using System.Drawing;

public partial class EDB_QueryBuilder : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataView dview;
    bool c = false;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            }
            else
                Response.Redirect("~/notlogged.aspx");
            dd_branch.Items.Insert(0, new ListItem("--All--", "0"));
            dd_designation.Items.Insert(0, new ListItem("--All--", "0"));
            dept_type.Items.Insert(0, new ListItem("--All-- ", "0"));
        }
        light.Style.Add("display", "none");
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {

    }

    protected void drpempstatus_DataBound(object sender, EventArgs e)
    {
        drpempstatus.Items.Insert(0, new ListItem("---All---", "0"));
    }

    protected void btngenerate_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();

            string query = getQuery();
            if (c == false)
            {
                ScriptManager.RegisterStartupScript(updatepannel1, updatepannel1.GetType(), "xx", "<script> alert('Please select atleast one Component')</script>", false);

            }
            else
            {
                ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt;
                    DataTable dt1;
                    dt = ds.Tables[0];

                    foreach (ListItem li in chkl_jobdetails.Items)
                    {

                        if (li.Selected == true)
                        {
                            if (li.Value == "supervisorcode")
                            {

                                if (dt.Rows[0]["Reporting Manager"].ToString() != "")
                                {

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        dt.Rows[i]["Reporting Manager"] = get_EmpName(dt.Rows[i]["Reporting Manager"].ToString());
                                    }
                                }
                            }
                            else if (li.Value == "hodcode")
                            {

                                if (dt.Rows[0]["Unit Head"].ToString() != "")
                                {

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        dt.Rows[i]["Unit Head"] = get_EmpName(dt.Rows[i]["Unit Head"].ToString());
                                    }
                                }
                            }

                            else if (li.Value == "corporatereportingcode")
                            {
                                if (dt.Rows[0]["Functional Manager"].ToString() != "")
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        dt.Rows[i]["Functional Manager"] = get_EmpName(dt.Rows[i]["Functional Manager"].ToString());
                                    }
                                }

                            }


                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                light.Style.Add("display", "block");
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

    protected string get_EmpName(string Empcode)
    {
        string Name = "";
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select empcode,isnull(emp_fname,'')+' '+isnull(emp_m_name,'')+' '+isnull(emp_l_name,'') as emp_fname from tbl_intranet_employee_jobDetails where empcode='" + Empcode + "'";
            DataSet ds_emp = new DataSet();
            ds_emp = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds_emp.Tables[0].Rows.Count < 1)
                return Name;
            else
                return Name = ds_emp.Tables[0].Rows[0]["emp_fname"].ToString();

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
        return Name;
    }

    protected void bind_ddlCCgroup()
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_cc_groupid.DataSource = ds;
            ddl_cc_groupid.DataTextField = "cost_center_group_name";
            ddl_cc_groupid.DataValueField = "id";
            ddl_cc_groupid.DataBind();
            ddl_cc_groupid.Items.Insert(0, new ListItem("--All--", "0"));
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

    protected void ddl_cc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_cc_code.Items.Clear();

        if (ddl_cc_groupid.SelectedValue != "0")
            bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));

    }

    protected void bind_cc_code(int accgroupid)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_cc_code.DataSource = ds;
            ddl_cc_code.DataTextField = "cost_center_code";
            ddl_cc_code.DataValueField = "id";
            ddl_cc_code.DataBind();
            ddl_cc_code.Items.Insert(0, new ListItem("--All--", "0"));
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

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));

    }

    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));

    }

    protected void ddl_cc_code_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected string getQuery()
    {
        string str = "";
        try
        {
            connection = activity.OpenConnection();
            string selectedColumns = "";

            #region JobDetails Query
            //-------------------------job details---------------
            string sqlstr_jobdetails = "";


            sqlstr_jobdetails = sqlstr_jobdetails + "tbl_intranet_employee_jobDetails.empcode" + " as 'Employee Code ',";
            foreach (ListItem li in chkl_jobdetails.Items)
            {

                if (li.Selected == true)
                {

                    c = true;


                    if (li.Value == "branch_id")
                    {
                        sqlstr_jobdetails = sqlstr_jobdetails + "tbl_intranet_branch_detail.branch_name" + " as '" + li.Text + "',";


                    }

                    else
                        if (li.Value == "dept_type_id")
                        {
                            sqlstr_jobdetails = sqlstr_jobdetails + "tbl_internate_department_type.dept_type_name" + " as '" + li.Text + "',";


                        }
                        else

                            if (li.Value == "dept_id")
                            {
                                sqlstr_jobdetails = sqlstr_jobdetails + "tbl_internate_departmentdetails.department_name" + " as '" + li.Text + "',";



                            }
                            else
                                if (li.Value == "division_id")
                                {
                                    sqlstr_jobdetails = sqlstr_jobdetails + "tbl_intranet_division.division_name" + " as '" + li.Text + "',";

                                }
                                else

                                    if (li.Value == "degination_id")
                                    {
                                        sqlstr_jobdetails = sqlstr_jobdetails + "tbl_intranet_designation.designationname" + " as '" + li.Text + "',";


                                    }

                                    else
                                        if (li.Value == "emp_status")
                                        {
                                            sqlstr_jobdetails = sqlstr_jobdetails + "tbl_intranet_employee_status.employeestatus" + " as '" + li.Text + "',";


                                        }
                                        else

                                            if (li.Value == "emp_type_id")
                                            {
                                                sqlstr_jobdetails = sqlstr_jobdetails + "tbl_internate_employee_type.emp_type_name" + " as '" + li.Text + "',";


                                            }

                                            else

                                                if (li.Value == "emp_subtype_id")
                                                {
                                                    sqlstr_jobdetails = sqlstr_jobdetails + "tbl_internate_employee_subtype.emp_subtype_name" + " as '" + li.Text + "',";


                                                }

                                                else

                                                    if (li.Value == "broadgroupid")
                                                    {
                                                        sqlstr_jobdetails = sqlstr_jobdetails + "dbo.tbl_intranet_broadgroup.broadgroup_name" + " as '" + li.Text + "',";


                                                    }
                                                    else

                                                        if (li.Value == "role")
                                                        {
                                                            sqlstr_jobdetails = sqlstr_jobdetails + "tbl_intranet_role.role" + " as '" + li.Text + "',";


                                                        }
                                                        else

                                                            if (li.Value == "emp_doj")
                                                            {
                                                                sqlstr_jobdetails = sqlstr_jobdetails + "(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(19), tbl_intranet_employee_jobDetails.emp_doj, 106) END) " + " as '" + li.Text + "',";


                                                            }
                                                            else

                                                                if (li.Value == "salary_cal_from")
                                                                {
                                                                    sqlstr_jobdetails = sqlstr_jobdetails + "(CASE WHEN tbl_intranet_employee_jobDetails.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(19), tbl_intranet_employee_jobDetails.salary_cal_from, 106) END) " + " as '" + li.Text + "',";


                                                                }
                                                                else

                                                                    if (li.Value == "emp_doleaving")
                                                                    {
                                                                        sqlstr_jobdetails = sqlstr_jobdetails + "(CASE WHEN tbl_intranet_employee_jobDetails.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(19), tbl_intranet_employee_jobDetails.emp_doleaving, 106) END) " + " as '" + li.Text + "',";


                                                                    }
                                                                    else
                                                                    {
                                                                        sqlstr_jobdetails = sqlstr_jobdetails + "tbl_intranet_employee_jobDetails." + li.Value + " as '" + li.Text + "',";
                                                                    }
                }
            }



            if (sqlstr_jobdetails != "")
            {
                sqlstr_jobdetails = sqlstr_jobdetails.Substring(0, sqlstr_jobdetails.Length - 1);
                selectedColumns = selectedColumns + sqlstr_jobdetails;
            }
            #endregion
            #region Payroll Query
            string sqlstr_payrolldetails = "";
            //sqlstr = "select ";
            foreach (ListItem li in chk_payrolldetails.Items)
            {

                if (li.Selected == true)
                {
                    c = true;
                    sqlstr_payrolldetails = sqlstr_payrolldetails + "tbl_intranet_employee_payrollDetails." + li.Value + " as '" + li.Text + "',";
                }
            }



            if (sqlstr_payrolldetails != "")
            {

                sqlstr_payrolldetails = sqlstr_payrolldetails.Substring(0, sqlstr_payrolldetails.Length - 1);
                if (selectedColumns.Length > 1)
                {
                    selectedColumns = selectedColumns + "," + sqlstr_payrolldetails;
                }
                else
                {
                    selectedColumns = selectedColumns + sqlstr_payrolldetails;
                }

            }
            #endregion
            #region Approvers Query
            string sqlstr_approverdetails = "";
            //sqlstr = "select ";
            foreach (ListItem li in chkapprover.Items)
            {

                if (li.Selected == true)
                {
                    c = true;
                    String Col_name = li.Value;
                    Col_name = Col_name + "_n";// ------ to get name column
                    String Col_alias_name = li.Text;
                    Col_alias_name = Col_alias_name + "_name"; // ------ to get name column heading

                    sqlstr_approverdetails = sqlstr_approverdetails + "vw_approvers." + li.Value + " as '" + li.Text + "',";
                    sqlstr_approverdetails = sqlstr_approverdetails + "vw_approvers." + Col_name + " as '" + Col_alias_name + "',";
                }
            }



            if (sqlstr_approverdetails != "")
            {

                sqlstr_approverdetails = sqlstr_approverdetails.Substring(0, sqlstr_approverdetails.Length - 1);
                if (selectedColumns.Length > 1)
                {
                    selectedColumns = selectedColumns + "," + sqlstr_approverdetails;
                }
                else
                {
                    selectedColumns = selectedColumns + sqlstr_approverdetails;
                }

            }
            #endregion
            #region Personal Query
            string sqlstr_personaldetails = "";
            foreach (ListItem li in chk_personalDetails.Items)
            {

                if (li.Selected == true)
                {
                    c = true;
                    if (li.Value == "bank_name")
                    {
                        sqlstr_personaldetails = sqlstr_personaldetails + "tbl_payroll_bank.bankname" + " as '" + li.Text + "',";


                    }

                    else
                        if (li.Value == "tbl_intranet_employee_personalDetails.dob")
                        {
                            sqlstr_personaldetails = sqlstr_personaldetails + "tbl_intranet_employee_personalDetails.dob" + " as '" + li.Text + "',";
                        }
                        else
                            if (li.Value == "paymentmode")
                            {
                                sqlstr_personaldetails = sqlstr_personaldetails + "case when tbl_intranet_employee_personalDetails.paymentmode='0' then 'Bank' else case when tbl_intranet_employee_personalDetails.paymentmode='1' then 'Cash' else 'Cheque' end end " + " as '" + li.Text + "',";


                            }


                            else
                                if (li.Value == "passportissuedate")
                                {
                                    sqlstr_personaldetails = sqlstr_personaldetails + "(CASE WHEN passportissuedate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(19), passportissuedate, 106) END) " + " as '" + li.Text + "',";


                                }
                                else
                                    if (li.Value == "passportexpiraydate")
                                    {
                                        sqlstr_personaldetails = sqlstr_personaldetails + "(CASE WHEN passportexpiraydate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(19), passportexpiraydate, 106) END) " + " as '" + li.Text + "',";

                                    }
                                    else
                                        if (li.Value == "dribing_lic_iss_date")
                                        {
                                            sqlstr_personaldetails = sqlstr_personaldetails + "(CASE WHEN dribing_lic_iss_date = '01/01/1900' THEN '' ELSE CONVERT(CHAR(19), dribing_lic_iss_date, 106) END) " + " as '" + li.Text + "',";


                                        }
                                        else
                                            if (li.Value == "driving_lic_exp_date")
                                            {
                                                sqlstr_personaldetails = sqlstr_personaldetails + "(CASE WHEN driving_lic_exp_date = '01/01/1900' THEN '' ELSE CONVERT(CHAR(19), tbl_intranet_employee_personalDetails.dob, 106) END) " + " as '" + li.Text + "',";

                                            }
                                            else
                                                if (li.Value == "child_name")
                                                {
                                                    sqlstr_personaldetails = sqlstr_personaldetails + "tbl_intranet_employee_childrendetail.child_name" + " as '" + li.Text + "',";

                                                }
                                                else
                                                    if (li.Value == "gender")
                                                    {
                                                        sqlstr_personaldetails = sqlstr_personaldetails + "tbl_intranet_employee_childrendetail.gender" + " as '" + li.Text + "',";

                                                    }
                                                    else
                                                        if (li.Value == "childdob")
                                                        {
                                                            sqlstr_personaldetails = sqlstr_personaldetails + "childdob" + " as '" + li.Text + "',";

                                                        }
                                                        else
                                                            sqlstr_personaldetails = sqlstr_personaldetails + "tbl_intranet_employee_personalDetails." + li.Value + " as '" + li.Text + "',";
                }
            }


            if (sqlstr_personaldetails != "")
            {
                sqlstr_personaldetails = sqlstr_personaldetails.Substring(0, sqlstr_personaldetails.Length - 1);
                if (selectedColumns.Length > 1)
                {
                    selectedColumns = selectedColumns + "," + sqlstr_personaldetails;
                }
                else
                {
                    selectedColumns = selectedColumns + sqlstr_personaldetails;
                }

            }
            #endregion
            #region Contact Query
            string sqlstr_contactdetails = "";
            foreach (ListItem li in chk_contactdetails.Items)
            {

                if (li.Selected == true)
                {
                    c = true;
                    if (li.Value == "mode")
                    {

                        sqlstr_contactdetails = sqlstr_contactdetails + "case when mode=0 then 'Own' else case when mode=1 then 'Company Vehicle' else '' end end" + " as '" + li.Text + "',";

                    }
                    else
                        sqlstr_contactdetails = sqlstr_contactdetails + "tbl_intranet_employee_contactlist." + li.Value + " as '" + li.Text + "',";
                }
            }



            if (sqlstr_contactdetails != "")
            {
                sqlstr_contactdetails = sqlstr_contactdetails.Substring(0, sqlstr_contactdetails.Length - 1);
                if (selectedColumns.Length > 1)
                {
                    selectedColumns = selectedColumns + "," + sqlstr_contactdetails;
                }
                else
                {
                    selectedColumns = selectedColumns + sqlstr_contactdetails;
                }
            }

            #endregion
            #region Where Condition Query

            string wherecodition = "";

            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("tbl_intranet_employee_jobDetails");
            query.SelectColumns(selectedColumns);


            if (sqlstr_payrolldetails != "")
            {
                query.AddJoin(JoinType.InnerJoin,
                          "tbl_intranet_employee_payrollDetails", "empcode",
                          Comparison.Equals,
                          "tbl_intranet_employee_jobDetails", "empcode");
            }
            if (sqlstr_approverdetails != "")
            {
                query.AddJoin(JoinType.InnerJoin,
                          "vw_approvers", "empcode",
                          Comparison.Equals,
                          "tbl_intranet_employee_jobDetails", "empcode");
            }

            if (sqlstr_personaldetails != "")
            {
                query.AddJoin(JoinType.InnerJoin,
                          "tbl_intranet_employee_personalDetails", "empcode",
                          Comparison.Equals,
                          "tbl_intranet_employee_jobDetails", "empcode");
                //-------------- left join  Bank Master ---------

                query.AddJoin(JoinType.LeftJoin,
                             "dbo.tbl_payroll_bank", "branchcode",
                             Comparison.Equals,
                             "tbl_intranet_employee_personalDetails", "bank_name");


                query.AddJoin(JoinType.LeftJoin,
                            "tbl_intranet_employee_childrendetail", "empcode",
                            Comparison.Equals,
                            "tbl_intranet_employee_personalDetails", "empcode");

            }

            if (sqlstr_contactdetails != "")
            {
                query.AddJoin(JoinType.InnerJoin,
                          "tbl_intranet_employee_contactlist", "empcode",
                          Comparison.Equals,
                          "tbl_intranet_employee_jobDetails", "empcode");
            }
            //--- For Selecting Dates ----------------
            if ((drpempstatus.SelectedValue != "4") || (drpempstatus.SelectedValue == "0"))
            {
                wherecodition = wherecodition + " tbl_intranet_employee_jobDetails.emp_doleaving is null and tbl_intranet_employee_jobDetails.status=1 ";

                if (txtfromdate.Text != "" && txttodate.Text != "")
                {
                    if (wherecodition != "")
                    {
                        wherecodition = wherecodition + " and convert(datetime,tbl_intranet_employee_jobDetails.emp_doj) BETWEEN    convert(datetime,'" + txtfromdate.Text + "') and  convert(datetime,'" + txttodate.Text + "')";
                    }
                    else
                        wherecodition = wherecodition + "  convert(datetime,tbl_intranet_employee_jobDetails.emp_doj) BETWEEN    convert(datetime,'" + txtfromdate.Text + "') and  convert(datetime,'" + txttodate.Text + "')";
                }


            }
            else
            {
                if (txtfromdate.Text != "" && txttodate.Text != "")
                {
                    if (wherecodition != "")
                        wherecodition = wherecodition + " and  convert(datetime,tbl_intranet_employee_jobDetails.emp_doleaving) BETWEEN    convert(datetime,'" + txtfromdate.Text + "') and  convert(datetime,'" + txttodate.Text + "')";
                    else
                        wherecodition = wherecodition + "  convert(datetime,tbl_intranet_employee_jobDetails.emp_doleaving) BETWEEN    convert(datetime,'" + txtfromdate.Text + "') and  convert(datetime,'" + txttodate.Text + "')";
                }
            }
            //-------------- left join  Branch ---------

            query.AddJoin(JoinType.LeftJoin,
                       "tbl_intranet_branch_detail", "Branch_Id",
                       Comparison.Equals,
                       "tbl_intranet_employee_jobDetails", "Branch_Id");
            if (drpbranch.SelectedValue != "0")
            {

                if (wherecodition != "")
                {
                    wherecodition = wherecodition + " and tbl_intranet_branch_detail.Branch_Id='" + drpbranch.SelectedValue + "'";
                }
                else
                {
                    wherecodition = wherecodition + " tbl_intranet_branch_detail.Branch_Id='" + drpbranch.SelectedValue + "'";
                }
            }

            //-------------- left join  Depatment ---------

            query.AddJoin(JoinType.LeftJoin,
                      "tbl_internate_departmentdetails", "departmentid",
                      Comparison.Equals,
                      "tbl_intranet_employee_jobDetails", "dept_id");
            if (dd_branch.SelectedValue != "0")
            {
                if (wherecodition != "")
                {
                    wherecodition = wherecodition + " and tbl_internate_departmentdetails.departmentid='" + dd_branch.SelectedValue + "'";
                }
                else
                {
                    wherecodition = wherecodition + " tbl_internate_departmentdetails.departmentid='" + dd_branch.SelectedValue + "'";
                }
            }


            //-------------- left join  empstatus ---------

            query.AddJoin(JoinType.LeftJoin,
                      "tbl_intranet_employee_status", "id",
                      Comparison.Equals,
                      "tbl_intranet_employee_jobDetails", "emp_status");
            if (drpempstatus.SelectedValue != "0")
            {
                if (wherecodition != "")
                {
                    wherecodition = wherecodition + " and tbl_intranet_employee_jobDetails.emp_status='" + drpempstatus.SelectedValue + "'";
                }
                else
                {
                    wherecodition = wherecodition + " tbl_intranet_employee_jobDetails.emp_status='" + drpempstatus.SelectedValue + "'";
                }
            }


            ////-------------- left join  Role ---------

            query.AddJoin(JoinType.LeftJoin,
                      "tbl_login", "empcode",
                      Comparison.Equals,
                      "tbl_intranet_employee_jobDetails", "empcode");

            query.AddJoin(JoinType.LeftJoin,
              "tbl_intranet_role", "id",
              Comparison.Equals,
              "tbl_login", "role");


            query.AddJoin(JoinType.LeftJoin,
              "tbl_internate_department_type", "dept_type_id",
              Comparison.Equals,
              "tbl_intranet_employee_jobDetails", "dep_type_id");

            query.AddJoin(JoinType.LeftJoin,
            "tbl_internate_employee_subtype", "emp_subtype_id",
            Comparison.Equals,
            "tbl_intranet_employee_jobDetails", "sub_emp_type");

            query.AddJoin(JoinType.LeftJoin,
            "tbl_internate_employee_type", "emp_type_id",
            Comparison.Equals,
            "tbl_intranet_employee_jobDetails", "employee_type");


            //-------------- left join  Division ---------

            query.AddJoin(JoinType.LeftJoin,
                      "tbl_intranet_division", "ID",
                      Comparison.Equals,
                      "tbl_intranet_employee_jobDetails", "division_id");

            //-------------- left join  Designation ---------

            query.AddJoin(JoinType.LeftJoin,
                      "tbl_intranet_designation", "id",
                      Comparison.Equals,
                      "tbl_intranet_employee_jobDetails", "degination_id");
            if (dd_designation.SelectedValue != "0")
            {
                if (wherecodition != "")
                {
                    wherecodition = wherecodition + " and tbl_intranet_designation.id='" + dd_designation.SelectedValue + "'";
                }
                else
                {
                    wherecodition = wherecodition + "  tbl_intranet_designation.id='" + dd_designation.SelectedValue + "'";
                }
            }
            //-------------- left join  Broad group ---------


            query.AddJoin(JoinType.LeftJoin,
                      "dbo.tbl_intranet_broadgroup", "id",
                      Comparison.Equals,
                      "tbl_intranet_employee_jobDetails", "broadgroupid");

            if (txtfirstname.Text != "")
            {
                if (wherecodition != "")
                {
                    wherecodition = wherecodition + " and (tbl_intranet_employee_jobDetails.emp_fname like '" + txtfirstname.Text.Trim() + "%' or tbl_intranet_employee_jobDetails.empcode like '" + txtfirstname.Text.Trim() + "%')";
                }
                else
                {
                    wherecodition = wherecodition + " (tbl_intranet_employee_jobDetails.emp_fname like '" + txtfirstname.Text.Trim() + "%' or tbl_intranet_employee_jobDetails.empcode like '" + txtfirstname.Text.Trim() + "%')";
                }
            }
            if (txtmidlename.Text != "")
            {
                if (wherecodition != "")
                {
                    wherecodition = wherecodition + " and  tbl_intranet_employee_jobDetails.emp_m_name like '" + txtmidlename.Text + "%'";
                }
                else
                {
                    wherecodition = wherecodition + " tbl_intranet_employee_jobDetails.emp_m_name like  '" + txtmidlename.Text + "%'";
                }
            }
            if (txtlastname.Text != "")
            {
                if (wherecodition != "")
                {
                    wherecodition = wherecodition + " and tbl_intranet_employee_jobDetails.emp_l_name like '" + txtlastname.Text + "%'";
                }
                else
                {
                    wherecodition = wherecodition + " tbl_intranet_employee_jobDetails.emp_l_name like '" + txtlastname.Text + "%'";
                }
            }


            if (wherecodition != "")
            {
                wherecodition = "where" + wherecodition;
            }
            wherecodition = wherecodition + " order by tbl_intranet_employee_jobDetails.empcode";
            #endregion

            str = query.BuildQuery().ToString();
            str = str + wherecodition;
            return str;
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
        return str;
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {
        string query = getQuery();
        if (c == false)
        {
            ScriptManager.RegisterStartupScript(updatepannel1, updatepannel1.GetType(), "xx", "<script> alert('Please select atleast one Component')</script>", false);

        }
        else
        {
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt;
                DataTable dt1;
                dt = ds.Tables[0];

                foreach (ListItem li in chkl_jobdetails.Items)
                {

                    if (li.Selected == true)
                    {
                        if (li.Value == "supervisorcode")
                        {

                            if (dt.Rows[0]["Reporting Manager"].ToString() != "")
                            {

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dt.Rows[i]["Reporting Manager"] = get_EmpName(dt.Rows[i]["Reporting Manager"].ToString());
                                }
                            }
                        }
                        else if (li.Value == "hodcode")
                        {

                            if (dt.Rows[0]["Unit Head"].ToString() != "")
                            {

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dt.Rows[i]["Unit Head"] = get_EmpName(dt.Rows[i]["Unit Head"].ToString());
                                }
                            }
                        }

                        else if (li.Value == "corporatereportingcode")
                        {
                            if (dt.Rows[0]["Functional Manager"].ToString() != "")
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dt.Rows[i]["Functional Manager"] = get_EmpName(dt.Rows[i]["Functional Manager"].ToString());
                                }
                            }

                        }


                    }
                }
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Empdetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
                DataGrid dg = new DataGrid();
                dg.DataSource = dt;
                dg.DataBind();

                String style = @"<style>.text{mso-number-format:\@;}</style>";
                HttpContext.Current.Response.Write(style);
                int colindex = 0;
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string valuetype = dc.DataType.ToString();
                    foreach (DataGridItem i in dg.Items)
                        i.Cells[colindex].Attributes.Add("class", "text");
                    colindex++;
                }

                dg.RenderControl(htmlwrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
        }
    }

    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkl_jobdetails.Items.Count; i++)
        {
            chkl_jobdetails.Items[i].Selected = true;
        }
    }

    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkl_jobdetails.Items.Count; i++)
        {
            chkl_jobdetails.Items[i].Selected = false;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_payrolldetails.Items.Count; i++)
        {
            chk_payrolldetails.Items[i].Selected = true;
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_payrolldetails.Items.Count; i++)
        {
            chk_payrolldetails.Items[i].Selected = false;
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_personalDetails.Items.Count; i++)
        {
            chk_personalDetails.Items[i].Selected = true;
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_personalDetails.Items.Count; i++)
        {
            chk_personalDetails.Items[i].Selected = false;
        }
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_contactdetails.Items.Count; i++)
        {
            chk_contactdetails.Items[i].Selected = true;
        }
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_contactdetails.Items.Count; i++)
        {
            chk_contactdetails.Items[i].Selected = false;
        }
    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmenttype(Convert.ToInt16(drpbranch.SelectedValue));
    }

    private void bind_departmenttype(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type WHERE branch_id='" + branchid + "' order by dept_type_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            dept_type.DataTextField = "dept_type_name";
            dept_type.DataValueField = "dept_type_id";
            dept_type.DataSource = ds1;
            dept_type.DataBind();
            dept_type.Items.Insert(0, new ListItem("--All-- ", "0"));
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

    protected void BindDepartment(int dept_type)
    {

        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails where dept_type_id='" + dept_type + "' order by department_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            dd_branch.DataTextField = "department_name";
            dd_branch.DataValueField = "departmentid";
            dd_branch.DataSource = ds1;
            dd_branch.DataBind();
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

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkapprover.Items.Count; i++)
        {
            chkapprover.Items[i].Selected = true;
        }

    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkapprover.Items.Count; i++)
        {
            chkapprover.Items[i].Selected = false;
        }
    }

    protected void dd_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDesignation(Convert.ToInt16(dd_branch.SelectedValue));
    }

    #region Bind Department

    private void BindDesignation(int deptid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dd_designation.DataSource = ds;
                dd_designation.DataTextField = "designationname";
                dd_designation.DataValueField = "id";
                dd_designation.DataBind();
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

    #endregion

    protected void dept_type_DataBound(object sender, EventArgs e)
    {
        //dept_type.Items.Insert(0, new ListItem(" All ", "0"));
    }

    protected void dept_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDepartment(Convert.ToInt32(dept_type.SelectedValue));
    }

}