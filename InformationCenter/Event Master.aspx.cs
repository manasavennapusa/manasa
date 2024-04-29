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

public partial class InformationCenter_Event_Master : System.Web.UI.Page
{

    string sqlstr;
    string _companyId, _userCode, RoleId;
    DataSet ds;
    //========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Request.QueryString["update"] == "true")
                {
                    Output.Show("Updated Sucessfully");
                }

            }
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }
            // bindcategory();
            bindgrid();
        }
        //message.InnerHtml = "";
    }
    //===========================================is used to add category dynamically =============================================================================================
    //protected void bindcategory()
    //{
    //    string categoryname;
    //    //-----Add the Category in the drop down list Box-------------------------------
    //    ddlcategory.Items.Add(new ListItem("---Select Category---"));

    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "select_category_sp");

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow row1 in ds.Tables[0].Rows)
    //        {
    //            categoryname = row1["categoryname"].ToString().Trim();

    //            ddlcategory.Items.Add(new ListItem(Convert.ToString(categoryname)));
    //        }
    //    }
    //}
    //========================================================================================================================================
    protected void bindgrid()
    {
       // sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate FROM COMPANY_EVENTS ORDER BY posteddate desc,category";
        sqlstr = "select id,heading,description,postedby,posteddate,run_status,priority,category,eventdate from COMPANY_EVENTS";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        eventsdetails.DataSource = ds;
        eventsdetails.DataBind();
    }
    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool s = saverecords();
        if (s != true)
        {
            Output.Show("Created Successfully");
            Clear();
            //message.InnerHtml = "Record has been saved successfully!";
        }
        else
        {
            Clear();
            lblhead.Text = "Create";
            btnsubmit.Text = "Submit";
            Response.Redirect("Event Master.aspx?update=true");
        }
        bindgrid();
        // reset();
    }

    private void Clear()
    {
        txt_edate.Text = "";
        ddlcategory.SelectedValue = "0";
        txtheading.Text = "";
        txtdescription.Text = "";
        ddlrunstatusg.SelectedValue = "0";
        ddlpriorityg.SelectedValue = "0";
    }

    //========================SAVING RECORDS===============================================================
    protected bool saverecords()
    {
        try
        {
             if (Convert.ToInt32(ViewState["flagedit"]) != 1)
            {

            SqlParameter[] newparameter = new SqlParameter[7];

            newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
            newparameter[0].Value = ddlcategory.SelectedValue;

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
            newparameter[1].Value = txtheading.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
            newparameter[3].Value = ddlrunstatusg.SelectedValue;

            newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
            newparameter[4].Value = ddlpriorityg.SelectedValue;

            newparameter[5] = new SqlParameter("@eventdate", SqlDbType.Date);
            newparameter[5].Value = txt_edate.Text;

            newparameter[6] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
            newparameter[6].Value = _userCode.ToString();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_events_sp", newparameter);
            return false;
        }
              if (Convert.ToInt32(ViewState["flagedit"]) == 1)
            {
                SqlParameter[] newparameter = new SqlParameter[8];

                newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
                newparameter[0].Value = ddlcategory.SelectedValue;

                newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
                newparameter[1].Value = txtheading.Text.Trim().ToString();

                newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
                newparameter[2].Value = txtdescription.Text.Trim().ToString();

                newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
                newparameter[3].Value = ddlrunstatusg.SelectedValue;

                newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
                newparameter[4].Value = ddlpriorityg.SelectedValue;


                newparameter[5] = new SqlParameter("@eventdate", SqlDbType.Date);
                newparameter[5].Value = txt_edate.Text;

                newparameter[6] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
                newparameter[6].Value = _userCode.ToString();

                newparameter[7] = new SqlParameter("@id", SqlDbType.Int);
                newparameter[7].Value = ViewState["id"].ToString();

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_update_events_sp", newparameter);
                return true;
            }
            return true;
        }
        catch (SqlException sql)
        {
            Output.Show("Cannot insert duplicate values or some database error has been occured");
           // message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
            return false;
        }
        catch (Exception ex)
        {
            //message.InnerHtml = ex.Message;
            return false;
        }
        finally
        {

        }
    }

    //========================================================================================================================================
    protected void btnclear_Click(object sender, EventArgs e)
    {
        reset();
    }
    //========================================================================================================================================
    protected void reset()
    {                     
        txt_edate.Text = "";
        ddlcategory.SelectedValue = "0";
        txtheading.Text = "";
        txtdescription.Text = "";
        ddlrunstatusg.SelectedValue = "0";
        ddlpriorityg.SelectedValue = "0";
        Response.Redirect("Event Master.aspx");
    }
    //========================================================================================================================================
    protected void eventsdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        eventsdetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void eventsdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        eventsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================
    protected void eventsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
        //    e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        //}
    }
    //========================================================================================================================================
    protected void eventsdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)eventsdetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM COMPANY_EVENTS WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
        Output.Show("Deleted Sucessfully");
    }

    //========================================================================================================================================
    protected void eventsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.Visible = false;
        int id;
        lblhead.Text = "Edit";
        btnsubmit.Text = "Update";
        btnreset.Text = "Cancel";
        ViewState["flagedit"] = 1; //FOR EDITING RECORDS

        id = (int)eventsdetails.DataKeys[e.NewEditIndex].Value;
        ViewState["id"] = id;

        sqlstr = " select heading,description,postedby,posteddate,run_status,priority,category,CONVERT(varchar(11), eventdate, 101)as eventdate from COMPANY_EVENTS WHERE id='" + id + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["category"].ToString();
        ddlrunstatusg.SelectedValue = ds.Tables[0].Rows[0]["run_status"].ToString();
        ddlpriorityg.SelectedValue = ds.Tables[0].Rows[0]["priority"].ToString();
        txtheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
        txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
        txt_edate.Text = ds.Tables[0].Rows[0]["eventdate"].ToString();

        //eventsdetails.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void eventsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //int id = (int)eventsdetails.DataKeys[e.RowIndex].Value;

        //string strname = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[0].FindControl("txtheadingg")).Text;

        //// SqlParameter[] sqlparam = new SqlParameter[6];

        //if (strname != "")
        //{
        //    string strcategory = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).SelectedValue;
        //    string strheading = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        //    string strdescription = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        //    string strrunstatus = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        //    string strpriority = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
        //    int code = (int)eventsdetails.DataKeys[e.RowIndex].Value;


        //    sqlstr = "UPDATE COMPANY_EVENTS SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);


         
            //ddlperquistename.DataBind();
            //othrsrcincgird.EditIndex = -1;
            //othrsrcincgird.DataSourceID = "SqlDataSource1";

            //    othrsrcincgird.DataBind();
            //txtothrsrcinc.Text = "";
            //message.InnerHtml = "Other Source Income has been added successfully !";
        //}
        //else
        //{
        //    string msg = "Please enter Heading !";
        //    Page.RegisterStartupScript("vv", "<script> alert('" + msg + "')</script>");
        //    message.InnerHtml = "Please enter Heading !";

        //}

        //string strcategory = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        //string strheading = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        //string strdescription = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        //string strrunstatus = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        //string strpriority = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
        //int code = (int)eventsdetails.DataKeys[e.RowIndex].Value;

        //sqlstr = "UPDATE COMPANY_EVENTS SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //eventsdetails.EditIndex = -1;
        //bindgrid();
    }
    //==================== 

}