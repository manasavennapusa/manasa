﻿using DataAccessLayer;
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
using System.IO;
using System.Globalization;

public partial class recruitment_candidateRegistrationForm : System.Web.UI.Page
{
    string _path;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_Applied_date.Text = DateTime.Now.ToString("dd'-'MMM'-'yyyy");
        
        if (!IsPostBack)
        {
            BindDesignation();
            if (Session["role"] != null)
            {
                //Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            //bindddlrrfcode();
            bindConsultancy();
            //binddesignation();
           // bindgrid();
        }
       // CompareValidatordob.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
        _path = HttpContext.Current.Request.Url.AbsolutePath;
        //bindlabel();
    }

//    protected void bindgrid()
//    {
//        string sqlstr =@"select candidate_name,dob,candidate_address,phone,mobile,emailid,Qualification,skills,experience,joinstatus,  expectedsalary,referredby,
//  referrername,achievements,uploadresume,passportno,passportvalidity,note,gender,consultancy_id,designation_id  from tbl_recruitment_candidate_registration where status=1 and id not in(select candidateid  from tbl_recruitment_candidate_interview)";
//        DataSet ds = new DataSet();
//        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
//        if (ds.Tables[0].Rows.Count < 1)
//            return;
//        txt_email.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
//        txt_candidateName.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
//        txt_phoneno.Text = ds.Tables[0].Rows[0]["phone"].ToString();
//        txt_Qualifications.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
//        txt_Dob.Text = ds.Tables[0].Rows[0]["dob"].ToString();
       
//        rbtnl_refferred.SelectedValue = ds.Tables[0].Rows[0]["consultancy_id"].ToString();
//        if (rbtnl_refferred.SelectedValue.Trim() == "0")
//        {
//            txt_referredby.Text = ds.Tables[0].Rows[0]["referredby"].ToString();
//        }
//        else
//        {
//            ddlConsultancy.SelectedValue = ds.Tables[0].Rows[0]["referredby"].ToString();
//        }

//        txt_Address.Text = ds.Tables[0].Rows[0]["candidate_address"].ToString();
//        txt_notes.Text = ds.Tables[0].Rows[0]["note"].ToString();
//        txt_mobileno.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
//        drpdesig.Text = ds.Tables[0].Rows[0]["designation_id"].ToString();
//        txt_experience.Text = ds.Tables[0].Rows[0]["experience"].ToString();
//        ddl_gender.Text = ds.Tables[0].Rows[0]["gender"].ToString();
//        txt_joinstatus.Text = ds.Tables[0].Rows[0]["joinstatus"].ToString();
//        txt_passportno.Text = ds.Tables[0].Rows[0]["passportno"].ToString();
//        txt_passportvalidity.Text = ds.Tables[0].Rows[0]["passportvalidity"].ToString();
//        txt_expSalary.Text = ds.Tables[0].Rows[0]["expectedsalary"].ToString();
//        txt_skills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
//        txt_achievements.Text = ds.Tables[0].Rows[0]["achievements"].ToString();

//    }

    //protected void bindlabel()
    //{
    //    SqlParameter[] sqlparam = new SqlParameter[1];
    //    Output.AssignParameter(sqlparam, 0, "@path", "String", 100, _path);
    //    DataSet ds = new DataSet();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ToString(), CommandType.StoredProcedure, "sp_getmenulable", sqlparam);
    //    if (ds.Tables[0].Rows.Count >= 1)
    //    {
    //        lblheader.Text = ds.Tables[0].Rows[0]["menulist"].ToString();
    //    }
    //}

