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

public partial class intranet_eventsmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    //========================================================================================================================================
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
            bindcategory();
            bindgrid();
        }
        message.InnerHtml = "";
    }
    //========================================================================================================================================
    protected void bindcategory()
    {
        string categoryname;
        //-----Add the Category in the drop down list Box-------------------------------
        ddlcategory.Items.Add(new ListItem("---Select Category---"));

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "select_category_sp");

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                categoryname = row1["categoryname"].ToString().Trim();

                ddlcategory.Items.Add(new ListItem(Convert.ToString(categoryname)));
            }
        }
    }
    //========================================================================================================================================
    protected void bindgrid()
    {
        sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate FROM COMPANY_EVENTS ORDER BY posteddate desc,category";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        eventsdetails.DataSource = ds;
        eventsdetails.DataBind();
    }
    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool s = saverecords();
        if (s)
        {
            message.InnerHtml = "Record has been saved successfully!";
        }
        bindgrid();
        reset();
    }

    //========================SAVING RECORDS===============================================================
    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[6];

            newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
            newparameter[0].Value = ddlcategory.SelectedItem.Text;

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 50);
            newparameter[1].Value = txtheading.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 50);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
            newparameter[3].Value = 0;

            newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
            newparameter[4].Value = 0;

            newparameter[5] = new SqlParameter("@eventdate", SqlDbType.DateTime);
            newparameter[5].Value = txt_edate.Text;

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_events_sp", newparameter);
            return true;
        }
        catch (SqlException sql)
        {
            message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
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

    //========================================================================================================================================
    protected void btnclear_Click(object sender, EventArgs e)
    {
        reset();
    }
    //========================================================================================================================================
    protected void reset()
    {
        ddlcategory.SelectedIndex = 0;
        txtheading.Text = "";
        txtdescription.Text = "";
        txt_edate.Text = "";
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
    }

    //========================================================================================================================================
    protected void eventsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        eventsdetails.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void eventsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int id = (int)eventsdetails.DataKeys[e.RowIndex].Value;

        string strname = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[0].FindControl("txtheadingg")).Text;

        SqlParameter[] sqlparam = new SqlParameter[2];

        if (strname != "")
        {
            string strcategory = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
            string strheading = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
            string strdescription = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
            string strrunstatus = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
            string strpriority = ((DropDownList)eventsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
            int code = (int)eventsdetails.DataKeys[e.RowIndex].Value;


            sqlstr = "UPDATE COMPANY_EVENTS SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);


            Response.Redirect("eventsmaster.aspx");
            //ddlperquistename.DataBind();
            //othrsrcincgird.EditIndex = -1;
            //othrsrcincgird.DataSourceID = "SqlDataSource1";

            //    othrsrcincgird.DataBind();
            //txtothrsrcinc.Text = "";
            //message.InnerHtml = "Other Source Income has been added successfully !";
        }
        else
        {
            string msg = "Please enter Heading !";
            Page.RegisterStartupScript("vv", "<script> alert('" + msg + "')</script>");
            message.InnerHtml = "Please enter Heading !";

        }

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
    //========================================================================================================================================   
}
//========================================================================================================================================

