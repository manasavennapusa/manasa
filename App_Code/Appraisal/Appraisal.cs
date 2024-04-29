using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;

namespace Approvers.Appraisal
{
    public class Approvers
    {
        IBase Lib = null;

        public Approvers()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataRow GetEmployeeInfo(string empcode)
        {
            var activity = new DataActivity();
            string Query = "";

            Query = @"select 
J.empcode,
J.emp_fname + ' ' + isnull(J.emp_m_name,'') + ' ' + isnull(J.emp_l_name,'') as name,
J.official_email_id
 from tbl_intranet_employee_jobDetails J 
   where J.empcode = '" + empcode + "'";

            SqlConnection connection = activity.OpenConnection();
            Lib = new Base();
            DataSet ds = Lib.Bee.WGetData(Query);
            return ds.Tables[0].Rows[0];
        }

        public DataRow GetApprovers(string empCode, int appraisalId)
        {
            var activity = new DataActivity();
            string Query = "";

            Query = @"select 
E.appcycle_id,
E.empcode,
E.emp_fname,
E.official_email_id,
RM.app_reportingmanager,
RM.emp_fname rmname,
RM.official_email_id rmemailid,
BH.app_businesshead,
BH.emp_fname bhname,
BH.official_email_id bhemailid,
HR.app_hr,
HR.emp_fname hrname,
HR.official_email_id hremailid,
MNG.app_management,
MNG.emp_fname mngname,
MNG.official_email_id mngemailid,
HRD.app_hrd,
HRD.emp_fname hrdname,
HRD.official_email_id hrdemailid
from
(
select 
A.appcycle_id,
A.empcode,
J.emp_fname,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.empcode = J.empcode

) E
left join
( 
select 
A.appcycle_id,
A.empcode,
A.app_reportingmanager,
J.emp_fname ,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_reportingmanager = J.empcode

) RM on E.appcycle_id = RM.appcycle_id and E.empcode = RM.empcode
left join
(
select 
A.appcycle_id,
A.empcode,
A.app_businesshead,
J.emp_fname,
J.official_email_id  
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_businesshead = J.empcode

) BH on E.appcycle_id = BH.appcycle_id and E.empcode = BH.empcode
left join
(
select 
A.appcycle_id,
A.empcode,
A.app_hr,
J.emp_fname,
J.official_email_id  
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_hr = J.empcode

) HR on E.appcycle_id = HR.appcycle_id and E.empcode = HR.empcode
left join
(
select 
A.appcycle_id,
A.empcode,
A.app_management,
J.emp_fname ,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_management = J.empcode

) MNG on E.appcycle_id = MNG.appcycle_id and E.empcode = MNG.empcode
left join
(
select
A.appcycle_id, 
A.empcode,
A.app_hrd,
J.emp_fname ,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_hrd = J.empcode

) HRD on E.appcycle_id = HRD.appcycle_id and E.empcode = HRD.empcode

where E.appcycle_id = " + appraisalId + " and E.empcode = '" + empCode + "'";

            SqlConnection connection = activity.OpenConnection();
            Lib = new Base();
            DataSet ds = Lib.Bee.WGetData(Query);
            return ds.Tables[0].Rows[0];
        }

        public DataRow GetApprovers(int assessmentId)
        {
            var activity = new DataActivity();
            string Query = "";

            Query = @"select 
E.appcycle_id,
E.empcode,
E.emp_fname,
E.official_email_id,
RM.app_reportingmanager,
RM.emp_fname rmname,
RM.official_email_id rmemailid,
BH.app_businesshead,
BH.emp_fname bhname,
BH.official_email_id bhemailid,
HR.app_hr,
HR.emp_fname hrname,
HR.official_email_id hremailid,
MNG.app_management,
MNG.emp_fname mngname,
MNG.official_email_id mngemailid,
HRD.app_hrd,
HRD.emp_fname hrdname,
HRD.official_email_id hrdemailid
from
(
select 
AA.assessment_id,
A.appcycle_id,
A.empcode,
J.emp_fname,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.empcode = J.empcode
 inner join tbl_appraisal_assessment AA on AA.empcode = J.empcode

) E
left join
( 
select 
A.appcycle_id,
A.empcode,
A.app_reportingmanager,
J.emp_fname ,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_reportingmanager = J.empcode

) RM on E.appcycle_id = RM.appcycle_id and E.empcode = RM.empcode
left join
(
select 
A.appcycle_id,
A.empcode,
A.app_businesshead,
J.emp_fname,
J.official_email_id  
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_businesshead = J.empcode

) BH on E.appcycle_id = BH.appcycle_id and E.empcode = BH.empcode
left join
(
select 
A.appcycle_id,
A.empcode,
A.app_hr,
J.emp_fname,
J.official_email_id  
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_hr = J.empcode

) HR on E.appcycle_id = HR.appcycle_id and E.empcode = HR.empcode
left join
(
select 
A.appcycle_id,
A.empcode,
A.app_management,
J.emp_fname ,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_management = J.empcode

) MNG on E.appcycle_id = MNG.appcycle_id and E.empcode = MNG.empcode
left join
(
select
A.appcycle_id, 
A.empcode,
A.app_hrd,
J.emp_fname ,
J.official_email_id 
from tbl_appraisal_approvers A
 inner join tbl_intranet_employee_jobDetails J on A.app_hrd = J.empcode

) HRD on E.appcycle_id = HRD.appcycle_id and E.empcode = HRD.empcode

where E.assessment_id = " + assessmentId + "";

            SqlConnection connection = activity.OpenConnection();
            Lib = new Base();
            DataSet ds = Lib.Bee.WGetData(Query);
            return ds.Tables[0].Rows[0];
        }

       
    }
}