using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Smart.HR.Common.Console;

public partial class appraisal_geetha : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    string _companyId, _userCode, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                // BindDept();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
            _userCode = Session["empcode"].ToString();
        }

    }
    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }


    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[21];

            newparameter[0] = new SqlParameter("@sno1", SqlDbType.Int);
            newparameter[0].Value = Label6.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@perfm1", SqlDbType.VarChar, 100);
            newparameter[1].Value = lblperformance1.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@achvt1", SqlDbType.VarChar, 100);
            newparameter[2].Value = txtachive1.Text;

            newparameter[3] = new SqlParameter("@weight1", SqlDbType.VarChar, 50);
            newparameter[3].Value = TextBox65.Text;

            newparameter[4] = new SqlParameter("@rating1", SqlDbType.VarChar, 50);
            newparameter[4].Value = ddlrateing1.Text.Trim().ToString();

            newparameter[5] = new SqlParameter("@score1", SqlDbType.VarChar, 50);
            newparameter[5].Value = txtscore1.Text;

            newparameter[6] = new SqlParameter("@sno2", SqlDbType.Int);
            newparameter[6].Value = Label5.Text.Trim().ToString();

            newparameter[7] = new SqlParameter("@perfm2", SqlDbType.VarChar, 100);
            newparameter[7].Value = lblperformance2.Text.Trim().ToString();

            newparameter[8] = new SqlParameter("@achvt2", SqlDbType.VarChar, 100);
            newparameter[8].Value = txtachive2.Text;

            newparameter[9] = new SqlParameter("@weight2", SqlDbType.VarChar, 50);
            newparameter[9].Value = TextBox66.Text;

            newparameter[10] = new SqlParameter("@rating2", SqlDbType.VarChar, 50);
            newparameter[10].Value = ddlrating2.Text.Trim().ToString();

            newparameter[11] = new SqlParameter("@score2", SqlDbType.VarChar, 50);
            newparameter[11].Value = txtscore2.Text;

            newparameter[12] = new SqlParameter("@sno3", SqlDbType.Int);
            newparameter[12].Value = Label7.Text.Trim().ToString();

            newparameter[13] = new SqlParameter("@perfm3", SqlDbType.VarChar, 100);
            newparameter[13].Value = lblperformance3.Text.Trim().ToString();

            newparameter[14] = new SqlParameter("@achvt3", SqlDbType.VarChar, 100);
            newparameter[14].Value = txtachive3.Text;

            newparameter[15] = new SqlParameter("@weight3", SqlDbType.VarChar, 50);
            newparameter[15].Value = TextBox67.Text;

            newparameter[16] = new SqlParameter("@rating3", SqlDbType.VarChar, 50);
            newparameter[16].Value = ddlrating3.Text.Trim().ToString();

            newparameter[17] = new SqlParameter("@score3", SqlDbType.VarChar, 50);
            newparameter[17].Value = txtscore3.Text;

            newparameter[18] = new SqlParameter("@total ", SqlDbType.VarChar, 50);
            newparameter[18].Value = Convert.ToDouble(TextBox68.Text);

            newparameter[19] = new SqlParameter("@total1 ", SqlDbType.VarChar, 50);
            newparameter[19].Value = Convert.ToDouble(txtscore4.Text);

            newparameter[20] = new SqlParameter("@postedby", SqlDbType.VarChar, 100);
            newparameter[20].Value = _userCode.ToString();

            //newparameter[21] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[21].Value = _userCode.ToString();




            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_appraisal_business_growth]", newparameter);
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
    protected void reset()
    {
        txtachive1.Text = "";
        txtscore4.Text = "";
        TextBox68.Text = "";
        txtscore3.Text = "";
        ddlrating3.SelectedValue = "0";
        TextBox67.Text = "";
        txtachive3.Text = "";
        txtachive2.Text = "";
        TextBox66.Text = "";
        ddlrating2.SelectedValue = "0";
        txtscore2.Text = "";
        TextBox65.Text = "";
        ddlrateing1.SelectedValue = "0";
        txtscore1.Text = "";


    }

    protected bool saverecords1()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[27];

            newparameter[0] = new SqlParameter("@sno1", SqlDbType.Int);
            newparameter[0].Value = Label1.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@perfm1", SqlDbType.VarChar, 100);
            newparameter[1].Value = lblperformance4.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@achvt1", SqlDbType.VarChar, 100);
            newparameter[2].Value = TextBox4.Text;

            newparameter[3] = new SqlParameter("@weight1", SqlDbType.VarChar, 50);
            newparameter[3].Value = TextBox7.Text;

            newparameter[4] = new SqlParameter("@rating1", SqlDbType.VarChar, 50);
            newparameter[4].Value = ddlrating4.Text.Trim().ToString();

            newparameter[5] = new SqlParameter("@score1", SqlDbType.VarChar, 50);
            newparameter[5].Value = txtscore5.Text;

            newparameter[6] = new SqlParameter("@sno2", SqlDbType.Int);
            newparameter[6].Value = Label2.Text.Trim().ToString();

            newparameter[7] = new SqlParameter("@perfm2", SqlDbType.VarChar, 100);
            newparameter[7].Value = lblperformance5.Text.Trim().ToString();

            newparameter[8] = new SqlParameter("@achvt2", SqlDbType.VarChar, 100);
            newparameter[8].Value = TextBox6.Text;

            newparameter[9] = new SqlParameter("@weight2", SqlDbType.VarChar, 50);
            newparameter[9].Value = TextBox11.Text;

            newparameter[10] = new SqlParameter("@rating2", SqlDbType.VarChar, 50);
            newparameter[10].Value = ddlrating5.Text.Trim().ToString();

            newparameter[11] = new SqlParameter("@score2", SqlDbType.VarChar, 50);
            newparameter[11].Value = txtscore6.Text;

            newparameter[12] = new SqlParameter("@sno3", SqlDbType.Int);
            newparameter[12].Value = Label3.Text.Trim().ToString();

            newparameter[13] = new SqlParameter("@perfm3", SqlDbType.VarChar, 100);
            newparameter[13].Value = lblperformance6.Text.Trim().ToString();

            newparameter[14] = new SqlParameter("@achvt3", SqlDbType.VarChar, 100);
            newparameter[14].Value = TextBox9.Text;

            newparameter[15] = new SqlParameter("@weight3", SqlDbType.VarChar, 50);
            newparameter[15].Value = TextBox18.Text;

            newparameter[16] = new SqlParameter("@rating3", SqlDbType.VarChar, 50);
            newparameter[16].Value = ddlrating6.Text.Trim().ToString();

            newparameter[17] = new SqlParameter("@score3", SqlDbType.VarChar, 50);
            newparameter[17].Value = txtscore7.Text;
            newparameter[18] = new SqlParameter("@sno4", SqlDbType.Int);
            newparameter[18].Value = Label8.Text.Trim().ToString();

            newparameter[19] = new SqlParameter("@perfm4", SqlDbType.VarChar, 100);
            newparameter[19].Value = lblperformance7.Text.Trim().ToString();

            newparameter[20] = new SqlParameter("@achvt4", SqlDbType.VarChar, 100);
            newparameter[20].Value = TextBox14.Text;

            newparameter[21] = new SqlParameter("@weight4", SqlDbType.VarChar, 50);
            newparameter[21].Value = TextBox22.Text;

            newparameter[22] = new SqlParameter("@rating4", SqlDbType.VarChar, 50);
            newparameter[22].Value = ddlrating7.Text.Trim().ToString();

            newparameter[23] = new SqlParameter("@score4", SqlDbType.VarChar, 50);
            newparameter[23].Value = txtscore8.Text;

            newparameter[24] = new SqlParameter("@total ", SqlDbType.VarChar, 50);
            newparameter[24].Value = Convert.ToDouble(TextBox12.Text);

            newparameter[25] = new SqlParameter("@total1 ", SqlDbType.VarChar, 50);
            newparameter[25].Value = Convert.ToDouble(TextBox13.Text);

            newparameter[26] = new SqlParameter("@postedby", SqlDbType.VarChar, 100);
            newparameter[26].Value = _userCode.ToString();

            //newparameter[27] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[27].Value = _userCode.ToString();


            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_tbl_relationship_management", newparameter);
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
    protected void reset2()
    {

        TextBox4.Text = "";
        TextBox7.Text = "";
        ddlrating4.SelectedValue = "0";
        txtscore5.Text = "";
        TextBox6.Text = "";
        TextBox9.Text = "";
        TextBox18.Text = "";
        ddlrating6.SelectedValue = "0";
        txtscore7.Text = "";
        TextBox14.Text = "";
        TextBox22.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        ddlrating7.SelectedValue = "0";
        txtscore8.Text = "";
        txtscore6.Text = "";
        ddlrating5.SelectedValue = "0";
    }


    protected bool saverecords3()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[81];

            newparameter[0] = new SqlParameter("@sno1", SqlDbType.Int);
            newparameter[0].Value = Label9.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@perfm1", SqlDbType.VarChar, 100);
            newparameter[1].Value = lblperformance8.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@achvt1", SqlDbType.VarChar, 100);
            newparameter[2].Value = TextBox2.Text;

            newparameter[3] = new SqlParameter("@weight1", SqlDbType.VarChar, 50);
            newparameter[3].Value = TextBox26.Text;

            newparameter[4] = new SqlParameter("@rating1", SqlDbType.VarChar, 50);
            newparameter[4].Value = ddlrating8.Text.Trim().ToString();

            newparameter[5] = new SqlParameter("@score1", SqlDbType.VarChar, 50);
            newparameter[5].Value = txtscore9.Text;

            newparameter[6] = new SqlParameter("@sno2", SqlDbType.Int);
            newparameter[6].Value = Label10.Text.Trim().ToString();

            newparameter[7] = new SqlParameter("@perfm2", SqlDbType.VarChar, 100);
            newparameter[7].Value = lblperformance9.Text.Trim().ToString();

            newparameter[8] = new SqlParameter("@achvt2", SqlDbType.VarChar, 100);
            newparameter[8].Value = TextBox5.Text;

            newparameter[9] = new SqlParameter("@weight2", SqlDbType.VarChar, 50);
            newparameter[9].Value = TextBox32.Text;

            newparameter[10] = new SqlParameter("@rating2", SqlDbType.VarChar, 50);
            newparameter[10].Value = ddlrating9.Text.Trim().ToString();

            newparameter[11] = new SqlParameter("@score2", SqlDbType.VarChar, 50);
            newparameter[11].Value = txtscore10.Text;

            newparameter[12] = new SqlParameter("@sno3", SqlDbType.Int);
            newparameter[12].Value = Label11.Text.Trim().ToString();

            newparameter[13] = new SqlParameter("@perfm3", SqlDbType.VarChar, 100);
            newparameter[13].Value = lblperformance10.Text.Trim().ToString();

            newparameter[14] = new SqlParameter("@achvt3", SqlDbType.VarChar, 100);
            newparameter[14].Value = TextBox10.Text;

            newparameter[15] = new SqlParameter("@weight3", SqlDbType.VarChar, 50);
            newparameter[15].Value = TextBox35.Text;

            newparameter[16] = new SqlParameter("@rating3", SqlDbType.VarChar, 50);
            newparameter[16].Value = ddlrating10.Text.Trim().ToString();

            newparameter[17] = new SqlParameter("@score3", SqlDbType.VarChar, 50);
            newparameter[17].Value = txtscore11.Text;
            newparameter[18] = new SqlParameter("@sno4", SqlDbType.Int);
            newparameter[18].Value = Label12.Text.Trim().ToString();

            newparameter[19] = new SqlParameter("@perfm4", SqlDbType.VarChar, 100);
            newparameter[19].Value = lblperformance11.Text.Trim().ToString();

            newparameter[20] = new SqlParameter("@achvt4", SqlDbType.VarChar, 100);
            newparameter[20].Value = TextBox16.Text;

            newparameter[21] = new SqlParameter("@weight4", SqlDbType.VarChar, 50);
            newparameter[21].Value = TextBox37.Text;

            newparameter[22] = new SqlParameter("@rating4", SqlDbType.VarChar, 50);
            newparameter[22].Value = ddlrating11.Text.Trim().ToString();

            newparameter[23] = new SqlParameter("@score4", SqlDbType.VarChar, 50);
            newparameter[23].Value = txtscore12.Text;

            newparameter[24] = new SqlParameter("@sno5", SqlDbType.Int);
            newparameter[24].Value = Label13.Text.Trim().ToString();

            newparameter[25] = new SqlParameter("@perfm5", SqlDbType.VarChar, 100);
            newparameter[25].Value = lblperformance12.Text.Trim().ToString();

            newparameter[26] = new SqlParameter("@achvt5", SqlDbType.VarChar, 100);
            newparameter[26].Value = TextBox21.Text;

            newparameter[27] = new SqlParameter("@weight5", SqlDbType.VarChar, 50);
            newparameter[27].Value = TextBox38.Text;

            newparameter[28] = new SqlParameter("@rating5", SqlDbType.VarChar, 50);
            newparameter[28].Value = ddlrating12.Text.Trim().ToString();

            newparameter[29] = new SqlParameter("@score5", SqlDbType.VarChar, 50);
            newparameter[29].Value = txtscore13.Text;
            newparameter[30] = new SqlParameter("@sno6", SqlDbType.Int);
            newparameter[30].Value = Label14.Text.Trim().ToString();

            newparameter[31] = new SqlParameter("@perfm6", SqlDbType.VarChar, 100);
            newparameter[31].Value = lblperformance13.Text.Trim().ToString();

            newparameter[32] = new SqlParameter("@achvt6", SqlDbType.VarChar, 100);
            newparameter[32].Value = TextBox24.Text;

            newparameter[33] = new SqlParameter("@weight6", SqlDbType.VarChar, 50);
            newparameter[33].Value = TextBox40.Text;

            newparameter[34] = new SqlParameter("@rating6", SqlDbType.VarChar, 50);
            newparameter[34].Value = ddlrating13.Text.Trim().ToString();

            newparameter[35] = new SqlParameter("@score6", SqlDbType.VarChar, 50);
            newparameter[35].Value = txtscore14.Text;
            newparameter[36] = new SqlParameter("@sno7", SqlDbType.Int);
            newparameter[36].Value = Label15.Text.Trim().ToString();

            newparameter[37] = new SqlParameter("@perfm7", SqlDbType.VarChar, 100);
            newparameter[37].Value = lblperformance14.Text.Trim().ToString();

            newparameter[38] = new SqlParameter("@achvt7", SqlDbType.VarChar, 100);
            newparameter[38].Value = TextBox27.Text;

            newparameter[39] = new SqlParameter("@weight7", SqlDbType.VarChar, 50);
            newparameter[39].Value = TextBox41.Text;

            newparameter[40] = new SqlParameter("@rating7", SqlDbType.VarChar, 50);
            newparameter[40].Value = ddlrating14.Text.Trim().ToString();

            newparameter[41] = new SqlParameter("@score7", SqlDbType.VarChar, 50);
            newparameter[41].Value = txtscore15.Text;
            newparameter[42] = new SqlParameter("@sno8", SqlDbType.Int);
            newparameter[42].Value = Label16.Text.Trim().ToString();

            newparameter[43] = new SqlParameter("@perfm8", SqlDbType.VarChar, 100);
            newparameter[43].Value = lblperformance15.Text.Trim().ToString();

            newparameter[44] = new SqlParameter("@achvt8", SqlDbType.VarChar, 100);
            newparameter[44].Value = TextBox30.Text;

            newparameter[45] = new SqlParameter("@weight8", SqlDbType.VarChar, 50);
            newparameter[45].Value = TextBox46.Text;

            newparameter[46] = new SqlParameter("@rating8", SqlDbType.VarChar, 50);
            newparameter[46].Value = ddlrating15.Text.Trim().ToString();

            newparameter[47] = new SqlParameter("@score8", SqlDbType.VarChar, 50);
            newparameter[47].Value = txtscore16.Text;
            newparameter[48] = new SqlParameter("@sno9", SqlDbType.Int);
            newparameter[48].Value = Label17.Text.Trim().ToString();

            newparameter[49] = new SqlParameter("@perfm9", SqlDbType.VarChar, 100);
            newparameter[49].Value = lblperformance16.Text.Trim().ToString();

            newparameter[50] = new SqlParameter("@achvt9", SqlDbType.VarChar, 100);
            newparameter[50].Value = TextBox33.Text;

            newparameter[51] = new SqlParameter("@weight9", SqlDbType.VarChar, 50);
            newparameter[51].Value = TextBox47.Text;

            newparameter[52] = new SqlParameter("@rating9", SqlDbType.VarChar, 50);
            newparameter[52].Value = ddlrating16.Text.Trim().ToString();

            newparameter[53] = new SqlParameter("@score9", SqlDbType.VarChar, 50);
            newparameter[53].Value = txtscore17.Text;

            newparameter[54] = new SqlParameter("@sno10", SqlDbType.Int);
            newparameter[54].Value = Label18.Text.Trim().ToString();

            newparameter[55] = new SqlParameter("@perfm10", SqlDbType.VarChar, 100);
            newparameter[55].Value = lblperformance17.Text.Trim().ToString();

            newparameter[56] = new SqlParameter("@achvt10", SqlDbType.VarChar, 100);
            newparameter[56].Value = TextBox36.Text;

            newparameter[57] = new SqlParameter("@weight10", SqlDbType.VarChar, 50);
            newparameter[57].Value = TextBox48.Text;

            newparameter[58] = new SqlParameter("@rating10", SqlDbType.VarChar, 50);
            newparameter[58].Value = ddlrating17.Text.Trim().ToString();

            newparameter[59] = new SqlParameter("@score10", SqlDbType.VarChar, 50);
            newparameter[59].Value = txtscore18.Text;
            newparameter[60] = new SqlParameter("@sno11", SqlDbType.Int);
            newparameter[60].Value = Label19.Text.Trim().ToString();

            newparameter[61] = new SqlParameter("@perfm11", SqlDbType.VarChar, 100);
            newparameter[61].Value = lblperformance18.Text.Trim().ToString();

            newparameter[62] = new SqlParameter("@achvt11", SqlDbType.VarChar, 100);
            newparameter[62].Value = TextBox39.Text;

            newparameter[63] = new SqlParameter("@weight11", SqlDbType.VarChar, 50);
            newparameter[63].Value = TextBox49.Text;

            newparameter[64] = new SqlParameter("@rating11", SqlDbType.VarChar, 50);
            newparameter[64].Value = ddlrating18.Text.Trim().ToString();

            newparameter[65] = new SqlParameter("@score11", SqlDbType.VarChar, 50);
            newparameter[65].Value = txtscore19.Text;
            newparameter[66] = new SqlParameter("@sno12", SqlDbType.Int);
            newparameter[66].Value = Label20.Text.Trim().ToString();

            newparameter[67] = new SqlParameter("@perfm12", SqlDbType.VarChar, 100);
            newparameter[67].Value = lblperformance19.Text.Trim().ToString();

            newparameter[68] = new SqlParameter("@achvt12", SqlDbType.VarChar, 100);
            newparameter[68].Value = TextBox42.Text;

            newparameter[69] = new SqlParameter("@weight12", SqlDbType.VarChar, 50);
            newparameter[69].Value = TextBox50.Text;

            newparameter[70] = new SqlParameter("@rating12", SqlDbType.VarChar, 50);
            newparameter[70].Value = ddlrating19.Text.Trim().ToString();

            newparameter[71] = new SqlParameter("@score12", SqlDbType.VarChar, 50);
            newparameter[71].Value = txtscore20.Text;
            newparameter[72] = new SqlParameter("@sno13", SqlDbType.Int);
            newparameter[72].Value = Label21.Text.Trim().ToString();

            newparameter[73] = new SqlParameter("@perfm13", SqlDbType.VarChar, 100);
            newparameter[73].Value = lblperformance20.Text.Trim().ToString();

            newparameter[74] = new SqlParameter("@achvt13", SqlDbType.VarChar, 100);
            newparameter[74].Value = TextBox45.Text;

            newparameter[75] = new SqlParameter("@weight13", SqlDbType.VarChar, 50);
            newparameter[75].Value = TextBox51.Text;

            newparameter[76] = new SqlParameter("@rating13", SqlDbType.VarChar, 50);
            newparameter[76].Value = ddlrating20.Text.Trim().ToString();

            newparameter[77] = new SqlParameter("@score13", SqlDbType.VarChar, 50);
            newparameter[77].Value = txtscore21.Text;

            newparameter[78] = new SqlParameter("@total ", SqlDbType.VarChar, 50);
            newparameter[78].Value = Convert.ToDouble(TextBox52.Text);

            newparameter[79] = new SqlParameter("@total1 ", SqlDbType.VarChar, 50);
            newparameter[79].Value = Convert.ToDouble(TextBox20.Text);

            newparameter[80] = new SqlParameter("@postedby", SqlDbType.VarChar, 100);
            newparameter[80].Value = _userCode.ToString();

            //newparameter[81] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[81].Value = _userCode.ToString();



            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_tbl_hrbp_supervision1 ", newparameter);
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
    protected void reset3()
    {
        TextBox52.Text = "";
        TextBox20.Text = "";
        TextBox10.Text = "";
        TextBox2.Text = "";
        TextBox26.Text = "";
        ddlrating8.SelectedValue = "0";
        txtscore9.Text = "";
        TextBox5.Text = "";
        TextBox32.Text = "";
        ddlrating9.SelectedValue = "0";
        txtscore10.Text = "";
        TextBox35.Text = "";
        ddlrating10.SelectedValue = "0";
        txtscore11.Text = "";
        TextBox16.Text = "";
        TextBox37.Text = "";
        ddlrating11.SelectedValue = "0";
        txtscore12.Text = "";
        TextBox21.Text = "";
        TextBox38.Text = "";
        ddlrating12.SelectedValue = "0";
        txtscore13.Text = "";
        TextBox24.Text = "";
        TextBox40.Text = "";
        ddlrating13.SelectedValue = "0";
        txtscore14.Text = "";
        TextBox27.Text = "";
        TextBox41.Text = "";
        ddlrating14.SelectedValue = "0";
        txtscore15.Text = "";
        TextBox30.Text = "";
        TextBox46.Text = "";
        ddlrating15.SelectedValue = "0";
        txtscore16.Text = "";
        TextBox33.Text = "";
        TextBox47.Text = "";
        ddlrating16.SelectedValue = "0";
        txtscore17.Text = "";
        TextBox36.Text = "";
        TextBox48.Text = "";
        ddlrating17.SelectedValue = "0";
        txtscore18.Text = "";
        TextBox39.Text = "";
        TextBox49.Text = "";
        ddlrating18.SelectedValue = "0";
        txtscore19.Text = "";
        TextBox42.Text = "";
        TextBox50.Text = "";
        ddlrating19.SelectedValue = "0";
        txtscore20.Text = "";
        TextBox45.Text = "";
        TextBox51.Text = "";
        ddlrating20.SelectedValue = "0";
        txtscore21.Text = "";
        TextBox52.Text = "";
        TextBox20.Text = "";
    }

    protected bool saverecord4()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[33];

            newparameter[0] = new SqlParameter("@sno1", SqlDbType.Int);
            newparameter[0].Value = Labelcom1.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@perfm1", SqlDbType.VarChar, 100);
            newparameter[1].Value = lblperformance21.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@achvt1", SqlDbType.VarChar, 100);
            newparameter[2].Value = TextBox3.Text;

            newparameter[3] = new SqlParameter("@weight1", SqlDbType.VarChar, 50);
            newparameter[3].Value = TextBox43.Text;

            newparameter[4] = new SqlParameter("@rating1", SqlDbType.VarChar, 50);
            newparameter[4].Value = ddlrating21.Text.Trim().ToString();

            newparameter[5] = new SqlParameter("@score1", SqlDbType.VarChar, 50);
            newparameter[5].Value = txtscore22.Text;

            newparameter[6] = new SqlParameter("@sno2", SqlDbType.Int);
            newparameter[6].Value = Labelcom2.Text.Trim().ToString();

            newparameter[7] = new SqlParameter("@perfm2", SqlDbType.VarChar, 100);
            newparameter[7].Value = lblperformance22.Text.Trim().ToString();

            newparameter[8] = new SqlParameter("@achvt2", SqlDbType.VarChar, 100);
            newparameter[8].Value = TextBox8.Text;

            newparameter[9] = new SqlParameter("@weight2", SqlDbType.VarChar, 50);
            newparameter[9].Value = TextBox54.Text;

            newparameter[10] = new SqlParameter("@rating2", SqlDbType.VarChar, 50);
            newparameter[10].Value = ddlrating22.Text.Trim().ToString();

            newparameter[11] = new SqlParameter("@score2", SqlDbType.VarChar, 50);
            newparameter[11].Value = txtscore23.Text;

            newparameter[12] = new SqlParameter("@sno3", SqlDbType.Int);
            newparameter[12].Value = Labelcom3.Text.Trim().ToString();

            newparameter[13] = new SqlParameter("@perfm3", SqlDbType.VarChar, 100);
            newparameter[13].Value = lblperformance23.Text.Trim().ToString();

            newparameter[14] = new SqlParameter("@achvt3", SqlDbType.VarChar, 100);
            newparameter[14].Value = TextBox17.Text;

            newparameter[15] = new SqlParameter("@weight3", SqlDbType.VarChar, 50);
            newparameter[15].Value = TextBox55.Text;

            newparameter[16] = new SqlParameter("@rating3", SqlDbType.VarChar, 50);
            newparameter[16].Value = ddlrating23.Text.Trim().ToString();

            newparameter[17] = new SqlParameter("@score3", SqlDbType.VarChar, 50);
            newparameter[17].Value = txtscore24.Text;

            newparameter[18] = new SqlParameter("@total ", SqlDbType.VarChar, 50);
            newparameter[18].Value = Convert.ToDouble(TextBox28.Text);

            newparameter[19] = new SqlParameter("@total1 ", SqlDbType.VarChar, 50);
            newparameter[19].Value = Convert.ToDouble(TextBox29.Text);

            newparameter[20] = new SqlParameter("@postedby", SqlDbType.VarChar, 100);
            newparameter[20].Value = _userCode.ToString();

            newparameter[21] = new SqlParameter("@sno4", SqlDbType.Int);
            newparameter[21].Value = Labelcom4.Text.Trim().ToString();

            newparameter[22] = new SqlParameter("@perfm4", SqlDbType.VarChar, 100);
            newparameter[22].Value = lblperformance24.Text.Trim().ToString();

            newparameter[23] = new SqlParameter("@achvt4", SqlDbType.VarChar, 100);
            newparameter[23].Value = TextBox23.Text;

            newparameter[24] = new SqlParameter("@weight4", SqlDbType.VarChar, 50);
            newparameter[24].Value = TextBox56.Text;

            newparameter[25] = new SqlParameter("@rating4", SqlDbType.VarChar, 50);
            newparameter[25].Value = ddlrating24.Text.Trim().ToString();

            newparameter[26] = new SqlParameter("@score4", SqlDbType.VarChar, 50);
            newparameter[26].Value = txtscore25.Text;

            newparameter[27] = new SqlParameter("@sno5", SqlDbType.Int);
            newparameter[27].Value = Labelcom5.Text.Trim().ToString();

            newparameter[28] = new SqlParameter("@perfm5", SqlDbType.VarChar, 100);
            newparameter[28].Value = lblperformance25.Text.Trim().ToString();

            newparameter[29] = new SqlParameter("@achvt5", SqlDbType.VarChar, 100);
            newparameter[29].Value = TextBox31.Text;

            newparameter[30] = new SqlParameter("@weight5", SqlDbType.VarChar, 50);
            newparameter[30].Value = TextBox57.Text;

            newparameter[31] = new SqlParameter("@rating5", SqlDbType.VarChar, 50);
            newparameter[31].Value = ddlrating25.Text.Trim().ToString();

            newparameter[32] = new SqlParameter("@score5", SqlDbType.VarChar, 50);
            newparameter[32].Value = txtscore26.Text;

            //newparameter[33] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[33].Value = _userCode.ToString();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_compliance_Implimentation", newparameter);
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
    protected void reset4()
    {

        TextBox3.Text = "";
        TextBox43.Text = "";
        ddlrating21.SelectedValue = "0";
        txtscore22.Text = "";
        TextBox8.Text = "";
        TextBox54.Text = "";
        ddlrating22.SelectedValue = "0";
        txtscore23.Text = "";
        TextBox17.Text = "";
        TextBox55.Text = "";
        ddlrating23.SelectedValue = "0";
        txtscore24.Text = "";
        TextBox23.Text = "";
        TextBox56.Text = "";
        ddlrating24.SelectedValue = "0";
        txtscore25.Text = "";
        TextBox31.Text = "";
        TextBox57.Text = "";
        ddlrating25.SelectedValue = "0";
        txtscore26.Text = "";
        TextBox28.Text = "";
        TextBox29.Text = "";
    }

    protected void butpayroll_Click(object sender, EventArgs e)
    {
        try
        {
            saverecords();
            saverecords1();
            saverecords3();
            saverecord4();
            saverecord5();
        }
        catch (Exception ex)
        {
            Output.Show("Record Not saved! Please contact to Super Admin");
        }
        finally
        {
            Output.Show("Record Saved Successfully!!");
            reset();
            reset2();
            reset3();
            reset4();
            reset5();
        }
    }
    protected bool saverecord5()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[27];

            newparameter[0] = new SqlParameter("@sno1", SqlDbType.Int);
            newparameter[0].Value = Labelpay1.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@perfm1", SqlDbType.VarChar, 100);
            newparameter[1].Value = Labelpay2.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@achvt1", SqlDbType.VarChar, 100);
            newparameter[2].Value = TextBoxpay.Text;

            newparameter[3] = new SqlParameter("@weight1", SqlDbType.VarChar, 50);
            newparameter[3].Value = TextBox58.Text;

            newparameter[4] = new SqlParameter("@rating1", SqlDbType.VarChar, 50);
            newparameter[4].Value = ddlrating26.Text.Trim().ToString();

            newparameter[5] = new SqlParameter("@score1", SqlDbType.VarChar, 50);
            newparameter[5].Value = txtscore27.Text;

            newparameter[6] = new SqlParameter("@sno2", SqlDbType.Int);
            newparameter[6].Value = Labelpay3.Text.Trim().ToString();

            newparameter[7] = new SqlParameter("@perfm2", SqlDbType.VarChar, 100);
            newparameter[7].Value = Labelpay4.Text.Trim().ToString();

            newparameter[8] = new SqlParameter("@achvt2", SqlDbType.VarChar, 100);
            newparameter[8].Value = TextBox15.Text;

            newparameter[9] = new SqlParameter("@weight2", SqlDbType.VarChar, 50);
            newparameter[9].Value = TextBox59.Text;

            newparameter[10] = new SqlParameter("@rating2", SqlDbType.VarChar, 50);
            newparameter[10].Value = ddlrating27.Text.Trim().ToString();

            newparameter[11] = new SqlParameter("@score2", SqlDbType.VarChar, 50);
            newparameter[11].Value = txtscore28.Text;

            newparameter[12] = new SqlParameter("@sno3", SqlDbType.Int);
            newparameter[12].Value = Labelpay5.Text.Trim().ToString();

            newparameter[13] = new SqlParameter("@perfm3", SqlDbType.VarChar, 100);
            newparameter[13].Value = Labelpay6.Text.Trim().ToString();

            newparameter[14] = new SqlParameter("@achvt3", SqlDbType.VarChar, 100);
            newparameter[14].Value = TextBox25.Text;

            newparameter[15] = new SqlParameter("@weight3", SqlDbType.VarChar, 50);
            newparameter[15].Value = TextBox60.Text;

            newparameter[16] = new SqlParameter("@rating3", SqlDbType.VarChar, 50);
            newparameter[16].Value = ddlrating28.Text.Trim().ToString();

            newparameter[17] = new SqlParameter("@score3", SqlDbType.VarChar, 50);
            newparameter[17].Value = txtscore29.Text;

            newparameter[18] = new SqlParameter("@total ", SqlDbType.VarChar, 50);
            newparameter[18].Value = Convert.ToDouble(TextBox62.Text);

            newparameter[19] = new SqlParameter("@total1 ", SqlDbType.VarChar, 50);
            newparameter[19].Value = Convert.ToDouble(TextBox44.Text);

            newparameter[20] = new SqlParameter("@postedby", SqlDbType.VarChar, 100);
            newparameter[20].Value = _userCode.ToString();

            newparameter[21] = new SqlParameter("@sno4", SqlDbType.Int);
            newparameter[21].Value = Labelpay7.Text.Trim().ToString();

            newparameter[22] = new SqlParameter("@perfm4", SqlDbType.VarChar, 100);
            newparameter[22].Value = Labelay8.Text.Trim().ToString();

            newparameter[23] = new SqlParameter("@achvt4", SqlDbType.VarChar, 100);
            newparameter[23].Value = TextBox34.Text;

            newparameter[24] = new SqlParameter("@weight4", SqlDbType.VarChar, 50);
            newparameter[24].Value = TextBox61.Text;

            newparameter[25] = new SqlParameter("@rating4", SqlDbType.VarChar, 50);
            newparameter[25].Value = ddlrating29.Text.Trim().ToString();

            newparameter[26] = new SqlParameter("@score4", SqlDbType.VarChar, 50);
            newparameter[26].Value = txtscore30.Text;

            //newparameter[27] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[27].Value = _userCode.ToString();


            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_apprisal_payroll_management", newparameter);
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

        TextBoxpay.Text = "";
        TextBox62.Text = "";
        ddlrating26.SelectedValue = "0";
        txtscore27.Text = "";
        TextBox15.Text = "";
        ddlrating27.SelectedValue = "0";
        txtscore28.Text = "";
        TextBox25.Text = "";
        TextBox60.Text = "";
        ddlrating28.SelectedValue = "0";
        txtscore29.Text = "";
        TextBox59.Text = "";
        TextBox44.Text = "";
        TextBox34.Text = "";
        TextBox61.Text = "";
        ddlrating29.SelectedValue = "0";
        txtscore30.Text = "";
        TextBox58.Text = "";
    }

}







