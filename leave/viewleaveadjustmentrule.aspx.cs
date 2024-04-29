using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_viewleaveadjustmentrule : System.Web.UI.Page
{

    DataTable dtable = new DataTable();
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    string strsql, _companyId, _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            { Session.Remove("aleave"); populateadjustmentleave(); }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
        if (Request.QueryString["empprofile"] != null)
        {
            Output.Show(" There is no adjustment rule defined for this leave ");
        }
    }
    protected void grid_aleave_PreRender(object sender, EventArgs e)
    {
        if (grid_aleave.Rows.Count > 0)
            grid_aleave.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void populateadjustmentleave()
    {
        try
        {
            DataSet ds;
            SqlParameter[] sqlparm;
            sqlparm = new SqlParameter[3];
            Output.AssignParameter(sqlparm, 0, "@leaveid", "Int", 10, Request.QueryString["leaveid"].ToString());
            Output.AssignParameter(sqlparm, 1, "@policyid", "Int", 0, Request.QueryString["policyid"].ToString());
            Output.AssignParameter(sqlparm, 2, "@comapnyid", "Int", 0, _companyId.ToString());
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_update_adjustment_rule", sqlparm);
            //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_update_adjustment_rule", sqlparm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();

            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lbl_policy.Text = ds.Tables[1].Rows[0]["policyname"].ToString();
            }

            if (Session["aleave"] == null)
            {
                createatable();
            }
            DataRow dr;
            DataTable sdata;

            sdata = (DataTable)Session["aleave"];

            for (int i = 0; ds.Tables[2].Rows.Count > i; i++)
            {
                dr = sdata.NewRow();
                dr["aleaveid"] = (ds.Tables[2].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[2].Rows[i]["adjust_leave"].ToString()) : 0;
                dr["aleavename"] = (ds.Tables[2].Rows[i]["leavetype"] != null) ? ds.Tables[2].Rows[i]["leavetype"].ToString() : "";
                sdata.Rows.Add(dr);
            }
            Session["aleave"] = sdata;
            bindadjustleave();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally { activity.CloseConnection(); }
    }

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("aleaveid", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["aleaveid"] };
        dtable.Columns.Add("aleavename", typeof(string));
        Session["aleave"] = dtable;
    }

    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["aleave"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();

    }
}
