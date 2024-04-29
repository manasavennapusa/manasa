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
using System.IO;
public partial class payroll_admin_payrollleavereport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            }
            else Response.Redirect("~/notlogged.aspx");
            //current_month();
            bind_fyear();
            dd_month.Enabled = false;
            date.Visible = false;
        }
    }

    //protected void current_month()
    //{
    //    DateTime dt = DateTime.Now;

    //    if (Convert.ToInt16(dt.Day) >= 30)
    //        dt = dt.AddMonths(1);

    //    dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
    //    dd_month.SelectedValue = dt.Month.ToString();
    //}

    protected void bind_fyear()
    {
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(dt.Month) >= 4)
            lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        else
            lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindreport();
    }

    protected void bindreport()
    {
        if (rbtnusedleave.Checked)
        {
            SqlParameter[] sqlparam = new SqlParameter[9];

            sqlparam[0] = new SqlParameter("@month", SqlDbType.Int);
            sqlparam[0].Value = dd_month.SelectedValue;

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = dd_designation.SelectedValue;

            sqlparam[2] = new SqlParameter("@name", SqlDbType.VarChar);
            sqlparam[2].Value = "";

            sqlparam[3] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[3].Value = dd_branch.SelectedValue;

            sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar);
            sqlparam[4].Value = lbl_fyear.Text.Trim();

            sqlparam[5] = new SqlParameter("@branch", SqlDbType.Int);
            sqlparam[5].Value = 0;

            sqlparam[6] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[6].Value = 3;

            sqlparam[7] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            sqlparam[7].Value = Utilities.Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

            sqlparam[8] = new SqlParameter("@todate", SqlDbType.DateTime);
            sqlparam[8].Value = Utilities.Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_leaveused", sqlparam);
        }
        else
        {
            SqlParameter[] sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[0].Value = dd_designation.SelectedValue;

            sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar);
            sqlparam[1].Value = "";

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = dd_branch.SelectedValue;

            sqlparam[3] = new SqlParameter("@branch", SqlDbType.Int);
            sqlparam[3].Value = 0;

            sqlparam[4] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[4].Value = 3;


            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_leavebalance]", sqlparam);
        }
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

    protected void btnreport_Click(object sender, EventArgs e)
    {
        bindreport();
    }

    protected void rbtnusedleave_CheckedChanged(object sender, EventArgs e)
    {
        dd_month.Enabled = true;
        date.Visible = true;
    }

    protected void rbtnbalancedleave_CheckedChanged(object sender, EventArgs e)
    {
        dd_month.Enabled = false;
        date.Visible = false;
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {
        //try
        //{
        string filename;
        filename = "attachment;";
        if (rbtnusedleave.Checked)
        {
            filename = filename + "Leave Report from Date : '" + txt_sdate.Text + "' and '" + txt_edate.Text + "'";

            SqlParameter[] sqlparam = new SqlParameter[9];

            sqlparam[0] = new SqlParameter("@month", SqlDbType.Int);
            sqlparam[0].Value = dd_month.SelectedValue;

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = dd_designation.SelectedValue;

            sqlparam[2] = new SqlParameter("@name", SqlDbType.VarChar);
            sqlparam[2].Value = "";

            sqlparam[3] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[3].Value = dd_branch.SelectedValue;

            sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar);
            sqlparam[4].Value = lbl_fyear.Text.Trim();

            sqlparam[5] = new SqlParameter("@branch", SqlDbType.Int);
            sqlparam[5].Value = 0;

            sqlparam[6] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[6].Value = 3;

            sqlparam[7] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            sqlparam[7].Value =Utilities.Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

            sqlparam[8] = new SqlParameter("@todate", SqlDbType.DateTime);
            sqlparam[8].Value = Utilities.Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_leaveused", sqlparam);
        }
        else
        {
            filename = filename + "Balance Leave Details Report";

            SqlParameter[] sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[0].Value = dd_designation.SelectedValue;

            sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar);
            sqlparam[1].Value = "";

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = dd_branch.SelectedValue;

            sqlparam[3] = new SqlParameter("@branch", SqlDbType.Int);
            sqlparam[3].Value = 0;

            sqlparam[4] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[4].Value = 3;
            
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_leavebalance]", sqlparam);

        } 
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        
         //filename = "attachment;filename =LeaveReport.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds.Tables[0];
        dg.DataBind();

        String style = @"<style>.text{mso-number-format:\@;}</style>";
        HttpContext.Current.Response.Write(style);
        int colindex = 0;
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            string valuetype = dc.DataType.ToString();
            foreach (DataGridItem i in dg.Items)
                i.Cells[colindex].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        //}
        //catch
        //{
        //    message.InnerHtml = "Monthly TDS Detail Can not be exported";
        //}
    }
}
