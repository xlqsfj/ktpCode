$(document).ready(function() { angel.deviceMgmtControl.initialize(); });

angel.deviceMgmtControl = (function($) {
    var $controlContainer = $("#deviceMgmtContainer");
    var $controlErrorContainer = $("#deviceMgmtErrorContainer");

    var $id = $("#deviceMgmtId");
    var $deviceCode = $("#deviceCode");
    var $ipAddress = $("#ipAddress");
    var $isCheckInLabel = $("#isCheckInLabel");
    var $isCheckIn = $("#isCheckIn");
    var $isCheckInFalse = $("#isCheckInFalse");
    var $deviceDescription = $("#deviceDescription");

    var $submitButton = $("#deviceMgmtSubmitButton");
    var $cancelButton = $("#deviceMgmtCancelButton");

    var submitButtonHandler = function() {};
    var cancelButtonHandler = function() {};

    var that = {};

    that.initialize = function() {
        $submitButton.click(function() {
            var isValidateSuccess = angel.validator.validate(
                $controlContainer.find(":input:not(:hidden)"),
                $controlErrorContainer);
            if (!isValidateSuccess) {
                $("html, body").animate({ scrollTop: 0 }, 0);
                return false;
            }
            submitButtonHandler();
            $controlContainer.modal("hide");
            return false;
        });

        $cancelButton.click(function() {
            cancelButtonHandler();
            $controlContainer.modal("hide");
            return false;
        });

        $deviceCode.rules("add", { required: true, messages: { required: "编号不允许为空" } });
        $ipAddress.rules("add", { required: true, messages: { required: "IP地址不允许为空" } });
        $isCheckIn.rules("add", { required: true, messages: { required: "是否为入场方向必须选择" } });
        angel.addRequiredMark($deviceCode);
        angel.addRequiredMark($ipAddress);
        angel.addRequiredMark($isCheckInLabel);
    };

    that.show = function(item, confirmHandler, cancelHandler) {
        if ($.isFunction(confirmHandler)) {
            submitButtonHandler = confirmHandler;
        }
        if ($.isFunction(cancelHandler)) {
            cancelButtonHandler = cancelHandler;
        }

        if (item) {
            $id.val(item.Id);
            $deviceCode.val(item.Code);
            $ipAddress.val(item.IpAddress);
            $deviceDescription.val(item.Description);
            if (item.IsCheckIn != null) {
                if (item.IsCheckIn == true) {
                    $isCheckIn.prop("checked", "checked");
                } else {
                    $isCheckInFalse.prop("checked", "checked");
                }
            }
        } else {
            $id.val("");
            $deviceCode.val("");
            $ipAddress.val("");
            $isCheckIn.prop("checked", "");
            $isCheckInFalse.prop("checked", "");
            $deviceDescription.val("");
        }

        $controlContainer.modal({ backdrop: "static", keyboard: false });
        $controlContainer.modal("show");
        $submitButton.blur();
        $cancelButton.blur();
        angel.validator.clearMessages($controlContainer.find(":input"), $controlErrorContainer);
    };

    that.newItem = function() {
        var isCheckIn = true;
        if ($isCheckInFalse.prop("checked") == true) {
            isCheckIn = false;
        }
        return {
            Id: $id.val(),
            Code: $deviceCode.val(),
            IpAddress: $ipAddress.val(),
            IsCheckIn: isCheckIn,
            Description: $deviceDescription.val()
        };
    };
    return that;
})(jQuery);