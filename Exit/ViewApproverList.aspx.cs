using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;

public partial class Exit_ViewApproverList : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;

    string SelectQueryList = @"select WorkFlowTypeId,WorkFlowTypeName from tbl_exit_workflowtype where status = 1";

    IBase Lib = null;
    SqlParameter[] parm = null;
    ArrayList arraylist1 = new ArrayList();
    ArrayList arraylist2 = new ArrayList();
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
                BindEmployeeList();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindList()
    {
        Lib = new Base();
        Lib.Bee.WBindList(SelectQueryList, drpWorkFlowType);
    }

    private void BindEmployeeList()
    {
        Lib = new Base();
        Lib.Bee.WBindListBox("select distinct app.usercode,empcode +' -> '+ isnull(emp_fname,'') +' ' + isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') empname from tbl_intranet_employee_jobDetails job inner join tbl_exit_approverdetails app on job.empcode = app.usercode  where job.emp_doleaving is null and app.status = 1 and app.WorkFlowTypeId = " + drpWorkFlowType.SelectedValue.Trim() + "", ListBox1);
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    private string GenerateEmpList()
    {
        string Query = "";
        if (ListBox2.Items.Count > 0)
        {
            foreach (ListItem item in ListBox2.Items)
            {
                Query = Query + "'" + item.Value + "'";
                Query = Query + ",";
            }
            Query = Query.Remove(Query.Length - 1, 1);
        }

        return Query;
    }

    private void BindGrid()
    {
        string EmpList = GenerateEmpList();

        string SelectQuery = @"select AR.Id,AR.WorkFlowTypeId,AR.WorkFlowId, userjob.emp_fname +' '+ isnull(userjob.emp_m_name,'') +' '+ isnull(userjob.emp_l_name,'') UserName, WF.WorkFlowName,AR.ApproverCode,Job.emp_fname +' '+ isnull(Job.emp_m_name,'') +' '+ isnull(Job.emp_l_name,'') ApproverName,AR.ApplicationTypeId,APP.ApplicationName,case when Hr = 'Y' then 'True' else 'False' end Hr,case when Hr = 'Y' then cast('true' as bit) else cast('false' as bit) end HrBool
 from tbl_exit_workflow WF
  inner join tbl_exit_approverdetails AR on WF.WorkFlowId = AR.WorkFlowId 
                                     and WF.WorkFlowTypeId = AR.WorkFlowTypeId
  left join tbl_intranet_employee_jobDetails Job on AR.ApproverCode = Job.empcode
  left join tbl_exit_applicationtype APP on APP.ApplicationTypeId = AR.ApplicationTypeId
  left join tbl_intranet_employee_jobDetails userjob on userjob.empcode = AR.UserCode
  where AR.Status=1 and AR.WorkFlowTypeId = " + drpWorkFlowType.SelectedValue.Trim() + " and AR.UserCode in (" + EmpList + ") order by AR.Id";

        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(SelectQuery);
        Grid.DataSource = ds;
        Grid.DataBind();
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        lbltxt.Visible = false;
        if (ListBox1.SelectedIndex >= 0)
        {
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                if (ListBox1.Items[i].Selected)
                {
                    if (!arraylist1.Contains(ListBox1.Items[i]))
                    {
                        arraylist1.Add(ListBox1.Items[i]);

                    }
                }

            }
            for (int i = 0; i < arraylist1.Count; i++)
            {
                if (!ListBox2.Items.Contains(((ListItem)arraylist1[i])))
                {
                    ListBox2.Items.Add(((ListItem)arraylist1[i]));
                }
                ListBox1.Items.Remove(((ListItem)arraylist1[i]));
            }
            ListBox2.SelectedIndex = -1;
        }
        else
        {
            lbltxt.Visible = true;
            lbltxt.Text = "Please select atleast one in Listbox1 to move";
        }
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        lbltxt.Visible = false;
        while (ListBox1.Items.Count != 0)
        {
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                ListBox2.Items.Add(ListBox1.Items[i]);
                ListBox1.Items.Remove(ListBox1.Items[i]);
            }
        }
    }
    protected void btn3_Click(object sender, EventArgs e)
    {
        lbltxt.Visible = false;
        if (ListBox2.SelectedIndex >= 0)
        {
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                if (ListBox2.Items[i].Selected)
                {
                    if (!arraylist2.Contains(ListBox2.Items[i]))
                    {
                        arraylist2.Add(ListBox2.Items[i]);

                    }
                }

            }
            for (int i = 0; i < arraylist2.Count; i++)
            {
                if (!ListBox1.Items.Contains(((ListItem)arraylist2[i])))
                {
                    ListBox1.Items.Add(((ListItem)arraylist2[i]));
                }
                ListBox2.Items.Remove(((ListItem)arraylist2[i]));
            }
            ListBox1.SelectedIndex = -1;
        }
        else
        {
            lbltxt.Visible = true;
            lbltxt.Text = "Please select atleast one in Listbox2 to move";
        }

    }
    protected void btn4_Click(object sender, EventArgs e)
    {
        lbltxt.Visible = false;
        while (ListBox2.Items.Count != 0)
        {
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                ListBox1.Items.Add(ListBox2.Items[i]);
                ListBox2.Items.Remove(ListBox2.Items[i]);
            }

        }


    }

    protected void Grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grid.EditIndex = e.NewEditIndex;
        BindGrid();
        Label ApproverCode = (Label)Grid.Rows[e.NewEditIndex].FindControl("lblApproverCode");
        DropDownList AppEmpCode = (DropDownList)Grid.Rows[e.NewEditIndex].FindControl("drpEmpCode");

        Lib.Bee.WBindList(@"select empcode, empcode +' -> ' + emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName
                               from tbl_intranet_employee_jobDetails job
                               where emp_doleaving is null
                               order by empcode", AppEmpCode);
        AppEmpCode.SelectedValue = ApproverCode.Text.Trim();

    }
    protected void Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid.EditIndex = -1;
        BindGrid();
    }
    protected void Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Lib = new Base();
        parm = new SqlParameter[3];
        string HRStatus = "N";
        int Id = (int)Grid.DataKeys[(int)e.RowIndex].Value;

        foreach (GridViewRow row in Grid.Rows)
        {
            if (row.RowIndex == e.RowIndex)
            {
                DropDownList AppEmpCode = (DropDownList)row.FindControl("drpEmpCode");
                // CheckBox Hr = (CheckBox)row.FindControl("Hr");

                if (AppEmpCode.SelectedValue.Trim() != "0")
                {
                    Output.AssignParameter(parm, 0, "@Id", "Int", 0, Id.ToString());
                    Output.AssignParameter(parm, 1, "@EmpCode", "String", 50, AppEmpCode.SelectedValue.Trim());
                    Output.AssignParameter(parm, 2, "@HRStatus", "String", 50, HRStatus.Trim());

                    Lib.Bee.WApplyChanges(parm, "update tbl_exit_approverdetails set ApproverCode = @EmpCode where Id = @Id");
                    Grid.EditIndex = -1;
                    BindGrid();
                }
            }
        }


    }

    protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Lib = new Base();
        parm = new SqlParameter[1];

        int Id = (int)Grid.DataKeys[(int)e.RowIndex].Value;
        Output.AssignParameter(parm, 0, "@Id", "Int", 0, Id.ToString());

        Lib.Bee.WApplyChanges(parm, "update tbl_exit_approverdetails set status = 0 where Id = @Id");
        BindGrid();
    }

    protected void drpWorkFlowType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEmployeeList();
    }
}