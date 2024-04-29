using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;

public partial class Exit_ApproverDetails : System.Web.UI.Page
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
        Lib.Bee.WBindListBox("select empcode, empcode +' -> '+ isnull(emp_fname,'') +' ' + isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') empname from tbl_intranet_employee_jobDetails where emp_doleaving is null and status = 1", ListBox1);
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    private void BindGrid()
    {
        string SelectQuery = @"select WorkFlowId,WorkFlowTypeId,WorkFlowName,HowManyApprovers from tbl_exit_workflow where status = 1 and WorkFlowTypeId = " + drpWorkFlowType.SelectedValue.Trim() + "";
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(SelectQuery);
        DataTable dt = new DataTable();
        dt.Columns.Add("WorkFlowId", typeof(int));
        dt.Columns.Add("WorkFlowTypeId", typeof(int));
        dt.Columns.Add("WorkFlowName", typeof(string));
        dt.Columns.Add("HowManyApprovers", typeof(int));

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            for (int i = 0; i < Convert.ToInt32(row["HowManyApprovers"].ToString()); i++)
            {
                dt.Rows.Add(row["WorkFlowId"], row["WorkFlowTypeId"], row["WorkFlowName"], row["HowManyApprovers"]);
            }
        }
        Grid.DataSource = dt;
        Grid.DataBind();
    }


    protected void Grid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Lib = new Base();
            DropDownList AppList = (DropDownList)e.Row.FindControl("drpApplication");
            if (drpWorkFlowType.SelectedValue == "1")
                Lib.Bee.WBindList("select ApplicationTypeId,ApplicationName from tbl_exit_applicationtype where status = 1 and ApplicationTypeId in (1)", AppList);
            else if (drpWorkFlowType.SelectedValue == "2")
                Lib.Bee.WBindList("select ApplicationTypeId,ApplicationName from tbl_exit_applicationtype where status = 1 and ApplicationTypeId not in (1,6,7,8)", AppList);
            DropDownList AppEmpCode = (DropDownList)e.Row.FindControl("drpEmpCode");
            Lib.Bee.WBindList(@"select empcode, empcode +' -> ' + emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName
                               from tbl_intranet_employee_jobDetails job
                               where emp_doleaving is null
                               order by empcode", AppEmpCode);

        }

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


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Query = "";
        Lib = new Base();
        int Error = 0;
        int Flag = 0;
        string HRStatus = "N";
        int LastRow = 1;
        try
        {
            Lib.Bee.OpenConnection();

            if (drpWorkFlowType.SelectedValue != "0")
            {

                if (Grid.Rows.Count > 0)
                {
                    if (ListBox2.Items.Count > 0)
                    {
                        Lib.Bee.BeginTrasaction();
                        foreach (ListItem item in ListBox2.Items)
                        {
                            Query = "update tbl_exit_approverdetails set Status = 0 where UserCode = '" + item.Value.Trim() + "' and Status = 1 and WorkFlowTypeId=" + drpWorkFlowType.SelectedValue.Trim() + "";
                            Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                            HRStatus = "N";
                            LastRow = 1;
                            foreach (GridViewRow row in Grid.Rows)
                            {
                                Label lblWorkFlowTypeId = (Label)row.FindControl("lblWorkFlowTypeId");
                                Label lblWorkFlowId = (Label)row.FindControl("lblWorkFlowId");
                                Label lblWorkFlowName = (Label)row.FindControl("lblWorkFlowName");
                                DropDownList drpEmpCode = (DropDownList)row.FindControl("drpEmpCode");
                                //  CheckBox Hr = (CheckBox)row.FindControl("Hr");
                                if (LastRow == Grid.Rows.Count)
                                    HRStatus = "Y";
                                DropDownList drpApplication = (DropDownList)row.FindControl("drpApplication");
                                if (drpEmpCode.SelectedValue.Trim() != "0")
                                {
                                    if (drpApplication.SelectedValue != "0")
                                    {
                                        Query = "insert into tbl_exit_approverdetails (UserCode,WorkFlowTypeId,WorkFlowId,ApproverCode,ApplicationTypeId,CreatedBy,CreateDateTime,Status,Hr) values ('" + item.Value.Trim() + "'," + lblWorkFlowTypeId.Text.Trim() + "," + lblWorkFlowId.Text.Trim() + "," + drpEmpCode.SelectedValue.Trim() + "," + drpApplication.SelectedValue.Trim() + ",'" + UserCode + "',getdate(),1,'" + HRStatus + "')";
                                        Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                                    }
                                    else
                                    {
                                        Lib.Bee.RollBack();
                                        Error = 1;
                                        Output.Show("Please select the application type for the employee " + drpEmpCode.SelectedValue.Trim() + "");
                                        break;
                                    }
                                }

                                LastRow++;
                            }

                            if (Error == 1)
                                break;
                        }

                        if (Error == 0)
                        {
                            Lib.Bee.Commit();
                            Output.Show("Approvers created successfully.");
                        }
                    }
                    else
                        Output.Show("Please select atleast one employee from the list.");
                }
                else
                    Output.Show("Work flow not defined. Please contact system admin.");
            }
            else
                Output.Show("Please select work flow type.");

        }
        catch (Exception ex)
        {
            Lib.Bee.RollBack();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        }
        finally
        {
            Lib.Bee.CloseConnection();
        }
    }

    protected void ChkStatus_CheckedChanged(object sender, EventArgs e)
    {
        if (drpWorkFlowType.SelectedValue.Trim() != "0")
        {
            if (ChkStatus.Checked)
                BindEmployeeListPending();
            else
                BindEmployeeList();
        }
        else
        {
            Output.Show("Please select work flow type.");
            ChkStatus.Checked = false;
        }
    }

    private void BindEmployeeListPending()
    {
        Lib = new Base();
        Lib.Bee.WBindListBox(@"select empcode, empcode +' -> '+ isnull(emp_fname,'') +' ' + isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') empname 
from tbl_intranet_employee_jobDetails 
where emp_doleaving is null and status = 1 and empcode not in (
                                                           select UserCode
                                                            from tbl_exit_approverdetails
                                                              where Status=1 and WorkFlowTypeId = " + drpWorkFlowType.SelectedValue.Trim() + ")", ListBox1);
    }
    protected void drpWorkFlowType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ChkStatus.Checked)
            BindEmployeeListPending();
        else
            BindEmployeeList();
    }
}