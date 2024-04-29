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

public partial class Admin_Company_createcompany : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
          

            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bind_department();
        }
    }

    public void btnsv_Click(object sender, EventArgs e)
    {
        edit_department_detail();
    }

    protected void bind_department()
    {
        string sqlstr = @"
select 
tbl_internate_departmentdetails.department_name,
tbl_internate_departmentdetails.department_code,
tbl_internate_department_type.dept_type_name,
tbl_internate_department_type.dept_type_id,
(CASE WHEN tbl_internate_departmentdetails.estt_date='01/01/1990' THEN '' ELSE CONVERT(CHAR(10), 
tbl_internate_departmentdetails.estt_date, 101) END)esstt_date
from 
tbl_internate_departmentdetails 
inner join tbl_internate_department_type 
on tbl_internate_department_type.dept_type_id=tbl_internate_departmentdetails.dept_type_id 
where departmentid =" + Request.QueryString["departmentid"].ToString();

        try
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            txt_branch_code.Text = ds.Tables[0].Rows[0]["department_code"].ToString();

            txt_branch_name.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            drp_comp_name.SelectedValue = ds.Tables[0].Rows[0]["dept_type_id"].ToString();

            txt_est_date.Text = ds.Tables[0].Rows[0]["esstt_date"].ToString();
        }
        catch { }
    }

    protected void edit_department_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@dept_type_id", SqlDbType.Int);
        sqlparam[0].Value = drp_comp_name.SelectedValue;

        sqlparam[1] = new SqlParameter("@department_name", SqlDbType.VarChar, 50);
        sqlparam[1].Value = txt_branch_name.Text;

        sqlparam[2] = new SqlParameter("@department_code", SqlDbType.VarChar, 50);
        sqlparam[2].Value = txt_branch_code.Text;

        if (txt_est_date.Text == "")
        {
            sqlparam[3] = new SqlParameter("@estt_date", SqlDbType.DateTime);
            sqlparam[3].Value = null;
        }
        else
        {
            sqlparam[3] = new SqlParameter("@estt_date", SqlDbType.DateTime);
            sqlparam[3].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
        }
        // sqlparam[3] = new SqlParameter("@estt_date", SqlDbType.DateTime);
        //sqlparam[3].Value =  Utilities.Utility.dataformat(txt_est_date.Text.ToString());

        sqlparam[4] = new SqlParameter("@departmentid", SqlDbType.Int);
        sqlparam[4].Value = Convert.ToInt32(Request.QueryString["departmentid"].ToString());

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_department", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_edit_department]", sqlparam);


        if (i <= 0)
        {
            SmartHr.Common.Alert(" Department name already exists, please enter another name.");
            //message.InnerHtml = "Department name already exists, please enter another name";
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully!!!");
            reset();

            Response.Redirect("departmentview.aspx?updated=true");
        }
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
        drp_comp_name.SelectedValue = "0";
    }

    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("departmentview.aspx");
    }
}
