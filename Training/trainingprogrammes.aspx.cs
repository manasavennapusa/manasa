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
using Common.Encode;
using Common.Data;
using Common.Console;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class training_trainingprogrammes : System.Web.UI.Page
{
      string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
           message.InnerHtml = "";
           if (!IsPostBack)
           {
               if (Session["empcode"] != null)
               {

               }
               else
               {
                   Response.Redirect("~/notlogged.aspx");
               }
               bind_trainingname();
               bind_trainingprogrammes();
           }
    }
    protected void Grid_trainingprogrammes_PreRender(object sender, EventArgs e)
    {
        if (Grid_trainingprogrammes.Rows.Count > 0)
        {
            Grid_trainingprogrammes.UseAccessibleHeader = true;
            Grid_trainingprogrammes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btn_select_Click(object sender, EventArgs e)
    {

    }
    protected void btn_deselect_Click(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {

    }
    protected void btn_back_Click(object sender, EventArgs e)
    {

    }

    protected void bind_trainingprogrammes()
    {
         try
        {
            connection = activity.OpenConnection();
            //sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' order by department_name";
            sqlstr = "select id,training_code,module_name,bachcode,training_name,training_type from tbl_training_shedulee";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 1)
            {
                return;
            }
            //drpdepartment.DataTextField = "department_name";
            //drpdepartment.DataValueField = "departmentid";
            Grid_trainingprogrammes.DataSource = ds1;
            Grid_trainingprogrammes.DataBind();
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

    protected void ddl_training_name_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void bind_trainingname()
    {
        string sqlstr = "select training_name from tbl_training_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddl_training_name.DataTextField = "training_name";
        //ddl_trainingname.DataValueField = "id";
        ddl_training_name.DataSource = ds;
        ddl_training_name.DataBind();
        ddl_training_name.Items.Insert(0, new ListItem("---Select---", "0"));

    }


}