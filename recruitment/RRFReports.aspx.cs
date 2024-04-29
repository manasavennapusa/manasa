using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
using System.IO;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Text;

public partial class recruitment_Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    bool c = false;
    DataTable dtable = new DataTable();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
        }
    }

    #region Masters

    protected void btn_search_Click(object sender, EventArgs e)
    {

    }

    //protected void uncheckbtn_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < chk_payrolldetails.Items.Count; i++)
    //    {
    //        chk_payrolldetails.Items[i].Selected = false;
    //    }
    //}
    //protected void uncheckcaninfo_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < chkl_RRFdetails.Items.Count; i++)
    //    {
    //        chkl_RRFdetails.Items[i].Selected = false;
    //    }

    //}

    protected void checkcaninfo_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkl_RRFdetails.Items.Count; i++)
        {
            chkl_RRFdetails.Items[i].Selected = true;
        }
        light.Visible = false;
    }

    protected void chechbtn_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_payrolldetails.Items.Count; i++)
        {
            chk_payrolldetails.Items[i].Selected = true;
        }
        light.Visible = false;
    }

    #endregion

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        //light.Visible = true;
        connection = activity.OpenConnection();
        string loop ;

        if (chkl_RRFdetails.SelectedValue == "" && chk_payrolldetails.SelectedValue == "")
        {
            //if (chk_payrolldetails.SelectedValue == "")
            //{
            ScriptManager.RegisterStartupScript(updatepannel1, updatepannel1.GetType(), "xx", "<script> alert('Please select atleast one Component')</script>", false);
            //}
        }
        else
        {
            string Select = "";
            foreach (ListItem li in chkl_RRFdetails.Items)
            {

                if (li.Value == "candidate_name")
                    if (li.Selected == true)
                        Select += "Candidate_Name as Candidate_Name";

                if (li.Value == "designation_id")
                    if (li.Selected == true)
                        Select += ",designation_id as Designation";

                if (li.Value == "Qualification")
                    if (li.Selected == true)
                        Select += ",Qualification as Qualification";

                if (li.Value == "experience")
                    if (li.Selected == true)
                        Select += ",experience as Experience";

                if (li.Value == "expectedsalary")
                    if (li.Selected == true)
                        Select += ",expectedsalary as Expected_Salary";

                if (li.Value == "phone")
                    if (li.Selected == true)
                        Select += ",phone as Phone_Number";

                if (li.Value == "emailid")
                    if (li.Selected == true)
                        Select += ",emailid as Email_Address";

                if (li.Value == "locationid")
                    if (li.Selected == true)
                        Select += ",city as City";

                if (li.Value == "referredby")
                    if (li.Selected == true)
                        Select += ",(referredby+' - '+referrername) as Referred_By";
            }

            foreach (ListItem li in chk_payrolldetails.Items)
            {
                if (li.Value == "rrf_code")
                    if (li.Selected == true)
                        Select += ",rrf_code as RRF_Code";

                if (li.Value == "designationname")
                    if (li.Selected == true)
                        Select += ",designationname as Designation";

                if (li.Value == "round1_date")
                    if (li.Selected == true)
                        Select += ",convert(varchar(10),Date,101) as Date";

                if (li.Value == "round_1_marks")
                    if (li.Selected == true)
                        Select += ",round_1_marks as Round_1_Marks";

                if (li.Value == "round_1_status")
                    if (li.Selected == true)
                        Select += ",round_1_status as Round_1_Status";

                if (li.Value == "round_2_marks")
                    if (li.Selected == true)
                        Select += ",round_2_marks as Round_2_Marks";

                if (li.Value == "round_2_status")
                    if (li.Selected == true)
                        Select += ",round_2_status as Round_2_Status";

                if (li.Value == "ctc")
                    if (li.Selected == true)
                        Select += ",expectedCTC as Expected_Salary";


                if (li.Value == "OverallAssessment")
                    if (li.Selected == true)
                        Select += ",R3_Assessment as Overall_Assessment";

                if (li.Value == "PanelsRecomendation")
                    if (li.Selected == true)
                        Select += ",R3_Panel_Info as Panel_Recommendation";

                if (li.Value == "status")
                    if (li.Selected == true)
                        Select += ",Final_status as Final_Status";
            }
            //Select += ",Candidate_ID";

            string SelectQuery = "";
            if (Select.Substring(0, 1) == ",")
                SelectQuery = "Select " + Select.Substring(1, Select.Length - 1);
            else

                SelectQuery = "Select " + Select;

            string OuterQueryStart = SelectQuery + @" From 
                                                      (
Select RR.candidate_name,RR.designation_id,RR.Qualification,RR.experience,RR.expectedsalary,RR.phone,RR.emailid,loc.city,RR.referredby,RR.referrername,
RF.rrf_code,desig.designationname,ctc.expectedCTC,IW.round_1_marks,IW.round_1_status,IW.round_2_marks,IW.round_2_status,IR.OverallAssessment as R3_Assessment,
case when IR.PanelsRecomendation='3' then 'Suitable' else case when IR.PanelsRecomendation='2' then 'Not Suitable' else 
case when IR.PanelsRecomendation='1' then 'To be kept on panel' end end end  as 'R3_Panel_Info',
IR.status as Final_status,RR.id as Candidate_ID,IW.round1_date as date ";

            string OuterQueryEnd = ") SourceTable";


            string From = @" from tbl_recruitment_candidate_registration RR
                            inner join tbl_recruitment_requisition_form RF on RR.rrf_id = RF.id
                            inner join tbl_recruitment_candidate_interview IW on RR.id = IW.candidateid
                            inner join tbl_intranet_city loc on RF.locationid=loc.cid
                            INNER JOIN tbl_recruitment_expctc_master ctc ON RF.incentive = ctc.id
                            inner join tbl_intranet_designation desig on RF.designationid=desig.id
                            left join tbl_recruitment_interviewrrating IR on IR.Candidate_id = IW.candidateid and IR.rrf_code = RF.rrf_code ";

            string Where = "";
            SelectQueryBuilder query = new SelectQueryBuilder();
            if (txtfromdate.Text != "" && txttodate.Text == "")
                Where += "Where SourceTable.Date = " + txtfromdate.Text;
            else if (txtfromdate.Text == "" && txttodate.Text != "")
                Where += "Where SourceTable.Date = " + txttodate.Text;

            else if (txtfromdate.Text == "" && txttodate.Text == "")
            {
                if (dropstatus.SelectedValue == "S")
                {
                    Where += " where SourceTable.round_1_status='S' and SourceTable.round_2_status='S' and SourceTable.Final_status='S'";
                }
                else if (dropstatus.SelectedValue == "R")
                {
                    Where += " where (SourceTable.round_1_status='R' or SourceTable.round_2_status='R' or SourceTable.Final_status='R')";
                }

            }

            else if (txtfromdate.Text != "" && txttodate.Text != "")
            {
                Where += " where SourceTable.Date between '" + txtfromdate.Text + "' and  '" + txttodate.Text + "'";
            }
            if (dropstatus.SelectedValue == "0")
            {
                Where += " ";
            }
            else if (dropstatus.SelectedValue == "S")
            {
                Where += " and SourceTable.round_1_status='S' and SourceTable.round_2_status='S' and SourceTable.Final_status='S'";
            }
            else if (dropstatus.SelectedValue == "R")
            {
                Where += " and (SourceTable.round_1_status='R' or SourceTable.round_2_status='R' or SourceTable.Final_status='R')";
            }
            if (Where == "")
                Where += " Where ";
            else if (Where != "")
                Where += "";
            if (Where == " Where ")
                Where = "";

            string Source = OuterQueryStart + From + OuterQueryEnd + " " + Where;

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, Source);


            if (ds.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = ds;
                gridview.DataBind();
            }
            else
            {
                gridview.DataSource = "";
                gridview.DataBind();
            }
            light.Visible = true;
            light.Style.Add("display", "block");
        }
        activity.CloseConnection();



        //string type = "0";
        //string empcode = txt_employee.Text.Trim();
        //string branch = drpbranch.SelectedValue;
        //string depttype = ddldepatrtmenttype.SelectedValue;
        //string dept = drpdepartment.SelectedValue;
        //string month = dd_month.SelectedValue;
        //string year = ddlYear.SelectedValue;
        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'monthlyattendancereport.aspx?Branch=" + branch + "&DepartmentType" + depttype + "&Department=" + dept + "&Type=" + type + " &EmpCode=" + empcode + " &Month=" + month + "&Year=" + year + "', null, 'height=600,width=1260,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        connection = activity.OpenConnection();

        if (chkl_RRFdetails.SelectedValue == "" && chk_payrolldetails.SelectedValue == "")
        {
            //if (chk_payrolldetails.SelectedValue == "")
            //{
                ScriptManager.RegisterStartupScript(updatepannel1, updatepannel1.GetType(), "xx", "<script> alert('Please select atleast one Component')</script>", false);
            //}
        }
        else
        {

            string Select = "";
            foreach (ListItem li in chkl_RRFdetails.Items)
            {

                if (li.Value == "candidate_name")
                    if (li.Selected == true)
                        Select += "Candidate_Name as Candidate_Name";

                if (li.Value == "designation_id")
                    if (li.Selected == true)
                        Select += ",designation_id as Designation";

                if (li.Value == "Qualification")
                    if (li.Selected == true)
                        Select += ",Qualification as Qualification";

                if (li.Value == "experience")
                    if (li.Selected == true)
                        Select += ",experience as Experience";

                if (li.Value == "expectedsalary")
                    if (li.Selected == true)
                        Select += ",expectedsalary as Expected_Salary";

                if (li.Value == "phone")
                    if (li.Selected == true)
                        Select += ",phone as Phone_Number";

                if (li.Value == "emailid")
                    if (li.Selected == true)
                        Select += ",emailid as Email_Address";

                if (li.Value == "locationid")
                    if (li.Selected == true)
                        Select += ",city as City";

                if (li.Value == "referredby")
                    if (li.Selected == true)
                        Select += ",(referredby+' - '+referrername) as Referred_By";
            }



            foreach (ListItem li in chk_payrolldetails.Items)
            {
                if (li.Value == "rrf_code")
                    if (li.Selected == true)
                        Select += ",rrf_code as RRF_Code";

                if (li.Value == "designationname")
                    if (li.Selected == true)
                        Select += ",designationname as Designation";

                if (li.Value == "round1_date")
                    if (li.Selected == true)
                        Select += ",convert(varchar(10),Date,101) as Date";

                if (li.Value == "round_1_marks")
                    if (li.Selected == true)
                        Select += ",round_1_marks as Round_1_Marks";

                if (li.Value == "round_1_status")
                    if (li.Selected == true)
                        Select += ",round_1_status as Round_1_Status";

                if (li.Value == "round_2_marks")
                    if (li.Selected == true)
                        Select += ",round_2_marks as Round_2_Marks";

                if (li.Value == "round_2_status")
                    if (li.Selected == true)
                        Select += ",round_2_status as Round_2_Status";

                if (li.Value == "ctc")
                    if (li.Selected == true)
                        Select += ",expectedCTC as Expected_CTC";


                if (li.Value == "OverallAssessment")
                    if (li.Selected == true)
                        Select += ",R3_Assessment as Overall_Assessment";

                if (li.Value == "PanelsRecomendation")
                    if (li.Selected == true)
                        Select += ",R3_Panel_Info as Panel_Recommendation";

                if (li.Value == "status")
                    if (li.Selected == true)
                        Select += ",Final_status as Final_Status";
            }
            //Select += ",Candidate_ID";

            string SelectQuery = "";
            if (Select.Substring(0, 1) == ",")
                SelectQuery = "Select " + Select.Substring(1, Select.Length - 1);
            else

                SelectQuery = "Select " + Select;

            string OuterQueryStart = SelectQuery + @" From 
                                  (

Select RR.candidate_name as Candidate_Name,
RR.designation_id,
RR.Qualification,
RR.experience,
RR.expectedsalary,
RR.phone,
RR.emailid,
loc.city,
RF.rrf_code,
desig.designationname,
ctc.expectedCTC,
IW.round_1_marks,
IW.round_1_status,
IW.round_2_marks,
IW.round_2_status,RR.referredby,RR.referrername,
IR.OverallAssessment as R3_Assessment,
case when IR.PanelsRecomendation='3' then 'Suitable' else case when IR.PanelsRecomendation='2' then 'Not Suitable' else case when IR.PanelsRecomendation='1' then 'To be kept on panel' end end end  as 'R3_Panel_Info',
IR.status as Final_status,
RR.id as Candidate_ID,
IW.round1_date as date ";


            string OuterQueryEnd = ") SourceTable";


            string From = @" from tbl_recruitment_candidate_registration RR
                            inner join tbl_recruitment_requisition_form RF on RR.rrf_id = RF.id
                            inner join tbl_recruitment_candidate_interview IW on RR.id = IW.candidateid
                            inner join tbl_intranet_city loc on RF.locationid=loc.cid
                            INNER JOIN tbl_recruitment_expctc_master ctc ON RF.incentive = ctc.id
                            inner join tbl_intranet_designation desig on RF.designationid=desig.id
                            left join tbl_recruitment_interviewrrating IR on IR.Candidate_id = IW.candidateid and IR.rrf_code = RF.rrf_code ";

            string Where = "";
            SelectQueryBuilder query = new SelectQueryBuilder();
            if (txtfromdate.Text != "" && txttodate.Text == "")
                Where += "Where SourceTable.Date = " + txtfromdate.Text;
            else if (txtfromdate.Text == "" && txttodate.Text != "")
                Where += "Where SourceTable.Date = " + txttodate.Text;

            else if (txtfromdate.Text == "" && txttodate.Text == "")
            {
                if (dropstatus.SelectedValue == "S")
                {
                    Where += " where SourceTable.round_1_status='S' and SourceTable.round_2_status='S' and SourceTable.Final_status='S'";
                }
                else if (dropstatus.SelectedValue == "R")
                {
                    Where += " where (SourceTable.round_1_status='R' or SourceTable.round_2_status='R' or SourceTable.Final_status='R')";
                }

            }

            else if (txtfromdate.Text != "" && txttodate.Text != "")
            {
                Where += " where SourceTable.Date between '" + txtfromdate.Text + "' and  '" + txttodate.Text + "'";
            }
            if (dropstatus.SelectedValue == "0")
            {
                Where += " ";
            }
            else if (dropstatus.SelectedValue == "S")
            {
                Where += " and SourceTable.round_1_status='S' and SourceTable.round_2_status='S' and SourceTable.Final_status='S'";
            }
            else if (dropstatus.SelectedValue == "R")
            {
                Where += " and (SourceTable.round_1_status='R' or SourceTable.round_2_status='R' or SourceTable.Final_status='R')";
            }
            if (Where == "")
                Where += " Where ";
            else if (Where != "")
                Where += "";
            if (Where == " Where ")
                Where = "";

            string Source = OuterQueryStart + From + OuterQueryEnd + " " + Where;

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, Source);


            if (ds.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = ds;
                gridview.DataBind();
            }
            else
            {
                gridview.DataSource = "";
                gridview.DataBind();
            }
            light.Style.Add("display", "block");
        }
        activity.CloseConnection();
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";

        string filename = "attachment;filename =RRF Candidate.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =DutyRoster.xls");// TeamLeaveStatus.xls");
        //Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds;
        dg.DataBind();

        String style = @"<style>.text{mso-number-format:\@;}</style>";
        HttpContext.Current.Response.Write(style);
        int colindex = 0;
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            string valuetype = dc.DataType.ToString();
            foreach (DataGridItem i in dg.Items)
                i.Cells[colindex].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void uncheckbtn_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chk_payrolldetails.Items.Count; i++)
        {
            chk_payrolldetails.Items[i].Selected = false;
        }
        light.Visible = false;
    }

    protected void uncheckcaninfo_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkl_RRFdetails.Items.Count; i++)
        {
            chkl_RRFdetails.Items[i].Selected = false;
        }
        light.Visible = false;
    }


}












