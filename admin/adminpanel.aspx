<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminpanel.aspx.cs" Inherits="Admin_adminpanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd. - Admin Panel</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/tabcontent.css";
    </style>

    <script type="text/javascript" src="../js/tabcontent.js">
        /***********************************************
        * Tab Content script v2.2- © Dynamic Drive DHTML code library (www.dynamicdrive.com)
        * This notice MUST stay intact for legal use
        * Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
        ***********************************************/
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

<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="1000" valign="top" class="bg">
                    <table width="980" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" class="wht-clr">
                                <!--......................HEADER..............................-->
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="65%" valign="top">
                                            <img src="../upload/logo/insight-logo1.gif" alt="" />
                                        </td>
                                        <td width="35%" align="right">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="91%" height="20" align="right" valign="bottom">
                                                        <strong>Welcome</strong>
                                                        <asp:Label ID="lblname" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="9%" align="center" valign="bottom">
                                                        <img src="../images/welcome-icon.jpg" width="14" height="16" alt="" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="bottom">
                                                        <asp:LinkButton ID="lnkhome" CssClass="link01" runat="server" OnClick="lnkbtnHome_Click">Home</asp:LinkButton>
                                                        <span class="black1-new">|</span>
                                                        <asp:LinkButton ID="lnkbtnWidth"  CssClass="link01" runat="server" OnClick="lnkbtnlogout_Click">Logout</asp:LinkButton>
                                                    </td>
                                                    <td align="center" valign="bottom">
                                                        <img src="../images/log-out-icons.jpg" width="10" height="10" alt="" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="23">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!--......................END HEADER..............................-->
                            </td>
                        </tr>
                        <%--<tr><td height="8" colspan="2"></td></tr>
--%><tr>
    <td valign="bottom" background="../images/bg-sub-nav.jpg" style="background-repeat: repeat-x;
        padding-left: 5px; padding-right: 5px; padding-top: 8px;">
        <div>
            <ul id="countrytabs" class="shadetabs">
                <li><a href="#" rel="country1" class="selected"><span>company</span></a></li>
                <%--<li><a href="#" rel="country2">Workplace</a></li>--%>
                <li><a href="#" rel="country3">Employee</a></li>
                <li><a href="#" rel="country4">Information Center</a></li>
                <li><a href="#" rel="country5">Leave Management</a></li>
                <li id="superadmin" runat="server" visible="false"><a href="#" rel="country6">Pay Roll</a></li>
                <!-- Codes by Quackit.com -->
            </ul>
        </div>
        <div style="padding-top: 1px;">
            <div id="country1" class="tabcontent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="7" colspan="3" bgcolor="#f1f4f5">
                        </td>
                    </tr>
                    <%--<tr>
<td height="30" colspan="3" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; ">company &gt;&gt; Create company </td>
</tr>--%>
                    <tr>
                        <td height="5" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" valign="top" class="blue-brdr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="210" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="nav-head">
                                                    Create company
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="glossymenu">
                                                        <a class="menuitem expandable" href="#">company</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <%--<li><a href="createcompany.aspx" target="content">Create company</a></li>--%>
                                                                <li><a href="viewcompany.aspx" target="content">View / Edit company</a></li>
                                                            </ul>
                                                        </div>
                                                        <a class="menuitem expandable" href="#">Branch</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <li><a href="createbranch.aspx" target="content">Create Branch</a></li>
                                                                <li><a href="branchview.aspx" target="content">View / Edit Branch</a></li>
                                                            </ul>
                                                        </div>
                                                        <a class="menuitem expandable" href="#">Department</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <li><a href="createdepartment.aspx" target="content">Create Department</a></li>
                                                                <li><a href="departmentview.aspx" target="content">View / Edit Department</a></li>
                                                            </ul>
                                                        </div>
                                                        <a class="menuitem expandable" href="#">Division</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <li><a href="createdivision.aspx" target="content">Create Division</a></li>
                                                                <li><a href="divisionview.aspx" target="content">View / Edit Division</a></li>
                                                            </ul>
                                                        </div>
                                                        <a class="menuitem expandable" href="#">Designation</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <li><a href="createdesigination.aspx" target="content">Create Designation</a></li>
                                                                <li><a href="desiginationview.aspx" target="content">View / Edit Designation</a></li>
                                                            </ul>
                                                        </div>
                                                        <a class="menuitem expandable" href="#">Grade</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <li><a href="creategrade.aspx" target="content">Create Grade</a></li>
                                                                <li><a href="gradeview.aspx" target="content">View / Edit Grade</a></li>
                                                            </ul>
                                                        </div>
                                                        <a class="menuitem expandable" href="#">Role</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <li><a href="createrole.aspx" target="content">Create Role</a></li>
                                                                <li><a href="roleview.aspx" target="content">View / Edit Role</a></li>
                                                            </ul>
                                                        </div>
                                                        <a class="menuitem expandable" href="#">Status</a>
                                                        <div class="submenu">
                                                            <ul>
                                                                <li><a href="createstatus.aspx" target="content">Create Status</a></li>
                                                                <li><a href="statusview.aspx" target="content">View / Edit Status</a></li>
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
                            <iframe name="content" frameborder="0" width="735px" height="495px" src="viewcompany.aspx"
                                scrolling="yes"></iframe>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="country2" class="tabcontent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <%--<tr>
<td colspan="3" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; height: 30px;">Workplace &gt;&gt; Contact List</td>
</tr>--%>
                    <tr>
                        <td colspan="3" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" valign="top" class="blue-brdr">
                            <!--................................LEFT NAVIGAION........................-->
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="210" border="0" cellspacing="0" cellpadding="0">
                                            <%--<tr>
