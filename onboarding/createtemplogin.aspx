<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createtemplogin.aspx.cs" Inherits="admin_createtemplogin" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <%--   <script src="../js/html5-trunk.js" type="text/javascript"></script>--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star {
            color: red;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Temporary Login Details</h2>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;">Create</span>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <div>
                                        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2" width="100%">
                                                    <table style="width: 100%; height: 180px" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="50%" valign="top">
                                                                <asp:UpdatePanel ID="kk" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr id="tr" runat="server" visible="false">
                                                                                <td class="frm-lft-clr123 border-bottom" width="40%" style="text-align: right">Employee Code<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="60%">
                                                                                    <asp:TextBox ID="txtempcode" runat="server" CssClass="span10" MaxLength="50"></asp:TextBox>

                                                                                </td>
                                                                            </tr>
                                                                            <tr id="tr1" runat="server" visible="false">
                                                                                <td class="frm-lft-clr123 border-bottom" width="40%" style="text-align: right">Login Password<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="60%">
                                                                                    <asp:TextBox ID="txtpwd" runat="server" CssClass="span10" TextMode="Password" MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="40%" style="text-align: right">Confirmed Candidates<span class="star"></span> </td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="60%">
                                                                                    <asp:TextBox ID="txtcandidatid" runat="server" CssClass="span10"></asp:TextBox>
                                                                                    <a href="JavaScript:newPopup1('Pic_Candidates.aspx?role=13&empcode=<%=txtcandidatid.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtcandidatid"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Candidate Id"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcandidatid"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Candidate Id"
                                                                                        ValidationGroup="v1" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="40%" style="text-align: right">Employee Name<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="60%">
                                                                                    <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="span10"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployeeName"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Employee Name"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="40%" style="text-align: right">Email Id<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="60%">
                                                                                    <asp:TextBox ID="txtEmailId" runat="server" CssClass="span10"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailId"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Email Id"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                                        ValidationGroup="v" ToolTip="Invalid Email Id" SetFocusOnError="True" Display="Dynamic"
                                                                                        ControlToValidate="txtEmailId" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="40%" style="text-align: right">Date Of Birth<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="60%">
                                                                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="span10" onkeypress="return false;" placeholder="dd-mmm-yyyy" onpaste="return false;" onkeydown="return enterdate(event);"></asp:TextBox>&#160;
                                                                                   <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" ToolTip="click to open calendar" />
                                                                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11" TargetControlID="txtDOB" Format="dd-MMM-yyyy"></cc1:CalendarExtender>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOB"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Date Of Birth"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>

                                                            <td valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td style="height: 21px"></td>
                                                                            </tr>
                                                                        </table>
                                                                        <table style="margin-left: 30px">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Button ID="getcandidt" runat="server" OnClick="getcandidt_Click" CssClass="btn btn-info" Text="Get Details" ValidationGroup="v1" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                        </table>
                                        <br />
                                        <div class="form-actions no-margin" style="text-align: center">
                                            <asp:Button ID="btngeneralsubmit" runat="server" CssClass="btn btn-info" OnClick="btngeneralsubmit_Click" Text="Create" ValidationGroup="v" Style="margin-right: 10px" />
                                            <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info" Text="Reset" Style="margin-right: 10px" OnClick="btn_reset_Click" />
                                         

                                        </div>
                                    </div>
                                </div>
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
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView
                                        ID="grid"
                                        runat="server"
                                        AutoGenerateColumns="false"
                                        CssClass="table table-condensed table-striped table-hover table-bordered pull-left datatable"
                                        OnPreRender="grid_PreRender" OnRowDeleting="grid_RowDeleting" DataKeyNames="id">
                                        <Columns>


                                            <asp:BoundField HeaderText="Employee Code" DataField="empcode" SortExpression="empcode" />
                                            <asp:BoundField HeaderText="Employee Name" DataField="emp_fname" SortExpression="emp_fname" />
                                            <asp:BoundField HeaderText="Email Id" DataField="email_id" SortExpression="email_id" />
                                            <asp:BoundField HeaderText="DOB" DataField="dob" SortExpression="dob" />

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <%#Eval("submitstatus") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--    <asp:HyperLinkField HeaderText="Validate"
                                                DataNavigateUrlFields="empcode"
                                                DataNavigateUrlFormatString="validateempmaster.aspx?edit={0}"
                                                ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center"
                                                ControlStyle-CssClass="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone"
                                                Text="Validate" />--%>

                                            <asp:HyperLinkField HeaderText="Reset Password"
                                                DataNavigateUrlFields="empcode"
                                                DataNavigateUrlFormatString="../onboarding/ResetPassword.aspx?q={0}"
                                                ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center"
                                                ControlStyle-CssClass="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone"
                                                Text="Reset" />
                                            <asp:TemplateField>
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete"><i class="icon-remove"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString  %>"
                                        runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                            <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                            <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                            <asp:Parameter Name="status" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grid').dataTable({
                "sPaginationType": "full_numbers",
                "aaSorting": [[0, "desc"]],
                "iDisplayLength": 7
            });
        });
    </script>
</body>
</html>
