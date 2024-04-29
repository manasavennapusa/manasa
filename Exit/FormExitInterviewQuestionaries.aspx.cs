using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Configuration;
using Common.Data;
using System.Data.SqlClient;

public partial class Exit_FormExitInterviewQuestionaries : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string PageId = "Exit Approvers";
    int ApplicationId = 6;
    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitEmployeeRule EmpRule = null;
    ExitCompanyRule CompanyRule = null;
    DateTime starttime;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ABC"] != null)
        {
            string Empcode = Request.QueryString["Empcode"].ToString();
            BindInitialData(Empcode);
        }
        else if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
            Id = Request.QueryString["Id"].ToString().Trim();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            ViewState["time"] = System.DateTime.Now;

            if (!IsPostBack)
            {
                BindClearence();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }


        starttime = Convert.ToDateTime(ViewState["time"]);

    }

    private void BindClearence()
    {
        try
        {
            Lib = new Base();
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = @"select * from tbl_exit_interviewquestion where ExitId = '" + Id + "' and Status = 1 ";
                DataSet ds = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query);
                DataRow row = ds.Tables[0].Rows[0];


                if (row["Position"].ToString() == "1")
                    Relocation1.Checked = true;
                if (row["Home"].ToString() == "1")
                    HigherEducation1.Checked = true;
                if (row["Health"].ToString() == "1")
                    JobProfile1.Checked = true;
                if (row["Relocation"].ToString() == "1")
                    CompanyPolicy1.Checked = true;
                if (row["Travel"].ToString() == "1")
                    Compensation1.Checked = true;
                if (row["Education"].ToString() == "1")
                    Benifits1.Checked = true;
                if (row["Dissatisfaction"].ToString() == "1")
                    Supervisor1.Checked = true;
                if (row["Dis_work"].ToString() == "1")
                    LackofCareerProgression1.Checked = true;
                if (row["Dis_Supervisor"].ToString() == "1")
                    CompanyManagement1.Checked = true;
                if (row["Dis_co"].ToString() == "1")
                    HealthMedicalReason1.Checked = true;
                if (row["Dis_work_condition"].ToString() == "1")
                    Personal1.Checked = true;
                if (row["Dis_benifits"].ToString() == "1")
                    Retirement1.Checked = true;
                if (row["Laid_off"].ToString() == "1")
                    Relocation2.Checked = true;
                if (row["Lack_of_work"].ToString() == "1")
                    HigherEducation2.Checked = true;
                if (row["Abolition"].ToString() == "1")
                    JobProfile2.Checked = true;
                if (row["Funds"].ToString() == "1")
                    CompanyPolicy2.Checked = true;
                if (row["Termination"].ToString() == "1")
                    Compensation2.Checked = true;
                //else if (row["ReasonResponsible1"].ToString() == "M")
                //    VeryLongHoursofWorking1.Checked = true;
                //else if (row["ReasonResponsible1"].ToString() == "N")
                //    Commute1.Checked = true;
                //else if (row["ReasonResponsible1"].ToString() == "O")
                //    AnotherJobOffer1.Checked = true;
                //else if (row["ReasonResponsible1"].ToString() == "P")
                //    BetterDesignation1.Checked = true;
                //else if (row["ReasonResponsible1"].ToString() == "Q")
                //    Marriage1.Checked = true;
                //txtOverAll4.Text = row[""].ToString();
                //txtOverAll5.Text = row[""].ToString();
                //Other1.Value = row["ReasonResponsible1Others"].ToString();
                //Pleaseelaboratetheabovepoint1.Text = row["ReasonResponsible1Elaborate"].ToString();


                //if (row["ReasonResponsible2"].ToString() == "A")
                //    Relocation2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "B")
                //    HigherEducation2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "C")
                //    JobProfile2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "D")
                //    CompanyPolicy2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "E")
                //    Compensation2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "F")
                //    Benifits2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "G")
                //    Supervisor2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "H")
                //    LackofCareerProgression2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "I")
                //    CompanyManagement2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "J")
                //    HealthMedicalReason2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "K")
                //    Personal2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "L")
                //    Retirement2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "M")
                //    VeryLongHoursofWorking2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "N")
                //    Commute2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "O")
                //    AnotherJobOffer2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "P")
                //    BetterDesignation2.Checked = true;
                //else if (row["ReasonResponsible2"].ToString() == "Q")
                //    Marriage2.Checked = true;

                //Other2.Value = row["ReasonResponsible2Others"].ToString();
                Pleaseelaboratetheabovepoint2.Text = row["ReasonResponsible2Elaborate"].ToString();
                txt_like.Text = row["Like_job"].ToString();
                txt_least.Text = row["Least"].ToString();
                txt_pay.Text = row["Pay"].ToString();
                txt_ff.Text = row["FandF"].ToString();
                txt_stsalary.Text = row["starting_sal"].ToString();
                txt_endsalary.Text = row["ending_sal"].ToString();
                txt_phone.Text = row["phoneno"].ToString();
                txt_mail.Text = row["email"].ToString();
                txtOverAll2.Text = row["perAdd"].ToString();
                txtOverAll3.Text = row["preAdd"].ToString();
                txtOverAll4.Text = row["city"].ToString();
                txtOverAll5.Text = row["zipcode"].ToString();
                txtOverAll6.Text = row["father"].ToString();
                txtOverAll7.Text = row["mother"].ToString();
                txtOverAll8.Text = row["Hb_wife"].ToString();
                txtOverAll9.Text = row["reference"].ToString();

                if (row["Rate1"].ToString().Trim() == "E")
                    Rate1e.Checked = true;
                else if (row["Rate1"].ToString().Trim() == "G")
                    Rate1g.Checked = true;
                else if (row["Rate1"].ToString().Trim() == "F")
                    Rate1f.Checked = true;
                //else if (row["Rate1"].ToString().Trim() == "P")
                //    Rate1p.Checked = true;


                if (row["Rate2"].ToString().Trim() == "E")
                    Rate2e.Checked = true;
                else if (row["Rate2"].ToString().Trim() == "G")
                    Rate2g.Checked = true;
                else if (row["Rate2"].ToString().Trim() == "F")
                    Rate2f.Checked = true;
                //else if (row["Rate2"].ToString().Trim() == "P")
                //    Rate2p.Checked = true;

                if (row["Rate3"].ToString().Trim() == "E")
                    Rate3e.Checked = true;
                else if (row["Rate3"].ToString().Trim() == "G")
                    Rate3g.Checked = true;
                else if (row["Rate3"].ToString().Trim() == "F")
                    Rate3f.Checked = true;
                //else if (row["Rate3"].ToString().Trim() == "P")
                //    Rate3p.Checked = true;

                if (row["Rate4"].ToString().Trim() == "E")
                    Rate4e.Checked = true;
                else if (row["Rate4"].ToString().Trim() == "G")
                    Rate4g.Checked = true;
                else if (row["Rate4"].ToString().Trim() == "F")
                    Rate4f.Checked = true;
                //else if (row["Rate4"].ToString().Trim() == "P")
                //    Rate4p.Checked = true;

                if (row["Rate5"].ToString().Trim() == "E")
                    Rate5e.Checked = true;
                else if (row["Rate5"].ToString().Trim() == "G")
                    Rate5g.Checked = true;
                else if (row["Rate5"].ToString().Trim() == "F")
                    Rate5f.Checked = true;
                //else if (row["Rate5"].ToString().Trim() == "P")
                //    Rate5p.Checked = true;

                if (row["Rate6"].ToString().Trim() == "E")
                    Rate6e.Checked = true;
                else if (row["Rate6"].ToString().Trim() == "G")
                    Rate6g.Checked = true;
                else if (row["Rate6"].ToString().Trim() == "F")
                    Rate6f.Checked = true;
                //else if (row["Rate6"].ToString().Trim() == "P")
                //    Rate6p.Checked = true;

                if (row["Rate7"].ToString().Trim() == "E")
                    Rate7e.Checked = true;
                else if (row["Rate7"].ToString().Trim() == "G")
                    Rate7g.Checked = true;
                else if (row["Rate7"].ToString().Trim() == "F")
                    Rate7f.Checked = true;
                //else if (row["Rate7"].ToString().Trim() == "P")
                //    Rate7p.Checked = true;


                if (row["Rate8"].ToString().Trim() == "E")
                    Rate8e.Checked = true;
                else if (row["Rate8"].ToString().Trim() == "G")
                    Rate8g.Checked = true;
                else if (row["Rate8"].ToString().Trim() == "F")
                    Rate8f.Checked = true;
                //else if (row["Rate8"].ToString().Trim() == "P")
                //    Rate8p.Checked = true;


                //if (row["Rate9"].ToString().Trim() == "E")
                //    Rate9e.Checked = true;
                //else if (row["Rate9"].ToString().Trim() == "G")
                //    Rate9g.Checked = true;
                //else if (row["Rate9"].ToString().Trim() == "F")
                //    Rate9f.Checked = true;
                //else if (row["Rate9"].ToString().Trim() == "P")
                //    Rate9p.Checked = true;

                //if (row["Rate10"].ToString().Trim() == "E")
                //    Rate10e.Checked = true;
                //else if (row["Rate10"].ToString().Trim() == "G")
                //    Rate10g.Checked = true;
                //else if (row["Rate10"].ToString().Trim() == "F")
                //    Rate10f.Checked = true;
                //else if (row["Rate10"].ToString().Trim() == "P")
                //    Rate10p.Checked = true;

                //if (row["Rate11"].ToString().Trim() == "E")
                //    Rate11e.Checked = true;
                //else if (row["Rate11"].ToString().Trim() == "G")
                //    Rate11g.Checked = true;
                //else if (row["Rate11"].ToString().Trim() == "F")
                //    Rate11f.Checked = true;
                //else if (row["Rate11"].ToString().Trim() == "P")
                //    Rate11p.Checked = true;

                //if (row["Rate12"].ToString().Trim() == "E")
                //    Rate12e.Checked = true;
                //else if (row["Rate12"].ToString().Trim() == "G")
                //    Rate12g.Checked = true;
                //else if (row["Rate12"].ToString().Trim() == "F")
                //    Rate12f.Checked = true;
                //else if (row["Rate12"].ToString().Trim() == "P")
                //    Rate12p.Checked = true;


                //if (row["Rate13"].ToString().Trim() == "E")
                //    Rate13e.Checked = true;
                //else if (row["Rate13"].ToString().Trim() == "G")
                //    Rate13g.Checked = true;
                //else if (row["Rate13"].ToString().Trim() == "F")
                //    Rate13f.Checked = true;
                //else if (row["Rate13"].ToString().Trim() == "P")
                //    Rate13p.Checked = true;

                //txtRateComments.Text = row["RateComments"].ToString();
                //txtOverAll2.Text = row["OverAll2"].ToString().Trim();
                //txtOverAll3.Text = row["OverAll3"].ToString().Trim();
                //txtOverAll4.Text = row["OverAll4"].ToString().Trim();
                //txtOverAll5.Text = row["OverAll5"].ToString().Trim();
                //if (row["OverAll6YesNo"].ToString().Trim() == "Y")
                //{
                //    OverAllYes.Checked = true;
                //    //  txtOverAll6.Visible = true;
                //}
                //else if (row["OverAll6YesNo"].ToString().Trim() == "N")
                //{
                //    OverAllNo.Checked = true;
                //    // txtOverAll6.Visible = false;
                //}
                txtOverAll1.Text = row["OverAll1"].ToString().Trim();
                //txtOverAll7.Text = row["OverAll7"].ToString().Trim();
                //txtOverAll8.Text = row["OverAll8"].ToString().Trim();
                //txtOverAll9.Text = row["OverAll9"].ToString().Trim();

                if (row["CurrentDateTime"].ToString() != "")
                    DateOfClearence.Text = Convert.ToDateTime(row["CurrentDateTime"].ToString()).ToString("dd-MMM-yyyy");
                else
                    DateOfClearence.Text = "";

                string str = @"select emp.Id,convert(varchar(20),job.emp_doj,106) as emp_doj,job.official_mob_no,job.official_email_id,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,
dept.department_name,convert(varchar(20),resg.AppliedDate,106) as applieddate,
CONVERT(varchar(20),resg.DefaultLWD,106) as lastdate,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join tbl_internate_departmentdetails dept on dept.departmentid=job.dept_id
left join tbl_exit_Resignation resg on resg.EmpCode=job.empcode
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId where job.empcode='" + UserCode + "' and resg.ResignStatus !='J' ";
                DataSet ds1 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, str);
                DataRow row3 = ds1.Tables[0].Rows[0];

                string strt = @"select top(1) emp.Id,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId
