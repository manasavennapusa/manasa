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
using DataAccessLayer;
using System.Data.SqlClient;
using System.IO;
public partial class payroll_admin_bankstatementform : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");

            bind_month();
        }
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[4];

        sqlparm[0] = new SqlParameter("@year", SqlDbType.VarChar, 25);
        sqlparm[0].Value = dd_year.SelectedItem.Text.Trim().ToString();

        sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 25);
        sqlparm[1].Value = ddlmonth.SelectedItem.Text.Trim().ToString();

        sqlparm[2] = new SqlParameter("@branchid", SqlDbType.VarChar, 25);
        sqlparm[2].Value = dd_branch.SelectedValue.ToString();

        sqlparm[3] = new SqlParameter("@bank", SqlDbType.VarChar, 25);
        sqlparm[3].Value = ddl_bank_name.SelectedValue.ToString();
        
        if(ddl_reimbursement_type.SelectedIndex == 0)
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_bankstatement_bank]", sqlparm);

        if (ddl_reimbursement_type.SelectedIndex == 1)
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_bankstatement_reimbursement]", sqlparm);
        //[sp_payroll_bankstatement_bonus]
        if (ddl_reimbursement_type.SelectedIndex == 2)
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_bankstatement_bonus]", sqlparm);
        
            bankgrid.DataSource = ds;
            bankgrid.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblbankname.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
            }
            else
            {
                lblbankname.Text = ddl_bank_name.SelectedItem.Text.ToString();
            }
        lblmonth.Text = ddlmonth.SelectedItem.Text.Trim().ToString() + '-' + dd_year.SelectedItem.Text.Trim().ToString();
    }

    protected void bind_month()
    {
        ddlmonth.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            ddlmonth.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        ddlmonth.SelectedValue = a.Month.ToString();
    }
    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        dd_branch.SelectedIndex = 0;
        dd_year.SelectedIndex = 0;
        //ddlmonth.SelectedIndex = 0;
        ddl_reimbursement_type.SelectedIndex = 0;
    }

    protected void bankgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        bankgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank---", "0"));
    }
    
    protected void exportexcel()
    {
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =BANKSTATEMENT.xls";
        //string filename = "attachment;filename =Attendance-1.xls";
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
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        bindgrid();
        exportexcel();
    }
}
