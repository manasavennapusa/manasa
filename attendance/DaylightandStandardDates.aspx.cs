using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class attendance_DaylightandStandardDates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Bind();
    }

    void Bind()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select id, datetype, convert(varchar(11),fromdate,101) fromdate, convert(varchar(11),todate,101) todate, status from tbl_attendance_std_daylight_dates where status = 1";

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        grid.DataSource = dt;
                        grid.DataBind();
                    }
                    else
                    {
                        grid.DataSource = null;
                        grid.DataBind();
                    }
                }
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Page.Validate("v");

        if (Page.IsValid)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;


                    cmd.CommandText = @"
                        if exists ( select 1 from tbl_attendance_std_daylight_dates where @fromdate between fromdate and todate)
                          return;
 
                        if exists ( select 1 from tbl_attendance_std_daylight_dates where @todate between fromdate and todate)
                          return;
 
                        INSERT INTO tbl_attendance_std_daylight_dates (datetype, fromdate, todate, status) values ( @datetype, @fromdate, @todate, @status )";

                    cmd.Parameters.Add("@datetype", SqlDbType.VarChar, 2).Value = ddlDateType.SelectedValue;
                    cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtFromDate.Text;
                    cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = txttodate.Text;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = true;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = hdnId.Value;

                    IAsyncResult res = cmd.BeginExecuteNonQuery(null, null);

                    if (res.IsCompleted)
                    {

                    }

                    int flag = cmd.EndExecuteNonQuery(res);

                    Bind();
                    reset();
                }
            }
        }

    }
   
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = (int)grid.DataKeys[e.RowIndex].Value;

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"delete from tbl_attendance_std_daylight_dates where id = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();

                Bind();

            }
        }
    }
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void reset()
    {
        txtFromDate.Text = "";
        txttodate.Text = "";
        ddlDateType.SelectedValue = "ST";
    }
}