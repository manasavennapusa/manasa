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

public partial class payroll_admin_reports_CostEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");

        }
        query q = new query();
        ParameterFields paramFields;
        ParameterField paramField;
        ParameterDiscreteValue paramDiscreteValue;
        paramFields = new ParameterFields();
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@branch", (q["branch"] != null) ? q["branch"] : "0");
        sqlparm[1] = new SqlParameter("@dept", (q["dept"] != null) ? q["dept"] : "0");
        sqlparm[2] = new SqlParameter("@month", (q["month"] != null) ? q["month"] : "");
        sqlparm[3] = new SqlParameter("@year", (q["year"] != null) ? q["year"] : "2008-2009");


        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_salary_sheet_monthly", sqlparm);
        ds1.Tables[0].TableName = "table";

        //DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, "select salaryid,month,empcode,year,fromdate,gtotal from tbl_payroll_employee_salary");
        //ds1.Tables[0].TableName = "table";
        
        int columncount = ds1.Tables[0].Columns.Count;
        //for (int i = 0; i < columncount; i++)
        //{
        //    paramField = new ParameterField();
        //    paramField.Name = "col" + Convert.ToString(i + 1);
        //    paramDiscreteValue = new ParameterDiscreteValue();
        //    paramDiscreteValue.Value = ds1.Tables[0].Columns[i].ColumnName.ToString();
        //    paramField.CurrentValues.Add(paramDiscreteValue);
        //    paramFields.Add(paramField);
        //    ds1.Tables[0].Columns[i].ColumnName = "column" + Convert.ToString(i+1);    
        //}
        for (int i = 0; i < 60; i++)
        {
            paramField = new ParameterField();
            paramField.Name = "col" + Convert.ToString(i + 1);
            paramDiscreteValue = new ParameterDiscreteValue();
            if (i < columncount)
            {
                paramDiscreteValue.Value = ds1.Tables[0].Columns[i].ColumnName.ToString();
                ds1.Tables[0].Columns[i].ColumnName = "column" + Convert.ToString(i + 1);
            }
            else
                paramDiscreteValue.Value = "";

            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
        }
        paramField = new ParameterField();
        paramField.Name = "monthy";
        paramDiscreteValue = new ParameterDiscreteValue();
        paramDiscreteValue.Value = q["month"].ToUpper()  + " " + q["year"];
        paramField.CurrentValues.Add(paramDiscreteValue);
        paramFields.Add(paramField);

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("SalarySheet.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["table"]);


        CrystalReportViewer1.ParameterFieldInfo = paramFields;
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }
}
