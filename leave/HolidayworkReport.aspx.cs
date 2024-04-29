using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.IO;
using System.Web.UI;
using System.Web;

public partial class leave_HolidayworkReport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }
    }
    protected void fetchleavedetail()
    {
        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparm = new SqlParameter[4];

            sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparm[0].Value = txt_employee.Text.Trim().ToString();

            sqlparm[1] = new SqlParameter("@status", SqlDbType.Int, 4);
            sqlparm[1].Value = 1;

            sqlparm[2] = new SqlParameter("@fromdate", SqlDbType.DateTime, 8);
            sqlparm[2].Value = Common.Date.Utility.DateFormat(txt_sdate.Text);

            sqlparm[3] = new SqlParameter("@todate", SqlDbType.DateTime, 8);
            sqlparm[3].Value = Common.Date.Utility.DateFormat(txt_edate.Text);

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_holiday_showempreporte_audit]", sqlparm);
            grid_leave.DataSource = ds;
            grid_leave.DataBind();
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (grid_leave.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "HolidayReport" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < grid_leave.Rows.Count; i++)
            {
                grid_leave.Rows[i].Style.Add("width", "150px");
                grid_leave.Rows[i].Style.Add("height", "20px");
            }
            grid_leave.GridLines = GridLines.Both;
            grid_leave.HeaderStyle.Font.Bold = true;
            grid_leave.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        fetchleavedetail();

    }

    protected void grid_leave_PreRender(object sender, EventArgs e)
    {
        if (grid_leave.Rows.Count > 0)
            grid_leave.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}