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

public partial class Training_viewbyHR_addparticipent : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    SqlConnection Connection = null;
    string sqlstr, _userCode, _companyId, RoleId;
    string fromdate, todate, Faculty, modulename, modulenamess;
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
            todate = Request.QueryString["ToDate"].ToString();
            Faculty = Request.QueryString["Faculty"].ToString();
            modulename = Request.QueryString["module_name"].ToString();
            if (!IsPostBack)
            {
                bind_branch();
                bind_addparticipants();
                drpdepartment.Items.Insert(0, new ListItem("All", "0"));
                trainingid.Items.Insert(0, new ListItem("All", "0"));
                dept_type.Items.Insert(0, new ListItem("All", "0"));
                drpcode.Items.Insert(0, new ListItem("All", "0"));
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

    private void bind_addparticipants()
    {
        try
        {
            Connection = activity.OpenConnection();
            string strng = @"select module_name from tbl_training_schedul where id='" + tid + "'";
            DataSet dsInsertedEmps = SQLServer.ExecuteDataset(connection, CommandType.Text, strng);
            if (dsInsertedEmps.Tables[0].Rows.Count < 0)
            {
                return;
            }
            else
            {
                modulenamess = dsInsertedEmps.Tables[0].Rows[0]["module_name"].ToString();
            }
            //sqlstr = "select jd.empcode,coalesce(jd.emp_fname,jd.emp_m_name,jd.emp_l_name)as name,jd.location,db.department_name,de.designationname from tbl_intranet_employee_jobDetails jd inner join tbl_internate_departmentdetails db on db.departmentid=jd.dept_id inner join tbl_intranet_designation de on de.id=jd.degination_id";
//            sqlstr = @"select distinct elgbl_emp.id,elgbl_emp.empcode,elgbl_emp.emp_fname,elgbl_emp.designationname,elgbl_emp.department_name,
//elgbl_emp.training_name,elgbl_emp.training_code,elgbl_emp.branch_name,elgbl_emp.trining_id,trn_scdl.module_name,
//CONVERT(varchar(60),trn_scdl.fromdate,106) as FromDate,CONVERT(varchar(60),trn_scdl.todate,106) as ToDate,elgbl_emp.status
//from tbl_training_elegible_emp elgbl_emp
//inner join tbl_training_schedul trn_scdl on elgbl_emp.training_code=elgbl_emp.training_code where elgbl_emp.status=0";

//            sqlstr = @"select distinct elgbl_emp.id,elgbl_emp.empcode,elgbl_emp.emp_fname,elgbl_emp.designationname,elgbl_emp.department_name,
//elgbl_emp.training_name,elgbl_emp.training_code,elgbl_emp.branch_name,elgbl_emp.trining_id,elgbl_emp.status,
//convert(varchar(40),elgbl_emp.fromdate,106) as FromDate,convert(varchar(40),elgbl_emp.todate,106) as ToDate,
//elgbl_emp.modulename
//from tbl_training_elegible_emp elgbl_emp
//inner join tbl_training_schedul trn_scdl on elgbl_emp.training_code=elgbl_emp.training_code 
//where elgbl_emp.status=0";

            sqlstr = @"select distinct el_emp.id,el_emp.empcode,el_emp.emp_fname,el_emp.designationname,el_emp.department_name,dep.departmentid,
el_emp.designationname,el_emp.create_by,el_emp.training_code,el_emp.training_name,el_emp.trining_id,el_emp.status,
(Convert (varchar(40),el_emp.fromdate,106)) as FromDate,(Convert (varchar(40),el_emp.todate,106)) as ToDate,el_emp.modulename
from tbl_training_elegible_emp el_emp
inner join tbl_training_schedul ts on ts.training_code=el_emp.training_code
inner join tbl_internate_departmentdetails db on db.departmentid=ts.dept_name
inner join tbl_internate_departmentdetails dep on dep.department_name=el_emp.department_name
where el_emp.status=0 and el_emp.modulename='" + modulenamess + "'  and  el_emp.fromdate='" + fromdate + "' and el_emp.todate='" + todate + "'";

            DataSet ds1 = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 0)
            {
                return;
            }
            Grid_Addparticipantsbyuser.DataSource = ds1;
            Grid_Addparticipantsbyuser.DataBind();
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

    protected void Grid_Addparticipantsbyuser_PreRender(object sender, EventArgs e)
    {
        if (Grid_Addparticipantsbyuser.Rows.Count > 0)
        {
            Grid_Addparticipantsbyuser.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        bind_tainingid(Convert.ToInt16(drpdepartment.SelectedValue));

    }

    private void bind_tainingid(int drpdepartment)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id,training_name from tbl_training_schedul where dept_name='" + drpdepartment + "' order by training_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            //trainingid.DataTextField = "training_name";
            trainingid.DataValueField = "id";
            trainingid.DataSource = ds1;
            trainingid.DataBind();
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

                sqlparam[3] = new SqlParameter("@id", SqlDbType.Int);
                sqlparam[3].Value = trainingid.SelectedValue;

                ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_emp_detail2_shadow", sqlparam);
                Grid_Addparticipantsbyuser.DataSource = ds;
                Grid_Addparticipantsbyuser.DataBind();
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

                sqlparam[2] = new SqlParameter("@branch", SqlDbType.VarChar, 50);
                if (drpbranch.SelectedValue != "")
                    sqlparam[2].Value = drpbranch.SelectedItem.Text;
                else
                    sqlparam[2].Value = "0";

                //sqlparam[3] = new SqlParameter("@tid", SqlDbType.Int);
                //if (trainingid.SelectedValue != "")
                //    sqlparam[3].Value = trainingid.SelectedItem.Text;
                //else
                //    sqlparam[3].Value = "0";

                //sqlparam[4] = new SqlParameter("@trainingname", SqlDbType.VarChar, 50);

                //if ((drpcode.SelectedItem.Text == "0") || (drpcode.SelectedItem.Text == ""))
                //{
                //    sqlparam[4].Value = System.Data.SqlTypes.SqlInt32.Null;
                //}
                //else
                //{
                //    sqlparam[4].Value = drpcode.SelectedItem.Text;
                //}

                ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_training_fetch_emp_detail2", sqlparam);
                Grid_Addparticipantsbyuser.DataSource = ds;
                Grid_Addparticipantsbyuser.DataBind();
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

    protected void trainingid_DataBound(object sender, EventArgs e)
    {
        trainingid.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void trainingid_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_tainingcode(Convert.ToInt16(trainingid.SelectedValue));
    }

    private void bind_tainingcode(int trainingid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id,modulename from tbl_training_elegible_emp where trining_id='" + trainingid + "' order by modulename";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpcode.DataTextField = "modulename";
            drpcode.DataValueField = "id";
            drpcode.DataSource = ds1;
            drpcode.DataBind();
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

    protected void drpcode_DataBound(object sender, EventArgs e)
    {
        drpcode.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void drpcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        // bind_tainingcodename(Convert.ToInt16(trainingid.SelectedValue));
    }

    protected void Grid_Addparticipantsbyuser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            activity.OpenConnection();

            string ChildMenu = Grid_Addparticipantsbyuser.DataKeys[e.RowIndex].Value.ToString();
            Label fromdate = (Label)Grid_Addparticipantsbyuser.Rows[e.RowIndex].FindControl("lblfromdate");
            Label todate = (Label)Grid_Addparticipantsbyuser.Rows[e.RowIndex].FindControl("lbltodate");
            if (ChildMenu != "")
            {
                string sqlchildmenu = "Delete tbl_training_elegible_emp  where empcode='" + ChildMenu + "' and fromdate='" + fromdate.Text + "' and todate='" + todate.Text + "'";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
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
            Response.Redirect("viewbyHR_addparticipent.aspx?del=true");
        }
    }

}