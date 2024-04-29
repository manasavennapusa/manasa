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

public partial class InformationCenter_VisionMission : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId;

    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();

        if (!IsPostBack)
        {
            if (Request.QueryString["updated"] == "true")
            {
                Output.Show("Updated Sucessfully");
            }

            if (Request.QueryString["create"] == "true")
            {
                Output.Show("Created Sucessfully");
            }

            lblhead.Text = "Create";
            if (Session["empcode"] != null && Session["companyid"] != null)
            {

            }


            else
            {
                Response.Redirect("~/notlogged.aspx");
            }
        }
       
        BindEmployeeGrid();   
    }

    protected void BindEmployeeGrid()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        try
        {
            string query = @"select ID,type,Heading,descs from tbl_information_vision_mission where status='1'";

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
  
    protected void btnreset_Click(object sender, EventArgs e)
    {
        claer();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (ViewState["id"] != null)
        {           
            lblhead.Text = "Edit";          
            UpdateGender(Convert.ToInt32(ViewState["id"]));
        }
        else
        {
            Insert_Create_Training();
            lblhead.Text = "Create";
        }
        BindEmployeeGrid();
        claer();
    }
    protected void grid_vision_PreRender(object sender, EventArgs e)
    {
        if (grid_vision.Rows.Count > 0)
            grid_vision.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void grid_vision_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.Visible = false;
        int id = Convert.ToInt32(grid_vision.DataKeys[e.NewEditIndex].Value);
        BindTbl(id);
        ViewState["id"] = id;
        btnsubmit.Text = "Update";
        btnreset.Text = "Cancel";
        lblhead.Text = "Edit";
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
            Output.AssignParameter(parm, 0, "@type","Int",0,ddl_type.SelectedValue);
            Output.AssignParameter(parm, 1, "@Heading", "String", 100, txt_heading.Text);
            Output.AssignParameter(parm, 2, "@descs", "String", 500, txt_desc.Text);
            Output.AssignParameter(parm, 3, "@cretaed_by", "String", 50, _userCode.ToString());

            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_information_insert_vision", parm);    
        }
        catch (Exception ex)
        {           
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Data not Saved. Please contact system admin. For error details please go through the log file.");
        }

        finally
        {
            Activity.CloseConnection();
            //Output.Show("Created successfully.");
            Response.Redirect("VisionMission.aspx?create=true");
        }

    }
    protected void claer()
    {
        lblhead.Text = "Create";
        ddl_type.SelectedValue ="0";
        txt_desc.Text = "";
        txt_heading.Text = "";
        Response.Redirect("VisionMission.aspx");
    }
    protected void grid_vision_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DeleteingGender(Convert.ToInt32(grid_vision.DataKeys[e.RowIndex].Value));
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
            
            string query = "update tbl_information_vision_mission set status=0 where ID=" + id + "";         
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
            Output.Show("Deleted Successfully");
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
            string query = "select * from  tbl_information_vision_mission where Id=" + id + "";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_type.SelectedValue = ds.Tables[0].Rows[0]["type"].ToString();
                txt_heading.Text = ds.Tables[0].Rows[0]["Heading"].ToString();
                txt_desc.Text = ds.Tables[0].Rows[0]["descs"].ToString();
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

            string query = @"update tbl_information_vision_mission set type='" + ddl_type.SelectedValue.ToString() + "', Heading='" + txt_heading.Text.Trim() + "',descs='"+txt_desc.Text.Trim()+"' where ID =" + id + "";
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
            //Output.Show("Updated Successfully");
            BindEmployeeGrid();
           // claer();
            Response.Redirect("VisionMission.aspx?updated=true");
        }
    }
}