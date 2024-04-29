using Common.Console;
using Common.Data;
using DataAccessLayer;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;

public partial class lagout : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection _Connection = new SqlConnection();
    SqlCommand cmd = null;
    DataSet ds = null;
    string _companyId, _userCode, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["empcode"]==null)
        //    Response.Redirect("~/notlogged.aspx");
        //_userCode = Session["empcode"].ToString();
        //_companyId = Session["companyid"].ToString();

        if (Session["empcode"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
        }
        else
            Response.Redirect("~/notlogged.aspx");


        lagouttime();
        Session.Remove("empcode");
        Session.Remove("login");
        Session.Remove("role");
        Session.Remove("rolename");
        Session.Remove("status");
        Session.Remove("AdminSection");
        //Session["name"] = ds.Tables[0].Rows[0]["name"].ToString();
        //Session["login"] = ds.Tables[0].Rows[0]["login_id"].ToString();
        //Session["role"] = ds.Tables[0].Rows[0]["role"].ToString();
        //Session["rolename"] = ds.Tables[0].Rows[0]["rolename"].ToString();
        //Session["status"] = ds.Tables[0].Rows[0]["status"].ToString();
        //Session["photo"] = ds.Tables[0].Rows[0]["Photo"].ToString();
        //Session["branch"] = ds.Tables[0].Rows[0]["branch_id"].ToString();
        //Session["AdminSection"] = SmartHr.Common.AdminSection(Session["role"].ToString());
        //Session["OfficialEmailId"] = ds.Tables[0].Rows[0]["official_email_id"].ToString();
        Response.Redirect("Default.aspx");

    }

    protected void lagouttime()
    {
        try
        {
            _Connection = activity.OpenConnection();
            SqlParameter[] parm = new SqlParameter[3];
            Output.AssignParameter(parm, 0, "@USERID", "String", 50, _userCode.ToString());
            Output.AssignParameter(parm, 1, "@COMMAND", "Int", 0, "1");
            Output.AssignParameter(parm, 2, "@Company_id", "Int", 0, _companyId.ToString());

            ds = SQLServer.ExecuteDataset(_Connection, CommandType.StoredProcedure, "SP_TRACK_Update_USERLOG", parm);

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
}