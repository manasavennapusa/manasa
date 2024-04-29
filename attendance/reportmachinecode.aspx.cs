using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

public partial class attendance_reportmachinecode : System.Web.UI.Page
{
    string CompanyId, UserCode;
    DataActivity DA = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            if (Session["empcode"] != null && Session["companyid"] != null)
            {
                UserCode = Session["empcode"].ToString();
                CompanyId = Session["companyid"].ToString();

                string Dept = Request.QueryString["Dept"].ToString();
                string DeptType = Request.QueryString["DeptType"].ToString();
                string Branch = Request.QueryString["Branch"].ToString();
                string Empcode = Request.QueryString["Empcode"].ToString();

                bindgrid(Dept, DeptType, Branch, Empcode);
            }
        }
        else
        {

        }
    }

    private void bindgrid(string Dept, string DeptType, string Branch, string Empcode)
    {
        SqlConnection Connection = null;
        DataActivity DA = new DataActivity();
        DataSet ds = null;
        try
        {
            Connection = DA.OpenConnection();
            SqlParameter[] parm = new SqlParameter[5];

            Common.Console.Output.AssignParameter(parm, 0, "@name", "String", 50, Empcode);
            Common.Console.Output.AssignParameter(parm, 1, "@branchid", "Int", 50, Branch);
            Common.Console.Output.AssignParameter(parm, 2, "@departmentid", "Int", 0, Dept);
            Common.Console.Output.AssignParameter(parm, 3, "@companyid", "Int", 50, CompanyId);
            Common.Console.Output.AssignParameter(parm, 4, "@depttype", "Int", 10, DeptType);

            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "SP_REPORT_EMPLOYEE_MACHINECODE&IP", parm);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {


        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=MachineCodeReport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

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


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ///e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
            e.Row.ToolTip = "selecting this row.";

        }
    }

}
