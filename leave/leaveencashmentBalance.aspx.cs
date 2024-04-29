using Common.Data;
using Smart.HR.Common.Console;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_leaveencashmentBalance : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    private string _companyId, _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (Request.QueryString["empcode"] == null)
            {
                if (Session["Leaveempcode"] != null && Session["periodid"] != null)
                {
                    hidd_empcode.Value = Session["Leaveempcode"].ToString();
                    hidd_period.Value = Session["periodid"].ToString();
                }
                else hidd_empcode.Value = _userCode;
            }
            else
                hidd_empcode.Value = Request.QueryString["empcode"].ToString().Trim();
        }
        bindEncasheddetails();
    }
    protected void bindEncasheddetails()
    {
        
      
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, hidd_empcode.Value);
        SqlConnection connection = activity.OpenConnection();
        Output.AssignParameter(sqlparm, 1, "@periodid", "String", 50, hidd_period.Value);
      
        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_encashment_History", sqlparm);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        GridView1.DataSource = ds;
        GridView1.DataBind();
        activity.CloseConnection();
    }
    protected void balancegrid_PreRender(object sender, EventArgs e)
    {
        if (balancegrid.Rows.Count > 0)
            balancegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}