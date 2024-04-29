using System.Data;
using System.Data.SqlClient;
using Smart.HR.Common.Console;
using Smart.HR.Common.Data;
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;

namespace Approvers.Travel
{
    public class Approvers
    {
        IBase Lib = null;

        public DataTable GetApprovers(int travelId, int level)
        {
            var activity = new DataActivity();
            string Query = "";

            if (level == 0)
                Query = @"select T.travelid,
F.accountcode,
T.approvercode,
J.emp_fname + ' ' + isnull(J.emp_m_name,'') + ' ' + isnull(J.emp_l_name,'') as name,
J.official_email_id
 from tbl_travel_travelformApproverStatus T
  inner join tbl_intranet_employee_jobDetails J on T.approvercode = J.empcode
  inner join tbl_travel_TravelForm F on T.travelid = F.travelid where T.travelid = " + travelId + "";
            else
                Query = @"select T.travelid,
F.accountcode,
T.approvercode,
J.emp_fname + ' ' + isnull(J.emp_m_name,'') + ' ' + isnull(J.emp_l_name,'') as name,
J.official_email_id
 from tbl_travel_travelformApproverStatus T
  inner join tbl_intranet_employee_jobDetails J on T.approvercode = J.empcode
  inner join tbl_travel_TravelForm F on T.travelid = F.travelid where T.travelid = " + travelId + " and T.approverlevel = " + level + "";

            SqlConnection connection = activity.OpenConnection();
            Lib = new Base();
            DataSet ds = Lib.Bee.WGetData(Query);


            return ds.Tables[0];
        }

        public DataRow TravelDetail(int travelId)
        {
            var activity = new DataActivity();
            string Query = "";

            Query = @"select * from tbl_travel_TravelForm where travelid = " + travelId + "";

            SqlConnection connection = activity.OpenConnection();
            Lib = new Base();
            DataSet ds = Lib.Bee.WGetData(Query);
            return ds.Tables[0].Rows[0];

        }

        public DataRow GetTravelEmployeeInfo(int travelId)
        {
            var activity = new DataActivity();
            string Query = "";

            Query = @"select 
F.empcode,
F.travelid,
F.accountcode,
J.emp_fname + ' ' + isnull(J.emp_m_name,'') + ' ' + isnull(J.emp_l_name,'') as name,
J.official_email_id
 from tbl_intranet_employee_jobDetails J 
  inner join tbl_travel_TravelForm F on J.empcode = F.empcode
   where F.travelid = " + travelId + "";

            SqlConnection connection = activity.OpenConnection();
            Lib = new Base();
            DataSet ds = Lib.Bee.WGetData(Query);


            return ds.Tables[0].Rows[0];
        }

    }
}
