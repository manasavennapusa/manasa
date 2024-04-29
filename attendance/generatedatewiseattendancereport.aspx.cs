using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.IO;
using Common.Data;
using Common.Console;

public partial class attendance_generatedatewiseattendancereport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {


            }
            else
                Response.Redirect("~/notlogged.aspx");
            drpdepartment.Items.Insert(0, new ListItem("All", "0"));
            drpdegination.Items.Insert(0, new ListItem("All", "0"));
            txt_sdate.Text = System.DateTime.Today.Date.ToString("MM/dd/yyyy");

        }
    }
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }

    protected void bind_departmnt(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' ";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartment.DataTextField = "department_name";
            drpdepartment.DataValueField = "departmentid";
            drpdepartment.DataSource = ds1;
            drpdepartment.DataBind();
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
    protected void drpdepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind_broadgroup(drpdepartment.SelectedValue);
        BindDesignation(drpdepartment.SelectedValue);
    }

    private void BindDesignation(string deptid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpdegination.DataSource = ds;
                drpdegination.DataTextField = "designationname";
                drpdegination.DataValueField = "id";
                drpdegination.DataBind();
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

    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        drpdegination.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void bindempdetail()
    {
        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[6];

            sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
            sqlparam[0].Value = txt_employee.Text.ToString();

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = drpdegination.SelectedValue;

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = drpdegination.SelectedValue;

            sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
            sqlparam[3].Value = "All";

            sqlparam[4] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            sqlparam[4].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

            sqlparam[5] = new SqlParameter("@branch", SqlDbType.Int);
            sqlparam[5].Value = drpbranch.SelectedValue;

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail", sqlparam);
            attendancegrid.DataSource = ds;
            attendancegrid.DataBind();
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
        exportexcel();
    }

    protected void exportexcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=DateWiseAttendenceReport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            attendancegrid.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in attendancegrid.HeaderRow.Cells)
            {
                cell.BackColor = attendancegrid.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in attendancegrid.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = attendancegrid.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = attendancegrid.RowStyle.BackColor;
                    }
                    cell.Height = 14;
                }
            }

            attendancegrid.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void attendancegrid_PreRender(object sender, EventArgs e)
    {
        if (attendancegrid.Rows.Count > 0)
            attendancegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}