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

public partial class payroll_admin_employee_paystructure : System.Web.UI.Page
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
            //bind_PayheadName();
            lblpayHeadMsg.Visible = false;
            lblCheckEmpRecords.Text = "";
            rngcheckpercentage.Enabled = false;
            drpPayCalType.Items[2].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            valuebase.Visible = false;
            btn_submit.Visible = false;
            Session.Remove("EmployeePayStructure");
        }
        lblCheckEmpRecords.Text = "";
    }

    protected void drpPayCalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(drpPayHead.SelectedValue) >= 1)
        {
            drpPayCalType.Items[2].Enabled = true;
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = false;
            drpPayCalType.Items[3].Enabled = true;
            if (drpPayCalType.SelectedValue == "0")
            {
                valuebase.Visible = false;
                txtValueBase.Text = "";
                txtamount.Enabled = true;
            }
            else if (drpPayCalType.SelectedValue == "2")
            {
                valuebase.Visible =true;
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


    //protected void bind_PayheadName()
    //{
    //    sqlstrPayheadName = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where id not in (2,3,7,12) and type<>3 and status=1";
    //    dsPayheadName = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrPayheadName);
    //    drpPayHead.DataTextField = "payhead_name";
    //    drpPayHead.DataValueField = "id";
    //    drpPayHead.DataSource = dsPayheadName;
    //    drpPayHead.DataBind();
    //}

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
                    drpPayCalType.Items[0].Enabled = false;
                    drpPayCalType.Items[1].Enabled = false;
                    drpPayCalType.Items[2].Enabled = true;
                    drpPayCalType.Items[3].Enabled = true;
                    rngcheckpercentage.Enabled = true;
                    lblpercent.Visible = true;
                    valuebase.Visible = true;
                    txtamount.Enabled = false;
                    lblCheckEmpRecords.Text = "";
                    divbasic.Visible = true;

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
    }
    protected void txtValueBase_TextChanged(object sender, EventArgs e)
    {

        //if (drpPayHead.SelectedValue == "2" || drpPayHead.SelectedValue == "3" || drpPayHead.SelectedValue == "4")
        //{
            dtable = (DataTable)Session["EmployeePayStructure"];
            DataRow drfind = dtable.Rows.Find(0);
            decimal amount = Convert.ToDecimal(drfind["Amount"]);
            decimal value_base = Convert.ToDecimal(txtValueBase.Text);

            if (drpRoundValue.SelectedItem.Text == "Higher Rupees")
            {
                if (Convert.ToDecimal((value_base * amount) / 100)/Convert.ToInt32((value_base * amount) / 100)==1)
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
            lblCheckEmpRecords.Text = "Payhead already exists in employee pay structure queue";
        }
        else
        {
                    dr = dtable.NewRow();
                    dr["Empcode"] = txt_employee.Text.Trim();
                    dr["PayheadID"] = drpPayHead.SelectedValue.ToString();
                    dr["PayheadName"] = drpPayHead.SelectedItem.ToString();
                    dr["PayCalculationType"] = drpPayCalType.SelectedItem.ToString();
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
                dr["Amount"] = "N/A"; 
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
        else if (drpPayHead.SelectedValue == "5" || drpPayHead.SelectedValue=="6")
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

        if (!validate())
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Pay Structure already exists for employee " + txt_employee.Text.ToString();
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = true;
            employeePayStructure.Visible = false;
            return;
        }
        else
        {
            emppaystructure();
        }
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
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
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
        sqlstr1 = @"select count(payhead) from tbl_payroll_employee_paystructure_detail where empcode='" + txt_employee.Text.Trim() + "' and status = 1 and payhead=0";
        i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr1);
        if (i > 0)
            return false;
        else
            return true;
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        int paystrucutreid;
        if (!validate())
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Pay Structure already exists for employee " + txt_employee.Text.ToString();
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = true;
            return;
        }

        try
        {
            dtable = (DataTable)Session["EmployeePayStructure"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;
                sqlparm = new SqlParameter[13];

                sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlparm[0].Value = txt_employee.Text;

                sqlparm[1] = new SqlParameter("@from_month", SqlDbType.VarChar,50);
                sqlparm[1].Value = dd_month_f.SelectedItem.Text;

                sqlparm[2] = new SqlParameter("@from_year", SqlDbType.VarChar, 50);
                sqlparm[2].Value = dd_year_f.SelectedValue;

                sqlparm[3] = new SqlParameter("@to_month", SqlDbType.VarChar, 50);
                sqlparm[3].Value = 0;

                sqlparm[4] = new SqlParameter("@to_year", SqlDbType.VarChar, 50);
                sqlparm[4].Value = 0;

                sqlparm[5] = new SqlParameter("@pf", SqlDbType.Bit);
                sqlparm[5].Value = chk_pf.Checked;

                sqlparm[6] = new SqlParameter("@esi", SqlDbType.Bit);
                sqlparm[6].Value = chk_esi.Checked;


                sqlparm[7] = new SqlParameter("@cutesi", SqlDbType.Bit);
                sqlparm[7].Value = chk_esi.Checked;


                sqlparm[8] = new SqlParameter("@user", SqlDbType.VarChar, 50);
                sqlparm[8].Value = Session["name"].ToString();

                sqlparm[9] = new SqlParameter("@pfmode", SqlDbType.Int);

                if (chk_pf.Checked)
                {
                    if (chk_1500.Checked)
                    {
                        sqlparm[9].Value = 1;
                    }
                    else if (chk_basic.Checked)
                    {
                        sqlparm[9].Value = 2;
                    }
                }
                else
                {
                    sqlparm[9].Value = 0;
                }

                sqlparm[10] = new SqlParameter("@vpf", SqlDbType.Bit);
                sqlparm[10].Value = chk_vpf.Checked;

                sqlparm[11] = new SqlParameter("@vpfper", SqlDbType.Decimal, 50);
                if (txt_vpf.Text != "")
                {
                    sqlparm[11].Value = Convert.ToDecimal(txt_vpf.Text);
                }
                else
                {
                    sqlparm[11].Value = 0;
                }

                sqlparm[12] = new SqlParameter("@pt", SqlDbType.Bit);
                if (chk_pt.Checked == true)
                {
                    sqlparm[12].Value = true;
                }
                else
                {
                    sqlparm[12].Value = false;
                }

               

               

                paystrucutreid = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_paystructure", sqlparm));

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

                    sqlparm[7] = new SqlParameter("@paystructure_id", SqlDbType.VarChar, 50);
                    sqlparm[7].Value  = paystrucutreid;

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_paystructure_detail", sqlparm);

                }
            }
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Records added successfully";
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = false;
            drpPayHead.SelectedValue = "0";
            Session.Remove("EmployeePayStructure");
            txt_employee.Text = "";
            txt_employee.Enabled =true;
            pickemp.Visible = true;
            btn_submit.Visible = false;

        }
        catch (Exception ex)
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Problem in adding Pay Structure records, try later";
        }
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
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month_f.SelectedValue = a.Month.ToString();
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
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year_f.SelectedValue = a.Year.ToString();
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
        }
    }
}
