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

public partial class InformationCenter_FinancialsView : System.Web.UI.Page
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
            string strWatermark = "Search Financials";
            txtsearch.Text = strWatermark;
            txtsearch.Attributes.Add("onfocus", "WatermarkFocus(this, '" + strWatermark + "');");
            txtsearch.Attributes.Add("onblur", "WatermarkBlur(this, '" + strWatermark + "');");
            //FOR WATER MARK IN SEARCH TEXT BOX

            bindgrid();
        }
    }

    //=======================================================================================================================================
    protected void bindgrid()
    {
        try
        {
            sqlstr = "SELECT id,heading,description,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,posteddate posteddate1,postedby FROM tbl_intranet_financial ORDER BY posteddate1 desc";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            griddetails.DataSource = ds;
            griddetails.DataBind();
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
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        ViewState["search"] = 1;
        bindsearch();
    }

    //=======================================================================================================================================
    protected void bindsearch()
    {
        try
        {
            if (Convert.ToInt32(ViewState["search"]) == 1)
            {
                sqlstr = "";
                sqlstr = "SELECT id,heading,description,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,posteddate posteddate1,postedby FROM tbl_intranet_financial WHERE 1=1";
                sqlstr = sqlstr + " AND (heading like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%' OR description like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";

                sqlstr = sqlstr + " OR postedby like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
                sqlstr = sqlstr + " OR posteddate like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%')";
                sqlstr = sqlstr + " ORDER BY posteddate1 DESC";

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                griddetails.DataSource = ds;
                griddetails.DataBind();

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
    protected void griddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }

 
    


}