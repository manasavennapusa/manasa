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
using System.Data.SqlTypes;

public partial class payroll_admin_editemployeepaystructure : System.Web.UI.Page
{
    string sqlstr, sqlstrPayheadName, sqlstr1;
    DataSet ds = new DataSet();
    DataSet dsPayheadName = new DataSet();
    DataTable dtable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

            bind_month();
            bind_year();
            string empcode = Request.QueryString["empcode"].ToString();
            int paystructureid = Convert.ToInt32(Request.QueryString["paystructureid"]);
            getemppaystructuredetails(empcode, paystructureid);
            //bind_PayheadName();
            lblpayHeadMsg.Visible = false;
            lblCheckEmpRecords.Text = "";
            rngcheckpercentage.Enabled = false;
            drpPayCalType.Items[2].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            valuebase.Visible = false;
        }
        lblCheckEmpRecords.Text = "";
    }

    protected void drpPayCalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(drpPayHead.SelectedValue) >= 1)
        {
            //drpPayCalType.SelectedIndex = 0;
            drpPayCalType.Items[2].Enabled = true;
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = true;
            if (drpPayCalType.SelectedValue == "0")
            {
                valuebase.Visible = false;
                txtValueBase.Text = "";
                txtamount.Enabled = true;
            }
            else if (drpPayCalType.SelectedValue == "2")
            {
                valuebase.Visible = true;
                divbasic.Visible = true;
                txtamount.Enabled = false;
            }
            if (drpPayCalType.SelectedValue == "3")
            {
                valuebase.Visible = false;
                txtValueBase.Text = "";
                txtamount.Enabled = true;
            }
        }
    }


    protected void bind_PayheadName()
    {
        sqlstrPayheadName = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where id not in (2,3,7,12) and type<>3 and status=1";

        dsPayheadName = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrPayheadName);

        drpPayHead.DataTextField = "payhead_name";
        drpPayHead.DataValueField = "id";

        drpPayHead.DataSource = dsPayheadName;
        drpPayHead.DataBind();
    }


    protected void drpPayHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        dtable = (DataTable)Session["EmployeePayStructure"];

        if (Session["EmployeePayStructure"] == null)
        {
            lblCheckEmpRecords.Text = "";
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Please Insert Basic Details first";
            drpPayHead.SelectedValue = "0";
            valuebase.Visible = false;
            rngcheckpercentage.Enabled = false;
            btn_submit.Visible = false;
            lblpercent.Visible = false;
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            txtValueBase.Text = "";
            divbasic.Visible = true;
        }
        else
        {
            if (drpPayHead.SelectedValue == "0")
            {
                drpPayCalType.Items[0].Enabled = true;
                drpPayCalType.Items[1].Enabled = true;
                drpPayCalType.Items[2].Enabled = false;
                // drpPayCalType.Items[3].Enabled = false;
                drpPayCalType.Items[3].Enabled = false;
                rngcheckpercentage.Enabled = false;
                lblpercent.Visible = false;
                valuebase.Visible = false;
                txtamount.Enabled = true;
                txtamount.Text = "";
                divbasic.Visible = true;
                employeePayStructure.Visible = true;
            }
            else if (drpPayHead.SelectedValue == "1")
            {
                //sqlstr = @"Select EPF, maxamount, minamount from tbl_payroll_providentfund where status=1";
                //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                //txtValueBase.Text = ds.Tables[0].Rows[0][0].ToString();

                //decimal MaxBasic = Convert.ToDecimal((ds.Tables[0].Rows[0][1].ToString() == "") ? "0.00" : ds.Tables[0].Rows[0][1].ToString());
                //decimal MinBasic = Convert.ToDecimal((ds.Tables[0].Rows[0][2].ToString() == "") ? "0.00" : ds.Tables[0].Rows[0][2].ToString());


                //dtable = (DataTable)Session["EmployeePayStructure"];
                //DataRow drfind = dtable.Rows.Find(0);
                //decimal amount = Convert.ToDecimal(drfind["Amount"]);
                //decimal value_base = Convert.ToDecimal(txtValueBase.Text);

                //if (amount > MaxBasic && MaxBasic != 0)
                //{

                //    if (drpRoundValue.SelectedItem.Text == "Higher Rupees")
                //    {
                //        txtamount.Text = Convert.ToString(Convert.ToInt32((value_base * MaxBasic) / 100) + 1);
                //    }
                //    else if (drpRoundValue.SelectedItem.Text == "Nearest Rupees")
                //    {
                //        txtamount.Text = Convert.ToString(System.Math.Round(Convert.ToDecimal((value_base * MaxBasic) / 100), 0));
                //    }
                //    else if (drpRoundValue.SelectedItem.Text == "Normal")
                //    {
                //        txtamount.Text = Convert.ToString(Convert.ToDecimal((value_base * MaxBasic) / 100));
                //    }

                //}
                //else if (amount < MinBasic && MinBasic != 0)
                //{
                //    if (drpRoundValue.SelectedItem.Text == "Higher Rupees")
                //    {
                //        txtamount.Text = Convert.ToString(Convert.ToInt32((value_base * MinBasic) / 100) + 1);
                //    }
                //    else if (drpRoundValue.SelectedItem.Text == "Nearest Rupees")
                //    {
                //        txtamount.Text = Convert.ToString(System.Math.Round(Convert.ToDecimal((value_base * MinBasic) / 100), 0));
                //    }
                //    else if (drpRoundValue.SelectedItem.Text == "Normal")
                //    {
                //        txtamount.Text = Convert.ToString(Convert.ToDecimal((value_base * MinBasic) / 100));
                //    }
                //}
                //else
                //{

                //    if (drpRoundValue.SelectedItem.Text == "Higher Rupees")
                //    {
                //        txtamount.Text = Convert.ToString(Convert.ToInt32((value_base * amount) / 100) + 1);
                //    }
                //    else if (drpRoundValue.SelectedItem.Text == "Nearest Rupees")
                //    {
                //        txtamount.Text = Convert.ToString(System.Math.Round(Convert.ToDecimal((value_base * amount) / 100), 0));
                //    }
                //    else if (drpRoundValue.SelectedItem.Text == "Normal")
                //    {
                //        txtamount.Text = Convert.ToString(Convert.ToDecimal((value_base * amount) / 100));
                //    }
                //}

                drpPayCalType.Items[0].Enabled = false;
                drpPayCalType.Items[1].Enabled = false;
                drpPayCalType.Items[2].Enabled = true;
                //drpPayCalType.Items[3].Enabled = false;
                drpPayCalType.Items[3].Enabled = true;
                rngcheckpercentage.Enabled = true;
                lblpercent.Visible = true;
                valuebase.Visible = true;
                txtamount.Enabled = false;
                lblCheckEmpRecords.Text = "";
                divbasic.Visible = true;

                //if (drpPayCalType.SelectedValue == "0")
                //{
                //    valuebase.Visible = false;
                //    txtValueBase.Text = "";
                //    txtamount.Enabled = true;
                //}
                //else 
                if (drpPayCalType.SelectedValue == "2")
                {
                    valuebase.Visible = true;
                    divbasic.Visible = true;
                    txtamount.Enabled = false;
                }
                if (drpPayCalType.SelectedValue == "3")
                {
                    valuebase.Visible = false;
                    txtValueBase.Text = "";
                    txtamount.Enabled = true;
                }

            }
            else if (Convert.ToInt16(drpPayHead.SelectedValue) >= 2)
            {
                drpPayCalType.SelectedIndex = 0;
                drpPayCalType.Items[0].Enabled = true;
                drpPayCalType.Items[1].Enabled = false;
                drpPayCalType.Items[2].Enabled = true;
                //drpPayCalType.Items[3].Enabled = false;
                drpPayCalType.Items[3].Enabled = true;
                rngcheckpercentage.Enabled = true;
                lblpercent.Visible = true;
                valuebase.Visible = true;
                txtamount.Enabled = false;
                lblCheckEmpRecords.Text = "";
                txtamount.Text = "";
                txtValueBase.Text = "";
                divbasic.Visible = true;
                drpPayCalType.Items[2].Enabled = true;
                drpPayCalType.Items[0].Enabled = true;
                drpPayCalType.Items[1].Enabled = false;
                //drpPayCalType.Items[3].Enabled = false;
                drpPayCalType.Items[3].Enabled = true;

                if (drpPayCalType.SelectedValue == "0")
                {
                    valuebase.Visible = false;
                    txtValueBase.Text = "";
                    txtamount.Enabled = true;
                }
                else if (drpPayCalType.SelectedValue == "2")
                {
                    valuebase.Visible = true;
                    divbasic.Visible = true;
                    txtamount.Enabled = false;
                }
                if (drpPayCalType.SelectedValue == "3")
                {
                    valuebase.Visible = false;
                    txtValueBase.Text = "";
                    txtamount.Enabled = true;
                }
            }
            //else if (drpPayHead.SelectedValue == "3")
            //{
            //        sqlstr = @"Select employeecontribution from tbl_payroll_esi where status=1";
            //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            //        txtValueBase.Text = ds.Tables[0].Rows[0][0].ToString();

            //        drpPayCalType.Items[0].Enabled = false;
            //        drpPayCalType.Items[1].Enabled = false;
            //        drpPayCalType.Items[2].Enabled = true;
            //        rngcheckpercentage.Enabled = true;
            //        lblpercent.Visible = true;
            //        valuebase.Visible = true;
            //        txtamount.Enabled = false;
            //        lblCheckEmpRecords.Text = "";
            //        txtamount.Text = "";
            //        divbasic.Visible = false;
            //}
            //else if (drpPayHead.SelectedValue == "4" || drpPayHead.SelectedValue == "3")
            //{
            //        drpPayCalType.Items[0].Enabled = false;
            //        drpPayCalType.Items[1].Enabled = false;
            //        drpPayCalType.Items[2].Enabled = true;
            //        //drpPayCalType.Items[3].Enabled = false;
            //        drpPayCalType.Items[3].Enabled = true;
            //        rngcheckpercentage.Enabled = true;
            //        lblpercent.Visible = true;
            //        valuebase.Visible = true;
            //        txtamount.Enabled = false;
            //        lblCheckEmpRecords.Text = "";
            //        txtamount.Text = "";
            //        txtValueBase.Text = "";
            //        divbasic.Visible = true;

            //}
            //else if (drpPayHead.SelectedValue =="5" || drpPayHead.SelectedValue=="6")
            //{

            //        drpPayCalType.Items[0].Enabled = false;
            //        drpPayCalType.Items[1].Enabled = false;
            //        drpPayCalType.Items[2].Enabled = false;
            //        //drpPayCalType.Items[3].Enabled = true;
            //        drpPayCalType.Items[3].Enabled = false;
            //        drpPayCalType.SelectedValue = "0";
            //        valuebase.Visible = true;
            //        lblCheckEmpRecords.Text = "";
            //        txtamount.Text = "";
            //        txtValueBase.Text = "";
            //        divbasic.Visible = true;
            //        valuebase.Visible = false;
            //        txtamount.Enabled = true;
            //}
            //else if (Convert.ToInt16(drpPayHead.SelectedValue) >= 7)
            //{
            //    drpPayCalType.Items[0].Enabled = true;
            //    drpPayCalType.Items[1].Enabled = false;
            //    drpPayCalType.Items[2].Enabled = true;
            //    //drpPayCalType.Items[3].Enabled = false;
            //    drpPayCalType.Items[3].Enabled = true;
            //    drpPayCalType.SelectedValue = "0";
            //    valuebase.Visible = true;
            //    lblCheckEmpRecords.Text = "";
            //    txtamount.Text = "";
            //    txtValueBase.Text = "";
            //    divbasic.Visible = true;
            //    valuebase.Visible = false;
            //    txtamount.Enabled = true;

            //}
        }
    }

    protected void txtValueBase_TextChanged(object sender, EventArgs e)
    {

        //if (drpPayHead.SelectedValue == "2" || drpPayHead.SelectedValue == "3" || drpPayHead.SelectedValue == "4" || Convert.ToInt32(drpPayHead.SelectedValue) >= 5)
        //{
        dtable = (DataTable)Session["EmployeePayStructure"];
        decimal amount = Convert.ToDecimal(dtable.Rows[0][6]);
        decimal value_base = Convert.ToDecimal(txtValueBase.Text);

        if (drpRoundValue.SelectedItem.Text == "Higher Rupees")
        {
            if (Convert.ToDecimal((value_base * amount) / 100) / Convert.ToInt32((value_base * amount) / 100) == 1)
                txtamount.Text = Convert.ToString(Convert.ToInt32((value_base * amount) / 100));
            else
                txtamount.Text = Convert.ToString(Convert.ToInt32((value_base * amount) / 100) + 1);
        }
        else if (drpRoundValue.SelectedItem.Text == "Nearest Rupees")
        {
            txtamount.Text = Convert.ToString(System.Math.Round(Convert.ToDecimal((value_base * amount) / 100), 0));
        }
        else if (drpRoundValue.SelectedItem.Text == "Normal")
        {
            txtamount.Text = Convert.ToString(Convert.ToDecimal((value_base * amount) / 100));
        }
        //}
    }

    protected void CreateDataTable()
    {
        dtable = new DataTable();

        dtable.Columns.Add("Empcode", typeof(string));

        dtable.Columns.Add("PayheadID", typeof(int));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["PayheadID"] };

        dtable.Columns.Add("PayheadName", typeof(string));

        dtable.Columns.Add("PayCalculationType", typeof(string));

        dtable.Columns.Add("PayCalculationValue", typeof(int));

        dtable.Columns.Add("ValueBase", typeof(string));

        dtable.Columns.Add("Amount", typeof(string));

        dtable.Columns.Add("RoundMethod", typeof(string));

        Session["EmployeePayStructure"] = dtable;
    }

    protected void emppaystructure()
    {
        DataRow dr;

        if (Session["EmployeePayStructure"] == null)
        {
            btn_submit.Visible = false;
            CreateDataTable();
        }

        dtable = (DataTable)Session["EmployeePayStructure"];

        DataRow drfind = dtable.Rows.Find(drpPayHead.SelectedValue.ToString());

        if (drfind != null)
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Payhead allready exists in employee pay structure queue";
        }
        else
        {
            dr = dtable.NewRow();
            dr["Empcode"] = txt_employee.Text.Trim();
            dr["PayheadID"] = drpPayHead.SelectedValue.ToString();
            dr["PayheadName"] = drpPayHead.SelectedItem.ToString();
            dr["PayCalculationType"] = drpPayCalType.SelectedItem.Text.ToString();
            dr["PayCalculationValue"] = drpPayCalType.SelectedValue;

            if (txtValueBase.Text.Trim() == "")
            {
                dr["ValueBase"] = "N/A";

            }
            else
            {
                dr["ValueBase"] = txtValueBase.Text.Trim();
            }


            if (txtamount.Text.Trim() == "")
            {
                dr["Amount"] = "N/A"; //System.Data.SqlTypes.SqlDecimal.Null;
            }
            else
            {
                dr["Amount"] = txtamount.Text.ToString();
            }

            dr["RoundMethod"] = drpRoundValue.SelectedItem.ToString();

            dtable.Rows.Add(dr);
        }


        Session["EmployeePayStructure"] = dtable;

        dtable = (DataTable)Session["EmployeePayStructure"];
        employeePayStructure.DataSource = dtable;
        employeePayStructure.DataBind();

        if (drpPayHead.SelectedValue == "0")
        {
            txtamount.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "1")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "2")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "3")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "4")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }

        else if (drpPayHead.SelectedValue == "5" || drpPayHead.SelectedValue == "6")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (Convert.ToInt16(drpPayHead.SelectedValue) >= 7)
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }



        if (dtable.Rows.Count > 0)
        {
            txt_employee.Enabled = false;
            pickemp.Visible = false;
        }

    }

    protected void Add_Click(object sender, EventArgs e)
    {

        emppaystructure();
        txtamount.Text = "";

    }
    protected void employeePayStructure_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["EmployeePayStructure"];

        DataRow drfind = dtable.Rows.Find(Convert.ToString(employeePayStructure.DataKeys[e.RowIndex].Value));

        if (dtable.Rows.Count > 1)
        {

            if (employeePayStructure.DataKeys[e.RowIndex].Value.ToString() == "0")
            {
                lblCheckEmpRecords.Visible = true;
                lblCheckEmpRecords.Text = "Can't delete! First delete all dependent records";
            }
            else
            {
                if (drfind != null)
                {
                    drfind.Delete();
                    Session["EmployeePayStructure"] = dtable;
                    dtable = (DataTable)Session["EmployeePayStructure"];
                    employeePayStructure.DataSource = dtable;
                    employeePayStructure.DataBind();
                    lblCheckEmpRecords.Text = "";
                }
            }

            txt_employee.Enabled = false;
            pickemp.Visible = false;
        }
        else if (dtable.Rows.Count == 1)
        {
            if (drfind != null)
            {
                drfind.Delete();
                Session["EmployeePayStructure"] = dtable;
                dtable = (DataTable)Session["EmployeePayStructure"];
                employeePayStructure.DataSource = dtable;
                employeePayStructure.DataBind();
                lblCheckEmpRecords.Text = "";
            }

            txt_employee.Enabled = false;
            pickemp.Visible = false;

        }


        if (dtable.Rows.Count < 1)
        {

            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = false;
            drpPayHead.SelectedValue = "0";
            txt_employee.Enabled = true;
            pickemp.Visible = true;
            btn_submit.Visible = false;
        }
    }

    public Boolean validate()
    {
        int i;
        sqlstr1 = @"select count(payhead) from tbl_payroll_employee_paystructure where empcode='" + txt_employee.Text.Trim() + "' and status = 1 and payhead=0";
        i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr1);
        if (i > 0)
            return false;
        else
            return true;
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            sqlstr1 = @"delete from tbl_payroll_employee_paystructure_detail where empcode='" + txt_employee.Text.Trim() + "' and status = 1";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);

            sqlstr1 = "update tbl_payroll_employee_paystructure set FROM_MONTH=@FROM_MONTH,FROM_YEAR=@FROM_YEAR,pf=@pf,esi=@esi,pt=@pt,modifieddate=@date,modifiedby=@user,PF_MODE=@pfmode,VPF=@vpf,VPFPer=@vpfper where id=@id";
            SqlParameter[] sqlparm = new SqlParameter[11];

            sqlparm[0] = new SqlParameter("@pf", SqlDbType.Bit);
            sqlparm[0].Value = Convert.ToBoolean(chk_pf.Checked);

            sqlparm[1] = new SqlParameter("@esi", SqlDbType.Bit);
            sqlparm[1].Value = Convert.ToBoolean(chk_esi.Checked);

            sqlparm[2] = new SqlParameter("@date", SqlDbType.DateTime, 8);
            sqlparm[2].Value = DateTime.Now;

            sqlparm[3] = new SqlParameter("@user", SqlDbType.VarChar, 50);
            sqlparm[3].Value = Session["name"].ToString();

            sqlparm[4] = new SqlParameter("@id", SqlDbType.Int);
            sqlparm[4].Value = Convert.ToInt32(Request.QueryString["paystructureid"]);

            sqlparm[5] = new SqlParameter("@pfmode", SqlDbType.Int);

            if (chk_pf.Checked)
            {
                if (chk_1500.Checked)
                {
                    sqlparm[5].Value = 1;
                }
                else if (chk_basic.Checked)
                {
                    sqlparm[5].Value = 2;
                }
            }
            else
            {
                sqlparm[5].Value = 0;
            }

            sqlparm[6] = new SqlParameter("@vpf", SqlDbType.Bit);
            sqlparm[6].Value = Convert.ToBoolean(chk_vpf.Checked);

            sqlparm[7] = new SqlParameter("@vpfper", SqlDbType.Decimal, 50);
            if (txt_vpf.Text != "")
            {
                sqlparm[7].Value = Convert.ToDecimal(txt_vpf.Text);
            }
            else
            {
                sqlparm[7].Value = 0;
            }

            sqlparm[7] = new SqlParameter("@vpfper", SqlDbType.Decimal, 50);
            if (txt_vpf.Text != "")
            {
                sqlparm[7].Value = Convert.ToDecimal(txt_vpf.Text);
            }
            else
            {
                sqlparm[7].Value = 0;
            }

            sqlparm[8] = new SqlParameter("@FROM_MONTH", SqlDbType.VarChar, 50);
            sqlparm[8].Value = dd_month_f.SelectedItem.Text;

            sqlparm[9] = new SqlParameter("@FROM_YEAR", SqlDbType.VarChar, 50);
            sqlparm[9].Value = dd_year_f.SelectedItem.Text;

            sqlparm[10] = new SqlParameter("@pt", SqlDbType.Bit);
            if (chk_pt.Checked == true)
            {
                sqlparm[10].Value = true;
            }
            else
            {
                sqlparm[10].Value = false;
            }


            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1, sqlparm);


            dtable = (DataTable)Session["EmployeePayStructure"];

            if (dtable.Rows.Count > 0)
            {


                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlparm = new SqlParameter[8];

                    sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparm[0].Value = dtable.Rows[i]["Empcode"].ToString();

                    sqlparm[1] = new SqlParameter("@payhead", SqlDbType.Int, 4);
                    sqlparm[1].Value = Convert.ToInt32(dtable.Rows[i]["PayheadID"].ToString());

                    sqlparm[2] = new SqlParameter("@calculation_type", SqlDbType.VarChar, 50);
                    sqlparm[2].Value = dtable.Rows[i]["PayCalculationValue"].ToString();

                    sqlparm[3] = new SqlParameter("@value_base", SqlDbType.Decimal);
                    sqlparm[3].Value = (dtable.Rows[i]["ValueBase"].ToString() == "N/A") ? System.Data.SqlTypes.SqlDecimal.Null : Convert.ToDecimal(dtable.Rows[i]["ValueBase"]);

                    sqlparm[4] = new SqlParameter("@amount", SqlDbType.Decimal);
                    sqlparm[4].Value = (dtable.Rows[i]["Amount"].ToString() == "N/A") ? System.Data.SqlTypes.SqlDecimal.Null : Convert.ToDecimal(dtable.Rows[i]["Amount"]);

                    sqlparm[5] = new SqlParameter("@round_method", SqlDbType.VarChar, 50);
                    sqlparm[5].Value = dtable.Rows[i]["RoundMethod"].ToString();

                    sqlparm[6] = new SqlParameter("@user", SqlDbType.VarChar, 50);
                    sqlparm[6].Value = Session["name"].ToString();

                    sqlparm[7] = new SqlParameter("@paystructure_id", SqlDbType.Int, 4);
                    sqlparm[7].Value = Request.QueryString["paystructureid"].ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_paystructure_detail", sqlparm);

                }
            }
            Session.Remove("EmployeePayStructure");
            Updatedconfirmationdiv.Visible = true;
            Divallhide.Visible = false;
            lblconfempcode.Text = txt_employee.Text.ToString();
            backid.Visible = true;
        }
        catch (Exception ex)
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Problem in adding Pay Structure records, try later";
        }
    }


    protected void getemppaystructuredetails(string empcode, int paystructureid)
    {
        DataRow dr;
        SqlParameter[] sqlparam = new SqlParameter[2];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = empcode;

        sqlparam[1] = new SqlParameter("@paystructure_id", SqlDbType.Int);
        sqlparam[1].Value = paystructureid;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_paystructuredetails", sqlparam);

        txt_employee.Text = empcode;
        txt_employee.Enabled = false;
        dd_month_f.SelectedItem.Text =(Convert.ToString(ds.Tables[0].Rows[0]["FROM_MONTH"].ToString()));
        //dd_month_t.SelectedValue = ds.Tables[0].Rows[0]["to_month"].ToString();
        dd_year_f.SelectedValue = ds.Tables[0].Rows[0]["FROM_YEAR"].ToString();
        // dd_year_t.SelectedValue=ds.Tables[0].Rows[0]["to_year"].ToString();
        chk_pf.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["pf"]);
        chk_esi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["esi"]);
        //chk_pt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["pt"]);
        if (ds.Tables[0].Rows[0]["VPF"].ToString() == "Yes")
        {
            chk_vpf.Checked = true;
            txt_vpf.Enabled = true;
            chk_pf.Checked = true;
        }
        else
        {
            chk_vpf.Checked = false;
        }

        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["pt"]) == true)
        {
            chk_pt.Checked = true;         
        }
        else
        {
            chk_pt.Checked = false;
        }

        txt_vpf.Text = ds.Tables[0].Rows[0]["VPFPer"].ToString();
        if (chk_pf.Checked)
        {
            chk_1500.Enabled = true;
            chk_basic.Enabled = true;

            if (ds.Tables[0].Rows[0]["PF_MODE"] == DBNull.Value)
            {

            }

            else if (ds.Tables[0].Rows[0]["PF_MODE"].ToString().Trim() == "")
            {

            }

            else if (Convert.ToInt32(ds.Tables[0].Rows[0]["PF_MODE"]) == 0)
            {

            }
            else if (Convert.ToInt32(ds.Tables[0].Rows[0]["PF_MODE"]) == 1)
            {
                chk_1500.Checked = true;
            }
            else if (Convert.ToInt32(ds.Tables[0].Rows[0]["PF_MODE"]) == 2)
            {
                chk_basic.Checked = true;
            }
        }
        pickemp.Visible = false;
        CreateDataTable();

        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            dr = dtable.NewRow();
            dr["Empcode"] = ds.Tables[1].Rows[i][5].ToString();
            dr["PayheadID"] = ds.Tables[1].Rows[i][6].ToString();
            dr["PayheadName"] = ds.Tables[1].Rows[i][0].ToString();
            dr["PayCalculationType"] = ds.Tables[1].Rows[i]["cal_type"].ToString();
            dr["PayCalculationValue"] = Convert.ToInt32(ds.Tables[1].Rows[i]["Calculation_Type"].ToString());
            dr["ValueBase"] = (ds.Tables[1].Rows[i][2].ToString() == "" ? "N/A" : ds.Tables[1].Rows[i][2].ToString());
            dr["Amount"] = (ds.Tables[1].Rows[i][3].ToString() == "" ? "N/A" : ds.Tables[1].Rows[i][3].ToString());
            dr["RoundMethod"] = ds.Tables[1].Rows[i][4].ToString();

            dtable.Rows.Add(dr);
        }

        employeePayStructure.DataSource = dtable;
        employeePayStructure.DataBind();
    }

    protected void btnviewok_Click(object sender, EventArgs e)
    {

        Response.Redirect("employeepaystructuredetails.aspx?empcode=" + txt_employee.Text + "&paystructureid=" + Convert.ToInt32(Request.QueryString["paystructureid"]));

    }
    //protected void employeePayStructure_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    employeePayStructure.PageIndex = e.NewPageIndex;
    //    dtable = (DataTable)Session["EmployeePayStructure"];
    //    employeePayStructure.DataSource = dtable;
    //    employeePayStructure.DataBind();
    //}
    protected void bind_month()
    {
        dd_month_f.Items.Insert(0, new ListItem("Select Month", "0"));
       
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, i).ToString("MMM");
            item.Value = i.ToString();
            dd_month_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
            //dd_month_t.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month_f.SelectedValue = a.Month.ToString();
        // dd_month_t.SelectedValue = "0";
    }

    protected void bind_year()
    {
        dd_year_f.Items.Insert(0, new ListItem("Select Year", "0"));
        for (int i = 1997; i <= DateTime.Now.Year + 1; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
            //dd_year_t.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year_f.SelectedValue = a.Year.ToString();
        //dd_year_t.SelectedValue = "0";
    }

    protected void chk_pf_CheckedChanged(object sender, EventArgs e)
    {
        if (!chk_pf.Checked)
        {
            chk_1500.Enabled = false;
            chk_basic.Enabled = false;

            chk_1500.Checked = false;
            chk_basic.Checked = false;
        }
        else
        {
            chk_1500.Enabled = true;
            chk_basic.Enabled = true;
        }
    }
    protected void chk_vpf_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_vpf.Checked == true)
        {
            txt_vpf.Enabled = true;
        }
        if (chk_vpf.Checked == false)
        {
            txt_vpf.Enabled = false;
            txt_vpf.Text = "0.00";
        }
    }
}
