<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewExpenseDetailsbyAdmin.aspx.cs" Inherits="Travel_viewExpenseDetailsbyAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script src="../js/JavaScriptValidations.js"></script>

    <script type="text/javascript">
        // window.onunload = RefreshParent;
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
                // window.close();
            }
        }

        function ClosePopup()
        { window.close(); }
    </script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="row-fluid" id="divTrip" runat="server">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>Expense Details
                                       
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li id="litravel" runat="server">Travel</li>
                                        <li id="liLodging" runat="server">L & C (Stay)</li>
                                        <li id="liOOP" runat="server">OOP</li>
                                        <li id="liMiscellaneous" runat="server">Miscellaneous</li>
                                        <li id="liPersonal" runat="server">Personal Car</li>
                                        <li id="liTelephone" runat="server">Telephone/Fax</li>
                                    </ol>
                                    <div>
                                        <p>
                                            <div class="row-fluid" id="Theadder" runat="server">
                                                <asp:UpdatePanel ID="updatepanel6" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="span12">
                                                            <div class="widget no-margin">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Travel Expenses
                 
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="dt_example" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdtravel" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <b>Total Amount :</b>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("amount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Currency">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtSanctionedAmount" runat="server" CssClass="span11" Style="border: 1px solid #0171b1;" Text='<%#Eval("sanctionedamount")%>' onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSanctionedAmount"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                            ValidationGroup="T" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtSanctionedAmount"
                                                                                            ValidationGroup="T" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Admin Comments" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="lblAdmincomments" runat="server" TextMode="MultiLine" CssClass="span11" Text='<%#Eval("admincomments")%>'></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                        <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="form-actions no-margin" style="text-align: right;" id="divtravelbuttons" runat="server">
                                                                        <asp:Button ID="btnTravelSave" runat="server" CssClass="btn btn-primary"
                                                                            Text="Save" ValidationGroup="T" OnClick="btnTravelSave_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </p>
                                    </div>
                                    <div>
                                        <p>
                                            <div class="row-fluid" id="Lheadder" runat="server">
                                                <asp:UpdatePanel ID="updatepanel5" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="span12">
                                                            <div class="widget no-margin">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>L & C (Stay)
                                                                   
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="Div1" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdlodging" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Start Date" HeaderStyle-Width="7%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("lodgingStartdate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="End Date" HeaderStyle-Width="7%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("lodgingEnddate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="No. Of Days" HeaderStyle-Width="7%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSDate" runat="server" Text='<%#Eval("noofdays")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>


                                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Currency">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="14%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtSanctionedAmount" runat="server" Text='<%#Eval("sanctionedamount")%>' CssClass="span11" Style="border: 1px solid #0171b1;" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSanctionedAmount"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                            ValidationGroup="L" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtSanctionedAmount"
                                                                                            ValidationGroup="L" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Admin Comments" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="lblAdmincomments" runat="server" TextMode="MultiLine" MaxLength="8000" CssClass="span11" Text='<%#Eval("admincomments")%>'></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                        <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="form-actions no-margin" style="text-align: right;" id="divlodgingbuttons" runat="server">
                                                                        <asp:Button ID="btnLodgingSave" runat="server" CssClass="btn btn-primary"
                                                                            Text="Save" ValidationGroup="L" OnClick="btnLodgingSave_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <div class="row-fluid" id="Oheadder" runat="server">
                                                <asp:UpdatePanel ID="updatepanel4" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="span12">
                                                            <div class="widget no-margin">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>OOP Expenses
                 
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="Div3" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdoop" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblOOPReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Travel Date" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblOOPDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Currency">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtSanctionedAmount" runat="server" Text='<%#Eval("sanctionedamount")%>' CssClass="span11" Style="border: 1px solid #0171b1;" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSanctionedAmount"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                            ValidationGroup="O" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtSanctionedAmount"
                                                                                            ValidationGroup="O" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Admin Comments" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="lblAdmincomments" runat="server" TextMode="MultiLine" MaxLength="8000" Text='<%#Eval("admincomments")%>'></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                        <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="form-actions no-margin" style="text-align: right;" id="divoopbuttons" runat="server">
                                                                        <asp:Button ID="btnOOPSave" runat="server" CssClass="btn btn-primary"
                                                                            Text="Save" ValidationGroup="O" OnClick="btnOOPSave_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <div class="row-fluid" id="Mheadder" runat="server">
                                                <asp:UpdatePanel ID="updatepanel3" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="span12">
                                                            <div class="widget no-margin">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Miscellaneous Expenses
                 
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="Div4" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdmiscillenaous" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblOOPReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Travel Date" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblOOPDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Currency">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtSanctionedAmount" runat="server" Text='<%#Eval("sanctionedamount")%>' Style="border: 1px solid #0171b1;" CssClass="span11 blue1" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSanctionedAmount"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                            ValidationGroup="M" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtSanctionedAmount"
                                                                                            ValidationGroup="M" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Admin Comments" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="lblAdmincomments" runat="server" TextMode="MultiLine" MaxLength="8000" CssClass="span11" Text='<%#Eval("admincomments")%>'></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                        <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="form-actions no-margin" style="text-align: right;" id="divmiscellaneousbuttons" runat="server">
                                                                        <asp:Button ID="bntMiscelSave" runat="server" CssClass="btn btn-primary"
                                                                            Text="Save" ValidationGroup="M" OnClick="bntMiscelSave_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <div class="row-fluid" id="Pheadder" runat="server">
                                                <asp:UpdatePanel ID="updatepanel2" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="span12">
                                                            <div class="widget no-margin">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Personal Car Expenses
                 
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="Div5" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdpersonalcar" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="8%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPCReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Travel Date" HeaderStyle-Width="8%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPCDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Travel From" HeaderStyle-Width="8%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPCFrom" runat="server" Text='<%#Eval("travelfrom")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Travel To " HeaderStyle-Width="8%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPCtravelto" runat="server" Text='<%#Eval("travelto")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Travel Distance" HeaderStyle-Width="8%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPCDistance" runat="server" Text='<%#Eval("approxdispance")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="8%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Currency">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="17%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtSanctionedAmount" runat="server" Text='<%#Eval("sanctionedamount")%>' Style="border: 1px solid #0171b1;" CssClass="span11" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSanctionedAmount"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                            ValidationGroup="P" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtSanctionedAmount"
                                                                                            ValidationGroup="P" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Admin Comments" HeaderStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="lblAdmincomments" runat="server" TextMode="MultiLine" MaxLength="8000" CssClass="span11" Text='<%#Eval("admincomments")%>'></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                        <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="form-actions no-margin" style="text-align: right;" id="divpersonalbuttons" runat="server">
                                                                        <asp:Button ID="btnPersonacarSave" runat="server" CssClass="btn btn-primary"
                                                                            Text="Save" ValidationGroup="P" OnClick="btnPersonacarSave_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <div class="row-fluid" id="Fheadder" runat="server">
                                                <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="span12">
                                                            <div class="widget no-margin">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Telephone/Fax Expenses
                 
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="Div6" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdtelephone" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFaxReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Travel Date" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPCDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Number" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFaxnumber" runat="server" Text='<%#Eval("phonenumber")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Currency">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtSanctionedAmount" runat="server" Text='<%#Eval("sanctionedamount")%>' CssClass="span11" Style="border: 1px solid #0171b1;" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSanctionedAmount"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                            ValidationGroup="F" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtSanctionedAmount"
                                                                                            ValidationGroup="F" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Admin Comments" HeaderStyle-Width="25%">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="lblAdmincomments" runat="server" TextMode="MultiLine" MaxLength="8000" CssClass="span11" Text='<%#Eval("admincomments")%>'></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                        <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                    <div class="form-actions no-margin" style="text-align: right;" id="divtelphonebuttons" runat="server">
                                                                        <asp:Button ID="btnFaxSave" runat="server" CssClass="btn btn-primary"
                                                                            Text="Save" ValidationGroup="F" OnClick="btnFaxSave_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </p>
                                    </div>
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>View Bill
                                </div>
                            </div>
                            <div class="widget-body">
                                <div class="example_alt_pagination">
                                    <iframe name="content" frameborder="0" width="100%" height="400px"></iframe>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions no-margin">
                    <asp:Button ID="btnClose" runat="server" OnClientClick="ClosePopup();" Text="Close" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <script src="js/wysiwyg/wysihtml5-0.3.0.js"></script>

        <script src="js/wysiwyg/bootstrap-wysihtml5.js"></script>
        <script type="text/javascript" src="js/date-picker/date.js"></script>
        <script type="text/javascript" src="js/date-picker/daterangepicker.js"></script>
        <script type="text/javascript" src="js/bootstrap-timepicker.js"></script>

        <!-- Editable Inputs -->
        <script src="js/bootstrap-editable.min.js"></script>
        <script src="js/select2.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/wizard/bwizard.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>
        <script src="js/custom-forms.js"></script>

        <script type="text/javascript">
            $("#wizard").bwizard();
        </script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grdtravel').dataTable({
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
