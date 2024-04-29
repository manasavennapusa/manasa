using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Data.SqlClient;

public partial class admin_CurrencyCodeMaster : System.Web.UI.Page
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
            bindGrid2();
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

        if (Request.QueryString["id"] == null)
        {
            btnCurrency.Text = "Submit";
        }
        else
        {
            btnCurrency.Text = "Update";
            grujj.Visible = false;
        }
        if (Request.QueryString["updated"] == "true")
        {
            SmartHr.Common.Alert("Updated Successfully");
           // message.InnerHtml = "Currency Code updated successfully";
        }
    }

    protected void btnCurrency_Click(object sender, EventArgs e)
    {
        editstate();
    }

    protected void editstate()
    {
        if (Request.QueryString["id"] == null)
        {
            insertstate();
        }
        else
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            SqlParameter[] sqlParam = new SqlParameter[3];

            sqlParam[0] = new SqlParameter("@currencycode", SqlDbType.VarChar, 5);
            sqlParam[0].Value = txt_currencycode.Text;

            sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            sqlParam[1].Value = txt_description.Text;

            sqlParam[2] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[2].Value = id;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_currencycode]", sqlParam);

            if (i <= 0)
            {
                SmartHr.Common.Alert(" Currency Code already exists, please enter another.");
               // message.InnerHtml = "Currency Code already exists, please enter another";
            }
            else
            {

                txt_currencycode.Text = "";
                txt_description.Text = "";
                Response.Redirect("CurrencyCodeMaster.aspx?updated=true");
            }
        }
    }

    protected void bindGrid2()
    {
        lblhead.Text = "Create";
        sqlstr = "select * from tbl_intranet_currencycode where status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Gridcurrencycode.DataSource = ds;
        Gridcurrencycode.DataBind();
    }

    protected void BindTbl()
    {

        if (Request.QueryString["id"] != null)
        {
            lblhead.Text = "Edit ";
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            sqlstr = "select * from tbl_intranet_currencycode where id="+ID.ToString();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txt_currencycode.Text = ds.Tables[0].Rows[0]["currencycode"].ToString();
            txt_description.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
     
    }

    protected void insertstate()
    {
        SqlParameter[] sqlParam = new SqlParameter[2];

        sqlParam[0] = new SqlParameter("@currencycode", SqlDbType.VarChar, 5);
        sqlParam[0].Value = txt_currencycode.Text;

        sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
        sqlParam[1].Value = txt_description.Text;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_currencycode]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Currecny Code already exists, please enter another");
            //message.InnerHtml = "Currecny Code already exists, please enter another.";
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
           // message.InnerHtml = "Currecny Code created successfully";
            txt_currencycode.Text = "";
            txt_description.Text = "";
            bindGrid2();
        }
    }
 
    protected void Gridcurrencycode_PreRender(object sender, EventArgs e)
    {
       // Gridcurrencycode.UseAccessibleHeader = true;
       // Gridcurrencycode.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void btn_cncl_Click(object sender, EventArgs e)
    {
        clerr();
    }
    public void clerr()
    {
        if (Request.QueryString["id"] == null)
        {
            clear();
        }
        else
        {
            Response.Redirect("CurrencyCodeMaster.aspx");
        }
    }

    public void clear()
    {
        txt_currencycode.Text = "";
        txt_description.Text = "";
    }
}
