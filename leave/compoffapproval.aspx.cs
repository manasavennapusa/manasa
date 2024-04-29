using System;
using System.Web.UI.WebControls;

public partial class leave_compoffapproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            if (Request.QueryString["message"] != null)
            {
                SmartHr.Common.Alert(Request.QueryString["message"].ToString());
            }
        }

    }
  
    protected string linkleave(string empcode, string leavename, int id)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
            return "<a href='viewcompoffapprover.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";

        else
            return "<a href='viewcompoffhr.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + " </a>";

    }
    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}