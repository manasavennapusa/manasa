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
using System.Data.SqlClient;
using DataAccessLayer;

public partial class admin_city : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //string sPagePath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                //System.IO.FileInfo oFileInfo = new System.IO.FileInfo(sPagePath);
                //AccessRights Access = NewHrms.Common.GetAccessRights((Container)Session["AccessRights"], oFileInfo.Name);
            }
            else {
                Response.Redirect("~/notlogged.aspx");
            }
                
            bind_country();

            bind_Citydetails();
            if (Request.QueryString["id"] != null)
            {
                bind_city();
            }
        }


       
        if (Request.QueryString["id"] != null)
        {
            btncity.Text = "Update";
            ddlstate.Enabled = false;
            ddlcountry.Enabled = false;
            lblhead.Text = "Edit ";
            grujj.Visible = false;
        }
        else
        {
            btncity.Text = "Submit";
            ddlstate.Enabled = true;
            ddlcountry.Enabled = true;
            lblhead.Text = "Create ";
        }
        if (Request.QueryString["updated"] == "true")
        {
            SmartHr.Common.Alert("Updated Successfully");
            // message.InnerHtml = "State updated successfully";
        }

        if (Request.QueryString["id"] == null)
        {
            btnrest.Text = "Reset";
        }
        else
        {
            btnrest.Text = "Cancel";
        }

    }
    protected void bind_country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlcountry.DataTextField = "countryname";
        ddlcountry.DataValueField = "countryname";
        ddlcountry.DataSource = ds3;
        ddlcountry.DataBind();
        ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void bind_state(string stateid)
    {

        string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
        DataSet ds4 = new DataSet();
        ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlstate.DataTextField = "state";
        ddlstate.DataValueField = "ID";
        ddlstate.DataSource = ds4;
        ddlstate.DataBind();
    }

    protected void ddlcountry_OnDataBound(object sender, EventArgs e)
    {
        ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddlstate_OnDataBound(object sender, EventArgs e)
    {
        ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btncity_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            edit_CityDetails();
        }
        else
        {
            insert_city_detail();
            bind_Citydetails();
        }
    }
    protected void insert_city_detail()
    {

        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@stateid", SqlDbType.Int);
        sqlparam[0].Value = ddlstate.Text;

        sqlparam[1] = new SqlParameter("@city", SqlDbType.VarChar, 50);
        sqlparam[1].Value = txtcity.Text;

        sqlparam[2] = new SqlParameter("@description", SqlDbType.VarChar, 150);
        sqlparam[2].Value = txt_Description.Text;
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_city]", sqlparam);


        if (i <= 0)
        {
           SmartHr.Common.Alert("city name already exists, please enter another name");
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
            reset();
            
        }
    }

    protected void reset()
    {
        txtcity.Text = "";
        txt_Description.Text = "";
        ddlcountry.SelectedValue="0";
        ddlstate.SelectedValue = "0";
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_state(ddlcountry.SelectedItem.Text);
    }

    private void bind_city()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        string sqlstr = "select stateid,city,description from tbl_intranet_city where cid= " + id;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {
            txtcity.Text = ds.Tables[0].Rows[0]["city"].ToString();
            txt_Description.Text = ds.Tables[0].Rows[0]["description"].ToString();
            int state_id = Convert.ToInt32(ds.Tables[0].Rows[0]["stateid"]);
            string sqlstr1 = "select * from tbl_intranet_state_master where ID='" + state_id + "'";
            DataSet ds_id = new DataSet();
            ds_id = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
            bind_country();
            ddlcountry.SelectedValue = ds_id.Tables[0].Rows[0]["Country"].ToString();
            bind_state(ddlcountry.SelectedValue);
            ddlstate.SelectedValue = ds.Tables[0].Rows[0]["stateid"].ToString();
        }
        catch { }
    }


    public void edit_CityDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
       
        SqlParameter[] sqlParam = new SqlParameter[4];

        sqlParam[0] = new SqlParameter("@stateid", SqlDbType.Int);
        sqlParam[0].Value = ddlstate.Text;

        sqlParam[1] = new SqlParameter("@city", SqlDbType.VarChar, 100);
        sqlParam[1].Value = txtcity.Text;
        sqlParam[2] = new SqlParameter("@description", SqlDbType.VarChar, 100);
        sqlParam[2].Value = txt_Description.Text;

        sqlParam[3] = new SqlParameter("@cid", SqlDbType.Int);
        sqlParam[3].Value = id;


        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_city]", sqlParam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_city]", sqlParam);


         if (i <= 0)
         {
            SmartHr.Common.Alert("city name already exists, please enter another name");
         }
         else
         {
             reset();

             Response.Redirect("city.aspx?updated=true");
         }

    }


    private void bind_Citydetails()
    {
        string sqlstr = "select stateid,city,description,cid from tbl_intranet_city ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int id = Convert.ToInt16(ds.Tables[0].Rows[0]["cid"].ToString());
            Session["city_id"] = id.ToString();
            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();
        }
        else
        {
            Grid_Emp.DataSource = null;
            Grid_Emp.DataBind();
        }
    }
    private void bind_Citygrid(string stateid)
    {
        int State = Convert.ToInt32(stateid);
        string sqlstr = "select stateid,city,description,cid from tbl_intranet_city where stateid='"+State+"'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_Citygrid(ddlstate.SelectedValue);
    }
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        //Grid_Emp.UseAccessibleHeader = true;
        //Grid_Emp.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void btn_cncl_Click(object sender, EventArgs e)
    {
        clerr();
    }
    public void clerr()
    {
        if (Request.QueryString["id"] == null)
        {
            reset();
        }
        else
        {
            Response.Redirect("city.aspx");
        }
    }
}
