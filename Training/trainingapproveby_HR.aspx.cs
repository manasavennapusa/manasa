using Common.Console;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Training_trainingapproveby_HR : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string bodyContent;
    string sqlstr, _userCode, _companyId, RoleId;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
         id = Convert.ToInt16(Request.QueryString["id"]);

        if (Session["empcode"] != null && Session["companyid"] != null)
        {            

            if (!IsPostBack)
            {

                if (Session["role"] != null)
                {
                }
                else
                {
                    Response.Redirect("~/notlogged.aspx");
                }

                bindtrining();

            }

        }
    }

    private void bindtrining()
    {
        

        SqlConnection Connection = null;
        try
        {
            Connection = activity.OpenConnection();
            //string str = @"select trainingdetails,emp_overall_rating,emp_overall_cmt,mgr_overall_rating,mgr_overall_cmt,behavior_color from tbl_appraisal_assessment where  status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + empcode + "' ";

            string str = @"select training_code,training_name,bran.branch_name,depty.dept_type_name,dep.department_name,module_name,
month,
(Convert (varchar(10),fromdate,101)) as FromDate,
bachcode,
faculty,
training_type,
training_shortname,
(Convert (varchar(10),todate,101)) as ToDate,
year
 from tbl_training_schedul ts
 inner join dbo.tbl_internate_department_type depty on ts.dept_type=depty.dept_type_id
 inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
 inner join dbo.tbl_intranet_branch_detail bran on ts.branch=bran.branch_id
 where ts.approverstatus='0' and ts.id='"+id+"'";
            
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            if (ds.Tables[0].Rows.Count < 1)
            {
                return;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltrainingcode.Text = ds.Tables[0].Rows[0]["training_code"].ToString();
                lblmodulename.Text = ds.Tables[0].Rows[0]["module_name"].ToString();
                lbltrainintype.Text = ds.Tables[0].Rows[0]["training_type"].ToString();
                lblfromdate.Text = ds.Tables[0].Rows[0]["FromDate"].ToString();
                lbldepartmentname.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
                lbltrainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
                lblfacultyname.Text = ds.Tables[0].Rows[0]["faculty"].ToString();
                lbltrainingshortname.Text = ds.Tables[0].Rows[0]["training_shortname"].ToString();
                lbltodate.Text = ds.Tables[0].Rows[0]["ToDate"].ToString();
                lblbranchname.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {        
        SqlConnection Connection = null;
        try
        {
            Connection = activity.OpenConnection();
            //string str = @"select trainingdetails,emp_overall_rating,emp_overall_cmt,mgr_overall_rating,mgr_overall_cmt,behavior_color from tbl_appraisal_assessment where  status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + empcode + "' ";

            string str = @"update tbl_training_schedul set approverstatus='1' where id='"+id+"'";
            
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            Response.Redirect("viewtrainingby_hr.aspx?approve=true");
          
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }



        //SqlParameter[] sqlparam1 = new SqlParameter[2];
        //string I_cycle = "0";
        //SqlConnection Connection = null;
        //SqlTransaction _transaction = null;
        //try
        //{
        //    Connection = activity.OpenConnection();
        //    Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, Request.QueryString["empcode"].ToString());
        //    Output.AssignParameter(sqlparam1, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
        //    DataSet dse = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_getEmployeeDetails", sqlparam1);
        //    if (dse.Tables[0].Rows.Count >= 1)
        //    {
        //        I_cycle = dse.Tables[0].Rows[0]["I_cycle"].ToString();
        //    }
        //    _transaction = Connection.BeginTransaction();
        //    //   insertIncreamenetDetails(Connection, _transaction);
        //    if (I_cycle.ToString() == "1")
        //        InsertIncrementStatus(Connection, _transaction, 3);
        //    else if (I_cycle.ToString() == "2")
        //        InsertIncrementStatus(Connection, _transaction, 4);
        //    _transaction.Commit();
        //    //  bindgrid();
        //}
        //catch (Exception ex)
        //{
        //    _transaction.Rollback();
        //    Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //    Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        //}
        //finally
        //{
        //    DataActivity.CloseConnection();
        //}
        //Response.Redirect("SalaryIncreamentProcessByMD.aspx?approve=true");
    }
    protected void btnreject_Click(object sender, EventArgs e)
    {

    }
}