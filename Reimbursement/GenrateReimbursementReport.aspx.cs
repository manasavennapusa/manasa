using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Encode;
using Common.Data;
using Common.Console;
using System.IO;
using System.Web.UI;
using System.Web;

public partial class Reimbursement_GenrateReimbursementReport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            drpdepartment.Items.Insert(0, new ListItem("--Select--", "0"));
            drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
            drpbranch.Items.Insert(0, new ListItem("--Select--", "0"));
            bindempdetail();
        }




    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }
    #region Bind Department
    protected void bind_departmnt(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails";
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
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid +" order by designationname";
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
    #endregion
    protected void bindempdetail()
    {
        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@worklocation", SqlDbType.Int);
            sqlparam[0].Value = drpbranch.SelectedValue;

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = drpdegination.SelectedValue;

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = drpdepartment.SelectedValue;

            sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (txtfromdate.Text == "")
                sqlparam[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
            else
                sqlparam[3].Value = txtfromdate.Text;

            sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (txttodate.Text == "")
                sqlparam[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
            else
                sqlparam[4].Value = txttodate.Text;


            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_reimbursement_report", sqlparam);
            Reimgrid.DataSource = ds;
            Reimgrid.DataBind();
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
        drpdepartment.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void Reimgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int a = (int)Reimgrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("createemployeeprofile.aspx?approvercode=" + Request.QueryString["approvercode"] + "");

    }
    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected string linkreset(string id)
    {
        QueryString q = new QueryString();
        string pairs = String.Format("empcode={0}", id.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a class='link05' href='ResetPassword.aspx?q=" + encoded + "' >Reset</a>";
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {

        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@worklocation", SqlDbType.Int);
            sqlparam[0].Value = drpbranch.SelectedValue;

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = drpdegination.SelectedValue;

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = drpdepartment.SelectedValue;

            sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (txtfromdate.Text == "")
                sqlparam[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
            else
                sqlparam[3].Value = txtfromdate.Text;

            sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (txttodate.Text == "")
                sqlparam[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
            else
                sqlparam[4].Value = txttodate.Text;


            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_reimbursement_report", sqlparam);
            Reimgrid.DataSource = ds;
            Reimgrid.DataBind();


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReimbursementReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //string filename = "attachment ;filename = ReimbursementReport.xls";
            //Response.Write(filename);
            //Response.AddHeader("content-disposition", filename);
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
            DataGrid dg = new DataGrid();
            dg.DataSource = ds;
            dg.DataBind();
            String style = @"<style>.text{mso-number-format:\@;}</style>";
            HttpContext.Current.Response.Write(style);
            int colindex = 0;
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                string valuetype = dc.DataType.ToString();
                foreach (DataGridItem i in dg.Items)
                    i.Cells[colindex].Attributes.Add("class", "text");
                colindex++;
            }

            dg.RenderControl(htmlwrite);
            Response.Write(stringWrite.ToString());
            Response.End();
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
        //exportexcel();
    }

    //***********************This Method is commented by Irshad bcz It was not working properly*********************************//
    protected void exportexcel()
    {
        if (Reimgrid.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReimbursementReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                Reimgrid.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in Reimgrid.HeaderRow.Cells)
                {
                    cell.BackColor = Reimgrid.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Reimgrid.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Reimgrid.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Reimgrid.RowStyle.BackColor;
                        }
                        cell.Height = 14;
                    }
                }

                Reimgrid.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }



}
