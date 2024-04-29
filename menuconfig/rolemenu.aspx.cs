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

public partial class menuconfig_rolemenu : System.Web.UI.Page
{
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
            
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        GetAssignedMenu();
        GetNotAssignedMenu();
    }
    protected void ValidateDropDown(object sender, ServerValidateEventArgs e)
    {
        if (ddlModule.SelectedValue == "0")
            e.IsValid = false;
        else
            e.IsValid = true;
    }
    private void GetAssignedMenu()
    {
        if (ddlRole.SelectedValue != "0" && ddlModule.SelectedValue != "0")
        {
            DataSet ds = new DataSet();
            if (ddlRole.SelectedValue != "E")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "getassignedmenus", Convert.ToInt32(ddlRole.SelectedValue.Trim()), Convert.ToInt32(ddlModule.SelectedValue.Trim()));
            }
            else
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "getempassignedmenus", Convert.ToInt32(ddlModule.SelectedValue.Trim()));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {

                gvAssignMenu.DataSource = ds;
                gvAssignMenu.DataBind();
                btnDelete.Visible = true;
               
            }
            else
            {

                gvAssignMenu.DataSource = null;
                gvAssignMenu.DataBind();
                btnDelete.Visible = false;
               
            }
        }
        else
        {
            gvAssignMenu.DataSource = null;
            gvAssignMenu.DataBind();
            btnDelete.Visible = false;
           
        }

    }

    private void GetNotAssignedMenu()
    {
        if (ddlRole.SelectedValue != "0" && ddlModule.SelectedValue != "0")
        {
            DataSet ds = new DataSet ();
            if (ddlRole.SelectedValue != "E")
            {
               ds  = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "getnotassignedmenus", Convert.ToInt32(ddlRole.SelectedValue.Trim()), Convert.ToInt32(ddlModule.SelectedValue.Trim()));
            }
            else
            {
                ds  = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "getempnotassignedmenus", Convert.ToInt32(ddlModule.SelectedValue.Trim()));
            }
            if (ds.Tables[0].Rows .Count  > 0)
            {

                gvNotAssignMenu.DataSource = ds;
                gvNotAssignMenu.DataBind();
               
                btnAssign.Visible = true;
            }
            else
            {

                gvNotAssignMenu.DataSource = null;
                gvNotAssignMenu.DataBind();
               
                btnAssign.Visible = false;
            }
        }
        else
        {
            gvNotAssignMenu.DataSource = null;
            gvNotAssignMenu.DataBind();
           
            btnAssign.Visible = false;
        }
    }

    protected void btnAssign_OnClick(object sender, EventArgs e)
    {
        if (gvNotAssignMenu.Rows.Count > 0)
        {
            foreach (GridViewRow row in gvNotAssignMenu.Rows)
            {
                CheckBox chkmenu = (CheckBox)row.FindControl("chkMenu");
                if (chkmenu.Checked == true)
                {
                    Label lblmenuCode = (Label)row.FindControl("lblMenuCode");

                    if (ddlRole.SelectedValue != "E")
                    {
                        if (DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "assignmenutorole", Convert.ToInt32(ddlRole.SelectedValue.Trim()), Convert.ToInt32(lblmenuCode.Text.Trim()), Session["empcode"].ToString().Trim()) > 0)
                        {

                        }
                    }
                    else
                    {
                        if (DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "assignmenutorole", Convert.ToInt32(lblmenuCode.Text.Trim()), Session["empcode"].ToString().Trim()) > 0)
                        {

                        }
                    }
                }
            }

            GetAssignedMenu();
            GetNotAssignedMenu();
        }

    }

    protected void btnDelete_OnClick(object sender, EventArgs e)
    {
        if (gvAssignMenu.Rows.Count > 0)
        {
            foreach (GridViewRow row in gvAssignMenu.Rows)
            {
                CheckBox chkmenu = (CheckBox)row.FindControl("chkMenu");
                if (chkmenu.Checked == true)
                {
                    Label lblslNo = (Label)row.FindControl("lblSlNo");

                    if (ddlRole.SelectedValue != "E")
                    {
                        if (DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "deleteassignmenutorole", Convert.ToInt32(lblslNo.Text.Trim())) > 0)
                        {

                        }
                    }
                    else
                    {
                        if (DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, "deleteempassignmenutorole", Convert.ToInt32(lblslNo.Text.Trim())) > 0)
                        {

                        }
                    }
                }
            }

            GetAssignedMenu();
            GetNotAssignedMenu();
        }
    }

    protected void gvAssignMenu_PreRender(object sender, EventArgs e)
    {
        if (gvAssignMenu.Rows.Count > 0)
        {
            gvAssignMenu.UseAccessibleHeader = true;
            gvAssignMenu.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void gvNotAssignMenu_PreRender(object sender, EventArgs e)
    {
        if (gvNotAssignMenu.Rows.Count > 0)
        {
            gvNotAssignMenu.UseAccessibleHeader = true;
            gvNotAssignMenu.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ddlRole.SelectedValue = "0";
        ddlModule.SelectedValue = "0";
    }
    protected void empgrid1_chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)gvAssignMenu.HeaderRow.FindControl("empgrid1_chkSelectAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in gvAssignMenu.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkMenu");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in gvAssignMenu.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkMenu");
                chkselect.Checked = false;
            }
        }
    }
    protected void empgrid2_chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)gvNotAssignMenu.HeaderRow.FindControl("empgrid2_chkSelectAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in gvNotAssignMenu.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkMenu");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in gvNotAssignMenu.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkMenu");
                chkselect.Checked = false;
            }
        }
    }
}
