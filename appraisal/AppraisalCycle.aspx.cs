using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using DataAccessLayer;

public partial class appraisal_AppraisalCycle : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        if (!IsPostBack)
        {
            bind_month();
            bindyear();
            bindgrid();
            BindFinYear();

            if (Request.QueryString["sno"] != null)
            {
                bind_appcycle();
            }

            if (Request.QueryString["inserted"] != null)
            {
                Output.Show("Submitted Successfully");
            }

            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Updated Successfully");
            }

            if (Request.QueryString["freze"] != null)
            {
                Output.Show("Cycle Freezed");
            }

            if (Request.QueryString["activate"] != null)
            {
                Output.Show("Cycle Activated");
            }

        }

    }

    protected void bind_appcycle()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            string str = @"select from_month,from_year,to_month,to_year,appcycle_id ,APP_year,quater from tbl_appraisal_cycle where appcycle_id=" + Request.QueryString["sno"];
            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Fmonth.SelectedItem.Text = ds.Tables[0].Rows[0]["from_month"].ToString();
                int fm = getmonthvalue(ds.Tables[0].Rows[0]["from_month"].ToString());
                ddl_Fmonth.SelectedItem.Value = fm.ToString();
                //ddl_From_Year.SelectedItem.Text = ds.Tables[0].Rows[0]["from_year"].ToString();
                ddl_From_Year.SelectedValue = ds.Tables[0].Rows[0]["from_year"].ToString();
                ddl_From_Year.Items[0].Enabled = false;

                ddlFinYear.SelectedValue = ds.Tables[0].Rows[0]["APP_year"].ToString();
                ddlFinYear.Items[0].Enabled = false;
                dd_Quater.SelectedValue = ds.Tables[0].Rows[0]["quater"].ToString();
                dd_Quater.Items[0].Enabled = false;


                ddl_Tmonth.SelectedItem.Text = ds.Tables[0].Rows[0]["to_month"].ToString();
                int tm = getmonthvalue(ds.Tables[0].Rows[0]["to_month"].ToString());
                ddl_Tmonth.SelectedItem.Value = tm.ToString();
                //ddl_To_Year.SelectedItem.Text = ds.Tables[0].Rows[0]["to_year"].ToString();
                ddl_To_Year.SelectedValue = ds.Tables[0].Rows[0]["to_year"].ToString();
                ddl_To_Year.Items[0].Enabled = false;

                btnsubmit.Text = "Update";
                btnreset.Text = "Cancel";
                lblhead.Text = "Edit";
                abc.Visible = false;
                //ddl_From_Year.Items.Remove("--Select--");
                //ddl_To_Year.Items.Remove("--Select--");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected int getmonthvalue(string month)
    {
        switch (month)
        {
            case "Jan": return 1;
            case "Feb": return 2;
            case "Mar": return 3;
            case "Apr": return 4;
            case "May": return 5;
            case "Jun": return 6;
            case "Jul": return 7;
            case "Aug": return 8;
            case "Sep": return 9;
            case "Oct": return 10;
            case "Nov": return 11;
            case "Dec": return 12;
            default: return 0;
        }
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            string str = @"select from_month,from_year,to_month,to_year,appcycle_id,status,freeze ,APP_year,quater from tbl_appraisal_cycle";
            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridappcycle.DataSource = ds;
                gridappcycle.DataBind();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void bind_month()
    {
        ddl_Fmonth.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_Tmonth.Items.Insert(0, new ListItem("--Select--", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            ddl_Fmonth.Items.Add(new ListItem(item.Text, item.Value));
            ddl_Tmonth.Items.Add(new ListItem(item.Text, item.Value));
        }
    }

    protected void bindyear()
    {
        ddl_From_Year.Items.Clear();
        ddl_To_Year.Items.Clear();
        ddl_From_Year.Items.Add(new ListItem("--Select--", "0"));
        ddl_To_Year.Items.Add(new ListItem("--Select--", "0"));
        for (int yr = 2012; yr <= DateTime.Now.Year + 4; yr++)
        {
            ddl_From_Year.Items.Add(new ListItem(Convert.ToString(yr)));
            ddl_To_Year.Items.Add(new ListItem(Convert.ToString(yr)));
        }
    }

    protected void BindFinYear()
    {
        string sql = "SELECT financial_year year FROM tbl_payroll_tax_master order by id desc";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sql);
        ddlFinYear.DataTextField = "year";
        ddlFinYear.DataValueField = "year";
        ddlFinYear.DataSource = ds;
        ddlFinYear.DataBind();
    }

    protected void reset()
    {
        ddl_Fmonth.SelectedValue = "0";
        ddl_From_Year.SelectedValue = "0";
        ddl_To_Year.SelectedValue = "0";
        ddl_Tmonth.SelectedValue = "0";
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string ddlFromdate = ddl_Fmonth.SelectedValue + "-" + ddl_From_Year.SelectedValue;
        string ddlTodate = ddl_Tmonth.SelectedValue + "-" + ddl_To_Year.SelectedValue;

        //if (Convert.ToDateTime(ddlFromdate) > Convert.ToDateTime(ddlTodate))
        //{
        //    Output.Show("Select Valid Month");
        //}
        //else
        //{
            if (Convert.ToInt32(ddl_From_Year.SelectedValue) == Convert.ToInt32(ddl_To_Year.SelectedValue))
            {
                if (Convert.ToInt32(ddl_Fmonth.SelectedValue) < Convert.ToInt32(ddl_Tmonth.SelectedValue))
                {
                    if (Request.QueryString["sno"] != null)
                    {
                        editapprasialcycle();
                        btnsubmit.Text = "Submit";
                    }
                    else
                    {
                        insertAppraisalCycle();
                    }
                    bindgrid();
                }
                else
                {
                    Output.Show("Select Valid Month");
                    ddl_Tmonth.Focus();
                }
            }
            if (Convert.ToInt32(ddl_From_Year.SelectedValue) != Convert.ToInt32(ddl_To_Year.SelectedValue))
            {
                if (Request.QueryString["sno"] != null)
                {
                    editapprasialcycle();
                    btnsubmit.Text = "Submit";
                }
                else
                {
                    insertAppraisalCycle();
                }
                bindgrid();
            }
        //}
    }

    protected void insertAppraisalCycle()
    {
        if (ddl_Fmonth.SelectedIndex != 0 && ddl_From_Year.SelectedIndex != 0 && ddl_Tmonth.SelectedIndex != 0 && ddl_To_Year.SelectedIndex != 0)
        {
            SqlParameter[] sqlParam = new SqlParameter[7];
            SqlConnection Connection = null;
            int Flag = 0;
            try
            {
                Output.AssignParameter(sqlParam, 0, "@from_month", "String", 3, ddl_Fmonth.SelectedItem.Text);
                Output.AssignParameter(sqlParam, 1, "@from_year", "String", 4, ddl_From_Year.SelectedItem.Text);
                Output.AssignParameter(sqlParam, 2, "@to_month", "String", 3, ddl_Tmonth.SelectedItem.Text);
                Output.AssignParameter(sqlParam, 3, "@to_year", "String", 4, ddl_To_Year.SelectedItem.Text);
                Output.AssignParameter(sqlParam, 4, "@create_by", "String", 50, Session["empcode"].ToString());
                Output.AssignParameter(sqlParam, 5, "@APP_year", "String", 50, ddlFinYear.SelectedItem.Text);
                Output.AssignParameter(sqlParam, 6, "@quater", "String", 10, dd_Quater.SelectedValue);

                Connection = DataActivity.OpenConnection();
                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "[sp_appraisal_insert_appraisalcycle]", sqlParam);
                if (Flag <= 0)
                {
                    Output.Show("Appraisal Cycle is already exists or Freezed. please enter another Appraisal Cycle name");
                }
                else
                {
                    Response.Redirect("AppraisalCycle.aspx?inserted=true");
                }
            }
            catch (Exception ex)
            {
                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                DataActivity.CloseConnection();
            }
        }
        else
        {
            Output.Show("Please Select Month & Year");
        }


    }

    protected void editapprasialcycle()
    {

        SqlParameter[] sqlParam = new SqlParameter[8];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["sno"]);
            Output.AssignParameter(sqlParam, 0, "@from_month", "String", 3, ddl_Fmonth.SelectedItem.Text);
            Output.AssignParameter(sqlParam, 1, "@from_year", "String", 4, ddl_From_Year.SelectedItem.Text);
            Output.AssignParameter(sqlParam, 2, "@to_month", "String", 3, ddl_Tmonth.SelectedItem.Text);
            Output.AssignParameter(sqlParam, 3, "@to_year", "String", 4, ddl_To_Year.SelectedItem.Text);
            Output.AssignParameter(sqlParam, 4, "@update_by", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlParam, 5, "@appcycle_id", "Int", 0, id.ToString());
            Output.AssignParameter(sqlParam, 6, "@APP_year", "String", 50, ddlFinYear.SelectedValue);
            Output.AssignParameter(sqlParam, 7, "@quater", "String", 10, dd_Quater.SelectedValue);

            Connection = DataActivity.OpenConnection();

            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "[sp_apprasial_updateapprasialcycle]", sqlParam);

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }

        if (Flag <= 0)
        {
            Output.Show("Appraisal Cycle is already exists or Freeze.please enter another Appraisal Cycle name");
        }
        else
        {
            Response.Redirect("AppraisalCycle.aspx?updated=true");
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        btnreset.Text = "Cancel";
        {
            Response.Redirect("AppraisalCycle.aspx");
        }
        reset();
    }

    protected void gridappcycle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            int id = (int)gridappcycle.DataKeys[e.RowIndex].Value;
            Output.AssignParameter(sqlParam, 0, "@appcycle_id", "Int", 0, id.ToString());
            Connection = DataActivity.OpenConnection();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_activeappraisalcycle", sqlParam);
           
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
            if (Flag > 0)
            {
                //Output.Show("Appraisal Cycle Activated Successfully");
                Response.Redirect("AppraisalCycle.aspx?activate=true");
            }
            else
            {
                Output.Show("Appraisal Cycle Already Activated");
            }
        }
        //if (Flag > 0)
        //{
        //    Output.Show("Appraisal Cycle Activated Successfully");
        //    bindgrid();
        //}
        //else
        //{
        //    Output.Show("Appraisal Cycle Already Activated");
        //}
    }

    protected void gridappcycle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridappcycle.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void lnkEdit_Command(object sender, CommandEventArgs e)
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(e.CommandArgument);

            Output.AssignParameter(sqlParam, 0, "@apc_id", "Int", 0, id.ToString());
            Connection = DataActivity.OpenConnection();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_Closeappraisalcycle", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
            if (Flag > 0)
            {
                Response.Redirect("AppraisalCycle.aspx?freze=true");
            }
            else
            {
                Output.Show("Appraisal Cycle  Not CLosed. Please check, the employee(s) assessments to be approved");
            }
        }
    }

    protected void gridappcycle_PreRender(object sender, EventArgs e)
    {
        if (gridappcycle.Rows.Count > 0)
        {
            gridappcycle.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void ddl_From_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddl_From_Year.SelectedValue) > DateTime.Now.Year)
        {
            Output.Show("Select Valid Year");
            ddl_From_Year.Focus();
        }
        else
        {
            if (ddl_To_Year.SelectedValue != "0")
            {
                if (Convert.ToInt32(ddl_To_Year.SelectedValue) < Convert.ToInt32(ddl_From_Year.SelectedValue))
                {
                    Output.Show("Select Valid Year");
                    ddl_To_Year.Focus();
                }
            }
        }
    }

    protected void ddl_To_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_Fmonth.SelectedValue != "0")
        //{
            if (ddl_From_Year.SelectedValue != "0")
            {
                if (Convert.ToInt32(ddl_To_Year.SelectedValue) < Convert.ToInt32(ddl_From_Year.SelectedValue))
                {
                    Output.Show("Select Valid Year");
                    ddl_To_Year.Focus();
                }
            }
            else
            {
                Output.Show("Select From Year");
                ddl_From_Year.Focus();
            }
        //}
        //else
        //{
        //    Output.Show("Enter From Month");
        //    ddl_Fmonth.Focus();
        //}
    }

    protected void gridappcycle_DataBound(object sender, EventArgs e)
    {

    }
}