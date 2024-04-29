using System;
using System.Web.UI.WebControls;
public partial class leave_odapproval : System.Web.UI.Page
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
        if (Request.QueryString["message"] != null)
        {
            Common.Console.Output.Show(Request.QueryString["message"].ToString());
        }
    }
    #endregion

    #region Approve Link of OD Details
    protected string linkleave(string empcode, int id)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
            return "<a href='ViewODApprover.aspx?q=" + encoded + "' title='view detail' class='lbl lbl-info'>View</a>";

        else
            return "<a href='ViewOdHR.aspx?q=" + encoded + "' title='view detail' class='lbl lbl-info'>View</a>";

    }
    #endregion

    protected void pendinggrid_PreRender(object sender, EventArgs e)
    {
        if (pendinggrid.Rows.Count > 0)
            pendinggrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}