using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;

public partial class admin_Approvestaus : System.Web.UI.Page
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
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void bindetail()
    {

        connection = activity.OpenConnection();
        string st1 = "select Approvercode from tbl_contact_detail where Approvercode='" + _userCode + "'";

        DataSet dsx = SQLServer.ExecuteDataset(connection, CommandType.Text, st1);
        if (dsx.Tables[0].Rows.Count < 1)
            return;
        string H_C = dsx.Tables[0].Rows[0]["Approvercode"].ToString();   //HR CODE BINDING VARIABLE
        if (H_C != null)
        {

            string st = @"select distinct jd.emp_fname,jd.empcode,desg.designationname,dept.department_name,rol.role AS Role,cont.Approverstatus 
FROM dbo.tbl_intranet_employee_jobDetails jd
inner join tbl_intranet_designation desg ON jd.degination_id = desg.id 
inner join tbl_internate_departmentdetails dept ON jd.dept_id = dept.departmentid 
inner join tbl_login ON jd.empcode = dbo.tbl_login.empcode 
inner join tbl_intranet_role rol ON dbo.tbl_login.role = rol.id 
inner join tbl_contact_detail cont ON jd.empcode = cont.empcode
 where cont.Approvercode='" + _userCode + "'";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, st);

            if (ds.Tables[0].Rows.Count < 1)
                return;
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
    }

    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

}
