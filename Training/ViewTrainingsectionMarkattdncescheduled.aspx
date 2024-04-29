<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTrainingsectionMarkattdncescheduled.aspx.cs" Inherits="Training_ViewTrainingsectionMarkattdncescheduled" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows
                        row.style.backgroundColor = "aqua";
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        if (row.rowIndex % 2 == 0) {
                            //Alternating Row Color
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

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
                                <h2>Mark Attendance</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="dashboard-wrapper" style="margin-left: 0px;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="row-fluid">
                                                    <div class="span12">
                                                        <div class="widget no-margin">
                                                            <div class="widget-header">
                                                                <div class="title">
                                                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                                                </div>
                                                            </div>
                                                            <div class="widget-body">
                                                                <div id="dt_example" class="example_alt_pagination">

                                                                    <asp:GridView ID="gridtrainingrequest"
                                                                        runat="server" DataKeyNames="dept_name,id"
                                                                        AutoGenerateColumns="False"
                                                                        EmptyDataText="No such employee exists !"
                                                                        class="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                                        OnPreRender="gridtrainingrequest_PreRender">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.NO">

                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex +1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <%--<asp:TemplateField HeaderText="Training Id">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("id") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>--%>

                                                                            <asp:TemplateField HeaderText="Training Schedule by">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("createdby") %>'></asp:Label></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Training Code">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbltrainingcode" runat="server" Text='<%#Eval ("training_code") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Training Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbltrainingname" runat="server" Text='<%#Eval ("training_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="From Date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblfromdate" runat="server" Text='<%#Eval ("FromDate") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To Date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbltodate" runat="server" Text='<%#Eval ("ToDate") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Module Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblmodulename" runat="server" Text='<%#Eval ("module_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Department Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbldepartment" runat="server" Text='<%#Eval("department_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Faculty">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblemfac" runat="server" Text='<%# Eval ("Faculty") %>'></asp:Label></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                          
                                                                            <asp:HyperLinkField DataNavigateUrlFields="dept_name,FromDate,ToDate,module_name,id,Faculty" HeaderText="View" DataNavigateUrlFormatString="markattendance.aspx?dept_name={0}&FromDate={1}&ToDate={2}&module_name={3}&id={4}&Faculty={5}"
                                                                                NavigateUrl="markattendance.aspx" Text="&lt;img src='../images/view.png'/&gt;">

                                                                                <HeaderStyle CssClass="" />
                                                                                <ControlStyle CssClass="link05" Width="50%" />
                                                                            </asp:HyperLinkField>
                                                                         
                                                                        </Columns>
                                                                    </asp:GridView>
                                   
                                                                    <div class="clearfix"></div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <span id="Span1" runat="server"></span>

                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <span id="message" runat="server"></span>

                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <script src="../js/jquery.min.js"></script>

        <script src="../js/jquery.dataTables.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gridtrainingrequest').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

    </form>

</body>
</html>

