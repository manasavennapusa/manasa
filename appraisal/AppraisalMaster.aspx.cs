using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;
using ADODB;
using DataAccessLayer;

public partial class appraisal_AppraisalMaster : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal grdTotal2 = 0;
    DataTable dtable = new DataTable();
    DataView dview;
    private string flow_id;
    private int ds_id;
    DataActivity DataActivity = new DataActivity();
    private string empcode;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string role;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        getActiveCycle();
        empcode = Session["empcode"].ToString();
        role = Session["role"].ToString();
        if (!IsPostBack)
        {
            if (Session["goal_details"] != null)
            {
                Session.Remove("goal_details");
            }
            if (Session["com_details"] != null)
            {
                Session.Remove("com_details");
            }
            bindempgrid2();

            //updatepanel2.Visible = false;
            //updatepanel3.Visible = false;
            //updatepanel4.Visible = false;
            //updatepanel5.Visible = false;
            //binddisplay();
            //bindgrid();

            //BindGoals();
            bindempgrid();

            if (Request.QueryString["sub"] != null)
            {
                Output.Show("Goals Added For Selected Employee(s) Successfully");
            }
            if (Request.QueryString["add"] != null)
            {
                Output.Show("Please Add Goals");
            }
            ddldesig.Items.Insert(0, new ListItem("--All--", "0"));
        }

    }

    //private void binddisplay()
    //{
    //    if (desig.SelectedValue == "1" || desig.SelectedValue == "0")
    //    {
    //        updatepanel2.Visible = true;
    //        updatepanel3.Visible = false;
    //        updatepanel4.Visible = false;
    //        updatepanel5.Visible = false;
    //    }
    //    else if (desig.SelectedValue == "2")
    //    {
    //        updatepanel2.Visible = false;
    //        updatepanel3.Visible = true;
    //        updatepanel4.Visible = false;
    //        updatepanel5.Visible = false;
    //    }
    //    else if (desig.SelectedValue == "3")
    //    {
    //        updatepanel2.Visible = false;
    //        updatepanel3.Visible = false;
    //        updatepanel4.Visible = true;
    //        updatepanel5.Visible = false;
    //    }
    //    else if (desig.SelectedValue == "4")
    //    {
    //        updatepanel2.Visible = false;
    //        updatepanel3.Visible = false;
    //        updatepanel4.Visible = false;
    //        updatepanel5.Visible = true;
    //    }
    //}

    protected void btnSaveGoals_Click(object sender, EventArgs e)
    {
        Div1.Visible = true;
        SqlConnection Connection = null;
        try
        {
            if (gvGoals.Rows.Count > 0 || GridView1.Rows.Count > 0)
            {
                Connection = DataActivity.OpenConnection();

                SqlParameter[] sqlparam = new SqlParameter[5];
                Output.AssignParameter(sqlparam, 0, "@appcycleid", "Int", 0, Session["appcycle"].ToString());

                if (gveligible.Rows.Count > 0)
                {
                    foreach (GridViewRow row in gveligible.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                        if (chk.Checked)
                        {
                            //selectedemp++;
                            Label emp = (Label)row.FindControl("lblempcode");
                            Session["employee"] = emp.Text;
                            string createdby = Session["empcode"].ToString();
                            Output.AssignParameter(sqlparam, 1, "@empcode", "String", 50, emp.Text);
                            Output.AssignParameter(sqlparam, 2, "@create_by", "String", 50, createdby);
                            Output.AssignParameter(sqlparam, 3, "@desigid", "Int", 0, desig.SelectedValue);

                            sqlparam[4] = new SqlParameter("@assmentid", SqlDbType.Int);
                            sqlparam[4].Direction = ParameterDirection.Output;


                            string str = @"select COUNT(*) from tbl_appraisal_eligible_employee where empcode='" + emp.Text + "' and appcycle_id=" + Convert.ToInt32(Session["appcycle"].ToString()) + " and status=1 and isdeleted=0";
                            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str);
                            if (cnt == 0)
                            {
                                //---------------insert Assessment--------------//
                                SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_add_goalsByHR", sqlparam);
                                ds_id = int.Parse(sqlparam[3].Value.ToString());
                                if (ds_id.ToString() != "")
                                {
                                    int assessmentid = ds_id;
                                    //-------------insert workflow-------------//
                                    SqlParameter[] sqlparam1 = new SqlParameter[9];
                                    Output.AssignParameter(sqlparam1, 0, "@assessment_id", "Int", 0, ds_id.ToString());
                                    Output.AssignParameter(sqlparam1, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                                    Output.AssignParameter(sqlparam1, 2, "@level", "Int", 0, "1");
                                    Output.AssignParameter(sqlparam1, 3, "@flow_status", "String", 1, "P");
                                    Output.AssignParameter(sqlparam1, 4, "@approvertype", "String", 5, "HR");
                                    Output.AssignParameter(sqlparam1, 5, "@cycle_type", "String", 5, "1");
                                    Output.AssignParameter(sqlparam1, 6, "@create_by", "String", 50, Session["empcode"].ToString());
                                    sqlparam1[7] = new SqlParameter("@flow_id", SqlDbType.Int);
                                    sqlparam1[7].Direction = ParameterDirection.Output;
                                    Output.AssignParameter(sqlparam1, 8, "@empcode", "String", 40, emp.Text);

                                    SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_workflow", sqlparam1);
                                    flow_id = sqlparam1[7].Value.ToString();
                                }
                            }

                            if (Session["goal_details"] != null)
                            {
                                dtable = (DataTable)Session["goal_details"];
                                for (int i = 0; i < dtable.Rows.Count; i++)
                                {
                                    //-----------Insert Assessment Details-------//
                                    SqlParameter[] sqlparam2 = new SqlParameter[12];
                                    Output.AssignParameter(sqlparam2, 0, "@assessment_id", "Int", 0, ds_id.ToString());
                                    Output.AssignParameter(sqlparam2, 1, "@flow_id", "Int", 0, flow_id);
                                    Output.AssignParameter(sqlparam2, 2, "@role", "String", 8000, dtable.Rows[i]["role_name_of_the_goal"].ToString()); //dtable.Rows[i]["role"].ToString()
                                    Output.AssignParameter(sqlparam2, 3, "@kca", "String", 8000, dtable.Rows[i]["kca_kra_desired_outcome_impact"].ToString());
                                    Output.AssignParameter(sqlparam2, 4, "@kpi", "String", 8000, dtable.Rows[i]["kpi_milestone_to_check_improvement"].ToString());
                                    Output.AssignParameter(sqlparam2, 5, "@weightage", "String", 2000, dtable.Rows[i]["weightage_timeline_and_support_required"].ToString());
                                    Output.AssignParameter(sqlparam2, 6, "@create_by", "String", 50, Session["empcode"].ToString());
                                    Output.AssignParameter(sqlparam2, 7, "@emp_comm", "String", 8000, "");
                                    Output.AssignParameter(sqlparam2, 8, "@mng_comm", "String", 8000, "");
                                    Output.AssignParameter(sqlparam2, 9, "@desigid", "Int", 0, Convert.ToString(desig.SelectedValue));
                                    Output.AssignParameter(sqlparam2, 10, "@asd_id", "Int", 0, "");
                                    Output.AssignParameter(sqlparam2, 11, "@empcode", "String", 50, Session["employee"].ToString());
                                    SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_assement_details", sqlparam2);
                                }

                                string sqlstr = @"select role_name_of_the_goal,kca_kra_desired_outcome_impact,kpi_milestone_to_check_improvement,weightage_timeline_and_support_required,
designationid from tbl_appraisal_emp_goal_cycle1 where designationid='" + desig.SelectedValue + "'";

                                DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                                if (ds.Tables[0].Rows.Count < 1)
                                {
                                    foreach (GridViewRow row1 in gvGoals.Rows)
                                    {
                                        Label role = (Label)row1.FindControl("lblro");
                                        Label kca = (Label)row1.FindControl("Label2");
                                        Label kpi = (Label)row1.FindControl("Label3");
                                        Label weightage = (Label)row1.FindControl("Label1e");

                                        //-----------Insert Employee Goal Cycle1 Details-------//

                                        SqlParameter[] sqlparam2 = new SqlParameter[9];
                                        Output.AssignParameter(sqlparam2, 0, "@empcode", "String", 60, Session["employee"].ToString());
                                        Output.AssignParameter(sqlparam2, 1, "@assessment_id", "String", 10, ds_id.ToString());
                                        Output.AssignParameter(sqlparam2, 2, "@role_name_of_the_goal", "String", 8000, role.Text);
                                        Output.AssignParameter(sqlparam2, 3, "@kca_kra_desired_outcome_impact", "String", 8000, kca.Text);
                                        Output.AssignParameter(sqlparam2, 4, "@kpi_milestone_to_check_improvement", "String", 8000, kpi.Text);
                                        Output.AssignParameter(sqlparam2, 5, "@weightage_timeline_and_support_required", "String", 8000, weightage.Text);
                                        Output.AssignParameter(sqlparam2, 6, "@designationid", "String", 10, Convert.ToString(desig.SelectedValue));
                                        Output.AssignParameter(sqlparam2, 7, "@designationname", "String", 100, Convert.ToString(desig.SelectedItem.Text));
                                        Output.AssignParameter(sqlparam2, 8, "@createdby", "String", 60, empcode);

                                        SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_emp_goal_cycle1", sqlparam2);
                                    }
                                }
                            }
                            else
                            {
                                if (gvGoals.Rows.Count > 0)
                                {
                                    foreach (GridViewRow row1 in gvGoals.Rows)
                                    {
                                        //Label asd_id = (Label)row1.FindControl("lblro2");
                                        Label role = (Label)row1.FindControl("lblro");
                                        Label kca = (Label)row1.FindControl("Label2");
                                        Label kpi = (Label)row1.FindControl("Label3");
                                        Label weightage = (Label)row1.FindControl("Label1e");
                                        //-----------Insert Assessment Details-------//
                                        SqlParameter[] sqlparam2 = new SqlParameter[12];
                                        Output.AssignParameter(sqlparam2, 0, "@assessment_id", "Int", 0, ds_id.ToString());
                                        Output.AssignParameter(sqlparam2, 1, "@flow_id", "Int", 0, flow_id);
                                        Output.AssignParameter(sqlparam2, 2, "@role", "String", 8000, role.Text); //dtable.Rows[i]["role"].ToString()
                                        Output.AssignParameter(sqlparam2, 3, "@kca", "String", 8000, kca.Text);
                                        Output.AssignParameter(sqlparam2, 4, "@kpi", "String", 8000, kpi.Text);
                                        Output.AssignParameter(sqlparam2, 5, "@weightage", "String", 2000, weightage.Text);
                                        Output.AssignParameter(sqlparam2, 6, "@create_by", "String", 50, Session["empcode"].ToString());
                                        Output.AssignParameter(sqlparam2, 7, "@emp_comm", "String", 8000, "");
                                        Output.AssignParameter(sqlparam2, 8, "@mng_comm", "String", 8000, "");
                                        Output.AssignParameter(sqlparam2, 9, "@desigid", "Int", 0, Convert.ToString(desig.SelectedValue));
                                        //Output.AssignParameter(sqlparam2, 10, "@asd_id", "Int", 0, asd_id.Text);
                                        Output.AssignParameter(sqlparam2, 10, "@asd_id", "Int", 0, "");
                                        Output.AssignParameter(sqlparam2, 11, "@empcode", "String", 50, Session["employee"].ToString());
                                        SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_assement_details", sqlparam2);
                                    }
                                }
                                if (GridView1.Rows.Count > 0)
                                {
                                    string sqlstr = @"select role_name_of_the_goal,kca_kra_desired_outcome_impact,kpi_milestone_to_check_improvement,weightage_timeline_and_support_required,
designationid from tbl_appraisal_emp_goal_cycle1 goal_cycle1 where designationid='" + desig.SelectedValue + "'";

                                    DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                                    if (ds.Tables[0].Rows.Count < 1)
                                    {
                                        foreach (GridViewRow row1 in gvGoals.Rows)
                                        {
                                            Label role = (Label)row1.FindControl("lblro");
                                            Label kca = (Label)row1.FindControl("Label2");
                                            Label kpi = (Label)row1.FindControl("Label3");
                                            Label weightage = (Label)row1.FindControl("Label1e");

                                            //-----------Insert Employee Goal Cycle1 Details-------//

                                            SqlParameter[] sqlparam2 = new SqlParameter[9];
                                            Output.AssignParameter(sqlparam2, 0, "@empcode", "String", 60, Session["employee"].ToString());
                                            Output.AssignParameter(sqlparam2, 1, "@assessment_id", "String", 10, ds_id.ToString());
                                            Output.AssignParameter(sqlparam2, 2, "@role_name_of_the_goal", "String", 8000, role.Text);
                                            Output.AssignParameter(sqlparam2, 3, "@kca_kra_desired_outcome_impact", "String", 8000, kca.Text);
                                            Output.AssignParameter(sqlparam2, 4, "@kpi_milestone_to_check_improvement", "String", 8000, kpi.Text);
                                            Output.AssignParameter(sqlparam2, 5, "@weightage_timeline_and_support_required", "String", 8000, weightage.Text);
                                            Output.AssignParameter(sqlparam2, 6, "@designationid", "String", 10, Convert.ToString(desig.SelectedValue));
                                            Output.AssignParameter(sqlparam2, 7, "@designationname", "String", 100, Convert.ToString(desig.SelectedItem.Text));
                                            Output.AssignParameter(sqlparam2, 8, "@createdby", "String", 60, empcode);

                                            SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_emp_goal_cycle1", sqlparam2);

                                        }
                                    }
                                }
                            }
                        }
                    }

                    //                    string sqlstr = @"select role_name_of_the_goal,kca_kra_desired_outcome_impact,kpi_milestone_to_check_improvement,weightage_timeline_and_support_required,
                    //designationid from tbl_appraisal_emp_goal_cycle1 goal_cycle1 where designationid='" + desig.SelectedValue + "'";

                    //                    DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                    //                    if (ds.Tables[0].Rows.Count < 1)
                    //                    {
                    //                        //foreach (GridViewRow row1 in gvGoals.Rows)
                    //                        //{
                    //                        //    Label role = (Label)row1.FindControl("lblro");
                    //                        //    Label kca = (Label)row1.FindControl("Label2");
                    //                        //    Label kpi = (Label)row1.FindControl("Label3");
                    //                        //    Label weightage = (Label)row1.FindControl("Label1e");

                    //                        //    //-----------Insert Employee Goal Cycle1 Details-------//

                    //                        //    SqlParameter[] sqlparam2 = new SqlParameter[9];
                    //                        //    Output.AssignParameter(sqlparam2, 0, "@empcode", "String", 60, Session["employee"].ToString());
                    //                        //    Output.AssignParameter(sqlparam2, 1, "@assessment_id", "String", 10, ds_id.ToString());
                    //                        //    Output.AssignParameter(sqlparam2, 2, "@role_name_of_the_goal", "String", 8000, role.Text);
                    //                        //    Output.AssignParameter(sqlparam2, 3, "@kca_kra_desired_outcome_impact", "String", 8000, kca.Text);
                    //                        //    Output.AssignParameter(sqlparam2, 4, "@kpi_milestone_to_check_improvement", "String", 8000, kpi.Text);
                    //                        //    Output.AssignParameter(sqlparam2, 5, "@weightage_timeline_and_support_required", "String", 8000, weightage.Text);
                    //                        //    Output.AssignParameter(sqlparam2, 6, "@designationid", "String", 10, Convert.ToString(desig.SelectedValue));
                    //                        //    Output.AssignParameter(sqlparam2, 7, "@designationname", "String", 100, Convert.ToString(desig.SelectedItem.Text));
                    //                        //    Output.AssignParameter(sqlparam2, 8, "@createdby", "String", 60, empcode);

                    //                        //    SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_emp_goal_cycle1", sqlparam2);

                    //                        //}
                    //                    }
                }
                else
                {
                    Output.Show("Employees are not Found");
                }
                Response.Redirect("AppraisalMaster.aspx?sub=true");
                return;
            }
            else
            {
                Output.Show("Please Add Goals");
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
            //Response.Redirect("AppraisalMaster.aspx?sub=true");
        }

    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        //bindempgrid();
        bindempgridforSearch();
    }

    private void getActiveCycle()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze!=1 ";
            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str1);
            if (cnt > 0)
            {
                int cycle = (int)SQLServer.ExecuteScalar(Connection, CommandType.StoredProcedure, "sp_appraisal_getapprisalcycle");
                if (cycle != 0)
                {
                    Session["appcycle"] = cycle;
                }
                else
                {
                    Output.Show("Please Mark Active Appraisal Cycle");
                }
            }
            else
            {
                Output.Show("Please Create Appraisal Cycle");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void dd_dpt_DataBound(object sender, EventArgs e)
    {
        dd_dpt.Items.Insert(0, new ListItem("-- All --", "0"));
    }

    private void bindgrid()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select apc_id,grade_id,title,description,weightage,createdby,createddate,status from tbl_appraisal_goals";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void BindGoals()
    {
        SqlConnection cn = null;
        try
        {
            cn = DataActivity.OpenConnection();
            //string str_1 = @"select asd_id, role, kpi, weightage, kca, desigid from dbo.tbl_appraisal_assessment_details where desigid='" + desig.SelectedValue + "' and create_by ='" + empcode + "'";
            string str_1 = @"select asd_id, role, kpi, weightage, kca, desigid from dbo.tbl_appraisal_assessment_details where desigid='" + desig.SelectedValue + "'";
            DataSet ds = SQLServer.ExecuteDataset(cn, CommandType.Text, str_1);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    //=================for Goal ===============================

    protected void cleargoalsfields()
    {
        textrole.Text = "";
        textkca.Text = "";
        textkpi.Text = "";
        txtWeightage.Text = "";
    }

    protected void btn_add_goals_Click(object sender, EventArgs e)
    {
        Div1.Visible = true;
        try
        {
            if (gvGoals.Rows.Count < 10)
            {
                //if (gvGoals.Rows.Count == 0)
                //{

                Ins_Goaldetails();
                return;

                //}
                //decimal weightage = 0;
                //Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
                //weightage = Convert.ToDecimal(total.Text);
                //if (weightage <= 100)
                //{

                //    weightage = Convert.ToDecimal(total.Text);
                //    weightage = weightage + Convert.ToDecimal(txtWeightage.Text);
                //    if (weightage <= 100)
                //    {
                //        Ins_Goaldetails();
                //    }
                //    else
                //    {
                //        Output.Show("Goals Total Weightage Should not be greater than 100.");
                //    }
                //}
                //else
                //{
                //    Output.Show("Goals Total Weightage Should not be greater than 100.");
                //}
            }
            else
            {
                Output.Show("You can add  maximum 10 Goals");
            }

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void create_goal_table()
    {

        dtable = new DataTable();
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        //dtable.Columns.Add(new DataColumn("appcycleid", typeof(int)));
        dtable.Columns.Add(new DataColumn("grade_id", typeof(int)));
        dtable.Columns.Add(new DataColumn("role_name_of_the_goal", typeof(string)));
        dtable.Columns.Add(new DataColumn("kca_kra_desired_outcome_impact", typeof(string)));
        dtable.Columns.Add(new DataColumn("kpi_milestone_to_check_improvement", typeof(string)));
        dtable.Columns.Add(new DataColumn("weightage_timeline_and_support_required", typeof(string)));
        //dtable.Columns.Add(new DataColumn("asd_id", typeof(int)));


        Session["goal_details"] = dtable;
    }

    private void Ins_Goaldetails()
    {
        try
        {
            DataRow dr;
            if (Session["goal_details"] == null)
            {
                create_goal_table();
            }
            dtable = (DataTable)Session["goal_details"];
            if (txtWeightage.Text != "" && textrole.Text != "" && textkca.Text != "" && textkpi.Text != "")
            {
                dr = dtable.NewRow();
                //dr["appcycleid"] = Convert.ToInt32(Session["appcycle"].ToString());
                //dr["grade_id"] = dd_grade.SelectedValue;
                dr["role_name_of_the_goal"] = textrole.Text;
                dr["kca_kra_desired_outcome_impact"] = textkca.Text;
                dr["kpi_milestone_to_check_improvement"] = textkpi.Text;
                dr["weightage_timeline_and_support_required"] = txtWeightage.Text;
                //dr["asd_id"] = 0;
                dtable.Rows.Add(dr);

                Session["goal_details"] = dtable;
                BindList_ofgoals();
                cleargoalsfields();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    private void BindList_ofgoals()
    {
        if (Session["goal_details"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["goal_details"];
            dview = new DataView(dtable);
        }

        if (dtable.Rows.Count <= 10)
        {
            gvGoals.DataSource = dview;
            gvGoals.DataBind();
        }
        else
        {
            Output.Show("You can add  maximum 10 goals");
        }
        if (dtable.Rows.Count == 0)
        {
            btnCancelGoals.Visible = false;
        }
        else
        {
            btnCancelGoals.Visible = true;
        }
    }

    protected void addgoals(string empcode)
    {

        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            if (Session["goal_details"] != null)
            {


                Connection = DataActivity.OpenConnection();

                dtable = (DataTable)Session["goal_details"];
                for (int i = 0; i < dtable.Rows.Count; i++)
                {

                    SqlParameter[] sqlParam = new SqlParameter[7];
                    Output.AssignParameter(sqlParam, 0, "@title", "String", 100, dtable.Rows[i]["title"].ToString());
                    Output.AssignParameter(sqlParam, 1, "@description", "String", 8000, dtable.Rows[i]["description"].ToString());
                    Output.AssignParameter(sqlParam, 2, "@weightage", "Decimal", 0, dtable.Rows[i]["weightage"].ToString());
                    Output.AssignParameter(sqlParam, 3, "@appcycleid", "Int", 4, Session["appcycle"].ToString());
                    Output.AssignParameter(sqlParam, 4, "@create_by", "String", 50, Session["empcode"].ToString());
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "[sp_appraisal_insert_appraisalcycle]", sqlParam);
                    SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_add_goalsByHR", sqlParam);
                    Output.Show("Goals are Added  Successfully ");
                }
            }
            else
            {
                Output.Show("Please add Goals");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void gvGoals_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    decimal rowTotal = (DataBinder.Eval(e.Row.DataItem, "weightage");
            //    grdTotal = grdTotal + rowTotal;
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label lbl = (Label)e.Row.FindControl("lblTotalWeightage");
            //    lbl.Text = grdTotal.ToString();
            //}
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    /*=================for Goal ===============================*/

    //protected void dd_grade_DataBound(object sender, EventArgs e)
    //{
    //    dd_grade.Items.Insert(0, new ListItem("----- All -----", "0"));
    //}

    protected void ddl_appraisal_cycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddl_emp();
    }

    protected void bindempgrid()
    {
        try
        {
            string sqlstr = @"select isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
convert(varchar(40),empjob.emp_doj,106) as emp_doj,empappr.status                  
 from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
--inner join tbl_employee_approvers empappr on empjob.empcode=empappr.empcode
left join tbl_appraisal_flow app_flow on empappr.empcode=app_flow.empcode
where 1=1 and empappr.status=0 and empjob.emp_status in (1,3) 
and empjob.empcode not in(select empcode from tbl_appraisal_flow)
 order by empjob.empcode";

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            if (ds.Tables.Count > 0)
            {
                gveligible.DataSource = ds;
                gveligible.DataBind();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void bindempgridforSearch()
    {
        try
        {
            string sqlstr = @"select isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,empjob.degination_id,empdesg.designationname as designation,empjob.dept_id,empdept.department_name as dept,
convert(varchar(40),empjob.emp_doj,106) as emp_doj,empappr.status                  
 from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
--inner join tbl_employee_approvers empappr on empjob.empcode=empappr.empcode
left join tbl_appraisal_flow app_flow on empappr.empcode=app_flow.empcode
where 1=1 and empappr.status=0 and empjob.emp_status in (1,3) 
and empjob.empcode not in(select empcode from tbl_appraisal_flow)";

            if (txt_employee.Text != "")
            {
                sqlstr = sqlstr + " and empjob.empcode='" + txt_employee.Text + "'";
            }
            if (dd_dpt.SelectedValue != "0")
            {
                sqlstr = sqlstr + " and empjob.dept_id='" + dd_dpt.SelectedValue + "'";
            }
            if (ddldesig.SelectedValue != "0")
            {
                sqlstr = sqlstr + " and empjob.degination_id='" + ddldesig.SelectedValue + "'";
            }

            sqlstr = sqlstr + " order by empjob.empcode";

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            if (ds.Tables.Count > 0)
            {
                gveligible.DataSource = ds;
                gveligible.DataBind();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void bindempgrid2()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {

            //Output.AssignParameter(sqlparam, 0, "@HRempcode", "String", 50, Session["empcode"].ToString());
            //Output.AssignParameter(sqlparam, 1, "@empcode", "String", 150, "");
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 150, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, "");
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 3, "@dept", "Int", 0, "0");


            Connection = DataActivity.OpenConnection();
            DataSet ds = new DataSet();

            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_emp_for_setgoals", sqlparam);

            if (ds.Tables.Count > 0)
            {
                gveligible.DataSource = ds;
                gveligible.DataBind();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void gveligible_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gveligible.PageIndex = e.NewPageIndex;
        bindempgrid();
    }

    //----------bind Select Employee Drop down------------------

    protected void Bind_ddl_emp()
    {
        //SqlParameter[] sqlparam = new SqlParameter[2];
        //SqlConnection Connection = null;
        //try
        //{

        //    Output.AssignParameter(sqlparam, 0, "@appcycle_id", "Int", 0, Session["appcycle"].ToString());
        //    Output.AssignParameter(sqlparam, 1, "@HrEmpcode", "String", 50, Session["empcode"].ToString());
        //    Connection = DataActivity.OpenConnection();
        //    DataSet ds = new DataSet();
        //    ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_getemp", sqlparam);
        //    ddl_Emp.Items.Clear();
        //    if (ds.Tables.Count > 0)
        //    {
        //        ddl_Emp.DataTextField = "emp_name";
        //        ddl_Emp.DataValueField = "empcode";
        //        ddl_Emp.DataSource = ds;
        //        ddl_Emp.DataBind();
        //    }
        //    ddl_Emp.Items.Insert(0, new ListItem("----- All -----", "0"));
        //}
        //catch (Exception ex)
        //{
        //    Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //    Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        //}
        //finally
        //{
        //    DataActivity.CloseConnection();
        //}
    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)gveligible.HeaderRow.FindControl("chkSelectAll");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }

    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
        {
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void gvGoals_PreRender(object sender, EventArgs e)
    {
        if (gvGoals.Rows.Count > 0)
        {
            gvGoals.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

        textrole.Text = "";
        textkca.Text = "";
        textkpi.Text = "";
        txtWeightage.Text = "";
        btn_add_goals.Enabled = true;
    }

    protected void desig_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string datatable = Session["goal_details"].ToString();
        //slectedDeptGrid();
        if (desig.SelectedValue != "0")
        {
            try
            {
                connection = activity.OpenConnection();
                string sqlstr = "select asd_id, role, kpi, weightage, kca, desigid from dbo.tbl_appraisal_assessment_details where desigid='" + desig.SelectedValue + "' and create_by ='" + empcode + "'";
                string sqlstr_1 = @"select role_name_of_the_goal,kca_kra_desired_outcome_impact,kpi_milestone_to_check_improvement,weightage_timeline_and_support_required,
designationid from tbl_appraisal_emp_goal_cycle1 goal_cycle1 where designationid='" + desig.SelectedValue + "'";
                DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
                DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_1);
                //if (ds.Tables[0].Rows.Count > 0)
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (role == "3")
                    {
                        Div1.Visible = true;
                        //gvGoals.DataSource = ds;
                        gvGoals.DataSource = ds1;
                        gvGoals.DataBind();
                        //Session["goal_details"] = ds.Tables[0];
                        foreach (GridViewRow gvr in gvGoals.Rows)
                        {
                            gvr.Cells[5].Visible = false;
                            gvr.Cells[6].Visible = false;
                        }
                        gvGoals.HeaderRow.Cells[5].Visible = false;
                        gvGoals.HeaderRow.Cells[6].Visible = false;
                    }
                    else
                    {
                        //gvGoals.DataSource = ds;
                        gvGoals.DataSource = ds1;
                        gvGoals.DataBind();
                        //Session["goal_details"] = ds.Tables[0];
                        Div1.Visible = true;
                        foreach (GridViewRow gvr in gvGoals.Rows)
                        {
                            gvr.Cells[5].Visible = false;
                            gvr.Cells[6].Visible = false;
                        }
                        gvGoals.HeaderRow.Cells[5].Visible = false;
                        gvGoals.HeaderRow.Cells[6].Visible = false;
                    }
                }
                else
                {
                    //Response.Redirect("AppraisalMaster.aspx");
                    Div1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                activity.CloseConnection();
            }
        }
        else
        {
            Response.Redirect("AppraisalMaster.aspx");
        }

    }

    private void slectedDeptGrid()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select asd_id, role, kpi, weightage, kca, desigid from dbo.tbl_appraisal_assessment_details where desigid='" + desig.SelectedValue + "' and create_by ='" + empcode + "'";
            //string sqlstr = "select asd_id, role, kpi, weightage, kca, desigid from dbo.tbl_appraisal_assessment_details where desigid='" + desig.SelectedValue + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (role == "3")
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Session["goal_details"] = ds.Tables[0];
                    Tr1.Visible = true;
                }
                else
                {
                    gvGoals.DataSource = ds;
                    gvGoals.DataBind();
                    Session["goal_details"] = ds.Tables[0];
                    Div1.Visible = true;
                }
            }
            else
            {
                Div1.Visible = false;
                Tr1.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void dd_dpt_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindDesignation(dd_dpt.SelectedValue);
    }

    private void BindDesignation(string deptid)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid='" + deptid + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddldesig.DataSource = ds;
                ddldesig.DataTextField = "designationname";
                ddldesig.DataValueField = "id";
                ddldesig.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
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

    protected void desig_DataBound(object sender, EventArgs e)
    {
        desig.Items.Insert(0, new ListItem("--Select Designation--", "0"));
    }

    protected void gvGoals_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        dtable = (DataTable)Session["goal_details"];
        int selId = (int)gvGoals.DataKeys[e.RowIndex].Value;
        DataRow dsSel = dtable.Rows[e.RowIndex];
        //DataRow drfind = dtable.Rows.Find(Convert.ToString(gvGoals.DataKeys[e.RowIndex].Value));
        if (dsSel != null)
        {
            //DataRow drSel = dtable.Rows[selId];
            dsSel.Delete();
            Session["goal_details"] = dtable;

            gvGoals.DataSource = dtable;
            gvGoals.DataBind();
            //BindList_ofgoals();
        }
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "delete from tbl_appraisal_assessment_details where asd_id = '" + selId.ToString().Trim() + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            slectedDeptGrid();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        Div1.Visible = true;
    }

    protected void btnCancelGoals_Click(object sender, EventArgs e)
    {
        Div1.Visible = true;
        dtable = (DataTable)Session["goal_details"];
        dtable.Rows.Clear();
        Session["goal_details"] = dtable;
        BindList_ofgoals();

    }

    protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    {

        if (Session["goal_details"] == null)
        {
            create_goal_table();
        }
        dtable = (DataTable)Session["goal_details"];
        //DataRow drfind = dtable.Rows.Find(Convert.ToString(gvGoals.DataKeys[e.NewEditIndex].Value));

        //Label Label1 = (Label)gvGoals.Rows[e.NewEditIndex].FindControl("labeledit");

        gvGoals.EditIndex = e.NewEditIndex;
        gvGoals.DataSource = dtable;
        gvGoals.DataBind();
        Div1.Visible = true;
    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //DataRow dr;
        int a = e.RowIndex;
        int abc = (int)gvGoals.DataKeys[e.RowIndex].Value;
        TextBox textrole = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text1");
        TextBox textkca = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text2");
        TextBox textkpi = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text3");
        TextBox textweight = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text4");

        dtable = (DataTable)Session["goal_details"];
        dtable.Rows[a]["role"] = textrole.Text;
        dtable.Rows[a]["kca"] = textkca.Text;
        dtable.Rows[a]["kpi"] = textkpi.Text;
        dtable.Rows[a]["weightage"] = textweight.Text;
        gvGoals.EditIndex = -1;
        Session["goal_details"] = dtable;
        gvGoals.DataSource = dtable;
        gvGoals.DataBind();
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"update tbl_appraisal_assessment_details 
set role='" + textrole.Text + "',kpi='" + textkpi.Text + "',weightage='" + textweight.Text + "',kca='" + textkca.Text + "' where asd_id = '" + abc.ToString().Trim() + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        Div1.Visible = true;
    }

    protected void btn_add_goals1_Click(object sender, EventArgs e)
    {

        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "insert into tbl_appraisal_assessment_details()values()";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
            //Session["goal_details"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Reset the edit index.
        gvGoals.EditIndex = -1;

        //Bind data to the GridView control.
        //BindGoals();
        BindList_ofgoals();

        //Session["goal_details"] = dtable;
        //gvGoals.DataSource = dtable;
        //gvGoals.DataBind();
        Div1.Visible = true;
    }

    protected void desig_DataBound1(object sender, EventArgs e)
    {
        desig.Items.Insert(0, new ListItem("--Select Designation--", "0"));
    }

    protected void ddldesig_DataBound(object sender, EventArgs e)
    {
        ddldesig.Items.Insert(0, new ListItem("--All--", "0"));
    }

}