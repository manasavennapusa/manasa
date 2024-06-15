using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System;
using Common.Data;
using Common.Console;
using System.Globalization;
using DataAccessLayer;
using System.Text;
using System.EnterpriseServices;
using System.Web.UI.WebControls.WebParts;


public partial class admin_Empdetails : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    string sqlstr, _userCode, _companyId, RoleId;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    string cn = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString;
  
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
      
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        try
        {

            //string cn = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cn);
            con.Open();


            SqlParameter[] sqlparam1 = new SqlParameter[3];
            sqlparam1[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
            if (tbempname.Text == "")
            {
                sqlparam1[0].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlparam1[0].Value = tbempname.Text;
            }

            sqlparam1[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
            if (tbempcode.Text == "")
            {
                sqlparam1[1].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlparam1[1].Value = tbempcode.Text;
            }

            sqlparam1[2] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
            if (tbempno.Text == " ")
            {
                sqlparam1[2].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlparam1[2].Value = tbempno.Text;
            }


            ds = SQLServer.ExecuteDataset(con, CommandType.StoredProcedure, transaction, "sp_insert_Employee_Details", sqlparam1);
           
            SmartHr.Common.Alert("Employee Job Details Saved successfully!!!.");
            con.Close();
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }  

}
   
    
  



    
