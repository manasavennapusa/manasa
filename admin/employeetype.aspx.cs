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

public partial class admin_employetype : System.Web.UI.Page
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

                //    Response.Redirect("~/Authenticate.aspx");
                // Bind();

            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
        inserte_employee_type();
    }

    private void inserte_employee_type()
    {
        SqlParameter[] sqlparam = new SqlParameter[7];

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

        sqlparam[6] = new SqlParameter("@discription", SqlDbType.VarChar,50);
        sqlparam[6].Value = txt_discription.Text;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_employee_type", sqlparam);

        if (i <= 0)
        {
            message.InnerHtml = "Employee Type name already exists, please enter another name";
        }
        else
        {
            Output.Show("Created Successfully");
            reset();
            return;
        }
       

    }

    private void reset()
    {
        txt_discription.Text = "";
        txt_employeetype.Text = "";
    }



    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
}