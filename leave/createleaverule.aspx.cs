using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;

public partial class leave_createleaverule : System.Web.UI.Page
{
    string _companyId, _userCode, sqlstr;
    DataSet ds = new DataSet();
    public int i;
    public decimal b;
    public decimal c, d;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                //txt_EncashLimit.Enabled = false;
                enable_ddhowdays();
                enable_monthly();
                enable_carryforward();
                carryforwar_days();
                bindemployeestatus(Convert.ToInt32(_companyId));
                BindLeavePolicy(Convert.ToInt32(_companyId));
                BindLeaveType(Convert.ToInt32(_companyId));
                postid.Visible = false;

            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    protected void BindLeavePolicy(int companyId)
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "SELECT [policyid], [policyname] FROM [tbl_leave_createleavepolicy] where status=1 and company_id=" + companyId;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dd_policy.DataSource = ds;
                dd_policy.DataTextField = "policyname";
                dd_policy.DataValueField = "policyid";
                dd_policy.DataBind();
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

    protected void BindLeaveType(int companyId)
    {
       
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr1 = "SELECT leaveid, leavetype FROM tbl_leave_createleave where leaveid!=0 and status=1 and company_id=" + companyId;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddleave.DataSource = ds;
                ddleave.DataTextField = "leavetype";
                ddleave.DataValueField = "leaveid";
                ddleave.DataBind();
            }
            Session["leavetypess"] = ds;
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

