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
using DataAccessLayer;

public partial class Training_viewby_addparticipants : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    string sqlstr, _userCode, _companyId, RoleId, fromdate, todate, modulename, modulenamess, Faculty;
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
            Faculty = Request.QueryString["Faculty"].ToString();
            if (!IsPostBack)
            {
                bind_addparticipantsLM();
            }
        }
    }

    private void bind_addparticipantsLM()
    {
        int deptid = Convert.ToInt16(Request.QueryString["dept_name"].ToString());
        //int tid = Convert.ToInt16(Request.QueryString["id"].ToString());
        //int tid = 1;
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
            //            string sqlstr = @"
            //select emp.empcode,
            //emp.emp_fname,
            //db.department_name,
            //de.designationname,
            //ts.training_code,
            //ts.training_name,
            //bd.branch_name,
            //ts.id,
            //app.app_reportingmanager 
            //from tbl_intranet_employee_jobDetails emp
            //inner join tbl_training_schedul ts on emp.dept_id= ts.dept_name 
            //inner join tbl_internate_departmentdetails db on db.departmentid=emp.dept_id 
            //inner join tbl_intranet_designation de on de.id=emp.degination_id
            //inner join tbl_intranet_branch_detail bd on emp.branch_id= bd.branch_id
            //left join dbo.tbl_employee_approvers app on ts.createdby=app.empcode
            //where 
            //emp.dept_id='" + id + "' and emp.empcode='" + _userCode + "'  and ts.id='" + tid + "' and ts.approverstatus='1' and emp.empcode not in ('";

            //            string sqlstr = @"
            //select emp.empcode,
            //emp.emp_fname,
            //db.department_name,
            //de.designationname,
            //ts.training_code,
            //ts.training_name,
            //bd.branch_name,
            //ts.id,
            //app.app_reportingmanager 
            //from tbl_intranet_employee_jobDetails emp
            //inner join tbl_training_schedul ts on emp.dept_id= ts.dept_name 
            //inner join tbl_internate_departmentdetails db on db.departmentid=emp.dept_id 
            //inner join tbl_intranet_designation de on de.id=emp.degination_id
            //inner join tbl_intranet_branch_detail bd on emp.branch_id= bd.branch_id
            //left join dbo.tbl_employee_approvers app on ts.createdby=app.empcode
            //where 
            //emp.dept_id='" + id + "' and emp.empcode='" + _userCode + "' and ts.id='" + tid + "' and ts.approverstatus='1' and emp.empcode not in ('";

            //            foreach (DataRow row in dsInsertedEmps.Tables[0].Rows)
            //            {
            //                string reporttee = row["empcode"].ToString().Trim();

            //                sqlstr = sqlstr + reporttee + "','";
            //            }

            //            sqlstr = sqlstr + "')";

            // app.app_reportingmanager='" + _userCode + "' and 
            //  "' and app.app_reportingmanager='" + _userCode + "' or app.app_dotted_linemanager='" + _userCode + "' or app.app_finance='" + _userCode + "'

            string sqlstr = @" select distinct emp.empcode,emp.emp_fname,emp.dept_id,db.department_name,de.designationname,ts.training_code,
ts.training_name,bd.branch_name,app.app_reportingmanager,CONVERT(varchar(40),ts.fromdate,106) as FromDate,CONVERT(varchar(40),ts.todate,106) as ToDate,
ts.module_name,ts.approverstatus  
from tbl_intranet_employee_jobDetails emp
inner join tbl_training_schedul ts on emp.dept_id= ts.dept_name 
inner join tbl_internate_departmentdetails db on db.departmentid=emp.dept_id 
inner join tbl_intranet_designation de on de.id=emp.degination_id
inner join tbl_intranet_branch_detail bd on emp.branch_id= bd.branch_id
left join dbo.tbl_employee_approvers app on ts.createdby=app.empcode
where 
emp.dept_id='" + deptid + "' and emp.empcode='" + _userCode + "' and ts.approverstatus='1' and CONVERT(varchar(40),ts.fromdate,106)='" + fromdate + "' and CONVERT(varchar(40),ts.todate,106)='" + todate + "'";
          //  and emp.empcode not in (select empcode from tbl_training_elegible_emp)
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds1.Tables[0].Rows.Count < 0)
            { 
                return;
            }

            DateTime fromda =Convert.ToDateTime(ds1.Tables[0].Rows[0]["fromdate"].ToString());
            DateTime todat = Convert.ToDateTime(ds1.Tables[0].Rows[0]["todate"].ToString());
            string module = Convert.ToString(ds1.Tables[0].Rows[0]["module_name"].ToString());

            string strng1 = @"select fromdate,todate,modulename from dbo.tbl_training_elegible_emp where status=0 and empcode='" + _userCode + "' order by id desc";
            DataSet dsInsertedEmps1 = SQLServer.ExecuteDataset(connection, CommandType.Text, strng1);

            if (dsInsertedEmps1.Tables[0].Rows.Count <= 0)
            {
                Grid_Addparticipants.DataSource = ds1;
                Grid_Addparticipants.DataBind();
            }
            else if(dsInsertedEmps1.Tables[0].Rows.Count > 0)
            {
                DateTime fromda1 = Convert.ToDateTime(dsInsertedEmps1.Tables[0].Rows[0]["fromdate"].ToString());
                DateTime todat1 = Convert.ToDateTime(dsInsertedEmps1.Tables[0].Rows[0]["fromdate"].ToString());
                string moduless = Convert.ToString(dsInsertedEmps1.Tables[0].Rows[0]["modulename"].ToString());

                if ((fromda == fromda1))
                {
                    return;
                }
                else
                {
                    Grid_Addparticipants.DataSource = ds1;
                    Grid_Addparticipants.DataBind();
                }
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

    protected void Grid_Addparticipants_PreRender(object sender, EventArgs e)
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
                            string createdby = Session["empcode"].ToString();
                            Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, emp.Text);
                            Output.AssignParameter(sqlParam, 1, "@training_code", "String", 50, training_code.Text);
                            Output.AssignParameter(sqlParam, 2, "@training_name", "String", 100, training_name.Text);
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

                            int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "[sp_training_insert_elegible_emp]", sqlParam);
                           // DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_training_insert_elegible_emp", sqlstr);
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
                        Output.Show("Submitted Successfully.");
                    else
                    {
                        string alert = "";
                        if (notsaved.Trim() != "")
                            alert = "[ " + notsaved + " ] Employee(s) are already exists.    ";
                        if (saved.Trim() != "")
                            alert = alert + "[ " + saved + " ]  Employee(s) are Successfully Saved.";

                        Output.Show(alert);
                    }
                }
                else
                {
                    Output.Show("Please Select Employees");
                }
            }
            bind_addparticipantsLM();

            Response.Redirect("trainingrequest.aspx?update=true");
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

           
            activity.CloseConnection();

        }

    }

}