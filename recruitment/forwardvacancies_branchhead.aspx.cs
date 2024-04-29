using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_forwardvacancies_branchhead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            binddepartment();
            bind_location();
            bindapprover();
            bindOrgheads();
            bind_RRF();
        }

    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void btn_Sumbit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        if (txt_fromdate.Text != "")
            sqlparam[0].Value = txt_fromdate.Text;
        else
            sqlparam[0].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[1] = new SqlParameter("@todate", SqlDbType.DateTime);
        if (txt_todate.Text != "")
            sqlparam[1].Value = txt_todate.Text;
        else
            sqlparam[1].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = ddl_dept.SelectedValue;

        sqlparam[3] = new SqlParameter("@location", SqlDbType.Int);
        sqlparam[3].Value = ddl_location.SelectedValue;

        sqlparam[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[4].Value = ddl_raiser.SelectedValue.Trim();

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitmnet_search_rrf", sqlparam);
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
       // cleartext();

    }
    private void cleartext()
    {
        txt_fromdate.Text = "";
        txt_todate.Text = "";
        ddl_raiser.SelectedValue = "0";
        ddl_location.SelectedValue = "0";
        ddl_dept.SelectedValue = "0";
    }
    protected void binddepartment()
    {
        string sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_dept.DataTextField = "department_name";
        ddl_dept.DataValueField = "departmentid";
        ddl_dept.DataSource = ds;
        ddl_dept.DataBind();
        ddl_dept.Items.Insert(0, new ListItem("--ALL--", "0"));
    }


    protected void bindapprover()
    {
        string sqlstr = "select empcode,emp_fname+''+emp_m_name+''+emp_l_name as name from dbo.tbl_intranet_employee_jobDetails";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_raiser.DataTextField = "name";
        ddl_raiser.DataValueField = "empcode";
        ddl_raiser.DataSource = ds;
        ddl_raiser.DataBind();
        ddl_raiser.Items.Insert(0, new ListItem("--ALL--", "0"));
    }
    protected void bindOrgheads()
    {
        string sqlstr = "select empcode,emp_fname+''+emp_m_name+''+emp_l_name as name from dbo.tbl_intranet_employee_jobDetails";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_org_head.DataTextField = "name";
        ddl_org_head.DataValueField = "empcode";
        ddl_org_head.DataSource = ds;
        ddl_org_head.DataBind();
        ddl_org_head.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_location()
    {
        string sqlstr = "select cid,city from tbl_intranet_city ";
        DataSet ds7 = new DataSet();
        ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_location.DataSource = ds7;
        ddl_location.DataTextField = "city";
        ddl_location.DataValueField = "cid";
        ddl_location.DataBind();
        ddl_location.Items.Insert(0, new ListItem("--ALL--", "0"));

    }

    protected void bind_RRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRFs_by_HR_from_Approver1");
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdRRF.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxRows.Checked == true)
            {
                HiddenField id = (HiddenField)row.FindControl("hfid");
                int RRF_ID =Convert.ToInt32(id.Value);
                string sqlstr = "update tbl_recruitment_requisition_form set approver2='"+ddl_org_head.SelectedValue+"' where id='" + RRF_ID + "'";
                DataSet ds = new DataSet();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                
            }
        }
        bind_RRF();
    }
}