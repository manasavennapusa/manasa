<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pfform12A.aspx.cs" Inherits="payroll_admin_reports_pfform12" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PF Form 12A</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            HasCrystalLogo="False" HasDrillUpButton="False" HasGotoPageButton="False" HasSearchButton="False"
            HasToggleGroupTreeButton="False"  HasZoomFactorList="False" />
    </div>
    </form>
</body>
</html>
