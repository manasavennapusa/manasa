<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fullandfinalsettlement.aspx.cs"
    Inherits="payroll_admin_fullandfinalsettlement" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payslip</title>
    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            font: 11px Arial, Helvetica, sans-serif;
            color: #333;
        }

        .bm-lne
        {
            border-bottom: 1px solid #e7f1ff;
            padding: 5px 0 5px 0px;
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #013366;
        }

        .txt-un
        {
            font: bold 14px Arial, Helvetica, sans-serif;
            color: #08486d;
            padding: 6px 0;
        }

        .blue-bg1
        {
            background: #1a638d;
            color: #fff;
            padding: 0 3px;
            font: normal 11px Tahoma, Helvetica, sans-serif;
        }

        .blue-bg
        {
            background: #08486d;
            color: #fff;
            padding: 0 10px;
            font: normal 11px Tahoma, Helvetica, sans-serif;
        }

        .txt-red
        {
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #990000;
        }

        .bdr
        {
            border: 1px solid #08486d;
        }

        .line-right
        {
            border-left: 1px solid #08486d;
            border-bottom: 1px solid #08486d;
        }

        .line-left
        {
            border-bottom: 1px solid #08486d;
        }

        .line-left1
        {
            border-left: 0px;
        }

        .line-right1
        {
            border-right: 0px;
        }
    </style>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container-fluid">

        <form id="Form1" class="form-horizontal" runat="server">

            <h3>Full and Final Settlement
            </h3>

            <div class="pull-right">
                <asp:Button ID="btnSubmitTop" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />

            </div>

            <br />
            <br />
            <br />

            <div class="panel panel-default">

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">

                            <div class="form-group">

                                <label class="control-label col-md-2">Employee Code</label>

                                <div class="col-md-3">

                                    <asp:TextBox
                                        ID="txt_employee"
                                        runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-md-1">
                                    <a href="JavaScript:newPopup1('pickemp.aspx');" 
                                        class="btn btn-info btn-sm">Pick Employee

                                    </a>
                                </div>
                                <div class="col-md-4">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button
                                        ID="btnGetInfo"
                                        runat="server"
                                        Text="Get"
                                        CssClass="btn btn-info btn-sm"
                                        OnClick="btnGetInfo_Click" />
                                </div>
                            </div>
                        </div>
                        <div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">Basic Information</div>
                <div class="panel-body">

                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label col-md-4">Name</label>
                                <div class="col-md-8">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label col-md-4">DOJ</label>
                                <div class="col-md-8">
                                    <asp:Label ID="lblDOJ" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-4">

                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Branch</label>

                                <div class="col-md-8">
                                    <asp:Label ID="lblBranch" runat="server"></asp:Label>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label col-md-4">Department</label>
                                <div class="col-md-8">
                                    <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label col-md-4">Designation</label>
                                <div class="col-md-8">
                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-4">

                            <div class="form-group" runat="server" visible="false">
                                <label class="control-label col-md-4" for="empcode">Purpose of Leaving</label>

                                <div class="col-md-8">
                                    <asp:Label ID="lblReasonofleaving" runat="server" />
                                </div>
                            </div>

                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label col-md-4">Last Day of Employement</label>
                                <div class="col-md-8">
                                    <asp:Label ID="lblDOL" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label col-md-4">Gross Salary</label>
                                <div class="col-md-8">
                                    <asp:Label ID="lblGrossSalary" runat="server" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>


            <div class="panel panel-default">
                <div class="panel-heading">Salary Payable Days</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Total days payable</label>
                                <div class="col-md-4">
                                    <asp:TextBox
                                        ID="txtTotalDayPayable"
                                        runat="server"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:CheckBox ID="ckd_salary_days" runat="server" OnCheckedChanged="ckd_salary_days_CheckedChanged"  AutoPostBack="true"/>
                                </div>
                                <div class="col-md-4">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button
                                        ID="btnTotalDayPayableView"
                                        runat="server"
                                        Text="View" CssClass="btn btn-info btn-sm" Visible="false" />

                                    <asp:Button
                                        ID="btnTotalDayPayableCalc"
                                        runat="server"
                                        Text="Calc" CssClass="btn btn-info btn-sm" Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">Leave Payable Days</div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Total leave payable/recoverable</label>
                                <div class="col-md-4">
                                    <asp:TextBox
                                        ID="txtTotalLeavePayable"
                                        runat="server"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:CheckBox ID="ckd_totalleavepayable" runat="server" OnCheckedChanged="ckd_totalleavepayable_CheckedChanged" AutoPostBack="true" />
                                </div>
                                <div class="col-md-4">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button
                                        ID="btnTotalLeavePayableView"
                                        runat="server"
                                        Text="View" CssClass="btn btn-info btn-sm" Visible="false" />

                                    <asp:Button
                                        ID="btnTotalLeavePayableCalc"
                                        runat="server"
                                        Text="Calc" CssClass="btn btn-info btn-sm" Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">Gratuity Payable Days</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Total end of Service Gratuity Payable - 1 to 5 years-21 days per year</label>
                                <div class="col-md-4">
                                    <asp:TextBox
                                        ID="txtGratuity1to5"
                                        runat="server"
                                        CssClass="form-control"></asp:TextBox>
                                    <asp:CheckBox ID="ckd_txtGratuity1to5" runat="server" OnCheckedChanged="ckd_txtGratuity1to5_CheckedChanged" AutoPostBack="true" />
                                </div>
                                <div class="col-md-4">
                                    &nbsp;
                                    
                                    <asp:Button
                                        ID="btnGratuity1to5Calc"
                                        runat="server"
                                        Text="Calc" CssClass="btn btn-info btn-sm" Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Total end of Service Gratuity Payable- From 6th year-30 days per year</label>
                                <div class="col-md-4">
                                    <asp:TextBox
                                        ID="txtGratuity6to30"
                                        runat="server"
                                        CssClass="form-control"></asp:TextBox>
                                     <asp:CheckBox ID="ckd_txtGratuity6to30" runat="server" OnCheckedChanged="ckd_txtGratuity6to30_CheckedChanged" AutoPostBack="true" />
                                </div>
                                <div class="col-md-4">
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">Any Other Allowance</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Select Allowance</label>
                                <div class="col-md-4">
                                    <asp:DropDownList
                                        ID="ddlVariableAllowance"
                                        runat="server"
                                        CssClass="form-control"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlVariableAllowance_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Amount</label>
                                <div class="col-md-4">
                                    <asp:TextBox
                                        ID="txtAmount"
                                        runat="server"
                                        CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-8" for="empcode">
                                    <asp:Button
                                        ID="btnAdd"
                                        runat="server"
                                        Text="Add"
                                        CssClass="btn btn-info btn-sm pull-right"
                                        OnClick="btnAdd_Click" />
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group" style="padding: 20px;">

                                <asp:GridView
                                    ID="gridAllowance"
                                    runat="server"
                                    AutoGenerateColumns="false" CssClass="table table-bordered">
                                    <Columns>
                                        <asp:TemplateField HeaderText="AllowanceId">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem,"AllowanceId") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Allowance Name">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem,"AllowanceName") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem,"Amount") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">Process Final Salary</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">
                                    <asp:Button ID="btnProcessSalary"
                                        runat="server"
                                        Text="Process Salary"
                                        CssClass="btn btn-success"
                                        OnClick="btnProcessSalary_Click" />
                                </label>
                                <div class="col-md-4">
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">Earnings</div>
                                <div class="panel-body">
                                    <asp:GridView
                                        ID="gridEarnings"
                                        runat="server"
                                          EmptyDataText="No data found"
                                        AutoGenerateColumns="false"
                                        CssClass="table table-bordered"
                                        ShowFooter="true"
                                        OnRowDataBound="gridEarnings_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="AllowanceId">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem,"AllowanceId") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Allowance Name">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem,"AllowanceName") %>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <b>Gross Earning (AED)</b>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem,"Amount") %>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblGrossTotal" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">Deducations</div>
                                <div class="panel-body">
                                    <asp:GridView
                                        ID="gridDeduction"  EmptyDataText="No data found"
                                        runat="server"
                                        AutoGenerateColumns="false"
                                        CssClass="table table-bordered"
                                        ShowFooter="true"
                                        OnRowDataBound="gridDeduction_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="AllowanceId">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem,"AllowanceId") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Allowance Name">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem,"AllowanceName") %>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <b>Total Deduction (AED)</b>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem,"Amount") %>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblDeduction" runat="server"></asp:Label>

                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-6" for="empcode">Net Payable Amount (AED)</label>
                                <div class="col-md-2">
                                    <asp:Label ID="lblNet" runat="server"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>


              <div class="panel panel-default">
                <div class="panel-heading">Payment Mode</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Payment Mode</label>
                                <div class="col-md-4">
                                    <asp:DropDownList
                                        ID="ddl_PMode"
                                        runat="server"
                                        CssClass="form-control">
                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                         <asp:ListItem Text="PAYROLL" Value="PAYROLL"></asp:ListItem>
                                         <asp:ListItem Text="SEPERATE" Value="SEPERATE"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                  
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-4" for="empcode">Amount</label>
                                <div class="col-md-4">
                                    <asp:TextBox
                                        ID="txt_amt"
                                        runat="server"
                                        CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="pull-right">
                <asp:Button ID="btnSubmitBottom" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            </div>
        </form>
    </div>
</body>
</html>
