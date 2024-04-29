using Common.Console;
using System;
using System.Data;
using System.Data.SqlClient;


public partial class leave_viewleaverule : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId;
    SqlConnection _connection;
    string sqlstr = "";
    Common.Data.DataActivity Activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindLeaveRule(Convert.ToInt32(_companyId));               
            }
            else { Response.Redirect("~/notlogged.aspx"); }
        }
    }
    protected void BindLeaveRule(int companyId)
    {
        try
        {
            _connection = Activity.OpenConnection();
            var parm = new SqlParameter[1];
            Output.AssignParameter(parm, 0, "@id", "Int", 10, Request.QueryString["id"].ToString());
            ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.StoredProcedure, "sp_leave_viewrule", parm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_policy_name.Text = ds.Tables[0].Rows[0]["policyname"].ToString();
                lbl_backdate_apply.Text = ds.Tables[0].Rows[0]["backdate_leave_applicable1"].ToString();
                lbl_doc_required.Text = ds.Tables[0].Rows[0]["document_required1"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["carryforward_applicable1"].ToString();
                Label4.Text = ds.Tables[0].Rows[0]["holidays_counted_asleave1"].ToString();
                lbl_modification.Text = ds.Tables[0].Rows[0]["leave_modification1"].ToString();
                lbl_halfdays_leave.Text = ds.Tables[0].Rows[0]["halfday_leave_applicable1"].ToString();
                lblleave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
                lbl_days_before_leave.Text = ds.Tables[0].Rows[0]["days_before_leaveapply"].ToString();
                lbl_entitled_days.Text = ds.Tables[0].Rows[0]["entitled_days"].ToString();
                lbl_backdate_days.Text = ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();
                lbl_minimum_days.Text = ds.Tables[0].Rows[0]["minimum_no_days"].ToString();
                lbl_carryforward.Text = ds.Tables[0].Rows[0]["carryforward_maximum_days"].ToString();
                lbl_entitled_maxdays.Text = ds.Tables[0].Rows[0]["maximum_no_days"].ToString();
                lbl_weekly.Text = ds.Tables[0].Rows[0]["weekly_off1"].ToString();
                lbl_accumulation_days.Text = ds.Tables[0].Rows[0]["accumulated_days"].ToString();
                lbl_min_accumulation_days.Text = ds.Tables[0].Rows[0]["min_accumulated_days"].ToString();
                string gender = ds.Tables[0].Rows[0]["applicable_to"].ToString();

                lbl_entitled_required.Text = ds.Tables[0].Rows[0]["entitle_applicable1"].ToString();
                lbl_doc_required_days.Text = ds.Tables[0].Rows[0]["document_days"].ToString();
                //   lbl_matrrialstatus.Text = ds.Tables[0].Rows[0]["applicable_to_marital"].ToString();
                lbl_workingdays_required.Text = ds.Tables[0].Rows[0]["isworking_days1"].ToString();
                lbl_workingdays.Text = ds.Tables[0].Rows[0]["working_days"].ToString();
                lbl_lastwrk_day.Text = ds.Tables[0].Rows[0]["is_last_year_working_days"].ToString();
                lbl_last_work_days.Text = ds.Tables[0].Rows[0]["last_year_working_days"].ToString();
                lbl_esi_app.Text = ds.Tables[0].Rows[0]["esi_applicable"].ToString();
                lbl_esi_cut_days.Text = ds.Tables[0].Rows[0]["esi_cutoff_amount"].ToString();
                lblprorata.Text = ds.Tables[0].Rows[0]["is_protata"].ToString();
                lbl_last_year.Text = ds.Tables[0].Rows[0]["is_nextyearapplicable"].ToString();
                lbl_mon_applicable.Text = ds.Tables[0].Rows[0]["monthly_leave_applicable"].ToString();
                lbl_mon_applicable_max_days.Text = ds.Tables[0].Rows[0]["monthly_leave_max_noofdays"].ToString();
                lbl_mon_applicable_max_nooftimes.Text = ds.Tables[0].Rows[0]["monthly_leave_max_nooftimes"].ToString();
                lblencashapplicable.Text = ds.Tables[0].Rows[0]["encash_applicable"].ToString();
                lblencashdays.Text = ds.Tables[0].Rows[0]["encash_days_limt"].ToString();
                lbl_post.Text = ds.Tables[0].Rows[0]["postdelivery"].ToString();
                lbl_pre.Text = ds.Tables[0].Rows[0]["predelivery"].ToString();
                label_processmonth.Text= ds.Tables[0].Rows[0]["Monthly_proce"].ToString();
                label_processmonth_days.Text = ds.Tables[0].Rows[0]["Monthly_Days"].ToString();
                if (gender == "M")
                {
                    lbl_genderapplicable.Text = "Male";
                }
                else if (gender == "F")
                {
                    lbl_genderapplicable.Text = "Female";
                }
                else if (gender == "A")
                {
                    lbl_genderapplicable.Text = "Both";
                }


                if (ds.Tables[0].Rows[0]["applicable_to_marital"].ToString() == "M")
                {
                    lbl_matrrialstatus.Text = "Married";
                }
                else if (ds.Tables[0].Rows[0]["applicable_to_marital"].ToString() == "U")
                {
                    lbl_matrrialstatus.Text = "UnMarried";
                }

                else if (ds.Tables[0].Rows[0]["applicable_to_marital"].ToString() == "A")
                {
                    lbl_matrrialstatus.Text = "Both";
                }

                if (ds.Tables[0].Rows[0]["leavetype"].ToString() == "Earned Leave")
                {
                    entitleid.Visible = true;
                    lbl_entitled_days.Visible = true;
                    postid.Visible = false;
                   // preid.Visible = false;
                    lbl_post.Visible = false;
                    lbl_pre.Visible = false;
                }

                if (ds.Tables[0].Rows[0]["leavetype"].ToString() == "Maternity Leave")
                {
                    entitleid.Visible = true;
                    postid.Visible = true;
                   // preid.Visible = true;
                    lbl_post.Visible = true;
                    lbl_pre.Visible = true;
                    lbl_entitled_days.Visible = true;
                }


                var parm1 = new SqlParameter[2];
                Output.AssignParameter(parm1, 0, "@policyid", "Int", 10, ds.Tables[0].Rows[0]["policyid"].ToString());
                Output.AssignParameter(parm1, 1, "@leaveid", "Int", 10, ds.Tables[0].Rows[0]["leaveid"].ToString());
                DataSet ds1 = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.StoredProcedure, "sp_leave_getempstatus", parm1);


                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    int empstatus = Convert.ToInt32(ds1.Tables[0].Rows[i]["applicable_emp_status"].ToString());
                    string sqlempstatus = @"SELECT id,employeestatus FROM tbl_intranet_employee_status where id=" + empstatus + "";
                    DataSet dsStatus = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, sqlempstatus);
                    if (dsStatus.Tables[0].Rows.Count > 0)
                    {
                        lbl1.Text += dsStatus.Tables[0].Rows[0]["employeestatus"] + "</br>";
                    }
                }

              
               
            }


        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
    }
}
