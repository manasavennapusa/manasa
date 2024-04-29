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

public partial class payroll_admin_edit_applyloanadvances_detail : System.Web.UI.Page
{
    string sqlstr = "";
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataView dview;
    string message1, message2, message3;    

    protected void Page_Load(object sender, EventArgs e)
    {       
        message.InnerHtml = "";
        //divintamnt.Visible = true;
        //divloanac.Visible = false;
      
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
             
            }
            else Response.Redirect("~/notlogged.aspx");
            Session.Remove("loan");
            bind_month();
            bind_year();
            bind_old_detail();           
        }
    }

    ////--------------------------------------- Check for Loan Status ------------------------------------//

    //protected bool check_status()
    //{
        
    //}


    //--------------------------------------- Bind old data --------------------------------------------

    protected void bind_old_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@loan_id", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["loan_id"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_viewapplyloan", sqlparam);
        lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_empname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
        txt_loanref.Text = ds.Tables[0].Rows[0]["loan_ref_id"].ToString();
        dd_loanname.SelectedValue = ds.Tables[0].Rows[0]["loan_name_id"].ToString();
        lbl_acno.Text = ds.Tables[0].Rows[0]["loan_acno"].ToString();
        txt_loanamnt.Text = ds.Tables[0].Rows[0]["loan_amount"].ToString();
        txt_sdate.Text = ds.Tables[0].Rows[0]["sanction_date"].ToString();
        dd_month.SelectedValue = ds.Tables[0].Rows[0]["recover_month"].ToString();
        dd_year.SelectedValue = ds.Tables[0].Rows[0]["recover_year"].ToString();
        lblinteresttopaid.Text = ds.Tables[0].Rows[0]["nt_interest_amount"].ToString();
        txt_instal_no.Text = ds.Tables[0].Rows[0]["no_installments"].ToString();
        lblinterestamount.Text = ds.Tables[0].Rows[0]["interest"].ToString();
        lblmonthlypayment.Text = ds.Tables[0].Rows[0]["pinst_amount"].ToString();
        sbi.Value = ds.Tables[0].Rows[0]["interestSBI"].ToString();
        //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["interest_applicable"]))
        //    opt_apply_interest_yes.Checked = true;
        //else
        //{
        //    opt_apply_interest_no.Checked = true;
        //    divintamnt.Visible = false;
        //}

        HiddenField1.Value = ds.Tables[0].Rows[0]["loan_ref_id"].ToString();
        bindloandetail();
    }

    protected void bindloandetail()
    {
        sqlstr = "SELECT *,month_year recovery FROM tbl_payroll_employee_loandetail where loan_id=" + Request.QueryString["loan_id"].ToString() + "";
        ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);

        detailgrid.DataSource = ds;
        detailgrid.DataBind();
    }

    //------------------------------- Bind Month in DropDownList ---------------------------------

    protected void bind_month()
    {
        dd_month.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month.SelectedValue = a.Month.ToString();
    }

    //------------------------------- Bind Year in DropDownList ---------------------------------

    protected void bind_year()
    {
        dd_year.Items.Insert(0, new ListItem("Select Year", "0"));
        int fromYear = Convert.ToInt32(ConfigurationManager.AppSettings["FromYear"]);
        int toYear = Convert.ToInt32(ConfigurationManager.AppSettings["ToYear"]);

        for (int i = fromYear; i <= toYear; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year.SelectedValue = a.Year.ToString();
    }

    //---------------------------------- Submit Loan Application --------------------------------------

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (validate_recover())
        {
            SqlParameter[] sqlparam = new SqlParameter[12];

            sqlparam[0] = new SqlParameter("@loan_id", SqlDbType.Int);
            sqlparam[0].Value = Request.QueryString["loan_id"];

            sqlparam[1] = new SqlParameter("@loan_name_id", SqlDbType.VarChar, 50);
            sqlparam[1].Value = dd_loanname.SelectedValue;

            sqlparam[2] = new SqlParameter("@loan_amount", SqlDbType.Decimal);
            sqlparam[2].Value = txt_loanamnt.Text.Trim();

            sqlparam[3] = new SqlParameter("@sanction_date", SqlDbType.DateTime);
            sqlparam[3].Value = Convert.ToDateTime(txt_sdate.Text);

            sqlparam[4] = new SqlParameter("@recover_month", SqlDbType.VarChar, 50);
            sqlparam[4].Value = dd_month.SelectedValue;

            sqlparam[5] = new SqlParameter("@recover_year", SqlDbType.VarChar, 50);
            sqlparam[5].Value = dd_year.SelectedValue;

            sqlparam[6] = new SqlParameter("@interest_applicable", SqlDbType.TinyInt);
            sqlparam[6].Value = 1;

            sqlparam[7] = new SqlParameter("@interest_amount", SqlDbType.Decimal);
            sqlparam[7].Value = lblinteresttopaid.Text.Trim().ToString();

            sqlparam[8] = new SqlParameter("@no_installments", SqlDbType.Int);
            sqlparam[8].Value = txt_instal_no.Text.Trim();

            sqlparam[9] = new SqlParameter("@modified_date", SqlDbType.DateTime);
            sqlparam[9].Value = System.DateTime.Now;

            sqlparam[10] = new SqlParameter("@modified_by", SqlDbType.VarChar, 100);
            sqlparam[10].Value = Session["name"].ToString();

            sqlparam[11] = new SqlParameter("@loan_ref_id", SqlDbType.VarChar, 50);
            sqlparam[11].Value = txt_loanref.Text.Trim().ToString();

            int a = (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_editapplyloan", sqlparam)));

            submit_inst_detail();

            sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = lbl_empcode.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@user", SqlDbType.VarChar, 50);
            sqlparam[1].Value = Session["name"].ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_loan_perqusite", sqlparam);



            Response.Redirect("view_applyloanadvances.aspx?message=Applied Loan/Advances updated successfully");
        }
        fun_acno_visible();
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        bind_old_detail();
        message.InnerHtml = "";
    }

    protected void clear()
    {
        //txt_employee.Text = "";
        txt_instal_no.Text = "";
        txt_loanamnt.Text = "";
        txt_loanref.Text = "";
        txt_sdate.Text = "";
        dd_loanname.SelectedValue = "0";
        dd_month.SelectedValue = "0";
        dd_year.SelectedValue = "0";
        divloanac.Visible = false;
        divdetail.Visible = false;
    }

    //-------------------------------- Display Loan/Advances A/c No. of Selected Loan/Advances Type -----------------------------------

    protected void dd_loanname_SelectedIndexChanged(object sender, EventArgs e)
    {
        sqlstr = @"select loan_acno,interest,interestSBI from tbl_payroll_loan_advances where id=" + dd_loanname.SelectedValue;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (dd_loanname.SelectedIndex != 0)
        {
            divloanac.Visible = true;
            lbl_acno.Text = ds.Tables[0].Rows[0]["loan_acno"].ToString();
            lblinterestamount.Text = ds.Tables[0].Rows[0]["interest"].ToString();
            sbi.Value = ds.Tables[0].Rows[0]["interestSBI"].ToString();
        }

    }



    protected void dd_loanname_DataBound(object sender, EventArgs e)
    {
        dd_loanname.Items.Insert(0, new ListItem("Select Loan/Advances", "0"));
    }

    protected void fun_acno_visible()
    {
        if (dd_loanname.SelectedIndex != 0)
            divloanac.Visible = true;
    }

    //------------------------------ Calculate Installment Amount ------------------------------

    protected decimal calculate_installment_amnt()
    {
        decimal amnt = 0, piamnt = 0;
        amnt = Convert.ToDecimal(txt_loanamnt.Text) + Convert.ToDecimal(lblinterestamount.Text);

        piamnt = System.Math.Round((amnt / Convert.ToDecimal(txt_instal_no.Text)), 2);
        return piamnt;
    }

    //------------------------------ Create Installment Detail ------------------------------    

    protected void view_installments()
    {
        double beginningbalance = 0.0, rate = 0.0, rate1 = 0.0, noofinstallment = 0.0, monthlypayment = 0.0, interestpayment = 0.0, suminterestpayment = 0.0, principalpayment = 0.0, endingbalance = 0.0, totalprincipal = 0.0, totalinterest = 0.0;
        beginningbalance = Convert.ToDouble(txt_loanamnt.Text);
        double beginningbalanceSBI = Convert.ToDouble(txt_loanamnt.Text);
        rate = Convert.ToDouble(lblinterestamount.Text);
        rate1 = (rate / 12) / 100;
        //SBI rate1
        double rateSBI = (Convert.ToDouble(sbi.Value) / 12) / 100;
        noofinstallment = Convert.ToDouble(txt_instal_no.Text);

        monthlypayment = Microsoft.VisualBasic.Financial.Pmt(rate1, noofinstallment, -beginningbalance, 0, 0);
        //SBI monthlypayment
        double monthlypaymentSBI = Microsoft.VisualBasic.Financial.Pmt(rateSBI, noofinstallment, -beginningbalance, 0, 0);

        lblmonthlypayment.Text = Convert.ToString(System.Math.Round(monthlypayment, 2));


        double endingbalanceSBI = 0.0, interestpaymentSBI = 0.0, principalpaymentSBI = 0.0;



        string recovr = "";
        recovr = dd_month.SelectedValue + "/1/" + dd_year.SelectedValue;
        DateTime t = Convert.ToDateTime(recovr);

        create_detailtable();

        for (int i = 1; i <= Convert.ToInt32(noofinstallment); i++)
        {
            DataRow dr = dtable.NewRow();

            string item = t.ToString("MMM / yyyy");
            //Added two coloum to sessiont able Fyear and IntrestSBI----------------------
            string fyear = "";
            if (t.Month > 3)
                fyear = t.Year.ToString() + "-" + Convert.ToString(t.Year + 1);
            else
                fyear = Convert.ToString(t.Year - 1) + "-" + t.Year.ToString();
            //----------------------------------------------------------------------
            t = t.AddMonths(1);

            dr["fyear"] = fyear;
            dr["recovery"] = item;

            if (dtable.Rows.Count == 0)
            {
                beginningbalance = beginningbalance;
                beginningbalanceSBI = beginningbalance;
            }
            else
            {
                beginningbalance = endingbalance;
                beginningbalanceSBI = endingbalanceSBI;
            }
            dr["beginningbalance"] = System.Math.Round(beginningbalance, 2);
            interestpayment = beginningbalance * ((rate / 100) / 12);
            interestpaymentSBI = beginningbalanceSBI * rateSBI;

            dr["interestpayment"] = System.Math.Round(interestpayment, 2);
            dr["interestpaymentSBI"] = System.Math.Round(interestpaymentSBI, 2);

            suminterestpayment = suminterestpayment + System.Math.Round(interestpayment, 2);

            principalpayment = monthlypayment - interestpayment;
            principalpaymentSBI = monthlypaymentSBI - interestpaymentSBI;
            dr["principalpayment"] = System.Math.Round(principalpayment, 2);

            endingbalance = beginningbalance - principalpayment;
            dr["endingbalance"] = System.Math.Round(endingbalance, 2);
            endingbalanceSBI = beginningbalanceSBI - principalpaymentSBI;

            totalprincipal = totalprincipal + principalpayment;
            dr["totalprincipal"] = System.Math.Round(totalprincipal, 2);

            totalinterest = totalinterest + interestpayment;
            dr["totalinterest"] = System.Math.Round(totalinterest, 2);

            dtable.Rows.Add(dr);
        }
        lblinteresttopaid.Text = Convert.ToString(System.Math.Round(suminterestpayment, 2));
    }

    protected void create_detailtable()
    {
        dtable = new DataTable();
        dtable.Columns.Add(new DataColumn("fyear", typeof(string)));
        dtable.Columns.Add(new DataColumn("recovery", typeof(string)));
        dtable.Columns.Add(new DataColumn("beginningbalance", typeof(string)));
        dtable.Columns.Add(new DataColumn("interestpayment", typeof(string)));
        dtable.Columns.Add(new DataColumn("principalpayment", typeof(string)));
        dtable.Columns.Add(new DataColumn("endingbalance", typeof(string)));
        dtable.Columns.Add(new DataColumn("totalprincipal", typeof(string)));
        dtable.Columns.Add(new DataColumn("totalinterest", typeof(string)));
        dtable.Columns.Add(new DataColumn("interestpaymentSBI", typeof(string)));
        
        Session["loan"] = dtable;
    }
    protected void bind_detailgrid()
    {
        if (Session["loan"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["loan"];
            dview = new DataView(dtable);

        }
        detailgrid.DataSource = dview;
        detailgrid.DataBind();
    }

    //--------------------------------------- View Installment Detail ---------------------------------------

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam9 = new SqlParameter[3];

        sqlparam9[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam9[0].Value = lbl_empcode.Text.Trim().ToString();

        sqlparam9[1] = new SqlParameter("@date", SqlDbType.DateTime);
        sqlparam9[1].Value =Utilities.Utility.dataformat(txt_sdate.Text.ToString());

        sqlparam9[2] = new SqlParameter("@loanid", SqlDbType.Int);
        sqlparam9[2].Value =Convert.ToInt32(dd_loanname.SelectedValue.ToString());

        DataSet ds9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_check_eligiblity_loan", sqlparam9);
        
        if (Convert.ToInt32(ds9.Tables[0].Rows[0][0].ToString()) == 1)
        {
            
            if (validate_recover())
            {
                view_installments();
                divdetail.Visible = true;
                bind_detailgrid();
            }
        }
        else
        {
         message.InnerHtml = "Employee is not eligible for taking loan";
        }
    }


    //-------------------------- Save Installment Detail -------------------------------

    protected void submit_inst_detail()
    {
        int loanid;
        //decimal pinstamnt = calculate_installment_amnt();
        string recovr = "";
        recovr = dd_month.SelectedValue + "/1/" + dd_year.SelectedValue;
        DateTime t = Convert.ToDateTime(recovr);
        loanid = Convert.ToInt32(Request.QueryString["loan_id"]);
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (Session["loan"] != null)
        {

            string sqlstr1 = "delete from tbl_payroll_employee_loandetail where loan_id=" + loanid + "";
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);

            dtable = (DataTable)Session["loan"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                string im = t.ToString("MMM");
                string iy = t.ToString("yyyy");
                string item = t.ToString("MMM / yyyy");
                t = t.AddMonths(1);

                SqlParameter[] sqlpar = new SqlParameter[13];

                sqlpar[0] = new SqlParameter("@loan_id", SqlDbType.Int);
                sqlpar[0].Value = loanid;

                sqlpar[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
                sqlpar[1].Value = im;

                sqlpar[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
                sqlpar[2].Value = iy;

                sqlpar[3] = new SqlParameter("@month_year", SqlDbType.VarChar, 50);
                sqlpar[3].Value = dtable.Rows[i]["recovery"];

                sqlpar[4] = new SqlParameter("@pinst_amount", SqlDbType.Decimal);
                sqlpar[4].Value = Convert.ToDouble(lblmonthlypayment.Text);

                sqlpar[5] = new SqlParameter("@beginningbalance", SqlDbType.Decimal);
                sqlpar[5].Value = Convert.ToDouble(dtable.Rows[i]["beginningbalance"]);

                sqlpar[6] = new SqlParameter("@interestpayment", SqlDbType.Decimal);
                sqlpar[6].Value = Convert.ToDouble(dtable.Rows[i]["interestpayment"]);

                sqlpar[7] = new SqlParameter("@principalpayment", SqlDbType.Decimal);
                sqlpar[7].Value = Convert.ToDouble(dtable.Rows[i]["principalpayment"]);

                sqlpar[8] = new SqlParameter("@endingbalance", SqlDbType.Decimal);
                sqlpar[8].Value = Convert.ToDouble(dtable.Rows[i]["endingbalance"]);

                sqlpar[9] = new SqlParameter("@totalprincipal", SqlDbType.Decimal);
                sqlpar[9].Value = Convert.ToDouble(dtable.Rows[i]["totalprincipal"]);

                sqlpar[10] = new SqlParameter("@totalinterest", SqlDbType.Decimal);
                sqlpar[10].Value = Convert.ToDouble(dtable.Rows[i]["totalinterest"]);

                sqlpar[11] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                sqlpar[11].Value = dtable.Rows[i]["fyear"].ToString();

                sqlpar[12] = new SqlParameter("@interestpaymentSBI", SqlDbType.Decimal);
                sqlpar[12].Value = Convert.ToDouble(dtable.Rows[i]["interestpaymentSBI"]);


                sqlstr = @"INSERT INTO tbl_payroll_employee_loandetail(loan_id,month,year,month_year,pinst_amount,beginningbalance,interestpayment,principalpayment,endingbalance,totalprincipal,totalinterest,fyear,interestpaymentSBI) 
                VALUES(@loan_id,@month,@year,@month_year,@pinst_amount,@beginningbalance,@interestpayment,@principalpayment,@endingbalance,@totalprincipal,@totalinterest,@fyear,@interestpaymentSBI)";

                DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlpar);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    //--------------------------------- Validation for Loan Amount -----------------------------------

    //protected Boolean validate_installment_amount()
    //{
    //    SqlParameter[] sqlparam = new SqlParameter[1];

    //    sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
    //    sqlparam[0].Value = txt_employee.Text.Trim().ToString();

    //    sqlstr = @"select (ntotal*0.75) as total from tbl_payroll_employee_salary where empcode=@empcode and createddate=(select max(createddate) from tbl_payroll_employee_salary where empcode=@empcode)";

    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparam);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if (!valdiate_loan(ds))
    //            return false;
    //    }

    //    return true;               
    //}

    protected Boolean valdiate_loan(DataSet ds)
    {
        decimal pinstamnt = calculate_installment_amnt();
        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["total"]))
        {
            if (Convert.ToInt32(pinstamnt) > Convert.ToInt32(ds.Tables[0].Rows[0]["total"]))
            {
                message1 = "You can not apply for this loan/advances.Whether decrease your loan amount or increase no. of installments.";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
                return false;
            }
        }
        return true;
    }

    //------------------------------------- Validation for Recover From  -----------------------------------

    protected Boolean validate_recover()
    {
        DateTime sd = Convert.ToDateTime(txt_sdate.Text);
        DateTime rd = Convert.ToDateTime(dd_month.SelectedValue + "/1/" + dd_year.SelectedValue);
        if (findcycle(sd) > rd) //|| (findcycle(DateTime.Now) > rd))
        {
            message2 = "You can not apply for this loan/advances.Either change your sanction date or recover from month/year.";
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
}