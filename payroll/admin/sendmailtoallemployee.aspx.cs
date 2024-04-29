using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Web;
using System.Web.Mail;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using NumberToEnglish;
public partial class payroll_admin_sendmailtoallemployee : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_ddlCCgroup();
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            bind_year();
            bind_month();
        }
    }
    protected void bind_ddlCCgroup()
    {
        sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddl_cc_groupid.DataSource = ds;
        ddl_cc_groupid.DataTextField = "cost_center_group_name";
        ddl_cc_groupid.DataValueField = "id";
        ddl_cc_groupid.DataBind();
        ddl_cc_groupid.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void ddl_cc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_cc_code.Items.Clear();
        //   ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_cc_groupid.SelectedValue != "0")
            bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));

    }
    protected void bind_cc_code(int accgroupid)
    {
        sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddl_cc_code.DataSource = ds;
        ddl_cc_code.DataTextField = "cost_center_code";
        ddl_cc_code.DataValueField = "id";
        ddl_cc_code.DataBind();
        ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void ddl_cc_code_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void bind_month()
    {
        sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds;
        dd_month.DataBind();
    }

    protected void bind_year()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[9];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text;

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[4].Value = 0;

        sqlparam[5] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[5].Value = dd_month.SelectedItem.Text.ToString();
        //sqlparam[5].Value = dd_month.SelectedItem.Text.ToString();

        sqlparam[6] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[6].Value = dd_year.SelectedItem.Text.ToString();

        sqlparam[7] = new SqlParameter("@costcentergroup", SqlDbType.VarChar, 100);
        sqlparam[7].Value = ddl_cc_groupid.SelectedValue;

        sqlparam[8] = new SqlParameter("@costcentercode", SqlDbType.Int);
        sqlparam[8].Value = ddl_cc_code.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_emp_detail", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
        bindempdetail();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < empgrid.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)empgrid.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                checkg.Checked = true;
            }
        }
    }

    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < empgrid.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)empgrid.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                checkg.Checked = false;
            }
        }
    }

    protected void sendmail()
    {
        try
        {
            int counter = 0;
            foreach (GridViewRow GridView in empgrid.Rows)
            {
                CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

                if (checkg.Checked)
                {
                    string strempcode, strmonth, stryear, mailto, mailbody;
                    strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;
                    strmonth = dd_month.SelectedItem.Text;
                    stryear = dd_year.SelectedItem.Text;

                    sqlstr = "SELECT official_email_id FROM tbl_intranet_employee_jobDetails WHERE empcode='" + strempcode.Trim().ToString() + "' and official_email_id is not null";
                    DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                    if (ds5.Tables[0].Rows.Count > 0)
                    {
                        mailto = ds5.Tables[0].Rows[0]["official_email_id"].ToString().Trim();
                        if (mailto.Trim() != "")
                        {
                            SqlParameter[] sqlparam;
                            sqlparam = new SqlParameter[3];
                            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                            sqlparam[0].Value = strempcode;
                            sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
                            //sqlparam[1].Value = a.ToString("MMM");
                            sqlparam[1].Value = strmonth;

                            sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
                            sqlparam[2].Value = stryear;

                            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "payroll_payslip_emp", sqlparam);
                            ds.Tables[0].TableName = "payslip_emp";

                            DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_deduction", sqlparam);
                            ds1.Tables[0].TableName = "payslip_emp_deduction";

                            DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_earning", sqlparam);
                            ds2.Tables[0].TableName = "payslip_emp_earning";

                            DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_tot_earning_deduction", sqlparam);
                            ds3.Tables[0].TableName = "payslip_emp_tot_earning_deduction";

                            DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fetch_companydetail");
                            ds4.Tables[0].TableName = "companydetail";

                            NumberToEnglish.NumberToEnglish abc = new NumberToEnglish.NumberToEnglish();

                            abc.changeCurrencyToWords(Convert.ToDouble(ds.Tables[1].Rows[0]["ntotal"].ToString()));

                            MailMessage mail = new MailMessage();
                            mailbody = "";
                            mail.From = ConfigurationManager.AppSettings["fromEmail"].ToString();
                            mail.To = mailto;
                            mail.Subject = "Payslip for month of " + strmonth + " " + stryear;
                            mail.BodyFormat = MailFormat.Text;
                            mail.Body = "Please find attached Payslip for month of " + strmonth + " " + stryear;

                            mailbody = @"
                        <html>
                        <head>
                        <style type='text/css'>
                        body { margin:0; padding:10px; font: 11px Arial, Helvetica, sans-serif; color: #333;}

                        .blue-bg {
                            background: #08486d; color: #fff; padding: 5px 10px; font: bold 11px Tahoma, Helvetica, sans-serif;
                        }
                        .text {
                        padding: 3px 20px 2px 10px; font: normal 11px Arial, Helvetica, sans-serif; color:#013366;
                        }
			            .txt-un {
 			            font: bold 14px Arial, Helvetica, sans-serif; color:#08486d; padding: 6px 0;
			            }
			            .txt-red {
			             font: bold 11px verdana, Helvetica, sans-serif; color:#990000;
			            }
			            .bm-lne {
			            border-bottom: 1px solid #e7f1ff; padding: 5px 0 5px 0px; font: normal 11px Arial, Helvetica, sans-serif; color:#013366;
			            }
                        .txtbold { font: bold 11px Arial, Helvetica, sans-serif; color:#000; 
			            }
                        .line-right {
                         border-left:1px solid #08486d; border-bottom: 1px solid #08486d;
                        }
                        .line-left {
                         border-bottom: 1px solid #08486d;
                        }
                         hr {
                         height:1px;
                        }
                        .blue-bg1 {
                         background: #1a638d; color: #fff; padding: 0 3px; font: normal 11px Tahoma, Helvetica, sans-serif;
                        }
                        </style>
                        </head>
                        <body>
                        <table width='80%' border='0' cellspacing='0' cellpadding='0'>
                        <tr>
					    <td align='center' class='blue-bg'>Trimedx India Pvt. Ltd.</td>
				        </tr>
                        <tr>
                        <td align='center' valign='top' class='txt-un'>Payslip for Month of " + strmonth + " " + ds.Tables[1].Rows[0]["year"].ToString();

                            mailbody = mailbody + @"</td>
                        </tr>
                        <tr><td align='center' class='txt-red'>" + ds.Tables[0].Rows[0]["name"].ToString();

                            mailbody = mailbody + @"</td></tr>
                    <tr>
                    <td class='text' valign='top'>
                        <table width='100%' border='0' cellspacing='0' cellpadding='3'>
                        <tr>
                        <td width='14%' class='bm-lne'><strong>Employee Code</strong></td>
                        <td width='2%' class='bm-lne'>:</td>
                        <td width='17%' class='bm-lne'>" + ds.Tables[0].Rows[0]["empcode"].ToString();
                            mailbody = mailbody + @"</td>
                        <td width='14%' class='bm-lne'><strong>Designation</strong></td>
                        <td width='2%' class='bm-lne'>:</td>
                        <td width='17%' class='bm-lne'>" + ds.Tables[0].Rows[0]["designationname"].ToString();
                            mailbody = mailbody + @"</td>
                        <td width='14%' class='bm-lne'><strong>Date of Joining</strong></td>
                        <td width='2%' class='bm-lne'>:</td>
                        <td width='17%' class='bm-lne'>" + ds.Tables[0].Rows[0]["emp_doj"].ToString();
                            mailbody = mailbody + @"</td>
                        </tr>
                        <tr>
                        <td class='bm-lne'><strong>Grade</strong></td>
                        <td class='bm-lne'>:</td>
                        <td class='bm-lne'>" + ds.Tables[0].Rows[0]["gradename"].ToString();
                            mailbody = mailbody + @"</td>
                        <td class='bm-lne'><strong>Department</strong></td>
                        <td class='bm-lne'>:</td>
                        <td class='bm-lne'>" + ds.Tables[0].Rows[0]["department_name"].ToString();
                            mailbody = mailbody + @"</td>
                        <td class='bm-lne'><strong>Branch</strong></td>
                        <td class='bm-lne'>:</td>
                        <td class='bm-lne'>" + ds.Tables[0].Rows[0]["branch_name"].ToString();
                            mailbody = mailbody + @"</td>
                        </tr>
                        <tr>
                        <td class='bm-lne'><strong>Payment Mode</strong></td>
                        <td class='bm-lne'>:</td>
                        <td class='bm-lne'>" + ds.Tables[0].Rows[0]["paymentmode"].ToString();
                            mailbody = mailbody + @"</td>
                        <td class='bm-lne'><strong>Bank Name</strong></td>
                        <td class='bm-lne'>:</td>
                        <td class='bm-lne'>" + ds.Tables[0].Rows[0]["bank_name"].ToString();
                            mailbody = mailbody + @"</td>

                        <td class='bm-lne'><strong>A/C No</strong></td>
                        <td class='bm-lne'>:</td>
                        <td class='bm-lne'>" + ds.Tables[0].Rows[0]["ac_number"].ToString();
                            mailbody = mailbody + @"</td>
                    </tr>

                    <tr>
								<td class='bm-lne'>&nbsp;</td>
								<td class='bm-lne'>&nbsp;</td>
								<td class='bm-lne'>&nbsp;</td>
								<td class='bm-lne'>&nbsp;</td>
                                <td class='bm-lne'>&nbsp;</td>
                                <td class='bm-lne'>&nbsp;</td>
                                <td class='bm-lne'>&nbsp;</td>

								<td class='bm-lne' align='right' colspan='2'>
								<table width='100%' border='0' cellspacing='0' cellpadding='0'>
									<tr>
										<td class='bm-lne'>LWP</td>
										<td class='bm-lne'>" + ds.Tables[1].Rows[0]["LWP"].ToString();

                            mailbody = mailbody + @"</td>
										<td class='bm-lne'>Total Days</td>
										<td class='bm-lne'>" + ds.Tables[1].Rows[0]["working_days"].ToString();

                            mailbody = mailbody + @"</td>
									</tr>
								</table>
								</td>   
                    </tr> 
                    </table>
                    </td>
                    </tr>
                    <tr>
                    <td align='center' class='text'>
                    <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tr>
                    <td valign='top' width='50%' >
                    <table width='100%' border='0' cellspacing='0' cellpadding='0' bordercolor='#000' style='border-collapse:collapse;'>
                    <tr>
                    <td colspan='2' class='blue-bg'>Earnings</td>
                    </tr>";

                            for (int e = 0; e < ds2.Tables[0].Rows.Count; e++)
                            {
                                mailbody = mailbody + @"
                        <tr>
                        <td class='text'>" + ds2.Tables[0].Rows[e]["payhead"].ToString();
                                mailbody = mailbody + @"</td><td align='right' class='text'>" + ds2.Tables[0].Rows[e]["amount"].ToString();

                                mailbody = mailbody + @"</td>
                        </tr>";
                            }
                            mailbody = mailbody + @"
                        </table>
                        </td>

                        <td valign='top' width='50%' >
                        <table width='100%' border='0' cellspacing='0' cellpadding='0' bordercolor='#000' style='border-collapse:collapse;'>
                        <tr>
                        <td colspan='2' class='blue-bg'>Deductions</td>
                        </tr>";
                            for (int d = 0; d < ds1.Tables[0].Rows.Count; d++)
                            {
                                mailbody = mailbody + @"
                        <tr>
                        <td class='text'>" + ds1.Tables[0].Rows[d]["payhead"].ToString();
                                mailbody = mailbody + @"</td><td align='right' class='text'>" + ds1.Tables[0].Rows[d]["amount"].ToString();

                                mailbody = mailbody + @"</td>
                        </tr>";
                            }
                            mailbody = mailbody + @"            
                    </table>
                    </td>
                    </tr>

<tr>
                      <td colspan='2'><HR color='#08486d'></td>
                    </tr>
                    <tr><td class='text'>
                    <table width='100%' border='0' cellspacing='0' cellpadding='0' bordercolor='#000' style='border-collapse:collapse;'>
                    <tr>
                    <td colspan='2' class='txtbold'>Total Earning</td>
                    <td align='right' class='txtbold'>" + ds3.Tables[0].Rows[0]["GTOTAL"].ToString();
                            mailbody = mailbody + @"</td></tr></table></td><td class='text'>
                        <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                        <tr>
                        <td colspan='2' class='txtbold'>Total Deduction</td>
                        <td align='right' class='txtbold'>" + ds3.Tables[0].Rows[0]["DTOTAL"].ToString();
                            mailbody = mailbody + @"</td></tr></table></td></tr>
<tr>
                    <td colspan='2' height='10'><HR color='#08486d'></td>
                     </tr>
                    <tr>
<td class='text'><table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    
                    <tr>
                    <td class='txtbold'>Net Amount</td>
                    <td class='txtbold' align='right'>" + ds3.Tables[0].Rows[0]["NTOTAL"].ToString();
                            mailbody = mailbody + @"</td>
</tr>
<tr>
    <td colspan='2'>
        <table width='100%' border='1' cellpadding='3' cellspacing='0'  style='border-collapse:collapse; border-color:#08486d;'>
            <tr class='bdr'>
                <td class='txtbold'><strong>G. Total</strong></td>
                <td class='text'>" + ds.Tables[1].Rows[0]["gtotal"].ToString();
                            mailbody = mailbody + @" </td>
                <td class='txtbold'><strong>G. Deduction</strong></td>
                <td class='text'>" + ds.Tables[1].Rows[0]["dtotal"].ToString();
                            mailbody = mailbody + @"</td>
                <td class='txtbold'><strong>Tot Reimbursement</strong></td>
                <td class='text'>" + ds.Tables[1].Rows[0]["REIMNTOTAL"].ToString();
                            mailbody = mailbody + @"</td>
            </tr>
            
        </table>
    </td>
</tr>
<tr><td colspan='2'>&nbsp;</td></tr>
<tr><td colspan='2' class='text'>Issued By GA & HR</td></tr>
<tr><td colspan='2' class='text'><b>Net Salary In Words :</b>" + abc.changeCurrencyToWords(Convert.ToDouble(ds.Tables[1].Rows[0]["ntotal"].ToString()));
                            mailbody = mailbody + @" </td></tr>
</table></td>

</tr>
</table></td>
 </tr>
 </table>
</body>
</html>";

                            System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(".") + "/upload/salaryslip.html");

                            sw.WriteLine(mailbody);

                            sw.Close();
                            MailAttachment attachMail = new MailAttachment(Server.MapPath(".") + "/upload/salaryslip.html");
                            mail.Attachments.Add(attachMail);
                            //SmtpMail.SmtpServer = "localhost";
                            SmtpMail.SmtpServer = ConfigurationManager.AppSettings["smtp"].ToString();
                            SmtpMail.Send(mail);
                        }
                    }
                }
                counter = counter + 1;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        sendmail();
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        chktowhomsend();
    }
    protected void chktowhomsend()
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked)
            {
                string strempcode, strmonth, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;
                strmonth = dd_month.SelectedItem.Text;
                stryear = dd_year.SelectedItem.Text;


                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlparam[0].Value = strempcode;
                sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
                //sqlparam[1].Value = a.ToString("MMM");
                sqlparam[1].Value = strmonth;

                sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
                sqlparam[2].Value = stryear;

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "generate_payslip_printing", sqlparam);
                ds.Tables[0].TableName = "payslip_emp";

                DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_deduction", sqlparam);
                ds1.Tables[0].TableName = "payslip_emp_deduction";

                DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_earning", sqlparam);
                ds2.Tables[0].TableName = "payslip_emp_earning";

                DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_tot_earning_deduction", sqlparam);
                ds3.Tables[0].TableName = "payslip_emp_tot_earning_deduction";

                DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fetch_companydetail");
                ds4.Tables[0].TableName = "companydetail";

                CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.HasCrystalLogo = false;

                ReportDocument myReportDocument = new ReportDocument();
                myReportDocument.Load(Server.MapPath(".") + "\\reports\\payslip.rpt");
                myReportDocument.SetDataSource(ds.Tables["payslip_emp"]);

                myReportDocument.OpenSubreport("payslip_emp_deduction.rpt").SetDataSource(ds1.Tables["payslip_emp_deduction"]);
                myReportDocument.OpenSubreport("payslip_emp_earning.rpt").SetDataSource(ds2.Tables["payslip_emp_earning"]);
                myReportDocument.OpenSubreport("payslip_total_earn_deduction.rpt").SetDataSource(ds3.Tables["payslip_emp_tot_earning_deduction"]);
                myReportDocument.OpenSubreport("payslip_company.rpt").SetDataSource(ds4.Tables["companydetail"]);
                myReportDocument.SetParameterValue("month", strmonth);
                myReportDocument.SetParameterValue("year", stryear);
                //CrystalReportViewer1.ReportSource = myReportDocument;
                //CrystalReportViewer1.DataBind();
                //System.Drawing.Printing.PrinterSettings printerSetting = new System.Drawing.Printing.PrinterSettings();
                //if (printerSetting.PrinterName == "Default printer is not set.")
                //{
                //  Response.Write("<script language='javascript'>alert('Default printer is not set.')</script>");
                //}
                //else
                //{
                // Response.Write("<script language='javascript'>alert('Default printer:'" + printerSetting.PrinterName + "')</script>");
                //myReportDocument.PrintOptions.PrinterName = printerSetting.PrinterName;
                //myReportDocument.PrintOptions.PrinterName = "HP PSC 1400 series";
                try
                {
                    myReportDocument.PrintOptions.PrinterName = DropDownList1.SelectedValue;
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('NO PRINTER FOUND')</script>");
                    return;
                }
                //System.Drawing.Printing.PrinterSettings.InstalledPrinters;

                myReportDocument.PrintToPrinter(1, false, 1, 1);
                myReportDocument.Close();
                //}
            }
            counter = counter + 1;
        }
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("Select Printer", "0"));
    }
}