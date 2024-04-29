<%@ Page Language="C#" AutoEventWireup="true" CodeFile="candidateResumeSearch.aspx.cs"
    Inherits="recruitment_candidateResumeSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8">
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
        function isKey(keyCode) {
            return false;
        }
    </script>
    <script type="text/javascript">
        function IsNumericDot(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]|\./;
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
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Resume</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Search
                                </div>
                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <div class="widget-body">
                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Skill Name
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_skills" runat="server" CssClass="span10" MaxLength="200"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">
                                            Expected Salary:
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_sal_from" runat="server" CssClass="span5" MaxLength="6" placeholder="From" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                            <asp:TextBox ID="txt_sal_to" runat="server" CssClass="span5 input-left-top-margins" placeholder="To" MaxLength="6" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                        </div>

                                    </div>

                                </div>

                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Designation Name :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:DropDownList ID="drpdesig" runat="server" CssClass="span10"
                                                OnDataBound="drpdesig_DataBound" OnSelectedIndexChanged="drpdesig_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Experience :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_exp_from" runat="server" CssClass="span5" MaxLength="6" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;" placeholder="From"></asp:TextBox>

                                            <asp:TextBox ID="txt_exp_to" runat="server" CssClass="span5 input-left-top-margins" MaxLength="6" placeholder="To" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="form-actions no-margin">
                                <asp:Button ID="btnSearch" runat="server" Text="Search " CssClass="btn btn-info" OnClick="btnSearch_Click" />&nbsp;
                                <asp:Button ID="btnsearchclear" runat="server" Text="Search Clear" Visible="false" CssClass="btn" OnClick="btnsearchclear_Click" />&nbsp;
                                                       
                            </div>
                        </div>
                    </div>
                </div>
                 
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View                                   
                                </div>
                            </div>
                            <div class="widget-header">

                              <asp:TextBox ID="search_textbox" runat="server" AutoPostBack="true"></asp:TextBox>
                                <asp:Button ID="btserch" runat="server" Text="Search" OnClick="btserch_Click" />
                            </div>
                            <div class="widget-body" style="overflow:scroll; height:600px">
                                <div id="dt_example">
                                    <asp:UpdatePanel ID="updpnl" runat="server">
                                        <ContentTemplate>

                                            <asp:GridView ID="grdcandidates" Style="margin-left: 0px" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdcandidates_PreRender" OnRowDataBound="grdcandidates_RowDataBound"
                                                EmptyDataText="No data Found" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" DataKeyNames="id" OnRowDeleting="grdcandidates_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("candidate_name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesignation" runat="server" Text='<%#Eval("designation_id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Skills" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblskills" runat="server" Text='<%#Eval("skills")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Exp (in Years)" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblexp" runat="server" Text='<%#Eval("experience")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Qualification" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblqualification" runat="server" Text='<%#Eval("Qualification")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Contact No." HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcontactno" runat="server" Text='<%#Eval("mobile")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Email" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemail" runat="server" Text='<%#Eval("emailid")%>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>--%>
                                                    <%-- <asp:TemplateField HeaderText="Salary Expected" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexpectedsalary" runat="server" Text='<%#Eval("expectedsalary")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtDate" runat="server" Style="width: 50px; height: 20px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox><asp:Image ID="Image12" runat="server" ImageUrl="images/clndr.gif" ToolTip="click to open calendar" Style="float: right" />
                                                            <cc1:CalendarExtender ID="CalendarExtender12" Format="dd-MMM-yyyy" runat="server" PopupButtonID="Image12" TargetControlID="txtDate" Enabled="True">
                                                            </cc1:CalendarExtender>
                                                            <%--  <asp:CompareValidator ID="CompareValidator16" runat="server" ValueToCompare="<%# DateTime.Today.ToShortDateString() %>"
                                                        ControlToValidate="txtDate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                        Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Back Date is not allowed "
                                                        ValidationGroup="rrf"></asp:CompareValidator>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Referred By" HeaderStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblreferedby" runat="server" Text='<%#Eval("referredby")%>'></asp:Label>
                                                            -
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("referrername")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Applied Date" HeaderStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_applied_date" runat="server" Text='<%#Eval("Applied_Date")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Time" HeaderStyle-Width="7%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="tbttime" runat="server" Style="width: 40px"></asp:TextBox>&nbsp;(Ex.2AM,2PM)
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Resume" ItemStyle-Width="5px" HeaderStyle-Width="3%">

                                                        <ItemTemplate>
                                                             <a href="upload/<%#DataBinder.Eval(Container.DataItem,"uploadresume")%>"  target="_blank" class="link05"  ><img src="images/download1.png"  border="0"></a>
                                                              <%-- <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("uploadresume")%>' OnCommand="lbtnview_Command" CssClass="link05"><img src="../images/download1.png'/&gt;"  border="0"></a></asp:LinkButton>--%>
                                                         <%--  <asp:LinkButton ID="lbtnview" runat="server" CommandArgument='<%# Eval("uploadresume")%>' OnCommand="lbtnview_Command" Text="&lt;img src='../images/download1.png'/&gt;" Width="30px" Style="margin-left: 10px"></asp:LinkButton>--%>
                                                        </ItemTemplate>

                                                        <%-- <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnview" Text="Download" CommandArgument='<%# Eval("uploadresume") %>' runat="server" CssClass="link05" ></asp:LinkButton>
                                                </ItemTemplate>--%>
                                                    </asp:TemplateField>

                                                    <%-- <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <a href="Editcandidate.aspx?id=<%#DataBinder.Eval(Container.DataItem, "candidate_name")%>" target="_self"
                                                                class="link05"><img src="images/edit.png" width="15" height="15" border="0"></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                    <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Editcandidate.aspx?id={0}&rrf_code=SR"
                                                        NavigateUrl="Editcandidate.aspx" Text="&lt;img src='../images/edit.png'/&gt;" HeaderStyle-Width="4%">
                                                        <ControlStyle CssClass="link05" />
                                                        <HeaderStyle CssClass="" />
                                                        <ItemStyle CssClass=""></ItemStyle>
                                                    </asp:HyperLinkField>

                                                    <asp:TemplateField HeaderStyle-Width="4%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                Text="&lt;img src='../images/download_delete.png'/&gt;"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%--<asp:TemplateField HeaderText="Profile">
                                                <ItemTemplate>--%>
                                                    <%--<a href="JavaScript:void(window.open('candidateprofile.aspx?id=<%#Eval("id") %>','title','height=550,width=1100,left=100,top=30'));" class="link05">View</a>--%>
                                                    <asp:HyperLinkField DataNavigateUrlFields="id" HeaderStyle-Width="4%" DataNavigateUrlFormatString="candidateprofile.aspx?id={0}"
                                                        NavigateUrl="candidateprofile.aspx" Text="&lt;img src='../images/view.png' /&gt;">
                                                        <ControlStyle CssClass="link05" />
                                                        <HeaderStyle CssClass="" />
                                                        <ItemStyle CssClass=""></ItemStyle>
                                                    </asp:HyperLinkField>
                                                    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("id", "~/candidateprofile.aspx?id={0}" %>") %>' Text='<%# Eval("id") %>' />--%>
                                                    <%--</ItemTemplate>
                                            </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">

                            <div class="widget-body">
                                <table class="table table-condensed table-bordered no-margin">
                                    <tr>
                                        <td class="frm-lft-clr123" style="width:90px">Select RRF
                                        </td>

                                        <td class="frm-rght-clr123">
                                            <asp:DropDownList ID="ddlRRF" runat="server" CssClass="span12"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRRF" InitialValue="0"
                                                Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select RRF"
                                                ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSelect" runat="server" Text="Select Candidate Round 1" CssClass="btn btn-info" OnClick="btnSelect_Click" ValidationGroup="rrf" style="margin-left:190px" />
                                            <asp:Button ID="btnselect3" runat="server" Text="Select Candidate Round 3" CssClass="btn btn-info" OnClick="btnselect3_Click" ValidationGroup="rrf" style="margin-left:20px" />

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script type="text/javascript" src="../js/timepicker.js"></script>

    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

  <%--  <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdcandidates').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>--%>
</body>
</html>
