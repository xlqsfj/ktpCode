$(document).ready(function() {
    var $changePasswordForm = $("#changePasswordForm");
    var $errorContainer = $("#errorContainer");
    var $errorMsg = $("#errorMsg");
    var $password = $("#password");
    var $newPassword = $("#newPassword");
    var $newPassworda = $("#newPassworda");
    var $changePasswordButton = $("#changePasswordButton");
    var changePasswordButtonText = $changePasswordButton.val();

    var initChangePasswordButton = function() {
        $changePasswordButton.removeAttr("disabled");
        $changePasswordButton.val(changePasswordButtonText);
    };

    var checkValidation = function() {
        $changePasswordButton.val("正在修改");
        $changePasswordButton.attr("disabled", "disabled");
        $errorContainer.hide();
        var errorMsgText = "";
        if (!$password.val()) {
            initChangePasswordButton();
            errorMsgText = "原密码不允许为空";
        } else if (!$newPassword.val()) {
            errorMsgText = "新密码不允许为空";
        } else if (!$newPassworda.val()) {
            errorMsgText = "确认密码不允许为空";
        } else if ($newPassword.val() != $newPassworda.val()) {
            errorMsgText = "新密码与确认密码不一致";
        }
        if (errorMsgText != "") {
            $errorMsg.text(errorMsgText);
            $errorContainer.show();
            initChangePasswordButton();
            return false;
        }
        return true;
    };

    var keydownHadler = function(event) {
        if (event.which === 13) {
            $changePasswordButton.click();
        }
    };

    $changePasswordButton.click(function() {
        if (!checkValidation()) {
            return;
        }
        $changePasswordForm.ajaxSubmit({
            url: "../Home/PutPassword",
            type: "post",
            dataType: "json",
            clearForm: false,
            success: function(result) {
                if (result.result == 0) {
                    angel.alert("修改成功",
                        function() {
                            window.opener = null;
                            window.close();
                        });
                } else {
                    initChangePasswordButton();
                    $errorMsg.text(result.resultValue);
                    $errorContainer.show();
                }
            }
        });
    });
    $(document).add($password).add($newPassword).add($newPassworda).keydown(keydownHadler);
});