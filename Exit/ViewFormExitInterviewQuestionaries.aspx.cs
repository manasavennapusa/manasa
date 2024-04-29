using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;


public partial class Exit_ViewFormExitInterviewQuestionaries : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id;
    string ResignId = "0";

    string PageId = "Exit Approvers";
    int ApplicationId = 6;
    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitEmployeeRule EmpRule = null;
    ExitCompanyRule CompanyRule = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
            //Id = Request.QueryString["Id"].ToString().Trim();
            ResignId = Request.QueryString["ResignId"].ToString().Trim();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindClearence();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindClearence()
    {
        try
        {
            Lib = new Base();
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_interviewquestion where ExitId = " + ResignId + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select * from tbl_exit_interviewquestion where ExitId = " + ResignId + " and Status = 1";
                DataSet ds = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query);
                DataRow row = ds.Tables[0].Rows[0];


                string query1 = "select EmpCode from tbl_exit_interviewquestion where ExitId = " + ResignId + " and Status = 1";
                DataSet dss = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, query1);
                DataRow dr=dss.Tables[0].Rows[0];
                string empcode = dr["EmpCode"].ToString();

                string str = @"select top(1)  emp.Id,convert(varchar(20),job.emp_doj,106) as emp_doj,job.official_mob_no,job.official_email_id,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,
dept.department_name,convert(varchar(20),resg.AppliedDate,106) as applieddate,
CONVERT(varchar(20),resg.DefaultLWD,106) as lastdate,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join tbl_internate_departmentdetails dept on dept.departmentid=job.dept_id
left join tbl_exit_Resignation resg on resg.EmpCode=job.empcode
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId where job.empcode='" + empcode + "'";
                DataSet ds1 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, str);

                string strt = @"select top(1) emp.Id,
desg.designationname
from dbo.tbl_intranet_employee_jobDetails job
left join EmpHistory emp on emp.EmpCode=job.empcode
left join tbl_intranet_designation desg on desg.id=emp.DesignationId
where job.empcode='" + empcode + "' order by emp.Id desc";
                DataSet ds4 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, strt);
                DataRow row4 = ds4.Tables[0].Rows[0];

                string str1 = @"select pre_add1,per_add1 from dbo.tbl_intranet_employee_contactlist where empcode='" + empcode + "'";
                DataSet ds2 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, str1);

                string str2 = @" select f_fname,m_fname,s_fname from dbo.tbl_intranet_employee_personalDetails where empcode='" + empcode + "'";
                DataSet ds3 = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, str2);

                DataRow row3 = ds1.Tables[0].Rows[0];
                //if (ds1.Tables[0].Rows.Count > 0)
                //{
                    
                //    txt_phone.Text = row3["official_mob_no"].ToString();
                //    txt_mail.Text = row3["official_email_id"].ToString();

                //}
                //if (ds2.Tables[0].Rows.Count > 0)
                //{
                //    DataRow row1 = ds2.Tables[0].Rows[0];
                //    txtOverAll2.Text = row1["per_add1"].ToString();
                //    txtOverAll3.Text = row1["pre_add1"].ToString();
                //}
                //else
                //{
                //    txtOverAll2.Text = "";
                //    txtOverAll3.Text = "";
                //}
                //if (ds3.Tables[0].Rows.Count > 0)
                //{
                //    DataRow row2 = ds3.Tables[0].Rows[0];
                //    txtOverAll6.Text = row2["f_fname"].ToString();
                //    txtOverAll7.Text = row2["m_fname"].ToString();
                //    txtOverAll8.Text = row2["s_fname"].ToString();
                //}

                txt_hire.Text = row3["emp_doj"].ToString();
                txt_name.Text = row3["EmpName"].ToString(); 
                txt_dept.Text = row3["department_name"].ToString();
                txt_hire.Text = row3["emp_doj"].ToString();
                txt_lastdate.Text = row3["lastdate"].ToString();
                txt_date.Text = row3["applieddate"].ToString();
                txt_stposition.Text = row3["designationname"].ToString();
                txt_endposition.Text = row4["designationname"].ToString();



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
                txtOverAll1.Text = row["OverAll1"].ToString();
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
                //txtOverAll6.Text = row["OverAll6"].ToString().Trim();
                //txtOverAll7.Text = row["OverAll7"].ToString().Trim();
                //txtOverAll8.Text = row["OverAll8"].ToString().Trim();
                //txtOverAll9.Text = row["OverAll9"].ToString().Trim();

                DateOfClearence.Text = row["CurrentDateTime"].ToString().Trim();

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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("ViewExitStatus.aspx?ResignId=" + ResignId + "");
    }

}