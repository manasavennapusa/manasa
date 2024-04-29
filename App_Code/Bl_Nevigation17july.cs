using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using querystring;
using Utilities;

public class Bl_Nevigation
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString());
    SqlCommand cm = new SqlCommand();
    int pid = 0, j;

    /********************** Created Date:21/5/09 Created By: Anshul Verma *******************************************/
    /********************** Code to create leave master ********************************/


    public void create_leave_master(string leavetype, string description, string displayleave, DateTime createddate, string createdby, string modifiedby, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_createleave";
            cm.Parameters.Add("@leavetype", SqlDbType.VarChar, 100).Value = leavetype;
            cm.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = description;
            cm.Parameters.Add("@displayleave", SqlDbType.VarChar, 100).Value = displayleave;
            cm.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate;
            cm.Parameters.Add("@createdby", SqlDbType.VarChar, 100).Value = createdby;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }

    }



    /********************** Created Date: 21/5/06 Created By: Anshul Verma *******************************************/
    /********************** Code to update leave master ********************************/

    public void update_leave_master(string leaveid, string leavetype, string displayleave, string description, string modifiedby, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_updateleave";
            cm.Parameters.Add("@leaveid", SqlDbType.Int).Value = leaveid;
            cm.Parameters.Add("@leavetype", SqlDbType.VarChar, 100).Value = leavetype;
            cm.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = description;
            cm.Parameters.Add("@displayleave", SqlDbType.VarChar, 100).Value = displayleave;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }


    }



    /*********************************** Create Holiday Master **********************************/
    /********************** Created Date: 26/05/09 Created By: Disha Mittal ***********************/

    public void create_holiday_master(string year, int branch_id, string name, string detail, DateTime date, string createdby, DateTime createddate, string modifiedby, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_createholiday";
            cm.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = year;
            cm.Parameters.Add("@branch_id", SqlDbType.Int).Value = branch_id;
            cm.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = name;
            cm.Parameters.Add("@detail", SqlDbType.VarChar, 100).Value = detail;
            cm.Parameters.Add("@date", SqlDbType.DateTime).Value = Utility.dataformat(date.ToString("MM/dd/yyyy"));
            cm.Parameters.Add("@createdby", SqlDbType.VarChar, 100).Value = createdby;
            cm.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }

    }



    /********************** Created Date:23/6/09 Created By: Anshul Verma *******************************************/
    /********************** Code to apply OD  ********************************/

    public void apply_od(string empcode, decimal working_hour, string reason, int Approval_status, int Leave_status, bool flag, bool status, DateTime createddate, string createdby, string modifiedby, string comment, int leavemode, DateTime fromdate, DateTime todate, DateTime fromtime, DateTime totime, DateTime hdate, bool half, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_applyod";
            cm.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = empcode;
            cm.Parameters.Add("@working_hour", SqlDbType.Decimal).Value = working_hour;
            cm.Parameters.Add("@reason", SqlDbType.VarChar, 500).Value = reason;
            cm.Parameters.Add("@Approval_status", SqlDbType.Int).Value = Approval_status;
            cm.Parameters.Add("@Leave_status", SqlDbType.Int).Value = Leave_status;
            cm.Parameters.Add("@flag", SqlDbType.Bit).Value = flag;
            cm.Parameters.Add("@status", SqlDbType.Bit).Value = status;
            cm.Parameters.Add("@createdby", SqlDbType.VarChar, 100).Value = createdby;
            cm.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate;
            cm.Parameters.Add("@comment", SqlDbType.VarChar, 500).Value = comment;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            cm.Parameters.Add("@leavemode", SqlDbType.Int).Value = leavemode;
            cm.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
            cm.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
            cm.Parameters.Add("@fromtime", SqlDbType.DateTime).Value = fromtime;
            cm.Parameters.Add("@totime", SqlDbType.DateTime, 100).Value = totime;
            cm.Parameters.Add("@hdate", SqlDbType.DateTime).Value = hdate;
            cm.Parameters.Add("@half", SqlDbType.Bit).Value = half;

            j =Convert.ToInt32( cm.ExecuteScalar());
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }
    }

    /********************** Created Date:23/6/09 Created By: Anshul Verma *******************************************/
    /********************** Code to edit applied OD ********************************/

    public void update_od(int id, string empcode, DateTime date, DateTime fromtime, decimal working_hour, string reason, int Approval_status, int Leave_status, bool flag, bool status, DateTime modifieddate, string modifiedby, string comment, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_updateod";
            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cm.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = empcode;
            cm.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            cm.Parameters.Add("@fromtime", SqlDbType.DateTime).Value = fromtime;
            cm.Parameters.Add("@working_hour", SqlDbType.Decimal).Value = working_hour;
            cm.Parameters.Add("@reason", SqlDbType.VarChar, 500).Value = reason;
            cm.Parameters.Add("@Approval_status", SqlDbType.Int).Value = Approval_status;
            cm.Parameters.Add("@Leave_status", SqlDbType.Int).Value = Leave_status;
            cm.Parameters.Add("@flag", SqlDbType.Bit).Value = flag;
            cm.Parameters.Add("@status", SqlDbType.Bit).Value = status;
            cm.Parameters.Add("@comment", SqlDbType.VarChar, 500).Value = comment;
            cm.Parameters.Add("@modifieddate", SqlDbType.DateTime).Value = modifieddate;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }
    }


    /************************************* Update Holiday Master **********************************/
    /********************** Created Date: 26/05/09 Created By: Disha Mittal ***********************/

    public void update_holiday_master(int holidayid, string year, int branch_id, string name, string detail, DateTime date, string modifiedby, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_updateholiday";
            cm.Parameters.Add("@holidayid", SqlDbType.Int).Value = holidayid;
            cm.Parameters.Add("@year", SqlDbType.VarChar, 10).Value = year;
            cm.Parameters.Add("@branch_id", SqlDbType.Int).Value = branch_id;
            cm.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = name;
            cm.Parameters.Add("@detail", SqlDbType.VarChar, 100).Value = detail;
            cm.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }
    }

    /**************************** Create Shift Master ***********************************/
    /**************************** Created Date: 26/5/09 Created By: Anshul Verma  **********************************/
    public void create_shift_master(string shiftname, int branch_id, string starttime, string endtime, string shift_description, string createdby, DateTime createddate, string modifiedby, bool nightallowance, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_createshift";
            cm.Parameters.Add("@shiftname", SqlDbType.VarChar, 100).Value = shiftname;
            cm.Parameters.Add("@branch_id", SqlDbType.Int).Value = branch_id;
            cm.Parameters.Add("@starttime", SqlDbType.VarChar, 10).Value = starttime;
            cm.Parameters.Add("@endtime", SqlDbType.VarChar, 10).Value = endtime;
            cm.Parameters.Add("@createdby", SqlDbType.VarChar, 100).Value = createdby;
            cm.Parameters.Add("@createddate", SqlDbType.DateTime).Value = Utility.dataformat(createddate.ToString("MM/dd/yyyy"));
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            cm.Parameters.Add("@shift_description", SqlDbType.VarChar, 200).Value = shift_description;
            cm.Parameters.Add("@nightshift", SqlDbType.Bit).Value = nightallowance;

            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }


    }

    //***************** Code to update shift ************************************//
    //***************** Created date: 26/5/09 Created by: Anshul Verma***********//

    public void update_shift_master(int shiftid, string shiftname, int branch_id, DateTime starttime, DateTime endtime, string shift_description, string modifiedby, bool nightallowance, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_updateshift";
            cm.Parameters.Add("@shiftid", SqlDbType.Int).Value = shiftid;
            cm.Parameters.Add("@shiftname", SqlDbType.VarChar, 100).Value = shiftname;
            cm.Parameters.Add("@branch_id", SqlDbType.Int).Value = branch_id;
            cm.Parameters.Add("@starttime", SqlDbType.DateTime, 10).Value = starttime;
            cm.Parameters.Add("@endtime", SqlDbType.DateTime, 10).Value = endtime;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            cm.Parameters.Add("@shift_description", SqlDbType.VarChar, 200).Value = shift_description;
            cm.Parameters.Add("@nightshift", SqlDbType.Bit).Value = nightallowance;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }
    }



    //  //***************** Code to create Approver Hierarchy ************************************//
    //  //***************** Created date: 27/5/09 Created by: Anshul Verma***********//

    //  public void create_hierarchy_master(string approvername, string approverpriority, ref int j)
    //  {
    //      try
    //      {
    //          cm.Connection = cn;
    //          cm.Connection.Open();
    //          cm.CommandType = CommandType.StoredProcedure;
    //          cm.CommandText = "sp_leave_createhierarchy";

    //          cm.Parameters.Add("@approvername", SqlDbType.VarChar, 100).Value = approvername;
    //          cm.Parameters.Add("@approverpriority", SqlDbType.Int).Value= Convert.ToInt32( approverpriority);
    //          j = cm.ExecuteNonQuery();
    //      }
    //      catch (SqlException sql)
    //      {
    //          string lbl_mgs = sql.Message;
    //      }
    //      finally
    //      {
    //          cm.Connection.Close();
    //          cm.Parameters.Clear();
    //      }
    //  }




    ////***************** Code to update Approver Hierarchy ************************************//
    //  //***************** Created date: 27/5/09 Created by: Anshul Verma***********//




    //  public void update_hierarchy_master(int approverid,string approvernameold, string approvername,int approverpriorityold, string approverpriority, ref int j)
    //  {
    //      try
    //      {
    //          cm.Connection = cn;
    //          cm.Connection.Open();
    //          cm.CommandType = CommandType.StoredProcedure;
    //          cm.CommandText = "sp_leave_updatehierarchy";
    //          cm.Parameters.Add("@approverid", SqlDbType.Int).Value = approverid;
    //          cm.Parameters.Add("@approvernameold", SqlDbType.VarChar, 100).Value = approvernameold;
    //          cm.Parameters.Add("@approvername", SqlDbType.VarChar, 100).Value = approvername;
    //          cm.Parameters.Add("@approverpriorityold", SqlDbType.Int).Value = Convert.ToInt32(approverpriorityold);
    //          cm.Parameters.Add("@approverpriority", SqlDbType.Int).Value = Convert.ToInt32(approverpriority);
    //          j = cm.ExecuteNonQuery();
    //      }
    //      catch (SqlException sql)
    //      {
    //          string lbl_mgs = sql.Message;
    //      }
    //      finally
    //      {
    //          cm.Connection.Close();
    //          cm.Parameters.Clear();
    //      }
    //  }




    //procedure is use to insert Module Master

    public bool Insert_modules_Master(string companyname, string establishmentdate, string registrationnumber, string companytype, string companyaddress1, string city1, string pincode1, string country1, string companyaddress2, string city2, string pincode2, string country2, string tannumber, string companyurl, string faxnumber1, string faxnumber2, string state1, string state2, string contactnumber1, string contactnumber2, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "checkcompanyname_sp";
            cm.Parameters.Add("@companyname", SqlDbType.VarChar, 50).Value = companyname;
            cm.Parameters.Add("@establishmentdate", SqlDbType.DateTime).Value = Convert.ToDateTime(establishmentdate);
            cm.Parameters.Add("@registrationnumber", SqlDbType.VarChar, 20).Value = registrationnumber;
            cm.Parameters.Add("@companytype", SqlDbType.VarChar, 50).Value = companytype;
            cm.Parameters.Add("@companyaddress1", SqlDbType.VarChar, 500).Value = companyaddress1;
            cm.Parameters.Add("@city1", SqlDbType.VarChar, 100).Value = city1;
            cm.Parameters.Add("@pincode1", SqlDbType.VarChar, 6).Value = pincode1;
            cm.Parameters.Add("@country1", SqlDbType.VarChar, 100).Value = country1;
            cm.Parameters.Add("@companyaddress2", SqlDbType.VarChar, 500).Value = companyaddress2;
            cm.Parameters.Add("@city2", SqlDbType.VarChar, 100).Value = city2;
            cm.Parameters.Add("@pincode2", SqlDbType.VarChar, 6).Value = pincode2;
            cm.Parameters.Add("@country2", SqlDbType.VarChar, 100).Value = country2;
            cm.Parameters.Add("@tannumber", SqlDbType.VarChar, 20).Value = tannumber;
            cm.Parameters.Add("@companyurl", SqlDbType.VarChar, 50).Value = companyurl;
            cm.Parameters.Add("@faxnumber1", SqlDbType.VarChar, 15).Value = faxnumber1;
            cm.Parameters.Add("@faxnumber2", SqlDbType.VarChar, 15).Value = faxnumber2;
            cm.Parameters.Add("@state1", SqlDbType.VarChar, 100).Value = state1;
            cm.Parameters.Add("@state2", SqlDbType.VarChar, 100).Value = state2;
            cm.Parameters.Add("@contactnumber1", SqlDbType.VarChar, 20).Value = contactnumber1;
            cm.Parameters.Add("@contactnumber2", SqlDbType.VarChar, 20).Value = contactnumber2;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }
        return true;
    }
    public bool Update_Company_Master(string companyid, string companyname, string establishmentdate, string registrationnumber, string companytype, string companyaddress1, string city1, string pincode1, string country1, string companyaddress2, string city2, string pincode2, string country2, string tannumber, string companyurl, string faxnumber1, string faxnumber2, string state1, string state2, string contactnumber1, string contactnumber2, ref int j)
    {
        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "edit_companymaster";
            cm.Parameters.Add("@companyid", SqlDbType.Int).Value = companyid;
            cm.Parameters.Add("@companyname", SqlDbType.VarChar, 50).Value = companyname;
            cm.Parameters.Add("@establishmentdate", SqlDbType.DateTime).Value = Convert.ToDateTime(establishmentdate);
            cm.Parameters.Add("@registrationnumber", SqlDbType.VarChar, 20).Value = registrationnumber;
            cm.Parameters.Add("@companytype", SqlDbType.VarChar, 50).Value = companytype;
            cm.Parameters.Add("@companyaddress1", SqlDbType.VarChar, 500).Value = companyaddress1;
            cm.Parameters.Add("@city1", SqlDbType.VarChar, 100).Value = city1;
            cm.Parameters.Add("@pincode1", SqlDbType.VarChar, 6).Value = pincode1;
            cm.Parameters.Add("@country1", SqlDbType.VarChar, 100).Value = country1;
            cm.Parameters.Add("@companyaddress2", SqlDbType.VarChar, 500).Value = companyaddress2;
            cm.Parameters.Add("@city2", SqlDbType.VarChar, 100).Value = city2;
            cm.Parameters.Add("@pincode2", SqlDbType.VarChar, 6).Value = pincode2;
            cm.Parameters.Add("@country2", SqlDbType.VarChar, 100).Value = country2;
            cm.Parameters.Add("@tannumber", SqlDbType.VarChar, 20).Value = tannumber;
            cm.Parameters.Add("@companyurl", SqlDbType.VarChar, 50).Value = companyurl;
            cm.Parameters.Add("@faxnumber1", SqlDbType.VarChar, 15).Value = faxnumber1;
            cm.Parameters.Add("@faxnumber2", SqlDbType.VarChar, 15).Value = faxnumber2;
            cm.Parameters.Add("@state1", SqlDbType.VarChar, 100).Value = state1;
            cm.Parameters.Add("@state2", SqlDbType.VarChar, 100).Value = state2;
            cm.Parameters.Add("@contactnumber1", SqlDbType.VarChar, 15).Value = contactnumber1;
            cm.Parameters.Add("@contactnumber2", SqlDbType.VarChar, 15).Value = contactnumber2;
            j = cm.ExecuteNonQuery();
        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }

        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }
        return true;
    }




    public void Insert_Branch_Master(string companyid, string companyname, string branchname, string establishmentdate, string branchcode, string branchtype, string branchaddress, string city, string pincode, string country, string faxnumber, string state, string contactnumber, string branchextnumber, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[14];

        sqlParam[0] = new SqlParameter("@companyid", SqlDbType.Int);
        sqlParam[0].Value = companyid;

        sqlParam[1] = new SqlParameter("@companyname", SqlDbType.VarChar, 50);
        sqlParam[1].Value = companyname;

        sqlParam[2] = new SqlParameter("@branchname", SqlDbType.VarChar, 50);
        sqlParam[2].Value = branchname;

        sqlParam[3] = new SqlParameter("@establishmentdate", SqlDbType.DateTime);
        sqlParam[3].Value = Convert.ToDateTime(establishmentdate);

        sqlParam[4] = new SqlParameter("@branchcode", SqlDbType.VarChar, 20);
        sqlParam[4].Value = branchcode;

        sqlParam[5] = new SqlParameter("@branchtype", SqlDbType.VarChar, 50);
        sqlParam[5].Value = branchtype;

        sqlParam[6] = new SqlParameter("@branchaddress", SqlDbType.VarChar, 500);
        sqlParam[6].Value = branchaddress;

        sqlParam[7] = new SqlParameter("@city", SqlDbType.VarChar, 100);
        sqlParam[7].Value = city;

        sqlParam[8] = new SqlParameter("@pincode", SqlDbType.VarChar, 6);
        sqlParam[8].Value = pincode;

        sqlParam[9] = new SqlParameter("@country", SqlDbType.VarChar, 100);
        sqlParam[9].Value = country;

        sqlParam[10] = new SqlParameter("@faxnumber", SqlDbType.VarChar, 15);
        sqlParam[10].Value = faxnumber;

        sqlParam[11] = new SqlParameter("@state", SqlDbType.VarChar, 100);
        sqlParam[11].Value = state;

        sqlParam[12] = new SqlParameter("@contactnumber", SqlDbType.VarChar, 15);
        sqlParam[12].Value = contactnumber;

        sqlParam[13] = new SqlParameter("@branchextnumber", SqlDbType.VarChar, 15);
        sqlParam[13].Value = branchextnumber;


        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_createbranch", sqlParam);

    }



    //===========CREATING GRADE OF COMPANY========================================================================================
    public int Insert_Grade(string gradename, string description, string createdby, DateTime dateofcreation, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[4];

        sqlParam[0] = new SqlParameter("@gradename", SqlDbType.VarChar, 50);
        sqlParam[0].Value = gradename;

        sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlParam[1].Value = description;

        sqlParam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[2].Value = createdby;

        sqlParam[3] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlParam[3].Value = dateofcreation;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_assigngrade", sqlParam);

        return j;
    }

    //==================CREATING DEPARTMENT OF COMPANY===================================================
    public int Insert_Department(string company, string branch, string departmentname, string departmentcode, DateTime estabishmentdate, string departmenthead, string departmentlocation, string contactnumber, string extensionnumber, string faxnumber, string companyid, string branchid, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[12];

        sqlParam[0] = new SqlParameter("@companyname", SqlDbType.VarChar, 50);
        sqlParam[0].Value = company;

        sqlParam[1] = new SqlParameter("@branchname", SqlDbType.VarChar, 50);
        sqlParam[1].Value = branch;

        sqlParam[2] = new SqlParameter("@departmentname", SqlDbType.VarChar, 50);
        sqlParam[2].Value = departmentname;

        sqlParam[3] = new SqlParameter("@departmentid", SqlDbType.VarChar, 50);
        sqlParam[3].Value = departmentcode;

        sqlParam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlParam[4].Value = estabishmentdate;

        sqlParam[5] = new SqlParameter("@departmenthead", SqlDbType.VarChar, 50);
        sqlParam[5].Value = departmenthead;

        sqlParam[6] = new SqlParameter("@location", SqlDbType.VarChar, 50);
        sqlParam[6].Value = departmentlocation;

        sqlParam[7] = new SqlParameter("@contactnumber", SqlDbType.VarChar, 50);
        sqlParam[7].Value = contactnumber;

        sqlParam[8] = new SqlParameter("@extnumber", SqlDbType.VarChar, 50);
        sqlParam[8].Value = extensionnumber;

        sqlParam[9] = new SqlParameter("@faxnumber", SqlDbType.VarChar, 50);
        sqlParam[9].Value = faxnumber;

        sqlParam[10] = new SqlParameter("@companyid", SqlDbType.VarChar, 50);
        sqlParam[10].Value = companyid;

        sqlParam[11] = new SqlParameter("@branchid", SqlDbType.VarChar, 50);
        sqlParam[11].Value = branchid;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_department", sqlParam);

        return j;
    }



    //==================CREATING DEPARTMENT OF COMPANY===================================================
    public int Insert_Designation(string designation, string description, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[2];

        sqlParam[0] = new SqlParameter("@designationname", SqlDbType.VarChar, 50);
        sqlParam[0].Value = designation;

        sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 50);
        sqlParam[1].Value = description;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_designation", sqlParam);

        return j;
    }

    //==================CREATING CONTACT DETAILS OF EMPLOYEE===================================================
    public int Insert_ContactDetails(string empid, string paddress, string pcity, string pstate, string pzip, string pphone, string pextension, string pmobile, string peraddress, string percity, string perstate, string perzip, string perphone, string perextension, string permobile, ref int j)
    {
        SqlParameter[] sqlParam = new SqlParameter[15];

        sqlParam[0] = new SqlParameter("@empid", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empid;

        sqlParam[1] = new SqlParameter("@paddress", SqlDbType.VarChar, 150);
        sqlParam[1].Value = paddress;

        sqlParam[2] = new SqlParameter("@pcity", SqlDbType.VarChar, 50);
        sqlParam[2].Value = pcity;

        sqlParam[3] = new SqlParameter("@pstate", SqlDbType.VarChar, 50);
        sqlParam[3].Value = pstate;

        sqlParam[4] = new SqlParameter("@pzip", SqlDbType.VarChar, 50);
        sqlParam[4].Value = pzip;

        sqlParam[5] = new SqlParameter("@pphone", SqlDbType.VarChar, 50);
        sqlParam[5].Value = pphone;

        sqlParam[6] = new SqlParameter("@pextension", SqlDbType.VarChar, 50);
        sqlParam[6].Value = pextension;

        sqlParam[7] = new SqlParameter("@pmobile", SqlDbType.VarChar, 50);
        sqlParam[7].Value = pmobile;

        sqlParam[8] = new SqlParameter("@peraddress", SqlDbType.VarChar, 150);
        sqlParam[8].Value = peraddress;

        sqlParam[9] = new SqlParameter("@percity", SqlDbType.VarChar, 50);
        sqlParam[9].Value = percity;

        sqlParam[10] = new SqlParameter("@perstate", SqlDbType.VarChar, 50);
        sqlParam[10].Value = perstate;

        sqlParam[11] = new SqlParameter("@perzip", SqlDbType.VarChar, 50);
        sqlParam[11].Value = perzip;

        sqlParam[12] = new SqlParameter("@perphone", SqlDbType.VarChar, 50);
        sqlParam[12].Value = perphone;

        sqlParam[13] = new SqlParameter("@perextension", SqlDbType.VarChar, 50);
        sqlParam[13].Value = perextension;

        sqlParam[14] = new SqlParameter("@permobile", SqlDbType.VarChar, 50);
        sqlParam[14].Value = permobile;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_contactdetails]", sqlParam);

        return j;
    }



    //==================CREATING PERSONAL DETAILS OF EMPLOYEE===================================================
    public int Insert_PersonalDetails(string empid, string perfthname, string permthname, string perheight, string perwt, string percomplextion, string perbloodgrp, string permaritalstatus, string perreligion, DateTime perdoa, string perdrivinglicence, string perhandicap, string perphotofilename, string persignaturefilename, string perpersonalfilename, string spfirstname, string splastname, string spmiddlename, DateTime spdob, string spgender, string spaddress, string spcity, string spstate, string spzip, string spnoofchild, ref int j)
    {
        SqlParameter[] sqlParam = new SqlParameter[25];

        sqlParam[0] = new SqlParameter("@empid", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empid;

        sqlParam[1] = new SqlParameter("@perfthname", SqlDbType.VarChar, 150);
        sqlParam[1].Value = perfthname;

        sqlParam[2] = new SqlParameter("@permthname", SqlDbType.VarChar, 50);
        sqlParam[2].Value = permthname;

        sqlParam[3] = new SqlParameter("@perheight", SqlDbType.VarChar, 50);
        sqlParam[3].Value = perheight;

        sqlParam[4] = new SqlParameter("@perwt", SqlDbType.VarChar, 50);
        sqlParam[4].Value = perwt;

        sqlParam[5] = new SqlParameter("@percomplextion", SqlDbType.VarChar, 50);
        sqlParam[5].Value = percomplextion;

        sqlParam[6] = new SqlParameter("@perbloodgrp", SqlDbType.VarChar, 50);
        sqlParam[6].Value = perbloodgrp;

        sqlParam[7] = new SqlParameter("@permaritalstatus", SqlDbType.VarChar, 50);
        sqlParam[7].Value = permaritalstatus;

        sqlParam[8] = new SqlParameter("@perreligion", SqlDbType.VarChar, 150);
        sqlParam[8].Value = perreligion;

        sqlParam[9] = new SqlParameter("@perdoa", SqlDbType.DateTime);
        sqlParam[9].Value = perdoa;

        sqlParam[10] = new SqlParameter("@perdrivinglicence", SqlDbType.VarChar, 50);
        sqlParam[10].Value = perdrivinglicence;

        sqlParam[11] = new SqlParameter("@perhandicap", SqlDbType.VarChar, 50);
        sqlParam[11].Value = perhandicap;

        sqlParam[12] = new SqlParameter("@perphotofilename", SqlDbType.VarChar, 50);
        sqlParam[12].Value = perphotofilename;

        sqlParam[13] = new SqlParameter("@persignaturefilename", SqlDbType.VarChar, 50);
        sqlParam[13].Value = persignaturefilename;

        sqlParam[14] = new SqlParameter("@perpersonalfilename", SqlDbType.VarChar, 50);
        sqlParam[14].Value = perpersonalfilename;

        sqlParam[15] = new SqlParameter("@spfirstname", SqlDbType.VarChar, 50);
        sqlParam[15].Value = spfirstname;

        sqlParam[16] = new SqlParameter("@splastname", SqlDbType.VarChar, 50);
        sqlParam[16].Value = splastname;

        sqlParam[17] = new SqlParameter("@spmiddlename", SqlDbType.VarChar, 150);
        sqlParam[17].Value = spmiddlename;

        sqlParam[18] = new SqlParameter("@spdob", SqlDbType.DateTime);
        sqlParam[18].Value = spdob;

        sqlParam[19] = new SqlParameter("@spgender", SqlDbType.VarChar, 50);
        sqlParam[19].Value = spgender;

        sqlParam[20] = new SqlParameter("@spaddress", SqlDbType.VarChar, 50);
        sqlParam[20].Value = spaddress;

        sqlParam[21] = new SqlParameter("@spcity", SqlDbType.VarChar, 50);
        sqlParam[21].Value = spcity;

        sqlParam[22] = new SqlParameter("@spstate", SqlDbType.VarChar, 50);
        sqlParam[22].Value = spstate;

        sqlParam[23] = new SqlParameter("@spzip", SqlDbType.VarChar, 50);
        sqlParam[23].Value = spzip;

        sqlParam[24] = new SqlParameter("@spnoofchild", SqlDbType.VarChar, 50);
        sqlParam[24].Value = spnoofchild;


        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_personaldetails]", sqlParam);

        return j;
    }

    //==================UPDATING DEPARTMENT OF COMPANY===================================================
    public int Update_Department(string company, string branch, string departmentname, string departmentcode, DateTime estabishmentdate, string departmenthead, string departmentlocation, string contactnumber, string extensionnumber, string faxnumber, string companyid, string branchid, int id, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[15];

        sqlParam[0] = new SqlParameter("@companyname", SqlDbType.VarChar, 50);
        sqlParam[0].Value = company;

        sqlParam[1] = new SqlParameter("@branchname", SqlDbType.VarChar, 50);
        sqlParam[1].Value = branch;

        sqlParam[2] = new SqlParameter("@departmentname", SqlDbType.VarChar, 50);
        sqlParam[2].Value = departmentname;

        sqlParam[3] = new SqlParameter("@departmentid", SqlDbType.VarChar, 50);
        sqlParam[3].Value = departmentcode;

        sqlParam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlParam[4].Value = estabishmentdate;

        sqlParam[5] = new SqlParameter("@departmenthead", SqlDbType.VarChar, 50);
        sqlParam[5].Value = departmenthead;

        sqlParam[6] = new SqlParameter("@location", SqlDbType.VarChar, 50);
        sqlParam[6].Value = departmentlocation;

        sqlParam[7] = new SqlParameter("@contactnumber", SqlDbType.VarChar, 50);
        sqlParam[7].Value = contactnumber;

        sqlParam[8] = new SqlParameter("@extnumber", SqlDbType.VarChar, 50);
        sqlParam[8].Value = extensionnumber;

        sqlParam[9] = new SqlParameter("@faxnumber", SqlDbType.VarChar, 50);
        sqlParam[9].Value = faxnumber;

        sqlParam[10] = new SqlParameter("@companyid", SqlDbType.VarChar, 50);
        sqlParam[10].Value = companyid;

        sqlParam[11] = new SqlParameter("@branchid", SqlDbType.VarChar, 50);
        sqlParam[11].Value = branchid;

        sqlParam[12] = new SqlParameter("@id", SqlDbType.VarChar, 50);
        sqlParam[12].Value = id;


        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_update_department", sqlParam);

        return j;
    }


    //==================CREATING JOB DETAILS OF EMPLOYEE===================================================
    public int Insert_JobDetails(string empid, DateTime doj, int probationperiod, DateTime doconfirmation, string status, string grade, string usertype, string recruiter, string convenceallowed, string pfmedicalallowed, string department, string location, string phoneno, string extension, string mobileno, ref int j)
    {
        SqlParameter[] sqlParam = new SqlParameter[15];

        sqlParam[0] = new SqlParameter("@empid", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empid;

        sqlParam[1] = new SqlParameter("@doj", SqlDbType.DateTime);
        sqlParam[1].Value = doj;

        sqlParam[2] = new SqlParameter("@probationperiod", SqlDbType.Int);
        sqlParam[2].Value = probationperiod;

        sqlParam[3] = new SqlParameter("@doconfirmation", SqlDbType.DateTime);
        sqlParam[3].Value = doconfirmation;

        sqlParam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlParam[4].Value = status;

        sqlParam[5] = new SqlParameter("@grade", SqlDbType.VarChar, 50);
        sqlParam[5].Value = grade;

        sqlParam[6] = new SqlParameter("@usertype", SqlDbType.VarChar, 50);
        sqlParam[6].Value = usertype;

        sqlParam[7] = new SqlParameter("@recruiter", SqlDbType.VarChar, 50);
        sqlParam[7].Value = recruiter;

        sqlParam[8] = new SqlParameter("@convenceallowed", SqlDbType.VarChar, 150);
        sqlParam[8].Value = convenceallowed;

        sqlParam[9] = new SqlParameter("@pfmedicalallowed", SqlDbType.VarChar, 50);
        sqlParam[9].Value = pfmedicalallowed;

        sqlParam[10] = new SqlParameter("@department", SqlDbType.VarChar, 50);
        sqlParam[10].Value = department;

        sqlParam[11] = new SqlParameter("@location", SqlDbType.VarChar, 50);
        sqlParam[11].Value = location;

        sqlParam[12] = new SqlParameter("@phoneno", SqlDbType.VarChar, 50);
        sqlParam[12].Value = phoneno;

        sqlParam[13] = new SqlParameter("@extension", SqlDbType.VarChar, 50);
        sqlParam[13].Value = extension;

        sqlParam[14] = new SqlParameter("@mobileno", SqlDbType.VarChar, 50);
        sqlParam[14].Value = mobileno;


        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_jobdetails]", sqlParam);

        return j;
    }

    //===========CREATING EDUCATION========================================================================================
    public int Insert_education_professionaldetails(string empid, string matricschool, string matricper, string matricfrom, string matricto, string matric, string highschooledu, string highschoolper, string highschoolfrom, string highschoolto, string highschool, string graduationedu, string graduationper, string graduationfrom, string graduationto, string graduation, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[16];

        sqlParam[0] = new SqlParameter("@empid", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empid;

        //Matric
        sqlParam[1] = new SqlParameter("@matriceducation", SqlDbType.VarChar, 500);
        sqlParam[1].Value = matric;

        sqlParam[2] = new SqlParameter("@matricschool_institute_university", SqlDbType.VarChar, 50);
        sqlParam[2].Value = matricschool;

        sqlParam[3] = new SqlParameter("@matricpercentage", SqlDbType.VarChar, 50);
        sqlParam[3].Value = matricper;

        sqlParam[4] = new SqlParameter("@matricyearfrom", SqlDbType.VarChar, 50);
        sqlParam[4].Value = matricfrom;

        sqlParam[5] = new SqlParameter("@matricyearto", SqlDbType.VarChar, 50);
        sqlParam[5].Value = matricto;

        //High School
        sqlParam[6] = new SqlParameter("@highschooleducation", SqlDbType.VarChar, 500);
        sqlParam[6].Value = highschool;

        sqlParam[7] = new SqlParameter("@highschoolschool_institute_university", SqlDbType.VarChar, 50);
        sqlParam[7].Value = highschooledu;

        sqlParam[8] = new SqlParameter("@highschoolpercentage", SqlDbType.VarChar, 50);
        sqlParam[8].Value = highschoolper;

        sqlParam[9] = new SqlParameter("@highschoolyearfrom", SqlDbType.VarChar, 50);
        sqlParam[9].Value = highschoolfrom;

        sqlParam[10] = new SqlParameter("@highschoolyearto", SqlDbType.VarChar, 50);
        sqlParam[10].Value = highschoolto;

        //Graduation
        sqlParam[11] = new SqlParameter("@graduationeducation", SqlDbType.VarChar, 500);
        sqlParam[11].Value = graduation;

        sqlParam[12] = new SqlParameter("@graduationschool_institute_university", SqlDbType.VarChar, 50);
        sqlParam[12].Value = graduationedu;

        sqlParam[13] = new SqlParameter("@graduationpercentage", SqlDbType.VarChar, 50);
        sqlParam[13].Value = graduationper;

        sqlParam[14] = new SqlParameter("@graduationyearfrom", SqlDbType.VarChar, 50);
        sqlParam[14].Value = graduationfrom;

        sqlParam[15] = new SqlParameter("@graduationyearto", SqlDbType.VarChar, 50);
        sqlParam[15].Value = graduationto;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_employee_insert_educationqualification]", sqlParam);

        return j;
    }

    //===========CREATING PROFESSIONAL QUALIFICATION========================================================================================
    public int Insert_professional_professionaldetails(string empid, string education1, string institute1, string percentage1, string from1, string to1, string education2, string institute2, string percentage2, string from2, string to2, string education3, string institute3, string percentage3, string from3, string to3, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[16];

        sqlParam[0] = new SqlParameter("@empid", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empid;

        sqlParam[1] = new SqlParameter("@education1", SqlDbType.VarChar, 500);
        sqlParam[1].Value = education1;

        sqlParam[2] = new SqlParameter("@institute1", SqlDbType.VarChar, 50);
        sqlParam[2].Value = institute1;

        sqlParam[3] = new SqlParameter("@percentage1", SqlDbType.VarChar, 50);
        sqlParam[3].Value = percentage1;

        sqlParam[4] = new SqlParameter("@from1", SqlDbType.VarChar, 50);
        sqlParam[4].Value = from1;

        sqlParam[5] = new SqlParameter("@to1", SqlDbType.VarChar, 50);
        sqlParam[5].Value = to1;

        sqlParam[6] = new SqlParameter("@education2", SqlDbType.VarChar, 500);
        sqlParam[6].Value = education2;

        sqlParam[7] = new SqlParameter("@institute2", SqlDbType.VarChar, 50);
        sqlParam[7].Value = institute2;

        sqlParam[8] = new SqlParameter("@percentage2", SqlDbType.VarChar, 50);
        sqlParam[8].Value = percentage2;

        sqlParam[9] = new SqlParameter("@from2", SqlDbType.VarChar, 50);
        sqlParam[9].Value = from2;

        sqlParam[10] = new SqlParameter("@to2", SqlDbType.VarChar, 50);
        sqlParam[10].Value = to2;

        sqlParam[11] = new SqlParameter("@education3", SqlDbType.VarChar, 500);
        sqlParam[11].Value = education3;

        sqlParam[12] = new SqlParameter("@institute3", SqlDbType.VarChar, 50);
        sqlParam[12].Value = institute3;

        sqlParam[13] = new SqlParameter("@percentage3", SqlDbType.VarChar, 50);
        sqlParam[13].Value = percentage3;

        sqlParam[14] = new SqlParameter("@from3", SqlDbType.VarChar, 50);
        sqlParam[14].Value = from3;

        sqlParam[15] = new SqlParameter("@to3", SqlDbType.VarChar, 50);
        sqlParam[15].Value = to3;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_employee_insert_professionalqualification]", sqlParam);

        return j;
    }


    //===========CREATING EXPERIENCE DETAILS========================================================================================
    public int Insert_experience_professionaldetails(string empid, string company, string totalexp1, string from1, string to1, string company2, string totalexp2, string from2, string to2, string company3, string totalexp3, string from3, string to3, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[13];

        sqlParam[0] = new SqlParameter("@empid", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empid;

        sqlParam[1] = new SqlParameter("@company", SqlDbType.VarChar, 500);
        sqlParam[1].Value = company;

        sqlParam[2] = new SqlParameter("@totalexp1", SqlDbType.VarChar, 50);
        sqlParam[2].Value = totalexp1;

        sqlParam[3] = new SqlParameter("@from1", SqlDbType.VarChar, 50);
        sqlParam[3].Value = from1;

        sqlParam[4] = new SqlParameter("@to1", SqlDbType.VarChar, 50);
        sqlParam[4].Value = to1;

        sqlParam[5] = new SqlParameter("@company2", SqlDbType.VarChar, 500);
        sqlParam[5].Value = company2;

        sqlParam[6] = new SqlParameter("@totalexp2", SqlDbType.VarChar, 50);
        sqlParam[6].Value = totalexp2;

        sqlParam[7] = new SqlParameter("@from2", SqlDbType.VarChar, 50);
        sqlParam[7].Value = from2;

        sqlParam[8] = new SqlParameter("@to2", SqlDbType.VarChar, 50);
        sqlParam[8].Value = to2;

        sqlParam[9] = new SqlParameter("@company3", SqlDbType.VarChar, 500);
        sqlParam[9].Value = company3;

        sqlParam[10] = new SqlParameter("@totalexp3", SqlDbType.VarChar, 50);
        sqlParam[10].Value = totalexp3;

        sqlParam[11] = new SqlParameter("@from3", SqlDbType.VarChar, 50);
        sqlParam[11].Value = from3;

        sqlParam[12] = new SqlParameter("@to3", SqlDbType.VarChar, 50);
        sqlParam[12].Value = to3;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_employee_insert_experiencedetails]", sqlParam);

        return j;
    }

    //===========CREATING ROLE OF COMPANY========================================================================================
    public int Insert_Role(string rolename, string description, string createdby, DateTime dateofcreation, ref int j)
    {

        SqlParameter[] sqlParam = new SqlParameter[4];

        sqlParam[0] = new SqlParameter("@rolename", SqlDbType.VarChar, 50);
        sqlParam[0].Value = rolename;

        sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlParam[1].Value = description;

        sqlParam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[2].Value = createdby;

        sqlParam[3] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlParam[3].Value = dateofcreation;

        j = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_assignrole", sqlParam);

        return j;
    }



    //***************** Code to create default rule ************************************//
    //***************** Created date: 1/6/09 Created by: Anshul Verma***********//


    public void create_default_rule_master(int leaveid, int policyid, decimal entitled_days, int days_before_leaveapply, int minimum_no_days, int maximum_no_days, bool document_required, bool backdate_leave_applicable, int backdate_howmany_days, bool holidays_counted_asleave, bool weekly_off, bool carryforward_applicable, decimal carryforward_maximum_days, decimal accumulation_days, bool modification_leave, DateTime createddate, string createdby, string modifiedby, bool halfday_leave_applicable, string gender, bool Entitled_checked, int doc_excessdays, bool workingdayschecked, int workingingdays, string metarialstatus,  ref int j)
    {

        try
        {
            cm.Connection = cn;
            cm.Connection.Open();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "sp_leave_createdefaultrule";
            cm.Parameters.Add("@leaveid", SqlDbType.Int).Value = leaveid;
            cm.Parameters.Add("@policyid", SqlDbType.Int).Value = policyid;
            cm.Parameters.Add("@entitled_days", SqlDbType.Decimal).Value = entitled_days;
            cm.Parameters.Add("@days_before_leaveapply", SqlDbType.Int).Value = days_before_leaveapply;
            cm.Parameters.Add("@minimum_no_days", SqlDbType.Int).Value = minimum_no_days;
            cm.Parameters.Add("@maximum_no_days", SqlDbType.Int).Value = maximum_no_days;
            cm.Parameters.Add("@document_required", SqlDbType.Bit).Value = document_required;
            cm.Parameters.Add("@backdate_leave_applicable", SqlDbType.Bit).Value = backdate_leave_applicable;
            cm.Parameters.Add("@backdate_howmany_days", SqlDbType.Int).Value = backdate_howmany_days;
            cm.Parameters.Add("@holidays_counted_asleave", SqlDbType.Bit).Value = holidays_counted_asleave;
            cm.Parameters.Add("@weekly_off", SqlDbType.Bit).Value = weekly_off;
            cm.Parameters.Add("@carryforward_applicable", SqlDbType.Bit).Value = carryforward_applicable;
            cm.Parameters.Add("@carryforward_maximum_days", SqlDbType.Decimal).Value = carryforward_maximum_days;
            cm.Parameters.Add("@accumulated_days", SqlDbType.Decimal).Value = accumulation_days;
            cm.Parameters.Add("@leave_modification", SqlDbType.Bit).Value = modification_leave;
            cm.Parameters.Add("@createddate", SqlDbType.DateTime).Value = createddate;
            cm.Parameters.Add("@createdby", SqlDbType.VarChar, 100).Value = createdby;
            cm.Parameters.Add("@modifiedby", SqlDbType.VarChar, 100).Value = modifiedby;
            cm.Parameters.Add("@halfday_leave_applicable", SqlDbType.Bit).Value = halfday_leave_applicable;
            cm.Parameters.Add("@applicable_to", SqlDbType.VarChar, 1).Value = gender;
            cm.Parameters.Add("@entitle_applicable", SqlDbType.Bit).Value = Entitled_checked;
            cm.Parameters.Add("@document_days", SqlDbType.Int).Value = doc_excessdays;
            cm.Parameters.Add("@isworking_days", SqlDbType.Bit).Value = workingdayschecked;
            cm.Parameters.Add("@working_days", SqlDbType.Int).Value = workingingdays;
            cm.Parameters.Add("@applicable_to_marital", SqlDbType.VarChar, 1).Value = metarialstatus;
           // cm.Parameters.Add("@applicable_emp_status", SqlDbType.VarChar, 100).Value = empstatus;

            j = cm.ExecuteNonQuery();


        }
        catch (SqlException sql)
        {
            string lbl_mgs = sql.Message;
        }
        finally
        {
            cm.Connection.Close();
            cm.Parameters.Clear();
        }


    }








}
