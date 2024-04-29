using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.Web;
using System.IO;
using System.Web.UI;

public partial class Reimbursement_Linemanegerapprove : System.Web.UI.Page
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




    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_grid();
    }



    protected void bind_grid()
    {
        var activity = new DataActivity();


        SqlConnection Connection = null;
        try
        {

            if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 2)
            {
                grdpending1.Visible = false;
               // grdpending1.Visible = false;
                grdpending.Visible = true;
                SqlParameter[] parm = new SqlParameter[5];

                Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
                Output.AssignParameter(parm, 1, "@flag", "Int", 0, "1");
                Output.AssignParameter(parm, 2, "@level", "Int", 0, "1");
                Output.AssignParameter(parm, 3, "@reject", "Int", 0, "0");
                Output.AssignParameter(parm, 4, "@type", "String", 0, "LM");
                Connection = DA.OpenConnection();
                ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "[sp_Rb_get_empreimdetails_Pending]", parm);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdpending.DataSource = ds;
                    grdpending.DataBind();
                   
                    
                }
            }


            else if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 4)
            {
                
                Connection = DA.OpenConnection();

                grdpending.Visible = false;
                //grdpending1.Visible = false;
                grdpending1.Visible = true;
                SqlParameter[] parm = new SqlParameter[5];

                Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
                Output.AssignParameter(parm, 1, "@flag", "Int", 0, "1");
                Output.AssignParameter(parm, 2, "@level", "Int", 0, "1");
                Output.AssignParameter(parm, 3, "@reject", "Int", 0, "0");
                Output.AssignParameter(parm, 4, "@type", "String", 0, "1");
                Connection = DA.OpenConnection();
                DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "[sp_Rb_get_Closedreimbursementdetails]", parm);

                if (ds1.Tables[0].Rows.Count > 0)
                {

                    grdpending1.DataSource = ds1;
                    grdpending1.DataBind();

                }
            }



            //else if (Convert.ToInt32(drp_leavestatus.SelectedValue) == 4)
            //{
            //   // grdpending1.Visible = true;
            //    grdpending.Visible = false;
            //    grdreim.Visible = false;
            //    SqlParameter[] parm = new SqlParameter[4];

            //    Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
            //    Output.AssignParameter(parm, 1, "@flag", "Int", 0, "1");
            //    Output.AssignParameter(parm, 2, "@level", "Int", 0, "4");
            //    Output.AssignParameter(parm, 3, "@reject", "Int", 0, "0");
            //    Connection = DA.OpenConnection();
            //    DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "[sp_Rb_get_Closedreimbursementdetails_emp]", parm);

            //    if (ds2.Tables[0].Rows.Count > 0)
            //    {

            //        grdpending1.DataSource = ds2;
            //        grdpending1.DataBind();

            //    }

            //}





        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }



    protected void reset()
    {
        drp_leavestatus.SelectedIndex = -1;
    }


    protected void grdpending_PreRender(object sender, EventArgs e)
    {
        if (grdpending.Rows.Count > 0)
        {
            grdpending.UseAccessibleHeader = true;
            grdpending.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btnpending_Command(object sender, CommandEventArgs e)
    {
        int rid = Convert.ToInt32(e.CommandArgument);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'PendingClosed.aspx?rid=" + rid + "', null, 'height=600,width=1000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }


    protected void btnview_Command(object sender, CommandEventArgs e)
    {

        int rid = Convert.ToInt32(e.CommandArgument);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'EditEmpReimbursement.aspx?rid=" + rid + "', null, 'height=600,width=1000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


    }
    //protected void grdreim_PreRender(object sender, EventArgs e)
    //{
    //    if (grdreim.Rows.Count > 0)
    //    {
    //        grdreim.UseAccessibleHeader = true;
    //        grdreim.HeaderRow.TableSection = TableRowSection.TableHeader;
    //    }
    //}
    protected void grdpending1_PreRender(object sender, EventArgs e)
    {
        if (grdpending1.Rows.Count > 0)
        {
            grdpending1.UseAccessibleHeader = true;
            grdpending1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}
