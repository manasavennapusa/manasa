using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Data;
using System;
using System.Configuration;
using Common.Data;
using Common.Console;
using Smart.HR.Common.Encode;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mail;



public partial class Training_trainingtypemasterentry : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string bodyContent;
    string sqlstr, _userCode, _companyId, RoleId;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            if (!IsPostBack)
            {
                trainingcode();
                bind_branch_id();
                lst_deptname.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_department.Items.Insert(0, new ListItem("--Select--", "0"));
                if (Request.QueryString["sub"] != null)
                {
                    Output.Show("Submitted Successfully");
                }
            }

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }


    }

    private void trainingcode()
    {
        string sqlstr = "select training_type_id from tbl_training_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //ddltrainingcode.DataTextField = "training_name";
        ddltrainingcode.DataValueField = "training_type_id";
        ddltrainingcode.DataSource = ds;
        ddltrainingcode.DataBind();
        ddltrainingcode.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void insert_trainingshedule()
    {
        DateTime t2 = Convert.ToDateTime(txt_fromdate.Text);
        string month = Convert.ToString(t2.Month);
        if (ddl_month.SelectedValue != month)
        {
            Output.Show("Wrong Month Selected");
            return;
            ddl_month.Focus();
        }

        DateTime t3 = Convert.ToDateTime(txt_fromdate.Text);
        string year = Convert.ToString(t3.Year);

        if (ddlyear.SelectedValue != year)
        {
            Output.Show("Wrong Year Selected");
            return;
            ddlyear.Focus();
        }
        //else
        //{
        if (txt_fromdate.Text != "" && txt_todate.Text != "")
        {
            if (Convert.ToDateTime(txt_fromdate.Text) > Convert.ToDateTime(txt_todate.Text))
            {
                Output.Show("To date should always be greater than or equal to From date");
                return;
                txt_todate.Text = "";
                txt_todate.Focus();
            }
        }
        //else if (ddl_month.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
        //{
        //    Output.Show("Wrong Year Selected");
        //    ddlyear.Focus();
        //}
        //        else
        //        {
        //            Output.Show("Please select From Date");
        //            return;
        //            txt_fromdate.Focus();
        //            txt_todate.Text = "";
        //        }
        //        // }
        //    }
        //    else
        //    {
        //        Output.Show("Please Select Year");
        //        return;
        //        ddlyear.Focus();
        //    }
        //}
        //else
        //{
        //    Output.Show("Please Select Month");
        //    return;
        //    ddl_month.Focus();
        //}




        var parm = new SqlParameter[27];
        SqlTransaction transaction = null;
        //var activity = new DataActivity();
        int flag = 0;
        try
        {
            if (lst_deptname.SelectedIndex != -1)
            {

                foreach (ListItem item in lst_deptname.Items)
                {
                    if (item.Selected)
                    {

                        Output.AssignParameter(parm, 0, "@training_code", "String", 50, ddltrainingcode.SelectedValue);
                        Output.AssignParameter(parm, 1, "@training_name", "String", 150, txttrainingname.Text);
                        Output.AssignParameter(parm, 2, "@branch", "Int", 0, ddl_branch_id.SelectedValue);
                        Output.AssignParameter(parm, 3, "@dept_type", "Int", 0, ddl_department.SelectedValue);
                        Output.AssignParameter(parm, 4, "@dept_name", "Int", 0, item.Value);
                        Output.AssignParameter(parm, 5, "@module_name", "String", 150, txt_module_name.Text.ToString());
                        Output.AssignParameter(parm, 6, "@descriptions", "String", 1000, txt_description.Text.ToString());
                        Output.AssignParameter(parm, 7, "@month", "String", 50, ddl_month.SelectedValue);
                        Output.AssignParameter(parm, 8, "@fromdate", "DateTime", 0, txt_fromdate.Text);
                        Output.AssignParameter(parm, 9, "@bachcode", "String", 50, txt_bachcode.Text.ToString());
                        Output.AssignParameter(parm, 10, "@training_type", "String", 50, ddl_trainingtype.SelectedItem.Text);
                        Output.AssignParameter(parm, 11, "@training_shortname", "String", 150, txt_training_short_name.Text.ToString());
                        Output.AssignParameter(parm, 12, "@year", "String", 50, ddlyear.SelectedItem.Text);
                        Output.AssignParameter(parm, 13, "@todate", "DateTime", 0, txt_todate.Text);
                        Output.AssignParameter(parm, 14, "@trainer", "String", 150, txt_time_of_training.Text.ToString());
                        Output.AssignParameter(parm, 15, "@faculty", "String", 50, txt_faculty.Text.ToString());
                        Output.AssignParameter(parm, 16, "@noofhours", "String", 50, txt_noofhours.Text);
                        if (rd_internal.Checked)
                        {
                            Output.AssignParameter(parm, 17, "@source_internal", "Int", 0, "1");
                        }
                        else if (rd_external.Checked)
                        {
                            Output.AssignParameter(parm, 17, "@source_internal", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 17, "@source_internal", "Int", 1, "0");
                        }

                        if (rd_training_effectiveness_yes.Checked)
                        {
                            Output.AssignParameter(parm, 18, "@effectiveness_to_be_cond", "Int", 0, "1");
                        }
                        else if (rd_training_effectiveness_no.Checked)
                        {
                            Output.AssignParameter(parm, 18, "@effectiveness_to_be_cond", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 18, "@effectiveness_to_be_cond", "Int", 0, "0");
                        }

                        if (rd_training_feedback_yes.Checked)
                        {
                            Output.AssignParameter(parm, 19, "@feedback_to_be_cond", "Int", 0, "1");
                        }
                        else if (rd_training_feedback_no.Checked)
                        {
                            Output.AssignParameter(parm, 19, "@feedback_to_be_cond", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 19, "@feedback_to_be_cond", "Int", 0, "0");
                        }

                        if (rd_participants_action_yes.Checked)
                        {
                            Output.AssignParameter(parm, 20, "@action_plan_to_be_cond", "Int", 0, "1");
                        }
                        else if (rd_participants_action_no.Checked)
                        {
                            Output.AssignParameter(parm, 20, "@action_plan_to_be_cond", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 20, "@action_plan_to_be_cond", "Int", 0, "0");
                        }

                        if (programe_yes.Checked)
                        {
                            Output.AssignParameter(parm, 21, "@program ", "Int", 0, "1");
                        }
                        else if (programe_no.Checked)
                        {
                            Output.AssignParameter(parm, 21, "@program ", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 21, "@program ", "Int", 0, "0");
                        }



                        if (facultydescription_yes.Checked)
                        {
                            Output.AssignParameter(parm, 22, "@faculty_description", "Int", 0, "1");
                        }
                        else if (facultydescription_no.Checked)
                        {
                            Output.AssignParameter(parm, 22, "@faculty_description", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 22, "@faculty_description", "Int", 0, "0");
                        }



                        if (anyother_yes.Checked)
                        {
                            Output.AssignParameter(parm, 23, "@any_other", "Int", 0, "1");
                        }
                        else if (anyother_no.Checked)
                        {
                            Output.AssignParameter(parm, 23, "@any_other", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 23, "@any_other", "Int", 0, "0");
                        }

                        Output.AssignParameter(parm, 24, "@createdby", "String", 50, _userCode);
                        Output.AssignParameter(parm, 25, "@approverstatus", "Int", 0, "0");
                        Output.AssignParameter(parm, 26, "@tds", "String", 100, "");


                        //Output.AssignParameter(parm, 14, "@organisation", "String", 10, txt_organisation.Value);
                        //Output.AssignParameter(parm, 15, "@total_no_of_participants", "String", 10, txt_total_noof_participents.Value);                       
                        //Output.AssignParameter(parm, 17, "@cost_of_training", "Int", 0, txt_cost_of_training.Value);
                        //Output.AssignParameter(parm, 18, "@cost_of_training_per_head", "Int", 0, txt_cost_of_training_perhead.Value);                                                                                                         
                        //ddbranch_id.Items.IndexOf(item).ToString()                        
                        SqlConnection connection = activity.OpenConnection();
                        transaction = connection.BeginTransaction();
                        flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_training_schedul", parm);
                        transaction.Commit();

                    }
                }
            }
            else
            {
                Output.Show("Select the Department Name");
            }
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            if (flag > 0)
            {
                // Output.Show("Training created successfully"); 
                Response.Redirect("trainingtypemasterentry.aspx?sub=true");
            }
        }
    }

    protected void Clear()
    {
        ddltrainingcode.SelectedValue = "0";
        txttrainingname.Text = "";
        ddl_branch_id.SelectedValue = "0";
        ddl_department.SelectedValue = "0";
        lst_deptname.SelectedValue = "0";
        txt_module_name.Text = "";
        txt_description.Text = "";
        ddl_month.SelectedValue = "0";
        txt_fromdate.Text = "";
        txt_bachcode.Text = "";
        ddl_trainingtype.Text = "0";
        txt_training_short_name.Text = "";
        ddlyear.SelectedValue = "0";
        txt_todate.Text = "";
        txt_time_of_training.Text = "";
        txt_faculty.Text = "";
        txt_noofhours.Text = "";
        rd_internal.Checked = false;
        rd_training_effectiveness_yes.Checked = false;
        rd_training_feedback_yes.Checked = false;
        rd_participants_action_yes.Checked = false;
        programe_yes.Checked = false;
        facultydescription_yes.Checked = false;
        anyother_yes.Checked = false;
    }

    //protected void btn_sbmit_Click(object sender, EventArgs e)
    //{

    //}

    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedValue != "0")
        {
            if (txt_fromdate.Text != "")
            {
                if (ddlyear.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                {
                    Output.Show("Wrong Year Selected");
                    ddlyear.Focus();
                }
            }
            if (txt_todate.Text != "")
            {
                if (ddlyear.SelectedValue != Convert.ToDateTime(txt_todate.Text).ToString("yyyy"))
                {
                    Output.Show("Wrong Year Selected");
                    ddlyear.Focus();
                }
            }
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("~/home.aspx");
    }

    protected void btn_addparticipant_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/training/addparticipants.aspx");
    }

    protected void btn_sendmail_Click(object sender, EventArgs e)
    {
        //var parm = new SqlParameter[9];
        //SqlTransaction transaction = null;
        //var activity = new DataActivity();
        //int flag = 0;


        if (lst_deptname.SelectedIndex != -1)
        {

            foreach (ListItem item in lst_deptname.Items)
            {
                if (item.Selected)
                {
                    int a = Convert.ToInt32(lst_deptname.SelectedValue);//.ToString();
                    //int id=Convert.ToInt32(lst_deptname.Items.IndexOf(item).ToString()); 

                    // Mailtoapprover( a);


                }
            }
        }

    }

    protected void btn_addnewparticipant_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/training/addneedparticipants.aspx");
    }

    protected void lst_deptname_SelectedIndexChanged(object sender, EventArgs e)
    {

        //foreach (ListItem oItem in lst_deptname.Items)
        //{
        //    if (oItem.Selected)
        //    {
        //        string a = oItem.Value;
        //        if (a != null)
        //        {
        //            addparticipanat(a);
        //        }
        //    }
        //}
    }

    private void addparticipanat(string a)
    {
        //try
        //  {
        //      connection = activity.OpenConnection();
        //      //sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' order by department_name";
        //      //sqlstr = "select jd.empcode,coalesce(jd.emp_fname,jd.emp_m_name,jd.emp_l_name)as name,jd.location,db.department_name,de.designationname from tbl_intranet_employee_jobDetails jd inner join tbl_internate_departmentdetails db on db.departmentid=jd.dept_id inner join tbl_intranet_designation de on de.id=jd.degination_id";
        //      sqlstr = @"";

        //      DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        //      //drpdepartment.DataTextField = "department_name";
        //      //drpdepartment.DataValueField = "departmentid";
        //      //Grid_Addparticipants.DataSource = ds1;
        //      //Grid_Addparticipants.DataBind();
        //  }
        //  catch (Exception ex)
        //  {
        //      Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //      Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        //  }
        //  finally
        //  {
        //      activity.CloseConnection();
        //  }
    }

    private void Mailtoapprover(int x)
    {
        // Getting the email details
        string fromEmail = ConfigurationManager.AppSettings["fromEmail"];
        string fromPwd = ConfigurationManager.AppSettings["pwd"];
        string fromName = ConfigurationManager.AppSettings["fromName"];
        string smtp = ConfigurationManager.AppSettings["smtp"];
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"];
        string subject = "Training Shedules";
        string otdate = DateTime.Now.ToString("yyyy/MM/dd");
        var activity = new DataActivity();
        try
        {


            SqlConnection connection = activity.OpenConnection();
            string qry = @"select jd.official_email_id
                                        from 
                                        tbl_intranet_employee_jobDetails jd 
                                        inner join tbl_internate_departmentdetails dp on jd.dept_id=dp.departmentid
                                        inner join dbo.tbl_intranet_branch_detail bd on jd.branch_id=bd.branch_id where dp.departmentid=" + x.ToString() + ";";


            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, qry);


            if (ds.Tables[0].Rows[0]["official_email_id"].ToString() != "")// && ds.Tables[1].Rows[0]["official_email_id"].ToString() != "" && ds.Tables[2].Rows[0]["official_email_id"].ToString() != "")
            {

                //int i = ds.Tables[0].Rows.Count;
                //int j = 0;

                QueryString q = new QueryString();
                string pairs = String.Format("");
                q.EncodePairs(pairs);

                string url =
                    "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" +
                    ConfigurationManager.AppSettings["url"] + "?m=" + pairs + "' >Click Here</a>";

                bodyContent = "The Training has been schedule. Click on the below link for more detail. <br/><br/>  <br/><br/>" + url + "&nbsp;&nbsp;&nbsp;";


                string completeBody = Email.GetBody(fromName, "Sir/Madam", bodyContent);


                try
                {

                    string toemailhr = "";
                    toemailhr = ds.Tables[0].Rows[0]["official_email_id"].ToString();
                    for (int v = 0; v < ds.Tables[0].Rows.Count; v++)
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient(smtp);
                        mail.From = new MailAddress(fromEmail);
                        mail.To.Add(toemailhr);
                        // mail.To.Add("n.maruthi1989@gmail.com");
                        mail.Subject = subject;
                        mail.Body += completeBody;

                        mail.IsBodyHtml = true;
                        string prt = ConfigurationManager.AppSettings["Port"];
                        SmtpServer.Port = Convert.ToInt32(prt);
                        SmtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, fromPwd);
                        string a = ConfigurationManager.AppSettings["EnableSsl"];
                        SmtpServer.EnableSsl = Convert.ToBoolean(v);
                        SmtpServer.Send(mail);
                    }
                }
                catch
                {
                    //list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"] +
                    //          " due to some technical problem.");
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

    protected void ddl_branch_id_SelectedIndexChanged(object sender, EventArgs e)
    {

        string sqlstr = "select dept_type_id,dept_type_name from dbo.tbl_internate_department_type where branch_id='" + ddl_branch_id.SelectedValue + "'";
        //string sqlstr = "select dept_type_id,dept_type_name from dbo.tbl_internate_department_type";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_department.DataTextField = "dept_type_name";
        ddl_department.DataValueField = "dept_type_id";
        ddl_department.DataSource = ds;
        ddl_department.DataBind();
        ddl_department.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_branch_id()
    {
        string sqlstr = "select branch_id,branch_name from dbo.tbl_intranet_branch_detail";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_branch_id.DataTextField = "branch_name";
        ddl_branch_id.DataValueField = "branch_id";
        ddl_branch_id.DataSource = ds;
        ddl_branch_id.DataBind();
        //ddl_branch_id.Items.Insert(0, new ListItem("---Select---", "0"));

    }

    protected void btn_markattendance_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/training/markattendance.aspx");
    }

    protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
    {

        string sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails where dept_type_id='" + ddl_department.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        lst_deptname.DataTextField = "department_name";
        lst_deptname.DataValueField = "departmentid";
        lst_deptname.DataSource = ds;
        lst_deptname.DataBind();
        lst_deptname.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void rd_internal_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rd_external_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void ddltrainingcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlstr = "select training_name from tbl_training_master where training_type_id='" + ddltrainingcode.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txttrainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
        }
    }

    protected void btnsv_Click(object sender, EventArgs e)
    {
        insert_trainingshedule();
    }
    protected void ddltrainingcode_DataBound(object sender, EventArgs e)
    {
        // ddltrainingcode.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_trainingtype_DataBound(object sender, EventArgs e)
    {
        ddl_trainingtype.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_department_DataBound(object sender, EventArgs e)
    {
        //ddl_department.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_branch_id_DataBound(object sender, EventArgs e)
    {
        ddl_branch_id.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void lst_deptname_DataBound(object sender, EventArgs e)
    {
        // lst_deptname.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void txt_todate_TextChanged(object sender, EventArgs e)
    {
        if (ddl_month.SelectedValue != "0")
        {
            if (ddlyear.SelectedValue != "0")
            {
                //if (ddl_month.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("MMM"))
                //{
                //    Output.Show("Wrong Month Selected");
                //    ddl_month.Focus();
                //}
                //else if (ddlyear.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                //{
                //    Output.Show("Wrong Year Selected");
                //    ddlyear.Focus();
                //}
                //else
                //{
                if (txt_fromdate.Text != "" && txt_todate.Text != "")
                {
                    if (Convert.ToDateTime(txt_fromdate.Text) > Convert.ToDateTime(txt_todate.Text))
                    {
                        Output.Show("To date should always be greater than or equal to From date");
                        txt_todate.Text = "";
                        txt_todate.Focus();
                    }
                }
                //else if (ddl_month.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                //{
                //    Output.Show("Wrong Year Selected");
                //    ddlyear.Focus();
                //}
                else
                {
                    Output.Show("Please select From Date");
                    txt_fromdate.Focus();
                    txt_todate.Text = "";
                }
                // }
            }
            else
            {
                Output.Show("Please Select Year");
                ddlyear.Focus();
            }
        }
        else
        {
            Output.Show("Please Select Month");
            ddl_month.Focus();
        }
    }

    protected void txt_fromdate_TextChanged(object sender, EventArgs e)
    {
        if (ddl_month.SelectedValue != "0")
        {
            if (ddlyear.SelectedValue != "0")
            {
                if (ddl_month.SelectedItem.Text != Convert.ToDateTime(txt_fromdate.Text).ToString("MMM"))
                {
                    Output.Show("Wrong Month Selected");
                    ddl_month.Focus();
                    ddl_month.SelectedValue = "0";
                }
                else if (ddlyear.SelectedItem.Text != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                {
                    Output.Show("Wrong Year Selected");
                    ddlyear.Focus();
                    ddlyear.SelectedValue = "0";
                }
                else
                {
                    if (txt_todate.Text != "" && txt_fromdate.Text != "")
                    {
                        if (Convert.ToDateTime(txt_fromdate.Text) > Convert.ToDateTime(txt_todate.Text))
                        {
                            Output.Show("To date should always be greater than or equal to From date");
                            txt_fromdate.Text = "";
                            txt_fromdate.Focus();
                        }
                    }
                }
            }
            else
            {
                Output.Show("Please Select Year");
                ddlyear.Focus();
            }
        }
        else
        {
            Output.Show("Please Select Month");
            ddl_month.Focus();
        }
    }

    protected void ddl_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_month.SelectedValue != "0")
        {
            if (txt_fromdate.Text != "")
            {
                if (ddl_month.SelectedItem.Text != Convert.ToDateTime(txt_fromdate.Text).ToString("MMM"))
                {
                    Output.Show("Wrong Month Selected");
                    ddl_month.Focus();
                }
            }
            if (txt_todate.Text != "")
            {
                if (ddl_month.SelectedItem.Text != Convert.ToDateTime(txt_todate.Text).ToString("MMM"))
                {
                    Output.Show("Wrong Month Selected");
                    ddl_month.Focus();
                }
            }
        }
    }

}




