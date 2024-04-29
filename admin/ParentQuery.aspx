<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParentQuery.aspx.cs" Inherits="Masters_ParentQuery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet">

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
                    <div class="pull-left">
                        <asp:Label ID="lblheadingcreate" runat="server"><h2> Parent Query Type</h2></asp:Label>
                        <asp:Label ID="lblheadingedit" runat="server"><h2> Parent Query Type</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <asp:Label ID="lblheading" runat="server">Create</asp:Label>
                                      
                                </div>
                            </div>

                            <div class="widget-body">
                                <fieldset>
                                  <%--  <div class="control-group">
                                        <label class="control-label">Department Name<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlDeptName" runat="server" Width="20%" CssClass="span4">
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDeptName"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department Name" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtDepartmentName"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                      <%--  </div>
                                    </div>--%>
                                    <div class="control-group">
                                        <label class="control-label">Parent Query Name<span class="star">*</span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtparentquery"  Width="20%"
                                                runat="server"
                                                CssClass="span4"
                                                onkeypress="return isAlphaNumeric();">
                                            </asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtparentquery" 
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Parent Query Name Required" ValidationGroup="c"
                                                        Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    

                                    <div class="form-actions no-margin">
                                        <div style="padding-left: 45px; padding-right: 80px;">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="c" OnClick="btnSubmit_Click"></asp:Button>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" ValidationGroup="c" OnClick="btnUpdate_Click"></asp:Button>
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click"></asp:Button>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid" id="grid_query" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span> View               
                                           
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="gvQuery" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                        EmptyDataText="No Data Exists" DataKeyNames="pquery_Id" OnPreRender="gvQuery_PreRender" OnRowDeleting="gvQuery_RowDeleting" OnRowEditing="gvQuery_RowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Parent Query ID" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeptId" runat="server" Text='<%#Eval("pquery_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Department Name" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeptName" runat="server" Text='<%#Eval("dept_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Parent Query Name" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQueryName" runat="server" Text='<%#Eval("parntquery_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Description" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldescrition" runat="server" Text='<%#Eval("descripetion")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--<asp:Button ID="lnkbtnEdit" runat="server" CommandName="Edit" ControlStyle-CssClass="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone" Text="Edit"></asp:Button>--%>
                                                    <asp:ImageButton ID="lnkbtnEdit" runat="server" CommandName="Edit" ImageUrl="~/images/edit.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--<asp:Button ID="lnkbtnDelete" runat="server" CommandName="Delete" ControlStyle-CssClass="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone" Text="Delete" OnClientClick="return confirm('Are you sure to Delete this entry?')"></asp:Button>--%>
                                                    <asp:ImageButton ID="lnkbtnDelete" runat="server" CommandName="Delete" ImageUrl="~/images/download_delete.png" Width="40px" OnClientClick="return confirm('Are you sure to Delete this entry?')" />
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
        </div>

    </form>
</body>
</html>

