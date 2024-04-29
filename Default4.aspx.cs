using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (Request.QueryString["m"] != null)
        {
            Session["menu"] = SmartHr.Common.GetMenu(Session["empcode"].ToString().Trim(), Session["role"].ToString().Trim(), Convert.ToInt32(Request.QueryString["m"].ToString()));
            string a = Session["menu"].ToString();
        }
        else
        {
            Session["menu"] = SmartHr.Common.GetMenu(Session["empcode"].ToString().Trim(), Session["role"].ToString().Trim(), 7);
        }

        if (!IsPostBack)
        {

            string Str = "";

            if (Session["role"] != null)
            {
                string r = Session["photo"].ToString();
                if (Session["photo"].ToString() != "")
                    Str += "<img src='Upload/photo/" + Session["photo"].ToString() + "' class='avatar' />";
                //  MyImg.ImageUrl = "Upload/photo/" + Session["photo"].ToString();
                else Str += "<img src='Upload/photo/image.png' class='avatar'/>";

                Session["PerPhoto"] = Str;


                if (Session["role"].ToString() == "16")    // for temporary employee
                    temp.Visible = true;
                else
                    superadmin.Visible = true;

                //MyImg.ImageUrl = "Upload/photo/image.jpg";


                //if (Session["role"].ToString() == "1" || (Session["role"].ToString() == "11"))    // for Employee and Account Manager
                //    employee.Visible = true;

                //else if ((Session["role"].ToString() == "9")) // for HR  and manager
                //{
                //    hr.Visible = true;
                //    // admin.Visible = true;
                //}
                //else if ((Session["role"].ToString() == "10") || (Session["role"].ToString() == "3") || (Session["role"].ToString() == "12")) // for Management  and Admin
                //{
                //    admindash.Visible = true;
                //    //  admin.Visible = true;
                //}



            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }
}