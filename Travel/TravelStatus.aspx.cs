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

public partial class Travel_TravelStatus : System.Web.UI.Page
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
                //grid_Travel.Visible = false;
                //grid_Travel.Visible = false;
                //grid_Travel.Visible = true;


                //SqlParameter[] param = new SqlParameter[1];

                //param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                //param[0].Value = Session["empcode"].ToString();

                //DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getApprovedTravelForms", param);
                //grid_Travel.DataSource = ds;
                //grid_Travel.DataBind();
                Response.Redirect("ApprovedTravelForm.aspx");
            }


            else if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 0)
            {

                //GridView1.Visible = false;
                //GridView1.Visible = false;
                //GridView1.Visible = true;

                //SqlParameter[] param = new SqlParameter[1];

                //param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                //param[0].Value = Session["empcode"].ToString();

                //DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getPendingTravelForms", param);
                //grid_Travel.DataSource = ds;
                //grid_Travel.DataBind();

                Response.Redirect("PendingTravelForm.aspx");
            }



            else if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 2)
            {
                //grdpending1.Visible = true;
                //grdpending.Visible = false;
                //grdreim.Visible = false;
                //SqlParameter[] parm = new SqlParameter[4];

                //Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
                //Output.AssignParameter(parm, 1, "@flag", "Int", 0, "1");
                //Output.AssignParameter(parm, 2, "@level", "Int", 0, "4");
                //Output.AssignParameter(parm, 3, "@reject", "Int", 0, "0");
                //Connection = DA.OpenConnection();
                //DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "[sp_Rb_get_Closedreimbursementdetails_emp]", parm);

                //if (ds2.Tables[0].Rows.Count > 0)
                //{

                //    grdpending1.DataSource = ds2;
                //    grdpending1.DataBind();

                //}

                Response.Redirect("RejectedTravelForm.aspx");
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
    protected void grid_Travel_PreRender(object sender, EventArgs e)
    {

    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {

    }
}