where job.empcode='" + UserCode + "' order by emp.Id desc";
                DataSet ds4 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, strt);
                DataRow row4 = ds4.Tables[0].Rows[0];

                txt_hire.Text = row3["emp_doj"].ToString();
                txt_name.Text = row3["EmpName"].ToString();
                txt_dept.Text = row3["department_name"].ToString();
                txt_hire.Text = row3["emp_doj"].ToString();
                txt_lastdate.Text = row3["lastdate"].ToString();
                txt_date.Text = row3["applieddate"].ToString();
                txt_stposition.Text = row3["designationname"].ToString();
                txt_endposition.Text = row4["designationname"].ToString();

            }
            else
            {
                string str = @"select top(1)  emp.Id,convert(varchar(20),job.emp_doj,106) as emp_doj,job.official_mob_no,job.official_email_id,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,
dept.department_name,convert(varchar(20),resg.AppliedDate,106) as applieddate,
CONVERT(varchar(20),resg.DefaultLWD,106) as lastdate,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join tbl_internate_departmentdetails dept on dept.departmentid=job.dept_id
left join tbl_exit_Resignation resg on resg.EmpCode=job.empcode
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId where job.empcode='" + UserCode + "' and resg.ResignStatus !='J'";
                DataSet ds1 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, str);

                string str1 = @"select pre_add1,per_add1 from dbo.tbl_intranet_employee_contactlist where empcode='" + UserCode + "'";
                DataSet ds2 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, str1);

                string str2 = @" select f_fname,m_fname,s_fname from dbo.tbl_intranet_employee_personalDetails where empcode='" + UserCode + "'";
                DataSet ds3 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, str2);

                string strt = @"select top(1) emp.Id,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId
