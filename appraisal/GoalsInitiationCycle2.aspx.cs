using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using Smart.HR.Common.Mail.Module;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;
using DataAccessLayer;


public partial class appraisal_GoalsInitiationCycle2 : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        UserCode = Session["empcode"].ToString();
        getActiveCycle();

        if (!IsPostBack)
        {
            if (grd_Cycle2.Rows.Count <= 0)
                grd_Cycle2.EmptyDataText = "No Records Found";
            bindgrid1();
        }
    }

    private void getActiveCycle()
    {
        SqlParameter[] sqlParam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze!=1 ";
            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str1);
            if (cnt > 0)
            {
               int cycle = (int)SQLServer.ExecuteScalar(Connection, CommandType.StoredProcedure, "sp_appraisal_getapprisalcycle");
                if (cycle != 0)
                {
                    Session["appcycle"] = cycle;
                }
                else
                {
                    Output.Show("Please Mark Active Appraisal Cycle");
                }
            }
            else
            {
                Output.Show("Please Create Appraisal Cycle");
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

    //protected void dd_dpt_DataBound(object sender, EventArgs e)
    //{
    //    dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
    //}

    protected void ddl_dept_DataBound(object sender, EventArgs e)
    {
        ddl_dept.Items.Insert(0, new ListItem("----- All -----", "0"));
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    private void bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            //Connection = DataActivity.OpenConnection();
            //Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            //Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            ////Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            //Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            //Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, ddl_dept.SelectedValue);
            //DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_fetch_eligibile_empForCycle2", sqlparam);

            string sqlstr = @"select empappr.appcycle_id,rtrim(empjob.empcode) as empcode,
isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,   
empdesg.designationname as designation,empdept.department_name as dept,convert(varchar(10),empjob.emp_doj,101) as emp_doj,
empappr.status,ast.create_by,ast.G1_cycle,ast.G2_cycle,ast.R_cycle           
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment ast on ast.empcode=empappr.empcode
where 1=1 and ast.G1_cycle='1' and ast.G2_cycle='0' and empappr.isdeleted=0 and ast.status in(1,3) and ast.R_cycle=4
and empjob.emp_status in(1,3) and ast.line_manager_comment is not null and ast.create_by='" + UserCode + "' and empjob.empcode='" + txt_employee.Text + "' and empdept.department_name='" + ddl_dept.SelectedItem.Text + "' order by empjob.empcode";
            DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            grd_Cycle2.DataSource = ds2;
            grd_Cycle2.DataBind();
            if (grd_Cycle2.Rows.Count <= 0)
                grd_Cycle2.EmptyDataText = "No Records Found";
            if (ds2.Tables[0].Rows.Count > 0)
            {

                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
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

    private void bindgrid1()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            //Connection = DataActivity.OpenConnection();
            //Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            //Output.AssignParameter(sqlparam, 1, "@name", "String", 150, "");
            ////Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, "0");
            //Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            //Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, "0");
            string sqlstr = @"select empappr.appcycle_id,rtrim(empjob.empcode) as empcode,
isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,   
empdesg.designationname as designation,empdept.department_name as dept,convert(varchar(10),empjob.emp_doj,101) as emp_doj,
empappr.status,ast.create_by,ast.G1_cycle,ast.G2_cycle,ast.R_cycle,ast.freeze              
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment ast on ast.empcode=empappr.empcode
where 1=1 and ast.G1_cycle='1' and ast.G2_cycle='0' and empappr.isdeleted=0 and ast.status in(1,3) and ast.R_cycle=4    
and empjob.emp_status in(1,3) and ast.line_manager_comment is not null and ast.line_manager_comment_for_cycle_2 is not null 
and ast.freeze='1'  and ast.create_by='" + UserCode + "' order by empjob.empcode";

            //DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_fetch_eligibile_empForCycle2", sqlparam);
            DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grd_Cycle2.DataSource = ds2;
            grd_Cycle2.DataBind();

            if (ds2.Tables[0].Rows.Count > 0)
            {

                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
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

    protected void grd_Cycle2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[3];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string id = (string)grd_Cycle2.DataKeys[e.RowIndex].Value;
            string appcycleid = Session["appcycle"].ToString();

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, id.Trim());
            Output.AssignParameter(sqlparam, 1, "@appcycleid", "Int", 0, appcycleid);
            Output.AssignParameter(sqlparam, 2, "@createdby", "String", 50, Session["empcode"].ToString());

            int ins = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_deleteeligibleemployee", sqlparam);
            if (ins > 0)
            {

                bindgrid1();
                //sendMailOnDelete(id);
                Output.Show("Record deleted successfully.");
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

    protected void grd_Cycle2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            string isBlack = row.Field<string>("G2_cycle");
            e.Row.Cells[4].Text = isBlack != "0" ? "Initiated" : "Not Initiated";
        }
    }

    protected void grd_Cycle2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_Cycle2.PageIndex = e.NewPageIndex;
        bindgrid1();
    }

    protected void chkAll_CheckedChanged1(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)grd_Cycle2.HeaderRow.FindControl("chkAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in grd_Cycle2.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in grd_Cycle2.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }

    protected void btn_goalscycle2_Click(object sender, EventArgs e)
    {
        String month = DateTime.Now.Month.ToString();

        //if (month == "1" || month == "2" || month == "3" || month == "10" || month == "11" || month == "12")
        //{

            SqlParameter[] sqlParam = new SqlParameter[5];
            SqlConnection Connection = null;
            SqlTransaction _Transaction = null;
            try
            {
                Connection = DataActivity.OpenConnection();
                int selected = 0;
                if (Session["appcycle"] != null)
                {

                    if (grd_Cycle2.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in grd_Cycle2.Rows)
                        {
                            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                            if (chk.Checked)
                            {
                                selected = selected + 1;
                                Label emp = (Label)row.FindControl("lblempcode");
                                string str2 = "select COUNT(empcode) from dbo.tbl_appraisal_assessment  where G2_cycle=1 and workflow='G' and status=1 and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                int count = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str2);
                                if (count == 0)
                                {

                                    try
                                    {
                                        _Transaction = Connection.BeginTransaction();
                                        string str4 = "select COUNT(empcode) from tbl_appraisal_assessment  where status=1 and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                        int cont = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, _Transaction, str4);
                                        if (cont > 0)
                                        {
                                            string str6 = "update tbl_appraisal_assessment set G2_cycle=1,workflow='G', G2_initiateddate=getdate()  where status=1 and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                            SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

                                            //SendEmail(emp.Text.Trim(), Convert.ToInt32(Session["appcycle"]));
                                        }
                                        _Transaction.Commit();


                                    }
                                    catch (Exception ex)
                                    {
                                        _Transaction.Rollback();
                                        Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                                        Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
                                    }
                                }
                                else
                                {
                                    Output.Show("Appraisal Already Initiated ");
                                }
                            }
                        }
                        if (selected <= 0)
                        {
                            Output.Show("Please Select Employees");
                        }
                        else
                        {
                            Output.Show("Appraisal Initiated Successfully");
                        }
                        //bindgird();
                        bindgrid1();
                    }
                    else
                    {
                        Output.Show("Employees are not Exists to initiate");
                    }
                }
                else
                {
                    Output.Show("Please Create Appraisal Cycle");
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
        //}
        //else
        //{
        //    Output.Show("Goal Cycle 2 Only Initiate Between October To March");
        //}
    }

    void SendEmail(string empcode, int appraisalId)
    {
        
            EmailFactory email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateGoalCycleIIEmployee();
            EmailClient client = new EmailClient(email);
            Approvers.Appraisal.Approvers appovers = new Approvers.Appraisal.Approvers();

            DataRow row = appovers.GetEmployeeInfo(empcode);
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)    // Code given By Siddharth to avoid "The remote certificate is invalid according to the validation procedure"
            {
                return true;
            };
            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["empcode"].ToString();
            client.employeeName = row["name"].ToString().Trim();
            client.Send();

            DataRow rowlm = appovers.GetApprovers(empcode, appraisalId);
            email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateGoalCycleIILM();
            client = new EmailClient(email);
            client.toEmailId = rowlm["rmemailid"].ToString().Trim();
            client.empCode = rowlm["app_reportingmanager"].ToString();
            client.employeeName = rowlm["rmname"].ToString().Trim();
            client.requestNumber = rowlm["emp_fname"].ToString().Trim() + "( " + rowlm["empcode"].ToString().Trim() + " ) ";
            client.Send();

            DataRow rowbh = appovers.GetApprovers(empcode, appraisalId);
            email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateGoalCycleIIBH();
            client = new EmailClient(email);
            client.toEmailId = rowbh["bhemailid"].ToString().Trim();
            client.empCode = rowbh["app_businesshead"].ToString();
            client.employeeName = rowbh["bhname"].ToString().Trim();
            client.requestNumber = rowlm["emp_fname"].ToString().Trim() + "( " + rowlm["empcode"].ToString().Trim() + " ) ";
            client.Send();
     
    }

    protected void grd_Cycle2_PreRender(object sender, EventArgs e)
    {
        if (grd_Cycle2.Rows.Count > 0)
            grd_Cycle2.HeaderRow.TableSection = TableRowSection.TableHeader;
        else grd_Cycle2.EmptyDataText = "No Records Found";
    }

}