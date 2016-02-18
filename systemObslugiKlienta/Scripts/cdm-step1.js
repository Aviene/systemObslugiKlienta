$(document).ready(function () {
    $('div#step1 div.div-huge-btn a').on('click', function () {

        $("div#step1 div.div-huge-btn a").removeClass("btn-primary");
        $("div#step1 div.div-huge-btn a").addClass("huge-btn-default");
        $("div#step1 div.div-huge-btn a span.glyphicon").removeClass("glyphicon-check");
        $("div#step1 div.div-huge-btn a span.glyphicon").addClass("glyphicon-unchecked");

        $(this).removeClass("huge-btn-default");
        $(this).addClass("btn-primary");
        $("span.glyphicon", this).removeClass("glyphicon-unchecked");
        $("span.glyphicon", this).addClass("glyphicon-check");
        $("div#step1 a.next-step").removeClass("disabled");
        $("div#steps-nav ul.nav-tabs li#step2-tab").removeClass("disabled");

        $("div#tables").empty();
        $("div#columns").empty();
        $("div#firstTenRows").empty();
    });

    $('ul.nav-tabs li#step3-tab a').on('click', function () {
        var serverName = $('div#step1 a.btn-primary span.serverName').text();
        var shardName = $('div#step1 a.btn-primary span.shardName').text();
        //alert(serverName + shardName);

        $.getJSON("/ClientDatabaseManagement/ListTables", { ServerName: serverName, ShardName: shardName }, function (data) {
            var items = [];
            var i = 0; // ilość kolumn
            // alert();
            $.each(data, function (key, val) {
                i++;
                items.push("<li id='" + key + "' class='" + "list-group-item" + "'><a href='" + "#" +"' class='" +"tableName" + "'>" + val + "</a></li>");
                //alert(items);
            });
            var animationTime = i * 50;
            //alert(animationTime);
            $("<ul/>", {
                "class": "list-group",
                "id": "check-list-box",
                html: items.join("")
            }).appendTo("div#tables").hide().animate({ height: 'toggle' }, animationTime);

            //Pbieranie listy kolumn w tabeli
            $('a.tableName').on('click', function () {
                $('a.tableName').removeClass('chosenTable');
                $(this).addClass('chosenTable');
                $("div#columns").empty();
                $("div#firstTenRows").empty();
                //alert($(this).text());

                var tableName = $(this).text();
                $.getJSON("/ClientDatabaseManagement/ListColumns", { TableName: tableName }, function (data) {
                    var items = [];
                    var i = 0; // ilość kolumn
                    // alert();
                    $.each(data, function (key, val) {
                        i++;
                        items.push("<li id='" + key + "' class='" + "list-group-item" + "'>" + val + "</li>");
                        //alert(items);
                    });
                    var animationTime = i * 50;
                    //alert(animationTime);
                    $("<ul/>", {
                        "class": "list-group checked-list-box",
                        "id": "check-list-box",
                        html: items.join("")
                    }).appendTo("div#columns").hide().animate({ height: 'toggle' }, animationTime);

                    $("<button/>", {
                        "class": "btn btn-primary",
                        "id": "getTenFirstRows",
                        "data-toggle": "modal",
                        "data-target": "#myModal",
                        text: "Execute"
                    }).appendTo("div#columns");

                    $('.list-group.checked-list-box .list-group-item').each(function () {
                        //console.log($('.list-group.checked-list-box .list-group-item'));
                        // Settings
                        var $widget = $(this),
                            $checkbox = $('<input type="checkbox" class="hidden" />'),
                            color = ($widget.data('color') ? $widget.data('color') : "primary"),
                            style = ($widget.data('style') == "button" ? "btn-" : "list-group-item-"),
                            settings = {
                                on: {
                                    icon: 'glyphicon glyphicon-check'
                                },
                                off: {
                                    icon: 'glyphicon glyphicon-unchecked'
                                }
                            };

                        $widget.css('cursor', 'pointer')
                        $widget.append($checkbox);

                        // Event Handlers
                        $widget.on('click', function () {
                            //if ($("#check-list-box li.active").size() >= 10) {

                            //    if (!$checkbox.is(':checked')) {
                            //        alert("Only 10 columns allowed");
                            //    } else {
                            //        $checkbox.prop('checked', !$checkbox.is(':checked'));
                            //        $checkbox.triggerHandler('change');
                            //        updateDisplay();
                            //    }

                            //} else {
                                $checkbox.prop('checked', !$checkbox.is(':checked'));
                                $checkbox.triggerHandler('change');
                                updateDisplay();
                            //}

                        });

                        $checkbox.on('change', function () {

                            updateDisplay();
                        }
                        );


                        // Actions
                        function updateDisplay() {
                            var isChecked = $checkbox.is(':checked');

                            // Set the button's state
                            $widget.data('state', (isChecked) ? "on" : "off");

                            // Set the button's icon
                            $widget.find('.state-icon')
                                .removeClass()
                                .addClass('state-icon ' + settings[$widget.data('state')].icon);

                            // Update the button's color
                            if (isChecked) {
                                $widget.addClass(style + color + ' active');
                            } else {
                                $widget.removeClass(style + color + ' active');
                            }
                        }

                        // Initialization
                        function init() {

                            if ($widget.data('checked') == true) {
                                $checkbox.prop('checked', !$checkbox.is(':checked'));
                            }

                            updateDisplay();

                            // Inject the icon if applicable
                            if ($widget.find('.state-icon').length == 0) {
                                $widget.prepend('<span class="state-icon ' + settings[$widget.data('state')].icon + '"></span> ');
                            }
                        }
                        init();


                    });
                    $('button#getTenFirstRows').on('click', function (event) {
                        //event.preventDefault();
                        $("div#firstTenRows").empty();
                        var checkedItems = {}, n = 0;
                        $("#check-list-box li.active").each(function (idx, li) {
                            checkedItems[n] = $(li).text();
                            //console.log(checkedItems);
                            n++;
                        });

                        $.getJSON("/ClientDatabaseManagement/TableRows", { TableName: tableName, columns: checkedItems }, function (data) {

                            $("<table />", { "class": "table table-bordered table-striped" }).appendTo('div#firstTenRows'); // dodanie tabeli
                            $("<tr />", { "class": "headers" }).appendTo('div#firstTenRows table'); // nadanie wiersza z etykietami

                            for (var i = 0; i < n; i++) {
                                $('div#firstTenRows table tr.headers').append("<th style='" + "cursor: pointer;" + "'> <span class='" + "state-icon glyphicon glyphicon-unchecked" + "'></span> <span class='" + "columnName" + "'>" + data[0][i].Key + "</span></th>"); // drukowanie poszczególnych etykiet tabeli
                            }

                            $.each(data, function (key, val) {

                                $("<tr />", { "class": key }).appendTo('div#firstTenRows table');

                                for (var i = 0; i < n; i++) {
                                    $('div#firstTenRows table tr.' + key).append("<td class='" + i + "'>" + val[i].Value + "</td>"); //wypełnianie danymi
                                }

                            });
                            var chosenColumns = [];
                            $('div#firstTenRows table tr.headers th').on('click', function () {

                                var index = $(this).index().toString();

                                if (chosenColumns.length >= 4) {

                                    if ($('span.state-icon', this).hasClass('glyphicon-unchecked')) {

                                        alert("More than 4 columns are not allowed");

                                    } else {
                                        $('span.state-icon', this).removeClass('glyphicon-check');
                                        $('span.state-icon', this).addClass('glyphicon-unchecked');
                                        $(this).removeClass('btn-primary');

                                        if ($('div#firstTenRows table td').hasClass(index)) {
                                            $('div#firstTenRows table td.' + index).removeClass('btn-primary');
                                        }

                                        chosenColumns.pop($('span.columnName', this).text());
                                    }
                                } else {
                                    if ($('span.state-icon', this).hasClass('glyphicon-unchecked')) {
                                        $('span.state-icon', this).removeClass('glyphicon-unchecked');
                                        $('span.state-icon', this).addClass('glyphicon-check');
                                        $(this).addClass('btn-primary');

                                        if ($('div#firstTenRows table td').hasClass(index)) {
                                            $('div#firstTenRows table td.' + index).addClass('btn-primary');
                                        };

                                        chosenColumns.push($('span.columnName', this).text());
                                    } else {
                                        $('span.state-icon', this).removeClass('glyphicon-check');
                                        $('span.state-icon', this).addClass('glyphicon-unchecked');
                                        $(this).removeClass('btn-primary');

                                        if ($('div#firstTenRows table td').hasClass(index)) {
                                            $('div#firstTenRows table td.' + index).removeClass('btn-primary');
                                        }

                                        chosenColumns.pop($('span.columnName', this).text());
                                    }
                                }
                                console.log(chosenColumns);
                                console.log(chosenColumns.length);
                            });

                        });
                    });
                })
            })
        });
    });
})