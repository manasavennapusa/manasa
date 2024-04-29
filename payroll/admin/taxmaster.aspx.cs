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

public partial class payroll_admin_taxmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

            txt_min_amt.Text = "0";
            txt_semin.Text = "0";
            txt_wminamnt.Text = "0";
            txt_wminamnt.Enabled = false;
            txt_semin.Enabled = false;
            txt_min_amt.Enabled = false;
            bind_year();
            bind_financialyear_data();

        }

    }

    //******************** Code to bind year *******************************************//

    protected void bind_year()
    {
        dd_year.Items.Insert(0, new ListItem("Select Year", "0"));

        int fromYear = Convert.ToInt32(ConfigurationManager.AppSettings["FromYear"]);
        int toYear = Convert.ToInt32(ConfigurationManager.AppSettings["ToYear"]);

        for (int i = fromYear; i <= toYear; i++)
        {
            string l, k;
            ListItem item = new ListItem();
            l = new DateTime(i, 1, 1).ToString("yyyy");
            k = new DateTime(i + 1, 1, 1).ToString("yyyy");
            item.Text = l + '-' + k;
            item.Value = i.ToString();
            dd_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year.SelectedValue = a.Year.ToString();
    }

    //*********************** Code to insert data in tax master table ***********************//

    protected void insert_masterdata()
    {
        if (HiddenField2.Value == "0")
        {

            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[6];
            sqlparam[0] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
            sqlparam[0].Value = dd_year.SelectedItem.Text.ToString();

            sqlparam[1] = new SqlParameter("@education_cess", SqlDbType.Decimal);
            sqlparam[1].Value = Convert.ToDecimal(txt_ecess.Text.ToString());

            sqlparam[2] = new SqlParameter("@surcharge", SqlDbType.Decimal);
            sqlparam[2].Value = Convert.ToDecimal(txt_scharge.Text.ToString());

            sqlparam[3] = new SqlParameter("@surcharge_limit", SqlDbType.Decimal);
            sqlparam[3].Value = Convert.ToDecimal(txt_slimit.Text);

            sqlparam[4] = new SqlParameter("@createdby", SqlDbType.VarChar);
            sqlparam[4].Value = Session["name"].ToString();

            sqlparam[5] = new SqlParameter("@createddate", SqlDbType.DateTime);
            sqlparam[5].Value = System.DateTime.Now;

            int a = (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_tax_master", sqlparam)));
            if (a > 0)
            {
                insert_slabrate(a);          //for men
                insert_slabrate1(a);         // for women
                insert_slabrate2(a);         //for senior citizen
                message.InnerHtml = "Slab for this financial year created already";
            }
            else
            {
                message.InnerHtml = "Slab for this financial year created already";
            }
        }
        else
        {
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
            sqlparam[0].Value = dd_year.SelectedItem.Text.ToString();

            sqlparam[1] = new SqlParameter("@education_cess", SqlDbType.Decimal);
            sqlparam[1].Value = Convert.ToDecimal(txt_ecess.Text.ToString());

            sqlparam[2] = new SqlParameter("@surcharge", SqlDbType.Decimal);
            sqlparam[2].Value = Convert.ToDecimal(txt_scharge.Text.ToString());

            sqlparam[3] = new SqlParameter("@surcharge_limit", SqlDbType.Decimal);
            sqlparam[3].Value = Convert.ToDecimal(txt_slimit.Text);

            sqlparam[4] = new SqlParameter("@modifiedby", SqlDbType.VarChar);
            sqlparam[4].Value = Session["name"].ToString();

            sqlparam[5] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
            sqlparam[5].Value = System.DateTime.Now;

            sqlparam[6] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[6].Value = HiddenField2.Value;

            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_update_tax_master", sqlparam);
            insert_slabrate(Convert.ToInt16(HiddenField2.Value));
            insert_slabrate1(Convert.ToInt16(HiddenField2.Value));
            insert_slabrate2(Convert.ToInt16(HiddenField2.Value));
            message.InnerHtml = "Tax slab for financial year updated successfully";
        }
    }

    //***************************** Code to create a data table for men **************************************//

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("minimumamount", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["minimumamount"] };
        dtable.Columns.Add("maximumamount", typeof(string));
        dtable.Columns.Add("Percentage", typeof(string));
        Session["aleave"] = dtable;
    }

    //***************************** Code to create a data table for women **************************************//

    protected void createatable1()
    {
        dtable = new DataTable();
        dtable.Columns.Add("minimumamount", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["minimumamount"] };
        dtable.Columns.Add("maximumamount", typeof(string));
        dtable.Columns.Add("Percentage", typeof(string));
        Session["bleave"] = dtable;
    }

    //***************************** Code to create a data table for senior citizen **************************************//

    protected void createatable2()
    {
        dtable = new DataTable();
        dtable.Columns.Add("minimumamount", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["minimumamount"] };
        dtable.Columns.Add("maximumamount", typeof(string));
        dtable.Columns.Add("Percentage", typeof(string));
        Session["cleave"] = dtable;
    }

    //***************************** Code to insert data in table for men **************************************//

    protected void adjustleave()
    {
        DataRow dr;
        if (Session["aleave"] == null)
        {
            createatable();

        }
        dtable = (DataTable)Session["aleave"];

        DataRow drfind = dtable.Rows.Find(txt_min_amt.Text.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Same minimum amount can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["minimumamount"] = txt_min_amt.Text.ToString();
            dr["maximumamount"] = txt_max_amt.Text.ToString();
            if (txt_max_amt.Text != "")
            {
                txt_min_amt.Text = Convert.ToString(Convert.ToInt32(txt_max_amt.Text.ToString()) + 1);
            }
            else
            {
            }
            dr["Percentage"] = txt_percentage.Text.ToString();
            dtable.Rows.Add(dr);
        }
        Session["aleave"] = dtable;
        clear();
        bindadjustleave();
    }

    protected void clear()
    {
        txt_max_amt.Text = "";
        txt_percentage.Text = "";
    }

    protected void tax_grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["aleave"];
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
            Session["aleave"] = dtable;

        }
        bindadjustleave();

    }

    //***************************** Code to insert data in table for women **************************************//

    protected void adjustleave1()
    {
        DataRow dr;
        if (Session["bleave"] == null)
        {
            createatable1();
        }
        dtable = (DataTable)Session["bleave"];

        DataRow drfind = dtable.Rows.Find(txt_wminamnt.Text.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Same minimum amount can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["minimumamount"] = txt_wminamnt.Text.ToString();
            dr["maximumamount"] = txt_wmaxamt.Text.ToString();
            if (txt_wmaxamt.Text != "")
            {
                txt_wminamnt.Text = Convert.ToString(Convert.ToInt32(txt_wmaxamt.Text.ToString()) + 1);
            }
            else
            {
            }
            dr["Percentage"] = txt_wpercentag.Text.ToString();
            dtable.Rows.Add(dr);
        }
        Session["bleave"] = dtable;
        clear1();
        bindadjustleave1();
    }

    protected void clear1()
    {
        txt_wmaxamt.Text = "";
        txt_wpercentag.Text = "";
    }

    protected void tax_wgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["bleave"];
        if (Convert.ToInt32(e.RowIndex) <= dtable.Rows.Count - 1)
        {
            txt_wminamnt.Text = Convert.ToString(tax_wgrid.DataKeys[e.RowIndex].Value);
            int count = dtable.Rows.Count - 1;
            for (int i = Convert.ToInt32(e.RowIndex); i <= count; i++)
            {
                DataRow drfind = dtable.Rows.Find(Convert.ToString(tax_wgrid.DataKeys[i].Value));
                if (drfind != null)
                {
                    drfind.Delete();
                }

            }
            Session["bleave"] = dtable;

        }
        bindadjustleave1();

    }
    //***************************** Code to insert data in table for senior citizen **************************************//

    protected void adjustleave2()
    {
        DataRow dr;
        if (Session["cleave"] == null)
        {
            createatable2();

        }
        dtable = (DataTable)Session["cleave"];

        DataRow drfind = dtable.Rows.Find(txt_semin.Text.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Same minimum amount can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["minimumamount"] = txt_semin.Text.ToString();
            dr["maximumamount"] = txt_semax.Text.ToString();
            if (txt_semax.Text != "")
            {
                txt_semin.Text = Convert.ToString(Convert.ToInt32(txt_semax.Text.ToString()) + 1);
            }
            else
            {
            }
            dr["Percentage"] = txt_seper.Text.ToString();
            dtable.Rows.Add(dr);
        }
        Session["cleave"] = dtable;
        clear2();
        bindadjustleave2();
    }

    protected void clear2()
    {
        txt_semax.Text = "";
        txt_seper.Text = "";
    }


    protected void tax_sgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["cleave"];
        if (Convert.ToInt32(e.RowIndex) <= dtable.Rows.Count - 1)
        {
            txt_semin.Text = Convert.ToString(tax_sgrid.DataKeys[e.RowIndex].Value);
            int count = dtable.Rows.Count - 1;
            for (int i = Convert.ToInt32(e.RowIndex); i <= count; i++)
            {
                DataRow drfind = dtable.Rows.Find(Convert.ToString(tax_sgrid.DataKeys[i].Value));
                if (drfind != null)
                {
                    drfind.Delete();
                }

            }
            Session["cleave"] = dtable;

        }
        bindadjustleave2();
    }
    //***************************** Code to bind data table data in grid for men **************************************//

    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["aleave"];
        tax_grid.DataSource = dtable;
        tax_grid.DataBind();
    }


    //***************************** Code to bind data table data in grid for women **************************************//

    protected void bindadjustleave1()
    {
        dtable = (DataTable)Session["bleave"];
        tax_wgrid.DataSource = dtable;
        tax_wgrid.DataBind();
    }

    //***************************** Code to bind data table data in grid for senior citizen **************************************//

    protected void bindadjustleave2()
    {
        dtable = (DataTable)Session["cleave"];
        tax_sgrid.DataSource = dtable;
        tax_sgrid.DataBind();
    }
    //***************************** Code to insert data into table from data table for men  **************************************//


    protected void insert_slabrate(int b)
    {
        try
        {
            dtable = (DataTable)Session["aleave"];

            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlstr = "insert into tbl_payroll_tax_detail(tax_id,person_status,min_range,max_range,percentage_deduction) values (@tax_id,@person_status,@min_range,@max_range,@percentage_deduction)";
                    sqlparm = new SqlParameter[5];

                    sqlparm[0] = new SqlParameter("@tax_id", SqlDbType.Int);
                    sqlparm[0].Value = b;

                    sqlparm[1] = new SqlParameter("@person_status", SqlDbType.VarChar, 50);
                    sqlparm[1].Value = 0;

                    sqlparm[2] = new SqlParameter("@min_range", SqlDbType.Decimal);
                    sqlparm[2].Value = dtable.Rows[i]["minimumamount"].ToString();

                    sqlparm[3] = new SqlParameter("@max_range", SqlDbType.Decimal);
                    if (dtable.Rows[i]["maximumamount"].ToString() == "")
                    {
                        sqlparm[3].Value = System.Data.SqlTypes.SqlDecimal.Null;

                    }
                    else
                    {
                        sqlparm[3].Value = Convert.ToDecimal(dtable.Rows[i]["maximumamount"].ToString());
                    }
                    sqlparm[4] = new SqlParameter("@percentage_deduction", SqlDbType.Decimal);
                    sqlparm[4].Value = Convert.ToDecimal(dtable.Rows[i]["percentage"].ToString());

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
            }
        }

        catch (Exception ex)
        {
        }
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

    public Boolean validate1()
    {
        if (txt_wmaxamt.Text != "")
        {
            if (Convert.ToDecimal(txt_wminamnt.Text.ToString()) > Convert.ToDecimal(txt_wmaxamt.Text.ToString()))
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

    //*************** Function to validate maximum range with minimum range *************//
    public Boolean validate2()
    {
        if (txt_semax.Text != "")
        {
            if (Convert.ToDecimal(txt_semin.Text.ToString()) > Convert.ToDecimal(txt_semax.Text.ToString()))
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

    //***************************** Code to insert data into table from data table for women  **************************************//


    protected void insert_slabrate1(int c)
    {
        try
        {
            dtable = (DataTable)Session["bleave"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlstr = "insert into tbl_payroll_tax_detail(tax_id,person_status,min_range,max_range,percentage_deduction) values (@tax_id,@person_status,@min_range,@max_range,@percentage_deduction)";
                    sqlparm = new SqlParameter[5];

                    sqlparm[0] = new SqlParameter("@tax_id", SqlDbType.Int);
                    sqlparm[0].Value = c;

                    sqlparm[1] = new SqlParameter("@person_status", SqlDbType.VarChar, 50);
                    sqlparm[1].Value = 1;

                    sqlparm[2] = new SqlParameter("@min_range", SqlDbType.Decimal);
                    sqlparm[2].Value = dtable.Rows[i]["minimumamount"].ToString();

                    sqlparm[3] = new SqlParameter("@max_range", SqlDbType.Decimal);

                    if (dtable.Rows[i]["maximumamount"].ToString() == "")
                    {
                        sqlparm[3].Value = System.Data.SqlTypes.SqlDecimal.Null;
                    }
                    else
                    {
                        sqlparm[3].Value = Convert.ToDecimal(dtable.Rows[i]["maximumamount"].ToString());
                    }
                    sqlparm[4] = new SqlParameter("@percentage_deduction", SqlDbType.Decimal);
                    sqlparm[4].Value = Convert.ToDecimal(dtable.Rows[i]["percentage"].ToString());

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
                //  message.InnerHtml = "Bonus sanctioned successfully";
            }
        }
        catch (Exception ex)
        {
        }
    }
    //***************************** Code to insert data into table from data table for senior citizen  **************************************//


    protected void insert_slabrate2(int k)
    {
        try
        {
            dtable = (DataTable)Session["aleave"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlstr = "insert into tbl_payroll_tax_detail(tax_id,person_status,min_range,max_range,percentage_deduction) values (@tax_id,@person_status,@min_range,@max_range,@percentage_deduction)";
                    sqlparm = new SqlParameter[5];

                    sqlparm[0] = new SqlParameter("@tax_id", SqlDbType.Int);
                    sqlparm[0].Value = k;

                    sqlparm[1] = new SqlParameter("@person_status", SqlDbType.VarChar, 50);
                    sqlparm[1].Value = 2;

                    sqlparm[2] = new SqlParameter("@min_range", SqlDbType.Decimal);
                    sqlparm[2].Value = dtable.Rows[i]["minimumamount"].ToString();

                    sqlparm[3] = new SqlParameter("@max_range", SqlDbType.Decimal);
                    if (dtable.Rows[i]["maximumamount"].ToString() == "")
                    {
                        sqlparm[3].Value = System.Data.SqlTypes.SqlDecimal.Null;

                    }
                    else
                    {
                        sqlparm[3].Value = Convert.ToDecimal(dtable.Rows[i]["maximumamount"].ToString());
                    }
                    sqlparm[4] = new SqlParameter("@percentage_deduction", SqlDbType.Decimal);
                    sqlparm[4].Value = Convert.ToDecimal(dtable.Rows[i]["percentage"].ToString());

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
                //  message.InnerHtml = "Bonus sanctioned successfully";
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btn_wadd_Click(object sender, EventArgs e)
    {
        if (validate1())
        {
            adjustleave1();
        }
    }

    protected void btn_seadd_Click(object sender, EventArgs e)
    {
        if (validate2())
        {
            adjustleave2();
        }
    }
    protected void btn_add_Click1(object sender, EventArgs e)
    {
        if (validate())
        {
            adjustleave();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        insert_masterdata();
    }

    //**************** Code to bind selected financial year data *********************//

    protected void bind_financialyear_data()
    {
        Session.Remove("aleave");
        Session.Remove("bleave");
        Session.Remove("cleave");
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@financialyear", SqlDbType.VarChar, 50);
        sqlparam[0].Value = dd_year.SelectedItem.Text.ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_bind_financialyear_data", sqlparam);

        if (ds.Tables[0].Rows.Count > 0)
        {
            HiddenField2.Value = ds.Tables[0].Rows[0]["id"].ToString();
            txt_ecess.Text = ds.Tables[0].Rows[0]["education_cess"].ToString();
            txt_scharge.Text = ds.Tables[0].Rows[0]["surcharge"].ToString();
            txt_slimit.Text = ds.Tables[0].Rows[0]["surcharge_limit"].ToString();

            //****************************** Bind data in data table for men ************//

            if (Session["aleave"] == null)
            {
                createatable();
            }
            DataRow dr;
            DataTable sdata;

            sdata = (DataTable)Session["aleave"];

            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = sdata.NewRow();
                dr["minimumamount"] = (ds.Tables[0].Rows[i]["min_range"] != null) ? ds.Tables[0].Rows[i]["min_range"].ToString() : "";
                dr["maximumamount"] = (ds.Tables[0].Rows[i]["max_range"] != null) ? ds.Tables[0].Rows[i]["max_range"].ToString() : "";
                dr["percentage"] = (ds.Tables[0].Rows[i]["percentage_deduction"] != null) ? ds.Tables[0].Rows[i]["percentage_deduction"].ToString() : "";
                sdata.Rows.Add(dr);
            }
            Session["aleave"] = sdata;
            bindadjustleave();


            //************************** Binding data in data table for women *************//
            if (Session["bleave"] == null)
            {
                createatable1();
            }
            sdata = (DataTable)Session["bleave"];

            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                dr = sdata.NewRow();
                dr["minimumamount"] = (ds.Tables[1].Rows[i]["min_range"] != null) ? ds.Tables[1].Rows[i]["min_range"].ToString() : "";
                dr["maximumamount"] = (ds.Tables[1].Rows[i]["max_range"] != null) ? ds.Tables[1].Rows[i]["max_range"].ToString() : "";
                dr["percentage"] = (ds.Tables[1].Rows[i]["percentage_deduction"] != null) ? ds.Tables[1].Rows[i]["percentage_deduction"].ToString() : "";
                sdata.Rows.Add(dr);
            }
            Session["bleave"] = sdata;
            bindadjustleave1();

            //************************** Binding data in data table for senior citizen *************//

            if (Session["cleave"] == null)
            {
                createatable2();
            }
            sdata = (DataTable)Session["cleave"];

            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                dr = sdata.NewRow();
                dr["minimumamount"] = (ds.Tables[2].Rows[i]["min_range"] != null) ? ds.Tables[2].Rows[i]["min_range"].ToString() : "";
                dr["maximumamount"] = (ds.Tables[2].Rows[i]["max_range"] != null) ? ds.Tables[2].Rows[i]["max_range"].ToString() : "";
                dr["percentage"] = (ds.Tables[2].Rows[i]["percentage_deduction"] != null) ? ds.Tables[2].Rows[i]["percentage_deduction"].ToString() : "";
                sdata.Rows.Add(dr);
            }
            Session["cleave"] = sdata;
            bindadjustleave2();
        }
        else
        {
            HiddenField2.Value = "0";
            blank();
        }
    }

    protected void blank()
    {
        tax_grid.DataSource = null;
        tax_grid.DataBind();
        tax_sgrid.DataSource = null;
        tax_sgrid.DataBind();
        tax_wgrid.DataSource = null;
        tax_wgrid.DataBind();
        txt_ecess.Text = "";
        txt_max_amt.Text = "";
        // txt_min_amt.Text = "";
        txt_percentage.Text = "";
        txt_scharge.Text = "";
        txt_semax.Text = "";
        // txt_semin.Text = "";
        txt_seper.Text = "";
        txt_slimit.Text = "";
        txt_wmaxamt.Text = "";
        //  txt_wminamnt.Text = "";
        txt_wpercentag.Text = "";
        message.InnerHtml = "";
    }
    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_financialyear_data();
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        bind_financialyear_data();
    }
}
