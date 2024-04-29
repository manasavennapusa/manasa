using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using Smart.HR.Common.Data;
using System.Data.SqlClient;

public partial class Exit_EmpResignationStatus : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 1;    // Resignation
    int ApplicationId = 1;
    string PageId = "Employee";
    DataActivity DA = new DataActivity();
    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitEmployeeRule EmpRule = null;
    ExitCompanyRule CompanyRule = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                drp_exitstatus.SelectedIndex = 0;
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

        if (Request.QueryString["msg"] != null)
        {
            if (Request.QueryString["msg"].ToString().Trim() == "True")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", Smart.HR.Common.Console.Output.Message("Resignation request has been submitted successfully.")); 
            }
        }
    }

    //private void BindDetails()
    //{
    //    Lib = new Base();
    //    // Application Type and Work Flow Type
    //    // Pending - Status = 1 and Resign Status = U
    //    Query = "select * from tbl_exit_Resignation where ApplicationId=" + ApplicationId + " and WorkFlowTypeId = " + WorkFlowTypeId + " and Status = 1 and ResignStatus in ('U') and EmpCode = '" + UserCode + "'";
    //    Lib.Bee.WBindGrid(Query, Grid);


    //    // Cancelled - Status = 0 and Resign Status = C
    //    // Rejected - Status = 0 and Resign Status = J
    //    // Freezed - Status = 1 and Resign Status = F
    //    // Re-Initiate - Make Status = 0 and Resign Status = R for the previous record and insert new record with the same values except, Status = 1 and Resign Status = U
    //}



    protected void Grid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        int Id = (int)Grid.DataKeys[(int)e.NewEditIndex].Value;
        Server.Transfer("ViewResignationDetails.aspx?ResignId=" + Id + "");
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_grid();
    }

    protected void bind_grid()
    {
      
            if (Convert.ToInt32(drp_exitstatus.SelectedValue)==1)
            {
                //grdreim.Visible = false;
                //grdpending1.Visible = false;
                //grdpending.Visible = true;
                //SqlParameter[] parm = new SqlParameter[4];

                //Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
                //Output.AssignParameter(parm, 1, "@flag", "Int", 0, "1");
                //Output.AssignParameter(parm, 2, "@level", "Int", 0, "1");
                //Output.AssignParameter(parm, 3, "@reject", "Int", 0, "0");

                //Connection = DA.OpenConnection();
                //ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "[sp_Rb_get_empreimdetails_Pending_emp]", parm);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    grdpending.DataSource = ds;
                //    grdpending.DataBind();

                //}
                Lib = new Base();
                Query = "select * from tbl_exit_Resignation where ApplicationId=" + ApplicationId + " and WorkFlowTypeId = " + WorkFlowTypeId + " and Status = 1 and ResignStatus in ('U') and EmpCode = '" + UserCode + "'";
                Lib.Bee.WBindGrid(Query, Grid);
            }


            else if (Convert.ToInt32(drp_exitstatus.SelectedValue) == 2)
            {

                //grdpending.Visible = false;
                //grdpending1.Visible = false;
                //grdreim.Visible = true;
                //SqlParameter[] parm = new SqlParameter[4];

                //Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
                //Output.AssignParameter(parm, 1, "@flag", "Int", 0, "1");
                //Output.AssignParameter(parm, 2, "@level", "Int", 0, "0");
                //Output.AssignParameter(parm, 3, "@reject", "Int", 0, "1");
                //Connection = DA.OpenConnection();
                //DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "[sp_Rb_get_empreimdetails_reject]", parm);

                //if (ds1.Tables[0].Rows.Count > 0)
                //{

                //    grdreim.DataSource = ds1;
                //    grdreim.DataBind();

                //}

                Lib = new Base();
                // Application Type and Work Flow Type
                // Pending - Status = 1 and Resign Status = U
                Query = "select * from tbl_exit_Resignation where ApplicationId=" + ApplicationId + " and WorkFlowTypeId = " + WorkFlowTypeId + " and ResignStatus in ('F') and EmpCode = '" + UserCode + "' and Status = 1";
                Lib.Bee.WBindGrid(Query, Grid);
            }



            else if (Convert.ToInt32(drp_exitstatus.SelectedValue) == 3)
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


                Lib = new Base();
                // Application Type and Work Flow Type
                // Pending - Status = 1 and Resign Status = U
                Query = "select * from tbl_exit_Resignation where ApplicationId=" + ApplicationId + " and WorkFlowTypeId = " + WorkFlowTypeId + " and ResignStatus in ('C','J') and EmpCode = '" + UserCode + "'";
                Lib.Bee.WBindGrid(Query, Grid);

            }

        }
        

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
      drp_exitstatus.SelectedIndex = -1;
    }
}