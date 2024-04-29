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
public partial class payroll_admin_editreimbursementmaster : System.Web.UI.Page
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
        sqlstr = @"SELECT payhead_name,alias_name,payhead_type,name_inpayslip,taxrebate FROM tbl_payroll_reimbursement where id =" + Request.QueryString["id"].ToString() + "";
               
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_alias.Text = ds.Tables[0].Rows[0]["alias_name"].ToString();
        txt_name.Text = ds.Tables[0].Rows[0]["payhead_name"].ToString();
        txt_payslip.Text = ds.Tables[0].Rows[0]["name_inpayslip"].ToString();
        //dd_payheadtype.SelectedValue = ds.Tables[0].Rows[0]["payhead_type"].ToString();
        HiddenField1.Value = ds.Tables[0].Rows[0]["payhead_name"].ToString();
        txt_taxrebate.Text = ds.Tables[0].Rows[0]["taxrebate"].ToString();
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
        sqlparam = new SqlParameter[8];

        sqlparam[0] = new SqlParameter("@payhead_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_name.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_alias.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@payhead_type", SqlDbType.Int);
        sqlparam[2].Value = 0;

        sqlparam[3] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
        sqlparam[3].Value = txt_payslip.Text.ToString().Trim();

        sqlparam[4] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[4].Value = Session["name"].ToString();

        sqlparam[5] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
        sqlparam[5].Value = System.DateTime.Now;

        sqlparam[6] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[6].Value = Request.QueryString["id"];

        sqlparam[7] = new SqlParameter("@taxrebate", SqlDbType.Decimal);
        sqlparam[7].Value = Convert.ToDecimal(txt_taxrebate.Text.Trim());

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_update_reimbursement_master", sqlparam);

        sqlstr = "DELETE FROM tbl_payroll_reimbursement_grade where reimbursementid=" + Request.QueryString["id"].ToString() + "";
        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr.ToString());

        //Create stringbuilder to store multiple DML statements 
        StringBuilder strSql = new StringBuilder(string.Empty);

        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            if (chkgrade.Items[i].Selected == true)
            {
                string strSqlInsert = @"INSERT INTO tbl_payroll_reimbursement_grade(reimbursementid,grade) VALUES(" + Request.QueryString["id"].ToString() + ",'" + chkgrade.Items[i].Value.ToString() + "');";
                //append update statement in stringBuilder 
                strSql.Append(strSqlInsert);
            }
        }

        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strSql.ToString()); 
        

        Response.Redirect("viewreimbursement.aspx?message=Reimbursement updated successfully");
        }
        else
        {
            message.InnerHtml = " Please select Grade for this reimbursement ";
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if (txt_name.Text == HiddenField1.Value)
            submit();
        else
        {
            if (validate_name())
                submit();
        }

    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewreimbursement.aspx");
    }

    //------------------------------------------- Check for Reimbursement Name ---------------------------------------------//

    protected Boolean validate_name()
    {
        sqlstr = @"SELECT count(payhead_name) FROM tbl_payroll_reimbursement WHERE payhead_name='" + txt_name.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This Reimbursement name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
            return false;
        }
        return true;
    }

    protected void bindgrade()
    {
        sqlstr = @"SELECT g.id,gradename,
                    case when p.id is null then cast(0 as bit) else cast(1 as bit) end flag
                    FROM tbl_intranet_grade g left outer join tbl_payroll_reimbursement_grade p on g.id=p.grade and p.reimbursementid=" + Request.QueryString["id"].ToString() + "";
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
