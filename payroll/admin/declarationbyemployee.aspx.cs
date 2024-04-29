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
using System.Security.Cryptography;
using Common.Data;
using Common.Console;

public partial class payroll_admin_declarationbyemployee : System.Web.UI.Page
{
    //string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataView dview;
    string filename, _userCode, _companyId;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        if (!IsPostBack)
        {
            BindEmp();
            bind_fyear();
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

            
            Session.Remove("deduction");
        }
    }

    protected void BindEmp()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "Select empcode from dbo.tbl_intranet_employee_jobDetails where empcode='" + _userCode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

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

    protected void bind_fyear()
    {
        int year = DateTime.Now.Year, count = 1;
        lbl_fyear.Items.Insert(0, new ListItem("---select---"));

        for (int i = year - 1; i < year + 5; i++)
        {
            lbl_fyear.Items.Insert(count, new ListItem(i.ToString() + "-" + (i + 1).ToString()));
            count++;
        }
    }

    protected void opt_loan_yes_CheckedChanged(object sender, EventArgs e)
    {
        loan_int_enable();
    }
    protected void opt_loan_no_CheckedChanged(object sender, EventArgs e)
    {
        loan_int_enable();
    }
    protected void rdoyearly_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoyearly.Checked)
        {
            yearly.Visible = true;
            monthly.Visible = false;
        }
        else
        {
            yearly.Visible = false;
            monthly.Visible = true;
        }
    }
    protected void rdomonthly_CheckedChanged(object sender, EventArgs e)
    {
        if (rdomonthly.Checked)
        {
            yearly.Visible = false;
            monthly.Visible = true;
        }
        else
        {
            yearly.Visible = true;
            monthly.Visible = false;
        }
    }
    protected void btn_6A_add_Click(object sender, EventArgs e)
    {
        deduction_grid();
        dd_smaster.SelectedIndex = -1;
        dd_sdetail.SelectedIndex = -1;
        txt_samnt.Text = "";
    }
    protected void grid_6A_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["deduction"];
        DataRow drfind_deduction = dtable.Rows.Find(Convert.ToString(grid_6A.DataKeys[e.RowIndex].Value));

        if (drfind_deduction != null)
        {
            drfind_deduction.Delete();
            Session["deduction"] = dtable;
            bindlist_deduction();
        }        
    }

    //=================================== Function for conversion of Amount from String to decimal ===========================================//

    protected Decimal convert_decimalamnt(string str)
    {
        Decimal damnt;
        if (str == "")
            damnt = 0;
        else
            damnt = Convert.ToDecimal(str);
        return damnt;
    }

    //=================================== Function for conversion of Number from String to int ===========================================//

    protected int convert_nochild(string str2)
    {
        int n;
        if (str2 == "")
            n = 0;
        else
            n = Convert.ToInt16(str2);
        return n;
    }

    //=================================== Insert Declaration Details ===========================================//

    protected void insert_declaration_detail(Decimal ramnt, Decimal aamnt, Decimal namnt, int nchild, Decimal a80c, Decimal a80ccc, Decimal a80ccd, Decimal a80d, Decimal a80e, Decimal a80dd, Decimal a80g, Decimal a80cf)
    {
        SqlParameter[] sqlparam = new SqlParameter[31];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@financialyr", SqlDbType.VarChar, 50);
        sqlparam[1].Value = lbl_fyear.Text;

        sqlparam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[2].Value = Session["name"].ToString();

        sqlparam[3] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[3].Value = DateTime.Now;

        sqlparam[4] = new SqlParameter("@rent", SqlDbType.Decimal);
        sqlparam[4].Value = ramnt;

        sqlparam[5] = new SqlParameter("@chapter6A", SqlDbType.Decimal);
        sqlparam[5].Value = aamnt;

        sqlparam[6] = new SqlParameter("@nsc", SqlDbType.Decimal);
        sqlparam[6].Value = namnt;

        sqlparam[7] = new SqlParameter("@children", SqlDbType.Int);
        sqlparam[7].Value = nchild;

        sqlparam[8] = new SqlParameter("@metro", SqlDbType.Int);
        sqlparam[8].Value = dd_metro.SelectedValue;

        sqlparam[9] = new SqlParameter("@hself_occupied", SqlDbType.Bit);
        if (opt_self_yes.Checked == true)
            sqlparam[9].Value = 1;
        else
            sqlparam[9].Value = 0;

        sqlparam[10] = new SqlParameter("@hloan_borrowed", SqlDbType.Bit);
        if (opt_loan_yes.Checked == true)
            sqlparam[10].Value = 1;
        else
            sqlparam[10].Value = 0;

        sqlparam[11] = new SqlParameter("@80C", SqlDbType.Decimal);
        sqlparam[11].Value = a80c;

        sqlparam[12] = new SqlParameter("@80CCC", SqlDbType.Decimal);
        sqlparam[12].Value = a80ccc;

        sqlparam[13] = new SqlParameter("@80CCD", SqlDbType.Decimal);
        sqlparam[13].Value = a80ccd;

        sqlparam[14] = new SqlParameter("@80D", SqlDbType.Decimal);
        sqlparam[14].Value = a80d;

        sqlparam[15] = new SqlParameter("@80E", SqlDbType.Decimal);
        sqlparam[15].Value = a80e;

        sqlparam[16] = new SqlParameter("@80DD", SqlDbType.Decimal);
        sqlparam[16].Value = a80dd;

        sqlparam[17] = new SqlParameter("@80G", SqlDbType.Decimal);
        sqlparam[17].Value = a80g;

        sqlparam[18] = new SqlParameter("@interest_house", SqlDbType.Decimal);
        if (txt_houseint.Text == "")
            sqlparam[18].Value = 0;
        else
            sqlparam[18].Value = txt_houseint.Text.Trim();

        sqlparam[19] = new SqlParameter("@status", SqlDbType.TinyInt);
        sqlparam[19].Value = 0;

        sqlparam[20] = new SqlParameter("@80CF", SqlDbType.Decimal);
        sqlparam[20].Value = a80cf;

        sqlparam[21] = new SqlParameter("@otherCity", SqlDbType.VarChar, 100);
        sqlparam[21].Value = DBNull.Value;

        sqlparam[22] = new SqlParameter("@PEIncome", SqlDbType.Decimal);
        sqlparam[22].Value = txt_Income.Text;

        sqlparam[23] = new SqlParameter("@PEPT", SqlDbType.Decimal);
        sqlparam[23].Value = txt_prof_tax.Text;

        sqlparam[24] = new SqlParameter("@PEPF", SqlDbType.Decimal);
        sqlparam[24].Value = txt_fund_paid.Text;

        sqlparam[25] = new SqlParameter("@PEIT", SqlDbType.Decimal);
        sqlparam[25].Value = txt_tax_paid.Text;

        sqlparam[26] = new SqlParameter("@LORentReceived", SqlDbType.Decimal);
        sqlparam[26].Value = txt_rent.Text;

        sqlparam[27] = new SqlParameter("@LOMunicipalTaxPaid", SqlDbType.VarChar, 100);
        sqlparam[27].Value = txt_less_tax.Text;

        sqlparam[28] = new SqlParameter("@LOInterestPaid", SqlDbType.Decimal);
        sqlparam[28].Value = txt_housing.Text;

        sqlparam[29] = new SqlParameter("@MedicalBill", SqlDbType.VarChar, 100);
        sqlparam[29].Value = txt_medical_bil.Text;

        sqlparam[30] = new SqlParameter("@LTA", SqlDbType.VarChar, 100);
        sqlparam[30].Value = txt_LTA.Text;

        //Common.Console.Output.AssignParameter(a, 21, "@PEIncome", "Decimal", 100, PEIncome.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 22, "@PEPT", "Decimal", 100, PEPT.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 23, "@PEPF", "Decimal", 100, PEPF.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 24, "@PEIT", "Decimal", 100, PEIT.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 25, "@LORentReceived", "Decimal", 100, LORentReceived.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 26, "@LOMunicipalTaxPaid", "Decimal", 100, LOMunicipalTaxPaid.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 27, "@LOInterestPaid", "Decimal", 100, LOInterestPaid.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 28, "@MedicalBill", "Decimal", 100, MedicalBillSubmitted.Text.Trim());
        //Common.Console.Output.AssignParameter(a, 29, "@LTA", "Decimal", 100, LTA.Text.Trim());

        int a = (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_declaration", sqlparam)));

        if (a > 0)
        {
            insert_rent_detail(a);
            insert_children_detail(a);
            insert_6A_detail(a);
            insert_nsc_detail(a);
            
            //  insert_LetOutProperty_detail(a);
            //  insert_PreviousEmploymentSalary_detail(a);
            message.InnerHtml = " Declaration made successfully ";
        }
        else
            message.InnerHtml = " Declaration for employee " + txt_employee.Text + " has been already done ";
    }

    protected void insert_nsc_detail(int ref_no)
    {
        if (Session["certificate"] != null)
        {
            dtable = (DataTable)Session["certificate"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[5];

                sqlParam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
                sqlParam[0].Value = ref_no;

                sqlParam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                sqlParam[1].Value = Session["name"].ToString();

                sqlParam[2] = new SqlParameter("@certi_no", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["certi_no"].ToString();

                sqlParam[3] = new SqlParameter("@inv_date", SqlDbType.DateTime);
                sqlParam[3].Value = dtable.Rows[i]["inv_date"].ToString();

                sqlParam[4] = new SqlParameter("@nsc_amount", SqlDbType.Decimal);
                sqlParam[4].Value = dtable.Rows[i]["nsc_amount"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_nsc_detail", sqlParam);
            }
        }
    }   

    protected void insert_6A_detail(int ref_no)
    {
        if (Session["deduction"] != null)
        {
            dtable = (DataTable)Session["deduction"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                CheckBox chkstatus = (CheckBox)grid_6A.Rows[i].Cells[0].FindControl("chkstatus");
                if (chkstatus != null)
                {
                    SqlParameter[] sqlParam = new SqlParameter[7];

                    sqlParam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
                    sqlParam[0].Value = ref_no;

                    sqlParam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                    sqlParam[1].Value = Session["name"].ToString();

                    sqlParam[2] = new SqlParameter("@section_name", SqlDbType.VarChar, 50);
                    sqlParam[2].Value = dtable.Rows[i]["section_name"].ToString();

                    sqlParam[3] = new SqlParameter("@section_detail", SqlDbType.VarChar, 200);
                    sqlParam[3].Value = dtable.Rows[i]["section_detail"].ToString();

                    sqlParam[4] = new SqlParameter("@a_amount", SqlDbType.Decimal);
                    sqlParam[4].Value = dtable.Rows[i]["a_amount"].ToString();

                    sqlParam[5] = new SqlParameter("@status", SqlDbType.Bit);
                    sqlParam[5].Value = chkstatus.Checked;

                    sqlParam[6] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlParam[6].Value = txt_employee.Text.Trim().ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_6A_detail", sqlParam);
                }
            }
        }
    }

    //=================================== Insert Rent Paid Details ===========================================//

    protected void insert_rent_detail(int ref_no)
    {
        SqlParameter[] sqlparam = new SqlParameter[16];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = ref_no;

        sqlparam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[1].Value = Session["name"].ToString();

        sqlparam[2] = new SqlParameter("@apr_amnt", SqlDbType.Decimal);
        sqlparam[2].Value = convert_decimalamnt(txt_apr.Text);

        sqlparam[3] = new SqlParameter("@may_amnt", SqlDbType.Decimal);
        sqlparam[3].Value = convert_decimalamnt(txt_may.Text);

        sqlparam[4] = new SqlParameter("@jun_amnt", SqlDbType.Decimal);
        sqlparam[4].Value = convert_decimalamnt(txt_june.Text);

        sqlparam[5] = new SqlParameter("@jul_amnt", SqlDbType.Decimal);
        sqlparam[5].Value = convert_decimalamnt(txt_jul.Text);

        sqlparam[6] = new SqlParameter("@aug_amnt", SqlDbType.Decimal);
        sqlparam[6].Value = convert_decimalamnt(txt_aug.Text);

        sqlparam[7] = new SqlParameter("@sep_amnt", SqlDbType.Decimal);
        sqlparam[7].Value = convert_decimalamnt(txt_sep.Text);

        sqlparam[8] = new SqlParameter("@oct_amnt", SqlDbType.Decimal);
        sqlparam[8].Value = convert_decimalamnt(txt_oct.Text);

        sqlparam[9] = new SqlParameter("@nov_amnt", SqlDbType.Decimal);
        sqlparam[9].Value = convert_decimalamnt(txt_nov.Text);

        sqlparam[10] = new SqlParameter("@dec_amnt", SqlDbType.Decimal);
        sqlparam[10].Value = convert_decimalamnt(txt_dec.Text);

        sqlparam[11] = new SqlParameter("@jan_amnt", SqlDbType.Decimal);
        sqlparam[11].Value = convert_decimalamnt(txt_jan.Text);

        sqlparam[12] = new SqlParameter("@feb_amnt", SqlDbType.Decimal);
        sqlparam[12].Value = convert_decimalamnt(txt_feb.Text);

        sqlparam[13] = new SqlParameter("@mar_amnt", SqlDbType.Decimal);
        sqlparam[13].Value = convert_decimalamnt(txt_mar.Text);

        sqlparam[14] = new SqlParameter("empcode", SqlDbType.VarChar, 50);
        sqlparam[14].Value = txt_employee.Text.Trim().ToString();

        sqlparam[15] = new SqlParameter("@doc", SqlDbType.VarChar, 100);
        if (flupload.HasFile)
        {
            try
            {
                string strFileName;
                string file_name = txt_employee.Text + System.DateTime.Now.GetHashCode().ToString();
                strFileName = flupload.FileName;
                flupload.PostedFile.SaveAs(Server.MapPath("../admin/upload/TDS/" + file_name + "_" + strFileName));
                sqlparam[15].Value = file_name + "_" + strFileName;
            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else sqlparam[15].Value = "";

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_rent_detail", sqlparam);

    }

    //=================================== Insert Children Studying Details ===========================================//

    protected void insert_children_detail(int ref_no)
    {
        SqlParameter[] sqlparam = new SqlParameter[15];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = ref_no;

        sqlparam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[1].Value = Session["name"].ToString();

        sqlparam[2] = new SqlParameter("@apr_no", SqlDbType.Int);
        sqlparam[2].Value = convert_nochild(txt_child.Text);

        sqlparam[3] = new SqlParameter("@may_no", SqlDbType.Int);
        sqlparam[3].Value = convert_nochild(txt_child.Text);

        sqlparam[4] = new SqlParameter("@jun_no", SqlDbType.Int);
        sqlparam[4].Value = convert_nochild(txt_child.Text);

        sqlparam[5] = new SqlParameter("@jul_no", SqlDbType.Int);
        sqlparam[5].Value = convert_nochild(txt_child.Text);

        sqlparam[6] = new SqlParameter("@aug_no", SqlDbType.Int);
        sqlparam[6].Value = convert_nochild(txt_child.Text);

        sqlparam[7] = new SqlParameter("@sep_no", SqlDbType.Int);
        sqlparam[7].Value = convert_nochild(txt_child.Text);

        sqlparam[8] = new SqlParameter("@oct_no", SqlDbType.Int);
        sqlparam[8].Value = convert_nochild(txt_child.Text);

        sqlparam[9] = new SqlParameter("@nov_no", SqlDbType.Int);
        sqlparam[9].Value = convert_nochild(txt_child.Text);

        sqlparam[10] = new SqlParameter("@dec_no", SqlDbType.Int);
        sqlparam[10].Value = convert_nochild(txt_child.Text);

        sqlparam[11] = new SqlParameter("@jan_no", SqlDbType.Int);
        sqlparam[11].Value = convert_nochild(txt_child.Text);

        sqlparam[12] = new SqlParameter("@feb_no", SqlDbType.Int);
        sqlparam[12].Value = convert_nochild(txt_child.Text);

        sqlparam[13] = new SqlParameter("@mar_no", SqlDbType.Int);
        sqlparam[13].Value = convert_nochild(txt_child.Text);

        sqlparam[14] = new SqlParameter("empcode", SqlDbType.VarChar, 50);
        sqlparam[14].Value = txt_employee.Text.Trim().ToString();

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_children_detail", sqlparam);

    }


    //=================================== Insert 6A Detail into 6A Grid ===========================================//  

    protected void deduction_grid()
    {
        DataRow dr;
        if (Session["deduction"] == null)
        {
            create_deduction_table();
        }

        dtable = (DataTable)Session["deduction"];

        DataRow drfind = dtable.Rows.Find(dd_sdetail.SelectedValue);

        if (drfind != null)
        {
            message.InnerHtml = "Same detail can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["section_name"] = dd_smaster.SelectedValue;
            dr["section_detail"] = dd_sdetail.SelectedValue;
            dr["a_amount"] = txt_samnt.Text.Trim();

            dtable.Rows.Add(dr);
        }
        Session["deduction"] = dtable;
        bindlist_deduction();
    }

    protected void bindlist_deduction()
    {
        if (Session["deduction"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["deduction"];
            dview = new DataView(dtable);
            dview.Sort = "section_name";
        }
        grid_6A.DataSource = dview;
        grid_6A.DataBind();
    }

    protected void create_deduction_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("section_name", typeof(string));
        dtable.Columns.Add("section_detail", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["section_detail"] };
        dtable.Columns.Add("a_amount", typeof(string));
        Session["deduction"] = dtable;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Decimal ramnt = 0, aamnt = 0, namnt = 0;
        int nchild = 0;
        Decimal a80c = 0, a80ccc = 0, a80ccd = 0, a80d = 0, a80e = 0, a80dd = 0, a80g = 0, a80cf = 0;
        
        if (rdoyearly.Checked)
        {
            txt_apr.Text = txt_mth.Text; txt_may.Text = txt_mth.Text; txt_june.Text = txt_mth.Text; txt_jul.Text = txt_mth.Text; txt_aug.Text = txt_mth.Text; txt_sep.Text = txt_mth.Text;
            txt_oct.Text = txt_mth.Text; txt_nov.Text = txt_mth.Text; txt_dec.Text = txt_mth.Text; txt_jan.Text = txt_mth.Text; txt_feb.Text = txt_mth.Text; txt_mar.Text = txt_mth.Text;
        }
        ramnt = convert_decimalamnt(txt_apr.Text) + convert_decimalamnt(txt_may.Text) + convert_decimalamnt(txt_june.Text) + convert_decimalamnt(txt_jul.Text) + convert_decimalamnt(txt_aug.Text) + convert_decimalamnt(txt_sep.Text) +
        convert_decimalamnt(txt_oct.Text) + convert_decimalamnt(txt_nov.Text) + convert_decimalamnt(txt_dec.Text) + convert_decimalamnt(txt_jan.Text) + convert_decimalamnt(txt_feb.Text) + convert_decimalamnt(txt_mar.Text);

        if (Session["deduction"] != null)
        {
            dtable = (DataTable)Session["deduction"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                CheckBox chkstatus = (CheckBox)grid_6A.Rows[i].Cells[0].FindControl("chkstatus");
                if (chkstatus != null)
                {
                    if (chkstatus.Checked)
                    {
                        aamnt = aamnt + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80C")
                            a80c = a80c + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80CCC")
                            a80ccc = a80ccc + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80CCD")
                            a80ccd = a80ccd + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80D")
                            a80d = a80d + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80E")
                            a80e = a80e + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80DD")
                            a80dd = a80dd + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80G")
                            a80g = a80g + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80CF")
                            a80cf = a80cf + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());
                    }
                }
            }
        }

        if (Session["certificate"] != null)
        {
            dtable = (DataTable)Session["certificate"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                namnt = namnt + Convert.ToDecimal(dtable.Rows[i]["nsc_amount"].ToString());
            }
        }

        nchild = convert_nochild(txt_child.Text) * 12;
        insert_declaration_detail(ramnt, aamnt, namnt, nchild, a80c, a80ccc, a80ccd, a80d, a80e, a80dd, a80g, a80cf);

        reset_detail();
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset_detail();
    }
    protected void dd_sdetail_DataBound(object sender, EventArgs e)
    {
        dd_sdetail.Items.Insert(0, new ListItem("Select Section Detail", "0"));
    }

    protected void reset_detail()
    {
        txt_employee.Text = "";
        txt_houseint.Text = "";
        opt_self_yes.Checked = true;
        opt_self_no.Checked = false;
        opt_loan_yes.Checked = true;
        opt_loan_no.Checked = false;
        txt_houseint.Enabled = true;
        reset_rentdetail();
        reset_childrendetail();
        reset_6Adetail();
        // reset_nscdetail();
    }

    protected void reset_rentdetail()
    {
        dd_metro.SelectedValue = "1";
        rdoyearly.Checked = true;
        txt_mth.Text = "";
        txt_apr.Text = "";
        txt_may.Text = "";
        txt_june.Text = "";
        txt_jul.Text = "";
        txt_aug.Text = "";
        txt_sep.Text = "";
        txt_oct.Text = "";
        txt_nov.Text = "";
        txt_dec.Text = "";
        txt_jan.Text = "";
        txt_feb.Text = "";
        txt_mar.Text = "";
    }

    protected void reset_childrendetail()
    {
        txt_child.Text = "";
    }

    protected void reset_6Adetail()
    {
        dd_smaster.SelectedIndex = -1;
        dd_sdetail.SelectedIndex = -1;
        txt_samnt.Text = "";
        Session.Remove("deduction");
        grid_6A.DataSource = "";
        grid_6A.DataBind();
    }

    //protected void reset_nscdetail()
    //{
    //    txt_certi.Text = "";
    //    txt_invdate.Text = "";
    //    txt_nscamnt.Text = "";
    //    Session.Remove("certificate");
    //    grid_nsc.DataSource = "";
    //    grid_nsc.DataBind();
    //}

    //=============================== Check for House Interest Applicable ================================//

    protected void loan_int_enable()
    {
        if (opt_loan_no.Checked == true)
        {
            txt_houseint.Enabled = false;
            txt_houseint.Text = "";
        }
        else
            txt_houseint.Enabled = true;
    }

    protected void insert_PreviousEmploymentSalary_detail(int ref_no)
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = ref_no;

        sqlparam[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[1].Value = txt_employee.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@income_after_exemption", SqlDbType.Decimal);
        sqlparam[2].Value = convert_decimalamnt(txt_Income.Text);

        sqlparam[3] = new SqlParameter("@prof_tax_paid", SqlDbType.Decimal);
        sqlparam[3].Value = convert_decimalamnt(txt_prof_tax.Text);

        sqlparam[4] = new SqlParameter("@fund_paid", SqlDbType.Decimal);
        sqlparam[4].Value = convert_decimalamnt(txt_fund_paid.Text);

        sqlparam[5] = new SqlParameter("@tax_paid", SqlDbType.Decimal);
        sqlparam[5].Value = convert_decimalamnt(txt_tax_paid.Text);


        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_taxdeclaration_pre_empsalary", sqlparam);

    }

    protected void insert_LetOutProperty_detail(int ref_no)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = ref_no;

        sqlparam[1] = new SqlParameter("@Rent_Received", SqlDbType.Decimal);
        sqlparam[1].Value = convert_decimalamnt(txt_rent.Text);

        sqlparam[2] = new SqlParameter("@less_paid", SqlDbType.Decimal);
        sqlparam[2].Value = convert_decimalamnt(txt_less_tax.Text);

        sqlparam[3] = new SqlParameter("@tax_housing", SqlDbType.Decimal);
        sqlparam[3].Value = convert_decimalamnt(txt_housing.Text);

        sqlparam[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_employee.Text;


        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_declaration_letout", sqlparam);

    }

   

}