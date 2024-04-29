using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
//===============================================================================================================
public partial class Admin_Company_assigngrade : System.Web.UI.Page
{

    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;
    DataSet ds = new DataSet();
    string sqlstr, sqlstr1, str_contry_name1;

    //===============================================================================================================
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
                Response.Redirect("~@otlogged.aspx");
            bindgrade();
        }

        message.InnerHtml = "";
    }

    //==================================================================================================================
    protected void bindgrade()
    {
        sqlstr = "SELECT id,gradename,description,createdby,status,(CASE WHEN createddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), createddate, 106) END) createddate FROM tbl_intranet_grade";
       ds= DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
       grid_hierarchy.DataSource = ds;
       grid_hierarchy.DataBind();
    }

    //===============================================================================================================
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            string createdby = Session["name"].ToString();
            DateTime dateofcreation = DateTime.Now;

            bl_navigation.Insert_Grade(txtgradename.Text, txtgradedescription.Text, createdby, dateofcreation, ref i);
            bindgrade();

            message.InnerHtml = "Records saved successfully!";
        }
        catch (SqlException sql)
        {
            message.InnerHtml = "Values cannot be inserted.";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Your session has been expired. Please login again.";
        }
        finally
        {
        }
    }

    //===============================================================================================================
    protected void brnrs_Click(object sender, EventArgs e)
    {
        reset();
    }

    //===============================================================================================================
    protected void reset()
    {
        txtgradename.Text = "";
        txtgradedescription.Text = "";
        message.InnerHtml = "";
    }

    //===============================================================================================================
    protected void grid_hierarchy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_hierarchy.PageIndex = e.NewPageIndex;
        bindgrade();
    }

    //===============================================================================================================
    protected void grid_hierarchy_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid_hierarchy.EditIndex = -1;
        bindgrade();
    }

    //===============================================================================================================
    protected void grid_hierarchy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)grid_hierarchy.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_intranet_grade WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrade();
    }

    //===============================================================================================================
    protected void grid_hierarchy_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid_hierarchy.EditIndex = e.NewEditIndex;
        bindgrade();
    }

    //===============================================================================================================
    protected void grid_hierarchy_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string gradename = ((TextBox)grid_hierarchy.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        string description = ((TextBox)grid_hierarchy.Rows[e.RowIndex].Cells[1].Controls[1]).Text;

        int code = (int)grid_hierarchy.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE tbl_intranet_grade SET gradename='" + gradename + "',description='" + description + "', createdby='" + Session["name"] + "',createddate='" + DateTime.Now + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grid_hierarchy.EditIndex = -1;
        bindgrade();
    }

    //==========================================================================================================
    protected void grid_hierarchy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        } 
    }
}
//===============================================================================================================