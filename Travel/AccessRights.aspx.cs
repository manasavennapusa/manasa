using System;
using System.Collections.Generic;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Travel_AccessRights : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    int c;
    DataTable dtable = new DataTable();
    DataView dview;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            Session.Remove("hiearchy");

        }
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        insert_approver();

        if (Session["hiearchy"] != null)
            btn_resetgrid.Visible = true;
        else
            btn_resetgrid.Visible = false;
    }

    protected void create_approver_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("empcode", typeof(string));
        dtable.Columns.Add(new DataColumn("name", typeof(string)));
        dtable.Columns.Add(new DataColumn("level", typeof(int)));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["empcode"] };
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

    protected void insert_approver()
    {
        DataRow dr;
        string level;
        level = hiddenlevel.Value;

        if (Session["hiearchy"] == null)
        {
            create_approver_table();
        }
        dtable = (DataTable)Session["hiearchy"];
        object[] keyArrary = new object[1];
        keyArrary[0] = "1";//txt_approver.Text;

        DataRow drfind = dtable.Rows.Find(keyArrary);
        if (drfind != null)
        {
            message.InnerHtml = "Approver already added.";
        }
        else
        {
            dr = dtable.NewRow();

            if (dtable.Rows.Count > 0)
            {
                hiddenlevel.Value = Convert.ToString(Convert.ToInt32(level) + 1);
            }

            dr["name"] = hidd_name.Value;
            dr["empcode"] = "";//txt_approver.Text;
            dr["level"] = hiddenlevel.Value;
            dtable.Rows.Add(dr);
        }
       // txt_approver.Text = "";
        Session["hiearchy"] = dtable;

        bindapprovallist();
    }
    protected void btn_greset_Click(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        Session.Remove("hiearchy");
        approvalgrid.DataSource = null;
        approvalgrid.DataBind();
        hiddenlevel.Value = "1";
        if (Session["hiearchy"] != null)
            btn_resetgrid.Visible = true;
        else
            btn_resetgrid.Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        insertApprovers();
    }
    protected void insertApprovers()
    {
        int cnt = 0;
        if (Session["hiearchy"] != null)
        {
            dtable = (DataTable)Session["hiearchy"];
            if (dtable.Rows.Count > 0)
            {
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    SqlParameter[] sqlparam = new SqlParameter[6];

                    sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparam[0].Value = //txt_employee.Text;

                    sqlparam[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
                    sqlparam[1].Value = dtable.Rows[i]["empcode"].ToString();

                    sqlparam[2] = new SqlParameter("@level", SqlDbType.Int);
                    sqlparam[2].Value = Convert.ToInt32(dtable.Rows[i]["level"]);

                    sqlparam[3] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
                    sqlparam[3].Value = ddl_traveltype.SelectedValue;

                    sqlparam[4] = new SqlParameter("@workflow", SqlDbType.VarChar, 30);
                    sqlparam[4].Value = ddl_approversfor.SelectedValue;

                    sqlparam[5] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                    sqlparam[5].Value = Session["empcode"].ToString();

                    cnt = cnt + DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_ApproverHierarchy", sqlparam);

                }
                if (cnt > 0)
                {
                    Clear();
                    SmartHr.Common.Alert("Data Saved Successfully.");
                }
                else
                {
                    SmartHr.Common.Alert("Data not saved.");
                }
            }
            else
            {
                SmartHr.Common.Alert("Add Atleast One Approver");
            }
        }
        else
        {
            SmartHr.Common.Alert("Add Atleast One Approver");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void Clear()
    {
       // txt_approver.Text = "";
        //txt_employee.Text = "";
        ddl_approversfor.SelectedValue = "0";
        ddl_traveltype.SelectedValue = "0";
        Session.Remove("hiearchy");
        approvalgrid.DataSource = null;
        approvalgrid.DataBind();
        btn_resetgrid.Visible = false;
    }
}