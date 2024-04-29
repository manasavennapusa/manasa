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

public partial class Travel_EditEmployeeApprover : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            if (Request.QueryString["id"] != null)
            {
                bindGrid();
            }
        }
        if (Request.QueryString["id"] != null)
        {
            bindGrid();
        }
    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Request.QueryString["id"].ToString();

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_viewApproveDetails", param);
        empgird.DataSource = ds;
        empgird.DataBind();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = lbl_empname.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        sqlparam[1].Value = lblTraveltype.Text.ToString();

        sqlparam[2] = new SqlParameter("@workflow", SqlDbType.VarChar, 30);
        sqlparam[2].Value = lblApproverfor.Text.ToString();

        sqlparam[3] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
        sqlparam[3].Value = txt_employee.Text;

        sqlparam[5] = new SqlParameter("@level", SqlDbType.Int);
        sqlparam[5].Value = lblLevel.Text;

        sqlparam[4] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[4].Value = lblid.Text;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_updateApprover", sqlparam);

        if (i <= 0)
        {

        }
        else
        {
            message.InnerHtml = "Approver updated successfully";
            reset();
            bindGrid();
            //Response.Redirect("EditEmployeeApprover.aspx?updated=true");            
            gridview.Visible = true;
            editapprovers.Visible = false;
        }

    }

    protected void reset()
    {
        txt_employee.Text = "";
    }

    protected void empgird_PreRender(object sender, EventArgs e)
    {
        if (empgird.Rows.Count > 0)
        {
            empgird.UseAccessibleHeader = true;
            empgird.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void empgird_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridview.Visible = false;
        editapprovers.Visible = true;
        // edit.Visible = true;
        string sqlstr = "select id, empcode,traveltype,workflow,approvercode,level from tbl_travel_ApproverHirarchy where id = " + empgird.DataKeys[e.NewEditIndex].Value.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_empname.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            //lblTraveltype.Text = ds.Tables[0].Rows[0]["traveltype"].ToString();
            if (ds.Tables[0].Rows[0]["traveltype"].ToString() == "I")
            {
                lblTraveltype.Text = "International";
            }
            else
            {
                lblTraveltype.Text = "Domestic";
            }
            lblApproverfor.Text = ds.Tables[0].Rows[0]["workflow"].ToString();
            lblLevel.Text = ds.Tables[0].Rows[0]["level"].ToString();
            txt_employee.Text = ds.Tables[0].Rows[0]["approvercode"].ToString();
            lblid.Text = ds.Tables[0].Rows[0]["id"].ToString();
        }

    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEditApprovers.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
        gridview.Visible = true;
        editapprovers.Visible = false;
    }
}