    private void BindDesignation()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select  id,designationname FROM tbl_intranet_designation";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_designation.DataSource = ds;
                txt_designation.DataTextField = "designationname";
                txt_designation.DataValueField = "id";
                txt_designation.DataBind();
                txt_designation.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }


    protected void bindConsultancy()
    {
        string sqlstr = "select id,organizationname from tbl_recruitment_jobsite_master ";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlConsultancy.DataSource = ds;
        ddlConsultancy.DataTextField = "organizationname";
        ddlConsultancy.DataValueField = "id";
        ddlConsultancy.DataBind();
        ddlConsultancy.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    private void cleartext()
    {
        txt_achievements.Text = "";
        txt_Address.Text = "";
        txt_candidateName.Text = "";
        txt_Dob.Text = "";
        txt_email.Text = "";
        txt_experience.Text = "";
        txt_skills.Text = "";
        txt_expSalary.Text = "";
        txt_joinstatus.Text = "";
        txt_mobileno.Text = "";
        //drpdesig.SelectedValue = "0";
        txt_designation.SelectedValue = "0";
        txt_notes.Text = "";
        txt_Applied_date.Text = "";
        txt_passportno.Text = "";
        txt_passportvalidity.Text = "";
        txt_phoneno.Text = "";
        txt_Qualifications.Text = "";
        txt_referredby.Text = "";
        //rbtnl_refferred.SelectedValue = null;
        ddl_gender.SelectedValue = "0";
        ddlConsultancy.SelectedValue = "0";
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        insertdata();
    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void insertdata()
    {
        
        //string inputString = txt_Dob.Text;
        //string[] dateSplit = inputString.Split('/');
        //if (Convert.ToInt32(dateSplit[1]) > 12)
        //{
        //    try
        //    {
               
        //    }
        //    catch (Exception ex)
        //    {
        //        Output.Show("Please Enter The Correct Date Format dd-MMM-yyyy!!!");
        //        return;
        //    }
        //    finally
        //    {
        //        //activity.CloseConnection();
        //    }
        //}
        //DateTime date = Convert.ToDateTime(txt_Dob.Text);
        //DateTime date = DateTime.ParseExact(txt_Dob.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //string inputString = txt_Dob.Text;
        ////DateTime dDate;
        //if (String.Format("dd/MM/yyyy") == inputString)
        //{
        //    //String.Format("{0:dd/MM/yyyy}", dDate);
        //}
        //else
        //{
        //    Output.Show("Invalid"); // <-- Control flow goes here
        //    return;
        //}


        //DateTime date = DateTime.ParseExact(txt_Dob.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);

        if (txt_Dob.Text != "")
        {
            if (Convert.ToDateTime(txt_Dob.Text) > DateTime.Now)
            {
                Output.Show("Date Of Birth should be less than or  equal to current date");
                txt_Dob.Text = "";
                return;
                
            }

        }
        else
        {
            Output.Show("Please Enter Date Of Birth");
        }

        string resume = "";
        if (fp_resume.HasFile)
        {
            string strFileName;
            string file_name = "RES" + System.DateTime.Now.GetHashCode().ToString();

            strFileName = fp_resume.FileName;
          
            if (Path.GetExtension(strFileName) != ".doc" && Path.GetExtension(strFileName) != ".docx" && Path.GetExtension(strFileName) != ".pdf")
            {
                Output.Show("Selected file is invlaid. Please select .doc file only.");
                return;
            }
           
            try
            {
                fp_resume.PostedFile.SaveAs(Server.MapPath("~/recruitment/upload/" + file_name + "_" + strFileName));
                resume = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            resume = "";
        }      

        SqlParameter[] sqlparam = new SqlParameter[22];
        int i = 0;
        try
        {
            Output.AssignParameter(sqlparam, 0, "@candidate_name", "String", 100, txt_candidateName.Text);
            //Output.AssignParameter(sqlparam, 1, "@dob", "DateTime", 0, date.ToString());
            Output.AssignParameter(sqlparam, 1, "@dob", "DateTime", 0, txt_Dob.Text);
            Output.AssignParameter(sqlparam, 2, "@candidate_address", "String", 1000, txt_Address.Text);
            Output.AssignParameter(sqlparam, 3, "@phone", "String", 50, txt_phoneno.Text);
            Output.AssignParameter(sqlparam, 4, "@mobile", "String", 50, txt_mobileno.Text);
            Output.AssignParameter(sqlparam, 5, "@emailid", "String", 50, txt_email.Text);
            Output.AssignParameter(sqlparam, 6, "@Qualification", "String", 50, txt_Qualifications.Text);
            Output.AssignParameter(sqlparam, 7, "@skills", "String", 1000, txt_skills.Text);
            Output.AssignParameter(sqlparam, 8, "@experience", "String", 20, txt_experience.Text);
            Output.AssignParameter(sqlparam, 9, "@joinstatus", "Int", 0, txt_joinstatus.Text);
            Output.AssignParameter(sqlparam, 10, "@expectedsalary", "Decimal", 0, txt_expSalary.Text);
            Output.AssignParameter(sqlparam, 11, "@referredby", "String", 50, rbtnl_refferred.SelectedValue);
            Output.AssignParameter(sqlparam, 12, "@referrername", "String", 50, txt_referredby.Text);
            Output.AssignParameter(sqlparam, 13, "@achievements", "String", 1000, txt_achievements.Text);
            Output.AssignParameter(sqlparam, 14, "@uploadresume", "String", 50, resume);
            Output.AssignParameter(sqlparam, 15, "@passportno", "String", 50, txt_passportno.Text);
            Output.AssignParameter(sqlparam, 16, "@passportvalidity", "String", 50, txt_passportvalidity.Text);
            Output.AssignParameter(sqlparam, 17, "@note", "String", 1000, txt_notes.Text);
            Output.AssignParameter(sqlparam, 18, "@gender", "String", 10, ddl_gender.SelectedItem.ToString());
            Output.AssignParameter(sqlparam, 19, "@consultancy", "Int", 0, ddlConsultancy.SelectedValue);
            //Output.AssignParameter(sqlparam, 20, "@designation", "String", 0, drpdesig.SelectedItem.ToString());
            Output.AssignParameter(sqlparam, 20, "@designation", "String", 50, txt_designation.SelectedItem.Text);
            Output.AssignParameter(sqlparam, 21, "@Applied_Date", "DateTime", 0, txt_Applied_date.Text);

            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_candidate", sqlparam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

        if (i <= 0)
        {
            Output.Show("Candidate Name/Email/Mobile Num already exists, please enter another");
        }
        else
        {
            Output.Show("Candidate Registered Successfully");
            cleartext();
        }
    }

    protected void btn_check_Click(object sender, EventArgs e)
    {
        int flag = 0;
        string sqlstr = "select count(*) from tbl_recruitment_candidate_registration where mobile='" + txt_mobileno.Text.Trim() + "'";

        flag = Convert.ToInt32(SQLServer.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr));

        if (txt_mobileno.Text == "")
        {
            Output.Show("Please Write Mobile Number");
        }
        else
        {
            if (flag > 0)
            {
                Output.Show("Mobile Number already exists, please enter another");
            }
            else
            {
                Output.Show("Mobile Number Not Registered");
            }
        }

    }

    protected void rbtnl_refferred_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_refferred.SelectedValue == "Consultancy")
        {
            ddlConsultancy.Visible = true;
            txt_referredby.Visible = false;
        }
        else
        {
            ddlConsultancy.Visible = false;
            txt_referredby.Visible = true;
        }
    }

    protected void drpdesig_DataBound(object sender, EventArgs e)
    {

    }

    protected void drpdesig_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    //protected void binddesignation()
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        string sqlstr = "select  id,designationname FROM tbl_intranet_designation";
    //        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            drpdesig.DataSource = ds;
    //            drpdesig.DataTextField = "designationname";
    //            drpdesig.DataValueField = "id";
    //            drpdesig.DataBind();
    //        }
    //        drpdesig.Items.Insert(0, new ListItem("--Select--", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

    protected void btn_check_email_Click(object sender, EventArgs e)
    {
       
        int flag = 0;
        string sqlstr = "select count(*) from tbl_recruitment_candidate_registration where emailid='" + txt_email.Text + "'";

        flag = Convert.ToInt32(SQLServer.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr));
        if (txt_email.Text == "")
        {
            Output.Show("Please Write Email ID");
        }
        else
        {
            if (flag >0)
            {
                Output.Show("Email Id already exists, please enter another");
            }
            else
            {
                Output.Show("Email Id Not Registered");
            }
        }
       
    }

    protected void txt_Dob_TextChanged(object sender, EventArgs e)
    {
        //if (txt_Dob.Text != "")
        //{
        //    if (Convert.ToDateTime(txt_Dob.Text) > DateTime.Now)
        //    {
        //        Output.Show("Date of birth should be less than or  equal to current date");
        //        return;

        //    }

        //}
        //else
        //{
        //    Output.Show("Please Enter Date Of Birth");
        //}
    }

}