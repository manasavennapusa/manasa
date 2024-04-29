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

public partial class payroll_admin_edit_bonus_detail : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string sqlstr;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;
    Double ad;
    string message2;

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
            bind_reimbursement();
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

    protected void bind_reimbursement()
    {
        sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@bonus_id", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Request.QueryString["bonus_id"].ToString();

        sqlparam[1] = new SqlParameter("@id", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Request.QueryString["id"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_bonus_detail", sqlparam);      
        txt_detail.Text = ds.Tables[0].Rows[0]["detail"].ToString();
        txt_employee.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        txt_remb_amount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
        txt_remb_ref.Text = ds.Tables[0].Rows[0]["bonus_ref_no"].ToString();
        txt_sanct.Text = ds.Tables[0].Rows[0]["sanction_date"].ToString();
        dd_bonus.SelectedItem.Text = ds.Tables[0].Rows[0]["payhead_name"].ToString();

        HiddenField1.Value = ds.Tables[0].Rows[0]["bonus_ref_no"].ToString();

        if (Session["aleave"] == null)
        {
            createatable();
        }
        DataRow dr;
        DataTable sdata;

        sdata = (DataTable)Session["aleave"];

        for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
        {
            dr = sdata.NewRow();
            dr["month"] = (ds.Tables[1].Rows[i]["month"] != null) ? ds.Tables[1].Rows[i]["month"].ToString() : "";
            dr["year"] = (ds.Tables[1].Rows[i]["year"] != null) ? ds.Tables[1].Rows[i]["year"].ToString() : "";
            dr["amount"] = (ds.Tables[1].Rows[i]["disperse_amount"] != null) ? ds.Tables[1].Rows[i]["disperse_amount"].ToString() : "";
            sdata.Rows.Add(dr);
        }
        Session["aleave"] = sdata;
        bindadjustleave();
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
            //validate_sum();
        }
    }

    protected void submit()
    {
        //if(validate_recover())
        //{
        try
        {
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
                    SqlParameter[] sqlparam = new SqlParameter[9];

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
                    //HiddenField1.Value = txt_remb_amount.Text.ToString();

                    sqlparam[5] = new SqlParameter("@detail", SqlDbType.VarChar, 500);
                    sqlparam[5].Value = txt_detail.Text.ToString().Trim();

                    sqlparam[6] = new SqlParameter("@MODIFIEDBY", SqlDbType.VarChar, 100);
                    sqlparam[6].Value = Session["name"].ToString();

                    sqlparam[7] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
                    sqlparam[7].Value = System.DateTime.Now;

                    sqlparam[8] = new SqlParameter("@id", SqlDbType.Int);
                    sqlparam[8].Value = Request.QueryString["id"].ToString();

                    DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_update_bonus", sqlparam);

                    insert_disperse_amount();
                }

            }

        }
        catch (Exception ex)
        {
            message.InnerHtml = "Reference number already exist";
        }
        //}
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (txt_remb_ref.Text == HiddenField1.Value)
            submit();
        else
        {
            if (validate_name())
                submit();
        }   
    }

    //***************************** Code to insert data into table from data table  **************************************//


    protected void insert_disperse_amount()
    {
        try
        {
            dtable = (DataTable)Session["aleave"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparam;

                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@emp_bonus_id", SqlDbType.VarChar, 50);
                sqlparam[0].Value = Request.QueryString["id"].ToString();
                sqlstr = "delete from tbl_payroll_employee_bonus_detail where emp_bonus_id=@emp_bonus_id";
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                   sqlparam=new SqlParameter[4];

                    sqlstr = "insert into tbl_payroll_employee_bonus_detail(emp_bonus_id,month,year,amount) values (@emp_bonus_id,@month,@year,@amount)";
                    sqlparam[0] = new SqlParameter("@emp_bonus_id", SqlDbType.Int);
                    sqlparam[0].Value = Request.QueryString["id"].ToString();

                    sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
                    sqlparam[1].Value = dtable.Rows[i]["month"].ToString();

                    sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
                    sqlparam[2].Value = dtable.Rows[i]["year"].ToString();

                    sqlparam[3] = new SqlParameter("@amount", SqlDbType.Decimal);
                    sqlparam[3].Value = Convert.ToDecimal(dtable.Rows[i]["amount"].ToString());
                   
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);
                }
                Response.Redirect("view_bonus.aspx?message=Sanctioned bonus updated successfully");
                //message.InnerHtml = "Sanctioned bonus updated successfully";
            }
        }
        catch (Exception ex)
        {
        }
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Session.Remove("aleave");
        bind_reimbursement();
    }
    //***************************** Code to match amount in main table and in disperse table  **************************************//

    protected bool validate_sum()
    {
        dtable = (DataTable)Session["aleave"];

        for (int d = 0; d < dtable.Rows.Count; d++)
        {
            ad = ad + Convert.ToDouble(dtable.Rows[d]["amount"].ToString());
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

    //------------------------------------------- Check for Reference No. ---------------------------------------------//

    protected Boolean validate_name()
    {
        sqlstr = @"SELECT count(bonus_ref_no) FROM tbl_payroll_employee_bonus WHERE bonus_ref_no='" + txt_remb_ref.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This Reference No. already exists.Please enter some other Reference No.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_remb_ref.Text = "";
            return false;
        }
        return true;
    }
}
