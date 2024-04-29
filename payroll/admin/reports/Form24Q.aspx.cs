using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Text;
using System.IO;

public partial class payroll_admin_reports_report_esiform5 : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet dsDD = new DataSet();
    DataSet dsSD=new DataSet();
    DataSet dsCH = new DataSet();
    string sqlstr;
    string strPop;
    SqlParameter[] sqlparm;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            //bind_year();
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        generateFUV();
    }
    
    protected string[] getmonths()
    {
        int i;
        if (Convert.ToInt32(dd_month.SelectedValue) == 1)
            i = 4;
        else if (Convert.ToInt32(dd_month.SelectedValue) == 2)
            i = 7;
        else if (Convert.ToInt32(dd_month.SelectedValue) == 3)
            i = 10;
        else if (Convert.ToInt32(dd_month.SelectedValue) == 4)
            i = 1;
        else
            i = 1;
        string[] months = new string[3];
        months[0] = monthname(i);
        months[1] = monthname(i + 1);
        months[2] = monthname(i + 2);
        return months;
    }

    protected string monthname(int month)
    {
        switch (month)
        {
            case 1: return "Jan"; 
            case 2: return "Feb";
            case 3: return "Mar"; 
            case 4: return "Apr"; 
            case 5: return "May"; 
            case 6: return "Jun"; 
            case 7: return "Jul"; 
            case 8: return "Aug"; 
            case 9: return "Sep"; 
            case 10: return "Oct"; 
            case 11: return "Nov"; 
            case 12: return "Dec"; 
            default: return "Apr";      
        }      
    }

    protected void generateFUV()
    {
        try
        {
            StreamWriter fp;
            string filename;
            StringBuilder fuvgenerate = new StringBuilder();
            int lineno = 1;
            char delim = '^';
            string lineend = "\n";
            string[] months = getmonths();
            int SDrecord = 0;
            decimal tgross = 0;

            if (dd_month.SelectedValue == "4")
            {
                sqlparm = new SqlParameter[2];
                sqlparm[0] = new SqlParameter("@financial_year", dd_year.SelectedValue);
                sqlparm[1] = new SqlParameter("@branch", dd_branch.SelectedValue);
                dsSD = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "SP_PAYROLL_FUV_SD_DETAIL", sqlparm);
                for (int z = 0; z < dsSD.Tables[0].Rows.Count; z++)
                {
                    tgross = tgross + Convert.ToDecimal(dsSD.Tables[0].Rows[z]["tgross"]);
                }
                SDrecord = dsSD.Tables[0].Rows.Count;
            }
            ///----------------------------------------------------FH ENTRY--------------------------------------------
            ///Line Number,Record Type,File Type,Upload Type,File Creation Date,File Sequence No.,Uploader Type,TAN of Employer,Total No. of Batches,Name of Return Preparation Utility
            ///Record Hash (Not applicable),FVU Version (Not applicable),File Hash (Not applicable),Sam Version (Not applicable),SAM Hash (Not applicable),SCM Version (Not applicable),SCM Hash (Not applicable)
            sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@financial_year", dd_year.SelectedValue);
            sqlparm[1] = new SqlParameter("@quater", dd_month.SelectedValue);
           // sqlparm[2] = new SqlParameter("@branch", dd_branch.SelectedValue);
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "SP_PAYROLL_FUV_FHBH_DETAIL", sqlparm);

            fuvgenerate.Append(lineno.ToString() + delim + "FH" + delim + "SL1" + delim + "R" + delim + DateTime.Now.ToString("ddMMyyyy") + delim + "1" + delim +
                          "D" + delim + Convert.ToString(ds.Tables[0].Rows[0]["tan_no"]) + delim + "1" + delim + "" +
                          delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + lineend);
            lineno = lineno + 1;
            ///----------------------------------------------------FH ENTRY DONE-----------------------------------------
            ///-------------------------,--------------------------BH ENTRY ---------------------------------------------
            fuvgenerate.Append(lineno.ToString() + delim + "BH" + delim + "1" + delim + "3" + delim + "24Q" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim +
                                Convert.ToString(ds.Tables[0].Rows[0]["tan_no"]) + delim + "" + delim + Convert.ToString(ds.Tables[0].Rows[0]["pan_no"]) + delim +
                //"200910^200809^" +
                                Convert.ToString(Convert.ToInt32(dd_year.SelectedItem.Text.Substring(0, 4)) + 1) + Convert.ToString(Convert.ToInt32(dd_year.SelectedItem.Text.Substring(5, 4)) + 1).Substring(2, 2) + delim + dd_year.SelectedItem.Text.Substring(0, 4) + dd_year.SelectedItem.Text.Substring(7, 2) + delim +
                                 dd_month.SelectedItem.Text + delim + Convert.ToString(ds.Tables[0].Rows[0]["empname"]) + delim + "" + delim +
                                Convert.ToString(ds.Tables[0].Rows[0]["address1"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["address2"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["address3"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["address4"]) + delim +
                                Convert.ToString(ds.Tables[0].Rows[0]["address5"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["state"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["pin"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["emailid"]) + delim +
                                Convert.ToString(ds.Tables[0].Rows[0]["std"]) + delim + "" + delim + "N" + delim + "O" + delim + Convert.ToString(ds.Tables[0].Rows[0]["rempname"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["designation"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["raddress1"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["raddress2"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["raddress3"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["raddress4"]) + delim +
                                Convert.ToString(ds.Tables[0].Rows[0]["raddress5"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["rstate"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["rpin"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["remailid"]) + delim + "" + delim + Convert.ToString(ds.Tables[0].Rows[0]["rstd"]) + delim +
                                "0" + delim + "N" + delim + Convert.ToString(ds.Tables[1].Rows[0]["total_tax"]) + delim + "" + delim + SDrecord.ToString() + delim + tgross.ToString("##########0.00") + delim + "N" + delim + "" + delim + "" + lineend);
            ///----------------------------------------------------BH ENTRY DONE-----------------------------------------
            ///----------------------------------------------------CD - DD ENTRY ---------------------------------------------
            lineno = lineno + 1;
            int batchno = 1;
            string s = ConfigurationManager.AppSettings["test"];
            foreach (string month in months)
            {
                sqlparm = new SqlParameter[3];
                sqlparm[0] = new SqlParameter("@financial_year", dd_year.SelectedValue);
                sqlparm[1] = new SqlParameter("@MONTH", month);
                sqlparm[2] = new SqlParameter("@branch", dd_branch.SelectedValue);
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "SP_PAYROLL_FUV_CD_DETAIL", sqlparm);
                ///----------------------------------------------------1 BATCH CD ENTRY ---------------------------------------------
                fuvgenerate.Append(lineno.ToString() + delim + "CD" + delim + "1" + delim + batchno.ToString() + delim + Convert.ToString(ds.Tables[0].Rows[0]["Tay_Payer"]) + delim + "N" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim +
                                   Convert.ToString(ds.Tables[0].Rows[0]["challenno"]) + delim + "" + delim + "" + delim + "" + delim + Convert.ToString(ds.Tables[0].Rows[0]["bank_branch_code"]) + delim + "" + delim + Convert.ToString(ds.Tables[0].Rows[0]["dddate"]) + delim +
                                   "" + delim + "" + delim + "92B" + delim + Convert.ToString(ds.Tables[0].Rows[0]["tds"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["surcharge"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["cess"]) + delim + "0.00" + delim + "0.00" + delim +
                                   Convert.ToString(ds.Tables[0].Rows[0]["ttax"]) + delim + "" + delim + Convert.ToString(ds.Tables[0].Rows[0]["ttax"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["tds"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["surcharge"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["cess"]) +
                                   delim + Convert.ToString(ds.Tables[0].Rows[0]["ttax"]) + delim + "0.00" + delim + "0.00" + delim + Convert.ToString(ds.Tables[0].Rows[0]["checkno"]) + delim + "N" + delim + "" + delim + "" + lineend);

                lineno = lineno + 1;
                ///----------------------------------------------------1 SEQ. DD ENTRY ---------------------------------------------
                dsDD = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "SP_PAYROLL_FUV_DD_DETAIL", sqlparm);
                for (int k = 0; k < dsDD.Tables[0].Rows.Count; k++)
                {
                    fuvgenerate.Append(lineno.ToString() + delim + "DD" + delim + "1" + delim + batchno.ToString() + delim + Convert.ToString(k + 1) + delim + "O" + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["emp_serial"]) + delim + "" + delim + "" + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["pan_no"]) + delim + "" + delim + "" +
                                       delim + Convert.ToString(dsDD.Tables[0].Rows[k]["empname"]).Trim() + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["tds"]) + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["surcharge"]) +
                                       delim + Convert.ToString(dsDD.Tables[0].Rows[k]["cess"]) + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["ttax"]) + delim + "" + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["ttax"]) + delim + "" + delim + "" + delim +
                                       Convert.ToString(dsDD.Tables[0].Rows[k]["gross_amount"]) + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["date"]) + delim + Convert.ToString(dsDD.Tables[0].Rows[k]["date"]) + delim + Convert.ToString(ds.Tables[0].Rows[0]["dddate"]) +
                                       delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + delim + "" + lineend);

                    ///----------------------------------------------------1 SEQ. DD ENTRY DONE-----------------------------------------
                    lineno = lineno + 1;
                }
                ///----------------------------------------------------1 BATCH ENTRY DONE-----------------------------------------
                batchno = batchno + 1;
            }
            if (dd_month.SelectedValue == "4")
            {
                ///----------------------------------------------------1 SEQ. SD ENTRY ---------------------------------------------
                for (int k = 0; k < dsSD.Tables[0].Rows.Count; k++)
                {
                    sqlparm = new SqlParameter[1];
                    sqlparm[0] = new SqlParameter("@empcode", dsSD.Tables[0].Rows[k]["empcode"].ToString());
                    dsCH = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "SP_PAYROLL_FUV_SD_CHAPTER6A_DETAIL", sqlparm);

                    fuvgenerate.Append(lineno.ToString() + delim + "SD" + delim + "1" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["emp_serial"]) + delim + "A" + delim + "" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["pan_no"]) + delim + "" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["empname"]) + delim +
                                       Convert.ToString(dsSD.Tables[0].Rows[k]["category"]).Trim() + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["fromdate"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["todate"]) +
                                       delim + Convert.ToString(dsSD.Tables[0].Rows[k]["gross_salary"]) + delim + "" + delim + "0" + delim + "0.00" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["gross_salary"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["otherincome"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["tgross"]) + delim + "" + delim + Convert.ToString(Convert.ToInt32(dsCH.Tables[0].Rows[0]["6A"]) + Convert.ToInt32(dsCH.Tables[0].Rows[0]["Other"])) + delim +
                                       Convert.ToString(dsSD.Tables[0].Rows[k]["TChapter6A"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["TAXABLE_INCOME"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["tds"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["surcharge"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["cess"]) +
                                       delim + "0.00" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["TAXAMOUNT"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["taxpaid"]) + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["Shortfall"]) + delim + "" + delim + "" + delim + "" + delim + "" + lineend);
                    lineno = lineno + 1;
                    int c6a = 1;
                    int s16 = 1;
                    ///----------------------------------------------------CHAPTER 6A ENTRY ---------------------------------------------
                    if (Convert.ToInt32(dsCH.Tables[0].Rows[0]["6A"]) > 0)
                    {
                        fuvgenerate.Append(lineno.ToString() + delim + "S16" + delim + "1" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["emp_serial"]) + delim +
                        s16.ToString() + delim + "80CCE" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["chapter6a"]) + delim + lineend);
                        s16 = s16 + 1;
                        lineno = lineno + 1;
                    }
                    if (Convert.ToInt32(dsCH.Tables[0].Rows[0]["Other"]) > 0)
                    {
                        fuvgenerate.Append(lineno.ToString() + delim + "C6A" + delim + "1" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["emp_serial"]) + delim +
                        c6a.ToString() + delim + "OTHERS" + delim + Convert.ToString(dsSD.Tables[0].Rows[k]["ochapter6a"]) + delim + lineend);
                        c6a = c6a + 1;
                        lineno = lineno + 1;
                    }
                    ///----------------------------------------------------CHAPTER 6A ENTRY ---------------------------------------------
                    ///---------------------------------------------------2 SEQ. SD ENTRY DONE-----------------------------------------

                }
            }

            filename = "etds" + dd_month.SelectedItem.Text + ".txt";
            fp = File.CreateText(Server.MapPath(".\\..\\Upload\\") + filename);
            fp.WriteLine(fuvgenerate.ToString().Trim());
            fp.Close();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.Flush();
            Response.WriteFile(Server.MapPath(".\\..\\Upload\\") + filename);
            Response.End();
        }
        catch (Exception ex)
        {
            message.InnerText = "Data is incomplete. Please check you have make challan for all months of particular quarter.";
        }
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        string strPop = "<script language='javascript'>window.open('QuaterReport.aspx?year=" + dd_year.SelectedItem.Text.ToString() + "&quater=" + dd_month.SelectedValue + "&branchid=" + dd_branch.SelectedValue + "')</script>";

        Page.RegisterClientScriptBlock("xx", strPop);
    }

    protected void reset()
    {
        dd_month.SelectedIndex = -1;
        dd_year.SelectedIndex = -1;
    }

    protected void bind_year()
    {
        sqlstr = "select distinct year from tbl_payroll_employee_salary";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void btn_form24q_Click(object sender, EventArgs e)
    {
        string strPop = "<script language='javascript'>window.open('Quater24Q.aspx?year=" + dd_year.SelectedItem.Text.ToString() + "&quater=" + dd_month.SelectedValue + "&branchid=" + dd_branch.SelectedValue + "')</script>";

        Page.RegisterClientScriptBlock("xx", strPop);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            sqlparm = new SqlParameter[3];
            sqlparm[0] = new SqlParameter("@fyear", ddlFinancialYearF16.SelectedValue);
            sqlparm[1] = new SqlParameter("@EMPCODE", txt_employee.Text.Trim().ToString());
            sqlparm[2] = new SqlParameter("@date", Utilities.Utility.dataformat(txtdate.Text.ToString()).ToString("MM/dd/yyyy"));
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_Q4_ETDS_EMPLOYEE", sqlparm);
        }
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("---Select Cost Center---", "0"));
    }
    protected void rbtnAll_CheckedChanged(object sender, EventArgs e)
    {
        form16Employee.Visible = false;
    }

    protected void rbtnEmployee_CheckedChanged(object sender, EventArgs e)
    {
        form16Employee.Visible = true;
    }

}