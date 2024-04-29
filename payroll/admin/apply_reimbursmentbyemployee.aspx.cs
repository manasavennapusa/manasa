using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using Common.Data;
using Common.Console;

public partial class payroll_admin_apply_reimbursmentbyemployee : System.Web.UI.Page
{
    string filename, _userCode, _companyId;
    DataSet ds = new DataSet();
    string message2;  
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            BindEmp();
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");
            dd_reimburse.DataBind();
        }  
    }

    protected void BindEmp()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "Select empcode from dbo.tbl_intranet_employee_jobDetails where empcode='" + _userCode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            string sqlstr1 = "Select empcode from dbo.tbl_intranet_employee_jobDetails where empcode='" + _userCode + "'";
            DataSet ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            txt_employee.Text = ds1.Tables[0].Rows[0]["empcode"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       
            Response.Write(upload_attach.PostedFile.FileName);
            SqlParameter[] sqlparam = new SqlParameter[11];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = txt_employee.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@reimbursement_id", SqlDbType.Int);
            sqlparam[1].Value = dd_reimburse.SelectedValue;

            sqlparam[2] = new SqlParameter("@reimbursement_ref", SqlDbType.VarChar, 50);
            sqlparam[2].Value = txt_remb_ref.Text.ToString();

            sqlparam[3] = new SqlParameter("@remb_amount", SqlDbType.Decimal);
            sqlparam[3].Value = txt_remb_amount.Text.ToString();

            sqlparam[4] = new SqlParameter("@sanc_date", SqlDbType.VarChar,50);
            sqlparam[4].Value = txt_sanct.Text.ToString();

            sqlparam[5] = new SqlParameter("@remb_month", SqlDbType.VarChar, 50);
            sqlparam[5].Value = "NULL";

            sqlparam[6] = new SqlParameter("@remb_year", SqlDbType.VarChar, 50);
            sqlparam[6].Value = "NULL";

            sqlparam[7] = new SqlParameter("@month_year", SqlDbType.VarChar, 50);
            sqlparam[7].Value = "NULL";

            sqlparam[8] = new SqlParameter("@file", SqlDbType.VarChar, 500);


            if (upload_attach.PostedFile.FileName != "")
            {
                //string file_name,fn;
                //fn = System.DateTime.Now.GetHashCode().ToString() + "_" + System.IO.Path.GetFileName(fupdocument.PostedFile.FileName.ToString());
                //file_name = Server.MapPath(".") + "\\documents\\" + fn;
                //fupdocument.PostedFile.SaveAs(file_name);
                //ViewState.Add("file_name", fn.ToString());
                filename = System.IO.Path.GetFileName(upload_attach.PostedFile.FileName.ToString());
                upload_attach.PostedFile.SaveAs(Server.MapPath(".") + "../../../upload/reimbursement/" + filename);
            }
            else
                filename = "";
            sqlparam[8].Value = filename;



            sqlparam[9] = new SqlParameter("@created_date", SqlDbType.DateTime);
            sqlparam[9].Value = System.DateTime.Now;

            sqlparam[10] = new SqlParameter("@created_by", SqlDbType.VarChar, 100);
            sqlparam[10].Value = _userCode.ToString();

            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_apply_reimburesment", sqlparam);
            Output.Show("Reimbursment applied successfully");
            clear();
        
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void dd_reimburse_DataBound(object sender, EventArgs e)
    {
        dd_reimburse.Items.Insert(0, new ListItem("Select one", "0"));
    }

    protected void clear()
    {
        dd_reimburse.SelectedIndex = -1;
        dd_month.SelectedIndex = -1;
        dd_year.SelectedIndex = -1;
        txt_employee.Text = "";
        txt_remb_amount.Text = "";
        txt_remb_ref.Text = "";
        txt_sanct.Text = "";
    }
    protected Boolean validate_reimbursement()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@reimbursementid", SqlDbType.Int);
        sqlparam[1].Value = dd_reimburse.SelectedValue;

        sqlparam[2] = new SqlParameter("@amount", SqlDbType.Decimal);
        sqlparam[2].Value = Convert.ToDecimal(txt_remb_amount.Text.Trim());

        sqlparam[3] = new SqlParameter("@sanction_date", SqlDbType.DateTime);
        sqlparam[3].Value = Convert.ToDateTime(txt_sanct.Text.ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_validate_reimbursement", sqlparam);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["flag"]) == 0)
            {
                return true;
            }
            else
            {
                message.InnerHtml = "You can not apply more reimbursement than assigned reimbursement";
                return false;
            }
        }
        //if (ds.Tables[1].Rows.Count > 0)
        //{
        //  return true;
        //}
        //else
        //{
        //  message.InnerHtml = "This employee does not belongs to grade applicable for this reimbursement";
        //  return false;
        //}        
        return true;
    }
    //------------------------------------- Validation for Recover From  -----------------------------------
    protected Boolean validate_recover()
    {
        DateTime sd = Convert.ToDateTime(txt_sanct.Text);
        DateTime rd = Convert.ToDateTime(dd_month.SelectedValue + "/1/" + dd_year.SelectedValue);
        if ((findcycle(sd) > rd) || (findcycle(DateTime.Now) > rd))
        {
            message2 = "You can not apply for this reimbursement. Either change your sanction date or reimburse month/year.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message2.ToString() + "')</script>", false);
            return false;
        }
        return true;
    }

    protected DateTime findcycle(DateTime dt)
    {
        if (Convert.ToInt16(dt.Day) >= 26)
            dt = dt.AddMonths(1);
        dt = Convert.ToDateTime(dt.Month.ToString() + "/1/" + dt.Year.ToString());
        return dt;
    }
    protected void dd_reimburse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();

            string sqlstr1 = "select payhead_name,taxrebate from tbl_payroll_reimbursement where payhead_name='" + dd_reimburse.SelectedItem.Text + "'";
            DataSet ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);

            txt_remb_amount.Text = ds2.Tables[0].Rows[0]["taxrebate"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
}