    protected void bind_carryforward_checked()
    {

        if (opt_carryforward_yes.Checked && opt_carry_all.Checked)
        {
            b = 0;
        }
        else if (opt_carryforward_yes.Checked && !opt_carry_all.Checked)
        {
            b = Convert.ToDecimal(txt_carry_maximumdays.Text);

        }
        else
        {
            b = 0;
        }
    }
    protected void bind_accumulation_checked()
    {
        if (opt_accumulation_all.Checked)
        {
            c = 0;
            d = 0;
        }
        else
        {
            txt_min_accumulation.Text = "0";
            c = Convert.ToDecimal(txt_min_accumulation.Text);
            d = Convert.ToDecimal(txt_max_accumulation.Text);
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        bind_carryforward_checked();
        bind_accumulation_checked();

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
            Output.Show("Please select the Gender");
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
            Output.Show("Please select the Marital Status");
            return;
        }

        if (getEmpStatus() == 0)
        {
            Output.Show("Please select the Employee status");
            return;
        }


        var parm = new SqlParameter[44];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@leaveid", "String", 10, ddleave.SelectedValue);
            Output.AssignParameter(parm, 1, "@policyid", "String", 0, dd_policy.SelectedValue);
            Output.AssignParameter(parm, 2, "@entitled_days", "Decimal", 0, txt_entitled.Text);
            Output.AssignParameter(parm, 3, "@days_before_leaveapply", "Decimal", 100, txt_days_before_leave.Text);
            Output.AssignParameter(parm, 4, "@minimum_no_days", "Decimal", 100, txt_minimum.Text);

            Output.AssignParameter(parm, 5, "@maximum_no_days", "Decimal", 10, txt_maximum.Text);
            Output.AssignParameter(parm, 6, "@document_required", "String", 0, opt_document_yes.Checked.ToString());
            Output.AssignParameter(parm, 7, "@backdate_leave_applicable", "String", 0, opt_backdate_yes.Checked.ToString());
            Output.AssignParameter(parm, 8, "@backdate_howmany_days", "Decimal", 100, txt_how_many.Text);
            Output.AssignParameter(parm, 9, "@holidays_counted_asleave", "String", 100, opt_holidays_yes.Checked.ToString());

            Output.AssignParameter(parm, 10, "@weekly_off", "String", 10, opt_weekly_yes.Checked.ToString());
            Output.AssignParameter(parm, 11, "@carryforward_applicable", "String", 0, opt_carryforward_yes.Checked.ToString());
            Output.AssignParameter(parm, 12, "@carryforward_maximum_days", "Decimal", 0, b.ToString());
            Output.AssignParameter(parm, 13, "@accumulated_days", "Decimal", 100, d.ToString());
            Output.AssignParameter(parm, 14, "@leave_modification", "String", 100, opt_modification_yes.Checked.ToString());

            Output.AssignParameter(parm, 15, "@createdby", "String", 0, _userCode);
            Output.AssignParameter(parm, 16, "@modifiedby", "String", 100, _userCode);
            Output.AssignParameter(parm, 17, "@halfday_leave_applicable", "String", 100, opt_halfdays_yes.Checked.ToString());
            Output.AssignParameter(parm, 18, "@applicable_to", "String", 100, gender.ToString());
            Output.AssignParameter(parm, 19, "@entitle_applicable", "String", 100, rd_Entitled_yes.Checked.ToString());

            Output.AssignParameter(parm, 20, "@document_days", "Decimal", 0, txt_excess_days.Text);
            Output.AssignParameter(parm, 21, "@isworking_days", "String", 100, rd_workdays_yes.Checked.ToString());
            Output.AssignParameter(parm, 22, "@working_days", "Decimal", 100, txt_working_days.Text);
            Output.AssignParameter(parm, 23, "@applicable_to_marital", "String", 100, metarialstatus.ToString());
            Output.AssignParameter(parm, 24, "@createddate", "DateTime", 100, DateTime.Now.ToString());
            Output.AssignParameter(parm, 25, "@companyid", "Int", 100, _companyId.ToString());
            Output.AssignParameter(parm, 26, "@esiapplicable", "String", 10, rd_Esi_Applicable_yes.Checked.ToString());
            Output.AssignParameter(parm, 27, "@esicutoffamount", "Decimal", 100, txt_salary.Text.ToString());
            Output.AssignParameter(parm, 28, "@islastyearwrkdays", "String", 10, rd_last_year_work_days_yes.Checked.ToString());
            Output.AssignParameter(parm, 29, "@lastyearworking_days", "Decimal", 100, txt_last_year_working_days.Text);
            Output.AssignParameter(parm, 30, "@isprorata", "String", 100, rdprorata_yes.Checked.ToString());
            Output.AssignParameter(parm, 31, "@isnextyear", "String", 100, rd_next_year_yes.Checked.ToString());
            Output.AssignParameter(parm, 32, "@min_accumulated_days", "Decimal", 100, c.ToString());
            Output.AssignParameter(parm, 33, "@monthly_leave_applicable", "String", 100, rd_month_leave_applicable_yes.Checked.ToString());
            Output.AssignParameter(parm, 34, "@monthly_leave_max_noofdays", "Decimal", 100, txt_mon_max_days.Text);
            Output.AssignParameter(parm, 35, "@monthly_leave_max_nooftimes", "Decimal", 100, txt_mon_max_nooftimes.Text);
            Output.AssignParameter(parm, 36, "@encash_applicable", "String", 100, rd_encash_app_yes.Checked.ToString());
            Output.AssignParameter(parm, 37, "@encash_days_limt", "Decimal", 100, txt_EncashLimit.Text);
            Output.AssignParameter(parm, 38, "@postdelivery", "Int",100, postdelivery.Text);
            Output.AssignParameter(parm, 39, "@predelivery", "Int", 100, predelivery.Text);

            Output.AssignParameter(parm, 40, "@accum_Check", "String", 100, opt_accumulation_all.Checked.ToString());
            Output.AssignParameter(parm, 41, "@Carry_Check", "String", 100, opt_carry_all.Checked.ToString());
            Output.AssignParameter(parm, 42, "@Monthly_proce", "String", 100, RadMonthly_yes.Checked.ToString());
            Output.AssignParameter(parm, 43, "@Monthly_Days", "Decimal", 100, txt_month_days.Text);

            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_createdefaultrule", parm);

            for (int k = 0; k < chkempstatus.Items.Count; k++)
            {
                if (chkempstatus.Items[k].Selected == true)
                {
                    SqlParameter[] parm1;
                    parm1 = new SqlParameter[3];
                    Output.AssignParameter(parm1, 0, "@policyid", "Int", 10, dd_policy.SelectedValue);
                    Output.AssignParameter(parm1, 1, "@leaveid", "Int", 0, ddleave.SelectedValue);
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
        if (flag > 0)
        {
            clear();
            Output.Show("Leave rule created successfully");

        }
        else
        {
            Output.Show("Leave rule already exists, try again");
        }
    }

    private int getEmpStatus()
    {
        int flag = 0;
        for (int k = 0; k < chkempstatus.Items.Count; k++)
        {
            if (chkempstatus.Items[k].Selected == true)
            {
                flag++;
            }
        }
        return flag;
    }


    protected void ddleave_DataBound(object sender, EventArgs e)
    {
        ddleave.Items.Insert(0, new ListItem("--Select Leave--", "0"));
    }

    protected void clear()
    {
        txt_min_accumulation.Text = "0";
        txt_max_accumulation.Text = "0";
        txt_carry_maximumdays.Text = "0";
        txt_days_before_leave.Text = "0";
        txt_entitled.Text = "0";
        txt_how_many.Text = "0";
        txt_maximum.Text = "0";
        txt_minimum.Text = "0";
        dd_policy.SelectedIndex = 0;
        ddleave.SelectedIndex = 0;
        opt_carryforward_yes.Checked = true;
        opt_carryforward_no.Checked = false;
        opt_accumulation_all.Checked = true;
        opt_accumulation_days.Checked = false;
        opt_backdate_yes.Checked = true;
        opt_backdate_no.Checked = false;
        opt_carry_all.Checked = true;
        opt_carry_days.Checked = false;
        opt_document_yes.Checked = true;
        //   RadioButton6.Checked = false;
        opt_backdate_no.Checked = false;
        opt_halfdays_yes.Checked = true;
        opt_halfday_no.Checked = false;
        opt_holidays_yes.Checked = true;
        RadioButton2.Checked = false;
        opt_modification_yes.Checked = true;
        opt_modification_no.Checked = false;
        opt_weekly_yes.Checked = true;
        opt_weekly_no.Checked = false;
        rd_Entitled_yes.Checked = true;
        rd_Entitled_no.Checked = false;
        txt_entitled.Text = "0";
        txt_entitled.Enabled = true;
        rd_workdays_yes.Checked = true;
        rd_workdays_no.Checked = false;
        txt_working_days.Text = "0";
        txt_working_days.Enabled = true;
        txt_excess_days.Text = "0";
        txt_excess_days.Enabled = true;
        opt_document_yes.Checked = true;
        opt_document_no.Checked = false;
        rd_last_year_work_days_yes.Checked = true;
        rd_last_year_work_days_no.Checked = false;
        txt_last_year_working_days.Enabled = true;
        txt_last_year_working_days.Text = "0";
        rd_Esi_Applicable_yes.Checked = true;
        rd_Esi_Applicable_no.Checked = false;
        txt_salary.Enabled = true;
        txt_salary.Text = "0";
        txt_min_accumulation.Text = "0";
        txt_max_accumulation.Text = "0";
        txt_days_before_leave.Enabled = true;
        txt_EncashLimit.Enabled = true;
        txt_EncashLimit.Text = "0.0";
        rd_encash_app_yes.Checked = true;   
        //  lnkuncheckall_Click();
        enable_carryforward();
        enable_ddhowdays();
        enable_monthly();
        for (int i = 0; i < chkempstatus.Items.Count; i++)
        {
            chkempstatus.Items[i].Selected = false;
        }
    }

    //--------------------- Code to bind true or false how many days radio button ----------------------------------// 
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
            //txt_days_before_leave.Enabled = true;

        }
    }

