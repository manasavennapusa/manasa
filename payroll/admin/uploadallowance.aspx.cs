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
public partial class payroll_admin_viewbankmaster : System.Web.UI.Page
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
            //current_month();//22Sep2010
            bind_fyear();
        }
    }
    protected void bind_fyear()
    {
        int year = DateTime.Now.Year, count = 1;
        lbl_fyear.Items.Insert(0, new ListItem("---select---"));

        for (int i = year - 1; i < year + 5; i++)
        {
            lbl_fyear.Items.Insert(count, new ListItem(i.ToString() + "-" + (i + 1).ToString()));
            count++;
        }
        //DateTime dt = DateTime.Now;

        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        //if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
        //    lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        //else
        //    lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
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
    //protected void bind_fyear()
    //{
    //    DateTime dt = DateTime.Now;

    //    if (Convert.ToInt16(dt.Day) >= 30)
    //        dt = dt.AddMonths(1);

    //    if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
    //        lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
    //    else
    //        lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    //}
    protected void bind_PayheadName()
    {
        sqlstr = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where status=1 and type=3";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpPayHead.DataTextField = "payhead_name";
        drpPayHead.DataValueField = "id";
        drpPayHead.DataSource = ds;
        drpPayHead.DataBind();
    }
    //protected void bind_year()
    //{
    //    sqlstr = "select distinct year from tbl_payroll_employee_salary";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    dd_year.DataTextField = "year";
    //    dd_year.DataValueField = "year";
    //    dd_year.DataSource = ds;
    //    dd_year.DataBind();
    //}
    protected void btnsv_Click(object sender, EventArgs e)
    {
        string Version = "none";

        string Path = "";
        if (fupload.HasFile)
        {
            if (UploadDocument(ref Version, ref Path))
            {
                string ConnectionString = GetConnection(Version, Path);


                try
                {
                    //string file = Server.MapPath(".") + "/upload/allowances.xls";
                    //String strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Server.MapPath(".") + "\\upload\\allowances.xls';Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                    //OleDbConnection objconn = new OleDbConnection(strConn);
                    //objconn.Open();
                    // OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [sheet1$]", objconn);
                    //OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                    //objadapter1.SelectCommand = objcmdselect;
                    //DataSet dds = new DataSet();
                    //objadapter1.Fill(dds, "Allowances");
                    //objconn.Close();


                    DataTable[] dt = new DataTable[1];

                    dt[0] = GetExcelDate("SELECT * FROM [sheet1$]", ConnectionString);

                    foreach (DataRow row in dt[0].Rows)
                    {

                        if (row["empcode"].ToString().Trim() != "")
                        {
                            sqlparm = new SqlParameter[7];
                            sqlparm[0] = new SqlParameter("@empcode", row["empcode"].ToString().Trim());
                            sqlparm[1] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
                            sqlparm[2] = new SqlParameter("@allowancename", drpPayHead.SelectedItem.Text);
                            sqlparm[3] = new SqlParameter("@amount", row["amount"].ToString().Trim());
                            sqlparm[4] = new SqlParameter("@month", dd_month.SelectedItem.Text);
                            sqlparm[5] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());
                            sqlparm[6] = new SqlParameter("@modifiedby", "Raghavendra CN");
                            //try
                            //{
                            if (sqlparm[0].Value.ToString().Trim() != "")
                            {
                                if (sqlparm[3].Value == "") sqlparm[3].Value = "0.00";
                                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_importallowance", sqlparm);

                            }
                            else
                            {
                                SqlParameter[] sqlparm1 = new SqlParameter[3];
                                sqlparm1[0] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
                                sqlparm1[1] = new SqlParameter("@month", dd_month.SelectedItem.Text);
                                sqlparm1[2] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());
                                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, "delete from tbl_payroll_allowance_detail where year=@year and allowanceid=@allowanceid and month=@month", sqlparm1);
                                //Response.Write("<script>alert('Please check format of empcode in excel');</script>");
                                message.InnerHtml = "Please check format of empcode in excel";
                                return;
                            }
                        }
                        message.InnerHtml = drpPayHead.SelectedItem.Text + " data  uploaded successfully!";

                        //FileInfo TheFile = new FileInfo(Server.MapPath(".") + "/upload/allowances.xls");
                        //if (TheFile.Exists)
                        //{
                        //    File.Delete(Server.MapPath(".") + "/upload/allowances.xls");
                        //} 
                        bindadjustment();
                    }
                }
                catch (Exception ex)
                {
                    message.InnerHtml = "Please check excel name should be allowances.xls and sheet name be sheet1";
                }
            }
        }
    }
    private DataTable GetExcelDate(string Command, string ConnectionString)
    {
        DataSet ds = new DataSet();

        try
        {
            OleDbConnection Connection = new OleDbConnection(ConnectionString);
            Connection.Open();
            OleDbCommand Cmd = new OleDbCommand(Command, Connection);
            OleDbDataAdapter oda = new OleDbDataAdapter(Cmd);
            oda.Fill(ds);
        }
        catch (Exception ex)
        {
            message.InnerHtml = "During GetExcelData: " + ex.Message + ".    " + DateTime.Now;
        }
        DataTable dt = new DataTable();
        dt = null;
        if (ds.Tables.Count > 0)
            dt = ds.Tables[0];
        return dt;


    }
    private string GetConnection(string version, string Path)
    {

        if (version == "4.0")
        {
            // I will add later.
            return "";
        }
        else if (version == "12.0")
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Trim() + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
        }
        else
        {
            // Display message - Suitable version needed.
            return "";
        }
    }
    protected bool UploadDocument(ref string version, ref string path)
    {
        try
        {
            string file_name, fn, ftype;
            bool flag = false;
            if (fupload.PostedFile.FileName.ToString() != "")
            {
                fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
                ftype = System.IO.Path.GetExtension(fn);
                switch (ftype)
                {
                    case ".xls":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                            fupload.PostedFile.SaveAs(file_name);
                            ViewState.Add("file_name", fn.ToString());
                            flag = true;
                            version = "4.0";
                            path = file_name;
                            break;
                        }
                    case ".xlsx":
                        {
                            System.IO.File.Delete(fn);
                            file_name = Server.MapPath(".") + "\\upload\\" + System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                            //  file_name = Server.MapPath(".") + "\\upload\\" + flEmployee.FileName + DateTime.Now.ToString();
                            fupload.PostedFile.SaveAs(file_name);
                            ViewState.Add("file_name", fn.ToString());
                            version = "12.0";
                            path = file_name;
                            flag = true;
                            break;

                        }
                    default:
                        {
                            version = "none";
                            path = "";
                            flag = false;
                            break;
                        }
                }

            }
            return flag;
        }
        catch (Exception ex)
        {
            message.InnerHtml = "connection prob";
            return false;
        }

    }

    protected void bindadjustment()
    {
        sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
        sqlparm[1] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[2] = new SqlParameter("@year", lbl_fyear.Text.Trim().ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_uploaded_detail", sqlparm);


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
    protected void adjustgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        adjustgrid.EditIndex = -1;
        bindadjustment();
    }
    protected void adjustgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@empcode", adjustgrid.DataKeys[e.RowIndex][0]);
        sqlparm[1] = new SqlParameter("@allowanceid", adjustgrid.DataKeys[e.RowIndex][1]);
        sqlparm[2] = new SqlParameter("@month", adjustgrid.DataKeys[e.RowIndex][2]);
        sqlparm[3] = new SqlParameter("@year", adjustgrid.DataKeys[e.RowIndex][3]);
        sqlstr = "delete from tbl_payroll_allowance_detail where empcode=@empcode and allowanceid=@allowanceid and month=@month and @year=@year";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
        bindadjustment();
    }
    protected void adjustgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        adjustgrid.EditIndex = e.NewEditIndex;
        bindadjustment();
    }
    protected void adjustgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        sqlparm = new SqlParameter[5];
        sqlparm[0] = new SqlParameter("@empcode", adjustgrid.DataKeys[e.RowIndex][0]);
        sqlparm[1] = new SqlParameter("@allowanceid", adjustgrid.DataKeys[e.RowIndex][1]);
        sqlparm[2] = new SqlParameter("@month", adjustgrid.DataKeys[e.RowIndex][2]);
        sqlparm[3] = new SqlParameter("@year", adjustgrid.DataKeys[e.RowIndex][3]);
        sqlparm[4] = new SqlParameter("@amount", ((TextBox)adjustgrid.Rows[e.RowIndex].Cells[3].Controls[1]).Text);
        sqlstr = "update tbl_payroll_allowance_detail set amount=@amount where empcode=@empcode and allowanceid=@allowanceid and month=@month and @year=@year";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
        adjustgrid.EditIndex = -1;
        bindadjustment();

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
    //protected void dd_year_DataBound(object sender, EventArgs e)
    //{
    //    dd_year.Items.Insert(0, new ListItem("---Select Financial Years---", "0"));
    //}
    protected void drpPayHead_DataBound(object sender, EventArgs e)
    {
        drpPayHead.Items.Insert(0, new ListItem("---Select Allowance---", "0"));
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
    }
}



