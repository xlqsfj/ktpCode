angel.ajax = (function($) {
    var that = {};

    var error = function(xmlHttpRequest, textStatus, errorThrown) {
        var msg = "出现错误:";
        msg = msg + " xmlHttpRequest.status=" + xmlHttpRequest.status;
        msg = msg + " xmlHttpRequest.readyState=" + xmlHttpRequest.readyState;
        msg = msg + " textStatus=" + textStatus;
        msg = msg + " errorThrown=" + errorThrown;
        //angel.alert(msg);
        console.log(msg);
        return false;
    };

    that.jsonStringify = function(value) {
        return encodeURIComponent(JSON.stringify(value));
    };

    that.ajaxGet = function(url, successHandler, errorHandler) {
        $.ajaxSetup({ cache: false });
        if (!$.isFunction(successHandler)) {
            successHandler = function() {
            };
        }
        if ($.isFunction(errorHandler)) {
            error = errorHandler;
        }
        $.ajax({
            type: "GET",
            url: url,
            error: error,
            success: successHandler
        });
    };

    that.ajaxGetJson = function(url, successHandler, errorHandler) {
        $.ajaxSetup({ cache: false });
        if (!$.isFunction(successHandler)) {
            successHandler = function() {
            };
        }
        if ($.isFunction(errorHandler)) {
            error = errorHandler;
        }
        $.getJSON(url, successHandler, error);
    };

    that.ajaxPost = function(url, data, successHandler, errorHandler) {
        if (!$.isFunction(successHandler)) {
            successHandler = function() {
            };
        }
        if ($.isFunction(errorHandler)) {
            error = errorHandler;
        }

        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: successHandler,
            error: error
        });
    };

    that.ajaxSubmit = function(url, successHandler, form, errorHandler) {
        if (!$.isFunction(successHandler)) {
            successHandler = function() {
            };
        }
        if ($.isFunction(errorHandler)) {
            error = errorHandler;
        }
        if (!form) {
            form = $("#mainForm");
        }
        form.ajaxSubmit({
            url: url,
            type: "post",
            dataType: "json",
            //clearForm: false,
            success: successHandler,
            error: error
        });
    };

    that.ajaxIsSuccess = function(data) {
        //1代表false,0代表true
        if (data.result == 1 || data.result == "1") {
            return false;
        }
        return true;
    };

    that.ajaxValue = function(data) {
        return data.resultValue;
    };

    return that;
})(jQuery);

angel.ajaxGet = function(url, successHandler, errorHandler) {
    angel.ajax.ajaxGet(url, successHandler, errorHandler);
};

angel.ajaxGetJson = function(url, successHandler, errorHandler) {
    angel.ajax.ajaxGetJson(url, successHandler, errorHandler);
};

angel.ajaxPost = function(url, data, successHandler, errorHandler) {
    angel.ajax.ajaxPost(url, data, successHandler, errorHandler);
};

angel.ajaxSubmit = function(url, successHandler, form, errorHandler) {
    angel.ajax.ajaxSubmit(url, successHandler, form, errorHandler);
};

angel.ajaxIsSuccess = function(data) {
    return angel.ajax.ajaxIsSuccess(data);
};

angel.ajaxValue = function(data) {
    return angel.ajax.ajaxValue(data);
};

angel.jsonStringify = function(value) {
    return angel.ajax.jsonStringify(value);
};