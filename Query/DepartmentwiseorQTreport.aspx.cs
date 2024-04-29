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


public partial class Query_DepartmentwiseorQTreport : System.Web.UI.Page
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
            bindDepartments();
            bindQueryType();

            if (Request.QueryString["page"] == "Back")
            {
                gvQueryReport.DataSource = Session["gvReportSearched"];
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
            if (ddlDeptName.SelectedIndex != 0 && ddlquerytype.SelectedIndex != 0)
            {
                strSearched = "select qry.id,qry.empCode,qry.postedby,qry.queryTypeName,qry.description from tbl_query_raised_queries qry inner join tbl_intranet_employee_jobDetails job on job.empcode=qry.empCode inner join tbl_internate_departmentdetails dep on job.dept_id=dep.departmentid where qry.status=1 and job.dept_id='" + ddlDeptName.SelectedValue + "' and qry.queryTypeName='" + ddlquerytype.SelectedItem.ToString() + "'";
                dsSearched = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearched);
            }
            else if (ddlDeptName.SelectedIndex != 0 && ddlquerytype.SelectedIndex == 0)
            {
                strSearched = "select qry.id,qry.empCode,qry.postedby,qry.queryTypeName,qry.description from tbl_query_raised_queries qry inner join tbl_intranet_employee_jobDetails job on job.empcode=qry.empCode inner join tbl_internate_departmentdetails dep on job.dept_id=dep.departmentid where qry.status=1 and job.dept_id='" + ddlDeptName.SelectedValue + "'";
                dsSearched = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearched);
            }
            else if (ddlDeptName.SelectedIndex == 0 && ddlquerytype.SelectedIndex != 0)
            {
                strSearched = "select qry.id,qry.empCode,qry.postedby,qry.queryTypeName,qry.description from tbl_query_raised_queries qry inner join tbl_intranet_employee_jobDetails job on job.empcode=qry.empCode inner join tbl_internate_departmentdetails dep on job.dept_id=dep.departmentid where qry.status=1 and qry.queryTypeName='" + ddlquerytype.SelectedItem.ToString() + "'";
                dsSearched = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearched);
            }
            else
            {
                strSearched = "select id,empCode,postedby,queryTypeName,description from tbl_query_raised_queries where status=1";
                dsSearched = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearched);
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
        Session["gvReportSearched"] = dsSearched;
    }

    private void bindQueryType()
    {
        string strQT;
        DataSet dsQT = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            strQT = "select query_Id,query_name from tbl_master_queryType where status=1";
            dsQT = SQLServer.ExecuteDataset(connection, CommandType.Text, strQT);
            if (dsQT.Tables[0].Rows.Count > 0)
            {
                ddlquerytype.DataSource = dsQT;
                ddlquerytype.DataTextField = "query_name";
                ddlquerytype.DataValueField = "query_Id";
                ddlquerytype.DataBind();
                ddlquerytype.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
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
    }

    private void bindDepartments()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select [departmentid],[department_name] from [tbl_internate_departmentdetails] where status=1";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDeptName.DataSource = ds;
                ddlDeptName.DataTextField = "department_name";
                ddlDeptName.DataValueField = "departmentid";
                ddlDeptName.DataBind();
                ddlDeptName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
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
            if (ddlDeptName.SelectedIndex != 0 && ddlquerytype.SelectedIndex != 0)
            {
                strSearch = "select qry.id,qry.empCode,qry.postedby,qry.queryTypeName,qry.description from tbl_query_raised_queries qry inner join tbl_intranet_employee_jobDetails job on job.empcode=qry.empCode inner join tbl_internate_departmentdetails dep on job.dept_id=dep.departmentid where qry.status=1 and job.dept_id='" + ddlDeptName.SelectedValue + "' and qry.queryTypeName='" + ddlquerytype.SelectedItem.ToString() + "'";
                dsSearch = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearch);
                gvQueryReport.DataSource = dsSearch;
                gvQueryReport.DataBind();
            }
            else if (ddlDeptName.SelectedIndex != 0 && ddlquerytype.SelectedIndex == 0)
            {
                strSearch = "select qry.id,qry.empCode,qry.postedby,qry.queryTypeName,qry.description from tbl_query_raised_queries qry inner join tbl_intranet_employee_jobDetails job on job.empcode=qry.empCode inner join tbl_internate_departmentdetails dep on job.dept_id=dep.departmentid where qry.status=1 and job.dept_id='" + ddlDeptName.SelectedValue + "'";
                dsSearch = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearch);
                gvQueryReport.DataSource = dsSearch;
                gvQueryReport.DataBind();
            }
            else if (ddlDeptName.SelectedIndex == 0 && ddlquerytype.SelectedIndex != 0)
            {
                strSearch = "select qry.id,qry.empCode,qry.postedby,qry.queryTypeName,qry.description from tbl_query_raised_queries qry inner join tbl_intranet_employee_jobDetails job on job.empcode=qry.empCode inner join tbl_internate_departmentdetails dep on job.dept_id=dep.departmentid where qry.status=1 and qry.queryTypeName='" + ddlquerytype.SelectedItem.ToString() + "'";
                dsSearch = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearch);
                gvQueryReport.DataSource = dsSearch;
                gvQueryReport.DataBind();
            }
            else
            {
                strSearch = "select id,empCode,postedby,queryTypeName,description from tbl_query_raised_queries where status=1";
                dsSearch = SQLServer.ExecuteDataset(connection, CommandType.Text, strSearch);
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
        //if (dsReport == null)
        //    return;
        //DataTable dt = dsReport.Tables[0];
        ////dt.Columns["id"].ColumnName = "ID";
        //if (gvQueryReport.Rows.Count > 0)
        //{
        //    try
        //    {
        //        ExportDataTabletopdf(dt, "Query Report");
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
            string FileName = "Query Report" + ".xls";
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
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.AddHeader("content-disposition", "attachment;filename=QueryDepartmentWiseReport.xls");
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