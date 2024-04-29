using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


/// <summary>
/// Summary description for Common
/// </summary>
namespace SmartHr
{
    public class Common
    {
        public Common()
        {

        }

        public static void Alert(string error)
        {

            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }

        public static string AdminSection(string roleCode)
        {
            string Menu = "";
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@roleCode", roleCode);
                param[1] = new SqlParameter("@adminsection", SqlDbType.VarChar, 4000);
                param[1].Direction = ParameterDirection.Output;

                int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.StoredProcedure, "getadminsection", param);

                if (param[1].Value != null)
                {
                    Menu = param[1].Value.ToString();
                }
            }
            catch
            {

            }
            finally
            {

            }

            return Menu;

        }
        public static string GetMenu(string empCode, string roleCode,int modCode)
        {
            string Menu = "";
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@userCode", empCode);
                param[1] = new SqlParameter("@roleCode", roleCode);
                param[2] = new SqlParameter("@modCode", modCode);
                param[3] = new SqlParameter("@menu", SqlDbType.VarChar, 2147483647);
                param[3].Direction = ParameterDirection.Output;

                DataSet flag = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.StoredProcedure, "getmenu", param);
                if (flag.Tables[0].Rows.Count > 0)
                {
                    DataRow row = flag.Tables[0].Rows[0];
                    Menu = row["menu"].ToString();                       
                }               
            }
            catch
            {

            }
            finally
            {

            }
            return Menu;
        }
    }
}
