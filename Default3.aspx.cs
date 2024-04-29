using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Text;

public partial class Default3 : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        //  getlogindetails();
        if (!IsPostBack)
        {

            if (Session["role"] != null)
            {
                getnewemployess();
                if (Session["role"].ToString() == "5") // Mng
                {
                    GetDeptAttendance();                 //nc
                    GetBirthdayAnniversaries();

                    GetEventCalander();
                    //    GetFeeds("");
                    adminpendingtask("active");

                    Session["info"] = info("Welcome to TriMedx India Pvt. Ltd.");
                    //  Session["warning"] = Latein();

                }
                else if ((Session["role"].ToString() == "9")||(Session["role"].ToString() == "10")) // HR or Management
                {
                    GetDeptAttendance();
                    GetBirthdayAnniversaries();
                    GetEventCalander();
                    GetLeaveBalance();                      //nc
                    GetAttendancePanel();
                    GetAttendance();
                    adminpendingtask("active");
                    hrpendingtask("");
                    GetFeeds("");

                    Session["info"] = info("Welcome to TriMedx India Pvt. Ltd.");
                    Session["success"] = Latein();




                    //  Session["warning"] = Latein();
                }
                else if ((Session["role"].ToString() == "2")||(Session["role"].ToString() == "11")  )  //account Manager or admin or manager
                {
                    GetDeptAttendance();
                    GetBirthdayAnniversaries();
                    GetEventCalander();
                    GetLeaveBalance();
                    GetAttendancePanel();
                    GetAttendance();
                    adminpendingtask("active");

                    Session["info"] = info("Welcome to TriMedx India Pvt. Ltd.");
                    Session["success"] = Latein();


                }
                else if (Session["role"].ToString() == "3")//super admin
                {
                    GetDeptAttendance();
                    GetBirthdayAnniversaries();

                    GetEventCalander();
                    GetFeeds("");
                    GetLeaveBalance();
                    GetAttendancePanel();
                    GetAttendance();
                    adminpendingtask("active");
                    hrpendingtask("");
                    GetLeaveBalance();
                    GetAttendancePanel();
                    GetAttendance();

                    Session["info"] = info("Welcome to TriMedx India Pvt. Ltd.");
                    Session["success"] = Latein();

                    //    Session["warning"] = Latein();
                    //   Session["danger"] = danger("");

                }
                else if (Session["role"].ToString() == "1") //user
                {
                    //deptatt.Visible = false;
                    GetBirthdayAnniversaries();
                    GetEventCalander();
                    GetLeaveBalance();
                    GetAttendancePanel();
                    GetAttendance();
                    //  GetFeeds("active");
                    Session["info"] = info("Welcome to TriMedx India Pvt. Ltd.");
                    Session["success"] = Latein();

                    task.Visible = false;
                }


            }
            else
                Response.Redirect("~/notlogged.aspx");

        }
    }

    private string info(string msg)
    {

        return "<div class='alert alert-info fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Info!</strong> " + msg + ". </div>";

    }

    private string success(string msg)
    {
        return "<div class='alert alert-success fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Today's Attendance!</strong> " + msg + ". </div>";

    }

    private string warning(string msg)
    {
        return "<div class='alert alert-warning fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Warning!</strong> " + msg + ". </div>";
    }

    private string danger(string msg)
    {
        return "<div class='alert alert-danger fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Error!</strong> " + msg + ". </div>";
    }

    private string Latein()
    {
        SqlParameter[] sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();
        string msg = "";
        DataSet loginds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "getlogindetails", sqlparm);
        if (loginds4.Tables.Count > 0)
        {
            if (loginds4.Tables[0].Rows.Count > 0)
            {
                msg = "LoginTime:" + "&nbsp;&nbsp;";
                if (loginds4.Tables[0].Rows[0]["intime"].ToString() != "")
                {
                    msg = msg + Convert.ToDateTime(loginds4.Tables[0].Rows[0]["intime"].ToString()).ToShortTimeString();
                    if ((Convert.ToBoolean(loginds4.Tables[0].Rows[0]["earlyin"].ToString()) == false) && (Convert.ToBoolean(loginds4.Tables[0].Rows[0]["latein"].ToString()) == false))
                        msg = msg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Login Status:" + "&nbsp;&nbsp;" + "correct time";
                    else if (Convert.ToBoolean(loginds4.Tables[0].Rows[0]["earlyin"].ToString()) == true)
                        msg = msg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "LoginStatus:" + "&nbsp;&nbsp;" + "Early in";
                    else if (Convert.ToBoolean(loginds4.Tables[0].Rows[0]["latein"].ToString()) == true)
                        msg = msg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Login Status:" + "&nbsp;&nbsp;" + "Late in";
                    //btnLogin.Enabled = false;
                    //btnlogout.Enabled = true;

                }

                msg = msg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                        + "Date:" + "&nbsp;&nbsp;" + Convert.ToDateTime(loginds4.Tables[0].Rows[0]["date"].ToString()).ToShortDateString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                        + "Day:" + "&nbsp;&nbsp;" + Convert.ToDateTime(loginds4.Tables[0].Rows[0]["date"].ToString()).DayOfWeek.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                DataSet loginds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "getlogoutdetails", sqlparm);
                if (loginds2.Tables.Count > 0)
                {
                    if (loginds2.Tables[0].Rows.Count > 0)
                    {
                        if (loginds2.Tables[0].Rows[0]["outtime"].ToString() != "")
                        {
                            //   btnLogin.Text = "Login";
                            msg = msg + "OutTime:" + "&nbsp;&nbsp;" + Convert.ToDateTime(loginds2.Tables[0].Rows[0]["outtime"].ToString()).ToShortTimeString();
                            if ((Convert.ToBoolean(loginds2.Tables[0].Rows[0]["earlyout"].ToString()) == false) && (Convert.ToBoolean(loginds2.Tables[0].Rows[0]["lateout"].ToString()) == false))
                                msg = msg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Logout Status:" + "&nbsp;&nbsp;" + "correct time";
                            else if (Convert.ToBoolean(loginds2.Tables[0].Rows[0]["earlyout"].ToString()) == true)
                                msg = msg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Logout Status:" + "&nbsp;&nbsp;" + "Early out";
                            else if (Convert.ToBoolean(loginds2.Tables[0].Rows[0]["lateout"].ToString()) == true)
                                msg = msg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Logout Status:" + "&nbsp;&nbsp;" + "Late out";
                            //   btnLogin.Enabled = true;
                            //  btnlogout.Enabled =false;
                        }


                    }
                }
                if (msg == "")
                {
                    return "<div class='alert alert-warning fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Login Details!</strong> Please Click login </div>";

                }
                else
                {
                    return "<div class='alert alert-warning fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Login Details!</strong> " + msg + ". </div>";

                }
            }
            else
            {
                return "<div class='alert alert-warning fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Login Details!</strong> Please Click login </div>";

            }
        }
        else
        {
            return "<div class='alert alert-warning fade in'><i class='icon-remove close' data-dismiss='alert'></i><strong>Login Details!</strong> Please Click login </div>";

        }
    }

    private string GetInOutTime()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "getInOutTime", Session["empcode"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            if ((row["INTIME"] == null || row["INTIME"].ToString() == "") && row["OUTTIME"].ToString() != "")
            {
                return "Office intime: Login time is not recorded.  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Office outtime: " + Convert.ToDateTime(row["OUTTIME"].ToString()).ToShortTimeString();
            }
            else if ((row["INTIME"] == null || row["INTIME"].ToString() == "") && row["OUTTIME"].ToString() == "")
            {
                return "Office intime: Login time is not recorded.  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Office outtime: Log out time is not recorded";
            }
            else if ((row["INTIME"] != null || row["INTIME"].ToString() == "") && row["OUTTIME"].ToString() == "")
            {
                return "Office intime: " + Convert.ToDateTime(row["INTIME"].ToString()).ToShortTimeString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Office outtime: Log out time is not recorded";
            }
            else
            {
                return "Office intime: " + Convert.ToDateTime(row["INTIME"].ToString()).ToShortTimeString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Office outtime: " + Convert.ToDateTime(row["OUTTIME"].ToString()).ToShortTimeString();
            }

        }
        else
            return "Attendance is not processed for the current day.";

    }

    private void GetAttendancePanel()
    {
        StringBuilder str = new StringBuilder();
        str.Append("");
        str.Append("<div class='row'>");
        str.Append("<div class='col-md-12'>");
        str.Append("<div class='widget box'>");
        str.Append("<div class='widget-header'>");
        str.Append("<h4>");
        str.Append("<i class='icon-reorder'></i>Attendance</h4>");
        str.Append("<div class='toolbar no-padding'>");
        str.Append("<div class='btn-group'>");
        str.Append("<span class='btn btn-xs widget-collapse'><i class='icon-angle-down'></i></span>");
        str.Append("</div>");
        str.Append("</div>");
        str.Append("</div>");
        str.Append("<div class='widget-content'>");
        str.Append("<div id='chart_filled_blue' class='chart'>");
        str.Append("</div>");
        str.Append("</div>");


        str.Append("</div>");
        str.Append("</div>");
        str.Append("</div>");

        Session["GetAttendancePanel"] = str.ToString();
    }

    private void GetDeptAttendance()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "demoattendance");
        string dn = "";
        string pn = "";
        int i = 1;
        foreach (DataRow row in ds.Tables[0].Rows)
        {

            dn = dn + "'" + row["department_name"].ToString() + "'";
            pn = pn + row["present"].ToString();

            if (i != ds.Tables[0].Rows.Count)
            {
                dn = dn + ",";
                pn = pn + ",";
            }

            i++;
        }

        GetPiechart(ds.Tables[0].Rows.Count, dn, pn);
    }


    private void GetPiechart(int deptCount, string deptName, string present)
    {

        string pichart = "<script type ='text/javascript'> 'use strict';$(document).ready(function(){var c=[];var b='" + deptCount + "';var z=[" + deptName + "];var p=[" + present + "];for(var a=0;a<b;a++){c[a]={label:z[a],data:p[a]}}$.plot('#chart_simple',c,$.extend(true,{},Plugins.getFlotDefaults(),{series:{pie:{show:true,radius:1,label:{show:true}}},grid:{hoverable:true},tooltip:true,tooltipOpts:{content:'%p.0%, %s',shifts:{x:20,y:0}}}))});</script>";
        Session["Pie"] = pichart.ToString();
        Session["PigChartTag"] = GetPieChartTag().ToString();
    }

    private string GetPieChartTag()
    {
        return "<div class='col-md-6'><div class='widget box'><div class='widget-header'><h4><i class='icon-reorder'></i>Department Wise Attendance</h4><div class='toolbar no-padding'><div class='btn-group'><span class='btn btn-xs widget-collapse'><i class='icon-angle-down'></i></span></div></div></div><div class='widget-content'><div id='chart_simple' class='chart' style='height: 270px;'></div></div></div></div>";
    }


    private void GetBirthdayAnniversaries()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "demogetbirthdayanniversary");
        StringBuilder str = new StringBuilder();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            if (row["Occasion"].ToString() == "Birthday")
            {
                str.Append("<tr>");
                str.Append("<td class='checkbox-column'>");
                str.Append("<input type='checkbox' class='uniform'>");
                str.Append("</td>");
                str.Append("<td class='hidden-xs'>");
                str.Append(row["fname"].ToString());
                str.Append("</td>");
                str.Append("<td>");
                str.Append(row["lname"].ToString());
                str.Append("</td>");
                str.Append("<td>");
                str.Append(" <span class='label label-success'>" + row["Occasion"].ToString() + "</span>");
                str.Append("</td>");
                str.Append("<td class='align-center'>");
                str.Append(row["dob"].ToString());
                str.Append("</td>");
                str.Append("</tr>");
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td class='checkbox-column'>");
                str.Append("<input type='checkbox' class='uniform'>");
                str.Append("</td>");
                str.Append("<td class='hidden-xs'>");
                str.Append(row["fname"].ToString());
                str.Append("</td>");
                str.Append("<td>");
                str.Append(row["lname"].ToString());
                str.Append("</td>");
                str.Append("<td>");
                str.Append(" <span class='label label-info'>" + row["Occasion"].ToString() + "</span>");
                str.Append("</td>");
                str.Append("<td class='align-center'>");
                str.Append(row["dob"].ToString());
                str.Append("</td>");
                str.Append("</tr>");

            }

        }

        Session["Birthday"] = str.ToString();
    }

    public void getnewemployess()
    {

        sqlstr = @"SELECT job.emp_fname as empname, job.photo,desig.designationname FROM tbl_intranet_employee_jobDetails job inner join tbl_intranet_designation desig on 
        job.degination_id=desig.id WHERE convert(datetime,convert(varchar(10),emp_doj,101)) BETWEEN  DATEADD(DAY, -30,  convert(datetime,convert(varchar(10),GETDATE(),101)) ) and 
         convert(datetime,convert(varchar(10),GETDATE(),101)) ";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionstring"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        string str = "";
        str = str + "<li class='dropdown hidden-xs hidden-sm'> <a href='#' class='dropdown-toggle' data-toggle='dropdown'> ";
        str = str + "<i class='icon-female'></i> <span class='badge'></span> </a>";
        str = str + "<ul class='dropdown-menu extended notification' style ='min-height: 0px;overflow: auto;max-height: 600px;'> ";
        str = str + "<li class='title'> <p>New Joinings</p> </li>";
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            str = str + " <li> <a href='javascript:void(0);'> <span class='photo'>";
            str = str + "<img src='upload/photo/" + row["photo"].ToString() + "' alt=''></span> <span class='subject'>";
            str = str + "<span class='from'>" + row["empname"].ToString() + "</span> ";
            str = str + "<span class='time'></span> </span> ";
            str = str + "<span class='text'> " + row["designationname"].ToString() + " </span> </a> </li>  ";
        }
        str = str + "</ul> </li>";

        Session["NewEmployees"] = str;
    }

    /*
     * var b=new Date();
    var e=b.getDate();
    var a=b.getMonth();
    var f=b.getFullYear();
    var c={};
    if($("#calendar").width()<=400)
    {c={left:"title",center:"",right:"prev,next"}}
    else
    {c={left:"prev,next",center:"title",right:"month"}}
    $("#calendar").fullCalendar({disableDragging:false,header:c,editable:true,events:[
    {title:"All Day Event",start:new Date(f,a,1),backgroundColor:App.getLayoutColorCode("yellow")},
    {title:"Long Event",start:new Date(f,a,e-5),end:new Date(f,a,e-2),backgroundColor:App.getLayoutColorCode("green")},
    {title:"Repeating Event",start:new Date(f,a,e-3,16,0),allDay:false,backgroundColor:App.getLayoutColorCode("red")},
    {title:"Repeating Event",start:new Date(f,a,e+4,16,0),allDay:false,backgroundColor:App.getLayoutColorCode("green")},
    {title:"Meeting",start:new Date(f,a,e,10,30),allDay:false},
    {title:"Lunch",start:new Date(f,a,e,12,0),end:new Date(f,a,e,14,0),backgroundColor:App.getLayoutColorCode("grey"),allDay:false,},
    {title:"Birthday Party",start:new Date(f,a,e+1,19,0),end:new Date(f,a,e+1,22,30),backgroundColor:App.getLayoutColorCode("purple"),allDay:false,},
    {title:"Click for Google",start:new Date(f,a,28),end:new Date(f,a,29),backgroundColor:App.getLayoutColorCode("yellow"),url:"http://google.com/",}]})});
     */

    private void GetEventCalander()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "getevents", Session["empcode"].ToString());

        string str = "";
        str = str + "<script type ='text/javascript'> 'use strict';$(document).ready(function(){var b=new Date();var e=b.getDate();var a=b.getMonth();var f=b.getFullYear();var c={};if($('#calendar').width()<=400){c={left:'title',center:'',right:'prev,next'}}else{c={left:'prev,next',center:'title',right:''}}$('#calendar').fullCalendar({disableDragging:false,header:c,editable:true,events:[";
        int count = 1;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            // {title:"All Day Event",start:new Date(f,a,1),backgroundColor:App.getLayoutColorCode("yellow")},
            System.DateTime d = Convert.ToDateTime(row["eventdate"].ToString());
            int f = d.Year;
            int a = d.Month - 1;
            int e = d.Day;

            if (row["heading"].ToString() == "P")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('green')}";

            }
            else if (row["heading"].ToString() == "A")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('blue')}";

            }
            else if (row["heading"].ToString() == "W")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('red')}";

            }
            else if (row["heading"].ToString() == "(HF)")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "CO")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "CO(HF)")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "EL")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "EL(HF)")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "SL")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "SL(HF)")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "CL")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "CL(HF)")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "FL")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "PL")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('purple')}";
            }
            else if (row["heading"].ToString() == "ML")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('grey')}";
            }
            else if (row["heading"].ToString() == "H")
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('slate')}";
            }
            else
            {
                str = str + "{title:'" + row["heading"].ToString() + "',start:new Date(" + f + "," + a + "," + e + "),backgroundColor:App.getLayoutColorCode('yellow'),url:'http://www.google.com/',}";
            }


            if (count != ds.Tables[0].Rows.Count)
            {
                str = str + ",";
            }

            count++;

            // {title:"Long Event",start:new Date(f,a,e-5),end:new Date(f,a,e-2),backgroundColor:App.getLayoutColorCode("green")},
            // {title:"Repeating Event",start:new Date(f,a,e-3,16,0),allDay:false,backgroundColor:App.getLayoutColorCode("red")},
            // {title:"Repeating Event",start:new Date(f,a,e+4,16,0),allDay:false,backgroundColor:App.getLayoutColorCode("green")},
            // {title:"Meeting",start:new Date(f,a,e,10,30),allDay:false},
            // {title:"Lunch",start:new Date(f,a,e,12,0),end:new Date(f,a,e,14,0),backgroundColor:App.getLayoutColorCode("grey"),allDay:false,},
            // {title:"Birthday Party",start:new Date(f,a,e+1,19,0),end:new Date(f,a,e+1,22,30),backgroundColor:App.getLayoutColorCode("purple"),allDay:false,},
            // {title:"Click for Google",start:new Date(f,a,28),end:new Date(f,a,29),backgroundColor:App.getLayoutColorCode("yellow"),url:"http://google.com/",}]})});
        }

        str = str + "]})});</script>";
        Session["Calander"] = str.ToString();
    }

    public void GetFeeds(string status)
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "demoFeeds");
        StringBuilder str = new StringBuilder();
        str.Append("<div class='tab-pane " + status + "'' id='tab_feed_3'><div class='scroller' data-height='290px' data-always-visible='1' data-rail-visible='0'><ul class='feeds clearfix'>");
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            str.Append("<a href='admin/readfeedback.aspx'><li>");
            str.Append("<div class='col1'>");
            str.Append("<div class='content'>");
            str.Append("<div class='content-col1'>");
            str.Append("<div class='label label-success' style='padding:0px'>");
            // str.Append("<i class='icon-bell'>");
            str.Append(" <img style='height:32px;width: 33px;'   src=upload/photo/" + row["photo"].ToString() + " />");
            //str.Append(" </i>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("<div class='content-col2'>");
            str.Append("<div class='desc'>");
            str.Append(row["postedby"].ToString());
            str.Append("&nbsp;&nbsp;");
            str.Append(row["subject"].ToString());
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("<div class='col2'>");
            str.Append("<div class='date'>");

            str.Append(row["posteddate"].ToString());
            // str.Append(row["posteddate"].ToString());
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</li></a>");
            //str.Append("<div class='desc'>");
            //str.Append(row["subject"].ToString());
            //str.Append("</div>");
            //str.Append("div class='date'>");
            //str.Append(row["posteddate,postedby"].ToString());
            //str.Append("</div>");
        }
        str.Append("</ul></div></div>");
        Session["FeedsHeading"] = "<li><a href='#tab_feed_3' data-toggle='tab'>Feeds</a></li>";
        Session["Feeds"] = str.ToString();

    }

    void adminpendingtask(string status)
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "sp_getpendingtasks", Session["empcode"].ToString(), 0, 1);
        StringBuilder str = new StringBuilder();
        str.Append("");

        string[] leaveName = new string[4];
        leaveName[0] = "leave application";
        leaveName[1] = "compoff application";
        leaveName[2] = "od application";
        leaveName[3] = "compoff request application";

        string[] url = new string[4];
        url[0] = "leave/leave_approval.aspx?leavestatus=0&hr=0";
        url[1] = "leave/compoff_approval.aspx?compoffstatus=0&hr=0";
        url[2] = "leave/view_approverod.aspx";
        url[3] = "leave/viewapprovecompoff.aspx";

        DataRow rLA = ds.Tables[0].Rows[0];
        string[] pending = new string[4];
        pending[0] = rLA["leavecount"].ToString();

        DataRow rCO = ds.Tables[1].Rows[0];
        pending[1] = rCO["compoffcount"].ToString();
        DataRow rOD = ds.Tables[2].Rows[0];
        pending[2] = rOD["odcount"].ToString();
        DataRow rCOA = ds.Tables[3].Rows[0];
        pending[3] = rCOA["compoffmarkcount"].ToString();

        str.Append("<div class='tab-pane active' id='tab_feed_1'><div class='scroller' data-height='290px' data-always-visible='1' data-rail-visible='0'><ul class='feeds clearfix'>");

        for (int i = 0; i < 4; i++)
        {
            str.Append("<a href='" + url[i].ToString() + "'><li>");
            str.Append(" <div class='col1'>");
            str.Append(" <div class='content'>");
            str.Append("<div class='content-col1'>");
            str.Append("<div class='label label-success'>");
            str.Append("<i class='icon-bell'></i>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("<div class='content-col2'>");
            str.Append("<div class='desc'>");

            str.Append(" You have " + pending[i] + " " + leaveName[i].ToString() + ".</div>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("<div class='col2'>");
            str.Append("<div class='date'>");
            str.Append("");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</li></a>");
        }
        str.Append("</ul></div></div>");
        Session["AdminPendingTaskHeading"] = "<li class='active'><a href='#tab_feed_1' data-toggle='tab'>Manager Pending Task</a></li>";
        Session["AdminPendingTask"] = str.ToString();
    }

    void hrpendingtask(string status)
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "sp_getpendingtasks", Session["empcode"].ToString(), 1, 1);
        StringBuilder str = new StringBuilder();
        str.Append("");

        string[] leaveName = new string[2];
        leaveName[0] = "leave application";
        leaveName[1] = "compoff application";

        string[] url = new string[4];
        url[0] = "leave/leave_approval.aspx?leavestatus=1&hr=1";
        url[1] = "leave/compoff_approval.aspx?compoffstatus=1&hr=1";


        DataRow rLA = ds.Tables[0].Rows[0];
        string[] pending = new string[2];
        pending[0] = rLA["hrleavecount"].ToString();

        DataRow rCO = ds.Tables[1].Rows[0];
        pending[1] = rCO["hrcompoffcount"].ToString();

        str.Append("<div class='tab-pane " + status + "' id='tab_feed_2'><div class='scroller' data-height='290px' data-always-visible='1' data-rail-visible='0'><ul class='feeds clearfix'>");

        for (int i = 0; i < 2; i++)
        {
            str.Append("<a href='" + url[i].ToString() + "'><li>");
            str.Append(" <div class='col1'>");
            str.Append(" <div class='content'>");
            str.Append("<div class='content-col1'>");
            str.Append("<div class='label label-success'>");
            str.Append("<i class='icon-bell'></i>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("<div class='content-col2'>");
            str.Append("<div class='desc'>");

            str.Append(" You have " + pending[i] + " " + leaveName[i].ToString() + ".</div>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("<div class='col2'>");
            str.Append("<div class='date'>");
            str.Append("");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</li></a>");
        }
        str.Append("</ul></div></div>");
        Session["HRPendingTaskHeading"] = "<li><a href='#tab_feed_2' data-toggle='tab'>HR Pending Task</a></li>";
        Session["HRPendingTask"] = str.ToString();
    }

    private void GetLeaveBalance()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "demoleavebalance", Session["empcode"].ToString());
        double Total = 0.0;
        string str = "";
        DataRow row1 = ds.Tables[1].Rows[0];
        str = str + "<li class='dropdown hidden-xs hidden-sm'><a href='#' class='dropdown-toggle' data-toggle='dropdown'><i class='icon-tasks'></i><span class='badge'>" + row1["TotalBalance"].ToString() + "</span> </a><ul class='dropdown-menu extended notification'><li class='title'><p>You have " + row1["TotalBalance"].ToString() + " balance leave</p></li>";

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            str = str + "<li><a href='javascript:void(0);'><span class='task'><span class='desc'>" + row["displayleave"].ToString() + "</span> <span class='percent'>" + row["Balance"].ToString() + "</span> </span> <div class='progress progress-small'> <div style='width: " + getPercentage(Convert.ToDouble(row["Entitled_days"].ToString()), Convert.ToDouble(row["Balance"].ToString())) + "%;' class='progress-bar progress-bar-info'></div></div></a></li>";
            Total = Total + Convert.ToDouble(row["Balance"].ToString());
        }
        str = str + "</ul>";

        Session["LeaveBalance"] = str.ToString();

        DataRow row2 = ds.Tables[2].Rows[0];
        Session["TotalEmployes"] = row2["TotalEmployees"].ToString();

        string Graph1 = "";
        foreach (DataRow row3 in ds.Tables[3].Rows)
        {
            Graph1 = Graph1 + row3["TotalEmployees"].ToString();
            Graph1 = Graph1 + ",";

        }

        Session["DeptEmployees"] = Graph1.ToString();

        DataRow row4 = ds.Tables[4].Rows[0];

        Session["TotalResignedEmployees"] = row4["TotalResignedEmployees"].ToString();
        string Graph2 = "";

        foreach (DataRow row5 in ds.Tables[5].Rows)
        {
            Graph2 = Graph2 + row5["TotalResignedEmployees"].ToString();
            Graph2 = Graph2 + ",";
        }
        Session["DeptResignedEmployees"] = Graph2.ToString();
    }

    private int getPercentage(double entitle, double balance)
    {
        if (entitle == 0.0 && balance == 0.0)
        {
            return 0;
        }
        else
        {
            return Convert.ToInt32((balance * 100) / entitle);
        }
    }


    // correct functions

    public void GetAttendance()
    {

        string str1 = "";
        string midstr = "";

        str1 = "<script type='text/javascript'>";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "sp_getattendance", Session["empcode"].ToString().Trim());
        foreach (DataRow row in ds.Tables[0].Rows)
        {

            if (row["month"].ToString().ToLower() == "jan")
            {
                midstr = midstr + "[1262304000000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "feb")
            {
                midstr = midstr + "[1264982400000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "mar")
            {
                midstr = midstr + "[1267401600000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "apr")
            {
                midstr = midstr + "[1270080000000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "may")
            {
                midstr = midstr + "[1272672000000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "jun")
            {
                midstr = midstr + "[1275350400000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "jul")
            {
                midstr = midstr + "[1277942400000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "aug")
            {
                midstr = midstr + "[1280620800000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "sep")
            {
                midstr = midstr + "[1283299200000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "oct")
            {
                midstr = midstr + "[1285891200000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "nov")
            {
                midstr = midstr + "[1288569600000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "],";
            }
            if (row["month"].ToString().ToLower() == "dec")
            {
                midstr = midstr + "[1291161600000," + Convert.ToInt32(row["TotalPresent"].ToString()) + "]";
            }

        }

        str1 = str1 + "$(document).ready(function(){var b=[" + midstr + "];var a=[{label:'Total Present',data:b,color:App.getLayoutColorCode('blue')}];$.plot('#chart_filled_blue',a,$.extend(true,{},Plugins.getFlotDefaults(),{xaxis:{min:(new Date(2009,12,1)).getTime(),max:(new Date(2010,11,2)).getTime(),mode:'time',tickSize:[1,'month'],monthNames:['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'],tickLength:1},series:{lines:{fill:true,lineWidth:1.5},points:{show:true,radius:2.5,lineWidth:1.1},grow:{active:true,growings:[{stepMode:'maximum'}]}},grid:{hoverable:true,clickable:true},tooltip:true,tooltipOpts:{content:'%s: %y'}}))});";
        str1 = str1 + "</script>";

        Session["Attendance"] = str1;
    }

    //--------------- created by ramu on 3/2/2014 for login and logout times recorded-----------------
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[2];


        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@logtype", SqlDbType.VarChar, 1);
        sqlparm[1].Value = "L";




        DataSet loginds = new DataSet();

        loginds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sampleforloginandlogout", sqlparm);


        Session["success"] = "";
        Session["success"] = Latein();



    }

    //Alert message.
    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }



    protected void btnlogout_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[2];


        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@logtype", SqlDbType.VarChar, 1);
        sqlparm[1].Value = "O";

        //sqlparm[2] = new SqlParameter("@msg", SqlDbType.VarChar, 200);
        //sqlparm[2].Direction = ParameterDirection.Output;



        DataSet loginds1 = new DataSet();

        loginds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sampleforloginandlogout", sqlparm);

        //if (sqlparm[2].Value != null)
        //{
        //    ShowAlertMessage(sqlparm[2].Value.ToString());
        //}
        Session["success"] = "";
        Session["success"] = Latein();
    }


}





