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
using DataAccessLayer;
using System.Data.SqlClient;
using Common.Console;

public partial class InformationCenter_NewsMasterEdit : System.Web.UI.Page
{
    string sqlstr, file_name;
    string _companyId, _userCode, RoleId;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                BindData();
            }
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }

            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
        }
    }

    protected void BindData()
    {
        if (Session["awardsID"] != null)
        {
            int id = Convert.ToInt32(Session["awardsID"].ToString());
            sqlstr = "select id,category,priority,description,heading,run_status,Upload from NEWSROOM WHERE id='" + id + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["category"].ToString();
            ddlrunstatus.SelectedValue = ds.Tables[0].Rows[0]["run_status"].ToString();
            ddlpriority.SelectedValue = ds.Tables[0].Rows[0]["priority"].ToString();
            txtheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
            txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            //-----------------
            if (ds.Tables[0].Rows.Count < 1)
            {
                lbl_file.Text = "no file";
                dftlink1.HRef = "#";
                return;
            }
            else if (ds.Tables[0].Rows[0]["Upload"].ToString() == "")
            {
                lbl_file.Text = "no file";
                dftlink1.HRef = "#";
            }
            else
            {
                dftlink1.HRef = "../InformationCenter/upload/" + ds.Tables[0].Rows[0]["Upload"].ToString();
                dftlink1.Target = "_blank";
                lbl_file.Text = ds.Tables[0].Rows[0]["Upload"].ToString();
            }
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int i = 0;
        int id = Convert.ToInt32(Session["awardsID"].ToString());
        if (fupload.PostedFile.FileName.ToString() != "")
        {
            file_name = System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
            fupload.PostedFile.SaveAs(Server.MapPath("../InformationCenter/upload/catalogs/" + file_name));
            ViewState.Add("file_name", file_name.ToString());
        }
        try
        {
            if (ViewState["file_name"] != null)
            {
                sqlstr = @"update NEWSROOM set heading='" + txtheading.Text + "',description='" + txtdescription.Text + "',category='" + ddlcategory.SelectedValue + "',run_status='" + ddlrunstatus.SelectedValue + "',priority='" + ddlpriority.SelectedValue + "',Upload='" + ViewState["file_name"].ToString() + "' where id='" + id + "'";
                i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            }
            else
            {
                sqlstr = @"update NEWSROOM set heading='" + txtheading.Text + "',description='" + txtdescription.Text + "',category='" + ddlcategory.SelectedValue + "',run_status='" + ddlrunstatus.SelectedValue + "',priority='" + ddlpriority.SelectedValue + "',Upload='' where id='" + id + "'";
                i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            if (i > 0)
            {
                //Output.Show("Updated Successfully");
                Response.Redirect("~/DashBoard_Demo.aspx?update=true");
            }
            else
            {
                Output.Show("Something Went Wrong.");
            }
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        ddlcategory.SelectedValue = "0";
        ddlrunstatus.SelectedValue = "0";
        ddlpriority.SelectedValue = "0";
        txtheading.Text = "";
        txtdescription.Text = "";
    }

}