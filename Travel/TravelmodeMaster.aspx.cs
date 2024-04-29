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

public partial class Travel_TravelmodeMaster : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindTravelmode();
            btnupdate.Visible = false;
            btncancel2.Visible = false;
            create1.Visible = true;
            create.Visible = true;
            edit1.Visible = false;
            edit.Visible = false;

            if (Request.QueryString["Id"] != null)
            {
                BindTierdetails();
                btntier.Visible = false;
                btnupdate.Visible = true;
                btncancel.Visible = false;
                edit1.Visible = true;
                edit.Visible = true;
                create1.Visible = false;
                create.Visible = false;
                grid1.Visible = false;
            }

        }
    }

    private void BindTierdetails()
    {
        btncancel2.Visible = true;
        int Tid = Convert.ToInt32(Request.QueryString["Id"]);
        sqlstr = "select travelmode,traveltype,descripetion from tbl_travel_travelmode where status=1 and travelmodeId='" + Tid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txtravelname.Text = ds.Tables[0].Rows[0]["travelmode"].ToString();
        ddl_traveltype.SelectedValue = ds.Tables[0].Rows[0]["traveltype"].ToString();
        txtdesc.Text = ds.Tables[0].Rows[0]["descripetion"].ToString();
    }

    private void bindTravelmode()
    {
         btncancel.Visible = true;
         btncancel2.Visible = false;
         create1.Visible = true;
         create.Visible = true;
         edit1.Visible = false;
         edit.Visible = false;
         grid1.Visible = true;
        
        sqlstr = "select travelmodeId,travelmode,traveltype,descripetion from tbl_travel_travelmode where status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdtravel.DataSource = ds;
        grdtravel.DataBind();     

    }

    protected void btntier_Click(object sender, EventArgs e)
    {
        string empcode = Session["empcode"].ToString();
       
        SqlParameter[] sqlParam = new SqlParameter[6];

        sqlParam[0] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        sqlParam[0].Value = ddl_traveltype.SelectedValue;
        
        sqlParam[1] = new SqlParameter("@travelmode", SqlDbType.VarChar, 50);
        sqlParam[1].Value = txtravelname.Text;

        sqlParam[2] = new SqlParameter("@descripetion", SqlDbType.VarChar, 100);
        sqlParam[2].Value = txtdesc.Text;
        
        sqlParam[3] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[3].Value = "I";
        
        sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[4].Value = empcode;

        sqlParam[5] = new SqlParameter("@travelmodeId", SqlDbType.Int);
        sqlParam[5].Value = 0;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_TravelmodeMaster]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Travel Mode name already exists, please enter another name");
         
        }
        else
        {
            SmartHr.Common.Alert("Travel Mode created Successfully!!!");

            clear();
            bindTravelmode();
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

        int Tid = Convert.ToInt32(Request.QueryString["Id"]);
        //string empcode = Session["empcode"].ToString();

        SqlParameter[] sqlParam = new SqlParameter[6];

        sqlParam[0] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        sqlParam[0].Value = ddl_traveltype.SelectedValue;

        sqlParam[1] = new SqlParameter("@travelmode", SqlDbType.VarChar, 50);
        sqlParam[1].Value = txtravelname.Text;

        sqlParam[2] = new SqlParameter("@descripetion", SqlDbType.VarChar, 100);
        sqlParam[2].Value = txtdesc.Text;

        sqlParam[3] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[3].Value = "U";

        sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[4].Value = Session["empcode"].ToString();

        sqlParam[5] = new SqlParameter("@travelmodeId", SqlDbType.Int);
        sqlParam[5].Value = Tid;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_TravelmodeMaster]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Travel Mode already exists, please enter another name");
            bindTravelmode();
        }
        else
        {
            SmartHr.Common.Alert("Travel Mode Updated Successfully!!!");
            clear();
            bindTravelmode();
            btntier.Visible = true;
            btnupdate.Visible = false;
        }



    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null)
        {
            Response.Redirect("TravelmodeMaster.aspx");
        }
        else
        {
            clear();
        }
    }

    protected void clear()
    {
        txtravelname.Text = "";
        txtdesc.Text = "";
        ddl_traveltype.SelectedValue = "0";
    }

    protected void grdtravel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Tid = Convert.ToInt32(grdtravel.DataKeys[e.RowIndex].Value);
        SqlParameter[] sqlParam = new SqlParameter[6];

        sqlParam[0] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        sqlParam[0].Value = "";

        sqlParam[1] = new SqlParameter("@travelmode", SqlDbType.VarChar, 50);
        sqlParam[1].Value = "";

        sqlParam[2] = new SqlParameter("@descripetion", SqlDbType.VarChar, 100);
        sqlParam[2].Value = "";

        sqlParam[3] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[3].Value = "D";

        sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[4].Value = "";

        sqlParam[5] = new SqlParameter("@travelmodeId", SqlDbType.Int);
        sqlParam[5].Value = Tid;


        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_TravelmodeMaster]", sqlParam);
        SmartHr.Common.Alert("Travel Mode Deleted Successfully!!!");
        bindTravelmode();

        btntier.Visible = true;
        btnupdate.Visible = false;
    }

    protected void grdtravel_PreRender(object sender, EventArgs e)
    {
        if (grdtravel.Rows.Count > 0)
        {
            grdtravel.UseAccessibleHeader = true;
            grdtravel.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/TravelmodeMaster.aspx");
    }
}