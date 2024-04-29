<%@ Page Language="C#" AutoEventWireup="true" CodeFile="processleavemonthly.aspx.cs" Inherits="leave_processleavemonthly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <%--<script type="text/javascript">
        function ValidateDate() {
            var leavename = document.getElementById('<%=txt_leave_type.ClientID %>');
            var displayname = document.getElementById('<%=txt_display_name.ClientID %>');
            if (leavename.value == "") {
                alert("Please enter leave name");
                return false;
            }
            if (displayname.value == "") {
                alert("Please enter display name");
                return false;
            }
            return true;
        }
    </script>--%>
</head>
<body>
     <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Process Leave Monthly</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Process Leave Monthly
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Select Leave Calender</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddl_Cal" runat="server" CssClass="span4" OnSelectedIndexChanged="ddl_Cal_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                           
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_Cal" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Calender Id" 
                                                        ValidationGroup="p" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                 </div>
                                             
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Select Leave Policy</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddl_policy" runat="server" CssClass="span4" OnSelectedIndexChanged="ddl_policy_SelectedIndexChanged" AutoPostBack="true" >
                                                   
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_policy" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Policy" 
                                                        ValidationGroup="p" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Select Leave Type</label>
                                            <div class="controls">
                                               <asp:DropDownList ID="ddl_type" runat="server" CssClass="span4" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                           
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_type" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Leave Type" 
                                                        ValidationGroup="p" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                 </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Process Leave Month</label>

                                        <div class="controls">
                                            <asp:DropDownList
                                                ID="ddl_months"
                                                runat="server"
                                                CssClass="span4"
                                                AppendDataBoundItems="true">
                                                <%--Enabled="false"--%>

                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="Sep"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                                            </asp:DropDownList>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_months" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Month" 
                                                        ValidationGroup="p" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>

                                           
                                        </div>


                                           <div class="control-group">
                                            <label class="control-label">Creadit Days</label>
                                            <div class="controls">
                                             <asp:TextBox ID="txt_days" Enabled="false" runat="server" CssClass="span4" ></asp:TextBox>
                                                 </div>
                                        </div>
                                        </div>

                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnsbmit" runat="server" Text="Process"  ValidationGroup="p" CssClass="btn btn-primary" OnClick="btnsbmit_Click"  ToolTip="Click to submit the created leave" />&nbsp;&nbsp; <%--OnClientClick="return ValidateDate();"--%>
                                         
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
