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

public partial class InformationCenter_Achievement_Master : System.Web.UI.Page
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
                Response.Redirect("~/notlogged.aspx");
            //bindcategory();
            bindgrid();
        }
      //  message.InnerHtml = "";
    }
    //========================================================================================================================================
    //protected void bindcategory()
    //{
    //    string categoryname;
    //    ////-----Add the Category in the drop down list Box-------------------------------
    //    ddlcategory.Items.Add(new ListItem("---Select Category---", "0"));

    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "select_category_sp");

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow row1 in ds.Tables[0].Rows)
    //        {
    //            categoryname = row1["categoryname"].ToString().Trim();

    //            ddlcategory.Items.Add(new ListItem(Convert.ToString(categoryname)));
    //        }
    //    }
      //  }
    //========================================================================================================================================

    protected void bindgrid()
    {
        //sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate FROM ACHIEVEMENTS ORDER BY posteddate desc,category";
        sqlstr = "select id,heading,description,postedby,run_status,priority,category from achievements";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        achievementsdetails.DataSource = ds;
        achievementsdetails.DataBind();
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
            Response.Redirect("Achievement Master.aspx?update=true");
        }
        bindgrid();
    }

    private void Clear()
    {
       
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
                SqlParameter[] newparameter = new SqlParameter[6];

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

                newparameter[5] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
                newparameter[5].Value = _userCode.ToString();

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_achievements_sp", newparameter);
                return false;
            }

            if (Convert.ToInt32(ViewState["flagedit"]) == 1)
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

                newparameter[5] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
                newparameter[5].Value = _userCode.ToString();

                newparameter[6] = new SqlParameter("@id", SqlDbType.Int);
                newparameter[6].Value = ViewState["id"].ToString();

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_update_achievements_sp", newparameter);
                return true;
            }
            return true;
        }
        catch (SqlException sql)
        {
            Output.Show("Cannot insert duplicate values or some database error has been occured");
            //message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
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
        ddlcategory.SelectedValue = "0";
        txtheading.Text = "";
        txtdescription.Text = "";
        Response.Redirect("Achievement Master.aspx");
    }
    //========================================================================================================================================
    protected void achievementsdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        achievementsdetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        achievementsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
        //    e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        //}
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)achievementsdetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM ACHIEVEMENTS WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
        Output.Show("Deleted Sucessfully");
    }

    //========================================================================================================================================
    protected void achievementsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.Visible = false;
        int id;
        lblhead.Text = "Edit";
        btnsubmit.Text = "Update";
        btnreset.Text = "Cancel";
        ViewState["flagedit"] = 1; //FOR EDITING RECORDS

        id = (int)achievementsdetails.DataKeys[e.NewEditIndex].Value;
        ViewState["id"] = id;

        sqlstr = " select heading,description,postedby,run_status,priority,category from achievements WHERE id='" + id + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["category"].ToString();
        ddlrunstatusg.SelectedValue = ds.Tables[0].Rows[0]["run_status"].ToString();
        ddlpriorityg.SelectedValue = ds.Tables[0].Rows[0]["priority"].ToString();
        txtheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
        txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
        //txt_edate.Text = ds.Tables[0].Rows[0]["eventdate"].ToString();
        //achievementsdetails.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //int id = (int)achievementsdetails.DataKeys[e.RowIndex].Value;

        //string strname = ((TextBox)achievementsdetails.Rows[e.RowIndex].Cells[0].FindControl("txtheadingg")).Text;

        //SqlParameter[] sqlparam = new SqlParameter[2];

        //if (strname != "")
        //{
        //    string strcategory = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        //    string strheading = ((TextBox)achievementsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        //    string strdescription = ((TextBox)achievementsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        //    string strrunstatus = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        //    string strpriority = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
        //    int code = (int)achievementsdetails.DataKeys[e.RowIndex].Value;

        //    sqlstr = "UPDATE ACHIEVEMENTS SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //    Response.Redirect("Achievement Master.aspx");
        //    //ddlperquistename.DataBind();
        //    //othrsrcincgird.EditIndex = -1;
        //    //othrsrcincgird.DataSourceID = "SqlDataSource1";

        //    //    othrsrcincgird.DataBind();
        //    //txtothrsrcinc.Text = "";
        //    //message.InnerHtml = "Other Source Income has been added successfully !";
        //}
        //else
        //{
        //    string msg = "Please enter Heading !";
        //    Page.RegisterStartupScript("vv", "<script> alert('" + msg + "')</script>");
        //    message.InnerHtml = "Please enter Heading !";

        //}

        //string strcategory = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        //string strheading = ((TextBox)achievementsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        //string strdescription = ((TextBox)achievementsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        //string strrunstatus = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        //string strpriority = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
        //int code = (int)achievementsdetails.DataKeys[e.RowIndex].Value;

        //sqlstr = "UPDATE ACHIEVEMENTS SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //achievementsdetails.EditIndex = -1;
        //bindgrid();
    }
    //===
}