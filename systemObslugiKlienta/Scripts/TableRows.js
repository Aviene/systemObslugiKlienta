$(document).ready(function () {

    //Pbieranie listy kolumn w tabeli
    $('a.tableName').on('click', function () {
        
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

            $("<a/>", {
                "class": "btn btn-primary",
                "id": "getTenFirstRows",
                text: "Execute",
                href: "#"
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
                    $checkbox.prop('checked', !$checkbox.is(':checked'));
                    $checkbox.triggerHandler('change');
                    updateDisplay();
                });
                $checkbox.on('change', function () {
                    updateDisplay();
                });


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
                        $widget.prepend('<span class="state-icon ' + settings[$widget.data('state')].icon + '"></span>');
                    }
                }
                init();

               
            });
            $('a#getTenFirstRows').on('click', function (event) {
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
                        $('div#firstTenRows table tr.headers').append("<th>" + data[0][i].Key + "</th>"); // drukowanie poszczególnych etykiet tabeli
                    }

                    $.each(data, function (key, val) {

                        $("<tr />", { "class": key }).appendTo('div#firstTenRows table');

                        for (var i = 0; i < n; i++) {     
                            $('div#firstTenRows table tr.' + key).append("<td class='" + i + "'>" + val[i].Value + "</td>"); //wypełnianie danymi
                        }   
                        
                    });                    
                });
            });
        })   
    })  
})
