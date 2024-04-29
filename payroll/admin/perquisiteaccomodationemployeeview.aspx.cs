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
public partial class payroll_admin_perquisiteaccomodationemployeeview : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    DataTable dtable = new DataTable();
    DataView dview;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");
            Session.Remove("perquisite");
            binddata();
            btnsubmit.Enabled = false;
        }
    }
    protected void binddata()
    {
        sqlstr = "SELECT fyear,empcode,perqusite_id,amount_received amount,accommodation_id FROM tbl_payroll_employee_perquisite WHERE empcode='" + Request.QueryString["empcode"].ToString() + "' AND accommodation_id='" + Request.QueryString["accommodation_id"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        txt_employee.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        grid.DataSource = ds;
        grid.DataBind();
    }


    protected void clear()
    {
        //txtperquisiteamt.Text = "";
        //txtperquisiteamtreceived.Text = "";
        //ddlperquisitedetail.SelectedIndex = 0;
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void cal_accommodation()
    {

        DateTime start, end, yearend;
        int i = 0; string year; decimal amount, day;

        start = Convert.ToDateTime(txtleasefrom.Text);
        end = Convert.ToDateTime(txtleaseto.Text);

        amount = Convert.ToDecimal(txtamount.Text);

        if (start.Month > 3)
        {
            year = Convert.ToString(start.AddYears(1).Year);
        }
        else
        {
            year = Convert.ToString(start.Year);
        }


        System.TimeSpan diffStEnd = start - end;

        day = amount / (diffStEnd.Days - 1);

        yearend = Convert.ToDateTime(year + "-03-31");

        DataRow dr;
        if (Session["perquisite"] == null)
        {
            create_perquisite_table();
        }
        dtable = (DataTable)Session["perquisite"];

        while (i == 0)
        {
            if (end > yearend)
            {
                object[] keyArrary = new object[1];
                keyArrary[0] = start.Year + '-' + yearend.Year;

                DataRow drfind = dtable.Rows.Find(keyArrary);
                if (drfind != null)
                {
                    message.InnerHtml = "You can not add same peruisite detail.";
                }
                else
                {
                    System.TimeSpan diffStYrend = start - yearend;
                    dr = dtable.NewRow();
                    if (start.Month > 3)
                    {
                        dr["fyear"] = start.Year.ToString() + '-' + yearend.Year.ToString();
                    }
                    else
                    {
                        dr["fyear"] = start.AddYears(-1).Year.ToString() + '-' + yearend.Year.ToString();
                    }
                    dr["amount"] = System.Math.Round((diffStYrend.Days - 1) * day, 2);
                    dtable.Rows.Add(dr);

                    start = yearend.AddDays(1);
                    yearend = yearend.AddYears(1);
                }
            }
            else
            {
                object[] keyArrary = new object[1];
                keyArrary[0] = start.Year.ToString() + '-' + yearend.Year.ToString();

                DataRow drfind = dtable.Rows.Find(keyArrary);
                if (drfind != null)
                {
                    message.InnerHtml = "You can not add same peruisite detail.";
                }
                else
                {
                    diffStEnd = start - end;

                    dr = dtable.NewRow();
                    dr["fyear"] = start.Year.ToString() + '-' + yearend.Year.ToString();
                    dr["amount"] = System.Math.Round((diffStEnd.Days - 1) * day, 2);
                    dtable.Rows.Add(dr);
                    i = 1;
                }
            }
        }

        Session["perquisite"] = dtable;
        bindgrid();
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        cal_accommodation();
        btnsubmit.Enabled = true;
    }

    //----------------------------------------creating table-----------------------------------------
    protected void create_perquisite_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("fyear", typeof(string));
        dtable.Columns.Add("amount", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["fyear"] };
        Session["perquisite"] = dtable;
    }

    //----------------------------------Binding------------------------------------------
    protected void bindgrid()
    {
        if (Session["perquisite"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["perquisite"];
            dview = new DataView(dtable);
            dview.Sort = "fyear";
        }
        grid.DataSource = dview;
        grid.DataBind();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if ((Session["perquisite"] != null) && (Session["name"] != null))
        {
            sqlstr = "DELETE FROM tbl_payroll_employee_perquisite WHERE empcode='" + Request.QueryString["empcode"].ToString() + "' AND accommodation_id='" + Request.QueryString["accommodation_id"].ToString() + "'";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

            sqlstr = "DELETE FROM tbl_payroll_employee_perquisite_accommodation WHERE empcode='" + Request.QueryString["empcode"].ToString() + "' AND id='" + Request.QueryString["accommodation_id"].ToString() + "'";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
            

            SqlParameter[] sqlparam1;
            sqlparam1 = new SqlParameter[5];

            sqlparam1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam1[0].Value = txt_employee.Text.Trim().ToString();

            sqlparam1[1] = new SqlParameter("@leasefrom", SqlDbType.DateTime);
            sqlparam1[1].Value = Utilities.Utility.dataformat(txtleasefrom.Text.ToString());

            sqlparam1[2] = new SqlParameter("@leaseto", SqlDbType.DateTime);
            sqlparam1[2].Value = Utilities.Utility.dataformat(txtleaseto.Text.ToString());

            sqlparam1[3] = new SqlParameter("@amount", SqlDbType.Decimal);
            sqlparam1[3].Value = Convert.ToDecimal(txtamount.Text);

            sqlparam1[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparam1[4].Value = Session["name"].ToString();

            ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite_accommodation", sqlparam1);

            dtable = (DataTable)Session["perquisite"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[7];

                sqlparam[0] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                sqlparam[0].Value = dtable.Rows[i]["fyear"].ToString();

                sqlparam[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlparam[1].Value = txt_employee.Text.Trim().ToString();

                sqlparam[2] = new SqlParameter("@perqusite_id", SqlDbType.Int);
                sqlparam[2].Value = Convert.ToInt32(1);

                sqlparam[3] = new SqlParameter("@amount", SqlDbType.Decimal);
                sqlparam[3].Value = Convert.ToDecimal(0.00);

                sqlparam[4] = new SqlParameter("@amount_received", SqlDbType.Decimal);
                sqlparam[4].Value = Convert.ToDecimal(dtable.Rows[i]["amount"]);

                sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                sqlparam[5].Value = Session["name"].ToString();

                sqlparam[6] = new SqlParameter("@accommodation_id", SqlDbType.Int);
                sqlparam[6].Value = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite_accommodation_ref", sqlparam);
            }

            
            message.InnerHtml = " Perquisite for Employee has been created successfully";
        }
    }
}

