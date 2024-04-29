using Common.Console;
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

public partial class admin_departmenttype : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
       // message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
               // Bind();

            }
            else
                Response.Redirect("~/notlogged.aspx");
           // drp_work_location.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }

    //private void Bind()
    //{
    //    string sqlstr = "select branch_id,branch_name from tbl_intranet_branch_detail";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //    drp_work_location.DataTextField = "branch_name";
    //    drp_work_location.DataValueField = "branch_id";
    //    drp_work_location.DataSource = ds;
    //    drp_work_location.DataBind();
    //    drp_work_location.Items.Insert(0, new ListItem("---Select---", "0"));
    //}


    protected void btn_save_Click(object sender, EventArgs e)
    {
        insert_department_type();
    }

    private void insert_department_type()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@branch_id", SqlDbType.Int);
        sqlparam[0].Value = drp_work_location.SelectedValue;

        sqlparam[1] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();

        sqlparam[2] = new SqlParameter("@create_date", SqlDbType.DateTime);
        sqlparam[2].Value = DateTime.Now;

        sqlparam[3] = new SqlParameter("@updated_by", SqlDbType.VarChar, 50);
        sqlparam[3].Value = System.Data.SqlTypes.SqlString.Null;

        sqlparam[4] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[4].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[5] = new SqlParameter("@txt_dept_typename", SqlDbType.VarChar,50);
        sqlparam[5].Value = txt_dept_typename.Text;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_department_type", sqlparam);


        if (i <= 0)
        {
            Output.Show("Department type code already exists, please enter another Work Location");
        }
        else
        {
            Output.Show("Created Successfully");
            reset();
        }
    }

    private void reset()
    {
        //drp_work_location.SelectedValue = "0";
        txt_dept_typename.Text = "";
    }
    //protected void drp_work_location_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //}
    protected void btnrest_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void drp_work_location_DataBound(object sender, EventArgs e)
    {
        drp_work_location.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void drp_work_location_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
