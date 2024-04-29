using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Collections;


public partial class appraisal_EligibleEmployees : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string _companyId, _userCode, RoleId;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
       
        if (!IsPostBack)
        {
           // bindempdetail("", "0");
        }
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();
    }

    protected void Dropappcycle_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindempdetail("", "0");
    }


    private void getActiveCycle()
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {

            string str1 = @"select count(*) from tbl_appraisal_cycle ";
            Connection = DataActivity.OpenConnection();
            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str1);
            if (cnt > 0)
            {
                int cycle = (int)SQLServer.ExecuteScalar(Connection, CommandType.StoredProcedure, "sp_appraisal_getapprisalcycle");
                if (cycle != 0)
                {
                    ViewState["appcycle"] = cycle;
                    bindempdetail("", "0");
                }
                else
                {
                    Output.Show("Please Mark Active Appraisal Cycle");
                }
            }
            else
            {
                Output.Show("Please Create Appraisal Cycle");
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



    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("------ All ------", "0"));
    }
    protected void dd_dpt_DataBound(object sender, EventArgs e)
    {
        dd_dpt.Items.Insert(0, new ListItem("--All--", "0"));
    }

    //protected void dd_grade_DataBound(object sender, EventArgs e)
    //{
    //    dd_grade.Items.Insert(0, new ListItem("----- All -----", "0"));
    //}

    protected void bindempdetail(string emp, string dept)
    {
        SqlConnection Connection = null;
        SqlParameter[] sqlParam = new SqlParameter[5];
        //string cycle=ViewState["appcycle"].ToString();
        string cycle = Dropappcycle_id.SelectedValue;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@name", "String", 150, emp);
            Output.AssignParameter(sqlParam, 1, "@desg", "Int", 0, "0");
            Output.AssignParameter(sqlParam, 2, "@department", "Int", 0, dept);
            Output.AssignParameter(sqlParam, 3, "@status", "String", 50, "All");
            //Output.AssignParameter(sqlParam, 4, "@branch", "Int", 0, "0");
            //Output.AssignParameter(sqlParam, 5, "@grade", "Int", 100, grade);
            Output.AssignParameter(sqlParam, 4, "@apc_id", "Int", 100, cycle);

            Connection = DataActivity.OpenConnection();
            ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_fetch_emp_detail", sqlParam);
            empgrid.DataSource = ds;
            empgrid.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                btnselect.Visible = true;
                btnreset.Visible = true;
                trbuttons.Visible = true;
                empgrid.Visible = true;
            }
            else
            {
                btnselect.Visible = false;
                btnreset.Visible = false;
                trbuttons.Visible = false;
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

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail(txt_employee.Text, dd_dpt.SelectedValue);

    }

    private void SaveCheckedValues()
    {
        ArrayList userdetails = new ArrayList();
        int index = -1;
        foreach (GridViewRow gvrow in empgrid.Rows)
        {
            string empcode = (string)empgrid.DataKeys[gvrow.RowIndex].Value;
            index = Convert.ToInt32(empcode);
            bool result = ((CheckBox)gvrow.FindControl("chkSelect")).Checked;

            // Check in the ViewState
            if (ViewState["CHECKED_ITEMS"] != null)
                userdetails = (ArrayList)ViewState["CHECKED_ITEMS"];
            if (result)
            {
                if (!userdetails.Contains(index))
                    userdetails.Add(index);
            }
            else
                userdetails.Remove(index);
        }
        if (userdetails != null && userdetails.Count > 0)
            ViewState["CHECKED_ITEMS"] = userdetails;
    }

    private void PopulateCheckedValues()
    {
        ArrayList userdetails = (ArrayList)ViewState["CHECKED_ITEMS"];
        if (userdetails != null && userdetails.Count > 0)
        {
            foreach (GridViewRow gvrow in empgrid.Rows)
            {
                string empcode = (string)empgrid.DataKeys[gvrow.RowIndex].Value;
                int index = Convert.ToInt32(empcode);
                if (userdetails.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)gvrow.FindControl("chkSelect");
                    myCheckBox.Checked = true;
                }
            }
        }
    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail(txt_employee.Text, dd_dpt.SelectedValue);
    }


    protected void btnselect_Click(object sender, EventArgs e)
    {
        GetSelectedRows();
        BindSecondGrid();
    }

    private void GetSelectedRows()
    {
        DataTable dt;
        if (ViewState["GetRecords"] != null)
            dt = (DataTable)ViewState["GetRecords"];
        else
            dt = CreateTable();
        for (int i = 0; i < empgrid.Rows.Count; i++)
        {
            //CheckBox chk = (CheckBox)empgrid.HeaderRow.FindControl("empgrid_chkSelectAll");
                CheckBox chk = (CheckBox)empgrid.Rows[i].Cells[4].FindControl("chkSelect");               

                if (chk.Checked)
                {
                    Label lb = (Label)empgrid.Rows[i].Cells[0].FindControl("lblempcode");

                    dt = AddGridRow(empgrid.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(empgrid.Rows[i], dt);
                }
            
            
        }
        ViewState["GetRecords"] = dt;
    }

    private DataTable CreateTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("empcode");
        dt.Columns.Add("name");
        dt.Columns.Add("department_name");
        dt.Columns.Add("emp_doj");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddGridRow(GridViewRow gvRow, DataTable dt)
    {
        Label lbl = (Label)gvRow.Cells[0].FindControl("lblempcode");
        DataRow[] dr = dt.Select("empcode = '" + lbl.Text + "'");

        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            int rowscount = dt.Rows.Count - 1;
            Label lb = (Label)gvRow.Cells[0].FindControl("lblempcode");
            Label l2 = (Label)gvRow.Cells[1].FindControl("l2");
            Label l3 = (Label)gvRow.Cells[2].FindControl("l3");
            Label l4 = (Label)gvRow.Cells[2].FindControl("l1");
            dt.Rows[rowscount]["empcode"] = lb.Text;
            dt.Rows[rowscount]["name"] = l2.Text;
            dt.Rows[rowscount]["department_name"] = l3.Text;
            dt.Rows[rowscount]["emp_doj"] = l4.Text;
            dt.AcceptChanges();
        }
        return dt;

    }
    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        Label lbl = (Label)gvRow.Cells[0].FindControl("lblempcode");
        DataRow[] dr = dt.Select("empcode = '" + lbl.Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }
    protected void BindSecondGrid()
    {
        DataTable dt = (DataTable)ViewState["GetRecords"];
        empgrid2.DataSource = dt;
        empgrid2.DataBind();
        if (dt.Rows.Count > 0)
        {
            btnSave.Visible = true;
             btnCancel.Visible = true;
        }
        else
        {
            btnSave.Visible = false;
             btnCancel.Visible = false;
        }
    }


    protected void empgrid2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid2.PageIndex = e.NewPageIndex;
        DataTable dt = (DataTable)ViewState["GetRecords"];
        empgrid2.DataSource = dt;
        empgrid2.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            ViewState["appcycle"] = Dropappcycle_id.SelectedValue;
          
            if (Dropappcycle_id.SelectedValue != null)
            {
                string saved = "", notsaved = "";

                SqlParameter[] sqlParam = new SqlParameter[3];
                Output.AssignParameter(sqlParam, 0, "@appcycleid", "Int", 0, ViewState["appcycle"].ToString());
                string a = ViewState["appcycle"].ToString();
                if (empgrid2.Rows.Count > 0)
                {
                    Connection = DataActivity.OpenConnection();
                    foreach (GridViewRow row in empgrid2.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                        if (chk.Checked)
                        {
                            Label emp = (Label)row.FindControl("lblemp");
                            string createdby = _userCode.ToString();
                            Output.AssignParameter(sqlParam, 1, "@empcode", "String", 50, emp.Text);
                            Output.AssignParameter(sqlParam, 2, "@create_by", "String", 50, createdby);

                            int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_elegible_emp", sqlParam);

                            if (i > 0)
                            {
                                saved = saved + " " + emp.Text;
                                DataTable dt;
                                dt = (DataTable)ViewState["GetRecords"];
                                dt = RemoveRowSecond(row, dt);
                                ViewState["GetRecords"] = dt;
                            }
                            else
                                notsaved = notsaved + " " + emp.Text;
                            // empgrid2.DeleteRow(this.G);
                        }
                    }
                    if (notsaved.Trim() == "" && saved.Trim() == "")
                        Output.Show("Please Select Employees");

                    if (notsaved.Trim() == "" && saved.Trim() != "")
                        Output.Show("Selected Employees are Successfully Saved.");
                    else
                    {
                        string alert = "";
                        if (notsaved.Trim() != "")
                            alert = "[ " + notsaved + " ] Employee(s) are already exists.    ";
                        if (saved.Trim() != "")
                            alert = alert + "[ " + saved + " ]  Employee(s) are Successfully Saved.";

                        Output.Show(alert);
                    }
                }
                else
                {
                    Output.Show("Please Select Employees");
                }
            }
            else
            {
                Output.Show("Please Create Appraisal Cycle");
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
        BindSecondGrid();
        bindempdetail("", "0");
    }

    protected void btnInitiateAprasial_Click(object sender, EventArgs e)
    {
        ////SqlConnection Connection = null;
        ////int Flag = 0;
        ////try
        ////{

        ////    if (ViewState["appcycle"] != null)
        ////    {
        ////        SqlParameter[] sqlparam = new SqlParameter[3];
        ////        sqlparam[0] = new SqlParameter("@appcycleid", SqlDbType.Int);
        ////        sqlparam[0].Value = Convert.ToInt32(ViewState["appcycle"]);
        ////        if (empgrid2.Rows.Count > 0)
        ////        {
        ////            Connection = DataActivity.OpenConnection();
        ////            foreach (GridViewRow row in empgrid2.Rows)
        ////            {
        ////                Label emp = (Label)row.FindControl("lblemp");
        ////                string createdby = ViewState["empcode"].ToString();
        ////                sqlparam[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        ////                sqlparam[1].Value = emp.Text;
        ////                sqlparam[2] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
        ////                sqlparam[2].Value = createdby;
        ////                string str = @"select COUNT(*) from tbl_appraisal_eligibilitylist where empcode=" + emp.Text + " and appcycleid=" + Convert.ToInt32(ViewState["appcycle"]) + " and initiate=1";
        ////                int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str);
        ////                if (cnt == 0)
        ////                {
        ////                    int res = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_initiatelegibilitylist", sqlparam);
        ////                    if (res > 0)
        ////                    {
        ////                        Output.Show("Record Saved Successfully");
        ////                    }
        ////                    string sqlstr = @"select corporatereportingcode from tbl_intranet_employee_jobDetails where empcode='" + emp.Text + "'";

        ////                    DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
        ////                    if (ds1.Tables[0].Rows.Count >= 1)
        ////                    {
        ////                        sendMail(emp.Text);
        ////                    }
        ////                    Output.Show("Record Saved Successfully");
        ////                }
        ////                else
        ////                {
        ////                    Output.Show("Appraisal Already Initiate ");
        ////                }
        ////            }
        ////        }
        ////    }
        ////    else
        ////    {
        ////        Output.Show("Please Create Appraisal Cycle");
        ////    }
        //}
        //catch (Exception ex)
        //{
        //    Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //    Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        //}
        //finally
        //{
        //    DataActivity.CloseConnection();
        //}
    }

    protected void sendMail(string empcode)
    {

        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            string qry = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + empcode + "'";
            string sqlstr = @"select e.empcode,e.official_email_id,e.emp_fname+' ' +e.emp_m_name+' ' +e.emp_l_name as empname,j.emp_fname+' ' +j.emp_m_name+' ' +j.emp_l_name as mgrname,j.empcode as mgrcode,j.official_email_id as mgrid from tbl_intranet_employee_jobDetails e,
                            tbl_intranet_employee_jobDetails j  where e.corporatereportingcode=j.empcode and e.empcode='" + empcode + "'";
            Connection = DataActivity.OpenConnection();
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                string subject = ConfigurationManager.AppSettings["subject"].ToString();
                string bodyContent = ConfigurationManager.AppSettings["bodyContent"].ToString();
                string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
                Email.getemailwithcc(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), ds1.Tables[0].Rows[0]["mgrid"].ToString(), "", subject, completeBody, smtp, emailLogo);
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //ViewState["GetRecords"] = null;
        //empgrid2.DataSource = null;
        //empgrid2.DataBind();
        //empgrid.DataSource = null;
        //empgrid.DataBind();
        //empgrid.Visible = false;
        //btnselect.Visible = false;
        //btnreset.Visible = false;
        //trbuttons.Visible = false;

        Response.Redirect("EligibleEmployees.aspx");
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        RemoveSelectedRows();
        BindSecondGrid();
    }

    private void RemoveSelectedRows()
    {
        DataTable dt;
        dt = (DataTable)ViewState["GetRecords"];
        for (int i = 0; i < empgrid2.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)empgrid2.Rows[i].Cells[4].FindControl("chkSelect");
            if (chk.Checked)
            {
                Label lb = (Label)empgrid2.Rows[i].Cells[0].FindControl("lblemp");
                dt = RemoveRowSecond(empgrid2.Rows[i], dt);
            }
        }
        ViewState["GetRecords"] = dt;
    }

    private DataTable RemoveRowSecond(GridViewRow gvRow, DataTable dt)
    {
        Label lbl = (Label)gvRow.Cells[0].FindControl("lblemp");
        DataRow[] dr = dt.Select("empcode = '" + lbl.Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }


    protected void empgrid2_chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)empgrid2.HeaderRow.FindControl("empgrid2_chkSelectAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in empgrid2.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in empgrid2.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }
    protected void empgrid_chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)empgrid.HeaderRow.FindControl("empgrid_chkSelectAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in empgrid.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in empgrid.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }
    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void empgrid2_PreRender(object sender, EventArgs e)
    {
        if (empgrid2.Rows.Count > 0)
            empgrid2.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void Dropappcycle_id_DataBound(object sender, EventArgs e)
    {
        Dropappcycle_id.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}