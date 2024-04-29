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


public partial class payroll_admin_viewtaxdeclarationstatus : System.Web.UI.Page
{
    string  _userCode;
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
           
        }
        if (Session["role"] != null)
        {

        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (Request.QueryString["message"] != null)
            message.InnerHtml = Request.QueryString["message"].ToString();

        
        bind_emp_declaration();
    }

    protected void bind_emp_declaration()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = _userCode;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_declaration_status", sqlparam);

        griddetail.DataSource = ds;
        griddetail.DataBind();
    }

    protected string linkviewdedit(string ref_no, string visiblity)
    {
        if (visiblity == "1")
        {
            return @"<a class='link05'   href='viewdeclarationdetail.aspx?ref_no=" + ref_no + @"' target='_self'>View</a>";
        }
        else
            return "No Links";
    }

}