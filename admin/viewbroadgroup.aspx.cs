using DataAccessLayer;
using Smart.HR.Common.Console;
using Smart.HR.Common.Data;
//using Smart.HR.Common.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_viewbroadgroup : System.Web.UI.Page
{

    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        message1.InnerHtml = "";
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
        if (Request.QueryString["updated"] != null)
            SmartHr.Common.Alert("Updated Successfully");
        //  message1.InnerHtml = "Business Unit detail updated successfully";
        bind_broadgroupdetails();
    }

    public void bind_broadgroupdetails()
    {
        int id;
        string sqlstr = "select id,broadgroup_name from tbl_intranet_broadgroup";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString());
            Session["broadgroup_id"] = id.ToString();
        }

        gd_Broadgroup.DataSource = ds;
        gd_Broadgroup.DataBind();

    }
    protected void gd_Broadgroup_PreRender(object sender, EventArgs e)
    {
        if (gd_Broadgroup.Rows.Count > 0)
        {
            gd_Broadgroup.UseAccessibleHeader = true;
            gd_Broadgroup.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void gd_Broadgroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
         try
        {
            //DataActivity.OpenConnection();

            int ChildMenu = (int)gd_Broadgroup.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete tbl_intranet_broadgroup where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Deleted Successfully");
                bind_broadgroupdetails();

            }
            else
            {
                Output.Show("Please select the record...");
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            //DataActivity.CloseConnection();
        }
    }
    }

    

   

