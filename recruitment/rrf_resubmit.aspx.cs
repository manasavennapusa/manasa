using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;
using Smart.HR.Common.Mail.Module;

public partial class recruitment_rrf_resubmit : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string UserCode;
    DataActivity DataActivity = new DataActivity();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Role"] != null)
        {
        }
        else
            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            binddep();
            binddepartment();
            bind_costcenter();
            bind_location();
            bind_requesttype();
            bindexpectedCTC();
            bind_vacancytype();
            bindrrfdetails();
            bindapproversgrid();
        }

    }

    private void binddep()
    {
        string sqlstr = "select dept_type_id, dept_type_name from tbl_internate_department_type";
        // DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddldeptype.DataSource = ds;
        ddldeptype.DataTextField = "dept_type_name";
        ddldeptype.DataValueField = "dept_type_id";
        ddldeptype.DataBind();
        ddldeptype.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindrrfdetails()
    {
        int rrf_id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlparam = new SqlParameter[1];
        try
        {
            sqlparam[0] = new SqlParameter("@ids", SqlDbType.Int);
            sqlparam[0].Value = rrf_id;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_resubmit", sqlparam);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                txt_Posts.Text = ds.Tables[0].Rows[0]["total_no_posts"].ToString();
                ddl_vacancy_type.SelectedValue = ds.Tables[0].Rows[0]["vacancy_typeid"].ToString();
                ddlexpectCTC.SelectedValue = ds.Tables[0].Rows[0]["incentive"].ToString();
                txt_shifthours.Text = ds.Tables[0].Rows[0]["shift_hours"].ToString();
                txt_reasons.Text = ds.Tables[0].Rows[0]["reasons_of_request"].ToString();
                txt_IndustriesPreferred.Text = ds.Tables[0].Rows[0]["industries_preferred"].ToString();
                txt_skills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
                txt_edu_qualification.Text = ds.Tables[0].Rows[0]["educational_qualifications"].ToString();
                ddl_request_type.SelectedValue = ds.Tables[0].Rows[0]["request_typeid"].ToString();
                ddl_location.SelectedValue = ds.Tables[0].Rows[0]["locationid"].ToString();
                ddl_dept.SelectedValue = ds.Tables[0].Rows[0]["departmentid"].ToString();
                binddesignation(Convert.ToInt32(ds.Tables[0].Rows[0]["departmentid"].ToString()));
                ddl_designation.SelectedValue = ds.Tables[0].Rows[0]["designationid"].ToString();
                ddl_costcenter.SelectedValue = ds.Tables[0].Rows[0]["costcenterid"].ToString();
                txt_experience.Text = ds.Tables[0].Rows[0]["experience"].ToString();
                txt_additionalqualifiers.Text = ds.Tables[0].Rows[0]["additional_qualifiers"].ToString();
                txt_jobDesc.Text = ds.Tables[0].Rows[0]["job_description"].ToString();
                ddldeptype.SelectedValue = ds.Tables[0].Rows[0]["deptype"].ToString();
            }
        }
        catch
        {
        }
    }

    protected void bind_vacancytype()
    {
        string sqlstr = "select id,vacancytype from tbl_recruitment_vacancytype ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_vacancy_type.DataSource = ds;
        ddl_vacancy_type.DataTextField = "vacancytype";
        ddl_vacancy_type.DataValueField = "id";
        ddl_vacancy_type.DataBind();
        ddl_vacancy_type.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindexpectedCTC()
    {
        string sqlstr = "select id,expectedCTC from tbl_recruitment_expctc_master";
        // DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlexpectCTC.DataTextField = "expectedCTC";
        ddlexpectCTC.DataValueField = "id";
        ddlexpectCTC.DataSource = ds;
        ddlexpectCTC.DataBind();
        ddlexpectCTC.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_requesttype()
    {
        string sqlstr = "select id,requesttype from tbl_recruitment_requesttype ";
        //DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_request_type.DataSource = ds;
        ddl_request_type.DataTextField = "requesttype";
        ddl_request_type.DataValueField = "id";
        ddl_request_type.DataBind();
        ddl_request_type.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_location()
    {
        string sqlstr = "select cid,city from tbl_intranet_city ";
        // DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_location.DataSource = ds;
        ddl_location.DataTextField = "city";
        ddl_location.DataValueField = "cid";
        ddl_location.DataBind();
        ddl_location.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_costcenter()
    {
        string sqlstr = "select id,division_name from tbl_intranet_division ";
        // DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_costcenter.DataSource = ds;
        ddl_costcenter.DataTextField = "division_name";
        ddl_costcenter.DataValueField = "id";
        ddl_costcenter.DataBind();
        ddl_costcenter.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void binddepartment()
    {
        string sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails";
        // DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_dept.DataTextField = "department_name";
        ddl_dept.DataValueField = "departmentid";
        ddl_dept.DataSource = ds;
        ddl_dept.DataBind();
        ddl_dept.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void binddesignation(int departmentid)
    {
        string sqlstr = "select id,designationname from tbl_intranet_designation where departmentid='" + departmentid + "'";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_designation.DataTextField = "designationname";
        ddl_designation.DataValueField = "id";
        ddl_designation.DataSource = ds;
        ddl_designation.DataBind();
        ddl_designation.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindapproversgrid()
    {
        IBase Lib = null;
        Lib = new Base();

        string Query = @"

select 
F.id, 
F.rrf_code, 
A.ApproverCode, 
isnull(J.emp_fname,'')+''+isnull(J.emp_m_name,'')+''+isnull(J.emp_l_name,'') ApproverName,
A.Approvelevel,
case 
when A.Approvelevel = 1 then 'BH'
when A.Approvelevel = 2 then 'HR-BP'
--when A.Approvelevel = 3 then 'MD'
--when A.Approvelevel = 4 then 'HR-TA' 
end ApproverRole
, 
case 
when A.ApproverStatus = 'H' then 'Pending'
when A.ApproverStatus = 'A' then 'Approved'
when A.ApproverStatus = 'R' then 'Rejected' end ApproverStatus
 from tbl_recruitment_requisition_form F
  inner join tbl_recruitment_master_approvers A on F.rrf_code = A.rrf_code
  inner join tbl_intranet_employee_jobDetails J on A.ApproverCode = J.empcode
   where F.id = " + Request.QueryString["id"].Trim() + " order by A.Approvelevel";

        Lib.Bee.WBindGrid(Query, grdapprovers);

    }

    protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddesignation(Convert.ToInt32(ddl_dept.SelectedValue));
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        insert_RRF();
    }

    protected void insert_RRF()
    {
        int approvers = 0;
        int i = 0;
        string rrfcode = "";

        foreach (GridViewRow row in grdapprovers.Rows)
        {
            Label approvercode = (Label)row.FindControl("lblempcode");
            Label approverlevel = (Label)row.FindControl("lbllevels");
            if (approvercode.Text != null && approvercode.Text != "")
            {
                approvers++;
            }
        }

        if (approvers == 2)
        {

            SqlParameter[] sqlParam = new SqlParameter[24];
            SqlConnection Connection = null;
            SqlTransaction _Transaction = null;
            try
            {
                Output.AssignParameter(sqlParam, 0, "@departmentid", "Int", 0, ddl_dept.SelectedValue);
                Output.AssignParameter(sqlParam, 1, "@designationid", "Int", 0, ddl_designation.SelectedValue);
                Output.AssignParameter(sqlParam, 2, "@total_no_posts", "Int", 0, txt_Posts.Text);
                Output.AssignParameter(sqlParam, 3, "@costcenterid", "Int", 0, ddl_costcenter.SelectedValue);
                Output.AssignParameter(sqlParam, 4, "@request_typeid", "Int", 0, ddl_request_type.SelectedValue);
                Output.AssignParameter(sqlParam, 5, "@budget", "Bool", 0, rbtn_budget.SelectedValue);
                Output.AssignParameter(sqlParam, 6, "@vacancy_typeid", "Int", 0, ddl_vacancy_type.SelectedValue);
                Output.AssignParameter(sqlParam, 7, "@locationid", "Int", 0, ddl_location.SelectedValue);
                Output.AssignParameter(sqlParam, 8, "@temporary", "Int", 0, txt_temparary.Text);
                Output.AssignParameter(sqlParam, 9, "@gross_salary", "Decimal", 100, txt_grosssalary.Text);
                Output.AssignParameter(sqlParam, 10, "@incentive", "Int", 0, ddlexpectCTC.SelectedValue);
                Output.AssignParameter(sqlParam, 11, "@ctc", "Decimal", 0, txt_tctc.Text);
                Output.AssignParameter(sqlParam, 12, "@working_hours", "String", 50, txt_workinghours.Text);
                Output.AssignParameter(sqlParam, 13, "@shift_hours", "String", 50, txt_shifthours.Text);
                Output.AssignParameter(sqlParam, 14, "@reasons_of_request", "String", 1000, txt_reasons.Text);
                Output.AssignParameter(sqlParam, 15, "@additional_qualifiers", "String", 1000, txt_additionalqualifiers.Text);
                Output.AssignParameter(sqlParam, 16, "@industries_preferred", "String", 1000, txt_IndustriesPreferred.Text);
                Output.AssignParameter(sqlParam, 17, "@job_description", "String", 1000, txt_jobDesc.Text);
                Output.AssignParameter(sqlParam, 18, "@skills", "String", 1000, txt_skills.Text);
                Output.AssignParameter(sqlParam, 19, "@educational_qualifications", "String", 1000, txt_edu_qualification.Text);
                Output.AssignParameter(sqlParam, 20, "@experience", "String", 1000, txt_experience.Text);
                Output.AssignParameter(sqlParam, 21, "@createdby", "String", 50, UserCode);
                Output.AssignParameter(sqlParam, 22, "@deptype", "Int", 0, ddldeptype.SelectedValue);
                sqlParam[23] = new SqlParameter("@rrf_code", SqlDbType.VarChar, 50);
                sqlParam[23].Value = "";
                sqlParam[23].Direction = ParameterDirection.Output;

                Connection = DataActivity.OpenConnection();
                _Transaction = Connection.BeginTransaction();

                i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "[sp_recruitment_insert_requisition_form]", sqlParam);

                if (sqlParam[23].Value != "")
                {
                    rrfcode = sqlParam[23].Value.ToString();
                    //    insertApprover(rrfcode, hf_bhcode.Value.ToString(), "1");
                    //    insertApprover(rrfcode, hf_mdcode.Value.ToString(), "2");
                    //    insertApprover(rrfcode, hf_hrdCode.Value.ToString(), "3");
                    //    insertApprover(rrfcode, hf_hrcode.Value.ToString(), "4");

                    foreach (GridViewRow row in grdapprovers.Rows)
                    {
                        Label approvercode = (Label)row.FindControl("lblempcode");
                        Label approverlevel = (Label)row.FindControl("lbllevels");
                        if (approvercode.Text != null && approvercode.Text != "")
                        {
                            SqlParameter[] Param = new SqlParameter[4];
                            Output.AssignParameter(Param, 0, "@rrf_code", "String", 50, rrfcode);
                            Output.AssignParameter(Param, 1, "@Approvelevel", "String", 1, approverlevel.Text);
                            Output.AssignParameter(Param, 2, "@ApproverCode", "String", 50, approvercode.Text);
                            Output.AssignParameter(Param, 3, "@Createdby", "String", 50, UserCode);

                            int i1 = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_approver_requisition_form]", Param);
                        }
                    }

                }
                _Transaction.Commit();


            }
            catch (Exception ex)
            {
                _Transaction.Rollback();
                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                DataActivity.CloseConnection();
            }

            if (i < 0)
            {
                Output.Show("Requisition Form is not Submited");
            }
            else
            {
               // SendEmailToLevel(rrfcode);

                //Output.Show("Submitted Successfully.");
                //Response.Redirect("viewStatusByRRF_Raiser.aspx");
                message.InnerHtml = "Re-Submitted Successfully.";
                Response.Redirect("viewStatusByRRF_Raiser.aspx?updated=true");
            }

        }
        else
        {
            Output.Show("Some of the approvers are not avaliable. Please contact your manager.");
        }
    }

    void SendEmailToLevel(string rrfId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedBH();
        EmailClient client = new EmailClient(email);
        RecruitmentApprovers objEmail = new RecruitmentApprovers();

        DataSet ds = objEmail.GetRecruitmentApprovers(rrfId);

        DataRow rowApp = ds.Tables[0].Rows[0];
        DataRow rowEmp = ds.Tables[1].Rows[0];

        client.toEmailId = rowApp["officialemailid"].ToString().Trim();
        client.empCode = rowApp["empcode"].ToString();
        client.employeeName = rowApp["empname"].ToString().Trim();
        client.requestNumber = rrfId;
        client.fromDate = rowEmp["empname"].ToString().Trim() + " ( " + rowEmp["empcode"].ToString().Trim() + " ) ";
        client.Send();
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewStatusByRRF_Raiser.aspx");
    }
    protected void ddldeptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //binddep(Convert.ToInt32(ddldeptype.SelectedValue));
    }

    protected void binddep(int depttypetid)
    {
        //string sqlstr = "select dd.departmentid, dd.department_name from tbl_internate_departmentdetails dd inner join  tbl_internate_department_type bd on bd.dept_type_id=dd.dept_type_id where dd.dept_type_id = " + depttypetid + "";
        //// DataSet ds = new DataSet();
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //ddl_dept.DataTextField = "department_name";
        //ddl_dept.DataValueField = "departmentid";
        //ddl_dept.DataSource = ds;
        //ddl_dept.DataBind();
        //ddl_dept.Items.Insert(0, new ListItem("--Select--", "0"));

        string sqlstr = "select dept_type_id, dept_type_name from tbl_internate_department_type where branch_id = " + depttypetid + "";
        // DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddldeptype.DataSource = ds;
        ddldeptype.DataTextField = "dept_type_name";
        ddldeptype.DataValueField = "dept_type_id";
        ddldeptype.DataBind();
        ddldeptype.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void ddl_location_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddep(Convert.ToInt32(ddl_location.SelectedValue));
        //binddepartment();
        //if (ddl_dept.SelectedValue != "0")
        //{
        //    //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
        //    binddeptmet();
        //}
        //if (ddl_designation.SelectedValue != "0")
        //{
        //    //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
        //    binddesig();
        //}

    }


    protected void binddeptmet()
    {
        string sqlstr = "select dd.departmentid, dd.department_name from tbl_internate_departmentdetails dd inner join  tbl_internate_department_type bd on bd.dept_type_id=dd.dept_type_id where dd.dept_type_id = " + ddldeptype.SelectedValue + "";
        // DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_dept.DataTextField = "department_name";
        ddl_dept.DataValueField = "departmentid";
        ddl_dept.DataSource = ds;
        ddl_dept.DataBind();
        ddl_dept.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    protected void binddesig()
    {
        string sqlstr = "select id,designationname from tbl_intranet_designation where departmentid='" + ddl_dept.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_designation.DataTextField = "designationname";
        ddl_designation.DataValueField = "id";
        ddl_designation.DataSource = ds;
        ddl_designation.DataBind();
        ddl_designation.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}