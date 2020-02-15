$(document).ready(function() {
    var promptDialogContainer =
        '<div class="modal fade" style="z-index: 2051" id="modalf8810deee30544baaca953ed5c17a5fd" tabindex="-1" role="dialog" aria-labelledby="modalLabelf8810deee30544baaca953ed5c17a5fd" aria-hidden="true">' +
            '<div class="modal-dialog" style="width: 360px">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<button type="button" class="close" data-dismiss="modal">' +
            '<span aria-hidden="true">&times;</span>' +
            '<span class="sr-only">Close</span>' +
            "</button>" +
            '<h4 class="modal-title" id="modalLabelf8810deee30544baaca953ed5c17a5fd">提示</h4>' +
            "</div>" +
            '<div class="modal-body">' +
            '<label id="modalMessagef8810deee30544baaca953ed5c17a5fd">...</label>' +
            "</div>" +
            '<div class="modal-footer">' +
            '<button type="button" class="btn btn-primary" id="modalOkButtonf8810deee30544baaca953ed5c17a5fd">确定</button>' +
            "</div>" +
            "</div>" +
            "</div>" +
            "</div>";

    if ($("#modalf8810deee30544baaca953ed5c17a5fd").length == 0) {
        $(document.body).append(promptDialogContainer);
    }

    angel.prompt.initialize({
        dialog: "modalf8810deee30544baaca953ed5c17a5fd",
        message: "modalMessagef8810deee30544baaca953ed5c17a5fd",
        okButton: "modalOkButtonf8810deee30544baaca953ed5c17a5fd",
        title: "modalLabelf8810deee30544baaca953ed5c17a5fd"
    });
});
angel.prompt = (function($) {
    var $dialog;
    var $message;
    var $okButton;
    var $title;

    var okHandler = function() {};

    var that = {};

    that.initialize = function(ids) {
        $dialog = $("#" + ids.dialog);
        $message = $("#" + ids.message);
        $okButton = $("#" + ids.okButton);
        $title = $("#" + ids.title);

        $okButton.click(function() {
            $dialog.modal("hide");
            return false;
        });

        $dialog.on("hide.zui.modal", function() { okHandler(); });
        //$dialog.on("hide.bs.modal", function () { okHandler(); });
    };

    that.show = function(message, closeHandler) {
        $message.text(message);

        if ($.isFunction(closeHandler)) {
            okHandler = closeHandler;
        }

        $dialog.modal({ backdrop: "static", keyboard: false });
        $dialog.modal("show");
        $okButton.blur();
    };

    that.hide = function() {
        $dialog.modal("hide");
    };

    return that;
})(jQuery);

angel.alert = function(message, closeHandler) {
    $(".close", $("#modalf8810deee30544baaca953ed5c17a5fd")).show();
    $(".modal-dialog", $("#modalf8810deee30544baaca953ed5c17a5fd")).removeClass("modal-sm");
    $("#modalOkButtonf8810deee30544baaca953ed5c17a5fd").show();
    angel.prompt.show(message, closeHandler);
};

angel.alertNonClose = function(message, closeHandler) {
    $(".close", $("#modalf8810deee30544baaca953ed5c17a5fd")).hide();
    $(".modal-dialog", $("#modalf8810deee30544baaca953ed5c17a5fd")).removeClass("modal-sm");
    $("#modalOkButtonf8810deee30544baaca953ed5c17a5fd").hide();
    angel.prompt.show(message, closeHandler);
};

angel.alertsm = function(message, closeHandler) {
    $(".close", $("#modalf8810deee30544baaca953ed5c17a5fd")).show();
    $(".modal-dialog", $("#modalf8810deee30544baaca953ed5c17a5fd")).addClass("modal-sm");
    $("#modalOkButtonf8810deee30544baaca953ed5c17a5fd").show();
    angel.prompt.show(message, closeHandler);
};

angel.alertsmNonClose = function(message, closeHandler) {
    $(".close", $("#modalf8810deee30544baaca953ed5c17a5fd")).hide();
    $(".modal-dialog", $("#modalf8810deee30544baaca953ed5c17a5fd")).addClass("modal-sm");
    $("#modalOkButtonf8810deee30544baaca953ed5c17a5fd").hide();
    angel.prompt.show(message, closeHandler);
};

angel.alertContainerId = function() {
    return "modalf8810deee30544baaca953ed5c17a5fd";
};