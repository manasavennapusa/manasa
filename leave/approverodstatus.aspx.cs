using System;
using System.Web.UI.WebControls;

public partial class leave_approverodstatus : System.Web.UI.Page
{

    string _companyId;
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {

            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    #endregion
    #region Link of Leave Details
    protected string linkleave(string empcode, int id, int approvalstatus)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a href='ViewApplyOd.aspx?q=" + encoded + "' title='view detail' class='link05'>View</a>";
    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}