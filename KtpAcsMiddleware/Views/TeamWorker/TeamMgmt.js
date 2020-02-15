$(document).ready(function() { angel.teamMgmtControl.initialize(); });

angel.teamMgmtControl = (function($) {
    var $controlContainer = $("#teamMgmtContainer");
    var $controlErrorContainer = $("#teamMgmtErrorContainer");

    var $name = $("#teamName");
    var $type = $("#teamWorkTypeId");
    var $description = $("#teamDescription");

    var $submitButton = $("#teamMgmtSubmitButton");
    var $cancelButton = $("#teamMgmtCancelButton");

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

        $name.rules("add", { required: true, messages: { required: "名称不允许为空" } });
        $type.rules("add", { required: true, messages: { required: "必需选择所属工种" } });
        angel.addRequiredMark($name);
        angel.addRequiredMark($type);
    };

    that.show = function(item, confirmHandler, cancelHandler) {
        if ($.isFunction(confirmHandler)) {
            submitButtonHandler = confirmHandler;
        }
        if ($.isFunction(cancelHandler)) {
            cancelButtonHandler = cancelHandler;
        }
        angel.validator.clearMessages($controlContainer.find(":input"), $controlErrorContainer);

        if (item) {
            $name.val(item.Name);
            $type.val(item.WorkTypeId);
            $description.val(item.Description);
        } else {
            $name.val("");
            $type.val("");
            $description.val("");
        }

        $controlContainer.modal({ backdrop: "static", keyboard: false });
        $controlContainer.modal("show");
        $submitButton.blur();
        $cancelButton.blur();
    };

    that.newItem = function() {
        return {
            Name: $name.val(),
            WorkTypeId: $type.val(),
            Description: $description.val()
        };
    };
    return that;
})(jQuery);