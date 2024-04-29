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

public partial class payroll_admin_payheadmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[12];

        sqlparam[0] = new SqlParameter("@payhead_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_name.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_alias.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@under", SqlDbType.VarChar, 100);
        //sqlparam[2].Value = dd_under.SelectedItem.Text.ToString().Trim();
        sqlparam[2].Value = "Assets";

        sqlparam[3] = new SqlParameter("@apply_slabrate", SqlDbType.TinyInt);
        //if (opt_apply_slab_yes.Checked)        
            sqlparam[3].Value = 1;        
        //else
        //    sqlparam[3].Value = 0;       

        sqlparam[4] = new SqlParameter("@payhead_type", SqlDbType.Int);
        sqlparam[4].Value = dd_payheadtype.SelectedValue;

        sqlparam[5] = new SqlParameter("@appear_inpayslip", SqlDbType.TinyInt);
        if (opt_apper_yes.Checked)
            sqlparam[5].Value = 1;
        else
            sqlparam[5].Value = 0;

        sqlparam[6] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
        if (txt_payslip.Text == "")
            sqlparam[6].Value = "N/A";
        else
            sqlparam[6].Value = txt_payslip.Text.ToString().Trim();

        sqlparam[7] = new SqlParameter("@use_ingratuity", SqlDbType.TinyInt);
        //if (opt_gratuity_yes.Checked)
            sqlparam[7].Value = 1;
        //else
        //    sqlparam[7].Value = 0;

        sqlparam[8] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[8].Value = Session["name"].ToString();

        sqlparam[9] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[9].Value = System.DateTime.Now;

        sqlparam[10] = new SqlParameter("@type", SqlDbType.Int);
        sqlparam[10].Value = 1;

        sqlparam[11] = new SqlParameter("@bases", SqlDbType.VarChar, 50);
        sqlparam[11].Value = dd_bases.SelectedValue;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_createpayhead", sqlparam);
        message.InnerHtml = " Payhead created successfully ";
        clear();
    }

    protected void clear()
    {
        txt_alias.Text = "";
        txt_name.Text = "";
        txt_payslip.Text = "";
        dd_payheadtype.SelectedIndex = -1;
        //dd_under.SelectedIndex = -1;
        opt_apper_yes.Checked = true;
       // opt_apply_slab_yes.Checked = true;
       // opt_gratuity_yes.Checked = true;
       // opt_gratuity_no.Checked = false;
      //  opt_apply_slab_no.Checked = false;
        opt_apper_no.Checked = false;       
        dd_bases.SelectedIndex = -1;
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }

    //------------------------------------------- Check for Payhead Name ---------------------------------------------//

    protected void txt_name_TextChanged(object sender, EventArgs e)
    {
        validate_name();        
    }

    protected void validate_name()
    {
        sqlstr = @"SELECT count(payhead_name) FROM tbl_payroll_payhead WHERE payhead_name='" + txt_name.Text.Trim().ToString() + "'";
        int i =(int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This payhead name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
        }        
    }

    //------------------------------------------- Check for Validation on Name in Payslip---------------------------------------------//

    protected void check_payslipname()
    {
        if (opt_apper_yes.Checked == true)
            rfvpayslip.Enabled = true;
        else
            rfvpayslip.Enabled = false;
    }
    protected void opt_apper_yes_CheckedChanged(object sender, EventArgs e)
    {
        check_payslipname();
    }
    protected void opt_apper_no_CheckedChanged(object sender, EventArgs e)
    {
        check_payslipname();
    }
}
