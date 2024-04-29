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
using DataAccessLayer;
using System.Data.SqlClient;

public partial class admin_state : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {
                    string sPagePath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                    System.IO.FileInfo oFileInfo = new System.IO.FileInfo(sPagePath);
                    //AccessRights Access = NewHrms.Common.GetAccessRights((Container)Session["AccessRights"], oFileInfo.Name);
                }
                BindTbl();
            }

            if (Request.QueryString["id"] == null)
            {
                btnrest.Text = "Reset";
            }
            else
            {
                btnrest.Text = "Cancel";
            }

            if (Request.QueryString["country"] == null)
            {
                ddlcountry.Enabled = true; ;
                btnstate.Text = "Submit";
                
            }
            else
            {
                ddlcountry.Enabled = false;
                btnstate.Text = "Update";
                bindGrid(Request.QueryString["country"].ToString());
                grujj.Visible = false;
            }
            if (Request.QueryString["updated"] == "true")
            {
                SmartHr.Common.Alert("Updated Successfully");
               // message.InnerHtml = "State updated successfully";
            }
    }
    protected void btnstate_Click(object sender, EventArgs e)
    {
        editstate();
    }

    protected void editstate()
    {
        if (Request.QueryString["country"] == null)
        {
            insertstate();
        }
        else
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
           
            SqlParameter[] sqlParam = new SqlParameter[3];

            sqlParam[0] = new SqlParameter("@country", SqlDbType.VarChar, 50);
            sqlParam[0].Value = ddlcountry.SelectedValue;

            sqlParam[1] = new SqlParameter("@state", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtstate.Text;

            sqlParam[2] = new SqlParameter("@ID", SqlDbType.Int);
            sqlParam[2].Value = id;

            //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_state]", sqlParam);
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_state]", sqlParam);

            if (i <= 0)
            {
                SmartHr.Common.Alert("State name already exists, please enter another name");
               // message.InnerHtml = "State name already exists, please enter another name";
            }
            else
            {
                txtstate.Text = "";
                //message.InnerHtml = "State updated successfully";
                Response.Redirect("state.aspx?updated=true");
            }
        }
    }

    protected void bindGrid( string country)
    {
        
        sqlstr = "select * from tbl_intranet_state_master  where Country='"+country+"'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    protected void bindGrid2()
    {
        lblhead.Text = "Create";
        sqlstr = "select * from tbl_intranet_state_master" ;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    protected void BindTbl()
    {

        if (Request.QueryString["country"] != null)
        {
            lblhead.Text = "Edit";
            int ID = Convert.ToInt32(Request.QueryString["Id"]);
            string country = Request.QueryString["country"].ToString();
            sqlstr = "select * from tbl_intranet_state_master where ID='" + ID + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtstate.Text = ds.Tables[0].Rows[0]["state"].ToString();
            bindcountry();
            ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
        }
        else
        {
            bindcountry();
            bindGrid2();
        }
    }
    protected void bindcountry()
    {
        sqlstr = "select * from tbl_intranet_country_master ";
        DataSet ds_country = new DataSet();
        ds_country = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //if (ds.Tables[0].Rows.Count < 1)
          //  return;
        ddlcountry.DataSource = ds_country;
        ddlcountry.DataTextField = "countryname";
        ddlcountry.DataValueField = "countryname";
        ddlcountry.DataBind();
        ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        
        //ddlcountry. = Request.QueryString["country"].ToString();
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindGrid(ddlcountry.SelectedValue);
    }

    protected void insertstate()
    {
        SqlParameter[] sqlParam = new SqlParameter[2];

        sqlParam[0] = new SqlParameter("@country", SqlDbType.VarChar, 50);
        sqlParam[0].Value = ddlcountry.SelectedItem.Text;

        sqlParam[1] = new SqlParameter("@state", SqlDbType.VarChar, 100);
        sqlParam[1].Value = txtstate.Text;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_state]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("State name already exists, please enter another name");
            //message.InnerHtml = "State name already exists, please enter another name";
        }
        else
        {
            bindGrid2();
            SmartHr.Common.Alert("Created Successfully");
           // message.InnerHtml = "State created successfully";

            txtstate.Text = "";
            
        }
    }
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        //Grid_Emp.UseAccessibleHeader = true;
        //Grid_Emp.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public void clerr()
    {
        if (Request.QueryString["id"] == null)
        {
            clear();
        }
        else
        {
            Response.Redirect("state.aspx");
        }
    }

    public void clear()
    {
        ddlcountry.SelectedValue = "0";
        txtstate.Text = "";
    }
    protected void btn_cncl_Click(object sender, EventArgs e)
    {
        clerr();
    }
}
