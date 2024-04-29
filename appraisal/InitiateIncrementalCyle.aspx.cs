using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;

public partial class appraisal_InitiateIncrementalCyle : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        getActiveCycle();
        if (!IsPostBack)
        {
            bindgrade();
            bindGrid();
        }
    }

    protected void getActiveCycle()
    {
        SqlParameter[] sqlParam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select count(*) from tbl_appraisal_cycle ";
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

    protected void bindGrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 3, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 4, "@department", "Int", 0, "0");
            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_empsforinitiateIncrementalCycle", sqlparam);

            gveligible.DataSource = ds;
            gveligible.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["Getemp"] = ds;
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

    protected void bindgrade()
    {
        SqlParameter[] sqlParam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"SELECT distinct  id, gradename  from tbl_intranet_grade";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            dd_dpt.DataTextField = "gradename";
            dd_dpt.DataValueField = "id";
            dd_dpt.DataSource = ds;
            dd_dpt.DataBind();
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

    protected void btn_search_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 3, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 4, "@department", "Int", 0, ddl_dept.SelectedValue);

            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_empsforinitiateIncrementalCycle", sqlparam);

            gveligible.DataSource = ds;
            gveligible.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {

                ViewState["Getemp"] = ds;
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[2];
        SqlConnection Connection = null;
        try
        {
            int selected = 0;
            if (Session["appcycle"] != null)
            {
                Connection = DataActivity.OpenConnection();

                Output.AssignParameter(sqlparam, 0, "@appcycleid", "Int", 0, Session["appcycle"].ToString());

                if (gveligible.Rows.Count > 0)
                {
                    foreach (GridViewRow row in gveligible.Rows)
                    {
                        Label emp = (Label)row.FindControl("lblempcode");
                        CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                        if (chk.Checked)
                        {
                            selected = selected + 1;
                            Output.AssignParameter(sqlparam, 1, "@empcode", "String", 50, emp.Text);
                            SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_initiateSalaryIncreamentbyhr", sqlparam);

                            // sendMail(emp.Text);
                        }
                    }
                    if (selected <= 0)
                    {
                        Output.Show("Please Select Employees");
                    }
                    else
                    {
                        Output.Show("Selected Employees are initiated Rating Successfully ");
                    }
                    bindGrid();
                }
                else
                {
                    Output.Show("Please Select Employees");
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

    protected void sendMail(string empcode)
    {
        SqlParameter[] sqlParam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            string sqlstr = @"select e.empcode,e.official_email_id,isnull(e.emp_fname,'')+' ' +isnull(e.emp_m_name,'')+' ' +isnull(e.emp_l_name,'') as empname,
                            isnull(s.emp_fname,'')+' ' +isnull(s.emp_m_name,'')+' ' +isnull(s.emp_l_name,'') as suprname,s.empcode as suprcode,s.official_email_id as supremail,
                            isnull(m.emp_fname,'')+' ' +isnull(m.emp_m_name,'')+' ' +isnull(m.emp_l_name,'') as mgrname,m.empcode as mgrcode,m.official_email_id as mgremail,
                            isnull(mt.emp_fname,'')+' ' +isnull(mt.emp_m_name,'')+' ' +isnull(mt.emp_l_name,'') as mgmtname,mt.empcode as mgmtcode,mt.official_email_id as mgmtemail
                            from  tbl_intranet_employee_jobDetails e 
                            left join tbl_intranet_employee_jobDetails s  on s.empcode=e.supervisorcode 
                            left join tbl_intranet_employee_jobDetails m  on m.empcode=e.hodcode 
                            left join tbl_intranet_employee_jobDetails mt  on mt.empcode=e.corporatereportingcode
                             where e.empcode='" + empcode + "'";
            Connection = DataActivity.OpenConnection();
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
                    string subject = ConfigurationManager.AppSettings["subjectRating"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContentRating"].ToString();
                    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
                    Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);

                    if (ds1.Tables[0].Rows[0]["supremail"].ToString() != "")
                    {
                        string completeBody1 = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["suprname"].ToString(), "Appraisal Rating initiated for the Employee " + empcode);
                        Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["supremail"].ToString(), "", subject, completeBody1, smtp, emailLogo);
                    }
                    if (ds1.Tables[0].Rows[0]["mgremail"].ToString() != "")
                    {
                        string completeBody2 = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["mgrname"].ToString(), "Appraisal Rating initiated for the Employee " + empcode);
                        Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["mgremail"].ToString(), "", subject, completeBody2, smtp, emailLogo);
                    }
                    if (ds1.Tables[0].Rows[0]["mgmtemail"].ToString() != "")
                    {
                        string completeBody3 = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["mgmtname"].ToString(), "Appraisal Rating initiated for the Employee " + empcode);
                        Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["mgmtemail"].ToString(), "", subject, completeBody3, smtp, emailLogo);
                    }
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

    protected void dd_dpt_DataBound(object sender, EventArgs e)
    {
        dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
    }

    protected void ddl_dept_DataBound(object sender, EventArgs e)
    {
        ddl_dept.Items.Insert(0, new ListItem("------ All ------", "0"));
    }

    protected void gveligible_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Getemp"] != null)
        {
            gveligible.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Getemp"];
            gveligible.DataSource = ds;
            gveligible.DataBind();
        }
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

}