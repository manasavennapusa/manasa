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

public partial class training_edit_trainingprogrammes : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        //message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }
            bind_edittrainingprogrammes();
            bind_trainingname();
            
        }        

    }

    protected void bind_edittrainingprogrammes()
    {
        String sqlstr = "select * from tbl_training_shedulee where id='" + Request.QueryString["id"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
        {
            return;
        }
        try
        {

            txt_approver.Text = ds.Tables[0].Rows[0]["training_code"].ToString();
            ddl_trainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
            ddl_monthedit.Text = ds.Tables[0].Rows[0]["month"].ToString();
            txt_module_name.Value = ds.Tables[0].Rows[0]["module_name"].ToString();
            txt_description.Text = ds.Tables[0].Rows[0]["descriptions"].ToString();
            txt_faculty.Value = ds.Tables[0].Rows[0]["faculty"].ToString();
            txt_fromdate.Text = ds.Tables[0].Rows[0]["fromdate"].ToString();
            txt_noofhours.Value = ds.Tables[0].Rows[0]["noofhours"].ToString();
            txt_bachcode.Value = ds.Tables[0].Rows[0]["bachcode"].ToString();
            txt_training_short_name.Value = ds.Tables[0].Rows[0]["training_shortname"].ToString();
            txt_todate.Text = ds.Tables[0].Rows[0]["todate"].ToString();
            txt_time_of_training.Value = ds.Tables[0].Rows[0]["trainer"].ToString();
            txt_organisation.Value = ds.Tables[0].Rows[0]["organisation"].ToString();
            txt_total_noof_participents.Value = ds.Tables[0].Rows[0]["total_no_of_participants"].ToString();
            txt_cost_of_training.Value = ds.Tables[0].Rows[0]["cost_of_training"].ToString();
            txt_cost_of_training_perhead.Value = ds.Tables[0].Rows[0]["cost_of_training_per_head"].ToString();
       


            if (Convert.ToInt32(ds.Tables[0].Rows[0]["effectiveness_to_be_cond"]) == 1)
            {
                rd_training_effectiveness_yes.Checked = true;
            }
            else
            {
                rd_training_effectiveness_no.Checked = false;
            }

         

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["feedback_to_be_cond"]) == 1)
            {
                rd_training_feedback_yes.Checked = true;
            }
            else
            {
                rd_training_feedback_no.Checked = false;
            }

           

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["action_plan_to_be_cond"]) == 1)
            {
                rd_training_feedback_yes.Checked = true;
            }
            else
            {
                rd_training_feedback_no.Checked = false;
            }

   

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["action_plan_to_be_cond"]) == 1)
            {
                rd_training_feedback_yes.Checked = true;
            }
            else
            {
                rd_training_feedback_no.Checked = false;
            }



            if (Convert.ToInt32(ds.Tables[0].Rows[0]["program"]) == 1)
            {
                programe_yes.Checked = true;
            }
            else
            {
                programe_no.Checked = false;
            }



            if (Convert.ToInt32(ds.Tables[0].Rows[0]["faculty_description"]) == 1)
            {
                facultydescription_yes.Checked = true;
            }
            else
            {
                facultydescription_no.Checked = false;
            }

       

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["any_other"]) == 1)
            {
                anyother_yes.Checked = true;
            }
            else
            {
                anyother_no.Checked = false;
            }

       
        }
        catch { }
        
     
        
    }

    protected void edit_trainingprogrammes()
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        int Flag = 0;
        try
        {
                Connection = Activity.OpenConnection();
            _Transaction = Connection.BeginTransaction();


            SqlParameter[] parm = new SqlParameter[26];

             //Common.Console.Output.AssignParameter(p, 0, "@payhead_name", "String", 50, txt_name.Text.Trim());
             Common.Console.Output.AssignParameter(parm, 0, "@id", "Int", 0, Request.QueryString["id"].ToString());
             Common.Console.Output.AssignParameter(parm, 1, "@training_code", "String", 10, txt_approver.Text);
             Common.Console.Output.AssignParameter(parm, 2, "@training_type", "String", 10, ddl_trainingtype.Text);
             Common.Console.Output.AssignParameter(parm, 3, "@training_name", "String", 50, ddl_trainingname.Text);
             Common.Console.Output.AssignParameter(parm, 4, "@training_shortname", "String", 10, txt_training_short_name.Value);
             Common.Console.Output.AssignParameter(parm, 5, "@fromdate", "DateTime", 0, txt_fromdate.Text);
             Common.Console.Output.AssignParameter(parm, 6, "@todate", "DateTime", 0, txt_todate.Text);
             Common.Console.Output.AssignParameter(parm, 7, "@descriptions", "String", 100, txt_description.Text);
             if (rd_internal.Checked == true)
             {
                 Common.Console.Output.AssignParameter(parm, 8, "@source", "Int", 0, "1");
             }
             else
             {
                 Common.Console.Output.AssignParameter(parm, 8, "@source", "Int", 0, "0");
             }
             Common.Console.Output.AssignParameter(parm, 9, "@trainer", "String", 50, txt_time_of_training.Value);
             Common.Console.Output.AssignParameter(parm, 10, "@organisation", "String", 10, txt_organisation.Value);
             Common.Console.Output.AssignParameter(parm, 11, "@total_no_of_participants", "String", 10, txt_total_noof_participents.Value);
             Common.Console.Output.AssignParameter(parm, 12, "@cost_of_training", "Int", 0, txt_cost_of_training.Value);
             Common.Console.Output.AssignParameter(parm, 13, "@cost_of_training_per_head", "Int", 0, txt_cost_of_training_perhead.Value);

            if (rd_training_effectiveness_yes.Checked == true)
            {
                Common.Console.Output.AssignParameter(parm, 14, "@effectiveness_to_be_cond", "Int", 0, "1");
            }
            else
            {
                Common.Console.Output.AssignParameter(parm, 14, "@effectiveness_to_be_cond", "Int", 0, "0");
            }


            if (rd_training_feedback_yes.Checked == true)
            {
                Common.Console.Output.AssignParameter(parm, 15, "@feedback_to_be_cond", "Int", 0, "1");
            }
            else
            {
                Common.Console.Output.AssignParameter(parm, 15, "@feedback_to_be_cond", "Int", 0, "0");
            }


            if (rd_participants_action_yes.Checked == true)
            {
                Common.Console.Output.AssignParameter(parm, 16, "@action_plan_to_be_cond", "Int", 0, "1");
            }
            else
            {
                Common.Console.Output.AssignParameter(parm, 16, "@action_plan_to_be_cond", "Int", 0, "0");
            }

            Common.Console.Output.AssignParameter(parm, 17, "@module_name", "String", 30, txt_module_name.Value);
            Common.Console.Output.AssignParameter(parm, 18, "@month", "String", 30, ddl_monthedit.Text);
            Common.Console.Output.AssignParameter(parm, 19, "@year", "String", 20, ddl_yearedit.SelectedValue);

            Common.Console.Output.AssignParameter(parm, 20, "@noofhours", "String", 10, txt_noofhours.Value);
            Common.Console.Output.AssignParameter(parm, 21, "@bachcode", "String", 10, txt_bachcode.Value);

            if (programe_yes.Checked == true)
            {
                Common.Console.Output.AssignParameter(parm, 22, "@program ", "Int", 0, "1");
            }
            else
            {
                Common.Console.Output.AssignParameter(parm, 22, "@program ", "Int", 0, "0");
            }


            if (facultydescription_yes.Checked == true)
            {
                Common.Console.Output.AssignParameter(parm, 23, "@faculty_description", "Int", 0, "1");
            }
            else
            {
                Common.Console.Output.AssignParameter(parm, 23, "@faculty_description", "Int", 0, "0");
            }


            if (anyother_yes.Checked == true)
            {
                Common.Console.Output.AssignParameter(parm, 24, "@any_other", "Int", 0, "1");
            }
            else
            {
                Common.Console.Output.AssignParameter(parm, 24, "@any_other", "Int", 0, "0");
            }

            Common.Console.Output.AssignParameter(parm, 25, "@faculty", "String", 30, txt_faculty.Value);

            Flag = Common.Data.SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_training_shedulee_upddate", parm);

            _Transaction.Commit();
            Common.Console.Output.Show("Record saved successfully.");
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
    }

    protected void bind_trainingname()
    {
        string sqlstr = "select training_name from tbl_training_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_trainingname.DataTextField = "training_name";
        //ddl_trainingname.DataValueField = "id";
        ddl_trainingname.DataSource = ds;
        ddl_trainingname.DataBind();
        ddl_trainingname.Items.Insert(0, new ListItem("---Select---", "0"));

    }






    protected void btnsv_Click1(object sender, EventArgs e)
    {
        edit_trainingprogrammes();
    }
}