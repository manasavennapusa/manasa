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
public partial class Reimbursement_HRPendingReimbursement : System.Web.UI.Page
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
                BindDetailsAll();
            }
        }
        else { Response.Redirect("~/Default.aspx"); }

        if (Request.QueryString["updated"] != null)
            Output.Show("Reimbursement Approved");

        if (Request.QueryString["updated1"] != null)
            Output.Show("Reimbursement Rejected");
    }

    private void BindDetailsAll()
    {
        SqlConnection Connection = null;
        try
        {
            SqlParameter[] parm = new SqlParameter[4];
            Output.AssignParameter(parm, 0, "@fromdate", "String", 50, txtfromdate.Text);
            Output.AssignParameter(parm, 1, "@todate", "String", 50, txttodate.Text);
            Output.AssignParameter(parm, 2, "@empcode", "String", 50, UserCode);
            Output.AssignParameter(parm, 3, "@flag", "Int", 0, "0");
            Connection = DA.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_Rb_get_reimbursementdetails_HR", parm);
            grdreim.DataSource = ds;
            grdreim.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        BindDetails();
    }

    private void BindDetails()
    {

        SqlConnection Connection = null;
        try
        {
            SqlParameter[] parm = new SqlParameter[4];
            Output.AssignParameter(parm, 0, "@fromdate", "String", 50, txtfromdate.Text);
            Output.AssignParameter(parm, 1, "@todate", "String", 50, txttodate.Text);
            Output.AssignParameter(parm, 2, "@empcode", "String", 50, UserCode);
            Output.AssignParameter(parm, 3, "@flag", "Int", 0, "1");
            Connection = DA.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_Rb_get_reimbursementdetails_HR", parm);
            grdreim.DataSource = ds;
            grdreim.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }
    protected void grdreim_PreRender(object sender, EventArgs e)
    {
        if (grdreim.Rows.Count > 0)
        {
            grdreim.UseAccessibleHeader = true;
            grdreim.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btnview_Command(object sender, CommandEventArgs e)
    {
        int rid = Convert.ToInt32(e.CommandArgument);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'HRViewReimDetails.aspx?rid=" + rid + "', null, 'height=600,width=1000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
}