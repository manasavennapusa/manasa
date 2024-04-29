using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class payroll_admin_calculate_gratuity : System.Web.UI.Page
{
    string connStr = string.Empty;
    string empcode = string.Empty;

    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString();
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        BindGratuity();
    }

    protected void BindGratuity()
    {
        empcode = txt_employee.Text.Trim();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_calculate_graduity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode",empcode);
            da.SelectCommand = cmd;
            conn.Open();

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblgraduityAmount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
              //  lblLast10basic.Text = ds.Tables[0].Rows[0]["last_10_basic"].ToString();
              //  lblMaxExmption.Text = ds.Tables[0].Rows[0]["max_exmption"].ToString();
            }
            else
            {
                lblgraduityAmount.Text = "0.00";
                lblLast10basic.Text = "0.00";
                lblMaxExmption.Text = "0.00";
            }
          
        }
    }
}
