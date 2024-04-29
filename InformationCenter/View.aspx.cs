using Common.Console;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class informationcenter_View : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {

            }
            Bind_empsatisfactionsurvey();
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }


    }


    protected void Bind_empsatisfactionsurvey()
    {

        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select 
fd.id,
fd.mulfeedback1,
fd.mulfeedback2,
fd.mulfeedback3,
fd.mulfeedback4,
fd.mulfeedback5,
fd.mulfeedback6,
fd.feedback6,
fd.feedback7,
fd.feedback8,
fd.feedback9,
fd.feedback10,
fd.feedback11,
fd.feedback12,
fd.feedback13,
fd.feedback14,
fd.feedback15,
fd.feedback16,
fd.feedback17,
fd.feedback18,
fd.feedback19,
fd.feedback20,
fd.feedback21,
fd.feedback22,
fd.feedback23,
fd.feedback24,
fd.feedback25,
fd.feedback26,
fd.feedback27,
fd.feedback28,
fd.feedback29,
fd.feedback30,
fd.feedback31,
fd.feedback32,
fd.feedback33,
fd.feedback34,
fd.feedback35,
fd.feedback36,
fd.feedback37,
fd.feedback38,
fd.feedback39,
fd.feedback40,
fd.feedback41,
fd.feedback42,
fd.feedback43,
fd.feedback44,
fd.feedback45,
fd.feedback46,
fd.feedback47,
fd.feedback48,
fd.feedback49,
fd.feedback50,
fd.feedback51,
fd.feedback52,
fd.feedback53,
fd.feedback54,
fd.feedback55,
fd.createdby
 from dbo.tbl_informationemployeefeedback fd
  where id='"+Request.QueryString["id"].ToString()+"'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            lbl_hremployee.Text = ds.Tables[0].Rows[0]["mulfeedback1"].ToString();
            lbl_hrdepartment.Text = ds.Tables[0].Rows[0]["mulfeedback2"].ToString();
            lbl_hrinformation.Text = ds.Tables[0].Rows[0]["mulfeedback3"].ToString();
            lbl_hrdifficult.Text = ds.Tables[0].Rows[0]["mulfeedback4"].ToString();
            lbl_infservice.Text = ds.Tables[0].Rows[0]["mulfeedback5"].ToString();
            lbl_problem.Text = ds.Tables[0].Rows[0]["mulfeedback6"].ToString();
            lbl_rbo_but1.Text = ds.Tables[0].Rows[0]["feedback6"].ToString();
            lbl_rdo_but2.Text = ds.Tables[0].Rows[0]["feedback7"].ToString();
            lbl_rdo_but3.Text = ds.Tables[0].Rows[0]["feedback8"].ToString();
            lbl_rdo_but4.Text = ds.Tables[0].Rows[0]["feedback9"].ToString();
            lbl_rdo_but5.Text = ds.Tables[0].Rows[0]["feedback10"].ToString();
            lbl_rdo_but6.Text = ds.Tables[0].Rows[0]["feedback11"].ToString();
            lbl_rdo_but7.Text = ds.Tables[0].Rows[0]["feedback12"].ToString();
            lbl_rdo_but8.Text = ds.Tables[0].Rows[0]["feedback13"].ToString();
            lbl_rdo_but9.Text = ds.Tables[0].Rows[0]["feedback14"].ToString();
            lbl_rdo_but10.Text = ds.Tables[0].Rows[0]["feedback15"].ToString();
            lbl_rdo_but11.Text = ds.Tables[0].Rows[0]["feedback16"].ToString();
            lbl_rdo_but12.Text = ds.Tables[0].Rows[0]["feedback17"].ToString();
            lbl_rdo_but13.Text = ds.Tables[0].Rows[0]["feedback18"].ToString();
            lbl_rdo_but14.Text = ds.Tables[0].Rows[0]["feedback19"].ToString();
            lbl_rdo_but15.Text = ds.Tables[0].Rows[0]["feedback20"].ToString();
            lbl_rdo_but16.Text = ds.Tables[0].Rows[0]["feedback21"].ToString();
            lbl_rdo_but17.Text = ds.Tables[0].Rows[0]["feedback22"].ToString();
            lbl_rdo_but18.Text = ds.Tables[0].Rows[0]["feedback23"].ToString();
            lbl_rdo_but19.Text = ds.Tables[0].Rows[0]["feedback24"].ToString();
            lbl_rdo_but20.Text = ds.Tables[0].Rows[0]["feedback25"].ToString();
            lbl_rdo_but21.Text = ds.Tables[0].Rows[0]["feedback26"].ToString();
            lbl_rdo_but22.Text = ds.Tables[0].Rows[0]["feedback27"].ToString();
            lbl_rdo_but23.Text = ds.Tables[0].Rows[0]["feedback28"].ToString();
            lbl_rdo_but24.Text = ds.Tables[0].Rows[0]["feedback29"].ToString();
            lbl_rdo_but25.Text = ds.Tables[0].Rows[0]["feedback30"].ToString();
            lbl_rdo_but26.Text = ds.Tables[0].Rows[0]["feedback31"].ToString();
            lbl_rdo_but27.Text = ds.Tables[0].Rows[0]["feedback32"].ToString();
            lbl_rdo_but28.Text = ds.Tables[0].Rows[0]["feedback33"].ToString();
            lbl_rdo_but29.Text = ds.Tables[0].Rows[0]["feedback34"].ToString();
            lbl_rdo_but30.Text = ds.Tables[0].Rows[0]["feedback35"].ToString();
            lbl_rdo_but31.Text = ds.Tables[0].Rows[0]["feedback36"].ToString();
            lbl_rdo_but32.Text = ds.Tables[0].Rows[0]["feedback37"].ToString();
            lbl_rdo_but33.Text = ds.Tables[0].Rows[0]["feedback38"].ToString();
            lbl_rdo_but34.Text = ds.Tables[0].Rows[0]["feedback39"].ToString();
            lbl_rdo_but35.Text = ds.Tables[0].Rows[0]["feedback40"].ToString();
            lbl_rdo_but36.Text = ds.Tables[0].Rows[0]["feedback41"].ToString();
            lbl_rdo_but37.Text = ds.Tables[0].Rows[0]["feedback42"].ToString();
            lbl_rdo_but38.Text = ds.Tables[0].Rows[0]["feedback43"].ToString();
            lbl_rdo_but39.Text = ds.Tables[0].Rows[0]["feedback44"].ToString();
            lbl_rdo_but40.Text = ds.Tables[0].Rows[0]["feedback45"].ToString();
            lbl_rdo_but41.Text = ds.Tables[0].Rows[0]["feedback46"].ToString();
            lbl_rdo_but42.Text = ds.Tables[0].Rows[0]["feedback47"].ToString();
            lbl_rdo_but43.Text = ds.Tables[0].Rows[0]["feedback48"].ToString();
            lbl_rdo_but44.Text = ds.Tables[0].Rows[0]["feedback49"].ToString();
            lbl_rdo_but45.Text = ds.Tables[0].Rows[0]["feedback50"].ToString();
            lbl_rdo_but46.Text = ds.Tables[0].Rows[0]["feedback51"].ToString();
            lbl_rdo_but47.Text = ds.Tables[0].Rows[0]["feedback52"].ToString();
            lbl_rdo_but48.Text = ds.Tables[0].Rows[0]["feedback53"].ToString();
            lbl_rdo_but49.Text = ds.Tables[0].Rows[0]["feedback54"].ToString();
            lbl_rdo_but50.Text = ds.Tables[0].Rows[0]["feedback55"].ToString();

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


}