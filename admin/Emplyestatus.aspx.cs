using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;

public partial class admin_Emplyestatus : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    string _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();

            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {

                }
                else
                    Response.Redirect("~/notlogged.aspx");

                if (Session["acc_education"] != null)
                {
                    Session.Remove("acc_education");
                }
                if (Session["Pro_education"] != null)
                {
                    Session.Remove("Pro_education");
                }
                bindetail();
            }
        }
    }
    protected void bindetail()
    {

        connection = activity.OpenConnection();
        string st1 = "select empcode from tbl_contact_detail where empcode='" + _userCode + "'";

        DataSet dsx = SQLServer.ExecuteDataset(connection, CommandType.Text, st1);
        if (dsx.Tables[0].Rows.Count < 1)
            return;
        string H_C = dsx.Tables[0].Rows[0]["empcode"].ToString();   //HR CODE BINDING VARIABLE
        if (H_C != null)
        {
            string st = @"SELECT DISTINCT 
                                            dbo.tbl_intranet_employee_jobDetails.emp_fname,
                                            dbo.tbl_intranet_employee_jobDetails.Comment,
                                            dbo.tbl_intranet_employee_jobDetails.empcode, dbo.tbl_intranet_designation.designationname, dbo.tbl_internate_departmentdetails.department_name, 
                                            dbo.tbl_intranet_role.role AS Role,dbo.tbl_contact_detail.Approverstatus FROM dbo.tbl_intranet_employee_jobDetails INNER JOIN dbo.tbl_intranet_designation ON dbo.tbl_intranet_employee_jobDetails.degination_id = dbo.tbl_intranet_designation.id INNER JOIN
                                            dbo.tbl_internate_departmentdetails ON dbo.tbl_intranet_employee_jobDetails.dept_id = dbo.tbl_internate_departmentdetails.departmentid INNER JOIN
                                            dbo.tbl_login ON dbo.tbl_intranet_employee_jobDetails.empcode = dbo.tbl_login.empcode INNER JOIN
                                            dbo.tbl_intranet_role ON dbo.tbl_login.role = dbo.tbl_intranet_role.id INNER JOIN
                                            dbo.tbl_contact_detail ON dbo.tbl_intranet_employee_jobDetails.empcode = dbo.tbl_contact_detail.empcode
                                            where tbl_contact_detail.empcode='" + _userCode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, st);

            if (ds.Tables[0].Rows.Count < 1)
                return;
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
    }
}