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


public partial class appraisal_AdditionalPerformanceFactors : System.Web.UI.Page
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
    }
    //==================================
    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool s = saverecords();
        if (s)
        {
            //message.InnerHtml = "Record has been saved successfully!";
            MsgBox("Record saved successfully!", this.Page, this);
        }
        else MsgBox("Record has not been saved!", this.Page, this);
        reset();
    }
    //--------------------------------------------------------------
    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[22];

            newparameter[0] = new SqlParameter("@typeEr", SqlDbType.VarChar, 10);
            newparameter[0].Value = Label5.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@af1", SqlDbType.VarChar, 100);
            newparameter[1].Value = lblperformance1.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@count1", SqlDbType.Int);
            newparameter[2].Value = TextBox1.Text;

            newparameter[3] = new SqlParameter("@perc1", SqlDbType.VarChar, 10);
            newparameter[3].Value = TextBox7.Text;

            newparameter[4] = new SqlParameter("@af2", SqlDbType.VarChar, 100);
            newparameter[4].Value = Label1.Text.Trim().ToString();

            newparameter[5] = new SqlParameter("@count2", SqlDbType.Int);
            newparameter[5].Value = TextBox2.Text;

            newparameter[6] = new SqlParameter("@perc2", SqlDbType.VarChar, 10);
            newparameter[6].Value = Convert.ToDouble(TextBox8.Text); 

            newparameter[7] = new SqlParameter("@af3", SqlDbType.VarChar, 100);
            newparameter[7].Value = Label2.Text.Trim().ToString();

            newparameter[8] = new SqlParameter("@count3", SqlDbType.Int);
            newparameter[8].Value = TextBox3.Text;

            newparameter[9] = new SqlParameter("@perc3", SqlDbType.VarChar, 10);
            newparameter[9].Value = Convert.ToDouble(TextBox9.Text); 

            newparameter[10] = new SqlParameter("@typeBo", SqlDbType.VarChar, 10);
            newparameter[10].Value = Label6.Text.Trim().ToString();

            newparameter[11] = new SqlParameter("@af4", SqlDbType.VarChar, 100);
            newparameter[11].Value = lblperformance2.Text.Trim().ToString();

            newparameter[12] = new SqlParameter("@count4", SqlDbType.Int);
            newparameter[12].Value = TextBox4.Text;

            newparameter[13] = new SqlParameter("@perc4", SqlDbType.VarChar, 10);
            newparameter[13].Value = Convert.ToDouble(TextBox10.Text);

            newparameter[14] = new SqlParameter("@af5", SqlDbType.VarChar, 100);
            newparameter[14].Value = Label3.Text.Trim().ToString();

            newparameter[15] = new SqlParameter("@count5", SqlDbType.Int);
            newparameter[15].Value = TextBox5.Text;

            newparameter[16] = new SqlParameter("@perc5", SqlDbType.VarChar, 10);
            newparameter[16].Value = Convert.ToDouble(TextBox11.Text); 

            newparameter[17] = new SqlParameter("@af6", SqlDbType.VarChar, 100);
            newparameter[17].Value = Label4.Text.Trim().ToString();

            newparameter[18] = new SqlParameter("@count6", SqlDbType.Int);
            newparameter[18].Value = TextBox6.Text;

            newparameter[19] = new SqlParameter("@perc6", SqlDbType.VarChar, 10);
            newparameter[19].Value = Convert.ToDouble(TextBox12.Text);

            newparameter[20] = new SqlParameter("@total", SqlDbType.VarChar, 10);
            newparameter[20].Value = Convert.ToDouble(lblTotal.Text);

            newparameter[21] = new SqlParameter("@postedby", SqlDbType.VarChar, 200);
            newparameter[21].Value = _userCode.ToString();

            //newparameter[22] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //newparameter[22].Value = _userCode.ToString();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Additional_Performance_Factors", newparameter);
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
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        lblTotal.Text = "";
    }


}