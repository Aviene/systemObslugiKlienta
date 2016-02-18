$(document).ready(function () {
    $('a.btn-prev-next').on('click', function (e) {
        $("ul.nav-tabs li#" + $(this).attr('id')+ "tab a").trigger("click");
    });

    $('ul.nav-tabs li a').on('click', function (e) {
        e.preventDefault();
        if (!$(this).parent().hasClass('disabled')) {
            if (!$(this).hasClass('blocked')) {
                var href = $(this).attr('href');
                console.log(href);
                if (!$(this).parent().hasClass('active')) {
                    $('ul.nav-tabs li a').addClass('blocked');
                    $('ul.nav-tabs li').removeClass('active');
                    $('#steps-content .tab').slideUp(600);
                    $(this).parent().addClass('active');
                    $(href).delay(600).slideDown(600,
                    function () {
                        $('ul.nav-tabs li a').removeClass('blocked');
                    });
                }
            }
        }
    });
})