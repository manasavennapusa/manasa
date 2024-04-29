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
public partial class payroll_admin_employee_processed_attendance : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");

            for (int i = 1; i <= 12; i++)
            {
                ListItem item = new ListItem();
                item.Text = new DateTime(1900, i, 1).ToString("MMM");
                item.Value = i.ToString();
            dd_year.Items.Add(new ListItem(Convert.ToString(item.Text),Convert.ToString(item.Value)));
            }
            DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
            dd_year.SelectedValue = a.Month.ToString();
        }
    }

    protected void validate_dd()
    {
        if (Convert.ToInt32(dd_year.SelectedValue) > System.DateTime.Now.Month)
        {
            message.InnerHtml = "You can not process attendance for next month";
        }
        else
        {
            message.InnerHtml = "Attendance for selected month processed successully";
        }
    }

    protected void procedd_attendance()
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[0].Value = dd_year.SelectedItem.Text.ToString();

        sqlparam[1] = new SqlParameter("@sdate", SqlDbType.DateTime);
        sqlparam[1].Value = (Convert.ToInt32(dd_year.SelectedValue) - 1) +  "/26/"  + System.DateTime.Now.Year;

        sqlparam[2] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlparam[2].Value = dd_year.SelectedValue + "/25/" + System.DateTime.Now.Year;

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_process_employee_attendance", sqlparam);
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        validate_dd();
        procedd_attendance();

    }
}
