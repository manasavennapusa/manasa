using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;


public partial class appraisal_BehaviorColorCoding : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
    protected void bindgrid()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            string str = @"select * from tbl_appraisal_behaviorpattren; select count(*) from tbl_appraisal_behaviorpattren";
            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            grdcolor.DataSource = ds;
            grdcolor.DataBind();
            for (int i = 0; i < 5; i++)
            {
                if (i == 1)
                {
                    grdcolor.Rows[i].Enabled = true;
                }
                else
                    grdcolor.Rows[i].Enabled = false;
            }

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    
    protected void btn_Unaccetable_Command(object sender, CommandEventArgs e)
    {
        
        string color = e.CommandArgument.ToString();
        lblpreformance.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
    }

    protected void grdcolor_PreRender(object sender, EventArgs e)
    {
        if (grdcolor.Rows.Count > 0)
            grdcolor.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
  
