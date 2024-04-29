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


public partial class admin_IDProofMaster : System.Web.UI.Page
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
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }

           

            bind_Citydetails();
            if (Request.QueryString["id"] != null)
            {
                bind_city();
            }
            if (Request.QueryString["updated"] == "true")
            {
                SmartHr.Common.Alert("Document Type Updated Successfully");
                // message.InnerHtml = "State updated successfully";
            }
        }



        if (Request.QueryString["id"] != null)
        {
            btncity.Text = "Update";
            lblhead.Text = "Edit ";
            grujj.Visible = false;
        }
        else
        {
            btncity.Text = "Submit";
            lblhead.Text = "Create ";
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

    private void bind_city()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        string sqlstr = "select name,des from tbl_Internet_AddressProof where id= " + id;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {
            txtcity.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txt_Description.Text = ds.Tables[0].Rows[0]["des"].ToString();
           
        }
        catch { }
    }
    private void bind_Citydetails()
    {
        string sqlstr = "select name,des,id from tbl_Internet_AddressProof ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString());
            Session["address_id"] = id.ToString();
            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();
        }
        else
        {
            Grid_Emp.DataSource = null;
            Grid_Emp.DataBind();
        }
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
    protected void btnrest_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {

    }

    protected void insert_city_detail()
    {

        SqlParameter[] sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txtcity.Text;

        sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_Description.Text;
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_address_proof]", sqlparam);


        if (i <= 0)
        {
            SmartHr.Common.Alert("Address Proof name already exists, please enter another name");
        }
        else
        {
            SmartHr.Common.Alert("Document Type Created Successfully");
            reset();

        }
    }

    protected void reset()
    {
        txtcity.Text = "";
        txt_Description.Text = "";
    }

    public void edit_CityDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());

        SqlParameter[] sqlParam = new SqlParameter[3];

        sqlParam[0] = new SqlParameter("@name", SqlDbType.VarChar, 100);
        sqlParam[0].Value = txtcity.Text;
        sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 100);
        sqlParam[1].Value = txt_Description.Text;

        sqlParam[2] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[2].Value = id;


        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_city]", sqlParam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_address_proof]", sqlParam);


        if (i <= 0)
        {
            SmartHr.Common.Alert("Adress Proof name already exists, please enter another name");
        }
        else
        {
            reset();

            Response.Redirect("IDProofMaster.aspx?updated=true");
        }

    }

}