using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class training_ViewFeedback : System.Web.UI.Page
{
    string Usercode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] == null)
            Response.Redirect("~/notlogged.aspx");
        Usercode = Session["empcode"].ToString();
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            bindfeedbackgrid();
        }

    }

    protected void Grid_viewfeedback_PreRender(object sender, EventArgs e)
    {
        if (Grid_viewfeedback.Rows.Count > 0)
        {
            Grid_viewfeedback.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btn_deselect_Click(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {

    }

    protected void btn_select_Click(object sender, EventArgs e)
    {

    }

    protected void bindfeedbackgrid()
    {


        string sqlstr = @"SELECT convert(varchar(20),form.fromdate,103)as fromdate,
form.empcode,form.department_name,form.training_name,
convert(varchar(20),form.todate,103) as todate FROM tbl_training_participants_feedback_form form
where form.Training_sheduled_by='" + Usercode + "'";

    
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 0)
        {
            return;
        }
        Grid_viewfeedback.DataSource = ds;
        Grid_viewfeedback.DataBind();
    }

}