(function($) {
    $.getParameter = function(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var pattern = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(pattern);
        var results = regex.exec(window.location.search);
        if (results == null) {
            return "";
        } else {
            return decodeURIComponent(results[1].replace(/\+/g, " "));
        }
    };

    $.overlay = function() {
        $("body").append('<div class="overlay"></div>');
    };

    $.cancleOverlay = function() {
        $(".overlay").remove();
    };

    $.htmlEncode = function(value) {
        return $("<div/>").text(value).html();
    };

    $.htmlDecode = function(value) {
        return $("<div/>").html(value).text();
    };

    $.daysInMonth = function(month, year) {
        switch (month) {
        case 2:
            if (isNaN(year)) {
                return 29;
            }
            return (year % 4 == 0 && year % 100) || year % 400 == 0 ? 29 : 28;
        case 9:
        case 4:
        case 6:
        case 11:
            return 30;
        default:
            return 31;
        }
    };

    $.formatPercentage = function(value) {
        if (!value && value !== 0) return "";

        var percentage = parseFloat(value);

        return (Math.round(percentage * 100) / 100).toFixed(2) + "%";
    };

    $.unformatPercentage = function(value) {
        if (!value) return "";

        var result = value.replace(/%$/, "");

        return result;
    };

    $.focusFirst = function() {
        $("form:eq(0)").find(":input:visible:enabled:first").focus();
    };

    $.fn.visible = function() {
        return this.css("visibility", "visible");
    };

    $.fn.invisible = function() {
        return this.css("visibility", "hidden");
    };

    $.fn.visibilityToggle = function() {
        return this.css("visibility",
            function(i, visibility) {
                return (visibility == "visible") ? "hidden" : "visible";
            });
    };

    $.fn.moveChild = function($child, newPosition) {
        return this.each(function() {
            $child.detach();
            if (newPosition == $(this).children().length) {
                $(this).children().eq(newPosition - 1).after($child);
            } else {
                $(this).children().eq(newPosition).before($child);
            }
        });
    };

    $.fn.getLength = function() {
        var value = $(this).val();

        if (!value) {
            return 0;
        }

        var lines = value.match(/\n/g);

        if (lines) {
            return value.length + lines.length;
        } else {
            return value.length;
        }
    };

    $.fn.truncateValue = function() {
        var $self = $(this);

        var value = $self.val();
        var maxlenght = $self.attr("maxlength");

        var count = 0;
        for (var index = 0, length = value.length; index < length; index++) {
            if (value[index] == "\n") {
                count++;
            }
            count++;

            if (count > maxlenght) {
                $self.val(value.substring(0, index));
                break;
            }
        }
    };

    $.fn.center = function() {
        this.css("position", "absolute");
        this.css("top", (($(window).height() - this.outerHeight()) / 2) + $(window).scrollTop() + "px");
        this.css("left", (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft() + "px");

        return this;
    };

    $.fn.horizontalCenter = function(top) {
        this.css("position", "absolute");
        this.css("top", top + $(window).scrollTop() + "px");
        this.css("left", (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft() + "px");

        return this;
    };

    $.fn.setPosition = function(top, left) {
        this.css("position", "absolute");
        this.css("top", top + "px");
        this.css("left", left + "px");

        return this;
    };

    $.fn.focusByLength = function(length) {
        var $input = $(this);
        if ($input.val().length == length) {
            $input.focusNextInputField();
        }
    };

    $.fn.focusNextInputField = function() {
        return this.each(function() {
            var fields = $(this).parents("form:eq(0),body").find(":input:not(:hidden)");
            var index = fields.index(this);
            if (index > -1 && (index + 1) < fields.length) {
                var $next = fields.eq(index + 1);

                $next.focus();
                $next.select();
            }
            return false;
        });
    };

    $.fn.isRequired = function() {
        var isRequired = this.attr("isrequired");
        if (isRequired) {
            isRequired = isRequired.toLowerCase();
        }

        return isRequired == "true";
    };

    $.fn.addSelectOptions = function(optionData) {
        var $self = $(this);
        $self.empty();

        $.each(optionData,
            function(index, value) {
                $self.append($("<option></option>")
                    .attr("value", value.id)
                    .text(value.name));
            });
    };

    $.fn.addDatepicker = function(closeHandler) {
        $(this).datetimepicker({
            language: "zh-CN",
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: "yyyy-mm-dd"
        });
        $(this).datetimepicker().on("hide", closeHandler);
    };

    $.fn.setDatepickerStartDate = function(value) {
        $(this).datetimepicker("setStartDate", value);
    };

    $.fn.setDatepickerEndDate = function(value) {
        $(this).datetimepicker("setEndDate", value);
    };

    $.fn.setDatepickerInitialDate = function(value) {
        $(this).datetimepicker("initialDate", value);
    };

    $.fn.isIdentityCode = function() {
        var code = $(this).val();
        if (code.length != 15 && code.length != 18) {
            return false;
        }
        //身份证号合法性验证
        //支持15位和18位身份证号
        //支持地址编码、出生日期、校验位验证
        var city = {
            11: "北京",
            12: "天津",
            13: "河北",
            14: "山西",
            15: "内蒙古",
            21: "辽宁",
            22: "吉林",
            23: "黑龙江 ",
            31: "上海",
            32: "江苏",
            33: "浙江",
            34: "安徽",
            35: "福建",
            36: "江西",
            37: "山东",
            41: "河南",
            42: "湖北 ",
            43: "湖南",
            44: "广东",
            45: "广西",
            46: "海南",
            50: "重庆",
            51: "四川",
            52: "贵州",
            53: "云南",
            54: "西藏 ",
            61: "陕西",
            62: "甘肃",
            63: "青海",
            64: "宁夏",
            65: "新疆",
            71: "台湾",
            81: "香港",
            82: "澳门",
            91: "国外 "
        };
        var row = {
            pass: true,
            msg: "验证成功"
        };
        if (!code || !/^\d{6}(18|19|20)?\d{2}(0[1-9]|1[012])(0[1-9]|[12]\d|3[01])\d{3}(\d|[xX])$/.test(code)) {
            row = {
                pass: false,
                msg: "身份证号格式错误"
            };
        } else if (!city[code.substr(0, 2)]) {
            row = {
                pass: false,
                msg: "身份证号地址编码错误"
            };
        } else {
            //18位身份证需要验证最后一位校验位
            if (code.length == 18) {
                code = code.split("");
                //∑(ai×Wi)(mod 11)
                //加权因子
                var factor = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
                //校验位
                var parity = [1, 0, "X", 9, 8, 7, 6, 5, 4, 3, 2];
                var sum = 0;
                var ai = 0;
                var wi = 0;
                for (var i = 0; i < 17; i++) {
                    ai = code[i];
                    wi = factor[i];
                    sum += ai * wi;
                }
                if (parity[sum % 11] != code[17].toUpperCase()) {
                    row = {
                        pass: false,
                        msg: "身份证号校验位错误"
                    };
                }
            }
        }
        return row.pass;
    };

})(jQuery);