using Common.Console;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;

public partial class Query_QTreportDateWise : System.Web.UI.Page
{
    string UserCode, RoleId = "";
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"].ToString() != null && Session["role"].ToString() != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
        }
        else
            Response.Redirect("../LogOut.aspx");
        if (!IsPostBack)
        {
            if (Request.QueryString["page"] == "Back")
            {
                gvQueryReport.DataSource = Session["gvReportSearchedDTW"];
                gvQueryReport.DataBind();
            }
        }
    }

    private void GetSearchedData()
    {
        DataSet dsSearched = new DataSet();
        string strSearched;
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
              
                strSearched = "select id,empCode,postedby,queryTypeName,description from tbl_query_raised_queries where status=1 and convert(varchar,posteddate,101) >= '" + txtFromDate.Text.Trim() + "' and convert(varchar,posteddate,101) <= '" + txtToDate.Text.Trim() + "'";
                dsSearched = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearched);
                dsSearched.Tables[0].Columns.Add("Other");
                for (int i = 0; i < dsSearched.Tables[0].Rows.Count; i++)
                {
                    dsSearched.Tables[0].Rows[i]["Other"] = "myPage";
                }
                gvQueryReport.DataSource = dsSearched;
                gvQueryReport.DataBind();
            }
            else
            {
                strSearched = "select id,empCode,postedby,queryTypeName,description from tbl_query_raised_queries where status=1";
                dsSearched = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearched);
                dsSearched.Tables[0].Columns.Add("Other");
                for (int i = 0; i < dsSearched.Tables[0].Rows.Count; i++)
                {
                    dsSearched.Tables[0].Rows[i]["Other"] = "myPage";
                }
                gvQueryReport.DataSource = dsSearched;
                gvQueryReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        Session["gvReportSearchedDTW"] = dsSearched;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetSearchedData();
        DataSet dsSearch = new DataSet();
        string strSearch;
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                strSearch = "select id,empCode,postedby,queryTypeName,description from tbl_query_raised_queries where status=1 and convert(varchar,posteddate,101) >= '" + txtFromDate.Text + "' and convert(varchar,posteddate,101) <= '" + txtToDate.Text + "'";
                dsSearch = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearch);
                dsSearch.Tables[0].Columns.Add("Other");
                for (int i = 0; i < dsSearch.Tables[0].Rows.Count; i++)
                {
                    dsSearch.Tables[0].Rows[i]["Other"] = "myPage";
                }
                gvQueryReport.DataSource = dsSearch;
                gvQueryReport.DataBind();
            }
            else
            {
                strSearch = "select id,empCode,postedby,queryTypeName,description from tbl_query_raised_queries where status=1";
                dsSearch = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearch);
                dsSearch.Tables[0].Columns.Add("Other");
                for (int i = 0; i < dsSearch.Tables[0].Rows.Count; i++)
                {
                    dsSearch.Tables[0].Rows[i]["Other"] = "myPage";
                }
                gvQueryReport.DataSource = dsSearch;
                gvQueryReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        dsSearch.Tables[0].Columns.Remove("Other");
        dsSearch.Tables[0].Columns.Remove("id");
        dsSearch.Tables[0].Columns["empCode"].ColumnName = "Employee Code";
        dsSearch.Tables[0].Columns["postedby"].ColumnName = "Employee Name";
        dsSearch.Tables[0].Columns["queryTypeName"].ColumnName = "Query Type";
        dsSearch.Tables[0].Columns["description"].ColumnName = "Description";
        ViewState["gvReport"] = dsSearch;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void lnkbtnExport_Click(object sender, EventArgs e)
    {
        //DataSet dsReport = (DataSet)ViewState["gvReport"];
        //if (dsReport==null)
        //    return;
        //DataTable dt = dsReport.Tables[0];
        ////dt.Columns["id"].ColumnName = "ID";
        //if (gvQueryReport.Rows.Count > 0)
        //{
        //    try
        //    {
        //       ExportDataTabletopdf(dt, "Query Report");
        //    }
        //    catch (Exception ex)
        //    {
        //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        //    }
        //}
        if (gvQueryReport.Rows.Count > 0)
        {
            // Hides the first column in the grid (zero-based index)
            gvQueryReport.HeaderRow.Cells[4].Visible = false;

            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvQueryReport.Rows.Count; i++)
            {
                GridViewRow row = gvQueryReport.Rows[i];
                row.Cells[4].Visible = false;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Query DateWise Report"+ ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < gvQueryReport.Rows.Count; i++)
            {

                gvQueryReport.Rows[i].Style.Add("width", "150px");
                gvQueryReport.Rows[i].Style.Add("height", "20px");
            }

            gvQueryReport.GridLines = GridLines.Both;
            gvQueryReport.HeaderStyle.Font.Bold = true;
            gvQueryReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }

    //private void ExportDataTabletopdf(DataTable dtable, string header)
    //{
    //     Response.Clear();
    //    Response.Buffer = true;
    //    Response.AddHeader("content-disposition", "attachment;filename=QueryDateWiseReport.xls");
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.ms-excel";
    //    using (StringWriter sw = new StringWriter())
    //    {
    //        HtmlTextWriter hw = new HtmlTextWriter(sw);
    //        gvQueryReport.HeaderRow.BackColor = System.Drawing.Color.White;
    //        foreach (TableCell cell in gvQueryReport.HeaderRow.Cells)
    //        {
    //            cell.BackColor = gvQueryReport.HeaderStyle.BackColor;
    //        }
    //        foreach (GridViewRow row in gvQueryReport.Rows)
    //        {
    //            row.BackColor = System.Drawing.Color.White;
    //            foreach (TableCell cell in row.Cells)
    //            {
    //                if (row.RowIndex % 2 == 0)
    //                {
    //                    cell.BackColor = gvQueryReport.AlternatingRowStyle.BackColor;
    //                }
    //                else
    //                {
    //                    cell.BackColor = gvQueryReport.RowStyle.BackColor;
    //                }
    //                cell.CssClass = "textmode";
    //            }
    //        }

    //        gvQueryReport.RenderControl(hw);

    //        //style to format numbers to string
    //        string style = @"<style> .textmode { } </style>";
    //        Response.Write(style);
    //        Response.Output.Write(sw.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }
    //}
}