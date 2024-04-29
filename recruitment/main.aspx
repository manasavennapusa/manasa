<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="recruitment_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd. </title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/tabcontent.css";
    </style>
    <script type="text/javascript" src="../js/tabcontent.js">
        

    </script>
    <script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="../js/ddaccordion.js"></script>
    <script type="text/javascript">
        ddaccordion.init({
            headerclass: "expandable", //Shared CSS class name of headers group
            contentclass: "submenu", //Shared CSS class name of contents group
            collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
            defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
            animatedefault: false, //Should contents open by default be animated into view?
            persiststate: true, //persist state of opened contents within browser session?
            toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["suffix", "<img src='../images/plus3.gif' class='statusicon' />", "<img src='../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="7" colspan="3" bgcolor="#f1f4f5"></td>
                </tr>
                <%--<tr>
<td height="30" colspan="3" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; ">Company &gt;&gt; Create Company </td>
</tr>--%>
                <tr>
                    <td height="5" colspan="3"></td>
                </tr>
                <tr>
                    <td width="12%" valign="top" class="blue-brdr">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <table width="210" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="nav-head">Recruitment
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="glossymenu">
                                                    <a class="menuitem expandable" href="#">RRF</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="requisition_form.aspx" target="content">Create RRF</a></li>
                                                            <li><a href="requisitionFormsList.aspx" target="content">View / Edit RRF</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">APProve RRF</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="approveRequistionForm.aspx" target="content">View RRF</a></li>
                                                            <%--<li><a href="stateedit.aspx" target="content">View / Edit State</a></li>--%>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Forward Vacancies</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="forwardVacancys.aspx" target="content">Forward Vacancies</a></li>
                                                            <%--<li><a href="Viewcity.aspx" target="content">View / Edit City</a></li>--%>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Post Vacancies</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <%--<li><a href="createcompany.aspx" target="content">Create Company</a></li>--%>
                                                            <li><a href="postVacancies.aspx" target="content">Post Vacancies</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">View Candidates</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="candidateResumeSearch.aspx" target="content">View Candidates</a></li>
                                                            <%--<li><a href="branchview.aspx" target="content">View / Edit Branch</a></li>--%>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Close Vacancies</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="closeVacancy.aspx" target="content">Close Vacancies</a></li>
                                                            <%--<li><a href="viewcostcentergroup.aspx" target="content">View/Edit Cost Center Group</a></li>
                                                                                            <li><a href="costcenter.aspx" target="content">Create Cost Center</a></li>
                                                                                            <li><a href="costcenterview.aspx" target="content">View/Edit Cost Center</a></li>--%>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Upload Resume</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="candidateRegistrationForm.aspx" target="content">upload Resume </a></li>
                                                            <%--  <li><a href="viewbroadgroup.aspx" target="content">View/Edit Broad Group</a></li>--%>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Skill Master</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addSkill.aspx" target="content">Add Skill</a></li>
                                                            <li><a href="skillsearch.aspx" target="content">View/Edit Skills</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Document Master</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addDocument.aspx" target="content">Add Document</a></li>
                                                            <li><a href="documentList.aspx" target="content">View / Edit Document</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Online Test Setup</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addPaperSet.aspx" target="content">Set Paper</a></li>
                                                            <li><a href="paperSetList.aspx" target="content">View / Edit Paper</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Interview Panel</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addInterviewPanelDetails.aspx" target="content">Create Panel</a></li>
                                                            <li><a href="interviewPanelList.aspx" target="content">View / Edit Panel</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Round Master</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addRoundDetails.aspx" target="content">Create Round</a></li>
                                                            <li><a href="interviewRoundsList.aspx" target="content">View / Edit Round</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Scheme Master</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addScheme.aspx" target="content">Create Scheme</a></li>
                                                            <li><a href="schemeList.aspx" target="content">View / Edit Scheme</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Schudular</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="schedularCriteria.aspx" target="content">Create Schudular</a></li>
                                                            <li><a href="divisionview.aspx" target="content">View / Edit Schudular</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Paper Master</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addPaperSet.aspx" target="content">Create Paper</a></li>
                                                            <li><a href="paperSetList.aspx" target="content">View / Edit Paper</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Resume Search</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="candidateResumeSearch.aspx" target="content">Resume Search</a></li>
                                                                                            <%--<li><a href="gradeview.aspx" target="content">View / Edit Grade</a></li>--%>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Jobsite / Consultancy Master</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="addjobsite_consultancy.aspx" target="content">Add Jobsite/Consultancy</a></li>
                                                            <li><a href="viewConsultancies_jobsites.aspx" target="content">View / Edit Jobsite/Consultancy</a></li>
                                                        </ul>
                                                    </div>
                                                    <a class="menuitem expandable" href="#">Online Test</a>
                                                    <div class="submenu">
                                                        <ul>
                                                            <li><a href="onlineTestLogin.aspx" target="content">Online Test Login</a></li>
                                                            <%--<li><a href="statusview.aspx" target="content">View / Edit Status</a></li>--%>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <!--................................LEFT NAVIGAION........................-->
                    </td>
                    <td width="1%" valign="top">
                        <img src="../images/5x5.gif" width="10" height="5" />
                    </td>
                    <td valign="top" align="left" class="blue-brdr-1">
                        <iframe name="content" frameborder="0" width="1000px" height="600px" src="requisition_form.aspx"
                            scrolling="yes"></iframe>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
