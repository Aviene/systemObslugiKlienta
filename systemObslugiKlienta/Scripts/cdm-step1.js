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
    });
})