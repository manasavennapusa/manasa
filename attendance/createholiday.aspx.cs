using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Collections.Specialized;

public partial class attendance_createholiday : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                Year();
                Bindalldata();

                if (Request.QueryString["save"] != null)
                    Common.Console.Output.Show("Holiday Created Successfully.");
                if (Request.QueryString["updated"] != null)
                    Common.Console.Output.Show("Holiday Updated Successfully.");
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of Create Holiday =============================
    #region Bind Year

    private void Year()
    {
        ddlyear.Items.Clear();
        ddlyear.Items.Add(new ListItem("--Select Year--", "0"));

        for (int yr = 2014; yr <= DateTime.Now.Year + 1; yr++)
        {
            ddlyear.Items.Add(new ListItem(Convert.ToString(yr)));
        }
    }
    #endregion
    
    #region Reset the Values

    private void Clearfield()
    {
        ddlyear.SelectedIndex = 0;
        ddbranch_id.SelectedIndex = 0;
        txtdate.Text = "";
        txtholiday.Text = "";
        txtdetail.Text = "";
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Clearfield();
    }
    #endregion
    #region Save the Holiday Details
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        var parm = new SqlParameter[10];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            StringCollection sc = new StringCollection();   //using System.Collections.Specialized;
            //if (ddbranch_id.SelectedIndex != -1)
            //{

            //    foreach (ListItem item in ddbranch_id.Items)
            //    {
            //        if (item.Selected)
            //        {
                       
                    
           
            Output.AssignParameter(parm, 0, "@year", "String", 10, ddlyear.Text);
            Output.AssignParameter(parm, 1, "@company_id", "Int", 0, _companyId);
            Output.AssignParameter(parm, 2, "@branch_id", "Int", 0, ddbranch_id.SelectedValue);
            Output.AssignParameter(parm, 3, "@name", "String", 100, txtholiday.Text);
            Output.AssignParameter(parm, 4, "@detail", "String", 200, txtdetail.Text);
            if (txtdate.Text != "")
            {
                if (txtdate.Text != null)
                    Output.AssignParameter(parm, 5, "@date", "DateTime", 0, Common.Date.Utility.DateFormat(txtdate.Text).ToString(CultureInfo.InvariantCulture));
            }
            else
                Output.AssignParameter(parm, 5, "@date", "DateTime", 0, "");

            Output.AssignParameter(parm, 6, "@createddate", "DateTime", 0,DateTime.Now.ToString());
            Output.AssignParameter(parm, 7, "@createdby", "String", 100, _userCode);
            Output.AssignParameter(parm, 8, "@modifiedby", "String", 100, _userCode);
            Output.AssignParameter(parm, 9, "@shiftid", "Int",0, ddl_shift.SelectedValue);
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_createholiday", parm);
            transaction.Commit();
            //        }
            //    }
            //}
            
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
           // Output.Show("Holiday Created Successfully");
            Response.Redirect("createholiday.aspx?save=true");
        }
        if (flag > 0)
        {

           
            Clearfield();
        }
        else
        {
            Output.Show("Holiday already exists, try again.");
        }
    }


      #endregion
    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddbranch_id.Items.Insert(0, new ListItem("--For All Work Locations--", "0"));

    }

    protected void ddlbranch_DataBound1(object sender, EventArgs e)
    {
        //ddselbranch.Items.Insert(0, new ListItem("--For all WorkLocations--", "0"));
    }

    protected void ddselbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindholiday();
    }

    private void Bindholiday()
    {
        if (ddselbranch.SelectedValue == "0")
            Bindalldata();
        else
            Bindsearchdata();
    }

    private void Bindalldata()
    {

        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "SELECT dbo.tbl_leave_holiday.holidayid, isnull(tbl_intranet_branch_detail.branch_name,'All Work Locations') branch_name, dbo.tbl_leave_holiday.year, dbo.tbl_leave_holiday.name, dbo.tbl_leave_holiday.detail,datename(dw,convert(varchar(11),tbl_leave_holiday.date,101)) dayofweek, (CASE WHEN dbo.tbl_leave_holiday.date='01/01/1990' THEN '' ELSE CONVERT(CHAR(12), dbo.tbl_leave_holiday.date, 106) END) date,tbl_leave_shift.shiftname FROM  dbo.tbl_leave_holiday left outer JOIN  tbl_intranet_branch_detail ON dbo.tbl_leave_holiday.branch_id = dbo.tbl_intranet_branch_detail.branch_id  left join tbl_leave_shift on tbl_leave_shift.shiftid=tbl_leave_holiday.shiftid where tbl_leave_holiday.year=year(getdate()) and tbl_leave_holiday.status=1 and tbl_leave_holiday.company_id=" + _companyId + " order by tbl_leave_holiday.year desc,tbl_leave_holiday.date";
            DataSet dataset = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            holidaygrid.DataSource = dataset;
            holidaygrid.DataBind();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }


    }

    private void Bindsearchdata()
    {

        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "SELECT dbo.tbl_leave_holiday.holidayid, isnull(dbo.tbl_intranet_branch_detail.branch_name,'" + ddselbranch.SelectedItem.Text + "') branch_name, dbo.tbl_leave_holiday.year, dbo.tbl_leave_holiday.name, dbo.tbl_leave_holiday.detail,datename(dw,convert(varchar(11),tbl_leave_holiday.date,101)) dayofweek, (CASE WHEN dbo.tbl_leave_holiday.date='01/01/1990' THEN '' ELSE CONVERT(CHAR(12), dbo.tbl_leave_holiday.date, 106) END) date FROM  dbo.tbl_leave_holiday left outer JOIN dbo.tbl_intranet_branch_detail ON dbo.tbl_leave_holiday.branch_id = dbo.tbl_intranet_branch_detail.branch_id where dbo.tbl_leave_holiday.branch_id in (" + ddselbranch.SelectedValue + ",0) and  tbl_leave_holiday.year=year(getdate()) order by dbo.tbl_leave_holiday.year desc,dbo.tbl_leave_holiday.date";
            DataSet dataSet = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            holidaygrid.DataSource = dataSet;
            holidaygrid.DataBind();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }



    }

    protected void holidaygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        holidaygrid.PageIndex = e.NewPageIndex;
        holidaygrid.DataSource = ds;
        holidaygrid.DataBind();
    }

    protected void holidaygrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var activity = new Common.Data.DataActivity();
        int i = 0;
        try
        {
            SqlConnection connection = activity.OpenConnection();
            var dataKey = holidaygrid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                var a = (int)dataKey.Value;
                string query = "delete from  tbl_leave_holiday  WHERE holidayid=" + a + "";
                i = Common.Data.SQLServer.ExecuteNonQuery(connection, CommandType.Text, query);
            }
            Bindholiday();
            if (i > 0)
            {
                Common.Console.Output.Show("Holiday Deleted successfully.");
            }

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void holidaygrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("UpdateHoliday.aspx?holidayid=" + Convert.ToInt32(Request.QueryString["holidayid"]) + "");
    }

    protected void holidaygrid_PreRender(object sender, EventArgs e)
    {
        if (holidaygrid.Rows.Count > 0)
            holidaygrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void ddbranch_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindshift();
    }

    protected void bindshift()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "select shiftid,shiftname as shiftname from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1 and tbl_leave_shift.branch_id=" + ddbranch_id.SelectedValue+ "";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
           
            ddl_shift.DataTextField = "shiftname";
            ddl_shift.DataValueField = "shiftid";
            ddl_shift.DataSource = ds;
            ddl_shift.DataBind();

            ddl_shift.Items.Insert(0, new ListItem("--Select-- ", "0"));
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
    protected void ddl_shift_DataBound(object sender, EventArgs e)
    {
        //ddl_shift.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}
