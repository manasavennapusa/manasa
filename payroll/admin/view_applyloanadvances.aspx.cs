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

public partial class payroll_applyloanadvances : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               // if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
        }
        if (Request.QueryString["message"] != null)
            message.InnerHtml = Request.QueryString["message"].ToString();
    }

    protected void bind_loandetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@loanrefno", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_loanrefno.Text;

        sqlparam[1] = new SqlParameter("@empname", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text;

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[3].Value = dd_dept.SelectedValue;

        sqlparam[4] = new SqlParameter("@loanname", SqlDbType.Int);
        sqlparam[4].Value = dd_loanname.SelectedValue;

        sqlparam[5] = new SqlParameter("@sdate", SqlDbType.DateTime);
        if (txt_sdate.Text == "")
            sqlparam[5].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[5].Value = Convert.ToDateTime(txt_sdate.Text);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_loandetail", sqlparam);
        griddetail.DataSource = ds;
        griddetail.DataBind();        
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_loandetail();
    }

    protected void dd_loanname_DataBound(object sender, EventArgs e)
    {
        dd_loanname.Items.Insert(0, new ListItem("All", "0"));
        bind_loandetail();
    }   
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_dept_DataBound(object sender, EventArgs e)
    {
        dd_dept.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void griddetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetail.PageIndex = e.NewPageIndex;
        bind_loandetail();
    }
}
