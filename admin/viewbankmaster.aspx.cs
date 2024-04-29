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
using System.Reflection;
using System.Collections.Generic;
using System.Data.Sql;

using System.Data.SqlClient;

public partial class payroll_admin_viewbankmaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
          
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (Request.QueryString["message"] != null)
        {
            if(Request.QueryString["message"].ToString()!="")
            SmartHr.Common.Alert(Request.QueryString["message"].ToString());
        }
           
    }
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        if (bankgird.Rows.Count > 0)
        {
            bankgird.UseAccessibleHeader = true;
            bankgird.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    #region GetSqlConnection
    /// <summary>
    /// GetSqlConnection
    /// </summary>
    /// <returns>SqlConnection</returns>
    private static SqlConnection GetSqlConnection()
    {
        string connString =
            ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString;
        return new SqlConnection(connString);
    }
    #endregion

    #region GetSqlCommand
    /// <summary>
    /// GetSqlCommand
    /// </summary>
    /// <param name="conn">SqlConnection</param>
    /// <param name="key">Key</param>
    /// <returns>SqlCommand</returns>
    private static SqlCommand GetSqlCommand(SqlConnection conn, string key, int count)
    {
        string commandText =
            @"SELECT TOP " + count.ToString() + " emp_fname FROM tbl_intranet_employee_jobDetails WHERE emp_fname LIKE '" + key + "%'";
        SqlCommand comm = new SqlCommand(commandText, conn);
        comm.CommandType = CommandType.Text;
        return comm;
    }
    #endregion

    #region GetCompletionList
    /// <summary>
    /// GetCompletionList
    /// </summary>
    /// <param name="prefixText">search text</param>
    /// <param name="count">no of matches to display</param>
    /// <returns>string[] of matching names</returns>
    [System.Web.Services.WebMethod]
    public static string[] GetCompletionList(String prefixText, int count)
    {
        List<String> suggetions = GetSuggestions(prefixText, count);
        return suggetions.ToArray();
    }
    #endregion

    #region GetSuggestions
    /// <summary>
    /// GetSuggestions
    /// </summary>
    /// <param name="key">Country Names to search</param>
    /// <returns>Country Names Similar to key</returns>
    private static List<String> GetSuggestions(string key, int count)
    {
        List<String> suggestions = new List<string>();
        DataTable dtSuggestions = new DataTable();

        using (SqlConnection conn = GetSqlConnection())
        {
            conn.Open();

            using (SqlCommand comm = GetSqlCommand(conn, key, count))
            {
                SqlDataAdapter adptr = new SqlDataAdapter(comm);
                adptr.Fill(dtSuggestions);
            }
        }

        if (dtSuggestions != null
            && dtSuggestions.Rows != null
            && dtSuggestions.Rows.Count > 0)
        {
            foreach (DataRow dr in dtSuggestions.Rows)
            {
                string suggestion = dr["emp_fname"].ToString();
                suggestions.Add(suggestion);
            }
        }

        return suggestions;
    }
    #endregion
}
