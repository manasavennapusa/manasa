using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
public partial class attendance_updateshift : System.Web.UI.Page
{
    string CompanyId, UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null && Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                bindshift();
            }
            this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime'))");
            this.Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime'))");
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }

    //====================  Created by Ramu nunna on 17-9-2014 Purpose of Update shift =============================
    protected void imgtime_Click(object sender, ImageClickEventArgs e)
    {
        this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime').toString())");
        this.Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime').toString())");
    }
    #region Bind Shifts
    public void bindshift()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "select shiftid,shiftname,branch_id,  right(convert(varchar(50),starttime),7)starttime, right(convert(varchar(50),endtime),7)endtime, shift_description from tbl_leave_shift where shiftid=" + Request.QueryString["shiftid"].ToString() + "";
            DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddbranch_id.SelectedValue = ds.Tables[0].Rows[0]["branch_id"].ToString();
                txtshift.Text = ds.Tables[0].Rows[0]["shiftname"].ToString();
                txtstime.Text = ds.Tables[0].Rows[0]["starttime"].ToString();
                txtetime.Text = ds.Tables[0].Rows[0]["endtime"].ToString();
                txtshiftDesc.Text = ds.Tables[0].Rows[0]["shift_description"].ToString();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("No Data Found. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }


    }
    #endregion

    #region Update Shift Details
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["shiftid"]);


        SqlParameter[] parm = new SqlParameter[8];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@shiftname", "String", 100, txtshift.Text.ToString());
            Output.AssignParameter(parm, 1, "@shiftid", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 2, "@branch_id", "Int", 0, ddbranch_id.SelectedValue.ToString());
            Output.AssignParameter(parm, 3, "@starttime", "DateTime", 0, "1900-01-01 " + txtstime.Text.ToString());
            Output.AssignParameter(parm, 4, "@endtime", "DateTime", 0, "1900-01-01 " + txtetime.Text.ToString());
            Output.AssignParameter(parm, 5, "@modifieddate", "DateTime", 0, DateTime.Now.ToString());
            Output.AssignParameter(parm, 6, "@modifiedby", "String", 100, UserCode);
            Output.AssignParameter(parm, 7, "@shift_description", "String", 200, txtshiftDesc.Text.ToString());
            Connection = Activity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_leave_updateshift", parm);
            _Transaction.Commit();
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
        }
        if (Flag > 0)
        {
            Response.Redirect("createshift.aspx?updated=true");
        }
        else
        {
            Output.Show("Shift Type already exists, try again");
        }




    }

    public void clear()
    {
        txtshift.Text = "";
        txtetime.Text = "";
        txtstime.Text = "";
        txtshiftDesc.Text = "";
    }
    protected void btncncl_Click(object sender, EventArgs e)
    {
        Server.Transfer("editshift.aspx");
        //Response.Redirect("editshift.aspx");
    }
    #endregion
}