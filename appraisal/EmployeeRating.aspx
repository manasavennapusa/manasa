<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeRating.aspx.cs" Inherits="appraisal_EmployeeRating" %>

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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <style>
        .center {
            position: absolute;
            top: 948px;
            left: 500px;
        }
    </style>
    <style type="text/css">
        .star:before {
            color: red !important;
            content: " *";
        }
    </style>

</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <%-- <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="modal-backdrop fade in">
                                <div class="center">
                                    Please Wait...
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>--%>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Employee Rating </h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;" visible="false" runat="server">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Employee Rating"></asp:Label>

                                            <asp:Label ID="Label1" Style="margin-left: 610px;" runat="server" Text="Evaluation Cylce :"></asp:Label>


                                            <asp:DropDownList ID="Dropappcycle_id" runat="server"
                                                CssClass="span12" DataSourceID="SqlDataSource12" DataTextField="cycleid" AutoPostBack="true" DataValueField="appcycle_id" OnDataBound="Dropappcycle_id_DataBound" OnSelectedIndexChanged="Dropappcycle_id_SelectedIndexChanged" Width="170px">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select  from_month +' '+ from_year +  ' - '  + to_month +' '+ to_year as cycleid ,appcycle_id as appcycle_id from tbl_appraisal_cycle"></asp:SqlDataSource>


                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <table style="width: 100%; border: 0">

                                            <tr>
                                                <td>
                                                    <table style="width: 100%; border: 0">
                                                        <tr>
                                                            <td>
                                                                <%--<div class="txt01" style="height: 40px"><strong>Rating System</strong>
                                                            </div>--%>
                                                                <%--<div style="width: 320px;">
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 300px;">
                                                                                <b>Evaluation Cylce:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="Dropappcycle_id" runat="server"
                                                                                    CssClass="span11" DataSourceID="SqlDataSource12" DataTextField="cycleid" AutoPostBack="true" DataValueField="appcycle_id" OnDataBound="Dropappcycle_id_DataBound" OnSelectedIndexChanged="Dropappcycle_id_SelectedIndexChanged" Width="200px">
                                                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="select  from_month +' '+ from_year +  ' - '  + to_month +' '+ to_year as cycleid ,appcycle_id as appcycle_id from tbl_appraisal_cycle"></asp:SqlDataSource>

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>--%>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gridratings" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                    DataKeyNames="rating_id" BorderWidth="0px" CellPadding="4" AllowPaging="True"
                                                                    CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Rating">
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "rating")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>

                                                        <tr runat="server" visible="false">
                                                            <td>
                                                                <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" ShowFooter="true"
                                                                    CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                                    DataKeyNames="asd_id,empcode" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" OnRowDataBound="gvGoals_RowDataBound1"
                                                                    EmptyDataText="No Data Found" OnRowEditing="gvGoals_RowEditing" OnSelectedIndexChanged="gvGoals_SelectedIndexChanged">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex +1 %>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="5%" />
                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderText="KRA">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("kca") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Flowid" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Labelspe4" runat="Server" Text='<%# Eval("flow_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="assementid" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Labelspe5" runat="Server" Text='<%# Eval("asd_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="initializeid" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Labelspe7" runat="Server" Text='<%# Eval("initializeid") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="desig" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Labelspe6" runat="Server" Text='<%# Eval("desigid") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Parameters">
                                                                            <ItemTemplate>
                                                                                <%-- <asp:Label ID="lblparameter" runat="Server" Text='<%#Eval("parameter")%>' Visible='<%#Eval("parameter").ToString()==""?false:true%>'></asp:Label>  <%--Visible='<%#Eval("parameter").ToString()==""?true:false%>'--%>
                                                                                <asp:DropDownList ID="ddlpara" runat="server">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Functional Skills</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Quality</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Communication Skills</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Self Development</asp:ListItem>
                                                                                    <asp:ListItem Value="5">Process Knowledge & Adherence</asp:ListItem>
                                                                                    <asp:ListItem Value="6">Team Participation </asp:ListItem>
                                                                                    <asp:ListItem Value="7">Commitment</asp:ListItem>
                                                                                    <asp:ListItem Value="8"> Client/Customer Orientation (Supervisor and above)</asp:ListItem>
                                                                                    <asp:ListItem Value="9">Team Planning & Management (Supervisors and above)</asp:ListItem>
                                                                                    <asp:ListItem Value="10">Mentoring, Leadership and Team Training (Supervisors and above)</asp:ListItem>

                                                                                </asp:DropDownList>

                                                                                <%--  <asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrating" ErrorMessage="Enter rating" InitialValue="0"
                                                                                    Display="Dynamic" ValidationGroup="v"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>--%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Employee Comments" Visible="false" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcomm3" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Employee Comments" Visible="false" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcomm4" runat="Server" Text='<%# Eval("desigid") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Assmentid" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcomm" runat="Server" Text='<%# Eval("assessment_id") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Rating">
                                                                            <ItemTemplate>
                                                                                <%-- <asp:Label ID="lblrating" runat="Server" Text='<%#Eval("emprating")%>' Visible='<%#Eval("emprating").ToString()==""?false:true%>'></asp:Label>  <%--Visible='<%#Eval("emprating").ToString()==""?false:true%>'--%>
                                                                                <asp:DropDownList ID="txtrating" runat="Server" Width="75px" AutoPostBack="true" OnSelectedIndexChanged="txtrating_SelectedIndexChanged" CssClass="blue1">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">4</asp:ListItem>
                                                                                    <asp:ListItem Value="2">3</asp:ListItem>
                                                                                    <asp:ListItem Value="3">2</asp:ListItem>
                                                                                    <asp:ListItem Value="4">1</asp:ListItem>

                                                                                </asp:DropDownList>
                                                                                <%--   <asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrating" ErrorMessage="Enter rating" InitialValue="0"
                                                                                    Display="Dynamic" ValidationGroup="v"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>--%>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblrating1" runat="Server" Text='<%#Eval("emprating")%>' Visible="false"></asp:Label>
                                                                                <asp:DropDownList ID="txteditrating" runat="Server" Width="75px" CssClass="blue1"></asp:DropDownList>
                                                                                <%--  <asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txteditrating" ErrorMessage="Enter rating" InitialValue="0"
                                                                                    Display="Dynamic" ValidationGroup="a"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>--%>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblGoalsAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Comments">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtcomments" TextMode="MultiLine" runat="Server" CssClass="blue1" Width="160px" Text='<%#Eval("emp_comments")%>' MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                                <%--  <asp:Label ID="lblmgrcomments" runat="Server" Text='<%#Eval("empcomments")%>' Visible='<%#Eval("emprating").ToString()==""?false:true%>'></asp:Label>--%>

                                                                                <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtcomments"
                                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                                                </asp:RegularExpressionValidator>--%>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txteditcomments" TextMode="MultiLine" CssClass="blue1" runat="Server" Width="160px" Text='<%#Eval("emp_comments")%>' MaxLength="8000"></asp:TextBox>

                                                                                <%--      <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txteditcomments"
                                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a">
                                                                                </asp:RegularExpressionValidator>--%>
                                                                            </EditItemTemplate>
                                                                            <HeaderStyle Width="17%" />
                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit" Visible="false">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtupdate" runat="server" ValidationGroup="a" CommandName="Update" CssClass="btn btn-primary" Text="Update" ToolTip="Update" />
                                                                                <asp:LinkButton ID="lnkbtncancle" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="btn btn-primary" Text="Cancel" ToolTip="Cancel" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')" CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>


                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>

                                                            <%--<td>
                                                                <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" ShowFooter="true"
                                                                    CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                                    DataKeyNames="asd_id,empcode" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" OnRowDataBound="gvGoals_RowDataBound1"
                                                                    EmptyDataText="No Data Found" OnRowEditing="gvGoals_RowEditing" OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowUpdating="gvGoals_RowUpdating" OnSelectedIndexChanged="gvGoals_SelectedIndexChanged">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex +1 %>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="5%" />
                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderText="KRA">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("kca") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Parameters">
                                                                            <ItemTemplate>
                                                                               <asp:Label ID="lblparameter" runat="Server" Text='<%#Eval("parameter")%>' Visible='<%#Eval("parameter").ToString()==""?false:true%>'></asp:Label> <%-- Visible='<%#Eval("parameter").ToString()==""?true:false%>'--%
                                                                                <asp:DropDownList ID="ddlpara" runat="server" Visible='<%#Eval("parameter").ToString()==""?true:false%>' >
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Functional Skills</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Quality</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Communication Skills</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Self Development</asp:ListItem>
                                                                                    <asp:ListItem Value="5">Process Knowledge & Adherence</asp:ListItem>
                                                                                    <asp:ListItem Value="6">Team Participation </asp:ListItem>
                                                                                    <asp:ListItem Value="7">Commitment</asp:ListItem>
                                                                                    <asp:ListItem Value="8"> Client/Customer Orientation (Supervisor and above)</asp:ListItem>
                                                                                    <asp:ListItem Value="9">Team Planning & Management (Supervisors and above)</asp:ListItem>
                                                                                    <asp:ListItem Value="10">Mentoring, Leadership and Team Training (Supervisors and above)</asp:ListItem>
                                                                                  
                                                                                </asp:DropDownList>

                                                                                <%--  <asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrating" ErrorMessage="Enter rating" InitialValue="0"
                                                                                    Display="Dynamic" ValidationGroup="v"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>--%
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Employee Comments" Visible="false" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcomm" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Manager Comments" Visible="false" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblmngcomm" runat="Server" Text='<%# Eval("mng_comments") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Weightage" Visible="false" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="8%" />
                                                                            <FooterTemplate>
                                                                                <b>Average Rating :</b>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Rating">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblrating" runat="Server" Text='<%#Eval("emprating")%>' Visible="false" ></asp:Label><%--Visible='<%#Eval("emprating").ToString()==""?false:true%>'--%
                                                                                <asp:DropDownList ID="txtrating" runat="Server" Width="75px" Visible='<%#Eval("emprating").ToString()==""?false:true%>'  CssClass="blue1">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrating" ErrorMessage="Enter rating" InitialValue="0"
                                                                                    Display="Dynamic" ValidationGroup="v"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>

                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblrating1" runat="Server" Text='<%#Eval("emprating")%>' Visible="false"></asp:Label>
                                                                                <asp:DropDownList ID="txteditrating" runat="Server" Width="75px" CssClass="blue1"></asp:DropDownList>
                                                                                <asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txteditrating" ErrorMessage="Enter rating" InitialValue="0"
                                                                                    Display="Dynamic" ValidationGroup="a"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>

                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblGoalsAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Comments">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtcomments" TextMode="MultiLine" runat="Server" CssClass="blue1" Width="160px" Text='<%#Eval("empcomments")%>' Visible='<%#Eval("emprating").ToString()==""?true:false%>' MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                                <asp:Label ID="lblmgrcomments" runat="Server" Text='<%#Eval("empcomments")%>' Visible='<%#Eval("emprating").ToString()==""?false:true%>'></asp:Label>

                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtcomments"
                                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                                                </asp:RegularExpressionValidator>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txteditcomments" TextMode="MultiLine" CssClass="blue1" runat="Server" Width="160px" Text='<%#Eval("empcomments")%>' MaxLength="8000"></asp:TextBox>

                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txteditcomments"
                                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a">
                                                                                </asp:RegularExpressionValidator>
                                                                            </EditItemTemplate>
                                                                            <HeaderStyle Width="17%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Manager  Rating" runat="server" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblmgrrating" runat="Server" Text='<%#Eval("mgrrating")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <b>Average Rating :</b><asp:Label ID="lblmgrAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="10%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Manager  Comments" Visible="false" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblmgcomments" runat="Server" Text='<%#Eval("mgrcomments")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="15%" />
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtupdate" runat="server" ValidationGroup="a" CommandName="Update" CssClass="btn btn-primary" Text="Update" ToolTip="Update" />
                                                                                <asp:LinkButton ID="lnkbtncancle" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="btn btn-primary" Text="Cancel" ToolTip="Cancel" />
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" Visible='<%#Eval("emprating").ToString()==""?false:true%>' CommandName="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')" CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>


                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>--%>
                                                        </tr>


                                                        <tr>
                                                            <td class="txt01" style="height: 40px" runat="server" visible="false"><strong>Training Requirement</strong>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtraining" runat="server" visible="false">
                                                            <td>
                                                                <asp:TextBox ID="txttraining" runat="Server" TextMode="MultiLine" Width="450px" CssClass="blue1" Height="40px" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txttraining"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                                </asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px"></td>
                                            </tr>
                                            <tr>
                                                <td class="frm-rght-clr123" style="width: 10%; border-left: none; text-align: right">
                                                    <a href="#myModal" role="button" class="btn btn-primary" data-toggle="modal" style="margin-left: 70%">View Goals</a>
                                                </td>
                                            </tr>

                                            <tr id="ratingself" visible="true" runat="server">
                                                <td>
                                                    <asp:UpdatePanel ID="updpnl" runat="server">
                                                        <ContentTemplate>
                                                            <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="txt01"><strong>Smart Goals Rating</strong>
                                                                        </td>
                                                                        <td style="border-right: none; border-left: none; width: 15%"></td>

                                                                        <%-- <td class="frm-rght-clr123" style="width: 10%; border-left: none;">
                                                                            <a href="#myModal" role="button" class="btn btn-primary" data-toggle="modal" style="margin-left:70%">View</a>
                                                                        </td>--%>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%"><b>Competency</b>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%"><b>Appraisee Rating</b></td>
                                                                        <td class="frm-rght-clr123" style="width: 15%"><b>Appraisee Comments</b></td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Funtional Skills
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_skils" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_skill_cmnt" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Quality
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_quality" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_quality_cmnt" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Communication Skills
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_comm" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_comm" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Self Development
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_self" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_self" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Process Knowledge & Ahereance
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_pro" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_pro" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Team Participation
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_team" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_team" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Commitment
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_commit" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_commit" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Client/Customer Orientation (Supervisor and above)
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_client" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_client" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Team Planing & Management (Supervisors and above)
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_plan" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_plan" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" style="width: 15%">Mentoring, Leadership and Team Training (Supervisors and above)
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:DropDownList ID="drp_mentor" runat="Server" Width="115px" AutoPostBack="true">
                                                                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="0">NA</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" style="width: 15%">
                                                                            <asp:TextBox runat="server" ID="txt_mentor" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </td>
                                            </tr>

                                            <tr id="troverall" visible="false" runat="server">
                                                <td>
                                                    <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                        <tbody>
                                                            <tr visible="false" runat="server">
                                                                <td class="frm-lft-clr123" style="width: 15%" visible="false" runat="server">Overall Rating
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 15%">
                                                                    <asp:Label ID="lblOverallRating" Visible="false" runat="server"></asp:Label>
                                                                    <asp:Label ID="GoalAvgRating" runat="server" Visible="false"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123" visible="false" runat="server">Overall Comments
                                                                </td>
                                                                <td class="frm-rght-clr123" visible="false" runat="server">
                                                                    <asp:TextBox ID="txtOverallComments" CssClass="blue1" TextMode="MultiLine" Width="400px" Height="50px" runat="server" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                        ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtOverallComments"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 10%" id="tdcolor1" runat="server" visible="false">Performance and Behavior
                                                                </td>
                                                            </tr>
                                                            <tr id="troverall2" runat="server" visible="false">
                                                                <td class="frm-lft-clr123 " style="width: 15%;">Manager Overall Rating
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 15%;">
                                                                    <asp:Label ID="lblMgrOverallRating" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123 " style="width: 20%;">Manager Overall Comments
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 40%;">
                                                                    <asp:Label ID="txtMgrOverallComments" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 10%" id="tdcolor2" runat="server">
                                                                    <asp:Label ID="lblBehavior" runat="server" Width="80px" Height="40px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr id="trquest" runat="server">
                                                <td>
                                                    <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblappr" runat="server"><b>What do you (Appraisee) consider to be your most important achievement of the past year?<span class="star"></span></b></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtappr" runat="server" TextMode="MultiLine" Width="600px" placeholder="Max 8000 chars."></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtappr" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Achievement Required" ValidationGroup="v" SetFocusOnError="true" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr id="tr1" runat="server">
                                                <td>
                                                    <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbltraining" runat="server"><b>Which trainings would benefit you to develop job skills by which you and your work will be benefited? (Technical, behavioural, language skills etc. trainings)<span class="star"></span></b></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txt_training" runat="server" TextMode="MultiLine" Width="600px" placeholder="Max 8000 chars."></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_training" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Training Detail Required" ValidationGroup="v" SetFocusOnError="true" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="tr2" runat="server">
                                                <td>
                                                    <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                        <tbody>
                                                            <tr>
                                                                <td runat="server">
                                                                    <asp:Label ID="lblcommnt" runat="server"><b>Any additional Comments:<span class="star"></span></b></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr runat="server" id="appr_div1" visible="true">
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtcmnt_aap" TextMode="MultiLine" Width="600px" Height="50px" placeholder="Max 8000 chars."></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="txtCommentsRequired" runat="server" ControlToValidate="txtcmnt_aap" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Additional Comments Required" ValidationGroup="v" SetFocusOnError="true" />
                                                                </td>

                                                            </tr>
                                                            <tr runat="server" id="appr_div" visible="true">
                                                                <td style="background-color: white">
                                                                    <asp:TextBox runat="server" ID="txtcmnt_appr" TextMode="MultiLine" Width="600px" Height="50px" placeholder="Max 8000 chars."></asp:TextBox>
                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcmnt_appr" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Comments" ValidationGroup="v" SetFocusOnError="true" />--%>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr id="trbuttons" runat="server">
                                                <td style="text-align: right">
                                                    <br />
                                                    <div class="form-actions no-margin">
                                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-success" ValidationGroup="v" Text="Save" OnClick="btnsave_Click" Visible="false" />
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" ValidationGroup="v" Text="Submit" OnClick="btnSubmit_Click" Visible="false"/>
                                                        <asp:Button ID="btnSubmitHR" runat="server" CssClass="btn btn-success" ValidationGroup="v" Text="Submit To HR" OnClick="btnSubmitHR_Click" Visible="false" />
                                                        <asp:Button ID="btnSubmitBUH" runat="server" CssClass="btn btn-success" ValidationGroup="v" Text="Submit TO Manager" OnClick="btnSubmitBUH_Click" Visible="false" />
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Clear" OnClick="btnCancel_Click" Visible="false" />&nbsp;
                                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-info" Text="Reset" OnClick="btnReset_Click" Visible="false" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 id="myModalLabel"><%--KRA's--%>Goal Sheet
                    </h4>
                </div>
                <div>
                    <iframe src="view_KRA.aspx" width="100%" frameborder="0" height="500px"></iframe>

                </div>
            </div>
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

