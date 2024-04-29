<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HRmangerapprove.aspx.cs" Inherits="Reimbursement_HRmangerapprove" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
</head>
<body>
    <form id="myForm" runat="server">

        <script type="text/javascript">
            function isKey(keyCode) {
                return false;
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Reimbursement Detials</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search 
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>

                                    <div class="control-group">
                                        <label class="control-label">Reimbursement Status</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drp_leavestatus" runat="server" CssClass="span3" Width="">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>                                               
                                                <asp:ListItem Value="2">Pending</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="4">Approved</asp:ListItem>
                                                <%--  <asp:ListItem Value="1">Rejected</asp:ListItem>
                                                --%>
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" OnClick="btn_search_Click" Text="Search" OnClientClick="return ValidateData();" />

                                        <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info" OnClick="btn_reset_Click" Text="Reset" ValidationGroup="c" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <%--  </ContentTemplate>
                    </asp:UpdatePanel>--%>

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

                                        <asp:GridView ID="grdpending" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                            DataKeyNames="RID" OnPreRender="grdpending_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="RID" HeaderStyle-Width="10%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbrid" runat="server" Text='<%#Eval("RID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Type")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approver Code" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblapprovercode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pending Level" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("level")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:HyperLinkField DataNavigateUrlFields="RID" HeaderText="View" DataNavigateUrlFormatString="PendingClosed.aspx?RID={0}"
                                                    NavigateUrl="PendingClosed.aspx" Text="&lt;img src='images/view.png'/&gt;">
                                                    <HeaderStyle CssClass="" />
                                                    <ControlStyle CssClass="link05" Width="50%" />
                                                </asp:HyperLinkField>
                                            </Columns>
                                        </asp:GridView>


                                        <%--      <asp:GridView ID="grdreim" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                DataKeyNames="RID" OnPreRender="grdreim_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="RDID" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbrid" runat="server" Text='<%#Eval("RID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="level" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("level")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText=" Name" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblbranch" runat="server" Text='<%#Eval("Comments")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                   <asp:HyperLinkField DataNavigateUrlFields="RID" HeaderText="View" DataNavigateUrlFormatString="EditEmpReimbursement.aspx?RID={0}"
                                                NavigateUrl="EditEmpReimbursement.aspx" Text="&lt;img src='images/view.png'/&gt;">
                                                           <HeaderStyle CssClass=""  />
                                                <ControlStyle CssClass="link05" Width="50%" />
                                            </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>--%>

                                        <asp:GridView ID="grdpending1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                            DataKeyNames="RID" OnPreRender="grdpending1_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="RID" HeaderStyle-Width="10%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbrid" runat="server" Text='<%#Eval("RID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:HyperLinkField DataNavigateUrlFields="RID" HeaderText="View" DataNavigateUrlFormatString="PendingClosed.aspx?RID={0}"
                                                    NavigateUrl="PendingClosed.aspx" Text="&lt;img src='images/view.png'/&gt;">
                                                    <HeaderStyle CssClass="" />
                                                    <ControlStyle CssClass="link05" Width="50%" />
                                                </asp:HyperLinkField>
                                            </Columns>
                                        </asp:GridView>



                                        <div class="clearfix"></div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#empleavegrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

