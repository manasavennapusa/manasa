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

public partial class admin_editemployeesubtype : System.Web.UI.Page
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
            }
            else
                Response.Redirect("~/notlogged.aspx");
                     
                bind_employeesubtype();

        }

    }

  

    private void bind_employeesubtype()
    {

        string id = Request.QueryString["emp_subtype_id"].ToString();

        //string sqlstr = @"
//select tbl_internate_employee_subtype.emp_subtype_id,tbl_internate_employee_subtype.emp_subtype_name, tbl_internate_employee_type.emp_type_name from tbl_internate_employee_type inner join tbl_internate_employee_subtype on tbl_internate_employee_type.emp_type_id=tbl_internate_employee_subtype.emp_subtype_id where tbl_internate_employee_subtype.emp_subtype_id=" + Request.QueryString["emp_subtype_id"].ToString();

        string sqlstr = @"select sub.emp_subtype_id,emp_subtype_name,sub.emp_type_code from tbl_internate_employee_subtype sub 
inner join tbl_internate_employee_type et 
on et.emp_type_id = sub.emp_type_code where sub.emp_subtype_id=" + id;

        try
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            txt_employeetype.Text = ds.Tables[0].Rows[0]["emp_subtype_name"].ToString();
            //txt_employeesubtype.Text = ds.Tables[0].Rows[0]["emp_subtype_id"].ToString();
            drp_comp_name1.SelectedValue = ds.Tables[0].Rows[0]["emp_type_code"].ToString();

           
        }
        catch { }

    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
      insert_subtype();
    }


    private void insert_subtype()
    {
         SqlParameter[] sqlparam = new SqlParameter[7];

         sqlparam[0] = new SqlParameter("@emp_type_id", SqlDbType.Int);
        sqlparam[0].Value = drp_comp_name1.SelectedValue;

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

        sqlparam[6] = new SqlParameter("@emp_subtype_id", SqlDbType.Int);
        sqlparam[6].Value = Convert.ToInt32(Request.QueryString["emp_subtype_id"].ToString());


        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_employeesubtype", sqlparam);


        if (i <= 0)
        {
             Output.Show("Work Location code already exists, please enter another Work Location");
        }
        else
        {
              Output.Show("Company Work Location created successfully");
            reset();

            Response.Redirect("employeesubtypeview.aspx?updated=true");
        }
    }


    private void reset()
    {
        drp_comp_name1.SelectedValue = "0";
        txt_employeetype.Text = "";
    }
   

    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name1.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("employeesubtypeview.aspx");
    }
}