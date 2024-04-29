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

public partial class InformationCenter_News_Master : System.Web.UI.Page
{
    string sqlstr, file_name;
    string _companyId, _userCode, RoleId;
    DataSet ds;
    //========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        RoleId = Session["role"].ToString();

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Request.QueryString["update"] == "true")
                {
                    Output.Show("Updated Sucessfully");
                }
            }
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }
            //bindcategory();
            bindgrid();
        }
       // message.InnerHtml = "";
    }
    //========================================================================================================================================
    //protected void bindcategory()
    //{
    //    string categoryname;
    //    ////-----Add the Category in the drop down list Box-------------------------------
    //    ddlcategory.Items.Add(new ListItem("---Select Category---"));

    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "select_category_sp");

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (DataRow row1 in ds.Tables[0].Rows)
    //        {
    //            categoryname = row1["categoryname"].ToString().Trim();

    //            ddlcategory.Items.Add(new ListItem(Convert.ToString(categoryname)));
    //        }
    //    }
    //}
    //========================================================================================================================================
    protected void  bindgrid()
    {
        //sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,posteddate posteddate1 FROM NEWSROOM ORDER BY posteddate1 desc,category";
        sqlstr = "select id,category,priority,description,heading,run_status from NEWSROOM";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        newsdetails.DataSource = ds;
        newsdetails.DataBind();
    }
    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (fupload.HasFile)
            {
                //file_name = System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                //fupload.PostedFile.SaveAs(Server.MapPath("../InformationCenter/upload/News_Buzz/" + file_name));
                file_name = System.DateTime.Now.GetHashCode().ToString() + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                fupload.PostedFile.SaveAs(Server.MapPath("../InformationCenter/upload/" + file_name));
                ViewState.Add("file_name", file_name.ToString());
            }

            bool s = saverecords();
            if (s != true)
            {
                Output.Show("Created Successfully");
                Clear();
                //message.InnerHtml = "Record has been saved successfully!";
            }
            else
            {
                Clear();
                lblhead.Text = "Create";
                btnSave.Text = "Submit";
                Response.Redirect("News Master.aspx?update=true");
            }
            bindgrid();
        }
    }

    private void Clear()
    {
        ddlcategory.SelectedValue = "0";
        txtheading.Text = "";
        txtdescription.Text = "";
        ddlrunstatusg.SelectedValue = "0";
        ddlpriorityg.SelectedValue = "0";
    }

    //========================SAVING RECORDS===============================================================
    protected bool saverecords()
    {
        try
        {
            if (Convert.ToInt32(ViewState["flagedit"]) != 1)
            {
                SqlParameter[] newparameter = new SqlParameter[6];

                newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
                newparameter[0].Value = ddlcategory.SelectedValue;

                newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
                newparameter[1].Value = txtheading.Text.Trim().ToString();

                newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
                newparameter[2].Value = txtdescription.Text.Trim().ToString();

                newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
                newparameter[3].Value = ddlrunstatusg.SelectedValue;

                newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
                newparameter[4].Value = ddlpriorityg.SelectedValue;

                newparameter[5] = new SqlParameter("@upload", SqlDbType.VarChar,200);
                if (ViewState["file_name"] != null)
                {
                    newparameter[5].Value = ViewState["file_name"].ToString();
                }
                else
                {
                    newparameter[5].Value = "";
                }
                //newparameter[5] = new SqlParameter("@upload", SqlDbType.VarChar, 200);
                //if (fileupload.HasFile)
                //{
                //    try
                //    {
                //        string strFileName = fileupload.FileName.ToString(); ;
                //        string file_name = System.DateTime.Now.GetHashCode().ToString();
                //        fileupload.PostedFile.SaveAs(Server.MapPath("../InformationCenter/upload/News_Buzz/" + file_name + "_" + strFileName));
                //        newparameter[5].Value = file_name + "_" + strFileName;
                //    }
                //    catch (Exception exc)
                //    {
                //        //lblMsg.Text = exc.Message;
                //    }
                //}
                //else
                //{
                //    newparameter[5].Value = "";
                //}

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_news_sp", newparameter);
                return false;
            }
            if (Convert.ToInt32(ViewState["flagedit"]) == 1)
            {
                if (fupload.PostedFile.FileName.ToString() != "")
                {
                    sqlstr = "SELECT upload FROM NEWSROOM WHERE id=" + ViewState["id"];
                    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string file = Server.MapPath("../InformationCenter/upload/News_Buzz/") + ds.Tables[0].Rows[0]["Upload"].ToString();
                        System.IO.File.Delete(file);
                    }
                }

                SqlParameter[] newparameter = new SqlParameter[7];

                newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
                newparameter[0].Value = ddlcategory.SelectedValue;

                newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
                newparameter[1].Value = txtheading.Text.Trim().ToString();

                newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
                newparameter[2].Value = txtdescription.Text.Trim().ToString();

                newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
                newparameter[3].Value = ddlrunstatusg.SelectedValue;

                newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
                newparameter[4].Value = ddlpriorityg.SelectedValue;

                newparameter[5] = new SqlParameter("@id", SqlDbType.Int);
                newparameter[5].Value = ViewState["id"].ToString();

                newparameter[6] = new SqlParameter("@upload", SqlDbType.VarChar, 200);
                if (ViewState["file_name"] != null)
                {
                    newparameter[6].Value = ViewState["file_name"].ToString();
                }
                else
                {
                    newparameter[6].Value = "";
                }

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_update_news_sp", newparameter);
            }
            return true;
        }
        catch (SqlException sql)
        {
            Output.Show("Cannot insert duplicate values or some database error has been occured!");
           // message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
            return false;
        }
        catch (Exception ex)
        {
            //message.InnerHtml = ex.Message;
            return false;
        }
        finally
        {

        }
    }

    //========================================================================================================================================
    protected void btnclear_Click(object sender, EventArgs e)
    {
        reset();
    }
    //========================================================================================================================================
    protected void reset()
    {
        ddlcategory.SelectedValue = "0";
        txtheading.Text = "";
        txtdescription.Text = "";
        ddlrunstatusg.SelectedValue = "0";
        ddlpriorityg.SelectedValue = "0";
        Response.Redirect("News Master.aspx");
    }
    //========================================================================================================================================
    protected void newsdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        newsdetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void newsdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        newsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================
    protected void newsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
        //    e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        //}
    }
    //========================================================================================================================================
    protected void newsdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)newsdetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM NEWSROOM WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
        Output.Show("Deleted Sucessfully");
    }

    //========================================================================================================================================
    protected void newsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.Visible = false;
        int id;
        lblhead.Text = "Edit";
        btnSave.Text = "Update";
        btnclear.Text = "Cancel";
        ViewState["flagedit"] = 1; //FOR EDITING RECORDS

        id = (int)newsdetails.DataKeys[e.NewEditIndex].Value;
        ViewState["id"] = id;

        sqlstr = "select id,category,priority,description,heading,run_status,Upload from NEWSROOM WHERE id='" + id + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["category"].ToString();
        ddlrunstatusg.SelectedValue = ds.Tables[0].Rows[0]["run_status"].ToString();
        ddlpriorityg.SelectedValue = ds.Tables[0].Rows[0]["priority"].ToString();
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
            // lbl_file.Text = "<a href='../upload/hrdocuments/" + ds.Tables[0].Rows[0]["upload"].ToString() + "'>" + ds.Tables[0].Rows[0]["upload"].ToString() + "</a>";

        }
       // bindgrid();
        bindgrid();

    }
    //========================================================================================================================================
    protected void newsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        ////grid.Visible = false;
        //int id;
        //lblhead.Text = "Edit";
        ////btnsubmit.Text = "Update";
        //ViewState["flagedit"] = 1; //FOR EDITING RECORDS

        //id = (int)newsdetails.DataKeys[e.RowIndex].Value;
        //ViewState["id"] = id;

        //sqlstr = "select id,category,priority,description,heading,run_status from NEWSROOM WHERE id='" + id + "'";
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["category"].ToString();
        //ddlrunstatusg.SelectedValue = ds.Tables[0].Rows[0]["run_status"].ToString();
        //ddlpriorityg.SelectedValue = ds.Tables[0].Rows[0]["priority"].ToString();
        //txtheading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
        //txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();

        //bindgrid();
        //txtsubject.Text = ds.Tables[0].Rows[0]["subject"].ToString();
        //txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
        //ViewState["file_name"] = ds.Tables[0].Rows[0]["upload"].ToString();







        //int id = (int)newsdetails.DataKeys[e.RowIndex].Value;

        //string strname = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[0].FindControl("txtheadingg")).Text;

        //SqlParameter[] sqlparam = new SqlParameter[2];

        //if (strname != "")
        //{
        //    string strcategory = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        //    string strheading = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        //    string strdescription = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        //    string strrunstatus = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        //    string strpriority = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
        //    int code = (int)newsdetails.DataKeys[e.RowIndex].Value;

        //    sqlstr = "UPDATE NEWSROOM SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //    Response.Redirect("News Master.aspx");
        //    //ddlperquistename.DataBind();
        //    //othrsrcincgird.EditIndex = -1;
        //    //othrsrcincgird.DataSourceID = "SqlDataSource1";

        //    //    othrsrcincgird.DataBind();
        //    //txtothrsrcinc.Text = "";
        //    //message.InnerHtml = "Other Source Income has been added successfully !";
        //}
        //else
        //{
        //    string msg = "Please enter Subjet !";
        //    Page.RegisterStartupScript("vv", "<script> alert('" + msg + "')</script>");
        //    message.InnerHtml = "Please enter Heading!";

        //}

        ////newsdetails.EditIndex = -1;
        //bindgrid();
    }
    //============================================================================================================================================   
    protected void newsdetails_PreRender(object sender, EventArgs e)
    {
        if (newsdetails.Rows.Count > 0)
        {
            newsdetails.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    //protected void View(object sender, EventArgs e)
    //{
    //    int id = int.Parse((sender as LinkButton).CommandArgument);
    //    string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"600px\">";
    //    embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
    //    embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
    //    embed += "</object>";
    //    //ltEmbed.Text = string.Format(embed, ResolveUrl("~/FileCS.ashx?Id="), id);
    //}

}