using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class leave_updateleaverule : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId;
    SqlConnection _connection;
    SqlTransaction transaction = null;
    string sqlstr = "";
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    double a;
    double b;
    double d;
    int c;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindLeaverule();
                BindEmployeeStatus(Convert.ToInt32(_companyId));
                BindEmpStatus();
                DataSet dsReport = (DataSet)Session["leavetypess"];
                if (dsReport.Tables[0].Rows[0]["leavetype"].ToString() == "Maternity Leave")
                {
                    if (rd_Entitled_yes.Checked == true)
                    {
                        entitledid.Visible = true;
                        txt_entitled.ReadOnly = true;
                        postid.Visible = true;
                    }
                    else
                    {
                        entitledid.Visible = false;
                        postid.Visible = false;
                    }
                }
                else
                {
                    entitledid.Visible = true;
                    postid.Visible = false;
                }
            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    protected void BindLeaverule()
    {
        try
        {
            _connection = activity.OpenConnection();
            var parm = new SqlParameter[1];
            Output.AssignParameter(parm, 0, "@id", "Int", 10, Request.QueryString["id"].ToString());
//            sqlstr = @"select def.carryforward_maximum_days,def.days_before_leaveapply,def.entitled_days,def.backdate_howmany_days,def.applicable_to,def.entitle_applicable,
//       def.maximum_no_days,def.minimum_no_days,def.backdate_leave_applicable,def.id,def.leaveid,def.policyid,policy.policyname,leave.leavetype,
//       def.carryforward_applicable,def.document_required,def.leave_modification,def.holidays_counted_asleave,def.halfday_leave_applicable,def.weekly_off,def.accumulated_days,
//def.document_days,def.isworking_days,working_days,applicable_to_marital,esi_applicable,esi_cutoff_amount,is_last_year_working_days,last_year_working_days,is_protata,is_nextyearapplicable,min_accumulated_days,monthly_leave_applicable,monthly_leave_max_noofdays,monthly_leave_max_nooftimes,encash_applicable,encash_days_limt
//       from tbl_leave_createdefaultrule def 
//       inner join tbl_leave_createleavepolicy policy on def.policyid=policy.policyid
//       inner join tbl_leave_createleave leave on leave.leaveid=def.leaveid 
//       where id=" + Request.QueryString["id"] + "";

            sqlstr= @"select 
def.carryforward_maximum_days,
def.days_before_leaveapply,
def.entitled_days,
def.backdate_howmany_days,
def.applicable_to,
def.entitle_applicable,
def.maximum_no_days,def.minimum_no_days,
def.backdate_leave_applicable,
def.id,def.leaveid,
def.policyid,
policy.policyname,
leave.leavetype,
def.carryforward_applicable,
def.document_required,
def.leave_modification,
def.holidays_counted_asleave,
def.halfday_leave_applicable,def.weekly_off,
def.accumulated_days,
def.document_days,
def.isworking_days,def.accum_Check,def.Monthly_proce,def.Monthly_Days,def.Carry_Check,
working_days,
applicable_to_marital,
esi_applicable,
esi_cutoff_amount,
is_last_year_working_days,
last_year_working_days,
is_protata,is_nextyearapplicable,
min_accumulated_days,
monthly_leave_applicable,
monthly_leave_max_noofdays,
monthly_leave_max_nooftimes,
encash_applicable,
encash_days_limt,
postdelivery ,
predelivery 
from tbl_leave_createdefaultrule def 
       inner join tbl_leave_createleavepolicy policy on def.policyid=policy.policyid
       inner join tbl_leave_createleave leave on leave.leaveid=def.leaveid 
       where id=" + Request.QueryString["id"] + "";

            ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, sqlstr, parm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_days_before_leave.Text = ds.Tables[0].Rows[0]["days_before_leaveapply"].ToString();
                txt_entitled.Text = ds.Tables[0].Rows[0]["entitled_days"].ToString();
                hidden_entitled.Value = ds.Tables[0].Rows[0]["entitled_days"].ToString();
                txt_how_many.Text = ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();
                txt_maximum.Text = ds.Tables[0].Rows[0]["maximum_no_days"].ToString();
                txt_minimum.Text = ds.Tables[0].Rows[0]["minimum_no_days"].ToString();
                lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
                lbl_policy_name.Text = ds.Tables[0].Rows[0]["policyname"].ToString();
                hidden_leaveid.Value = ds.Tables[0].Rows[0]["leaveid"].ToString();
                hidden_policyid.Value = ds.Tables[0].Rows[0]["policyid"].ToString();
                string gender = ds.Tables[0].Rows[0]["applicable_to"].ToString();
                string materialstatus = ds.Tables[0].Rows[0]["applicable_to_marital"].ToString();
                txt_working_days.Text = ds.Tables[0].Rows[0]["working_days"].ToString();
                txt_excess_days.Text = ds.Tables[0].Rows[0]["document_days"].ToString();
                txt_last_year_working_days.Text = ds.Tables[0].Rows[0]["last_year_working_days"].ToString();
                txt_salary.Text = ds.Tables[0].Rows[0]["esi_cutoff_amount"].ToString();
                txt_mon_max_days.Text = ds.Tables[0].Rows[0]["monthly_leave_max_noofdays"].ToString();
                txt_mon_max_nooftimes.Text = ds.Tables[0].Rows[0]["monthly_leave_max_nooftimes"].ToString();
                txt_EncashLimit.Text = ds.Tables[0].Rows[0]["encash_days_limt"].ToString();
                postdelivery.Text = ds.Tables[0].Rows[0]["postdelivery"].ToString();
                predelivery.Text = ds.Tables[0].Rows[0]["predelivery"].ToString();
                if (gender == "M")
                {
                    chkMale.Checked = true;
                }
                else if (gender == "F")
                {
                    chkFemale.Checked = true;
                }
                else if (gender == "A")
                {
                    chkMale.Checked = true;
                    chkFemale.Checked = true;
                }
                if (materialstatus == "M")
                {
                    chkmarried.Checked = true;
                }
                else if (materialstatus == "U")
                {
                    chkmarried.Checked = true;
                }
                else if (materialstatus == "A")
                {
                    chkmarried.Checked = true;
                    chkunmarried.Checked = true;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["isworking_days"]) == true)
                {
                    rd_workdays_yes.Checked = true;
                    txt_working_days.Enabled = true;
                    rd_workdays_no.Checked = false;
                }
                else
                {
                    rd_workdays_no.Checked = true;
                    txt_working_days.Enabled = false;
                    rd_workdays_yes.Checked = false;
                }

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["entitle_applicable"]) == true)
                {
                    txt_entitled.Enabled = true;
                    rd_Entitled_yes.Checked=true;
                        rd_Entitled_no.Checked=false;
                }
                else
                {
                    txt_entitled.Enabled = false;
                    rd_Entitled_yes.Checked = false;
                    rd_Entitled_no.Checked = true;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Monthly_proce"]) == true)
                {
                    txt_entitled.Enabled = false;
                    txt_entitled.Text = "0";
                    RadMonthly_yes.Checked = true;
                    RadMonthly_no.Checked = false;
                    txt_month_days.Text = ds.Tables[0].Rows[0]["Monthly_Days"].ToString();

                }
                else
                {
                    txt_entitled.Enabled =true ;
                    RadMonthly_yes.Checked = false;
                    RadMonthly_no.Checked = true;
                    txt_month_days.Text = "0";
                   
                }

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["esi_applicable"]) == true)
                {
                    rd_Esi_Applicable_yes.Checked = true;
                    txt_salary.Enabled = true;
                    rd_Esi_Applicable_no.Checked = false;
                }
                else
                {
                    rd_Esi_Applicable_yes.Checked = false;
                    rd_Esi_Applicable_no.Checked = true;
                    txt_salary.Enabled = false;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["is_last_year_working_days"]) == true)
                {
                    rd_last_year_work_days_yes.Checked = true;
                    rd_last_year_work_days_no.Checked = false;
                    txt_last_year_working_days.Enabled = true;
                }
                else
                {
                    rd_last_year_work_days_no.Checked = true;
                    rd_last_year_work_days_yes.Checked = false;
                    txt_last_year_working_days.Enabled = false;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["carryforward_applicable"]) == true)
                {
                    opt_carryforward_yes.Checked = true;
                    opt_carryforward_no.Checked = false;
                    //rd_encash_app_yes.Checked = true;
                    //rd_encash_app_no.Checked = false;
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["carryforward_maximum_days"]) != 0.0)
                    {
                        opt_carry_days.Checked = true;
                        opt_carry_all.Checked = false;
                        txt_carry_maximumdays.Visible = true;
                        txt_carry_maximumdays.Text = ds.Tables[0].Rows[0]["carryforward_maximum_days"].ToString();
                    }
                    else
                    {
                        opt_carry_all.Checked = true;
                        opt_carry_days.Checked = false;
                        txt_carry_maximumdays.Visible = false;

                    }
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["accumulated_days"]) != 0.0)
                    {
                        opt_accumulation_days.Checked = true;
                        opt_accumulation_all.Checked = false;
                        txt_max_accumulation.Visible = true;
                        txt_min_accumulation.Visible = false;
                        txt_max_accumulation.Text = ds.Tables[0].Rows[0]["accumulated_days"].ToString();
                        txt_min_accumulation.Text = ds.Tables[0].Rows[0]["min_accumulated_days"].ToString();
                    }
                    else
                    {
                        opt_accumulation_all.Checked = true;
                        opt_accumulation_days.Checked = false;
                        txt_max_accumulation.Visible = false;
                        txt_min_accumulation.Visible = false;
                    }
                }
                else
                {
                    opt_carryforward_yes.Checked = false;
                    opt_carryforward_no.Checked = true;
                    opt_carry_all.Enabled = false;
                    opt_carry_days.Enabled = false;
                    opt_accumulation_all.Enabled = false;
                    opt_accumulation_days.Enabled = false;
                    txt_carry_maximumdays.Visible = false;
                    txt_max_accumulation.Visible = false;
                    txt_min_accumulation.Visible = false;
                    //rd_encash_app_yes.Checked = false;
                    //rd_encash_app_no.Checked = true;

                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["encash_applicable"]) == true)
                {
                    rd_encash_app_yes.Checked = true;
                    rd_encash_app_no.Checked = false;
                    txt_how_many.Enabled = true;
                    txt_EncashLimit.Text = ds.Tables[0].Rows[0]["encash_days_limt"].ToString();
                }
                else
                {
                    rd_encash_app_yes.Checked = false;
                    rd_encash_app_no.Checked = true;
                    txt_EncashLimit.Enabled = false;
                    txt_EncashLimit.Text = "0.00";
                }

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["backdate_leave_applicable"]) == true)
                {
                    opt_backdate_yes.Checked = true;
                    opt_backdate_no.Checked = false;
                    txt_how_many.Enabled = true;
                    txt_how_many.Text = ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();
                }
                else
                {
                    opt_backdate_no.Checked = true;
                    opt_backdate_yes.Checked = false;
                    txt_how_many.Enabled = false;
                }


                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["document_required"]) == true)
                {
                    opt_document_yes.Checked = true;
                    txt_excess_days.Enabled = true;
                    opt_document_no.Checked = false;
                }
                else
                {
                    opt_document_no.Checked = true;
                    txt_excess_days.Enabled = false;
                    opt_document_yes.Checked = false;

                }


                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leave_modification"]) == true)
                {
                    opt_extension_yes.Checked = true;
                }
                else
                {
                    opt_extension_no.Checked = true;
                }


                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["holidays_counted_asleave"]) == true)
                {
                    opt_holidays_yes.Checked = true;
                }
                else
                {
                    opt_holidays_no.Checked = true;
                }


                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["halfday_leave_applicable"]) == true)
                {
                    //opt_halfday_leave.Checked = true;
                }
                else
                {
                    opt_halfday_no.Checked = true;
                }

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["is_protata"]) == true)
                {
                    rdprorata_yes.Checked = true;
                    rdprorata_no.Checked = false;

                }
                else
                {
                    rdprorata_no.Checked = true;
                    rdprorata_yes.Checked = false;

                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["is_nextyearapplicable"]) == true)
                {
                    //rd_workdays_no.Checked = false;
                    rd_next_year_yes.Checked = true;
                    rd_next_year_no.Checked = false;
                }
                else if (Convert.ToBoolean(ds.Tables[0].Rows[0]["is_nextyearapplicable"]) == false)

                {
                    //rd_workdays_no.Checked = true;
                    rd_next_year_yes.Checked = false;
                    rd_next_year_no.Checked = true;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["monthly_leave_applicable"]) == true)
                {
                    rd_month_leave_applicable_yes.Checked = true;
                    rd_month_leave_applicable_no.Checked = false;
                    txt_mon_max_days.Enabled = true;
                    txt_mon_max_nooftimes.Enabled = true;
                }
                else
                {
                    rd_month_leave_applicable_yes.Checked = false;
                    rd_month_leave_applicable_no.Checked = true;
                    txt_mon_max_days.Enabled = false;
                    txt_mon_max_nooftimes.Enabled = false;
                }
                
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["encash_applicable"]) == true)
                {

                    txt_EncashLimit.Enabled = true;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["encash_applicable"]) == false)
                {

                    txt_EncashLimit.Enabled = false;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["weekly_off"]) == true)
                {
                    opt_weekly_yes.Checked = true;
                }
                else
                {
                    opt_weekly_no.Checked = true;
                }



                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["entitle_applicable"]) == true)
                {
                    rd_Entitled_yes.Checked = true;
                }
                else
                {
                    rd_Entitled_no.Checked = true;
                }

                //if (Convert.ToBoolean(ds.Tables[0].Rows[0][""]) == true)
                //{

                //}
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        Session["leavetypess"] = ds;


    }
    protected void BindEmpStatus()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = @"select applicable_emp_status  from tbl_leave_createdefaultrule_emp_status where policyid=" + hidden_policyid.Value + " and leaveid=" + hidden_leaveid.Value + "";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row1 in ds.Tables[0].Rows)
                {
                    string gradename = row1["applicable_emp_status"].ToString().Trim();
                    chkempstatus.Items.FindByValue(gradename).Selected = true;
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
    protected void BindEmployeeStatus(int companyId)
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "SELECT id,employeestatus FROM tbl_intranet_employee_status";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row1 in ds.Tables[0].Rows)
                {
                    string gradename = row1["employeestatus"].ToString().Trim();
                    chkempstatus.Items.Add(new ListItem(Convert.ToString(gradename), row1["id"].ToString(), true));
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
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        int pre;
        int post;

        try
        {
            if (postdelivery.Text != "")
            {
                post = Convert.ToInt32(postdelivery.Text);
            }
            else
            {
                post = 0;
            }
            if (predelivery.Text != "")
            {
                pre = Convert.ToInt32(predelivery.Text);
            }
            else
            {
                pre = 0;
            }

            if (opt_carryforward_no.Checked)
            {
                a = 0.0;
                b = 0.0;
            }
            else
            {
                if (opt_carry_all.Checked)
                {
                    a = 0.0;
                }
                else
                    a = Convert.ToDouble(txt_carry_maximumdays.Text);
                if (opt_accumulation_all.Checked)
                {
                    b = 0.0;
                    d = 0.0;
                }
                else
                {
                    d = Convert.ToDouble(txt_min_accumulation.Text);
                    b = Convert.ToDouble(txt_max_accumulation.Text);
                }
            }
            if (opt_backdate_no.Checked)
            {
                c = 0;
            }
            else
            {
                c = Convert.ToInt32(txt_how_many.Text);
            }

            string gender = "";
            //----------------------------------------For Gender-----------------------------------------------
            if (chkMale.Checked == true && chkFemale.Checked == true)
            {
                gender = "A";
            }
            else if (chkMale.Checked == true)
            {
                gender = "M";
            }
            else if (chkFemale.Checked == true)
            {
                gender = "F";
            }
            else
            {
                Output.Show("Please select the Applicable to Gender");
                return;
            }

            //----------------------------------------For Metarial Status-----------------------------------------------
            string metarialstatus = "";

            if (chkmarried.Checked == true && chkunmarried.Checked == true)
            {
                metarialstatus = "A";
            }
            else if (chkmarried.Checked == true)
            {
                metarialstatus = "M";
            }
            else if (chkunmarried.Checked == true)
            {
                metarialstatus = "U";
            }
            else
            {
                Output.Show("Please select the Applicable to Metarial Status");
                return;
            }

            if (rd_Entitled_yes.Checked == true)
            {
                txt_entitled.Enabled = true;
            }
            else
            {
                txt_entitled.Enabled = false;
                txt_entitled.Text = "0";
            }

            bool work_days = false;
            if (rd_workdays_yes.Checked == true)
            {
                work_days = true;
            }
            int flag = 0;

            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();

            string sqlstr1 = "delete from tbl_leave_createdefaultrule_emp_status where policyid=" + hidden_policyid.Value + " and leaveid=" + hidden_leaveid.Value +"";
            flag += SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1);
            if (txt_EncashLimit.Text.ToString() == "")
            {
                txt_EncashLimit.Text = "0.00";
            }
            string sqlstr = "Update tbl_leave_createdefaultrule set predelivery='" + pre + "', postdelivery='" + post + "', document_days='" + txt_excess_days.Text + "',isworking_days='" + work_days + "',working_days='" + txt_working_days.Text + "',applicable_to_marital='" + metarialstatus + "',applicable_to='" + gender + "',entitle_applicable='" + rd_Entitled_yes.Checked + "' ,days_before_leaveapply='" + Convert.ToInt32(txt_days_before_leave.Text) + "',minimum_no_days='" + (txt_minimum.Text) + "',entitled_days='" + Convert.ToDecimal(txt_entitled.Text) + "',maximum_no_days='" + (txt_maximum.Text) + "',backdate_howmany_days='" + c + "',carryforward_maximum_days ='" + a + "', backdate_leave_applicable='" + opt_backdate_yes.Checked + "' , document_required ='" + opt_document_yes.Checked + "',holidays_counted_asleave='" + opt_holidays_yes.Checked + "',carryforward_applicable='" + opt_carryforward_yes.Checked + "',leave_modification='" + opt_extension_yes.Checked + "',halfday_leave_applicable='" + opt_halfdays_yes.Checked + "',accumulated_days='" + b + "',weekly_off='" + opt_weekly_yes.Checked + "',modifiedby='" + Session["name"].ToString().Trim().ToString().Replace("'", "''") + "',esi_applicable='" + rd_Esi_Applicable_yes.Checked.ToString() + "',esi_cutoff_amount='" + txt_salary.Text + "',is_last_year_working_days='" + rd_last_year_work_days_yes.Checked.ToString() + "',last_year_working_days='" + txt_last_year_working_days.Text + "',is_protata='" + rdprorata_yes.Checked.ToString() + "',is_nextyearapplicable='" + rd_next_year_yes.Checked.ToString() + "',min_accumulated_days='" + d.ToString() + "',monthly_leave_applicable='" + rd_month_leave_applicable_yes.Checked.ToString() + "',monthly_leave_max_noofdays='" + txt_mon_max_days.Text.ToString() + "',monthly_leave_max_nooftimes='" + txt_mon_max_nooftimes.Text.ToString() + "',encash_applicable='" + rd_encash_app_yes.Checked.ToString() + "',encash_days_limt= case when encash_days_limt=null then '0' else '" + txt_EncashLimit.Text.ToString() + "' end  ,Monthly_proce='" + RadMonthly_yes.Checked + "',Monthly_Days='" + txt_month_days.Text.ToString() + "' ,accum_Check='" + opt_accumulation_all.Checked + "',Carry_Check='" + opt_carry_all.Checked + "' where id=" + Request.QueryString["id"] + "";
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);


            for (int k = 0; k < chkempstatus.Items.Count; k++)
            {
                if (chkempstatus.Items[k].Selected == true)
                {
                    SqlParameter[] parm1;
                    parm1 = new SqlParameter[3];
                    Output.AssignParameter(parm1, 0, "@policyid", "Int", 10, hidden_policyid.Value);
                    Output.AssignParameter(parm1, 1, "@leaveid", "Int", 0, hidden_leaveid.Value);
                    Output.AssignParameter(parm1, 2, "@applicable_emp_status", "Int", 0, chkempstatus.Items[k].Value.Trim());
                    flag += SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_setempstatus", parm1);
                }

            }

            transaction.Commit();

        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        RegisterStartupScript("df", "<script language='javascript'>window.close()</script>");
        // Response.Redirect("<script language='javascript'><a href='overviewrule.aspx?updated=null' target='name123'>asdasdafddsf</a></script>;");

        Response.Redirect("EditLeaveRule.aspx?updated=true");
    }
    protected void btnrst_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditLeaveRule.aspx");
    }

    protected void enable_ddhowdays()
    {
        if (opt_backdate_no.Checked)
        {
            txt_how_many.Enabled = false;
            //txt_days_before_leave.Enabled = true;
        }
        else
        {
            txt_how_many.Enabled = true;
            //txt_days_before_leave.Text = "0";
            //txt_days_before_leave.Enabled = false;

        }
    }

    protected void opt_backdate_no_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }
    protected void opt_backdate_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }

    protected void enable_carryforward()
    {
        if (opt_carryforward_no.Checked)
        {
            opt_carry_all.Enabled = false;
            opt_carry_days.Enabled = false;
            opt_accumulation_all.Enabled = false;
            opt_accumulation_days.Enabled = false;
            txt_max_accumulation.Visible = false;
            txt_min_accumulation.Visible = false;
            txt_carry_maximumdays.Visible = false;



        }
        else
        {
            opt_carry_all.Enabled = true;
            opt_carry_days.Enabled = true;
            opt_accumulation_days.Enabled = true;
            opt_accumulation_all.Enabled = true;

            if (opt_carry_all.Checked)
            {
                txt_carry_maximumdays.Visible = false;

            }
            else
            {
                txt_carry_maximumdays.Visible = true;

            }
            if (opt_accumulation_all.Checked)
            {
                txt_max_accumulation.Visible = false;
                txt_min_accumulation.Visible = false;

            }
            else
            {
                txt_max_accumulation.Visible = true;
                txt_min_accumulation.Visible = false;
            }

        }
    }

    protected void opt_carry_all_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
    protected void opt_carry_days_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
   

    protected void accumulation_days()
    {
        if (opt_accumulation_all.Checked)
        {
            txt_max_accumulation.Visible = false;
            txt_min_accumulation.Visible = false;
        }
        else
        {
            txt_max_accumulation.Visible = true;
            txt_min_accumulation.Visible = false;
        }
    }

    protected void opt_accumulation_all_CheckedChanged(object sender, EventArgs e)
    {
        accumulation_days();
    }
    protected void opt_accumulation_days_CheckedChanged(object sender, EventArgs e)
    {
        accumulation_days();
    }


    protected void opt_holidays_yes_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void opt_holidays_no_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void opt_carryforward_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
    protected void opt_carryforward_no_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }

    protected void opt_document_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_excess_days.Enabled = true;
    }
    protected void opt_document_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_excess_days.Enabled = false;
    }
    protected void rd_workdays_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_working_days.Enabled = true;
    }
    protected void rd_workdays_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_working_days.Enabled = false;
    }



    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkempstatus.Items.Count; i++)
        {
            chkempstatus.Items[i].Selected = true;
        }
    }

    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkempstatus.Items.Count; i++)
        {
            chkempstatus.Items[i].Selected = false;
        }
    }
    //protected void bindemployeestatus()
    //{
    //    sqlstr = "SELECT id,employeestatus FROM tbl_intranet_employee_status";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow row1 in ds.Tables[0].Rows)
    //        {
    //            string gradename = row1["employeestatus"].ToString().Trim();
    //            chkempstatus.Items.Add(new ListItem(Convert.ToString(gradename), row1["id"].ToString(), true));
    //        }
    //    }


    //}

    protected void rd_Entitled_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_entitled.Enabled = true;
    }
    protected void rd_Entitled_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_entitled.Enabled = false;

    }
    protected void rd_last_year_work_days_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_last_year_working_days.Enabled = true;
    }

    protected void rd_last_year_work_days_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_last_year_working_days.Enabled = false;
    }

    protected void rd_Esi_Applicable_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_salary.Enabled = true;
    }

    protected void rd_Esi_Applicable_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_salary.Enabled = false;
    }
    protected void rd_month_leave_applicable_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_mon_max_days.Enabled = true;
        txt_mon_max_nooftimes.Enabled = true;
    }

    protected void rd_month_leave_applicable_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_mon_max_days.Enabled = false;
        txt_mon_max_nooftimes.Enabled = false;
    }
    protected void txt_days_before_leave_TextChanged(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(txt_days_before_leave.Text) > 0)
        //{
        //    opt_backdate_no.Checked = true;
        //    txt_how_many.Enabled = false;
        //}
        //else
        //{
        //    opt_backdate_yes.Checked = true;
        //    txt_how_many.Enabled = true;
        //}
    }
    protected void rd_encash_app_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_EncashLimit.Enabled = true;
        txt_EncashLimit.Text = "0.00";
    }

    protected void rd_encash_app_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_EncashLimit.Enabled = false;
        txt_EncashLimit.Text = "0.00";
    }
    protected void rd_workdays_yes_CheckedChanged1(object sender, EventArgs e)
    {
        txt_working_days.Enabled = true;

    }
    protected void rd_last_year_work_days_no_CheckedChanged1(object sender, EventArgs e)
    {
        txt_working_days.Enabled = false;
    }
    protected void predelivery_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(postdelivery.Text) && !string.IsNullOrEmpty(predelivery.Text))
            txt_entitled.Text = (Convert.ToInt32(postdelivery.Text) + Convert.ToInt32(predelivery.Text)).ToString();
    }

    //protected void clear()
    //{
    //    txt_min_accumulation.Text = "0";
    //    txt_max_accumulation.Text = "0";
    //    txt_carry_maximumdays.Text = "0";
    //    txt_days_before_leave.Text = "0";
    //    txt_entitled.Text = "0";
    //    txt_how_many.Text = "0";
    //    txt_maximum.Text = "0";
    //    txt_minimum.Text = "0";
    //    //dd_policy.SelectedIndex = 0;
    //    //ddleave.SelectedIndex = 0;
    //    opt_carryforward_yes.Checked = true;
    //    opt_carryforward_no.Checked = false;
    //    opt_accumulation_all.Checked = true;
    //    opt_accumulation_days.Checked = false;
    //    opt_backdate_yes.Checked = true;
    //    opt_backdate_no.Checked = false;
    //    opt_carry_all.Checked = true;
    //    opt_carry_days.Checked = false;
    //    opt_document_yes.Checked = true;
    //    //   RadioButton6.Checked = false;
    //    opt_backdate_no.Checked = false;
    //    opt_halfdays_yes.Checked = true;
    //    opt_halfday_no.Checked = false;
    //    opt_holidays_yes.Checked = true;
    //    opt_holidays_no.Checked = false;
    //    //opt_modification_yes.Checked = true;
    //    //opt_modification_no.Checked = false;
    //    opt_weekly_yes.Checked = true;
    //    opt_weekly_no.Checked = false;
    //    rd_Entitled_yes.Checked = true;
    //    rd_Entitled_no.Checked = false;
    //    txt_entitled.Text = "0";
    //    txt_entitled.Enabled = true;
    //    rd_workdays_yes.Checked = true;
    //    rd_workdays_no.Checked = false;
    //    txt_working_days.Text = "0";
    //    txt_working_days.Enabled = true;
    //    txt_excess_days.Text = "0";
    //    txt_excess_days.Enabled = true;
    //    opt_document_yes.Checked = true;
    //    opt_document_no.Checked = false;
    //    rd_last_year_work_days_yes.Checked = true;
    //    rd_last_year_work_days_no.Checked = false;
    //    txt_last_year_working_days.Enabled = true;
    //    txt_last_year_working_days.Text = "0";
    //    rd_Esi_Applicable_yes.Checked = true;
    //    rd_Esi_Applicable_no.Checked = false;
    //    txt_salary.Enabled = true;
    //    txt_salary.Text = "0";
    //    txt_min_accumulation.Text = "0";
    //    txt_max_accumulation.Text = "0";
    //    txt_days_before_leave.Enabled = true;
    //    txt_EncashLimit.Enabled = true;
    //    txt_EncashLimit.Text = "0.0";
    //    rd_encash_app_yes.Checked = true;
    //    //  lnkuncheckall_Click();
    //    chkmarried.Checked = false;
    //    chkunmarried.Checked = false;
    //    enable_carryforward();
    //    enable_ddhowdays();
    //    for (int i = 0; i < chkempstatus.Items.Count; i++)
    //    {
    //        chkempstatus.Items[i].Selected = false;
    //    }
    //}

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("editleaverule.aspx");
    }
    protected void RadMonthly_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_monthly();
    }
    protected void RadMonthly_no_CheckedChanged(object sender, EventArgs e)
    {
        enable_monthly();
      
    }
    protected void enable_monthly()
    {
        if (RadMonthly_no.Checked)
        {
            txt_month_days.Enabled = false;
            txt_entitled.Enabled = true;
            txt_entitled.Text = "0";
            txt_month_days.Text = "0";
        }
        else
        {
         
            txt_month_days.Enabled = true;
            txt_entitled.Enabled = false;
            txt_entitled.Text = "0";
            txt_month_days.Text = "0";
        }
    }
    protected void postdelivery_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(postdelivery.Text) && !string.IsNullOrEmpty(predelivery.Text))
            txt_entitled.Text = (Convert.ToInt32(postdelivery.Text) + Convert.ToInt32(predelivery.Text)).ToString();
    }
}

