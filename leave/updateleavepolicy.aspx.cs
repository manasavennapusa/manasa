using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Common.Console;
using Common.Data;
public partial class leave_updateleavepolicy : System.Web.UI.Page
{
    string _companyId;
    private DataSet _ds;
    string policy_file_name = "1.pdf";
    string policy_file_type = ".pdf";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindData(Convert.ToInt32(_companyId));
            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }


    private void BindData(int companyId)
    {

        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = "select policyid,policyname,policydescription,policy_file_name,policy_file_type,date,(policy_file_name+policy_file_type) as name  from tbl_leave_createleavepolicy where policyid=" + Request.QueryString["policyid"] + " and company_id=" + companyId;
            _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            txt_policy.Text = _ds.Tables[0].Rows[0]["policyname"].ToString();
            txt_policy_desc.Text = _ds.Tables[0].Rows[0]["policydescription"].ToString();
            lbl_file.Text = (_ds.Tables[0].Rows[0]["policy_file_type"].ToString() != "") ? "<a target='_blank' href='upload/policydockit/" + _ds.Tables[0].Rows[0]["name"] +
                "'>" + _ds.Tables[0].Rows[0]["policy_file_name"] + "</a>" : "No exisitng file found";
            prvimg.Value = _ds.Tables[0].Rows[0]["policy_file_name"].ToString();
            hdfiletype.Value = _ds.Tables[0].Rows[0]["policy_file_type"].ToString(); ;

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


    private void Uploadfile()
    {

        var parm = new SqlParameter[6];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        string filExt = "";
        try
        {
            string filename;
            filename = System.IO.Path.GetFileName(fupload.PostedFile.FileName);
            if (fupload.HasFile)
            {
                string policyFileName = txt_policy.Text + DateTime.Now.GetHashCode();
                filExt = System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                fupload.PostedFile.SaveAs(Server.MapPath("upload/policydockit/" + policyFileName + filExt));
                ViewState.Add("policy_file_name", policyFileName);
                ViewState.Add("policy_file_type", filExt);
            }
            else
            {
                filename = prvimg.Value;

                ViewState["policy_file_name"] = filename;
                ViewState["policy_file_type"] = hdfiletype.Value;
            }
            Output.AssignParameter(parm, 0, "@policyname", "String", 100, txt_policy.Text);
            Output.AssignParameter(parm, 1, "@policydescription", "String", 2000, txt_policy_desc.Text);
            Output.AssignParameter(parm, 2, "@policy_file_name", "String", 200, ViewState["policy_file_name"].ToString());
            Output.AssignParameter(parm, 3, "@policy_file_type", "String", 100, ViewState["policy_file_type"].ToString());
            //Output.AssignParameter(parm, 4, "@date", "DateTime", 0, DateTime.Today.ToString(CultureInfo.InvariantCulture));
            Output.AssignParameter(parm, 4, "@date", "DateTime", 0, DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss"));
            Output.AssignParameter(parm, 5, "@policyid", "String", 100, Request.QueryString["policyid"]);
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_updateleavepolicy", parm);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (flag > 0)
        {

            Response.Redirect("EditLeavePolicy.aspx?updated=true");

        }
        else
        {
            Output.Show("Leave policy  already exists, please enter another name");
        }

    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        Uploadfile();

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("editleavepolicy.aspx");
    }
}
