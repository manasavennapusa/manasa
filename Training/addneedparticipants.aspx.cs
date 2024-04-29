using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Encode;
using Common.Data;
using Common.Console;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using DataAccessLayer;
using System.IO;

public partial class training_addneedparticipants : System.Web.UI.Page
{
    //string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    SqlConnection Connection = null;
    string sqlstr, _userCode, _companyId, RoleId;
    string  fromdate, todate, Faculty, modulename, modulenamess ,dept_name;
    int tid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            tid = Convert.ToInt16(Request.QueryString["id"]);

            fromdate = Request.QueryString["FromDate"].ToString();
           string dept_namea = Request.QueryString["dept_name"].ToString();
            todate = Request.QueryString["ToDate"].ToString();
            Faculty = Request.QueryString["Faculty"].ToString();
            modulename = Request.QueryString["module_name"].ToString();
            if (!IsPostBack)
            {
                bind_branch();
                bind_addneedparticipants();
                drpdepartment.Items.Insert(0, new ListItem("All", "0"));
                //trainingid.Items.Insert(0, new ListItem("All", "0"));
                dept_type.Items.Insert(0, new ListItem("All", "0"));
                //drpcode.Items.Insert(0, new ListItem("All", "0"));
                if (Request.QueryString["del"] != null)
                {
                    Output.Show("Deleted Successfully");
                }
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {     
      
        int Flag = 0;
        try
        {
            //if (Session["appcycle"] != null)
            {
                string saved = "", notsaved = "";

                SqlParameter[] sqlParam = new SqlParameter[1];
                //Output.AssignParameter(sqlParam, 0, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
                //string a = Session["appcycle"].ToString();
                if (Grid_Addparticipants.Rows.Count > 0)
                {
                    Connection = activity.OpenConnection();
                    foreach (GridViewRow row in Grid_Addparticipants.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                        if (chk.Checked)
                        {
                            Label emp = (Label)row.FindControl("l0");
                            //Label training_code = (Label)row.FindControl("l1");
                            //Label training_name = (Label)row.FindControl("l2");
                            //Label emp_fname = (Label)row.FindControl("l3");
                            //Label designationname = (Label)row.FindControl("l4");
                            //Label department_name = (Label)row.FindControl("l5");
                            //Label branch_name = (Label)row.FindControl("l6");
                            //Label trining_id = (Label)row.FindControl("l7");
                            //string createdby = Session["empcode"].ToString();
                            Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, emp.Text);
                            //Output.AssignParameter(sqlParam, 1, "@training_code", "String", 50, training_code.Text);
                            //Output.AssignParameter(sqlParam, 2, "@training_name", "String", 100, training_name.Text);
                            //Output.AssignParameter(sqlParam, 3, "@emp_fname", "String", 50, emp_fname.Text);
                            //Output.AssignParameter(sqlParam, 4, "@designationname", "String", 100, designationname.Text);
                            //Output.AssignParameter(sqlParam, 5, "@department_name", "String", 50, department_name.Text);
                            //Output.AssignParameter(sqlParam, 6, "@branch_name", "String", 50, branch_name.Text);
                            //Output.AssignParameter(sqlParam, 7, "@create_by", "String", 50, createdby);
                            //Output.AssignParameter(sqlParam, 8, "@trining_id", "Int", 0, trining_id.Text);

                            int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_training_insert_hrschedule", sqlParam);

                        
                            if (i > 0)
                            {

                                //sendmail(emp.Text);
                                saved = saved + " " + emp.Text;
                                DataTable dt;
                                dt = (DataTable)ViewState["GetRecords"];
                                //dt = RemoveRowSecond(row, dt);
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
            //else
            //{
            //    Output.Show("Please Create Appraisal Cycle");
            //}
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            bind_addneedparticipants();
            clear();
            activity.CloseConnection();

        }
       
    }

    private void clear()
    {
        bind_addneedparticipants();
    }

    //private void sendmail(string emp)
    //{
    //    try
    //    {
    //        //DataSet ds = (DataSet)ViewState["EmpBrt"];
    //        //DataSet ds13 = SQLServer.ExecuteDataset(_Connection, CommandType.StoredProcedure, "CurentDay");
    //        //DataSet dsSent = SQLServer.ExecuteDataset(connection, CommandType.Text, "select empcode, bdate from emp_birtday_email");
    //        sqlstr = "select official_email_id,empcode,emp_fname from dbo.tbl_intranet_employee_jobDetails where empcode='" + emp + "'";
    //        DataSet ds1 = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
    //        //DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        for (int i = 0; i <= ds1.Tables[0].Rows.Count; i++)
    //        {
    //            // if (ds.Tables[0].Rows[i]["dob"].ToString() == ds13.Tables[0].Rows[0]["Date"].ToString() && ds.Tables[0].Rows[i]["Occasion"].ToString() == "Birthday")
    //            //if (ds1.Tables[0].Rows[i]["official_email_id"].ToString() == "official_email_id")
    //            //{
    //            string clientemail = ds1.Tables[0].Rows[i]["official_email_id"].ToString();
    //                string employeecode = ds1.Tables[0].Rows[i]["empcode"].ToString();
    //                string empname = ds1.Tables[0].Rows[i]["emp_fname"].ToString();
    //                //DataRow[] isSentRows = ds.Tables[0].Select("empcode=" + ds.Tables[0].Rows[i]["empcode"] + " and bdate='" + System.DateTime.Now.ToShortDateString() + "'");
    //                //DataRow[] isSentRows=ds1.Tables[0].Select("empcode="+ds.Tables[0].Rows[i]["empcode"]+"");
    //                //if (isSentRows.Length <= 0)
    //                //{
    //                    try
    //                    {
    //                        //Sendmail(ds.Tables[0].Rows[i]["empcode"].ToString());
    //                        SendmailBirthday(clientemail, employeecode, empname);

    //                        //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, "insert into emp_birtday_email (empcode,bdate) values ('" + ds.Tables[0].Rows[i]["empcode"] + "','" + System.DateTime.Now.ToShortDateString() + "')");
    //                    }
    //                    catch
    //                    {

    //                    }
    //               // }                

    //        }
    //    }
    //    catch
    //    {
    //    }
    //}

    //protected void SendmailBirthday(string clientemail, string empcode, string empname)
    //{
    //    try
    //    {


    //        string body = "Dear " + empname + "," + "\n" + "\n";
    //        body += "Wishing you many happy returns of the day " + "\n";
    //        body += "and wishing for many more to come!!" + "\n" + "\n " + "\n";
    //        body += "Regards" + "," + "\n";
    //        body += "AB Mauri India - HR Team" + "\n";
    //        body += "abmauriapps.in/HRMS";
    //        var smtp = new System.Net.Mail.SmtpClient();
    //        {
    //            smtp.Host = "smtp.gmail.com";
    //            smtp.Port = 25;
    //            smtp.EnableSsl = true;
    //            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    //            smtp.Credentials = new NetworkCredential("maruthimca47@gmail.com", "90601982961");
    //            //smtp.Timeout = 3000;

    //        }
    //        ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)    // Code given By Siddharth to avoid "The remote certificate is invalid according to the validation procedure"
    //        {
    //            return true;
    //        };
    //        smtp.Send("maruthimca47@gmail.com", clientemail, "Wishes From Company ", body);


    //    }

    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("{0} Exception caught.", ex);
    //    }
    //}
 
    protected void btn_back_Click(object sender, EventArgs e)
    {

    }

    protected void bind_addneedparticipants()
    {

        try
        {
            Connection = activity.OpenConnection();

            string strng = @"select module_name,dept_name from tbl_training_schedul where id='" + tid + "'";
            DataSet dsInsertedEmps = SQLServer.ExecuteDataset(connection, CommandType.Text, strng);
            if (dsInsertedEmps.Tables[0].Rows.Count < 1)
            {
                return;
            }
            else
            {
                modulenamess = dsInsertedEmps.Tables[0].Rows[0]["module_name"].ToString();
                dept_name = dsInsertedEmps.Tables[0].Rows[0]["dept_name"].ToString();
            }
            //sqlstr = "select jd.empcode,coalesce(jd.emp_fname,jd.emp_m_name,jd.emp_l_name)as name,jd.location,db.department_name,de.designationname from tbl_intranet_employee_jobDetails jd inner join tbl_internate_departmentdetails db on db.departmentid=jd.dept_id inner join tbl_intranet_designation de on de.id=jd.degination_id";
//            sqlstr = @"select distinct elgbl_emp.id,elgbl_emp.empcode,elgbl_emp.emp_fname,elgbl_emp.department_name,elgbl_emp.training_name,
//elgbl_emp.training_code,elgbl_emp.branch_name,elgbl_emp.trining_id,trn_sdl.module_name  ,
//CONVERT(varchar(40),trn_sdl.fromdate,106) as FromDate,CONVERT(varchar(40),trn_sdl.todate,106) as ToDate
//from tbl_training_elegible_emp elgbl_emp
//inner join tbl_training_schedul trn_sdl on elgbl_emp.training_code=trn_sdl.training_code
//where elgbl_emp.status=1";
            sqlstr = @"select distinct el_emp.empcode, el_emp.id,el_emp.emp_fname,el_emp.designationname,el_emp.department_name,dep.departmentid,
el_emp.designationname,el_emp.create_by,el_emp.training_code,el_emp.training_name,el_emp.trining_id,el_emp.status,
(Convert (varchar(40),el_emp.fromdate,106)) as FromDate,(Convert (varchar(40),el_emp.todate,106)) as ToDate,el_emp.modulename
from tbl_training_elegible_emp el_emp
inner join tbl_training_schedul ts on ts.training_code=el_emp.training_code
inner join tbl_internate_departmentdetails db on db.departmentid=ts.dept_name
inner join tbl_internate_departmentdetails dep on dep.department_name=el_emp.department_name
where el_emp.status=1  and el_emp.modulename='" + modulenamess + "' and dep.departmentid='" + dept_name + "'  and  el_emp.fromdate='" + fromdate + "' and el_emp.todate='" + todate + "'";

            DataSet ds1 = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 1)
            {
                return;
            }

            Grid_Addparticipants.DataSource = ds1;
            Grid_Addparticipants.DataBind();
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

    protected void Grid_Addparticipants_PreRender(object sender, EventArgs e)
    {
        if (Grid_Addparticipants.Rows.Count > 0)
        {
            Grid_Addparticipants.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
   
    protected void Grid_Addparticipants_chkSelectAll_CheckedChanged1(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)Grid_Addparticipants.HeaderRow.FindControl("Grid_Addparticipants_chkSelectAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in Grid_Addparticipants.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in Grid_Addparticipants.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }

    private void bind_branch()
    {

        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select branch_id,branch_name from tbl_intranet_branch_detail";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpbranch.DataTextField = "branch_name";
            drpbranch.DataValueField = "branch_id";
            drpbranch.DataSource = ds1;
            drpbranch.DataBind();
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

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {

        bind_departmenttype(Convert.ToInt16(drpbranch.SelectedValue));

    }

    private void bind_departmenttype(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type WHERE branch_id='" + branchid + "' order by dept_type_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            dept_type.DataTextField = "dept_type_name";
            dept_type.DataValueField = "dept_type_id";
            dept_type.DataSource = ds1;
            dept_type.DataBind();
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

    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dept_type_DataBound(object sender, EventArgs e)
    {
        dept_type.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dept_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(dept_type.SelectedValue));
    }

    private void bind_departmnt(int dept_type)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails where dept_type_id='" + dept_type + "' order by department_name";
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

        //bind_tainingid(Convert.ToInt16(drpdepartment.SelectedValue));

    }

    //private void bind_tainingid(int drpdepartment)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select id,training_name from tbl_training_schedul where dept_name='" + drpdepartment + "' order by training_name";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        //trainingid.DataTextField = "training_name";
    //        trainingid.DataValueField = "id";
    //        trainingid.DataSource = ds1;
    //        trainingid.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }

    //}

    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void bindempdetail()
    {

        try
        {
            if (RoleId == "28")
            {
                connection = activity.OpenConnection();
                SqlParameter[] sqlparam = new SqlParameter[4];

                //sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
                //sqlparam[0].Value = txt_employee.Text.Trim().ToString();

                //sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
                //sqlparam[1].Value = drpdegination.SelectedValue;

                sqlparam[0] = new SqlParameter("@department", SqlDbType.Int);
                sqlparam[0].Value = drpdepartment.SelectedValue;

                sqlparam[1] = new SqlParameter("@status", SqlDbType.VarChar, 50);
                sqlparam[1].Value = "All";

                sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
                if (drpbranch.SelectedValue != "")
                    sqlparam[2].Value = drpbranch.SelectedValue;
                else
                    sqlparam[2].Value = "0";

                //sqlparam[3] = new SqlParameter("@id", SqlDbType.Int);
                //sqlparam[3].Value = trainingid.SelectedValue;

                ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_training_fetch_need_emp_detail2", sqlparam);
                Grid_Addparticipants.DataSource = ds;
                Grid_Addparticipants.DataBind();
            }
            else
            {
                connection = activity.OpenConnection();
                SqlParameter[] sqlparam = new SqlParameter[3];

                //sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
                //sqlparam[0].Value = txt_employee.Text.Trim().ToString();

                //sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
                //sqlparam[1].Value = drpdegination.SelectedValue;

                sqlparam[0] = new SqlParameter("@department", SqlDbType.VarChar,50);
                if ((drpdepartment.SelectedItem.Text == "0") || (drpdepartment.SelectedItem.Text == ""))
                {
                    sqlparam[0].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    sqlparam[0].Value = drpdepartment.SelectedItem.Text;
                }

                sqlparam[1] = new SqlParameter("@status", SqlDbType.VarChar, 50);
                sqlparam[1].Value = "All";

                sqlparam[2] = new SqlParameter("@branch", SqlDbType.VarChar,50);
                if (drpbranch.SelectedItem.Text != "")
                    sqlparam[2].Value = drpbranch.SelectedItem.Text;
                else
                    sqlparam[2].Value = "0";

                //sqlparam[3] = new SqlParameter("@tid", SqlDbType.Int);
                //if (trainingid.SelectedValue != "")
                //    sqlparam[3].Value = trainingid.SelectedItem.Text;
                //else
                //    sqlparam[3].Value = "0";

                //sqlparam[4] = new SqlParameter("@trainingname", SqlDbType.VarChar,50);
              
                //if ((drpcode.SelectedItem.Text == "0") || (drpcode.SelectedItem.Text == ""))
                //{
                //    sqlparam[4].Value = System.Data.SqlTypes.SqlInt32.Null;
                //}
                //else
                //{
                //    sqlparam[4].Value = drpcode.SelectedItem.Text;
                //}

                ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_training_fetch_need_emp_detail2", sqlparam);
                Grid_Addparticipants.DataSource = ds;
                Grid_Addparticipants.DataBind();
            }
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

    //protected void trainingid_DataBound(object sender, EventArgs e)
    //{
    //    trainingid.Items.Insert(0, new ListItem("All", "0"));
    //}

    //protected void trainingid_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bind_tainingcode(Convert.ToInt16(trainingid.SelectedValue));
    //}

    //private void bind_tainingcode(int trainingid)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select id,modulename from tbl_training_elegible_emp where trining_id='" + trainingid + "' order by modulename";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpcode.DataTextField = "modulename";
    //        drpcode.DataValueField = "id";
    //        drpcode.DataSource = ds1;
    //        drpcode.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

    //protected void drpcode_DataBound(object sender, EventArgs e)
    //{
    //    drpcode.Items.Insert(0, new ListItem("All", "0"));
    //}

    protected void drpcode_SelectedIndexChanged(object sender, EventArgs e)
    {
       // bind_tainingcodename(Convert.ToInt16(trainingid.SelectedValue));
    }

    //private void bind_tainingcodename(int trainingid)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select id,training_code from tbl_training_elegible_emp where trining_id='" + trainingid + "' order by training_name";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpcode.DataTextField = "training_name";
    //        drpcode.DataValueField = "id";
    //        drpcode.DataSource = ds1;
    //        drpcode.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}



    //protected void drpcodename_DataBound(object sender, EventArgs e)
    //{

    //}
    //protected void drpcodename_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    protected void Grid_Addparticipants_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            activity.OpenConnection();

            string ChildMenu = Grid_Addparticipants.DataKeys[e.RowIndex].Value.ToString();
            Label fromdate = (Label)Grid_Addparticipants.Rows[e.RowIndex].FindControl("lblfromdate");
            Label todate = (Label)Grid_Addparticipants.Rows[e.RowIndex].FindControl("lbltodate");
            if (ChildMenu != "")
            {
                string sqlchildmenu = "Delete tbl_training_elegible_emp  where empcode='" + ChildMenu + "' and fromdate='" + fromdate.Text + "' and todate='" + todate.Text + "'";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                bind_addneedparticipants();
            }
            else
            {
                Output.Show("Please select the record...");
            }

        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not deleted. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            Response.Redirect("addneedparticipants.aspx?del=true");
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (Grid_Addparticipants.Rows.Count > 0)
        {
            // Hides the first column in the grid (zero-based index)
            Grid_Addparticipants.HeaderRow.Cells[8].Visible = false;
            Grid_Addparticipants.HeaderRow.Cells[9].Visible = false;

            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < Grid_Addparticipants.Rows.Count; i++)
            {
                GridViewRow row = Grid_Addparticipants.Rows[i];
                row.Cells[8].Visible = false;
                row.Cells[9].Visible = false;
                Grid_Addparticipants.Columns[8].Visible = false;
                Grid_Addparticipants.Columns[9].Visible = false;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ViewNeedParticipants" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < Grid_Addparticipants.Rows.Count; i++)
            {

                Grid_Addparticipants.Rows[i].Style.Add("width", "150px");
                Grid_Addparticipants.Rows[i].Style.Add("height", "20px");
            }

            Grid_Addparticipants.GridLines = GridLines.Both;
            Grid_Addparticipants.HeaderStyle.Font.Bold = true;
            Grid_Addparticipants.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}