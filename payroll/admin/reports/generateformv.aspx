<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeFile="generateformv.aspx.cs"
    Inherits="payroll_admin_reports_generateformv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../css/main.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Generate Salary Sheet</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                </div>
                            </div>
                            <div class="widget-body">

                                <fieldset>

                                    <div class="control-group">
                                        <label class="control-label">Branch</label>
                                        <div class="controls">
                                            <asp:DropDownList
                                                ID="ddlBranch"
                                                runat="server"
                                                CssClass="span4"
                                                AppendDataBoundItems="true"
                                                DataSourceID="Sql1"
                                                DataTextField="branch_name"
                                                DataValueField="branch_id">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator1"
                                                runat="server"
                                                ControlToValidate="ddlBranch"
                                                Display="Dynamic"
                                                SetFocusOnError="True" ToolTip="Select Branch"
                                                ValidationGroup="c"
                                                InitialValue="0">
                                                        <img src="../../img/error1.gif" alt="" />
                                            </asp:RequiredFieldValidator>

                                            <asp:SqlDataSource
                                                ID="Sql1"
                                                runat="server"
                                                ConnectionString="<%$connectionStrings:ConnectionString %>"
                                                SelectCommand="select branch_id, branch_name from tbl_intranet_branch_detail"
                                                SelectCommandType="Text"
                                                ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Financial Year</label>
                                        <div class="controls">
                                            <asp:DropDownList
                                                ID="ddlFinYear"
                                                runat="server"
                                                CssClass="span4"
                                                AppendDataBoundItems="true">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator2"
                                                runat="server"
                                                ControlToValidate="ddlFinYear"
                                                Display="Dynamic"
                                                InitialValue="0"
                                                SetFocusOnError="True" ToolTip="Select Financial Year"
                                                ValidationGroup="c">
                                                        <img src="../../img/error1.gif" alt="" />
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Month</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlMonth"
                                                runat="server"
                                                CssClass="span4"
                                                AppendDataBoundItems="true">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem>Jan</asp:ListItem>
                                                <asp:ListItem>Feb</asp:ListItem>
                                                <asp:ListItem>Mar</asp:ListItem>
                                                <asp:ListItem>Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>Jul</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sep</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator3"
                                                runat="server"
                                                ControlToValidate="ddlMonth"
                                                Display="Dynamic"
                                                InitialValue="0"
                                                SetFocusOnError="True" ToolTip="Select Month"
                                                ValidationGroup="c">
                                                        <img src="../../img/error1.gif" alt="" />
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                    <div class="form-actions no-margin">
                                        <asp:Button
                                            ID="btnSalSheet"
                                            runat="server"
                                            CssClass="btn btn-primary"
                                            OnClick="btnSalSheet_Click"
                                            Text="Generate"
                                            ValidationGroup="c" />                                      
                                        
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
