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

public partial class menuconfig_childmenu : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            GetChildMenu();
        }
    }

    #region
    protected override void OnInit(EventArgs e)
    {
        InitializeComponents();
        base.OnInit(e);
    }

    private void InitializeComponents()
    {
        gvChildMenu.RowEditing += new GridViewEditEventHandler(gvChildMenu_RowEditing);
        gvChildMenu.RowCancelingEdit += new GridViewCancelEditEventHandler(gvChildMenu_RowCancelingEdit);
        gvChildMenu.RowUpdating += new GridViewUpdateEventHandler(gvChildMenu_RowUpdating);
        gvChildMenu.RowDeleting += new GridViewDeleteEventHandler(gvChildMenu_RowDeleting);
    }

    void gvChildMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int ChildMenu = (int)gvChildMenu.DataKeys[(int)e.RowIndex].Value;
        TextBox txtchildmenuName = (TextBox)gvChildMenu.Rows[(int)e.RowIndex].FindControl("txtEditChildMenuName");
        TextBox txtfilePath = (TextBox)gvChildMenu.Rows[(int)e.RowIndex].FindControl("txtEditFilePath");
        TextBox txtchildmenuorder = (TextBox)gvChildMenu.Rows[(int)e.RowIndex].FindControl("txtEditOrder");

        if (txtchildmenuName.Text != "" && txtfilePath.Text != "")
        {

            Convert.ToInt32(ddlParentMenu.SelectedValue.Trim());

            if (SaveChildMenu(Convert.ToInt32(ddlParentMenu.SelectedValue), ChildMenu, txtchildmenuName.Text.Trim(), txtfilePath.Text.Trim(), Convert.ToInt32(ddlModule.SelectedValue.Trim()), Session["empcode"].ToString().Trim(), "Update", txtchildmenuorder.Text.Trim()))
            {

               // ddlParentMenu.SelectedValue = "0";
                txtChildMenu.Value = "";
                txtFileName.Value = "";
              //  ddlModule.SelectedValue = "0";
                gvChildMenu.EditIndex = -1;
                GetChildMenu();
                SmartHr.Common.Alert("Updated Successfully");
            }
            else
            {
                SmartHr.Common.Alert("Record updated failed.");
            }
        }
        else
        {
            SmartHr.Common.Alert("Some of the fields need corrections.");
        }

    }

    void gvChildMenu_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvChildMenu.EditIndex = e.NewEditIndex;
        GetChildMenu();
    }

    void gvChildMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvChildMenu.EditIndex = -1;
        GetChildMenu();
    }
    void gvChildMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ChildMenu = (int)gvChildMenu.DataKeys[(int)e.RowIndex].Value;
        string sqlroleid = "Select rolecode from rolemenu where menucode=" + ChildMenu;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlroleid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            SmartHr.Common.Alert("Parent Menu Already Assigned");
          
        }
        else
        {
            string sqlchildmenu = "Delete  from menumaster where menucode=" + ChildMenu;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
            GetChildMenu();
        }
    }
    #endregion

    private void GetChildMenu()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "getchildmenu", Convert.ToInt32(ddlParentMenu.SelectedValue));
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvChildMenu.DataSource = ds.Tables[0];
            gvChildMenu.DataBind();
        }
        else
        {
            gvChildMenu.DataSource = null;
            gvChildMenu.DataBind();
        }
    }

    protected void ValidateDropDown(object sender, ServerValidateEventArgs e)
    {
        if (ddlModule.SelectedValue == "0")
            e.IsValid = false;
        else
            e.IsValid = true;
    }

    protected void ddlParentMenu_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        txtChildMenu.Value = "";
        txtFileName.Value = "";
        ddlModule.SelectedValue = "0";
        GetChildMenu();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlParentMenu.SelectedValue != "0" && txtChildMenu.Value != "" && txtFileName.Value.Trim() != "" && ddlModule.SelectedValue != "0")
        {
            if (SaveChildMenu(Convert.ToInt32(ddlParentMenu.SelectedValue), 0, txtChildMenu.Value.Trim(), txtFileName.Value.Trim(), Convert.ToInt32(ddlModule.SelectedValue.Trim()), Session["empcode"].ToString().Trim(), "Insert", txtchildmenuorder.Value.Trim()))
            {
                GetChildMenu();
                txtChildMenu.Value = "";
                txtFileName.Value = "";
                ddlModule.SelectedValue = "0";
                SmartHr.Common.Alert("Created Successfully");

            }
            else
                SmartHr.Common.Alert("Child menu not saved.");
        }
        else
            SmartHr.Common.Alert("Please select mandatory fields");
    }

    public static bool SaveChildMenu(int ParentMenuCode, int ChildMenuCode, string ChildMenuName, string FilePath, int ModuleCode, string EmpCode, string action, string menuorder)
    {
        try
        {
            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "savechildmenu", ParentMenuCode, ChildMenuCode, ChildMenuName, FilePath, ModuleCode, EmpCode, action,menuorder);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void gvChildMenu_PreRender(object sender, EventArgs e)
    {
        if (gvChildMenu.Rows.Count > 0)
        {
            gvChildMenu.UseAccessibleHeader = true;
            gvChildMenu.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    private void cancel()
    {
        txtChildMenu.Value = "";
        txtFileName.Value = "";
        ddlModule.SelectedValue = "0";
        ddlParentMenu.SelectedValue = "0";
        txtchildmenuorder.Value = "";
    }
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        cancel();
    }
}
