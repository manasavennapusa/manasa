using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Utilities;
using Common.Data;
using Common.Console;
using System.Web.UI;
using System.IO;

public partial class attendance_generateemployeewiseattendencereport : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;
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
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindattendance();
    }

    protected void bindattendance()
    {
        try
        {
            connection = activity.OpenConnection();
            DateTime dt = DateTime.Now;
            DateTime sdate = new DateTime();
            DateTime edate = new DateTime();
            sdate = Common.Date.Utility.DateFormat(txt_sdate.Text.ToString());
            edate = Common.Date.Utility.DateFormat(txt_edate.Text.ToString());

            SqlParameter[] sqlparm = new SqlParameter[3];
            sqlparm[0] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
            sqlparm[0].Value = sdate;

            sqlparm[1] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);
            sqlparm[1].Value = edate;

            sqlparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[2].Value = txt_employee.Text;

            attendancegrid.DataSource = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_attendance_detail_datewise", sqlparm);
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

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txt_edate.Text = "";
        txt_sdate.Text = "";
        txt_employee.Text = "";
    }


    protected void attendancegrid_PreRender(object sender, EventArgs e)
    {
        if (attendancegrid.Rows.Count > 0)
            attendancegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=EmployeeWiseAttendenceReport.xls");
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
                    cell.CssClass = "textmode";
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
}