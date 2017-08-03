//site.js
(function () {
    var ele = $("#username"); //document.getElementById("username")
    ele.text("Kheneahm Ares");

    //var main = document.getElementById("main");
    //main.onmouseenter = function () {
    //    main.style = "background-color: #888;";
    //};

    //main.onmouseleave = function () {
    //    main.style = "";
    //};

    //var menuItems = $("ul.menu li a");  //so we dont have to handle an event for each list item

    //menuitems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

})(); //self executing anonymous function

$(document).ready(function () {

    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");

        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa fa-angle-left");
            $icon.addClass("fa fa-angle-right");
        }
        else {
            $icon.removeClass("fa fa-angle-right");

            $icon.addClass("fa fa-angle-left");
        }
    });
});