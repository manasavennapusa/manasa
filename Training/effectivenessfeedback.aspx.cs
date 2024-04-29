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

public partial class training_effectivenessfeedback : System.Web.UI.Page
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

            if (Request.QueryString["sub"] != null)
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
        string str = @"select distinct emp .id,emp.training_code,emp.trining_id,emp.training_name,emp.modulename,CONVERT(varchar(60),emp.fromdate,106) as FromDate, 
CONVERT(varchar(60),emp.todate,106) as ToDate,emp.empcode,emp.emp_fname,emp.department_name  from tbl_training_mark_attendance att 
          inner join tbl_training_elegible_emp emp on emp.empcode=att.empcode      
where emp.fromdate not in (select fromdate from tbl_training_effectivefeedback_for_improvement)
and att.trainerempname ='" + Session["empcode"].ToString().Trim() + "'";
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