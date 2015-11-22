$(document).ready(function () {

    $('#myButton').click(function () {
        //alert("cocococ");
        

        $.getJSON("/ClientDatabaseManagement/TableRows", { TableName: $('#myButton').text() }, function (data) {
            var items = [];
            alert();
            $.each(data, function (key, val) {
                items.push("<a id='" + key + "' class='" + "list-group-item" + "'>" + val + "</a>");
            });

            $("<div/>", {
                "class": "list-group",
                html: items.join("")
            }).appendTo("div#rows");
        });
    })
})