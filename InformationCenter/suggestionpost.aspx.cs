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
using Common.Console;


public partial class InformationCenter_suggestionpost : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }
    }

    //-------------------------------------FUNCTION TO SAVE VALUES IN DATABASE-------------------------------------
    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[6];

            newparameter[0] = new SqlParameter("@subject", SqlDbType.VarChar, 100);
            newparameter[0].Value = txtsubject.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[1].Value = txtdescription.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            newparameter[2].Value = Session["empcode"].ToString();

            newparameter[3] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
            newparameter[3].Value = Session["name"].ToString();

            newparameter[4] = new SqlParameter("@posteddate", SqlDbType.DateTime);
            newparameter[4].Value = System.DateTime.Now;

            newparameter[5] = new SqlParameter("@status", SqlDbType.TinyInt);
            newparameter[5].Value = 0;

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_suggestions_sp", newparameter);

            return true;
        }
        catch (SqlException sql)
        {
            Output.Show("Some database error has been occured!");
           /// message.InnerHtml = "Some database error has been occured!";
            return false;
        }
        catch (Exception ex)
        {
            Output.Show(ex.Message);
            //message.InnerHtml = ex.Message;
            return false;
        }
        finally
        {

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        bool s = saverecords();

        if (s)
        {
            Output.Show("Your suggestion has been sent to admin!");
           // message.InnerHtml = "Your suggestion has been sent to admin!";
            reset();
        }
    }

    //------------------------------------CALL FUNCTION TO RESET VALUES-----------------------------------------------------------

    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }

    //------------------------------------FUNCTION TO RESET CONTROLS VALUE-----------------------------------------------------------
    protected void reset()
    {
        txtsubject.Text = "";
        txtdescription.Text = "";
    }
}