using System;
using System.Data;
using System.Data.SqlTypes;
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

public partial class payroll_admin_taxMasterslab : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            insert_slabrate();
            insert_slabtax();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            message.InnerHtml = "Tax Slab Successfully inserted";
        }
    }

    protected void insert_slabrate()
    {
        try
        {
            dtable = (DataTable)Session["slab1"];

            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlstr = "insert into tbl_taxslabforNHIF(slab,min_amount,max_amount,fixed_amount,start_date,end_date,status) values (@slab,@min_amount,@max_amount,@fixed_amount,@start_date,@end_date,1)";
                    sqlparm = new SqlParameter[6];

                    sqlparm[0] = new SqlParameter("@slab", SqlDbType.VarChar , 50);
                    sqlparm[0].Value = dtable.Rows[i]["slabnhif"].ToString();

                    sqlparm[1] = new SqlParameter("@min_amount", SqlDbType.Decimal);
                    sqlparm[1].Value = Convert.ToDecimal(dtable.Rows[i]["minimumamount"].ToString());

                    sqlparm[2] = new SqlParameter("@max_amount", SqlDbType.Decimal);
                    if (dtable.Rows[i]["maximumamount"].ToString() == "")
                    {
                        sqlparm[2].Value = System.Data.SqlTypes.SqlDecimal.Null;

                    }
                    else
                    {
                        sqlparm[2].Value = Convert.ToDecimal(dtable.Rows[i]["maximumamount"].ToString());
                    }
                    sqlparm[3] = new SqlParameter("@fixed_amount", SqlDbType.Decimal);
                    sqlparm[3].Value = Convert.ToDecimal(dtable.Rows[i]["fixedamount"].ToString());
                    sqlparm[4] = new SqlParameter("@start_date", SqlDbType.DateTime);
                    sqlparm[4].Value = Convert.ToDateTime(dtable.Rows[i]["startdate"].ToString());
                    sqlparm[5] = new SqlParameter("@end_date", SqlDbType.DateTime);
                    sqlparm[5].Value = Convert.ToDateTime(dtable.Rows[i]["enddate"].ToString());

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
            }
        }

        catch (Exception ex)
        {
        }
    }

    protected void insert_slabtax()
    {
        try
        {
            dtable = (DataTable)Session["taxslab"];

            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlstr = "insert into tbl_taxslabforPaye(slab_no,min_amount,max_amount,tax_pre,fixed_amount,mrp_amount,status) values (@slabNo,@min_amount,@max_amount,@taxper,@fixedamount,@mrpamount,1)";
                    sqlparm = new SqlParameter[6];

                    sqlparm[0] = new SqlParameter("@slabNo", SqlDbType.VarChar , 50);
                    sqlparm[0].Value = dtable.Rows[i]["slabNo"].ToString();

                    sqlparm[1] = new SqlParameter("@min_amount", SqlDbType.Decimal);
                    sqlparm[1].Value = Convert.ToDecimal(dtable.Rows[i]["minimumamount"].ToString());

                    sqlparm[2] = new SqlParameter("@max_amount", SqlDbType.Decimal);
                    if (dtable.Rows[i]["maximumamount"].ToString() == "")
                    {
                        sqlparm[2].Value = System.Data.SqlTypes.SqlDecimal.Null;

                    }
                    else
                    {
                        sqlparm[2].Value = Convert.ToDecimal(dtable.Rows[i]["maximumamount"].ToString());
                    }
                    sqlparm[3] = new SqlParameter("@taxper", SqlDbType.Decimal);
                    sqlparm[3].Value = Convert.ToDecimal(dtable.Rows[i]["taxper"].ToString());
                    sqlparm[4] = new SqlParameter("@fixedamount", SqlDbType.Decimal);
                    sqlparm[4].Value = Convert.ToDecimal(dtable.Rows[i]["fixedamount"].ToString());
                    sqlparm[5] = new SqlParameter("@mrpamount", SqlDbType.Decimal);
                    sqlparm[5].Value = Convert.ToDecimal(dtable.Rows[i]["mrpamount"].ToString());

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
            }
        }

        catch (Exception ex)
        {
        }
    }
   
    protected void btn_add_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            adjustleave();
        }
    }
    protected void tax_grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["slab1"];
        if (Convert.ToInt32(e.RowIndex) <= dtable.Rows.Count - 1)
        {
            txt_min_amt.Text = Convert.ToString(tax_grid.DataKeys[e.RowIndex].Value);
            int count = dtable.Rows.Count - 1;
            for (int i = Convert.ToInt32(e.RowIndex); i <= count; i++)
            {
                DataRow drfind = dtable.Rows.Find(Convert.ToString(tax_grid.DataKeys[i].Value));
                if (drfind != null)
                {
                    drfind.Delete();
                }
            }
            Session["slab1"] = dtable;

        }
        bindadjustleave();
    }

    protected void adjustleave()
    {
        DataRow dr;

        if (Session["slab1"] == null)
        {
            createatable();
       }

        dtable = (DataTable)Session["slab1"];

        DataRow drfind = dtable.Rows.Find(txt_min_amt.Text.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Same minimum amount can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["slabnhif"] = txt_nhif.Text.ToString();
            dr["maximumamount"] = txt_max_amt.Text.ToString();
            dr["minimumamount"] = txt_min_amt.Text.ToString();
            dr["fixedamount"] = txt_fx_amt.Text.ToString();

            if (txt_max_amt.Text != "")
            {
                txt_min_amt.Text = Convert.ToString(Convert.ToInt32(txt_max_amt.Text.ToString()) + 1);
            }
            else
            {
            }
            dr["startdate"] = txtstartdate.Text.ToString();
            dr["enddate"] = txtenddate.Text.ToString();
            dtable.Rows.Add(dr);
        }
        Session["slab1"] = dtable;
        clear();
        bindadjustleave();
    }

    protected void clear()
    {
        txt_max_amt.Text = "";
        txtstartdate.Text = "";
        txtenddate.Text = "";
        txt_nhif.Text = "";
        txt_min_amt.Text = "";
        txt_fx_amt.Text = "";
    }

    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["slab1"];
        tax_grid.DataSource = dtable;
        tax_grid.DataBind();
    }

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("slabnhif", typeof(string));
        dtable.Columns.Add("minimumamount", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["minimumamount"] };
        dtable.Columns.Add("maximumamount", typeof(string));      
        dtable.Columns.Add("fixedamount", typeof(string));
        dtable.Columns.Add("startdate", typeof(string));
        dtable.Columns.Add("enddate", typeof(string));
        Session["slab1"] = dtable;
    }

    public Boolean validate()
    {
        if (txt_max_amt.Text != "")
        {
            if (Convert.ToDecimal(txt_min_amt.Text.ToString()) > Convert.ToDecimal(txt_max_amt.Text.ToString()))
            {
                message.InnerHtml = "Minimum amount can not be greater than maximum amount";
                return false;
            }
            else
            {
                return true;
            }
        }
        else
            return true;
    }

    protected void adjustSlab()
    {
        DataRow dr;

        if (Session["taxslab"] == null)
        {
            createatable1();
        }
       

        dtable = (DataTable)Session["taxslab"];

        DataRow drfind = dtable.Rows.Find(txt_maxamt.Text.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Same minimum amount can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["slabNo"] = txt_slab_no.Text.ToString();
            dr["minimumamount"] = txt_min_amt1.Text.ToString();
            dr["maximumamount"] = txt_maxamt.Text.ToString();
            dr["taxper"] = txt_taxper.Text.ToString();

            if (txt_maxamt.Text != "")
            {
                txt_min_amt1.Text = Convert.ToString(Convert.ToInt32(txt_maxamt.Text.ToString()) + 1);
            }
            else
            {
            }
            dr["fixedamount"] = txt_fix.Text.ToString();
            dr["mrpamount"] = txt_mrp.Text.ToString();
            dtable.Rows.Add(dr);
        }
        Session["taxslab"] = dtable;
        clear1();
        bindadjusttaxslab();
    }

    private void clear1()
    {
        txt_slab_no.Text = "";
        txt_min_amt1.Text = "";
        txt_maxamt.Text = "";
        txt_taxper.Text = "";
        txt_fix.Text = "";
        txt_mrp.Text = "";
    }

    protected void createatable1()
    {
        dtable = new DataTable();
        dtable.Columns.Add("slabNo", typeof(string));
        dtable.Columns.Add("minimumamount", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["minimumamount"] };
        dtable.Columns.Add("maximumamount", typeof(string));
        dtable.Columns.Add("taxper", typeof(string));
        dtable.Columns.Add("fixedamount", typeof(string));
        dtable.Columns.Add("mrpamount", typeof(string));
        Session["taxslab"] = dtable;
    }

    protected void bindadjusttaxslab()
    {
        dtable = (DataTable)Session["taxslab"];
        grid_tax.DataSource = dtable;
        grid_tax.DataBind();
    }
    protected void grid_tax_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["taxslab"];
        if (Convert.ToInt32(e.RowIndex) <= dtable.Rows.Count - 1)
        {
            txt_min_amt1.Text = Convert.ToString(grid_tax.DataKeys[e.RowIndex].Value);
            int count = dtable.Rows.Count - 1;
            for (int i = Convert.ToInt32(e.RowIndex); i <= count; i++)
            {
                DataRow drfind = dtable.Rows.Find(Convert.ToString(grid_tax.DataKeys[i].Value));
                if (drfind != null)
                {
                    drfind.Delete();
                }
            }
            Session["taxslab"] = dtable;

        }
        bindadjusttaxslab();
    }
    protected void btnslbtax_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            adjustSlab();
        }
    }
}