using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;


public partial class recruitment_candidatesSelectedinRound2 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["role"] != null)
        //    {
        //        //Response.Redirect("~/Authenticate.aspx");
        //    }
        //    else
        //        Response.Redirect("~/notlogged.aspx");
        //    bindgrid();
        //    bindddlrrfcode();
        //}
    }

    //protected void bindddlrrfcode()
    //{
    //    DataSet ds = new DataSet();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
    //    ddlrrfcode.DataTextField = "rrf_code";
    //    ddlrrfcode.DataValueField = "id";
    //    ddlrrfcode.DataSource = ds;
    //    ddlrrfcode.DataBind();
    //    ddlrrfcode.Items.Insert(0, new ListItem("--Select--", "0"));
    //}

    //protected void ddlrrfcode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlrrfcode.SelectedValue != "0")
    //    {
    //        int id = Convert.ToInt32(ddlrrfcode.SelectedValue);
    //        SqlParameter[] sqlParam = new SqlParameter[1];

    //        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
    //        sqlParam[0].Value = id;
    //        //string sqlstr = "select * from tbl_recruitment_requisition_form where id='" + id + "'";
    //        DataSet ds = new DataSet();
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_Round2byRRFCODE", sqlParam);
    //        grdcandidates.DataSource = ds;
    //        grdcandidates.DataBind();
    //    }
    //}

    //protected void bindgrid()
    //{
    //    DataSet ds = new DataSet();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_Round2");
    //    grdcandidates.DataSource = ds;
    //    grdcandidates.DataBind();
    //}

    //protected void lbtnview_Command(object sender, CommandEventArgs e)
    //{
    //    string filepath = e.CommandArgument.ToString();
    //    Session["FileData"] = Server.MapPath("~/recruitment/upload/" + filepath);
    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Script", " JavaScript:newPopup1('viewresume.aspx');", true);
    //}

    //protected void grdcandidates_PreRender(object sender, EventArgs e)
    //{
    //    if (grdcandidates.Rows.Count > 0)
    //    {
    //        grdcandidates.HeaderRow.TableSection = TableRowSection.TableHeader;
    //    }
    //}

    //protected void btnsave_Click(object sender, EventArgs e)
    //{
    //    SqlParameter[] param = new SqlParameter[3];
    //    if (grdcandidates.Rows.Count > 0)
    //    {
    //        foreach (GridViewRow row in grdcandidates.Rows)
    //        {
    //            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
    //            if (chk.Checked)
    //            {
    //                Label id = (Label)row.FindControl("lblID");
    //                Label name = (Label)row.FindControl("lblname");
    //                Label email = (Label)row.FindControl("lblemail");
    //                TextBox date = (TextBox)row.FindControl("txtDate");
    //                TextBox time = (TextBox)row.FindControl("tbttime");

    //                if (date.Text != "" && time.Text != "")
    //                {
    //                    param[0] = new SqlParameter("@candidateId", SqlDbType.Int);
    //                    param[0].Value = Convert.ToInt32(id.Text);
    //                    param[1] = new SqlParameter("@round3date", SqlDbType.DateTime);
    //                    param[1].Value = Convert.ToDateTime(date.Text);
    //                    param[2] = new SqlParameter("@round3time", SqlDbType.VarChar, 10);
    //                    param[2].Value = time.Text;
    //                    try
    //                    {
    //                        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_select_candiate_interview_round3", param);
    //                        if (i > 0)
    //                        {
    //                            //sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
    //                            Output.Show("Record Saved Successfully");
    //                        }
    //                        else
    //                        {

    //                        }
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
    //                        Output.Show("Record not saved.Please contact system admin.For error details please go through the log file");
    //                    }
    //                }
    //                else
    //                {

    //                }
    //            }

    //        }           
    //    }
    //    bindgrid();
    //}
   
}