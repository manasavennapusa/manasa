using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;

public partial class recruitment_r_rrfview : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    IBase Lib = null;
    string Query = "";
    string RRFId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
            RRFId = Request.QueryString["id"].Trim();
            if (!IsPostBack)
            {
                BindConfirmedDetails(RRFId);
                BindRejectedDetails(RRFId);
                BindProcessDetails(RRFId);
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindProcessDetails(string _rrfid)
    {
        Lib = new Base();

        Query = InProcessScript(_rrfid);
        Lib.Bee.WBindGrid(Query, grdprocess);
    }


    private string InProcessScript(string _rrfid)
    {
        // Written by Raghavendra for timebeing due to incomeplete nomalization and round 3 status not handing the database.

        return @"
CREATE TABLE #tbl_recruitment_candidate_registration(
	id int NULL,
	rrf_id int NULL,
	candidate_name varchar(100) NOT NULL,
	dob datetime NULL,
	candidate_address varchar(1000) NULL,
	phone varchar(15) NULL,
	mobile varchar(15) NULL,
	emailid varchar(50) NULL,
	Qualification varchar(50) NULL,
	skills varchar(1000) NULL,
	experience varchar(20) NULL,
	joinstatus int NULL,
	expectedsalary decimal(20, 2) NULL,
	referredby varchar(50) NULL,
	referrername varchar(50) NULL,
	achievements varchar(1000) NULL,
	uploadresume varchar(500) NULL,
	passportno varchar(50) NULL,
	passportvalidity datetime NULL,
	note varchar(1000) NULL,
	status bit NULL,
	relation_to_referrer varchar(50) NULL,
	reasons_of_referrence varchar(500) NULL,
	gender varchar(10) NULL,
	consultancy_id int NULL)

	

declare @cur cursor
declare @candidateid int
declare @rrfcode varchar(50)
declare @condition int

set @cur = cursor for
              select id,rrf_code
               from tbl_recruitment_requisition_form
                where status = 1
                
open @cur
fetch next from @cur into @candidateid,@rrfcode 

set @condition = 0
            
while @@FETCH_STATUS = 0
begin
  
  if exists (select 1 
              from tbl_recruitment_candidate_interview 
               where candidateid = @candidateid and round_1_status is null and round_2_status is null)
  begin
   print 'P1'
   set @condition = 1
  end
  
  else if exists (select 1 
                   from tbl_recruitment_candidate_interview 
                    where candidateid = @candidateid and round_1_status = 'S' and round_2_status is null)
  begin
   print 'P2'
   set @condition = 1
  end
  
  else if exists (select 1 
              from tbl_recruitment_candidate_interview 
               where candidateid = @candidateid and round_1_status = 'S' and round_2_status = 'S' and 
                ( select COUNT(*)
                    from tbl_recruitment_interviewrrating
                     where Candidate_id = @candidateid
                 ) = 0 )              
   begin
    print 'P3'
    set @condition = 1
   end
   
   else if exists (select 1 
              from tbl_recruitment_candidate_interview 
               where candidateid = @candidateid and round_1_status = 'S' and round_2_status = 'S' and 
                ( select COUNT(*)
                    from tbl_recruitment_interviewrrating
                     where Candidate_id = @candidateid and status = 'P'
                 ) > 0 )              
   begin
    print 'P4'
    set @condition = 1
   end 
   
   if @condition = 1
   begin
     insert into #tbl_recruitment_candidate_registration
      select *
       from tbl_recruitment_candidate_registration
        where id = @candidateid
   end
   
   
   set @condition = 0
   
fetch next from @cur into @candidateid,@rrfcode
 
end

close @cur
deallocate @cur

select * from #tbl_recruitment_candidate_registration where rrf_id = "+_rrfid+"; drop table #tbl_recruitment_candidate_registration;";

    }

    private void BindConfirmedDetails(string _rrfid)
    {
        Lib = new Base();

        Query = @"select distinct cr.rrf_id,cr.candidate_name,cr.dob,cr.mobile,cr.emailid,cr.phone,cr.Qualification,cr.skills,cr.experience,
cr.joinstatus,cr.expectedsalary,cr.rrf_id,ci.round_1_status,ci.round_1_marks,ci.round_2_status,ir.rrf_code,ir.Candidate_id,ir.status
from tbl_recruitment_candidate_registration cr 
inner join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid
inner join tbl_recruitment_interviewrrating ir on ci.candidateid=ir.Candidate_id
where ci.round_1_status='S' and ci.round_2_status='S' and ir.status='S' and cr.rrf_id = " + _rrfid + "";

        Lib.Bee.WBindGrid(Query, grdConfirmed);

    }

    private void BindRejectedDetails(string _rrfid)
    {
        Lib = new Base();

        Query = @"select distinct cr.rrf_id,cr.candidate_name,cr.dob,cr.mobile,cr.emailid,cr.phone,cr.Qualification,cr.skills,cr.experience,
cr.joinstatus,cr.expectedsalary,ci.round_1_status,ci.round_1_marks,ci.round_2_status,ir.rrf_code,ir.Candidate_id,ir.status
from tbl_recruitment_candidate_registration cr 
inner join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid
inner join tbl_recruitment_interviewrrating ir on cr.id=ir.Candidate_id
where ci.round_1_status='R' or ci.round_2_status='R' or ir.status='R' and cr.rrf_id = " + _rrfid + "";

        Lib.Bee.WBindGrid(Query, grdRejectedcandidates);

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewStatusByRRF_Raiser.aspx");
    }

}