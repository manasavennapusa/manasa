using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DataAccessLayer;
using System.Data.SqlClient;
public partial class admin_costcenterview : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    protected void bindData()
    {
        sqlstr = "select G.cost_center_group_name ,C.cost_center_code,C.cost_center_name,C.id from tbl_intranet_cost_center C inner join tbl_intranet_cost_center_group G on C.cost_center_group_id=G.id ";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if(ds.Tables[0].Rows.Count<0)
            return;
        Grid_costcenter.DataSource = ds;
        Grid_costcenter.DataBind();
    }

}
