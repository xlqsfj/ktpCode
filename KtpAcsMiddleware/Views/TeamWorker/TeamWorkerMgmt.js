$(document).ready(function() { angel.teamWorkerMgmtControl.initialize(); });

angel.teamWorkerMgmtControl = (function($) {
    var $controlContainer = $("#teamWorkerMgmtContainer");
    var $controlErrorContainer = $("#teamWorkerMgmtErrorContainer");

    var $identityCodeCreditGradeWarning = $("#identityCodeCreditGradeWarning");
    var $identityCodeCreditGrade = $("#identityCodeCreditGrade");

    var $workerName = $("#workerName");
    var $sexLabel = $("#sexLabel");
    var $sexMan = $("#sexMan");
    var $identityCode = $("#identityCode");
    var $mobile = $("#mobile");
    var $birthday = $("#birthday");
    var $nation = $("#nation");
    var $bankCardCode = $("#bankCardCode");
    var $bankCardTypeId = $("#bankCardTypeId");
    var $addressNow = $("#addressNow");
    var $issuingAuthority = $("#issuingAuthority");
    var $activateTime = $("#activateTime");
    var $invalidTime = $("#invalidTime");
    var $inTime = $("#inTime");
    var $outTime = $("#outTime");
    var $teamWorkerId = $("#teamWorkerId");
    var $teamId = $("#teamWorkerMgmtTeamId");
    var $workerId = $("#workerId");
    var $status = $("#teamWorkerStatus");

    var $submitButton = $("#teamWorkerMgmtSubmitButton");
    var $cancelButton = $("#teamWorkerMgmtCancelButton");

    var submitButtonHandler = function() {};
    var cancelButtonHandler = function() {};

    var getIdentityCreditScore = function() {
        var identityCode = $identityCode.val();
        $identityCodeCreditGrade.text("");
        $identityCodeCreditGradeWarning.fadeOut(1000);
        if (identityCode.length == 15 || identityCode.length == 18) {
            var getIdentityCreditScoreUrl = "GetIdentityCreditScore?code=" + identityCode;
            if ($identityCode.isIdentityCode()) {
                $.getJSON(getIdentityCreditScoreUrl,
                    function(result) {
                        if (result.result == 0) {
                            $identityCodeCreditGrade.text(result.resultValue);
                            if (result.resultValue < 60) {
                                $identityCodeCreditGradeWarning.fadeIn(1000);
                            } else {
                                $identityCodeCreditGradeWarning.fadeOut(1000);
                            }
                        }
                    });
            }
        }
    };
    var that = {};

    that.initialize = function() {
        $identityCode.keyup(getIdentityCreditScore);
        $identityCode.change(getIdentityCreditScore);
        $identityCode.blur(getIdentityCreditScore);
        $identityCode.focus(getIdentityCreditScore);
        $birthday.addDatepicker(function(ev) {
            $activateTime.setDatepickerStartDate(ev.date);
            if (!$activateTime.val()) {
                $invalidTime.setDatepickerStartDate(ev.date);
            }
            $(this).blur();
        });
        $activateTime.addDatepicker(function(ev) {
            $birthday.setDatepickerEndDate(ev.date);
            $invalidTime.setDatepickerStartDate(ev.date);
            $(this).blur();
        });
        $invalidTime.addDatepicker(function(ev) {
            $activateTime.setDatepickerEndDate(ev.date);
            if (!$activateTime.val()) {
                $birthday.setDatepickerEndDate(ev.date);
            }
            $(this).blur();
        });
        $submitButton.click(function() {
            $identityCodeCreditGradeWarning.hide();
            var isValidateSuccess = angel.validator.validate(
                $controlContainer.find(":input:not(:hidden)"),
                $controlErrorContainer);
            if (!isValidateSuccess) {
                $("html, body").animate({ scrollTop: 0 }, 0);
                return false;
            }
            submitButtonHandler();
            return false;
        });

        $cancelButton.click(function() {
            cancelButtonHandler();
            $controlContainer.modal("hide");
            return false;
        });

        $workerName.rules("add", { required: true, messages: { required: "工人姓名不允许为空" } });
        $sexMan.rules("add", { required: true, messages: { required: "工人性别必须选择" } });
        $identityCode.rules("add",
            {
                required: true,
                isIdentityCode: true,
                messages: {
                    required: "身份证号不允许为空",
                    isIdentityCode: "身份证号错误"
                }
            });
        $mobile.rules("add",
            {
                required: true,
                digits: true,
                rangelength: [11, 11],
                messages: {
                    required: "手机号码不允许为空",
                    digits: "手机号码必须为数字",
                    rangelength: "手机号码必须为11位"
                }
            });
        $birthday.rules("add",
            {
                required: true,
                dateISO: true,
                compareDateFromTo: [$birthday, $activateTime],
                messages: {
                    required: "出生日期不允许为空",
                    dateISO: "出生日期必需为日期格式(ISO)。例:2018-03-02",
                    compareDateFromTo: "出生日期必需小于身份证有效期"
                }
            });
        $nation.rules("add", { required: true, messages: { required: "民族必需选择" } });
        $addressNow.rules("add", { required: true, messages: { required: "地址不允许为空" } });
        //$address.rules("add", { required: true, messages: { required: "籍贯不允许为空" } });
        $issuingAuthority.rules("add", { required: true, messages: { required: "发证机关不允许为空" } });
        $activateTime.rules("add",
            {
                required: true,
                dateISO: true,
                compareDateFromTo: [$activateTime, $invalidTime],
                messages: {
                    required: "证件有效期(开始)不允许为空",
                    dateISO: "证件有效期(开始)必需为日期格式(ISO)。例:2018-03-02",
                    compareDateFromTo: "有效期(开始)必需小于有效期(结束)"
                }
            });
        $invalidTime.rules("add",
            {
                required: true,
                dateISO: true,
                compareDateFromTo: [$activateTime, $invalidTime],
                messages: {
                    required: "证件有效期(结束)不允许为空",
                    dateISO: "证件有效期(结束)必需为日期格式(ISO)。例:2018-03-02",
                    compareDateFromTo: "有效期(开始)必需小于有效期(结束)"
                }
            });
        angel.addRequiredMark($workerName);
        angel.addRequiredMark($identityCode);
        angel.addRequiredMark($sexLabel);
        angel.addRequiredMark($nation);
        angel.addRequiredMark($birthday);
        angel.addRequiredMark($addressNow);
        angel.addRequiredMark($mobile);
        angel.addRequiredMark($issuingAuthority);
        angel.addRequiredMark($activateTime);
    };

    that.show = function(item, confirmHandler, cancelHandler) {
        $identityCodeCreditGradeWarning.hide();
        if ($.isFunction(confirmHandler)) {
            submitButtonHandler = confirmHandler;
        }
        if ($.isFunction(cancelHandler)) {
            cancelButtonHandler = cancelHandler;
        }
        angel.validator.clearMessages($controlContainer.find(":input"), $controlErrorContainer);

        if (item) {
            /**********************************/
            $teamWorkerId.val(item.Id);
            $teamId.val(item.TeamId);
            $workerId.val(item.WorkerId);
            $inTime.val(item.InTimeText);
            $outTime.val(item.OutTimeText);
            $mobile.val(item.Mobile);
            $status.val(item.Status);
            $bankCardTypeId.val(item.BankCardTypeId);
            $bankCardCode.val(item.BankCardCode);
            /**********************************/
            $addressNow.val(item.AddressNow);
        } else {
            $controlContainer.find(":input").each(function() {
                if ($(this).attr("type") == "radio") {
                    $(this).removeProp("checked");
                } else {
                    $(this).val("");
                }
            });
        }
        angel.teamWorkerMgmtPicControl.init(item);
        angel.teamWorkerMgmtIdentityControl.init(item);

        $controlContainer.modal({ backdrop: "static", keyboard: false });
        $controlContainer.modal("show");
        $submitButton.blur();
        $cancelButton.blur();
    };

    that.hide = function() {
        $controlContainer.modal("hide");
    };

    that.newItem = function() {
        var dto = {
            Id: $teamWorkerId.val(),
            TeamId: $teamId.val(),
            WorkerId: $workerId.val(),
            InTime: $inTime.val(),
            OutTime: $outTime.val(),
            Mobile: $mobile.val(),
            Status: $status.val(),
            BankCardTypeId: $bankCardTypeId.val(),
            BankCardCode: $bankCardCode.val(),
            /**********************************/
            AddressNow: $addressNow.val()
        };
        dto = angel.teamWorkerMgmtPicControl.get(dto);
        dto = angel.teamWorkerMgmtIdentityControl.get(dto);
        return dto;
    };
    return that;
})(jQuery);