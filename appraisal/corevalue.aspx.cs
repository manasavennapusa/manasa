using DataAccessLayer;
using Common.Console;
using Common.Data;
using Common.Date;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;
using System.Collections.Generic;

public partial class appraisal_corevalue : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    private string _companyId, _userCode;
    private static double sum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {



            }

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
            _userCode = Session["empcode"].ToString();
        }


    }
    protected void ddlrate1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddlrate1.SelectedItem.Text == "Poor")
        {
            TextBox8.Text = "1";
        }
        else if (ddlrate1.SelectedItem.Text == "Below Expectation")
        {
            TextBox8.Text = "2";
        }
        else if (ddlrate1.SelectedItem.Text == "Meets Expectation")
        {
            TextBox8.Text = "3";
        }
        else if (ddlrate1.SelectedItem.Text == "Above Expectation")
        {
            TextBox8.Text = "4";
        }
        else if (ddlrate1.SelectedItem.Text == "Outstanding")
        {
            TextBox8.Text = "5";
        }
        doSum();

    }
    protected void ddlrate2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrate2.SelectedItem.Text == "Poor")
        {
            TextBox1.Text = "1";
        }
        else if (ddlrate2.SelectedItem.Text == "Below Expectation")
        {
            TextBox1.Text = "2";
        }
        else if (ddlrate2.SelectedItem.Text == "Meets Expectation")
        {
            TextBox1.Text = "3";
        }
        else if (ddlrate2.SelectedItem.Text == "Above Expectation")
        {
            TextBox1.Text = "4";
        }
        else if (ddlrate2.SelectedItem.Text == "Outstanding")
        {
            TextBox1.Text = "5";
        }
        doSum();

    }
    protected void ddlrate3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrate3.SelectedItem.Text == "Poor")
        {
            TextBox2.Text = "1";
        }
        else if (ddlrate3.SelectedItem.Text == "Below Expectation")
        {
            TextBox2.Text = "2";
        }
        else if (ddlrate3.SelectedItem.Text == "Meets Expectation")
        {
            TextBox2.Text = "3";
        }
        else if (ddlrate3.SelectedItem.Text == "Above Expectation")
        {
            TextBox2.Text = "4";
        }
        else if (ddlrate3.SelectedItem.Text == "Outstanding")
        {
            TextBox2.Text = "5";
        }
        doSum();

    }
    protected void ddlrate4_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlrate4.SelectedItem.Text == "Poor")
        {
            TextBox3.Text = "1";
        }
        else if (ddlrate4.SelectedItem.Text == "Below Expectation")
        {
            TextBox3.Text = "2";
        }
        else if (ddlrate4.SelectedItem.Text == "Meets Expectation")
        {
            TextBox3.Text = "3";
        }
        else if (ddlrate4.SelectedItem.Text == "Above Expectation")
        {
            TextBox3.Text = "4";
        }
        else if (ddlrate4.SelectedItem.Text == "Outstanding")
        {
            TextBox3.Text = "5";
        }
        doSum();

    }
    protected void ddlrate5_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlrate5.SelectedItem.Text == "Poor")
        {
            TextBox4.Text = "1";
        }
        else if (ddlrate5.SelectedItem.Text == "Below Expectation")
        {
            TextBox4.Text = "2";
        }
        else if (ddlrate5.SelectedItem.Text == "Meets Expectation")
        {
            TextBox4.Text = "3";
        }
        else if (ddlrate5.SelectedItem.Text == "Above Expectation")
        {
            TextBox4.Text = "4";
        }
        else if (ddlrate5.SelectedItem.Text == "Outstanding")
        {
            TextBox4.Text = "5";
        }
        doSum();

    }
    protected void ddlrate6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrate6.SelectedItem.Text == "Poor")
        {
            TextBox5.Text = "1";
        }
        else if (ddlrate6.SelectedItem.Text == "Below Expectation")
        {
            TextBox5.Text = "2";
        }
        else if (ddlrate6.SelectedItem.Text == "Meets Expectation")
        {
            TextBox5.Text = "3";
        }
        else if (ddlrate6.SelectedItem.Text == "Above Expectation")
        {
            TextBox5.Text = "4";
        }
        else if (ddlrate6.SelectedItem.Text == "Outstanding")
        {
            TextBox5.Text = "5";
        }
        doSum();

    }
    private void doSum()
    {
        double sum1 = Convert.ToDouble(ddlrate1.SelectedValue);
        double sum2 = Convert.ToDouble(ddlrate2.SelectedValue);
        double sum3 = Convert.ToDouble(ddlrate3.SelectedValue);
        double sum4 = Convert.ToDouble(ddlrate4.SelectedValue);
        double sum5 = Convert.ToDouble(ddlrate5.SelectedValue);
        double sum6 = Convert.ToDouble(ddlrate6.SelectedValue);


        txtperc.Text = (sum1 + sum2 + sum3 + sum4 + sum5 + sum6).ToString();
    }

    
    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        bool s = saverecords6();
        if (s)
        {
            //message.InnerHtml = "Record has been saved successfully!";
            MsgBox("Record saved successfully!", this.Page, this);
        }
        else MsgBox("Record has not been saved!", this.Page, this);
        reset6();
    }
    protected bool saverecords6()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[39];

            newparameter[0] = new SqlParameter("@sno1", SqlDbType.Int);
            newparameter[0].Value = Label1.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@val1", SqlDbType.VarChar, 100);
            newparameter[1].Value = lblcreativity.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@def1", SqlDbType.VarChar, 100);
            newparameter[2].Value = lbldef1.Text;

            newparameter[3] = new SqlParameter("@achvt1", SqlDbType.VarChar, 100);
            newparameter[3].Value = txtrating1.Text.Trim().ToString();

            newparameter[4] = new SqlParameter("@rating1", SqlDbType.VarChar, 50);
            newparameter[4].Value = ddlrate1.Text;

            newparameter[5] = new SqlParameter("@score1", SqlDbType.VarChar, 50);
            newparameter[5].Value = TextBox8.Text;

            newparameter[6] = new SqlParameter("@sno2", SqlDbType.Int);
            newparameter[6].Value = Label2.Text.Trim().ToString();

            newparameter[7] = new SqlParameter("@val2", SqlDbType.VarChar, 100);
            newparameter[7].Value = lblprof.Text.Trim().ToString();

            newparameter[8] = new SqlParameter("@def2", SqlDbType.VarChar, 100);
            newparameter[8].Value = lbldef22.Text;

            newparameter[9] = new SqlParameter("@achvt2", SqlDbType.VarChar, 100);
            newparameter[9].Value = txtrating2.Text.Trim().ToString();

            newparameter[10] = new SqlParameter("@rating2", SqlDbType.VarChar, 50);
            newparameter[10].Value = ddlrate2.Text;

            newparameter[11] = new SqlParameter("@score2", SqlDbType.VarChar, 50);
            newparameter[11].Value = TextBox1.Text;

            newparameter[12] = new SqlParameter("@sno3", SqlDbType.Int);
            newparameter[12].Value = Label3.Text.Trim().ToString();

            newparameter[13] = new SqlParameter("@val3", SqlDbType.VarChar, 100);
            newparameter[13].Value = lblteamwork.Text.Trim().ToString();

            newparameter[14] = new SqlParameter("@def3", SqlDbType.VarChar, 100);
            newparameter[14].Value = lbldef44.Text;

            newparameter[15] = new SqlParameter("@achvt3", SqlDbType.VarChar, 100);
            newparameter[15].Value = txtrating3.Text.Trim().ToString();

            newparameter[16] = new SqlParameter("@rating3", SqlDbType.VarChar, 50);
            newparameter[16].Value = ddlrate3.Text;

            newparameter[17] = new SqlParameter("@score3", SqlDbType.VarChar, 50);
            newparameter[17].Value = TextBox2.Text;

            newparameter[18] = new SqlParameter("@sno4", SqlDbType.Int);
            newparameter[18].Value = Label5.Text.Trim().ToString();

            newparameter[19] = new SqlParameter("@val4", SqlDbType.VarChar, 100);
            newparameter[19].Value = lblintegrty.Text.Trim().ToString();

            newparameter[20] = new SqlParameter("@def4", SqlDbType.VarChar, 100);
            newparameter[20].Value = lbldef55.Text;

            newparameter[21] = new SqlParameter("@achvt4", SqlDbType.VarChar, 100);
            newparameter[21].Value = txtrating4.Text.Trim().ToString();

            newparameter[22] = new SqlParameter("@rating4", SqlDbType.VarChar, 50);
            newparameter[22].Value = ddlrate4.Text;

            newparameter[23] = new SqlParameter("@score4", SqlDbType.VarChar, 50);
            newparameter[23].Value = TextBox3.Text;

            newparameter[24] = new SqlParameter("@sno5", SqlDbType.Int);
            newparameter[24].Value = Label6.Text.Trim().ToString();

            newparameter[25] = new SqlParameter("@val5", SqlDbType.VarChar, 100);
            newparameter[25].Value = lblexcel.Text.Trim().ToString();

            newparameter[26] = new SqlParameter("@def5", SqlDbType.VarChar, 100);
            newparameter[26].Value = lbldef66.Text;

            newparameter[27] = new SqlParameter("@achvt5", SqlDbType.VarChar, 100);
            newparameter[27].Value = txtrating5.Text.Trim().ToString();

            newparameter[28] = new SqlParameter("@rating5", SqlDbType.VarChar, 50);
            newparameter[28].Value = ddlrate5.Text;

            newparameter[29] = new SqlParameter("@score5", SqlDbType.VarChar, 50);
            newparameter[29].Value = TextBox4.Text;

            newparameter[30] = new SqlParameter("@sno6", SqlDbType.Int);
            newparameter[30].Value = Label7.Text.Trim().ToString();

            newparameter[31] = new SqlParameter("@val6", SqlDbType.VarChar, 100);
            newparameter[31].Value = lblpassion.Text.Trim().ToString();

            newparameter[32] = new SqlParameter("@def6", SqlDbType.VarChar, 100);
            newparameter[32].Value = lbldef77.Text;

            newparameter[33] = new SqlParameter("@achvt6", SqlDbType.VarChar, 100);
            newparameter[33].Value = txtrating6.Text.Trim().ToString();

            newparameter[34] = new SqlParameter("@rating6", SqlDbType.VarChar, 50);
            newparameter[34].Value = ddlrate6.Text;

            newparameter[35] = new SqlParameter("@score6", SqlDbType.VarChar, 50);
            newparameter[35].Value = TextBox5.Text;

            newparameter[36] = new SqlParameter("@total ", SqlDbType.VarChar, 50);
            newparameter[36].Value = Convert.ToDouble(txtperc.Text);

            newparameter[37] = new SqlParameter("@total1 ", SqlDbType.VarChar, 50);
            newparameter[37].Value = Convert.ToDouble(txtavg.Text);

            newparameter[38] = new SqlParameter("@postedby", SqlDbType.VarChar, 100);
            newparameter[38].Value = _userCode.ToString();

            //newparameter[39] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[39].Value = _userCode.ToString();



            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_tbl_core_values]", newparameter);
            return true;
        }
        catch (SqlException sql)
        {
            //message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
            MsgBox("Cannot insert duplicate values or some database error has been occured!", this.Page, this);
            return false;
        }
        catch (Exception ex)
        {
            //message.InnerHtml = ex.Message;
            return false;
        }
        finally
        {

        }
    }
    protected void reset6()
    {
        ddlrate1.SelectedValue="0";
        TextBox8.Text = "";
        ddlrate2.SelectedValue="0";
        txtperc.Text="";
        txtavg.Text = "";
        TextBox5.Text="";
        ddlrate6.SelectedValue="0";
        txtrating6.Text="";
        TextBox4.Text="";
        ddlrate5.SelectedValue="0";
        txtrating5.Text="";
        TextBox3.Text="";
        ddlrate4.SelectedValue="0";
        txtrating4.Text="";
        TextBox2.Text="";
        ddlrate3.SelectedValue="0";
        txtrating3.Text="";
        TextBox1.Text="";
        txtrating1.Text = "";
        txtrating2.Text = "";
    }
}






