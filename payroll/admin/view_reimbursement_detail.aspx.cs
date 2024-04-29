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

public partial class payroll_admin_view_reimbursement_detail : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    SqlParameter[] sqlparam;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
           
        }
        else
            Response.Redirect("~/notlogged.aspx");
        bind_reimbursement();
    }

   
    protected void bind_reimbursement()
    {
        sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@remb_ref_no", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Request.QueryString["reimbursement_ref_no"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure,"sp_payroll_employee_reimburse_detail",sqlparam);
       lbl_amount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
       lbl_empname.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
       lbl_month.Text = ds.Tables[0].Rows[0]["month_year"].ToString();
       lbl_refno.Text = ds.Tables[0].Rows[0]["reimbursement_ref_no"].ToString();
       lbl_reimbursement.Text = ds.Tables[0].Rows[0]["PAYHEAD_NAME"].ToString();
       lbl_sanct.Text = ds.Tables[0].Rows[0]["sanction_date"].ToString();
        lbl_path.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() !="") ? "<a href='../../upload/reimbursement/"+ds.Tables[0].Rows[0]["file_path"].ToString()+
            "'>"+ds.Tables[0].Rows[0]["file_path"].ToString()+"</a>" : "No file exist";
        //lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a href='upload/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
        //      "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No exisitng file found";

    
    }
}
