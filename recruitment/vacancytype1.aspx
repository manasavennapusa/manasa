<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vacancytype1.aspx.cs" Inherits="recruitment_vacancytype1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
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

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Vacancy Type</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Create Expected CTC"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div class="control-group">
                                            <label class="control-label">Vacancy Type</label>
                                            <div class="controls">
                                               <asp:TextBox ID="txtvacancytype" runat="server" CssClass="span10" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtvacancytype"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Vacancy Type" ValidationGroup="c"
                                                    Width="6px"><img 
                                                            src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator13" runat="server" ValidationGroup="c" ToolTip="Enter only Alphabets and space"
                                                    SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtvacancytype"
                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>

                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Description</label>
                                            <div class="controls">
                                               <asp:TextBox ID="txtdesc" runat="server" CssClass="span10" MaxLength="500" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions no-margin" style="text-align: right">
                                      <%--  <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="c"
                                            OnClick="btnSubmit_Click" />--%>
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="c" OnClick="btnSubmit_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>CTC Range       
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="gridvacancytype1" runat="server" DataKeyNames="id" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                EmptyDataText="No Data Found" OnPreRender="gridvacancytype1_PreRender" OnRowDeleting="gridvacancytype1_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Vacancy Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblvacanytype" runat="server" Text='<%#Eval("vacancytype")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("description")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/vacancytype1.aspx?Id={0}"
                                                        Text="Edit"></asp:HyperLinkField>

                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                Text="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <%-- <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>--%>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdCTCrange').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>

