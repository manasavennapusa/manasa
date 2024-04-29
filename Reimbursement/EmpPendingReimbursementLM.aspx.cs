using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class Reimbursement_EmpPendingReimbursementLM : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DA = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null)
        {
            UserCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {

                BindPendingDetailsAll();
            }
        }
        else { Response.Redirect("~/Default.aspx"); }
    }
   


    private void BindPendingDetailsAll()
    {
        SqlConnection Connection = null;
        try
        {
            SqlParameter[] parm = new SqlParameter[5];
            Output.AssignParameter(parm, 0, "@fromdate", "String", 50, txtfromdate.Text);
            Output.AssignParameter(parm, 1, "@todate", "String", 50, txttodate.Text);
            Output.AssignParameter(parm, 2, "@empcode", "String", 50, UserCode);
            Output.AssignParameter(parm, 3, "@flag", "Int", 0, "1");
            Output.AssignParameter(parm, 4, "@type", "String", 0, "LM");
            Connection = DA.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_Rb_get_empreimdetails_Pending", parm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdpending.DataSource = ds;
                grdpending.DataBind();
            }
            else { Output.Show("No Data Found"); }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        BindPendingDetails();
    }

    private void BindPendingDetails()
    {
        SqlConnection Connection = null;
        try
        {
            SqlParameter[] parm = new SqlParameter[5];
            Output.AssignParameter(parm, 0, "@fromdate", "String", 50, txtfromdate.Text);
            Output.AssignParameter(parm, 1, "@todate", "String", 50, txttodate.Text);
            Output.AssignParameter(parm, 2, "@empcode", "String", 50, UserCode);
            Output.AssignParameter(parm, 3, "@flag", "Int", 0, "0");
            Output.AssignParameter(parm, 4, "@type", "String", 0, "LM");
            Connection = DA.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_Rb_get_empreimdetails_Pending", parm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdpending.DataSource = ds;
                grdpending.DataBind();
            }
            else { Output.Show("No Data Found"); }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }


    protected void btnpending_Command(object sender, CommandEventArgs e)
    {
        int rid = Convert.ToInt32(e.CommandArgument);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'PendingClosed.aspx?rid=" + rid + "', null, 'height=600,width=1000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void grdpending_PreRender(object sender, EventArgs e)
    {
        if (grdpending.Rows.Count > 0)
        {
            grdpending.UseAccessibleHeader = true;
            grdpending.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}