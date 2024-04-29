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
public partial class payroll_admin_reimbursementmaster : System.Web.UI.Page
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
            bindgrade();
        }
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
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
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@payhead_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_name.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_alias.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@payhead_type", SqlDbType.Int);
        sqlparam[2].Value = 0;

        sqlparam[3] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
        sqlparam[3].Value = txt_payslip.Text.ToString().Trim();

        sqlparam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[4].Value = Session["name"].ToString();

        sqlparam[5] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[5].Value = System.DateTime.Now;

        sqlparam[6] = new SqlParameter("@taxrebate", SqlDbType.Decimal);
        sqlparam[6].Value = Convert.ToDecimal(txt_taxrebate.Text);

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_reimbursement_master", sqlparam);
        int id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            //Create stringbuilder to store multiple DML statements 
            StringBuilder strSql = new StringBuilder(string.Empty);

            for (int i = 0; i < chkgrade.Items.Count; i++)
            {
                if (chkgrade.Items[i].Selected == true)
                {
                    string strSqlInsert = @"INSERT INTO tbl_payroll_reimbursement_grade(reimbursementid,grade) VALUES(" + id + ",'" + chkgrade.Items[i].Value.ToString() + "');";
                    //append update statement in stringBuilder 
                    strSql.Append(strSqlInsert);
                }
            }
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strSql.ToString());

            message.InnerHtml = " Reimbursement created successfully ";
            clear();
        }
        else
        {
            message.InnerHtml = " Please select Grade for this reimbursement ";
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }
    protected void clear()
    {
        txt_alias.Text = "";
        txt_name.Text = "";
        txt_payslip.Text = "";
       // dd_payheadtype.SelectedIndex = -1;
        txt_taxrebate.Text = "";
        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            chkgrade.Items[i].Selected = false;
        }
    }

    //------------------------------------------- Check for Payhead Name ---------------------------------------------//

    protected void txt_name_TextChanged(object sender, EventArgs e)
    {
        validate_name();
    }

    protected void validate_name()
    {
        sqlstr = @"SELECT count(payhead_name) FROM tbl_payroll_reimbursement WHERE payhead_name='" + txt_name.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This reimbursement name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
        }
    }
    protected void bindgrade()
    {
        sqlstr = "SELECT id,gradename FROM tbl_intranet_grade";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                string gradename = row1["gradename"].ToString().Trim();
                chkgrade.Items.Add(new ListItem(Convert.ToString(gradename), row1["id"].ToString(), true));
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
