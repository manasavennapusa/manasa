<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ECFReport.aspx.cs" Inherits="payroll_admin_ECFReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style>
        table
        {
            border-collapse: collapse;
        }

            table tr td
            {
                color: #333;
                font-size: 13px;
                font-family: Book Antiqua;
                padding: 10px;
            }

        .btn-head
        {
            font-weight: bold;
            color: #4d4d4d;
            font-size: 1.7em;
        }

        .botn
        {
            background-color: #62a6d0; /* Green */
            border-radius: 4px;
            border: none;
            color: white;
            padding: 8px 15px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            margin: 4px 2px;
            cursor: pointer;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
        }

            .botn:hover
            {
                background-color: #337ead;
                color: white;
                box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24),0 17px 50px 0 rgba(0,0,0,0.19);
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center> 
        <div >
            <asp:Button ID="btnExport"  runat="server" OnClick="btnExport_Click" Text="Export" CssClass="botn" style="vertical-align:middle;float:left;margin-top:15px;"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            


                  
            <br />
            <br />
            <div style="width:100%; text-align:center;">
                 <div style="width: 50%; background-color:aqua; margin:  0px auto; text-align:left; visibility:collapse" ></div><br />
</div>
                 <asp:Label ID="Label1" runat="server"  style="margin:-200px"  Font-Size="Large" ForeColor="#70a1ff"  Text="ECR REPORT" ></asp:Label>  
            </div>
            <div>
          <%--  <asp:Label ID="lbl_compname" ForeColor="#70a1ff"  Font-Size="Large"  runat="server" style="margin-left:10px "></asp:Label> 
            <asp:Label ID="lbl_epf" ForeColor="#70a1ff"  Font-Size="Large"  runat="server"  Text="Employer PF No.:" style="padding-left:350px" ></asp:Label>&nbsp;<asp:Label ID="lbl_epfdetails" runat="server" CssClass="btn-head" ForeColor="#70a1ff"  Font-Size="Large"></asp:Label>--%>
           <center><asp:Label ID="Label5" ForeColor="#70a1ff" Font-Size="Large" runat="server" Text="ECR Report For Month of">&nbsp;</asp:Label><asp:Label ID="lbldate" runat="server" CssClass="btn-head" ForeColor="#70a1ff"  Font-Size="Large"></asp:Label> </center>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable datatable">
                <Columns>
                 <asp:BoundField DataField="uan" HeaderText="UAN" HeaderStyle-Width="150"/>
                 <asp:BoundField DataField="Name" HeaderText="Member Name" ItemStyle-Width="150" />
                 <asp:BoundField DataField="EarnedBasic" HeaderText="Gross Wages" ItemStyle-Width="150" />
                 <asp:BoundField DataField="EmployeePFDeductions" HeaderText="EPF Wages" ItemStyle-Width="150" />
                 <asp:BoundField DataField="EPSWages" HeaderText="EPS Wages" ItemStyle-Width="150" />
                 <asp:BoundField DataField="PF_AC_21" HeaderText="EDLI Wages" ItemStyle-Width="150" />
                 <asp:BoundField DataField="EPFCON" HeaderText="EPF Contribution" ItemStyle-Width="250" />
                 <asp:BoundField DataField="EPFRemitted" HeaderText="EPF Remitted" ItemStyle-Width="150" />
                 <asp:BoundField DataField="EPSContribution" HeaderText="EPS Contribution" ItemStyle-Width="350"/>
                 <asp:BoundField DataField="EPSWages" HeaderText="EPS Remitted" ItemStyle-Width="350" />
                 <asp:BoundField DataField="EPFEPS" HeaderText="EPF-EPS(ER Due)" ItemStyle-Width="150" />
                 <asp:BoundField DataField="EPFEPSERRemitted" HeaderText="EPF-EPS(ER Remitted)" ItemStyle-Width="150" />
                 <asp:BoundField DataField="LWP" HeaderText="NCP Days" ItemStyle-Width="150" />
                 <asp:BoundField DataField="RefundAdvances" HeaderText="Refund of Advances" ItemStyle-Width="200" />
                 <asp:BoundField DataField="ArrearEPFWages" HeaderText="Arrear EPF Wages" HeaderStyle-Width="250" />
                 <asp:BoundField DataField="ArrearEPFShare" HeaderText="Arrear EPF Share" ItemStyle-Width="150" />
                 <asp:BoundField DataField="ArrearEPSShare" HeaderText="Arrear EPS Share" ItemStyle-Width="150" />
                 <asp:BoundField DataField="ArrearEPS" HeaderText="Arrear EPS" ItemStyle-Width="150" />
                 <asp:BoundField DataField="f_fname" HeaderText="Member Father Name" ItemStyle-Width="150" />
                 <asp:BoundField DataField="relation" HeaderText="Relationship with Member" ItemStyle-Width="150" />
                 <asp:BoundField DataField="dob" HeaderText="DOB" ItemStyle-Width="150" />
                 <asp:BoundField DataField="emp_gender" HeaderText="Gender" ItemStyle-Width="150" />
                 <asp:TemplateField HeaderText="DOJ EPF">
                 <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                 <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                 <ItemTemplate>
                 <asp:Label ID="l3" runat="server" Text='<%# Bind ("DOJEPF") %>'></asp:Label>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="DOJ EPS">
                 <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                 <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                 <ItemTemplate>
                 <asp:Label ID="l3" runat="server" Text='<%# Bind ("DOJEPS") %>'></asp:Label>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Date of Exit EPF">
                 <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                 <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                 <ItemTemplate>
                 <asp:Label ID="l3" runat="server" Text='<%# Bind ("DateExitEPF") %>'></asp:Label>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Date of Exit EPS">
                 <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                 <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                 <ItemTemplate>
                 <asp:Label ID="l3" runat="server" Text='<%# Bind ("DateExitEPS") %>'></asp:Label>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Reason for leaving">
                 <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                 <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                 <ItemTemplate>
                 <asp:Label ID="l3" runat="server" Text='<%# Bind ("Reasonleaving") %>'></asp:Label>
                 </ItemTemplate>
                 </asp:TemplateField>               
                 </Columns>
            </asp:GridView>
        </div>
             </center>
    </form>
</body>
</html>
