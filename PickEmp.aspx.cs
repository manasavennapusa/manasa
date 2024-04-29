using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PickEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindempdetail();
        }
    }

    protected void bindempdetail()
    {

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recuitment_get_employee_in_hr_letter");
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

    //protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    empgrid.PageIndex = e.NewPageIndex;
    //    bindempdetail();
    //}

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    //protected void empgrid_PreRender(object sender, EventArgs e)
    //{
    //    if (empgrid.Rows.Count > 0)
    //        empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    //}


    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
          bindempdetail();
    }

}