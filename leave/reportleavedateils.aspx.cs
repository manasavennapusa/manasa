using System;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Web.UI;
using System.Web;


public partial class leave_reportleavedateils : System.Web.UI.Page
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
            drpdepartment.Items.Insert(0, new ListItem("All", "0"));
            drpdegination.Items.Insert(0, new ListItem("All", "0"));

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


    protected void bindempdetail()
    {
        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
            sqlparam[0].Value = txt_employee.Text.Trim();

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = drpdegination.SelectedValue;

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = drpdepartment.SelectedValue;

            sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
            sqlparam[3].Value = "All";

            sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
            sqlparam[4].Value = drpbranch.SelectedValue;

            //ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_emp_detail1", sqlparam);
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_leavebalance", sqlparam);
            empgrid.DataSource = ds;
            empgrid.DataBind();
            Txt_Search.Text = "";
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

    protected void btn_search_click(object sender, EventArgs e)
    {
        bindempdetail();
    }

   

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    
    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Leave Balance Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < empgrid.Rows.Count; i++)
            {

                empgrid.Rows[i].Style.Add("width", "150px");
                empgrid.Rows[i].Style.Add("height", "20px");
            }
     
                empgrid.GridLines = GridLines.Both;
                empgrid.HeaderStyle.Font.Bold = true;
                empgrid.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
         
        }
    }

    protected void Txt_Search_TextChanged(object sender, EventArgs e)
    {
        //connection = activity.OpenConnection();
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Txt_Search.Text;
        DataSet ds100 = SQLServer.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.StoredProcedure, "sp_leave_fetch_leavebalanceForSearch", sqlparam);
        empgrid.DataSource = ds100;
        empgrid.DataBind();
        Txt_Search.Text = "";
    }
}