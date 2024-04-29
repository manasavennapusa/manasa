<%@ Page Language="C#" AutoEventWireup="true" CodeFile="raiseticket.aspx.cs" Inherits="Query_raiseticket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />

    <style type="text/css">
        .star {
            content: " *";
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
                    <div id="divCreate" runat="server" class="pull-left">
                        <h2>Create Query</h2>
                    </div>
                    <div id="divEdit" runat="server" class="pull-left">
                        <h2>Edit Query</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Query Form
                                </div>
                            </div>

                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Parent Query Name<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlDeptName" runat="server" Width="20%" CssClass="span4" AutoPostBack="true" OnSelectedIndexChanged="ddlDeptName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDeptName"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department Name" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtDepartmentName"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Query Type<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlQueryType" runat="server" Width="20%" CssClass="span4">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Ticket Type<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlTicketType" runat="server" Width="20%" CssClass="span4">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem>Question</asp:ListItem>
                                                <asp:ListItem>Issue</asp:ListItem>
                                                <asp:ListItem>Request</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="control-group">
                                        <label class="control-label">Priority<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlpriority" runat="server" Width="20%" CssClass="span4">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem>High</asp:ListItem>
                                                <asp:ListItem>Medium</asp:ListItem>
                                                <asp:ListItem>Low</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group" runat="server" id="restatus" visible="false">
                                        <label class="control-label">Status<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlstatus" runat="server" Width="20%" CssClass="span4">
                                                 <asp:ListItem Value="2">--Select--</asp:ListItem>
                                                <asp:ListItem Value="0">Re-open</asp:ListItem>
                                                <asp:ListItem Value="1">Close</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Posted Date</label>
                                        <div class="controls">
                                            <asp:Label ID="lblPostedDate" runat="server" Text="" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Refrence No.</label>
                                        <div class="controls">
                                            <asp:Label ID="lblRefNo" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Description<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtdescription" TextMode="MultiLine" Width="20%"
                                                runat="server"
                                                CssClass="span4"
                                                onkeypress="return isAlphaNumeric();">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin">
                                        <div style="padding-left: 45px; padding-right: 85px;">
                                            <asp:Button ID="btnSubmit"
                                                runat="server"
                                                Text="Submit"
                                                CssClass="btn btn-primary"
                                                ValidationGroup="v" OnClick="btnSubmit_Click"></asp:Button>
                                            <asp:Button ID="btnUpdate"
                                                runat="server"
                                                Text="Update"
                                                CssClass="btn btn-primary"
                                                ValidationGroup="v" OnClick="btnUpdate_Click"></asp:Button>
                                            <asp:Button ID="btnReset"
                                                runat="server"
                                                Text="Reset"
                                                CssClass="btn btn-primary"
                                                ValidationGroup="v" OnClick="btnReset_Click"></asp:Button>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Query Types               
                                           
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="gvQuery" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                        EmptyDataText="No Data Exists" DataKeyNames="query_Id" OnPreRender="gvQuery_PreRender" OnRowDeleting="gvQuery_RowDeleting" OnRowEditing="gvQuery_RowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Query ID" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeptId" runat="server" Text='<%#Eval("query_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department Name" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeptName" runat="server" Text='<%#Eval("dept_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Query Name" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQueryName" runat="server" Text='<%#Eval("query_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Description" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldescrition" runat="server" Text='<%#Eval("descripetion")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton
                                                        ID="lnkbtnEdit"
                                                        runat="server"
                                                        CommandName="Edit"
                                                        CssClass="link04"
                                                        Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton
                                                        ID="lnkbtnDelete"
                                                        runat="server"
                                                        CommandName="Delete"
                                                        CssClass="link04"
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
                </div>--%>
            </div>
        </div>

    </form>
</body>
</html>
