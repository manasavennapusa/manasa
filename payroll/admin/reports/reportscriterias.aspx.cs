using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class payroll_admin_reports_reportscriterias : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DateTime Fdate, Todate;
    ReportDocument cryRpt = new ReportDocument();
    SqlParameter[] sqlparam = new SqlParameter[4];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");

            if (Convert.ToInt32(Request.QueryString["pfform5"]) == 5)
            {
                divform5message.Visible = true;
                divform10message.Visible = false;
                divpfform12Amessage.Visible = false;
                divpfform6Amessage.Visible = false;
                divesiform5message.Visible = false;
                divesiform6message.Visible = false;
                divesimonthlyreportmessage.Visible = true;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "PF Form 5";
            }

             if (Request.QueryString["pfform6A"] == "6A")
            {
                divpfform6Amessage.Visible = true;
                divform10message.Visible = false;
                divform5message.Visible = false;
                divpfform12Amessage.Visible = false;
                divesiform5message.Visible = false;
                divesiform6message.Visible = false;
                divesimonthlyreportmessage.Visible = true;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "PF Form 6A";
                
            }

            if (Convert.ToInt32(Request.QueryString["pfform10"]) == 10)
            {

                divform10message.Visible = true;
                divpfform12Amessage.Visible = false;
                divpfform6Amessage.Visible = false;
                divform5message.Visible = false;
                divesiform5message.Visible = false;
                divesiform6message.Visible = false;
                divesimonthlyreportmessage.Visible = false;
                divpfmonthlyreportmessage.Visible = false;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "PF Form 10";
            }
            
            if (Request.QueryString["pfform12A"] == "12A")
            {
                divpfform12Amessage.Visible = true;
                divform10message.Visible = false;
                divpfform6Amessage.Visible = false;
                divform5message.Visible = false;
                divesiform5message.Visible = false;
                divesiform6message.Visible = false;
                divesimonthlyreportmessage.Visible = false;
                divpfmonthlyreportmessage.Visible = false;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "PF Form 12A";
            }

            if (Request.QueryString["esiform5"] == "5")
            {
                divesiform5message.Visible = true;
                divpfform12Amessage.Visible = false;
                divform10message.Visible = false;
                divpfform6Amessage.Visible = false;
                divform5message.Visible = false;
                divesiform6message.Visible = false;
                divesimonthlyreportmessage.Visible = false;
                divpfmonthlyreportmessage.Visible = false;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "ESI Form 5";
            }


            if (Request.QueryString["esiform6"] == "6")
            {
                divesiform6message.Visible = true;
                divesiform5message.Visible = false;
                divpfform12Amessage.Visible = false;
                divform10message.Visible = false;
                divpfform6Amessage.Visible = false;
                divform5message.Visible = false;
                divesimonthlyreportmessage.Visible = false;
                divpfmonthlyreportmessage.Visible = false;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "ESI Form 6";
            }

            if (Request.QueryString["esimonthlyreport"] == "30")
            {
                divesimonthlyreportmessage.Visible = true;
                divesiform6message.Visible = false;
                divesiform5message.Visible = false;
                divpfform12Amessage.Visible = false;
                divform10message.Visible = false;
                divpfform6Amessage.Visible = false;
                divform5message.Visible = false;
                divpfmonthlyreportmessage.Visible = false;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "ESI Monthly Report";
            }

            if (Request.QueryString["pfmonthlyreport"] == "30")
            {
                divpfmonthlyreportmessage.Visible = true;
                divesiform6message.Visible = false;
                divesiform5message.Visible = false;
                divpfform12Amessage.Visible = false;
                divform10message.Visible = false;
                divpfform6Amessage.Visible = false;
                divform5message.Visible = false;
                divesimonthlyreportmessage.Visible = false;
                divesihalfyearlychallanmessage.Visible = false;
                lblfrmname.Text = "PF Monthly Report";
            }

            if (Request.QueryString["esihalfyearlychallan"] == "180")
            {
                divesihalfyearlychallanmessage.Visible = true;
                divpfmonthlyreportmessage.Visible = false;
                divesiform6message.Visible = false;
                divesiform5message.Visible = false;
                divpfform12Amessage.Visible = false;
                divform10message.Visible = false;
                divpfform6Amessage.Visible = false;
                divform5message.Visible = false;
                divesimonthlyreportmessage.Visible = false;
                lblfrmname.Text = "ESI Half Yearly Report";
            }

        }
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        getdatefun();

        if (Convert.ToInt32(Request.QueryString["pfform5"]) == 5)
        {
            bindempdetail();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform5", sqlparam);

            if (ds.Tables[0].Rows.Count > 0)
            {
                divform5message.Visible = true;
                divform10message.Visible = false;
                GridViewform10.Visible = false;
            }
            else
            {
                divform5message.Visible = false;
                divform10message.Visible = false;
            }

            GridViewform5.DataSource = ds;
            GridViewform5.DataBind();
        }

        else if (Convert.ToInt32(Request.QueryString["pfform10"]) == 10)
        {
            bindempdetail();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", sqlparam);

            if (ds.Tables[0].Rows.Count > 0)
            {
                divform10message.Visible = true;
                divform5message.Visible = false;
                GridViewform5.Visible = false;
            }
            else
            {
                divform10message.Visible = false;
                divform5message.Visible = false;
            }

            GridViewform10.DataSource = ds;
            GridViewform10.DataBind();

        }


    }

    protected void bindempdetail()
    {
        sqlparam[0] = new SqlParameter("@Fdate", SqlDbType.DateTime);
        sqlparam[0].Value = Fdate.ToShortDateString();

        sqlparam[1] = new SqlParameter("@Todate", SqlDbType.DateTime);
        sqlparam[1].Value = Todate.ToShortDateString();

        sqlparam[2] = new SqlParameter("@PF_Group",  SqlDbType.VarChar, 50);
        sqlparam[2].Value = drppfgroup.SelectedValue;

        sqlparam[3] = new SqlParameter("@OrderBy", SqlDbType.VarChar, 150);
        sqlparam[3].Value = drporderby.SelectedValue;
        
    }
    
    protected void getdatefun()
    {
        Fdate=  Convert.ToDateTime("1/" + drpMonth.SelectedValue.ToString() + "/" + drpYear.SelectedItem.ToString());
        //Fdate = Convert.ToDateTime(drpMonth.SelectedValue.ToString() + "/1/" + drpYear.SelectedItem.ToString());
        Todate = Fdate.AddMonths(1).AddDays(-1);
    }

    protected void lnkshowreport_Click(object sender, EventArgs e)
    {
        getdatefun();

        if (Convert.ToInt32(Request.QueryString["pfform5"]) == 5)
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&pfform5=5','name123')</script>");
        }

        if (Request.QueryString["pfform6A"] == "6A")
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&pfform6A=6A','name123')</script>");
        }

        if (Convert.ToInt32(Request.QueryString["pfform10"]) == 10)
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&pfform10=10','name123')</script>");
        }

        if (Request.QueryString["pfform12A"] == "12A")
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&pfform12A=12A','name123')</script>");
        }

        if (Request.QueryString["esiform5"] == "5")
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&esiform5=5','name123')</script>");
        }

        if (Request.QueryString["esiform6"] == "6")
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&esiform6=6','name123')</script>");
        }

        if (Request.QueryString["esimonthlyreport"] == "30")
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&esimonthlyreport=30','name123')</script>");
        }

        if (Request.QueryString["pfmonthlyreport"] == "30")
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&pfmonthlyreport=30','name123')</script>");
        }
        if (Request.QueryString["esihalfyearlychallan"] == "180")
        {
            Response.Write("<script language='javascript'>window.open('reports.aspx?Fdate=" + Fdate.ToLongDateString() + "&Todate=" + Todate.ToLongDateString() + "&PF_Group=" + drppfgroup.SelectedValue + "&OrderBy=" + drporderby.SelectedValue + "&Month=" + drpMonth.SelectedItem + "&Year=" + drpYear.SelectedItem + "&esihalfyearlychallan=180','name123')</script>");
        }

    }

}
