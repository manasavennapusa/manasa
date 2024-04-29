<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DaylightandStandardDates.aspx.cs" Inherits="attendance_DaylightandStandardDates" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <script src="js/timepicker.js"></script>
    
</head>
<body>
    <form id="myForm" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">

        </asp:ScriptManager>
        <asp:HiddenField ID="hdnId" runat="server" Value="0" />
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Daylight And Standard Dates</h2>
                                </div>
                              
                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Daylight And Standard Dates
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Date Type</label>
                                                <div class="controls">
                                                    <asp:DropDownList
                                                ID="ddlDateType"
                                                runat="server">
                                                <asp:ListItem Value="ST">Standard Time</asp:ListItem>
                                                <asp:ListItem Value="DT">Daylight Time</asp:ListItem>
                                            </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">From Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtFromDate"  runat="server"></asp:TextBox>
                                                     <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                            <cc1:CalendarExtender
                                                                ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txtFromDate">
                                                            </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">To date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txttodate" runat="server"></asp:TextBox>
                                                     <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                            <cc1:CalendarExtender
                                                                ID="CalendarExtender2" runat="server" PopupButtonID="Image1" TargetControlID="txttodate">
                                                            </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            
                                            
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="btn btn-info  " OnClick="Button3_Click" OnClientClick="return ValidateData()" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;
                                                
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Daylight And Standard Dates
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                <%-- <div class="fontrol-group">--%>
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView
                                        ID="grid"
                                        runat="server"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                        DataKeyNames="id"
                                        OnRowEditing="grid_RowEditing" OnRowDeleting="grid_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl#">
                                                <ItemTemplate>
                                                    <%#  Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DateType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateType" runat="server" Text='<%#Eval("datetype")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="From Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("fromdate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("todate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="link05" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="link05" CommandName="Delete"><i class="icon-remove"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                    <%--</div>--%>
                                </div>
                            </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        function ValidateData() {
            var datetype = document.getElementById('<%=ddlDateType.ClientID %>');
            var fromdate = document.getElementById('<%=txtFromDate.ClientID %>');
            var todate = document.getElementById('<%=txttodate.ClientID %>');
            if (datetype.value == 0) {
                alert("Please Select DateType");
                return false;
            }


            if (fromdate.value == "") {
                alert("Please Enter Shift Start Time");
                return false;
            }
            if (todate.value == "") {
                alert("Please Enter Shift End Time");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
