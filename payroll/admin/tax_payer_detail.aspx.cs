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
public partial class payroll_admin_tax_payer_detail : System.Web.UI.Page
{
    string sqlstr;   
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
            

           binddetail();
        }
        message.InnerHtml = "";
    }

    protected void binddetail()
    {
     
        sqlstr = "SELECT * FROM tbl_payroll_tax_payer_detail";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text,sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        {
            txtempname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
            txtempadd1.Text = ds.Tables[0].Rows[0]["address1"].ToString();
            txtempadd2.Text = ds.Tables[0].Rows[0]["address2"].ToString();
            txtempadd3.Text = ds.Tables[0].Rows[0]["address3"].ToString();
            txtempadd4.Text = ds.Tables[0].Rows[0]["address4"].ToString();
            txtempadd5.Text = ds.Tables[0].Rows[0]["address5"].ToString();
            ddlempstate.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
            txtemppin.Text = ds.Tables[0].Rows[0]["pin"].ToString();
            txtemptel.Text = ds.Tables[0].Rows[0]["telephone"].ToString();
            txtempemail.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
            txtempstd.Text = ds.Tables[0].Rows[0]["std"].ToString();

            txtrespname.Text = ds.Tables[0].Rows[0]["rempname"].ToString();
            txtrespfname.Text = ds.Tables[0].Rows[0]["fempname"].ToString();
            txtrespdesig.Text = ds.Tables[0].Rows[0]["designation"].ToString();
            txtrespadd1.Text = ds.Tables[0].Rows[0]["raddress1"].ToString();
            txtrespadd2.Text = ds.Tables[0].Rows[0]["raddress2"].ToString();
            txtrespadd3.Text = ds.Tables[0].Rows[0]["raddress3"].ToString();
            txtrespadd4.Text = ds.Tables[0].Rows[0]["raddress4"].ToString();
            txtrespadd5.Text = ds.Tables[0].Rows[0]["raddress5"].ToString();
            ddlrespstate.SelectedValue = ds.Tables[0].Rows[0]["rstate"].ToString();
            txtresppin.Text = ds.Tables[0].Rows[0]["rpin"].ToString();
            txtrespemail.Text = ds.Tables[0].Rows[0]["remailid"].ToString();
            txtrespstd.Text = ds.Tables[0].Rows[0]["rstd"].ToString();
            txtresptel.Text = ds.Tables[0].Rows[0]["rtelephone"].ToString();
        }
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {

        inserttaxpayerdetails();

//        SqlParameter[] sqlparam = new SqlParameter[24];

//        sqlparam[0] = new SqlParameter("@empname", SqlDbType.NVarChar, 50);
//        sqlparam[0].Value = txtempname.Text.Trim().ToString();

//        sqlparam[1] = new SqlParameter("@address1", SqlDbType.NVarChar, 50);
//        sqlparam[1].Value = txtempadd1.Text.Trim().ToString();

//        sqlparam[2] = new SqlParameter("@address2", SqlDbType.NVarChar, 50);
//        sqlparam[2].Value = txtempadd2.Text.Trim().ToString();

//        sqlparam[3] = new SqlParameter("@address3", SqlDbType.NVarChar, 50);
//        sqlparam[3].Value = txtempadd3.Text.Trim().ToString();

//        sqlparam[4] = new SqlParameter("@address4", SqlDbType.NVarChar, 50);
//        sqlparam[4].Value = txtempadd4.Text.Trim().ToString();

//        sqlparam[5] = new SqlParameter("@address5", SqlDbType.NVarChar, 50);
//        sqlparam[5].Value = txtempadd5.Text.Trim().ToString();

//        sqlparam[6] = new SqlParameter("@state", SqlDbType.Int);
//        sqlparam[6].Value = Convert.ToInt32(ddlempstate.SelectedValue);

//        sqlparam[7] = new SqlParameter("@pin", SqlDbType.NVarChar, 50);
//        sqlparam[7].Value = txtemppin.Text.Trim().ToString();

//        sqlparam[8] = new SqlParameter("@telephone", SqlDbType.NVarChar, 50);
//        sqlparam[8].Value = txtemptel.Text.Trim().ToString();

//        sqlparam[9] = new SqlParameter("@emailid", SqlDbType.NVarChar, 50);
//        sqlparam[9].Value = txtempemail.Text.Trim().ToString();

//        sqlparam[10] = new SqlParameter("@std", SqlDbType.NVarChar, 50);
//        sqlparam[10].Value = txtempstd.Text.Trim().ToString();

//        sqlparam[11] = new SqlParameter("@rempname", SqlDbType.NVarChar, 50);
//        sqlparam[11].Value = txtrespname.Text.Trim().ToString();

//        sqlparam[12] = new SqlParameter("@fempname", SqlDbType.NVarChar, 50);
//        sqlparam[12].Value = txtrespfname.Text.Trim().ToString();

//        sqlparam[13] = new SqlParameter("@designation", SqlDbType.NVarChar, 50);
//        sqlparam[13].Value = txtrespdesig.Text.Trim().ToString();

//        sqlparam[14] = new SqlParameter("@raddress1", SqlDbType.NVarChar, 50);
//        sqlparam[14].Value = txtrespadd1.Text.Trim().ToString();

//        sqlparam[15] = new SqlParameter("@raddress2", SqlDbType.NVarChar, 50);
//        sqlparam[15].Value = txtrespadd2.Text.Trim().ToString();

//        sqlparam[16] = new SqlParameter("@raddress3", SqlDbType.NVarChar, 50);
//        sqlparam[16].Value = txtrespadd3.Text.Trim().ToString();

//        sqlparam[17] = new SqlParameter("@raddress4", SqlDbType.NVarChar, 50);
//        sqlparam[17].Value = txtrespadd4.Text.Trim().ToString();

//        sqlparam[18] = new SqlParameter("@raddress5", SqlDbType.NVarChar, 50);
//        sqlparam[18].Value = txtrespadd5.Text.Trim().ToString();

//        sqlparam[19] = new SqlParameter("@rstate", SqlDbType.VarChar, 50);
//        sqlparam[19].Value = Convert.ToInt32(ddlrespstate.SelectedValue);

//        sqlparam[20] = new SqlParameter("@rpin", SqlDbType.NVarChar, 50);
//        sqlparam[20].Value = txtresppin.Text.Trim().ToString();

//        sqlparam[21] = new SqlParameter("@remailid", SqlDbType.NVarChar, 50);
//        sqlparam[21].Value = txtrespemail.Text.Trim().ToString();

//        sqlparam[22] = new SqlParameter("@rstd", SqlDbType.NVarChar, 50);
//        sqlparam[22].Value = txtrespstd.Text.Trim().ToString();

//        sqlparam[23] = new SqlParameter("@rtelephone", SqlDbType.NVarChar, 50);
//        sqlparam[23].Value = txtresptel.Text.Trim().ToString();

//        sqlstr = @"UPDATE tbl_payroll_tax_payer_detail SET
//            empname=@empname,
//            address1=@address1,
//            address2=@address2,
//            address3=@address3,
//            address4=@address4,
//            address5=@address5,
//            state=@state,
//            pin=@pin,
//            telephone=@telephone,
//            emailid=@emailid,
//            std=@std,
//            rempname=@rempname,
//            fempname=@fempname,
//            designation=@designation,
//            raddress1=@raddress1,
//            raddress2=@raddress2,
//            raddress3=@raddress3,
//            raddress4=@raddress4,
//            raddress5=@raddress5,
//            rstate=@rstate,
//            rpin=@rpin,
//            remailid=@remailid,
//            rstd=@rstd,
//            rtelephone=@rtelephone";
//       int i= DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["EarthConnectionString"].ToString(), CommandType.Text, sqlstr,sqlparam);

//       if (i > 0)
//       {
//           message.InnerHtml = "";
//           message.InnerHtml = "Records has been updated successfully !";
//       }
    }

    protected void inserttaxpayerdetails()
    {
        SqlParameter[] sqlparam = new SqlParameter[27];

        sqlparam[0] = new SqlParameter("@empname", SqlDbType.NVarChar, 50);
        sqlparam[0].Value = txtempname.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@address1", SqlDbType.NVarChar, 50);
        sqlparam[1].Value = txtempadd1.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@address2", SqlDbType.NVarChar, 50);
        sqlparam[2].Value = txtempadd2.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@address3", SqlDbType.NVarChar, 50);
        sqlparam[3].Value = txtempadd3.Text.Trim().ToString();

        sqlparam[4] = new SqlParameter("@address4", SqlDbType.NVarChar, 50);
        sqlparam[4].Value = txtempadd4.Text.Trim().ToString();

        sqlparam[5] = new SqlParameter("@address5", SqlDbType.NVarChar, 50);
        sqlparam[5].Value = txtempadd5.Text.Trim().ToString();

        sqlparam[6] = new SqlParameter("@state", SqlDbType.Int);
        sqlparam[6].Value = Convert.ToInt32(ddlempstate.SelectedValue);

        sqlparam[7] = new SqlParameter("@pin", SqlDbType.NVarChar, 50);
        sqlparam[7].Value = txtemppin.Text.Trim().ToString();

        sqlparam[8] = new SqlParameter("@telephone", SqlDbType.NVarChar, 50);
        sqlparam[8].Value = txtemptel.Text.Trim().ToString();

        sqlparam[9] = new SqlParameter("@emailid", SqlDbType.NVarChar, 50);
        sqlparam[9].Value = txtempemail.Text.Trim().ToString();

        sqlparam[10] = new SqlParameter("@std", SqlDbType.NVarChar, 50);
        sqlparam[10].Value = txtempstd.Text.Trim().ToString();

        sqlparam[11] = new SqlParameter("@rempname", SqlDbType.NVarChar, 50);
        sqlparam[11].Value = txtrespname.Text.Trim().ToString();

        sqlparam[12] = new SqlParameter("@fempname", SqlDbType.NVarChar, 50);
        sqlparam[12].Value = txtrespfname.Text.Trim().ToString();

        sqlparam[13] = new SqlParameter("@designation", SqlDbType.NVarChar, 50);
        sqlparam[13].Value = txtrespdesig.Text.Trim().ToString();

        sqlparam[14] = new SqlParameter("@raddress1", SqlDbType.NVarChar, 50);
        sqlparam[14].Value = txtrespadd1.Text.Trim().ToString();

        sqlparam[15] = new SqlParameter("@raddress2", SqlDbType.NVarChar, 50);
        sqlparam[15].Value = txtrespadd2.Text.Trim().ToString();

        sqlparam[16] = new SqlParameter("@raddress3", SqlDbType.NVarChar, 50);
        sqlparam[16].Value = txtrespadd3.Text.Trim().ToString();

        sqlparam[17] = new SqlParameter("@raddress4", SqlDbType.NVarChar, 50);
        sqlparam[17].Value = txtrespadd4.Text.Trim().ToString();

        sqlparam[18] = new SqlParameter("@raddress5", SqlDbType.NVarChar, 50);
        sqlparam[18].Value = txtrespadd5.Text.Trim().ToString();

        sqlparam[19] = new SqlParameter("@rstate", SqlDbType.VarChar, 50);
        sqlparam[19].Value = Convert.ToInt32(ddlrespstate.SelectedValue);

        sqlparam[20] = new SqlParameter("@rpin", SqlDbType.NVarChar, 50);
        sqlparam[20].Value = txtresppin.Text.Trim().ToString();

        sqlparam[21] = new SqlParameter("@remailid", SqlDbType.NVarChar, 50);
        sqlparam[21].Value = txtrespemail.Text.Trim().ToString();

        sqlparam[22] = new SqlParameter("@rstd", SqlDbType.NVarChar, 50);
        sqlparam[22].Value = txtrespstd.Text.Trim().ToString();

        sqlparam[23] = new SqlParameter("@rtelephone", SqlDbType.NVarChar, 50);
        sqlparam[23].Value = txtresptel.Text.Trim().ToString();

        sqlparam[24] = new SqlParameter("@epf_no", SqlDbType.VarChar, 20);
        sqlparam[24].Value = txtepfno.Text.Trim().ToString();

        sqlparam[25] = new SqlParameter("@esi_no", SqlDbType.VarChar, 20);
        sqlparam[25].Value = txtesino.Text.Trim().ToString();

        sqlparam[26] = new SqlParameter("@esi_local_no", SqlDbType.VarChar, 20);
        sqlparam[26].Value = txtesilocalno.Text.Trim().ToString();


        sqlstr = @"INSERT INTO tbl_payroll_tax_payer_detail(empname,address1,address2,address3,address4,address5,state,pin,telephone,emailid,std,
                rempname,fempname,designation,raddress1,raddress2,raddress3,raddress4,raddress5,rstate,rpin,remailid,rstd,rtelephone,epf_no,esi_no,esi_local_no)
                VALUES(@empname,@address1,@address2,@address3,@address4,@address5,@state,@pin,@telephone,@emailid,@std,
      @rempname,@fempname,@designation,@raddress1,@raddress2,@raddress3,@raddress4,@raddress5,@rstate,@rpin,@remailid,@rstd,@rtelephone,@epf_no,@esi_no,@esi_local_no)";
        
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);

        if (i > 0)
        {
            message.InnerHtml = "";
            message.InnerHtml = "Records has been inserted successfully !";
        }
        else
        {
            message.InnerHtml = "";
            message.InnerHtml = "Records has already found !";
        }
    }

    
}
