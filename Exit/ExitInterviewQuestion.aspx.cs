using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ExitInterviewQuestion : System.Web.UI.Page
{
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
            DateTime start;
            DateTime modified;
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
                DataRow dr = dss.Tables[0].Rows[0];
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
desg.designationname,job.official_email_id
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


                if (row["CurrentDateTime"].ToString() != "")
                {
                     start = Convert.ToDateTime(row["CurrentDateTime"].ToString());
                
                     modified = Convert.ToDateTime(row["CreateDateTime"].ToString());


                    lbl_statedate.Text = (start).ToString("dddddddddddddddd, dd-MMM-yyyy hh:mm tt");
                    lbl_modified.Text = (modified).ToString("dddddddddddddddd, dd-MMM-yyyy hh:mm tt");
                    TimeSpan dd = modified - start;
                    Labelq4.Text = string.Format("{0}:{1}:{2}", dd.Hours, dd.Minutes, dd.Seconds);

                }
             


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
                Label10.Text = row4["official_email_id"].ToString();



                if (row["Position"].ToString() == "1")
                {
                    lbl_id.Text = "Took another position";

                }
                else
                {
                    tr.Visible = false;
                }

                if (row["Home"].ToString() == "1")
                {
                    Label9.Text = "Home/family needs";
                }
                else
                {
                    tr1.Visible = false;
                }

                if (row["Health"].ToString() == "1")
                {
                    Label11.Text = "Poor health/physical disability";
                }
                else
                {
                    tr2.Visible = false;
                }

                if (row["Relocation"].ToString() == "1")
                {
                    Label12.Text = "Relocation to another city";
                }
                else
                {
                    tr3.Visible = false;
                }

                if (row["Travel"].ToString() == "1")
                {
                    Label13.Text = "Travel difficulties";
                }
                else
                {
                    tr4.Visible = false;
                }    
                   

                if (row["Education"].ToString() == "1")
                {
                    Label14.Text = "To attend Education";
                }
                else
                {
                    tr5.Visible = false;
                }

                if (row["Dissatisfaction"].ToString() == "1")
                {
                    Label15.Text = "Dissatisfaction with salary";
                }
                else
                {
                    tr6.Visible = false;
                }

                if (row["Dis_work"].ToString() == "1")
                {
                    Label16.Text = "Dissatisfaction - work";
                }
                else
                {
                    tr7.Visible = false;
                }

                if (row["Dis_Supervisor"].ToString() == "1")
                {
                    Label17.Text = "Dissatisfaction -supervisor";
                }
                else
                {
                    tr8.Visible = false;
                }

                if (row["Dis_co"].ToString() == "1")
                {
                    Label18.Text = "Dissatisfaction -co-workers";
                }
                else
                {
                    tr9.Visible = false;
                }

                if (row["Dis_work_condition"].ToString() == "1")
                {
                    Label19.Text = "Dissatisfaction– working Conditions";
                }
                else
                {
                    tr10.Visible = false;
                }

                if (row["Dis_benifits"].ToString() == "1")
                {
                    Label20.Text = "Dissatisfaction with benefits";
                }
                else
                {
                    tr11.Visible = false;
                }

                if (row["Laid_off"].ToString() == "1")
                {
                    Label21.Text = "LAID OFF";
                }
                else
                {
                    tr12.Visible = false;
                }


                if (row["Lack_of_work"].ToString() == "1")
                {
                    Label22.Text = "Lack of work";
                }
                else
                {
                    tr13.Visible = false;
                }

                if (row["Abolition"].ToString() == "1")
                {
                    Label23.Text = "Abolition of position";
                }
                else
                {
                    tr14.Visible = false;
                }

                if (row["Funds"].ToString() == "1")
                {
                    Label24.Text = "Lack of funds";
                }
                else
                {
                    tr15.Visible = false;
                }

                if (row["Termination"].ToString() == "1")
                {
                    Label25.Text = "Termination";
                }
                else
                {
                    tr16.Visible = false;
                } 

                Pleaseelaboratetheabovepoint2.Text = row["ReasonResponsible2Elaborate"].ToString();
                txt_like.Text = row["Like_job"].ToString();
                txt_least.Text = row["Least"].ToString();
                txt_pay.Text = row["Pay"].ToString();
                txt_ff.Text = row["FandF"].ToString();
                //txtOverAll1.Text = row["OverAll1"].ToString();
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
                    Label1.Text="Very-Satisfied";
                    //Rate1e.Checked = true;
                else if (row["Rate1"].ToString().Trim() == "G")
                    Label1.Text = "Satisfied";
                   // Rate1g.Checked = true;
                else if (row["Rate1"].ToString().Trim() == "F")
                    Label1.Text = "Dissatisfied";
                    //Rate1f.Checked = true;
                //else if (row["Rate1"].ToString().Trim() == "P")
                //    Rate1p.Checked = true;


                if (row["Rate2"].ToString().Trim() == "E")
                   // Rate2e.Checked = true;
                      Label2.Text="Very-Satisfied";
                else if (row["Rate2"].ToString().Trim() == "G")
                      Label2.Text = "Satisfied";
                   // Rate2g.Checked = true;
                else if (row["Rate2"].ToString().Trim() == "F")
                     Label2.Text = "Dissatisfied";
                   // Rate2f.Checked = true;
                //else if (row["Rate2"].ToString().Trim() == "P")
                //    Rate2p.Checked = true;

                if (row["Rate3"].ToString().Trim() == "E")
                      Label3.Text="Very-Satisfied";
                  //  Rate3e.Checked = true;
                else if (row["Rate3"].ToString().Trim() == "G")
                      Label3.Text = "Satisfied";
                   // Rate3g.Checked = true;
                else if (row["Rate3"].ToString().Trim() == "F")
                     Label3.Text = "Dissatisfied";
                   // Rate3f.Checked = true;
                //else if (row["Rate3"].ToString().Trim() == "P")
                //    Rate3p.Checked = true;

                if (row["Rate4"].ToString().Trim() == "E")
                      Label4.Text="Very-Satisfied";
                    //Rate4e.Checked = true;
                else if (row["Rate4"].ToString().Trim() == "G")
                    Label4.Text = "Satisfied";
                   // Rate4g.Checked = true;
                else if (row["Rate4"].ToString().Trim() == "F")
                    Label4.Text = "Dissatisfied";
                    //Rate4f.Checked = true;
                //else if (row["Rate4"].ToString().Trim() == "P")
                //    Rate4p.Checked = true;

                if (row["Rate5"].ToString().Trim() == "E")
                      Label5.Text="Very-Satisfied";
                   // Rate5e.Checked = true;
                else if (row["Rate5"].ToString().Trim() == "G")
                    Label5.Text = "Satisfied";
                    //Rate5g.Checked = true;
                else if (row["Rate5"].ToString().Trim() == "F")
                    Label5.Text = "Dissatisfied";
                    //Rate5f.Checked = true;
                //else if (row["Rate5"].ToString().Trim() == "P")
                //    Rate5p.Checked = true;

                if (row["Rate6"].ToString().Trim() == "E")
                      Label6.Text="Very-Satisfied";
                   // Rate6e.Checked = true;
                else if (row["Rate6"].ToString().Trim() == "G")
                    Label6.Text = "Satisfied";
                   // Rate6g.Checked = true;
                else if (row["Rate6"].ToString().Trim() == "F")
                    Label6.Text = "Dissatisfied";
                  //  Rate6f.Checked = true;
                //else if (row["Rate6"].ToString().Trim() == "P")
                //    Rate6p.Checked = true;

                if (row["Rate7"].ToString().Trim() == "E")
                      Label7.Text="Very-Satisfied";
                   // Rate7e.Checked = true;
                else if (row["Rate7"].ToString().Trim() == "G")
                      Label7.Text = "Satisfied";
                   // Rate7g.Checked = true;
                else if (row["Rate7"].ToString().Trim() == "F")
                     Label7.Text = "Dissatisfied";
                   // Rate7f.Checked = true;
                //else if (row["Rate7"].ToString().Trim() == "P")
                //    Rate7p.Checked = true;


                if (row["Rate8"].ToString().Trim() == "E")
                      Label8.Text="Very-Satisfied";
                    //Rate8e.Checked = true;
                else if (row["Rate8"].ToString().Trim() == "G")
                      Label8.Text = "Satisfied";
                   // Rate8g.Checked = true;
                else if (row["Rate8"].ToString().Trim() == "F")
                     Label8.Text = "Dissatisfied";
                   // Rate8f.Checked = true;
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
      //  Server.Transfer("ViewExitStatus.aspx?ResignId=" + ResignId + "");
    }

    
}