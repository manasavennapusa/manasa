using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class recruitment_vacancytype1 : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
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
            bindgrid();

            if (Request.QueryString["id"] != null)
            {
                bindtbl();
            }
            if (Request.QueryString["update"] != null)
            {
                Output.Show("CTC range updated successfully");
            }
        }
        if (Request.QueryString["id"] == null)
        {
            btnSubmit.Text = "Add";

        }
        else
        {
            btnSubmit.Text = "Update";
        }

    }

    private void bindtbl()
    {
        if (Request.QueryString["Id"] != null)
        {
            lblhead.Text = "Edit Vacancy Type ";
            int ID = Convert.ToInt32(Request.QueryString["Id"]);
            sqlstr = "select * from tbl_recruitment_vacancytype where id='" + ID + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtvacancytype.Text = ds.Tables[0].Rows[0]["vacancytype"].ToString();
            txtdesc.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        else
        {
            bindgrid();
        }
    }

    private void bindgrid()
    {
        lblhead.Text = "Create Vacancy Type ";
        sqlstr = "select * from tbl_recruitment_vacancytype";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        gridvacancytype1.DataSource = ds;
        gridvacancytype1.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] == null)
        {
            insertrequesttype();
        }
        else
        {
            editrequesttype();
        }
    }

    private void editrequesttype()
    {
        SqlParameter[] parm = new SqlParameter[4];

        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);

            Output.AssignParameter(parm, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 1, "@vacancytype", "String", 50, txtvacancytype.Text);
            Output.AssignParameter(parm, 2, "@description", "String", 500, txtdesc.Text);
            Output.AssignParameter(parm, 3, "@updateby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_vacancytype]", parm);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Updated. Please contact system admin. For error details please go through the log file.");
        }
        if (Flag > 0)
        {
            txtvacancytype.Text = "";
            txtdesc.Text = "";
            Response.Redirect("vacancytype1.aspx?update=true");
        }
        else
        {
            Output.Show("Vacancy Type Already Exists,Try Another Name");
        }
    }

    private void insertrequesttype()
    {
        SqlParameter[] parm = new SqlParameter[3];
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@vacancytype", "String", 50, txtvacancytype.Text);
            Output.AssignParameter(parm, 1, "@description", "String", 500, txtdesc.Text);
            Output.AssignParameter(parm, 2, "@createby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_vacancytype]", parm);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        if (Flag <= 0)
        {
            Output.Show("Vacancy Type already exists, please enter another name");
        }
        else
        {
            Output.Show("Vacancy Type created successfully");
            txtvacancytype.Text = "";
            txtdesc.Text = "";
            bindgrid();
        }
    }
    protected void gridvacancytype1_PreRender(object sender, EventArgs e)
    {
        if (gridvacancytype1.Rows.Count > 0)
        {
            gridvacancytype1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void gridvacancytype1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)gridvacancytype1.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_vacancytype where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Record deleted sucessfully...");
                bindgrid();
            }
            else
            {
                Output.Show("Please select the record...");
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
}