using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;

public partial class createdocument : System.Web.UI.Page
{
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //    Response.Redirect("~/Authenticate.aspx");
        }
        else

            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {

            bindGrid();

            if (Request.QueryString["id"] != null)
            {
                bindinfomation();
                btnadd.Text = "Update";
                btnclear.Text = "Cancel";
                lblheader.Text = "EDIT DOCUMENT";
            }
            else
            {
                btnadd.Text = "Add";
                btnclear.Text = "Clear";
                lblheader.Text = "CREATE DOCUMENT";
            }

            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Document Name is Updated Successfully.");
            }
        }
        
    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_document_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grddocument.DataSource = ds;
        grddocument.DataBind();

    }

    private void cleartext()
    {
        txt_docname.Text = "";
        txt_dec.Text = "";
        chk_mandatory.Checked = false;
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            update_Document();
        }
        else
        {
            insert_Document();
        }
        bindGrid();
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createdocument.aspx");
        }
    }

    protected void insert_Document()
    {
        SqlParameter[] sqlParam = new SqlParameter[4];
        int i = 0;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@document_name", "String", 100, txt_docname.Text);
            Output.AssignParameter(sqlParam, 1, "@description", "String", 50, txt_dec.Text);
            Output.AssignParameter(sqlParam, 2, "@mandatory", "Bool", 0, chk_mandatory.Checked.ToString());
            Output.AssignParameter(sqlParam, 3, "@createby", "String", 50, UserCode);

            i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_documentt]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

        if (i < 0)
        {
            Output.Show("Document Name is already exists try another name.");
        }
        else
        {
            Output.Show("Document Name is inserted Successfully.");
            cleartext();
        }
    }

    protected void update_Document()
    {
        SqlParameter[] sqlParam = new SqlParameter[5];
        int i = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(sqlParam, 1, "@document_name", "String", 100, txt_docname.Text);
            Output.AssignParameter(sqlParam, 2, "@description", "String", 50, txt_dec.Text);
            Output.AssignParameter(sqlParam, 3, "@mandatory", "Bool", 0, chk_mandatory.Checked.ToString());
            Output.AssignParameter(sqlParam, 4, "@updateby", "String", 50, UserCode);

            i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recriutment_update_document]", sqlParam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not updated. Please contact system admin. For error details please go through log file.");
        }
        if (i < 0)
        {
            Output.Show("Document Name is already exists try another name.");
        }
        else
        {
            //message.InnerHtml = "Skill Name is Updated Successfully.";
            Response.Redirect("createdocument.aspx?updated=true");
            cleartext();
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_document_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_docname.Text = ds.Tables[0].Rows[0]["document_name"].ToString();
        txt_dec.Text = ds.Tables[0].Rows[0]["description"].ToString();
        chk_mandatory.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["mandatory"]);

    }

    protected void grddocument_PreRender(object sender, EventArgs e)
    {
        if (grddocument.Rows.Count > 0)
        {
            grddocument.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}