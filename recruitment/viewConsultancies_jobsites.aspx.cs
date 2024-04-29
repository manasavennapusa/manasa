using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

public partial class recruitment_viewConsultancies_jobsites : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
        }
    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_jobsite_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdjobsites.DataSource = ds;
        grdjobsites.DataBind();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        string selectedjobsites = "";
        string selectedids = "";
        foreach (GridViewRow row in grdjobsites.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            Label skill = (Label)row.FindControl("lblorg");
            HiddenField id = (HiddenField)row.FindControl("hfid");
            if (ChkBoxRows.Checked == true)
            {
                selectedjobsites = selectedjobsites + skill.Text + " , ";
                selectedids = selectedids + id.Value + ",";
            }
        }
        if (selectedjobsites != "")
        {
            selectedjobsites = selectedjobsites.Substring(0, selectedjobsites.Length - 2);
            selectedids = selectedids.Substring(0, selectedids.Length - 1);

        }

        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Script", "selectSkills('" + selectedjobsites + "','" + selectedids + "');", true);
    }


    protected void grdjobsites_PreRender(object sender, EventArgs e)
    {
        if (grdjobsites.Rows.Count > 0)
        {
            grdjobsites.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}