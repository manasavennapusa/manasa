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
using DataAccessLayer;
using System.Data.SqlClient;

public partial class payroll_viewdeclarationdetail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        bind_declaration_detail();
        bind_6A_detail();
        //bind_nsc_detail();
    }

    protected void bind_declaration_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["ref_no"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_view_declaration_detail", sqlparam);

        lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_empname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
        lbl_fyear.Text = ds.Tables[0].Rows[0]["financialyr"].ToString();
        lbl_metro.Text = ds.Tables[0].Rows[0]["metroname"].ToString();
        lbl_self.Text = ds.Tables[0].Rows[0]["dhself_occupied"].ToString();
        lbl_loan.Text = ds.Tables[0].Rows[0]["dhloan_borrowed"].ToString();

        if (lbl_loan.Text == "No")
            txt_houseint.Text = "N/A";
        else
            txt_houseint.Text = ds.Tables[0].Rows[0]["interest_house"].ToString(); 

        //Bind rent detail

        txt_apr.Text = ds.Tables[0].Rows[0]["apr_amnt"].ToString();
        txt_may.Text = ds.Tables[0].Rows[0]["may_amnt"].ToString();
        txt_june.Text = ds.Tables[0].Rows[0]["jun_amnt"].ToString();
        txt_jul.Text = ds.Tables[0].Rows[0]["jul_amnt"].ToString();
        txt_aug.Text = ds.Tables[0].Rows[0]["aug_amnt"].ToString();
        txt_sep.Text = ds.Tables[0].Rows[0]["sep_amnt"].ToString();
        txt_oct.Text = ds.Tables[0].Rows[0]["oct_amnt"].ToString();
        txt_nov.Text = ds.Tables[0].Rows[0]["nov_amnt"].ToString();
        txt_dec.Text = ds.Tables[0].Rows[0]["dec_amnt"].ToString();
        txt_jan.Text = ds.Tables[0].Rows[0]["jan_amnt"].ToString();
        txt_feb.Text = ds.Tables[0].Rows[0]["feb_amnt"].ToString();
        txt_mar.Text = ds.Tables[0].Rows[0]["mar_amnt"].ToString();

        //Bind children(studying) detail

        txt_apr2.Text = ds.Tables[0].Rows[0]["apr_no"].ToString();
        txt_may2.Text = ds.Tables[0].Rows[0]["may_no"].ToString();
        txt_june2.Text = ds.Tables[0].Rows[0]["jun_no"].ToString();
        txt_jul2.Text = ds.Tables[0].Rows[0]["jul_no"].ToString();
        txt_aug2.Text = ds.Tables[0].Rows[0]["aug_no"].ToString();
        txt_sep2.Text = ds.Tables[0].Rows[0]["sep_no"].ToString();
        txt_oct2.Text = ds.Tables[0].Rows[0]["oct_no"].ToString();
        txt_nov2.Text = ds.Tables[0].Rows[0]["nov_no"].ToString();
        txt_dec2.Text = ds.Tables[0].Rows[0]["dec_no"].ToString();
        txt_jan2.Text = ds.Tables[0].Rows[0]["jan_no"].ToString();
        txt_feb2.Text = ds.Tables[0].Rows[0]["feb_no"].ToString();
        txt_mar2.Text = ds.Tables[0].Rows[0]["mar_no"].ToString();
    }

    //===========================================Bind 6a detail===============================================

    protected void bind_6A_detail()
    {
        sqlstr = "Select section_name,section_detail,a_amount,(case when status=1 then 'Yes' else 'No' end) status from tbl_payroll_employee_6A_detail where ref_no=" + Request.QueryString["ref_no"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        grid_6A.DataSource = ds;
        grid_6A.DataBind();
    }

    //=====================================Bind NSC detail==========================================

    //protected void bind_nsc_detail()
    //{
    //    sqlstr = "Select certi_no,convert(varchar(10),inv_date,101) inv_date,nsc_amount from tbl_payroll_employee_nsc_detail where ref_no=" + Request.QueryString["ref_no"].ToString();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //    grid_nsc.DataSource = ds;
    //    grid_nsc.DataBind();
    //}
}