<td class="nav-head">Create Workplace</td>
</tr>
<tr>
<td>
<div class="glossymenu">
<a class="menuitem expandable" href="#">Contact List</a>
<div class="submenu">
<ul>
<li><a href="#" target="content1">Create Contact List</a></li>
<li><a href="#" target="content1">View / Edit Contact List</a></li>
</ul>
</div>
<a class="menuitem expandable" href="#">Suggestions</a>
<div class="submenu">
<ul>
<li><a href="#" target="content1">Create Suggestions</a></li>
<li><a href="#" target="content1">View / Edit Suggestions</a></li>
</ul>
</div>

<a class="menuitem expandable" href="#">Feedback</a>
<div class="submenu">
<ul>
<li><a href="#" target="content1">Create Feedback</a></li>
<li><a href="#" target="content1">View / Edit Feedback</a></li>
</ul>
</div>
</div></td>
</tr>--%>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!--................................END LEFT NAVIGAION........................-->
                        </td>
                        <td valign="top" style="width: 1%">
                            <img src="../images/5x5.gif" width="10" height="5" />
                        </td>
                        <td width="87%" valign="top" align="left" class="blue-brdr-1">
                            <iframe name="content1" frameborder="0" width="735px" height="495px" src="1.htm"
                                scrolling="yes"></iframe>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="country3" class="tabcontent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <%--<tr>
<td height="30" colspan="3" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; ">Employee &gt;&gt; Create Employee </td>
</tr>--%>
                    <tr>
                        <td height="5" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" valign="top" class="blue-brdr">
                            <!--................................LEFT NAVIGAION........................-->
                            <table width="210" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="nav-head">
                                        Create Employee
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="glossymenu">
                                            <a class="menuitem expandable" href="#">Employee</a>
                                            <div class="submenu">
                                                <ul>
                                                    <li><a href="empmaster.aspx" target="content2">Create Employee</a></li>
                                                    <li><a href="empview.aspx" target="content2">View / Edit Employee</a></li>
                                                    <li><a href="empviewresign.aspx" target="content2">View Employee who Resigned</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <!--................................END LEFT NAVIGAION........................-->
                        </td>
                        <td width="1%" valign="top">
                            <img src="../images/5x5.gif" width="10" height="5" />
                        </td>
                        <td width="87%" valign="top" align="left" class="blue-brdr-1">
                            <iframe name="content2" frameborder="0" width="735px" height="495px" src="empmaster.aspx"
                                scrolling="yes"></iframe>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="country4" class="tabcontent">
                <table width="99%" border="0" cellspacing="0" cellpadding="0">
                    <%--<tr>
<td height="30" colspan="3" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; ">Information Center &gt;&gt; News Entry </td>
</tr>--%>
                    <tr>
                        <td height="5" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" valign="top" class="blue-brdr">
                            <!--................................LEFT NAVIGAION........................-->
                            <table width="210" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="nav-head-new">
                                        Navigation
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="newsmaster.aspx" class="other-text" target="content4">News Master</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="eventsmaster.aspx" class="other-text" target="content4">Event Master</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="achievements.aspx" class="other-text" target="content4">Achievement Master</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="announcements.aspx" class="other-text" target="content4">Announcement Master</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="catalogs.aspx" class="other-text" target="content4">Catalog</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="isodocuments.aspx" class="other-text" target="content4">ISO Documents</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="trainingdocuments.aspx" class="other-text" target="content4">Training Documents</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="hrdocuments.aspx" class="other-text" target="content4">HR Documents</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="productinformation.aspx" class="other-text" target="content4">Product Information</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="manuals.aspx" class="other-text" target="content4">Manuals</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="policydockit.aspx" class="other-text" target="content4">Policy Dockit</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="organizationchart.aspx" class="other-text" target="content4">Organization Chart</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="financialentry.aspx" class="other-text" target="content4">Financial</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="pressrelease.aspx" class="other-text" target="content4">Press Release</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="suggestionapprove.aspx" class="other-text" target="content4">Approve Suggestion</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="readfeedback.aspx" class="other-text" target="content4">Read Feedback</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="other">
                                        <a href="bulletindocuments.aspx" class="other-text" target="content4">Upload Bulletin</a>
                                    </td>
                                </tr>
                            </table>
                            <!--................................END LEFT NAVIGAION........................-->
                        </td>
                        <td valign="top" style="width: 1%">
                            <img src="../images/5x5.gif" width="10" height="5" />
                        </td>
                        <td width="87%" valign="top" align="left" class="blue-brdr-1">
                            <iframe name="content4" frameborder="0" width="735px" height="495px" src="newsmaster.aspx"
                                scrolling="yes"></iframe>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="country5" class="tabcontent">

                <script language="javascript" type="text/javascript">
                    //javascript:location.reload(true);
                </script>

                <iframe name="name123" frameborder="0" width="969px" height="575px" src="../leave/admin/leaveadmin.aspx"
                    scrolling="no"></iframe>
            </div>
            <div id="country6" class="tabcontent">

                <script language="javascript" type="text/javascript">
                    //javascript:location.reload(true);
                </script>

                <iframe name="name123" frameborder="0" width="969px" height="536px" src="../payroll/admin/Payrolladmin.aspx"
                    scrolling="no"></iframe>
            </div>
        </div>

        <script type="text/javascript">
            var countries = new ddtabcontent("countrytabs")
            countries.setpersist(true)
            countries.setselectedClassTarget("link") //"link" or "linkparent"
            countries.init()
        </script>

    </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="footer">
        <div class="main">
            Powered by SmartDrive Labs Technologies India Pvt. Ltd.
        </div>
    </div>
    </form>
</body>
</html>
