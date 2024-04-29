using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;


public partial class payroll_admin_sanction_bonus : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string sqlstr;
    DataSet ds = new DataSet();
    string message2;
    Double ad;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";      
       
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");
            
            Session.Remove("aleave");
            bind_month();
            bind_year();
            dd_bonus.DataBind();
        }
    }

//***************************** Code to insert month in drop down **************************************//
   
    protected void bind_month()
    {
        dd_month.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month.SelectedValue = a.Month.ToString();
    }

    //***************************** Code to insert year in drop down **************************************//

    protected void bind_year()
    {
        dd_year.Items.Insert(0, new ListItem("Select Year", "0"));
        for (int i = 2009; i <= 2015; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year.SelectedValue = a.Year.ToString();
    }

//***************************** Code to create a data table **************************************//

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("month", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["month"] };
        dtable.Columns.Add("amount", typeof(string));
        dtable.Columns.Add("year", typeof(string));
        Session["aleave"] = dtable;
    }

 //***************************** Code to insert data in table **************************************//

    protected void adjustleave()
    {
        DataRow dr;
        if (Session["aleave"] == null)
        {
            createatable();
            
        }
        dtable = (DataTable)Session["aleave"];

        DataRow drfind = dtable.Rows.Find(dd_month.SelectedItem.Text.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Same month can not be added again";
        }        
        else
        {
            dr = dtable.NewRow();
            dr["month"] = dd_month.SelectedItem.Text.ToString();
            dr["year"] = dd_year.SelectedValue.ToString();
            dr["amount"] = txt_dispers.Text.ToString();
            dtable.Rows.Add(dr);
        }
        Session["aleave"] = dtable;
        bindadjustleave();
    }

    //***************************** Code to bind data table data in grid **************************************//
    
    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["aleave"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();

    }
    protected void btm_add_Click(object sender, EventArgs e)
    {
        if (validate_recover())
        {
           adjustleave();
           // validate_sum();
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //if (validate_recover())
        //{
            if (Session["aleave"] == null)
            {
                message.InnerHtml = "Please add diespersement details";
                return;
            }
            else
            {
                bool s = validate_sum();
                if (!s)
                {
                    message.InnerHtml = "Dispersement amount is not equal to total amount";
                    return;
                }
                else
                {
                    SqlParameter[] sqlparam = new SqlParameter[8];

                    sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparam[0].Value = txt_employee.Text.Trim().ToString();

                    sqlparam[1] = new SqlParameter("@bonus_id", SqlDbType.Int);
                    sqlparam[1].Value = dd_bonus.SelectedValue;

                    sqlparam[2] = new SqlParameter("@bonus_ref_no", SqlDbType.VarChar, 50);
                    sqlparam[2].Value = txt_remb_ref.Text.ToString();

                    sqlparam[3] = new SqlParameter("@sanction_date", SqlDbType.DateTime);
                    sqlparam[3].Value = Convert.ToDateTime(txt_sanct.Text.ToString());

                    sqlparam[4] = new SqlParameter("@amount", SqlDbType.Decimal);
                    sqlparam[4].Value = txt_remb_amount.Text.ToString();
                    HiddenField1.Value = txt_remb_amount.Text.ToString();

                    sqlparam[5] = new SqlParameter("@detail", SqlDbType.VarChar, 500);
                    sqlparam[5].Value = txt_detail.Text.ToString().Trim();

                    sqlparam[6] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                    sqlparam[6].Value = Session["name"].ToString();

                    sqlparam[7] = new SqlParameter("@createddate", SqlDbType.DateTime);
                    sqlparam[7].Value = System.DateTime.Now;

                    int a = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_apply_bonus", sqlparam));

                    if (a > 0)
                    {
                        insert_disperse_amount(a);

                        clear();
                    }
                    else
                    {
                        message.InnerHtml = "Reference number already exist";
                    }
                }
            }
      }

    //***************************** Code to insert data into table from data table  **************************************//


    protected void insert_disperse_amount(int b)
    {
       try
        {
            dtable = (DataTable)Session["aleave"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlstr = "insert into tbl_payroll_employee_bonus_detail(emp_bonus_id,month,year,amount) values (@emp_bonus_id,@month,@year,@amount)";
                    sqlparm = new SqlParameter[4];

                    sqlparm[0] = new SqlParameter("@emp_bonus_id", SqlDbType.Int);
                    sqlparm[0].Value = b;

                    sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
                    sqlparm[1].Value = dtable.Rows[i]["month"].ToString();

                    sqlparm[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
                    sqlparm[2].Value = dtable.Rows[i]["year"].ToString();

                    sqlparm[3] = new SqlParameter("@amount", SqlDbType.Decimal);
                    sqlparm[3].Value = Convert.ToDecimal(dtable.Rows[i]["amount"].ToString());
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
                message.InnerHtml = "Bonus sanctioned successfully";
            }
        }
        catch (Exception ex)
        {
        }
    }

    //***************************** Code to match amount in main table and in disperse table  **************************************//

    protected bool validate_sum()
    {
        dtable = (DataTable)Session["aleave"];
        
        for (int d = 0; d < dtable.Rows.Count; d++)
        {
             ad = ad +  Convert.ToDouble(dtable.Rows[d]["amount"].ToString());
        }
         if (ad != Convert.ToDouble(txt_remb_amount.Text.ToString()))
         {
             return false;
         }
         else
         {
             return true;
         }

    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        txt_detail.Text = "";
        txt_dispers.Text = "";
        txt_employee.Text = "";
        txt_remb_amount.Text = "";
        txt_remb_ref.Text = "";
        txt_sanct.Text = "";
        dd_bonus.SelectedIndex = -1;
        grid_aleave.DataSource = null;
        grid_aleave.DataBind();
        txt_dispers.Text = "";
        Session.Remove("aleave");
       
     }

    protected void grid_aleave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["aleave"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(grid_aleave.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            Session["aleave"] = dtable;
            bindadjustleave();
        }
    }

    //------------------------------------- Validation for Recover From  -----------------------------------
    protected Boolean validate_recover()
    {
        DateTime sd = Convert.ToDateTime(txt_sanct.Text);
        DateTime rd = Convert.ToDateTime(dd_month.SelectedValue + "/1/" + dd_year.SelectedValue);
        if ((findcycle(sd) > rd) || (findcycle(DateTime.Now) > rd))
        {
            message2 = "You can not apply for this bonus.Either change your sanction date or month from month/year.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message2.ToString() + "')</script>", false);
            return false;
        }
        return true;
    }

    protected DateTime findcycle(DateTime dt)
    {
        if (Convert.ToInt16(dt.Day) >= 26)
            dt = dt.AddMonths(1);
        dt = Convert.ToDateTime(dt.Month.ToString() + "/1/" + dt.Year.ToString());
        return dt;
    }    
}
