<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleavepolicy.aspx.cs" Inherits="leave_editleavepolicy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                     <div class="page-header">
                            <div class="pull-left">
                                <h2> Leave Policy </h2>
                            </div>
                            
                            <div class="clearfix"></div>
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
                                            <asp:GridView ID="policygrid" runat="server" DataKeyNames="policyid" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                OnRowDeleting="policygird_RowDeleting1" OnPreRender="policygrid_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Policy Id" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("policyid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Policy Name" HeaderStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l7" runat="server" Text='<%# Bind ("policyname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Policy File" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <a href="upload/policydockit/<%#DataBinder.Eval(Container.DataItem,"policy_file_name")%>" target="_blank" class="link05" ><img src="images/m.png"  border="0"></td>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="File Type" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("policy_file_type")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Uploaded Date" HeaderStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("date") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="12%">
                                                        <ItemTemplate>
                                                            <a class="link05" href="UpdateLeavePolicy.aspx?policyid=<%#DataBinder.Eval(Container.DataItem, "policyid")%>" target="_self"><i class="icon-pencil"></i></a>|
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');" CommandName="Delete"><i class="icon-remove"></i>
                                                             </asp:LinkButton>
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
                  <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#policygrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
