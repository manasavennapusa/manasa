using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Services;

public partial class home : System.Web.UI.Page
{
    string Str, Str_1, Str_2, Str_3, image;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }

        if (Session["AdminSection"] != null)
        {
            string asds = Session["AdminSection"].ToString();
        }
        if (Request.QueryString["m"] != null)
        {
            if (Request.QueryString["m"] == "MyDash")
            {
                reportiees.Visible = true;
                accordion1.Visible = true;
                useraccordion1.Visible = true;
                Div2.Visible = false;
                superadmin.Visible = true;
                Session["modulecode"] = "0";
                div_home_2.Visible = true;
                div_home_1.Visible = false;
            }
            else
            {
                Session["menu"] = SmartHr.Common.GetMenu(Session["empcode"].ToString().Trim(), Session["role"].ToString().Trim(), Convert.ToInt32(Request.QueryString["m"].ToString()));
                string a = Session["menu"].ToString();

                reportiees.Visible = false;
                Session["modulecode"] = Request.QueryString["m"].ToString();
            }
        }
        else
        {
            Session.Remove("menu");
            reportiees.Visible = true;
            Session["modulecode"] = "50";
            modulelogo.Visible = true;

            accordion1.Visible = false;
            useraccordion1.Visible = false;
        }

        GetPhotos();

        if (!IsPostBack)
        {
            if (Session["role"].ToString() == "16")
            {
                temp.Visible = true;
                accordion1.Visible = false;
                useraccordion1.Visible = false;
            }
            else
            {
                superadmin.Visible = true;
                BindApproverCount();
            }
        }

    }

    #region Approver Report
    public void BindApproverCount()
    {
        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @"select count(*) as EmployeeList from tbl_intranet_employee_jobDetails ej inner join tbl_employee_approvers ep on ep.empcode=ej.empcode and ep.app_reportingmanager='" + Session["empcode"].ToString() + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is null  and ej.status=1 ";
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                lblempcount.Text = ds.Tables[0].Rows[0]["EmployeeList"].ToString();
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    [WebMethod]
    public static Approver[] GetApproverList(string empcode)
    {
        List<Approver> details = new List<Approver>();
        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @"select 'admin/TeamMember_empDetail.aspx?empcode=' + ej.empcode empcode,emp_fname as name,designationname,photo,isnull(mode,'') as mode from tbl_intranet_employee_jobDetails ej inner join tbl_employee_approvers ep on ep.empcode=ej.empcode and ep.app_reportingmanager='" + empcode + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is null and ej.status=1  order by emp_fname";
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                Approver app = new Approver();
                app.empcode = dtrow["empcode"].ToString();
                app.empname = dtrow["name"].ToString();
                app.designation = dtrow["designationname"].ToString();

                //app.photo = (string.IsNullOrEmpty(dtrow["photo"].ToString()) != true) ? "Upload/photo/" + dtrow["photo"].ToString() + "" : "Upload/photo/image.png";
                if (dtrow["photo"].ToString() != "")
                {
                    if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("Upload/photo/" + dtrow["photo"].ToString() + "")))
                    {
                        app.photo = "Upload/photo/" + dtrow["photo"].ToString() + "";
                    }
                    else
                    {
                        app.photo = "Upload/photo/image.png";
                    }
                }
                else
                {
                    app.photo = "Upload/photo/image.png";
                }

                app.mode = dtrow["mode"].ToString();
                details.Add(app);
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return details.ToArray();
    }

    public class Approver
    {
        public string empcode { get; set; }
        public string empname { get; set; }
        public string designation { get; set; }
        public string photo { get; set; }
        public string mode { get; set; }
    }
    #endregion

    protected void btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/notlogged.aspx?logout=1");
    }

    protected void GetPhotos()
    {
        if (Session["photo"] != null)
        {
            if (Session["photo"].ToString() == "System.Data.DataSet")
            {
                string query = @"SELECT l.empcode empcode,g.photo photo FROM tbl_login l 
                                          INNER JOIN tbl_intranet_employee_jobDetails g ON g.empcode=l.empcode
                                           left Join tbl_intranet_employee_personalDetails p ON g.empcode = p.empcode 
                                            inner join tbl_intranet_role er on er.id=l.role
                                             WHERE l.empcode = '" + Session["empcode"].ToString() + "' and g.emp_doleaving is null";
                DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
                if (ds_1.Tables[0].Rows.Count > 0)
                {
                    image = ds_1.Tables[0].Rows[0]["photo"].ToString();

                    if (File.Exists(Server.MapPath("upload/photo/" + image + "")))
                    {
                        Str += "<img src='upload/photo/" + image + "' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                    }
                    else
                    {
                        Str += "<img src='images/av_1.png' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                    }
                }
            }
            else
            {
                if (File.Exists(Server.MapPath("upload/photo/" + Session["photo"].ToString() + "")))
                {
                    Str += "<img src='upload/photo/" + Session["photo"].ToString() + "' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                }
                else
                {
                    Str += "<img src='images/av_1.png' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                }
            }
        }
        else
        {
            Str += "<img src='images/av_1.png' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
        }

        if (Session["UploadedLogo"] != null)
        {
            if (File.Exists(Server.MapPath("Upload/logo/" + Session["UploadedLogo"].ToString() + "")))
            {
                Str_1 += "<img src='upload/logo/" + Session["UploadedLogo"].ToString() + "' class='avatar' style='width:180px;height:55px;padding-left:50px;padding-top:4px' />";
            }
            else
            {
                Str_1 += "<img src='images/sdl_logo_new.png' class='avatar' style='width:220px;padding-left: 50px;' />";
            }
        }
        else
        {
            Str_1 += "<img src='images/sdl_logo_new.png' class='avatar' style='width:220px;padding-left: 50px;' />";
        }

        if (Session["photo"] != null)
        {
            string a = Session["photo"].ToString();
            if (Session["photo"].ToString() == "System.Data.DataSet")
            {
                string query = @"SELECT l.empcode empcode,g.photo photo FROM tbl_login l 
                                          INNER JOIN tbl_intranet_employee_jobDetails g ON g.empcode=l.empcode
                                           left Join tbl_intranet_employee_personalDetails p ON g.empcode = p.empcode 
                                            inner join tbl_intranet_role er on er.id=l.role
                                             WHERE l.empcode = '" + Session["empcode"].ToString() + "' and g.emp_doleaving is null";
                DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
                if (ds_1.Tables[0].Rows.Count > 0)
                {
                    image = ds_1.Tables[0].Rows[0]["photo"].ToString();

                    if (File.Exists(Server.MapPath("upload/photo/" + image + "")))
                    {
                        Str_2 += "<img src='../upload/photo/" + image + "' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                    }
                    else
                    {
                        Str_2 += "<img src='../images/av_1.png' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                    }
                }
            }
            else
            {
                if (File.Exists(Server.MapPath("upload/photo/" + Session["photo"].ToString() + "")))
                {
                    Str_2 += "<img src='../upload/photo/" + Session["photo"].ToString() + "' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                }
                else
                {
                    Str_2 += "<img src='../images/av_1.png' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
                }
            }
        }
        else
        {
            Str_2 += "<img src='../images/av_1.png' class='avatar' style='border-radius:12px 12px;width:100%;height:100%' />";
        }

        if (Session["photo"] != null)
        {
            if (Session["photo"].ToString() == "System.Data.DataSet")
            {
                string query = @"SELECT l.empcode empcode,g.photo photo FROM tbl_login l 
                                          INNER JOIN tbl_intranet_employee_jobDetails g ON g.empcode=l.empcode
                                           left Join tbl_intranet_employee_personalDetails p ON g.empcode = p.empcode 
                                            inner join tbl_intranet_role er on er.id=l.role
                                             WHERE l.empcode = '" + Session["empcode"].ToString() + "' and g.emp_doleaving is null";
                DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
                if (ds_1.Tables[0].Rows.Count > 0)
                {
                    image = ds_1.Tables[0].Rows[0]["photo"].ToString();

                    if (File.Exists(Server.MapPath("upload/photo/" + image + "")))
                    {
                        Str_3 += "<img src='upload/photo/" + image + "' class='avatar' style='width:100%;height:110px; border-radius: 50%' title='" + Session["name"].ToString() + "' />";
                    }
                    else
                    {
                        Str_3 += "<img src='images/av_1.png' class='avatar' style='width:100%;height:110px; border-radius: 50%' title='" + Session["name"].ToString() + "' />";
                    }
                }
            }
            else
            {

                if (File.Exists(Server.MapPath("upload/photo/" + Session["photo"].ToString() + "")))
                {
                    Str_3 += "<img src='upload/photo/" + Session["photo"].ToString() + "' class='avatar' style='width:100%;height:110px; border-radius: 50%' title='" + Session["name"].ToString() + "' />";
                }
                else
                {
                    Str_3 += "<img src='images/av_1.png' class='avatar' style='width:100%;height:110px; border-radius: 50%' title='" + Session["name"].ToString() + "' />";
                }
            }
        }
        else
        {
            Str_3 += "<img src='images/av_1.png' class='avatar' style='width:100%;height:110px; border-radius: 50%' title='" + Session["name"].ToString() + "' />";
        }

        Session["PerPhoto"] = Str;
        Session["Uploaded_logo"] = Str_1;
        Session["PerEmpPhoto"] = Str_2;
        Session["PhotoForHome"] = Str_3;

    }

    protected void btn_GoToMain_Click(object sender, EventArgs e)
    {
        Session["position"] = 1;
        Response.Redirect("~/home.aspx");
    }

}