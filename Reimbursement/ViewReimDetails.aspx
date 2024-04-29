<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewReimDetails.aspx.cs" Inherits="Reimbursement_ViewReimDetails" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function RefeshWindow() {
            window.opener.location.reload();
            window.close();
        }
    </script>
    <style>
        .center
        {
            position: absolute;
            top: 100px;
            left: 200px;
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                    <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="updatepanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                                <div class="modal-backdrop fade in">
                                    <div class="center">
                                        Please Wait...
                                    </div>
                                </div>
                            </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                             <h2>Reimbursement Details</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>


                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label3" runat="server" Text="View"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="widget-body">

                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                DataKeyNames="RDID" OnPreRender="grd_PreRender" OnRowDataBound="grd_RowDataBound" ShowFooter="true">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="RDID" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbrdid" runat="server" Text='<%#Eval("RDID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Name" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                           <FooterTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text="Total Amount" ></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Units" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("Units")%>'></asp:Label>
                                                        </ItemTemplate>
                                                     
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblammt" runat="server" Text='<%#Eval("Ammount")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lbltotalammount" runat="server" Font-Bold="true"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    
                                                     <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                             <a href="../upload/employeedocuments/<%#DataBinder.Eval(Container.DataItem,"Attachment")%>" target="_blank" class="link05" >
                                                                <asp:Label ID="lblAttachment"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Attachment")%>'   Visible="TRUE"></asp:Label>
                                                                <asp:Label ID="aViewFile" runat="server" >



                                                                      <%-- <a href="upload/policydockit/<%#DataBinder.Eval(Container.DataItem,"policy_file_name")%>" target="_blank" class="link05" >
                                                                           <img src="images/m.png"  border="0"></td>--%>
                                                                   <%--   <asp:Image ID="Image14" runat="server"  Text="&lt;img src='images/view.png'/&gt;" ></asp:Image>--%>
                                                                   
                                                                </asp:Label>
                                                                
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcomments" runat="server" Text='<%#Eval("user_comments")%>'></asp:Label>
                                                        </ItemTemplate>
                                                     
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                            <div class="clearfix"></div>
                                            <asp:HiddenField ID="hdnamount" runat="server" Value="0" />
                                        </div>

                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Approved Final Amount</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtfinalammount" runat="server" CssClass="span4" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;">0.0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfinalammount" ToolTip="Enter Final Amount"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Comments</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdesc" runat="server" CssClass="span4" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdesc" ToolTip="Enter Comments"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblorginal" runat="server" CssClass="span4" Visible="false"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnapprove" runat="server" CssClass="btn btn-primary" ValidationGroup="c" Text="Approve" OnClick="btnapprove_Click" />
                                                <asp:Button ID="btnreject" runat="server" CssClass="btn btn-primary" ValidationGroup="v" Text="Reject" OnClick="btnreject_Click" />
                                                 <asp:Button ID="btnbck" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnbck_Click" />
                                            </div>
                                        </fieldset>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_Emp').dataTable({
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
    </form>
</body>
</html>
