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
using Common.Console;
using Common.Data;

public partial class appraisal_OverallRatings : System.Web.UI.Page
{
  DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();

            if (!IsPostBack)
            {
              


            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void btnsumbmit_Click(object sender, EventArgs e)
    {


        SqlParameter[] sqlParam = new SqlParameter[4];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            SqlConnection connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, UserCode.ToString());
            Output.AssignParameter(sqlParam, 1, "@EmployeeComment", "String", 100, TextBox1.Text);
            Output.AssignParameter(sqlParam, 2, "@AppraisalComment", "String", 100, TextBox2.Text);
            Output.AssignParameter(sqlParam, 3, "@createdby", "String", 50, UserCode.ToString());


            Connection = DataActivity.OpenConnection();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "[sp_Appraisal_OverAllRating]", sqlParam);

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
            Output.Show("submitted sucessfully");
            reset();
        }

    }

    protected void reset()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
}


     

        



































    
