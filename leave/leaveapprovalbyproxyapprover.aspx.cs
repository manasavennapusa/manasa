using System;
using System.Web.UI.WebControls;

public partial class leave_leaveapprovalbyproxyapprover : System.Web.UI.Page
{
    string _companyId, usercode;
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            usercode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
                    lbltitle.Text = "Leave Approval";
                else
                    lbltitle.Text = "Leave Updation";
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
        if (Request.QueryString["message"] != null)
        {
            Common.Console.Output.Show(Request.QueryString["message"].ToString());
        }
    }
    #endregion
    #region Approve Link of Leave Details
    protected string linkleave(string empcode, string leavename, int id)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
            return "<a href='viewleaveapproverproxy.aspx?q=" + encoded + "' title='view detail' class='lable lable-info'>" + leavename + "</a>";

        else
            return "<a href='ViewLeaveHR.aspx?q=" + encoded + "' title='view detail' class='lable lable-info'>" + leavename + " </a>";

    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}