<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatetrainingdevelopment.aspx.cs" Inherits="updatetrainingdevelopment" %>

<!DOCTYPE html>

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
    <link href="../css@vd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


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
                                <h2> Training & Development </h2>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                            Edit
                                            <span id="Span2" runat="server"></span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Title</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_title" size="40" CssClass="span4" runat="server"  onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_title"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="v"
                                                        Display="Dynamic" ToolTip="Enter Tital Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txt_title"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z'.\-\s]+$" ToolTip="Enter only alphabets"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                 <label class="control-label">Description</label>
                                                 <div class="controls">
                                                      <asp:TextBox ID="txt_description" runat="server" CssClass="span4" size="40" 
                                                           TextMode="MultiLine" ></asp:TextBox>
                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_description"
                                                           ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9.\/\-\#\s]+$" ToolTip="Enter only alphanumeric and space / -  #"
                                                           ErrorMessage="Enter correct Description"></asp:RegularExpressionValidator>
                                                 </div>
                                             </div>

                                              <div class="control-group">
                                                   <label class="control-label">Trainer</label>
                                                   <div class="controls">
                                                        <asp:TextBox ID="txt_trainer" size="40" CssClass="span4" runat="server"  onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_trainer"
                                                          ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="v"
                                                          Display="Dynamic" ToolTip="Enter Trainer Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_trainer"
                                                          ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z'.\-\s]+$" ToolTip="Enter only alphabets"
                                                          ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                  </div>
                                                </div>

             
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnsbmit_Click"
                                                    ValidationGroup="v" ToolTip="Click to submit the Training Data" />&nbsp;
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                                    Text="Cancel" />
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



    </form>

</body>
</html>

