using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Encode;
using Common.Data;
using Common.Console;
using System.Data.SqlClient;

public partial class Training_AddParticipants : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    string sqlstr, _userCode, _companyId, RoleId, fromdate, todate, modulename, trainingcode, trainingname, modulenamess, Faculty;
    int tid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
             tid = Convert.ToInt16(Request.QueryString["id"]);

             fromdate = Request.QueryString["FromDate"].ToString();
             todate = Request.QueryString["ToDate"].ToString();
             modulename = Request.QueryString["module_name"].ToString();
             trainingcode = Request.QueryString["training_code"].ToString();
             trainingname = Request.QueryString["training_name"].ToString();
             string ame = Request.QueryString["module_name"].ToString();
             Faculty = Request.QueryString["Faculty"].ToString();
            if (!IsPostBack)
            {
                bind_branch();
                bind_addparticipantsLM();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void bind_branch()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select branch_id,branch_name from tbl_intranet_branch_detail";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpbranch.DataTextField = "branch_name";
            drpbranch.DataValueField = "branch_id";
            drpbranch.DataSource = ds1;
            drpbranch.DataBind();
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





    //protected void Grid_Addparticipants_PreRender(object sender, EventArgs e)
    //{

    //}

    //protected void btn_select_Click(object sender, EventArgs e)
    //{
    //    if (Grid_Addparticipants.Rows.Count > 0)
    //    {
    //        foreach (GridViewRow row in Grid_Addparticipants.Rows)
    //        {
    //            CheckBox chk = (CheckBox)row.FindControl("chk");
    //            chk.Checked = true;
    //        }
    //    }

    //}

    //protected void btn_deselect_Click(object sender, EventArgs e)
    //{
    //    if (Grid_Addparticipants.Rows.Count > 0)
    //    {
    //        foreach (GridViewRow row in Grid_Addparticipants.Rows)
    //        {
    //            CheckBox chk = (CheckBox)row.FindControl("chk");
    //            chk.Checked = false;
    //        }
    //    }

    //}


    protected void bind_addparticipantsLM()
    {
        int deptidid = Convert.ToInt16(Request.QueryString["dept_name"]);
        //int tid = Convert.ToInt16(Request.QueryString["id"]);
        try
        {
            connection = activity.OpenConnection();
            string strng = @"select module_name from tbl_training_schedul where id='" + tid + "'"; 
            DataSet dsInsertedEmps = SQLServer.ExecuteDataset(connection, CommandType.Text, strng);
            if (dsInsertedEmps.Tables[0].Rows.Count < 1)
            {
                return;
            }
            else
            {
                modulenamess = dsInsertedEmps.Tables[0].Rows[0]["module_name"].ToString();
            }
//            string sqlstr = @"select distinct emp.empcode,emp.emp_fname,db.department_name,de.designationname,
//bd.branch_name,app.app_reportingmanager 
//from tbl_intranet_employee_jobDetails emp
//inner join tbl_training_schedul ts on emp.dept_id= ts.dept_name 
//inner join tbl_internate_departmentdetails db on db.departmentid=emp.dept_id 
//inner join tbl_intranet_designation de on de.id=emp.degination_id
//inner join tbl_intranet_branch_detail bd on emp.branch_id= bd.branch_id
//left join dbo.tbl_employee_approvers app on ts.createdby=app.empcode
//where emp.dept_id='" + deptidid + "' and ts.approverstatus='1' and emp.empcode not in (select empcode from tbl_training_elegible_emp where fromdate='" + fromdate + "' and todate='" + todate + "')";

            string sqlstr = @"select distinct emp.empcode,emp.emp_fname,db.department_name,de.designationname,
bd.branch_name,app.app_reportingmanager 
from tbl_intranet_employee_jobDetails emp
inner join tbl_training_schedul ts on emp.branch_id= ts.branch 
inner join tbl_internate_departmentdetails db on db.departmentid=emp.dept_id 
inner join tbl_intranet_designation de on de.id=emp.degination_id
inner join tbl_intranet_branch_detail bd on emp.branch_id= bd.branch_id
left join dbo.tbl_employee_approvers app on emp.empcode=app.empcode
where app.app_reportingmanager='" + _userCode + "' and emp.emp_status!='2' and ts.approverstatus='1' and emp.empcode not in (select empcode from tbl_training_elegible_emp where fromdate='" + fromdate + "' and todate='" + todate + "' and modulename='" + modulenamess + "' and training_name='" + trainingname + "' and training_code='" + trainingcode + "')";

            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 1)
            {
                return;
            }
            Grid_Addparticipants.DataSource = ds1;
            Grid_Addparticipants.DataBind();
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

    protected void Grid_Addparticipants_PreRender1(object sender, EventArgs e)
    {
        if (Grid_Addparticipants.Rows.Count > 0)
        {
            Grid_Addparticipants.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void Grid_Addparticipants_chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)Grid_Addparticipants.HeaderRow.FindControl("Grid_Addparticipants_chkSelectAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in Grid_Addparticipants.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in Grid_Addparticipants.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {

    }

    protected void btn_approve_Click(object sender, EventArgs e)
    {
        

        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            //if (Session["appcycle"] != null)
            {
                string saved = "", notsaved = "";

                SqlParameter[] sqlParam = new SqlParameter[12];
                //Output.AssignParameter(sqlParam, 0, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
                //string a = Session["appcycle"].ToString();
                if (Grid_Addparticipants.Rows.Count > 0)
                {
                    Connection = activity.OpenConnection();

                    string strng = @"select module_name from tbl_training_schedul where id='" + tid + "'";
                    DataSet dsInsertedEmps = SQLServer.ExecuteDataset(Connection, CommandType.Text, strng);
                    modulenamess = dsInsertedEmps.Tables[0].Rows[0]["module_name"].ToString();

                    foreach (GridViewRow row in Grid_Addparticipants.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                        if (chk.Checked)
                        {
                            Label emp = (Label)row.FindControl("l0");
                            Label training_code = (Label)row.FindControl("l1");
                            Label training_name = (Label)row.FindControl("l2");
                            Label emp_fname = (Label)row.FindControl("l3");
                            Label designationname = (Label)row.FindControl("l4");
                            Label department_name = (Label)row.FindControl("l5");
                            Label branch_name = (Label)row.FindControl("l6");
                            Label trining_id = (Label)row.FindControl("l7");
                            //Label Fauclty = (Label)row.FindControl("l7");
                            string createdby = Session["empcode"].ToString();
                            Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, emp.Text);
                            Output.AssignParameter(sqlParam, 1, "@training_code", "String", 50, trainingcode);
                            Output.AssignParameter(sqlParam, 2, "@training_name", "String", 100, trainingname);
                            Output.AssignParameter(sqlParam, 3, "@emp_fname", "String", 50, emp_fname.Text);
                            Output.AssignParameter(sqlParam, 4, "@designationname", "String", 100, designationname.Text);
                            Output.AssignParameter(sqlParam, 5, "@department_name", "String", 100, department_name.Text);
                            Output.AssignParameter(sqlParam, 6, "@branch_name", "String", 50, branch_name.Text);
                            Output.AssignParameter(sqlParam, 7, "@create_by", "String", 50, createdby);
                            //Output.AssignParameter(sqlParam, 8, "@trining_id", "Int", 0, trining_id.Text);
                            Output.AssignParameter(sqlParam, 8, "@fromdate", "DateTime", 0, fromdate);
                            Output.AssignParameter(sqlParam, 9, "@todate", "DateTime", 0, todate);
                            Output.AssignParameter(sqlParam, 10, "@modulename", "String", 100, modulenamess);
                            Output.AssignParameter(sqlParam, 11, "@Faculty", "String", 100, Faculty);
                          

                            int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_training_insert_elegible_LM", sqlParam);

                            if (i > 0)
                            {
                                saved = saved + " " + emp.Text;
                                DataTable dt;
                                dt = (DataTable)ViewState["GetRecords"];
                                //dt = RemoveRowSecond(row, dt);
                                ViewState["GetRecords"] = dt;
                            }
                            else
                                notsaved = notsaved + " " + emp.Text;
                            // empgrid2.DeleteRow(this.G);
                        }
                    }
                    if (notsaved.Trim() == "" && saved.Trim() == "")
                        Output.Show("Please Select Employees");

                    if (notsaved.Trim() == "" && saved.Trim() != "")
                        Output.Show("Employees Selected Successfully");
                    //else
                    //{
                    //    string alert = "";
                    //    if (notsaved.Trim() != "")
                    //        alert = "[ " + notsaved + " ] Employee(s) are already exists.    ";
                    //    if (saved.Trim() != "")
                    //        alert = alert + "[ " + saved + " ]  Employee(s) are Successfully Saved.";

                    //    Output.Show(alert);
                    //}
                }
                else
                {
                    Output.Show("Please Select Employees");
                }
            }
            //else
            //{
            //    Output.Show("Please Create Appraisal Cycle");
            //}
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {

            bind_addparticipantsLM();
            activity.CloseConnection();

        }

    }

    //protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    bind_departmenttype(Convert.ToInt16(drpbranch.SelectedValue));

    //}

    //private void bind_departmenttype(int branchid)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type WHERE branch_id='" + branchid + "' order by dept_type_name";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        dept_type.DataTextField = "dept_type_name";
    //        dept_type.DataValueField = "dept_type_id";
    //        dept_type.DataSource = ds1;
    //        dept_type.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}


    //protected void drpbranch_DataBound(object sender, EventArgs e)
    //{

    //}
    //protected void dept_type_DataBound(object sender, EventArgs e)
    //{

    //}
    //protected void dept_type_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bind_departmnt(Convert.ToInt16(dept_type.SelectedValue));
    //}

    //private void bind_departmnt(int dept_type)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails where dept_type_id='" + dept_type + "' order by department_name";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpdepartment.DataTextField = "department_name";
    //        drpdepartment.DataValueField = "departmentid";
    //        drpdepartment.DataSource = ds1;
    //        drpdepartment.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

    //protected void drpdepartment_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void drpdepartment_DataBound(object sender, EventArgs e)
    //{

    //}
    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    bindempdetail();
    //}

    //protected void bindempdetail()
    //{

    //    try
    //    {
    //        if (RoleId == "28")
    //        {
    //            connection = activity.OpenConnection();
    //            SqlParameter[] sqlparam = new SqlParameter[4];

    //            //sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
    //            //sqlparam[0].Value = txt_employee.Text.Trim().ToString();

    //            //sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
    //            //sqlparam[1].Value = drpdegination.SelectedValue;

    //            sqlparam[0] = new SqlParameter("@department", SqlDbType.Int);
    //            sqlparam[0].Value = drpdepartment.SelectedValue;

    //            sqlparam[1] = new SqlParameter("@status", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = "All";

    //            sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
    //            if (drpbranch.SelectedValue != "")
    //                sqlparam[2].Value = drpbranch.SelectedValue;
    //            else
    //                sqlparam[2].Value = "0";

    //            sqlparam[3] = new SqlParameter("@id", SqlDbType.Int);
    //            sqlparam[3].Value = tid;

    //            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_emp_detail2_shadow", sqlparam);
    //            Grid_Addparticipants.DataSource = ds;
    //            Grid_Addparticipants.DataBind();
    //        }
    //        else
    //        {
    //            connection = activity.OpenConnection();
    //            SqlParameter[] sqlparam = new SqlParameter[4];

    //            //sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
    //            //sqlparam[0].Value = txt_employee.Text.Trim().ToString();

    //            //sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
    //            //sqlparam[1].Value = drpdegination.SelectedValue;

    //            sqlparam[0] = new SqlParameter("@department", SqlDbType.Int);
    //            sqlparam[0].Value = drpdepartment.SelectedValue;

    //            sqlparam[1] = new SqlParameter("@status", SqlDbType.VarChar, 50);
    //            sqlparam[1].Value = "All";

    //            sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
    //            if (drpbranch.SelectedValue != "")
    //                sqlparam[2].Value = drpbranch.SelectedValue;
    //            else
    //                sqlparam[2].Value = "0";

    //            sqlparam[3] = new SqlParameter("@tid", SqlDbType.Int);
    //            sqlparam[3].Value = tid;

    //            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_training_fetch_emp_detail2", sqlparam);
    //            Grid_Addparticipants.DataSource = ds;
    //            Grid_Addparticipants.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}


    //protected void trainingid_DataBound(object sender, EventArgs e)
    //{
    //    trainingid.Items.Insert(0, new ListItem("--All--", "0"));
    //}
    //protected void trainingid_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bind_tainingcode(Convert.ToInt16(trainingid.SelectedValue));
    //}

    //private void bind_tainingcode(int trainingid)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select id,training_name from tbl_training_elegible_emp where trining_id='" + trainingid + "' order by training_name";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpcode.DataTextField = "training_name";
    //        drpcode.DataValueField = "id";
    //        drpcode.DataSource = ds1;
    //        drpcode.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}


    //protected void drpcode_DataBound(object sender, EventArgs e)
    //{
    //    drpcode.Items.Insert(0, new ListItem("--All--", "0"));
    //}
    //protected void drpcode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // bind_tainingcodename(Convert.ToInt16(trainingid.SelectedValue));
    //}

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

    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void dept_type_DataBound(object sender, EventArgs e)
    {
        dept_type.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void dept_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(dept_type.SelectedValue));
    }

    private void bind_departmnt(int dept_type)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails where dept_type_id='" + dept_type + "' order by department_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartment.DataTextField = "department_name";
            drpdepartment.DataValueField = "departmentid";
            drpdepartment.DataSource = ds1;
            drpdepartment.DataBind();
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

    protected void drpdepartment_SelectedIndexChanged(object sender, EventArgs e)
    {

        bind_tainingid(Convert.ToInt16(drpdepartment.SelectedValue));

    }

    private void bind_tainingid(int drpdepartment)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id,training_name from tbl_training_schedul where dept_name='" + drpdepartment + "' order by training_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            //trainingid.DataTextField = "training_name";
            trainingid.DataValueField = "id";
            trainingid.DataSource = ds1;
            trainingid.DataBind();
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

    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void bindempdetail()
    {

        try
        {
            if (RoleId == "28")
            {
                connection = activity.OpenConnection();
                SqlParameter[] sqlparam = new SqlParameter[4];

                //sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
                //sqlparam[0].Value = txt_employee.Text.Trim().ToString();

                //sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
                //sqlparam[1].Value = drpdegination.SelectedValue;

                sqlparam[0] = new SqlParameter("@department", SqlDbType.Int);
                sqlparam[0].Value = drpdepartment.SelectedValue;

                sqlparam[1] = new SqlParameter("@status", SqlDbType.VarChar, 50);
                sqlparam[1].Value = "All";

                sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
                if (drpbranch.SelectedValue != "")
                    sqlparam[2].Value = drpbranch.SelectedValue;
                else
                    sqlparam[2].Value = "0";

                sqlparam[3] = new SqlParameter("@id", SqlDbType.Int);
                sqlparam[3].Value = trainingid.SelectedValue;

                ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_training_fetch_need_emp_detail2", sqlparam);
                Grid_Addparticipants.DataSource = ds;
                Grid_Addparticipants.DataBind();
            }
            else
            {
                connection = activity.OpenConnection();
                SqlParameter[] sqlparam = new SqlParameter[4];

                //sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
                //sqlparam[0].Value = txt_employee.Text.Trim().ToString();

                //sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
                //sqlparam[1].Value = drpdegination.SelectedValue;

                sqlparam[0] = new SqlParameter("@department", SqlDbType.Int);
                if ((drpdepartment.SelectedValue == "0") || (drpdepartment.SelectedValue == ""))
                {
                    sqlparam[0].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    sqlparam[0].Value = drpdepartment.SelectedValue;
                }

                sqlparam[1] = new SqlParameter("@status", SqlDbType.VarChar, 50);
                sqlparam[1].Value = "All";

                sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
                if (drpbranch.SelectedValue != "")
                    sqlparam[2].Value = drpbranch.SelectedValue;
                else
                    sqlparam[2].Value = "0";

                sqlparam[3] = new SqlParameter("@tid", SqlDbType.Int);
                if (trainingid.SelectedValue != "")
                    sqlparam[3].Value = trainingid.SelectedValue;
                else
                    sqlparam[3].Value = "0";

                ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_training_fetch_need_emp_detail2", sqlparam);
                Grid_Addparticipants.DataSource = ds;
                Grid_Addparticipants.DataBind();
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

    protected void trainingid_DataBound(object sender, EventArgs e)
    {
        trainingid.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void trainingid_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_tainingcode(Convert.ToInt16(trainingid.SelectedValue));
    }

    private void bind_tainingcode(int trainingid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id,training_name from tbl_training_elegible_emp where trining_id='" + trainingid + "' order by training_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpcode.DataTextField = "training_name";
            drpcode.DataValueField = "id";
            drpcode.DataSource = ds1;
            drpcode.DataBind();
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

    protected void drpcode_DataBound(object sender, EventArgs e)
    {
        drpcode.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void drpcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        // bind_tainingcodename(Convert.ToInt16(trainingid.SelectedValue));
    }

}