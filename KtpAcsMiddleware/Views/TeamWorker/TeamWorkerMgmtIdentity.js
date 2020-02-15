$(document).ready(function() { angel.teamWorkerMgmtIdentityControl.initialize(); });

angel.teamWorkerMgmtIdentityControl = (function($) {
    var $identityButton = $("#identityButton");

    var $identityCodeCreditGradeWarning = $("#identityCodeCreditGradeWarning");
    var $identityCodeCreditGrade = $("#identityCodeCreditGrade");

    var $workerName = $("#workerName");
    var $sexMan = $("#sexMan");
    var $sexLady = $("#sexLady");
    var $identityCode = $("#identityCode");
    var $identityId = $("#identityId");
    var $birthday = $("#birthday");
    var $nation = $("#nation");
    var $addressNow = $("#addressNow");
    var $address = $("#address");
    var $issuingAuthority = $("#issuingAuthority");
    var $activateTime = $("#activateTime");
    var $invalidTime = $("#invalidTime");
    var $createType = $("#createType");
    var $identityFaceSim = $("#identityFaceSim");

    var readonlyIdentity = function() {
        $workerName.attr("readonly", "readonly");
        $identityCode.attr("readonly", "readonly");
        $address.attr("readonly", "readonly");
        $issuingAuthority.attr("readonly", "readonly");

        $sexLady.attr("disabled", "disabled");
        $sexMan.attr("disabled", "disabled");
        $birthday.attr("disabled", "disabled");
        $nation.attr("disabled", "disabled");
        $activateTime.attr("disabled", "disabled");
        $invalidTime.attr("disabled", "disabled");
    };
    var disReadonlyIdentity = function() {
        $workerName.removeAttr("readonly");
        $identityCode.removeAttr("readonly");
        $address.removeAttr("readonly");
        $issuingAuthority.removeAttr("readonly");

        $sexLady.removeAttr("disabled");
        $sexMan.removeAttr("disabled");
        $birthday.removeAttr("disabled");
        $nation.removeAttr("disabled");
        $activateTime.removeAttr("disabled");
        $invalidTime.removeAttr("disabled");
    };

    var that = {};

    that.initialize = function() {
        $identityButton.click(function() {
            angel.identityCardReaderrControl.show(
                function() {
                    var newItem = angel.identityCardReaderrControl.newCard();
                    $identityId.val(newItem.Id);
                    $workerName.val(newItem.Name);
                    $identityCode.val(newItem.Code);
                    $nation.val(newItem.Nation);
                    $address.val(newItem.Address);
                    $addressNow.val(newItem.Address);
                    $birthday.val(newItem.BirthdayText);
                    $issuingAuthority.val(newItem.IssuingAuthority);
                    $activateTime.val(newItem.ActivateTimeText);
                    $invalidTime.val(newItem.InvalidTimeText);
                    $createType.val(newItem.CreateType);
                    if (newItem.Sex == $sexLady.val()) {
                        $sexLady.prop("checked", "checked");
                    } else {
                        $sexMan.prop("checked", "checked");
                    }
                    readonlyIdentity();
                    var getIdentityCreditScoreUrl = "GetIdentityCreditScore?code=" + newItem.Code;
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
                                //$identityCodeCreditGrade.text(result.resultValue);
                                //$identityCodeCreditGradeWarning.fadeIn(1000);
                            });
                    }
                });
        });
    };

    that.init = function(dto) {
        if (dto) {
            $workerName.val(dto.WorkerName);
            $identityId.val(dto.IdentityId);
            $identityFaceSim.val(dto.IdentityFaceSim);
            $createType.val(dto.CreateType);
            $identityCodeCreditGrade.text(dto.CreditGrade);
            $identityCode.val(dto.IdentityCode);
            $nation.val(dto.Nation);
            $address.val(dto.Address);
            $birthday.val(dto.BirthdayText);
            $issuingAuthority.val(dto.IssuingAuthority);
            $activateTime.val(dto.ActivateTimeText);
            $invalidTime.val(dto.InvalidTimeText);
            if (dto.Sex == $sexLady.val()) {
                $sexLady.prop("checked", "checked");
            } else {
                $sexMan.prop("checked", "checked");
            }
            if (dto.CreateType == 0) {
                $identityButton.hide();
                readonlyIdentity();
            } else {
                $identityButton.show();
                disReadonlyIdentity();
            }
        } else {
            $identityCodeCreditGrade.text("");
            $sexLady.prop("checked", "");
            $sexMan.prop("checked", "");
            $createType.val(1);
            $identityButton.show();
            disReadonlyIdentity();
        }
    };

    that.get = function(dto) {
        if (!dto) {
            dto = {};
        }
        disReadonlyIdentity();
        var sex = $sexMan.val();
        if ($sexLady.prop("checked") == true) {
            sex = $sexLady.val();
        }
        dto.WorkerName = $workerName.val();
        dto.IdentityId = $identityId.val();
        dto.IdentityFaceSim = $identityFaceSim.val();
        dto.IdentityCode = $identityCode.val();
        dto.Sex = sex;
        dto.Nation = $nation.val();
        dto.Address = $address.val();
        dto.Birthday = $birthday.val();
        dto.IssuingAuthority = $issuingAuthority.val();
        dto.ActivateTime = $activateTime.val();
        dto.InvalidTime = $invalidTime.val();
        dto.CreditGrade = $identityCodeCreditGrade.text();
        dto.CreateType = $createType.val();

        readonlyIdentity();
        return dto;
    };

    return that;
})(jQuery);