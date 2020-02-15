$(document).ready(function() {
    var $loginForm = $("#loginForm");
    var $loginErrorContainer = $("#loginErrorContainer");
    var $loginErrorMsg = $("#loginErrorMsg");
    var $loginName = $("#loginName");
    var $password = $("#password");
    var $loginButton = $("#loginButton");
    var loginButtonText = $loginButton.val();

    var initLoginButton = function() {
        $loginButton.removeAttr("disabled");
        $loginButton.val(loginButtonText);
    };

    var checkValidation = function() {
        $loginButton.val("正在登录");
        $loginButton.attr("disabled", "disabled");
        $loginErrorContainer.hide();
        $loginErrorMsg.text("用户名或者密码错误。");
        if (!$loginName.val() || !$password.val()) {
            initLoginButton();
            return false;
        }
        if ($loginName.val() == "Login Name" || $password.val() == "Password") {
            $loginErrorContainer.show();
            initLoginButton();
            return false;
        }
        return true;
    };

    var keydownHadler = function(event) {
        if (event.which === 13) {
            $loginButton.click();
        }
    };

    $loginButton.click(function() {
        if (!checkValidation()) {
            return;
        }
        $loginForm.ajaxSubmit({
            url: "../Home/PostLogin",
            type: "post",
            dataType: "json",
            clearForm: false,
            success: function(result) {
                if (result.result == 0) {
                    window.location.href = "../TeamWorker/Index";
                } else {
                    $loginErrorMsg.text(result.resultValue);
                    $loginErrorContainer.show();
                    initLoginButton();
                }
            }
        });
    });

    $(document).add($loginName).add($password).keydown(keydownHadler);
});