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
using Common.Data;
using Common.Console;
using System.IO;
using System.Text;


public partial class payroll_admin_ECFReport : System.Web.UI.Page
{
    SqlParameter[] sqlparm;
    string _companyId;
    DataSet ds;
    public string Month, Year, Dept, Emptype, EmpSubType, Branch;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

        }
        BindDetails();
        string month = Request.QueryString["month"].ToString();
        string year = Request.QueryString["year"].ToString();
        DataSet ds = BindGrid(Month, Year);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        BindGrid(Month, Year);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";
        GridView1.AllowPaging = false;
        GridView1.DataBind();

        StringBuilder columnbind = new StringBuilder();
        for (int k = 0; k < GridView1.Columns.Count; k++)
        {

            //columnbind.Append(GridView1.Columns[k].HeaderText + '#'+'~'+'#');
        }

        //columnbind.Append("\r\n");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int k = 0; k < GridView1.Columns.Count; k++)
            {

                columnbind.Append(GridView1.Rows[i].Cells[k].Text + '#'+'~'+'#');
            }

            columnbind.Append("\r\n");
        }
        Response.Output.Write(columnbind.ToString());
        Response.Flush();
        Response.End();  



        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=" + "ECRReport.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //using (StringWriter sw = new StringWriter())
        //{
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GridView1.HeaderRow.BackColor = System.Drawing.Color.White;
        //    foreach (TableCell cell in GridView1.HeaderRow.Cells)
        //    {
        //        cell.BackColor = GridView1.HeaderStyle.BackColor;
        //    }
        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        row.BackColor = System.Drawing.Color.White;
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (row.RowIndex % 2 == 0)
        //            {
        //                cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
        //            }
        //            else
        //            {
        //                cell.BackColor = GridView1.RowStyle.BackColor;
        //            }
        //            cell.CssClass = "textmode";
        //        }
        //    }

        //    GridView1.RenderControl(hw);

        //    //style to format numbers to string
        //    string style = @"<style> .textmode { } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private DataSet BindGrid(string Month, string Year)
    {

        SqlConnection Connection = null;
        DataActivity Activity = new DataActivity();
        if (Branch != "0")
        {
            if (Dept != "0")
            {
                try
                {
                    Connection = Activity.OpenConnection();
                    //SqlParameter[] parm = new SqlParameter[2];                 
                    //Output.AssignParameter(parm, 0, "@month", "String", 5, Request.QueryString["month"].ToString());
                    //Output.AssignParameter(parm, 1, "@year", "String", 4, Request.QueryString["year"].ToString());

                    string sqlstrExitRpt = @"select distinct jobDetails.empcode [Empcode],p.uan,      
coalesce(jobDetails.emp_fname,'''') +  '' + coalesce(jobDetails.emp_m_name,'''') +  '' + coalesce(jobDetails.emp_l_name,'''') as [Name], 
sd.amount [EarnedBasic],  
0 as EPS,   
salary.EPF [EmployeePFDeductions],  
cast(round((salary.EPF * 12)/100,0) as decimal(5,2)) as EPFCON,                           
salary.PF_AC_21,
jobDetails.emp_gender,
convert(varchar(20),personal.dob, 106) dob,
case when personal.f_fname != '' then personal.f_fname else null end as f_fname,
'F' as relation,
salary.LWP,
0 as EPFRemitted, 0 as EPSContribution, 0 as EPSWages, 0 as EPFEPS, 0 as EPFEPSERRemitted, 0 as RefundAdvances, 0 as ArrearEPFWages, 0 as ArrearEPFShare, 0 as ArrearEPSShare, 0 as ArrearEPS, '' as DOJEPF , '' as DOJEPS, '' as DateExitEPF, '' as DateExitEPS,'' as Reasonleaving 
from tbl_intranet_companydetails,dbo.tbl_payroll_providentfund pf,tbl_intranet_employee_payrollDetails payrollDetails       
right outer join tbl_intranet_employee_jobDetails jobDetails on jobDetails.empcode=payrollDetails.empcode      
inner join tbl_payroll_employee_salary salary on salary.empcode=jobDetails.empcode 
inner join tbl_payroll_employee_salarydetail sd on sd.SALARYID = salary.SALARYID and sd.PAYHEADID = 0
inner join tbl_payroll_employee_paystructure on salary.empcode=tbl_payroll_employee_paystructure.empcode and tbl_payroll_employee_paystructure.status = 1   
inner join tbl_payroll_employee_paystructure_detail pd on pd.empcode = tbl_payroll_employee_paystructure.empcode and pd.payhead = 0 and pd.status = 1
inner join tbl_intranet_employee_payrollDetails p on p.empcode = salary.EMPCODE and p.uan != ''
inner join tbl_intranet_employee_personalDetails personal on personal.empcode = salary.EMPCODE
where salary.month='" + Request.QueryString["month"].ToString() + "' and salary.year = '" + Request.QueryString["year"].ToString() + "' group by tbl_intranet_companydetails.companyname,tbl_intranet_companydetails.epf_no,pf.account02,pf.account21,p.uan,pf.account22,pf.pension_fund,jobDetails.emp_fname,salary.LWP,jobDetails.emp_gender,personal.dob,personal.f_fname,jobDetails.emp_m_name,jobDetails.emp_l_name,salary.EPF,salary.EEPF,salary.PF_AC_02,salary.PF_AC_10,salary.PF_AC_21,salary.PF_AC_22,sd.amount,pd.amount,jobDetails.empcode ";

                    ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstrExitRpt);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    lbldate.Text = "ECR REPORT FOR MONTH OF" + ' ' + Request.QueryString["month"].ToString() + '/' + Request.QueryString["year"].ToString();
                }

                catch (Exception ex)
                {

                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    Activity.CloseConnection();
                }


            }


        }

        return ds;
    }

    protected void BindDetails()
    {
        SqlConnection Connection = null;
        DataActivity Activity = new DataActivity();
        Connection = Activity.OpenConnection();
        string query = @"select companyname,epf_no from tbl_intranet_companydetails";
        ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
        Activity.CloseConnection();
        // lbl_compname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        //lbl_epfdetails.Text = ds.Tables[0].Rows[0]["epf_no"].ToString();

    }

}