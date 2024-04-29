using System;
using System.Data;
using System.Data.SqlClient;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ApplicationType : System.Web.UI.Page
{
  
    // Declarations

    string UserCode, RoleId;
    string InsertQuery = @"insert into tbl_exit_applicationtype (ApplicationName,Path,CreatedBy,CreateDateTime,Status) values(@ApplicationName,@Path,@CreatedBy,getdate(),1)";
    string SelectQuery = @"select * from tbl_exit_applicationtype where status = 1";
    string SelectQueryById = @"select * from tbl_exit_applicationtype where ApplicationTypeId = @Id";
    string DeleteQuery = @"update tbl_exit_applicationtype set Status = 0 where ApplicationTypeId = @Id";
    string UpdateQuery = @"update tbl_exit_applicationtype 
                             set ApplicationName = @ApplicationName, 
                             Path = @Path,
                             UpdatedBy = @CreatedBy,
                             UpdatedDateTime = getdate() 
                              where ApplicationTypeId = @Id";
    IBase Lib = null;

    SqlParameter[] parm = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                hdnApplicationId.Value = "";
                BindGrid();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        // Declaration
        Lib = new Base();
        parm = new SqlParameter[4];

        // Assignment
        Output.AssignParameter(parm, 0, "@ApplicationName", "String", 100, txtApplicationName.Text.Trim());
        Output.AssignParameter(parm, 1, "@Path", "String", 500, txtPath.Text.Trim());
        Output.AssignParameter(parm, 2, "@CreatedBy", "String", 0, UserCode);
        Output.AssignParameter(parm, 3, "@Id", "Int", 0, hdnApplicationId.Value);

        // Action
        if (hdnApplicationId.Value != "" && btnsave.Text == "Update")
        {
            Output.Show(Lib.Bee.WApplyChanges(parm, UpdateQuery));
            hdnApplicationId.Value = "";
            btnsave.Text = "Save";
            BindGrid();
        }
        else
        {
            Output.Show(Lib.Bee.WApplyChanges(parm, InsertQuery));
            BindGrid();
        }

    }

    private void BindGrid()
    {
        Lib = new Base();
        Lib.Bee.WBindGrid(SelectQuery, grdApplicationType);
    }

    protected void grdApplicationType_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        Lib = new Base();
        parm = new SqlParameter[1];

        int Id = (int)grdApplicationType.DataKeys[(int)e.NewEditIndex].Value;
        Output.AssignParameter(parm, 0, "@Id", "Int", 0, Id.ToString());

        DataSet ds = Lib.Bee.WGetData(SelectQueryById, parm);
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            hdnApplicationId.Value = row["ApplicationTypeId"].ToString().Trim();
            txtApplicationName.Text = row["ApplicationName"].ToString().Trim();
            txtPath.Text = row["Path"].ToString().Trim();
            btnsave.Text = "Update";
            BindGrid();
        }
    }

    protected void grdApplicationType_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        Lib = new Base();
        parm = new SqlParameter[1];

        int Id = (int)grdApplicationType.DataKeys[(int)e.RowIndex].Value;
        Output.AssignParameter(parm, 0, "@Id", "Int", 0, Id.ToString());

        Lib.Bee.WApplyChanges(parm, DeleteQuery);
        BindGrid();
    }
    protected void grdApplicationType_PreRender(object sender, EventArgs e)
    {
        if (grdApplicationType.Rows.Count > 0)
            grdApplicationType.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}