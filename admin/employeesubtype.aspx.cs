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

public partial class admin_employeesubtype : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

       // message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
                Bind();

            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    private void Bind()
    {
        string sqlstr = "select emp_type_id,emp_type_name from tbl_internate_employee_type";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        drpemployeetype.DataTextField = "emp_type_name";
        drpemployeetype.DataValueField = "emp_type_id";
        drpemployeetype.DataSource = ds;
        drpemployeetype.DataBind();
        drpemployeetype.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void btnsv_Click(object sender, EventArgs e)
    {
        insert_empsubdept();
    }

    private void insert_empsubdept()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@emp_type_id", SqlDbType.Int);
        sqlparam[0].Value = drpemployeetype.SelectedValue;

        sqlparam[1] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();

        sqlparam[2] = new SqlParameter("@create_date", SqlDbType.DateTime);
        sqlparam[2].Value = DateTime.Now;

        sqlparam[3] = new SqlParameter("@update_by", SqlDbType.VarChar, 50);
        sqlparam[3].Value = System.Data.SqlTypes.SqlString.Null;

        sqlparam[4] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[4].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[5] = new SqlParameter("@emp_subtype_name", SqlDbType.VarChar, 50);
        sqlparam[5].Value = txt_employeetype.Text;

  
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_employee_subtype", sqlparam);


        if (i <= 0)
        {
          Output.Show("Work Location code already exists, please enter another Work Location");
        }
        else
        {
            Output.Show("Created Successfully");
           reset();
        }
    }

    private void reset()
    {
        drpemployeetype.SelectedValue = "0";
        txt_employeetype.Text = "";
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
}