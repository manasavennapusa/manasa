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
    SqlParameter[] sqlparm;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            dd_year.DataBind();
           // bind_year();
        }
    }
   

    protected void bind_year()
    {
        sqlstr = "select distinct year from tbl_payroll_employee_form16detail";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

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

        sqlparam[5] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[5].Value = dd_year.SelectedItem.Text.ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_emp_detail_tdsReports", sqlparam);
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


       protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("Select Printer", "0"));
    }

    protected void btn_16_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked)
            {
                string strempcode,strcmd, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;

                stryear = dd_year.SelectedItem.Text;


                sqlparm = new SqlParameter[1];
                sqlparm[0] = new SqlParameter("@fyear", stryear);
                DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_company_ack_form16", sqlparm);
                ds2.Tables[0].TableName = "Companydetail";

                sqlparm = new SqlParameter[2];
                sqlparm[0] = new SqlParameter("@empcode", strempcode);
                sqlparm[1] = new SqlParameter("@fyear", stryear);

                strcmd = "select * from tbl_payroll_employee_section10_detail where empcode=@empcode and year=@fyear";

                DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_form16", sqlparm);
                ds1.Tables[0].TableName = "Form16";

                DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_crystal_form19EmpDetail", sqlparm);
                ds3.Tables[0].TableName = "EmployeePan";

                DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tds_detail", sqlparm);
                ds4.Tables[0].TableName = "tds_detail";

                DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd, sqlparm);
                ds5.Tables[0].TableName = "section10";

                DataSet ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_80C_detail", sqlparm);
                ds6.Tables[0].TableName = "80C";

                strcmd = "select isnull(sum(total_tax),0.00) from tbl_payroll_employee_tax_deduction_detail where empcode='" + strempcode + "' and financial_year='" + stryear + "'"; 
                decimal taxpaid = Convert.ToDecimal(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd));

                strcmd = "select rempname,fempname,designation,raddress3 from tbl_payroll_tax_payer_detail";
                DataSet ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd);

                DataSet ds9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_form16_ochapter6a", sqlparm);
                ds9.Tables[0].TableName = "sp_payroll_employee_form16_ochapter6a";


                CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.HasCrystalLogo = false;

                ReportDocument myReportDocument = new ReportDocument();
                myReportDocument.Load(Server.MapPath("." + "/reports/Form16.rpt"));

                myReportDocument.SetDataSource(ds1.Tables["Form16"]);
                myReportDocument.OpenSubreport("Form16Company.rpt").SetDataSource(ds2.Tables["Companydetail"]);
                myReportDocument.OpenSubreport("Form16Employee.rpt").SetDataSource(ds3.Tables["EmployeePan"]);
                myReportDocument.OpenSubreport("Form16TaxDeducted.rpt").SetDataSource(ds4.Tables["tds_detail"]);
                myReportDocument.OpenSubreport("Form16-Section10.rpt").SetDataSource(ds5.Tables["section10"]);
                myReportDocument.OpenSubreport("Form16-80C.rpt").SetDataSource(ds6.Tables["80C"]);
                myReportDocument.OpenSubreport("Form16-Ochapter6A.rpt").SetDataSource(ds9.Tables["sp_payroll_employee_form16_ochapter6a"]);
                myReportDocument.SetParameterValue("TAXPAID", taxpaid);
                myReportDocument.SetParameterValue("emp", ds7.Tables[0].Rows[0]["rempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("femp", ds7.Tables[0].Rows[0]["fempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("desg", ds7.Tables[0].Rows[0]["designation"].ToString().ToUpper());
                myReportDocument.SetParameterValue("place", ds7.Tables[0].Rows[0]["raddress3"].ToString().ToUpper());

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
    protected void btn_16D_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked)
            {
                string strempcode, strcmd, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;

                stryear = dd_year.SelectedItem.Text;


                sqlparm = new SqlParameter[1];
                sqlparm[0] = new SqlParameter("@fyear", stryear);
                DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_company_ack_form16", sqlparm);
                ds2.Tables[0].TableName = "Companydetail";

                sqlparm = new SqlParameter[2];
                sqlparm[0] = new SqlParameter("@empcode", strempcode);
                sqlparm[1] = new SqlParameter("@fyear", stryear);

                strcmd = "select * from tbl_payroll_employee_section10_detail where empcode=@empcode and year=@fyear";

                DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_form16", sqlparm);
                ds1.Tables[0].TableName = "Form16";

                DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_crystal_form19EmpDetail", sqlparm);
                ds3.Tables[0].TableName = "EmployeePan";

                DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tds_detail", sqlparm);
                ds4.Tables[0].TableName = "tds_detail";

                DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd, sqlparm);
                ds5.Tables[0].TableName = "section10";

                DataSet ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_80C_detail", sqlparm);
                ds6.Tables[0].TableName = "80C";

                strcmd = "select isnull(sum(total_tax),0.00) from tbl_payroll_employee_tax_deduction_detail where empcode='" + strempcode + "'";
                decimal taxpaid = Convert.ToDecimal(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd));

                strcmd = "select rempname,fempname,designation,raddress3 from tbl_payroll_tax_payer_detail";
                DataSet ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd);

                DataSet ds8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_Form16_Gross_Detail", sqlparm);
                ds8.Tables[0].TableName = "sp_payroll_fetch_Form16_Gross_Detail";

                DataSet ds9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_form16_ochapter6a", sqlparm);
                ds9.Tables[0].TableName = "sp_payroll_employee_form16_ochapter6a";


                CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.HasCrystalLogo = false;

                ReportDocument myReportDocument = new ReportDocument();
                myReportDocument.Load(Server.MapPath("." + "/reports/Form16Detail.rpt"));

                myReportDocument.SetDataSource(ds1.Tables["Form16"]);
                myReportDocument.OpenSubreport("Form16Company.rpt").SetDataSource(ds2.Tables["Companydetail"]);
                myReportDocument.OpenSubreport("Form16Employee.rpt").SetDataSource(ds3.Tables["EmployeePan"]);
                myReportDocument.OpenSubreport("Form16TaxDeducted.rpt").SetDataSource(ds4.Tables["tds_detail"]);
                myReportDocument.OpenSubreport("Form16-Section10.rpt").SetDataSource(ds5.Tables["section10"]);
                myReportDocument.OpenSubreport("Form16-80C.rpt").SetDataSource(ds6.Tables["80C"]);
                myReportDocument.OpenSubreport("Form16-Ochapter6A.rpt").SetDataSource(ds9.Tables["sp_payroll_employee_form16_ochapter6a"]);
                myReportDocument.OpenSubreport("Form16GrossDetail.rpt").SetDataSource(ds8.Tables["sp_payroll_fetch_Form16_Gross_Detail"]);
                // myReportDocument.SetParameterValue("month", strmonth);
                //myReportDocument.SetParameterValue("year", stryear);
                myReportDocument.SetParameterValue("TAXPAID", taxpaid);
                myReportDocument.SetParameterValue("emp", ds7.Tables[0].Rows[0]["rempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("femp", ds7.Tables[0].Rows[0]["fempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("desg", ds7.Tables[0].Rows[0]["designation"].ToString().ToUpper());
                myReportDocument.SetParameterValue("place", ds7.Tables[0].Rows[0]["raddress3"].ToString().ToUpper());
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
    protected void btn_16AA_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked)
            {
                string strempcode, strcmd, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;

                stryear = dd_year.SelectedItem.Text;


                sqlparm = new SqlParameter[1];
                sqlparm[0] = new SqlParameter("@fyear", stryear);
                DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_company_ack_form16", sqlparm);
                ds2.Tables[0].TableName = "Companydetail";

                sqlparm = new SqlParameter[2];
                sqlparm[0] = new SqlParameter("@empcode", strempcode);
                sqlparm[1] = new SqlParameter("@fyear", stryear);

                strcmd = "select * from tbl_payroll_employee_section10_detail where empcode=@empcode and year=@fyear";

                DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_form16", sqlparm);
                ds1.Tables[0].TableName = "Form16";

                DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_crystal_form19EmpDetail", sqlparm);
                ds3.Tables[0].TableName = "EmployeePan";

                DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tds_detail", sqlparm);
                ds4.Tables[0].TableName = "tds_detail";

                DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd, sqlparm);
                ds5.Tables[0].TableName = "section10";

                DataSet ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_80C_detail", sqlparm);
                ds6.Tables[0].TableName = "80C";

                strcmd = "select isnull(sum(total_tax),0.00) from tbl_payroll_employee_tax_deduction_detail where empcode='" + strempcode + "' and financial_year='" + stryear + "'";
                decimal taxpaid = Convert.ToDecimal(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd));

                strcmd = "select rempname,fempname,designation,raddress3 from tbl_payroll_tax_payer_detail";
                DataSet ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd);

                DataSet ds9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_form16_ochapter6a", sqlparm);
                ds9.Tables[0].TableName = "sp_payroll_employee_form16_ochapter6a";


                CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.HasCrystalLogo = false;

                ReportDocument myReportDocument = new ReportDocument();
                myReportDocument.Load(Server.MapPath("." + "/reports/Form16AA.rpt"));
                myReportDocument.SetDataSource(ds1.Tables["Form16"]);

                myReportDocument.OpenSubreport("Form16AACompany.rpt").SetDataSource(ds2.Tables["Companydetail"]);
                myReportDocument.OpenSubreport("Form16AAEmployee.rpt").SetDataSource(ds3.Tables["EmployeePan"]);
                myReportDocument.OpenSubreport("Form16TaxDeducted.rpt").SetDataSource(ds4.Tables["tds_detail"]);
                myReportDocument.OpenSubreport("Form16-Section10.rpt").SetDataSource(ds5.Tables["section10"]);
                myReportDocument.OpenSubreport("Form16-80C.rpt").SetDataSource(ds6.Tables["80C"]);
                myReportDocument.OpenSubreport("Form16-Ochapter6A.rpt").SetDataSource(ds9.Tables["sp_payroll_employee_form16_ochapter6a"]);
                // myReportDocument.SetParameterValue("month", strmonth);
                //myReportDocument.SetParameterValue("year", stryear);
                myReportDocument.SetParameterValue("TAXPAID", taxpaid);
                myReportDocument.SetParameterValue("emp", ds7.Tables[0].Rows[0]["rempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("femp", ds7.Tables[0].Rows[0]["fempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("desg", ds7.Tables[0].Rows[0]["designation"].ToString().ToUpper());
                myReportDocument.SetParameterValue("place", ds7.Tables[0].Rows[0]["raddress3"].ToString().ToUpper());
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
    protected void btn_12BA_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked)
            {
                string strempcode, strcmd, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;

                stryear = dd_year.SelectedItem.Text;

            sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@empcode", strempcode);
            sqlparm[1] = new SqlParameter("@fyear", stryear);

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite_12Ba_sum", sqlparm);
        ds1.Tables[0].TableName = "Form12BA";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite_Form12B", sqlparm);
        ds2.Tables[0].TableName = "Form12BA-perquisite";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;

        ReportDocument myReportDocument = new ReportDocument();

        myReportDocument.Load(Server.MapPath("." + "/reports/Form12BA.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["Form12BA"]);

        myReportDocument.OpenSubreport("form12BA-Perquisite.rpt").SetDataSource(ds2.Tables["Form12BA-perquisite"]);
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
    protected void btn_ack_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked)
            {
                string strempcode, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;

                stryear = dd_year.SelectedItem.Text;

                sqlparm = new SqlParameter[2];
                sqlparm[0] = new SqlParameter("@empcode", strempcode);
                sqlparm[1] = new SqlParameter("@fyear", stryear);
                DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_ITR_Ack", sqlparm);
                ds.Tables[0].TableName = "sp_payroll_generate_ITR_Ack";

                CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.HasCrystalLogo = false;

                ReportDocument myReportDocument = new ReportDocument();
                
                myReportDocument.Load(Server.MapPath("." + "/reports/incometaxdept-acknowledgement.rpt"));
                myReportDocument.SetDataSource(ds.Tables["sp_payroll_generate_ITR_Ack"]);

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
    protected void btn_itr_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked)
            {
                string strempcode, strcmd, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;

                stryear = dd_year.SelectedItem.Text;

                sqlparm = new SqlParameter[2];
                sqlparm[0] = new SqlParameter("@empcode", strempcode);
                sqlparm[1] = new SqlParameter("@fyear", stryear);

                DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_ITR1", sqlparm);
                ds.Tables[0].TableName = "itr1";

                DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tds_detail", sqlparm);
                ds2.Tables[0].TableName = "tds_detail";

                CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.HasCrystalLogo = false;

                ReportDocument myReportDocument = new ReportDocument();
                myReportDocument.Load(Server.MapPath("." + "/reports/income-tax-return.rpt"));
                myReportDocument.SetDataSource(ds.Tables["itr1"]);

                myReportDocument.OpenSubreport("taxpayment.rpt").SetDataSource(ds2.Tables["tds_detail"]);
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
}