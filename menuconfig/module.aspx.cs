using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DataAccessLayer;
using Common.Console;

public partial class menuconfig_module : System.Web.UI.Page
{
    string modulecode;
    protected void Page_Load(object sender, EventArgs e)
    {
        // message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                modulecode = Session["modulecode"].ToString();
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }

        if (Request.QueryString["update"] == "true")
        {
            Output.Show("Module Already Assigned");
        }
    }

    //#region
    //protected override void OnInit(EventArgs e)
    //{
    //    InitializeComponents();
    //    base.OnInit(e);
    //}

    //private void InitializeComponents()
    //{
    //    Grid_Emp.RowEditing += new GridViewEditEventHandler(Grid_Emp_RowEditing);
    //    Grid_Emp.RowCancelingEdit += new GridViewCancelEditEventHandler(Grid_Emp_RowCancelingEdit);
    //    Grid_Emp.RowUpdating += new GridViewUpdateEventHandler(Grid_Emp_RowUpdating);
    //}

    //void gvChildMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    int ChildMenu = (int)gvChildMenu.DataKeys[(int)e.RowIndex].Value;
    //    TextBox txtchildmenuName = (TextBox)gvChildMenu.Rows[(int)e.RowIndex].FindControl("txtEditChildMenuName");
    //    TextBox txtfilePath = (TextBox)gvChildMenu.Rows[(int)e.RowIndex].FindControl("txtEditFilePath");

    //    if (txtchildmenuName.Text != "" && txtfilePath.Text != "")
    //    {

    //        Convert.ToInt32(ddlParentMenu.SelectedValue.Trim());

    //        if (SaveChildMenu(Convert.ToInt32(ddlParentMenu.SelectedValue), ChildMenu, txtchildmenuName.Text.Trim(), txtfilePath.Text.Trim(), Convert.ToInt32(ddlModule.SelectedValue.Trim()), Session["empcode"].ToString().Trim(), "Update"))
    //        {

    //            ddlParentMenu.SelectedValue = "0";
    //            txtChildMenu.Value = "";
    //            txtFileName.Value = "";
    //            ddlModule.SelectedValue = "0";
    //            gvChildMenu.EditIndex = -1;
    //            GetChildMenu();
    //            SmartHr.Common.Alert("Record updated successfully.");
    //        }
    //        else
    //        {
    //            SmartHr.Common.Alert("Record updated failed.");
    //        }
    //    }
    //    else
    //    {
    //        SmartHr.Common.Alert("Some of the fields need corrections.");
    //    }

    //}

    //void gvChildMenu_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvChildMenu.EditIndex = e.NewEditIndex;
    //    GetChildMenu();
    //}

    //void gvChildMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    Grid_Emp.EditIndex = -1;
    //    GetChildMenu();
    //}
    //#endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtModule.Value != "")
        {
            if (SaveModuleDetails(0, txtModule.Value.Trim(), Session["empcode"].ToString().Trim(), "Insert", txtorder.Value.Trim()))
            {
                txtModule.Value = "";
                txtorder.Value = "";
                Grid_Emp.DataSourceID = "SqlDataSource1";
                Common.Console.Output.Show("Created Successfully");
            }
            else
                Common.Console.Output.Show("Module not saved.");
        }
        else
        {
            SmartHr.Common.Alert("Please enter module name");
        }
    }

    private bool SaveModuleDetails(int ModuleCode,string ModuleName,string EmpCode,string action, string moduleorder)
    {     
        try
        {
            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "savemoduledetails", ModuleCode, ModuleName, EmpCode, action,moduleorder);            
            return true;
        }
        catch 
        {
            return false;
        }
    }

   
    
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {        
        Grid_Emp.UseAccessibleHeader = true;
        Grid_Emp.HeaderRow.TableSection = TableRowSection.TableHeader;
    
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        cancel();
    }

    private void cancel()
    {
        txtModule.Value="";
        txtorder.Value="";
    }

    protected void Grid_Emp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ChildMenu = (int)Grid_Emp.DataKeys[(int)e.RowIndex].Value;
        string sqlroleid = "Select modulename from module where modulecode=" + ChildMenu;
       DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlroleid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //Common.Console.Output.Show("Already assigned to relevant role please contact system admin");   
            Response.Redirect("module.aspx?update=true");                 

        }
        else
        {
            string sqlchildmenu = "Delete  from module where modulecode=" + ChildMenu;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
         
        }

    }
}
