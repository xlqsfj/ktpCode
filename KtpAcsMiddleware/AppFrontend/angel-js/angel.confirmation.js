$(document).ready(function() {
    var confirmationContainer =
        '<div class="modal fade" style="z-index: 2051" id="modal53008f24a7ea4695998a6f1a30807c18" tabindex="-1" role="dialog" aria-labelledby="modalLabel53008f24a7ea4695998a6f1a30807c18" aria-hidden="true">' +
            '<div class="modal-dialog" style="width: 360px">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<button type="button" class="close" data-dismiss="modal">' +
            '<span aria-hidden="true">&times;</span>' +
            '<span class="sr-only">Close</span>' +
            "</button>" +
            '<h4 class="modal-title" id="modalLabel53008f24a7ea4695998a6f1a30807c18">提示</h4>' +
            "</div>" +
            '<div class="modal-body">' +
            '<label id="modalMessage53008f24a7ea4695998a6f1a30807c18">...</label>' +
            "</div>" +
            '<div class="modal-footer">' +
            '<button type="button" class="btn btn-default" id="modalNoButton53008f24a7ea4695998a6f1a30807c18">取消</button>' +
            '<button type="button" class="btn btn-primary" id="modalYesButton53008f24a7ea4695998a6f1a30807c18">确定</button>' +
            "</div>" +
            "</div>" +
            "</div>" +
            "</div>";

    if ($("#modal53008f24a7ea4695998a6f1a30807c18").length == 0) {
        $(document.body).append(confirmationContainer);
    }

    angel.confirmation.initialize({
        dialog: "modal53008f24a7ea4695998a6f1a30807c18",
        message: "modalMessage53008f24a7ea4695998a6f1a30807c18",
        yesButton: "modalYesButton53008f24a7ea4695998a6f1a30807c18",
        noButton: "modalNoButton53008f24a7ea4695998a6f1a30807c18",
        title: "modalLabel53008f24a7ea4695998a6f1a30807c18"
    });
});

angel.confirmation = (function($) {
    var $dialog;
    var $dialogTitle;
    var $dialogMessage;
    var $dialogYesButton;
    var $dialogNoButton;

    var yesButtonHandler = function() {
    };

    var noButtonHandler = function() {
    };

    var that = {};

    that.initialize = function(ids) {
        $dialog = $("#" + ids.dialog);
        $dialogTitle = $("#" + ids.title);
        $dialogMessage = $("#" + ids.message);
        $dialogYesButton = $("#" + ids.yesButton);
        $dialogNoButton = $("#" + ids.noButton);

        $dialogYesButton.click(function() {
            yesButtonHandler();
            $dialog.modal("hide");
            return false;
        });

        $dialogNoButton.click(function() {
            noButtonHandler();
            $dialog.modal("hide");
            return false;
        });
    };

    that.show = function(message, confirmHandler, cancelHandler) {
        $dialogMessage.text(message);
        if ($.isFunction(confirmHandler)) {
            yesButtonHandler = confirmHandler;
        }
        if ($.isFunction(cancelHandler)) {
            noButtonHandler = cancelHandler;
        }

        $dialog.modal({ backdrop: "static", keyboard: false });
        $dialog.modal("show");
        $dialogYesButton.blur();
        $dialogNoButton.blur();
    };

    return that;
})(jQuery);

angel.confirm = function(message, confirmHandler, cancelHandler) {
    angel.confirmation.show(message, confirmHandler, cancelHandler);
};