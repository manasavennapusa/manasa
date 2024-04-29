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
public partial class payroll_admin_create_view_graduity : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
           
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[3];
       
        sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedItem.Text);
        sqlparm[1] = new SqlParameter("@date", Utilities.Utility.dataformat(txtdate.Text.ToString()));
        sqlparm[2] = new SqlParameter("@user", Session["name"].ToString());

        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_gratuity]", sqlparm);
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        bindgrid();
        graduityview.Visible = true;
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedItem.Text);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_gratuity_show]", sqlparm);
        empgrid.DataSource = ds;
        empgrid.DataBind();

        lblgraduityamt.Text = ds.Tables[1].Rows[0]["Total_amt"].ToString();
        lblgraduitydate.Text = ds.Tables[1].Rows[0]["Date"].ToString();
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void exportexcel()
    {
        //try
        //{
        SqlParameter[] sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedItem.Text);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_gratuity_show]", sqlparm);
        
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =GRATUITY.xls";
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
    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }
}
