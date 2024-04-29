using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System;
using Common.Data;
using Common.Console;
using System.Globalization;
using DataAccessLayer;
using System.Text;
using System.EnterpriseServices;
using System.Web.UI.WebControls.WebParts;
public partial class Admin_company_empmaster : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    string sqlstr, _userCode, _companyId, RoleId;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_msg.Text = "";

        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {

                if (Session["role"] != null)
                {
                    //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    // Response.Redirect("~/Authenticate.aspx");
                }
                else
                    Response.Redirect("~/notlogged.aspx");

                //var tab2 = this.Page.FindControl("li_tabs2");

                //if (tab2 != null)
                //    tab2.dis = false;
                if (Session["Child"] != null)
                {
                    Session.Remove("Child");
                }
                if (Session["acc_education"] != null)
                {
                    Session.Remove("acc_education");
                }
                if (Session["Pro_education"] != null)
                {
                    Session.Remove("Pro_education");
                }
                if (Session["exp"] != null)
                {
                    Session.Remove("exp");
                }
                if (Session["training"] != null)
                {
                    Session.Remove("training");
                }
                if (Session["emg_contact"] != null)
                {
                    Session.Remove("emg_contact");
                }
                if (Session["Other_upload"] != null)
                {
                    Session.Remove("Other_upload");
                }
                if (Session["Address_upload"] != null)
                {
                    Session.Remove("Address_upload");
                }
                if (Session["upload"] != null)
                {
                    Session.Remove("upload");
                }
                if (Session["role"].ToString() == "3")
                {
                    // ck_editlables.Visible = true;

                }
                else
                {
                    // ck_editlables.Visible = false;
                }
                Adddefaultlables();
                // bindlabels();
                pick.Visible = false;
                doj.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));
                drpdepartment.Items.Insert(0, new ListItem("--Select Department--", "0"));
                drpdepartmenttype.Items.Insert(0, new ListItem("---Select Department Type---", "0"));
                ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_broadgroup.Items.Insert(0, new ListItem("--Select--", "0"));
                drpdegination.Items.Insert(0, new ListItem("--Select Designation--", "0"));
                //ddl_cc_country.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_cc_state.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_cc_city.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_cc_location.Items.Insert(0, new ListItem("--Select--", "0"));

                //ddl_acc_country.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_acc_state.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_acc_city.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_acc_location.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_emp_type.Items.Insert(0, new ListItem("---Select Employee Type---", "0"));
                ddl_semp_type.Items.Insert(0, new ListItem("---Select Employee Sub Type---", "0"));
                bind_ddlCCgroup();
                bind_ddl_aCCgroup();
                bind_per_country();
                bind_pre_country();
                bind_Emergency_country();
                // bind_departmenttype
                //bind_Entity();
                //bind_subgroup();
                bind_broadgroup();
                bind_emp();
                Bind_IdType();
                BindApproverDetails();
                div_Edu_Qual_others.Visible = false;

            }
        }
    }



    private void BindApproverDetails()
    {
        try
        {
            connection = activity.OpenConnection();
            //sqlstr = "select * from tbl_employee_approvers  WHERE empcode = '" + emp_code + "'";
            //ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;
            //txtreportmanager.Text = "";
            //txtbusinesshead.Text = "EIN1001>Ankur saxena";
            //txtfncmang.Text = "EIN1065>Baldev Kumar";
            //txtadmin.Text = "EIN1073>Harsh Longani";
            //txthr.Text = "EIN1108>Jaspreet Kaur Saini";
            //txthrd.Text = "EIN1073>Harsh Longani";
            //txtmng.Text = "EIN1001>Ankur saxena";

            //txtdeptclr.Text = ds.Tables[0].Rows[0]["clr_department"].ToString();
            //txtadminclr.Text = ds.Tables[0].Rows[0]["clr_generaladmin"].ToString();
            //txtaccdeptclr.Text = ds.Tables[0].Rows[0]["clr_accountsdept"].ToString();
            //txtnetworkclr.Text = "EIN1047>Parminder Singh";
            //txthrdeptclr.Text = ds.Tables[0].Rows[0]["clr_hr"].ToString();
            //txtaccdeleclr.Text = ds.Tables[0].Rows[0]["clr_useraccountdeletion"].ToString();
            //txtdottedlinemanager.Text = "";
            //txthrcb.Text = "EIN1073>Harsh Longani";
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #region set the by default values in the drop down list-----------
    protected void drpempstatus_DataBound(object sender, EventArgs e)
    {
        drpempstatus.Items.Insert(0, new ListItem("---Select Status---", "0"));
    }
    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("---Select Work Location---", "0"));
    }
    protected void ddl_emp_type_DataBound(object sender, EventArgs e)
    {
        ddl_emp_type.Items.Insert(0, new ListItem("---Select Employee Type---", "0"));
    }
    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("---Select Department---", "0"));
    }
    protected void drpdepartmenttype_DataBound(object sender, EventArgs e)
    {
        drpdepartmenttype.Items.Insert(0, new ListItem("---Select Department Type---", "0"));
    }
    protected void drpgrade_DataBound(object sender, EventArgs e)
    {
        drpgrade.Items.Insert(0, new ListItem("---Select Grade---", "0"));
    }
    protected void drpdegination_DataBound(object sender, EventArgs e)
    {
        drpdegination.Items.Insert(0, new ListItem("---Select Designation---", "0"));
    }
    protected void drpdivision_DataBound(object sender, EventArgs e)
    {
        drpdivision.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void drprole_DataBound(object sender, EventArgs e)
    {
        drprole.Items.Insert(0, new ListItem("---Select Role---", "0"));
    }
    protected void ddl_emp_type_DataBound1(object sender, EventArgs e)
    {
        ddl_emp_type.Items.Insert(0, new ListItem("---Select Employee Type---", "0"));
    }
    protected void ddl_semp_type_DataBound(object sender, EventArgs e)
    {
        ddl_semp_type.Items.Insert(0, new ListItem("---Select Employee Sub Type---", "0"));
    }
    #endregion
    #region SeletedIndex Events
    protected void ddlpersonalstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlpersonalstatus.SelectedValue.ToString() == "UNMARRIED") || (ddlpersonalstatus.SelectedValue == "0"))
        {
            tbl1.Visible = false;
            //   cv_s_dob.Enabled = false;
        }
        else
        {
            tbl1.Visible = true;
            // cv_s_dob.Enabled = true;
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            //if ((ddl_pre_country.SelectedValue == "0") || (ddl_pre_state.SelectedValue == "0") || (ddl_pre_city.SelectedValue == "0"))
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please Select Country,State and City in Present Address');", true);
            //    CheckBox1.Checked = false;
            //}
            //else
            //{
            txt_per_add1.Text = txt_pre_add1.Text;
            //txt_per_add2.Text = txt_pre_Add2.Text;
            //ddl_per_country.SelectedValue = ddl_pre_country.SelectedValue;
            //bind_per_state(ddl_per_country.SelectedValue);
            //ddl_per_state.SelectedValue = ddl_pre_state.SelectedValue;
            //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
            //ddl_per_city.SelectedValue = ddl_pre_city.SelectedValue;
            //txt_per_zip.Text = txt_pre_zip.Text;
            //txt_per_phone.Text = txt_pre_phone.Text;
            txt_per_add1.Enabled = false;
            txt_per_add2.Enabled = false;
            ddl_per_city.Enabled = false;
            ddl_per_state.Enabled = false;
            ddl_per_country.Enabled = false;
            txt_per_zip.Enabled = false;
            txt_per_phone.Enabled = false;
            //  }
        }
        else
        {
            txt_per_add1.Enabled = true;
            txt_per_add2.Enabled = true;
            ddl_per_city.Enabled = true;
            ddl_per_state.Enabled = true;
            ddl_per_country.Enabled = true;
            txt_per_zip.Enabled = true;
            txt_per_phone.Enabled = true;
            txt_per_add1.Text = "";
            txt_per_add2.Text = "";
            ddl_per_country.SelectedValue = "0";
            ddl_per_state.DataSource = "";
            ddl_per_state.DataBind();
            ddl_per_city.DataSource = "";
            ddl_per_city.DataBind();
            txt_per_zip.Text = "";
            txt_per_phone.Text = "";
        }
    }
    protected void optown_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = false;
        lblpickuppoint.Visible = false;
        pick.Visible = false;
    }

    protected void optcompany_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = true;
        lblpickuppoint.Visible = true;
        pick.Visible = true;
    }

    protected void rbtnbank_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = true;
    }

    protected void rbtncheque_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }

    protected void rbtncash_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }



    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        paymentmode.Visible = false;
    }



    protected void ddl_bank_name_reimbursement_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name_reimbursement.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmenttype(Convert.ToInt32(drpbranch.SelectedValue));
        // bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }

    protected void ddl_gradetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_gradetype.SelectedValue == "A")
        {
            sqlstr = "select * from tbl_intranet_grade where gradetype='" + ddl_gradetype.SelectedValue + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            drpgrade.DataSource = ds;
            drpgrade.DataValueField = "id";
            drpgrade.DataTextField = "gradename";
            drpgrade.DataBind();
            drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        else if (ddl_gradetype.SelectedValue == "T")
        {
            sqlstr = "select * from tbl_intranet_grade where gradetype='" + ddl_gradetype.SelectedValue + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            drpgrade.DataSource = ds;
            drpgrade.DataValueField = "id";
            drpgrade.DataTextField = "gradename";
            drpgrade.DataBind();
            drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            drpgrade.DataSource = "";
            drpgrade.DataBind();
            drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void drpempstatus_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedValue.Trim() == "1")
        {
            lblprob.Text = "Probation End date";
            //trprobationperiod.Visible = true;
            //trprobationdate.Visible = true;
            //trprobationdate2.Visible = true;
            trprobationdate3.Visible = true;

            //trduptstart.Visible = false;
            //trduptenddate.Visible = false;


            trDOL.Visible = false;
            trReasonL.Visible = false;
            txtdol.Text = "";
        }
        else
            if (drpempstatus.SelectedValue.Trim() == "3")
            {
                lblprob.Text = "Confirmation Date";
                //trprobationperiod.Visible = true;
                //trprobationdate.Visible = true;
                //trprobationdate2.Visible = true;
                trprobationdate3.Visible = true;

                //trduptstart.Visible = false;
                //trduptenddate.Visible = false;

                txtdol.Text = "";
                trDOL.Visible = false;
                trReasonL.Visible = false;
            }
            else
                if (drpempstatus.SelectedValue.Trim() == "2")
                {
                    trprobationperiod.Visible = false;
                    trprobationdate.Visible = false;
                    trprobationdate2.Visible = false;
                    trprobationdate3.Visible = false;
                    trduptstart.Visible = false;
                    trduptenddate.Visible = false;
                    trReasonL.Visible = true;
                    trDOL.Visible = true;
                }
                else
                    if (drpempstatus.SelectedValue.Trim() == "4" || drpempstatus.SelectedValue.Trim() == "5" || drpempstatus.SelectedValue.Trim() == "6")
                    {
                        trprobationperiod.Visible = false;
                        trprobationdate.Visible = false;
                        trprobationdate2.Visible = false;
                        trprobationdate3.Visible = false;
                        trduptstart.Visible = false;
                        trduptenddate.Visible = false;
                        //trReasonL.Visible = true;
                        //trDOL.Visible = true;
                        trReasonL.Visible = false;
                        trDOL.Visible = false;
                    }
                    else
                    {
                        trprobationperiod.Visible = false;
                        trprobationdate.Visible = false;
                        trprobationdate2.Visible = false;
                        trprobationdate3.Visible = false;
                        trduptstart.Visible = false;
                        trduptenddate.Visible = false;
                        trDOL.Visible = false;
                        trReasonL.Visible = false;
                        trDOL.Visible = false;
                        txtdol.Text = "";
                    }
    }

    protected void txt_probationperiod_TextChanged(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedValue.Trim() == "2")
        {
            if ((doj.Text == "") || (txt_probationperiod.Text == ""))
            {
                txt_confirmationdate.Text = "";
                //txt_probationperiod.Text = "";
            }
            else
            {
                int probitionpriod = Convert.ToInt32(txt_probationperiod.Text);
                txt_confirmationdate.Text = (Convert.ToDateTime(doj.Text).AddMonths(probitionpriod)).ToString("MM/dd/yyyy");
                //DateTime.Now.AddMonths(probitionpriod).ToString("dd/MMM/yyyy");
            }
        }
    }
    //protected void doj_TextChanged(object sender, EventArgs e)
    //{
    //    if (!CheckDOJ())
    //        return;
    //    if (drpempstatus.SelectedValue.Trim() == "2")
    //    {
    //        if ((doj.Text == "") || (txt_probationperiod.Text == ""))
    //        {
    //            txt_confirmationdate.Text = "";
    //        }
    //        else
    //        {
    //            int probitionpriod = Convert.ToInt32(txt_probationperiod.Text);
    //            txt_confirmationdate.Text = (Convert.ToDateTime(doj.Text).AddMonths(probitionpriod)).ToString("MM/dd/yyyy");
    //            //DateTime.Now.AddMonths(probitionpriod).ToString("dd/MMM/yyyy");
    //        }
    //    }
    //}
    //private bool CheckDOJ()
    //{
    //    if (Convert.ToDateTime(doj.Text) < Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")))
    //    {
    //        // btnjob.Enabled = false;
    //        doj.Text = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
    //        string str = "<script> alert('DOJ Should not be less than Current Date.')</script>";
    //        ScriptManager.RegisterStartupScript(upl, upl.GetType(), "xx", str, false);
    //        return false;
    //    }
    //    else
    //    {
    //        //  btnjob.Enabled = true;
    //        return true;
    //    }
    //}
    protected void txt_dob_changed(object sender, EventArgs e)
    {
        if (doj.Text != "" && txt_DOB.Text != "")
            if (Convert.ToDateTime(txt_DOB.Text) >= Convert.ToDateTime(doj.Text))
            {
                imgerror.Visible = true;
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Date of Birth should be less than Date of Joining');", true);

                //Response.Write("<script> alert('Please enter valid date(should be less than date of join)')</script>");
            }
            else
            {
                imgerror.Visible = false;
            }
    }
    protected void ddlSalutation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlSalutation.SelectedValue == "Ms") || (ddlSalutation.SelectedValue == "Mrs"))
        {
            drpgender.SelectedValue = "FEMALE";
        }
        else
        {
            drpgender.SelectedValue = "MALE";
        }
    }
    protected void drpgender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((drpgender.SelectedValue == "FEMALE"))
        {
            ddlSalutation.SelectedValue = "Ms";
        }
        else
        {
            ddlSalutation.SelectedValue = "Mr";
        }
    }
    #endregion
    #region Submit Click
    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {
        
        if (drpempstatus.SelectedValue.Trim() == "4" || drpempstatus.SelectedValue.Trim() == "5" || drpempstatus.SelectedValue.Trim() == "6")
        {
            if (txtdol.Text == "")
            {
                string str = "<script> alert('Please enter date of leaving.')</script>";
                ScriptManager.RegisterStartupScript(dd, dd.GetType(), "xx", str, false);
                txtdol.Focus();
                return;
            }
        }

        if (txt_DOB.Text != "")
        {
            if (Convert.ToDateTime(txt_DOB.Text) > DateTime.Now)
            {
                Output.Show("Date of birth should be less than or  equal to current date");
                return;

            }

        }
        if (txt_s_DOB.Text != "")
        {
            if (Convert.ToDateTime(txt_s_DOB.Text) > DateTime.Now)
            {
                Output.Show("Spouse Date of birth should be less than or  equal to current date");
                return;
            }
        }
        if (txt_child_Dob.Text != "")
        {
            if (Convert.ToDateTime(txt_child_Dob.Text) > DateTime.Now)
            {
                Output.Show("Children Date of birth should be less than or equal to current date");
                return;
            }
        }
        try
        {
            connection = activity.OpenConnection();
            string file_name = "";

            if (Page.IsValid)
            {
                if (f_upload_rep1.GotFile)
                {
                    file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
                    f_upload_rep1.FilePost.SaveAs(Server.MapPath("../upload/photo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
                    file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();

                    ViewState.Add("Photo", file_name);

                }
                else
                    ViewState.Add("Photo", file_name);
            }
            else
                ViewState.Add("Photo", file_name);


            //if (duplicate_emp_code() && duplicate_loginID())
            //{
            transaction = connection.BeginTransaction();
            insert_Job_detail(connection, transaction);
            insert_Log_in_detail(connection, transaction);

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();

                Insert_Educational_Qualification(emplyee_Code, connection, transaction);
                Insert_Professional_Qualification(emplyee_Code, connection, transaction);
                Insert_Expriece_detail(emplyee_Code, connection, transaction);
                insert_personal_detail(emplyee_Code, connection, transaction);
                BindApproverDetails(emplyee_Code, connection, transaction);
                Insert_Children_detail(emplyee_Code, connection, transaction);
                insert_contact_detail(emplyee_Code, connection, transaction);
                insert_Payroll_Detail(emplyee_Code, connection, transaction);
                insert_Training_details(emplyee_Code, connection, transaction);
                BindApproverDetails(txtempcode.Text.ToString(), connection, transaction);
                Insert_PhotoIDProof_detail(emplyee_Code, connection, transaction);
                Insert_Addressdoc_detail(emplyee_Code, connection, transaction);
                Insert_otherdoc_detail(emplyee_Code, connection, transaction);
                Upload_doc(emplyee_Code, connection, transaction);
                transaction.Commit();
                resetcontact();
                resetPersonalDetails();
                reset_professional_detail();
                resetjobdetails();
                //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                string str = "<script> alert('Employee Created Successfully')</script>";
                Page.RegisterStartupScript("Employee", str.ToString());

                //TabContainer1.ActiveTabIndex = 0;
                //}
                //else
                //{
                //    string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
                //    Page.RegisterStartupScript("Employee", str.ToString());
                //}
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Job Details
    protected void insert_Job_detail(SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam = new SqlParameter[49];
        sqlparam[0] = new SqlParameter("@emp_code", SqlDbType.NChar, 20);
        if (txtempcode.Text == "")
        {
            sqlparam[0].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[0].Value = txtempcode.Text;
        }
       

        sqlparam[1] = new SqlParameter("@card_no", SqlDbType.VarChar, 100);
        if (txt_card_no.Text == "")
        {
            sqlparam[1].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[1].Value = txt_card_no.Text;
        }
       

        sqlparam[2] = new SqlParameter("@emp_gender", SqlDbType.VarChar, 10);
        if ((drpgender.SelectedValue=="0")||(drpgender.SelectedValue==""))
        {
            sqlparam[2].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[2].Value = drpgender.SelectedItem.ToString();
        }
        sqlparam[3] = new SqlParameter("@emp_fname", SqlDbType.VarChar, 50);
        if (txtfirstname.Text == "")
        {
            sqlparam[3].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[3].Value = txtfirstname.Text;
        }
      

        sqlparam[4] = new SqlParameter("@emp_m_name", SqlDbType.VarChar, 50);
        if (txtmiddlename.Text == "")
        {
            sqlparam[4].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[4].Value = txtmiddlename.Text;
        }
      

        sqlparam[5] = new SqlParameter("@emp_l_name", SqlDbType.VarChar, 50);
        if (txtlastname.Text == "")
        {
            sqlparam[5].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[5].Value = txtlastname.Text;
        }
        sqlparam[6] = new SqlParameter("@emp_status", SqlDbType.Int);
        if (drpempstatus.SelectedValue == "0")
        {
            sqlparam[6].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[6].Value = drpempstatus.SelectedValue;
        }
        sqlparam[7] = new SqlParameter("@dept_id", SqlDbType.Int);
        if (drpdepartment.SelectedValue == "0")
        {
            sqlparam[7].Value = DBNull.Value;
        }
        else
        {
            sqlparam[7].Value = drpdepartment.SelectedValue;
        }

        sqlparam[8] = new SqlParameter("@division_id", SqlDbType.Int);
        sqlparam[8].Value = drpdivision.SelectedValue;

        sqlparam[9] = new SqlParameter("@degination_id", SqlDbType.Int);
        sqlparam[9].Value = drpdegination.SelectedValue;

        sqlparam[10] = new SqlParameter("@Grade", SqlDbType.Int);
        if ((drpgrade.SelectedValue == "0") || (drpgrade.SelectedValue == ""))
        {
            sqlparam[10].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[10].Value = drpgrade.SelectedValue;
        }

        sqlparam[11] = new SqlParameter("@branch_id", SqlDbType.Int);
        if ((drpbranch.SelectedValue == "0") || (drpbranch.SelectedValue == ""))
        {
            sqlparam[11].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[11].Value = drpbranch.SelectedValue;
        }
       


        sqlparam[12] = new SqlParameter("@emp_doj", SqlDbType.DateTime);
        if (doj.Text == "")
            sqlparam[12].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[12].Value = doj.Text;
       // sqlparam[12].Value = Convert.ToDateTime((doj.Text.Trim()=="")? "1/1/1900" : doj.Text.Trim());

        sqlparam[13] = new SqlParameter("@ext_number", SqlDbType.VarChar, 50);
        if ((txtextstdcode.Text != "") && (txtext.Text != ""))
        {
            sqlparam[13].Value = txtextccode.Text + "-" + txtextstdcode.Text + "-" + txtext.Text;
        }
        else sqlparam[13].Value = "";

        sqlparam[14] = new SqlParameter("@photo", SqlDbType.VarChar, 100);
        if (empphoto.HasFile)
        {
            try
            {
                string strFileName;
                string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
                strFileName = empphoto.FileName;
                empphoto.PostedFile.SaveAs(Server.MapPath("~/upload/photo/" + file_name + "_" + strFileName));
                sqlparam[14].Value = file_name + "_" + strFileName;
            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else sqlparam[14].Value = "";

        sqlparam[15] = new SqlParameter("@salary_cal_from", SqlDbType.DateTime);
        if (txtsalary.Text == "")
            sqlparam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[15].Value = Convert.ToDateTime(txtsalary.Text);

        sqlparam[16] = new SqlParameter("@emp_doleaving", SqlDbType.DateTime);
        if (txtdol.Text == "")
            sqlparam[16].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[16].Value = Convert.ToDateTime(txtdol.Text);

        sqlparam[17] = new SqlParameter("@reason_leaving", SqlDbType.VarChar, 200);
        sqlparam[17].Value = txtreason.Text;

        sqlparam[18] = new SqlParameter("@salutation", SqlDbType.VarChar, 3);
        sqlparam[18].Value = ddlSalutation.SelectedValue;


        sqlparam[19] = new SqlParameter("@probationperiod", SqlDbType.Int);
        sqlparam[19].Value = System.Data.SqlTypes.SqlInt32.Null;
        sqlparam[20] = new SqlParameter("@probationenddate", SqlDbType.DateTime);
        if (txt_confirmationdate.Text != "")
        {
            if (drpempstatus.SelectedItem.Text == "Probation")
            {
                //sqlparam[19].Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlparam[20].Value = txt_confirmationdate.Text;
            }

            else
            {
                //sqlparam[19].Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlparam[20].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
        }
        else
        {
            sqlparam[20].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }


        sqlparam[21] = new SqlParameter("@deputationstartdate", SqlDbType.DateTime);
        sqlparam[22] = new SqlParameter("@deputationenddate", SqlDbType.DateTime);
        if (drpempstatus.SelectedItem.Text == "Contractual")
        {
            sqlparam[21].Value = txt_deput_start_date.Text;
            sqlparam[22].Value = txt_deput_end_date.Text;
        }
        else
        {
            sqlparam[21].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparam[22].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }

        sqlparam[23] = new SqlParameter("@subgroupid", SqlDbType.Int);
        //if ((ddl_subgroup.SelectedValue == "0") || (ddl_subgroup.SelectedValue == ""))
        //{
        //    sqlparam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
        //}
        //else
        //{
        sqlparam[23].Value = System.Data.SqlTypes.SqlInt32.Null;// ddl_subgroup.SelectedValue;
        //}

        sqlparam[24] = new SqlParameter("@broadgroupid", SqlDbType.Int);
        if ((ddl_broadgroup.SelectedValue == "0") || (ddl_broadgroup.SelectedValue == ""))
        {
            sqlparam[24].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[24].Value = ddl_broadgroup.SelectedValue;
        }

        sqlparam[25] = new SqlParameter("@entityid", SqlDbType.Int);
        // if ((ddl_entity.SelectedValue == "0") || (ddl_entity.SelectedValue == ""))
        //{
        sqlparam[25].Value = System.Data.SqlTypes.SqlInt32.Null;
        //}
        //else
        //{
        //    sqlparam[25].Value = ddl_entity.SelectedValue;
        //}

        sqlparam[26] = new SqlParameter("@gradetype", SqlDbType.VarChar, 1);
        if ((ddl_gradetype.SelectedValue == "0") || (ddl_gradetype.SelectedValue == ""))
        {
            sqlparam[26].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[26].Value = ddl_gradetype.SelectedValue;
        }
        sqlparam[27] = new SqlParameter("@official_mob_no", SqlDbType.VarChar, 50);
        if ((txtcountrycode.Text != "") || (txtoff_mobileno.Text != ""))
        {
            sqlparam[27].Value = txtcountrycode.Text + "-" + txtoff_mobileno.Text;
        }
        else sqlparam[27].Value = "";
        sqlparam[28] = new SqlParameter("@official_email_id", SqlDbType.VarChar, 50);
        sqlparam[28].Value = txt_officialemail.Text;

        sqlparam[29] = new SqlParameter("@supervisorcode", SqlDbType.VarChar, 50);
        if ((ddl_supervisor.SelectedValue == "0") || (ddl_supervisor.SelectedValue == ""))
        {
            sqlparam[29].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[29].Value = ddl_supervisor.SelectedValue;
        }

        sqlparam[30] = new SqlParameter("@hodcode", SqlDbType.VarChar, 50);
        if ((ddl_hod.SelectedValue == "0") || (ddl_hod.SelectedValue == ""))
        {
            sqlparam[30].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[30].Value = ddl_hod.SelectedValue;
        }

        sqlparam[31] = new SqlParameter("@corporatereportingcode", SqlDbType.VarChar, 50);
        if ((ddl_corp_report_name.SelectedValue == "0") || (ddl_corp_report_name.SelectedValue == ""))
        {
            sqlparam[31].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[31].Value = ddl_corp_report_name.SelectedValue;
        }

        sqlparam[32] = new SqlParameter("@cost_center_group_id", SqlDbType.Int);
        if ((ddl_cc_groupid.SelectedValue == "0") || (ddl_cc_groupid.SelectedValue == ""))
        {
            sqlparam[32].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[32].Value = Convert.ToInt32(ddl_cc_groupid.SelectedValue);
        }
        sqlparam[33] = new SqlParameter("@cost_center_code", SqlDbType.Int);
        if ((ddl_cc_code.SelectedValue == "0") || (ddl_cc_code.SelectedValue == ""))
        {
            sqlparam[33].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[33].Value = Convert.ToInt32(ddl_cc_code.SelectedValue);
        }


        sqlparam[34] = new SqlParameter("@country", SqlDbType.Int);
        if ((hf_ccountry.Value == "0") || (hf_ccountry.Value == ""))
        {
            sqlparam[34].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[34].Value = Convert.ToInt32(hf_ccountry.Value);
        }

        sqlparam[35] = new SqlParameter("@state", SqlDbType.Int);
        if ((hf_cstate.Value == "0") || (hf_cstate.Value == ""))
        {
            sqlparam[35].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[35].Value = Convert.ToInt32(hf_cstate.Value);
        }
        sqlparam[36] = new SqlParameter("@city", SqlDbType.Int);
        if ((hf_ccity.Value == "0") || (hf_ccity.Value == ""))
        {
            sqlparam[36].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[36].Value = Convert.ToInt32(hf_ccity.Value);
        }

        sqlparam[37] = new SqlParameter("@location", SqlDbType.VarChar, 100);
        if ((lbl_cc_location.Text == "0") || (lbl_cc_location.Text == ""))
        {
            sqlparam[37].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[37].Value = lbl_cc_location.Text;
        }

        sqlparam[38] = new SqlParameter("@add_cost_center_group_id", SqlDbType.Int);
        if ((ddl_acc_groupid.SelectedValue == "0") || (ddl_acc_groupid.SelectedValue == ""))
        {
            sqlparam[38].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[38].Value = Convert.ToInt32(ddl_acc_groupid.SelectedValue);
        }
        sqlparam[39] = new SqlParameter("@add_cost_center_code", SqlDbType.Int);
        if ((ddl_acc_code.SelectedValue == "0") || (ddl_acc_code.SelectedValue == ""))
        {
            sqlparam[39].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[39].Value = Convert.ToInt32(ddl_acc_code.SelectedValue);
        }
        sqlparam[40] = new SqlParameter("@add_country", SqlDbType.Int);
        if ((hf_accountry.Value == "0") || (hf_accountry.Value == ""))
        {
            sqlparam[40].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[40].Value = Convert.ToInt32(hf_accountry.Value);
        }

        sqlparam[41] = new SqlParameter("@add_state", SqlDbType.Int);
        if ((hf_acstate.Value == "0") || (hf_acstate.Value == ""))
        {
            sqlparam[41].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[41].Value = Convert.ToInt32(hf_acstate.Value);
        }

        sqlparam[42] = new SqlParameter("@add_city", SqlDbType.Int);
        if ((hf_accity.Value == "0") || (hf_accity.Value == ""))
        {
            sqlparam[42].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[42].Value = Convert.ToInt32(hf_accity.Value);
        }

        sqlparam[43] = new SqlParameter("@add_location", SqlDbType.VarChar, 100);
        if ((lbl_acc_location.Text == "0") || (lbl_acc_location.Text == ""))
        {
            sqlparam[43].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[43].Value = lbl_acc_location.Text;
        }

        sqlparam[44] = new SqlParameter("@confirmationdate", SqlDbType.DateTime);
        if (txt_confirmationdate.Text != "")
        {
            if (drpempstatus.SelectedItem.Text != "Confirmed")
            {
                sqlparam[44].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlparam[44].Value = txt_confirmationdate.Text;
            }
        }
        else
        {
            sqlparam[44].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }

        sqlparam[45] = new SqlParameter("@noticeperiod", SqlDbType.Int);
        if (txt_noticePeriod.Text == "")
        {
            sqlparam[45].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[45].Value = Convert.ToInt32(txt_noticePeriod.Text);
        }

        sqlparam[46] = new SqlParameter("@employee_type", SqlDbType.Int);
        sqlparam[46].Value = ddl_emp_type.SelectedValue;
        sqlparam[47] = new SqlParameter("@sub_emp_type", SqlDbType.Int);
        sqlparam[47].Value = ddl_semp_type.SelectedValue;

        sqlparam[48] = new SqlParameter("@dep_type_id", SqlDbType.Int);
        sqlparam[48].Value = drpdepartmenttype.SelectedValue;       


        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_edit_jobdetails", sqlparam);

        //SmartHr.Common.Alert("Employee Job Details Saved successfully!!!.");
    }
    #endregion
    #region Job Login Details
    protected void insert_Log_in_detail(SqlConnection connection, SqlTransaction transaction)
    {
        int saltSize = 5;
        string salt = CreateSalt(saltSize);
        string autogeneratedPassword = CreateRandomPassword(8);
        hdnpassword.Value = autogeneratedPassword;
        string passwordHash = CreatePasswordHash(autogeneratedPassword, salt);

        SqlParameter[] sqlparam1 = new SqlParameter[4];

        sqlparam1[0] = new SqlParameter("@loginid", SqlDbType.VarChar, 50);
        sqlparam1[0].Value = txtempcode.Text.Trim().ToString();

        sqlparam1[1] = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
        sqlparam1[1].Value = passwordHash.Trim().ToString();

        sqlparam1[2] = new SqlParameter("@role", SqlDbType.TinyInt);
        sqlparam1[2].Value = drprole.SelectedValue;

        sqlparam1[3] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam1[3].Value = txtempcode.Text.Trim().ToString();

        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_employee_login", sqlparam1);

    }
    private void mailtoemployee(string empcode)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,isnull(emp_fname,'')+' ' +isnull(emp_m_name,'')+' ' +isnull(emp_l_name,'') as empname from tbl_intranet_employee_jobDetails where empcode='" + empcode + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

        string subject = "";
        string bodyContent = "";
        subject = "AutoGenerated Password";
        bodyContent = "Please find the auto generated password below.</br> Password :" + hdnpassword.Value + "";


        string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
        if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
        {
            try
            {
                Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
            }
            catch
            {
                Common.Console.Output.Show("Password is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
            }
        }
        else
        {
            Common.Console.Output.Show("Password Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
        }
        activity.CloseConnection();
    }
    public static string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }

    private static string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }
    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
    }
    #endregion
    #region Payroll Details
    protected void insert_Payroll_Detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam2 = new SqlParameter[9];

        sqlparam2[0] = new SqlParameter("@emp_code", SqlDbType.VarChar, 50);
        sqlparam2[0].Value = empcode;

        sqlparam2[1] = new SqlParameter("@esi_no", SqlDbType.VarChar, 50);
        sqlparam2[1].Value = esino.Text.Trim().ToString();

        sqlparam2[2] = new SqlParameter("@esi_disp", SqlDbType.VarChar, 100);
        sqlparam2[2].Value = esidesp.Text.Trim().ToString();

        sqlparam2[3] = new SqlParameter("@pf_no", SqlDbType.VarChar, 50);
        sqlparam2[3].Value = pfno.Text.Trim().ToString();

        sqlparam2[4] = new SqlParameter("@pf_no_dept", SqlDbType.VarChar, 50);
        sqlparam2[4].Value = pfno_dept.Text.Trim().ToString();

        sqlparam2[5] = new SqlParameter("@pan_no", SqlDbType.VarChar, 50);
        sqlparam2[5].Value = panno.Text.Trim().ToString();

        sqlparam2[6] = new SqlParameter("@ward", SqlDbType.VarChar, 100);
        sqlparam2[6].Value = ward.Text.Trim().ToString();

        sqlparam2[7] = new SqlParameter("@ptno", SqlDbType.VarChar, 50);
        sqlparam2[7].Value = txt_ptno.Text.Trim().ToString();

        sqlparam2[8] = new SqlParameter("@uano", SqlDbType.VarChar, 50);
        sqlparam2[8].Value = txt_uan.Text.Trim().ToString();

        SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_edit_payrolldetails", sqlparam2);
    }
    #endregion
    #region children detail
    protected void btn_child_Add_Click(object sender, EventArgs e)
    {
        if (txt_child_Dob.Text != "" && txt_s_DOB.Text != "")
        {
            if (Convert.ToDateTime(txt_child_Dob.Text.ToString()) < Convert.ToDateTime(txt_s_DOB.Text.ToString()))
            {

                Output.Show("Child Date of Birth should be less than Spouse Date of Birth");
                txt_child_Dob.Focus();
            }
        }
        Child_grid();
        txt_child_name.Text = "";
        txt_child_Dob.Text = "";
        ddl_child_gender.SelectedValue = "0";
        // }
        // }
        //  else
        //  {
        //  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please enter spouse Date of birth date');", true);
        //  }
    }

    protected void Child_grid()
    {
        DataRow dr;
        if (Session["child"] == null)
        {
            create_child_table();
        }
        dtable = (DataTable)Session["child"];

        DataRow drfind = dtable.Rows.Find(txt_child_name.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["child_name"] = txt_child_name.Text;
            dr["gender"] = ddl_child_gender.SelectedValue;
            dr["child_dob"] = txt_child_Dob.Text;

            dtable.Rows.Add(dr);
        }
        Session["child"] = dtable;
        BindList_child();
    }
    protected void BindList_child()
    {
        if (Session["child"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["child"];
            dview = new DataView(dtable);
            dview.Sort = "Child_name";
        }
        grid_child.DataSource = dview;
        grid_child.DataBind();
    }
    protected void create_child_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("child_name", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["child_name"] };
        dtable.Columns.Add("gender", typeof(string));
        dtable.Columns.Add(new DataColumn("child_DOB", typeof(string)));
        Session["child"] = dtable;
    }

    protected void grid_child_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["child"];
        DataRow drfind_child = dtable.Rows.Find(Convert.ToString(grid_child.DataKeys[e.RowIndex].Value));
        if (drfind_child != null)
        {
            drfind_child.Delete();
            Session["child"] = dtable;
            BindList_child();
        }
    }
    protected void Insert_Children_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {

        if (Session["child"] != null)
        {
            sqlstr = "delete from tbl_intranet_employee_childrendetail where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["child"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DateTime dob;
                if (dtable.Rows[i]["child_dob"].ToString() != "")
                {
                    dob = Convert.ToDateTime(dtable.Rows[i]["child_dob"]);
                }
                else
                    dob = Convert.ToDateTime("01/01/1900");


                SqlParameter[] sqlParam = new SqlParameter[4];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@child_name", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["child_name"].ToString();

                sqlParam[2] = new SqlParameter("@childdob", SqlDbType.DateTime);
                //if (dob == "")
                //    sqlParam[2].Value = System.Data.SqlTypes.SqlDateTime.Null;
                //else
                //    sqlParam[2].Value = dob;
                sqlParam[2].Value = dob;


                sqlParam[3] = new SqlParameter("@gender", SqlDbType.VarChar, 10);
                sqlParam[3].Value = dtable.Rows[i]["gender"].ToString();
                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_insert_childrendetail]", sqlParam);
            }

        }



    }
    #endregion
    #region Professional Qualification
    protected void btn_pro_qual_add_Click(object sender, EventArgs e)
    {
        //dtable = (DataTable)Session["acc_education"];
        //int toYearFstPg = Convert.ToInt32(txtfrm1.Text);

        //int fromYear = Convert.ToInt32(dtable.Rows[0][4]);
        //if (toYearFstPg < fromYear)
        //{
        //    Common.Console.Output.Show("Professtional Qualification year should be greater than Eduacational Qualification");
        //    return;
        //}

        Ins_Pro_edu();
        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        txtfrm1.Text = "";
        txtto1.Text = "";
        txtpro_specilazation.Text = "";
    }
    protected void Ins_Pro_edu()
    {
        DataRow dr;
        if (Session["Pro_education"] == null)
        {
            create_Pro_edu_table();
        }
        dtable = (DataTable)Session["Pro_education"];

        DataRow drfind = dtable.Rows.Find(txteduc1.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["education"] = txteduc1.Text;
            dr["school"] = txtsch1.Text;
            dr["percentage"] = txtper1.Text;
            dr["from_year"] = txtfrm1.Text;
            dr["to_year"] = txtto1.Text;
            dr["specialization"] = txtpro_specilazation.Text;

            dtable.Rows.Add(dr);
        }
        Session["Pro_education"] = dtable;
        BindList_pro_edu();
    }
    protected void BindList_pro_edu()
    {
        if (Session["Pro_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Pro_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_Pro_education.DataSource = dview;
        grid_Pro_education.DataBind();
    }
    protected void create_Pro_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("specialization", typeof(string)));

        Session["Pro_education"] = dtable;
    }
    protected void grid_Pro_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Pro_education"];
        DataRow drfind_pro_edu = dtable.Rows.Find(Convert.ToString(grid_Pro_education.DataKeys[e.RowIndex].Value));
        if (drfind_pro_edu != null)
        {
            drfind_pro_edu.Delete();
            Session["Pro_education"] = dtable;
            BindList_pro_edu();
        }

    }
    protected void Insert_Professional_Qualification(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["Pro_education"] != null)
        {
            sqlstr = "delete from tbl_employee_professionalqualifications where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["Pro_education"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["education"].ToString();

                sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["school"].ToString();

                sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["percentage"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                sqlParam[6].Value = dtable.Rows[i]["specialization"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_professionalqualification]", sqlParam);
            }
        }
    }
    #endregion
    #region  exprience detail
    protected void btn_exp_add_Click(object sender, EventArgs e)
    {
        dtable = (DataTable)Session["acc_education"];
        string anyYear = txt_exp_from.Text;
        int anyyr = Convert.ToInt32(anyYear);
        int toYearFstPg = anyyr;

        //if (dtable != null)
        //{
        //    int fromYear = Convert.ToInt32(dtable.Rows[0][3]);
        //    if (toYearFstPg <= fromYear)
        //    {
        //        Common.Console.Output.Show("Experience year should be greater than Educational Qualification");
        //        return;
        //    }
        //}

        //else
        //{
        //    int fromyear = Convert.ToInt32(txt_exp_to.Text);
        //    double total = fromyear - toYearFstPg;

        //    double totalexp = Convert.ToDouble(txt_total_exp.Text);
        //    if (total < totalexp)
        //    {
        //        Common.Console.Output.Show("Enter valid year in Experience details");
        //        return;
        //    }

        //}

        Ins_exp();
        txtcomp1.Text = "";
        txt_com_local.Text = "";
        txt_total_exp.Text = "";
        txt_exp_from.Text = "";
        txt_exp_to.Text = "";
        txt_EXp_designation.Text = "";
    }

    protected void Ins_exp()
    {
        DataRow dr;
        if (Session["exp"] == null)
        {
            create_exp_table();
        }
        dtable = (DataTable)Session["exp"];

        //DataRow drfind = dtable.Rows.Find(txtcomp1.Text);
        //if (drfind != null)
        //{
        //}
        //else
        //{
        dr = dtable.NewRow();


        dr["comp_name"] = txtcomp1.Text;
        dr["location"] = txt_com_local.Text;
        dr["total_exp"] = txt_total_exp.Text;
        dr["from_year"] = txt_exp_from.Text;
        dr["to_year"] = txt_exp_to.Text;
        dr["designation"] = txt_EXp_designation.Text;
        dtable.Rows.Add(dr);
        //}
        Session["exp"] = dtable;
        BindList_exp();
    }
    protected void BindList_exp()
    {
        if (Session["exp"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["exp"];
            dview = new DataView(dtable);
            dview.Sort = "from_year";
        }
        grid_exp.DataSource = dview;
        grid_exp.DataBind();
    }
    protected void create_exp_table()
    {



        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("comp_name", typeof(string));
        dtable.Columns.Add(new DataColumn("location", typeof(string)));
        dtable.Columns.Add(new DataColumn("total_exp", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("designation", typeof(string)));


        Session["exp"] = dtable;
    }
    protected void grid_exp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["exp"];
        DataRow drfind_exp = dtable.Rows.Find(Convert.ToString(grid_exp.DataKeys[e.RowIndex].Value));
        if (drfind_exp != null)
        {
            drfind_exp.Delete();
            Session["exp"] = dtable;
            BindList_exp();
        }
    }
    protected void Insert_Expriece_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["exp"] != null)
        {
            sqlstr = "delete from tbl_employee_experiencedetails where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["exp"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@companyname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["comp_name"].ToString();

                sqlParam[2] = new SqlParameter("@location", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["location"].ToString();

                sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@designation", SqlDbType.VarChar, 50);
                sqlParam[6].Value = dtable.Rows[i]["designation"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_experiencedetails]", sqlParam);
            }
        }
    }
    #endregion
    #region Educational Qualification
    protected void drp_edu_qualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_edu_qualification.SelectedValue == "others")
            div_Edu_Qual_others.Visible = true;
        else
            div_Edu_Qual_others.Visible = false;
    }
    protected void Ins_acc_edu()
    {
        DataRow dr;
        if (Session["acc_education"] == null)
        {
            create_acc_edu_table();
        }
        else
        {
            dtable = (DataTable)Session["acc_education"];
            if (dtable.Rows[0][4] != null)
            {
                check_equal(dtable);
                int toYearsecPg = Convert.ToInt32(txtedufrom.Text);

                int fromfirstYear = Convert.ToInt32(dtable.Rows[0][4]);



                if (toYearsecPg <= fromfirstYear)
                {
                    Common.Console.Output.Show("The Education year should be equal or greater then the end year of the previous Education year");
                    return;
                }
               
            }
        }

        


        dtable = (DataTable)Session["acc_education"];

        DataRow drfind = dtable.Rows.Find(drp_edu_qualification.SelectedItem.ToString());
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();

            String edu_qual = "";
            if (drp_edu_qualification.SelectedValue != "others")
                edu_qual = drp_edu_qualification.SelectedItem.ToString();
            else
                edu_qual = txt_Edu_Qual_others.Text;

            dr["education"] = edu_qual;
            dr["school"] = txtedush.Text;
            dr["percentage"] = txteduper.Text;
            dr["from_year"] = txtedufrom.Text;
            dr["to_year"] = txteduto.Text;
            dr["specialization"] = txtedu_specilazation.Text;
            dtable.Rows.Add(dr);
        }
        Session["acc_education"] = dtable;
        BindList_acc_edu();
    }


    void check_equal(DataTable dtable)
    {
        if (dtable.Rows[0][4] != null)
        {
            string secondyearedu = drp_edu_qualification.SelectedValue.Trim();
            ////string secondyearspecialization = txtedu_specilazation.Text;
            ////string secondyearschool = txtedush.Text;
            ////string percentage = txteduper.Text;
            ////int fromYearsecPg = Convert.ToInt32(txteduto.Text);
            ////int toYearsecPg = Convert.ToInt32(txtedufrom.Text);
            //string xx = (dtable.Rows[0][0]).ToString();
            
            ////string xx1 = (dtable.Rows[0][1]).ToString();
            ////string xx2 = (dtable.Rows[0][2]).ToString();
            ////int xx3 =Convert.ToInt32(dtable.Rows[0][3]);
            ////int xx4 =Convert.ToInt32(dtable.Rows[0][4]);
            //if ((secondyearedu == xx))
            //{
            //    Common.Console.Output.Show("Record Already Inserted");
            //    return;
            //}
            for (int i = 0; i <= dtable.Rows.Count - 1; i++)
            {
                if (dtable.Rows[i][0].ToString() == secondyearedu)
                {
                    Common.Console.Output.Show("Record Already Inserted");
                    return;
                }
               
            }
            
        

        }
    }

    protected void btnBindList_acc_edu()
    {
        if (Session["acc_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["acc_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_edu_education.DataSource = dview;
        grid_edu_education.DataBind();
    }
    protected void create_acc_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("specialization", typeof(string)));


        Session["acc_education"] = dtable;
    }
    protected void BindList_acc_edu()
    {
        if (Session["acc_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["acc_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_edu_education.DataSource = dview;
        grid_edu_education.DataBind();
    }
    protected void grid_edu_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["acc_education"];
        DataRow drfind_acc_edu = dtable.Rows.Find(Convert.ToString(grid_edu_education.DataKeys[e.RowIndex].Value));
        if (drfind_acc_edu != null)
        {
            drfind_acc_edu.Delete();
            Session["acc_education"] = dtable;
            BindList_acc_edu();
        }

    }
    protected void btn_quali_add_Click(object sender, EventArgs e)
    {
        if (drp_edu_qualification.SelectedValue == "others" && txt_Edu_Qual_others.Text.Trim() == "")
        {
            Common.Console.Output.Show("Please fill OTHERS details in below text field");
        }
        else
        {
            Ins_acc_edu();
            drp_edu_qualification.SelectedValue = "0";
            txtedush.Text = "";
            txteduper.Text = "";
            txtedufrom.Text = "";
            txteduto.Text = "";
            txtedu_specilazation.Text = "";
            txt_Edu_Qual_others.Text = "";
        }
    }
    protected void Insert_Educational_Qualification(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["acc_education"] != null)
        {
            sqlstr = "delete  from tbl_employee_edcationalqualifications where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["acc_education"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["education"].ToString();

                sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["school"].ToString();

                sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["percentage"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                sqlParam[6].Value = dtable.Rows[i]["specialization"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_educationqualification]", sqlParam);
            }
        }
    }
    #endregion
    #region  Training detail
    protected void btn_Training_add_Click(object sender, EventArgs e)
    {
        add_Training();
        txt_TrProgram.Text = "";
        txt_TrConductedBy.Text = "";
        txtFromdate.Text = "";
        txtToDate.Text = "";
        txtTrRemarks.Text = "";
    }
    protected void add_Training()
    {
        DataRow dr;
        if (Session["training"] == null)
        {
            create_Training_table();
        }
        dtable = (DataTable)Session["training"];

        DataRow drfind = dtable.Rows.Find(txt_TrProgram.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();

            dr["trainingname"] = txt_TrProgram.Text;
            dr["personname"] = txt_TrConductedBy.Text;
            dr["fromdate"] = txtFromdate.Text;
            dr["todate"] = txtToDate.Text;
            dr["remarks"] = txtTrRemarks.Text;
            dtable.Rows.Add(dr);
        }
        Session["training"] = dtable;
        BindList_Training();
    }
    protected void BindList_Training()
    {
        if (Session["training"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["training"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridTraning.DataSource = dview;
        GridTraning.DataBind();
    }
    protected void create_Training_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("trainingname", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["trainingname"] };
        dtable.Columns.Add(new DataColumn("personname", typeof(string)));
        dtable.Columns.Add(new DataColumn("fromdate", typeof(string)));
        dtable.Columns.Add(new DataColumn("todate", typeof(string)));
        dtable.Columns.Add(new DataColumn("remarks", typeof(string)));
        Session["training"] = dtable;
    }
    protected void GridTraning_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["training"];
        DataRow drfind_Training = dtable.Rows.Find(Convert.ToString(GridTraning.DataKeys[e.RowIndex].Value));
        if (drfind_Training != null)
        {
            drfind_Training.Delete();
            Session["training"] = dtable;
            BindList_Training();
        }
    }

    protected void insert_Training_details(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["training"] != null)
        {
            sqlstr = "delete from tbl_intranet_employee_trainingdetail where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["training"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[6];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@trainingname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["trainingname"].ToString();

                sqlParam[2] = new SqlParameter("@personname", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["personname"].ToString();

                sqlParam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
                sqlParam[3].Value = dtable.Rows[i]["fromdate"].ToString();

                sqlParam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
                sqlParam[4].Value = dtable.Rows[i]["todate"].ToString();

                sqlParam[5] = new SqlParameter("@remarks", SqlDbType.VarChar, 500);
                sqlParam[5].Value = dtable.Rows[i]["remarks"].ToString();



                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_insert_emp_training]", sqlParam);
            }
        }

    }
    #endregion
    #region Insert Personal Details
    protected void insert_personal_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        int paymentmode = 0;
        SqlParameter[] sqlParam = new SqlParameter[35];

        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;
        sqlParam[1] = new SqlParameter("@f_fname", SqlDbType.VarChar, 50);
        sqlParam[1].Value = txt_f_f_name.Text;
        sqlParam[2] = new SqlParameter("@f_mname", SqlDbType.VarChar, 50);
        sqlParam[2].Value = ddl_Tshirt.SelectedValue;
        sqlParam[3] = new SqlParameter("@f_lname", SqlDbType.VarChar, 50);
        sqlParam[3].Value = ddl_ShirtSize.SelectedValue;
        sqlParam[4] = new SqlParameter("@m_fname", SqlDbType.VarChar, 50);
        sqlParam[4].Value = txt_m_fname.Text;
        sqlParam[5] = new SqlParameter("@m_lname", SqlDbType.VarChar, 50);
        sqlParam[5].Value = txt_m_l_name.Text;
        sqlParam[6] = new SqlParameter("@m_mname", SqlDbType.VarChar, 50);
        sqlParam[6].Value = txt_m_mname.Text;
        sqlParam[7] = new SqlParameter("@bloodgrp", SqlDbType.VarChar, 50);
        sqlParam[7].Value = ddlbloodgrp.SelectedValue;
        sqlParam[8] = new SqlParameter("@maritalstatus", SqlDbType.VarChar, 50);
        sqlParam[8].Value = ddlpersonalstatus.SelectedValue;
        sqlParam[9] = new SqlParameter("@religion", SqlDbType.VarChar, 50);
        sqlParam[9].Value = txtrelg.Text;
        sqlParam[10] = new SqlParameter("@doa", SqlDbType.DateTime);
        if (txt_doa.Text == "")
            sqlParam[10].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[10].Value = Convert.ToDateTime(txt_doa.Text);

        sqlParam[11] = new SqlParameter("@dlno", SqlDbType.VarChar, 50);
        sqlParam[11].Value = txt_dl_no.Text;
        sqlParam[12] = new SqlParameter("@s_fname", SqlDbType.VarChar, 50);
        sqlParam[12].Value = txt_sp_fname.Text;
        sqlParam[13] = new SqlParameter("@s_mname", SqlDbType.VarChar, 50);
        sqlParam[13].Value = txt_sp_mname.Text;
        sqlParam[14] = new SqlParameter("@s_lname", SqlDbType.VarChar, 50);
        sqlParam[14].Value = txt_sp_lname.Text;
        sqlParam[15] = new SqlParameter("@s_dob", SqlDbType.DateTime);
        if (txt_s_DOB.Text == "")
            sqlParam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[15].Value = txt_s_DOB.Text;
        sqlParam[16] = new SqlParameter("@s_gender", SqlDbType.VarChar, 50);
        sqlParam[16].Value = ddl_s_gender.SelectedValue;
        sqlParam[17] = new SqlParameter("@no_child", SqlDbType.Int);
        sqlParam[17].Value = 3;

        sqlParam[18] = new SqlParameter("@mobile_no", SqlDbType.VarChar, 50);
        if (txtmobileno.Text != "")
            sqlParam[18].Value = txtccode.Text + "-" + txtmobileno.Text;
        else
            sqlParam[18].Value = "";
        sqlParam[19] = new SqlParameter("@email_id", SqlDbType.VarChar, 50);
        sqlParam[19].Value = txt_email.Text;
        sqlParam[20] = new SqlParameter("@bank_name", SqlDbType.VarChar, 50);
        sqlParam[20].Value = ddl_bank_name.SelectedValue;
        sqlParam[21] = new SqlParameter("@ac_number", SqlDbType.VarChar, 50);
        sqlParam[21].Value = txt_bank_ac.Text.Trim();
        sqlParam[22] = new SqlParameter("@passport_number", SqlDbType.VarChar, 50);
        sqlParam[22].Value = txt_passportno.Text;

        sqlParam[23] = new SqlParameter("@DOB", SqlDbType.DateTime);
        if (txt_DOB.Text == "")
            sqlParam[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[23].Value = Convert.ToDateTime(txt_DOB.Text);

        if (rbtnbank.Checked)
            paymentmode = 0;

        if (rbtncheque.Checked)
            paymentmode = 1;

        if (rbtncash.Checked)
            paymentmode = 2;

        sqlParam[24] = new SqlParameter("@paymentmode", SqlDbType.Int);
        sqlParam[24].Value = paymentmode;

        sqlParam[25] = new SqlParameter("@bank_name_reimbursement", SqlDbType.VarChar, 50);
        sqlParam[25].Value = "";// ddl_bank_name_reimbursement.SelectedValue;

        sqlParam[26] = new SqlParameter("@ac_number_reimbursement", SqlDbType.VarChar, 50);
        sqlParam[26].Value = ""; txt_bank_ac_reimbursement.Text.Trim();


        sqlParam[27] = new SqlParameter("@bankbranch", SqlDbType.VarChar, 50);
        sqlParam[27].Value = txt_bankbrachname.Text;
        sqlParam[28] = new SqlParameter("@ifsc", SqlDbType.VarChar, 50);
        sqlParam[28].Value = txt_ifsc.Text;
        sqlParam[29] = new SqlParameter("@passportissuedate", SqlDbType.DateTime);
        if (txt_passportexpdate.Text == "")
        {
            sqlParam[29].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[29].Value = Convert.ToDateTime(txt_passportissueddate.Text);
        }
        sqlParam[30] = new SqlParameter("@passportexpiraydate", SqlDbType.DateTime);
        if (txt_passportexpdate.Text == "")
        {
            sqlParam[30].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[30].Value = Convert.ToDateTime(txt_passportexpdate.Text);
        }

        sqlParam[31] = new SqlParameter("@dl_number", SqlDbType.VarChar, 50);
        sqlParam[31].Value = txt_drli_no.Text;

        sqlParam[32] = new SqlParameter("@dlissuedate", SqlDbType.DateTime);
        if (txt_dr_iss_date.Text == "")
        {
            sqlParam[32].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[32].Value = Convert.ToDateTime(txt_dr_iss_date.Text);
        }


        sqlParam[33] = new SqlParameter("@dlexpiraydate", SqlDbType.DateTime);
        if (txt_dr_exp_date.Text == "")
        {
            sqlParam[33].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[33].Value = Convert.ToDateTime(txt_dr_exp_date.Text);
        }
        sqlParam[34] = new SqlParameter("@landlineno", SqlDbType.VarChar);
        sqlParam[34].Value = txtperccode.Text + "-" + txtperstdcode.Text + "-" + txtperlandno.Text;



        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_Edit_personaldetails]", sqlParam);

    }
    #endregion
    #region  contact detail

    protected void insert_contact_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlParam = new SqlParameter[26];

        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;
        sqlParam[1] = new SqlParameter("@pre_add1", SqlDbType.VarChar, 500);
        sqlParam[1].Value = txt_pre_add1.Text;
        sqlParam[2] = new SqlParameter("@pre_Add2", SqlDbType.VarChar, 500);
        sqlParam[2].Value = txt_pre_Add2.Text;
        sqlParam[3] = new SqlParameter("@pre_city", SqlDbType.VarChar, 100);
        if ((ddl_pre_city.SelectedValue == "0") || (ddl_pre_city.SelectedValue == ""))
        {
            sqlParam[3].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[3].Value = ddl_pre_city.SelectedValue;
        }

        sqlParam[4] = new SqlParameter("@pre_state", SqlDbType.VarChar, 50);
        if ((ddl_pre_state.SelectedValue == "0") || (ddl_pre_state.SelectedValue == ""))
        {
            sqlParam[4].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[4].Value = ddl_pre_state.SelectedValue;
        }
        sqlParam[5] = new SqlParameter("@pre_country", SqlDbType.VarChar, 50);
        if ((ddl_pre_country.SelectedValue == "0") || (ddl_pre_country.SelectedValue == ""))
        {
            sqlParam[5].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[5].Value = ddl_pre_country.SelectedValue;
        }
        sqlParam[6] = new SqlParameter("@pre_zip", SqlDbType.VarChar, 50);
        sqlParam[6].Value = txt_pre_zip.Text;
        sqlParam[7] = new SqlParameter("@pre_phone", SqlDbType.VarChar, 50);
        sqlParam[7].Value = txt_pre_phone.Text;
        sqlParam[8] = new SqlParameter("@per_add1", SqlDbType.VarChar, 500);
        sqlParam[8].Value = txt_per_add1.Text;
        sqlParam[9] = new SqlParameter("@per_add2", SqlDbType.VarChar, 500);
        sqlParam[9].Value = txt_per_add2.Text;
        sqlParam[10] = new SqlParameter("@per_city", SqlDbType.VarChar, 100);
        if ((ddl_per_city.SelectedValue == "0") || (ddl_per_city.SelectedValue == ""))
        {
            sqlParam[10].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[10].Value = ddl_per_city.SelectedValue;
        }
        sqlParam[11] = new SqlParameter("@per_state", SqlDbType.VarChar, 50);
        if ((ddl_per_state.SelectedValue == "0") || (ddl_per_state.SelectedValue == ""))
        {
            sqlParam[11].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[11].Value = ddl_per_state.SelectedValue;
        }
        sqlParam[12] = new SqlParameter("@per_country", SqlDbType.VarChar, 50);
        if ((ddl_per_country.SelectedValue == "0") || (ddl_per_country.SelectedValue == ""))
        {
            sqlParam[12].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[12].Value = ddl_per_country.SelectedValue;
        }
        sqlParam[13] = new SqlParameter("@per_zip", SqlDbType.VarChar, 50);
        sqlParam[13].Value = txt_per_zip.Text;
        sqlParam[14] = new SqlParameter("@per_phone", SqlDbType.VarChar, 50);
        sqlParam[14].Value = txt_per_phone.Text;
        sqlParam[15] = new SqlParameter("@mode", SqlDbType.TinyInt);

        if (optcompany.Checked)
        {
            sqlParam[15].Value = 1;
        }

        if (optown.Checked)
        {
            sqlParam[15].Value = 0;
        }

        sqlParam[16] = new SqlParameter("@modeoftransport", SqlDbType.VarChar, 50);
        sqlParam[16].Value = txtmodeoftransport.Text.Trim();

        sqlParam[17] = new SqlParameter("@emergency_contact_no", SqlDbType.VarChar, 50);
        sqlParam[17].Value = "";// txt_emg_ccode.Text + "-" + txt_emergency_contactno.Text;

        sqlParam[18] = new SqlParameter("@emergency_name", SqlDbType.VarChar, 50);
        sqlParam[18].Value = "";// txt_emergency_name.Text;

        sqlParam[19] = new SqlParameter("@emergency_relation", SqlDbType.VarChar, 50);
        sqlParam[19].Value = "";// drp_emg_relation.SelectedValue;

        sqlParam[20] = new SqlParameter("@emergency_address1", SqlDbType.VarChar, 500);
        sqlParam[20].Value = txt_emergency_address.Text;

        sqlParam[21] = new SqlParameter("@emergency_address2", SqlDbType.VarChar, 500);
        sqlParam[21].Value = txt_emergency_address2.Text;

        sqlParam[22] = new SqlParameter("@emergency_city", SqlDbType.Int);
        if ((ddl_emergency_city.SelectedValue == "0") || (ddl_emergency_city.SelectedValue == ""))
        {
            sqlParam[22].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlParam[22].Value = Convert.ToInt32(ddl_emergency_city.SelectedValue);
        }

        sqlParam[23] = new SqlParameter("@emergency_state", SqlDbType.Int);
        if ((ddl_emergency_state.SelectedValue == "0") || (ddl_emergency_state.SelectedValue == ""))
        {
            sqlParam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlParam[23].Value = Convert.ToInt32(ddl_emergency_state.SelectedValue);
        }
        sqlParam[24] = new SqlParameter("@emergency_country", SqlDbType.VarChar, 50);
        if ((ddl_emergency_country.SelectedValue == "0") || (ddl_emergency_country.SelectedValue == ""))
        {
            sqlParam[24].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[24].Value = ddl_emergency_country.SelectedValue;
        }

        sqlParam[25] = new SqlParameter("@emergency_zip", SqlDbType.VarChar, 50);
        sqlParam[25].Value = txt_emergency_zipcode.Text;

        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_EDIT_contactdetails]", sqlParam);
    }
    #endregion
    #region Upload Details
    private void Upload_doc(string empcode, SqlConnection connection, SqlTransaction transaction)
    {

        string defaultUpload1 = "";
        string defaultUpload2 = "";
        string defaultUpload3 = "";
        string defaultUpload4 = "";
        string defaultUpload5 = "";
        string defaultUpload6 = "";
        string defaultUpload7 = "";
        string defaultUpload8 = "";
        string defaultUpload9 = "";
        string defaultUpload10 = "";
        string defaultUpload11 = "";
        string defaultUpload12 = "";
        string defaultUpload13 = "";
        string defaultUpload14 = "";
        string defaultUpload15 = "";
      
        if (File_UploadDft1.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft1.FileName;
            try
            {
                File_UploadDft1.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload1 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload1 = "";
        }


        if (File_UploadDft2.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft2.FileName;
            try
            {
                File_UploadDft2.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload2 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload2 = "";
        }



        if (File_UploadDft3.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft3.FileName;
            try
            {
                File_UploadDft3.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload3 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload3 = "";
        }




        if (File_UploadDft4.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft4.FileName;
            try
            {
                File_UploadDft4.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload4 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload4 = "";
        }



        if (File_UploadDft5.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft5.FileName;
            try
            {
                File_UploadDft5.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload5 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload5 = "";
        }




        if (File_UploadDft6.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft6.FileName;
            try
            {
                File_UploadDft6.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload6 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload6 = "";
        }




        if (File_UploadDft7.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft7.FileName;
            try
            {
                File_UploadDft7.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload7 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload7 = "";
        }




        if (File_UploadDft8.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft8.FileName;
            try
            {
                File_UploadDft8.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload8 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload8 = "";
        }



        if (File_UploadDft9.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft9.FileName;
            try
            {
                File_UploadDft9.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload9 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload9 = "";
        }




        if (File_UploadDft10.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft10.FileName;
            try
            {
                File_UploadDft10.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload10 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload10 = "";
        }


        if (File_UploadDft11.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft11.FileName;
            try
            {
                File_UploadDft11.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload11 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload11 = "";
        }


        if (File_UploadDft12.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft12.FileName;
            try
            {
                File_UploadDft12.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload12 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload12 = "";
        }


        // writen by darshan

        if (File_UploadDft13.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft13.FileName;
            try
            {
                File_UploadDft13.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload13 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload13 = "";
        }


        if (File_UploadDft14.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft14.FileName;
            try
            {
                File_UploadDft14.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload14 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload14 = "";
        }

        if (File_UploadDft15.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = File_UploadDft15.FileName;
            try
            {
                File_UploadDft15.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload15 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
        }
        else
        {
            defaultUpload15 = "";
        }

        //End



        SqlParameter[] sqlParam = new SqlParameter[16];

        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;

        sqlParam[1] = new SqlParameter("@default1", SqlDbType.VarChar, 100);
        sqlParam[1].Value = defaultUpload1;

        sqlParam[2] = new SqlParameter("@default2", SqlDbType.VarChar, 100);
        sqlParam[2].Value = defaultUpload2;

        sqlParam[3] = new SqlParameter("@default3", SqlDbType.VarChar, 100);
        sqlParam[3].Value = defaultUpload3;

        sqlParam[4] = new SqlParameter("@default4", SqlDbType.VarChar, 100);
        sqlParam[4].Value = defaultUpload4;

        sqlParam[5] = new SqlParameter("@default5", SqlDbType.VarChar, 100);
        sqlParam[5].Value = defaultUpload5;

        sqlParam[6] = new SqlParameter("@default6", SqlDbType.VarChar, 100);
        sqlParam[6].Value = defaultUpload6;

        sqlParam[7] = new SqlParameter("@default7", SqlDbType.VarChar, 100);
        sqlParam[7].Value = defaultUpload7;

        sqlParam[8] = new SqlParameter("@default8", SqlDbType.VarChar, 100);
        sqlParam[8].Value = defaultUpload8;

        sqlParam[9] = new SqlParameter("@default9", SqlDbType.VarChar, 100);
        sqlParam[9].Value = defaultUpload9;

        sqlParam[10] = new SqlParameter("@default10", SqlDbType.VarChar, 100);
        sqlParam[10].Value = defaultUpload10;

        sqlParam[11] = new SqlParameter("@default11", SqlDbType.VarChar, 100);
        sqlParam[11].Value = defaultUpload11;

        sqlParam[12] = new SqlParameter("@default12", SqlDbType.VarChar, 100);
        sqlParam[12].Value = defaultUpload12;

        sqlParam[13] = new SqlParameter("@default13", SqlDbType.VarChar, 100);
        sqlParam[13].Value = defaultUpload13;

        sqlParam[14] = new SqlParameter("@default14", SqlDbType.VarChar, 100);
        sqlParam[14].Value = defaultUpload14;

        sqlParam[15] = new SqlParameter("@default15", SqlDbType.VarChar, 100);
        sqlParam[15].Value = defaultUpload15;

        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_update_emp_doc_upload", sqlParam);

    }
    #endregion
    #region Validate Dupllicate Login & Empcode Function
    public Boolean duplicate_loginID()
    {
        int count;
        connection = activity.OpenConnection();
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@login_ID", txtempcode.Text.Trim());

        sqlstr = "select count(Login_ID) from tbl_login where Login_ID= @login_ID";
        count = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            // lbl_msg.Text = "Employee Loging ID allready existes Please change Login ID.";

            string str = "<script> alert('Employee Loging ID already exists, Please change Login ID.')</script>";
            ScriptManager.RegisterStartupScript(upempcode, upempcode.GetType(), "xx", str, false);
            return false;

        }
        else
        {
            return true;
        }
    }
    public Boolean duplicate_emp_code()
    {
        int count;

        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@emp_code", txtempcode.Text.Trim());
        connection = activity.OpenConnection();
        sqlstr = "select count(empcode) from tbl_intranet_employee_jobDetails where empcode= @emp_code";
        count = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            txtempcode.Text = "";
            //  lbl_msg.Text = "Employee Code allready existes Please change Emplyee Code.";

            string str = "<script> alert('Employee Code already exists, Please change Employee Code.')</script>";
            // Common.Console.Output.Show("'Employee Code already exists, Please change Employee Code.");

            ScriptManager.RegisterStartupScript(upempcode, upempcode.GetType(), "xx", str, false);
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion
    #region Reset Details
    protected void resetcontact()
    {

        ddl_per_state.DataSource = "";
        ddl_per_state.DataBind();
        ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_per_city.DataSource = "";
        ddl_per_city.DataBind();
        ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_pre_state.DataSource = "";
        ddl_pre_state.DataBind();
        ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_pre_city.DataSource = "";
        ddl_pre_city.DataBind();
        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_emergency_state.DataSource = "";
        ddl_emergency_state.DataBind();
        ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_emergency_city.DataSource = "";
        ddl_emergency_city.DataBind();
        ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
        txt_pre_add1.Text = "";
        txt_pre_Add2.Text = "";
        ddl_pre_country.SelectedValue = "0";
        // ddl_pre_state.Items.Insert(0, new ListItem("select", "0"));

        //ddl_pre_state.SelectedValue = "0";
        //ddl_pre_city.SelectedValue = "0";

        ddl_per_country.SelectedValue = "0";
        //ddl_per_state.SelectedValue = "0";
        //ddl_per_city.SelectedValue = "0";

        //ddl_emergency_city.SelectedValue = "0";
        ddl_emergency_country.SelectedValue = "0";
        //ddl_emergency_state.SelectedValue = "0";
        txt_emergency_address.Text = "";
        txt_emergency_address2.Text = "";
        txt_emergency_contactno.Text = "";
        txt_emergency_name.Text = "";
        drp_emg_relation.SelectedValue = "0";
        txt_emergency_zipcode.Text = "";
        txtmodeoftransport.Text = "";

        txt_pre_zip.Text = "";
        txt_pre_phone.Text = "";
        txt_per_add1.Text = "";
        txt_per_add2.Text = "";
        txt_per_zip.Text = "";
        txt_per_phone.Text = "";
        Session.Remove("emg_contact");
        gvemgcontact.DataSource = "";
        gvemgcontact.DataBind();
    }
    protected void resetPersonalDetails()
    {

        txt_DOB.Text = "";
        txt_passportno.Text = "";
        txt_dl_no.Text = "";
        txt_email.Text = "";
        //txt_bank_name.Text = "";
        ddl_bank_name.SelectedIndex = -1;
        ddl_bank_name_reimbursement.SelectedIndex = -1;
        rbtncheque.Checked = true;
        txt_bank_ac_reimbursement.Text = "";
        txt_bank_ac.Text = "";
        ddlbloodgrp.SelectedValue = "0";
        txtrelg.Text = "";
        txtmobileno.Text = "";
        txt_f_f_name.Text = "";
        txt_f_mname.Text = "";
        txt_f_l_name.Text = "";
        txt_m_fname.Text = "";
        txt_m_mname.Text = "";
        txt_m_l_name.Text = "";
        ddlpersonalstatus.SelectedValue = "0";
        tbl1.Visible = false;
        txt_s_DOB.Text = "";
        ddl_s_gender.SelectedValue = "0";
        txt_sp_fname.Text = "";
        txt_sp_mname.Text = "";
        txt_doa.Text = "";
        txt_sp_lname.Text = "";


        txt_child_name.Text = "";
        txt_child_Dob.Text = "";

        Session.Remove("Child");
        grid_child.DataSource = "";
        grid_child.DataBind();

        txt_passportexpdate.Text = "";
        txt_passportissueddate.Text = "";

        txt_bankbrachname.Text = "";
        txt_ifsc.Text = "";
        txt_drli_no.Text = "";
        txt_dr_iss_date.Text = "";
        txt_dr_exp_date.Text = "";

    }
    protected void resetjobdetails()
    {
        txtccode.Text = "";
        txtextccode.Text = "";
        txtextstdcode.Text = "";
        txt_card_no.Text = "";
        //txt_login_id.Text = "";
        txtpwd.Text = "";
        drpgender.SelectedValue = "0";
        txtfirstname.Text = "";
        txtmiddlename.Text = "";
        txtlastname.Text = "";
        drpempstatus.SelectedValue = "0";
        drprole.SelectedValue = "0";
        drpbranch.SelectedValue = "0";
        ddl_broadgroup.SelectedValue = "0";
        drpdivision.SelectedValue = "0";
        drpdegination.SelectedValue = "0";
        drpgrade.SelectedValue = "0";
        ddl_gradetype.SelectedValue = "0";
        drpdepartment.SelectedValue = "0";
        txt_noticePeriod.Text = "";
        txtsalary.Text = "";
        drpempstatus.SelectedValue = "0";
        ddl_corp_report_name.SelectedValue = "0";
        ddl_hod.SelectedValue = "0";
        //ddl_entity.SelectedValue = "0";
        //ddl_subgroup.SelectedValue = "0";
        ddl_supervisor.SelectedValue = "0";
        txt_confirmationdate.Text = "";
        txt_officialemail.Text = "";
        txtoff_mobileno.Text = "";


        ddl_cc_code.Items.Clear();
        ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_acc_code.Items.Clear();
        ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));




        ddl_acc_groupid.SelectedValue = "0";
        traddcc.Visible = false;
        //ddl_acc_country.SelectedValue = "0";
        //ddl_acc_location.SelectedValue = "0";
        //ddl_acc_state.SelectedValue = "0";
        //ddl_acc_code.SelectedValue = "0";
        //ddl_acc_city.SelectedValue = "0";
        //ddl_broadgroup.SelectedValue = "0";

        ddl_cc_groupid.SelectedValue = "0";
        trcc.Visible = false;
        //ddl_cc_city.SelectedValue = "0";
        //ddl_cc_code.SelectedValue = "0";
        //ddl_cc_country.SelectedValue = "0";
        //ddl_cc_location.SelectedValue = "0";
        //ddl_cc_state.SelectedValue = "0";


        txtdol.Text = "";
        txtreason.Text = "";
        txtext.Text = "";
        doj.Text = "";
        txtempcode.Text = "";

        txt_ptno.Text = "";
        esino.Text = "";
        esidesp.Text = "";
        pfno.Text = "";
        panno.Text = "";
        pfno_dept.Text = "";
        ward.Text = "";
        // Reset Approvers Details
        txtreportmanager.Text = "";
        txtbusinesshead.Text = "";
        txtfncmang.Text = "";
        txtadmin.Text = "";
        txthr.Text = "";
        txthrd.Text = "";
        txtmng.Text = "";
        txtdeptclr.Text = "";
        txtadminclr.Text = "";
        txtaccdeptclr.Text = "";
        txtnetworkclr.Text = "";
        txthrdeptclr.Text = "";
        txtaccdeleclr.Text = "";


    }
    protected void reset_professional_detail()
    {
        Session.Remove("acc_education");
        Session.Remove("Pro_education");
        Session.Remove("exp");
        Session.Remove("training");

        grid_edu_education.DataSource = "";
        grid_edu_education.DataBind();

        grid_Pro_education.DataSource = "";
        grid_Pro_education.DataBind();

        grid_exp.DataSource = "";
        grid_exp.DataBind();

        GridTraning.DataSource = "";
        GridTraning.DataBind();
        ddlpersonalstatus.SelectedValue = "0";


    }
    protected void resetprofessionaldetails()
    {

        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        txtfrm1.Text = "";
        txtto1.Text = "";


    }
    protected void resetexperiencedetails()
    {
        txtcomp1.Text = "";
        txt_total_exp.Text = "";
        txt_exp_from.Text = "";
        txt_exp_to.Text = "";
    }
    #endregion
    #region Add static upload fields
    //-------------------Add static upload fields-------------------------
    //protected void bindlabels()
    //{
    //    sqlstr = @"select id,labelname from staticlabel ";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    DropDownList1.DataSource = ds;
    //    DropDownList1.DataValueField = "id";
    //    DropDownList1.DataTextField = "labelname";
    //    DropDownList1.DataBind();

    //    DropDownList2.DataSource = ds;
    //    DropDownList2.DataValueField = "id";
    //    DropDownList2.DataTextField = "labelname";
    //    DropDownList2.DataBind();

    //    DropDownList3.DataSource = ds;
    //    DropDownList3.DataValueField = "id";
    //    DropDownList3.DataTextField = "labelname";
    //    DropDownList3.DataBind();

    //    DropDownList4.DataSource = ds;
    //    DropDownList4.DataValueField = "id";
    //    DropDownList4.DataTextField = "labelname";
    //    DropDownList4.DataBind();

    //    DropDownList5.DataSource = ds;
    //    DropDownList5.DataValueField = "id";
    //    DropDownList5.DataTextField = "labelname";
    //    DropDownList5.DataBind();

    //    DropDownList6.DataSource = ds;
    //    DropDownList6.DataValueField = "id";
    //    DropDownList6.DataTextField = "labelname";
    //    DropDownList6.DataBind();

    //    DropDownList7.DataSource = ds;
    //    DropDownList7.DataValueField = "id";
    //    DropDownList7.DataTextField = "labelname";
    //    DropDownList7.DataBind();

    //    DropDownList8.DataSource = ds;
    //    DropDownList8.DataValueField = "id";
    //    DropDownList8.DataTextField = "labelname";
    //    DropDownList8.DataBind();

    //    DropDownList9.DataSource = ds;
    //    DropDownList9.DataValueField = "id";
    //    DropDownList9.DataTextField = "labelname";
    //    DropDownList9.DataBind();


    //    DropDownList10.DataSource = ds;
    //    DropDownList10.DataValueField = "id";
    //    DropDownList10.DataTextField = "labelname";
    //    DropDownList10.DataBind();

    //}
    public void Adddefaultlables()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select labelname from staticlabel";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            lbl_Default1.Text = ds.Tables[0].Rows[0]["labelname"].ToString();
            lbl_Default2.Text = ds.Tables[0].Rows[1]["labelname"].ToString();
            lbl_Default3.Text = ds.Tables[0].Rows[2]["labelname"].ToString();
            lbl_Default4.Text = ds.Tables[0].Rows[3]["labelname"].ToString();
            lbl_Default5.Text = ds.Tables[0].Rows[4]["labelname"].ToString();
            lbl_Default6.Text = ds.Tables[0].Rows[5]["labelname"].ToString();
            lbl_Default7.Text = ds.Tables[0].Rows[6]["labelname"].ToString();
            lbl_Default8.Text = ds.Tables[0].Rows[7]["labelname"].ToString();
            lbl_Default9.Text = ds.Tables[0].Rows[8]["labelname"].ToString();
            lbl_Default10.Text = ds.Tables[0].Rows[9]["labelname"].ToString();
            lbl_Default11.Text = ds.Tables[0].Rows[10]["labelname"].ToString();
            lbl_Default12.Text = ds.Tables[0].Rows[11]["labelname"].ToString();
            lbl_Default13.Text = ds.Tables[0].Rows[12]["labelname"].ToString();
            lbl_Default14.Text = ds.Tables[0].Rows[13]["labelname"].ToString();
            lbl_Default15.Text = ds.Tables[0].Rows[16]["labelname"].ToString();
            //Label3.Text = ds.Tables[0].Rows[14]["labelname"].ToString();
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            TextBox8.Visible = false;
            TextBox9.Visible = false;
            TextBox10.Visible = false;
            TextBox11.Visible = false;
            TextBox12.Visible = false;
            TextBox13.Visible = false;
            TextBox14.Visible = false;
            lbl_Default1.Visible = true;
            lbl_Default2.Visible = true;
            lbl_Default3.Visible = true;
            lbl_Default4.Visible = true;
            lbl_Default5.Visible = true;
            lbl_Default6.Visible = true;
            lbl_Default7.Visible = true;
            lbl_Default8.Visible = true;
            lbl_Default9.Visible = true;
            lbl_Default10.Visible = true;
            lbl_Default11.Visible = true;
            lbl_Default12.Visible = true;
            TextBox15.Visible = false;
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    //protected void ck_editlables_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ck_editlables.Checked == true)
    //    {
    //        btnSavedeflable.Visible = true;
    //        TextBox1.Visible = true;
    //        TextBox2.Visible = true;
    //        TextBox3.Visible = true;
    //        TextBox4.Visible = true;
    //        TextBox5.Visible = true;
    //        TextBox6.Visible = true;
    //        TextBox7.Visible = true;
    //        TextBox8.Visible = true;
    //        TextBox9.Visible = true;
    //        TextBox10.Visible = true;

    //        TextBox1.Text = lbl_Default1.Text;
    //        TextBox2.Text = lbl_Default2.Text;
    //        TextBox3.Text = lbl_Default3.Text;
    //        TextBox4.Text = lbl_Default4.Text;
    //        TextBox5.Text = lbl_Default5.Text;
    //        TextBox6.Text = lbl_Default6.Text;
    //        TextBox7.Text = lbl_Default7.Text;
    //        TextBox8.Text = lbl_Default8.Text;
    //        TextBox9.Text = lbl_Default9.Text;
    //        TextBox10.Text = lbl_Default10.Text;

    //        lbl_Default1.Visible = false;
    //        lbl_Default2.Visible = false;
    //        lbl_Default3.Visible = false;
    //        lbl_Default4.Visible = false;
    //        lbl_Default5.Visible = false;
    //        lbl_Default6.Visible = false;
    //        lbl_Default7.Visible = false;
    //        lbl_Default8.Visible = false;
    //        lbl_Default9.Visible = false;
    //        lbl_Default10.Visible = false;
    //    }
    //    else
    //    {
    //        Adddefaultlables();


    //    }

    //}
    //protected void btnSavedeflable_Click(object sender, EventArgs e)
    //{
    //    string[,] label = new string[10, 2];

    //    label[0, 0] = "1";
    //    label[0, 1] = DropDownList1.Text;

    //    label[1, 0] = "2";
    //    label[1, 1] = DropDownList2.Text;

    //    label[2, 0] = "3";
    //    label[2, 1] = DropDownList3.Text;

    //    label[3, 0] = "4";
    //    label[3, 1] = DropDownList4.Text;

    //    label[4, 0] = "5";
    //    label[4, 1] = DropDownList5.Text;

    //    label[5, 0] = "6";
    //    label[5, 1] = DropDownList6.Text;

    //    label[6, 0] = "7";
    //    label[6, 1] = DropDownList7.Text;

    //    label[7, 0] = "8";
    //    label[7, 1] = DropDownList8.Text;

    //    label[8, 0] = "9";
    //    label[8, 1] = DropDownList9.Text;

    //    label[9, 0] = "10";
    //    label[9, 1] = DropDownList10.Text;

    //    for (int i = 0; i < 10; i++)
    //    {
    //        for (int j = 0; j < 1; j++)
    //        {
    //            UpdateLabel(Convert.ToInt32(label[i, j]), label[i, j + 1]);
    //            // Adddefaultlables();
    //        }
    //    }
    //    // ck_editlables.Checked = false;

    //}

    private void UpdateLabel(int id, string labelName)
    {
        try
        {
            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@emp_code", SqlDbType.Int);
            parm[0].Value = id;

            parm[0] = new SqlParameter("@emp_code", SqlDbType.VarChar, 50);
            parm[0].Value = labelName.ToString();

            int flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "UpdateLabel", parm);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    #endregion
    #region Bind Employee Name
    protected void bind_emp()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr_entity = "select empcode,empcode+'->'+isnull(emp_fname,'')+' '+isnull(emp_m_name,'')+' '+isnull(emp_l_name,'') as emp_fname from tbl_intranet_employee_jobDetails where emp_status!='4'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_entity);

            ddl_supervisor.DataSource = ds;
            ddl_supervisor.DataValueField = "empcode";
            ddl_supervisor.DataTextField = "emp_fname";
            ddl_supervisor.DataBind();
            ddl_supervisor.Items.Insert(0, new ListItem("--Select--", "0"));

            ddl_hod.DataSource = ds;
            ddl_hod.DataValueField = "empcode";
            ddl_hod.DataTextField = "emp_fname";
            ddl_hod.DataBind();
            ddl_hod.Items.Insert(0, new ListItem("--Select--", "0"));

            ddl_corp_report_name.DataSource = ds;
            ddl_corp_report_name.DataValueField = "empcode";
            ddl_corp_report_name.DataTextField = "emp_fname";
            ddl_corp_report_name.DataBind();
            ddl_corp_report_name.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    #endregion
    #region Bind BroadGroup
    protected void bind_broadgroup()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id,broadgroup_name from tbl_intranet_broadgroup order by broadgroup_name";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_broadgroup.DataSource = ds;
                ddl_broadgroup.DataTextField = "broadgroup_name";
                ddl_broadgroup.DataValueField = "id";
                ddl_broadgroup.DataBind();
            }
            ddl_broadgroup.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Bind Cost Center & Additonal costcenter

    protected void ddl_cc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_cc_code.Items.Clear();
        ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));
        trcc.Visible = false;
        if (ddl_cc_groupid.SelectedValue != "0")
            bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));

    }
    protected void ddl_cc_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        trcc.Visible = false;
        if (ddl_cc_code.SelectedValue != "0")
        {
            trcc.Visible = true;
            bind_cc(Convert.ToInt32(ddl_cc_code.SelectedValue));
        }

        //bind_cc_country(Convert.ToInt32(ddl_cc_code.SelectedValue));
        //ddl_cc_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void bind_ddlCCgroup()
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_cc_groupid.DataSource = ds;
            ddl_cc_groupid.DataTextField = "cost_center_group_name";
            ddl_cc_groupid.DataValueField = "id";
            ddl_cc_groupid.DataBind();
            ddl_cc_groupid.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_cc_code(int accgroupid)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_cc_code.DataSource = ds;
            ddl_cc_code.DataTextField = "cost_center_code";
            ddl_cc_code.DataValueField = "id";
            ddl_cc_code.DataBind();
            ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_cc(int cc_id)
    {
        try
        {
            connection = activity.OpenConnection(); string sqlstr1 = "select id,country,state,city, location from tbl_intranet_cost_center where id='" + cc_id + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            int cid = Convert.ToInt32(ds.Tables[0].Rows[0]["country"]);
            string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            hf_ccountry.Value = ds.Tables[0].Rows[0]["country"].ToString();
            hf_cstate.Value = ds.Tables[0].Rows[0]["state"].ToString();
            hf_ccity.Value = ds.Tables[0].Rows[0]["city"].ToString();
            lbl_cc_country.Text = ds3.Tables[0].Rows[0]["countryname"].ToString();

            string sqlstr2 = "select ID,state from tbl_intranet_state_master where ID='" + Convert.ToInt32(ds.Tables[0].Rows[0]["state"]) + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr2);
            lbl_cc_state.Text = ds4.Tables[0].Rows[0]["state"].ToString();


            string sqlstr3 = "select cid,stateid,city from tbl_intranet_city where cid='" + Convert.ToInt32(ds.Tables[0].Rows[0]["city"]) + "'";
            DataSet ds5 = new DataSet();
            ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr3);
            lbl_cc_city.Text = ds5.Tables[0].Rows[0]["city"].ToString();

            lbl_cc_location.Text = ds.Tables[0].Rows[0]["location"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    //protected void bind_cc_country(int cc_id)
    //{
    //    if (cc_id == 0)
    //        return;
    //    string sqlstr1 = "select * from tbl_intranet_cost_center where cost_center_code='" + cc_id + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
    //    int cid = Convert.ToInt32(ds.Tables[0].Rows[0]["country"]);
    //    string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
    //    DataSet ds3 = new DataSet();
    //    ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_cc_country.DataTextField = "countryname";
    //    ddl_cc_country.DataValueField = "cid";
    //    ddl_cc_country.DataSource = ds3;
    //    ddl_cc_country.DataBind();
    //    bind_cc_state(Convert.ToInt32(ds.Tables[0].Rows[0]["state"]));
    //    bind_cc_city(Convert.ToInt32(ds.Tables[0].Rows[0]["city"]));
    //    bind_cc_location(ds.Tables[0].Rows[0]["location"].ToString());
    //}
    //protected void bind_cc_state(int stateid)
    //{

    //    string sqlstr = "select ID,state from tbl_intranet_state_master where ID='" + stateid + "' ";
    //    DataSet ds4 = new DataSet();
    //    ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_cc_state.DataTextField = "state";
    //    ddl_cc_state.DataValueField = "ID";
    //    ddl_cc_state.DataSource = ds4;
    //    ddl_cc_state.DataBind();
    //}
    //protected void bind_cc_city(int cityid)
    //{
    //    sqlstr = "select cid,stateid,city from tbl_intranet_city where cid='" + cityid + "'";
    //    DataSet ds5 = new DataSet();
    //    ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    ddl_cc_city.DataSource = ds5;
    //    ddl_cc_city.DataTextField = "city";
    //    ddl_cc_city.DataValueField = "cid";
    //    ddl_cc_city.DataBind();


    //}
    //protected void bind_cc_location(string location)
    //{
    //    sqlstr = "select location from tbl_intranet_cost_center where location='" + location + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;
    //    ddl_cc_location.DataSource = ds;
    //    ddl_cc_location.DataTextField = "location";
    //    ddl_cc_location.DataValueField = "location";
    //    ddl_cc_location.DataBind();
    //    //ddl_cc_location.Items.Insert(0, new ListItem("--Select--", "0"));

    //}


    //------------------------End----------------------



    //-----------------------for additional cost center--------------


    protected void ddl_acc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_acc_code.Items.Clear();
        ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
        traddcc.Visible = false;
        if (ddl_acc_groupid.SelectedValue != "0")
            bind_ddl_acc_code(Convert.ToInt32(ddl_acc_groupid.SelectedValue));
        //ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_acc_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        traddcc.Visible = false;
        if (ddl_acc_code.SelectedValue != "0")
        {
            bind_acc(Convert.ToInt32(ddl_acc_code.SelectedValue));
            traddcc.Visible = true;
        }
        //bind_acc_country(Convert.ToInt32(ddl_acc_code.SelectedValue));
        //ddl_acc_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_ddl_aCCgroup()
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_acc_groupid.DataSource = ds;
            ddl_acc_groupid.DataTextField = "cost_center_group_name";
            ddl_acc_groupid.DataValueField = "id";
            ddl_acc_groupid.DataBind();
            ddl_acc_groupid.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_ddl_acc_code(int accgroupid)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_acc_code.DataSource = ds;
            ddl_acc_code.DataTextField = "cost_center_code";
            ddl_acc_code.DataValueField = "id";
            ddl_acc_code.DataBind();
            ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }


    protected void bind_acc(int acc_id)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr1 = "select id,country,state,city, location from tbl_intranet_cost_center where id='" + acc_id + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            int cid = Convert.ToInt32(ds.Tables[0].Rows[0]["country"]);
            string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            hf_accountry.Value = ds.Tables[0].Rows[0]["country"].ToString();
            hf_acstate.Value = ds.Tables[0].Rows[0]["state"].ToString();
            hf_accity.Value = ds.Tables[0].Rows[0]["city"].ToString();

            lbl_acc_country.Text = ds3.Tables[0].Rows[0]["countryname"].ToString();

            string sqlstr2 = "select ID,state from tbl_intranet_state_master where ID='" + Convert.ToInt32(ds.Tables[0].Rows[0]["state"]) + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr2);
            lbl_acc_state.Text = ds4.Tables[0].Rows[0]["state"].ToString();


            string sqlstr3 = "select cid,stateid,city from tbl_intranet_city where cid='" + Convert.ToInt32(ds.Tables[0].Rows[0]["city"]) + "'";
            DataSet ds5 = new DataSet();
            ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr3);
            lbl_acc_city.Text = ds5.Tables[0].Rows[0]["city"].ToString();

            lbl_acc_location.Text = ds.Tables[0].Rows[0]["location"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    //protected void bind_acc_country(int acc_id)
    //{
    //    if (acc_id == 0)
    //        return;
    //    string sqlstr1 = "select * from tbl_intranet_cost_center where cost_center_code='" + acc_id + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
    //    int cid = Convert.ToInt32(ds.Tables[0].Rows[0]["country"]);
    //    string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
    //    DataSet ds3 = new DataSet();
    //    ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_acc_country.DataTextField = "countryname";
    //    ddl_acc_country.DataValueField = "cid";
    //    ddl_acc_country.DataSource = ds3;
    //    ddl_acc_country.DataBind();
    //    bind_acc_state(Convert.ToInt32(ds.Tables[0].Rows[0]["state"]));
    //    bind_acc_city(Convert.ToInt32(ds.Tables[0].Rows[0]["city"]));
    //    bind_acc_location(ds.Tables[0].Rows[0]["location"].ToString());

    //}
    //protected void bind_acc_state(int stateid)
    //{

    //    string sqlstr = "select ID,state from tbl_intranet_state_master where ID='" + stateid + "' ";
    //    DataSet ds4 = new DataSet();
    //    ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_acc_state.DataTextField = "state";
    //    ddl_acc_state.DataValueField = "ID";
    //    ddl_acc_state.DataSource = ds4;
    //    ddl_acc_state.DataBind();
    //}
    //protected void bind_acc_city(int cityid)
    //{
    //    sqlstr = "select cid,stateid,city from tbl_intranet_city where cid='" + cityid + "'";
    //    DataSet ds5 = new DataSet();
    //    ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    ddl_acc_city.DataSource = ds5;
    //    ddl_acc_city.DataTextField = "city";
    //    ddl_acc_city.DataValueField = "cid";
    //    ddl_acc_city.DataBind();


    //}


    //protected void bind_acc_location(string location)
    //{
    //    sqlstr = "select location from tbl_intranet_cost_center where location='" + location + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;
    //    ddl_acc_location.DataSource = ds;
    //    ddl_acc_location.DataTextField = "location";
    //    ddl_acc_location.DataValueField = "location";
    //    ddl_acc_location.DataBind();


    //}
    //----------------------------------------------




    //-----------------------for Permanent address--------------
    #endregion
    #region Bind Country, State and City
    protected void ddl_per_country_SelectedIndexChanged(object sender, EventArgs e)
    {


        ddl_per_state.Items.Clear();
        ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_per_city.Items.Clear();
        ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_per_country.SelectedValue != "0")
        {
            bind_per_state(ddl_per_country.SelectedValue);
            ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    protected void ddl_per_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_per_city.Items.Clear();
        ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_per_state.SelectedValue != "0")
        {
            bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
            ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_per_country()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_per_country.DataTextField = "countryname";
            ddl_per_country.DataValueField = "countryname";
            ddl_per_country.DataSource = ds3;
            ddl_per_country.DataBind();
            ddl_per_country.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_per_state(string stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_per_state.DataTextField = "state";
            ddl_per_state.DataValueField = "ID";
            ddl_per_state.DataSource = ds4;
            ddl_per_state.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_per_city(int stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
            DataSet ds5 = new DataSet();
            ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            ddl_per_city.DataSource = ds5;
            ddl_per_city.DataTextField = "city";
            ddl_per_city.DataValueField = "cid";
            ddl_per_city.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void ddl_pre_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_pre_state.Items.Clear();
        ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_pre_city.Items.Clear();
        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_pre_country.SelectedValue != "0")
        {
            bind_pre_state(ddl_pre_country.SelectedValue);
            ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void ddl_pre_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_pre_city.Items.Clear();
        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_pre_state.SelectedValue != "0")
        {
            bind_pre_city(Convert.ToInt32(ddl_pre_state.SelectedValue));
            ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_pre_country()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_pre_country.DataTextField = "countryname";
            ddl_pre_country.DataValueField = "countryname";
            ddl_pre_country.DataSource = ds3;
            ddl_pre_country.DataBind();
            ddl_pre_country.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_pre_state(string stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_pre_state.DataTextField = "state";
            ddl_pre_state.DataValueField = "ID";
            ddl_pre_state.DataSource = ds4;
            ddl_pre_state.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_pre_city(int stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
            DataSet ds5 = new DataSet();
            ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            ddl_pre_city.DataSource = ds5;
            ddl_pre_city.DataTextField = "city";
            ddl_pre_city.DataValueField = "cid";
            ddl_pre_city.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void ddl_emergency_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_emergency_state.Items.Clear();
        ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_emergency_city.Items.Clear();
        ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_emergency_country.SelectedValue != "0")
        {
            bind_Emergency_state(ddl_emergency_country.SelectedValue);
            ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void ddl_emergency_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_emergency_city.Items.Clear();
        ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_emergency_state.SelectedValue != "0")
        {
            bind_Emergency_city(Convert.ToInt32(ddl_emergency_state.SelectedValue));
            ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_Emergency_country()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_emergency_country.DataTextField = "countryname";
            ddl_emergency_country.DataValueField = "countryname";
            ddl_emergency_country.DataSource = ds3;
            ddl_emergency_country.DataBind();
            ddl_emergency_country.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_Emergency_state(string stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
            DataSet ds4 = new DataSet();
            ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddl_emergency_state.DataTextField = "state";
            ddl_emergency_state.DataValueField = "ID";
            ddl_emergency_state.DataSource = ds4;
            ddl_emergency_state.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void bind_Emergency_city(int stateid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
            DataSet ds_emg = new DataSet();
            ds_emg = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            ddl_emergency_city.DataSource = ds_emg;
            ddl_emergency_city.DataTextField = "city";
            ddl_emergency_city.DataValueField = "cid";
            ddl_emergency_city.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    #endregion
    #region Bind Department
    protected void bind_departmnt(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE dept_type_id='" + branchid + "' order by department_name ";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartment.DataTextField = "department_name";
            drpdepartment.DataValueField = "departmentid";
            drpdepartment.DataSource = ds1;
            drpdepartment.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }


    protected void drpdepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //bind_departmenttype(Convert.ToInt32(drpdepartment.SelectedValue));
        //BindDesignation(drpdepartment.SelectedValue);
    }
    #endregion
    #region Bind Department Type
    protected void bind_departmenttype(int dept_type_id)
    {
         try
        {
            connection = activity.OpenConnection();
            sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type where branch_id='" + dept_type_id + "' order by dept_type_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartmenttype.DataTextField = "dept_type_name";
            drpdepartmenttype.DataValueField = "dept_type_id";
            drpdepartmenttype.DataSource = ds1;
            drpdepartmenttype.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }


    #endregion


    private void BindDesignation(string deptid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid + " order by  designationname";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpdegination.DataSource = ds;
                drpdegination.DataTextField = "designationname";
                drpdegination.DataValueField = "id";
                drpdegination.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void bind_employeesubtype(string emp_type_code)
    {
        try
        {
            connection = activity.OpenConnection();
            //sqlstr = "select emp_type_code,emp_subtype_name from tbl_internate_employee_subtype where emp_type_code=" + emp_type_code + " order by emp_subtype_name";
            sqlstr = "select emp_subtype_id,emp_subtype_name from tbl_internate_employee_subtype where emp_type_code=" + emp_type_code + " order by emp_subtype_name";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_semp_type.DataSource = ds;
                ddl_semp_type.DataTextField = "emp_subtype_name";
                ddl_semp_type.DataValueField = "emp_subtype_id";
                ddl_semp_type.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    #region Save Job Details for Job Details Tab

    protected void btnjob_Click1(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            string file_name = "";

            if (Page.IsValid)
            {
                if (f_upload_rep1.GotFile)
                {
                    file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
                    f_upload_rep1.FilePost.SaveAs(Server.MapPath("../upload/photo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
                    file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();

                    ViewState.Add("Photo", file_name);

                }
                else
                    ViewState.Add("Photo", file_name);
            }
            else
                ViewState.Add("Photo", file_name);
            Session.Add("Inserted_Emp_code", txtempcode.Text);

            //if (duplicate_emp_code() && duplicate_loginID())
            //{
            // if (!CheckDOJ())
            // return;
            insert_Job_detail(connection, transaction);
            insert_Log_in_detail_save(connection, transaction);
            //-------------Employee History Is Added Here starts ---------------//
                
            string st = "insert into EmpHistory(EmpCode,DesignationId,DepartmentId,EmpRole,UpdatedBy,DateAdded,status)values('" + txtempcode.Text.Trim() + "','" + drpdegination.SelectedValue.Trim().ToString() + "','" + drpdepartment.SelectedValue.Trim().ToString() + "','" + drprole.SelectedValue.Trim().ToString() + "','" + _userCode + "','" + System.DateTime.Today.ToShortDateString() + "',0)";
            int x = SQLServer.ExecuteNonQuery(connection, CommandType.Text, st);
            //-------------Employee History Is Added Here Ends---------------//
            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();
                transaction = connection.BeginTransaction();
                insert_Payroll_Detail(emplyee_Code, connection, transaction);
                transaction.Commit();

                string str = "<script> alert('Employee Job Detail has been successfully Saved')</script>";
                ScriptManager.RegisterStartupScript(dd, dd.GetType(), "xx", str, false);
            }
            //}

            else
            {
                string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
                Page.RegisterStartupScript("Employee", str.ToString());
            }
        }

        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            //SmartHr.Common.Alert("Employee Job Details Saved successfully!!!.");
            activity.CloseConnection();
        }
    }


    //protected void btnjob_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        string file_name = "";

    //        if (Page.IsValid)
    //        {
    //            if (f_upload_rep1.GotFile)
    //            {
    //                file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
    //                f_upload_rep1.FilePost.SaveAs(Server.MapPath("../upload/photo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
    //                file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();

    //                ViewState.Add("Photo", file_name);

    //            }
    //            else
    //                ViewState.Add("Photo", file_name);
    //        }
    //        else
    //            ViewState.Add("Photo", file_name);
    //        Session.Add("Inserted_Emp_code", txtempcode.Text);

    //        //if (duplicate_emp_code() && duplicate_loginID())
    //        //{
    //        // if (!CheckDOJ())
    //       // return;
    //        insert_Job_detail(connection, transaction);
    //        insert_Log_in_detail_save(connection, transaction);
    //        //-------------Employee History Is Added Here starts ---------------//

    //        string st = "insert into EmpHistory(EmpCode,DesignationId,DepartmentId,EmpRole,UpdatedBy,DateAdded,status)values('" + txtempcode.Text.Trim() + "','" + drpdegination.SelectedValue.Trim().ToString() + "','" + drpdepartment.SelectedValue.Trim().ToString() + "','" + drprole.SelectedValue.Trim().ToString() + "','" + _userCode + "','"+System.DateTime.Today.ToShortDateString()+"',0)";
    //        int x = SQLServer.ExecuteNonQuery(connection, CommandType.Text, st);
    //        //-------------Employee History Is Added Here Ends---------------//
    //        if (Session["Inserted_Emp_code"] != null)
    //        {
    //            string emplyee_Code = Session["Inserted_Emp_code"].ToString();
    //            transaction = connection.BeginTransaction();
    //            insert_Payroll_Detail(emplyee_Code, connection, transaction);
    //            transaction.Commit();

    //            //string str = "<script> alert('Employee Job Detail has been successfully Saved')</script>";
    //            //ScriptManager.RegisterStartupScript(dd, dd.GetType(), "xx", str, false);
    //        }
    //        //}

    //        else
    //        {
    //            string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
    //            Page.RegisterStartupScript("Employee", str.ToString());
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        transaction.Rollback();
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        //SmartHr.Common.Alert("Employee Job Details Saved successfully!!!.");
    //        activity.CloseConnection();
    //    }
    //}

    private void insert_Log_in_detail_save(SqlConnection connection, SqlTransaction transaction)
    {
        int saltSize = 5;
        string salt = CreateSalt(saltSize);
        string passwordHash = CreatePasswordHash("123", salt);

        SqlParameter[] sqlparam1 = new SqlParameter[4];

        sqlparam1[0] = new SqlParameter("@loginid", SqlDbType.VarChar, 50);
        sqlparam1[0].Value = txtempcode.Text.Trim().ToString();

        sqlparam1[1] = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
        sqlparam1[1].Value = passwordHash.Trim().ToString();

        sqlparam1[2] = new SqlParameter("@role", SqlDbType.TinyInt);
        sqlparam1[2].Value = drprole.SelectedValue;

        sqlparam1[3] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam1[3].Value = txtempcode.Text.Trim().ToString();

        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_employee_login", sqlparam1);
    }
    #endregion
    #region Save Contact Details for Contact Details Tab
    protected void btncontact_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();

            transaction = connection.BeginTransaction();

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();


                insert_contact_detail(emplyee_Code, connection, transaction);
                Insert_Emg_Contact_detail(emplyee_Code, connection, transaction);
                transaction.Commit();
                //  resetcontact();

                //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                string str = "<script> alert('Employee Contact Detail saved successfully!!!')</script>";
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "xx", str, false);
                //TabContainer1.ActiveTabIndex = 0;
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Save Profissional Details for Profissional Details Tab
    protected void btnprop_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();

            transaction = connection.BeginTransaction();

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();
                Insert_Educational_Qualification(emplyee_Code, connection, transaction);
                Insert_Professional_Qualification(emplyee_Code, connection, transaction);
                Insert_Expriece_detail(emplyee_Code, connection, transaction);
                insert_Training_details(emplyee_Code, connection, transaction);
                //  insert_personal_detail(emplyee_Code, connection, transaction);
                transaction.Commit();
                // reset_professional_detail();

                //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                string str = "<script> alert('Employee Professional Detail Saved Successfully!!!')</script>";
                ScriptManager.RegisterStartupScript(upedu, upedu.GetType(), "xx", str, false);
                Page.RegisterStartupScript("Employee", str.ToString());
                //TabContainer1.ActiveTabIndex = 0;
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Save Personal Details for Personal Details Tab
    protected void btnpersonal_Click(object sender, EventArgs e)
    {
        if (txt_DOB.Text != "")
        {
            if (Convert.ToDateTime(txt_DOB.Text) > DateTime.Now)
            {
                Output.Show("Date of birth should be less than or  equal to current date");
                return;

            }

        }
        if (txt_s_DOB.Text != "")
        {
            if (Convert.ToDateTime(txt_s_DOB.Text) > DateTime.Now)
            {
                Output.Show("Spouse Date of birth should be less than or  equal to current date");
                return;
            }
        }
        if (txt_child_Dob.Text != "")
        {
            if (Convert.ToDateTime(txt_child_Dob.Text) > DateTime.Now)
            {
                Output.Show("Children Date of birth should be less than or equal to current date");
                return;
            }
        }
        //if (Convert.ToDateTime(txt_passportissueddate.Text)<Convert.ToDateTime(txt_passportexpdate.Text))
        //{
        //    Output.Show("eneter the valid date and year");
            
        //}
        try
        {
            connection = activity.OpenConnection();

            transaction = connection.BeginTransaction();

            Session.Add("Inserted_Emp_code", txtempcode.Text);

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();
                insert_personal_detail(emplyee_Code, connection, transaction);
                Insert_Children_detail(emplyee_Code, connection, transaction);
                transaction.Commit();
                // resetPersonalDetails();
                string str = "<script> alert('Employee Personal Detail has been successfully Saved')</script>";
                ScriptManager.RegisterStartupScript(updatepanel8, updatepanel8.GetType(), "xx", str, false);
                Page.RegisterStartupScript("Employee", str.ToString());
                //TabContainer1.ActiveTabIndex = 0;
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Save Upload Details for Upload Details Tab
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();
                Upload_doc(emplyee_Code, connection, transaction);
                transaction.Commit();
                //string str = "<script> alert('Employee Upload Details has been successfully Saved')</script>";
                //ScriptManager.RegisterStartupScript(upload, upload.GetType(), "xx", str, false);
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Validate Empcode on Empcode Text chageevent
    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {
        if (duplicate_emp_code() && duplicate_loginID())
        {
        }
        else
        {

            string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
            Page.RegisterStartupScript("Employee", str.ToString());

            //lbl_msg.Text = "Error : Please Enter Employee Code in Job Detail Tab of Employee Master.";

        }
    }
    #endregion

    #region Emg Contact detail
    //protected void btnemgcontact_Click(object sender, EventArgs e)
    //{
    //    Emg_Conatct_grid();
    //    txt_emergency_name.Text = "";
    //    txt_emg_ccode.Text = "";
    //    drp_emg_relation.SelectedValue = "0";
    //    txt_emergency_contactno.Text = "";
    //    txt_emg_landlinestdcode.Text = "";
    //    txt_emg_landlineno.Text = "";
    //    txt_emg_landcode.Text = "";

    //}

    protected void Emg_Conatct_grid()
    {
        DataRow dr;
        if (Session["emg_contact"] == null)
        {
            create_emg_contact_table();
        }
        dtable = (DataTable)Session["emg_contact"];

        DataRow drfind = dtable.Rows.Find(txt_emergency_name.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["emg_name"] = txt_emergency_name.Text;
            dr["emg_relation"] = drp_emg_relation.SelectedValue;
            dr["emg_contactno"] = txt_emg_ccode.Text + "-" + txt_emergency_contactno.Text;
            dr["emg_landlineno"] = txt_emg_landcode.Text + "-" + txt_emg_landlinestdcode.Text + "-" + txt_emg_landlineno.Text;

            dtable.Rows.Add(dr);
        }
        Session["emg_contact"] = dtable;
        BindList_Emg_Contact();
    }
    protected void BindList_Emg_Contact()
    {
        if (Session["emg_contact"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["emg_contact"];
            dview = new DataView(dtable);
            dview.Sort = "emg_name";
        }
        gvemgcontact.DataSource = dview;
        gvemgcontact.DataBind();
    }
    protected void create_emg_contact_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("emg_name", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["emg_name"] };
        dtable.Columns.Add("emg_relation", typeof(string));
        dtable.Columns.Add(new DataColumn("emg_contactno", typeof(string)));
        dtable.Columns.Add(new DataColumn("emg_landlineno", typeof(string)));
        Session["emg_contact"] = dtable;
    }

    protected void gvemgcontact_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["emg_contact"];
        DataRow drfind_child = dtable.Rows.Find(Convert.ToString(gvemgcontact.DataKeys[e.RowIndex].Value));
        if (drfind_child != null)
        {
            drfind_child.Delete();
            Session["emg_contact"] = dtable;
            BindList_Emg_Contact();
        }
    }
    protected void Insert_Emg_Contact_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {

        if (Session["emg_contact"] != null)
        {
            dtable = (DataTable)Session["emg_contact"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                string sqlstr = @"insert into tbl_intranet_employee_emgcontact_details(empcode,emg_name ,emg_relation,emg_contactno,emg_landlineno ) values('" + emp_code + "','" + dtable.Rows[i]["emg_name"].ToString() + "','" + dtable.Rows[i]["emg_relation"].ToString() + "','" + dtable.Rows[i]["emg_contactno"].ToString() + "','" + dtable.Rows[i]["emg_landlineno"].ToString() + "')";
                SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            }

        }



    }
    #endregion
    #region Bind ApproverDetails
    private void BindApproverDetails(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparm1 = new SqlParameter[17];
        Output.AssignParameter(sqlparm1, 0, "@empcode", "String", 50, empcode.ToString());
        Output.AssignParameter(sqlparm1, 1, "@app_finance", "String", 50, txtfncmang.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 2, "@app_admin", "String", 50, txtadmin.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 3, "@app_reportingmanager", "String", 50, txtreportmanager.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 4, "@app_management", "String", 50, txtmng.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 5, "@app_hr", "String", 50, txthr.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 6, "@app_businesshead", "String", 50, txtbusinesshead.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 7, "@app_hrd", "String", 50, txthrd.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 8, "@clr_department", "String", 50, txtdeptclr.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 9, "@clr_generaladmin", "String", 50, txtadminclr.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 10, "@clr_accountsdept", "String", 50, txtaccdeleclr.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 11, "@clr_networkdept", "String", 50, txtnetworkclr.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 12, "@clr_hr", "String", 50, txthrdeptclr.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 13, "@clr_useraccountdeletion", "String", 50, txtaccdeleclr.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 14, "@create_by", "String", 50, _userCode.ToString());
        Output.AssignParameter(sqlparm1, 15, "@app_dotted_linemanager", "String", 50, txtdottedlinemanager.Text.Split('>')[0].Trim());
        Output.AssignParameter(sqlparm1, 16, "@app_hr_cb", "String", 50, txthrcb.Text.Split('>')[0].Trim());
        //   string sqlstr = @"insert into tbl_employee_approvers(empcode ,app_finance ,app_admin ,app_reportingmanager ,app_management ,app_hr ,app_businesshead ,app_hrd ,clr_department ,clr_generaladmin ,clr_accountsdept ,clr_networkdept ,clr_hr ,clr_useraccountdeletion ,create_date ,create_by  ,app_status ,status )";
        //   sqlstr += "values('" + empcode + "','" + txtfncmang.Text.ToString().Trim() + "','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"',getdate(),'" + Session["empcode"].ToString() + "','A',1)";
        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_intranet_insert_approvers_details", sqlparm1);
    }



    protected void btnapprover_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            BindApproverDetails(txtempcode.Text.ToString(), connection, transaction);
            transaction.Commit();
            string str = "<script> alert('Employee Approver Detail Saved successfully!!!')</script>";
            ScriptManager.RegisterStartupScript(upapprobver, upapprobver.GetType(), "xx", str, false);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }


    }
    #endregion



    protected void buthealth_Click(object sender, EventArgs e)
    {

    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/health_insurance/");
    }
    protected void chk_basic_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void chk_classic_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void chk_unique_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_individualplan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //SqlConnection Connection = null;
        //SqlTransaction _Transaction = null;
        //Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        //DataSet Flag = null;
        try
        {

            // StringBuilder userbuilt = new StringBuilder();
            SqlParameter[] newparameter = new SqlParameter[5];

            if (txtbasic.Checked)
            {
                newparameter[0] = new SqlParameter("@benefits", SqlDbType.VarChar, 50);
                newparameter[0].Value = "MTN CR BASIC".ToString();
                txtclassic.Visible = false;
                txtunique.Visible = false;
            }
            else if (txtclassic.Checked)
            {
                newparameter[0] = new SqlParameter("@benefits", SqlDbType.VarChar, 50);
                newparameter[0].Value = "MTN CR CLASSIC".ToString();
                txtbasic.Visible = false;
                txtunique.Visible = false;
            }
            else if (txtunique.Checked)
            {
                newparameter[0] = new SqlParameter("@benefits", SqlDbType.VarChar, 50);
                newparameter[0].Value = "MTN CR UNIQUE".ToString();
                txtclassic.Visible = false;
                txtbasic.Visible = false;
            }
            newparameter[1] = new SqlParameter("@individual", SqlDbType.Int);
            newparameter[1].Value = ddl_individual.SelectedItem.Text;

            newparameter[2] = new SqlParameter("@familyplanfour", SqlDbType.Int);
            newparameter[2].Value = ddl_familyfour.SelectedItem.Text;

            newparameter[3] = new SqlParameter("@familyplansix", SqlDbType.Int);
            newparameter[3].Value = ddl_familysix.SelectedItem.Text;

            newparameter[4] = new SqlParameter("@createdby", SqlDbType.VarChar,50);
            newparameter[4].Value = _userCode;


            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_health_insurance", newparameter);
            // return true;
        }
        catch (Exception ex)
        {
            //_Transaction.Rollback();
            Common.Console.Output.Log("During Apply Loan: " + ex.Message + ".    " + DateTime.Now);
            //Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
           // activity.CloseConnection();
            Output.Show("Health insurance is created sucessfully");
        }
    }
    protected void btn_view_Click(object sender, EventArgs e)
    {
        
    }

    protected void txtbasic_CheckedChanged(object sender, EventArgs e)
    {
        txtbasic.Visible = true;
        txtclassic.Visible = false;
        txtunique.Visible = false;
    }
    protected void txtclassic_CheckedChanged(object sender, EventArgs e)
    {
        txtclassic.Visible = true;
        txtbasic.Visible = false;
        txtunique.Visible = false;
    }
    protected void txtunique_CheckedChanged(object sender, EventArgs e)
    {
        txtunique.Visible = true;
        txtclassic.Visible = false;
        txtbasic.Visible = false;
    }


    protected void drpdepartment_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //bind_departmenttype(Convert.ToInt32(drpdepartment.SelectedValue));
        BindDesignation(drpdepartment.SelectedValue);
    }

    protected void drpdepartmenttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(drpdepartmenttype.SelectedValue));
        //bind_departmenttype(Convert.ToInt32(drpdepartment.SelectedValue));
    }
    protected void ddl_emp_type_SelectedIndexChanged(object sender, EventArgs e)
    {
       // bind_employeesubtype(Convert.ToInt32(ddl_emp_type.SelectedValue));
    }
   
    protected void ddl_semp_type_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    //protected void ddl_semp_type_DataBound(object sender, EventArgs e)
    //{
    //    ddl_semp_type.Items.Insert(0, new ListItem("---Select Employee Sub Type---", "0"));
    //}
    protected void ddl_emp_type_SelectedIndexChanged1(object sender, EventArgs e)
    {
        bind_employeesubtype(ddl_emp_type.SelectedValue);
    }


    protected void btnemgcontact_Click1(object sender, EventArgs e)
    {
        Emg_Conatct_grid();
        txt_emergency_name.Text = "";
        //txt_emg_ccode.Text = "";
        drp_emg_relation.SelectedValue = "0";
        txt_emergency_contactno.Text = "";
        txt_emg_landlinestdcode.Text = "";
        txt_emg_landlineno.Text = "";
        //txt_emg_landcode.Text = "";

    }
    private void Bind_IdType()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id, name from tbl_Internet_AddressProof order by id asc";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList13.DataSource = ds;
                DropDownList13.DataValueField = "id";
                DropDownList13.DataTextField = "name";
                DropDownList13.DataBind();

                DropDownList15.DataSource = ds;
                DropDownList15.DataValueField = "id";
                DropDownList15.DataTextField = "name";
                DropDownList15.DataBind();
            }
            DropDownList13.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList15.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    #region PhotoIdProof
    protected void Button2_Click(object sender, EventArgs e)
    {
        add_upload();
        DropDownList13.SelectedValue = "0";
        TextBox77.Text = "";
        //DropDownList14.SelectedIndex = -1;
        //RadioButton10.Checked = false;
        //RadioButton11.Checked = false;
    }

    protected void add_upload()
    {
        DataRow dr;
        if (Session["upload"] == null)
        {
            create_upload_table();
        }
        dtable = (DataTable)Session["upload"];


        dr = dtable.NewRow();
        string file = "";
        if (FileUpload2.HasFile)
        {
            file = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
            string File_Ext = System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName);
            try
            {
                FileUpload2.PostedFile.SaveAs(Server.MapPath("../upload/employeedocuments/" + file));

            }
            catch (Exception exc)
            {
            }
        }
        string ss = "";

        dr["ID_Type"] = DropDownList13.SelectedItem.Text;
        if (ot1.Visible == true)
        {
            dr["Others"] = TextBox77.Text;
        }
        else
        {
            dr["Others"] = "";
        }
        dr["Address_Type"] = ss;
        dr["File"] = file;
        dtable.Rows.Add(dr);
        //}
        Session["upload"] = dtable;
        BindList_PhotoUpload();
    }

    protected void BindList_PhotoUpload()
    {
        if (Session["upload"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["upload"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridView1.DataSource = dview;
        GridView1.DataBind();
    }

    protected void create_upload_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("ID_Type", typeof(string));
        dtable.Columns.Add(new DataColumn("Others", typeof(string)));
        dtable.Columns.Add(new DataColumn("Address_Type", typeof(string)));
        dtable.Columns.Add(new DataColumn("File", typeof(string)));

        Session["upload"] = dtable;
    }
    protected void GridPhotoUpload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["upload"];
        DataRow drfind_upload = dtable.Rows.Find(Convert.ToString(GridView1.DataKeys[e.RowIndex].Value));
        if (drfind_upload != null)
        {
            drfind_upload.Delete();
            Session["upload"] = dtable;
            BindList_PhotoUpload();
        }
    }
    protected void Insert_PhotoIDProof_detail(string emplyee_Code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["upload"] != null)
        {
            sqlstr = "delete from Emp_PhotoId_Doc where empcode ='" + emplyee_Code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["upload"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[5];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlParam[0].Value = emplyee_Code;

                sqlParam[1] = new SqlParameter("@id_type", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["ID_Type"].ToString();

                sqlParam[2] = new SqlParameter("@Others", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["Others"].ToString();

                //sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                //sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();

                sqlParam[3] = new SqlParameter("@Address_details", SqlDbType.VarChar, 100);
                sqlParam[3].Value = dtable.Rows[i]["Address_Type"].ToString();

                sqlParam[4] = new SqlParameter("@filename", SqlDbType.VarChar, 2000);
                sqlParam[4].Value = dtable.Rows[i]["File"].ToString();




                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_update_emp_Photoid_upload]", sqlParam);
            }
        }
    }
    #endregion

    #region Addressdoc Upload
    protected void Button3_Click(object sender, EventArgs e)
    {
        add_Address_upload();

        DropDownList15.SelectedIndex = -1;
        TextBox74.Text = "";
        //RadioButton10.Checked = false;
        //RadioButton11.Checked = false;
    }

    protected void add_Address_upload()
    {
        DataRow dr;
        if (Session["Address_upload"] == null)
        {
            create_Address_upload_table();
        }
        dtable = (DataTable)Session["Address_upload"];


        dr = dtable.NewRow();
        string file = "";
        if (FileUpload3.HasFile)
        {
            file = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
            string File_Ext = System.IO.Path.GetExtension(FileUpload3.PostedFile.FileName);

            try
            {
                FileUpload3.PostedFile.SaveAs(Server.MapPath("../upload/employeedocuments/" + file));

            }
            catch (Exception exc)
            {
            }
        }
        string ss = "";
        //if (RadioButton12.Checked)
        //{
        //    ss = "Current Residential Address";
        //}
        //if (RadioButton13.Checked)
        //{
        //    ss = "Current Permanent Address";
        //}

        dr["ID_Type"] = DropDownList15.SelectedItem.Text;
        if (ot2.Visible == true)
        {
            dr["Others"] = TextBox74.Text;
        }
        else
        {
            dr["Others"] = "";
        }
        dr["Address_Type"] = ss;
        dr["File"] = file;
        dtable.Rows.Add(dr);
        //}
        Session["Address_upload"] = dtable;
        BindList_Address_Upload();
    }

    protected void BindList_Address_Upload()
    {
        if (Session["Address_upload"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Address_upload"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridView2.DataSource = dview;
        GridView2.DataBind();
    }

    protected void create_Address_upload_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("ID_Type", typeof(string));
        dtable.Columns.Add(new DataColumn("Others", typeof(string)));
        dtable.Columns.Add(new DataColumn("Address_Type", typeof(string)));
        dtable.Columns.Add(new DataColumn("File", typeof(string)));

        Session["Address_upload"] = dtable;
    }
    protected void GridAddressUpload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Address_upload"];
        DataRow drfind_upload = dtable.Rows.Find(Convert.ToString(GridView2.DataKeys[e.RowIndex].Value));
        if (drfind_upload != null)
        {
            drfind_upload.Delete();
            Session["Address_upload"] = dtable;
            BindList_Address_Upload();
        }
    }
    protected void Insert_Addressdoc_detail(string emplyee_Code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["Address_upload"] != null)
        {
            sqlstr = "delete from Emp_Address_Doc where empcode ='" + emplyee_Code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["Address_upload"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[5];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlParam[0].Value = emplyee_Code;

                sqlParam[1] = new SqlParameter("@id_type", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["ID_Type"].ToString();

                sqlParam[2] = new SqlParameter("@Others", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["Others"].ToString();

                //sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                //sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();

                sqlParam[3] = new SqlParameter("@Address_details", SqlDbType.VarChar, 100);
                sqlParam[3].Value = dtable.Rows[i]["Address_Type"].ToString();

                sqlParam[4] = new SqlParameter("@filename", SqlDbType.VarChar, 2000);
                sqlParam[4].Value = dtable.Rows[i]["File"].ToString();




                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_update_emp_Address_upload]", sqlParam);
            }
        }
    }
    #endregion

    #region Otherdocumentupload
    protected void Button4_Click(object sender, EventArgs e)
    {
        add_Other_upload();


        TextBox73.Text = "";

    }

    protected void add_Other_upload()
    {
        DataRow dr;
        if (Session["Other_upload"] == null)
        {
            create_Otherdoc_upload_table();
        }
        dtable = (DataTable)Session["Other_upload"];

        ////DataRow drfind = dtable.Rows.Find(txt_TrProgram.Text);
        //if (drfind != null)
        //{
        //}
        //else
        //{
        dr = dtable.NewRow();
        string file = "";
        if (FileUpload4.HasFile)
        {
            file = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
            string File_Ext = System.IO.Path.GetExtension(FileUpload4.PostedFile.FileName);


            try
            {
                FileUpload4.PostedFile.SaveAs(Server.MapPath("../upload/employeedocuments/" + file));

            }
            catch (Exception exc)
            {
            }

        }



        dr["Others"] = TextBox73.Text;
        dr["File"] = file;
        dtable.Rows.Add(dr);
        //}
        Session["Other_upload"] = dtable;
        BindList_Otherdoc_Upload();
    }

    protected void BindList_Otherdoc_Upload()
    {
        if (Session["Other_upload"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Other_upload"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridView3.DataSource = dview;
        GridView3.DataBind();
    }

    protected void create_Otherdoc_upload_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("Others", typeof(string));
        dtable.Columns.Add(new DataColumn("File", typeof(string)));

        Session["Other_upload"] = dtable;
    }
    protected void GridOtherDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Other_upload"];
        DataRow drfind_upload = dtable.Rows.Find(Convert.ToString(GridView3.DataKeys[e.RowIndex].Value));
        if (drfind_upload != null)
        {
            drfind_upload.Delete();
            Session["Other_upload"] = dtable;
            BindList_Otherdoc_Upload();
        }
    }
    protected void Insert_otherdoc_detail(string emplyee_Code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["Other_upload"] != null)
        {
            sqlstr = "delete from Emp_Other_Doc where empcode ='" + emplyee_Code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["Other_upload"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[3];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlParam[0].Value = emplyee_Code;

                sqlParam[1] = new SqlParameter("@Docname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["Others"].ToString();

                sqlParam[2] = new SqlParameter("@filename", SqlDbType.VarChar, 2000);
                sqlParam[2].Value = dtable.Rows[i]["File"].ToString();

                //sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                //sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();






                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_update_emp_otherdoc_upload]", sqlParam);
            }
        }
    }
    #endregion

    protected void DropDownList15_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList13_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
