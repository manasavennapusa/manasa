<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllqueryStatus.aspx.cs" Inherits="Query_AllqueryStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <style type="text/css">
        .star {
            content: "*";
            margin-left: 5px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnId" runat="server" />

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <asp:Label ID="lblheadingcreate" runat="server"><h2>View All Query Status</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    All Query Status
                                </div>
                            </div>
                <div class="row-fluid">
                    <div class="span12">  

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>
                                       <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                     <div style="  padding: 5px;  font-size: 16px;">
                                    Search : <asp:TextBox ID="TextBox1" runat="server" width="15%" Font-Size="15px" onkeyup="Search_Gridview(this, 'suggestionsgrid')"></asp:TextBox>
                                       </div>
                                    <asp:GridView ID="suggestionsgrid" runat="server" Width="100%" AutoGenerateColumns="False" style="border-right:1px solid #eaeaea"
                                        DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnPageIndexChanging="suggestions_PageIndexChanging" EmptyDataText="No records found!"
                                        ToolTip="Read Feedback" AllowPaging="true" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                        OnRowEditing="suggestionsgrid_RowEditing" OnRowDeleting="suggestionsgrid_RowDeleting" OnRowCancelingEdit="suggestionsgrid_RowCancelingEdit"
                                        OnRowUpdating="suggestionsgrid_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Empcode" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "empCode")%>'></asp:Label>
                                                    <%--<%#DataBinder.Eval(Container.DataItem, "empCode")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Posted By">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "postedby")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldept" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "deptName")%>'></asp:Label>
                                                    <%--<%#DataBinder.Eval(Container.DataItem, "deptName")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Query Type">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "queryTypeName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ticket Type">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "tickettype")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Priority">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "priority")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <a href="ViewqueryDetail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                        target="_self" class="link05">
                                                        <%#DataBinder.Eval(Container.DataItem, "description")%>...</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "status")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlapprovalstatus" runat="server" Width="95px" SelectedValue='<%#Bind("status1")%>' CssClass="blue1" Height="29px">
                                                       <asp:ListItem Value="0">Open</asp:ListItem>
                                                        <asp:ListItem Value="1">Close</asp:ListItem>
                                                        <asp:ListItem Value="2">Under Review</asp:ListItem>
                                                        <asp:ListItem Value="3">Scrap</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Posted Date">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Closed Date">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "approvedDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Code - Approver Name">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "approverCode")%><b>-</b> <%#DataBinder.Eval(Container.DataItem, "emp_fname")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comment">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "comment")%>
                                                </ItemTemplate>
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_cmnt" runat="server" TextMode="MultiLine" Text='<%#DataBinder.Eval(Container.DataItem, "comment")%>'></asp:TextBox>
                                                 </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Code" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppvrCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "approverCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Name" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppvrName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "emp_fname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')" CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                    | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                </EditItemTemplate>

                                                <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                    | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')" CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
    
                    </div>
                </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
     <script type="text/javascript">
         function Search_Gridview(strKey, strGV) {
             var strData = strKey.value.toLowerCase().split(" ");
             var tblData = document.getElementById(strGV);
             var rowData;
             for (var i = 1; i < tblData.rows.length; i++) {
                 rowData = tblData.rows[i].innerHTML;
                 var styleDisplay = 'none';
                 for (var j = 0; j < strData.length; j++) {
                     if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                         styleDisplay = '';
                     else {
                         styleDisplay = 'none';
                         break;
                     }
                 }
                 tblData.rows[i].style.display = styleDisplay;
             }
         }
    </script>
</body>
</html>
