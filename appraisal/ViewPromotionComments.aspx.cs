using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Appraisal_ViewPromotionComments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadComments();
    }

    void LoadComments()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
//                cmd.CommandText = @"select hc.empcode, j.emp_fname, comments, commentdate
// from tbl_appraisal_promotion_comments hc
//  inner join tbl_appraisal_promotion h on hc.promotionid = h.id
//  left join tbl_intranet_employee_jobDetails j on hc.empcode = j.empcode
//   where h.assessmentid = @assessmentid";

                cmd.CommandText = @"select hc.empcode, j.emp_fname, hc.comments, hc.commentdate,hc.BH_comment,hc.BH_created_date
 from tbl_appraisal_promotion_comments hc
  inner join tbl_appraisal_promotion h on hc.promotionid = h.id  and h.APP_year=hc.APP_year
  and hc.empcode=h.empcode and h.appcycle_id =hc.appcycle_id
  left join tbl_intranet_employee_jobDetails j on hc.empcode = j.empcode
   where h.assessmentid = @assessmentid";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@assessmentid", SqlDbType.Int).Value = Request.QueryString["id"];
                //cmd.Parameters.Add("@empcode", SqlDbType.VarChar,50).Value = Request.QueryString["empcode"];

                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                string str = "";

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rc in dt.Rows)
                    {
                        str += @"<div class='alert alert-block alert-info fade in no-margin' style='border:0px'>
                                                 <p style='color: #428bca; font-size: 13px; font-weight: 400;'>" + rc["emp_fname"] + " on <span style='color: #428bca;font-size: 11px;font-weight: 400;'>" + Convert.ToDateTime(rc["commentdate"]).ToString("dd-MMM-yyyy") + " </span></p><br/><br/><p style='color: #4d4d4d;'> Virtual Head Comments    :    " + rc["comments"] + @" </p><br/><br/><p style='color: #4d4d4d;'> Business Head Comments    :    " + rc["BH_comment"] + @" </p></div><br/>";
                    } 
                }

                divComments.InnerHtml = str;

            }
        }
    }
}