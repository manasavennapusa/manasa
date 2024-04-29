using Common.Console;
using Common.Encode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class payroll_admin_PerqItStatement : System.Web.UI.Page
{
    string CompanyId, UserCode, RoleId;
    string strempcode, strmonth, stryear;
    int cont = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
        }
        else Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {

        }

        QueryString q = new QueryString();
        strempcode = (q["empcode"] != null) ? q["empcode"] : "0";
        strmonth = (q["month"] != null) ? q["month"] : "0";
        stryear = (q["year"] != null) ? q["year"] : "0";

        if (EmployeeExists(strempcode.Trim()))
        {
            GenerateITStatement(stryear, strmonth, GetMonthId(strmonth), strempcode);
        }
        else
        {
            Common.Console.Output.Show("Employee does not exists or you do not have permission to access this employee. Please contact system admin.");
        }
    }

    private bool EmployeeExists(string empcode)
    {
        Common.Data.DataActivity DA = new Common.Data.DataActivity();
        SqlConnection Connection = null;
        Connection = DA.OpenConnection();
        DA.CloseConnection();
        string query = @"select E.empcode
 from tbl_intranet_employee_jobDetails E
  where  empcode = '" + empcode + "'";

        DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

        DA.CloseConnection();
        if (ds.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }

    private int GetMonthId(string Month)
    {
        if (Month == "Apr") return 1;
        if (Month == "May") return 2;
        if (Month == "Jun") return 3;
        if (Month == "Jul") return 4;
        if (Month == "Aug") return 5;
        if (Month == "Sep") return 6;
        if (Month == "Oct") return 7;
        if (Month == "Nov") return 8;
        if (Month == "Dec") return 9;
        if (Month == "Jan") return 10;
        if (Month == "Feb") return 11;
        if (Month == "Mar") return 12;

        return 0;
    }

    private int MonthRemaining(string Month)
    {
        if (Month == "Apr") return 12;
        if (Month == "May") return 11;
        if (Month == "Jun") return 10;
        if (Month == "Jul") return 9;
        if (Month == "Aug") return 8;
        if (Month == "Sep") return 7;
        if (Month == "Oct") return 6;
        if (Month == "Nov") return 5;
        if (Month == "Dec") return 4;
        if (Month == "Jan") return 3;
        if (Month == "Feb") return 2;
        if (Month == "Mar") return 1;

        return 0;
    }

    private string GetMonthName(int MonthId)
    {
        if (MonthId == 1) return "Apr";
        if (MonthId == 2) return "May";
        if (MonthId == 3) return "Jun";
        if (MonthId == 4) return "Jul";
        if (MonthId == 5) return "Aug";
        if (MonthId == 6) return "Sep";
        if (MonthId == 7) return "Oct";
        if (MonthId == 8) return "Nov";
        if (MonthId == 9) return "Dec";
        if (MonthId == 10) return "Jan";
        if (MonthId == 11) return "Feb";
        if (MonthId == 12) return "Mar";

        return "";
    }

    private void GenerateITStatement(string FYear, string Month, int MonthId, string EmpCode)
    {


        SqlConnection Connection = null;
        Common.Data.DataActivity DA = new Common.Data.DataActivity();
        string Query = "";
        DataSet Ds = null;

        int[] PayMonth = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        decimal[] TotEar = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        decimal[] ToDed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        try
        {
            Connection = DA.OpenConnection();

            string Heading = "<p class='head'>Perquisite statement for the financial year " + FYear + "<p>";
            string SubHeading = "<p class='head'>Payroll for the month of " + Month + "<p><br/>";

            string EmpInfo = "<p>" + GetEmployeeInfo(Connection, EmpCode) + "</p><br/>";
            // Distinct earning component id

            Query = @"select distinct SD.PAYHEADID ,SD.PAYHEAD
                           from tbl_payroll_employee_salary S 
                           inner join tbl_payroll_employee_salarydetail SD on S.SALARYID = SD.SALARYID
                           inner join tbl_payroll_payhead H on SD.PAYHEADID = H.id
                           where S.YEAR='" + FYear + "' and S.EMPCODE = '" + EmpCode + "' and S.STATUS = 1 and H.payhead_type = 1 and SD.PAYHEADID in (61) order by SD.PAYHEADID";

            Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);
            if (Ds.Tables.Count >0)
            {
                if (Ds.Tables[0].Rows.Count < 1)
                {
                    Output.Show("Perquisite not yet created");
                    return;
                }
            }
            

            decimal PayHeadYear = 0;
            string PayHeadValue = "0.0";

            string A = "<p>A) <b>Taxable Income</b></p><table>";

            A = A + "<tr>   <td class='head'>Earning Components</td>    <td class='head'>Apr</td>   <td class='head'>May</td>   <td class='head'>Jun</td>   <td class='head'>Jul</td>  <td class='head'>Aug</td>    <td class='head'>Sep</td>    <td class='head'>Oct</td>   <td class='head'>Nov</td>   <td class='head'>Dec</td>    <td class='head'>Jan</td>    <td class='head'>Feb</td>    <td class='head'>Mar</td>   <td class='head'>Total</td>   </tr>";

            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                A = A + "<tr>";
                A = A + "<td>" + Row["PAYHEAD"] + "</td>";

                for (int m = 0; m < PayMonth.Length; m++)
                {
                    if (PayMonth[m] <= MonthId)
                    {
                        PayHeadValue = GetComponentAmount(Connection, Row["PAYHEADID"].ToString(), EmpCode, FYear, GetMonthName(PayMonth[m]), MonthId);
                        PayHeadYear = PayHeadYear + Convert.ToDecimal(PayHeadValue);
                        TotEar[m] = TotEar[m] + Convert.ToDecimal(PayHeadValue);

                        A = A + "<td class='cellvalue'>" + PayHeadValue + "</td>";

                    }
                    else
                    {
                        string NextMonthExpectedAmount = GetExpectedAmount(Connection, Row["PAYHEADID"].ToString(), EmpCode, FYear, GetMonthName(PayMonth[m - 1]));

                        for (int e = MonthId + 1; e <= PayMonth.Length; e++)
                        {
                            PayHeadYear = PayHeadYear + Convert.ToDecimal(NextMonthExpectedAmount);
                            TotEar[e - 1] = TotEar[e - 1] + Convert.ToDecimal(NextMonthExpectedAmount);

                            A = A + "<td class='cellvalue'>" + NextMonthExpectedAmount + "</td>";
                        }

                        break;
                    }
                }

                A = A + "<td class='cellvalue'>" + PayHeadYear + "</td>";
                PayHeadYear = 0;
                A = A + "</tr>";


            }

            decimal TotalEarning = 0;

            A = A + "<tr style='display:None'><td>Total</td>";

            for (int a = 0; a < TotEar.Length; a++)
            {
                TotalEarning = TotalEarning + TotEar[a];

                A = A + "<td class='cellvalue'>" + TotEar[a] + "</td>";
            }
            A = A + "<td class='cellvalue'>" + TotalEarning + "</td>";
            A = A + "</tr>";

            A = A + "</table>";

            Session["TotalEarning"] = TotalEarning;

            // Distinct deduction component id

            Query = @"select distinct SD.PAYHEADID ,SD.PAYHEAD
                           from tbl_payroll_employee_salary S 
                           inner join tbl_payroll_employee_salarydetail SD on S.SALARYID = SD.SALARYID
                           inner join tbl_payroll_payhead H on SD.PAYHEADID = 61
                           where S.YEAR='" + FYear + "' and S.EMPCODE = '" + EmpCode + "' and S.STATUS = 1 and SD.HEAD_TYPE = 1 order by SD.PAYHEADID";

            Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

            string B = "<p>B) <b>Other Components</b></p><table>";
            B = B + "<tr><td class='head'>Deduction Components</td><td class='head'>Apr</td><td class='head'>May</td><td class='head'>Jun</td><td class='head'>Jul</td><td class='head'>Aug</td><td class='head'>Sep</td><td class='head'>Oct</td><td class='head'>Nov</td><td class='head'>Dec</td><td class='head'>Jan</td><td class='head'>Feb</td><td class='head'>Mar</td><td class='head'>Total</td></tr>";
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                B = B + "<tr>";
                B = B + "<td>" + Row["PAYHEAD"] + "</td>";

                for (int m = 0; m < PayMonth.Length; m++)
                {
                    if (PayMonth[m] <= MonthId)
                    {
                        PayHeadValue = GetComponentAmount2(Connection, Row["PAYHEADID"].ToString(), EmpCode, FYear, GetMonthName(PayMonth[m]));

                        PayHeadYear = PayHeadYear + Convert.ToDecimal(PayHeadValue);
                        ToDed[m] = ToDed[m] + Convert.ToDecimal(PayHeadValue);
                        B = B + "<td class='cellvalue'>" + PayHeadValue + "</td>";
                    }
                    else
                    {
                        string NextMonthExpectedAmount = GetExpectedDeductionAmount(Connection, Row["PAYHEADID"].ToString(), EmpCode, FYear, GetMonthName(PayMonth[m - 1]));

                        for (int e = MonthId + 1; e <= PayMonth.Length; e++)
                        {
                            PayHeadYear = PayHeadYear + Convert.ToDecimal(NextMonthExpectedAmount);

                            ViewState["Deduction"] = PayHeadYear;
                            B = B + "<td class='cellvalue'>" + NextMonthExpectedAmount + "</td>";
                        }

                        break;
                    }
                }

                B = B + "<td class='cellvalue'>" + PayHeadYear + "</td>";
                PayHeadYear = 0;

                B = B + "</tr>";
            }
            //decimal TotalDeduction = 0;

            //B = B + "<tr><td>Total</td>";

            //for (int a = 0; a < ToDed.Length; a++)
            //{
            //    TotalEarning = TotalDeduction + ToDed[a];

            //    B = B + "<td class='cellvalue'>" + ToDed[a] + "</td>";
            //}
            //B = B + "<td class='cellvalue'>" + TotalDeduction + "</td>";
            //B = B + "</tr>";
            B = B + "</table>";


            string TotalGross = "<p style='display:None'> Sub Total(A): " + GetTotalGrossPerYear(Connection, EmpCode, FYear, Month) + "</p>";
            string Perquisite = "<p style='display:None'>C) <b>Perquisites</b></p><p style='text-align:left;display:None'>Sub Total(C): " + GetPerquisite(Connection, EmpCode, FYear, Month) + "</p>";
            decimal res;
                res= Convert.ToDecimal(Convert.ToDecimal(GetTotalGrossPerYear(Connection, EmpCode, FYear, Month)) - Convert.ToDecimal(ViewState["Deduction"].ToString()));
                string tot = "<p>C) <b>Balance</b></p><p style='text-align:left;'>Balance(C):" + res + "</p>";
            //string PreviousEmployement = IncomeFromPreviousEmployer(Connection, EmpCode, FYear, Month);
            //string OtherIncome = "<p>E) <b>Any other income declared by the employee</b></p><p style='text-align:left;'> " + AnyOtherIncome(Connection, EmpCode, FYear, Month) + "</p>";

            //string _GrossTotalIncome = "<p>F) <b>Gross Total Income: (A + C + D + E)</b> " + GrossTotalIncome(Connection, EmpCode, FYear, Month) + "</p>";

            //string LessExemptionUnderSection = LessExemptionUnderSection10(Connection, EmpCode, FYear, Month);

            //string PT16 = "<p>H) <b>Less deduction u/s 16</b></p><p style='text-align:left;'>Tax on employment: " + GetUS16(Connection, EmpCode, FYear, Month) + "</p>";
            //string Less6A = LessExemptionUnderSectiion6A(Connection, EmpCode, FYear, Month);

            //string _TotalDeduction = "<p>J) <b>Total Deduction: (G + H + I)</b> " + TotalDeduction(Connection, EmpCode, FYear, Month) + "</p>";
            //string _TaxableAmount = "<p>K) <b>Taxable Amount:</b> " + TaxableAmount(Connection, EmpCode, FYear, Month) + "</p>";
            //string _RoundToNearest10 = "<p>M) <b>Round off to nearest 10 rupee:</b> " + RoundToNearest10(Connection, EmpCode, FYear, Month) + "</p>";
            //string _Tax = "<p>N) <b>Raw Tax:</b> " + Tax(Connection, EmpCode, FYear, Month) + "</p>";
            //string _RebateUS87 = "<p>O) <b>Rebate u/s 87:</b> " + RebateUS87(Connection, EmpCode, FYear, Month) + "</p>";
            //string _Surcharge = "<p>P) <b>Surcharge:</b> " + Surcharge(Connection, EmpCode, FYear, Month) + "</p>";
            //string _EducationCess = "<p>Q) <b>Education Cess:</b> " + EducationCess(Connection, EmpCode, FYear, Month) + "</p>";
            //string _TotalTax = "<p>R) <b>Total Tax:</b> " + TotalTax(Connection, EmpCode, FYear, Month) + "</p>";
            //string _TotalTaxTillPaid = "<p>S) <b>Total Tax Till Paid:</b> " + TotalTaxTillPaid(Connection, EmpCode, FYear, Month) + "</p>";
            //string _MonthRemaining = "<p>T) <b>Remaining Month:</b> " + MonthRemaining(Month) + "</p>";
            //string _TDS = "<p>U) <b>Tax: ( R - S ) / T</b> " + TDS(Connection, EmpCode, FYear, Month) + "</p>";

            Result.InnerHtml = Heading + SubHeading + EmpInfo + A + "<br/>" + TotalGross + "<br/>" + B + "<br/>" + Perquisite + "<br/>"+tot+ "<br/>" ;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DA.CloseConnection();
        }

    }

    private string GetComponentAmount(SqlConnection Connection, string CId, string EmpCode, string FYear, string Month,int MonthId)
    {
        //int K=0;


    //    if (cont ==0)
    //    {
    //        string Query1 = @"select distinct top(1) Id,MONTH from tbl_payroll_employee_salarydetail  where PAYHEADID=61 and EMPCODE = '" + EmpCode + "' order by ID desc";
    //        DataSet Ds2 = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query1);
    //        if (Ds2.Tables.Count > 0)
    //        {
    //            if (Ds2.Tables[0].Rows.Count > 0)
    //            {
    //                 K = GetMonthId(Ds2.Tables[0].Rows[0]["MONTH"].ToString());
    //            }

    //        }
    //    }
    //    int Last = GetMonthId(Month);
    //    if (Last <= K)
    //    {
        string amnt = GetComponentAmount2(Connection, "61", EmpCode, FYear, Month);

        if (Convert.ToDecimal(amnt) > Convert.ToDecimal(0.0))
        {
            string Query = @"select Distinct amount as AMOUNT from tbl_payroll_employee_perquisite where empcode = '" + EmpCode + "' ";

            DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (Ds.Tables[0].Rows[0]["AMOUNT"].ToString() != "")
                {
                    return Ds.Tables[0].Rows[0]["AMOUNT"].ToString();
                }
                else
                {
                    return "0.00";
                }
            }
            else
                return "0.00";
        }
        else
            return "0.00";

    }
    private string GetComponentAmount2(SqlConnection Connection, string CId, string EmpCode, string FYear, string Month)
    {
        string Query = @"select SD.AMOUNT
                              from tbl_payroll_employee_salary S 
                              inner join tbl_payroll_employee_salarydetail SD on S.SALARYID = SD.SALARYID
                              inner join tbl_payroll_payhead H on SD.PAYHEADID = H.id
                              where S.YEAR='" + FYear + "' and S.EMPCODE = '" + EmpCode + "' and S.STATUS = 1   and S.MONTH = '" + Month + "' and SD.PAYHEADID = 61";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
        {
            if (Ds.Tables[0].Rows[0]["AMOUNT"].ToString() != "")
            {
                return Ds.Tables[0].Rows[0]["AMOUNT"].ToString();
            }
            else
            {
                return "0.00";
            }
        }
        else
            return "0.00";

    }

    private string GetExpectedAmount(SqlConnection Connection, string CId, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and subsection = '" + CId + "'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";

    }

    private string GetExpectedDeductionAmount(SqlConnection Connection, string CId, string EmpCode, string FYear, string Month)
    {

        // R NEXT MONTH PF
        // S NEXT MONTH VPF

        if (CId == "3")
            CId = "R";
        else if (CId == "26")
            CId = "S";


        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = '" + CId + "'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
        {
            if (Ds.Tables[0].Rows[0]["amount"].ToString() != "")
            {
                return Ds.Tables[0].Rows[0]["amount"].ToString();
            }
            else
            {
                return "0.00";
            }
        }
        else
            return "0.00";

    }

    private string GetTotalGrossPerYear(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AB'";


        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Session["TotalEarning"].ToString();
        else
            return Session["TotalEarning"].ToString();
    }

    private string GetPerquisite(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select distinct sum(sd.AMOUNT) as amount
from tbl_payroll_employee_salary S 
inner join tbl_payroll_employee_salarydetail SD on S.SALARYID = SD.SALARYID
inner join tbl_payroll_payhead H on SD.PAYHEADID = H.id
where S.YEAR='" + FYear + "' and S.EMPCODE = '" + EmpCode + "' and S.STATUS = 1 and SD.PAYHEADID = 61 group by sd.AMOUNT";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);
        if (Ds.Tables[0].Rows.Count > 0)
        {
            if (Ds.Tables[0].Rows[0]["amount"].ToString() != "")
            {
                Session["Perquisites"] = Ds.Tables[0].Rows[0]["amount"].ToString();
            }
            else
            {
                Session["Perquisites"] = "0.00";
            }
        }
        else
            Session["Perquisites"] = "0.00";

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string LessExemptionUnderSection10(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select *
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxtype = 'C'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        string S10 = "<p>G) <b>Less exemption under section 10</b></p><table>";

        S10 = S10 + "<tr><td class='head'>Section 10 Name</td><td class='head'>Exemption Limit If Any</td></tr>";
        foreach (DataRow Row in Ds.Tables[0].Rows)
        {
            S10 = S10 + "<tr>";

            if (Row["section"].ToString().Trim() == "LESS EXEMPTION UNDER SECTION 10")
            {
                S10 = S10 + "<td>" + Row["subsection"] + "</td>";
                S10 = S10 + "<td class='cellvalue'>" + Row["exemptamount"] + "</td>";
                //S10 = S10 + "<td class='cellvalue'>" + Row["qualifyamount"] + "</td>";
            }
            else
            {
                S10 = S10 + "<td>" + Row["section"] + "</td>";
                S10 = S10 + "<td class='cellvalue'>" + Row["exemptamount"] + "</td>";
                //S10 = S10 + "<td class='cellvalue'>" + Row["qualifyamount"] + "</td>";
            }

            S10 = S10 + "</tr>";
        }

        S10 = S10 + "</table>";

        return S10;

    }

//    private string IncomeFromPreviousEmployer(SqlConnection Connection, string EmpCode, string FYear, string Month)
//    {
//        string Query = @"select *
//                             from dbo.tbl_payroll_tax_calculation
//                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxtype = 'U'";

//        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

//        string S10 = "<p>D) <b>Income from previous employer</b></p><table>";

//        S10 = S10 + "<tr><td class='head'>Pay Item</td><td class='head'>Amount</td></tr>";

//        foreach (DataRow Row in Ds.Tables[0].Rows)
//        {
//            S10 = S10 + "<tr>";
//            S10 = S10 + "<td>" + Row["section"] + "</td>";
//            S10 = S10 + "<td class='cellvalue'>" + Row["qualifyamount"] + "</td>";
//            S10 = S10 + "</tr>";
//        }

//        S10 = S10 + "</table>";

//        return S10;
//    }

    private string LessExemptionUnderSectiion6A(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select *
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxtype = 'H'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        string S10 = "<p>I) <b>Less deduction under section VIA</b></p><table>";

        S10 = S10 + "<tr><td class='head'>Section</td><td class='head'>Investment</td><td class='head'>Gross</td><td class='head'>Exemption Limit If Any</td></tr>";
        foreach (DataRow Row in Ds.Tables[0].Rows)
        {
            S10 = S10 + "<tr>";

            S10 = S10 + "<td>" + Row["section"] + "</td>";
            S10 = S10 + "<td>" + Row["subsection"] + "</td>";
            S10 = S10 + "<td class='cellvalue'>" + Row["amount"] + "</td>";
            S10 = S10 + "<td class='cellvalue'>" + Row["exemptamount"] + "</td>";
            //S10 = S10 + "<td class='cellvalue'>" + Row["qualifyamount"] + "</td>";

            S10 = S10 + "</tr>";
        }

        S10 = S10 + "</table>";

        return S10;

    }

    private string GetUS16(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'R'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string AnyOtherIncome(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AP'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string TaxableAmount(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAI'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string RoundToNearest10(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAJ'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string Tax(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAK'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string RebateUS87(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAL'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string Surcharge(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAM'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string EducationCess(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAN'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string TotalTax(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAO'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string TotalTaxTillPaid(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAP'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string TDS(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAR'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string GrossTotalIncome(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAG'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        decimal per = Convert.ToDecimal(Session["Perquisites"]);
        decimal totalE = Convert.ToDecimal(Session["TotalEarning"]);

        string gross_amount = (per + totalE).ToString();

        if (Ds.Tables[0].Rows.Count > 0)
            return gross_amount;
        else
            return gross_amount;
    }

    private string TotalDeduction(SqlConnection Connection, string EmpCode, string FYear, string Month)
    {
        string Query = @"select qualifyamount amount
                             from dbo.tbl_payroll_tax_calculation
                              where empcode = '" + EmpCode + "' and financial_year = '" + FYear + "' and MONTH = '" + Month + "' and taxcode = 'AAH'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        if (Ds.Tables[0].Rows.Count > 0)
            return Ds.Tables[0].Rows[0]["amount"].ToString();
        else
            return "0.00";
    }

    private string GetEmployeeInfo(SqlConnection Connection, string EmpCode)
    {
        string Query = @"select 
                              emp_fname + isnull(emp_m_name,'') + isnull(emp_l_name,'') ename,
                              emp_gender Gender,
                              emp_doj
                               from dbo.tbl_intranet_employee_jobDetails E
                                  where E.empcode = '" + EmpCode + "'";

        DataSet Ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

        string str = "<table>";
        if (Ds.Tables[0].Rows.Count > 0)
        {
            DataRow Row = Ds.Tables[0].Rows[0];

            str = str + "<tr>";
            str = str + "<td><b>Employee Code</b></td>";
            str = str + "<td>" + EmpCode + "</td>";
            str = str + "<tr>";

            str = str + "<tr>";
            str = str + "<td><b>Employee Name</b></td>";
            str = str + "<td>" + Row["ename"] + "</td>";
            str = str + "<tr>";

            str = str + "<tr>";
            str = str + "<td><b>Gender</b></td>";
            str = str + "<td>" + Row["Gender"] + "</td>";
            str = str + "<tr>";

            //str = str + "<tr>";
            //str = str + "<td><b>PAN Number</b></td>";
            //str = str + "<td>" + Row["panno"] + "</td>";
            //str = str + "<tr>";


            str = str + "<tr>";
            str = str + "<td><b>Date of Joining(mm/dd/yyyy)</b></td>";
            if (Row["emp_doj"].ToString() != "")
                str = str + "<td>" + Convert.ToDateTime(Row["emp_doj"]).ToShortDateString() + "</td>";
            else
                str = str + "<td></td>";

            //str = str + "<tr>";

            //str = str + "<tr>";
            //str = str + "<td><b>Date of Birth(mm/dd/yyyy)</b></td>";

            //if (Row["dob"].ToString() != "")
            //    str = str + "<td>" + Convert.ToDateTime(Row["dob"]).ToShortDateString() + "</td>";
            //else
            //    str = str + "<td></td>";

            str = str + "<tr>";
        }

        str = str + "</table>";

        return str;
    }

}