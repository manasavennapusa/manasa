using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Web;

public partial class payroll_admin_reports_salarysheetnew : System.Web.UI.Page
{
    ArrayList List = new ArrayList();
    public static int PayableDays = 0;
    public static int OTHours = 0;
    public static int BankAccountNo = 0;
    public static int Signature = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string b = Page.Request.QueryString["b"];
        string f = Page.Request.QueryString[1];
        string m = Page.Request.QueryString["m"];

        GetPayHeadDetails();
        GetAllowance(f, m, b);

    }

    public void GetAllowance(string FYear, string Month, string Branch)
    {
        SqlConnection Connection = null;

        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            Connection.Open();

            string queryCompany = @"select * from tbl_intranet_companydetails";

            SqlCommand cmd = new SqlCommand(queryCompany, Connection);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet dsCompany = new DataSet();
            sda.Fill(dsCompany);

            DataRow rowCompany = dsCompany.Tables[0].Rows[0];


            SqlCommand cmd1 = new SqlCommand("sp_payroll_generate_form5_report", Connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@FYear", SqlDbType.VarChar, 50).Value = FYear;
            cmd1.Parameters.Add("@Month", SqlDbType.VarChar, 50).Value = Month;
            cmd1.Parameters.Add("@Branch", SqlDbType.Int).Value = Branch;

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataSet dsCumulative = new DataSet();
            sda1.Fill(dsCumulative);
            Session["payrollsheet"] = dsCumulative;

            if (dsCumulative.Tables[0].Rows.Count > 0)
            {
                DataSet RemovedEmptyColums = RemoveEmptyColums(dsCumulative);
                GvCumulative.DataSource = AddAutoIncrementColumn(RemovedEmptyColums.Tables[0]);
                GvCumulative.DataBind();

                GenerateHeader(RemovedEmptyColums, Month, rowCompany["companyname"].ToString(), FYear, rowCompany["cors_add1"].ToString());

            }
            else
            {
                Common.Console.Output.Show("No records found.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private static DataTable AddAutoIncrementColumn(DataTable dt)
    {
        DataColumn Col = dt.Columns.Add("SlNo", System.Type.GetType("System.Int32"));
        Col.SetOrdinal(0);// to put the column in position 0;
        return dt;
    }

    protected void GvCumulative_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.Cells.Count > 0)
            {
                e.Row.Cells[0].Text = "SL No.";
                e.Row.Cells[1].Text = "Employee Code";
                e.Row.Cells[2].Text = "Employee Name";
                e.Row.Cells[3].Text = "Department";
                e.Row.Cells[4].Text = "Designation";
                e.Row.Cells[5].Text = "DOJ";

                e.Row.Cells[0].Style.Add("background", "yellow");
                e.Row.Cells[1].Style.Add("background", "yellow");
                e.Row.Cells[2].Style.Add("background", "yellow");
                e.Row.Cells[3].Style.Add("background", "yellow");
                e.Row.Cells[4].Style.Add("background", "yellow");
                e.Row.Cells[5].Style.Add("background", "yellow");

                for (int i = 0; i <= 5; i++)
                {
                    e.Row.Cells[i].Style.Add("font-size", "12px");
                    e.Row.Cells[i].Style.Add("color", "#000");
                    e.Row.Cells[i].Style.Add("font-family", "Calibri");
                    e.Row.Cells[i].Style.Add("width", "5px");
                }

                for (int i = 6; i < e.Row.Cells.Count; i++)
                {

                    string text = e.Row.Cells[i].Text;
                    // Changing Heading Names


                    if (text.Trim() == "PSAmount")
                        e.Row.Cells[i].Text = "Gross Fixed Salary";

                    if (text.Trim() == "TotalDeduction")
                        e.Row.Cells[i].Text = "Total Deduction";

                    if (text.Trim() == "NetPay")
                        e.Row.Cells[i].Text = "Net Pay";

                    if (text.Trim() == "BankAccountNo")
                    {
                        BankAccountNo = i;
                        e.Row.Cells[i].Text = "Bank Account No.";
                    }

                    if (text.Trim() == "Signature")
                    {
                        Signature = i;
                        e.Row.Cells[i].Text = "Employee Signature";
                    }

                    if (text.Trim() == "DaysPayable")
                        PayableDays = i;

                    if (text.Trim() == "OTHours")
                        OTHours = i;


                    if (text.Trim() == "FixedAmount")
                        e.Row.Cells[i].Text = "Gross Earning/Wage (A)";

                    if (text.Trim() == "TotalEarnings")
                        e.Row.Cells[i].Text = "Total Earnings";

                    int psindex = text.IndexOf("PSAmount");
                    if (psindex != -1)
                    {
                        string result = text.Replace("PSAmount", "").Trim();
                        try
                        {
                            e.Row.Cells[i].Text = GetPayheadName(Convert.ToInt32(result));
                            e.Row.Cells[i].Style.Add("padding-left", "8px");
                            e.Row.Cells[i].Style.Add("padding-right", "8px");
                            e.Row.Cells[i].Style.Add("font-family", "Book Antiqua");
                            e.Row.Cells[i].Style.Add("background", "rgb(0, 158, 255)");
                            e.Row.Cells[i].Style.Add("color", "#fff");
                        }
                        catch
                        {
                            e.Row.Cells[i].Style.Add("background", "rgb(239, 114, 77)");
                            e.Row.Cells[i].Style.Add("color", "#fff");
                        }
                    }

                    int index = text.IndexOf("Amount");
                    if (index != -1)
                    {
                        string result = text.Replace("Amount", "").Trim();
                        try
                        {
                            e.Row.Cells[i].Text = GetPayheadName(Convert.ToInt32(result));
                            e.Row.Cells[i].Style.Add("padding-left", "8px");
                            e.Row.Cells[i].Style.Add("padding-right", "8px");
                            e.Row.Cells[i].Style.Add("font-family", "Book Antiqua");
                            e.Row.Cells[i].Style.Add("background", "rgb(0, 158, 255)");
                            e.Row.Cells[i].Style.Add("color", "#fff");
                        }
                        catch
                        {
                            e.Row.Cells[i].Style.Add("background", "rgb(239, 114, 77)");
                            e.Row.Cells[i].Style.Add("color", "#fff");
                        }
                    }
                    else
                    {
                        e.Row.Cells[i].Style.Add("background", "rgb(239, 114, 77)");
                        e.Row.Cells[i].Style.Add("color", "#fff");
                    }

                    e.Row.Cells[i].Style.Add("font-size", "12px");
                    e.Row.Cells[i].Style.Add("color", "#000");
                    e.Row.Cells[i].Style.Add("font-family", "Calibri");
                    e.Row.Cells[i].Style.Add("width", "5px");

                }





            }
        }
        else
        {
            if (e.Row.Cells.Count > 0)
            {

                e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();

                if (e.Row.Cells[0].Text == "0")
                {
                    e.Row.Cells[0].Text = "&nbsp;";
                }
                if (e.Row.Cells[1].Text == "0")
                {
                    e.Row.Cells[1].Text = "&nbsp;";
                }
                if (e.Row.Cells[2].Text == "0")
                {
                    e.Row.Cells[2].Text = "&nbsp;";
                }
                if (e.Row.Cells[3].Text == "0")
                {
                    e.Row.Cells[3].Text = "&nbsp;";
                }
                if (e.Row.Cells[4].Text == "0")
                {
                    e.Row.Cells[4].Text = "&nbsp;";
                }
                if (e.Row.Cells[5].Text == "0")
                {
                    e.Row.Cells[5].Text = "&nbsp;";
                }
                for (int i = 0; i <= 5; i++)
                {
                    e.Row.Cells[i].Style.Add("font-size", "12px");
                    e.Row.Cells[i].Style.Add("color", "#000");
                    e.Row.Cells[i].Style.Add("font-family", "Calibri");
                    e.Row.Cells[i].Style.Add("width", "5px");
                }

                for (int i = 6; i < e.Row.Cells.Count; i++)
                {
                    if (PayableDays == i)
                    {
                        e.Row.Cells[i].Style.Add("text-align", "right");
                        e.Row.Cells[i].Style.Add("font-size", "12px");
                        e.Row.Cells[i].Style.Add("color", "#000");
                        e.Row.Cells[i].Style.Add("font-family", "Calibri");
                        e.Row.Cells[i].Style.Add("width", "5px");
                        continue;
                    }
                    if (OTHours == i)
                    {
                        e.Row.Cells[i].Style.Add("text-align", "right");
                        e.Row.Cells[i].Style.Add("font-size", "12px");
                        e.Row.Cells[i].Style.Add("color", "#000");
                        e.Row.Cells[i].Style.Add("font-family", "Calibri");
                        e.Row.Cells[i].Style.Add("width", "5px");
                        continue;
                    }
                    if (BankAccountNo == i)
                    {
                        continue;
                    }
                    if (Signature == i)
                    {
                        continue;
                    }
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Style.Add("text-align", "right");
                        e.Row.Cells[i].Text = "0";
                    }
                    else if (e.Row.Cells[i].Text == "0.0")
                    {
                        e.Row.Cells[i].Style.Add("text-align", "right");
                        e.Row.Cells[i].Text = "0";
                    }
                    else if (e.Row.Cells[i].Text == "0.00")
                    {
                        e.Row.Cells[i].Style.Add("text-align", "right");
                        e.Row.Cells[i].Text = "0";
                    }
                    else if (e.Row.Cells[i].Text != "&nbsp;")
                    {
                        if (i == 2)
                            e.Row.Cells[i].Text = e.Row.Cells[i].Text;
                        else
                            e.Row.Cells[i].Text = Convert.ToDecimal(e.Row.Cells[i].Text).ToString("0,0", CultureInfo.InvariantCulture);

                        e.Row.Cells[i].Style.Add("text-align", "right");
                        e.Row.Cells[i].Style.Add("padding-right", "5px");
                        e.Row.Cells[i].Style.Add("font-family", "Book Antiqua");
                    }
                    else if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Style.Add("text-align", "right");
                        e.Row.Cells[i].Text = "0";
                    }

                    e.Row.Cells[i].Style.Add("font-size", "12px");
                    e.Row.Cells[i].Style.Add("color", "#000");
                    e.Row.Cells[i].Style.Add("font-family", "Calibri");
                    e.Row.Cells[i].Style.Add("width", "5px");
                }


            }
        }


    }

    private string GetPayheadName(int id)
    {
        string PayHeadName = "";

        foreach (_Cumulative obj in List)
        {
            if (id == Convert.ToInt32(obj.PayHeadId))
                PayHeadName = obj.PayHeadName;
        }

        return PayHeadName;
    }

    private void GetPayHeadDetails()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();

        try
        {
            Connection = Activity.OpenConnection();

            DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, "select * from tbl_payroll_payhead where status=1");
            //Session["payrollsheet"] = ds;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _Cumulative Cum = new _Cumulative();
                Cum.PayHeadId = row["id"].ToString();
                Cum.PayHeadName = row["payhead_name"].ToString();
                List.Add(Cum);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Activity.CloseConnection();
        }
    }

    private DataSet LoopDelete(DataSet ds)
    {
        int IsEmpty = 0;
        string Value = "";

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int c = 4; c < ds.Tables[0].Columns.Count; c++)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    Value = ds.Tables[0].Rows[r][c].ToString();

                    if (Value != "")
                    {
                        if (Value != null)
                        {
                            if (Value != "0.0")
                            {
                                if (Value != "0.00")
                                {
                                    IsEmpty = 1;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (IsEmpty == 0)
                {
                    ds.Tables[0].Columns.RemoveAt(c);
                    break;
                }

                IsEmpty = 0;
            }
        }

        IsEmpty = 0;
        return ds;
    }

    private DataSet RemoveUnWantedColumns(DataSet ds)
    {
        for (int c = 5; c < ds.Tables[0].Columns.Count; c++)
        {
            if (ds.Tables[0].Columns[c].ColumnName == "FixedAmount")
                ds.Tables[0].Columns.Remove("FixedAmount");
            //if (ds.Tables[0].Columns[c].ColumnName == "FixedAmount")
            //    ds.Tables[0].Columns.Remove("FixedAmount");
            if (ds.Tables[0].Columns[c].ColumnName == "FixedVarAmount")
                ds.Tables[0].Columns.Remove("FixedVarAmount");
            if (ds.Tables[0].Columns[c].ColumnName == "Earnings")
                ds.Tables[0].Columns.Remove("Earnings");
            if (ds.Tables[0].Columns[c].ColumnName == "TotalVariable")
                ds.Tables[0].Columns.Remove("TotalVariable");
            if (ds.Tables[0].Columns[c].ColumnName == "Gross Earning/Wage (A)")
                ds.Tables[0].Columns.Remove("Gross Earning/Wage (A)");

            //if (ds.Tables[0].Columns[c].ColumnName == "PSAmount")
            //    ds.Tables[0].Columns.Remove("PSAmount");
        }

        return ds;
    }

    private DataSet RemoveEmptyColums(DataSet ds)
    {
        DataSet dsTemp = ds;

        for (int c = 1; c <= dsTemp.Tables[0].Columns.Count + 50; c++)
        {
            ds = LoopDelete(dsTemp);
            dsTemp = ds;
        }

        Footer(dsTemp);

        return RemoveUnWantedColumns(dsTemp);
    }

    private void Footer(DataSet ds)
    {
        DataTable dt = ds.Tables[0];
        DataRow totalsRow = dt.NewRow();
        int i = 0;
        foreach (DataColumn col in dt.Columns)
        {
            decimal colTotal = 0;
            string Value;
            if (i == 0)
                totalsRow[col.ColumnName] = 0;
            else if (i == 1)
                totalsRow[col.ColumnName] = 0;
            else if (i == 2)
                totalsRow[col.ColumnName] = 0;
            else if (i == 3)
                totalsRow[col.ColumnName] = 0;
            else if (i == 4)
                totalsRow[col.ColumnName] = 0;
            else
            {
                foreach (DataRow row in col.Table.Rows)
                {
                    Value = row[col].ToString();

                    if (Value != "")
                    {
                        if (Value != null)
                        {
                            if (Value != "0.0")
                            {
                                if (Value != "0.00")
                                {
                                    colTotal += Convert.ToDecimal(Value);
                                }
                            }
                        }
                    }


                }
            }

            if (i > 4)
                totalsRow[col.ColumnName] = colTotal;

            i++;
        }

        dt.Rows.Add(totalsRow);
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private void GenerateHeader(DataSet ds, string Month, string Company, string FYear, string cors_add1)
    {
        string str = "";
        int count = ds.Tables[0].Columns.Count;
        int countminusten = count - 7;
        int remaining = count - countminusten - 1;

        str = str + "<table style='width:100%'><tr><td colspan='" + count + "' align='center'><b>Salary Sheet</b><td></tr>";
        str = str + "<tr><td colspan='" + count + "' align='center'>&nbsp;<td></tr>";

        str = str + "<tr><td colspan='1'><b>Name & address of the establishment:</b>  " + Company + " & " + cors_add1 + "<td><td colspan='" + countminusten + "'>&nbsp;<td><td colspan='" + remaining + "'><b>Payroll for the month of </b> " + Month + " " + FYear + "<td></tr>";
        str = str + "<tr><td colspan='" + count + "' align='center'>&nbsp;<td></tr>";
        str = str + "</table>";

        tablehead.InnerHtml = str.ToString();
    }



    protected void btnexport_Click(object sender, EventArgs e)
    {
        OldExportCOde();
    }


    private void OldExportCOde()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=SalarySheet.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            foreach (TableCell cell in GvCumulative.HeaderRow.Cells)
            {
                GvCumulative.HeaderRow.Cells[5].Style.Add("width", "65px");
                cell.Style.Add("width", "50px");
            }
            foreach (GridViewRow row in GvCumulative.Rows)
            {
                row.Cells[5].Style.Add("width", "65px");
                foreach (TableCell cell in row.Cells)
                {
                    cell.Style.Add("width", "50px");
                }
            }
            GvCumulative.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }





    //    //DataSet ds = (DataSet)Session["payrollsheet"];
    //    //GetData();
    //    DataSet ds = (DataSet)Session["payrollsheet"];
    //    Response.Clear(); //this clears the Response of any headers or previous output 
    //    Response.Charset = "";
    //    Response.Buffer = true; //make sure that the entire output is rendered simultaneously
    //    Response.ClearContent();
    //    Response.ContentType = "application/vnd.ms-excel";
    //    //string filename = "attachment;filename =SALARYSHEET.xls";
    //    string filename = "attachment;filename =SALARYSHEET.xls";
    //    //string filename = "attachment;filename =Attendance-1.xls";
    //    //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
    //    Response.Write(filename);
    //    Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
    //    StringWriter stringWrite = new StringWriter();
    //    HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
    //    DataGrid dg = new DataGrid();
    //    dg.DataSource = ds.Tables[0];
    //    dg.DataBind();

    //    String style = @"<style>.text{mso-number-format:\@;}</style>";
    //    HttpContext.Current.Response.Write(style);
    //    int colindex = 0;
    //    foreach (DataColumn dc in ds.Tables[0].Columns)
    //    {
    //        string valuetype = dc.DataType.ToString();
    //        foreach (DataGridItem i in dg.Items)
    //            i.Cells[colindex].Attributes.Add("class", "text");
    //        colindex++;
    //    }

    //    dg.RenderControl(htmlwrite);
    //    Response.Write(stringWrite.ToString());
    //    Response.End();
    //}
}

public class _Cumulative
{
    public string PayHeadId { get; set; }
    public string PayHeadName { get; set; }
}





