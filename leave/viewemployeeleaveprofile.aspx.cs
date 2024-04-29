using Common.Console;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class leave_viewemployeeleaveprofile : System.Web.UI.Page
{
    string sqlstr, _companyId, _userCode, _empcode;
    DataSet ds = new DataSet();
    public int i;
    DataTable dtable = new DataTable();
    DataView dview;
    Boolean add;
    SqlConnection _connection;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            _empcode = Request.QueryString["empcode"].ToString();
            if (!IsPostBack)
            {
                Session.Remove("hiearchy");
                //GridViewHelper helper = new GridViewHelper(this.grid_customizerule);
                //helper.RegisterGroup("policyname", true, true);

                //helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                fetchemphierarchy();
                BindLeavePolicyDetails(_empcode);

            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }

    private void BindLeavePolicyDetails(string empCode)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = @"SELECT tbl_leave_employee_leave_master.PolicyId, tbl_leave_employee_leave_master.Entitled_days AS Expr4, tbl_leave_employee_leave_master.leaveid, tbl_leave_employee_leave_master.empcode, tbl_leave_createleave.leaveid AS Expr1, tbl_leave_createleave.leavetype, tbl_leave_createleavepolicy.policyid AS Expr2, tbl_leave_createleavepolicy.policyname, tbl_leave_createleave.leavetype AS Expr3 FROM tbl_leave_employee_leave_master INNER JOIN tbl_leave_createleave ON tbl_leave_createleave.leaveid = tbl_leave_employee_leave_master.leaveid INNER JOIN tbl_leave_createleavepolicy ON tbl_leave_createleavepolicy.policyid = tbl_leave_employee_leave_master.PolicyId WHERE (tbl_leave_employee_leave_master.status = 1) AND (tbl_leave_employee_leave_master.empcode = '" + empCode + "') AND (tbl_leave_employee_leave_master.leaveid!=0) and tbl_leave_createleave.company_id=" + _companyId;
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            grid_customizerule.DataSource = ds;
            grid_customizerule.DataBind();

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void grid_customizerule_PreRender(object sender, EventArgs e)
    {
        if (grid_customizerule.Rows.Count > 0)
            grid_customizerule.HeaderRow.TableSection = TableRowSection.TableHeader;

    }

    protected void approvalgrid_PreRender(object sender, EventArgs e)
    {
        if (approvalgrid.Rows.Count > 0)
            approvalgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "policyname")
        {
            row.Cells[0].CssClass = "frm-btm-line-1";
            row.HorizontalAlign = HorizontalAlign.Left;
            row.Cells[0].Text = row.Cells[0].Text;
        }
    }
    protected void fetchemphierarchy()
    {
        try
        {

            lbl_empcode.Text = Request.QueryString["empcode"].ToString();
            SqlParameter[] sqlparam1;
            sqlparam1 = new SqlParameter[1];
            Output.AssignParameter(sqlparam1, 0, "@empid", "String", 50, Request.QueryString["empcode"].ToString());

            SqlConnection connection = activity.OpenConnection();
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchrule", sqlparam1);
            // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_fetchrule", sqlparm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_hr.Text = ds.Tables[0].Rows[0]["approverid"].ToString();
                
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                create_approver_table();
                DataRow dr;
                DataTable sdata;

                sdata = (DataTable)Session["hiearchy"];
                for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
                {
                    dr = sdata.NewRow();
                    dr["empcode"] = (ds.Tables[1].Rows[i]["approverid"] != null) ? ds.Tables[1].Rows[i]["approverid"].ToString() : "";
                    dr["name"] = (ds.Tables[1].Rows[i]["name"] != null) ? ds.Tables[1].Rows[i]["name"].ToString() : "";
                    dr["level"] = (ds.Tables[1].Rows[i]["approverpriority"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["approverpriority"].ToString()) : 0;

                    sdata.Rows.Add(dr);
                }
                Session["hiearchy"] = sdata;
                bindapprovallist();
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void create_approver_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("empcode", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["empcode"] };
        dtable.Columns.Add(new DataColumn("name", typeof(string)));
        dtable.Columns.Add(new DataColumn("level", typeof(int)));
        Session["hiearchy"] = dtable;
    }


    protected void createhiearchy()
    {
        if (Session["hiearchy"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["hiearchy"];
            dview = new DataView(dtable);
            dview.Sort = "level";
        }
    }
    protected void bindapprovallist()
    {
        dtable = (DataTable)Session["hiearchy"];
        dview = new DataView(dtable);
        dview.Sort = "level";
        approvalgrid.DataSource = dview;
        approvalgrid.DataBind();
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("editemployeeleaveprofile.aspx");
    }

}
