using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Text;
using System.Collections.Generic;

public partial class InformationCenter_ESS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bindemployee_detail();
        }

    }
    protected void bindemployee_detail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = Session["empcode"].ToString();
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
        empname.Text = ds.Tables[0].Rows[0]["name"].ToString();
        empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        empdesignation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        string sqlstr = @"select approverid,approvername from tbl_leave_employee_hierarchy  where   approverpriority=1  and employeecode='" + Session["empcode"].ToString() + "'";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            supempcode.Text = ds1.Tables[0].Rows[0]["approverid"].ToString();
            lblsup_name.Text = ds1.Tables[0].Rows[0]["approvername"].ToString();
            
        }
        SqlParameter sqlparm1 = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        if (ds1.Tables[0].Rows.Count > 0)
        sqlparm1.Value = ds1.Tables[0].Rows[0]["approverid"].ToString();
        else
            sqlparm1.Value = System.Data.SqlTypes.SqlString.Null;

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm1);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            supverosdesignation.Text = ds2.Tables[0].Rows[0]["designationname"].ToString();
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sp = new SqlParameter[48];

        sp[0] = new SqlParameter("@empcode", Session["empcode"].ToString());
        sp[1] = new SqlParameter("@overallsatisfaction", rbtnlrating.SelectedValue);
        sp[2] = new SqlParameter("@confidenceonleadership", RadioButtonList1.SelectedValue);
        sp[3] = new SqlParameter("@adequateplanning", RadioButtonList8.SelectedValue);
        sp[4] = new SqlParameter("@Managementdoesnotplayfavorites", RadioButtonList9.SelectedValue);
        sp[5] = new SqlParameter("@Managementdoesnotsayonethinganddoanother", RadioButtonList10.SelectedValue);
        sp[6] = new SqlParameter("@QualityisatopprioritywithTriMedx", RadioButtonList2.SelectedValue);
        sp[7] = new SqlParameter("@IndividualinitiativeisencouragedatTriMedx", RadioButtonList3.SelectedValue);
        sp[8] = new SqlParameter("@NothingatTriMedxkeepsmefromdoingmybesteverday", RadioButtonList4.SelectedValue);
        sp[9] = new SqlParameter("@TriMedxscorporatecommunicationsarefrequentenough", RadioButtonList6.SelectedValue);
        sp[10] = new SqlParameter("@IfeelIcantrustwhatTriMedxtellsme", RadioButtonList7.SelectedValue);
        sp[11] = new SqlParameter("@Thereisadequatecommunicationbetweendepartments", RadioButtonList11.SelectedValue);
        sp[12] = new SqlParameter("@IhaveaclearlyestablishedcareerpathatTriMedx", RadioButtonList13.SelectedValue);
        sp[13] = new SqlParameter("@Ihaveopportunitiestolearnandgrow", RadioButtonList14.SelectedValue);
        sp[14] = new SqlParameter("@Mylastperformanceappraisalaccuratelyreflectedmyperformance", RadioButtonList5.SelectedValue);
        sp[15] = new SqlParameter("@Theperformanceappraisalsystemisfair", RadioButtonList26.SelectedValue);
        sp[16] = new SqlParameter("@IamgivenenoughauthoritytomakedecisionsIneedtomake", RadioButtonList12.SelectedValue);
        sp[17] = new SqlParameter("@IfeelIamcontributingtoTriMedxsmission", RadioButtonList15.SelectedValue);
        sp[18] = new SqlParameter("@IhavethematerialsandequipmentIneedtodomyjobwell", RadioButtonList16.SelectedValue);
        sp[19] = new SqlParameter("@IfIdogoodworkIcancountonmakingmoremoney", RadioButtonList18.SelectedValue);
        sp[20] = new SqlParameter("@IfIdogoodworkIcancountonbeingpromoted", RadioButtonList19.SelectedValue);
        sp[21] = new SqlParameter("@IfeelIamvaluedatTriMedx", RadioButtonList17.SelectedValue);
        sp[22] = new SqlParameter("@TriMedxgivesenoughrecognitionforworkthatswelldone", RadioButtonList27.SelectedValue);
        sp[23] = new SqlParameter("@Mysalaryisfairformyresponsibilities", RadioButtonList20.SelectedValue);
        sp[24] = new SqlParameter("@Ifeelpartofateamworkingtowardasharedgoal", RadioButtonList21.SelectedValue);
        sp[25] = new SqlParameter("@Politicsatthiscompanyarekepttoaminimum", RadioButtonList22.SelectedValue);
        sp[26] = new SqlParameter("@Ibelievemyjobissecure", RadioButtonList24.SelectedValue);
        sp[27] = new SqlParameter("@Myphysicalworkingconditionsaregood", RadioButtonList25.SelectedValue);
        sp[28] = new SqlParameter("@DeadlinesatTriMedxarerealistic", RadioButtonList23.SelectedValue);
        sp[29] = new SqlParameter("@Myworkloadisreasonable", RadioButtonList28.SelectedValue);
        sp[30] = new SqlParameter("@Icankeepareasonablebalancebetweenworkandpersonallife", RadioButtonList29.SelectedValue);
        sp[31] = new SqlParameter("@Mysupervisortreatsmefairly", RadioButtonList30.SelectedValue);
        sp[32] = new SqlParameter("@Mysupervisortreatsmewithrespect", RadioButtonList31.SelectedValue);
        sp[33] = new SqlParameter("@Mysupervisorhandlesmyworkrelatedissuessatisfactorily", RadioButtonList32.SelectedValue);
        sp[34] = new SqlParameter("@Mysupervisorasksmeforminputtohelpmakedecisions", RadioButtonList33.SelectedValue);
        sp[35] = new SqlParameter("@Mysupervisorisaneffectivemanager", RadioButtonList34.SelectedValue);
        sp[36] = new SqlParameter("@TriMedxprovidedasmuchinitialtrainingasIneeded", RadioButtonList35.SelectedValue);
        sp[37] = new SqlParameter("@TriMedxprovidesasmuchongoingtrainingasIneed", RadioButtonList36.SelectedValue);
        sp[38] = new SqlParameter("@HowlongdoyouplantocontinueyourcareerwithTriMedx", RadioButtonList37.SelectedValue);
        sp[39] = new SqlParameter("@WouldyourecommendemploymentattriMedxtoafriend", RadioButtonList38.SelectedValue);
        sp[40] = new SqlParameter("@WhatIlikebestaboutworkinginTriMedx", txt14.Text);
        sp[41] = new SqlParameter("@ThingsthatTriMedxshoulddotomakeitabetterworkplace", TextBox1.Text);
        sp[42] = new SqlParameter("@WhatIlikebestaboutworkinginmyDepartment", TextBox2.Text);
        sp[43] = new SqlParameter("@ThingsthatmyDepartmentshoulddotomakeitabetterplacetowork", TextBox3.Text);
        sp[44] = new SqlParameter("@Year", DateTime.Now.Year);
        sp[45] = new SqlParameter("@createdby", Session["empcode"].ToString());
        sp[46] = new SqlParameter("@createddate", DateTime.Now);
        sp[47] = new SqlParameter("@halfday", drpyear.SelectedValue);

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_insert_employee_satisfactorydetails]", sp);

        if (i <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('You are already applied this Term.Please wait until next Term');", true);

            //message.InnerHtml = "Employeesatisfaction form form send  ";
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Employeesatisfaction form Sent to  HR Sucessfully.');", true);

          //  message.InnerHtml = "Employeesatisfaction form goes HR Sucessfully.";
            reset();

        }


    }
    protected void reset()
    {
        rbtnlrating.ClearSelection();
        RadioButtonList1.ClearSelection();
        RadioButtonList2.ClearSelection();
        RadioButtonList3.ClearSelection();
        RadioButtonList4.ClearSelection();
        RadioButtonList5.ClearSelection();
        RadioButtonList6.ClearSelection();
        RadioButtonList7.ClearSelection();
        RadioButtonList8.ClearSelection();
        RadioButtonList9.ClearSelection();
        RadioButtonList10.ClearSelection();
        RadioButtonList11.ClearSelection();
        RadioButtonList12.ClearSelection();
        RadioButtonList13.ClearSelection();
        RadioButtonList14.ClearSelection();
        RadioButtonList15.ClearSelection();
        RadioButtonList16.ClearSelection();
        RadioButtonList17.ClearSelection();
        RadioButtonList18.ClearSelection();
        RadioButtonList19.ClearSelection();
        RadioButtonList20.ClearSelection();
        RadioButtonList21.ClearSelection();
        RadioButtonList22.ClearSelection();
        RadioButtonList23.ClearSelection();
        RadioButtonList24.ClearSelection();
        RadioButtonList25.ClearSelection();
        RadioButtonList26.ClearSelection();
        RadioButtonList27.ClearSelection();
        RadioButtonList28.ClearSelection();
        RadioButtonList29.ClearSelection();
        RadioButtonList30.ClearSelection();
        RadioButtonList31.ClearSelection();
        RadioButtonList32.ClearSelection();
        RadioButtonList33.ClearSelection();
        RadioButtonList34.ClearSelection();
        RadioButtonList35.ClearSelection();
        RadioButtonList36.ClearSelection();
        RadioButtonList37.ClearSelection();
        RadioButtonList38.ClearSelection();
        txt14.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text= "";
    }

}