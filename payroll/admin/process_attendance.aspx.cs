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
using System.Data.OleDb;
using System.Linq;

public partial class payroll_admin_process_attendance : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_message.Text = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");
            //current_month(); //22Sep2010
        }
        bind_fyear();
        //validate_attendance();
    }

    protected void current_month()
    {
        DateTime dt = DateTime.Now;

        DateTime da = new DateTime(dt.Year, dt.Month, 1);

        if (Convert.ToInt16(dt.Day) > da.AddMonths(1).AddDays(-1).Day)
            dt = dt.AddMonths(1);
        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
    protected void bind_fyear()
    {

        int year = DateTime.Now.Year, count = 1;
        lbl_fyear.Items.Insert(0, new ListItem("---select---"));

        for (int i = year-1; i < year + 5; i++)
        {
            lbl_fyear.Items.Insert(count, new ListItem(i.ToString() + "-" + (i + 1).ToString()));
            count++;
        }
        //DateTime dt = DateTime.Now;

        //if (Convert.ToInt16(dt.Day) > 30)
        //    dt = dt.AddMonths(1);

        //if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
        //{
        //    lbl.Text = dt.Year + "-" + dt.AddYears(1).Year;
        //    lbl_fyear.DataSource = Enumerable.Range(1990, DateTime.Now.Year);
        //    lbl_fyear.DataBind();
        //}
        //else
        //    lbl.Text = dt.AddYears(-1).Year + "-" + dt.Year;
        //    lbl_fyear.DataSource = Enumerable.Range(2000, DateTime.Now.Year);
        //    lbl_fyear.DataBind();
    }
    protected void validate_attendance()
    {
        sqlstr = "select count(MONTH) as rows from tbl_payroll_employee_attendence_detail where MONTH='" + dd_month.SelectedItem.Text.ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //******************  Case 1: when there is data for the selected month for attendance in tbl_payroll_employee_attendence **************// 

        if (Convert.ToInt16(ds.Tables[0].Rows[0]["rows"]) > 0)
        {
            sqlstr = "select count(MONTH) as salary_rows from tbl_payroll_employee_salary where MONTH='" + dd_month.SelectedItem.Text.ToString() + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            //******************  Case 2: when there is  data for slected month for salary in tbl_payroll_employee_salary **************// 

            if (Convert.ToInt16(ds.Tables[0].Rows[0]["salary_rows"]) > 0)
            {
                btn_procs_att.Enabled = false;
                btn_procs_salary.Enabled = false;
                btn_reprocs_att.Enabled = true;
                btn_reprocs_salary.Enabled = true;
            }
            //******************  Case 3: when there is no data for slected month for salary in tbl_payroll_employee_salary **************// 
            else
            {
                btn_procs_salary.Enabled = true;
                btn_reprocs_salary.Enabled = false;
                btn_procs_att.Enabled = false;
                btn_reprocs_att.Enabled = true;
            }
        }
        //******************  Case 4: when there is no data for slected month for attendance in tbl_payroll_employee_salary **************// 

        else
        {
            btn_procs_att.Enabled = true;
            btn_procs_salary.Enabled = false;
            btn_reprocs_att.Enabled = false;
            btn_reprocs_salary.Enabled = false;
        }
    }

    protected void bind_attendance()
    {
        //string fyer = lbl_fyear.Text.Trim().ToString();
        //string[] mob = fyer.Split('-');
        //int year = Convert.ToInt32(mob[0].ToString());

        //DateTime dt = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), 25);
        //DateTime dt2 = dt.AddMonths(-1).AddDays(1);

        string fyer = lbl_fyear.Text.Trim().ToString();
        string[] mob = fyer.Split('-');
        int year;

        if (Convert.ToInt32(dd_month.SelectedValue) <= 3)
        {
            year = Convert.ToInt32(mob[1].ToString());
        }
        else
        {
            year = Convert.ToInt32(mob[0].ToString());
        }

        int dtNow = DateTime.DaysInMonth(year, Convert.ToInt32(dd_month.SelectedValue));
        DateTime dt = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), 01);
        DateTime dt2 = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), dtNow);


        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlparam[0].Value = dt2;

        sqlparam[1] = new SqlParameter("@sdate", SqlDbType.DateTime);
        sqlparam[1].Value = dt;

        sqlparam[2] = new SqlParameter("@FYEAR", SqlDbType.VarChar, 50);
        sqlparam[2].Value = lbl_fyear.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_month.SelectedItem.Text;

        sqlparam[4] = new SqlParameter("@branchid", SqlDbType.Int);
        if (ddlbranch.SelectedIndex != 0)
        {
            sqlparam[4].Value = ddlbranch.SelectedValue;
        }
        else
        {
            sqlparam[4].Value = 0;
        }

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_attendance]", sqlparam);

        //    SqlParameter[] sqlparam;
        //    sqlparam = new SqlParameter[3];

        //    sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //    sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();

        //    sqlparam[1] = new SqlParameter("@enddate", SqlDbType.DateTime);
        //    sqlparam[1].Value = dt;

        //    sqlparam[2] = new SqlParameter("@sdate", SqlDbType.DateTime);
        //    sqlparam[2].Value = dt2;


        //DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_process_employee_attendance", sqlparam); 
    }
    protected void btn_reprocs_att_Click(object sender, EventArgs e)
    {
        bind_attendance();
        lbl_message.Text = lbl_message.Text = "Attendance re-processed successfully";
        //validate_attendance();
    }
    protected void btn_procs_att_Click(object sender, EventArgs e)
    {
        bind_attendance();
        bindgrid();
        lbl_message.Text = lbl_message.Text = "Attendance processed successfully";
        //validate_attendance();
    }

    protected void bind_salary()
    {
        if (Session["name"] != null)
        {
            string fyer = lbl_fyear.Text.Trim().ToString();
            string[] mob = fyer.Split('-');
            int year = Convert.ToInt32(mob[0].ToString());

            int dtNow = DateTime.DaysInMonth(year, Convert.ToInt32(dd_month.SelectedValue));
            DateTime dt = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), 01);
            DateTime dt2 = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), dtNow);


            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[6];

            sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
            sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();

            sqlparam[1] = new SqlParameter("@TODATE", SqlDbType.DateTime);
            sqlparam[1].Value = dt2;

            sqlparam[2] = new SqlParameter("@FROMDATE", SqlDbType.DateTime);
            sqlparam[2].Value = dt;

            sqlparam[3] = new SqlParameter("@user", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["name"].ToString();

            sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
            sqlparam[4].Value = lbl_fyear.Text;

            sqlparam[5] = new SqlParameter("@branchid", SqlDbType.Int);
            if (ddlbranch.SelectedIndex != 0)
            {
                sqlparam[5].Value = ddlbranch.SelectedValue;
            }
            else
            {
                sqlparam[5].Value = 0;
            }

            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_EMPLOYEE_SALARY_GENERATE", sqlparam);
        }
    }
    protected void btn_procs_salary_Click(object sender, EventArgs e)
    {
        bind_salary();
        lbl_message.Text = "Salary processed successfully";
        //validate_attendance();
    }
    protected void btn_reprocs_salary_Click(object sender, EventArgs e)
    {
        bind_salary();
        lbl_message.Text = "Salary re-processed successfully";
        //validate_attendance();
    }
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
        //validate_attendance();
    }

    //protected void find_end_start_date()
    //{
    //    DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 24);
    //    DateTime dt2 = dt.AddMonths(-1).AddDays(1);


    //}
    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }

    protected bool uploaddocument()
    {
        string file_name, fn, ftype;
        if (fupload.PostedFile.FileName.ToString() != "")
        {
            fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
            ftype = System.IO.Path.GetExtension(fn);
            switch (ftype)
            {
                case ".xlsx":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\" + fn;
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());

                        lbl_message.Text = "";
                        return true;
                        //break;
                    }
                case ".xls":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\" + fn;
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());

                        lbl_message.Text = "";
                        return true;
                        //break;
                    }
                default:
                    {
                        lbl_message.Text = "";
                        lbl_message.Text = "Only Excel File can be uploaded";
                        return false;
                        //break;
                    }
            }
            return true;
        }
        return true;
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
        try
        {
            if (uploaddocument())
            {
                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    string file = Server.MapPath(".") + "/upload/" + fupload.PostedFile.FileName;
                    String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                    OleDbConnection objconn = new OleDbConnection(strConn);
                    objconn.Open();
                    OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [sheet1$]", objconn);
                    OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                    objadapter1.SelectCommand = objcmdselect;
                    DataSet dds = new DataSet();
                    objadapter1.Fill(dds, "Attendance");
                    objconn.Close();

                    string fyer = lbl_fyear.Text.Trim().ToString();
                    string[] mob = fyer.Split('-');
                    int year;

                    if (Convert.ToInt32(dd_month.SelectedValue) <= 3)
                    {
                        year = Convert.ToInt32(mob[1].ToString());
                    }
                    else
                    {
                        year = Convert.ToInt32(mob[0].ToString());
                    }

                    int dtNow = DateTime.DaysInMonth(year, Convert.ToInt32(dd_month.SelectedValue));
                    DateTime dt = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), 01);
                    DateTime dt2 = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), dtNow);
                    //DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
                    //DateTime dt2 = dt.AddMonths(-1).AddDays(1);

                    for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                    {
                        SqlParameter[] sqlparm = new SqlParameter[7];
                        sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["empcode"].ToString().Trim());
                        sqlparm[1] = new SqlParameter("@lwp", dds.Tables[0].Rows[i]["lwp"].ToString());
                        sqlparm[2] = new SqlParameter("@working_days", dds.Tables[0].Rows[i]["days"].ToString());
                        sqlparm[3] = new SqlParameter("@fromdate", dt);
                        sqlparm[4] = new SqlParameter("@todate", dt2);
                        sqlparm[5] = new SqlParameter("@month", dd_month.SelectedItem.Text);
                        sqlparm[6] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());


                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_import_attendance]", sqlparm);
                    }
                    lbl_message.Text = "Attendance Data Uploaded Successfully!!!";
                    bindgrid();
                }
            }
        }
        catch (Exception ex)
        {
            lbl_message.Text = "Please check Excel format.There must be three fields named empcode,lwp and days with sheet named SHEET1.There should not be blank data.";
        }
        //}
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[2];


        sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[1] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bind_attendance]", sqlparm);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void exportexcel()
    {
        //     string filename = "Process Attendance Details Report for Month :- " + dd_month.SelectedItem.Text;

        SqlParameter[] sqlparm = new SqlParameter[2];

        sqlparm[0] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[1] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bind_attendance]", sqlparm);

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =Attendance-1.xls";
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
