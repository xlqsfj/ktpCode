$(document).ready(function() {
    var $orgUserContainer = $("#orgUserContainer");
    var $orgUserErrorContainer = $("#orgUserErrorContainer");

    var $userId = $("#userId");
    var $status = $("#status");
    var $account = $("#account");
    var $name = $("#name");
    var $mail = $("#mail");
    var $mobile = $("#mobile");
    var $birthday = $("#birthday");
    var $saveButton = $("#saveButton");
    var $cancleButton = $("#cancleButton");

    var init = function() {
        $cancleButton.hide();
        if ($userId.val()) {
            $cancleButton.show();
        }
        if ($status.val() != 0) {
            $saveButton.hide();
            $cancleButton.hide();
        }
    };

    $birthday.addDatepicker();
    $birthday.setDatepickerInitialDate(new Date().addMonths(-216));
    $birthday.setDatepickerEndDate(new Date().addMonths(-216));

    $saveButton.click(function() {
        var isValidateSuccess = angel.validator.validate($orgUserContainer, $orgUserErrorContainer);
        if (!isValidateSuccess) {
            $("html, body").animate({ scrollTop: 0 }, 0);
            return false;
        }
        angel.ajaxSubmit("PutUser",
            function(result) {
                var msg = "保存成功";
                if (result.result == 0) {
                    var userId = result.resultValue.split(",")[0];
                    var userPwd = result.resultValue.split(",")[1];
                    if (!$userId.val()) {
                        msg = "保存成功,新用户默认密码为:" + userPwd;
                    }
                    angel.alert(msg,
                        function() {
                            window.location.href = "UserDetail?id=" + userId;
                        });
                } else {
                    angel.alert(result.resultValue);
                }
            });
        return false;
    });

    $cancleButton.click(function() {
        angel.confirm("确认要注销当前用户吗?",
            function() {
                angel.ajaxPost("PutUserCancle",
                    { id: $userId.val() },
                    function(data) {
                        var result = $.parseJSON(data);
                        if (result.result == 0) {
                            angel.alert("当前用户已注销成功",
                                function() {
                                    window.location.href = "UserDetail?id=" + $userId.val();
                                });
                        } else {
                            angel.alert(result.resultValue);
                        }
                    });
            });
    });

    init();

    $account.rules("add", { required: true, messages: { required: "登录名不允许为空" } });
    $name.rules("add", { required: true, messages: { required: "姓名不允许为空" } });
    $mail.rules("add",
        {
            required: true,
            email: true,
            messages: {
                required: "邮箱不允许为空",
                email: "邮箱格式错误"
            }
        });
    $mobile.rules("add", { cnMobile: true, messages: { cnMobile: "手机号码格式错误" } });
    $birthday.rules("add", { dateISO: true, messages: { dateISO: "出生日期必需为日期格式(ISO)。例:2012-02-02" } });
    angel.addRequiredMark($account);
    angel.addRequiredMark($name);
    angel.addRequiredMark($mail);
});