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

public partial class appraisal_PerformanceQualities : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    //SqlTransaction transaction = null;
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
            doSum1();
        }
        else if (ddlrate1.SelectedItem.Text == "Below Expectation")
        {
            TextBox8.Text = "2";
            doSum1();
        }
        else if (ddlrate1.SelectedItem.Text == "Meets Expectation")
        {
            TextBox8.Text = "3";
            doSum1();
        }
        else if (ddlrate1.SelectedItem.Text == "Above Expectation")
        {
            TextBox8.Text = "4";
            doSum1();
        }
        else if (ddlrate1.SelectedItem.Text == "Outstanding")
        {
            TextBox8.Text = "5";
            doSum1();
        }
        doSum();
        doSum1();
    }
    protected void ddlrate2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrate2.SelectedItem.Text == "Poor")
        {
            TextBox1.Text = "1";
            doSum1();
        }
        else if (ddlrate2.SelectedItem.Text == "Below Expectation")
        {
            TextBox1.Text = "2";
            doSum1();
        }
        else if (ddlrate2.SelectedItem.Text == "Meets Expectation")
        {
            TextBox1.Text = "3";
            doSum1();
        }
        else if (ddlrate2.SelectedItem.Text == "Above Expectation")
        {
            TextBox1.Text = "4";
            doSum1();
        }
        else if (ddlrate2.SelectedItem.Text == "Outstanding")
        {
            TextBox1.Text = "5";
            doSum1();
        }

        doSum();
        doSum1();

    }
    private void doSum()
    {
        double sum1 = Convert.ToDouble(ddlrate1.SelectedValue);
        double sum2 = Convert.ToDouble(ddlrate2.SelectedValue);
        double sum3 = Convert.ToDouble(ddlrate3.SelectedValue);
        double sum4 = Convert.ToDouble(ddlrate4.SelectedValue);
        double sum5 = Convert.ToDouble(ddlrate5.SelectedValue);
        double sum6 = Convert.ToDouble(ddlrate6.SelectedValue);
        double sum7 = Convert.ToDouble(ddlrate7.SelectedValue);
        double sum8 = Convert.ToDouble(ddlrate8.SelectedValue);

        txt_totalrate.Text = (sum1 + sum2 + sum3 + sum4 + sum5 + sum6 + sum7 + sum8).ToString();
    }


    private void doSum1()
    {
        //int txt1Add = Convert.ToInt32(TextBox8.Text);
        //int totalScore = 0;
        //totalScore = totalScore + txt1Add;
        //txt_totalscore.Text = totalScore.ToString();
        double sum1 = 0.0;
        double sum2 = 0.0;
        double sum3 = 0.0;
        double sum4 = 0.0;
        double sum5 = 0.0;
        double sum6 = 0.0;
        double sum7 = 0.0;
        double sum8 = 0.0;
        if (TextBox8.Text != "")
        {
            sum1 = Convert.ToDouble(TextBox8.Text);
        }
        if (TextBox1.Text != "")
        {
            sum2 = Convert.ToDouble(TextBox1.Text);
        }
        if (TextBox2.Text != "")
        {
            sum3 = Convert.ToDouble(TextBox2.Text);
        }
        if (TextBox3.Text != "")
        {
            sum4 = Convert.ToDouble(TextBox3.Text);
        }
        if (TextBox4.Text != "")
        {
            sum5 = Convert.ToDouble(TextBox4.Text);
        }
        if (TextBox5.Text != "")
        {
            sum6 = Convert.ToDouble(TextBox5.Text);
        }
        if (TextBox6.Text != "")
        {
            sum7 = Convert.ToDouble(TextBox6.Text);
        }
        if (TextBox7.Text != "")
        {
            sum8 = Convert.ToDouble(TextBox7.Text);
        }

        txt_totalscore.Text = (sum1 + sum2 + sum3 + sum4 + sum5 + sum6 + sum7 + sum8).ToString();
    }

    protected void ddlrate3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrate3.SelectedItem.Text == "Poor")
        {
            TextBox2.Text = "1";
            doSum1();
        }
        else if (ddlrate3.SelectedItem.Text == "Below Expectation")
        {
            TextBox2.Text = "2";
            doSum1();
        }
        else if (ddlrate3.SelectedItem.Text == "Meets Expectation")
        {
            TextBox2.Text = "3";
            doSum1();
        }
        else if (ddlrate3.SelectedItem.Text == "Above Expectation")
        {
            TextBox2.Text = "4";
            doSum1();
        }
        else if (ddlrate3.SelectedItem.Text == "Outstanding")
        {
            TextBox2.Text = "5";
            doSum1();
        }
        doSum();
        doSum1();


    }
    protected void ddlrate4_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddlrate4.SelectedItem.Text == "Poor")
        {
            TextBox3.Text = "1";
            doSum1();
        }
        else if (ddlrate4.SelectedItem.Text == "Below Expectation")
        {
            TextBox3.Text = "2";
            doSum1();
        }
        else if (ddlrate4.SelectedItem.Text == "Meets Expectation")
        {
            TextBox3.Text = "3";
            doSum1();
        }
        else if (ddlrate4.SelectedItem.Text == "Above Expectation")
        {
            TextBox3.Text = "4";
            doSum1();
        }
        else if (ddlrate4.SelectedItem.Text == "Outstanding")
        {
            TextBox3.Text = "5";
            doSum1();
        }
        doSum();
        doSum1();


    }
    protected void ddlrate5_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddlrate5.SelectedItem.Text == "Poor")
        {
            TextBox4.Text = "1";
            doSum1();
        }
        else if (ddlrate5.SelectedItem.Text == "Below Expectation")
        {
            TextBox4.Text = "2";
            doSum1();
        }
        else if (ddlrate5.SelectedItem.Text == "Meets Expectation")
        {
            TextBox4.Text = "3";
            doSum1();
        }
        else if (ddlrate5.SelectedItem.Text == "Above Expectation")
        {
            TextBox4.Text = "4";
            doSum1();
        }
        else if (ddlrate5.SelectedItem.Text == "Outstanding")
        {
            TextBox4.Text = "5";
            doSum1();
        }
        doSum();
        doSum1();


    }
    protected void ddlrate6_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddlrate6.SelectedItem.Text == "Poor")
        {
            TextBox5.Text = "1";
            doSum1();
        }
        else if (ddlrate6.SelectedItem.Text == "Below Expectation")
        {
            TextBox5.Text = "2";
            doSum1();
        }
        else if (ddlrate6.SelectedItem.Text == "Meets Expectation")
        {
            TextBox5.Text = "3";
            doSum1();
        }
        else if (ddlrate6.SelectedItem.Text == "Above Expectation")
        {
            TextBox5.Text = "4";
            doSum1();
        }
        else if (ddlrate6.SelectedItem.Text == "Outstanding")
        {
            TextBox5.Text = "5";
            doSum1();
        }
        doSum();
        doSum1();

    }
    protected void ddlrate7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrate7.SelectedItem.Text == "Poor")
        {
            TextBox6.Text = "1";
            doSum1();
        }
        else if (ddlrate7.SelectedItem.Text == "Below Expectation")
        {
            TextBox6.Text = "2";
            doSum1();
        }
        else if (ddlrate7.SelectedItem.Text == "Meets Expectation")
        {
            TextBox6.Text = "3";
            doSum1();
        }
        else if (ddlrate7.SelectedItem.Text == "Above Expectation")
        {
            TextBox6.Text = "4";
            doSum1();
        }
        else if (ddlrate7.SelectedItem.Text == "Outstanding")
        {
            TextBox6.Text = "5";
            doSum1();
        }
        doSum();
        doSum1();

    }
    protected void ddlrate8_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrate8.SelectedItem.Text == "Poor")
        {
            TextBox7.Text = "1";
            doSum1();
        }
        else if (ddlrate8.SelectedItem.Text == "Below Expectation")
        {
            TextBox7.Text = "2";
            doSum1();
        }
        else if (ddlrate8.SelectedItem.Text == "Meets Expectation")
        {
            TextBox7.Text = "3";
            doSum1();
        }
        else if (ddlrate8.SelectedItem.Text == "Above Expectation")
        {
            TextBox7.Text = "4";
            doSum1();
        }
        else if (ddlrate8.SelectedItem.Text == "Outstanding")
        {
            TextBox7.Text = "5";
            doSum1();
        }
        doSum();
        doSum1();

    }
    //    string selcnt1 = ddlrate1.SelectedValue;
    //    List<string> str1 = new List<string>();
    //    {

    //        if (selcnt1 == "Poor")
    //        {
    //            str1.Add("1");

    //        }
    //        else if (selcnt1 == "Below Expectation")
    //        {
    //            str1.Add("2");

    //        }
    //        else if (selcnt1 == "Meets Expectation")
    //        {
    //            str1.Add("3");

    //        }
    //        else if (selcnt1 == "Above Expectation")
    //        {
    //            str1.Add("4");

    //        }
    //        else if (selcnt1 == "Outstanding")
    //        {
    //            str1.Add("5");

    //        }
    //    }
    //    ddlrate1.DataSource = str1;
    //    ddlrate1.DataBind();
    //}
    //protected void ddlrate2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selcnt2 = ddlrate2.SelectedValue;
    //    List<string> str2 = new List<string>();
    //    {

    //        if (selcnt2 == "Poor")
    //        {
    //            str2.Add("1");

    //        }
    //        else if (selcnt2 == "Below Expectation")
    //        {
    //            str2.Add("2");

    //        }
    //        else if (selcnt2 == "Meets Expectation")
    //        {
    //            str2.Add("3");

    //        }
    //        else if (selcnt2 == "Above Expectation")
    //        {
    //            str2.Add("4");

    //        }
    //        else if (selcnt2 == "Outstanding")
    //        {
    //            str2.Add("5");

    //        }
    //    }
    //    ddlrate2.DataSource = str2;
    //    ddlrate2.DataBind();

    //}
    //protected void ddlrate3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selcnt3 = ddlrate3.SelectedValue;
    //    List<string> str3 = new List<string>();
    //    {

    //        if (selcnt3 == "Poor")
    //        {
    //            str3.Add("1");

    //        }
    //        else if (selcnt3 == "Below Expectation")
    //        {
    //            str3.Add("2");

    //        }
    //        else if (selcnt3 == "Meets Expectation")
    //        {
    //            str3.Add("3");

    //        }
    //        else if (selcnt3 == "Above Expectation")
    //        {
    //            str3.Add("4");

    //        }
    //        else if (selcnt3 == "Outstanding")
    //        {
    //            str3.Add("5");

    //        }
    //    }
    //    ddlrate3.DataSource = str3;
    //    ddlrate3.DataBind();
    //}
    //protected void ddlrate4_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selcnt4 = ddlrate4.SelectedValue;
    //    List<string> str4 = new List<string>();
    //    {

    //        if (selcnt4 == "Poor")
    //        {
    //            str4.Add("1");

    //        }
    //        else if (selcnt4 == "Below Expectation")
    //        {
    //            str4.Add("2");

    //        }
    //        else if (selcnt4 == "Meets Expectation")
    //        {
    //            str4.Add("3");

    //        }
    //        else if (selcnt4 == "Above Expectation")
    //        {
    //            str4.Add("4");

    //        }
    //        else if (selcnt4 == "Outstanding")
    //        {
    //            str4.Add("5");

    //        }
    //    }
    //    ddlrate4.DataSource = str4;
    //    ddlrate4.DataBind();

    //}
    //protected void ddlrate5_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selcnt5 = ddlrate5.SelectedValue;
    //    List<string> str5 = new List<string>();
    //    {

    //        if (selcnt5 == "Poor")
    //        {
    //            str5.Add("1");

    //        }
    //        else if (selcnt5 == "Below Expectation")
    //        {
    //            str5.Add("2");

    //        }
    //        else if (selcnt5 == "Meets Expectation")
    //        {
    //            str5.Add("3");

    //        }
    //        else if (selcnt5 == "Above Expectation")
    //        {
    //            str5.Add("4");

    //        }
    //        else if (selcnt5 == "Outstanding")
    //        {
    //            str5.Add("5");

    //        }
    //    }
    //    ddlrate5.DataSource = str5;
    //    ddlrate5.DataBind();

    //}
    //protected void ddlrate6_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    string selcnt6 = ddlrate6.SelectedValue;
    //    List<string> str6 = new List<string>();
    //    {

    //        if (selcnt6 == "Poor")
    //        {
    //            str6.Add("1");

    //        }
    //        else if (selcnt6 == "Below Expectation")
    //        {
    //            str6.Add("2");

    //        }
    //        else if (selcnt6 == "Meets Expectation")
    //        {
    //            str6.Add("3");

    //        }
    //        else if (selcnt6 == "Above Expectation")
    //        {
    //            str6.Add("4");

    //        }
    //        else if (selcnt6 == "Outstanding")
    //        {
    //            str6.Add("5");

    //        }
    //    }
    //    ddlrate6.DataSource = str6;
    //    ddlrate6.DataBind();
    //}

    //protected void ddlrate8_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selcnt8 = ddlrate8.SelectedValue;
    //    List<string> str8 = new List<string>();
    //    {

    //        if (selcnt8 == "Poor")
    //        {
    //            str8.Add("1");

    //        }
    //        else if (selcnt8 == "Below Expectation")
    //        {
    //            str8.Add("2");

    //        }
    //        else if (selcnt8 == "Meets Expectation")
    //        {
    //            str8.Add("3");

    //        }
    //        else if (selcnt8 == "Above Expectation")
    //        {
    //            str8.Add("4");

    //        }
    //        else if (selcnt8 == "Outstanding")
    //        {
    //            str8.Add("5");

    //        }
    //    }
    //    ddlrate8.DataSource = str8;
    //    ddlrate8.DataBind();
    //}
    //protected void ddlrate7_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selcnt7 = ddlrate7.SelectedValue;
    //    List<string> str7 = new List<string>();
    //    {

    //        if (selcnt7 == "Poor")
    //        {
    //            str7.Add("1");

    //        }
    //        else if (selcnt7 == "Below Expectation")
    //        {
    //            str7.Add("2");

    //        }
    //        else if (selcnt7 == "Meets Expectation")
    //        {
    //            str7.Add("3");

    //        }
    //        else if (selcnt7 == "Above Expectation")
    //        {
    //            str7.Add("4");

    //        }
    //        else if (selcnt7 == "Outstanding")
    //        {
    //            str7.Add("5");

    //        }
    //    }
    //    ddlrate7.DataSource = str7;
    //    ddlrate7.DataBind();
    //}
    //protected void bindapproversgrid()
    //{
    //    SqlParameter[] sqlParam = new SqlParameter[1];
    //    Output.AssignParameter(sqlParam, 0,"@empcode","String", 50, _userCode);
    //    DataSet ds = new DataSet();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Performance_qulity", sqlParam);
    //    grdapprover.DataSource = ds;
    //    grdapprover.DataBind();
    //}

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }


    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        bool s = saverecords5();
        if (s)
        {
            //message.InnerHtml = "Record has been saved successfully!";
            MsgBox("Record saved successfully", this.Page, this);
        }
        else MsgBox("Record has not been saved", this.Page, this);
        reset5();
    }
    protected bool saverecords5()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[43];

            newparameter[0] = new SqlParameter("@sno1", SqlDbType.Int);
            newparameter[0].Value = lb1.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@perfm1", SqlDbType.VarChar, 100);
            newparameter[1].Value = lblperformance1.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@def1", SqlDbType.VarChar, 100);
            newparameter[2].Value = Labeldef1.Text;

            newparameter[3] = new SqlParameter("@rating1", SqlDbType.VarChar, 50);
            newparameter[3].Value = ddlrate1.Text.Trim().ToString();

            newparameter[4] = new SqlParameter("@score1", SqlDbType.VarChar, 50);
            newparameter[4].Value = TextBox8.Text;

            newparameter[5] = new SqlParameter("@sno2", SqlDbType.Int);
            newparameter[5].Value = lb2.Text.Trim().ToString();

            newparameter[6] = new SqlParameter("@perfm2", SqlDbType.VarChar, 100);
            newparameter[6].Value = lblperformance2.Text.Trim().ToString();

            newparameter[7] = new SqlParameter("@def2", SqlDbType.VarChar, 100);
            newparameter[7].Value = Labeldef2.Text;

            newparameter[8] = new SqlParameter("@rating2", SqlDbType.VarChar, 50);
            newparameter[8].Value = ddlrate2.Text.Trim().ToString();

            newparameter[9] = new SqlParameter("@score2", SqlDbType.VarChar, 50);
            newparameter[9].Value = TextBox1.Text;

            newparameter[10] = new SqlParameter("@sno3", SqlDbType.Int);
            newparameter[10].Value = lb3.Text.Trim().ToString();

            newparameter[11] = new SqlParameter("@perfm3", SqlDbType.VarChar, 100);
            newparameter[11].Value = lblperformance3.Text.Trim().ToString();

            newparameter[12] = new SqlParameter("@def3", SqlDbType.VarChar, 100);
            newparameter[12].Value = Labeldef3.Text;

            newparameter[13] = new SqlParameter("@rating3", SqlDbType.VarChar, 50);
            newparameter[13].Value = ddlrate3.Text.Trim().ToString();

            newparameter[14] = new SqlParameter("@score3", SqlDbType.VarChar, 50);
            newparameter[14].Value = TextBox2.Text;

            newparameter[15] = new SqlParameter("@sno4", SqlDbType.Int);
            newparameter[15].Value = lb4.Text.Trim().ToString();

            newparameter[16] = new SqlParameter("@perfm4", SqlDbType.VarChar, 100);
            newparameter[16].Value = lblperformance4.Text.Trim().ToString();

            newparameter[17] = new SqlParameter("@def4", SqlDbType.VarChar, 100);
            newparameter[17].Value = Labeldef4.Text;

            newparameter[18] = new SqlParameter("@rating4", SqlDbType.VarChar, 50);
            newparameter[18].Value = ddlrate4.Text.Trim().ToString();

            newparameter[19] = new SqlParameter("@score4", SqlDbType.VarChar, 50);
            newparameter[19].Value = TextBox3.Text;

            newparameter[20] = new SqlParameter("@sno5", SqlDbType.Int);
            newparameter[20].Value = lb5.Text.Trim().ToString();

            newparameter[21] = new SqlParameter("@perfm5", SqlDbType.VarChar, 100);
            newparameter[21].Value = lblperformance5.Text.Trim().ToString();

            newparameter[22] = new SqlParameter("@def5", SqlDbType.VarChar, 100);
            newparameter[22].Value = Labeldef5.Text;

            newparameter[23] = new SqlParameter("@rating5", SqlDbType.VarChar, 50);
            newparameter[23].Value = ddlrate5.Text.Trim().ToString();

            newparameter[24] = new SqlParameter("@score5", SqlDbType.VarChar, 50);
            newparameter[24].Value = TextBox4.Text;

            newparameter[25] = new SqlParameter("@sno6", SqlDbType.Int);
            newparameter[25].Value = lb6.Text.Trim().ToString();

            newparameter[26] = new SqlParameter("@perfm6", SqlDbType.VarChar, 100);
            newparameter[26].Value = lblperformance6.Text.Trim().ToString();

            newparameter[27] = new SqlParameter("@def6", SqlDbType.VarChar, 100);
            newparameter[27].Value = Labeldef6.Text;

            newparameter[28] = new SqlParameter("@rating6", SqlDbType.VarChar, 50);
            newparameter[28].Value = ddlrate6.Text.Trim().ToString();

            newparameter[29] = new SqlParameter("@score6", SqlDbType.VarChar, 50);
            newparameter[29].Value = TextBox5.Text;

            newparameter[30] = new SqlParameter("@sno7", SqlDbType.Int);
            newparameter[30].Value = lb7.Text.Trim().ToString();

            newparameter[31] = new SqlParameter("@perfm7", SqlDbType.VarChar, 100);
            newparameter[31].Value = lblperformance7.Text.Trim().ToString();

            newparameter[32] = new SqlParameter("@def7", SqlDbType.VarChar, 100);
            newparameter[32].Value = Labeldef7.Text;

            newparameter[33] = new SqlParameter("@rating7", SqlDbType.VarChar, 50);
            newparameter[33].Value = ddlrate7.Text.Trim().ToString();

            newparameter[34] = new SqlParameter("@score7", SqlDbType.VarChar, 50);
            newparameter[34].Value = TextBox6.Text;

            newparameter[35] = new SqlParameter("@sno8", SqlDbType.Int);
            newparameter[35].Value = lb8.Text.Trim().ToString();

            newparameter[36] = new SqlParameter("@perfm8", SqlDbType.VarChar, 100);
            newparameter[36].Value = lblperformance8.Text.Trim().ToString();

            newparameter[37] = new SqlParameter("@def8", SqlDbType.VarChar, 100);
            newparameter[37].Value = Labeldef8.Text;

            newparameter[38] = new SqlParameter("@rating8", SqlDbType.VarChar, 50);
            newparameter[38].Value = Convert.ToDouble(ddlrate8.Text.Trim());

            newparameter[39] = new SqlParameter("@score8", SqlDbType.VarChar, 50);
            newparameter[39].Value = TextBox7.Text;

            newparameter[40] = new SqlParameter("@total ", SqlDbType.VarChar, 50);
            newparameter[40].Value = Convert.ToDouble(txt_totalrate.Text);

            newparameter[41] = new SqlParameter("@total1 ", SqlDbType.VarChar, 50);
            newparameter[41].Value = Convert.ToDouble(txt_totalscore.Text);

            newparameter[42] = new SqlParameter("@postedby", SqlDbType.VarChar, 100);
            newparameter[42].Value = _userCode.ToString();

            //newparameter[43] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[43].Value = _userCode.ToString();



            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Performance_qulity]", newparameter);
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
    protected void reset5()
    {

        ddlrate1.SelectedValue = "0";
        TextBox8.Text = "";
        ddlrate2.SelectedValue = "0";
        TextBox1.Text = "";
        ddlrate3.SelectedValue = "0";
        TextBox2.Text = "";
        ddlrate4.SelectedValue = "0";
        TextBox3.Text = "";
        ddlrate5.SelectedValue = "0";
        TextBox4.Text = "";
        ddlrate6.SelectedValue = "0";
        TextBox5.Text = "";
        ddlrate7.SelectedValue = "0";
        TextBox6.Text = "";
        ddlrate8.SelectedValue = "0";
        TextBox7.Text = "";
        txt_totalrate.Text = "";
        txt_totalscore.Text = "";
    }


}




























