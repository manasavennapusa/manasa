using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Training_pickfaculty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCandidateDetails();
        }
    }

    protected void bindCandidateDetails()
    {
        DataSet ds = new DataSet();
        string sqlstr = @"select jd.empcode,coalesce(jd.emp_fname,'') + '' + coalesce(jd.emp_m_name,'') + '' + coalesce(jd.emp_l_name,'') as empname, 
jd.degination_id,desg.designationname 
from tbl_intranet_employee_jobDetails jd
inner join tbl_intranet_designation desg on jd.degination_id=desg.id";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
        candidategrid.DataSource = ds;
        candidategrid.DataBind();
    }

    protected void candidategrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        candidategrid.PageIndex = e.NewPageIndex;
        bindCandidateDetails();
    }

    protected void candidategrid_PreRender(object sender, EventArgs e)
    {
        if (candidategrid.Rows.Count > 0)
        {
            candidategrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

}