using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.IO;
using System.Web.UI;
using System.Drawing;


public partial class appraisal_EmployeeAppraisalReport : System.Web.UI.Page
{
    string _companyId;
    DataSet ds;
    public string Year, Quarter;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {

            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                Quarter = Request.QueryString["Quarter"].ToString();
                Year = Request.QueryString["Year"].ToString();
                DataSet ds = BindGrid( Quarter, Year);

            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }

    protected DataSet BindGrid(string Quarter, string Year)
    {

        SqlConnection Connection = null;
        DataActivity Activity = new DataActivity();

        try
        {
            Connection = Activity.OpenConnection();
            SqlParameter[] parm = new SqlParameter[2];
            Output.AssignParameter(parm, 0, "@quarter", "String", 10, Quarter);
            Output.AssignParameter(parm, 1, "@year", "String", 20, Year);
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_fetch_employee_appraisal_report", parm);

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
        Response.AddHeader("content-disposition", "attachment;filename=" + Quarter + "_" + Year + "_AppraisalReport.xls");
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

    
}