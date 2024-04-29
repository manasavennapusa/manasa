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
using Utilities;
using System.IO;


public partial class payroll_admin_monthly_tds_challan_payment_edit : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    int challan_no;
    SqlParameter[] sqlparm;

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");

        challan_no = Convert.ToInt32(Request.QueryString["challan_no"]);

        if (!IsPostBack)
        {
            //sqlstr = "SELECT MAX(challan_no) FROM tbl_payroll_challan_no";
            //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);

            //lblchallanno.Text = ds.Tables[0].Rows[0][0].ToString();

            //bind_year();
            //bind_month();

            //Button2.Enabled = false;
            //Button1.Enabled = false;
            
            bindChallanMasterInfo();
            bindChallanDetailInfo();
        }
    }

    protected void bindChallanMasterInfo()
    {
        sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@challan_no", challan_no);
        
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_tds_monthlychallan_edit]", sqlparm);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            lblchallanno.Text = ds1.Tables[0].Rows[0]["challan_no"].ToString();
            lblFinancialYear.Text = ds1.Tables[0].Rows[0]["financial_year"].ToString();
            lblMonth.Text = ds1.Tables[0].Rows[0]["month"].ToString();
            lblCostCenter.Text = ds1.Tables[0].Rows[0]["cost_center_name"].ToString();

            griddetail.DataSource = ds1.Tables[1];
            griddetail.DataBind();
        }
    }

    protected void bindChallanDetailInfo()
    {
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@challan_no", challan_no);
        sqlparm[1] = new SqlParameter("@empcode", txtSearch.Text=="" ? "" : txtSearch.Text.Trim().ToString());

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_tds_monthlychallan_edit_search]", sqlparm);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            griddetail.DataSource = ds1.Tables[0];
            griddetail.DataBind();
        }
    }

    //protected void bind_year()
    //{
    //    sqlstr = "select [financial_year] as year from tbl_payroll_tax_master order by id desc";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    dd_year.DataTextField = "year";
    //    dd_year.DataValueField = "year";
    //    dd_year.DataSource = ds;
    //    dd_year.DataBind();
    //}

    //protected void bind_month()
    //{
    //    sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    dd_month.DataTextField = "month";
    //    dd_month.DataValueField = "month";
    //    dd_month.DataSource = ds;
    //    dd_month.DataBind();
    //}

    //protected void bind_tds_detail()
    //{
    //    try
    //    {
    //        SqlParameter[] sqlparam = new SqlParameter[3];

    //        sqlparam[0] = new SqlParameter("@financial_year_f", SqlDbType.VarChar, 50);
    //        sqlparam[0].Value = dd_year.SelectedValue;

    //        sqlparam[1] = new SqlParameter("@month_f", SqlDbType.VarChar, 50);
    //        sqlparam[1].Value = dd_month.SelectedItem.Text.ToString();

    //        sqlparam[2] = new SqlParameter("@costcenter_f", SqlDbType.Int);
    //        if ((drp_comp_name.SelectedIndex == 0) || (drp_comp_name.SelectedIndex == -1))
    //        {
    //            sqlparam[2].Value = 0;
    //        }
    //        else
    //        {
    //            sqlparam[2].Value = drp_comp_name.SelectedValue;
    //        }
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_emp_monthly_tds_fetch]", sqlparam);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            griddetail.DataSource = ds.Tables[0];
    //            griddetail.DataBind();

    //            Button2.Enabled = true;
    //            Button1.Enabled = true;
    //        }
    //        else
    //        {
    //            griddetail.DataSource = null;
    //            griddetail.DataBind();
    //            message.InnerHtml = "Monthly TDS Detail can not be viewed";
    //        }
    //        //GridView1.DataSource = ds.Tables[1];
    //        //GridView1.DataBind();
    //    }
    //    catch
    //    {
    //        message.InnerHtml = "Monthly TDS Detail can not be viewed";
    //    }
    //}


    //protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bind_month();
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    if (griddetail.Rows.Count < 1)
    //    {
    //        message.InnerHtml = "Monthly TDS Detail cannot be saved...";
    //        return;
    //    }
    //    generate_challan_tds();
    //}

    //protected DateTime dataformat(string date)
    //{
    //    string[] datesplit = date.Split('/');
    //    DateTime dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
    //    return dates;
    //}

    protected void griddetail_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        griddetail.PageIndex = e.NewPageIndex;
        bindChallanDetailInfo();
    }

    //protected void drp_comp_name_DataBound(object sender, EventArgs e)
    //{
    //    drp_comp_name.Items.Insert(0, new ListItem("--Select Cost Center--", "0"));
    //}

    //protected void drp_comp_name_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //bind_tds_detail();
    //}

    //protected void btnsearch_Click(object sender, EventArgs e)
    //{
    //    bind_tds_detail();
    //}

    protected void griddetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        griddetail.EditIndex = e.NewEditIndex;
        bindChallanDetailInfo();
    }

    protected void griddetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        griddetail.EditIndex = -1;
        bindChallanDetailInfo();
    }

    protected void griddetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        decimal education_cess, education_cess_per, surcharge, surcharge_limit, tds_rupees, tottds;
        sqlstr = @"select education_cess,surcharge,surcharge_limit		
	            from tbl_payroll_tax_master where financial_year='" + lblFinancialYear.Text.Trim().ToString() + "'";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        education_cess_per = Convert.ToDecimal(ds.Tables[0].Rows[0]["education_cess"].ToString());
        surcharge = Convert.ToDecimal(ds.Tables[0].Rows[0]["surcharge"].ToString());
        surcharge_limit = Convert.ToDecimal(ds.Tables[0].Rows[0]["surcharge_limit"].ToString());

        tds_rupees = Convert.ToDecimal(((TextBox)griddetail.Rows[e.RowIndex].Cells[3].Controls[1]).Text);
        tds_rupees = System.Math.Round(tds_rupees, 0);
        surcharge = 0.00M;
        education_cess = System.Math.Round((tds_rupees + surcharge) * education_cess_per / 100, 0);

        tottds = tds_rupees + surcharge + education_cess;

        string month = ((Label)griddetail.Rows[e.RowIndex].Cells[0].FindControl("lblmonthg")).Text;
        string financial_year = ((Label)griddetail.Rows[e.RowIndex].Cells[0].FindControl("lblfinancialyrg")).Text;
        string empcode = ((Label)griddetail.Rows[e.RowIndex].Cells[0].FindControl("lblempcodeg")).Text;

        sqlstr = "UPDATE tbl_payroll_employee_tdsmonthly_challan_detail SET tds_rupees='" + tds_rupees + "', surcharge='" + surcharge + "', education_cess='" + education_cess + "', total_tax='" + tottds + "' WHERE empcode='" + empcode.Trim() + "' and financial_year='" + financial_year.Trim().ToString() + "' and month='" + month.Trim().ToString() + "'";
        int a = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        griddetail.EditIndex = -1;
        bindChallanDetailInfo();
    }

    //protected void update_challan_no()
    //{
    //    string strupdate;
    //    int challan_no;
    //    strupdate = "SELECT MAX(challan_no) + 1 FROM tbl_payroll_challan_no";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, strupdate);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        challan_no = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
    //        strupdate = "UPDATE tbl_payroll_challan_no SET challan_no='" + challan_no + "'";
    //        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, strupdate);
    //    }
    //}

    //protected void generate_challan_tds()
    //{
    //    SqlParameter[] sqlparam;
    //    sqlparam = new SqlParameter[5];

    //    sqlparam[0] = new SqlParameter("@year", SqlDbType.VarChar);
    //    sqlparam[0].Value = dd_year.SelectedValue;

    //    sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar);
    //    sqlparam[1].Value = dd_month.SelectedValue;

    //    sqlparam[2] = new SqlParameter("@modifiedby", SqlDbType.VarChar);
    //    sqlparam[2].Value = Session["name"].ToString();

    //    sqlparam[3] = new SqlParameter("@branch", SqlDbType.VarChar);
    //    sqlparam[3].Value = drp_comp_name.SelectedValue;

    //    sqlparam[4] = new SqlParameter("@challanno", SqlDbType.Int);
    //    sqlparam[4].Value = lblchallanno.Text.Trim();

    //    int a = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_tds_monthlychallan_insert]", sqlparam);

    //    if (a != 0)
    //    {
    //        generate_challan_tds_detail();
    //        update_challan_no();
    //        message.InnerHtml = "Monthly Challan Saved Successfully...";
    //    }
    //    else
    //        message.InnerHtml = "Monthly Challan Has Not Been Saved...";
    //}

    //protected void generate_challan_tds_detail()
    //{
    //    try
    //    {
    //        int counter = 0;
    //        foreach (GridViewRow GridView in griddetail.Rows)
    //        {
    //            CheckBox checkg = (CheckBox)griddetail.Rows[counter].Cells[0].FindControl("chkempcode");

    //            if (checkg.Checked)
    //            {
    //                string strempcode, strmonth, stryear;
    //                strempcode = ((Label)griddetail.Rows[counter].FindControl("lblempcodeg")).Text;
    //                strmonth = ((Label)griddetail.Rows[counter].FindControl("lblmonthg")).Text;
    //                stryear = ((Label)griddetail.Rows[counter].FindControl("lblfinancialyrg")).Text;

    //                sqlstr = "UPDATE tbl_payroll_employee_tdsmonthly_challan_detail SET status = 0 , challan_no='" + lblchallanno.Text.Trim().ToString() + "' WHERE empcode='" + strempcode + "' AND month='" + strmonth + "' AND financial_year='" + stryear + "'";
    //                int a = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
    //            }
    //            counter = counter + 1;
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    protected void search_Click(object sender, EventArgs e)
    {
        bindChallanDetailInfo();
    }
}
