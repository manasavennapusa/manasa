using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.IO;

public partial class leave_User_Year_Ending_Report : System.Web.UI.Page
{
    string strsql;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null && Session["empcode"] == null)
                Response.Redirect("~/notlogged.aspx");

        }
    }


    protected void empleavegrid_PreRender(object sender, EventArgs e)
    {
        if (empleavegrid.Rows.Count > 0)
            empleavegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (empleavegrid.Rows.Count > 0)
        {
            // Hides the first column in the grid (zero-based index)
            //  empleavegrid.HeaderRow.Cells[6].Visible = false;

            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < empleavegrid.Rows.Count; i++)
            {
                GridViewRow row = empleavegrid.Rows[i];
                //   row.Cells[6].Visible = false;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "LeaveReport" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < empleavegrid.Rows.Count; i++)
            {

                empleavegrid.Rows[i].Style.Add("width", "150px");
                empleavegrid.Rows[i].Style.Add("height", "20px");
            }

            empleavegrid.GridLines = GridLines.Both;
            empleavegrid.HeaderStyle.Font.Bold = true;
            empleavegrid.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (Ddl_Calender_Year.SelectedValue != "0")
        {
            connection = activity.OpenConnection();
            
            try
            {
                  strsql = @" select 
                        Cp.policyname,
                        Cl.leavetype,
                        UE.CarrriedForward,
                        UE.empcode,
                        UE.EmpName,
                        UE.EncashedLeaves,
                        UE.LapsedLeaves,
                        UE.OpeningBalance
                         from tbl_leave_Upload_year_Ending UE inner join tbl_leave_createleavepolicy Cp on
                        UE.policyid = Cp.policyid inner join tbl_leave_createleave Cl on UE.leaveid = Cl.leaveid 
                        inner join tbl_leave_employee_hierarchy EH on EH.employeecode = UE.empcode
						where EH.employeecode = '" + Session["empcode"].ToString() + "' and UE.Calenderid= " + Ddl_Calender_Year.SelectedValue;
                

                ds = SQLServer.ExecuteDataset(connection, CommandType.Text, strsql);
                empleavegrid.DataSource = ds;
                empleavegrid.DataBind();
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
        else
        {
            Output.Show("Please Select Calender Year !!");
        }
    }
    protected void Ddl_Calender_Year_DataBound(object sender, EventArgs e)
    {
        Ddl_Calender_Year.Items.Insert(0, new ListItem("Select", "0"));
    }
}