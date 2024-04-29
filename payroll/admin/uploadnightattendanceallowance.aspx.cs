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
public partial class payroll_admin_uploadnightattendanceallowance : System.Web.UI.Page
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
        //message.InnerHtml = "";
        if (!IsPostBack)
        {
            bind_PayheadName();
            //current_month();//22Sep2010
            bind_fyear();
        }
    }
    protected void bind_fyear()
    {
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
            lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        else
            lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }
    protected void current_month()
    {
        DateTime dt = DateTime.Now;
        DateTime da = new DateTime(dt.Year, dt.Month, 1);

        if (Convert.ToInt16(dt.Day) > da.AddMonths(1).AddDays(-1).Day)
            dt = dt.AddMonths(1);
        ////if (Convert.ToInt16(dt.Day) >= 30)
        //  //  dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
    protected void bind_PayheadName()
    {
        sqlstr = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where type=3 and id in(16,22) and status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpPayHead.DataTextField = "payhead_name";
        drpPayHead.DataValueField = "id";
        drpPayHead.DataSource = ds;
        drpPayHead.DataBind();
    }

    
    protected void btn_view_Click(object sender, EventArgs e)
    {
        exportexcel();
        
    }
    protected void exportexcel()
    {
        if (drpPayHead.SelectedIndex != 0)
        {
            if (drpPayHead.SelectedValue == "16")
                sqlparm = new SqlParameter[8];
            else
                sqlparm = new SqlParameter[7];
            sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
            sqlparm[1] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());
            sqlparm[2] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
            sqlparm[3] = new SqlParameter("@allowancename", drpPayHead.SelectedItem.Text);
            sqlparm[4] = new SqlParameter("@branch_id", drp_comp_name.SelectedValue);
            sqlparm[5] = new SqlParameter("@name", Session["name"].ToString());
            sqlparm[6] = new SqlParameter("@month_num", Convert.ToInt32(dd_month.SelectedValue));
            if (drpPayHead.SelectedValue == "16")
                sqlparm[7] = new SqlParameter("@amount", txtamount.Text.Trim().ToString());
            //else
            //{
            //    sqlparm[6] = new SqlParameter("@amount", SqlDbType.Decimal);
            //    sqlparm[6].Value = 0.0;
            //}

            if (drpPayHead.SelectedValue == "14")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_autocreate_nightallowance_amount]", sqlparm);
            }
            if (drpPayHead.SelectedValue == "15")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_autocreate_attendance_amount]", sqlparm);
            }
            if (drpPayHead.SelectedValue == "16")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_autocreate_productionincentive_amount]", sqlparm);
            }
            if (drpPayHead.SelectedValue == "22")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_autocreate_canteen_amount]", sqlparm);
            }
        }

        string filename ="attachment;" +  drpPayHead.SelectedItem.Text.ToString() + "-" + dd_month.SelectedItem.Text + ".xls";

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        
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
    //protected void dd_year_DataBound(object sender, EventArgs e)
    //{
    //    dd_year.Items.Insert(0, new ListItem("---Select Financial Years---", "0"));
    //}
    protected void drpPayHead_DataBound(object sender, EventArgs e)
    {
        drpPayHead.Items.Insert(0, new ListItem("---Select Allowance---", "0"));
    }
    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }
   
    protected void drpPayHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPayHead.SelectedValue == "16")
            tramount.Visible = true;
        else
            tramount.Visible = false;
    }
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
    }
}



