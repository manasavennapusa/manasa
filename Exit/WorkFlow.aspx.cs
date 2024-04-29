using System;
using System.Data;
using System.Data.SqlClient;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;

public partial class Exit_WorkFlow : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    string InsertQuery = @"insert into tbl_exit_workflow (WorkFlowTypeId,WorkFlowName,HowManyApprovers,CreatedBy,CreateDateTime,Status) values(@WorkFlowTypeId,@WorkFlowName,@HowManyApprovers,@CreatedBy,getdate(),1)";

    string SelectQuery = @"select * from tbl_exit_workflow where status = 1";

    string SelectQueryById = @"select * from tbl_exit_workflow where WorkFlowId = @Id";

    string DeleteQuery = @"update tbl_exit_workflow set Status = 0 where WorkFlowId = @Id";

    string UpdateQuery = @"update tbl_exit_workflow 
                             set WorkFlowTypeId = @WorkFlowTypeId,
                             WorkFlowName = @WorkFlowName,
                             HowManyApprovers = @HowManyApprovers, 
                             UpdatedBy = @CreatedBy,
                             UpdatedDateTime = getdate() 
                              where WorkFlowTypeId = @Id";

    string SelectQueryList = @"select WorkFlowTypeId,WorkFlowTypeName from tbl_exit_workflowtype where status = 1";

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
                hdnId.Value = "";
                BindList();
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
        parm = new SqlParameter[5];

        // Assignment
        Output.AssignParameter(parm, 0, "@WorkFlowTypeId", "String", 100, drpWorkFlowType.SelectedValue.Trim());
        Output.AssignParameter(parm, 1, "@WorkFlowName", "String", 100, txtWorkFlow.Text.Trim());
        Output.AssignParameter(parm, 2, "@HowManyApprovers", "String", 100, txtHowMany.Text.Trim());
        Output.AssignParameter(parm, 3, "@CreatedBy", "String", 0, UserCode);
        Output.AssignParameter(parm, 4, "@Id", "Int", 0, hdnId.Value);

        // Action
        if (hdnId.Value != "" && btnsave.Text == "Update")
        {
            Output.Show(Lib.Bee.WApplyChanges(parm, UpdateQuery));
            hdnId.Value = "";
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
        Lib.Bee.WBindGrid(SelectQuery, Grid);
    }

    private void BindList()
    {
        Lib = new Base();
        Lib.Bee.WBindList(SelectQueryList, drpWorkFlowType);
    }

    protected void Grid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        Lib = new Base();
        parm = new SqlParameter[1];

        int Id = (int)Grid.DataKeys[(int)e.NewEditIndex].Value;
        Output.AssignParameter(parm, 0, "@Id", "Int", 0, Id.ToString());

        DataSet ds = Lib.Bee.WGetData(SelectQueryById, parm);
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            hdnId.Value = row["WorkFlowId"].ToString().Trim();
            drpWorkFlowType.SelectedValue = row["WorkFlowTypeId"].ToString().Trim();
            txtWorkFlow.Text = row["WorkFlowName"].ToString().Trim();
            txtHowMany.Text = row["HowManyApprovers"].ToString().Trim();
            btnsave.Text = "Update";
            BindGrid();
        }
    }

    protected void Grid_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        Lib = new Base();
        parm = new SqlParameter[1];

        int Id = (int)Grid.DataKeys[(int)e.RowIndex].Value;
        Output.AssignParameter(parm, 0, "@Id", "Int", 0, Id.ToString());

        Lib.Bee.WApplyChanges(parm, DeleteQuery);
        BindGrid();
    }
}