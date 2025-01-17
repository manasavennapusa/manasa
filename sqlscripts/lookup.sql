USE [ABMauriLive]
GO
/****** Object:  StoredProcedure [dbo].[LookupUser]    Script Date: 07/31/2015 19:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[LookupUser]
@employeeID varchar(50)
AS
SELECT l.login_id login_id, l.empcode empcode,l.pwd pwd,l.role role,er.role as rolename, l.status status,l.createddate createddate,l.updateddate updateddate,l.lastlogin lastlogin,coalesce(g.emp_fname,' ')+' '+coalesce(g.emp_m_name,' ')+' '+coalesce(g.emp_l_name,' ') as name,g.branch_id ,g.photo photo,g.emp_gender gender,p.doa doa,official_email_id
FROM tbl_login l INNER JOIN 
                   tbl_intranet_employee_jobDetails g ON g.empcode=l.empcode
                 left Join tbl_intranet_employee_personalDetails p ON g.empcode = p.empcode 
                 inner join tbl_intranet_role er on er.id=l.role
WHERE l.empcode = @employeeID and g.emp_doleaving is null
