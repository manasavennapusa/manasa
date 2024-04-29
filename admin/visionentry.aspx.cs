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
using DataAccessLayer;
using System.Data.SqlClient;

public partial class intranet_visionentry : System.Web.UI.Page
{

    string sqlstr, file_name;
    DataSet ds;

    //---------------------------------------FORM LOAD BINDING DATA IN GRIDVIEW-----------------------------------------------------
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
            bindgrid();
        }
        message.InnerHtml = "";
    }

    //-------------------------------------CLICKING ON SUBMIT BUTTON TO SAVE RECORDS IN DATABASE-------------------------------------
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       
        bool s = saverecords();
        if (s)
        {
            message.InnerHtml = "Records saved successfully!";
            reset();
        }
        bindgrid();
    }

    //-------------------------------------FUNCTION TO SAVE VALUES IN DATABASE-------------------------------------
    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[5];

            newparameter[0] = new SqlParameter("@mission_vision", SqlDbType.VarChar, 50);
            newparameter[0].Value = ddltype.SelectedItem.Text;

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
            newparameter[1].Value = txtsubject.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@uploadedby", SqlDbType.VarChar, 50);
            newparameter[3].Value = Session["name"].ToString();

            newparameter[4] = new SqlParameter("@uploadeddate", SqlDbType.DateTime);
            newparameter[4].Value = System.DateTime.Now;


            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_visionmission_sp", newparameter);
            return true;
        }
        catch (SqlException sql)
        {
            message.InnerHtml = "Cannot insert dupilicate values or some database error has been occured!";
            return false;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
            return false;
        }
        finally
        {

        }
    }

    //--------------------------------------BINDING GRID----------------------------------------------------------------------------------
    protected void bindgrid()
    {
        sqlstr = "SELECT id,mission_vision,heading,description,uploadedby,uploadeddate FROM tbl_intranet_mission_vission";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        griddetails.DataSource = ds;
        griddetails.DataBind();
    }

    //-----------------------------------------PAGING IN GRID--------------------------------------------------------------------------
    protected void griddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    //----------------------------------------CANCELING IN GRIDVIEW----------------------------------------------------------------------
    protected void griddetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        griddetails.EditIndex = -1;
        bindgrid();
    }

    //-----------------------------------------CHANGING COLOR OF ROW ON MOVING MOUSE---------------------------------------------------
    protected void griddetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        }
    }

    //---------------------------------------DELETING A PARTICULAR RECORDS FROM GRIDVIEW -------------------------------------------------
    protected void griddetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)griddetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_intranet_mission_vission WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    //-----------------------------------CLICKING ON EDIT BUTTON-------------------------------------------------------------------
    protected void griddetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        griddetails.EditIndex = e.NewEditIndex;
        bindgrid();
    }

    //-----------------------------------CLICKING ON UPDATE BUTTON IN GRIDVIEW-------------------------------------------------------
    protected void griddetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = (int)griddetails.DataKeys[e.RowIndex].Value;

        string strname = ((TextBox)griddetails.Rows[e.RowIndex].Cells[0].FindControl("txtgsubject")).Text;

        SqlParameter[] sqlparam = new SqlParameter[2];

        if (strname != "")
        {
            string strtype = ((DropDownList)griddetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
            string strsubject = ((TextBox)griddetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
            string strdescription = ((TextBox)griddetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
            int code = (int)griddetails.DataKeys[e.RowIndex].Value;

            sqlstr = "UPDATE tbl_intranet_mission_vission SET mission_vision='" + strtype + "',heading='" + strsubject + "',description='" + strdescription + "' WHERE id=" + code + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            Response.Redirect("visionentry.aspx");
            //ddlperquistename.DataBind();
            //othrsrcincgird.EditIndex = -1;
            //othrsrcincgird.DataSourceID = "SqlDataSource1";

            //    othrsrcincgird.DataBind();
            //txtothrsrcinc.Text = "";
            //message.InnerHtml = "Other Source Income has been added successfully !";
        }
        else
        {
            string msg = "Please enter Subjet !";
            Page.RegisterStartupScript("vv", "<script> alert('" + msg+ "')</script>");
            message.InnerHtml = "Please enter Subjet !";
            
        }
        //string strtype = ((DropDownList)griddetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        //string strsubject = ((TextBox)griddetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        //string strdescription = ((TextBox)griddetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        //int code = (int)griddetails.DataKeys[e.RowIndex].Value;

        //sqlstr = "UPDATE tbl_intranet_mission_vission SET mission_vision='" + strtype + "',heading='" + strsubject + "',description='" + strdescription + "' WHERE id=" + code + "";
        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //griddetails.EditIndex = -1;
        //bindgrid();
    }

    //------------------------------------CLICKING ON RESET BUTTON-------------------------------------------------------------------------
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }

    //------------------------------------FUNCTION TO RESET CONTROLS VALUE-----------------------------------------------------------
    protected void reset()
    {
        ddltype.SelectedIndex = 0;
        txtsubject.Text = "";
        txtdescription.Text = "";
    }
}
//---------------------------------------END OF PROGRAM-----------------------------------------------------------------------------------