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

public partial class admin_editeployeetype : System.Web.UI.Page
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
                bind_employeetype();

        }
    }

    //select emp_type_code,emp_type_name from tbl_internate_employee_type

    private void bind_employeetype()
    {
        string sqlstr = @"select emp_type_code,emp_type_name from tbl_internate_employee_type where emp_type_id=" + Request.QueryString["emp_type_id"].ToString();

        try
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            txt_discription.Text = ds.Tables[0].Rows[0]["emp_type_code"].ToString();
            txt_employeetype.Text = ds.Tables[0].Rows[0]["emp_type_name"].ToString();
          

        }
        catch { }
    }

    private void bind_departmenttype()
    {
       
    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
        inserte_employee_type();
    }

    private void inserte_employee_type()
    {
        SqlParameter[] sqlparam = new SqlParameter[8];

        sqlparam[0] = new SqlParameter("@emp_type_name", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employeetype.Text;

        sqlparam[1] = new SqlParameter("@create_by  ", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();

        sqlparam[2] = new SqlParameter("@create_date", SqlDbType.DateTime);
        sqlparam[2].Value = DateTime.Now;

        sqlparam[3] = new SqlParameter("@update_by", SqlDbType.VarChar, 50);
        sqlparam[3].Value = System.Data.SqlTypes.SqlString.Null;

        sqlparam[4] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[4].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[5] = new SqlParameter("@companyid", SqlDbType.Int);
        sqlparam[5].Value = Session["companyid"].ToString();

        sqlparam[6] = new SqlParameter("@emp_type_code", SqlDbType.VarChar, 50);
        sqlparam[6].Value = txt_discription.Text;

        sqlparam[7] = new SqlParameter("@emp_type_id", SqlDbType.Int);
        sqlparam[7].Value = Convert.ToInt32(Request.QueryString["emp_type_id"].ToString());

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_employeetype", sqlparam);


        if (i <= 0)
        {
            Output.Show("Work Location code already exists, please enter another Work Location");
        }
        else
        {
            Output.Show("Employee Type Master Updated Successfully!!!");
            //reset();

            Response.Redirect("employeetypeview.aspx?updated=true");
        }
       // reset();

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("employeetypeview.aspx");
    }
}