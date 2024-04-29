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
using DataAccessLayer;

public partial class admin_costcentergroup : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
        //bind_CCgroup();
    }
    protected void btnAddCostCenterGroup_Click(object sender, EventArgs e)
    {
        insert_costcentergroup();
    }
    protected void insert_costcentergroup()
    {
        SqlParameter[] sqlParam = new SqlParameter[6];

        sqlParam[0] = new SqlParameter("@cost_center_group_name", SqlDbType.VarChar, 100);
        sqlParam[0].Value = txt_costcentergroup.Text;

        sqlParam[1] = new SqlParameter("@status", SqlDbType.Bit);
        sqlParam[1].Value = true;

        sqlParam[2] = new SqlParameter("@create_by", SqlDbType.VarChar, 10);
        sqlParam[2].Value = Session["empcode"].ToString();

        sqlParam[3] = new SqlParameter("@create_date", SqlDbType.DateTime);
        sqlParam[3].Value = DateTime.Now;

        sqlParam[4] = new SqlParameter("@modified_by", SqlDbType.VarChar, 10);
        sqlParam[4].Value = System.Data.SqlTypes.SqlString.Null;

        sqlParam[5] = new SqlParameter("@modified_date", SqlDbType.DateTime);
        sqlParam[5].Value = System.Data.SqlTypes.SqlDateTime.Null;


        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_costcentergroup]", sqlParam);
        if (i <= 0)
        {
            message.InnerHtml = "cost center group name already exists, please enter another name";
        }
        else
        {
            message.InnerHtml = "cost center group name created successfully";
            reset();
        }
        //  bind_CCgroup();
    }
    protected void reset()
    {
        txt_costcentergroup.Text = "";

    }
    //protected void bind_CCgroup()
    //{
    //    sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;
    //    Grid_CostcenterGroup.DataSource = ds;
    //    Grid_CostcenterGroup.DataBind();

    //}


}
