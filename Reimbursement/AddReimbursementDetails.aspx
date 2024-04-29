<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddReimbursementDetails.aspx.cs" Inherits="Reimbursement_AddReimbursementDetails" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <style type="text/css">
       .star
       {
           color:red;
       }

   </style>
    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <script type="text/javascript">
        function isKey(keyCode) {
            return false;
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
    <link href="../css/main.css" rel="stylesheet" />
    <style>
        .center
        {
            position: absolute;
            top: 948px;
            left: 500px;
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                            runat="server">
                            <ProgressTemplate>
                                <div class="modal-backdrop fade in">
                                    <div class="center">
                                        Please Wait...
                                    </div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div class="main-container">

                            <div class="page-header">
                                <div class="pull-left">
                                    <h2> Reimbursement Request </h2>
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
                                                 Create 
                                            <span id="message" runat="server"></span>
                                            </div>

                                        </div>
                                        <div class="widget-body">
                                            <fieldset>

                                                <div class="control-group">
                                                    <label class="control-label">Category<span class="star">*</span></label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="ddlcategory" runat="server" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" AutoPostBack="true" CssClass="span4">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Business Reimbursement" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Miscellaneous Reimbursement" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                          <asp:RequiredFieldValidator ID="RFcategory" runat="server" ControlToValidate="ddlcategory" InitialValue="0" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                        ValidationGroup="c"  ToolTip="Select Category"></asp:RequiredFieldValidator>


                                                        
                                                        <%--                                                    <div style="float: right"><a href="../upload/EDB_Upload_Format1.2.xlsx" target="_blank"><b style="color: #e08c07;"><u>Help Document</u></b></a></div>--%>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">Date<span class="star">*</span></label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txtdate" runat="server" CssClass="span4" MaxLength="50" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;" Width=""></asp:TextBox>
                                                        <asp:Image ID="Image14" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                        <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txtdate" Format="dd-MMM-yyyy"
                                                            PopupButtonID="Image14">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RFtxtdate" runat="server" ControlToValidate="txtdate"  ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                        ValidationGroup="c"  ToolTip="Select Date"></asp:RequiredFieldValidator>
                                                        
                                                        <%-- <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />
                                                    <cc1:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txtdate" Enabled="True"></cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdate" ToolTip="Enter Date"
                                                      ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>

                                                <div class="control-group">
                                                    <label class="control-label">Pay Head <span class="star">*</span></label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="ddlpayhead" runat="server" AutoPostBack="true" CssClass="span4" OnSelectedIndexChanged="ddlpayhead_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlpayhead"  ToolTip="Select Pay Head" InitialValue="0"
                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c" ></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>


                                                <div class="control-group" style="display: none">
                                                    <label class="control-label">Unit</label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txtunits" runat="server" CssClass="span4" MaxLength="50" Width=""></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">Amount<span class="star">*</span></label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txtammount" runat="server" CssClass="span4" MaxLength="50" Width="" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtammount" ToolTip="Enter Amount"
                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">Attachment</label>
                                                    <div class="controls">
                                                        <asp:FileUpload ID="fpattachment" runat="server" CssClass="span4" />
                                                        <asp:Label ID="lblmanadatory" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hdvalue" runat="server" />
                                                    </div>
                                                </div>

                                                <div class="control-group">
                                                    <label class="control-label">Comments<span class="star">*</span></label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_comments" runat="server" CssClass="span4" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_comments" ToolTip="Enter Comments"
                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>

                                                <div class="form-actions no-margin">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="c" OnClick="btnsave_Click" />
                                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" visible="false"/>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row-fluid" id="gridreim" runat="server" visible="false">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                                <asp:Label ID="Label3" runat="server" Text="View"></asp:Label>

                                            </div>
                                           <%-- <div style="float: right">
                                                <span>
                                                    <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" />
                                                </span>
                                            </div>--%>

                                        </div>

                                        <div class="widget-body">

                                            <div id="dt_example" class="example_alt_pagination">

                                                <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                    DataKeyNames="autoID" OnRowDeleting="grd_RowDeleting" OnPreRender="grd_PreRender" OnRowDataBound="grd_RowDataBound" ShowFooter="true">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <%--  <%# Container.DataItemIndex +1 %>--%>
                                                                <asp:Label ID="lbcid" runat="server" Text='<%#Eval("CID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" Name" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("CompName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <div style="padding: 0 0 5px 0">
                                                                    <asp:Label ID="Label2" Text="<b>Total</b>" runat="server" />
                                                                </div>
                                                                <%--<div><asp:Label ID="Label4" Text="Grand Total" runat="server" /></div>--%>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Units" HeaderStyle-Width="0%" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("Units")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblammt" runat="server" Text='<%#Eval("Ammount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblammount" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                     <%--   <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="20%" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Attachment" runat="server" Text='<%#Eval("Attachment")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <a href="../upload/employeedocuments/<%#DataBinder.Eval(Container.DataItem,"Attachment")%>" target="_blank"  class="link05">
                                                                <asp:Label ID="lblAttachment"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Attachment")%>' Visible="TRUE"></asp:Label>
                                                                <asp:Label ID="aViewFile"  runat="server">

                                                                     <%-- <asp:Image ID="Image14" runat="server"  Text="&lt;img src='images/view.png'/&gt;" ></asp:Image>--%>
                                                                </asp:Label>
                                                                
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomments" runat="server" Text='<%#Eval("Comments")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="link05" Text="Delete" CommandName="Delete"><i class="icon-remove"></i></asp:LinkButton>
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

                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                                <asp:Label ID="Label1" runat="server" Text="Approvers Details"></asp:Label>

                                            </div>


                                        </div>

                                        <div class="widget-body">

                                            <div class="example_alt_pagination">

                                                <asp:GridView ID="grdapprovers" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                    DataKeyNames="" OnPreRender="grdapprovers_PreRender">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approver Code" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approver Name" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="level" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllevels" runat="server" Text='<%#Eval("levels")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Role" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblroles" runat="server" Text='<%#Eval("roles")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                                <div class="clearfix"></div>
                                            </div>
                                             
                                        </div>

                                        
                             <div class="widget-header">
                                            <div class="title">
                                               
                                                <span id="Span4" runat="server" class="txt-red" enableviewstate="false"></span>
                                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>

                                            </div>
                                            <div style="float: right">
                                                <span>
                                                    <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" />
                                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="Button3_Click" />
                                                </span>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>


                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsave" />
                    </Triggers>
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
