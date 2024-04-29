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
using System.Text;
public partial class payroll_admin_perquisite_employee_accommodation : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string strsql;
    DataSet ds = new DataSet();
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
            dd_branch.DataBind();
            dd_designation.DataBind();
            bindgrid();
        }
    }

    protected void clear()
    {
        txt_employee.Text = "";
        txtamount.Text = "0.00";
        btnsubmit.Text = "Submit";
        CheckBox1.Checked = false;
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
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txtempcode.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[4].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_tds_ammendment]", sqlparam);
        grid.DataSource = ds;
        grid.DataBind();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    { 
        SqlParameter[] sqlparam1;
        sqlparam1 = new SqlParameter[4];

        sqlparam1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam1[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam1[1] = new SqlParameter("@amount", SqlDbType.Decimal);
        sqlparam1[1].Value = Convert.ToDecimal(txtamount.Text);

        sqlparam1[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam1[2].Value = Session["name"].ToString();

        sqlparam1[3] = new SqlParameter("@status", SqlDbType.Bit);
        sqlparam1[3].Value = CheckBox1.Checked;
        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tax_amendment", sqlparam1);
            message.InnerHtml = "TDS Amendment done successfully";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem occured,Try Latter";
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
        ViewState["edit"]=1;
        txt_employee.Text=((Label)grid.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        txtamount.Text = ((Label)grid.Rows[e.RowIndex].Cells[3].Controls[1]).Text;
        if (((Label)grid.Rows[e.RowIndex].Cells[2].Controls[1]).Text == "Yes")
            CheckBox1.Checked = true;
        else
            CheckBox1.Checked = false;
        btnsubmit.Text = "Modify";
    }

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strsql = "delete from tbl_payroll_employee_tds_amendment where empcode=" + grid.DataKeys[e.RowIndex].Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strsql);
        bindgrid();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void update()
    {
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            CheckBox chkstatusg = (CheckBox)grid.Rows[i].Cells[0].FindControl("chkstatusg");
            if (chkstatusg != null)
            {
                 Label lblempcodeg = (Label)grid.Rows[i].Cells[0].FindControl("lblempcodeg");
                 TextBox txtamountg = (TextBox)grid.Rows[i].Cells[0].FindControl("txtamountg");
                                            
                SqlParameter[] sqlparam1;
                sqlparam1 = new SqlParameter[4];

                sqlparam1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlparam1[0].Value = lblempcodeg.Text.Trim().ToString();

                sqlparam1[1] = new SqlParameter("@amount", SqlDbType.Decimal);
                sqlparam1[1].Value = Convert.ToDecimal(txtamountg.Text);

                sqlparam1[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                sqlparam1[2].Value = Session["name"].ToString();

                sqlparam1[3] = new SqlParameter("@status", SqlDbType.Bit);
                sqlparam1[3].Value = chkstatusg.Checked;
                try
                {
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tax_amendment", sqlparam1);
                }
                catch (Exception ex)
                {
                    message.InnerHtml = "Problem occured,Try Latter";
                }
                finally
                {
                    
                } 
            }
       }
       bindgrid();
       
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
       update();
    }

    protected void btnupdate1_Click(object sender, EventArgs e)
    {
       update();
    }

}
