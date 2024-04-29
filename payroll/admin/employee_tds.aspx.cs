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

public partial class payroll_admin_employee_tds : System.Web.UI.Page
{
    string sqlstr = "";
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");

            bind_month(); 
            bind_year();
        }
    }

    //------------------------------- Bind Month in DropDownList ---------------------------------

    protected void bind_month()
    {
        dd_month.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month.SelectedValue = a.Month.ToString();
    }

    //------------------------------- Bind Year in DropDownList ---------------------------------
    
    protected void bind_year()
    {
        dd_year.Items.Insert(0, new ListItem("Select Year", "0"));
        for (int i = 2009; i <= 2015; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year.SelectedValue = a.Year.ToString();
    }

    //---------------------------------- Submit Employee TDS Detail --------------------------------------
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlParameter[] sqlparam = new SqlParameter[6];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = txt_employee.Text.ToString().Trim();

            sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
            sqlparam[1].Value = dd_month.SelectedValue;

            sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
            sqlparam[2].Value = dd_year.SelectedValue;

            sqlparam[3] = new SqlParameter("@amount", SqlDbType.Decimal);
            sqlparam[3].Value = txt_amnt.Text;

            sqlparam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
            sqlparam[4].Value = System.DateTime.Now;

            sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
            sqlparam[5].Value = Session["name"].ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tds", sqlparam);

            message.InnerHtml = "Employee TDS created successfully";

            clear();
        }
        catch
        {
            message.InnerHtml = "Repetition of  same entries is not allowed";
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }

    protected void clear()
    {
        txt_employee.Text = "";
        txt_amnt.Text = "";
        dd_month.SelectedValue = "0";
        dd_year.SelectedValue = "0";
    }
}
