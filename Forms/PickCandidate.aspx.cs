using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Configuration;

public partial class recruitment_PickCandidate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCandidateDetails();
        }
    }
    protected void bindCandidateDetails()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recuitment_candidate_details_in_hr_letter");
        candidategrid.DataSource = ds;
        candidategrid.DataBind();
    }

    protected void candidategrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        candidategrid.PageIndex = e.NewPageIndex;
        bindCandidateDetails();
    }
    protected void candidategrid_PreRender(object sender, EventArgs e)
    {
        if (candidategrid.Rows.Count > 0)
            candidategrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    //protected void btnaddnew_Click(object sender, EventArgs e)
    //{
    //    string selectedemployee = "", selectedemployeenames = "";
    //    foreach (GridViewRow row in candidategrid.Rows)
    //    {
    //        CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
    //        Label empcode = (Label)row.FindControl("lblempcode");
    //        Label empname = (Label)row.FindControl("lblname");
    //        if (ChkBoxRows.Checked == true)
    //        {
    //            selectedemployee = selectedemployee + empcode.Text.Trim() + ",";
    //            selectedemployeenames = selectedemployeenames + empname.Text.Trim() + ", ";
    //        }
    //    }
    //    if (selectedemployee != "")
    //    {
    //        selectedemployee = selectedemployee.Substring(0, selectedemployee.Length - 1);
    //    }
    //    if (selectedemployeenames != "")
    //    {
    //        selectedemployeenames = selectedemployeenames.Substring(0, selectedemployeenames.Length - 2);
    //    }
    //    //System.Web.UI.ScriptManager.RegisterClientScriptBlock("Script", "returnempcode('" + selectedemployee + "','" + selectedemployeenames + "');", true);
    //}
}