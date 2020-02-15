$(document).ready(function() {
    angel.validator.initialize();
    $("#nowYear").text(new Date().getFullYear());
    //-----------navigation------------------------------------------------------------------------------//
    var setActiveTab = function() {
        if (!$(".navbar-nav")) {
            return;
        }
        //判断是否嵌入iframe中
        if (self != top) {
            $("nav[role='navigation']").hide();
            return;
        }
        var basicUrl = window.location.href;
        $(".navbar-nav a").each(function() {
            if (basicUrl.indexOf($(this).attr("nav")) > 0) {
                $(".navbar-nav li.active").removeClass("active");
                if ($(this).closest("ul").attr("role") == "menu") {
                    $(this).parent().parent().parent().addClass("active");
                    return;
                }
                $(this).closest("li").addClass("active");
                return;
            }
        });
        //$(".tree-menu a").each(function() {
        //    if (basicUrl.indexOf($(this).attr("href")) > 0) {
        //        $(".tree-menu li.active").removeClass("active");
        //        $(this).closest("li").addClass("active");
        //        return;
        //    }
        //});
    };
    setActiveTab();
});