using System;
using System.Web.UI.WebControls;

public partial class leave_viewleavestatus : System.Web.UI.Page
{
    private string _companyId, _userCode;
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                if (Request.QueryString["message"] != null)
                {
                    Common.Console.Output.Show(Request.QueryString["message"].ToString());
                }
            }

        }
        else
        {
           Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected string linkleave(string empcode, string leavename, int id, int approvalstatus)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Request.QueryString["leavestatus"].ToString() == "5")
            return "<a href='ModifiedLeave.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        else
            return "<a href='ViewLeaveApplication.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
    }
}