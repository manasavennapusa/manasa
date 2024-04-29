using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.Data.SqlClient;

public partial class recruitment_closeVacancy : System.Web.UI.Page
{
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //    Response.Redirect("~/Authenticate.aspx");
        }
        else

            Response.Redirect("~/notlogged.aspx");
        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            bind_RRF();
        }
    }
    protected void bind_RRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs_for_CloseVacancy", sqlparam);
        grdvacancy.DataSource = ds;
        grdvacancy.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdvacancy.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkclose");
            if (ChkBoxRows.Checked)
            {
                int id = Convert.ToInt32(grdvacancy.DataKeys[row.RowIndex].Value);
                string sqlstr = "update tbl_recruitment_requisition_form set status=0 where id=" + id;
                DataSet ds = new DataSet();
                //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                if (i < 0)
                {
                    //SendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
                    Output.Show("Employee Not Closed");
                }
                else
                {
                    Output.Show("Closed Successfully");
                }
            }
            else
            {
                Output.Show("Please Select Atleast One RRF");
            }
            //Output.Show("Closed Successfully");
          
        }
        
        bind_RRF();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdvacancy.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkclose");
            ChkBoxRows.Checked = false;
        }
    }

}