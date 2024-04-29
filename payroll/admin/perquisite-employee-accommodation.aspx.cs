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
using System.Data.SqlClient;
using DataAccessLayer;
public partial class payroll_admin_perquisite_employee_accommodation : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            ViewState["edit"] = "0";
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");

            //int year = DateTime.Now.Year;
            //int month = DateTime.Now.Month;

            //if (month <= 3)
            //    year = year - 1;

            //DateTime mindate = new DateTime(year, 4, 1);
            //DateTime maxdate = new DateTime(year + 1, 3, 31);
            //Range4from.Type=ValidationDataType.Date;
            //Range4to.Type = ValidationDataType.Date;

            //Range4from.MaximumValue = maxdate.ToString("MM/dd/yyyy");
            //Range4from.MinimumValue = mindate.ToString("MM/dd/yyyy");

            //Range4to.MaximumValue = maxdate.ToString("MM/dd/yyyy");
            //Range4to.MinimumValue = mindate.ToString("MM/dd/yyyy");
            bindgrid();
        }
    }
    protected void clear()
    {
        txt_employee.Text = "";
        txtamount.Text = "0.00";
        txtleasefrom.Text = "";
        txtleaseto.Text = "";
        btnsubmit.Text = "Submit";
        ViewState["edit"] = "0";
    }
    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    //protected void cal_accommodation()
    //{     

       


            

        
    //    DateTime.Today.Month>3 
    //    DateTime.Today.Year

    //    DateTime start, end, yearend;
    //    int i = 0; string year; decimal amount, day;
        
    //    start = Convert.ToDateTime(txtleasefrom.Text);
    //    end = Convert.ToDateTime(txtleaseto.Text);

    //    amount =Convert.ToDecimal(txtamount.Text);

    //    if (start.Month > 3)
    //    {
    //        year = Convert.ToString(start.AddYears(1).Year);
    //    }
    //    else
    //    {
    //        year = Convert.ToString(start.Year);
    //    }

        
    //    System.TimeSpan diffStEnd = start - end;

    //    day = amount / (diffStEnd.Days - 1);

    //    yearend = Convert.ToDateTime(year + "-03-31");
       
    //    DataRow dr;
    //    if (Session["perquisite"] == null)
    //    {
    //        create_perquisite_table();
    //    }
    //    dtable = (DataTable)Session["perquisite"];

    //    while (i == 0)
    //    {
    //        if (end > yearend)
    //        {
    //            object[] keyArrary = new object[1];
    //            keyArrary[0] = start.Year + '-' + yearend.Year;

    //            DataRow drfind = dtable.Rows.Find(keyArrary);
    //            if (drfind != null)
    //            {
    //                message.InnerHtml = "You can not add same peruisite detail.";
    //            }
    //            else
    //            {
    //                System.TimeSpan diffStYrend = start - yearend;
    //                dr = dtable.NewRow();
    //                if (start.Month > 3)
    //                {
    //                    dr["fyear"] = start.Year.ToString() + '-' + yearend.Year.ToString();
    //                }
    //                else
    //                {
    //                    dr["fyear"] = start.AddYears(-1).Year.ToString() + '-' + yearend.Year.ToString();
    //                }
    //                dr["amount"] = System.Math.Round((diffStYrend.Days - 1) * day,2);
    //                dtable.Rows.Add(dr);

    //                start = yearend.AddDays(1);
    //                yearend = yearend.AddYears(1);
    //            }
    //        }
    //        else
    //        {
    //            object[] keyArrary = new object[1];
    //            keyArrary[0] = start.Year.ToString() + '-' + yearend.Year.ToString();

    //            DataRow drfind = dtable.Rows.Find(keyArrary);
    //            if (drfind != null)
    //            {
    //                message.InnerHtml = "You can not add same peruisite detail.";
    //            }
    //            else
    //            {
    //                 diffStEnd = start - end;

    //                dr = dtable.NewRow();
    //                dr["fyear"] = start.Year.ToString() + '-' + yearend.Year.ToString();
    //                dr["amount"] = System.Math.Round((diffStEnd.Days - 1) * day,2);
    //                dtable.Rows.Add(dr);
    //                i = 1;
    //            }
    //        }
    //    }

    //    Session["perquisite"] = dtable;
    //    bindgrid();
    //}


    //----------------------------------------creating table-----------------------------------------


    //----------------------------------Binding------------------------------------------

    protected void bindgrid()
    {
        strsql = "select id,fyear,empcode,convert(varchar,leasefrom,101) leasefrom,convert(varchar,leaseto,101) leaseto,amount,act_amount,case when status=1 then 'Metro' else 'Non-Metro' end Status from tbl_payroll_employee_perquisite_accommodation order by fyear,empcode";
      grid.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strsql);
      grid.DataBind();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    { 
       
            
            TimeSpan ts = Utilities.Utility.dataformat(txtleaseto.Text) - Utilities.Utility.dataformat(txtleasefrom.Text);
            
            SqlParameter[] sqlparam1;
            sqlparam1 = new SqlParameter[9];

            
            sqlparam1[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            if (ViewState["edit"].ToString() == "0")
                sqlparam1[0].Value = 0;
            else
                sqlparam1[0].Value = ViewState["edit"].ToString();

            sqlparam1[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
            sqlparam1[1].Value = dd_year.SelectedValue;

            sqlparam1[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam1[2].Value = txt_employee.Text.Trim().ToString();

            sqlparam1[3] = new SqlParameter("@leasefrom", SqlDbType.DateTime);
            sqlparam1[3].Value = Utilities.Utility.dataformat(txtleasefrom.Text.ToString());

            sqlparam1[4] = new SqlParameter("@leaseto", SqlDbType.DateTime);
            sqlparam1[4].Value = Utilities.Utility.dataformat(txtleaseto.Text.ToString());

            sqlparam1[5] = new SqlParameter("@amount", SqlDbType.Decimal);
            sqlparam1[5].Value = Convert.ToDecimal(txtamount.Text) * Math.Round(Convert.ToDecimal(ts.Days) / 30);

            sqlparam1[6] = new SqlParameter("@act_amount", SqlDbType.Decimal);
            sqlparam1[6].Value = Convert.ToDecimal(txtamount.Text) ;

            sqlparam1[7] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparam1[7].Value = Session["name"].ToString();

            sqlparam1[8] = new SqlParameter("@status", SqlDbType.Bit);
            sqlparam1[8].Value = CheckBox1.Checked;


            try
            {
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite_accommodation", sqlparam1);
                message.InnerHtml = "Lease Detail updated successfully";
            }
            catch (Exception ex)
            {
                message.InnerHtml = "Lease Detail already exist for Employee";
            }
            finally
            {
                bindgrid();
                clear();
            }
            }



    protected void Button1_Click(object sender, EventArgs e)
    {
        clear();
    }


    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ViewState["edit"]=grid.DataKeys[e.RowIndex].Value;
        dd_year.SelectedValue = ((Label)grid.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        txt_employee.Text=((Label)grid.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        txtleasefrom.Text=((Label)grid.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        txtleaseto.Text=((Label)grid.Rows[e.RowIndex].Cells[3].Controls[1]).Text;
        if (((Label)grid.Rows[e.RowIndex].Cells[4].Controls[1]).Text == "Metro")
            CheckBox1.Checked = true;
        else
            CheckBox1.Checked = false;


        txtamount.Text=((Label)grid.Rows[e.RowIndex].Cells[5].Controls[1]).Text;
        btnsubmit.Text = "Modify";
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strsql = "delete from tbl_payroll_employee_perquisite_accommodation where id=" + grid.DataKeys[e.RowIndex].Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strsql);
        bindgrid();
    }
}
