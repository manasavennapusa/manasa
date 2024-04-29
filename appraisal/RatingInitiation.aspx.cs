using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using Smart.HR.Common.Mail.Module;

public partial class appraisal_RatingInitiation : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        } getActiveCycle();
        if (!IsPostBack)
        {
            if (gveligible.Rows.Count <= 0)
                gveligible.EmptyDataText = "No Records Found";
          
            //bindgrade();
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
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            //Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, "0");
            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_empsforinitiateratings", sqlparam);

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
            //dd_dpt.DataTextField = "gradename";
            //dd_dpt.DataValueField = "id";
            //dd_dpt.DataSource = ds;
            //dd_dpt.DataBind();
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
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            //Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, ddl_dept.SelectedValue);

            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_empsforinitiateratings", sqlparam);

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

    void SendEmail(string empcode, int appraisalId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateRatingCycleEmployee();
        EmailClient client = new EmailClient(email);
        Approvers.Appraisal.Approvers appovers = new Approvers.Appraisal.Approvers();

        DataRow row = appovers.GetEmployeeInfo(empcode);
        client.toEmailId = row["official_email_id"].ToString().Trim();
        client.empCode = row["empcode"].ToString();
        client.employeeName = row["name"].ToString().Trim();
        client.Send();

        DataRow rowlm = appovers.GetApprovers(empcode, appraisalId);
        email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateRatingCycleLM();
        client = new EmailClient(email);
        client.toEmailId = rowlm["rmemailid"].ToString().Trim();
        client.empCode = rowlm["app_reportingmanager"].ToString();
        client.employeeName = rowlm["rmname"].ToString().Trim();
        client.requestNumber = rowlm["emp_fname"].ToString().Trim() + "( " + rowlm["empcode"].ToString().Trim() + " ) ";
        client.Send();

        DataRow rowbh = appovers.GetApprovers(empcode, appraisalId);
        email = new Smart.HR.Common.Mail.Module.Appraisal.InitiateRatingCycleBH();
        client = new EmailClient(email);
        client.toEmailId = rowbh["bhemailid"].ToString().Trim();
        client.empCode = rowbh["app_businesshead"].ToString();
        client.employeeName = rowbh["bhname"].ToString().Trim();
        client.requestNumber = rowlm["emp_fname"].ToString().Trim() + "( " + rowlm["empcode"].ToString().Trim() + " ) ";
        client.Send();
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
                            SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_initiateratingbyhr", sqlparam);

                            //SendEmail(emp.Text.Trim(), Convert.ToInt32(Session["appcycle"]));
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

   

    //protected void dd_dpt_DataBound(object sender, EventArgs e)
    //{
    //    dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
    //}

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

    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found";
    }
}