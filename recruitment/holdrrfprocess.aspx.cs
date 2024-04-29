using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using DataAccessLayer;
using System.Configuration;

public partial class recruitment_holdrrfprocess : System.Web.UI.Page
{
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //    Response.Redirect("~/Authenticate.aspx");
        }
        else

            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            bind_activeRRF();
            bind_holdrrf();
        }
    }

    //Hold RRF Process
    protected void bind_activeRRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs_for_CloseVacancy", sqlparam);
        grdholdrrf.DataSource = ds;
        grdholdrrf.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdholdrrf.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkclose");
            ChkBoxRows.Checked = false;
        }
    }

    protected void grdholdrrf_PreRender(object sender, EventArgs e)
    {
        if (grdholdrrf.Rows.Count > 0)
        {
            grdholdrrf.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }


    //Activate RRF Process
    protected void bind_holdrrf()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_holdRRFs",sqlparam);
        grdactivaterrf.DataSource = ds;
        grdactivaterrf.DataBind();
    }

    protected void btnaholdclear_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdactivaterrf.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkclose");
            ChkBoxRows.Checked = false;
        }
    }

    protected void grdactivaterrf_PreRender(object sender, EventArgs e)
    {
        if (grdactivaterrf.Rows.Count > 0)
        {
            grdactivaterrf.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}