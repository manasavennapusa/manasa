using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformationCenter_Read_Employee_Satisfaction_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Year();
    }
    protected void griddetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void griddetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void griddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void griddetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {

    }
    public void Year()
    {
        drp_year.Items.Clear();
        drp_year.Items.Add(new ListItem("Select Year", "0"));

        for (int yr = 2013; yr <= DateTime.Now.Year; yr++)
        {
            drp_year.Items.Add(new ListItem(Convert.ToString(yr), yr.ToString()));
        }
    }
}