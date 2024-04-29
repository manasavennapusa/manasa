using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
using System.IO;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Text;

public partial class Travel_TravelReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataView dview;
    bool c = false;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    bool expance = false;
    bool finance = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            bind_ddlCCgroup();
            bindgrade();
            dd_branch.Items.Insert(0, new ListItem("--All--", "0"));
            dd_designation.Items.Insert(0, new ListItem("--All--", "0"));
            dpttype.Items.Insert(0, new ListItem("--All--", "0"));
                
        }
    }

    private void bindgrade()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select * from tbl_intranet_grade ";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            drpgrade.DataSource = ds;
            drpgrade.DataValueField = "id";
            drpgrade.DataTextField = "gradename";
            drpgrade.DataBind();
            drpgrade.Items.Insert(0, new ListItem("--All--", "0"));
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

    protected void bind_ddlCCgroup()
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_cc_groupid.DataSource = ds;
            ddl_cc_groupid.DataTextField = "cost_center_group_name";
            ddl_cc_groupid.DataValueField = "id";
            ddl_cc_groupid.DataBind();
            ddl_cc_groupid.Items.Insert(0, new ListItem("--All--", "0"));
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

    protected void ddl_cc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_cc_code.Items.Clear();
        //   ddl_cc_code.Items.Insert(0, new ListItem("--All--", "0"));

        if (ddl_cc_groupid.SelectedValue != "0")
            bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));

    }

    protected void bind_cc_code(int accgroupid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_cc_code.DataSource = ds;
            ddl_cc_code.DataTextField = "cost_center_code";
            ddl_cc_code.DataValueField = "id";
            ddl_cc_code.DataBind();
            ddl_cc_code.Items.Insert(0, new ListItem("--All--", "0"));
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

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));

    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDepartmentType(Convert.ToInt32(drpbranch.SelectedValue));
    }

    protected void dd_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDesignation(Convert.ToInt16(dd_branch.SelectedValue));
    }

    protected void ddl_cc_code_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void drpempstatus_DataBound(object sender, EventArgs e)
    {
        drpempstatus.Items.Insert(0, new ListItem("---All---", "0"));
    }

    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }

    private void BindDesignation(int deptid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dd_designation.DataSource = ds;
                dd_designation.DataTextField = "designationname";
                dd_designation.DataValueField = "id";
                dd_designation.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
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

    protected void BindDepartment(int dprttype)
    {
        try
        {

            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE dept_type_id='" + dprttype + "' ";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            dd_branch.DataTextField = "department_name";
            dd_branch.DataValueField = "departmentid";
            dd_branch.DataSource = ds1;
            dd_branch.DataBind();
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

    protected void dpttype_DataBound(object sender, EventArgs e)
    {
        dpttype.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dpttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDepartment(Convert.ToInt32(dpttype.SelectedValue));
    }

    protected void BindDepartmentType(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select  dept_type_id,dept_type_name FROM tbl_internate_department_type where branch_id='" + branchid + "' ";
            DataSet ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            
                dpttype.DataSource = ds2;
                dpttype.DataTextField = "dept_type_name";
                dpttype.DataValueField = "dept_type_id";
                dpttype.DataBind();
            
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
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

    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkl_jobdetails.Items.Count; i++)
        {
            chkl_jobdetails.Items[i].Selected = true;
        }
    }

    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkl_jobdetails.Items.Count; i++)
        {
            chkl_jobdetails.Items[i].Selected = false;
        }
    }

    protected void btngenerate_Click(object sender, EventArgs e)
    {
        connection = activity.OpenConnection();
        string str = "";
        try
        {
            str = getQuery();

            if (str.Equals(""))
            {
                Output.Show("Please Select One to gernerate report");
            }
            else
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@appprovercode", SqlDbType.VarChar, 50);
                param[0].Value = Session["empcode"].ToString();
                param[1] = new SqlParameter("@selectedcolumns", SqlDbType.VarChar, 2000);
                param[1].Value = str;
                param[2] = new SqlParameter("@name", SqlDbType.VarChar, 50);
                param[2].Value = txtfirstname.Text;
                param[3] = new SqlParameter("@desg", SqlDbType.VarChar, 2000);
                param[3].Value = dd_designation.SelectedValue;
                param[4] = new SqlParameter("@department", SqlDbType.VarChar, 50);
                param[4].Value = dd_branch.SelectedValue;
                param[5] = new SqlParameter("@status", SqlDbType.VarChar, 2000);
                param[5].Value = drpempstatus.SelectedValue;
                param[6] = new SqlParameter("@branch", SqlDbType.VarChar, 50);
                param[6].Value = drpbranch.SelectedValue;
                param[7] = new SqlParameter("@grade", SqlDbType.VarChar, 2000);
                param[7].Value = drpgrade.SelectedValue;
                param[8] = new SqlParameter("@fromdate", SqlDbType.DateTime);
                param[8].Value = txtfromdate.Text == "" ? "1/1/1900" : txtfromdate.Text.Trim();
                param[9] = new SqlParameter("@todate", SqlDbType.DateTime);
                param[9].Value = txttodate.Text == "" ? "1/1/1900" : txttodate.Text.Trim();
                ds.Clear();
                ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_travel_generateTravelReport", param);
                tblResult.InnerHtml = bindtable(ds);
                light.Style.Add("display", "block");
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

    protected void btnexport_Click(object sender, EventArgs e)
    {
        Response.AppendHeader("content-disposition", "attachment;filename=TravelReport.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
        Response.Write(tblResult.InnerHtml);
        Response.End();
    }

    protected string getQuery()
    {
        string str = "";
        foreach (ListItem li in chkl_jobdetails.Items)
        {
            if (li.Selected == true)
            {
                if (li.Value != "totalPrebooking" && li.Value != "totalExpense")
                    str = str + li.Value + " as '" + li.Text + "',";
                else
                    if (li.Value == "totalPrebooking")
                        expance = true;
                    else
                        if (li.Value == "totalExpense")
                            finance = true;

            }
        }
        if (str != "")
            str = str.Substring(0, str.Length - 1);
        else str = "";
        return str;
    }

    protected string bindtable(DataSet dset)
    {
        StringBuilder table = new StringBuilder();
        StringBuilder hearder = new StringBuilder();
        table.Append("<table class='table table-hover table-striped table-bordered table-highlight-head'>");
        hearder.Append("<tr>");
        for (int i = 1; i < dset.Tables[0].Columns.Count; i++)
        {
            if (expance || finance)
            {
                hearder.Append("<td class='frm-lft-clr123' rowspan=2 >" + dset.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
            }
            else
            {
                hearder.Append("<td class='frm-lft-clr123' style='width:100%'>" + dset.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
            }

        }
        if (dset.Tables.Count > 2)
            if (dset.Tables[1].Rows.Count > 0)
            {
                if (expance)
                {
                    hearder.Append("<td class='frm-lft-clr123' colspan='" + (dset.Tables[1].Columns.Count - 1).ToString() + "'> Total Expense Sanctioned</td>");
                }
            }
        if (dset.Tables.Count == 3)
            if (dset.Tables[2].Rows.Count > 0)
            {
                if (finance)
                {
                    hearder.Append("<td class='frm-lft-clr123' colspan='" + (dset.Tables[2].Columns.Count - 1).ToString() + "'> Total Pre Booking Amount</td>");
                }
            }
        hearder.Append("</tr>");

        if (expance || finance)
        {
            hearder.Append("<tr class='frm-rght-clr123 border-bottom'>");
            if (dset.Tables.Count > 2)
                if (dset.Tables[1].Rows.Count > 0)
                {
                    if (expance)
                        for (int i = 1; i < dset.Tables[1].Columns.Count; i++)
                        {
                            hearder.Append("<td class='frm-lft-clr123' style='border-right:none'>" + dset.Tables[1].Columns[i].ColumnName.ToString() + "</td>");
                        }
                }
            if (dset.Tables.Count == 3)
                if (dset.Tables[2].Rows.Count > 0)
                {
                    if (finance)
                        for (int i = 1; i < dset.Tables[2].Columns.Count; i++)
                        {
                            hearder.Append("<td class='frm-lft-clr123 border-bottom'>" + dset.Tables[2].Columns[i].ColumnName.ToString() + "</td>");
                        }
                }
            hearder.Append("</tr>");

        }
        table.Append(hearder);
        for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
        {
            table.Append("<tr class='frm-rght-clr123 border-bottom'>");
            for (int ic = 1; ic < dset.Tables[0].Columns.Count; ic++)
                table.Append("<td class='frm-rght-clr123 border-bottom' style='border-right:none' >" + dset.Tables[0].Rows[i][ic].ToString() + "</td>");

            if (expance)
            {
                if (dset.Tables.Count > 2)
                    if (dset.Tables[1].Rows.Count > 0)
                    {
                        DataView dv1 = dset.Tables[1].DefaultView;
                        dv1.RowFilter = "travelid=" + dset.Tables[0].Rows[i][0].ToString();
                        DataTable dtexp = dv1.ToTable();

                        for (int e = 0; e < dtexp.Rows.Count; e++)
                        {
                            for (int ec = 1; ec < dtexp.Columns.Count; ec++)
                                table.Append("<td class='frm-rght-clr123 border-bottom'>" + dtexp.Rows[e][ec].ToString() + "</td>");
                        }
                    }
            }
            if (finance)
            {
                if (dset.Tables.Count == 3)
                    if (dset.Tables[2].Rows.Count > 0)
                    {
                        DataView dv2 = dset.Tables[2].DefaultView;
                        dv2.RowFilter = "travelid=" + dset.Tables[0].Rows[i][0].ToString();
                        DataTable dtfin = dv2.ToTable();

                        for (int f = 0; f < dtfin.Rows.Count; f++)
                        {
                            for (int fc = 1; fc < dtfin.Columns.Count; fc++)
                                table.Append("<td class='frm-rght-clr123 border-bottom'>" + dtfin.Rows[f][fc].ToString() + "</td>");
                        }
                    }
            }
            table.Append("</tr>");
        }
        table.Append("</table>");

        return table.ToString();

    }

    
}