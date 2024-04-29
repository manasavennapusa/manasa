using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;

public partial class createpanel : System.Web.UI.Page
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

            bindGrid();
            bindsubject();
            if (Request.QueryString["id"] != null)
            {
                trpanelcode.Visible = false;
                bindinfomation();
                btnadd.Text = "Update";
                btnclear.Text = "Cancel";
                lblheader.Text = "Edit";
                viewgrid.Visible = false;
            }
            else
            {
                btnadd.Text = "Submit";
                btnclear.Text = "Reset";
                lblheader.Text = "Create";
                trpanelcode.Visible = false;
            }

            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Updated Successfully");
            }

        }

    }

    protected void bindsubject()
    {
        string sqlstr = "   select * from tbl_recruitment_subject_master ";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_subject.DataValueField = "id";
        ddl_subject.DataTextField = "subject_name";
        ddl_subject.DataSource = ds;
        ddl_subject.DataBind();
        ddl_subject.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindGrid()
    {
        string sqlstr = @"select pm.id,
pm.panelcode,
pm.Panelname,
pm.resourcenames,
sm.subject_name
--emp.emp_fname,
--resourcenames+'>'+FN.emp_fname as Resourcesname
--FN.emp_fname 
from tbl_recruitment_panel_master pm
inner join tbl_recruitment_subject_master sm on sm.id=pm.subjectname";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdPanel.DataSource = ds;
        grdPanel.DataBind();

    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            update_Panel();
        }
        else
        {
            insert_Panel();
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createpanel.aspx");
        }
    }

    protected void insert_Panel()
    {
        SqlParameter[] sqlParam = new SqlParameter[4];

        int Flag = 0;
        try
        {
            Output.AssignParameter(sqlParam, 0, "@Panelname", "String", 100, txt_panelname.Text);
            Output.AssignParameter(sqlParam, 1, "@subjectname", "String", 50, ddl_subject.SelectedValue);
            Output.AssignParameter(sqlParam, 2, "@resourcenames", "String", 500, hidd_empcode.Value);
            Output.AssignParameter(sqlParam, 3, "@createby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_panel]", sqlParam);
        }

        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        if (Flag < 0)
        {
            Output.Show("Panel Name is already exists try another name");
        }
        else
        {
            Output.Show("Created Successfully");
            cleartext();
            bindGrid();
        }
    }

    protected void update_Panel()
    {
        SqlParameter[] sqlParam = new SqlParameter[5];

        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            Output.AssignParameter(sqlParam, 0, "@id", "Int", 0, id.ToString());
            Output.AssignParameter(sqlParam, 1, "@Panelname", "String", 100, txt_panelname.Text);
            Output.AssignParameter(sqlParam, 2, "@subjectname", "String", 50, ddl_subject.SelectedValue);
            Output.AssignParameter(sqlParam, 3, "@resourcenames", "String", 500, hidd_empcode.Value);
            Output.AssignParameter(sqlParam, 4, "@updateby", "String", 50, UserCode);

            Flag = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_panel]", sqlParam);
        }

        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not updated. Please contact system admin. For error details please go through log file.");
        }


        if (Flag < 0)
        {
            Output.Show("Panel Name is already exists try another name");
        }
        else
        {
            //message.InnerHtml = "Skill Name is Updated Successfully.";
            Response.Redirect("createpanel.aspx?updated=true");
            bindGrid();
            cleartext();
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_panel_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_panelname.Text = ds.Tables[0].Rows[0]["Panelname"].ToString();
        ddl_subject.SelectedValue = ds.Tables[0].Rows[0]["subjectname"].ToString();
        string resourcenames = "";
        string[] resourcename = ds.Tables[0].Rows[0]["resourcenames"].ToString().Split('-');
        if (resourcename.Length > 0)
        {
            for (int i = 0; i < resourcename.Length; i++)
            {
                if (i != 0)
                    resourcenames += ",";
                resourcenames += getname(resourcename[i].ToString());
            }
        }
      //  txt_resourcename.Text = resourcenames;
        //hidd_empcode.Value=ds.Tables[0].Rows[0]["resourcenames"].ToString();
        txt_resourcename.Text = ds.Tables[0].Rows[0]["resourcenames"].ToString();
        hidd_empcode.Value = ds.Tables[0].Rows[0]["resourcenames"].ToString();
        lbl_panelcode.Text = ds.Tables[0].Rows[0]["panelcode"].ToString();
    }

    private string getname(string empcode)
    {
        string sqlstr = "select ISNULL(emp_fname,'')+''+ISNULL(emp_m_name,'')+''+ISNULL(emp_l_name,'') as Name from tbl_intranet_employee_jobDetails where empcode= '" + empcode + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0]["Name"].ToString();
        else
            return "";
    }
    private void cleartext()
    {
        txt_panelname.Text = "";
        ddl_subject.SelectedValue = "0";
        txt_resourcename.Text = "";
    }

    protected void grdPanel_PreRender(object sender, EventArgs e)
    {
        if (grdPanel.Rows.Count > 0)
        {
            grdPanel.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grdPanel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)grdPanel.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete  from tbl_recruitment_panel_master where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Deleted Successfully");
                bindGrid();
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