    protected void enable_monthly()
    {
        if (RadMonthly_no.Checked)
        {
            txt_month_days.Enabled = false;
            //txt_days_before_leave.Enabled = true;
        }
        else
        {
            txt_month_days.Enabled = true;
            //txt_days_before_leave.Text = "0";
            //txt_days_before_leave.Enabled = true;

        }
    }

    protected void opt_backdate_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        enable_ddhowdays();
    }

    //--------------------- Code to bind true or false carryforward days radio button ----------------------------------// 

    protected void enable_carryforward()
    {
        if (opt_carryforward_no.Checked)
        {

            txt_carry_maximumdays.Visible = false;

            opt_carry_all.Enabled = false;
            opt_carry_days.Enabled = false;
            opt_accumulation_all.Enabled = false;
            opt_accumulation_days.Enabled = false;
            txt_min_accumulation.Visible = false;
            txt_max_accumulation.Visible = false;
            //txt_EncashLimit.Enabled = false;
            //rd_encash_app_yes.Enabled = false;
            //rd_encash_app_no.Enabled = false;
        }
        else
        {
            txt_carry_maximumdays.Visible = true;
            opt_carry_days.Enabled = true;
            opt_carry_all.Enabled = true;
            opt_accumulation_days.Enabled = true;
            opt_accumulation_all.Enabled = true;
            txt_min_accumulation.Visible = false;
            txt_max_accumulation.Visible = true;
            rd_encash_app_yes.Checked = true;
            //txt_EncashLimit.Enabled = true;
            //rd_encash_app_yes.Enabled = true;
            //rd_encash_app_no.Enabled = true;
            carryforwar_days();
            accumulation_days();
        }
    }
    protected void opt_carryforward_yes_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }
    protected void opt_carryforward_no_CheckedChanged(object sender, EventArgs e)
    {
        enable_carryforward();
    }

    protected void dd_policy_DataBound(object sender, EventArgs e)
    {
        dd_policy.Items.Insert(0, new ListItem("--Select Policy--", "0"));
    }

    protected void carryforwar_days()
    {
        if (opt_carry_all.Checked)
        {
            txt_carry_maximumdays.Visible = false;

        }
        else
        {
            txt_carry_maximumdays.Visible = true;
        }
    }

    protected void opt_carry_all_CheckedChanged(object sender, EventArgs e)
    {
        carryforwar_days();
    }

    protected void opt_carry_days_CheckedChanged(object sender, EventArgs e)
    {
        carryforwar_days();
    }
    protected void accumulation_days()
    {
        if (opt_accumulation_all.Checked)
        {
            txt_min_accumulation.Visible = false;
            txt_max_accumulation.Visible = false;

        }
        else
        {
            txt_min_accumulation.Visible = false;
            txt_max_accumulation.Visible = true;
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        clear();
    }

    //--------------------------For Entitled Check days--------------------------------------//
    protected void rd_Entitled_yes_CheckedChanged(object sender, EventArgs e)
    {
        // rd_Entitled_yes.Checked = true;
        txt_entitled.Enabled = true;
        postdelivery.Enabled = true;
        predelivery.Enabled = true;
    }
    protected void rd_Entitled_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_entitled.Enabled = false;
        postdelivery.Enabled = false;
        predelivery.Enabled = false;

    }
    //--------------------------For Document Required Check days--------------------------------------//

    protected void opt_document_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_excess_days.Enabled = true;
    }
    protected void opt_document_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_excess_days.Enabled = false;
    }

    //--------------------------For Working Days Check days--------------------------------------//

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
    protected void bindemployeestatus(int companyId)
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
        if (Convert.ToInt32(txt_days_before_leave.Text) > 0)
        {
            //opt_backdate_no.Enabled = false;
            //opt_backdate_yes.Enabled = true;
            //txt_how_many.Enabled = false;
        }
        else
        {
            //opt_backdate_no.Enabled = true;
            //opt_backdate_yes.Enabled = true;
            //txt_how_many.Enabled = true;
        }
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

    protected void ddleave_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsReport = (DataSet)Session["leavetypess"];
        if (ddleave.SelectedItem.ToString() == "Maternity Leave")
        {
           
            if (rd_Entitled_yes.Checked == true)
            {
                entitledid.Visible = true;
                txt_entitled.ReadOnly=true;
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

    
    protected void predelivery_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(postdelivery.Text) && !string.IsNullOrEmpty(predelivery.Text))
            txt_entitled.Text = (Convert.ToInt32(postdelivery.Text) + Convert.ToInt32(predelivery.Text)).ToString();
    }
    protected void RadMonthly_yes_CheckedChanged(object sender, EventArgs e)
    {
        txt_month_days.Enabled = true;
        txt_entitled.Enabled = false;
        txt_entitled.Text = "0";
    }
    protected void RadMonthly_no_CheckedChanged(object sender, EventArgs e)
    {
        txt_month_days.Enabled = false;
        txt_entitled.Enabled = true;
        txt_entitled.Text = "0";
    }
}
