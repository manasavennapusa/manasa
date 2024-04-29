<%@ Page Language="C#" AutoEventWireup="true" CodeFile="round1candidates.aspx.cs" Inherits="recruitment_candidatesSelectedForRound1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <style type="text/css">
        .ajax__calendar_container td {
            border: none;
            padding: 0px;
        }
    </style>
    <script type="text/javascript">
        function IsNumericDot(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="modal-backdrop fade in">
                                <div class="center">
                                    <img src="../img/loading.gif" />"
                                    Please Wait...
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>


                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Round One Candidates</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>CANDIDATES SELECTED FOR ROUND ONE
                                        </div>
                                    </div>
                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>
                                            <tr>
                                                <td>Select RRF Code
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlrrfcode" runat="server" CssClass="span4" OnSelectedIndexChanged="ddlrrfcode_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grdcandidates" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdcandidates_PreRender"
                                                EmptyDataText="No data Found" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Candidate ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RRF Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrrfID" runat="server" Text='<%#Eval("rrf_code")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesig" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("candidate_name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Skills" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblskills" runat="server" Text='<%#Eval("skills")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Experience" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblexp" runat="server" Text='<%#Eval("experience")%>'></asp:Label>
                                                            Months
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qualification">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblqualification" runat="server" Text='<%#Eval("Qualification")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Interview Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_rnd1_date" runat="server" Text='<%#Eval("round1_date","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Interview Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_rnd1_time" runat="server" Text='<%#Eval("round1_time")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact No." Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcontactno" runat="server" Text='<%#Eval("mobile")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("emailid")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select Function" HeaderStyle-Width="13%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpaper" runat="server" Text='<%#Eval("round1_paperid")%>' Visible='<%#Eval("round1_paperid").ToString()!=""?true:false%>'></asp:Label>
                                                            <div id="div" runat="server" visible='<%#Eval("round1_paperid").ToString() != "" ? false: true%>'>
                                                                <asp:DropDownList ID="ddlpaper" runat="server" CssClass="span10"></asp:DropDownList>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Marks/Remarks" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmarks" runat="server" Visible='<%#Eval("round_1_marks").ToString()!=""?true:false%>' Text='<%#Eval("round_1_marks")%>'></asp:Label>
                                                            <asp:TextBox ID="txtmarks" runat="server" CssClass="span10" Visible='<%#Eval("round_1_marks").ToString() != "" ? false: true%>' ondrop="return false;" onpaste="return false;" MaxLength="50"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Update" Visible="false">
                                                        <ItemTemplate>
                                                            <%--<a href="JavaScript:newPopup1('viewresume.aspx?doc=<%# Eval("uploadresume")%>');" class="link05">view</a>--%>
                                                            <asp:LinkButton ID="lbtnview" runat="server" CommandArgument='<%# Eval("id")%>' Visible='<%#Eval("round_1_marks").ToString() != "" ? false: true%>' OnCommand="lbtnview_Command" CssClass="link05">Update</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Profile">
                                                        <ItemTemplate>
                                                            <%-- <a href='EditUser.aspx?uid=<%# Eval("Userid")%>&other=<%# Eval("Other")%>'>Text</a>--%>
                                                            <%--<a href="JavaScript:newPopup1('Candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>')" 'height="550",width' class="link05">View</a>--%>
                                                            <a href="javascript:void(window.open('Candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05">
                                                                <img src="../images/view.png" width="17" height="17" border="0"></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                    <div class="form-actions no-margin" style="text-align:right">
                                        <asp:Button ID="btnSelect" runat="server" Text="Select Candidates" CssClass="btn btn-info" OnClick="btnSelect_Click" />&nbsp;
                                <asp:Button ID="btnReject" runat="server" Text="Reject Candidates" CssClass="btn btn-info" OnClick="btnReject_Click" OnClientClick="return confirm('Are you sure. you want to Reject?')" />
                                        <%-- CssClass="btn btn-danger"--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>CANDIDATES SELECTED IN ROUND ONE
                                        </div>
                                    </div>
                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>
                                            <tr>
                                                <td>Select RRF Code
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlrrf" runat="server" CssClass="span4" OnSelectedIndexChanged="ddlrrf_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="widget-body">
                                        <div id="dt_example1" class="example_alt_pagination">
                                            <asp:GridView ID="grdcandidatesinround1" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnRowDataBound="grdcandidatesinround1_RowDataBound"
                                                EmptyDataText="No data Found" OnPreRender="grdcandidatesinround1_PreRender" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnRowDeleting="grdcandidatesinround1_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Candidate ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RRF Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrrfID" runat="server" Text='<%#Eval("rrf_code")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Designation Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesig1" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("candidate_name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Skills" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblskills" runat="server" Text='<%#Eval("skills")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Experience (in Months)" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblexp" runat="server" Text='<%#Eval("experience")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Contact No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcontactno" runat="server" Text='<%#Eval("mobile")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("emailid")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Round_1 Date" Visible="false">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="lblrnd_1date" runat="server" Text='<%#Eval("round1_date","{0:MM/dd/yyyy}")%>'></asp:Label>--%>
                                                            <asp:Label ID="lblrnd_1date" runat="server" Text='<%#Eval("round1_date","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                            <%--<asp:TextBox ID="lblrnd_1date" runat="server" CssClass="span8" ></asp:TextBox>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Marks in Round 1">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmarks" runat="server" Text='<%#Eval("round_1_marks")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="13%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("round2_date", "{0:MM/dd/yyyy}")%>' Visible='<%#Eval("round2_date").ToString()==""?false:true%>'></asp:Label>
                                                            <div id="divdate" runat="server" visible='<%#Eval("round2_date").ToString()==""?true:false%>'>
                                                                <asp:TextBox ID="txtDate" runat="server" CssClass="span8" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox><%-- OnTextChanged="txtDate_TextChanged"  AutoPostBack="true"--%>
                                                                <asp:Image ID="Image12" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12" TargetControlID="txtDate" Enabled="True" Format="dd-MMM-yyyy">
                                                                </cc1:CalendarExtender>
                                                                <%--<asp:CompareValidator ID="CompareValidator16" runat="server" ValueToCompare="<%# DateTime.Today.ToShortDateString() %>"
                                                            ControlToValidate="txtDate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                            Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Select valid date "
                                                            ValidationGroup="c"></asp:CompareValidator>--%>
                                                                <%--<asp:CompareValidator ID="CompareValidator16" runat="server" ValueToCompare='<%#Eval("round1_date","{0:MM/dd/yyyy}")%>'
                                                            ControlToValidate="txtDate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                            Operator="GreaterThanEqual" SetFocusOnError="True" Type="Date" ToolTip="Please Enter Valid Date&Time"
                                                            ValidationGroup="c"></asp:CompareValidator>--%>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Time" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltime" runat="server" Text='<%#Eval("round2_time")%>' Visible='<%#Eval("round2_time").ToString()==""?false:true%>'></asp:Label>
                                                            <div id="divtime" runat="server" visible='<%#Eval("round2_time").ToString()==""?true:false%>'>
                                                                <asp:TextBox ID="tbttime" runat="server" CssClass="span5"></asp:TextBox>
                                                                (Ex.2AM,2PM)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbttime"
                                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Time fro Interview"
                                                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Profile">
                                                        <ItemTemplate>
                                                            <%-- <a href='EditUser.aspx?uid=<%# Eval("Userid")%>&other=<%# Eval("Other")%>'>Text</a>--%>
                                                            <%-- <a href="JavaScript:newPopup1('Candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>')" class="link05">View</a>--%>
                                                            <a href="javascript:void(window.open('Candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05">
                                                                <img src="../images/view.png" width="17" height="17" border="0"></a>
                                                            <%--  <a href="#advanced" role="button" class="btn btn-primary pull-right" data-toggle="modal">Details</a>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Editcandidate.aspx?id={0}&rrf_code=0"
                                                        NavigateUrl="Editcandidate.aspx" Text="&lt;img src='../images/edit.png'/&gt;" HeaderStyle-Width="8%">
                                                        <ControlStyle CssClass="link05" />
                                                        <HeaderStyle CssClass="" Width="15px" />
                                                        <ItemStyle CssClass=""></ItemStyle>
                                                    </asp:HyperLinkField>

                                                    <asp:TemplateField HeaderStyle-Width="4%" ItemStyle-Width="30px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                Text="&lt;img src='../images/download_delete.png'/&gt;"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="form-actions no-margin" style="text-align:right">
                                        <asp:Button ID="btnSelectinround1" runat="server" Text="Select Candidates Round 2" CssClass="btn btn-info" OnClick="btnSelectinround1_Click" />&nbsp;
                                        <asp:Button ID="btnSelectinround3" runat="server" Text="Select Candidates Round 3" CssClass="btn btn-info" OnClick="btnSelectinround3_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdcandidates').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
        $(document).ready(function () {
            $('#grdcandidatesinround1').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>
</body>
</html>

