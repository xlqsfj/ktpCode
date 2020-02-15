window.angel = (function($) {
    var variable1;
    var requiredMarkHtml = '<span style="color: red;margin-left: 2px;width:4px">*</span>';
    //var requiredMark = '<span class="text-muted" style="color: red;">*</span>';
    //...other variable

    var function1 = function() {
        variable1 = "a";
    };

    //...other function

    var that = {};

    that.method1 = function() {
        function1();
        $.isArray([]);
        //...other code
    };

    that.addRequiredMark = function($element) {
        //$element.after(requiredMarkHtml);
        if ($element.is("label")) {
            var value = $element.text();
            var newValue = value + requiredMarkHtml;
            $element.html(newValue);
            return;
        }
        var $label = $('label[for="' + $element.attr("id") + '"]');
        if (!$label) {
            var $inputParent = $element.parent();
            $label = $inputParent.children("label").eq(0);
        }
        if ($label) {
            var labelValue = $label.text();
            var newLabelValue = labelValue + requiredMarkHtml;
            $label.html(newLabelValue);
        }
    };

    that.hideButton = function() {
        $(".btn").each(function() {
            $(this).hide();
        });
    };

    that.showButton = function() {
        $(".btn").each(function() {
            $(this).show();
        });
    };

    that.setDefultName = function($element) {
        $element.attr("name", $element.attr("id"));
    };

    that.reloadPage = function() {
        //location.reload();
        top.location = window.location.href;
    };

    that.redirectPage = function(url) {
        top.location = url;
    };

    that.getQueryString = function(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]);
        return null;
    };

    that.openWnd = function(url, width, height) {
        if (!width) {
            width = $(window).width() * 0.6;
        }
        if (!height) {
            height = $(window).height() * 0.7;
        }
        var top = ($(window).height() - height) / 3;
        var left = ($(window).width() - width) / 2;
        return window.open(url,
            "newwindow",
            "height=" +
            height +
            "px, width=" +
            width +
            "px,top=" +
            top +
            ",left=" +
            left +
            " toolbar= no, menubar=no, scrollbars=no, resizable=no, location=no, status=no,z-look=yes");
    };

    return that;
})(jQuery);