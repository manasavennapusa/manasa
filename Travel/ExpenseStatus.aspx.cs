using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;

public partial class Travel_ExpenseStatus : System.Web.UI.Page
{
    string strsql, _userCode;
    DataSet ds = new DataSet();
    DataActivity DA = new DataActivity();
    SqlConnection connection = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        // p3.Visible = false;
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            drp_leavestatus.SelectedIndex = 0;
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_grid();
    }

    private void bind_grid()
    {

        var activity = new DataActivity();


        SqlConnection Connection = null;
        try
        {

            if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 1)
            {
                Response.Redirect("ViewExpanceDetails.aspx");
            }


            else if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 0)
            {

                Response.Redirect("PendingExpense.aspx");
            }



            else if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 2)
            {

                Response.Redirect("RejectedExpenseForms.aspx");
            }





        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            //DA.CloseConnection();
        }

    }



    protected void btn_reset_Click(object sender, EventArgs e)
    {

    }
}