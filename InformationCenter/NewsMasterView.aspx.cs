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
public partial class InformationCenter_NewsMasterView : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;

    //=======================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            //FOR WATER MARK IN SEARCH TEXT BOX
            string strWatermark = "";
            //txtsearch.Text = strWatermark;
            //txtsearch.Attributes.Add("onfocus", "WatermarkFocus(this, '" + strWatermark + "');");
            //txtsearch.Attributes.Add("onblur", "WatermarkBlur(this, '" + strWatermark + "');");
            //FOR WATER MARK IN SEARCH TEXT BOX

           // bindcategory();//BINDING CATEGORY

            //DATE WISE NEWS
            if (Request.QueryString["news"] == "1")
            {
              //  binddatewise();
                defaltbindatewise();
            }

            //PRIORITY NEWS
            if (Request.QueryString["news"] == "2")
            {
                //bindpriority();
                //defaltbindpriority();
            }

            //TODAY'S NEWS
            if ((Request.QueryString["news"] != "1") && (Request.QueryString["news"] != "2"))
            {
                bindnews();
            }
        }
    }

    //=======================================================================================================================================
    protected void bindnews()
    {
        try
        {
            //img1.Visible = true;
            if ((Request.QueryString["news"] != "1") && (Request.QueryString["news"] != "2"))
            {
                DateTime d = DateTime.Today;
               // lbldate.Text = d.ToString("MMM dd, yyyy");
                sqlstr = "";
                sqlstr = "select id,heading,substring(description,1,200) description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,run_status,category,priority,Posteddate Posteddate1,Upload from newsroom WHERE 1=1 AND CONVERT(CHAR(15), posteddate, 106)=CONVERT(CHAR(15), getdate(), 106)";
                if (ddlcategory.SelectedValue != "0")
                {
                    sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedValue + "'";

                }
                sqlstr = sqlstr + " AND run_status in (1,2) AND priority In (1,2,3) ORDER BY Posteddate1 desc,category";

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                Newsgrid.DataSource = ds;
                Newsgrid.DataBind();

                searchgrid.Visible = false;
                Newsgrid.Visible = true;
                newsdatewise.Visible = false;
                //priority.Visible = false;
            }
        }
        catch (SqlException sql)
        {
            message.InnerHtml = sql.Message;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
        }
        finally
        {

        }
    }

    //=======================================================================================================================================
    protected void bindcategory()
    {
        try
        {
            string category;
            ////-----Add the CATEGORY in the drop down list Box-------------------------------
            ddlcategory.Items.Add(new ListItem("---Select Category---"));

            sqlstr = "SELECT distinct category FROM NEWSROOM";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row1 in ds.Tables[0].Rows)
                {
                    category = row1["category"].ToString().Trim();

                    ddlcategory.Items.Add(new ListItem(Convert.ToString(category)));
                }
            }
        }
        catch (SqlException sql)
        {
            message.InnerHtml = "Errors in record fetching. Please try later!";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Session expired. Please login again!";
        }
        finally
        {

        }
    }

    //=======================================================================================================================================

    protected void defaltbindatewise()
    {
          
        try
        {
            //img1.Visible = false;
            if (Request.QueryString["news"] == "1")
            {
                sqlstr = "";
                sqlstr = "select id,heading,substring(description,1,200) description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,run_status,category,priority,Posteddate Posteddate1,Upload from newsroom WHERE 1=1";


                sqlstr = sqlstr + " AND run_status in (1,2) ORDER BY Posteddate1 desc,category";


                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                newsdatewise.DataSource = ds;
                newsdatewise.DataBind();

                searchgrid.Visible = false;
                Newsgrid.Visible = false;
                newsdatewise.Visible = true;
               // priority.Visible = false;
            }
        }
        catch (SqlException sql)
        {
            message.InnerHtml = sql.Message;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
        }
        finally
        {

        }
    }

    protected void binddatewise()
    {
        try
        {
            //img1.Visible = false;
            if (Request.QueryString["news"] == "1")
            {
                sqlstr = "";
                sqlstr = "select id,heading,substring(description,1,200) description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,run_status,category,priority,Posteddate Posteddate1 from newsroom WHERE 1=1";

                if (ddlcategory.SelectedValue != "0")
                {
                    sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedValue+ "'";

                }
                sqlstr = sqlstr + " AND run_status in (1,2) ORDER BY Posteddate1 desc,category";


                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                newsdatewise.DataSource = ds;
                newsdatewise.DataBind();

                searchgrid.Visible = false;
                Newsgrid.Visible = false;
                newsdatewise.Visible = true;
               // priority.Visible = false;
            }
        }
        catch (SqlException sql)
        {
            message.InnerHtml = sql.Message;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
        }
        finally
        {

        }
    }

    //=======================================================================================================================================

    //protected void defaltbindpriority()
    //{

    //    try
    //    {
    //        //img1.Visible = false;
    //        if (Request.QueryString["news"] == "2")
    //        {
    //            sqlstr = "";
    //            sqlstr = "select id,heading,substring(description,1,200) description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,run_status,category,priority,Posteddate Posteddate1 from newsroom WHERE 1=1";
               
    //            sqlstr = sqlstr + " AND run_status in (1,2) ORDER BY priority desc,Posteddate1 desc,category";


    //            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //            priority.DataSource = ds;
    //            priority.DataBind();

    //            searchgrid.Visible = false;
    //            Newsgrid.Visible = false;
    //            newsdatewise.Visible = false;
    //            priority.Visible = true;
    //        }
    //    }
    //    catch (SqlException sql)
    //    {
    //        message.InnerHtml = sql.Message;
    //    }
    //    catch (Exception ex)
    //    {
    //        message.InnerHtml = ex.Message;
    //    }
    //    finally
    //    {

    //    }
    //}


    //protected void bindpriority()
    //{
    //    try
    //    {
    //        //img1.Visible = false;
    //        if (Request.QueryString["news"] == "2")
    //        {
    //            sqlstr = "";
    //            sqlstr = "select id,heading,substring(description,1,200) description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,run_status,category,priority,Posteddate Posteddate1 from newsroom WHERE 1=1";

    //            if (ddlcategory.SelectedValue != "0")
    //            {
    //                sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedValue + "'";

    //            }
    //            sqlstr = sqlstr + " AND run_status in (1,2) ORDER BY priority desc,Posteddate1 desc,category";


    //            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //            priority.DataSource = ds;
    //            priority.DataBind();

    //            searchgrid.Visible = false;
    //            Newsgrid.Visible = false;
    //            newsdatewise.Visible = false;
    //            priority.Visible = true;
    //        }
    //    }
    //    catch (SqlException sql)
    //    {
    //        message.InnerHtml = sql.Message;
    //    }
    //    catch (Exception ex)
    //    {
    //        message.InnerHtml = ex.Message;
    //    }
    //    finally
    //    {

    //    }
    //}

    //=======================================================================================================================================
    protected void btngo_Click(object sender, EventArgs e)
    {
        bindnews();
        binddatewise();
       // bindpriority();
       // bindsearch();
    }

    //=======================================================================================================================================
    //protected void btnsearch_Click(object sender, EventArgs e)
    //{
    //    ViewState["search"] = 1;
    //    bindsearch();
    //}

    //=======================================================================================================================================
    //protected void bindsearch()
    //{
    //    try
    //    {
    //        //img1.Visible = false;
    //        if (Convert.ToInt32(ViewState["search"]) == 1)
    //        {
    //            sqlstr = "";
    //            sqlstr = "SELECT id,heading,substring(description,1,200) description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,run_status,category,priority,posteddate posteddate1 from newsroom WHERE 1=1";
    //            sqlstr = sqlstr + " AND (heading like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%' OR description like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";

    //            sqlstr = sqlstr + " OR category like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
    //            sqlstr = sqlstr + " OR postedby like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
    //            sqlstr = sqlstr + " OR posteddate like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%')";
    //            if (ddlcategory.SelectedIndex != 0)
    //            {
    //                sqlstr = sqlstr + " AND category='" + ddlcategory.SelectedItem.Text + "'";
    //            }
    //            sqlstr = sqlstr + " AND run_status in (1,2)";
    //            sqlstr = sqlstr + " ORDER BY priority DESC,posteddate1 DESC";

    //            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //            searchgrid.DataSource = ds;
    //            searchgrid.DataBind();

    //            searchgrid.Visible = true;
    //            Newsgrid.Visible = false;
    //            newsdatewise.Visible = false;
    //            priority.Visible = false;
    //        }
    //    }
    //    catch (SqlException sql)
    //    {
    //        message.InnerHtml = sql.Message;
    //    }
    //    catch (Exception ex)
    //    {
    //        message.InnerHtml = ex.Message;
    //    }
    //    finally
    //    {

    //    }
    //}

    //=======================================================================================================================================
    //protected void Newsgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    Newsgrid.PageIndex = e.NewPageIndex;
    //    bindnews();
    //}

    //=======================================================================================================================================
    //protected void newsdatewise_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    newsdatewise.PageIndex = e.NewPageIndex;
    //    binddatewise();
    //}

    //=======================================================================================================================================
    //protected void priority_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    priority.PageIndex = e.NewPageIndex;
    //    bindpriority();
    //}

    //=======================================================================================================================================
    protected void searchgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        searchgrid.PageIndex = e.NewPageIndex;
       // bindsearch();
    }
    protected void newsdatewise_PreRender(object sender, EventArgs e)
    {
        if (newsdatewise.Rows.Count > 0)
        {
            newsdatewise.UseAccessibleHeader = true;
            newsdatewise.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    
    protected void Newsgrid_PreRender(object sender, EventArgs e)
    {
        if (Newsgrid.Rows.Count > 0)
        {
            Newsgrid.UseAccessibleHeader = true;
            Newsgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}