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

public partial class menuconfig_parentmenu : System.Web.UI.Page
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
            GetParentMenu("0");
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
        gvParentMenu.RowEditing += new GridViewEditEventHandler(gvParentMenu_RowEditing);
        gvParentMenu.RowCancelingEdit += new GridViewCancelEditEventHandler(gvParentMenu_RowCancelingEdit);
        gvParentMenu.RowUpdating += new GridViewUpdateEventHandler(gvParentMenu_RowUpdating);
        gvParentMenu.RowDeleting += new GridViewDeleteEventHandler(gvParentMenu_RowDeleting);
    }

    void gvParentMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int ParentMenu = (int)gvParentMenu.DataKeys[(int)e.RowIndex].Value;
        TextBox txtparentmenuName = (TextBox)gvParentMenu.Rows[(int)e.RowIndex].FindControl("txtEditParentMenuName");
        TextBox txtorder = (TextBox)gvParentMenu.Rows[(int)e.RowIndex].FindControl("txtEditParentorder");
        if (txtparentmenuName.Text != "")
        {
            if (SaveParentMenu(ParentMenu, txtparentmenuName.Text.Trim(), 0, Session["empcode"].ToString().Trim(), "Update", txtorder.Text.Trim()))
            {

                gvParentMenu.EditIndex = -1;
                GetParentMenu(ddlModule.SelectedValue.Trim());
                SmartHr.Common.Alert("Updated Successfully");
            }
            else
            {
                SmartHr.Common.Alert("Parent Menu updation failed");
            }
        }
        else
        {
            SmartHr.Common.Alert("Please enter menu name");
        }

    }

    void gvParentMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvParentMenu.EditIndex = -1;
        GetParentMenu(ddlModule.SelectedValue.Trim());
    }

    void gvParentMenu_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvParentMenu.EditIndex = e.NewEditIndex;
        GetParentMenu(ddlModule.SelectedValue.Trim());
    }

    void gvParentMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int menucode = (int)gvParentMenu.DataKeys[(int)e.RowIndex].Value;
        string Query=@"select rolecode  from  rolemenu rm
        INNER JOIN  menumaster mm on rm.menucode=mm.menucode
        INNER JOIN  module m on mm.modulecode=m.modulecode
        where mm.menucode=" + menucode + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, Query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            SmartHr.Common.Alert("Parent Menu Already Assigned");
           
        }
        else
        {
            string Query1 = "Delete  from menumaster where pmenucode=" + menucode;
            string Query2 = "Delete from menumaster where menucode=" + menucode;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, Query1);
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, Query2);
            GetParentMenu(ddlModule.SelectedValue.Trim());
        }
    }
    #endregion

    private void GetParentMenu(string moduleCode)
    {
        string Query = @"select menucode,menudesc ,modulename ,menu_order
        from menumaster N,module M
        where N.modulecode=M.modulecode and
        pmenucode is null and N.modulecode = " + moduleCode + "";


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, Query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvParentMenu.DataSource = ds.Tables[0];
            gvParentMenu.DataBind();
        }
        else
        {
            gvParentMenu.DataSource = null;
            gvParentMenu.DataBind();
        }
    }

    protected void ValidateDropDown(object sender, ServerValidateEventArgs e)
    {
        if (ddlModule.SelectedValue == "0")
            e.IsValid = false;
        else
            e.IsValid = true;
    }

    protected void btnsv_Click(object sender, EventArgs e)
    {
        if (txtParentMenu.Value != "" && ddlModule.SelectedValue != "0")
        {
            if (SaveParentMenu(0, txtParentMenu.Value.Trim(), Convert.ToInt32(ddlModule.SelectedValue.Trim()), Session["empcode"].ToString().Trim(), "Insert", txtParentorder.Value))
            {
                GetParentMenu(ddlModule.SelectedValue.Trim());
                txtParentMenu.Value = "";

                SmartHr.Common.Alert("Created Successfully");

            }
            else
                SmartHr.Common.Alert("Parent menu not saved.");
        }
        else
            SmartHr.Common.Alert("Please select mandatory fields");

    }


    public static bool SaveParentMenu(int ParentMenuCode, string ParentMenuName, int ModuleCode, string EmpCode, string action, string menuorder)
    {
        try
        {
            int Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "saveparentmenu", ParentMenuCode, ParentMenuName, ModuleCode, EmpCode, action,menuorder);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void gvParentMenu_PreRender(object sender, EventArgs e)
    {
        if (gvParentMenu.Rows.Count > 0)
        {
            gvParentMenu.UseAccessibleHeader = true;
            gvParentMenu.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetParentMenu(ddlModule.SelectedValue.Trim());
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        Cancel();
    }

    private void Cancel()
    {
        ddlModule.SelectedValue = "0";
        txtParentMenu.Value = "";
        txtParentorder.Value = "";
    }
}
