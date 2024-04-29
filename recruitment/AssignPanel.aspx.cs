using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class recruitment_AssignPanel : System.Web.UI.Page
{
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //    Response.Redirect("~/Authenticate.aspx");
        }
        else
            
            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            bindGrid();
            //bindpanelcode();
            bind_ddlRRF();
            bindAssiengedGrid();
        }

        if (Request.QueryString["updated"] != null)
        {
            Output.Show("Panel Name is Updated Successfully.");
        }
    }

    protected void bind_ddlRRF()
    {
//        string sqlstr = @"select distinct rrf.rrf_code,rrf.id from tbl_recruitment_requisition_form rrf
//inner join tbl_recruitment_master_approvers approvers on rrf.rrf_code=approvers.rrf_code
// inner join tbl_recruitment_master_approvers approver_BH on approver_BH.rrf_code=approvers.rrf_code and approver_BH.Approvelevel='1' --and approver_BH.ApproverStatus='A'
// inner join tbl_recruitment_master_approvers approver_MD on approver_MD.rrf_code=approvers.rrf_code and approver_MD.Approvelevel='2' --and approver_BH.ApproverStatus='A'
// inner join tbl_recruitment_master_approvers approver_HRD on approver_HRD.rrf_code=approvers.rrf_code and approver_HRD.Approvelevel='3' --and approver_BH.ApproverStatus='A'
// inner join tbl_intranet_employee_jobDetails e  on approvers.ApproverCode=e.empcode
// where (approver_BH.ApproverStatus='A' and approver_MD.ApproverStatus='A' and approver_HRD.ApproverStatus='A') and rrf.status=1 and rrf.id not in(select rrf_code from tbl_recruitment_assignpanel) ";

//        string sqlstr = @"select distinct rrf.rrf_code,rrf.id from tbl_recruitment_requisition_form rrf
//inner join tbl_recruitment_master_approvers approvers on rrf.rrf_code=approvers.rrf_code
// inner join tbl_recruitment_master_approvers approver_BH on approver_BH.rrf_code=approvers.rrf_code and approver_BH.Approvelevel='1' --and approver_BH.ApproverStatus='A'
// inner join tbl_recruitment_master_approvers approver_MD on approver_MD.rrf_code=approvers.rrf_code and approver_MD.Approvelevel='2' --and approver_BH.ApproverStatus='A'
// --inner join tbl_recruitment_master_approvers approver_HRD on approver_HRD.rrf_code=approvers.rrf_code and approver_HRD.Approvelevel='3' --and approver_BH.ApproverStatus='A'
// inner join tbl_intranet_employee_jobDetails e  on approvers.ApproverCode=e.empcode

        string sqlstr = @"select distinct rrf.id, rrf.rrf_code + ' - ' + desg.designationname as newvalue from tbl_recruitment_requisition_form rrf
inner join tbl_recruitment_master_approvers approvers on rrf.rrf_code=approvers.rrf_code
 inner join tbl_recruitment_master_approvers approver_BH on approver_BH.rrf_code=approvers.rrf_code and approver_BH.Approvelevel='1' --and approver_BH.ApproverStatus='A'
 inner join tbl_recruitment_master_approvers approver_MD on approver_MD.rrf_code=approvers.rrf_code and approver_MD.Approvelevel='2' --and approver_BH.ApproverStatus='A'
 --inner join tbl_recruitment_master_approvers approver_HRD on approver_HRD.rrf_code=approvers.rrf_code and approver_HRD.Approvelevel='3' --and approver_BH.ApproverStatus='A'
 inner join tbl_intranet_employee_jobDetails e  on approvers.ApproverCode=e.empcode
  inner join tbl_intranet_designation desg on desg.id=rrf.designationid

 where (
 approver_BH.ApproverStatus='A' and 
 approver_MD.ApproverStatus='A' 
 --and approver_HRD.ApproverStatus='A'
 ) 
 and rrf.status=1 
 and rrf.id not in(select rrf_code from tbl_recruitment_assignpanel)";

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlRRF.DataTextField = "newvalue";
        ddlRRF.DataValueField = "id";
        ddlRRF.DataSource = ds;
        ddlRRF.DataBind();
        ddlRRF.Items.Insert(0, new ListItem("----------Select---------", "0"));
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        SqlParameter[] param = new SqlParameter[4];
        if (grdpanel.Rows.Count > 0)
        {
            ViewState["ddlRRF"] = ddlRRF.SelectedValue;
            //string a = ViewState["ddlRRF"].ToString();
            foreach (GridViewRow row in grdpanel.Rows)
            {               
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Label id = (Label)row.FindControl("lblID");
                    Label code = (Label)row.FindControl("lblpcode");
                    Label name = (Label)row.FindControl("lblname");
                    Label sname = (Label)row.FindControl("lblsubname");
                    Label rname = (Label)row.FindControl("lblresname");

                    param[0] = new SqlParameter("@rrf_code", SqlDbType.Int);
                    //ViewState["ddlRRF"] = ddlRRF.SelectedValue;
                    param[0].Value = ViewState["ddlRRF"];
                    param[1] = new SqlParameter("@panelcode", SqlDbType.VarChar,50);
                    param[1].Value = code.Text;
                    param[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                    param[2].Value = UserCode;
                    param[3] = new SqlParameter("@id", SqlDbType.Int);
                    param[3].Value = id.Text;
                   
                    string con = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString;
                    try
                    {
                        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_assignpanel", param);
                        if (i > 0)
                        {
                            //sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
                            Output.Show("Assigned Successfully");
                            bindAssiengedGrid();
                            bind_ddlRRF();
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
                        Output.Show("Record not saved.Please contact system admin.For error details please go through the log file");
                    }

                }

            }
            bindGrid();
        }
    }

    protected void bindpanelcode()
    {
        string sqlstr = "select * from tbl_recruitment_panel_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlcode.DataTextField = "panelcode";
        ddlcode.DataValueField = "id";
        ddlcode.DataSource = ds;
        ddlcode.DataBind();
        ddlcode.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindGrid()
    {
        //string sqlstr = @"select * from tbl_recruitment_panel_master";

        string sqlstr = @"  select rp.*,emp.emp_fname from tbl_recruitment_panel_master rp 
          left join tbl_intranet_employee_jobDetails emp on rp.resourcenames=emp.empcode where rp.status=1";

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdpanel.DataSource = ds;
        grdpanel.DataBind();

    }

    protected void bindAssiengedGrid()
    {
//        string sqlstr = @"select rp.*,rf.rrf_code from tbl_recruitment_panel_master rp
//                            inner join tbl_recruitment_assignpanel ap on rp.id=ap.panelid
//                            inner join tbl_recruitment_requisition_form rf on rf.id=ap.rrf_code
//                            where rf.status=1";

        string sqlstr = @"select rp.*,
rf.rrf_code,
desg.designationname,
emp.emp_fname 
from tbl_recruitment_panel_master rp
inner join tbl_recruitment_assignpanel ap on rp.id=ap.panelid
inner join tbl_recruitment_requisition_form rf on rf.id=ap.rrf_code
left join tbl_intranet_designation desg on desg.id=rf.designationid
left join  tbl_intranet_employee_jobDetails emp on emp.empcode=rp.resourcenames                                                      
                            where rf.status=1";




        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdassigned.DataSource = ds;
        grdassigned.DataBind();

    }

    protected void ddlcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcode.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddlcode.SelectedValue);
            string sqlstr = "select * from tbl_recruitment_panel_master where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdpanel.DataSource = ds;
            grdpanel.DataBind();
        }
        else
        {
            bindGrid();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string Panelname = txt_search.Text;

        string sqlstr = "select * from tbl_recruitment_panel_master  where Panelname like '%" + Panelname + "%'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdpanel.DataSource = ds;
        grdpanel.DataBind();
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    private void cleartext()
    {
        txt_search.Text = "";
        ddlcode.SelectedValue = "0";
    }
}