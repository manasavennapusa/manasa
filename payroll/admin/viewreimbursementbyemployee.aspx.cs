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

public partial class payroll_admin_viewreimbursementbyemployee : System.Web.UI.Page
{
    string sqlstr, _userCode;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_employee_reimburesment();
        }
        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
    }

    protected void bind_employee_reimburesment()
    {
        sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = _userCode.ToString();


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_reimbursement_detail_employee", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
}