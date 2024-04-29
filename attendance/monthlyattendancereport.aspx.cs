using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.IO;
using System.Web.UI;
using System.Drawing;

public partial class attendance_monthlyattendancereport : System.Web.UI.Page
{
    string _companyId;
    DataSet ds;
    public string Month, Year, Branch, Dept, Emptype, EmpSubType,DepartmentType;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {

            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                Branch = Request.QueryString["Branch"].ToString();
               //DepartmentType = Request.QueryString["DepartmentType"].ToString();
                Dept = Request.QueryString["Department"].ToString();
                string Type = Request.QueryString["Type"].ToString();
                string Empcode = Request.QueryString["EmpCode"].ToString();
                Month = Request.QueryString["Month"].ToString();
                Year = Request.QueryString["Year"].ToString();
                DataSet ds = BindGrid(_companyId, Branch, Dept, Type, Empcode, Month, Year);

            }
        }
        else {Response.Redirect("~/notlogged.aspx"); }

    }

    protected DataSet BindGrid(string _companyId, string Branch, string Dept, string Type, string Empcode, string Month, string Year)
    {

        SqlConnection Connection = null;
        DataActivity Activity = new DataActivity();

        try
        {
            Connection = Activity.OpenConnection();
            SqlParameter[] parm = new SqlParameter[7];
            Output.AssignParameter(parm, 0, "@type", "Int", 0, "0");
            Output.AssignParameter(parm, 1, "@name", "String", 50, Empcode);
            Output.AssignParameter(parm, 2, "@branchid", "Int", 0, Branch);
            Output.AssignParameter(parm, 3, "@departmentid", "Int", 0, Dept);
            Output.AssignParameter(parm, 4, "@companyid", "Int", 0, _companyId);
            Output.AssignParameter(parm, 5, "@month", "Int", 0, Month);
            Output.AssignParameter(parm, 6, "@year", "Int", 0, Year);
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "SP_LEAVE_FETCH_ATTENDANCE_TMT", parm);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
        return ds;

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {


        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + Month + "_" + Year + "_AttendenceReport.xls");
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
            DataRowView row = e.Row.DataItem as DataRowView;
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {

                //int n;
                //bool isNumeric = int.TryParse(e.Row.Cells[i].Text, out n);
                //if (isNumeric)
                //{
                if (e.Row.Cells[i].Text == "P")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#51a351");
                }
                else if (e.Row.Cells[i].Text == "A")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#bd362f");
                }
                else if (e.Row.Cells[i].Text == "W")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#3968c6");
                }
                else if (e.Row.Cells[i].Text == "H")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#3968c6");
                }
                else if (e.Row.Cells[i].Text == "CO")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#428bca");
                }
                else if (e.Row.Cells[i].Text == "OD")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#428bca");
                }
                else if (e.Row.Cells[i].Text == " ")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#f3f3f3");
                }
                else if (e.Row.Cells[i].Text == "CL")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#f89406");
                }
                else if (e.Row.Cells[i].Text == "AL")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#f89406");
                }
                else if (e.Row.Cells[i].Text == "ML")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#f89406");
                }
                else if (e.Row.Cells[i].Text == "PL")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#f89406");
                }
                else if (e.Row.Cells[i].Text == "SL")
                {
                    e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#f89406");
                }
                // else { e.Row.Cells[i].ForeColor = Color.Orange; }
                // }
            }
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            int j = 0, k = 0;
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "Intime")
                    j = 1;
                if (e.Row.Cells[i].Text == "Outtime")
                    k = 1;
                if (e.Row.Cells[i].Text == ("Intime" + j))
                {
                    e.Row.Cells[i].Text = "Intime";
                    j++;
                }
                else if (e.Row.Cells[i].Text == ("Outtime" + k))
                {
                    e.Row.Cells[i].Text = "Outtime";
                    k++;
                }
            }
        }
    }

}
