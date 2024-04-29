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
using Utilities;

public partial class payroll_admin_AttendanceCumNightAllowance : System.Web.UI.Page
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
        //sqlparm[0] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
        sqlparm[0] = new SqlParameter("@fromdate", Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString());
        sqlparm[1] = new SqlParameter("@todate", Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString());
        sqlparm[2] = new SqlParameter("@branch", dd_designation.SelectedItem.Text);

        if (drpPayHead.SelectedIndex == 0)
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[payroll_night_allowance_sp]", sqlparm);
        }
        else
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[payroll_attendance_allowance_sp]", sqlparm);
        }
        
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =ATTENDANCECUMNIGHTALLOWANCE.xls";
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

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

}
