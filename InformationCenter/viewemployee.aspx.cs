using Common.Console;
using Common.Data;
using Common.Encode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class informationcenter_viewemployee : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {

            }
           
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
        bind_viewemployee();
    }
    protected void Grid_employeefeedbacksurvey_PreRender(object sender, EventArgs e)
    {
        if (Grid_employeefeedbacksurvey.Rows.Count > 0)
        {
            Grid_employeefeedbacksurvey.UseAccessibleHeader = true;
            Grid_employeefeedbacksurvey.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }


    protected void bind_viewemployee() 
    {

     try
        {
            connection = activity.OpenConnection();           
           
            string sqlstr = @"select pd.empcode,pd.f_fname,fb.createdby,fb.id  from dbo.tbl_intranet_employee_personalDetails pd inner join dbo.tbl_informationemployeefeedback fb on fb.createdby=pd.empcode";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
          
            Grid_employeefeedbacksurvey.DataSource = ds1;
            Grid_employeefeedbacksurvey.DataBind();
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

    //protected string linkreset(string id)
    //{
    //    QueryString q = new QueryString();
    //    string pairs = String.Format("empcode={0}", id.Trim());
    //    string encoded;
    //    encoded = q.EncodePairs(pairs);
    //    return "<a class='link05' href='ResetPassword.aspx?q=" + encoded + "' >Reset</a>";
    //}


}