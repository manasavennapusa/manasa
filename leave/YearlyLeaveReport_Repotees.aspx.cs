using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Leave_YearlyLeaveReport_Repotees : System.Web.UI.Page
{
    string empcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            empcode = Session["empcode"].ToString();
           
            GetLeaveCalender();
        }
    }

    void GetLeaveCalender()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        conn.Open();

        if (conn.State == ConnectionState.Open)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"

select 
id,
periodname,
fromdate,
todate
from tbl_leave_leaveperiod
where status = 1";

            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds);

            ViewState["ActiveCalenderYear"] = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLeaveCalender.DataSource = ds.Tables[0];
                ddlLeaveCalender.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                ddlLeaveCalender.DataTextField = ds.Tables[0].Columns[1].ColumnName;
                ddlLeaveCalender.DataBind();
            }
        }

        InsertAtPositionZero(ddlLeaveCalender);
    }

    void InsertAtPositionZero(System.Web.UI.WebControls.DropDownList ddl)
    {
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        Page.Validate("v");

        empcode = Session["empcode"].ToString();

        if (Page.IsValid)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open('YearlyLeaveReport_ReporteesDetails.aspx?PolicyId=" + ddlPolicy.SelectedValue + "&Leave=" + ddlLeaveType.SelectedValue + "&Calander=" + ddlLeaveCalender.SelectedValue + "&CalanderName=" + ddlLeaveCalender.SelectedItem.Text + "&LeaveName=" + ddlLeaveType.SelectedItem.Text + "', null, 'height=600,width=1260,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }
    }
}