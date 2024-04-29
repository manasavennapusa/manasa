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
public partial class payroll_report_tax_variance_employee : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            
        }
    }

    protected void bindempdetail()
    {
        //sqlstr = "select year(getdate()) as year ,month(getdate()) as month";
        //ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);

        //int year, month,styear,endyear;
        //string fyear;
        //year = Convert.ToInt32(ds.Tables[0].Rows[0]["year"]);
        //month = Convert.ToInt32(ds.Tables[0].Rows[0]["month"]);

        //if (month < 4)
        //{
        //    styear=year-1;
        //    endyear=year;
        //    fyear = styear.ToString() + '-' + endyear.ToString();
        //}
        //else
        //{
        //    styear = year;
        //    endyear = year + 1;
        //    fyear = styear.ToString() + '-' + endyear.ToString();
        //}


        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = 0;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = 0;

        //sqlparam[3] = new SqlParameter("@declaration", SqlDbType.VarChar,25);
        //sqlparam[3].Value = ddldeclaration.SelectedValue;

        sqlparam[3] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[3].Value = 0;

        sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
        sqlparam[4].Value = dd_year.SelectedValue;

        //sqlparam[5] = new SqlParameter("@month", SqlDbType.VarChar, 25);
        //sqlparam[5].Value = dd_month.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_tax_variance_report_employee]", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void bind_emp_details()
    {
        SqlParameter[] sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();


        sqlparam[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
        sqlparam[1].Value = dd_year.SelectedValue;

        //sqlparam[5] = new SqlParameter("@month", SqlDbType.VarChar, 25);
        //sqlparam[5].Value = dd_month.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_tds_tax]", sqlparam);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblesttottax.Text = ds.Tables[0].Rows[0]["incometax"].ToString();
            lblestbaltax.Text = ds.Tables[0].Rows[0]["balance"].ToString();
            lblegrossamt.Text = ds.Tables[0].Rows[0]["gross_amount"].ToString();
            lblehraexemption.Text = ds.Tables[0].Rows[0]["hra_exemption"].ToString();
            lblestgrossamt.Text = ds.Tables[0].Rows[0]["tgross"].ToString();
            lblesttaxincome.Text = ds.Tables[0].Rows[0]["ttaxable_amount"].ToString();

            if (ds.Tables[1].Rows.Count > 0)
            {

                lbl80c.Text = ds.Tables[1].Rows[0]["80C"].ToString();
                lbl80ccc.Text = ds.Tables[1].Rows[0]["80CCC"].ToString();
                lbl80ccd.Text = ds.Tables[1].Rows[0]["80CCD"].ToString();
                lbl80d.Text = ds.Tables[1].Rows[0]["80D"].ToString();
                lbl80e.Text = ds.Tables[1].Rows[0]["80E"].ToString();
                lbl80dd.Text = ds.Tables[1].Rows[0]["80DD"].ToString();
                lbl80g.Text = ds.Tables[1].Rows[0]["80G"].ToString();
                lblinteresthouse.Text = ds.Tables[1].Rows[0]["interst_house"].ToString();
                lblchapter6a.Text = ds.Tables[1].Rows[0]["chapter6A"].ToString();
            }
            else
            {
                lbl80c.Text = "0.00";
                lbl80ccc.Text = "0.00";
                lbl80ccd.Text = "0.00";
                lbl80d.Text = "0.00";
                lbl80e.Text = "0.00";
                lbl80dd.Text = "0.00";
                lbl80g.Text = "0.00";
                lblinteresthouse.Text = "0.00";
                lblchapter6a.Text = "0.00";
            }
        }
        else
        {
            lblesttottax.Text = "0.00";
            lblestbaltax.Text = "0.00";
            lblegrossamt.Text = "0.00";
            lblehraexemption.Text = "0.00";
            lblestgrossamt.Text = "0.00";
            lblesttaxincome.Text = "0.00";

            lbl80c.Text = "0.00";
            lbl80ccc.Text = "0.00";
            lbl80ccd.Text = "0.00";
            lbl80d.Text = "0.00";
            lbl80e.Text = "0.00";
            lbl80dd.Text = "0.00";
            lbl80g.Text = "0.00";
            lblinteresthouse.Text = "0.00";
            lblchapter6a.Text = "0.00";
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        bindempdetail(); bind_emp_details();
    }

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    }
}
