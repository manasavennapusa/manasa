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

public partial class InformationCenter_Suggestion : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    //=======================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FOR WATER MARK IN SEARCH TEXT BOX
            string strWatermark = "Search Your Suggestion";
            txtsearch.Text = strWatermark;
            txtsearch.Attributes.Add("onfocus", "WatermarkFocus(this, '" + strWatermark + "');");
            txtsearch.Attributes.Add("onblur", "WatermarkBlur(this, '" + strWatermark + "');");
            //FOR WATER MARK IN SEARCH TEXT BOX

            bindsuggestion();
        }
    }
    //=======================================================================================================================================
    protected void bindsuggestion()
    {
        try
        {
            sqlstr = "";
            sqlstr = "SELECT es.id,es.subject,es.description,es.postedby,(CASE WHEN es.posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), es.posteddate, 106) END) posteddate,ed.department_name FROM tbl_intranet_suggestions es INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=es.empcode INNER JOIN tbl_internate_departmentdetails ed ON ed.departmentid=ej.dept_id WHERE es.status=1 ORDER BY es.approveddate desc";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            suggestiongrid.DataSource = ds;
            suggestiongrid.DataBind();
            searchgrid.Visible = false;
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
                sqlstr = "SELECT es.id,es.subject,es.description,es.status,es.postedby,(CASE WHEN es.posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), es.posteddate, 106) END) posteddate,es.approveddate,ed.department_name FROM tbl_intranet_suggestions es INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=es.empcode INNER JOIN tbl_internate_departmentdetails ed ON ed.departmentid=ej.dept_id WHERE 1=1";
                sqlstr = sqlstr + " AND (es.subject like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%' OR es.description like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
                sqlstr = sqlstr + " OR es.postedby like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%'";
                sqlstr = sqlstr + " OR es.posteddate like '%" + txtsearch.Text.Replace("'", "''").Trim().ToString() + "%')";
                sqlstr = sqlstr + " AND es.status=1";
                sqlstr = sqlstr + " ORDER BY es.approveddate DESC";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                searchgrid.DataSource = ds;
                searchgrid.DataBind();
                searchgrid.Visible = true;
                suggestiongrid.Visible = false;
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

    protected void suggestiongrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        suggestiongrid.PageIndex = e.NewPageIndex;
        bindsuggestion();
    }
    protected void searchgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        searchgrid.PageIndex = e.NewPageIndex;
        bindsearch();
    }
}