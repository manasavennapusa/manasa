<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Emplyestatus.aspx.cs" Inherits="admin_Emplyestatus" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head2" runat="server">


    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <%--   <script src="../js/html5-trunk.js" type="text/javascript"></script>--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star
        {
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
    <script src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#wizard").bwizard();
        });
    </script>
    <script src="../js/JavaScriptValidations.js"></script>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin" style="background-color:whitesmoke;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%-- <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="updatepannel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        <div class="dashboard-wrapper" style="margin-left: 0px;background-color:whitesmoke;">
            <%--  <asp:UpdatePanel ID="updatepannel1" runat="server">
                <ContentTemplate>--%>
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Status Update</h2>
                        <div class="clearfix"></div>
                    </div>
                   
                        <div class="control-group">
                            <div class="controls">
                                <div class="column">
                                    <div style="float: right">
                                       <%-- <div class="span2">
                                            <asp:RadioButton ID="chkemployee" runat="server" GroupName="Check" Text="Employee" OnCheckedChanged="chkemployee_CheckedChanged" Checked="true" AutoPostBack="true" />
                                        </div>--%>
                                       <%-- <div class="span2">
                                            <asp:RadioButton ID="chkClients" runat="server" GroupName="Check" Text="Clients" OnCheckedChanged="chkClients_CheckedChanged" AutoPostBack="true" />
                                        </div>--%>
                                    </div>

                                </div>
                            </div>
                        </div>
                </div>


            
                
                <div class="row-fluid" id="divemployee" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <b>View</b>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="empgrid"
                                        runat="server"
                                        DataKeyNames="empcode"
                                        AutoGenerateColumns="False"
                                        EmptyDataText="No such employee exists !"
                                        class="table table-condensed table-striped table-hover table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comment">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("Comment") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Role">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("Role") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Eval("Approverstatus").ToString()=="1"?"Approved" :Eval("Approverstatus").ToString()=="2"?"Rejected":"Pending" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                            <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="viewedbdeatilspage.aspx?empcode={0}"
                                                NavigateUrl="admin/viewedbdeatilspage.aspx" Text="&lt;img src='images/View.png'/&gt;">

                                                <HeaderStyle CssClass="" />
                                                <ControlStyle CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" Width="50%" />
                                            </asp:HyperLinkField>
                                 
                                        </Columns>
                                        <HeaderStyle CssClass="" />
                                        <FooterStyle CssClass="" />
                                        <RowStyle Height="5px" />
                                        <PagerStyle CssClass=""></PagerStyle>
                                    </asp:GridView>

                                    <div class="clearfix"></div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>


            </div>
            <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

    </form>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#empgrid').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>


