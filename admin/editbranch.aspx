<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editbranch.aspx.cs" Inherits="Admin_Company_createcompany"
    Title="Create Company" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->
<html lang="en">
<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2> Work Location </h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            Edit
                                        </div>
                                    </div>
                                                <fieldset>
                                                    <br>
                                                    <br></br>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        Company Name</label>
                                                        <div class="controls">
                                                              <asp:TextBox ID="drp_comp_name" runat="server" CssClass="span10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                           <%-- <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="span10" DataSourceID="SqlDataSource1" DataTextField="companyname" DataValueField="companyid">
                                                            </asp:DropDownList>--%>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name" ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [companyid], [companyname] FROM [tbl_intranet_companydetails]"></asp:SqlDataSource>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        Region Name<span class="star" style="color:red">*</span></label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="drp_region" runat="server" CssClass="span10" Height="" Width="">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <asp:ListItem>North</asp:ListItem>
                                                                <asp:ListItem>South</asp:ListItem>
                                                                <asp:ListItem>East</asp:ListItem>
                                                                <asp:ListItem>West</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drp_region" ErrorMessage="CompareValidator" Operator="NotEqual" ToolTip="Select Region Name" ValidationGroup="c" ValueToCompare="0"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        Work Location Name <span class="star" style="color:red">*</span></label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_branch_name" runat="server" CssClass="span10" onkeypress="return isCharOrSpace()" Width=""></asp:TextBox>
                                                            &nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name" Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Work Location Name" ValidationGroup="c" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_branch_name" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot;  /&gt;" ToolTip="Enter only alphabets and slash " ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="c"></asp:RegularExpressionValidator>--%>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        Work Location Code</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_branch_code" runat="server" CssClass="span10" MaxLength="20" onkeypress="return isChar_Number_slash()" Width=""></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txt_branch_code" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot;  /&gt;" ToolTip="Enter only alphanumberic and slash " ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        Establishment Date</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_est_date" runat="server" CssClass="span10" onkeydown="return enterdate(event);" onkeypress="return false;" onpaste="return false;"></asp:TextBox>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" ToolTip="click to open calender" />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="Image1" TargetControlID="txt_est_date">
                                                            </cc1:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        ESI Code No.</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_esi_local_no" runat="server" CssClass="span10" MaxLength="20" onkeypress="return isNumber()" Width=""></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_esi_local_no" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" ToolTip="Enter only numbers" ValidationExpression="^[0-9]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        ESI Work Location Office</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_Pfphoneno" runat="server" CssClass="span10" MaxLength="12" onkeypress="return isCharOrSpace()" Width=""></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt_Pfphoneno" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" ToolTip="Enter only alphabets and space" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        ESI Contact No.</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_Panno" runat="server" CssClass="span10" MaxLength="10" onkeypress=" return ValidateZIP()" Width=""></asp:TextBox>
                                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_Panno"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter only numbers minimum 10 digits"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>--%>
                                                        </div>
                                                    </div>
                                                    <div class="control-group">
                                                        <label class="control-label">
                                                        PT Circle</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txt_PtCircle" runat="server" CssClass="span10" MaxLength="20" onkeypress="return isChar_Number_space_ifin()" Width=""></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txt_PtCircle" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" ToolTip="Enter only numbers minimum 10 digits" ValidationExpression="^[a-zA-Z0-9\s\-]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <%--  <div class="form-actions no-margin">
                                                <div style="padding-left: 10%">
                                                    <asp:Button ID="Button1"  runat="server" Text="Save" CssClass="btn btn-primary"
                                                        OnClientClick="return Validate();"></asp:Button>
                                                </div>
                                              
                                            </div>--%>
                                                    <br>
                                                    <br></br>
                                                    </br>
                                                    </br>                                                   
                                        </fieldset>
                                  
                                    </div>

                                </div>

                           <%-- ******************************Changed By Irshad***********************************--%>

                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>
                                        </div>
                                    </div>
                                      <fieldset>
                                          <br>
                                          <br></br>
                                          <div class="control-group">
                                              <label class="control-label">
                                              Address</label>
                                              <div class="controls">
                                                  <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="span10" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()" Width=""></asp:TextBox>
                                                  <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pre_add1" Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Address" ValidationGroup="c" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txt_pre_add1" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot;  /&gt;" ToolTip="Enter only alphanumeric space / #  ." ValidationExpression="^[a-zA-Z0-9&amp;\.\/\-\#\s\:\,\(\)\']+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              Country</label>
                                              <div class="controls">
                                                  <asp:DropDownList ID="ddlCostCenterCountry" runat="server" AutoPostBack="true" CssClass="span10" Height="" OnSelectedIndexChanged="ddlCostCenterCountry_SelectedIndexChanged1" Width="">
                                                  </asp:DropDownList>
                                                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCostCenterCountry" Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select Country" ValidationGroup="c" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              State</label>
                                              <div class="controls">
                                                  <asp:DropDownList ID="ddlCostCenterState" runat="server" AutoPostBack="true" CssClass="span10" Height="" OnSelectedIndexChanged="ddlCostCenterState_SelectedIndexChanged1" Width="">
                                                  </asp:DropDownList>
                                                  <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCostCenterState" Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select State" ValidationGroup="c" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              City</label>
                                              <div class="controls">
                                                  <asp:DropDownList ID="ddlCostCenterCity" runat="server" CssClass="span10" Height="" Width="">
                                                  </asp:DropDownList>
                                                  <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCostCenterCity" Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select city" ValidationGroup="c" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              Zip Code</label>
                                              <div class="controls">
                                                  <asp:TextBox ID="txt_pre_zip" runat="server" CssClass="span10" MaxLength="6" onkeypress="return ValidateZIP()" Width=""></asp:TextBox>
                                                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_pre_zip"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Zip Code" ValidationGroup="c"
                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%><%--<asp:RegularExpressionValidator ID="RegularExpressionValidator35" ControlToValidate="txt_pre_zip"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{6}$" ToolTip="Enter only numbers, min 6 digits"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>--%>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              EPF Code No.</label>
                                              <div class="controls">
                                                  <asp:TextBox ID="txt_esibranchoffice" runat="server" CssClass="span10" MaxLength="20" onkeypress="return isChar_Number_slash()" Width=""></asp:TextBox>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_esibranchoffice" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot;  /&gt;" ToolTip="Enter only alphanumberic and slash " ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              EPF Work Location Office</label>
                                              <div class="controls">
                                                  <asp:TextBox ID="txt_Esiphno" runat="server" CssClass="span10" MaxLength="12" onkeypress="return isCharOrSpace()" Width=""></asp:TextBox>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Pfphoneno" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" ToolTip="Enter only alphabets and space" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              EPF Contact No.</label>
                                              <div class="controls">
                                                  <asp:TextBox ID="txt_Epfoffice" runat="server" CssClass="span10" MaxLength="10" onkeypress="return ValidateZIP()" Width=""></asp:TextBox>
                                                  <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_Epfoffice"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter only numbers minimum 10 digits"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>--%>
                                              </div>
                                          </div>
                                          <div class="control-group">
                                              <label class="control-label">
                                              TDS Circle</label>
                                              <div class="controls">
                                                  <asp:TextBox ID="txt_Epfoffadd" runat="server" CssClass="span10" MaxLength="20" onkeypress="return isChar_Number_space_ifin()" Width=""></asp:TextBox>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txt_Epfoffadd" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" ToolTip="Enter only numbers minimum 10 digits" ValidationExpression="^[a-zA-Z0-9\s\-]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                              </div>
                                          </div>
                                          <%--  <div class="form-actions no-margin">
                                                <div style="padding-left: 10%">
                                                    <asp:Button ID="Button1"  runat="server" Text="Save" CssClass="btn btn-primary"
                                                        OnClientClick="return Validate();"></asp:Button>
                                                </div>
                                              
                                            </div>--%>
                                          <br>
                                          <br></br>
                                          </br>
                                          </br>
                                       
                                        </fieldset>
                                  
                                    </div>

                                </div>
                            </div>
   <%--***************************************************************  Changes for column***********************************************--%>


                        </div>

                        <div class="form-actions no-margin" align="right">
                        <asp:Button ID="btnsv1" OnClick="btnsv1_Click" runat="server" Text="Update" CssClass="btn btn-primary"
                                ValidationGroup="c"></asp:Button>
                                  <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                                        CssClass="btn btn-primary" ></asp:Button>
                        </div>
                           
                 
                        </div>
                        </div>
                        <span id="message" runat="server"></span>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

    <script type="text/javascript">




        function ValidateZIP() {
            if ((event.keyCode > 47 && event.keyCode < 58) || event.keyCode == 32)
                return event.returnValue;
            return event.returnValue = '';
        }

         </script>

</body>
</html>

