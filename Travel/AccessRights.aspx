<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessRights.aspx.cs" Inherits="Travel_AccessRights" %>

<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../img/loading.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Access Rights Master</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                           Access Rights
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                           
                                            <div class="control-group">
                                                <label class="control-label">Travel Type</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_traveltype" CssClass="span4" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                        <asp:ListItem Value="D">Domestic</asp:ListItem>
                                                        <asp:ListItem Value="I">International</asp:ListItem>
                                                    </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_traveltype" ToolTip="Select Travel Type" InitialValue="0"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Access Rights For</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_approversfor" CssClass="span4" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                        <asp:ListItem Value="Travel">Travel</asp:ListItem>
                                                        <asp:ListItem Value="Expense">Expense</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_approversfor" ToolTip="Select Approvers For" InitialValue="0"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Level</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_level" CssClass="span4" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_level" ToolTip="Select level" InitialValue="0"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                          
                                             <div class="control-group">
                                                <label class="control-label">  Access Rights</label>
                                                <div class="controls">
                                                    <asp:CheckBox ID="chk_approve" CssClass="checkbox inline" Text="Approve" runat="server" />
                                                    <asp:CheckBox ID="CheckBox1" CssClass="checkbox inline" Text="Reject" runat="server" />
                                                    <asp:CheckBox ID="CheckBox2" CssClass="checkbox inline" Text="Edit" runat="server" />
                                                    <asp:CheckBox ID="CheckBox3" CssClass="checkbox inline" Text="Raise excemption" runat="server" />
                                                    <asp:CheckBox ID="CheckBox4" CssClass="checkbox inline" Text="Approve Excemption" runat="server" />
                                                    <asp:CheckBox ID="CheckBox6" CssClass="checkbox inline" Text="Reject Excemption" runat="server" />
                                                    <asp:CheckBox ID="CheckBox5" CssClass="checkbox inline" Text="Sanction Advance" runat="server" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_level" ToolTip="Select level" InitialValue="0"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Access Rights
                
                                           
                                        </div>
                                         <div style="float:right">
                                                <asp:Button ID="btn_resetgrid" runat="server" CssClass="btn btn-primary" ValidationGroup="onone" Visible="false"
                                                    Text="Reset Grid" OnClick="btn_greset_Click" />
                                            </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="approvalgrid" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left" DataKeyNames="empcode">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Emp Code" HeaderStyle-Width="24%">

                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name" HeaderStyle-Width="24%">

                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level" HeaderStyle-Width="24%">

                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("level") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                                <RowStyle Height="5px" />
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hidd_name" runat="server" />
                            <asp:HiddenField ID="hiddenlevel" runat="server" Value="1" />
                        </div>

                        <div class="form-actions no-margin" style="text-align:right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="btn btn-primary"
                                ValidationGroup="a"></asp:Button>
                             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn"
                                OnClick="btnCancel_Click"></asp:Button>
                        </div>
                    </div>
                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
