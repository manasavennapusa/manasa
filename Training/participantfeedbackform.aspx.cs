using Common.Console;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class training_participantfeedbackform : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    string Usercode, fromdate, todate, Faculty, modulename, modulenamess;
    int tid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] == null)
            Response.Redirect("~/notlogged.aspx");

        Usercode = Session["empcode"].ToString();
        tid = Convert.ToInt16(Request.QueryString["id"]);

        fromdate = Request.QueryString["FromDate"].ToString();
        todate = Request.QueryString["ToDate"].ToString();
        Faculty = Request.QueryString["Faculty"].ToString();
        modulename = Request.QueryString["module_name"].ToString();
        //message.InnerHtml = "";
        if (!IsPostBack)
        {
            bind_participantfeed();
        }
   
    }

    protected void btn_select_Click(object sender, EventArgs e)
    {

    }

    protected void btn_deselect_Click(object sender, EventArgs e)
    {
        Clearfield();
    }

    private void Clearfield()
    {
        Text4.Text = "";
        Text1.Text = "";
        Text2.Text = "";
     
        var cntls = GetAll(this, typeof(RadioButton));
        foreach (Control cntrl in cntls)
        {
            RadioButton _rb = (RadioButton)cntrl;
            if (_rb.Checked)
            {
                _rb.Checked = false;
            }
        }
    }

    public IEnumerable<Control> GetAll(Control control, Type type)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrls => GetAll(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewParticipantsScheduled.aspx");
    }

    protected void btn_select_Click1(object sender, EventArgs e)
    {
        
        try
        {               
                connection = activity.OpenConnection();
                insert_feedback(connection, transaction);
           
        }
        catch (Exception ex)
        {
           
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            Output.Show("Submitted Successfully");
            Clearfield();
        }
    }

    protected void bind_participantfeed()
    {
        //string sqlstr;
        DataActivity activity = new DataActivity();
        SqlConnection connection = new SqlConnection();
        SqlTransaction transaction = null;
        int deptid = Convert.ToInt16(Request.QueryString["dept_name"].ToString());
        try
        {

            connection = activity.OpenConnection();

            string strng = @"select module_name from tbl_training_schedul where id='" + tid + "'";
            DataSet dsInsertedEmps = SQLServer.ExecuteDataset(connection, CommandType.Text, strng);
            if (dsInsertedEmps.Tables[0].Rows.Count < 1)
            {
                return;
            }
            else
            {
                modulenamess = dsInsertedEmps.Tables[0].Rows[0]["module_name"].ToString();
            }

            //string sqlstr = "select ts.training_name,ts.fromdate,jd.emp_fname,ts.faculty,ts.trainer,jd.empcode,dp.department_name from dbo.tbl_training_shedulee ts inner join tbl_intranet_employee_jobDetails jd on jd.dept_id=ts.dept_id inner join tbl_internate_departmentdetails dp on dp.departmentid=jd.dept_id";

//            string sqlstr = @"select * from tbl_training_schedul ts
//inner join tbl_training_elegible_emp emp on emp.training_code=ts.training_code
//where emp.empcode='" + Usercode + "'";


            string sqlstr = @"select distinct * from tbl_training_schedul emp
inner join tbl_training_elegible_emp ts  on emp.training_code=ts.training_code and 
 ts.training_name=emp.training_name
 and emp.module_name=ts.modulename 
inner join tbl_internate_departmentdetails dp on dp.departmentid=emp.dept_name
where ts.empcode='" + Usercode + "' and module_name='" + modulenamess + "' and  dp.departmentid=" + deptid + " and  emp.fromdate='" + fromdate + "' and emp.todate='" + todate + "'";



            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
            {
                Output.Show("Training Section is not assigned");
                btn_submit.Visible = true;
                btn_select.Visible = false;
                btn_deselect.Visible = false;
                return;
            }
            txtcmpname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
            if (ds.Tables[0].Rows[0]["fromdate"].ToString() != "")
            {
                txt_est_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");


            }
            if (ds.Tables[0].Rows[0]["todate"].ToString() != "")
            {
                Label1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy");
            }
            txt_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            txt_pan.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
            txttin.Text = ds.Tables[0].Rows[0]["faculty"].ToString();
            txtregno.Text = ds.Tables[0].Rows[0]["trainer"].ToString();
            txt_tanno.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            //txt_tds.Text = ds.Tables[0].Rows[0]["ptno"].ToString();
            txtscheled.Text = ds.Tables[0].Rows[0]["createdby"].ToString();

            string str = @"select empcode,status from tbl_training_participants_feedback_form
                              where empcode='" + Usercode + "' and CONVERT(varchar(40),fromdate,106)='" + fromdate + "' and CONVERT(varchar(40),todate,106)='" + todate + "'";
           DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, str);
           if (ds1.Tables[0].Rows.Count < 1)
           {
                return;
           }
            int value = Convert.ToInt32(ds1.Tables[0].Rows[0]["status"].ToString());
            if (value == 1)
            {
                btn_select.Visible = false;
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

    protected void insert_feedback(SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlParam = new SqlParameter[21];
        sqlParam[0] = new SqlParameter("@objective", SqlDbType.VarChar,10);
        if (RadioButton1.Checked)
        {
            sqlParam[0].Value = 1;
        }
        if (RadioButton2.Checked)
        {
            sqlParam[0].Value = 2;
        }
        if (RadioButton3.Checked)
        {
            sqlParam[0].Value = 3;
        }
        if (RadioButton4.Checked)
        {
            sqlParam[0].Value = 4;
        }
        if (RadioButton5.Checked)
        {
            sqlParam[0].Value =5;
        }
        if (RadioButton6.Checked)
        {
            sqlParam[0].Value =6;
        }
        if (RadioButton7.Checked)
        {
            sqlParam[0].Value = 7;
        }
        if (RadioButton1.Checked == false && RadioButton2.Checked == false && RadioButton3.Checked == false && RadioButton4.Checked == false && RadioButton5.Checked == false && RadioButton6.Checked == false && RadioButton7.Checked == false)
        {
            sqlParam[0].Value = 0;
        }
        sqlParam[1] = new SqlParameter("@subject", SqlDbType.VarChar,10);
        if (RadioButton8.Checked)
        {
            sqlParam[1].Value = 1;
        }
        if (RadioButton9.Checked)
        {
            sqlParam[1].Value = 2;
        }
        if (RadioButton10.Checked)
        {
            sqlParam[1].Value = 3;
        }
        if (RadioButton11.Checked)
        {
            sqlParam[1].Value = 4;
        }
        if (RadioButton12.Checked)
        {
            sqlParam[1].Value = 5;
        }
        if (RadioButton13.Checked)
        {
            sqlParam[1].Value = 6;
        }
        if (RadioButton14.Checked)
        {
            sqlParam[1].Value = 7;
        }
        if (RadioButton8.Checked == false && RadioButton9.Checked == false && RadioButton10.Checked == false && RadioButton11.Checked == false && RadioButton12.Checked == false && RadioButton13.Checked == false && RadioButton14.Checked == false)
        {
            sqlParam[1].Value = 0;
        }
        sqlParam[2] = new SqlParameter("@learnings", SqlDbType.VarChar,10);
        if (RadioButton15.Checked)
        {
            sqlParam[2].Value = 1;
        }
        if (RadioButton16.Checked)
        {
            sqlParam[2].Value = 2;
        }
        if (RadioButton17.Checked)
        {
            sqlParam[2].Value = 3;
        }
        if (RadioButton18.Checked)
        {
            sqlParam[2].Value = 4;
        }
        if (RadioButton19.Checked)
        {
            sqlParam[2].Value = 5;
        }
        if (RadioButton20.Checked)
        {
            sqlParam[2].Value = 6;
        }
        if (RadioButton21.Checked)
        {
            sqlParam[2].Value = 7;
        }
        if (RadioButton15.Checked == false && RadioButton16.Checked == false && RadioButton17.Checked == false && RadioButton18.Checked == false && RadioButton19.Checked == false && RadioButton20.Checked == false && RadioButton21.Checked == false)
        {
            sqlParam[2].Value = 0;
        }
        sqlParam[3] = new SqlParameter("@communicator", SqlDbType.VarChar,10);
        if (RadioButton22.Checked)
        {
            sqlParam[3].Value = 1;
        }
        if (RadioButton23.Checked)
        {
            sqlParam[3].Value = 2;
        }
        if (RadioButton24.Checked)
        {
            sqlParam[3].Value = 3;
        }
        if (RadioButton25.Checked)
        {
            sqlParam[3].Value = 4;
        }
        if (RadioButton26.Checked)
        {
            sqlParam[3].Value = 5;
        }
        if (RadioButton27.Checked)
        {
            sqlParam[3].Value = 6;
        }
        if (RadioButton28.Checked)
        {
            sqlParam[3].Value = 7;
        }
        if (RadioButton22.Checked == false && RadioButton23.Checked == false && RadioButton24.Checked == false && RadioButton25.Checked == false && RadioButton26.Checked == false && RadioButton27.Checked == false && RadioButton28.Checked == false)
        {
            sqlParam[3].Value = 0;
        }
        sqlParam[4] = new SqlParameter("@wellprepared", SqlDbType.VarChar,10);
        if (RadioButton29.Checked)
        {
            sqlParam[4].Value = 1;
        }
        if (RadioButton30.Checked)
        {
            sqlParam[4].Value = 2;
        }
        if (RadioButton31.Checked)
        {
            sqlParam[4].Value = 3;
        }
        if (RadioButton32.Checked)
        {
            sqlParam[4].Value = 4;
        }
        if (RadioButton33.Checked)
        {
            sqlParam[4].Value = 5;
        }
        if (RadioButton34.Checked)
        {
            sqlParam[4].Value = 6;
        }
        if (RadioButton35.Checked)
        {
            sqlParam[4].Value = 7;
        }
        if (RadioButton29.Checked == false && RadioButton30.Checked == false && RadioButton31.Checked == false && RadioButton32.Checked == false && RadioButton33.Checked == false && RadioButton34.Checked == false && RadioButton35.Checked == false)
        {
            sqlParam[4].Value = 0;
        }
        sqlParam[5] = new SqlParameter("@approachable", SqlDbType.VarChar,10);
        if (RadioButton36.Checked)
        {
            sqlParam[5].Value = 1;
        }
        if (RadioButton37.Checked)
        {
            sqlParam[5].Value = 2;
        }
        if (RadioButton38.Checked)
        {
            sqlParam[5].Value = 3;
        }
        if (RadioButton39.Checked)
        {
            sqlParam[5].Value = 4;
        }
        if (RadioButton40.Checked)
        {
            sqlParam[5].Value = 5;
        }
        if (RadioButton41.Checked)
        {
            sqlParam[5].Value = 6;
        }
        if (RadioButton42.Checked)
        {
            sqlParam[5].Value = 7;
        }
        if (RadioButton36.Checked == false && RadioButton37.Checked == false && RadioButton38.Checked == false && RadioButton39.Checked == false && RadioButton40.Checked == false && RadioButton41.Checked == false && RadioButton42.Checked == false)
        {
            sqlParam[5].Value = 0;
        }
        sqlParam[6] = new SqlParameter("@trainingcontent", SqlDbType.VarChar,10);
        if (RadioButton43.Checked)
        {
            sqlParam[6].Value = 1;
        }
        if (RadioButton44.Checked)
        {
            sqlParam[6].Value = 2;
        }
        if (RadioButton45.Checked)
        {
            sqlParam[6].Value = 3;
        }
        if (RadioButton46.Checked)
        {
            sqlParam[6].Value = 4;
        }
        if (RadioButton47.Checked)
        {
            sqlParam[6].Value = 5;
        }
        if (RadioButton48.Checked)
        {
            sqlParam[6].Value = 6;
        }
        if (RadioButton49.Checked)
        {
            sqlParam[6].Value = 7;
        }
        if (RadioButton43.Checked == false && RadioButton44.Checked == false && RadioButton45.Checked == false && RadioButton46.Checked == false && RadioButton47.Checked == false && RadioButton48.Checked == false && RadioButton49.Checked == false)
        {
            sqlParam[6].Value = 0;
        }
        sqlParam[7] = new SqlParameter("@balance", SqlDbType.VarChar,10);
        if (RadioButton50.Checked)
        {
            sqlParam[7].Value = 1;
        }
        if (RadioButton51.Checked)
        {
            sqlParam[7].Value = 2;
        }
        if (RadioButton52.Checked)
        {
            sqlParam[7].Value = 3;
        }
        if (RadioButton53.Checked)
        {
            sqlParam[7].Value = 4;
        }
        if (RadioButton54.Checked)
        {
            sqlParam[7].Value = 5;
        }
        if (RadioButton55.Checked)
        {
            sqlParam[7].Value = 6;
        }
        if (RadioButton56.Checked)
        {
            sqlParam[7].Value = 7;
        }
        if (RadioButton50.Checked == false && RadioButton51.Checked == false && RadioButton52.Checked == false && RadioButton53.Checked == false && RadioButton54.Checked == false && RadioButton55.Checked == false && RadioButton56.Checked == false)
        {
            sqlParam[7].Value = 0;
        }
        sqlParam[8] = new SqlParameter("@question", SqlDbType.VarChar,10);
        if (RadioButton57.Checked)
        {
            sqlParam[8].Value = 1;
        }
        if (RadioButton58.Checked)
        {
            sqlParam[8].Value = 2;
        }
        if (RadioButton59.Checked)
        {
            sqlParam[8].Value = 3;
        }
        if (RadioButton60.Checked)
        {
            sqlParam[8].Value = 4;
        }
        if (RadioButton61.Checked)
        {
            sqlParam[8].Value = 5;
        }
        if (RadioButton62.Checked)
        {
            sqlParam[8].Value = 6;
        }
        if (RadioButton63.Checked)
        {
            sqlParam[8].Value = 7;
        }
        if (RadioButton57.Checked == false && RadioButton58.Checked == false && RadioButton59.Checked == false && RadioButton60.Checked == false && RadioButton61.Checked == false && RadioButton62.Checked == false && RadioButton63.Checked == false)
        {
            sqlParam[8].Value = 0;
        }
        //sqlParam[9] = new SqlParameter("@programme", SqlDbType.VarChar, 50);
        //if (RadioButton64.Checked)
        //{
        //    sqlParam[9].Value = "Too Short";
        //}
        //if (RadioButton65.Checked)
        //{
        //    sqlParam[9].Value = "About Right";
        //}
        //if (RadioButton66.Checked)
        //{
        //    sqlParam[9].Value = "Too Long";
        //}
        //if (RadioButton64.Checked == false && RadioButton65.Checked == false && RadioButton66.Checked == false)
        //{
        //    sqlParam[9].Value = "";
        //}
        sqlParam[9] = new SqlParameter("@prog_suggestion", SqlDbType.VarChar, 200);
        sqlParam[9].Value = Text4.Text;
        sqlParam[10] = new SqlParameter("@faculty", SqlDbType.VarChar, 200);
        sqlParam[10].Value = Text1.Text;
        sqlParam[11] = new SqlParameter("@other", SqlDbType.VarChar, 200);
        sqlParam[11].Value = Text2.Text;
        //sqlParam[13] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        //sqlParam[13].Value = "";
        sqlParam[12] = new SqlParameter("@empcode", SqlDbType.VarChar, 40);
        sqlParam[12].Value = txt_empcode.Text;
        sqlParam[13] = new SqlParameter("@training_name", SqlDbType.VarChar, 40);
        sqlParam[13].Value = txtcmpname.Text;
        sqlParam[14] = new SqlParameter("@conducted_by", SqlDbType.VarChar, 40);
        sqlParam[14].Value = txttin.Text;
        sqlParam[15] = new SqlParameter("@dept", SqlDbType.VarChar, 40);
        sqlParam[15].Value = txt_tanno.Text;
        sqlParam[16] = new SqlParameter("@participant_name", SqlDbType.VarChar, 50);
        sqlParam[16].Value = txt_pan.Text;
        sqlParam[17] = new SqlParameter("@created_by", SqlDbType.VarChar, 200);
        sqlParam[17].Value = Usercode;
        sqlParam[18] = new SqlParameter("@sheclede_by", SqlDbType.VarChar, 50);
        sqlParam[18].Value = txtscheled.Text;
        sqlParam[19] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlParam[19].Value = txt_est_date.Text;
        sqlParam[20] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlParam[20].Value = Label1.Text;

        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_training_insert_participants_feedback_form", sqlParam);
        btn_select.Visible = false;
    }

    public SqlConnection connection { get; set; }

    public SqlTransaction transaction { get; set; }

    public object empcode { get; set; }
}