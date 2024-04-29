<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrgChart.aspx.cs" Inherits="admin_OrgChart" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
<!--
  <![endif]-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8"/>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet"/>
  


    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet"/>

    <!-- Bootstrap css -->
<%--    <link href="../css/main.css" rel="stylesheet"/>--%>

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
   <title>SmartDrive Labs</title>
    <style type="text/css">
        body {
            border-top: 5px solid #0e71bb;
            margin-left: 0px;
            margin-top: 0px;
            width: 100%;
            background-color: #fff;
            padding-top:50px;
        }

        #chart {
            width: 900px;
            height: 500px;
            background-color: #fff;
            border-color: #fff;
        }

            #chart div {
                width: 130px;
                border-color: #fff;
            }

            #chart span {
                color: red;
                font-size: 8pt;
                font-style: italic;
                border-color: #fff;
            }

            #chart img {
                height: 100px;
                width: 100px;
            }
    </style>
</head>
<body>
     <form id="form1" runat="server" style="">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["orgchart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            //var options = {
            //    ////title: 'USA City Distribution',
            //    //pieHole: 0.4,
            //    //width: 480,
            //    //height: 279
            //    'border-top':'white'
            //};
        
            var parameters = {
                empcode: '<%=Session["empcode"].ToString()%>'
             };
            $.ajax({
                type: "POST",
                url: "OrgChart.aspx/GetChartData",
                data: JSON.stringify(parameters),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'Entity');
                    data.addColumn('string', 'ParentEntity');
                    data.addColumn('string', 'ToolTip');
                    for (var i = 0; i < r.d.length; i++) {
                        debugger;
                        var employeeId = r.d[i][0].toString();
                        var employeeName = r.d[i][1];
                        var designation = r.d[i][2];
                        var reportingManager = r.d[i][3] != null ? r.d[i][3].toString() : '';
                        data.addRows([[{
                            v: employeeId,
                            f: '<div>(<span>' + designation + '</span>)' +'</br>'+ employeeName 
                        }, reportingManager, designation]]);
                    }
                    //</div><img src = "../upload/photo/' + employeeId + '.jpg" />
                    var chart = new google.visualization.OrgChart($("#chart")[0]);
                    chart.draw(data, { allowHtml: true });
                },
                failure: function (r) {
                    alert(r.d);
                }, 
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>
    <div id="chart">
    </div>
    </form>
</body>
</html>
