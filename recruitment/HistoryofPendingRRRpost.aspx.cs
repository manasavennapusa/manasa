using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class recruitment_HistoryofPendingRRRpost : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            //bind_ddlrrf();
            bind_rrf_status();

        }

    }

    //protected void ddlrrfcode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlParameter[] sqlparam1;
    //    sqlparam1 = new SqlParameter[1];
    //    Output.AssignParameter(sqlparam1, 0, "@rrfcode", "String", 50, ddlrrfcode.SelectedItem.ToString());

    //    SqlConnection connection = activity.OpenConnection();
    //    DataSet ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_recruitment_post_history", sqlparam1);
    //    //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_fetchrule", sqlparm);
    //    if (ds.Tables[0].Rows.Count < 0)
    //    {
    //        return;

    //    }

    //    grdposts.DataSource = ds;
    //    grdposts.DataBind();
    //    activity.CloseConnection();
    //}
    //protected void bind_ddlrrf()
    //{
    //    DataSet ds = new DataSet();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_post_history_grid"); 
    //    ddlrrfcode.DataTextField = "rrf_code";
    //    ddlrrfcode.DataValueField = "id";       
    //    ddlrrfcode.DataSource = ds;
    //    ddlrrfcode.DataBind();
    //    ddlrrfcode.Items.Insert(0, new ListItem("-------All-------", "0"));  

    //    //string sqlstr = "select id,rrf_code from tbl_recruitment_requisition_form where status in (1,2)";
    //    //DataSet ds = new DataSet();
    //    //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //    //ddlrrfcode.DataTextField = "rrf_code";
    //    //ddlrrfcode.DataValueField = "id";
    //    //ddlrrfcode.DataSource = ds;
    //    //ddlrrfcode.DataBind();
    //    //ddlrrfcode.Items.Insert(0, new ListItem("--All--", "0"));
    //}

    protected void bind_rrf_status()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_post_history_grid");
        grdposts.DataSource = ds;
        grdposts.DataBind();
    }

    protected void grdposts_PreRender(object sender, EventArgs e)
    {
        if (grdposts.Rows.Count > 0)
            grdposts.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}