using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.IO;
public partial class payroll_admin_uploadallowance_view : System.Web.UI.Page
{
    string sqlstr;
    SqlParameter[] sqlparm;
    DataSet ds = new DataSet();
    DataView dv = new DataView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            bind_PayheadName();
        }
    }
    
    protected void bind_PayheadName()
    {
        sqlstr = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where type=3 and status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpPayHead.DataTextField = "payhead_name";
        drpPayHead.DataValueField = "id";
        drpPayHead.DataSource = ds;
        drpPayHead.DataBind();
    }
   
    protected void bindadjustment()
    {
        sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
        sqlparm[1] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[2] = new SqlParameter("@year", dd_year.SelectedValue);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_uploaded_detail_view", sqlparm);


        if (ViewState["sortExpr"] != null)
        {
            dv = new DataView(ds.Tables[0]);
            dv.Sort = (string)ViewState["sortExpr"];
        }
        else
            dv = ds.Tables[0].DefaultView;

        adjustgrid.DataSource = dv;
        adjustgrid.DataBind();
    }
    
    protected void btn_view_Click(object sender, EventArgs e)
    {
        bindadjustment();
    }
    protected void adjustgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        adjustgrid.PageIndex = e.NewPageIndex;
        bindadjustment();
    }
    protected void adjustgrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortExpr"] = e.SortExpression;
        bindadjustment();
    }
    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Years---", "0"));
    }
    protected void drpPayHead_DataBound(object sender, EventArgs e)
    {
        drpPayHead.Items.Insert(0, new ListItem("---Select Allowance---", "0"));
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }

    protected void exportexcel()
    {
        //try
        //{
        //SqlParameter[] sqlparam = new SqlParameter[2];

        sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
        sqlparm[1] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[2] = new SqlParameter("@year", dd_year.SelectedValue);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_uploaded_detail_view", sqlparm);
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =ALLOWANCEDETAILS.xls";
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
        //}
        //catch
        //{
        //    message.InnerHtml = "Monthly TDS Detail Can not be exported";
        //}
    }
}


