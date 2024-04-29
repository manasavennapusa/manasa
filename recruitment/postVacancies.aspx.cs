using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_postVacancies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            binddepartment();
            bind_location();
            bindapprover();
            bindOrgheads();
            bind_RRF();
        }

    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void btn_Sumbit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        if (txt_fromdate.Text != "")
            sqlparam[0].Value = txt_fromdate.Text;
        else
            sqlparam[0].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[1] = new SqlParameter("@todate", SqlDbType.DateTime);
        if (txt_todate.Text != "")

            sqlparam[1].Value = txt_todate.Text;
        else
            sqlparam[1].Value = System.Data.SqlTypes.SqlDateTime.Null;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = ddl_dept.SelectedValue;

        sqlparam[3] = new SqlParameter("@location", SqlDbType.Int);
        sqlparam[3].Value = ddl_location.SelectedValue;

        sqlparam[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[4].Value = ddl_raiser.SelectedValue.Trim();

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitmnet_search_rrf", sqlparam);
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
        // cleartext();

    }

    private void cleartext()
    {
        txt_fromdate.Text = "";
        txt_todate.Text = "";
        ddl_raiser.SelectedValue = "0";
        ddl_location.SelectedValue = "0";
        ddl_dept.SelectedValue = "0";
    }
    protected void binddepartment()
    {
        string sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_dept.DataTextField = "department_name";
        ddl_dept.DataValueField = "departmentid";
        ddl_dept.DataSource = ds;
        ddl_dept.DataBind();
        ddl_dept.Items.Insert(0, new ListItem("--ALL--", "0"));
    }


    protected void bindapprover()
    {
        string sqlstr = "select empcode,emp_fname+''+emp_m_name+''+emp_l_name as name from dbo.tbl_intranet_employee_jobDetails";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_raiser.DataTextField = "name";
        ddl_raiser.DataValueField = "empcode";
        ddl_raiser.DataSource = ds;
        ddl_raiser.DataBind();
        ddl_raiser.Items.Insert(0, new ListItem("--ALL--", "0"));
    }
    protected void bindOrgheads()
    {
        //string sqlstr = "select empcode,emp_fname+''+emp_m_name+''+emp_l_name as name from dbo.tbl_intranet_employee_jobDetails";
        //DataSet ds = new DataSet();
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //ddl_org_head.DataTextField = "name";
        //ddl_org_head.DataValueField = "empcode";
        //ddl_org_head.DataSource = ds;
        //ddl_org_head.DataBind();
        //ddl_org_head.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_location()
    {
        string sqlstr = "select cid,city from tbl_intranet_city ";
        DataSet ds7 = new DataSet();
        ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_location.DataSource = ds7;
        ddl_location.DataTextField = "city";
        ddl_location.DataValueField = "cid";
        ddl_location.DataBind();
        ddl_location.Items.Insert(0, new ListItem("--ALL--", "0"));

    }

    protected void bind_RRF()
    {
        //SqlParameter[] sqlparam = new SqlParameter[1];
        //sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        //sqlparam[0].Value = Session["empcode"].ToString();

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }

    protected void btnsend_Click(object sender, EventArgs e)
    {
        string Body = "";
        bool Flag = false;

        // Prepare body for all RRF first

        foreach (GridViewRow row in grdRRF.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");


            if (ChkBoxRows.Checked == true)
            {
                HiddenField rrfcode = (HiddenField)row.FindControl("hfrrfcode");
                HiddenField rrfid = (HiddenField)row.FindControl("hfid");

                Body += "<br/><p>" + GenerateBody(rrfid.Value) + "</p><br/><br/>";

                Flag = true;
            }
        }

        if (Flag)
        {

            SendMailToEmployees(hidd_empcode.Value, Body);
            SendMailToJobSites(hfid.Value, Body);
            Common.Console.Output.Show("Submitted Successfully");
        }
    }

    protected void SendMailToEmployees(string empcode, string body)
    {
        string emplist = empcode.Replace(",", "','");
        string sqlstr = @"select empcode, official_email_id, emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname 
from tbl_intranet_employee_jobDetails 
where empcode in ('" + emplist + "')";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (ds1.Tables[0].Rows[i]["official_email_id"].ToString() != "")
                {
                    Smart.HR.Common.Mail.Module.Email email = new Smart.HR.Common.Mail.Module.Email();

                    email.FromEmailId = ConfigurationManager.AppSettings["fromEmail"].ToString();
                    email.Password = ConfigurationManager.AppSettings["pwd"].ToString();
                    email.FromName = ConfigurationManager.AppSettings["fromName"].ToString();
                    email.SMTP = ConfigurationManager.AppSettings["smtp"].ToString();
                    email.ToEmailId = ds1.Tables[0].Rows[i]["official_email_id"].ToString();
                    email.Subject = "Regarding Vacencies in our Company";

                    string preBody = "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Dear " + ds1.Tables[0].Rows[i]["empname"].ToString() + ",</p>";
                    preBody += "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Please refer candidates for the following RRF.</p>";

                    string postBody = "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Thanks</p>";
                    postBody += "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>AB Mauri India - HR Team</p>";

                    email.Body = preBody + body + postBody;
                    email.Send();
                }
            }
        }
    }

    protected void SendMailToJobSites(string ids, string body)
    {
        if (ids != "")
        {
            string sqlstr = @"select organizationname, email from tbl_recruitment_jobsite_master where id  in (" + ids + ")";

            DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i]["email"].ToString() != "")
                    {
                        Smart.HR.Common.Mail.Module.Email email = new Smart.HR.Common.Mail.Module.Email();

                        email.FromEmailId = ConfigurationManager.AppSettings["fromEmail"].ToString();
                        email.Password = ConfigurationManager.AppSettings["pwd"].ToString();
                        email.FromName = ConfigurationManager.AppSettings["fromName"].ToString();
                        email.SMTP = ConfigurationManager.AppSettings["smtp"].ToString();
                        email.ToEmailId = ds1.Tables[0].Rows[i]["email"].ToString();
                        email.Subject = "Regarding Vacencies in our Company";
                        email.Subject = "Regarding Vacencies in our Company";

                        string preBody = "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Dear " + ds1.Tables[0].Rows[i]["organizationname"].ToString() + ",</p>";
                        preBody += "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Please refer candidates for the following RRF.</p>";

                        string postBody = "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Thanks</p>";
                        postBody += "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>AB Mauri India - HR Team</p>";

                        email.Body = preBody + body + postBody;
                        email.Send();
                    }
                }
            }
        }
    }

    protected string GenerateBody(string selectedRRFs)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@ids", SqlDbType.VarChar, 100);
        sqlparam[0].Value = selectedRRFs;

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_byIDs", sqlparam);
        StringBuilder str = new StringBuilder();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            str.Append("<table style='border-collapse:collapse;'><tr>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif;padding:10px; border:1px solid #ddd;'><b>SL#</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif;padding:10px; border:1px solid #ddd;'><b>RRF&nbsp;Code</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Total&nbsp;No of&nbsp;Posts</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Request&nbsp;Type</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Vacancy&nbsp;Type</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Expected&nbsp;CTC</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Reasons&nbsp;of&nbsp;Request</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Shift&nbsp;Hours</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Industries&nbsp;Prefered</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Skills&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Experience (In Months)</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Location&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Department&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Designation&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>Additional&nbsp;Qualifiers</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Job&nbsp;Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>");
            str.Append("<td style='background-color:#90C3D4; color:#fff; font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Educational&nbsp;Qualification&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>");
            str.Append("</tr>");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (ds1.Tables[0].Rows[i]["designationname"].ToString() != "")
                {
                    str.Append("<tr>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(i + 1);
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["rrf_code"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["total_no_posts"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["requesttype"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["vacancytype"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["expectedCTC"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["reasons_of_request"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["shift_hours"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["industries_preferred"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["skills"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["experience"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["location"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["department_name"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["designationname"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["additional_qualifiers"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["job_description"].ToString());
                    str.Append("</td>");

                    str.Append("<td style='font-size:11.0pt;font-family:Calibri,sans-serif; padding:10px; border:1px solid #ddd;'>");
                    str.Append(ds1.Tables[0].Rows[i]["educational_qualifications"].ToString());
                    str.Append("</td>");


                    str.Append("</tr>");
                }
            }
            str.Append("</table>");
        }

        return str.ToString();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txt_employee.Text = "";
        txtjobconsult.Text = "";
        foreach (GridViewRow row in grdRRF.Rows)
        {
            if(row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkrow = (CheckBox)row.FindControl("chkselect");
               if(chkrow.Checked)
                   chkrow.Checked = false;
            }
        }
    }
}