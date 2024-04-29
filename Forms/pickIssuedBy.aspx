<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pickIssuedBy.aspx.cs" Inherits="recruitment_pickIssuedBy" %>
   
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <meta charset="utf-8" />
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd. : Employee Details</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>

    <script type="text/javascript" language="javascript">
        function returnempcode(val)
        {
        var role = GetParameterValues('role');
        if (role == "12")
            window.opener.document.getElementById("tbissuedby").value = val;
        if (role == "13")
            window.opener.document.getElementById("tbIssuedby").value = val;
        window.opener.focus();
        window.close();
        }

        function GetParameterValues(param)
        {
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var urlparam = url[i].split('=');
                if (urlparam[0] == param) {
                    return urlparam[1];
                }
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
          <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">   
                <div class="row-fluid" style="border:1px solid rgba(0, 0, 0, 0.10);">
                    <div class="span12" style="">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                  <asp:GridView ID="empgrid" runat="server" HorizontalAlign="Center"
                                   CellPadding="4" AutoGenerateColumns="False"
                                   EmptyDataText="No such employee exists !" AllowSorting="True"
                                   OnPageIndexChanging="empgrid_PageIndexChanging" OnSelectedIndexChanged="empgrid_SelectedIndexChanged"
                                   OnPreRender="empgrid_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                     <Columns>
                                      <asp:TemplateField HeaderText="Employee Code">
                                      <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                  <ItemStyle Width="24%" HorizontalAlign="Center" />
                                      <ItemTemplate>
                                          <a href="javascript:returnempcode('<%# DataBinder.Eval(Container.DataItem, "name") %>'+' ' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "empcode") %></a>
                                      <%--<asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>--%>
                                       </ItemTemplate>
                                      </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                          <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <ItemStyle Width="26%" HorizontalAlign="Center" />
                                           <ItemTemplate>
                                               <%--<a href="javascript:returnempcode('<%# DataBinder.Eval(Container.DataItem, "name") %>'+' ' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "name") %></a>--%>
                                              <asp:Label ID="lblname" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                               </ItemTemplate>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Designation">
                                              <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                             <ItemStyle Width="26%" HorizontalAlign="Center" />
                                              <ItemTemplate>
                                              <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                               </ItemTemplate>
                                              </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Department">
                                             <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                               <ItemStyle Width="24%" HorizontalAlign="Center" />
                                              <ItemTemplate>
                                         <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                               </Columns>
                                           <HeaderStyle CssClass="frm-lft-clr123" />
                                              <FooterStyle CssClass="frm-lft-clr123" />
                                              <RowStyle Height="5px" />
                                           </asp:GridView>   
                                </div>
                                <div class="clearfix"></div> 
                            </div>
                        </div>
                    </div>
                </div>
                </div>
              </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#empgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
