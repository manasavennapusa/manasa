using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_TravelModeClassification : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
           

            bindtravelmodeclass();
            btnupdate.Visible = false;
            btncancel2.Visible = false;
            create1.Visible = true;
            create.Visible = true;
            edit1.Visible = false;
            edit.Visible = false;
            ddltravelmodeclass.Items.Insert(0, new ListItem("---Select---", "0"));
            if (Request.QueryString["Id"] != null)
            {
                bindtravelmodeclassdetails();
                btntier.Visible = false;
                btnupdate.Visible = true;
                btncancel.Visible = false;
                btncancel2.Visible = true;
                create1.Visible = false;
                create.Visible = false;
                edit1.Visible = true;
                edit.Visible = true;
                grid1.Visible = false;
            }

        }
        //if (Request.QueryString["updated"] != null)
        //{
        //    SmartHr.Common.Alert("Grade-Tier-Mode-Class Binding Updated successfully");
        //}
    }

    private void bindtravelmodeclassdetails()
    {
        int Tid = Convert.ToInt32(Request.QueryString["Id"]);
       // sqlstr = "select tm.gradeID,tm.citytierid,tm.Amount,tm.travelclassID,tc.travelmodeID from tbl_travel_TravelModeClassification tm inner join tbl_travel_TravelModeClass tc on tm.travelclassID=tc.travelclassid where tm.id=" + Tid + "";
        sqlstr = "select tm.citytierid,tm.Amount,tm.travelclassID,tc.travelmodeID from tbl_travel_TravelModeClassification tm inner join tbl_travel_TravelModeClass tc on tm.travelclassID=tc.travelclassid where tm.id=" + Tid + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //drpgrade.SelectedValue = ds.Tables[0].Rows[0]["gradeID"].ToString();
            ddltier.SelectedValue = ds.Tables[0].Rows[0]["citytierid"].ToString();
            ddltravelmode.SelectedValue = ds.Tables[0].Rows[0]["travelmodeID"].ToString();
            bindtravelclass(ds.Tables[0].Rows[0]["travelmodeID"].ToString());
            ddltravelmodeclass.SelectedValue = ds.Tables[0].Rows[0]["travelclassID"].ToString();
           // txtAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
            //drpgrade.Enabled = false;
            //ddltier.Enabled = false;
            //ddltravelmode.Enabled = false;
        }

    }

    private void bindtravelmodeclass()
    {

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_mode_getclassforgrades]");
        grdtravelmodes.DataSource = ds;
        grdtravelmodes.DataBind();
    }
    
    protected void ddltier_DataBound(object sender, EventArgs e)
    {
        ddltier.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    
    protected void ddltravelmode_DataBound(object sender, EventArgs e)
    {
        ddltravelmode.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    
    protected void ddltravelmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindtravelclass(ddltravelmode.SelectedValue);
    }
    
    protected void drpgrade_DataBound(object sender, EventArgs e)
    {
        drpgrade.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    
    protected void ddltravelmodeclass_DataBound(object sender, EventArgs e)
    {
        ddltravelmodeclass.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    
    protected void bindtravelclass(string ID)
    {
        sqlstr = "SELECT travelclassid,travelmodeclass FROM tbl_travel_TravelModeClass WHERE travelmodeID='" + ID + "' ";
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddltravelmodeclass.DataTextField = "travelmodeclass";
        ddltravelmodeclass.DataValueField = "travelclassid";
        ddltravelmodeclass.DataSource = ds1;
        ddltravelmodeclass.DataBind();
    }

    protected void btntier_Click(object sender, EventArgs e)
    {
        string empcode = Session["empcode"].ToString();
        SqlParameter[] sqlParam = new SqlParameter[8];

        sqlParam[0] = new SqlParameter("@grade", SqlDbType.Int);
        sqlParam[0].Value = drpgrade.SelectedItem.Value;

        sqlParam[1] = new SqlParameter("@tier", SqlDbType.Int);
        sqlParam[1].Value = ddltier.SelectedItem.Value;

        sqlParam[2] = new SqlParameter("@travelclass", SqlDbType.Int);
        sqlParam[2].Value = ddltravelmodeclass.SelectedItem.Value;

        sqlParam[3] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[3].Value = "I";

        sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[4].Value = empcode;

        sqlParam[5] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[5].Value = 0;

        sqlParam[6] = new SqlParameter("@travelmodeId", SqlDbType.Int);
        sqlParam[6].Value = ddltravelmode.SelectedValue;

        sqlParam[7] = new SqlParameter("@amount", SqlDbType.Decimal);
        sqlParam[7].Value =System.Data.SqlTypes.SqlDecimal.Null;// txtAmount.Text;


        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_mode_classforgrades]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Grade-Tier-Mode-Class Binding already exists, please enter another");
        }
        else
        {
            SmartHr.Common.Alert("Grade-Tier-Mode-Class Created Successfully!!!");
            clearfields();
            bindtravelmodeclass();
        }

    }
    
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null)
        {
            string empcode = Session["empcode"].ToString();
            int Tid = Convert.ToInt32(Request.QueryString["Id"]);

            SqlParameter[] sqlParam = new SqlParameter[8];

            sqlParam[0] = new SqlParameter("@grade", SqlDbType.Int);
            sqlParam[0].Value = drpgrade.SelectedItem.Value;

            sqlParam[1] = new SqlParameter("@tier", SqlDbType.Int);
            sqlParam[1].Value = ddltier.SelectedItem.Value;

            sqlParam[2] = new SqlParameter("@travelclass", SqlDbType.Int);
            sqlParam[2].Value = ddltravelmodeclass.SelectedItem.Value;

            sqlParam[3] = new SqlParameter("@flag", SqlDbType.Char, 1);
            sqlParam[3].Value = "U";

            sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlParam[4].Value = empcode;

            sqlParam[5] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[5].Value = Tid;

            sqlParam[6] = new SqlParameter("@travelmodeId", SqlDbType.Int);
            sqlParam[6].Value = ddltravelmode.SelectedValue;

            sqlParam[7] = new SqlParameter("@amount", SqlDbType.Decimal);
            sqlParam[7].Value = System.Data.SqlTypes.SqlDecimal.Null; //txtAmount.Text;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_mode_classforgrades]", sqlParam);

            if (i <= 0)
            {
                SmartHr.Common.Alert("Grade-Tier-Mode-Class Binding already exists, please enter another name");
            }
            else
            {
                clearfields();
                bindtravelmodeclass();
                SmartHr.Common.Alert("Grade-Tier-Mode-Class Updated Successfully!!!");
                btntier.Visible = true;
                btnupdate.Visible = false;
                btncancel2.Visible = false;
                btncancel.Visible = true;
                create1.Visible = true;
                create.Visible = true;
                edit1.Visible = false;
                edit.Visible = false;
                grid1.Visible = true;
            }
        }

    }
    
    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null)
        {
            Response.Redirect("TravelModeClassification.aspx");
        }
        else
        {
            clearfields();
        }
    }

    protected void grdtravelmodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        SqlParameter[] sqlParam = new SqlParameter[8];

        sqlParam[0] = new SqlParameter("@grade", SqlDbType.Int);
        sqlParam[0].Value = 0;

        sqlParam[1] = new SqlParameter("@tier", SqlDbType.Int);
        sqlParam[1].Value = 0;

        sqlParam[2] = new SqlParameter("@travelclass", SqlDbType.Int);
        sqlParam[2].Value = 0;

        sqlParam[3] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[3].Value = "D";

        sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[4].Value = "";

        sqlParam[5] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[5].Value = grdtravelmodes.DataKeys[e.RowIndex].Value;

        sqlParam[6] = new SqlParameter("@travelmodeId", SqlDbType.Int);
        sqlParam[6].Value =0;

        sqlParam[7] = new SqlParameter("@amount", SqlDbType.Decimal);
        sqlParam[7].Value = 0;



        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_mode_classforgrades]", sqlParam);

        if (i <= 0)
        {
           SmartHr.Common.Alert("Grade-Tier-Mode-Class Binding Not Deleted Sucessfully");
        }
        else
        {
            SmartHr.Common.Alert("Grade-Tier-Mode-Class Deleted Successfully!!!");
            bindtravelmodeclass();
        }
    }

    protected void clearfields()
    {
        drpgrade.SelectedValue = "0";
        ddltier.SelectedValue = "0";
        ddltravelmode.SelectedValue = "0";
        ddltravelmodeclass.SelectedValue = "0";
        txtAmount.Text = "";
    }

    protected void grdtravelmodes_PreRender(object sender, EventArgs e)
    {
        if (grdtravelmodes.Rows.Count > 0)
        {
            grdtravelmodes.UseAccessibleHeader = true;
            grdtravelmodes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/TravelModeClassification.aspx");
    }
}