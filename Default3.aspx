<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <title>Dashboard | SmartHr</title>


    <link href="./js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="./js/main.css" rel="stylesheet" type="text/css" />

    <link href="./js/plugins.css" rel="stylesheet" type="text/css" />
    <link href="./js/responsive.css" rel="stylesheet" type="text/css" />

    <%--<link href="./js/icons.css" rel="stylesheet" type="text/css">--%>

    <link href='./googlefont/css.css' rel='stylesheet' type='text/css'>

    <!--[if lt IE 9]><link rel="stylesheet" type="text/css" href="plugins/jquery-ui/jquery.ui.1.10.2.ie.css"/><![endif]-->


    <link href="./js/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!--[if IE 7]><link rel="stylesheet" href="assets/css/fontawesome/font-awesome-ie7.min.css"><![endif]-->

    <!--[if IE 8]><link href="assets/css/ie8.css" rel="stylesheet" type="text/css"/><![endif]-->

    <link href="./js/fullcalendar.css" rel="stylesheet" type="text/css">

    <script type="text/javascript" defer="" async="" src="./js/piwik.js"></script>

    <script type="text/javascript" src="./js/jquery-1.10.2.min.js.pagespeed.jm.ZzSiN_5Whq.js"></script>

    <script type="text/javascript" src="./js/jquery-ui-1.10.2.custom.min.js.pagespeed.jm.pvfc1Oyct9.js"></script>

    <script type="text/javascript" src="./js/bootstrap.min.js.pagespeed.jm.bskXSwReiw.js"></script>

    <script type="text/javascript" src="./js/lodash.compat.min.js.pagespeed.jm.IMmt48bQIc.js"></script>

    <!--[if lt IE 9]><script src="assets/js/libs/html5shiv.js"></script><![endif]-->

    <script type="text/javascript">//<![CDATA[
        (function (b) { b.support.touch = "ontouchend" in document; if (!b.support.touch) { return; } var c = b.ui.mouse.prototype, e = c._mouseInit, a; function d(g, h) { if (g.originalEvent.touches.length > 1) { return; } g.preventDefault(); var i = g.originalEvent.changedTouches[0], f = document.createEvent("MouseEvents"); f.initMouseEvent(h, true, true, window, 1, i.screenX, i.screenY, i.clientX, i.clientY, false, false, false, false, 0, null); g.target.dispatchEvent(f); } c._touchStart = function (g) { var f = this; if (a || !f._mouseCapture(g.originalEvent.changedTouches[0])) { return; } a = true; f._touchMoved = false; d(g, "mouseover"); d(g, "mousemove"); d(g, "mousedown"); }; c._touchMove = function (f) { if (!a) { return; } this._touchMoved = true; d(f, "mousemove"); }; c._touchEnd = function (f) { if (!a) { return; } d(f, "mouseup"); d(f, "mouseout"); if (!this._touchMoved) { d(f, "click"); } a = false; }; c._mouseInit = function () { var f = this; f.element.bind("touchstart", b.proxy(f, "_touchStart")).bind("touchmove", b.proxy(f, "_touchMove")).bind("touchend", b.proxy(f, "_touchEnd")); e.call(f); }; })(jQuery);
        //]]></script>

    <script type="text/javascript" src="./js/jquery.event.move.js.pagespeed.jm.yli2SNTHc5.js"></script>

    <script type="text/javascript">//<![CDATA[
        (function (module) { if (typeof define === 'function' && define.amd) { define(['jquery'], module); } else { module(jQuery); } })(function (jQuery, undefined) {
            var add = jQuery.event.add, remove = jQuery.event.remove, trigger = function (node, type, data) { jQuery.event.trigger(type, data, node); }, settings = { threshold: 0.4, sensitivity: 6 }; function moveend(e) {
                var w, h, event; w = e.target.offsetWidth; h = e.target.offsetHeight; event = { distX: e.distX, distY: e.distY, velocityX: e.velocityX, velocityY: e.velocityY, finger: e.finger }; if (e.distX > e.distY) {
                    if (e.distX > -e.distY) { if (e.distX / w > settings.threshold || e.velocityX * e.distX / w * settings.sensitivity > 1) { event.type = 'swiperight'; trigger(e.currentTarget, event); } }
                    else { if (-e.distY / h > settings.threshold || e.velocityY * e.distY / w * settings.sensitivity > 1) { event.type = 'swipeup'; trigger(e.currentTarget, event); } }
                }
                else {
                    if (e.distX > -e.distY) { if (e.distY / h > settings.threshold || e.velocityY * e.distY / w * settings.sensitivity > 1) { event.type = 'swipedown'; trigger(e.currentTarget, event); } }
                    else { if (-e.distX / w > settings.threshold || e.velocityX * e.distX / w * settings.sensitivity > 1) { event.type = 'swipeleft'; trigger(e.currentTarget, event); } }
                }
            }
            function getData(node) {
                var data = jQuery.data(node, 'event_swipe'); if (!data) { data = { count: 0 }; jQuery.data(node, 'event_swipe', data); }
                return data;
            }
            jQuery.event.special.swipe = jQuery.event.special.swipeleft = jQuery.event.special.swiperight = jQuery.event.special.swipeup = jQuery.event.special.swipedown = {
                setup: function (data, namespaces, eventHandle) {
                    var data = getData(this); if (data.count++ > 0) { return; }
                    add(this, 'moveend', moveend); return true;
                }, teardown: function () {
                    var data = getData(this); if (--data.count > 0) { return; }
                    remove(this, 'moveend', moveend); return true;
                }, settings: settings
            };
        });
        //]]></script>

    <script type="text/javascript">//<![CDATA[
        (function ($) {
            var lastSize = 0; var interval = null; $.fn.resetBreakpoints = function () {
                $(window).unbind('resize'); if (interval) { clearInterval(interval); }
                lastSize = 0;
            }; $.fn.setBreakpoints = function (settings) {
                var options = jQuery.extend({ distinct: true, breakpoints: new Array(320, 480, 768, 1024) }, settings); interval = setInterval(function () {
                    var w = $(window).width(); var done = false; for (var bp in options.breakpoints.sort(function (a, b) { return (b - a) })) {
                        if (!done && w >= options.breakpoints[bp] && lastSize < options.breakpoints[bp]) {
                            if (options.distinct) {
                                for (var x in options.breakpoints.sort(function (a, b) { return (b - a) })) { if ($('body').hasClass('breakpoint-' + options.breakpoints[x])) { $('body').removeClass('breakpoint-' + options.breakpoints[x]); $(window).trigger('exitBreakpoint' + options.breakpoints[x]); } }
                                done = true;
                            }
                            $('body').addClass('breakpoint-' + options.breakpoints[bp]); $(window).trigger('enterBreakpoint' + options.breakpoints[bp]);
                        }
                        if (w < options.breakpoints[bp] && lastSize >= options.breakpoints[bp]) { $('body').removeClass('breakpoint-' + options.breakpoints[bp]); $(window).trigger('exitBreakpoint' + options.breakpoints[bp]); }
                        if (options.distinct && w >= options.breakpoints[bp] && w < options.breakpoints[bp - 1] && lastSize > w && lastSize > 0 && !$('body').hasClass('breakpoint-' + options.breakpoints[bp])) { $('body').addClass('breakpoint-' + options.breakpoints[bp]); $(window).trigger('enterBreakpoint' + options.breakpoints[bp]); }
                    }
                    if (lastSize != w) { lastSize = w; }
                }, 250);
            };
        })(jQuery);
        //]]></script>

    <script type="text/javascript" src="./js/respond.min.js.pagespeed.jm.BmAdyZM9D3.js"></script>

    <script type="text/javascript">//<![CDATA[
        (function (e, f, b) { var d = /\+/g; function g(j) { return j } function h(j) { return c(decodeURIComponent(j.replace(d, " "))) } function c(j) { if (j.indexOf('"') === 0) { j = j.slice(1, -1).replace(/\\"/g, '"').replace(/\\\\/g, "\\") } return j } function i(j) { return a.json ? JSON.parse(j) : j } var a = e.cookie = function (r, q, w) { if (q !== b) { w = e.extend({}, a.defaults, w); if (q === null) { w.expires = -1 } if (typeof w.expires === "number") { var s = w.expires, v = w.expires = new Date(); v.setDate(v.getDate() + s) } q = a.json ? JSON.stringify(q) : String(q); return (f.cookie = [encodeURIComponent(r), "=", a.raw ? q : encodeURIComponent(q), w.expires ? "; expires=" + w.expires.toUTCString() : "", w.path ? "; path=" + w.path : "", w.domain ? "; domain=" + w.domain : "", w.secure ? "; secure" : ""].join("")) } var j = a.raw ? g : h; var u = f.cookie.split("; "); var x = r ? null : {}; for (var p = 0, n = u.length; p < n; p++) { var o = u[p].split("="); var k = j(o.shift()); var m = j(o.join("=")); if (r && r === k) { x = i(m); break } if (!r) { x[k] = i(m) } } return x }; a.defaults = {}; e.removeCookie = function (k, j) { if (e.cookie(k) !== null) { e.cookie(k, null, j); return true } return false } })(jQuery, document);
        //]]></script>

    <script type="text/javascript" src="./js/jquery.slimscroll.min.js.pagespeed.jm.qPOR2x4vbw.js"></script>

    <script type="text/javascript" src="./js/jquery.slimscroll.horizontal.min.js.pagespeed.jm.SIGGOjCPkC.js"></script>

    <!--[if lt IE 9]><script type="text/javascript" src="plugins/flot/excanvas.min.js"></script><![endif]-->

    <script type="text/javascript" src="./js/jquery.sparkline.min.js.pagespeed.jm.yiHIYyEJ8S.js"></script>

    <script type="text/javascript" src="./js/jquery.flot.min.js.pagespeed.jm.zWmzVdkfPV.js"></script>

    <script type="text/javascript" src="./js/jquery.flot.tooltip.min.js.pagespeed.jm.psZjUaeo6S.js"></script>

    <script type="text/javascript">//<![CDATA[
        (function (k, z, g) { function d() { for (var l = b.length - 1; l >= 0; l--) { var i = k(b[l]); if (i[0] == z || i.is(":visible")) { var c = i.width(), f = i.height(), a = i.data(x); !a || c === a.w && f === a.h ? m[v] = m[j] : (m[v] = m[w], i.trigger(y, [a.w = c, a.h = f])) } else { a = i.data(x), a.w = 0, a.h = 0 } } A !== null && (A = z.requestAnimationFrame(d)) } var b = [], m = k.resize = k.extend(k.resize, {}), A, e = "setTimeout", y = "resize", x = y + "-special-event", v = "delay", j = "pendingDelay", w = "activeDelay", q = "throttleWindow"; m[j] = 250, m[w] = 20, m[v] = m[j], m[q] = !0, k.event.special[y] = { setup: function () { if (!m[q] && this[e]) { return !1 } var a = k(this); b.push(this), a.data(x, { w: a.width(), h: a.height() }), b.length === 1 && (A = g, d()) }, teardown: function () { if (!m[q] && this[e]) { return !1 } var a = k(this); for (var c = b.length - 1; c >= 0; c--) { if (b[c] == this) { b.splice(c, 1); break } } a.removeData(x), b.length || (cancelAnimationFrame(A), A = null) }, add: function (a) { function c(n, l, p) { var r = k(this), h = r.data(x); h.w = l !== g ? l : r.width(), h.h = p !== g ? p : r.height(), f.apply(this, arguments) } if (!m[q] && this[e]) { return !1 } var f; if (k.isFunction(a)) { return f = a, c } f = a.handler, a.handler = c } }, z.requestAnimationFrame || (z.requestAnimationFrame = function () { return z.webkitRequestAnimationFrame || z.mozRequestAnimationFrame || z.oRequestAnimationFrame || z.msRequestAnimationFrame || function (a, c) { return z.setTimeout(a, m[v]) } }()), z.cancelAnimationFrame || (z.cancelAnimationFrame = function () { return z.webkitCancelRequestAnimationFrame || z.mozCancelRequestAnimationFrame || z.oCancelRequestAnimationFrame || z.msCancelRequestAnimationFrame || clearTimeout }()) })(jQuery, this); (function (b) { var a = {}; function c(f) { function e() { var h = f.getPlaceholder(); if (h.width() == 0 || h.height() == 0) { return } f.resize(); f.setupGrid(); f.draw() } function g(i, h) { i.getPlaceholder().resize(e) } function d(i, h) { i.getPlaceholder().unbind("resize", e) } f.hooks.bindEvents.push(g); f.hooks.shutdown.push(d) } b.plot.plugins.push({ init: c, options: a, name: "resize", version: "1.0" }) })(jQuery);
        //]]></script>

    <script type="text/javascript" src="./js/jquery.flot.time.min.js.pagespeed.jm.6mi8c2wk99.js"></script>

    <%--<script type="text/javascript" src="./js/jquery.flot.growraf.min.js.pagespeed.jm.HERdnh676v.js"></script>--%>

    <script type="text/javascript" src="./js/jquery.flot.pie.min.js"></script>

    <script type="text/javascript" src="./js/moment.min.js.pagespeed.jm.M7lKW9-eTG.js"></script>

    <script type="text/javascript" src="./js/daterangepicker.js.pagespeed.jm.88NAo6D1rv.js"></script>

    <script type="text/javascript" src="./js/jquery.blockUI.min.js.pagespeed.jm.UOQvf-4HaB.js"></script>

    <script type="text/javascript" src="./js/fullcalendar.min.js.pagespeed.jm.mNjkBG4QZb.js"></script>

    <script type="text/javascript" src="./js/jquery.noty.js.pagespeed.jm.fcIvi4axQA.js"></script>

    <script type="text/javascript">//<![CDATA[
        ; (function ($) { $.noty.layouts.top = { name: 'top', options: {}, container: { object: '<ul id="noty_top_layout_container" />', selector: 'ul#noty_top_layout_container', style: function () { $(this).css({ top: 0, left: '5%', position: 'fixed', width: '90%', height: 'auto', margin: 0, padding: 0, listStyleType: 'none', zIndex: 9999999 }); } }, parent: { object: '<li />', selector: 'li', css: {} }, css: { display: 'none' }, addClass: '' }; })(jQuery);
        //]]></script>

    <script type="text/javascript" src="./js/default.js.pagespeed.jm.bOesaHuWmV.js"></script>

    <script type="text/javascript" src="./js/jquery.uniform.min.js.pagespeed.ce.KEJlR4KnXL.js"></script>

    <script type="text/javascript" src="./js/select2.min.js.pagespeed.jm.6KuwL6Yqay.js"></script>

    <script type="text/javascript" src="./js/app.js.pagespeed.ce.63T17cuuJf.js"></script>

    <script type="text/javascript" src="./js/plugins.js.pagespeed.ce.n1by01J4pc.js"></script>

    <script type="text/javascript" src="./js/plugins.form-components.js.pagespeed.ce.7fs8f0WyK3.js"></script>

    <script>$(document).ready(function () { App.init(); Plugins.init(); FormComponents.init() });</script>

    <script type="text/javascript">//<![CDATA[
        "use strict"; $(document).ready(function () { $(".sidebar-search").submit(function (a) { $(".sidebar-search-results").slideDown(200); return false }); $(".sidebar-search-results .close").click(function () { $(".sidebar-search-results").slideUp(200) }); $(".row-bg-toggle").click(function (a) { a.preventDefault(); $(".row.row-bg").each(function () { $(this).slideToggle(200) }) }); $("#sparkline-bar").sparkline("html", { type: "bar", height: "35px", zeroAxis: false, barColor: App.getLayoutColorCode("red") }); $("#sparkline-bar2").sparkline("html", { type: "bar", height: "35px", zeroAxis: false, barColor: App.getLayoutColorCode("green") }); $(".widget .toolbar .widget-refresh").click(function () { var a = $(this).parents(".widget"); App.blockUI(a); window.setTimeout(function () { App.unblockUI(a); noty({ text: "<strong>Widget updated.</strong>", type: "success", timeout: 1000 }) }, 1000) }); setTimeout(function () { $("#sidebar .notifications.demo-slide-in > li:eq(1)").slideDown(500) }, 3500); setTimeout(function () { $("#sidebar .notifications.demo-slide-in > li:eq(0)").slideDown(500) }, 7000) });
        //]]></script>

    <% if (Session["Calander"] != null) Response.Write(Session["Calander"].ToString()); %>



    <% if (Session["Attendance"] != null) Response.Write(Session["Attendance"].ToString()); %>

    <%--<script type="text/javascript">//<![CDATA[
"use strict";$(document).ready(function(){var b=[[1262304000000,0],[1264982400000,4],[1267401600000,8],[1270080000000,12],[1272672000000,16],[1275350400000,20],[1277942400000,24],[1280620800000,28],[1283299200000,24],[1285891200000,20],[1288569600000,24],[1291161600000,26]];var a=[{label:"Total Present",data:b,color:App.getLayoutColorCode("blue")}];$.plot("#chart_filled_blue",a,$.extend(true,{},Plugins.getFlotDefaults(),{xaxis:{min:(new Date(2009,12,1)).getTime(),max:(new Date(2010,11,2)).getTime(),mode:"time",tickSize:[1,"month"],monthNames:["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"],tickLength:1},series:{lines:{fill:true,lineWidth:1.5},points:{show:true,radius:2.5,lineWidth:1.1},grow:{active:true,growings:[{stepMode:"maximum"}]}},grid:{hoverable:true,clickable:true},tooltip:true,tooltipOpts:{content:"%s: %y"}}))});
//]]></script>--%>

    <%--   <script type="text/javascript">//<![CDATA[
"use strict";$(document).ready(function(){var a=[];for(var b=0;b<20;b+=2){a.push([b,b+3]);}var d=$.plot("#chart_simple",[{data:a,label:"Total Present"}],$.extend(true,{},Plugins.getFlotDefaults(),{series:{lines:{show:true},points:{show:true},grow:{active:true}},grid:{hoverable:true,clickable:true},yaxis:{min:0,max:31},xaxis:{min:0,max:20},tooltip:true,tooltipOpts:{content:"%s: %y"}}))});
//]]></script>--%>

    <%--<script type ="text/javascript">
   "use strict";$(document).ready(function(){var e=[];for(var a=12;a<=24;a+=1){e.push([a,parseInt(Math.random()*30)])} var d=new Array();d.push({label:"Bar #1",data:e,bars:{show:true,barWidth:0.2,order:1}});$.plot("#chart_simple",d,$.extend(true,{},Plugins.getFlotDefaults(),{series:{lines:{show:false},points:{show:false}},grid:{hoverable:true},tooltip:true,tooltipOpts:{content:"%s: %y"}}))});
    </script>--%>

    <% if (Session["Pie"] != null) Response.Write(Session["Pie"].ToString()); %>
    <%--<script type ="text/javascript" >
    "use strict";$(document).ready(function(){var c=[]; var b=7;for(var a=0;a<b;a++){c[a]={label:"Department "+(a+1),data:11}}$.plot("#chart_simple",c,$.extend(true,{},Plugins.getFlotDefaults(),{series:{pie:{show:true,radius:1,label:{show:true}}},grid:{hoverable:true},tooltip:true,tooltipOpts:{content:"%p.0%, %s",shifts:{x:20,y:0}}}))});
    </script>--%>

    <style type="text/css">
        .jqstooltip {
            position: absolute;
            left: 0px;
            top: 0px;
            visibility: hidden;
            background: rgb(0, 0, 0) transparent;
            background-color: rgba(0,0,0,0.6);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000);
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#99000000, endColorstr=#99000000)";
            color: white;
            font: 10px arial, san serif;
            text-align: left;
            white-space: nowrap;
            padding: 5px;
            border: 1px solid white;
            z-index: 10000;
        }

        .jqsfield {
            color: white;
            font: 10px arial, san serif;
            text-align: left;
        }
    </style>



    <meta name="document_iterator.js">
    <meta name="find_proxy.js">
    <meta name="get_html_text.js">
    <meta name="global_constants.js">
    <meta name="name_injection_builder.js">
    <meta name="number_injection_builder.js">
    <meta name="menu_injection_builder.js">
    <meta name="string_finder.js">
    <meta name="change_sink.js">
</head>
<body>
    <form id="form1" runat="server">


        <div class="page-header">
            <div class="page-title">
                <h3>Dashboard</h3>
                <span>Good morning, <% if (Session["name"] != null) Response.Write(Session["name"].ToString()); %>!</span>

            </div>

            <ul class="page-stats">
               <%-- <li>
                    <div class="dropdown">
                        <span>New Employees</span>
                        <% if (Session["NewEmployees"] != null) Response.Write(Session["NewEmployees"]); %>
                    </div>

                </li>--%>
                <li>
                    <div class="summary">
                        <span></span>

                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="btn btn-sm btn-primary" Style="height: 40px; width: 82px; margin-right: 22px;" />
                          <asp:Button ID="btnlogout" runat="server" OnClick="btnlogout_Click" Text="Logout" CssClass="btn btn-sm btn-primary" Style="height: 40px; width: 82px; margin-right: 22px;" />
                    </div>
                    <div class="summary">
                        <span>Total Employees</span>
                        <h3>
                            <% if (Session["TotalEmployes"] != null) Response.Write(Session["TotalEmployes"]); %></h3>
                    </div>


                    <div id="sparkline-bar" class="graph sparkline hidden-xs">
                        <% if (Session["DeptEmployees"] != null) Response.Write(Session["DeptEmployees"]); %>
                    </div>
                </li>


            </ul>
        </div>

        <% if (Session["info"] != null) Response.Write(Session["info"].ToString()); %>
        <% if (Session["success"] != null) Response.Write(Session["success"].ToString()); %>
        <% if (Session["warning"] != null) Response.Write(Session["warning"].ToString()); %>
        <% if (Session["danger"] != null) Response.Write(Session["danger"].ToString()); %>

        <% if (Session["GetAttendancePanel"] != null) Response.Write(Session["GetAttendancePanel"].ToString()); %>

        <div class="row">
            <div class="col-md-6">
                <div class="widget">
                    <div class="widget-header">
                        <h4>
                            <i class="icon-calendar"></i>Calendar</h4>
                    </div>
                    <div class="widget-content">
                        <div id="calendar">
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-md-6">
                <div class="widget box">
                    <div class="widget-header">
                        <h4>
                            <i class="icon-reorder"></i>Wishes</h4>
                        <div class="toolbar no-padding">
                            <div class="btn-group">
                                <span class="btn btn-xs widget-collapse"><i class="icon-angle-down"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="widget-content no-padding">
                        <div class="scroller" data-height="290px" data-always-visible="1" data-rail-visible="0">
                            <table class="table table-striped table-checkable table-hover">
                                <thead>
                                    <tr>
                                        <th class="checkbox-column">
                                            <input type="checkbox" class="uniform">
                                        </th>
                                        <th class="hidden-xs">First Name
                                        </th>
                                        <th>Last Name
                                        </th>
                                        <th>Occasion
                                        </th>
                                        <th class="align-center">Date
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% if (Session["Birthday"] != null) Response.Write(Session["Birthday"].ToString()); %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <% if (Session["PigChartTag"] != null) Response.Write(Session["PigChartTag"].ToString()); %>

            <div class="col-md-6" runat="server" id="task">
                <div class="widget">
                    <div class="widget-header">
                        <h4>
                            <i class="icon-reorder"></i>Pending Task</h4>
                        <div class="toolbar no-padding">
                            <div class="btn-group">
                                <span class="btn btn-xs widget-collapse"><i class="icon-angle-down"></i></span><span
                                    class="btn btn-xs widget-refresh"><i class="icon-refresh"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="widget-content">
                        <div class="tabbable tabbable-custom">
                            <ul class="nav nav-tabs">
                                <% if (Session["AdminPendingTaskHeading"] != null) Response.Write(Session["AdminPendingTaskHeading"].ToString()); %>
                                <% if (Session["HRPendingTaskHeading"] != null) Response.Write(Session["HRPendingTaskHeading"].ToString()); %>
                                <% if (Session["FeedsHeading"] != null) Response.Write(Session["FeedsHeading"].ToString()); %>
                            </ul>

                            <div class="tab-content">

                                <% if (Session["AdminPendingTask"] != null) Response.Write(Session["AdminPendingTask"].ToString()); %>

                                <% if (Session["HRPendingTask"] != null) Response.Write(Session["HRPendingTask"].ToString()); %>

                                <% if (Session["Feeds"] != null) Response.Write(Session["Feeds"].ToString()); %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
