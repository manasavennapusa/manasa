using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer;
using Common.Data;
using Common.Console;

public partial class recruitment_registeredcandidates : System.Web.UI.Page
{
   
   // string _path;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //Response.Redirect("~/Authenticate.aspx");
        }
        else

            Response.Redirect("~/notlogged.aspx");
        bindcandidates();
       // _path = HttpContext.Current.Request.Url.AbsolutePath;
       // bindlabel();
    }

    //protected void bindlabel()
    //{
    //    SqlParameter[] sqlparam = new SqlParameter[1];
    //    Output.AssignParameter(sqlparam, 0, "@path", "String", 100, _path);
    //    DataSet ds = new DataSet();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ToString(), CommandType.StoredProcedure, "sp_getmenulable", sqlparam);
    //    if (ds.Tables[0].Rows.Count >= 1)
    //    {
    //        lblheader.Text = ds.Tables[0].Rows[0]["menulist"].ToString();
    //    }
    //}

    protected void bindcandidates()
    {
        string sqlstr = "select * from tbl_recruitment_candidate_registration";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
        grdCandidates.DataSource = ds;
        grdCandidates.DataBind();
    }

    protected void grdCandidates_PreRender(object sender, EventArgs e)
    {
        if (grdCandidates.Rows.Count > 0)
        {
            grdCandidates.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}