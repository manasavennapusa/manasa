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
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    public void btnsv_Click(object sender, EventArgs e)
    {
        insert_department_detail();
    }

    protected void insert_department_detail()
    {
        //@branchid int ,@department_name varchar(50),@department_code varchar(50),@estt_date datetime

        SqlParameter[] sqlparam = new SqlParameter[4];

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
            // sqlparam[3].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[3].Value = Convert.ToDateTime(txt_est_date.Text.ToString());
        }

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_department", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_department]", sqlparam);


        if (i <= 0)
        {
            SmartHr.Common.Alert("Department name already exists, please enter another name.");
           // message.InnerHtml = "Department name already exists, please enter another name";
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
           // message.InnerHtml = "Department created successfully";
           // reset();
        }
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
        txt_est_date.Text = "";
        drp_comp_name.SelectedValue = "0";
    }

    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }
}
