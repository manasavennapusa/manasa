using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Common.Console;
using Common.Data;
using System.Data.SqlClient;

public partial class Travel_viewExpenseDetailsbyAdmin : System.Web.UI.Page
{

    string sqlstr;
    DataSet ds;
    DataActivity DataActivity = new DataActivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            SmartHr.Common.Alert("session expaired.");
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ClosePopup", "ClosePopup();", true);
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["tripid"] != null)
            {
                int tripid = Convert.ToInt32(Request.QueryString["tripid"]);
                bindExpanseDetails(tripid);
            }
        }
    }

    protected void bindExpanseDetails(int tripid)
    {
        sqlstr = @"select ed.*,td.tripno,c.currencycode from tbl_travel_ExpenseDetails ed with(nolock) 
                    inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                    inner join tbl_intranet_currencycode c on c.id=ed.currenceycode where ed.tripid=" + tripid.ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        DataView ExpanseDV = new DataView(ds.Tables[0]);
        ExpanseDV.RowFilter = "expensetype = 'Travel'";

        grdtravel.DataSource = ExpanseDV;
        grdtravel.DataBind();
        if (ExpanseDV.Count > 0)
        { divtravelbuttons.Visible = true; }
        else
        { divtravelbuttons.Visible = false; }


        ExpanseDV.RowFilter = "expensetype = 'L & C (Stay)'";
        grdlodging.DataSource = ExpanseDV;
        grdlodging.DataBind();
        if (ExpanseDV.Count > 0)
        { divlodgingbuttons.Visible = true; }
        else
        { divlodgingbuttons.Visible = false; }

        ExpanseDV.RowFilter = "expensetype = 'OOP'";
        grdoop.DataSource = ExpanseDV;
        grdoop.DataBind();
        if (ExpanseDV.Count > 0)
        { divoopbuttons.Visible = true; }
        else
        { divoopbuttons.Visible = false; }

        ExpanseDV.RowFilter = "expensetype = 'Miscellaneous'";
        grdmiscillenaous.DataSource = ExpanseDV;
        grdmiscillenaous.DataBind();
        if (ExpanseDV.Count > 0)
        { divmiscellaneousbuttons.Visible = true; }
        else
        { divmiscellaneousbuttons.Visible = false; }

        ExpanseDV.RowFilter = "expensetype = 'PersonalCar'";
        grdpersonalcar.DataSource = ExpanseDV;
        grdpersonalcar.DataBind();
        if (ExpanseDV.Count > 0)
        { divpersonalbuttons.Visible = true; }
        else
        { divpersonalbuttons.Visible = false; }

        ExpanseDV.RowFilter = "expensetype = 'Telephone'";
        grdtelephone.DataSource = ExpanseDV;
        grdtelephone.DataBind();
        if (ExpanseDV.Count > 0)
        { divtelphonebuttons.Visible = true; }
        else
        { divtelphonebuttons.Visible = false; }
    }

    protected void btnTravelSave_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            foreach (GridViewRow row in grdtravel.Rows)
            {
                Label amount = (Label)row.FindControl("lblAmount");
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                if (Convert.ToDecimal(amount.Text) < Convert.ToDecimal(sanctionedamount.Text))
                {
                    Output.Show("Sanctioned Amount Should not be greater than Claimed amount.");
                    return;
                }
            }

            SqlParameter[] parm = new SqlParameter[3];

            foreach (GridViewRow row in grdtravel.Rows)
            {
                Label amount = (Label)row.FindControl("lblAmount");
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                TextBox admincomments = (TextBox)row.FindControl("lblAdmincomments");

                Output.AssignParameter(parm, 0, "@expenseid", "Int", 0, grdtravel.DataKeys[row.RowIndex].Value.ToString());
                Output.AssignParameter(parm, 1, "@sanctionedamount", "Decimal", 50, sanctionedamount.Text);
                Output.AssignParameter(parm, 2, "@admincomments", "String", 8000, admincomments.Text);

                Flag += SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_travel_update_sanctionedamount", parm);
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Saved Successfully");
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
        }
        else
        {
            Output.Show("Not Saved Successfully");
        }

    }

    protected void btnLodgingSave_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            foreach (GridViewRow row in grdlodging.Rows)
            {
                Label amount = (Label)row.FindControl("lblAmount");
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                if (Convert.ToDecimal(amount.Text) < Convert.ToDecimal(sanctionedamount.Text))
                {
                    Output.Show("Sanctioned Amount Should not be greater than Claimed amount.");
                    return;
                }
            }
            SqlParameter[] parm = new SqlParameter[3];

            foreach (GridViewRow row in grdlodging.Rows)
            {
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                TextBox admincomments = (TextBox)row.FindControl("lblAdmincomments");

                Output.AssignParameter(parm, 0, "@expenseid", "Int", 0, grdlodging.DataKeys[row.RowIndex].Value.ToString());
                Output.AssignParameter(parm, 1, "@sanctionedamount", "Decimal", 50, sanctionedamount.Text);
                Output.AssignParameter(parm, 2, "@admincomments", "String", 8000, admincomments.Text);

                Flag += SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_travel_update_sanctionedamount", parm);
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Saved Successfully");
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
        }
        else
        {
            Output.Show("Not Saved Successfully");
        }
    }

    protected void btnOOPSave_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            foreach (GridViewRow row in grdoop.Rows)
            {
                Label amount = (Label)row.FindControl("lblAmount");
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                if (Convert.ToDecimal(amount.Text) < Convert.ToDecimal(sanctionedamount.Text))
                {
                    Output.Show("Sanctioned Amount Should not be greater than Claimed amount.");
                    return;
                }
            }
            SqlParameter[] parm = new SqlParameter[3];

            foreach (GridViewRow row in grdoop.Rows)
            {
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                TextBox admincomments = (TextBox)row.FindControl("lblAdmincomments");

                Output.AssignParameter(parm, 0, "@expenseid", "Int", 0, grdoop.DataKeys[row.RowIndex].Value.ToString());
                Output.AssignParameter(parm, 1, "@sanctionedamount", "Decimal", 50, sanctionedamount.Text);
                Output.AssignParameter(parm, 2, "@admincomments", "String", 8000, admincomments.Text);

                Flag += SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_travel_update_sanctionedamount", parm);
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Saved Successfully");
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
        }
        else
        {
            Output.Show("Not Saved Successfully");
        }
    }

    protected void bntMiscelSave_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            foreach (GridViewRow row in grdmiscillenaous.Rows)
            {
                Label amount = (Label)row.FindControl("lblAmount");
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                if (Convert.ToDecimal(amount.Text) < Convert.ToDecimal(sanctionedamount.Text))
                {
                    Output.Show("Sanctioned Amount Should not be greater than Claimed amount.");
                    return;
                }
            }
            SqlParameter[] parm = new SqlParameter[3];

            foreach (GridViewRow row in grdmiscillenaous.Rows)
            {
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                TextBox admincomments = (TextBox)row.FindControl("lblAdmincomments");

                Output.AssignParameter(parm, 0, "@expenseid", "Int", 0, grdmiscillenaous.DataKeys[row.RowIndex].Value.ToString());
                Output.AssignParameter(parm, 1, "@sanctionedamount", "Decimal", 50, sanctionedamount.Text);
                Output.AssignParameter(parm, 2, "@admincomments", "String", 8000, admincomments.Text);

                Flag += SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_travel_update_sanctionedamount", parm);
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Saved Successfully");
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
        }
        else
        {
            Output.Show("Not Saved Successfully");
        }
    }

    protected void btnPersonacarSave_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            foreach (GridViewRow row in grdpersonalcar.Rows)
            {
                Label amount = (Label)row.FindControl("lblAmount");
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                if (Convert.ToDecimal(amount.Text) < Convert.ToDecimal(sanctionedamount.Text))
                {
                    Output.Show("Sanctioned Amount Should not be greater than Claimed amount.");
                    return;
                }
            }
            SqlParameter[] parm = new SqlParameter[3];

            foreach (GridViewRow row in grdpersonalcar.Rows)
            {
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                TextBox admincomments = (TextBox)row.FindControl("lblAdmincomments");

                Output.AssignParameter(parm, 0, "@expenseid", "Int", 0, grdpersonalcar.DataKeys[row.RowIndex].Value.ToString());
                Output.AssignParameter(parm, 1, "@sanctionedamount", "Decimal", 50, sanctionedamount.Text);
                Output.AssignParameter(parm, 2, "@admincomments", "String", 8000, admincomments.Text);

                Flag += SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_travel_update_sanctionedamount", parm);
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Saved Successfully");
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
        }
        else
        {
            Output.Show("Not Saved Successfully");
        }
    }

    protected void btnFaxSave_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            foreach (GridViewRow row in grdtelephone.Rows)
            {
                Label amount = (Label)row.FindControl("lblAmount");
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                if (Convert.ToDecimal(amount.Text) < Convert.ToDecimal(sanctionedamount.Text))
                {
                    Output.Show("Sanctioned Amount Should not be greater than Claimed amount.");
                    return;
                }
            }
            SqlParameter[] parm = new SqlParameter[3];

            foreach (GridViewRow row in grdtelephone.Rows)
            {
                TextBox sanctionedamount = (TextBox)row.FindControl("txtSanctionedAmount");
                TextBox admincomments = (TextBox)row.FindControl("lblAdmincomments");

                Output.AssignParameter(parm, 0, "@expenseid", "Int", 0, grdtelephone.DataKeys[row.RowIndex].Value.ToString());
                Output.AssignParameter(parm, 1, "@sanctionedamount", "Decimal", 50, sanctionedamount.Text);
                Output.AssignParameter(parm, 2, "@admincomments", "String", 8000, admincomments.Text);

                Flag += SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_travel_update_sanctionedamount", parm);
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            Output.Show("Saved Successfully");
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
        }
        else
        {
            Output.Show("Not Saved Successfully");
        }
    }
}