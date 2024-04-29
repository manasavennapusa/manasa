using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Training_edittrainingschedule : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string bodyContent;
    string sqlstr, _userCode, _companyId, RoleId,tid,trainingcode,fromdate,todate,modulename,deptid;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
   {
        if (Session["role"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            //tid = Request.QueryString["id"].ToString();

            if (Request.QueryString["trainingcode"].ToString() != null)
            {
                trainingcode = Request.QueryString["trainingcode"].ToString();
                fromdate = Request.QueryString["FromDate"].ToString();
                todate = Request.QueryString["ToDate"].ToString();
                modulename = Request.QueryString["modulename"].ToString();
                deptid= Request.QueryString["dept_id"].ToString();
            }

            if (!IsPostBack)
            {
                bindtrainingcode();
                branchname();
                binddepartmenttypee();
                bindtriningschedule();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void bindtriningschedule()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select id,training_code,training_name,ts.branch,ts.dept_type,ts.dept_name,ts.tds,module_name,descriptions,
month,bachcode,CONVERT(varchar(40), ts.fromdate, 106) as FromDate,CONVERT(varchar(40), ts.todate, 106) as ToDate,
training_type,training_shortname,year,trainer,faculty,noofhours,source_internal,
effectiveness_to_be_cond,feedback_to_be_cond,action_plan_to_be_cond,program,faculty_description,any_other 
from dbo.tbl_training_schedul ts
inner join tbl_intranet_branch_detail bd on ts.branch=bd.branch_id
inner join tbl_internate_department_type dt on ts.dept_type=dt.dept_type_id
inner join tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
where ts.training_code='" + trainingcode + "' and CONVERT(varchar(40), ts.fromdate, 106)='" + fromdate + "' and CONVERT(varchar(40), ts.todate, 106)='" + todate + "' and ts.dept_name='" + deptid + "'";

            DataSet ds1 = new DataSet();
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            lbl_id.Text = ds.Tables[0].Rows[0]["id"].ToString();
            ddltrainingcode.Text = ds.Tables[0].Rows[0]["training_code"].ToString();
            txttrainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
            ddl_department.SelectedValue = ds.Tables[0].Rows[0]["dept_type"].ToString();
            ddl_branch_id.SelectedValue = ds.Tables[0].Rows[0]["branch"].ToString();
            //ddl_department.Text;

            bind_departmnt(ds.Tables[0].Rows[0]["dept_name"].ToString());
            lst_deptname.SelectedValue = ds.Tables[0].Rows[0]["dept_name"].ToString();
           
            txt_module_name.Text = ds.Tables[0].Rows[0]["module_name"].ToString();
            txt_description.Text = ds.Tables[0].Rows[0]["descriptions"].ToString();
            ddl_month.SelectedValue = ds.Tables[0].Rows[0]["month"].ToString();
            txt_fromdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Fromdate"]).ToString("dd MMM yyyy");
            txt_bachcode.Text = ds.Tables[0].Rows[0]["bachcode"].ToString();
            ddl_trainingtype.SelectedValue = ds.Tables[0].Rows[0]["training_type"].ToString();
            txt_training_short_name.Text = ds.Tables[0].Rows[0]["training_shortname"].ToString();
            ddlyear.SelectedValue = ds.Tables[0].Rows[0]["year"].ToString();
            txt_todate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Todate"]).ToString("dd MMM yyyy");
            txt_time_of_training.Text = ds.Tables[0].Rows[0]["trainer"].ToString();
            txt_faculty.Text = ds.Tables[0].Rows[0]["faculty"].ToString();
            txt_noofhours.Text = ds.Tables[0].Rows[0]["noofhours"].ToString();
            //txt_Epfoffadd.Text = ds.Tables[0].Rows[0]["tds"].ToString();
            if (ds.Tables[0].Rows[0]["source_internal"].ToString() == "1")
            {
                rd_internal.Checked = true;
                rd_external.Checked = false;              
            }
            else if (ds.Tables[0].Rows[0]["source_internal"].ToString() == "2")
            {
                rd_internal.Checked = false;
                rd_external.Checked = true;
            }
            else
            {
                rd_internal.Checked = false;
                rd_external.Checked = false;
            }


            if (ds.Tables[0].Rows[0]["effectiveness_to_be_cond"].ToString() == "1")
            {
                rd_training_effectiveness_yes.Checked = true;
                rd_training_effectiveness_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["effectiveness_to_be_cond"].ToString() == "2")
            {
                rd_training_effectiveness_yes.Checked = false;
                rd_training_effectiveness_no.Checked = true;
            }
            else
            {
                rd_training_effectiveness_yes.Checked = false;
                rd_training_effectiveness_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["feedback_to_be_cond"].ToString() == "1")
            {
                rd_training_feedback_yes.Checked = true;
                rd_training_feedback_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["feedback_to_be_cond"].ToString() == "2")
            {
                rd_training_feedback_yes.Checked = false;
                rd_training_feedback_no.Checked = true;
            }
            else
            {
                rd_training_feedback_yes.Checked = false;
                rd_training_feedback_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["action_plan_to_be_cond"].ToString() == "1")
            {
                rd_participants_action_yes.Checked = true;
                rd_participants_action_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["action_plan_to_be_cond"].ToString() == "2")
            {
                rd_participants_action_yes.Checked = false;
                rd_participants_action_no.Checked = true;
            }
            else
            {
                rd_participants_action_yes.Checked = false;
                rd_participants_action_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["program"].ToString() == "1")
            {
                programe_yes.Checked = true;
                programe_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["program"].ToString() == "2")
            {
                programe_yes.Checked = false;
                programe_no.Checked = true;
            }
            else
            {
                programe_yes.Checked = false;
                programe_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["faculty_description"].ToString() == "1")
            {
                facultydescription_yes.Checked = true;
                facultydescription_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["faculty_description"].ToString() == "2")
            {
                facultydescription_yes.Checked = false;
                facultydescription_no.Checked = true;
            }
            else
            {
                facultydescription_yes.Checked = false;
                facultydescription_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["any_other"].ToString() == "1")
            {
                anyother_yes.Checked = true;
                anyother_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["any_other"].ToString() == "2")
            {
                anyother_yes.Checked = false;
                anyother_no.Checked = true;
            }
            else
            {
                anyother_yes.Checked = false;
                anyother_no.Checked = false;
            }

          
        }
        catch (Exception ex)
        {
            Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void binddepartmenttypee()
    {
        string sqlstr = "select dept_type_name,dept_type_id from dbo.tbl_internate_department_type";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_department.DataTextField = "dept_type_name";
        ddl_department.DataValueField = "dept_type_id";
        ddl_department.DataSource = ds;
        ddl_department.DataBind();
        //ddl_department.Items.Insert(0, new ListItem("---Select---", "0"));

    }

    protected void bind_departmnt(string dept)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails where departmentid='" + dept + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            lst_deptname.DataTextField = "department_name";
            lst_deptname.DataValueField = "departmentid";
            lst_deptname.DataSource = ds1;
            lst_deptname.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void branchname()
    {
        string sqlstr = "select branch_id,branch_name from dbo.tbl_intranet_branch_detail";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_branch_id.DataTextField = "branch_name";
        ddl_branch_id.DataValueField = "branch_id";
        ddl_branch_id.DataSource = ds;
        ddl_branch_id.DataBind();
       // ddl_branch_id.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    private void bindtrainingname()
    {
       
    }

    private void bindtrainingcode()
    {
        string sqlstr = "select training_type_id from tbl_training_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //ddltrainingcode.DataTextField = "training_name";
        ddltrainingcode.DataValueField = "training_type_id";
        ddltrainingcode.DataSource = ds;
        ddltrainingcode.DataBind();
        //ddltrainingcode.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    protected void rd_internal_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rd_external_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void lst_deptname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedValue != "0")
        {
            if (txt_fromdate.Text != "")
            {
                if (ddlyear.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                {
                    Output.Show("Wrong Year Selected");
                    ddlyear.Focus();
                }
            }
            if (txt_todate.Text != "")
            {
                if (ddlyear.SelectedValue != Convert.ToDateTime(txt_todate.Text).ToString("yyyy"))
                {
                    Output.Show("Wrong Year Selected");
                    ddlyear.Focus();
                }
            }
        }
    }

    protected void ddltrainingcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlstr = "select training_name from tbl_training_master where training_type_id='" + ddltrainingcode.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txttrainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
        }

    }

    protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
    {

        string sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails where dept_type_id='" + ddl_department.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        lst_deptname.DataTextField = "department_name";
        lst_deptname.DataValueField = "departmentid";
        lst_deptname.DataSource = ds;
        lst_deptname.DataBind();
        //lst_deptname.Items.Insert(0, new ListItem("---Select---", "0"));


    }

    protected void ddl_branch_id_SelectedIndexChanged(object sender, EventArgs e)
    {
       // ddltrainingcode.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    protected void btnsv_Click(object sender, EventArgs e)
    {
        insert_trainingshedule();
    }

    private void insert_trainingshedule()
    {
        if (lst_deptname.SelectedIndex != -1)
        {
            DateTime t2 = Convert.ToDateTime(txt_fromdate.Text);
            string month = Convert.ToString(t2.Month);
            if (ddl_month.SelectedValue != month)
            {
                Output.Show("Wrong Month Selected");
                return;
                ddl_month.Focus();
            }

            DateTime t3 = Convert.ToDateTime(txt_fromdate.Text);
            string year = Convert.ToString(t3.Year);

            if (ddlyear.SelectedValue != year)
            {
                Output.Show("Wrong Year Selected");
                return;
                ddlyear.Focus();
            }
            //else
            //{
            if (txt_fromdate.Text != "" && txt_todate.Text != "")
            {
                if (Convert.ToDateTime(txt_fromdate.Text) > Convert.ToDateTime(txt_todate.Text))
                {
                    Output.Show("To date should always be greater than or equal to From date");
                    return;
                    txt_todate.Text = "";
                    txt_todate.Focus();
                }
            }

            var parm = new SqlParameter[27];
            SqlTransaction transaction = null;
            //var activity = new DataActivity();
            int flag = 0;
            try
            {
                //if (lst_deptname.SelectedIndex != -1)
                //{

                foreach (ListItem item in lst_deptname.Items)
                {
                    if (item.Selected)
                    {

                        Output.AssignParameter(parm, 0, "@training_code", "String", 50, ddltrainingcode.SelectedValue);
                        Output.AssignParameter(parm, 1, "@training_name", "String", 150, txttrainingname.Text);
                        Output.AssignParameter(parm, 2, "@branch", "Int", 0, ddl_branch_id.SelectedValue);
                        Output.AssignParameter(parm, 3, "@dept_type", "Int", 0, ddl_department.SelectedValue);
                        Output.AssignParameter(parm, 4, "@dept_name", "Int", 0, item.Value);
                        Output.AssignParameter(parm, 5, "@module_name", "String", 150, txt_module_name.Text);
                        Output.AssignParameter(parm, 6, "@descriptions", "String", 1000, txt_description.Text);
                        Output.AssignParameter(parm, 7, "@month", "String", 50, ddl_month.SelectedValue);
                        Output.AssignParameter(parm, 8, "@fromdate", "DateTime", 0, txt_fromdate.Text);
                        Output.AssignParameter(parm, 9, "@bachcode", "String", 50, txt_bachcode.Text);
                        Output.AssignParameter(parm, 10, "@training_type", "String", 50, ddl_trainingtype.SelectedItem.Text);
                        Output.AssignParameter(parm, 11, "@training_shortname", "String", 150, txt_training_short_name.Text);
                        Output.AssignParameter(parm, 12, "@year", "String", 50, ddlyear.SelectedItem.Text);
                        Output.AssignParameter(parm, 13, "@todate", "DateTime", 0, txt_todate.Text);
                        Output.AssignParameter(parm, 14, "@trainer", "String", 150, txt_time_of_training.Text);
                        Output.AssignParameter(parm, 15, "@faculty", "String", 50, txt_faculty.Text);
                        Output.AssignParameter(parm, 16, "@noofhours", "String", 50, txt_noofhours.Text);
                        if (rd_internal.Checked)
                        {
                            Output.AssignParameter(parm, 17, "@source_internal", "Int", 0, "1");
                        }
                        else if (rd_external.Checked)
                        {
                            Output.AssignParameter(parm, 17, "@source_internal", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 17, "@source_internal", "Int", 1, "0");
                        }

                        if (rd_training_effectiveness_yes.Checked)
                        {
                            Output.AssignParameter(parm, 18, "@effectiveness_to_be_cond", "Int", 0, "1");
                        }
                        else if (rd_training_effectiveness_no.Checked)
                        {
                            Output.AssignParameter(parm, 18, "@effectiveness_to_be_cond", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 18, "@effectiveness_to_be_cond", "Int", 0, "0");
                        }

                        if (rd_training_feedback_yes.Checked)
                        {
                            Output.AssignParameter(parm, 19, "@feedback_to_be_cond", "Int", 0, "1");
                        }
                        else if (rd_training_feedback_no.Checked)
                        {
                            Output.AssignParameter(parm, 19, "@feedback_to_be_cond", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 19, "@feedback_to_be_cond", "Int", 0, "0");
                        }

                        if (rd_participants_action_yes.Checked)
                        {
                            Output.AssignParameter(parm, 20, "@action_plan_to_be_cond", "Int", 0, "1");
                        }
                        else if (rd_participants_action_no.Checked)
                        {
                            Output.AssignParameter(parm, 20, "@action_plan_to_be_cond", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 20, "@action_plan_to_be_cond", "Int", 0, "0");
                        }

                        if (programe_yes.Checked)
                        {
                            Output.AssignParameter(parm, 21, "@program ", "Int", 0, "1");
                        }
                        else if (programe_no.Checked)
                        {
                            Output.AssignParameter(parm, 21, "@program ", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 21, "@program ", "Int", 0, "0");
                        }

                        if (facultydescription_yes.Checked)
                        {
                            Output.AssignParameter(parm, 22, "@faculty_description", "Int", 0, "1");
                        }
                        else if (facultydescription_no.Checked)
                        {
                            Output.AssignParameter(parm, 22, "@faculty_description", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 22, "@faculty_description", "Int", 0, "0");
                        }

                        if (anyother_yes.Checked)
                        {
                            Output.AssignParameter(parm, 23, "@any_other", "Int", 0, "1");
                        }
                        else if (anyother_no.Checked)
                        {
                            Output.AssignParameter(parm, 23, "@any_other", "Int", 0, "2");
                        }
                        else
                        {
                            Output.AssignParameter(parm, 23, "@any_other", "Int", 0, "0");
                        }

                        Output.AssignParameter(parm, 24, "@createdby", "String", 50, _userCode);
                        Output.AssignParameter(parm, 25, "@id", "Int", 0, lbl_id.Text);
                        Output.AssignParameter(parm, 26, "@tds", "String", 100, "");

                        SqlConnection connection = activity.OpenConnection();
                        transaction = connection.BeginTransaction();
                        flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_update_training_schedul", parm);
                        transaction.Commit();

                    }
                }

            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                if (flag > 0)
                {
                    Response.Redirect("viewtrainingschedule.aspx?upd=true");
                }
                else
                {
                    Response.Redirect("viewtrainingschedule.aspx?notupd=true");
                }
            }
        }
        else
        {
            Output.Show("Select Department Name");
            lst_deptname.Focus();
        }
    }

    private void Clear()
    {
       // ddltrainingcode.SelectedValue = "0";
        txttrainingname.Text = "";
        ddl_branch_id.SelectedValue = "0";
        ddl_department.SelectedValue = "0";
        lst_deptname.SelectedValue = "0";
        txt_module_name.Text = "";
        txt_description.Text = "";
        ddl_month.SelectedValue = "0";
        txt_fromdate.Text = "";
        txt_bachcode.Text = "";
        ddl_trainingtype.Text = "0";
        txt_training_short_name.Text = "";
        ddlyear.SelectedValue = "0";
        txt_todate.Text = "";
        txt_time_of_training.Text = "";
        txt_faculty.Text = "";
        txt_noofhours.Text = "";
        rd_internal.Checked = false;
        rd_training_effectiveness_yes.Checked = false;
        rd_training_feedback_yes.Checked = false;
        rd_participants_action_yes.Checked = false;
        programe_yes.Checked = false;
        facultydescription_yes.Checked = false;
        anyother_yes.Checked = false;       
    }

    protected void ddltrainingcode_DataBound(object sender, EventArgs e)
    {
        // ddltrainingcode.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_trainingtype_DataBound(object sender, EventArgs e)
    {
        ddl_trainingtype.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_department_DataBound(object sender, EventArgs e)
    {
        ddl_department.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_branch_id_DataBound(object sender, EventArgs e)
    {
        ddl_branch_id.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void lst_deptname_DataBound(object sender, EventArgs e)
    {
        //lst_deptname.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void txt_fromdate_TextChanged(object sender, EventArgs e)
    {
        if (ddl_month.SelectedValue != "0")
        {
            if (ddlyear.SelectedValue != "0" && txt_fromdate.Text!="")
            {
                if (ddl_month.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("MMM"))
                {
                    Output.Show("Wrong Month Selected");
                    ddl_month.Focus();
                    ddl_month.SelectedValue = "0";
                }
                else if(ddlyear.SelectedItem.Text != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                {
                    Output.Show("Wrong Year Selected");
                    ddlyear.Focus();
                    ddlyear.SelectedValue = "0";
                }
                else
                {
                    if (txt_todate.Text != "" && txt_fromdate.Text != "")
                    {
                        if (Convert.ToDateTime(txt_fromdate.Text) > Convert.ToDateTime(txt_todate.Text))
                        {
                            Output.Show("To date should always be greater than or equal to From date");
                            txt_fromdate.Text = "";
                            txt_fromdate.Focus();
                        }
                    }
                }
            }
            else
            {
                //Output.Show("Please Select Year");
                //ddlyear.Focus();
            }
        }
        else
        {
            //Output.Show("Please Select Month");
            //ddl_month.Focus();
        }
    }

    protected void txt_todate_TextChanged(object sender, EventArgs e)
    {
        if (ddl_month.SelectedValue != "0")
        {
            if (ddlyear.SelectedValue != "0" && txt_fromdate.Text!="")
            {
                if (ddl_month.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("MMM"))
                {
                    Output.Show("Wrong Month Selected");
                    ddl_month.Focus();
                }
                else if (ddlyear.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                {
                    Output.Show("Wrong Year Selected");
                    ddlyear.Focus();
                }
                else
                {
                    if (txt_fromdate.Text != "" && txt_todate.Text != "")
                    {
                        if (Convert.ToDateTime(txt_fromdate.Text) > Convert.ToDateTime(txt_todate.Text))
                        {
                            Output.Show("To date should always be greater than or equal to From date");
                            txt_todate.Text = "";
                            txt_todate.Focus();
                        }
                    }
                    else if (ddl_month.SelectedValue != Convert.ToDateTime(txt_fromdate.Text).ToString("yyyy"))
                    {
                        Output.Show("Wrong Year Selected");
                        ddlyear.Focus();
                    }
                    else
                    {
                        Output.Show("Please select From Date");
                        txt_fromdate.Focus();
                        txt_todate.Text = "";
                    }
                }
            }
            else
            {
                //Output.Show("Please Select Year");
                //ddlyear.Focus();
            }
        }
        else
        {
            //Output.Show("Please Select Month");
            //ddl_month.Focus();
        }
    }

    protected void ddl_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_month.SelectedValue != "0")
        {
            if (txt_fromdate.Text != "")
            {
                if (ddl_month.SelectedItem.Text != Convert.ToDateTime(txt_fromdate.Text).ToString("MMM"))
                {
                    Output.Show("Wrong Month Selected");
                    ddl_month.Focus();
                }
            }
            if (txt_todate.Text != "")
            {
                if (ddl_month.SelectedItem.Text != Convert.ToDateTime(txt_todate.Text).ToString("MMM"))
                {
                    Output.Show("Wrong Month Selected");
                    ddl_month.Focus();
                }
            }
        }
    }


}