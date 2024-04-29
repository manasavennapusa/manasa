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

public partial class intranet_isodocuments : System.Web.UI.Page
{
    string sqlstr, file_name;
    DataSet ds;

    //---------------------------------------FORM LOAD BINDING DATA IN GRIDVIEW-----------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgrid();
        }
        message.InnerHtml = "";
    }

    //-------------------------------------CLICKING ON SUBMIT BUTTON TO SAVE RECORDS IN DATABASE-------------------------------------
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    file_name = System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                    fupload.PostedFile.SaveAs(Server.MapPath("../upload/isodocuments/" + file_name));
                    ViewState.Add("file_name", file_name.ToString());
                }

                bool s = saverecords();
                if (s)
                {
                    message.InnerHtml = "Record has been saved successfully!";
                    reset();
                }
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "File has not been uploaded. Please try again!";
        }
    }

    //-------------------------------------FUNCTION TO SAVE VALUES IN DATABASE-------------------------------------
    protected bool saverecords()
    {
        try
        {
            if (Convert.ToInt32(ViewState["flagedit"]) != 1)
            {
                SqlParameter[] newparameter = new SqlParameter[6];

                newparameter[0] = new SqlParameter("@type", SqlDbType.VarChar, 50);
                newparameter[0].Value = ddltype.SelectedItem.Text;

                newparameter[1] = new SqlParameter("@subject", SqlDbType.VarChar, 100);
                newparameter[1].Value = txtsubject.Text.Trim().ToString();

                newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
                newparameter[2].Value = txtdescription.Text.Trim().ToString();

                newparameter[3] = new SqlParameter("@upload", SqlDbType.VarChar, 150);
                newparameter[3].Value = ViewState["file_name"].ToString();

                newparameter[4] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
                newparameter[4].Value = Session["name"].ToString();             

                newparameter[5] = new SqlParameter("@posteddate", SqlDbType.DateTime);
                newparameter[5].Value = System.DateTime.Now;

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_isodocument_sp", newparameter);
                return true;
            }
            if (Convert.ToInt32(ViewState["flagedit"]) == 1)
            {
                //----------------Deletion of old uploaded file from the server------------------

                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    sqlstr = "SELECT upload FROM tbl_intranet_iso_documents WHERE id=" + ViewState["id"];
                    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string file = Server.MapPath("../upload/isodocuments/") + ds.Tables[0].Rows[0]["upload"].ToString();
                        System.IO.File.Delete(file);
                    }
                }

                //----------------Edition of record in database---------------------------------

                SqlParameter[] newparameter = new SqlParameter[7];

                newparameter[0] = new SqlParameter("@type", SqlDbType.VarChar, 50);
                newparameter[0].Value = ddltype.SelectedItem.Text;

                newparameter[1] = new SqlParameter("@subject", SqlDbType.VarChar, 100);
                newparameter[1].Value = txtsubject.Text.Trim().ToString();

                newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
                newparameter[2].Value = txtdescription.Text.Trim().ToString();

                newparameter[3] = new SqlParameter("@upload", SqlDbType.VarChar, 150);
                newparameter[3].Value = ViewState["file_name"].ToString();

                newparameter[4] = new SqlParameter("@postedby", SqlDbType.VarChar, 50);
                newparameter[4].Value = Session["name"].ToString();

                newparameter[5] = new SqlParameter("@posteddate", SqlDbType.DateTime);
                newparameter[5].Value = System.DateTime.Now;

                newparameter[6] = new SqlParameter("@id", SqlDbType.Int);
                newparameter[6].Value = ViewState["id"].ToString();

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_update_isodocument_sp", newparameter);
                return true;
            }
            return true;
        }
        catch (SqlException sql)
        {
            message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
            return false;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
            return false;
        }
        finally
        {

        }
    }

    //--------------------------------------BINDING GRID----------------------------------------------------------------------------------
    protected void bindgrid()
    {
        sqlstr = "SELECT id,type,subject,description,upload,postedby FROM tbl_intranet_iso_documents ORDER BY posteddate desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        griddetails.DataSource = ds;
        griddetails.DataBind();
    }

    //-----------------------------------------PAGING IN GRID--------------------------------------------------------------------------
    protected void griddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    //-----------------------------------------CHANGING COLOR OF ROW ON MOVING MOUSE---------------------------------------------------
    protected void griddetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
        //    e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        //}
    }

    //---------------------------------------DELETING A PARTICULAR RECORDS FROM GRIDVIEW -------------------------------------------------
    protected void griddetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)griddetails.DataKeys[e.RowIndex].Value;

        //----------------Deletion of uploaded file from the server------------------

        sqlstr = "SELECT upload FROM tbl_intranet_iso_documents WHERE id=" + code;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            string file = Server.MapPath("../upload/isodocuments/") + ds.Tables[0].Rows[0]["upload"].ToString();
            System.IO.File.Delete(file);
        }

        //----------------Deletion of record from the database------------------

        sqlstr = "DELETE FROM tbl_intranet_iso_documents WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
        reset();
    }

    //-----------------------------------CLICKING ON EDIT BUTTON-------------------------------------------------------------------
    protected void griddetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id;

        ViewState["flagedit"] = 1; //FOR EDITING RECORDS

        id = (int)griddetails.DataKeys[e.NewEditIndex].Value;
        ViewState["id"] = id;

        sqlstr = "SELECT id,type,subject,description,upload,postedby FROM tbl_intranet_iso_documents WHERE id='" + id + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddltype.SelectedValue = ds.Tables[0].Rows[0]["type"].ToString();
        txtsubject.Text = ds.Tables[0].Rows[0]["subject"].ToString();
        txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
        ViewState["file_name"] = ds.Tables[0].Rows[0]["upload"].ToString();

        rfvupload.Enabled = false;

        lbl_file.Text = "<a href='../upload/isodocuments/" + ds.Tables[0].Rows[0]["upload"].ToString() + "'>" + ds.Tables[0].Rows[0]["upload"].ToString() + "</a>";        
    }

    //------------------------------------CLICKING ON RESET BUTTON-------------------------------------------------------------------------
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }

    //------------------------------------FUNCTION TO RESET CONTROLS VALUE-----------------------------------------------------------
    protected void reset()
    {
        ddltype.SelectedIndex = 0;
        txtsubject.Text = "";
        txtdescription.Text = "";
        lbl_file.Text = "";
        rfvupload.Enabled = true;
        ViewState.Remove("file_name");
    }
}
//---------------------------------------END OF PROGRAM-----------------------------------------------------------------------------------