where job.empcode='" + UserCode + "' order by emp.Id desc";
                DataSet ds4 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, strt);
                DataRow row4 = ds4.Tables[0].Rows[0];

                DataRow row3 = ds1.Tables[0].Rows[0];
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    txt_phone.Text = row3["official_mob_no"].ToString();
                    txt_mail.Text = row3["official_email_id"].ToString();



                }
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    DataRow row1 = ds2.Tables[0].Rows[0];
                    txtOverAll2.Text = row1["per_add1"].ToString();
                    txtOverAll3.Text = row1["pre_add1"].ToString();
                }
                else
                {
                    txtOverAll2.Text = "";
                    txtOverAll3.Text = "";
                }
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    DataRow row2 = ds3.Tables[0].Rows[0];
                    txtOverAll6.Text = row2["f_fname"].ToString();
                    txtOverAll7.Text = row2["m_fname"].ToString();
                    txtOverAll8.Text = row2["s_fname"].ToString();
                }

                txt_hire.Text = row3["emp_doj"].ToString();
                txt_name.Text = row3["EmpName"].ToString();
                txt_dept.Text = row3["department_name"].ToString();
                txt_hire.Text = row3["emp_doj"].ToString();
                txt_lastdate.Text = row3["lastdate"].ToString();
                txt_date.Text = row3["applieddate"].ToString();
                txt_stposition.Text = row3["designationname"].ToString();
                txt_endposition.Text = row4["designationname"].ToString();
            }
        }
        catch (Exception ex)
        {
            Lib.Bee.RollBack();
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Lib.Bee.CloseConnection();
        }
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {

        string Position = "";
        string Home = "";
        string Health = "";
        string Relocation = "";
        string Travel = "";
        string Education = "";
        string Dissatisfaction = "";
        string Dis_work = "";
        string Dis_Supervisor = "";
        string Dis_co = "";
        string Dis_work_condition = "";
        string Dis_benifits = "";
        string Laid_off = "";
        string Lack_of_work = "";
        string Abolition = "";
        string Funds = "";
        string Termination = "";
        string StartSalary = "";
        string EndSalary = "";
        string phone = "";
        string mail = "";
        string peradd = "";
        string preadd = "";
        string city = "";
        string zipcode = "";
        string father = "";
        string mother = "";
        string hb_wife = "";
        string reference = "";
        //string ReasonResponsible1Others;
        string ReasonResponsible1Elaborate;

        string Like_job = "";
        string Least = "";
        string Pay = "";
        string ReasonResponsible2Elaborate;
        string fandf = "";

        string Rate1 = "";
        string Rate2 = "";
        string Rate3 = "";
        string Rate4 = "";
        string Rate5 = "";
        string Rate6 = "";
        string Rate7 = "";
        string Rate8 = "";
        string Rate9 = "";
        string Rate10 = "";
        string Rate11 = "";
        string Rate12 = "";
        string Rate13 = "";

        string RateComments = "";

        string OverAll1 = "";
        string OverAll2 = "";
        string OverAll3 = "";
        string OverAll4 = "";
        string OverAll5 = "";
        string OverAll6YesNo = "";
        string OverAll6 = "";
        string OverAll7 = "";
        string OverAll8 = "";
        string OverAll9 = "";
        string CurrentDateTime = null;

        int Flag = 0;
        Lib = new Base();

        if (Relocation1.Checked)
        {
            Position = "1";
        }
        else
        {
            Position = "0";
        }
        if (HigherEducation1.Checked)
        {
            Home = "1";
        }
        else
        {
            Home = "0";
        }

        if (JobProfile1.Checked)
        {
            Health = "1";
        }
        else
        {
            Health = "0";
        }


        if (CompanyPolicy1.Checked)
        {
            Relocation = "1";
        }
        else
        {
            Relocation = "0";
        }


        if (Compensation1.Checked)
        {
            Travel = "1";
        }
        else
        {
            Travel = "0";
        }


        if (Benifits1.Checked)
        {
            Education = "1";
        }
        else
        {
            Education = "0";
        }

        if (Supervisor1.Checked)
        {
            Dissatisfaction = "1";
        }
        else
        {
            Dissatisfaction = "0";
        }

        if (LackofCareerProgression1.Checked)
        {
            Dis_work = "1";
        }
        else
        {
            Dis_work = "0";
        }

        if (CompanyManagement1.Checked)
        {
            Dis_Supervisor = "1";
        }
        else
        {
            Dis_Supervisor = "0";
        }

        if (HealthMedicalReason1.Checked)
        {
            Dis_co = "1";
        }
        else
        {
            Dis_co = "0";
        }

        if (Personal1.Checked)
        {
            Dis_work_condition = "1";
        }
        else
        {
            Dis_work_condition = "0";
        }

        if (Retirement1.Checked)
        {
            Dis_benifits = "1";
        }
        else
        {
            Dis_benifits = "0";
        }

        //else if (VeryLongHoursofWorking1.Checked == true)
        //    ReasonResponsible1 = "M";
        //else if (Commute1.Checked == true)
        //    ReasonResponsible1 = "N";
        //else if (AnotherJobOffer1.Checked == true)
        //    ReasonResponsible1 = "O";
        //else if (BetterDesignation1.Checked == true)
        //    ReasonResponsible1 = "P";
        //else if (Marriage1.Checked == true)
        //    ReasonResponsible1 = "Q";

        //ReasonResponsible1Others = Other1.Value.Trim();
        ReasonResponsible1Elaborate = Pleaseelaboratetheabovepoint2.Text.Trim();
        Pay = txt_pay.Text.Trim();
        Like_job = txt_like.Text.Trim();
        Least = txt_least.Text.Trim();
        fandf = txt_ff.Text.Trim();
        StartSalary = txt_stsalary.Text.Trim();
        EndSalary = txt_endsalary.Text.Trim();
        phone = txt_phone.Text.Trim();
        mail = txt_mail.Text.Trim();
        peradd = txtOverAll2.Text.Trim();
        preadd = txtOverAll3.Text.Trim();
        city = txtOverAll4.Text.Trim();
        zipcode = txtOverAll5.Text.Trim();
        father = txtOverAll6.Text.Trim();
        mother = txtOverAll7.Text.Trim();
        hb_wife = txtOverAll8.Text.Trim();
        reference = txtOverAll9.Text.Trim();

        if (Relocation2.Checked)
        {
            Laid_off = "1";
        }
        else
        {
            Laid_off = "0";
        }

        if (HigherEducation2.Checked)
        {
            Lack_of_work = "1";
        }
        else
        {
            Lack_of_work = "0";
        }

        if (JobProfile2.Checked)
        {
            Abolition = "1";
        }
        else
        {
            Abolition = "0";
        }

        if (CompanyPolicy2.Checked)
        {
            Funds = "1";
        }
        else
        {
            Funds = "0";
        }

        if (Compensation2.Checked)
        {
            Termination = "1";
        }
        else
        {
            Termination = "0";
        }

        //else if (Benifits2.Checked == true)
        //    ReasonResponsible2 = "F";
        //else if (Supervisor2.Checked == true)
        //    ReasonResponsible2 = "G";
        //else if (LackofCareerProgression2.Checked == true)
        //    ReasonResponsible2 = "H";
        //else if (CompanyManagement2.Checked == true)
        //    ReasonResponsible2 = "I";
        //else if (HealthMedicalReason2.Checked == true)
        //    ReasonResponsible2 = "J";
        //else if (Personal2.Checked == true)
        //    ReasonResponsible2 = "K";
        //else if (Retirement2.Checked == true)
        //    ReasonResponsible2 = "L";
        //else if (VeryLongHoursofWorking2.Checked == true)
        //    ReasonResponsible2 = "M";
        //else if (Commute2.Checked == true)
        //    ReasonResponsible2 = "N";
        //else if (AnotherJobOffer2.Checked == true)
        //    ReasonResponsible2 = "O";
        //else if (BetterDesignation2.Checked == true)
        //    ReasonResponsible2 = "P";
        //else if (Marriage2.Checked == true)
        //    ReasonResponsible2 = "Q";

        //ReasonResponsible2Others = Other2.Value.Trim();
        ReasonResponsible2Elaborate = Pleaseelaboratetheabovepoint2.Text.Trim();


        if (Rate1e.Checked)
        {
            Rate1 = "E";
        }
        else if (Rate1g.Checked)
        {
            Rate1 = "G";
        }
        else if (Rate1f.Checked)
        {
            Rate1 = "F";
        }
        else
        {
            Rate1 = "";
        }

        if (Rate2e.Checked)
        {
            Rate2 = "E";
        }
        else if (Rate2g.Checked)
        {
            Rate2 = "G";
        }
        else if (Rate2f.Checked)
        {
            Rate2 = "F";
        }
        else
        {
            Rate2 = "";
        }

        if (Rate3e.Checked == true)
        {
            Rate3 = "E";
        }
        else if (Rate3g.Checked)
        {
            Rate3 = "G";
        }
        else if (Rate3f.Checked)
        {
            Rate3 = "F";
        }
        else
        {
            Rate3 = "";
        }
        if (Rate4e.Checked)
        {
            Rate4 = "E";
        }
        else if (Rate4g.Checked)
        {
            Rate4 = "G";
        }
        else if (Rate4f.Checked)
        {
            Rate4 = "F";
        }
        else
        {
            Rate4 = "";
        }

        //if (Rate4p.Checked == true)
        //    Rate4 = "P";

        if (Rate5e.Checked)
        {
            Rate5 = "E";
        }
        else if (Rate5g.Checked)
        {
            Rate5 = "G";
        }
        else if (Rate5f.Checked)
        {
            Rate5 = "F";
        }
        else
        {
            Rate5 = "";
        }

        //if (Rate5p.Checked == true)
        //    Rate5 = "P";

        if (Rate6e.Checked)
        {
            Rate6 = "E";
        }
        else if (Rate6g.Checked)
        {
            Rate6 = "G";
        }
        else if (Rate6f.Checked)
        {
            Rate6 = "F";
        }
        else
        {
            Rate6 = "";
        }

        //if (Rate6p.Checked == true)
        //    Rate6 = "P";

        if (Rate7e.Checked)
        {
            Rate7 = "E";
        }
        else if (Rate7g.Checked)
        {
            Rate7 = "G";
        }
        else if (Rate7f.Checked)
        {
            Rate7 = "F";
        }
        else
        {
            Rate7 = "";
        }

        //if (Rate7p.Checked == true)
        //    Rate7 = "P";

        if (Rate8e.Checked)
        {
            Rate8 = "E";
        }
        else if (Rate8g.Checked)
        {
            Rate8 = "G";
        }
        else if (Rate8f.Checked)
        {
            Rate8 = "F";
        }
        else
        {
            Rate8 = "";
        }

        //if (Rate8p.Checked == true)
        //    Rate8 = "P";

        //if (Rate9e.Checked == true)
        //    Rate9 = "E";
        //if (Rate9g.Checked == true)
        //    Rate9 = "G";
        //if (Rate9f.Checked == true)
        //    Rate9 = "F";
        //if (Rate9p.Checked == true)
        //    Rate9 = "P";

        //if (Rate10e.Checked == true)
        //    Rate10 = "E";
        //if (Rate10g.Checked == true)
        //    Rate10 = "G";
        //if (Rate10f.Checked == true)
        //    Rate10 = "F";
        //if (Rate10p.Checked == true)
        //    Rate10 = "P";

        //if (Rate11e.Checked == true)
        //    Rate11 = "E";
        //if (Rate11g.Checked == true)
        //    Rate11 = "G";
        //if (Rate11f.Checked == true)
        //    Rate11 = "F";
        //if (Rate11p.Checked == true)
        //    Rate11 = "P";

        //if (Rate12e.Checked == true)
        //    Rate12 = "E";
        //if (Rate12g.Checked == true)
        //    Rate12 = "G";
        //if (Rate12f.Checked == true)
        //    Rate12 = "F";
        //if (Rate12p.Checked == true)
        //    Rate12 = "P";

        //if (Rate13e.Checked == true)
        //    Rate13 = "E";
        //if (Rate13g.Checked == true)
        //    Rate13 = "G";
        //if (Rate13f.Checked == true)
        //    Rate13 = "F";
        //if (Rate13p.Checked == true)
        //    Rate13 = "P";

        //RateComments = txtRateComments.Text.Trim();

        OverAll1 = txtOverAll1.Text.Trim();
        OverAll2 = txtOverAll2.Text.Trim();
        OverAll3 = txtOverAll3.Text.Trim();
        OverAll4 = txtOverAll4.Text.Trim();
        OverAll5 = txtOverAll5.Text.Trim();
        //if (OverAllYes.Checked == true)
        //    OverAll6YesNo = "Y";
        //else
        //    OverAll6YesNo = "N";
        OverAll6 = txtOverAll6.Text.Trim();
        OverAll7 = txtOverAll7.Text.Trim();
        OverAll8 = txtOverAll8.Text.Trim();
        OverAll9 = txtOverAll9.Text.Trim();
        fandf = txt_ff.Text.Trim();
        CurrentDateTime = DateOfClearence.Text.Trim();

        try
        {
            connection = activity.OpenConnection();
            Query = "select * from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
            if (ds.Tables[0].Rows.Count > 0)
            {

                Query = "select * from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1 and ApproverStatus in ('A','C')";
                DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);

                if (ds_1.Tables[0].Rows.Count < 1)
                {

                    Query = "update tbl_exit_interviewquestion set Status = 0 where ExitId = " + Id + " and ApproverStatus = 'S'";
                 
                     Flag= DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);

                    if (Flag > 0)
                    {
                        Flag = 0;
                        if (DateOfClearence.Text != "")
                            Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,OverAll1,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + OverAll1 + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','S','" + UserCode + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','1','" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";
                        else
                            Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,OverAll1,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + OverAll1 + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','S','" + UserCode + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','1','" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";

                        Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);

                        if (Flag > 0)
                        {
                            Output.Show("Saved Successfully");
                        }
                        else
                        {
                            Output.Show("Record not saved.");
                        }

                    }
                    else
                    {
                        Output.Show("Record not saved. Only saved application will be able to modify.");
                    }
                }
                else
                {
                    Output.Show("Sorry! not able to save the record. Due to record is already approved/cancelled.");
                }
            }
            else
            {
                if (DateOfClearence.Text != "")
                {
                    Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,OverAll1,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + OverAll1 + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','S','" + UserCode + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','1','" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";
                }
                else
                {
                    Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,OverAll1,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + OverAll1 + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','S','" + UserCode + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','1','" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";
                }
                Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                if (Flag > 0)
                {
                   
                    Output.Show("Saved Successfully");
                }
                else
                {
                   
                    Output.Show("Record not saved.");
                }
            }

        }
        catch (Exception ex)
        {
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
           activity.CloseConnection();
        }

    }


    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string Position = "";
        string Home = "";
        string Health = "";
        string Relocation = "";
        string Travel = "";
        string Education = "";
        string Dissatisfaction = "";
        string Dis_work = "";
        string Dis_Supervisor = "";
        string Dis_co = "";
        string Dis_work_condition = "";
        string Dis_benifits = "";
        string Laid_off = "";
        string Lack_of_work = "";
        string Abolition = "";
        string Funds = "";
        string Termination = "";
        string StartSalary = "";
        string EndSalary = "";
        string phone = "";
        string mail = "";
        string peradd = "";
        string preadd = "";
        string city = "";
        string zipcode = "";
        string father = "";
        string mother = "";
        string hb_wife = "";
        string reference = "";
        string ReasonResponsible2Elaborate;
        string Like_job = "";
        string Least = "";
        string Pay = "";
        
        string fandf = "";

        string Rate1 = "";
        string Rate2 = "";
        string Rate3 = "";
        string Rate4 = "";
        string Rate5 = "";
        string Rate6 = "";
        string Rate7 = "";
        string Rate8 = "";
        string OverAll1 = "";
        string OverAll2 = "";
        string OverAll3 = "";
        string OverAll4 = "";
        string OverAll5 = "";

        string OverAll6 = "";
        string OverAll7 = "";
        string OverAll8 = "";
        string OverAll9 = "";

        string CurrentDateTime = null;

        int Flag = 0;
        bool BFlag = false;

        //Lib = new Base();

        if (Relocation1.Checked)
        {
            Position = "1";
        }
        else
        {
            Position = "0";
        }

        if (HigherEducation1.Checked)
        {
            Home = "1";
        }
        else
        {
            Home = "0";
        }

        if (JobProfile1.Checked)
        {
            Health = "1";
        }
        else
        {
            Health = "0";
        }

        if (CompanyPolicy1.Checked)
        {
            Relocation = "1";
        }
        else
        {
            Relocation = "0";
        }

        if (Compensation1.Checked)
        {
            Travel = "1";
        }
        else
        {
            Travel = "0";
        }

        if (Benifits1.Checked)
        {
            Education = "1";
        }
        else
        {
            Education = "0";
        }

        if (Supervisor1.Checked)
        {
            Dissatisfaction = "1";
        }
        else
        {
            Dissatisfaction = "0";
        }

        if (LackofCareerProgression1.Checked)
        {
            Dis_work = "1";
        }
        else
        {
            Dis_work = "0";
        }

        if (CompanyManagement1.Checked)
        {
            Dis_Supervisor = "1";
        }
        else
        {
            Dis_Supervisor = "0";
        }

        if (HealthMedicalReason1.Checked)
        {
            Dis_co = "1";
        }
        else
        {
            Dis_co = "0";
        }

        if (Personal1.Checked)
        {
            Dis_work_condition = "1";
        }
        else
        {
            Dis_work_condition = "0";
        }

        if (Retirement1.Checked)
        {
            Dis_benifits = "1";
        }
        else
        {
            Dis_benifits = "0";
        }

        if (Relocation2.Checked)
        {
            Laid_off = "1";
        }
        else
        {
            Laid_off = "0";
        }

        if (HigherEducation2.Checked)
        {
            Lack_of_work = "1";
        }
        else
        {
            Lack_of_work = "0";
        }

        if (JobProfile2.Checked)
        {
            Abolition = "1";
        }
        else
        {
            Abolition = "0";
        }

        if (CompanyPolicy2.Checked)
        {
            Funds = "1";
        }
        else
        {
            Funds = "0";
        }

        if (Compensation2.Checked)
        {
            Termination = "1";
        }
        else
        {
            Termination = "0";
        }

      
        ReasonResponsible2Elaborate = Pleaseelaboratetheabovepoint2.Text.Trim();
        Pay = txt_pay.Text.Trim();
        Like_job = txt_like.Text.Trim();
        Least = txt_least.Text.Trim();
        fandf = txt_ff.Text.Trim();
        StartSalary = txt_stsalary.Text.Trim();
        EndSalary = txt_endsalary.Text.Trim();
        phone = txt_phone.Text.Trim();
        mail = txt_mail.Text.Trim();
        peradd = txtOverAll2.Text.Trim();
        preadd = txtOverAll3.Text.Trim();
        city = txtOverAll4.Text.Trim();
        zipcode = txtOverAll5.Text.Trim();
        father = txtOverAll6.Text.Trim();
        mother = txtOverAll7.Text.Trim();
        hb_wife = txtOverAll8.Text.Trim();
        reference = txtOverAll9.Text.Trim();


        if (Rate1e.Checked)
        {
            Rate1 = "E";
        }
        else if (Rate1g.Checked)
        {
            Rate1 = "G";
        }
        else if (Rate1f.Checked)
        {
            Rate1 = "F";
        }
        else
        {
            Rate1 = "";
        }

        if (Rate2e.Checked)
        {
            Rate2 = "E";
        }
        else if (Rate2g.Checked)
        {
            Rate2 = "G";
        }
        else if (Rate2f.Checked)
        {
            Rate2 = "F";
        }
        else
        {
            Rate2 = "";
        }

        if (Rate3e.Checked == true)
        {
            Rate3 = "E";
        }
        else if (Rate3g.Checked)
        {
            Rate3 = "G";
        }
        else if (Rate3f.Checked)
        {
            Rate3 = "F";
        }
        else
        {
            Rate3 = "";
        }
        if (Rate4e.Checked)
        {
            Rate4 = "E";
        }
        else if (Rate4g.Checked)
        {
            Rate4 = "G";
        }
        else if (Rate4f.Checked)
        {
            Rate4 = "F";
        }
        else
        {
            Rate4 = "";
        }

        //if (Rate4p.Checked == true)
        //    Rate4 = "P";

        if (Rate5e.Checked)
        {
            Rate5 = "E";
        }
        else if (Rate5g.Checked)
        {
            Rate5 = "G";
        }
        else if (Rate5f.Checked)
        {
            Rate5 = "F";
        }
        else
        {
            Rate5 = "";
        }

        //if (Rate5p.Checked == true)
        //    Rate5 = "P";

        if (Rate6e.Checked)
        {
            Rate6 = "E";
        }
        else if (Rate6g.Checked)
        {
            Rate6 = "G";
        }
        else if (Rate6f.Checked)
        {
            Rate6 = "F";
        }
        else
        {
            Rate6 = "";
        }

        //if (Rate6p.Checked == true)
        //    Rate6 = "P";

        if (Rate7e.Checked)
        {
            Rate7 = "E";
        }
        else if (Rate7g.Checked)
        {
            Rate7 = "G";
        }
        else if (Rate7f.Checked)
        {
            Rate7 = "F";
        }
        else
        {
            Rate7 = "";
        }

        //if (Rate7p.Checked == true)
        //    Rate7 = "P";

        if (Rate8e.Checked)
        {
            Rate8 = "E";
        }
        else if (Rate8g.Checked)
        {
            Rate8 = "G";
        }
        else if (Rate8f.Checked)
        {
            Rate8 = "F";
        }
        else
        {
            Rate8 = "";
        }

      
        OverAll1 = txtOverAll1.Text.Trim();
        OverAll2 = txtOverAll2.Text.Trim();
        OverAll3 = txtOverAll3.Text.Trim();
        OverAll4 = txtOverAll4.Text.Trim();
        OverAll5 = txtOverAll5.Text.Trim();
       
        OverAll6 = txtOverAll6.Text.Trim();
        OverAll7 = txtOverAll7.Text.Trim();
        OverAll8 = txtOverAll8.Text.Trim();
        OverAll9 = txtOverAll9.Text.Trim();

        CurrentDateTime = DateOfClearence.Text.Trim();

        try
        {
            connection = activity.OpenConnection();

            Query = "select * from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Query = "select * from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);

                if (ds_1.Tables[0].Rows.Count < 1)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'A' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                    Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                    if (Flag > 0)
                    {
                        Query = "update tbl_exit_interviewquestion set ApproverStatus = 'A', CurrentDateTime=getdate() where ExitId = " + Id + " and Status = 1";
                        Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);
                        if (Flag > 0)
                        {
                            BFlag = true;
                            Output.Show("Submitted Successfully");
                        }
                        else
                        {
                           
                            Output.Show("Application not approved.");
                        }
                    }
                    else
                        Output.Show("Application not approved.");
                }
                else
                    Output.Show("This application is already approved.");
            }
            else
            {
                if (DateOfClearence.Text != "")
                {
                    Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,OverAll1,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + OverAll1 + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','S','" + UserCode + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','1','" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";
                }
                else
                {
                    Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,OverAll1,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + OverAll1 + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','S','" + UserCode + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt") + "','1','" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";
                }

                Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);

                Query = "update tbl_exit_ExitProcess set ApproverStatus = 'A' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                

                if (Flag > 0)
                {
                    Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, Query);

                    if (Flag > 0)
                    {
                        
                        BFlag = true;
                        Output.Show("Submitted Successfully");
                    }
                    else
                    {
                      
                        Output.Show("Application not approved.");
                    }
                }
                else
                    Output.Show("Application not approved.");
            }

        }
        catch (Exception ex)
        {
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            if (BFlag == true)
            {
                Server.Transfer("PendingExitProcess.aspx?msg=Approved");
            }
            
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string Position = "";
        string Home = "";
        string Health = "";
        string Relocation = "";
        string Travel = "";
        string Education = "";
        string Dissatisfaction = "";
        string Dis_work = "";
        string Dis_Supervisor = "";
        string Dis_co = "";
        string Dis_work_condition = "";
        string Dis_benifits = "";
        string Laid_off = "";
        string Lack_of_work = "";
        string Abolition = "";
        string Funds = "";
        string Termination = "";
        string ReasonResponsible1Others;
        string ReasonResponsible1Elaborate;
        string StartSalary = "";
        string EndSalary = "";
        string phone = "";
        string mail = "";
        string peradd = "";
        string preadd = "";
        string city = "";
        string zipcode = "";
        string father = "";
        string mother = "";
        string hb_wife = "";
        string reference = "";
        string ReasonResponsible2 = "";
        string ReasonResponsible2Others;
        string ReasonResponsible2Elaborate;
        string Like_job = "";
        string Least = "";
        string Pay = "";
        
        string fandf = "";
        string Rate1 = "";
        string Rate2 = "";
        string Rate3 = "";
        string Rate4 = "";
        string Rate5 = "";
        string Rate6 = "";
        string Rate7 = "";
        string Rate8 = "";
        string Rate9 = "";
        string Rate10 = "";
        string Rate11 = "";
        string Rate12 = "";
        string Rate13 = "";

        string RateComments = "";

        string OverAll1 = "";
        string OverAll2 = "";
        string OverAll3 = "";
        string OverAll4 = "";
        string OverAll5 = "";
        string OverAll6YesNo = "";
        string OverAll6 = "";
        string OverAll7 = "";
        string OverAll8 = "";
        string OverAll9 = "";

        string CurrentDateTime = null;

        int Flag = 0;
        Lib = new Base();

        if (Relocation1.Checked == true)
            Position = "1";
        if (HigherEducation1.Checked == true)
            Home = "1";
        if (JobProfile1.Checked == true)
            Health = "1";
        if (CompanyPolicy1.Checked == true)
            Relocation = "1";
        if (Compensation1.Checked == true)
            Travel = "1";
        if (Benifits1.Checked == true)
            Education = "1";
        if (Supervisor1.Checked == true)
            Dissatisfaction = "1";
        if (LackofCareerProgression1.Checked == true)
            Dis_work = "1";
        if (CompanyManagement1.Checked == true)
            Dis_Supervisor = "1";
        if (HealthMedicalReason1.Checked == true)
            Dis_co = "1";
        if (Personal1.Checked == true)
            Dis_work_condition = "1";
        if (Retirement1.Checked == true)
            Dis_benifits = "1";
        //else if (VeryLongHoursofWorking1.Checked == true)
        //    ReasonResponsible1 = "M";
        //else if (Commute1.Checked == true)
        //    ReasonResponsible1 = "N";
        //else if (AnotherJobOffer1.Checked == true)
        //    ReasonResponsible1 = "O";
        //else if (BetterDesignation1.Checked == true)
        //    ReasonResponsible1 = "P";
        //else if (Marriage1.Checked == true)
        //    ReasonResponsible1 = "Q";

        //ReasonResponsible1Others = Other1.Value.Trim();
        //ReasonResponsible1Elaborate = Pleaseelaboratetheabovepoint1.Text.Trim();


        if (Relocation2.Checked == true)
            Laid_off = "1";
        if (HigherEducation2.Checked == true)
            Lack_of_work = "1";
        if (JobProfile2.Checked == true)
            Abolition = "1";
        if (CompanyPolicy2.Checked == true)
            Funds = "1";
        if (Compensation2.Checked == true)
            Termination = "1";
        //else if (Benifits2.Checked == true)
        //    ReasonResponsible2 = "F";
        //else if (Supervisor2.Checked == true)
        //    ReasonResponsible2 = "G";
        //else if (LackofCareerProgression2.Checked == true)
        //    ReasonResponsible2 = "H";
        //else if (CompanyManagement2.Checked == true)
        //    ReasonResponsible2 = "I";
        //else if (HealthMedicalReason2.Checked == true)
        //    ReasonResponsible2 = "J";
        //else if (Personal2.Checked == true)
        //    ReasonResponsible2 = "K";
        //else if (Retirement2.Checked == true)
        //    ReasonResponsible2 = "L";
        //else if (VeryLongHoursofWorking2.Checked == true)
        //    ReasonResponsible2 = "M";
        //else if (Commute2.Checked == true)
        //    ReasonResponsible2 = "N";
        //else if (AnotherJobOffer2.Checked == true)
        //    ReasonResponsible2 = "O";
        //else if (BetterDesignation2.Checked == true)
        //    ReasonResponsible2 = "P";
        //else if (Marriage2.Checked == true)
        //    ReasonResponsible2 = "Q";

        //ReasonResponsible2Others = Other2.Value.Trim();
        ReasonResponsible2Elaborate = Pleaseelaboratetheabovepoint2.Text.Trim();
        Pay = txt_pay.Text.Trim();
        Like_job = txt_like.Text.Trim();
        Least = txt_least.Text.Trim();
        fandf = txt_ff.Text.Trim();
        StartSalary = txt_stsalary.Text.Trim();
        EndSalary = txt_endsalary.Text.Trim();
        phone = txt_phone.Text.Trim();
        mail = txt_mail.Text.Trim();
        peradd = txtOverAll2.Text.Trim();
        preadd = txtOverAll3.Text.Trim();
        city = txtOverAll4.Text.Trim();
        zipcode = txtOverAll5.Text.Trim();
        father = txtOverAll6.Text.Trim();
        mother = txtOverAll7.Text.Trim();
        hb_wife = txtOverAll8.Text.Trim();
        reference = txtOverAll9.Text.Trim();

        if (Rate1g.Checked == true)
            Rate1 = "E";
        if (Rate1g.Checked == true)
            Rate1 = "G";
        if (Rate1f.Checked == true)
            Rate1 = "F";
        //if (Rate1p.Checked == true)
        //    Rate1 = "P";

        if (Rate2g.Checked == true)
            Rate2 = "E";
        if (Rate2g.Checked == true)
            Rate2 = "G";
        if (Rate2f.Checked == true)
            Rate2 = "F";
        //if (Rate2p.Checked == true)
        //    Rate2 = "P";

        if (Rate3g.Checked == true)
            Rate3 = "E";
        if (Rate3g.Checked == true)
            Rate3 = "G";
        if (Rate3f.Checked == true)
            Rate3 = "F";
        //if (Rate3p.Checked == true)
        //    Rate3 = "P";

        if (Rate4g.Checked == true)
            Rate4 = "E";
        if (Rate4g.Checked == true)
            Rate4 = "G";
        if (Rate4f.Checked == true)
            Rate4 = "F";
        //if (Rate4p.Checked == true)
        //    Rate4 = "P";

        if (Rate5g.Checked == true)
            Rate5 = "E";
        if (Rate5g.Checked == true)
            Rate5 = "G";
        if (Rate5f.Checked == true)
            Rate5 = "F";
        //if (Rate5p.Checked == true)
        //    Rate5 = "P";

        if (Rate6g.Checked == true)
            Rate6 = "E";
        if (Rate6g.Checked == true)
            Rate6 = "G";
        if (Rate6f.Checked == true)
            Rate6 = "F";
        //if (Rate6p.Checked == true)
        //    Rate6 = "P";

        if (Rate7g.Checked == true)
            Rate7 = "E";
        if (Rate7g.Checked == true)
            Rate7 = "G";
        if (Rate7f.Checked == true)
            Rate7 = "F";
        //if (Rate7p.Checked == true)
        //    Rate7 = "P";

        if (Rate8g.Checked == true)
            Rate8 = "E";
        if (Rate8g.Checked == true)
            Rate8 = "G";
        if (Rate8f.Checked == true)
            Rate8 = "F";
        //if (Rate8p.Checked == true)
        //    Rate8 = "P";

        //if (Rate9g.Checked == true)
        //    Rate9 = "E";
        //if (Rate9g.Checked == true)
        //    Rate9 = "G";
        //if (Rate9f.Checked == true)
        //    Rate9 = "F";
        //if (Rate9p.Checked == true)
        //    Rate9 = "P";

        //if (Rate10g.Checked == true)
        //    Rate10 = "E";
        //if (Rate10g.Checked == true)
        //    Rate10 = "G";
        //if (Rate10f.Checked == true)
        //    Rate10 = "F";
        //if (Rate10p.Checked == true)
        //    Rate10 = "P";

        //if (Rate11g.Checked == true)
        //    Rate11 = "E";
        //if (Rate11g.Checked == true)
        //    Rate11 = "G";
        //if (Rate11f.Checked == true)
        //    Rate11 = "F";
        //if (Rate11p.Checked == true)
        //    Rate11 = "P";

        //if (Rate12g.Checked == true)
        //    Rate12 = "E";
        //if (Rate12g.Checked == true)
        //    Rate12 = "G";
        //if (Rate12f.Checked == true)
        //    Rate12 = "F";
        //if (Rate12p.Checked == true)
        //    Rate12 = "P";

        //if (Rate13g.Checked == true)
        //    Rate13 = "E";
        //if (Rate13g.Checked == true)
        //    Rate13 = "G";
        //if (Rate13f.Checked == true)
        //    Rate13 = "F";
        //if (Rate13p.Checked == true)
        //    Rate13 = "P";

        //RateComments = txtRateComments.Text.Trim();

        OverAll1 = txtOverAll1.Text.Trim();
        OverAll2 = txtOverAll2.Text.Trim();
        OverAll3 = txtOverAll3.Text.Trim();
        OverAll4 = txtOverAll4.Text.Trim();
        OverAll5 = txtOverAll5.Text.Trim();
        //if (OverAllYes.Checked == true)
        //    OverAll6YesNo = "Y";
        //else
        //    OverAll6YesNo = "N";
        OverAll6 = txtOverAll6.Text.Trim();
        OverAll7 = txtOverAll7.Text.Trim();
        OverAll8 = txtOverAll8.Text.Trim();
        OverAll9 = txtOverAll9.Text.Trim();

        CurrentDateTime = DateOfClearence.Text.Trim();

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1";

            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'C'";

                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'C' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                    if (Flag > 0)
                    {
                        Query = "update tbl_exit_interviewquestion set ApproverStatus = 'C' where ExitId = " + Id + " and Status = 1";
                        Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                        if (Flag > 0)
                        {
                            Lib.Bee.Commit();
                            Output.Show("Clearance Request Rejected.");
                        }
                        else
                        {
                            Lib.Bee.RollBack();
                            Output.Show("Record not cancelled.");
                        }
                    }
                    else
                        Output.Show("Record not cancelled.");
                } 
                else
                    Output.Show("This application is already cancelled.");
            }
            else
            {

                if (DateOfClearence.Text != "")
                    Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + starttime + "','S','" + UserCode + "',getdate(),1,'" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";
                else
                    Query = @"insert into tbl_exit_interviewquestion (ExitId,EmpCode,ApproverCode,Position,Home,Health,Relocation,Travel,Education,Dissatisfaction,Dis_work,Dis_Supervisor,Dis_co,Dis_work_condition,Dis_benifits,Laid_off,Lack_of_work,Abolition,Funds,Termination,ReasonResponsible2Elaborate,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Like_job,Least,Pay,FandF,CurrentDateTime,ApproverStatus,CreatedBy,CreateDateTime,Status,starting_sal,ending_sal,phoneno,email,perAdd,preAdd,city,zipcode,father,mother,Hb_wife,reference) 
values (" + Id + ",'" + UserCode.Trim() + "','" + UserCode + "','" + Position + "','" + Home + "','" + Health + "','" + Relocation + "','" + Travel + "','" + Education + "','" + Dissatisfaction + "','" + Dis_work + "','" + Dis_Supervisor + "','" + Dis_co + "','" + Dis_work_condition + "','" + Dis_benifits + "','" + Laid_off + "','" + Lack_of_work + "','" + Abolition + "','" + Funds + "','" + Termination + "','" + ReasonResponsible2Elaborate + "','" + Rate1.Trim() + "','" + Rate2.Trim() + "','" + Rate3.Trim() + "','" + Rate4.Trim() + "','" + Rate5.Trim() + "','" + Rate6.Trim() + "','" + Rate7.Trim() + "','" + Rate8.Trim() + "','" + Like_job + "','" + Least + "','" + Pay + "','" + fandf + "','" + starttime + "','S','" + UserCode + "',getdate(),1,'" + StartSalary + "','" + EndSalary + "','" + phone + "','" + mail + "','" + peradd + "','" + preadd + "','" + city + "','" + zipcode + "','" + father + "','" + mother + "','" + hb_wife + "','" + reference + "')";


                Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                if (Flag > 0)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'A' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);

                    if (Flag > 0)
                    {
                        Lib.Bee.Commit();
                        Output.Show("Clearance Request Rejected.");
                    }
                    else
                    {
                        Lib.Bee.RollBack();
                        Output.Show("Application not cancelled.");
                    }
                }
                else
                    Output.Show("Application not cancelled.");
            }
        }
        catch (Exception ex)
        {
            Lib.Bee.RollBack();
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Lib.Bee.CloseConnection();
        }
    }

    //protected void OverAllYes_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (OverAllYes.Checked == true)
    //        OverAllYes.Visible = true;
    //    else
    //        OverAllYes.Visible = false;
    //}
    //protected void OverAllNo_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (OverAllNo.Checked == true)
    //        OverAllNo.Visible = false;
    //    else
    //        OverAllNo.Visible = true;
    //}

    protected void BindInitialData(string Empcode)
    {
        string Query = @"select emp.Id,convert(varchar(20),job.emp_doj,106) as emp_doj,job.official_mob_no,job.official_email_id,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,
dept.department_name,convert(varchar(20),resg.AppliedDate,106) as applieddate,
CONVERT(varchar(20),resg.DefaultLWD,106) as lastdate,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join tbl_internate_departmentdetails dept on dept.departmentid=job.dept_id
left join tbl_exit_Resignation resg on resg.EmpCode=job.empcode
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId where job.empcode='" + Empcode + "' and resg.ResignStatus !='J' ";
 DataSet DS = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,Query);
        string InitialQuery = @"select top(1) emp.Id,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId
