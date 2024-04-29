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
using Common.Console;

public partial class InformationCenter_jobdescriptation : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                BindEmployeeGrid();
            }

        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        if (ViewState["id"] != null)
        {
            UpdateGender(Convert.ToInt32(ViewState["id"]));
        }
        else
        {
            Insert_Create_Training();
        }
        BindEmployeeGrid();
        reset();
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void grid_vision_PreRender(object sender, EventArgs e)
    {
        if (grid_vision.Rows.Count > 0)
            grid_vision.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void grid_vision_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DeleteingGender(Convert.ToInt32(grid_vision.DataKeys[e.RowIndex].Value));
    }
    protected void grid_vision_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = Convert.ToInt32(grid_vision.DataKeys[e.NewEditIndex].Value);
        BindTbl(id);
        ViewState["id"] = id;
        btnsubmit.Text = "Update";
    }

    protected void reset()
    {
        txt_job_summary.Text = "";
        txt_requ.Text = "";
        txt_Resp.Text = "";
    }

    protected void BindEmployeeGrid()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        try
        {
            string query = @"select id, job_summary,job_reposability,job_requirement from tbl_Information_job where status='1'";

            DataSet dspay = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            grid_vision.DataSource = dspay;
            grid_vision.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Data not Binding. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
    }

    protected void Insert_Create_Training()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        try
        {
            Connection = Activity.OpenConnection();

            SqlParameter[] parm = new SqlParameter[4];
            Output.AssignParameter(parm, 0, "@job_summary", "String", 500, txt_job_summary.Text);
            Output.AssignParameter(parm, 1, "@job_reposability", "String", 1000, txt_Resp.Text);
            Output.AssignParameter(parm, 2, "@job_requirement", "String", 1000, txt_requ.Text);
            Output.AssignParameter(parm, 3, "@created_by", "String", 50, _userCode.ToString());

            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_information_job_insert", parm);
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Data not Saved. Please contact system admin. For error details please go through the log file.");
        }

        finally
        {
            Activity.CloseConnection();
            Common.Console.Output.Show("Job Description is created successfully.");
        }

    }

    protected void DeleteingGender(int id)
    {
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Connection = Activity.OpenConnection();

            string query = "update tbl_Information_job set status=0 where id=" + id + "";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
            Output.Show("Job Description Deleted Successfully");
            BindEmployeeGrid();
        }
    }

    protected void BindTbl(int id)
    {
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        SqlConnection Connection = null;
        DataSet ds = new DataSet();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "select * from  tbl_Information_job where id=" + id + "";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_job_summary.Text = ds.Tables[0].Rows[0]["job_summary"].ToString();
                txt_requ.Text = ds.Tables[0].Rows[0]["job_requirement"].ToString();
                txt_Resp.Text = ds.Tables[0].Rows[0]["job_reposability"].ToString();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
    }

    protected void UpdateGender(int id)
    {
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        SqlConnection Connection = null;       
        try
        {
            Connection = Activity.OpenConnection();

            string query = @"update tbl_Information_job set job_summary='" +txt_job_summary.Text.Trim()+ "', job_reposability='" + txt_Resp.Text.Trim() + "',job_requirement='" + txt_requ.Text.Trim() + "' where id =" + id + "";
            //   Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, query);
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
            Output.Show("Job Description Updated Successfully");
            BindEmployeeGrid();
            reset();
        }
    }
}