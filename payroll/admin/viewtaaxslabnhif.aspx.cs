using System;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class payroll_admin_viewtaaxslabnhif : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindSlab();
            bindSlabtax();
        }
    }

    protected void bindSlab()
    {
       
        string sqlstr = "select * from tbl_taxslabforNHIF";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        tax_grid.DataSource = ds;
        tax_grid.DataBind();
    }

    protected void bindSlabtax()
    {
        
        string sqlstr = "select * from tbl_taxslabforPaye";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_tax.DataSource = ds;
        grid_tax.DataBind();
    }
}