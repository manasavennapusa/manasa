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
            bind_grad_information();
        }
    }
   
    public void btnsv_Click(object sender, EventArgs e)
    {
        edit_grade_detail();
    }

    protected void bind_grad_information()
    {
        string sqlstr = "SELECT id,gradename,description,gradetype FROM tbl_intranet_grade where id  =" + Request.QueryString["grade_id"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text ,sqlstr);

        try
        {
            txt_branch_name.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            txt_branch_code.Text = ds.Tables[0].Rows[0]["description"].ToString();
            rbtn_gradetype.SelectedValue = ds.Tables[0].Rows[0]["gradetype"].ToString();
        }
        catch { }
    }

    protected void edit_grade_detail()
    {                       
                SqlParameter[] sqlparam = new SqlParameter[5];

                sqlparam[0] = new SqlParameter("@gradename", SqlDbType.VarChar, 50);
                sqlparam[0].Value = txt_branch_name.Text;

                sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
                sqlparam[1].Value = txt_branch_code.Text;

                sqlparam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                sqlparam[2].Value = Session["name"].ToString();

                sqlparam[3] = new SqlParameter("@grade_id", SqlDbType.Int);
                sqlparam[3].Value = Convert.ToInt32(Request.QueryString["grade_id"].ToString());

                sqlparam[4] = new SqlParameter("@gradetype", SqlDbType.VarChar, 1);
                sqlparam[4].Value = rbtn_gradetype.SelectedValue;

                //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_grade", sqlparam);
                int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_edit_grade]", sqlparam);
                if (i < 0)
                {
                    message.InnerHtml = "Grade is already exist. Try another Grade.";
                }
                else
                {
                    message.InnerHtml = "Transaction Completed Successfully!!!";
                    reset();
                    Response.Redirect("gradeview.aspx?updated=true");
                }
                
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("gradeview.aspx?");
    }
}