where job.empcode='" + Empcode + "' order by emp.Id desc";
        DataSet DSInitial = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, InitialQuery);
        if (DS.Tables[0].Rows.Count > 0)
        {

            txt_hire.Text = DS.Tables[0].Rows[0]["emp_doj"].ToString();
            txt_name.Text = DS.Tables[0].Rows[0]["EmpName"].ToString();
            txt_dept.Text = DS.Tables[0].Rows[0]["department_name"].ToString(); 
            txt_lastdate.Text = DS.Tables[0].Rows[0]["lastdate"].ToString(); 
            txt_date.Text = DS.Tables[0].Rows[0]["applieddate"].ToString(); 
            txt_stposition.Text = DS.Tables[0].Rows[0]["designationname"].ToString();
            txt_endposition.Text = DSInitial.Tables[0].Rows[0]["designationname"].ToString(); 
        }


        string AllQuery = "select * from tbl_exit_interviewquestion where EmpCode='" + Empcode +"'";
        DataSet AllInitial = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, AllQuery);
        if (AllInitial.Tables[0].Rows.Count > 0)
        {
            txt_stsalary.Text = AllInitial.Tables[0].Rows[0]["starting_sal"].ToString();
            txt_endsalary.Text = AllInitial.Tables[0].Rows[0]["ending_sal"].ToString();
            if (AllInitial.Tables[0].Rows[0]["Position"].ToString() == "1")
            {
                Relocation1.Checked = true;
            }
            else
            {
                Relocation1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Home"].ToString() == "1")
            {
                HigherEducation1.Checked = true;
            }
            else
            {
                HigherEducation1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Health"].ToString() == "1")
            {
                JobProfile1.Checked = true;
            }
            else
            {
                JobProfile1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Relocation"].ToString() == "1")
            {
                CompanyPolicy1.Checked = true;
            }
            else
            {
                CompanyPolicy1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Travel"].ToString() == "1")
            {
                Compensation1.Checked = true;
            }
            else
            {
                Compensation1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Education"].ToString() == "1")
            {
                Benifits1.Checked = true;
            }
            else
            {
                Benifits1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Dissatisfaction"].ToString() == "1")
            {
                Supervisor1.Checked = true;
            }
            else
            {
                Supervisor1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Dis_work"].ToString() == "1")
            {
                LackofCareerProgression1.Checked = true;
            }
            else
            {
                LackofCareerProgression1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Dis_Supervisor"].ToString() == "1")
            {
                CompanyManagement1.Checked = true;
            }
            else
            {
                CompanyManagement1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Dis_co"].ToString() == "1")
            {
                HealthMedicalReason1.Checked = true;
            }
            else
            {
                HealthMedicalReason1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Dis_work_condition"].ToString() == "1")
            {
                Personal1.Checked = true;
            }
            else
            {
                Personal1.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Dis_benifits"].ToString() == "1")
            {
                Retirement1.Checked = true;
            }
            else
            {
                Retirement1.Checked = false;
            }


            if (AllInitial.Tables[0].Rows[0]["Laid_off"].ToString() == "1")
            {
                Relocation2.Checked = true;
            }
            else
            {
                Relocation2.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Lack_of_work"].ToString() == "1")
            {
                HigherEducation2.Checked = true;
            }
            else
            {
                HigherEducation2.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Abolition"].ToString() == "1")
            {
                JobProfile2.Checked = true;
            }
            else
            {
                JobProfile2.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Funds"].ToString() == "1")
            {
                CompanyPolicy2.Checked = true;
            }
            else
            {
                CompanyPolicy2.Checked = false;
            }
            if (AllInitial.Tables[0].Rows[0]["Termination"].ToString() == "1")
            {
                Compensation2.Checked = true;
            }
            else
            {
                Compensation2.Checked = false;
            }
            Pleaseelaboratetheabovepoint2.Text = AllInitial.Tables[0].Rows[0]["ReasonResponsible2Elaborate"].ToString();
            txt_like.Text = AllInitial.Tables[0].Rows[0]["Like_job"].ToString();
            txt_least.Text = AllInitial.Tables[0].Rows[0]["Least"].ToString();
            txt_pay.Text = AllInitial.Tables[0].Rows[0]["Pay"].ToString();

            if (AllInitial.Tables[0].Rows[0]["Rate1"].ToString() == "E")
            {
                Rate1e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate1"].ToString() == "F")
            {
                Rate1f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate1"].ToString() == "G")
            {
                Rate1g.Checked = true;
            }
            else
            {
                Rate1e.Checked = false;
                Rate1f.Checked = false;
                Rate1g.Checked = false;
            }

            if (AllInitial.Tables[0].Rows[0]["Rate2"].ToString() == "E")
            {
                Rate2e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate2"].ToString() == "F")
            {
                Rate2f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate2"].ToString() == "G")
            {
                Rate2g.Checked = true;
            }
            else
            {
                Rate2e.Checked = false;
                Rate2f.Checked = false;
                Rate2g.Checked = false;
            }

            if (AllInitial.Tables[0].Rows[0]["Rate3"].ToString() == "E")
            {
                Rate3e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate3"].ToString() == "F")
            {
                Rate3f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate3"].ToString() == "G")
            {
                Rate3g.Checked = true;
            }
            else
            {
                Rate3e.Checked = false;
                Rate3f.Checked = false;
                Rate3g.Checked = false;
            }

            if (AllInitial.Tables[0].Rows[0]["Rate4"].ToString() == "E")
            {
                Rate4e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate4"].ToString() == "F")
            {
                Rate4f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate4"].ToString() == "G")
            {
                Rate4g.Checked = true;
            }
            else
            {
                Rate4e.Checked = false;
                Rate4f.Checked = false;
                Rate4g.Checked = false;
            }

            if (AllInitial.Tables[0].Rows[0]["Rate5"].ToString() == "E")
            {
                Rate5e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate5"].ToString() == "F")
            {
                Rate5f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate5"].ToString() == "G")
            {
                Rate5g.Checked = true;
            }
            else
            {
                Rate5e.Checked = false;
                Rate5f.Checked = false;
                Rate5g.Checked = false;
            }

            if (AllInitial.Tables[0].Rows[0]["Rate6"].ToString() == "E")
            {
                Rate6e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate6"].ToString() == "F")
            {
                Rate6f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate6"].ToString() == "G")
            {
                Rate6g.Checked = true;
            }
            else
            {
                Rate6e.Checked = false;
                Rate6f.Checked = false;
                Rate6g.Checked = false;
            }

            if (AllInitial.Tables[0].Rows[0]["Rate7"].ToString() == "E")
            {
                Rate7e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate7"].ToString() == "F")
            {
                Rate7f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate7"].ToString() == "G")
            {
                Rate7g.Checked = true;
            }
            else
            {
                Rate7e.Checked = false;
                Rate7f.Checked = false;
                Rate7g.Checked = false;
            }

            if (AllInitial.Tables[0].Rows[0]["Rate8"].ToString() == "E")
            {
                Rate8e.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate8"].ToString() == "F")
            {
                Rate8f.Checked = true;
            }
            else if (AllInitial.Tables[0].Rows[0]["Rate8"].ToString() == "G")
            {
                Rate8g.Checked = true;
            }
            else
            {
                Rate8e.Checked = false;
                Rate8f.Checked = false;
                Rate8g.Checked = false;
            }

            txt_phone.Text = AllInitial.Tables[0].Rows[0]["phoneno"].ToString();
            txt_mail.Text = AllInitial.Tables[0].Rows[0]["email"].ToString();
            txt_ff.Text = AllInitial.Tables[0].Rows[0]["FandF"].ToString();

            txtOverAll1.Text = AllInitial.Tables[0].Rows[0]["OverAll1"].ToString();
            txtOverAll2.Text = AllInitial.Tables[0].Rows[0]["perAdd"].ToString();
            txtOverAll3.Text = AllInitial.Tables[0].Rows[0]["preAdd"].ToString();

            txtOverAll7.Text = AllInitial.Tables[0].Rows[0]["mother"].ToString();
            txtOverAll8.Text = AllInitial.Tables[0].Rows[0]["Hb_wife"].ToString();
            txtOverAll9.Text = AllInitial.Tables[0].Rows[0]["reference"].ToString();

            txtOverAll4.Text = AllInitial.Tables[0].Rows[0]["city"].ToString();
            txtOverAll5.Text = AllInitial.Tables[0].Rows[0]["zipcode"].ToString();
            txtOverAll6.Text = AllInitial.Tables[0].Rows[0]["father"].ToString();
            btnsave.Visible = false;
            btnApprove.Visible = false;
            Btn_Back.Visible = true;
        }
        else
        {
            btnsave.Visible = false;
            btnApprove.Visible = false;
            Btn_Back.Visible = true;
        }
    }

    protected void Btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResignationHistory.aspx");
    }
}