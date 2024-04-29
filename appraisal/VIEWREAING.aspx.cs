using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;

public partial class appraisal_VIEWREAING : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;
    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    string EmployeeCode = "";
    DataActivity DataActivity = new DataActivity();
    string UserCode;

    protected void Page_Load(object sender, EventArgs e)
    {
          if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        getActiveCycle();
        if (!IsPostBack)
        {
            EmployeeCode = Session["empcode"].ToString();
            bindEmpDetails(EmployeeCode);
            if (gveligible.Rows.Count <= 0)
                gveligible.EmptyDataText = "No Records Found!.";
          
           
            if (Request.QueryString["empcode"] != null)
            {
              
              
                emplist.Visible = false;
              
             

           
            }


        }
    }

    private void getActiveCycle()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze!=1";
            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str1);
            if (cnt > 0)
            {
               int cycle = (int)SQLServer.ExecuteScalar(Connection, CommandType.StoredProcedure, "sp_appraisal_getapprisalcycle");
                if (cycle != 0)
                {
                    Session["appcycle"] = cycle;
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


 

    //private void bindgrid()
    //{
    //    SqlParameter[] sqlparam = new SqlParameter[5];
    //    SqlConnection Connection = null;
    //    try
    //    {
    //        Connection = DataActivity.OpenConnection();
    //        Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
    //        Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
    //        Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, "0");
    //        Output.AssignParameter(sqlparam, 3, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
    //        Output.AssignParameter(sqlparam, 4, "@department", "Int", 0, "0");
    //        DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_listof_EmpforHR", sqlparam);
    //        emplist.Visible = true;
    //        gveligible.DataSource = ds;
    //        gveligible.DataBind();
    //        ViewState["Getemp"] = ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        DataActivity.CloseConnection();
    //    }
    //}


    protected void bindEmpDetails(string empcode)
    {
        SqlParameter[] sqlparam1 = new SqlParameter[2];
        SqlConnection Connection = null;

       
          try
            {
                Connection = DataActivity.OpenConnection();

                string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
                DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query1);
                string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
                string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();


                string query = @"select empappr.appcycle_id,isnull(emp_fname ,'')+'' +isnull( emp_m_name,'')+ '' +isnull( emp_l_name,'') as name,
rtrim(empjob.empcode) as empcode,    
empdesg.designationname as designation,
empdept.department_name as dept,
convert(varchar(10),empjob.emp_doj,101) as emp_doj,
		(case when appast.G1_cycle='0' then 'Not Inititated' 
		when appast.G1_cycle='1' then 'Initiated'
		end )as GoalStatus,
		
		(case when R_cycle='0' then 'Pending'
		when appast.R_cycle='1'  then 'Pending'
		when   R_cycle='2' then 'Pending at LM'
		when   R_cycle='3' then 'Pending at BH'
		when   R_cycle='4' then 'Rating Completed'
		end )as RatingStatus,
		(case when  appast.I_cycle=0  then 'Not Inititated'
	  when appast.I_cycle=1  then 'Inititated'
	  end )as IncreamentStatus,
empappr.status                  
 from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment appast on appast.empcode=empappr.empcode
inner join tbl_appraisal_rating_details_1 rating on rating.empcode=appast.empcode and appast.quater=rating.quater and appast.APP_year=rating.APP_year
and empappr.appcycle_id =appast.appcycle_id
where 1=1 AND rating.empcode='" + empcode + "'and empappr.appcycle_id='" + Convert.ToInt32(Session["appcycle"]) + "' and rating.quater='" + quater + "' and rating.APP_year='" + APP_year + "' ";
                DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gveligible.DataSource = ds;
                    gveligible.DataBind();
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
    


 



    


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEmployeeListByHR.aspx");
    }
    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found";
    }
    protected void gveligible_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[3];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string id = (string)gveligible.DataKeys[e.RowIndex].Value;
            string appcycleid = Session["appcycle"].ToString();

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, id.Trim());
            Output.AssignParameter(sqlparam, 1, "@appcycleid", "Int", 0, appcycleid);
            Output.AssignParameter(sqlparam, 2, "@createdby", "String", 50, Session["empcode"].ToString());

            int ins = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_deleteeligibleemployee", sqlparam);
            if (ins > 0)
            {
              //  bindgrid();
                // sendMailOnDelete(id);
                Output.Show("Record deleted successfully.");
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
}