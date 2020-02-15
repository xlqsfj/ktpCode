$(document).ready(function() { angel.workerIdentityAuthenticationControl.initialize(); });

angel.workerIdentityAuthenticationControl = (function($) {
    var $container = $("#faa91b310ecc46768bca09bd7f2eea91Container");
    var $errorContainer = $("#faa91b310ecc46768bca09bd7f2eea91ErrorContainer");
    var $errorMsg = $("#faa91b310ecc46768bca09bd7f2eea91ErrorMsg");

    var $workerId = $("#workerIdfaa91b310ecc46768bca09bd7f2eea91");
    var $workerName = $("#workerNamefaa91b310ecc46768bca09bd7f2eea91");
    var $identityCode = $("#identityCodefaa91b310ecc46768bca09bd7f2eea91");
    var $identityId = $("#identityIdfaa91b310ecc46768bca09bd7f2eea91");

    var $identityPicButton = $("#identityPicButtonfaa91b310ecc46768bca09bd7f2eea91");
    var $identityPic = $("#identityPicfaa91b310ecc46768bca09bd7f2eea91");
    var $identityPicId = $("#identityPicIdfaa91b310ecc46768bca09bd7f2eea91");
    var $identityPicFileName = $("#identityPicFileNamefaa91b310ecc46768bca09bd7f2eea91");

    var $identityBackPicButton = $("#identityBackPicButtonfaa91b310ecc46768bca09bd7f2eea91");
    var $identityBackPic = $("#identityBackPicfaa91b310ecc46768bca09bd7f2eea91");
    var $identityBackPicId = $("#identityBackPicIdfaa91b310ecc46768bca09bd7f2eea91");
    var $identityBackPicFileName = $("#identityBackPicFileNamefaa91b310ecc46768bca09bd7f2eea91");

    var $facePicButton = $("#facePicButtonfaa91b310ecc46768bca09bd7f2eea91");
    var $facePic = $("#facePicfaa91b310ecc46768bca09bd7f2eea91");
    var $facePicId = $("#facePicIdfaa91b310ecc46768bca09bd7f2eea91");
    var $facePicFileName = $("#facePicFileNamefaa91b310ecc46768bca09bd7f2eea91");

    var $submitButton = $("#faa91b310ecc46768bca09bd7f2eea91SubmitButton");
    var $cancelButton = $("#faa91b310ecc46768bca09bd7f2eea91CancelButton");

    var submitButtonHandler = function() {};
    var cancelButtonHandler = function() {};

    var that = {};

    that.initialize = function() {
        $submitButton.click(function() {
            $errorContainer.hide();
            $errorMsg.text("");
            if (!$workerId.val()) {
                $errorMsg.text("工人信息出错。");
                $errorContainer.show();
                return false;
            }
            if (!$facePicId.val()) {
                $errorMsg.text("人脸识别照片不允许为空。");
                $errorContainer.show();
                return false;
            }
            if (!$identityPicId.val()) {
                $errorMsg.text("身份证正面照不允许为空。");
                $errorContainer.show();
                return false;
            }
            if (!$identityBackPicId.val()) {
                $errorMsg.text("身份证背面照不允许为空。");
                $errorContainer.show();
                return false;
            }
            submitButtonHandler();
            return false;
        });

        $cancelButton.click(function() {
            cancelButtonHandler();
            $container.modal("hide");
            return false;
        });

        $identityPicButton.click(function() {
            angel.canvasUploadControl.show(
                function() {
                    var newItem = angel.canvasUploadControl.newFile();
                    $identityPicId.val(newItem.Id);
                    $identityPicFileName.val(newItem.PhysicalFileName);
                    $identityPic.attr("src", newItem.PhysicalFileName);
                });
        });

        $identityBackPicButton.click(function() {
            angel.canvasUploadControl.show(
                function() {
                    var newItem = angel.canvasUploadControl.newFile();
                    $identityBackPicId.val(newItem.Id);
                    $identityBackPicFileName.val(newItem.PhysicalFileName);
                    $identityBackPic.attr("src", newItem.PhysicalFileName);
                });
        });

        $facePicButton.click(function() {
            angel.canvasUploadControl.show(
                function() {
                    var newItem = angel.canvasUploadControl.newFile();
                    $facePicId.val(newItem.Id);
                    $facePicFileName.val(newItem.PhysicalFileName);
                    $facePic.attr("src", newItem.PhysicalFileName);
                });
        });

        $identityPic.add($identityBackPic).add($facePic).click(function() {
            if ($(this).attr("src")) {
                window.open($(this).attr("src"));
            }
        });
    };

    that.show = function(item, confirmHandler, cancelHandler) {
        $errorContainer.hide();
        $errorMsg.empty();
        if ($.isFunction(confirmHandler)) {
            submitButtonHandler = confirmHandler;
        }
        if ($.isFunction(cancelHandler)) {
            cancelButtonHandler = cancelHandler;
        }

        if (item) {
            $workerId.val(item.WorkerId);
            $workerName.val(item.WorkerName);
            $identityId.val(item.IdentityId);
            $identityCode.val(item.IdentityCode);
            /**********************************/
            $identityPicId.val(item.IdentityPicId);
            $identityPicFileName.val(item.IdentityPicFileName);
            $identityBackPicId.val(item.IdentityBackPicId);
            $identityBackPicFileName.val(item.IdentityBackPicFileName);
            $facePicId.val(item.FacePicId);
            $facePicFileName.val(item.FacePicFileName);
            if (item.IdentityPicFileName) {
                $identityPic.attr("src", item.IdentityPicFileName);
            } else {
                $identityPic.removeAttr("src");
            }
            if (item.IdentityBackPicFileName) {
                $identityBackPic.attr("src", item.IdentityBackPicFileName);
            } else {
                $identityBackPic.removeAttr("src");
            }
            if (item.FacePicFileName) {
                $facePic.attr("src", item.FacePicFileName);
            } else {
                $facePic.removeAttr("src");
            }
        } else {
            $workerId.val("");
            $workerName.val("");
            $identityId.val("");
            $identityCode.val("");
            /**********************************/
            $identityPic.removeAttr("src");
            $identityBackPic.removeAttr("src");
            $facePic.removeAttr("src");
        }

        $container.modal({ backdrop: "static", keyboard: false });
        $container.modal("show");
        $submitButton.blur();
        $cancelButton.blur();
    };

    that.hide = function() {
        $container.modal("hide");
    };

    that.newItem = function() {
        return {
            WorkerId: $workerId.val(),
            IdentityId: $identityId.val(),
            FacePicId: $facePicId.val(),
            IdentityPicId: $identityPicId.val(),
            IdentityBackPicId: $identityBackPicId.val()
        };
    };
    return that;
})(jQuery);