using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using Utilities;

public partial class admin_viewemployeesatisfactionform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            // bindemployee_detail();
            bindfeedbackdetails();
        }
    }

    protected void bindfeedbackdetails()
    {
        string sqlstr = @"select sno,empcode,overallsatisfaction,confidenceonleadership,adequateplanning,Managementdoesnotplayfavorites,
Managementdoesnotsayonethinganddoanother,QualityisatopprioritywithTriMedx,IndividualinitiativeisencouragedatTriMedx
,NothingatTriMedxkeepsmefromdoingmybesteverday,TriMedxscorporatecommunicationsarefrequentenough,
IfeelIcantrustwhatTriMedxtellsme,
Thereisadequatecommunicationbetweendepartments,
IhaveaclearlyestablishedcareerpathatTriMedx,
Ihaveopportunitiestolearnandgrow,
Mylastperformanceappraisalaccuratelyreflectedmyperformance,
Theperformanceappraisalsystemisfair,
IamgivenenoughauthoritytomakedecisionsIneedtomake,
IfeelIamcontributingtoTriMedxsmission,
IhavethematerialsandequipmentIneedtodomyjobwell,
IfIdogoodworkIcancountonmakingmoremoney,
IfIdogoodworkIcancountonbeingpromoted,
IfeelIamvaluedatTriMedx,
TriMedxgivesenoughrecognitionforworkthatswelldone,
Mysalaryisfairformyresponsibilities,
Ifeelpartofateamworkingtowardasharedgoal,
Politicsatthiscompanyarekepttoaminimum,
Ibelievemyjobissecure,
Myphysicalworkingconditionsaregood,
DeadlinesatTriMedxarerealistic,
Myworkloadisreasonable,
Icankeepareasonablebalancebetweenworkandpersonallife,
Mysupervisortreatsmefairly,
Mysupervisortreatsmewithrespect,
Mysupervisorhandlesmyworkrelatedissuessatisfactorily,
Mysupervisorasksmeforminputtohelpmakedecisions,
Mysupervisorisaneffectivemanager,
TriMedxprovidedasmuchinitialtrainingasIneeded,
TriMedxprovidesasmuchongoingtrainingasIneed,
HowlongdoyouplantocontinueyourcareerwithTriMedx,
WouldyourecommendemploymentattriMedxtoafriend,
WhatIlikebestaboutworkinginTriMedx,
ThingsthatTriMedxshoulddotomakeitabetterworkplace,
WhatIlikebestaboutworkinginmyDepartment,
ThingsthatmyDepartmentshoulddotomakeitabetterplacetowork,
Year,
createdby,
createddate from tbl_intranet_employeesatisfactionsurvey where sno=" + Convert.ToInt32(Request.QueryString["sno"].ToString());


        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //for (int i = 0; i <= 40; i++)
        //{
        //    Label[] labels = new Label[40];
        ////    labels[i].Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0][arry[i]].ToString()));

        //}
        bindemployee_detail(Convert.ToInt32(ds1.Tables[0].Rows[0]["empcode"].ToString()));
        Label1.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["overallsatisfaction"].ToString()));
        Label2.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["confidenceonleadership"].ToString()));
        Label3.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["adequateplanning"].ToString()));
        Label4.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Managementdoesnotplayfavorites"].ToString()));
        Label7.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Managementdoesnotsayonethinganddoanother"].ToString()));
        Label8.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["QualityisatopprioritywithTriMedx"].ToString()));
        Label9.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IndividualinitiativeisencouragedatTriMedx"].ToString()));
        Label10.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["NothingatTriMedxkeepsmefromdoingmybesteverday"].ToString()));
        Label11.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["TriMedxscorporatecommunicationsarefrequentenough"].ToString()));
        Label12.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IfeelIcantrustwhatTriMedxtellsme"].ToString()));
        Label13.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Thereisadequatecommunicationbetweendepartments"].ToString()));
        Label14.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IhaveaclearlyestablishedcareerpathatTriMedx"].ToString()));
        Label15.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Ihaveopportunitiestolearnandgrow"].ToString()));
        Label16.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Mylastperformanceappraisalaccuratelyreflectedmyperformance"].ToString()));
        Label17.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Theperformanceappraisalsystemisfair"].ToString()));
        Label18.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IamgivenenoughauthoritytomakedecisionsIneedtomake"].ToString()));
        Label19.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IfeelIamcontributingtoTriMedxsmission"].ToString()));
        Label20.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IhavethematerialsandequipmentIneedtodomyjobwell"].ToString()));
        Label21.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IfIdogoodworkIcancountonmakingmoremoney"].ToString()));
        Label22.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IfIdogoodworkIcancountonbeingpromoted"].ToString()));
        Label23.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["IfeelIamvaluedatTriMedx"].ToString()));
        Label24.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["TriMedxgivesenoughrecognitionforworkthatswelldone"].ToString()));
        Label25.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Mysalaryisfairformyresponsibilities"].ToString()));
        Label26.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Ifeelpartofateamworkingtowardasharedgoal"].ToString()));
        Label27.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Politicsatthiscompanyarekepttoaminimum"].ToString()));
        Label28.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Ibelievemyjobissecure"].ToString()));
        Label29.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["DeadlinesatTriMedxarerealistic"].ToString()));
        Label30.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Myworkloadisreasonable"].ToString()));
        Label31.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Icankeepareasonablebalancebetweenworkandpersonallife"].ToString()));

        Label32.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Mysupervisortreatsmefairly"].ToString()));

        Label33.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Mysupervisortreatsmewithrespect"].ToString()));

        Label34.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Mysupervisorhandlesmyworkrelatedissuessatisfactorily"].ToString()));

        Label35.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Mysupervisorasksmeforminputtohelpmakedecisions"].ToString()));

        Label36.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["Mysupervisorisaneffectivemanager"].ToString()));

        Label37.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["TriMedxprovidedasmuchinitialtrainingasIneeded"].ToString()));

        Label38.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["TriMedxprovidesasmuchongoingtrainingasIneed"].ToString()));

        Label39.Text = ratingattributes(Convert.ToInt32(ds1.Tables[0].Rows[0]["TriMedxprovidesasmuchongoingtrainingasIneed"].ToString()));

        Label40.Text = bindcarrercontinuehowmanyyears(Convert.ToInt32(ds1.Tables[0].Rows[0]["HowlongdoyouplantocontinueyourcareerwithTriMedx"].ToString()));

        Label41.Text = bindfriendrecommendedtotrimedx(Convert.ToInt32(ds1.Tables[0].Rows[0]["WouldyourecommendemploymentattriMedxtoafriend"].ToString()));

        Label42.Text = ds1.Tables[0].Rows[0]["WhatIlikebestaboutworkinginTriMedx"].ToString();
        Label43.Text = ds1.Tables[0].Rows[0]["ThingsthatTriMedxshoulddotomakeitabetterworkplace"].ToString();

        Label44.Text = ds1.Tables[0].Rows[0]["WhatIlikebestaboutworkinginmyDepartment"].ToString();
        Label45.Text = ds1.Tables[0].Rows[0]["ThingsthatmyDepartmentshoulddotomakeitabetterplacetowork"].ToString();
    }
    protected string  bindcarrercontinuehowmanyyears(int value)
    {
        if (value == 1)
            return "Less than a year";
        else if (value == 2)
            return " One to two years";
        else if (value == 3)
            return "Two to five years";
        else if (value == 4)
            return "More than five years";
        else if (value == 5)
            return "Don't Know";
        else
            return "";


    }
    protected string bindfriendrecommendedtotrimedx(int value)
    {
        if (value == 1)
            return "Definitely not";
        else if (value == 2)
            return " probably not";
        else if (value == 3)
            return "maybe";
        else if (value == 4)
            return "probably would";
        else if (value == 5)
            return "definitely would";
        else
            return "";

    }
    protected void bindemployee_detail(int empcode)
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = Session["empcode"].ToString();
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
        lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        //  HiddenField_gender.Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        lbl_doj.Text = Utility.dataformat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
        //  hdn_branchid.Value = ds.Tables[0].Rows[0]["branch_id"].ToString();

    }
    protected string ratingattributes(int value)
    {


        if (value == 1)
            return "Disagree Strongly";
        else if (value == 2)
            return " Disagree Somewhat";
        else if (value == 3)
            return "Neutral";
        else if (value == 4)
            return "Agree Somewhat";
        else if (value == 5)
            return "Agree Strongly";
        else
            return " ";
       


    }
}

