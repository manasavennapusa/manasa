using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_OrgChart : System.Web.UI.Page
{
    [WebMethod]
    public static List<object> GetChartData(string empcode)
    {
     
        string query = @"select ej.empcode as EmployeeId ,ej.emp_fname as Name,designationname as Designation,job.emp_fname as ReportingManager 
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep 
on ep.empcode=ej.empcode and ep.app_reportingmanager='" + empcode + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) left join tbl_intranet_employee_jobDetails job on job.empcode=ep.app_reportingmanager where  ej.emp_doleaving is null and ej.status=1  order by ej.emp_fname";

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                List<object> chartData = new List<object>();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                {
                    sdr["EmployeeId"], sdr["Name"], sdr["Designation"] , sdr["ReportingManager"]
                });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }
}