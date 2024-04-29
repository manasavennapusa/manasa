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
using Common.Console;

public partial class InformationCenter_Financial : System.Web.UI.Page
{
    string sqlstr, file_name;
    string _companyId, _userCode, RoleId;
    DataSet ds;

    //---------------------------------------FORM LOAD BINDING DATA IN GRIDVIEW-----------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();

        if (!IsPostBack)
        {
            if (Request.QueryString["update"] == "true")
            {
                Output.Show("Updated Sucessfully");
            }

            if (Session["role"] != null)
            {

            }

            else
            {
                Response.Redirect("~/notlogged.aspx");
            }

            bindgrid();
        }
       
     
       // message.InnerHtml = "";
    }

    //-------------------------------------CLICKING ON SUBMIT BUTTON TO SAVE RECORDS IN DATABASE-------------------------------------
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        bool s = saverecords();
        if (s!=true)
        {
            Output.Show("Created successfully");
            //message.InnerHtml = "Record has been saved successfully!";
            //reset();
            Clear();
        }
        else
        {
            //reset();
            Clear();
            lblhead.Text = "Create";
            btnsubmit.Text = "Submit";
            Response.Redirect("Financial.aspx?update=true");
        }
        bindgrid();
    }

    private void Clear()
    {
        txtsubject.Text = "";
        txtdescription.Text = "";
    }

    //-------------------------------------FUNCTION TO SAVE VALUES IN DATABASE-------------------------------------
    protected bool saverecords()
    {
        try
        {
            if (Convert.ToInt32(ViewState["flagedit"]) != 1)
            {
            SqlParameter[] newparameter = new SqlParameter[4];

            newparameter[0] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
            newparameter[0].Value = txtsubject.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[1].Value = txtdescription.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
            newparameter[2].Value = _userCode.ToString();

            newparameter[3] = new SqlParameter("@posteddate", SqlDbType.DateTime);
            newparameter[3].Value = System.DateTime.Now;

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_financial_sp", newparameter);
            return false;

            }

            if (Convert.ToInt32(ViewState["flagedit"]) == 1)
            {

                SqlParameter[] newparameter = new SqlParameter[5];

                newparameter[0] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
                newparameter[0].Value = txtsubject.Text.Trim().ToString();

                newparameter[1] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
                newparameter[1].Value = txtdescription.Text.Trim().ToString();

                newparameter[2] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
                newparameter[2].Value = _userCode.ToString();

                newparameter[3] = new SqlParameter("@posteddate", SqlDbType.DateTime);
                newparameter[3].Value = System.DateTime.Now;

                newparameter[4] = new SqlParameter("@id", SqlDbType.Int);
                newparameter[4].Value = ViewState["id"].ToString();

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_upate_financial_sp", newparameter);
                return true;
            }
            return true;

        }
        catch (SqlException sql)
        {
            Output.Show("Cannot insert duplicate values or some database error has been occured!");
            //message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
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
        sqlstr = "SELECT id,heading,description,postedby,posteddate FROM tbl_intranet_financial ORDER BY posteddate desc";
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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
        //    e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        //}
    }

    //---------------------------------------DELETING A PARTICULAR RECORDS FROM GRIDVIEW -------------------------------------------------
    protected void griddetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)griddetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_intranet_financial WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    //-----------------------------------CLICKING ON EDIT BUTTON-------------------------------------------------------------------
    protected void griddetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
       // griddetails.EditIndex = e.NewEditIndex; 
        grid.Visible = false;
        int id;
        lblhead.Text = "Edit";
        btnsubmit.Text = "Update";
        btnreset.Text = "Cancel";
        ViewState["flagedit"] = 1; //FOR EDITING RECORDS

        id = (int)griddetails.DataKeys[e.NewEditIndex].Value;
        ViewState["id"] = id;

        sqlstr = "select id,heading,description,posteddate,postedby from tbl_intranet_financial  WHERE id='" + id + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //ddltype.SelectedValue = ds.Tables[0].Rows[0]["type"].ToString();
        txtsubject.Text = ds.Tables[0].Rows[0]["heading"].ToString();
        txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();       
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
            string strsubject = ((TextBox)griddetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
            string strdescription = ((TextBox)griddetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
            int code = (int)griddetails.DataKeys[e.RowIndex].Value;


            sqlstr = "UPDATE tbl_intranet_financial SET heading='" + strsubject + "',description='" + strdescription + "' WHERE id=" + code + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);


            Response.Redirect("Financial.aspx");
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
            Page.RegisterStartupScript("vv", "<script> alert('" + msg + "')</script>");
            message.InnerHtml = "Please enter Heading!";

        }
        //string strsubject = ((TextBox)griddetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        //string strdescription = ((TextBox)griddetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        //int code = (int)griddetails.DataKeys[e.RowIndex].Value;

        //sqlstr = "UPDATE tbl_intranet_financial SET heading='" + strsubject + "',description='" + strdescription + "' WHERE id=" + code + "";
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
        txtsubject.Text = "";
        txtdescription.Text = "";
        Response.Redirect("Financial.aspx");
    }
}