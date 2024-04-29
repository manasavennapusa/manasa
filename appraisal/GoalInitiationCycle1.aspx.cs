using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using Smart.HR.Common.Mail.Module;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using DataAccessLayer;

public partial class appraisal_GoalInitiationCycle1 : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        //month_from = Convert.ToDateTime(System.DateTime.Now.Month.ToString("4"));
        //month_from = DateTime.Now.Month.ToString();
        //month_to = DateTime.Now.Month.ToString();

        message.InnerHtml = "";
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        UserCode = Session["empcode"].ToString();
        getActiveCycle();
        if (!IsPostBack)
        {
            bindgrid1();
            if (gveligible.Rows.Count <= 0) gveligible.EmptyDataText = "No Records Found";
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

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void gveligible_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[3];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string id = (string)gveligible.DataKeys[e.RowIndex].Value;
            string appcycleid = Session["appcycle"].ToString();

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, id.Trim());
            Output.AssignParameter(sqlparam, 1, "@appcycleid", "Int", 0, appcycleid);
            Output.AssignParameter(sqlparam, 2, "@createdby", "String", 50, Session["empcode"].ToString());

            int ins = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_deleteeligibleemployee", sqlparam);
            if (ins > 0)
            {
                //bindgird();
                bindgrid1();
                // sendMailOnDelete(id);
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

            //ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_fetch_eligibile_emp", sqlparam);

            string str_1 = @"select empappr.appcycle_id,isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
convert(varchar(10),empjob.emp_doj,101) as emp_doj,
empappr.status,ast.G1_cycle,ast.G2_cycle,ast.line_manager_comment,ast.create_by                    
 from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment ast on ast.empcode=empappr.empcode
inner join tbl_appraisal_cycle cycle on cycle.appcycle_id=empappr.appcycle_id
where 1=1 and ast.G1_cycle=0 and ast.G2_cycle=0
and empappr.isdeleted=0 and empappr.status=0 and MONTH(empappr.create_date) in (4,5,6,7,8,9)  
and empjob.emp_status in (1,3) and and cycle.status=1
and ast.create_by='" + UserCode + "' and empjob.empcode='" + txt_employee.Text + "' and empdept.department_name='" + ddl_dept.SelectedItem.Text + "' order by empjob.empcode";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, str_1);


            gveligible.DataSource = ds;
            gveligible.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {

                divbutton.Visible = true;
            }
            else
            {
                divbutton.Visible = false;
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
            Connection = DataActivity.OpenConnection();
            //Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            //Output.AssignParameter(sqlparam, 1, "@name", "String", 150, "");
            ////Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, "0");
            //Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            //Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, "0");
            //ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_fetch_eligibile_emp", sqlparam);

            //            string str_1 = @"select empappr.appcycle_id,isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
            //rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
            //convert(varchar(10),empjob.emp_doj,101) as emp_doj,
            //empappr.status,ast.G1_cycle,ast.G2_cycle,ast.line_manager_comment                    
            // from tbl_intranet_employee_jobDetails empjob
            //inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
            //inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
            //inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
            //inner join tbl_appraisal_assessment ast on ast.empcode=empappr.empcode
            //where 1=1 and ast.G1_cycle=0 and ast.G2_cycle=0
            //and empappr.isdeleted=0 and empappr.status=0 and MONTH(empappr.create_date) in (4,5,6,7,8,9)  
            //and empjob.emp_status in (1,3) and ast.line_manager_comment is not null
            //and empappr.create_by='" + UserCode + "' order by empjob.empcode";

            string str_1 = @"select distinct empappr.appcycle_id,isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
convert(varchar(10),empjob.emp_doj,101) as emp_doj,empappr.status,ast.G1_cycle,ast.G2_cycle,ast.line_manager_comment,
empjob.emp_status,empappr.isdeleted,empappr.create_by,ast.create_by                    
 from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment ast on ast.empcode=empappr.empcode
inner join tbl_appraisal_cycle cycle on cycle.appcycle_id=empappr.appcycle_id
where ast.G1_cycle=1 and ast.G2_cycle=0
and empappr.isdeleted=0 and empappr.status=1 and MONTH(empappr.create_date) in (4,5,6,7,8,9)  
and empjob.emp_status in (1,3) 
 and cycle.status=1 
and ast.create_by='" + UserCode + "'";

            //and ast.line_manager_comment is not null
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, str_1);

            gveligible.DataSource = ds;
            gveligible.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                divbutton.Visible = true;
            }
            else
            {
                divbutton.Visible = false;
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

    protected void btnInitiateAprasial_Click(object sender, EventArgs e)
    {
        String month = DateTime.Now.Month.ToString();

        if (4 <= Convert.ToInt32(month) && 9 >= Convert.ToInt32(month))
        {
            SqlParameter[] sqlParam = new SqlParameter[5];
            SqlConnection Connection = null;
            SqlTransaction _Transaction = null;
            bool flag = false;
            try
            {
                Connection = DataActivity.OpenConnection();
                int selected = 0;
                string notsaved = "";
                string saved = "";
                Label emp = null;

                if (Session["appcycle"] != null)
                {

                    if (gveligible.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in gveligible.Rows)
                        {
                            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                            flag = false;

                            if (chk.Checked)
                            {
                                selected = selected + 1;
                                emp = (Label)row.FindControl("lblempcode");
                                string strsql = @"select isnull(COUNT(app_reportingmanager),0)+isnull(COUNT(app_businesshead),0)+isnull(COUNT(app_hrd),0)+isnull(COUNT(app_management),0) from tbl_employee_approvers where empcode='" + emp.Text + "'";
                                int apvrsCount = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, strsql);
                                if (apvrsCount < 4)
                                {
                                    notsaved = notsaved + " [" + emp.Text + "]";
                                }
                                else
                                {
                                    string str = @"select COUNT(*) from tbl_appraisal_eligible_employee where empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and status=1 and isdeleted=0";
                                    int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str);
                                    if (cnt < 2)
                                    {
                                        string str2 = "select COUNT(empcode) from dbo.tbl_appraisal_assessment  where status=1 and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                        int count = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str2);
                                        if (count == 0)
                                        {
                                            try
                                            {
                                                _Transaction = Connection.BeginTransaction();

                                                insertApprovers(emp.Text, Convert.ToInt32(Session["appcycle"]), Session["empcode"].ToString(), Connection, _Transaction);

                                                string createdby = Session["empcode"].ToString();
                                                SqlParameter[] sqlparam = new SqlParameter[4];
                                                Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, emp.Text);
                                                Output.AssignParameter(sqlparam, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
                                                Output.AssignParameter(sqlparam, 2, "@create_by", "String", 50, createdby);
                                                sqlparam[3] = new SqlParameter("@assmentid", SqlDbType.Int);
                                                sqlparam[3].Direction = ParameterDirection.Output;

                                                SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_appraisal_initiatelegibilitylist", sqlparam);


                                                int ds_id = int.Parse(sqlparam[3].Value.ToString());
                                                if (ds_id.ToString() != "")
                                                {
                                                    string str3 = "update tbl_appraisal_eligible_employee set status=1  where isdeleted=0 and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                                    SQLServer.ExecuteScalar(Connection, CommandType.Text, _Transaction, str3);
                                                    int assessmentid = ds_id;

                                                    string sqlstr = @"update tbl_appraisal_assessment set G1_initiateddate=getdate() where assessment_id=" + sqlparam[3].Value.ToString();
                                                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, sqlstr);


                                                }
                                                _Transaction.Commit();
                                                flag = true;
                                                saved = saved + " [" + emp.Text + "]";
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
                                            try
                                            {
                                                _Transaction = Connection.BeginTransaction();
                                                string str4 = "select COUNT(empcode) from tbl_appraisal_assessment  where status=1  and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                                int cont = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, _Transaction, str4);
                                                if (cont > 0)
                                                {
                                                    insertApprovers(emp.Text, Convert.ToInt32(Session["appcycle"]), Session["empcode"].ToString(), Connection, _Transaction);

                                                    string str5 = "update tbl_appraisal_eligible_employee set status=1  where isdeleted=0 and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

                                                    string str6 = "update tbl_appraisal_assessment set G1_cycle=1 ,workflow='G', G1_initiateddate=getdate() where status=1 and empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"]);
                                                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);


                                                }
                                                _Transaction.Commit();
                                                flag = true;
                                                saved = saved + " [" + emp.Text + "]";
                                            }
                                            catch (Exception ex)
                                            {
                                                _Transaction.Rollback();
                                                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                                                Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Output.Show("Appraisal Already Initiated ");
                                    }
                                }
                            }

                            if (flag == true)
                            {
                                try
                                {
                                    try
                                    {
                                        //SendEmail(emp.Text.Trim(), Convert.ToInt32(Session["appcycle"]));
                                    }
                                    catch (SqlException dx)
                                    {
                                    }

                                }
                                catch (SqlException ex)
                                {
                                    try { }
                                    catch (SqlException cx)
                                    {
                                    }
                                }
                            }
                        }

                        if (selected <= 0)
                        {
                            Output.Show("Please Select Employees");

                        }
                        else
                        {
                            if (saved.Trim() != "" || notsaved.Trim() != "")
                            {
                                string alert = notsaved.Trim() != "" ? "For the Employee(s) " + notsaved + " Appraisal not Initiated because approvers are not set " : "";

                                alert += saved.Trim() != "" ? "   Appraisal Initiated Successfully for the Employee(s) " + saved : "";
                                Output.Show(alert);
                            }
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
        }
        else
        {
            Output.Show("Goal Cycle Only Initiate Between April To September");
        }

    }

    protected void insertApprovers(string empcode, int appcycle_id, string creade_by, SqlConnection conn, SqlTransaction trans)
    {
        SqlParameter[] sqlparam = new SqlParameter[3];
        Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, empcode);
        Output.AssignParameter(sqlparam, 1, "@appcycle_id", "Int", 0, appcycle_id.ToString());
        Output.AssignParameter(sqlparam, 2, "@create_by", "String", 50, creade_by);
        SQLServer.ExecuteNonQuery(conn, CommandType.StoredProcedure, trans, "sp_appraisal_insert_approvers", sqlparam);
    }

    void SendEmail(string empcode, int appraisalId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateGoalCycleIEmployee();
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
        email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateGoalCycle1LM();
        client = new EmailClient(email);
        client.toEmailId = rowlm["rmemailid"].ToString().Trim();
        client.empCode = rowlm["app_reportingmanager"].ToString();
        client.employeeName = rowlm["rmname"].ToString().Trim();
        client.requestNumber = rowlm["emp_fname"].ToString().Trim() + "( " + rowlm["empcode"].ToString().Trim() + " ) ";
        client.Send();

        DataRow rowbh = appovers.GetApprovers(empcode, appraisalId);

        email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateGoalCycleIBH();
        client = new EmailClient(email);
        client.toEmailId = rowbh["bhemailid"].ToString().Trim();
        client.empCode = rowbh["app_businesshead"].ToString();
        client.employeeName = rowbh["bhname"].ToString().Trim();
        client.requestNumber = rowlm["emp_fname"].ToString().Trim() + "( " + rowlm["empcode"].ToString().Trim() + " ) ";
        client.Send();



    }

    protected void sendMailOnDelete(string empcode)
    {


        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select empcode,official_email_id, isnull(emp_fname,'')+' ' +isnull(emp_m_name,'')+' ' +isnull(emp_l_name,'') as empname
                             from  tbl_intranet_employee_jobDetails where empcode='" + empcode + "'";


            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);


            if (ds1.Tables[0].Rows.Count > 0)
            {

                if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
                {
                    string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                    string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                    string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                    string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                    string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                    string subject = ConfigurationManager.AppSettings["subject_delete"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContent_onDelete"].ToString();
                    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
                    Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);

                }
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

    protected void gveligible_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            bool isBlack = row.Field<bool>("status");
            e.Row.Cells[4].Text = isBlack ? "Initiated" : "Not Initiated";
        }
    }

    protected void gveligible_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gveligible.PageIndex = e.NewPageIndex;
        //bindgird();
        bindgrid1();
    }

    protected void ddl_dept_DataBound(object sender, EventArgs e)
    {
        ddl_dept.Items.Insert(0, new ListItem("----- All -----", "0"));
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)gveligible.HeaderRow.FindControl("chkAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }

    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found";
    }



}