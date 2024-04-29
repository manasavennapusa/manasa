<%@ Page Language="C#" AutoEventWireup="true" CodeFile="holdandrelesesalary.aspx.cs" Inherits="payroll_admin_holdandrelesesalary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";

        .gvclass th
        {
            text-align: left;
            background-color: #F9F9F9;
            border: 1px solid #ddd;
        }

        absolute fieldset
        {
            margin: 0;
            padding: 0;
            border: 1px solid #c9dffb;
            padding: 0 7px 10px 7px;
        }

        legend
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #08486d;
            padding-bottom: 0px;
            padding-top: 2px;
        }
    </style>


    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" />
                                    </td>
                                    <td valign="bottom">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top" colspan="5">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="blue-brdr-1">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <%-- <td width="3%" style="height: 16px">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>--%>
                                                                            <td id="Td1" class="txt01" runat="server" style="width: 347px; height: 16px">Hold Loan Payout 
                                                                            </td>
                                                                            <td id="Td2" runat="server" align="right" class="txt02" style="height: 16px">
                                                                                <asp:Label ID="lbl_message" runat="server" Enabled="true" ForeColor="#990000" Text=""></asp:Label>
                                                                            </td>
                                                                            <%--<td><a style="float:right;" href="doc/attendance.xls">Download</a></td>--%>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5">
                                                                    <%--<asp:RadioButton ID="rbtnprocess" runat="server" Checked="true" AutoPostBack="True" OnCheckedChanged="rbtnprocess_CheckedChanged" Text="Process Attendance" GroupName="c" /> | <asp:RadioButton ID="rbtnupload" runat="server" Checked="false" AutoPostBack="True" Text="Upload Attendance" GroupName="c" OnCheckedChanged="rbtnupload_CheckedChanged" />--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Employee Code  <span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="txt_employee" size="40" CssClass="span4" runat="server" ></asp:Label>
                                                                             <%--   <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                               <%-- <a href="JavaScript:newPopup1('../../leave/pickemployee.aspx');" class="link05">Pick Employee</a>--%>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="20%">Financial Year
                                                                            </td>
                                                                            <td class="frm-rght-clr123" colspan="2" style="width: 572px">&nbsp;<asp:Label ID="lbl_fyear" runat="server" CssClass="span4"></asp:Label>
                                                                                <asp:Label ID="lbl" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Select Month
                                                                            </td>
                                                                            <td class="frm-rght-clr123" colspan="2" style="width: 572px">&nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="span4" AutoPostBack="True" OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
                                                                               
                                                                            </asp:DropDownList>
                                                                            </td>
                                                                        </tr>


                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Remarks<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:TextBox ID="txt_remarks" size="40" CssClass="span4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="20%">
                                                                            </td>
                                                                            <td align="left" class="frm-rght-clr123 border-bottom" colspan="2">&nbsp;
                                                                                <asp:Button ID="btn_procs_att" runat="server" CssClass="button" Text="Hold Loan" Width="100px"
                                                                                ValidationGroup="v" OnClick="btn_procs_att_Click" />
                                                                              
                                                                            
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="15"></td>
                                                            </tr>

                                                            <tr>
                                                                <td class="head-2" valign="top">
                                                                    <%-- <div style="overflow-x: scroll; overflow-y: hidden;">--%>
                                                                    <asp:GridView ID="empgrid" GridLines="Both" runat="server" AllowPaging="True"
                                                                        OnPageIndexChanging="empgrid_PageIndexChanging" PageSize="50" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                    </asp:GridView>
                                                                    <%--</div>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <%--<Triggers>
                <asp:PostBackTrigger ControlID="btnupload" />
                <asp:PostBackTrigger ControlID="btnexport" />
            </Triggers>--%>
        </asp:UpdatePanel>
    </form>
</body>
</html>
