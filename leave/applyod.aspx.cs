using Common.Console;
using Common.Data;
using Common.Date;
using Common.Mail;
using Smart.HR.Common.Mail.Module;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Mail;
public partial class leave_applyod : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    private string _companyId, _userCode, comment, sqlstr;
    public int i, k;
    string todate, fromdt;
    DataActivity activity = new DataActivity();
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();



            if (!IsPostBack)
            {

                bindemployee_detail();
                //  BindOdType(_companyId);
            }

            this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtftime'))");
            this.imgouttime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txttotime'))");
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion
    #region Bind The Employee Details
    protected void bindemployee_detail()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = _ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = _ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = _ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = _ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = _ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = _ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = _ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Convert.ToDateTime(_ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }



    }
    #endregion
    #region Bind Od Type
    protected void BindOdType(string companyId)
    {
        SqlConnection conncetion = activity.OpenConnection();
        string sqlstr = @"select * from tbl_leave_createod where status=1 and company_id='" + companyId + "'";
        DataSet ds = SQLServer.ExecuteDataset(conncetion, CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlOdType.DataSource = ds;
            ddlOdType.DataValueField = "odid";
            ddlOdType.DataTextField = "odtype";
            ddlOdType.DataBind();
        }
    }
    #endregion

    protected Boolean validate_applydate()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, _userCode);
            if (divfull.Visible == true)
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, txt_sdate.Text);
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, txt_edate.Text);

            }
            else
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, txt_select.Text);
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, txt_select.Text);

            }
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_applied_date", sqlparam);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                Output.Show("You have already applied leave during this span! Please check application status");
                return false;
            }
            else
            {
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    Output.Show("You have already applied for Compoff during this span! Please check application status");
                    return false;
                }
                else
                {
                    if (_ds.Tables[2].Rows.Count > 0)
                    {
                        Output.Show("You have already applied for OD during this span! Please check application status");
                        return false;
                    }
                    else
                    {
                        //if (_ds.Tables[4].Rows.Count > 0)
                        //{
                        //    Output.Show("You have already applied for Substitute Holiday during this span! Please check application status");
                        //    return false;
                        //}
                        //else
                        //{
                        if (_ds.Tables[3].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            Output.Show("Your leave profile is not created! Please contact your Manager");
                            return false;
                        }
                        // }
                    }
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
        return true;
    }

    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        SqlConnection connection = activity.OpenConnection();
        SqlTransaction transaction = null;
        try
        {
            if (divhalf.Visible == true)
            {
                if (txt_select.Text == "")
                {
                    Output.Show("Please select date.");
                    txt_sdate.Focus();
                    return;
                }

            }
            //if (Convert.ToDateTime( txt_sdate.Text > txt_edate.Text)
            //{
            //    Output.Show("FromDate should be less than ToDate.PleaSE check the dates.");
            //    return;
            //}
            //if (!validate_dutyroster())
            //    return;
            if (!validate_applydate())
                return;
            //if (!validate_OdDate())
            //    return;
            //if (!Validate_Od())
            //    return;
            if (txt_comment.Text != "")
                comment = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
            else
                comment = "";
            int leavemode;
            DateTime fromdate = new DateTime();
            DateTime todate = new DateTime();
            DateTime fromtime = new DateTime();
            DateTime totime = new DateTime();
            DateTime hdate = new DateTime();
            bool half;

            ArrayList list = new ArrayList();

            if (divfull.Visible == true)
            {
                divfull.Visible = true;
                divhalf.Visible = false;
                fulltime.Visible = false;
                leavemode = 1;
                fromdate = Convert.ToDateTime(txt_sdate.Text);
                todate = Convert.ToDateTime(txt_edate.Text);
                fromtime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                totime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                hdate = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                half = false;
                double No_Of_OD_days = (todate - fromdate).TotalDays;
                No_Of_OD_days = No_Of_OD_days + 1;
                HiddenField1.Value = Convert.ToString(No_Of_OD_days);
                if (!validatetimespan(fromtime, totime, fromdate, todate))
                    return;
            }
            else
            {
                divfull.Visible = false;
                divhalf.Visible = true;
                fulltime.Visible = false;
                leavemode = 0;
                fromdate = Convert.ToDateTime(txt_select.Text);
                todate = Convert.ToDateTime(txt_select.Text);
                fromtime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                totime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
                hdate = Convert.ToDateTime(txt_select.Text);
                half = opt_first.Checked;
                HiddenField1.Value = Convert.ToString("0.5");
                if (!validatetimespan(fromtime, totime, fromdate, todate))
                    return;
            }

            transaction = connection.BeginTransaction();
            int i = apply_od(_userCode, Convert.ToDecimal(HiddenField1.Value), txt_reason.Text, 0, 0, true, true, System.DateTime.Now, Session["name"].ToString(), Session["name"].ToString(), comment.ToString(), leavemode, fromdate, todate, fromtime, totime, hdate, half, connection, transaction, ref k);
            transaction.Commit();
            if (i <= 0)
            {
                //list.Add("Problem applying OD, try again");
                Output.Show("Problem applying OD, try again");
            }
            else
            {
                //list.Add("OD application applied successfully");
                Output.Show("OD application applied successfully");
                

                SendMail(i);
                sendmailtoemp(i);
                // Mail(list, i, "o");
                clearfield();
                string str = "";
                for (int j = 0; j < list.Count; j++)
                {
                    str = str + list[j].ToString();
                    str = str + "\\n";
                }


                // Output.Show(str);

            }
        }
        catch (Exception ex)
        {
            //if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Problem applying OD. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        } 
    }

    void SendEmail(int leaveid)
    {
        try
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfODRequest();
            EmailClient client = new EmailClient(email);
            client.toEmailId = Session["OfficialEmailId"].ToString().Trim();
            client.empCode = Session["empcode"].ToString();
            client.employeeName = Session["name"].ToString().Trim();
            client.appsendername = Session["name"].ToString().Trim();
            client.requestNumber = leaveid.ToString();
            client.Send();
        }
        catch (Exception ex)
        {
            Smart.HR.Common.Console.Output.Log("During Apply Leave: " + ex.Message + ".    " + DateTime.Now);
            throw ex;
        }
    }

    //private void Mail(ArrayList list, int leaveid, string type)
    //{
    //    SendEmail(leaveid);

    //    var activity = new DataActivity();
    //    SqlParameter[] sqlparm = new SqlParameter[2];
    //    Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
    //    Output.AssignParameter(sqlparm, 1, "@type", "String", 20, type.ToString());

    //    SqlConnection connection = activity.OpenConnection();
    //    DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
    //    activity.CloseConnection();

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        int n = ds.Tables[0].Rows.Count;

    //        for (int i = 0; i < n; i++)
    //        {
    //            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
    //            {
    //                EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfODRequestApprover();
    //                EmailClient client = new EmailClient(email);
    //                client.toEmailId = ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim();
    //                client.empCode = ds.Tables[0].Rows[i]["approvercode"].ToString().Trim();
    //                client.employeeName = ds.Tables[0].Rows[i]["a_name"].ToString().Trim();
    //                client.appsendername = Session["name"].ToString().Trim();
    //                client.requestNumber = leaveid.ToString();
    //                client.Send();
    //            }
    //            else
    //            {
    //                list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[i]["a_name"]);
    //            }

    //        }
    //    }
    //    else
    //    {
    //        throw new Exception("No approvers");

    //    }

    //}

    private bool validate_OdDate()
    {
        SqlConnection connection = activity.OpenConnection();
        try
        {
            sqlstr = @"select isnull(COUNT(*),0) as PresenetDays from tbl_attendance_log 
                    inner join tbl_attendance_empipenrollno_mapping on tbl_attendance_empipenrollno_mapping.machinecode=tbl_attendance_log.enrollno
                        where empcode='" + _userCode.ToString() + "' and convert(varchar(10),date,101) between convert(varchar(10),'" + txt_sdate.Text.ToString() + "',101) and convert(varchar(10),'" + txt_edate.Text.ToString() + "',101)";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if ((ds.Tables[0].Rows[0]["PresenetDays"] != null) && (ds.Tables[0].Rows[0]["PresenetDays"].ToString() != ""))
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["PresenetDays"]) > 0)
                    {
                        Common.Console.Output.Show("Leave not allowed as employee present between  " + txt_sdate.Text.ToString() + "  to  " + txt_edate.Text.ToString() + " . please choose different date.");
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Problem applying OD. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return true;
    }
    private bool Validate_Od()
    {
        try
        {

            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @"select * from tbl_leave_create_od_rule where status=1 and company_id='" + _companyId + "' and odtypeid='" + ddlOdType.SelectedValue + "' ";
            DataSet ds20 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds20.Tables[0].Rows.Count < 1)
            {
                Output.Show("OD Rule not defined,contact administrator");

                return false;
            }

            DateTime sdate;
            if (divfull.Visible == true)
                sdate = Convert.ToDateTime(txt_sdate.Text);
            else
                sdate = Convert.ToDateTime(txt_select.Text);

            TimeSpan ts = sdate - DateTime.Now;
            if (sdate > DateTime.Now)
            {
                Output.Show("Please select before current date.");

                return false;
            }
            if (Convert.ToInt16(ds20.Tables[0].Rows[0]["backdays"]) <
                   Convert.ToInt16(Math.Abs(ts.TotalDays)))
            {
                Output.Show("Maximum back day leave allowed is  " + ds20.Tables[0].Rows[0]["backdays"]);

                return false;
            }

            string sqlstr1 = @"select * from tbl_leave_create_od_rule_weekday where status=1 and od_id='" + ddlOdType.SelectedValue + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string exp = "applicable_week_of_type='" + DateTime.Now.DayOfWeek.ToString() + "'";
                    DataRow[] myrow = ds.Tables[0].Select(exp);
                    if (myrow.Length <= 0)
                    {
                        Output.Show("" + ddlOdType.SelectedItem.Text + " OD application should not apply on " + DateTime.Now.DayOfWeek.ToString() + "");
                        return false;
                    }

                }

            }

            if (ds20.Tables[0].Rows[0]["weektype"].ToString() != "0")
            {
                if (ds20.Tables[0].Rows[0]["weektype"].ToString() == "1") // Current Week
                {
                    DateTime s_date = Convert.ToDateTime(txt_sdate.Text.ToString());
                    CultureInfo ciCurr = CultureInfo.CurrentCulture;
                    int weekNumdate = ciCurr.Calendar.GetWeekOfYear(s_date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    int weeknumofcurdate = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    if (weekNumdate != weeknumofcurdate)
                    {
                        Output.Show("" + ddlOdType.SelectedItem.Text + " OD application should apply on current week ");
                        return false;
                    }


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
        return true;
    }

    public int apply_od(string empcode, decimal working_hour, string reason, int Approval_status, int Leave_status, bool flag, bool status, DateTime createddate, string createdby, string modifiedby, string comment, int leavemode, DateTime fromdate, DateTime todate, DateTime fromtime, DateTime totime, DateTime hdate, bool half, SqlConnection connection, SqlTransaction transaction, ref int j)
    {
        SqlParameter[] sqlparam = new SqlParameter[20];
        Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, empcode.ToString());
        Output.AssignParameter(sqlparam, 1, "@working_hour", "Decimal", 50, working_hour.ToString());
        Output.AssignParameter(sqlparam, 2, "@reason", "String", 5000, reason);
        Output.AssignParameter(sqlparam, 3, "@Approval_status", "Int", 50, Approval_status.ToString());
        Output.AssignParameter(sqlparam, 4, "@Leave_status", "Int", 50, Leave_status.ToString());
        Output.AssignParameter(sqlparam, 5, "@flag", "String", 50, flag.ToString());
        Output.AssignParameter(sqlparam, 6, "@status", "String", 50, status.ToString());
        Output.AssignParameter(sqlparam, 7, "@createdby", "String", 50, createdby.ToString());
        Output.AssignParameter(sqlparam, 8, "@createddate", "DateTime", 50, createddate.ToString());
        Output.AssignParameter(sqlparam, 9, "@comment", "String", 5000, comment);
        Output.AssignParameter(sqlparam, 10, "@modifiedby", "String", 50, modifiedby);
        Output.AssignParameter(sqlparam, 11, "@leavemode", "Int", 50, leavemode.ToString());
        Output.AssignParameter(sqlparam, 12, "@fromdate", "DateTime", 50, fromdate.ToString());
        Output.AssignParameter(sqlparam, 13, "@todate", "DateTime", 50, todate.ToString());
        Output.AssignParameter(sqlparam, 14, "@fromtime", "DateTime", 50, fromtime.ToString());
        Output.AssignParameter(sqlparam, 15, "@totime", "DateTime", 50, totime.ToString());
        Output.AssignParameter(sqlparam, 16, "@hdate", "DateTime", 50, hdate.ToString());
        Output.AssignParameter(sqlparam, 17, "@half", "String", 50, half.ToString());
        Output.AssignParameter(sqlparam, 18, "@comapnyid", "Int", 50, _companyId.ToString());
        Output.AssignParameter(sqlparam, 19, "@odtype", "Int", 50, "0");

        j = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, transaction, "sp_leave_applyod", sqlparam));
        return j;
    }

    private bool validatetimespan(DateTime fromtime, DateTime totime, DateTime fromdate, DateTime todate)
    {
        if (divfull.Visible == true)
        {
            if (fromdate > todate)
            {
                Output.Show("FromDate Should be less than ToDate.Please check the Selected Dates.");
                return false;
            }
            // else return true;
            TimeSpan maxhrs = TimeSpan.FromHours(2);
            TimeSpan ts = totime.Subtract(fromtime);
            // TimeSpan maxhrs=02.00.00;
            if (fromtime < totime)
            {
                return true;

            }
            else
            {

                // Output.Show("End Time Must be Greater than Start Time");
                return true;
            }
        }
        else
            return true;
    }


    protected void mailtoapprover(ArrayList list, int leaveid, string type)
    {
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 50, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 50, type.ToString());
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = ds.Tables[0].Rows.Count;
            int j = 0;

            while (i != 0)
            {

                string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                //query q = new query();
                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "OD");
                //string encoded;
                //encoded = q.EncodePairs(pairs);

                string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
                string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";

                string subject = "Official Duty Application for Approval";

                string bodyContent = "";
                if (divfull.Visible == true)
                    bodyContent = "A new OD request has been submitted by employee " + Session["name"].ToString() + " from " + txt_sdate.Text + " to " + txt_edate.Text + ". <br/><br/><br/><br/>" + url + "&nbsp;&nbsp;&nbsp;" + url1;
                else
                    bodyContent = "A new OD request has been submitted by employee " + Session["name"].ToString() + " for the date " + txt_select.Text + ". <br/><br/><br/><br/>" + url + "&nbsp;&nbsp;&nbsp;" + url1;

                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(), bodyContent);

                if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
                {
                    try
                    {

                        Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                    }
                    catch
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString() + " due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Email id does not exists for the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString());
                }

                i--;
                j++;
            }
        }
    }

    protected void clearfield()
    {
        txt_sdate.Text = "";
        txt_edate.Text = "";
        txt_reason.Text = "";
        txt_comment.Text = "";
        txtftime.Text = "";
        txttotime.Text = "";
        txt_select.Text = "";
        opt_first.Checked = true;
        opt_second.Checked = false;
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clearfield();
    }

    //protected Boolean validate_dutyroster()
    //{
    //    TimeSpan d1;
    //    if (divfull.Visible == true)
    //    {
    //        DateTime dt1 = Convert.ToDateTime(txt_sdate.Text);
    //        DateTime dt2 = Convert.ToDateTime(txt_edate.Text);
    //        d1 = Convert.ToDateTime(txt_edate.Text) - Convert.ToDateTime(txt_sdate.Text);
    //    }
    //    else
    //    {
    //        DateTime dt1 = Convert.ToDateTime(txt_select.Text);
    //        DateTime dt2 = Convert.ToDateTime(txt_select.Text);
    //        d1 = Convert.ToDateTime(txt_select.Text) - Convert.ToDateTime(txt_select.Text);
    //    }


    //    //DateTime dt1 = Convert.ToDateTime(txt_sdate.Text);
    //    //DateTime dt2 = Convert.ToDateTime(txt_edate.Text);
    //    //TimeSpan d1 = Convert.ToDateTime(txt_edate.Text) - Convert.ToDateTime(txt_sdate.Text);
    //    if (d1.Days < 0)
    //    {
    //         Common.Console.Output.Show( "End date should be greater than start date.";
    //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
    //        //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
    //        return false;
    //    }
    //    //-----------------validate---work roster creation---------------------------------
    //    DataSet dsdr = new DataSet();

    //    SqlParameter[] sqlpar = new SqlParameter[3];

    //    sqlpar[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
    //    sqlpar[0].Value = Session["empcode"].ToString();

    //    sqlpar[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
    //    sqlpar[2] = new SqlParameter("@todate", SqlDbType.DateTime);

    //    if (divfull.Visible == true)
    //    {
    //        sqlpar[1].Value = txt_sdate.Text;
    //        sqlpar[2].Value = txt_edate.Text;
    //    }
    //    else
    //    {
    //        sqlpar[1].Value = txt_select.Text;
    //        sqlpar[2].Value = txt_select.Text;
    //    }

    //    dsdr = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_leave_dutyroster", sqlpar);

    //    if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) > 0)
    //    {
    //        if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) != Convert.ToInt32(dsdr.Tables[1].Rows[0]["applieddays"].ToString()))
    //        {
    //             Common.Console.Output.Show( "Your work roster is not created for this date span.Please contact your Manager.";
    //            //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
    //            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //         Common.Console.Output.Show( "Your work roster is not created for this date span.Please contact your Manager.";
    //        //Page.RegisterStartupScript("vv", "<script> alert('" + message1.ToString() + "')</script>");
    //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
    //        return false;
    //    }
    //    return true;
    //}

    protected void txt_ftime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TimeSpan t = Convert.ToDateTime(txt_edate.Text) - Convert.ToDateTime(txt_sdate.Text);
            //TimeSpan t = Convert.ToDateTime(txt_edate.Text) - Convert.ToDateTime(txt_sdate.Text);
            HiddenField1.Value = Convert.ToString(t.Days + 1);
        }
        catch
        {
            HiddenField1.Value = Convert.ToString("1");
        }
    }

    protected void txt_date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TimeSpan t = Convert.ToDateTime(txt_edate.Text) - Convert.ToDateTime(txt_sdate.Text);
            HiddenField1.Value = Convert.ToString(t.Days + 1);
        }
        catch
        {
            HiddenField1.Value = Convert.ToString("1");
        }
    }

    protected void opt_first_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void opt_second_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rdofullday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            fulltime.Visible = false;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            fulltime.Visible = false;
        }
    }

    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdohalfday.Checked == true)
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            fulltime.Visible = false;
        }
        else
        {
            divhalf.Visible = false;
            divfull.Visible = true;
            fulltime.Visible = false;
        }
    }


    private void SendMail(int leaveid)
    {
        if (divfull.Visible == true)
        {
            fromdt = txt_sdate.Text;
            todate = txt_edate.Text;
        }
        else
        {
            fromdt = txt_select.Text;
            todate = txt_select.Text;
        }


        //-----------------------Sending Mail To Employee---------------------//

        //string empmsg = "Dear " + lbl_emp_name.Text + "," + "\n" + "\n";
        //empmsg += "Thanks for using Smart HR.You have applied " + dd_typeleave.SelectedItem + " for " + txt_nod.Text + " days that is from " + fromdt + "  to  " + todt + "\n";
        //empmsg += "Your application will submitted to Approver for Approval" + "\n" + "\n " + "\n";

        //empmsg += "Regards" + "," + "\n";
        //empmsg += "HR" + "\n";
        //if (Session["OfficialEmailId"].ToString().Trim() != "")
        //{
        //  //  sendmail_Template(Session["OfficialEmailId"].ToString().Trim(), empmsg);
        //}
        //----------------------Sending Mail To Approver ---------------------//

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //SqlParameter[] sqlparm = new SqlParameter[2];
        //Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        //Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "co");


        string query = @"select distinct job.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_employee_approvers app 
inner join dbo.tbl_intranet_employee_jobDetails job 
on job.empcode=app.app_reportingmanager
inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager 
where app.empcode='" + Session["empcode"].ToString() + "'";

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
        activity.CloseConnection();


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //string appmsg = "Dear " + ds.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            //appmsg += " You have a pending Leave Application from " + lbl_emp_name.Text.Trim() + " - " + _userCode.Trim() + "\n" + "\n " + "\n";
            //appmsg += "Regards" + "," + "\n";
            //appmsg += "HR" + "\n";
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["emp_fname"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim(), fromdt, todate, ds.Tables[0].Rows[i]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[i]["dlm_mail"].ToString().Trim());
            }
        }


    }

    public bool sendmail_Template(string recievermailid, string approver, string employee, string empcode, string fromdt, string todate, string lm_mail, string dlm_mail)
    {

        try
        {


            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];

            string Template = EmailTemplate(approver, employee, empcode, fromdt, todate);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            //mailMessage.CC.Add(lm_mail);
            mailMessage.CC.Add(dlm_mail);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "OD Application";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;

            //if (fileAttachment.HasFile)
            //{
            //    FileName = Path.GetFileName(fileAttachment.PostedFile.FileName);
            //    FileName = "attachments/" + FileName;
            //    fileAttachment.PostedFile.SaveAs(Server.MapPath(FileName));

            //    attachment = new System.Net.Mail.Attachment(Server.MapPath(FileName));
            //    mailMessage.Attachments.Add(attachment);

            //    IsAttachment = true;
            //}

            mailMessage.Priority = MailPriority.High;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            smtpClient.Host = ConfigurationManager.AppSettings["smtp"];
            smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);

            object userState = mailMessage;

            try
            {

                smtpClient.Send(mailMessage);
                if (IsAttachment)
                {
                    attachment.ContentStream.Close();

                }
                return true;
            }
            catch (System.Net.Mail.SmtpException)
            {
                return false;
            }
        }


        catch (Exception)
        {
            return false;
        }
    }
    public string EmailTemplate(string approver, string employee, string empcode, string fromdt, string todate)
    {

        string appr = approver.ToString();
        string emp = employee.ToString();
        string empcod = empcode.ToString();
        string EmailFormat = @"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>" +
                    "<html lang='en'>" +
"<head>" +

    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +

    "<style type='text/css'>" +
        "body, td, div, p, a, input" +
        "{" +
            "font-family: arial, sans-serif;" +
        "}" +
    "</style>" +

    "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
    "<title>OD Application</title>" +
    "<style type='text/css'>" +
        "body, td" +
        "{" +
            "font-size: 13px;" +
        "}" +

        "a:link, a:active" +
        "{" +
            "color: #1155CC;" +
            "text-decoration: none;" +
        "}" +

        "a:hover" +
       "{" +
            "text-decoration: underline;" +
            "cursor: pointer;" +
        "}" +

        "a:visited" +
        "{" +
            "color: #6611CC;" +
        "}" +

        "img" +
        "{" +
            "border: 0px;" +
        "}" +

        "pre" +
        "{" +
            "white-space: pre;" +
            "white-space: -moz-pre-wrap;" +
            "white-space: -o-pre-wrap;" +
            "white-space: pre-wrap;" +
           "word-wrap: break-word;" +
           "max-width: 800px;" +
            "overflow: auto;" +
        "}" +

        ".logo" +
        "{" +
            "left: -7px;" +
            "position: relative;" +
        "}" +
    "</style>" +
"</head>" +
"<body>" +
    "<div class='bodycontainer'>" +


        "<div class='maincontent'>" +

            "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>" +
                "<tr>" +

                    "<tr>" +
                        "<td colspan='2'><font size='-1' class='recipient'>" +
                            "<div></div>" +
                        "</font>" +
                           " <tr>" +
                                "<td colspan='2'>" +
                                    "<table width='100%' cellpadding='12' cellspacing='0' border='0'>" +
                                        "<tr>" +
                                            "<td>" +
                                                "<div style='overflow: hidden;'>" +
                                                    "<font size='-1'>" +
                                                        "<div id='leaveid'>" +
            //"<table width='100%'>" +
            //    "<tbody>" +

                                                            //        "<tr>" +
            //            "<td style='border-bottom: 1px solid #ccc; font: 12px arial'>" +
            //                "<div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Holiday Work Application</span></div>" +
            //            "</td>" +
            //            "<td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>" +
            //        "</tr>" +
            //    "</tbody>" +
            //"</table>" +
            //"<br>" +
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a OD request from  " + emp + " - " + empcod + " dated from " + Convert.ToDateTime(fromdt).ToString("dd-MMM-yyyy") + " - " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + " for Approval / Reject.</p>" +

                                                            "<p>Click here - https://escalon.sdlapps.com </p>" +

                                                            "<p>" +
                                                                "<b>Regards,<br><br>" +
                                                                    "HR<br><br>" +
                                                                "</b>" +
                                                            "</p>" +
                                                            "<br>" +

                                                            "<table width='100%'>" +
                                                                "<tbody>" +
                                                                    "<tr>" +
                                                                        "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                            "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR." +
                                                                            "<br>" +
            //"(1) Call our 24-hour Customer Care or<br>" +
            //"(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>" +
                                                                            "<br>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                        "</td>" +
                                                                    "</tr>" +
                                                                "</tbody>" +
                                                            "</table>" +

                                                        "</div>" +
                                                    "</font>" +
                                                "</div>" +
                                    "</table>" +
            "</table>" +
        "</div>" +
    "</div>" +

"</body>" +
"</html>";

        return EmailFormat;
    }

    private void sendmailtoemp(int leaveid)
    {
        if (divfull.Visible == true)
        {
            fromdt = txt_sdate.Text;
            todate = txt_edate.Text;
        }
        else
        {
            fromdt = txt_select.Text;
            todate = txt_select.Text;
        }

        //-----------------------Sending Mail To Employee---------------------//

        //string empmsg = "Dear " + lbl_emp_name.Text + "," + "\n" + "\n";
        //empmsg += "Thanks for using Smart HR.You have applied " + dd_typeleave.SelectedItem + " for " + txt_nod.Text + " days that is from " + fromdt + "  to  " + todt + "\n";
        //empmsg += "Your application will submitted to Approver for Approval" + "\n" + "\n " + "\n";

        //empmsg += "Regards" + "," + "\n";
        //empmsg += "HR" + "\n";
        //if (Session["OfficialEmailId"].ToString().Trim() != "")
        //{
        //  //  sendmail_Template(Session["OfficialEmailId"].ToString().Trim(), empmsg);
        //}
        //----------------------Sending Mail To Approver ---------------------//

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //SqlParameter[] sqlparm = new SqlParameter[2];
        //Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        //Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "co");


        string query = @"select distinct joblm.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_intranet_employee_jobDetails job
 inner join tbl_employee_approvers app on app.empcode=job.empcode
 inner join tbl_intranet_employee_jobDetails jobvh on jobvh.empcode=app.clr_department
 inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
 inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager
 where job.empcode='" + Session["empcode"].ToString() + "'";

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
        activity.CloseConnection();


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //string appmsg = "Dear " + ds.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            //appmsg += " You have a pending Leave Application from " + lbl_emp_name.Text.Trim() + " - " + _userCode.Trim() + "\n" + "\n " + "\n";
            //appmsg += "Regards" + "," + "\n";
            //appmsg += "HR" + "\n";
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template1(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["emp_fname"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim(), fromdt, todate, ds.Tables[0].Rows[i]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[i]["dlm_mail"].ToString().Trim());
            }
        }


    }

    public bool sendmail_Template1(string recievermailid, string approver, string employee, string empcode, string fromdt, string todate, string lm_mail, string dlm_mail)
    {

        try
        {


            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];

            string Template = EmailTemplate1(approver, employee, empcode, fromdt, todate);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            //mailMessage.CC.Add(lm_mail);
            mailMessage.CC.Add(dlm_mail);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "OD Application";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;

            //if (fileAttachment.HasFile)
            //{
            //    FileName = Path.GetFileName(fileAttachment.PostedFile.FileName);
            //    FileName = "attachments/" + FileName;
            //    fileAttachment.PostedFile.SaveAs(Server.MapPath(FileName));

            //    attachment = new System.Net.Mail.Attachment(Server.MapPath(FileName));
            //    mailMessage.Attachments.Add(attachment);

            //    IsAttachment = true;
            //}

            mailMessage.Priority = MailPriority.High;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            smtpClient.Host = ConfigurationManager.AppSettings["smtp"];
            smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);

            object userState = mailMessage;

            try
            {

                smtpClient.Send(mailMessage);
                if (IsAttachment)
                {
                    attachment.ContentStream.Close();

                }
                return true;
            }
            catch (System.Net.Mail.SmtpException)
            {
                return false;
            }
        }


        catch (Exception)
        {
            return false;
        }
    }
    public string EmailTemplate1(string approver, string employee, string empcode, string fromdt, string todate)
    {

        string appr = approver.ToString();
        string emp = employee.ToString();
        string empcod = empcode.ToString();
        string EmailFormat = @"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>" +
                    "<html lang='en'>" +
"<head>" +

    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +

    "<style type='text/css'>" +
        "body, td, div, p, a, input" +
        "{" +
            "font-family: arial, sans-serif;" +
        "}" +
    "</style>" +

    "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
    "<title>OD Application</title>" +
    "<style type='text/css'>" +
        "body, td" +
        "{" +
            "font-size: 13px;" +
        "}" +

        "a:link, a:active" +
        "{" +
            "color: #1155CC;" +
            "text-decoration: none;" +
        "}" +

        "a:hover" +
       "{" +
            "text-decoration: underline;" +
            "cursor: pointer;" +
        "}" +

        "a:visited" +
        "{" +
            "color: #6611CC;" +
        "}" +

        "img" +
        "{" +
            "border: 0px;" +
        "}" +

        "pre" +
        "{" +
            "white-space: pre;" +
            "white-space: -moz-pre-wrap;" +
            "white-space: -o-pre-wrap;" +
            "white-space: pre-wrap;" +
           "word-wrap: break-word;" +
           "max-width: 800px;" +
            "overflow: auto;" +
        "}" +

        ".logo" +
        "{" +
            "left: -7px;" +
            "position: relative;" +
        "}" +
    "</style>" +
"</head>" +
"<body>" +
    "<div class='bodycontainer'>" +


        "<div class='maincontent'>" +

            "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>" +
                "<tr>" +

                    "<tr>" +
                        "<td colspan='2'><font size='-1' class='recipient'>" +
                            "<div></div>" +
                        "</font>" +
                           " <tr>" +
                                "<td colspan='2'>" +
                                    "<table width='100%' cellpadding='12' cellspacing='0' border='0'>" +
                                        "<tr>" +
                                            "<td>" +
                                                "<div style='overflow: hidden;'>" +
                                                    "<font size='-1'>" +
                                                        "<div id='leaveid'>" +
            //"<table width='100%'>" +
            //    "<tbody>" +

                                                            //        "<tr>" +
            //            "<td style='border-bottom: 1px solid #ccc; font: 12px arial'>" +
            //                "<div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Holiday Work Application</span></div>" +
            //            "</td>" +
            //            "<td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>" +
            //        "</tr>" +
            //    "</tbody>" +
            //"</table>" +
            //"<br>" +
                                                            "<p><b>Dear " + emp + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your OD request has been submitted successfully to Line Manager  " + appr + " from dated from " + Convert.ToDateTime(fromdt).ToString("dd-MMM-yyyy") + " - " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + "  for Approval / Reject. Once approved by the Line Manager your OD balance would be added in the attendance module. </p>" +

                                                            "<p>Click here - https://escalon.sdlapps.com </p>" +

                                                            "<p>" +
                                                                "<b>Regards,<br><br>" +
                                                                    "HR<br><br>" +
                                                                "</b>" +
                                                            "</p>" +
                                                            "<br>" +

                                                            "<table width='100%'>" +
                                                                "<tbody>" +
                                                                    "<tr>" +
                                                                        "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                            "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR." +
                                                                            "<br>" +
            //"(1) Call our 24-hour Customer Care or<br>" +
            //"(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>" +
                                                                            "<br>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                        "</td>" +
                                                                    "</tr>" +
                                                                "</tbody>" +
                                                            "</table>" +

                                                        "</div>" +
                                                    "</font>" +
                                                "</div>" +
                                    "</table>" +
            "</table>" +
        "</div>" +
    "</div>" +

"</body>" +
"</html>";

        return EmailFormat;
    }

}
