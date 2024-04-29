using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Configuration;

public partial class appraisal_AppraisalEmployeeReport : System.Web.UI.Page
{
    string CompanyId, RoleId = "";
    string sqlstr;
    DataSet ds;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null && Session["role"] != null)
        {
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();


            if (!IsPostBack)
            {
                // month();
                //Year();
                getActiveCycle();
                ddlAppraisalCycle.Items.Insert(0, new ListItem("--Select--", "0"));
            }

        
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }

    private void getActiveCycle()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select appcycle_id, from_month +'-'+ from_year +' to '+ to_month +'-'+ to_year appcyclename ,APP_year
                                     from tbl_appraisal_cycle 
                                      where status = 1
                                       order by appcycle_id desc";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                ddlAppraisalCycle.DataSource = dt;
                ddlAppraisalCycle.DataValueField = "appcycle_id";
                ddlAppraisalCycle.DataTextField = "APP_year";
                ddlAppraisalCycle.DataBind();
            }
        }
    }

    protected void btnreport_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void bindgrid()
    {
        //string type = "0";
        //string empcode = txt_employee.Text.Trim();
        //string branch = drpbranch.SelectedValue;
        //string depttype = ddldepatrtmenttype.SelectedValue;
        //string dept = drpdepartment.SelectedValue;
        //string month = dd_month.SelectedValue;
        string year = ddlAppraisalCycle.SelectedItem.Text;
        string quarter = ddl_quarter.SelectedItem.Text;
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'EmployeeAppraisalReport.aspx?Quarter=" + quarter + "&Year=" + year + "', null, 'height=600,width=1260,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }
}