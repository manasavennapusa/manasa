using System;
using System.Web.UI.WebControls;
public partial class leave_myleavebalance : System.Web.UI.Page
{
    private string _companyId, _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (Request.QueryString["empcode"] == null)
                if (Session["Leaveempcode"] != null)
                    hidd_empcode.Value = Session["Leaveempcode"].ToString();
                else hidd_empcode.Value = _userCode;

            else
                hidd_empcode.Value = Request.QueryString["empcode"].ToString().Trim();
        }
    }

    protected void balancegrid_PreRender(object sender, EventArgs e)
    {
        if (balancegrid.Rows.Count > 0)
            balancegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}