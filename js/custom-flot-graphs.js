// chart colors
var $border_color = "#efefef";
var $grid_color = "#ddd";
var $default_black = "#666";
var $default_grey = "#ccc";
var $primary_color = "#428bca";
var $go_green = "#93caa3";
var $jet_blue = "#70aacf";
var $lemon_yellow = "#ffe38a";
var $nagpur_orange = "#fc965f";
var $ruby_red = "#fa9c9b";



// Flot Charts
var updateInterval = 60;

$("#updateInterval").val(updateInterval).change(function () {
    var v = $(this).val();
    if (v && !isNaN(+v)) {
        updateInterval = +v;
        if (updateInterval < 1)
            updateInterval = 1;
        if (updateInterval > 2000)
            updateInterval = 2000;
        $(this).val("" + updateInterval);
    }
});

var data = [], totalPoints = 200;
function getRandomData() {
    if (data.length > 0)
        data = data.slice(1);

    // do a random walk
    while (data.length < totalPoints) {
        var prev = data.length > 0 ? data[data.length - 1] : 90;
        var y = prev + Math.random() * 10 - 5;
        if (y < 0)
            y = 0;
        if (y > 100)
            y = 100;
        data.push(y);
    }

    // zip the generated y values with the x values
    var res = [];
    for (var i = 0; i < data.length; ++i)
        res.push([i, data[i]])
    return res;
}

if ($("#serverLoad").length) {
    var options = {
        series: { shadowSize: 1 },
        lines: { show: true, lineWidth: 3, fill: true, fillColor: { colors: [{ opacity: 0.5 }, { opacity: 0.5 }] } },
        yaxis: { min: 0, max: 200, tickFormatter: function (v) { return v + "%"; } },
        xaxis: { show: false },
        colors: [$primary_color],
        grid: {
            tickColor: $border_color,
            borderWidth: 0,
        },
    };
    var plot = $.plot($("#serverLoad"), [getRandomData()], options);
    function update() {
        plot.setData([getRandomData()]);
        // since the axes don't change, we don't need to call plot.setupGrid()
        plot.draw();
        setTimeout(update, updateInterval);
    }
    update();
}

if ($("#realtimechart").length) {
    var options = {
        series: { shadowSize: 1 },
        lines: { lineWidth: 1, fill: true, fillColor: { colors: [{ opacity: 1 }, { opacity: 0.1 }] } },
        yaxis: { min: 0, max: 200 },
        xaxis: { show: false },
        colors: [$primary_color],
        grid: {
            tickColor: $border_color,
            borderWidth: 0
        }
    };
    var plot = $.plot($("#realtimechart"), [getRandomData()], options);
    function update() {
        plot.setData([getRandomData()]);
        // since the axes don't change, we don't need to call plot.setupGrid()
        plot.draw();
        setTimeout(update, updateInterval);
    }
    update();
}




$(function socialCatigories() {

    var data = [["Jan", 31], ["Feb", 25], ["Mar", 22], ["Apr", 13], ["May", 17], ["Jun", 29], ["Jul", 27], ["Aug", 31], ["Sep", 27], ["Oct", 10], ["Nov", 0], ["Dec", 0]];

    $.plot("#social-catigories", [data], {
        series: {
            bars: {
                show: true,
                lineWidth: 1,
                fill: true,
                barWidth: 0.5,
                fillColor: { colors: [{ opacity: 0.8 }, { opacity: 0.1 }] }
            }
        },
        grid: {
            hoverable: true,
            clickable: true,
            tickColor: $border_color,
            borderWidth: 0
        },
        colors: [$nagpur_orange, $primary_color, $jet_blue, $lemon_yellow, $ruby_red, $go_green, $default_black],
        xaxis: {
            mode: "categories",
            tickLength: 0
        }
    });

    // Add the Flot version string to the footer

    $("#footer").prepend("Flot " + $.plot.version + " &ndash; ");
});

$(function pieCharts() {
    //Pie Chart
    var data = [
      { label: "FINANCE", data: 25 },
      { label: "SALES", data: 50 },
      { label: "HR & ADMIN", data: 75 },
      { label: "OPERATIONS", data: 190 },
      { label: "R & D", data: 100 },
      { label: "QA & QC", data: 60 },
    { label: "HSE", data: 70 }

    ];

    if ($("#piechart").length) {
        $.plot($("#piechart"), data, {
            series: {
                pie: {
                    show: true
                }
            },
            grid: {
                hoverable: true,
                clickable: true
            },
            legend: {
                show: false
            },
            colors: [$jet_blue, $lemon_yellow, $nagpur_orange, $ruby_red, $go_green, $default_black],
        });
    }

    if ($("#donutchart").length) {
        $.plot($("#donutchart"), data, {
            series: {
                pie: {
                    innerRadius: 0.5,
                    show: true
                }
            },
            legend: {
                show: false
            },
            colors: [$ruby_red, $go_green, $nagpur_orange, $jet_blue, $lemon_yellow, $default_black],
        });
    }

    if ($("#piechart-1").length) {
        $.plot('#piechart-1', data, {
            series: {
                pie: {
                    show: true,
                    radius: 3 / 4,
                    label: {
                        show: true,
                        radius: 1,
                        formatter: function (label, series) {
                            return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                        },
                        background: {
                            opacity: 0.8,
                        },
                    }
                }
            },
            legend: {
                show: false
            },
            colors: [$nagpur_orange, $jet_blue, $ruby_red, $go_green, $lemon_yellow, $default_black],
        });
    }

});




