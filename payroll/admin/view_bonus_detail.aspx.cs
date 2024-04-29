using System;
using System.Data;
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

public partial class payroll_admin_view_bonus_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;
    DataTable dtable = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        bind_reimbursement();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");

            Session.Remove("aleave");
        }
    }

    protected void bind_reimbursement()
    {
        sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@bonus_id", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Request.QueryString["bonus_id"].ToString();

        sqlparam[1] = new SqlParameter("@id", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Request.QueryString["id"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_bonus_detail", sqlparam);
        lbl_amount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
        lbl_bonus.Text = ds.Tables[0].Rows[0]["payhead_name"].ToString();
        lbl_detail.Text = ds.Tables[0].Rows[0]["detail"].ToString();
        lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_ref.Text = ds.Tables[0].Rows[0]["bonus_ref_no"].ToString();
        lbl_sanction.Text = ds.Tables[0].Rows[0]["sanction_date"].ToString();
       
        
        if (Session["aleave"] == null)
        {
            createatable();
        }
        DataRow dr;
        DataTable sdata;

        sdata = (DataTable)Session["aleave"];

        for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
        {
            dr = sdata.NewRow();
            dr["month"] = (ds.Tables[1].Rows[i]["month"] != null) ? ds.Tables[1].Rows[i]["month"].ToString() : "";
            dr["year"] = (ds.Tables[1].Rows[i]["year"] != null) ? ds.Tables[1].Rows[i]["year"].ToString() : "";
            dr["amount"] = (ds.Tables[1].Rows[i]["disperse_amount"] != null) ? ds.Tables[1].Rows[i]["disperse_amount"].ToString() : "";
            sdata.Rows.Add(dr);
        }
        Session["aleave"] = sdata;
        bindadjustleave();
        

    }
    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("month", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["month"] };
        dtable.Columns.Add("amount", typeof(string));
        dtable.Columns.Add("year", typeof(string));
        Session["aleave"] = dtable;
    }
    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["aleave"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();
    }
}
