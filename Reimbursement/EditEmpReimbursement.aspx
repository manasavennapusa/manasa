<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditEmpReimbursement.aspx.cs" Inherits="Reimbursement_EditEmpReimbursement" %>


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
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel2" runat="server">
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <%-- <h2>Reimbursement Details</h2>--%>
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
                                            <asp:Label ID="Label3" runat="server" Text=" Reimbursement Details"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="widget-body">

                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" 
                                                DataKeyNames="RDID" OnPreRender="grd_PreRender" OnRowDataBound="grd_RowDataBound" ShowFooter="true" OnRowEditing="grd_RowEditing" OnRowCancelingEdit="grd_RowCancelingEdit" OnRowUpdating="grd_RowUpdating" OnRowDeleting="grd_RowDeleting">
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
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtammount" runat="server" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;" Text='<%#Eval("Ammount")%>' Width="100px" ></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lbltotalammount" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAttachment" runat="server" Text='<%#Eval("Attachment")%>' Visible="false"></asp:Label>
                                                            <a href="../upload/employeedocuments/<%#DataBinder.Eval(Container.DataItem,"Attachment")%>" target="_blank" class="link05">View File</a></td>

                                                        </ItemTemplate>
                                                         <EditItemTemplate>
                                                            <asp:FileUpload ID="fpup" runat="server" />
                                                            <asp:Label ID="lblAttachment1" runat="server" Text='<%#Eval("Attachment")%>' Visible="false"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Edit/Delete" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" />
                                                            <span onclick="return confirm('Are you sure want to delete?')">
                                                                <asp:LinkButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" />
                                                            </span>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="btnUpdate" Text="Update" runat="server" CommandName="Update" />
                                                            <asp:LinkButton ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel" />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                            <div class="clearfix"></div>
                                        </div>

                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            
                                            <div class="control-group" >
                                                <label class="control-label">Comments</label>
                                                <div class="controls">
                                                    <asp:Label ID="lblcommnets" runat="server" CssClass="span4" TextMode="MultiLine"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnapprove" runat="server" CssClass="btn btn-primary" Text="Send" OnClick="btnapprove_Click" />
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
