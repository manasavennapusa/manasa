using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Configuration;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

public partial class Exit_ResignationHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //string UserCode = Session["empcode"].ToString();
          BindGridData();

        }
    }
    protected void History_Grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string Empcode = History_Grid.DataKeys[e.NewEditIndex].Value.ToString();
        Session["ABC"] = Empcode;
        Response.Redirect("FormExitInterviewQuestionaries.aspx?Empcode=" + Empcode);
    }
    protected void History_Grid_PreRender(object sender, EventArgs e)
    {
        if (History_Grid.Rows.Count > 0)
        {
            History_Grid.UseAccessibleHeader = true;
            History_Grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void BindGridData()
    {
        string Query = @"select 
                         RG.ResignationId,
                         RG.AppliedDate,
                         RG.NoticePeriod,
                         JD.empcode, 
                         JD.emp_fname,
                         DD.department_name,
                         DG.designationname
                         from tbl_intranet_employee_jobDetails JD inner join
                         tbl_exit_Resignation RG on JD.empcode=RG.EmpCode
                         inner join tbl_internate_departmentdetails DD on JD.dept_id=DD.departmentid
                         inner join tbl_intranet_designation DG on JD.degination_id=DG.id
                         where RG.Whichlevel=3 and JD.emp_status=2 order by RG.ResignationId desc";
        DataSet DS = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
        if (DS.Tables[0].Rows.Count > 0)
        {
            History_Grid.DataSource = DS;
            History_Grid.DataBind();
        }
        else
        {
            History_Grid.DataSource = null;
            History_Grid.DataBind();
        }
    }
}