using Common.Data;
using DataAccessLayer;
using Smart.HR.Common.Console;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Training_linemangereffectiveFeedback : System.Web.UI.Page
{
    string Usercode;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] == null)
            Response.Redirect("~/notlogged.aspx");
        Usercode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            bindfeedbackgrid();

            if (Request.QueryString["stat1"] != null)
            {
                Output.Show("Submitted Successfully");
            }
        }
    }

    protected void bindfeedbackgrid()
    {
        //        string sqlstr = @"select distinct ts .id,ts.training_code,elg_emp.trining_id,ts.training_name,ts.module_name,CONVERT(varchar(60),ts.fromdate,106) as FromDate, 
        //CONVERT(varchar(60),ts.todate,106) as ToDate,elg_emp.empcode,elg_emp.emp_fname,elg_emp.department_name
        //from tbl_training_schedul ts 
        //inner join tbl_training_mark_attendance trn_mrk_atndnc on ts.training_code=trn_mrk_atndnc.training_code
        //inner join tbl_training_elegible_emp elg_emp on ts.training_code=elg_emp.training_code
        //inner join tbl_training_participants_feedback_form feed_form on ts.training_name=feed_form.training_name";
        //where elg_emp.empcode='" +Usercode+"'";
        string str = @"select distinct fee.id , imp.empcode,imp.emp_fname,imp.department_name,imp.training_name,
imp.training_code,imp.branch_name,convert(varchar(20),emp.fromdate,103)as fromdate,
convert(varchar(20),emp.todate,103) as todate from tbl_training_mark_attendance imp
inner join   tbl_training_effectivefeedback_for_improvement fee on imp.empcode=fee.empcode
inner join tbl_employee_approvers app on app.empcode=imp.empcode 
inner join tbl_training_elegible_emp emp on emp.empcode=fee.empcode and  fee.fromdate=emp.fromdate
and fee.todate=emp.todate                      
 where app.app_reportingmanager='" + Usercode + "' and fee.approverstatus=0";

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, str);
        if (ds.Tables[0].Rows.Count < 1)
        {
            return;
        }
        Grid_feedback.DataSource = ds;
        Grid_feedback.DataBind();
    }

    protected void Grid_feedback_PreRender(object sender, EventArgs e)
    {
        if (Grid_feedback.Rows.Count > 0)
        {
            Grid_feedback.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}