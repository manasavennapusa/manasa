using System;
using System.Web.UI.WebControls;

public partial class leave_leavestatus : System.Web.UI.Page
{
    //================================= Created by Ramu Nunna on 10-11-14 purpose of View Leave Details =============//

    string _companyId;
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                if (Request.QueryString["leavestatus"] != null)
                {
                    if (Request.QueryString["leavestatus"].ToString() == "0")
                        Label1.Text = "View Pending Leave";
                    else if (Request.QueryString["leavestatus"].ToString() == "1")
                        Label1.Text = "View Approved Leave";

                    else if (Request.QueryString["leavestatus"].ToString() == "2")
                        Label1.Text = "View Cancelled leave";

                    else if (Request.QueryString["leavestatus"].ToString() == "3")
                        Label1.Text = "View Rejected leave";

                    else if (Request.QueryString["leavestatus"].ToString() == "5")
                        Label1.Text = "View Draft leaves";

                }
            }
        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }
    #endregion
    #region Link of Leave Details
    protected string linkleave(string empcode, string leavename, int id, int approvalstatus)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Request.QueryString["leavestatus"].ToString() == "5")
            return "<a href='ModifiedLeave.aspx?q=" + encoded + "' title='view detail' class='link05'>View</a>";
        else
            return "<a href='ViewLeaveApplication.aspx?q=" + encoded + "' title='view detail' class='link05'>View</a>";
    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}