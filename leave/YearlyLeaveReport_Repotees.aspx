<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyLeaveReport_Repotees.aspx.cs" Inherits="Leave_YearlyLeaveReport_Repotees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>My Reportees Yearly Leave Report</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Yearly Leave Report
                                </div>
                                <div>
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">

                                        <label class="control-label">Select Leave Calender</label>
                                        <div class="controls">

                                            <asp:DropDownList
                                                ID="ddlLeaveCalender"
                                                runat="server"
                                                CssClass="span4"
                                                AppendDataBoundItems="true"
                                                >
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator
                                                ID="RFV1"
                                                runat="server"
                                                ControlToValidate="ddlLeaveCalender"
                                                EnableClientScript="true"
                                                Display="Static"
                                                ValidationGroup="v"
                                                ErrorMessage="Leave Calender field is required."
                                                SetFocusOnError="true"
                                                InitialValue="0"
                                                Text="<font style='color:red;'>*</font>"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Select Leave Policy</label>

                                        <div class="controls">
                                            <asp:DropDownList
                                                ID="ddlPolicy"
                                                runat="server"
                                                CssClass="span4"
                                                >
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="SDL GLOBE POLICY"></asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                runat="server"
                                                ControlToValidate="ddlPolicy"
                                                InitialValue="0"
                                                ErrorMessage="Leave Policy field is required."
                                                Text="<font style='color:red;'>*</font>"
                                                ValidationGroup="v"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Select Leave Type</label>

                                        <div class="controls">
                                            <asp:DropDownList
                                                ID="ddlLeaveType"
                                                runat="server"
                                                CssClass="span4"
                                                >
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Casual Leave (CL)"></asp:ListItem>
                                             <%--   <asp:ListItem Value="2" Text="Casual & SickLeave"></asp:ListItem>--%>
                                                <asp:ListItem Value="3" Text="Sick Leave"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Loss of pay (LOP)"></asp:ListItem>
                                                <%--<asp:ListItem Value="5" Text="Loss of pay (LOP)"></asp:ListItem>--%>
                                                <asp:ListItem Value="10" Text="All"></asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                runat="server"
                                                ControlToValidate="ddlLeaveType"
                                                InitialValue="0"
                                                ErrorMessage="Leave Type field is required."
                                                Text="<font style='color:red;'>*</font>"
                                                ValidationGroup="v"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    
                                    <div class="form-actions no-margin">

                                        <asp:ValidationSummary ID="VS1"
                                            runat="server"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true"
                                            ShowMessageBox="true"
                                            ShowSummary="false" ValidationGroup="v" />

                                        <asp:Button
                                            ID="btnsbmit"
                                            runat="server"
                                            Text="Generate"
                                            CssClass="btn btn-info"
                                            ValidationGroup="v"
                                            OnClick="btnsbmit_Click" />
                                    </div>
                                </fieldset>
                            </div>

                        </div>
                    </div>


                </div>
            </div>
        </div>

    </form>
</body>
</html>
