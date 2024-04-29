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

public partial class InformationCenter_CatalogEdit : System.Web.UI.Page
{
    string sqlstr, file_name;
    string _userCode, _companyId, RoleId;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();

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
        }
    }

    protected void BindData()
    {
        if (Session["NewsID"] != null)
        {
            int id = Convert.ToInt32(Session["NewsID"].ToString());
            sqlstr = "select id,type,subject,description,upload,postedby,posteddate from tbl_intranet_catalogs WHERE id='" + id + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            ddltype.SelectedValue = ds.Tables[0].Rows[0]["type"].ToString();
            txtsubject.Text = ds.Tables[0].Rows[0]["subject"].ToString();
            txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            //-----------------
            if (ds.Tables[0].Rows.Count < 1)
            {
                lbl_file.Text = "no file";
                dftlink1.HRef = "#";
                return;
            }
            else if (ds.Tables[0].Rows[0]["upload"].ToString() == "")
            {
                lbl_file.Text = "no file";
                dftlink1.HRef = "#";
            }
            else
            {
                dftlink1.HRef = "../InformationCenter/upload/catalogs/" + ds.Tables[0].Rows[0]["upload"].ToString();
                dftlink1.Target = "_blank";
                lbl_file.Text = ds.Tables[0].Rows[0]["upload"].ToString();
            }
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (Session["NewsID"] != null)
        {
            int id = Convert.ToInt32(Session["NewsID"].ToString());
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
                    sqlstr = @"UPDATE tbl_intranet_catalogs set type='" + ddltype.SelectedValue + "',subject='" + txtsubject.Text.Trim().ToString() + "',description='" + txtdescription.Text.Trim().ToString() + "',upload='" + ViewState["file_name"].ToString() + "',postedby='" + _userCode.ToString() + "',posteddate='" + System.DateTime.Now + "' where id='" + id + "'";
                    i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                }
                else
                {
                    sqlstr = @"UPDATE tbl_intranet_catalogs set type='" + ddltype.SelectedValue + "',subject='" + txtsubject.Text.Trim().ToString() + "',description='" + txtdescription.Text.Trim().ToString() + "',upload='',postedby='" + _userCode.ToString() + "',posteddate='" + System.DateTime.Now + "' where id='" + id + "'";
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
                    Response.Redirect("~/DashBoard_Demo.aspx?newsupdate=true");
                }
                else
                {
                    Output.Show("Something Went Wrong.");
                }
            }
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        ddltype.SelectedValue = "0";
        txtsubject.Text = "";
        txtdescription.Text = "";
    }

}