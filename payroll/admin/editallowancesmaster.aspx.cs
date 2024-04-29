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
using System.Text;
public partial class payroll_admin_editallowancesmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");
            binddata();
            bindgrade();
        }
    }

    protected void binddata()
    {
        sqlstr = "SELECT distinct * FROM tbl_payroll_payhead WHERE id=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_alias.Text = ds.Tables[0].Rows[0]["alias_name"].ToString();
        txt_name.Text = ds.Tables[0].Rows[0]["payhead_name"].ToString();
        txt_payslip.Text = ds.Tables[0].Rows[0]["name_inpayslip"].ToString();
        dd_payheadtype.SelectedValue = ds.Tables[0].Rows[0]["payhead_type"].ToString();

        if (Convert.ToInt32(ds.Tables[0].Rows[0]["appear_inpayslip"]) == 0)
            opt_apper_no.Checked = true;
        else
            opt_apper_yes.Checked = true;

        HiddenField1.Value = ds.Tables[0].Rows[0]["payhead_name"].ToString();
        txt_taxrebate.Text = ds.Tables[0].Rows[0]["taxrebate"].ToString();
        drp_type.SelectedValue = ds.Tables[0].Rows[0]["type"].ToString();
    }

    protected void submit()
    {
        int flag = 0;
        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            if (flag == 0)
            {
                if (chkgrade.Items[i].Selected == true)
                {
                    flag = 1;
                    break;
                }
            }
        }
        if (flag == 1)
        {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[10];

        sqlparam[0] = new SqlParameter("@payhead_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_name.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_alias.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@payhead_type", SqlDbType.Int);
        sqlparam[2].Value = dd_payheadtype.SelectedValue;

        sqlparam[3] = new SqlParameter("@appear_inpayslip", SqlDbType.TinyInt);
        if (opt_apper_yes.Checked)
            sqlparam[3].Value = 1;
        else
            sqlparam[3].Value = 0;

        sqlparam[4] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
        if (txt_payslip.Text == "")
            sqlparam[4].Value = "N/A";
        else
            sqlparam[4].Value = txt_payslip.Text.ToString().Trim();

        sqlparam[5] = new SqlParameter("@use_ingratuity", SqlDbType.TinyInt);
        sqlparam[5].Value = 0;

        sqlparam[6] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[6].Value = Session["name"].ToString();

        sqlparam[7] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[7].Value = Request.QueryString["id"];

        sqlparam[8] = new SqlParameter("@taxrebate", SqlDbType.Decimal);
        sqlparam[8].Value = Convert.ToDecimal(txt_taxrebate.Text.Trim());

        sqlparam[9] = new SqlParameter("@type", SqlDbType.Int);
        sqlparam[9].Value = drp_type.SelectedValue;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_updatpayhead", sqlparam);


        sqlstr = "DELETE FROM tbl_payroll_payhead_grade where payheadid=" + Request.QueryString["id"].ToString() + "";
        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr.ToString()); 

        //Create stringbuilder to store multiple DML statements 
        StringBuilder strSql = new StringBuilder(string.Empty);

        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            if (chkgrade.Items[i].Selected == true)
            {
                string strSqlInsert = @"INSERT INTO tbl_payroll_payhead_grade(payheadid,grade) VALUES(" + Request.QueryString["id"].ToString() + ",'" + chkgrade.Items[i].Value.ToString() + "');";
                //append update statement in stringBuilder 
                strSql.Append(strSqlInsert);
            }
        }

        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strSql.ToString()); 
        

        Response.Redirect("viewallowances.aspx?message=Allowance updated successfully");
    }
    else
    {
        message.InnerHtml = " Please select Grade for this allowance ";
    }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if (txt_name.Text.ToLower() == HiddenField1.Value.ToLower())
            submit();
        else
        {
            if (validate_name())
                submit();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewallowances.aspx");
    }

    //------------------------------------------- Check for Payhead Name ---------------------------------------------//

    protected Boolean validate_name()
    {
        sqlstr = @"SELECT count(payhead_name) FROM tbl_payroll_payhead WHERE payhead_name='" + txt_name.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This allowance name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
            return false;
        }
        return true;
    }

    //------------------------------------------- Check for Validation on Name in Payslip---------------------------------------------//

    protected void check_payslipname()
    {
        if (opt_apper_yes.Checked == true)
            rfvpayslip.Enabled = true;
        else
        {
            rfvpayslip.Enabled = false;
            txt_payslip.Text = "";
        }
    }
    protected void opt_apper_yes_CheckedChanged(object sender, EventArgs e)
    {
        check_payslipname();
    }
    protected void opt_apper_no_CheckedChanged(object sender, EventArgs e)
    {
        check_payslipname();
    }

    protected void bindgrade()
    {
        sqlstr = @"SELECT g.id,gradename,
                    case when p.id is null then cast(0 as bit) else cast(1 as bit) end flag
                    FROM tbl_intranet_grade g left outer join tbl_payroll_payhead_grade p on g.id=p.grade and p.payheadid=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        int i = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                
                    string gradename = row1["gradename"].ToString().Trim();
                    chkgrade.Items.Add(new ListItem(Convert.ToString(gradename), row1["id"].ToString(), true));
                    if (Convert.ToInt32(row1["flag"]) == 1)
                    {
                        chkgrade.Items[i].Selected = true;
                    }
                    i = i + 1;
            }
        }
    }

    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            chkgrade.Items[i].Selected = true;
        }
    }

    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            chkgrade.Items[i].Selected = false;
        }
    }
}