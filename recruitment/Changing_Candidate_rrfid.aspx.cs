using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using DataAccessLayer;

public partial class recruitment_Changing_Candidate_rrfid : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr, emp_code;
    string qry;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            emp_code = Session["empcode"].ToString();

            if (!IsPostBack)
            {

                Bindgrid();
            }
        }
       else
             Response.Redirect("~/notlogged.aspx");
    }
    private void Bindgrid()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select distinct  c.id as candidateid,c.rrf_id,r.rrf_code,d.designationname,c.candidate_name,c.dob,c.candidate_address,c.phone,c.mobile,c.emailid,c.Qualification,c.skills,c.experience,c.expectedsalary,c.joinstatus,c.referredby,c.referrername,c.achievements,c.uploadresume,c.passportno,c.passportvalidity,c.note,c.relation_to_referrer,c.reasons_of_referrence from tbl_recruitment_candidate_registration c inner join tbl_recruitment_requisition_form r on r.id=c.rrf_id inner join dbo.tbl_intranet_designation d on r.designationid=d.id  where  r.status=1 and c.rrf_id is not null";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;

            GridView1.DataSource = ds;
            GridView1.DataBind();
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

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bindgrid();// your gridview binding function
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddList = (DropDownList)e.Row.FindControl("ddlrrf");
                //bind dropdown-list
                connection = activity.OpenConnection();
                string sqlstr = "select id,rrf_code from tbl_recruitment_requisition_form where status=1";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                ddList.DataSource = ds;
                ddList.DataTextField = "rrf_code";
                ddList.DataValueField = "id";
                ddList.DataBind();

                DataRowView dr = e.Row.DataItem as DataRowView;
                //ddList.SelectedItem.Text = dr["category_name"].ToString();
                ddList.SelectedValue = dr["rrf_id"].ToString();
            }
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int rowno = e.RowIndex;
        GridViewRow gvr = GridView1.Rows[rowno];

        DropDownList ddltype = gvr.FindControl("ddlrrf") as DropDownList;

        Label cid = gvr.FindControl("lblCID") as Label;
      
        
        int rrfid = Convert.ToInt32(ddltype.SelectedValue);
        string rrfcode = ddltype.SelectedItem.ToString();



        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@rrf_code", SqlDbType.VarChar, 50);
        sqlparam[0].Value = rrfcode;


        sqlparam[1] = new SqlParameter("@candidateid", SqlDbType.Int);
        sqlparam[1].Value = Convert.ToInt32(cid.Text);

        sqlparam[2] = new SqlParameter("@rrfid", SqlDbType.Int);
        sqlparam[2].Value = rrfid;

        // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_role", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_RRFID]", sqlparam);


        if (i <= 0)
        {
            Output.Show("RRF already Exist!!!");
        }
        else
        {

            Output.Show("Updated Sucessfully!!!");

        }

        GridView1.EditIndex = -1;

        Bindgrid();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        e.Cancel = true;
        Bindgrid();
       

    }
}