using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_editdepartmenttype : System.Web.UI.Page
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
                bind_departmenttype();
          
        }
    }
  

    private void bind_departmenttype()
    {
        string sqlstr = @"
SELECT 
tbl_internate_department_type.dept_type_id, 
tbl_internate_department_type.dept_type_name,
tbl_intranet_branch_detail.branch_name,
tbl_intranet_branch_detail.branch_id 
FROM tbl_intranet_branch_detail 
INNER JOIN dbo.tbl_internate_department_type 
ON tbl_intranet_branch_detail.branch_id = tbl_internate_department_type.branch_id 
where dept_type_id=" + Request.QueryString["dept_type_id"].ToString();

        try
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            txt_dept_typename.Text = ds.Tables[0].Rows[0]["dept_type_name"].ToString();

            drp_comp_name3.SelectedValue = ds.Tables[0].Rows[0]["branch_id"].ToString();
           
        }
        catch { }
    }
    //protected void drp_work_location_DataBound(object sender, EventArgs e)
    //{
    //    drp_work_location1.Items.Insert(0, new ListItem("--Select branch--", "0"));
    //}
    protected void btn_save_Click(object sender, EventArgs e)
    {
        insert_department_typedetail();
    }

    private void insert_department_typedetail()
    {
        //throw new NotImplementedException();
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@branch_id", SqlDbType.Int);
        sqlparam[0].Value = drp_comp_name3.SelectedValue;

        sqlparam[1] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();

        sqlparam[2] = new SqlParameter("@create_date", SqlDbType.DateTime);
        sqlparam[2].Value = DateTime.Now;

        sqlparam[3] = new SqlParameter("@updated_by", SqlDbType.VarChar, 50);
        sqlparam[3].Value = System.Data.SqlTypes.SqlString.Null;

        sqlparam[4] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[4].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[5] = new SqlParameter("@txt_dept_typename", SqlDbType.VarChar, 50);
        sqlparam[5].Value = txt_dept_typename.Text;

        sqlparam[6] = new SqlParameter("@dept_type_id", SqlDbType.Int);
        sqlparam[6].Value = Convert.ToInt32(Request.QueryString["dept_type_id"].ToString());

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_departmenttype", sqlparam);


        if (i <= 0)
        {
            message.InnerHtml = "Work Location code already exists, please enter another Work Location";
        }
        else
        {
            message.InnerHtml = "Company Work Location created successfully";
            reset();

            Response.Redirect("departmenttypeview.aspx?updated=true");
        }

    }

    private void reset()
    {
        drp_comp_name3.SelectedValue = "0";
        txt_dept_typename.Text = "";
    }

    protected void drp_comp_name3_DataBound(object sender, EventArgs e)
    {
        drp_comp_name3.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("departmenttypeview.aspx");
    }
}