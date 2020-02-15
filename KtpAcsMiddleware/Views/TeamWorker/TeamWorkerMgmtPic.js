$(document).ready(function() { angel.teamWorkerMgmtPicControl.initialize(); });

angel.teamWorkerMgmtPicControl = (function($) {
    var $identityPicButton = $("#identityPicButton");
    var $identityPic = $("#identityPic");
    var $identityPicId = $("#identityPicId");
    var $identityPicFileName = $("#identityPicFileName");

    var $identityBackPicButton = $("#identityBackPicButton");
    var $identityBackPic = $("#identityBackPic");
    var $identityBackPicId = $("#identityBackPicId");
    var $identityBackPicFileName = $("#identityBackPicFileName");

    var $facePicButton = $("#facePicButton");
    var $facePic = $("#facePic");
    var $facePicId = $("#facePicId");
    var $facePicFileName = $("#facePicFileName");
    //var $identityFaceSim = $("#identityFaceSim");
    //var $createType = $("#createType");

    var $contractPicButton = $("#contractPicButton");
    var $contractPic = $("#contractPic");
    var $contractPicId = $("#contractPicId");
    var $contractPicFileName = $("#contractPicFileName");

    var that = {};

    that.initialize = function() {
        $contractPicButton.click(function() {
            angel.fileUploadControl.imgShow(
                function() {
                    var newItem = angel.fileUploadControl.newFile();
                    $contractPicId.val(newItem.Id);
                    $contractPicFileName.val(newItem.PhysicalFileName);
                    $contractPic.attr("src", newItem.PhysicalFileName);
                });
        });

        $identityPicButton.click(function() {
            angel.canvasUploadControl.imgShow(
                function() {
                    var newItem = angel.canvasUploadControl.newFile();
                    $identityPicId.val(newItem.Id);
                    $identityPicFileName.val(newItem.PhysicalFileName);
                    $identityPic.attr("src", newItem.PhysicalFileName);
                });
        });

        $identityBackPicButton.click(function() {
            angel.canvasUploadControl.imgShow(
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

        $identityPic.add($identityBackPic).add($facePic).add($contractPic).click(function() {
            if ($(this).attr("src")) {
                window.open($(this).attr("src"));
            }
        });
    };

    that.init = function(dto) {
        if (dto) {
            $facePicId.val(dto.FacePicId);
            $facePicFileName.val(dto.FacePicFileName);
            $identityPicId.val(dto.IdentityPicId);
            $identityPicFileName.val(dto.IdentityPicFileName);
            $identityBackPicId.val(dto.IdentityBackPicId);
            $identityBackPicFileName.val(dto.IdentityBackPicFileName);
            $contractPicId.val(dto.ContractPicId);
            $contractPicFileName.val(dto.ContractPicFileName);

            if (dto.IdentityPicFileName) {
                $identityPic.attr("src", dto.IdentityPicFileName);
            } else {
                $identityPic.removeAttr("src");
            }
            if (dto.IdentityBackPicFileName) {
                $identityBackPic.attr("src", dto.IdentityBackPicFileName);
            } else {
                $identityBackPic.removeAttr("src");
            }
            if (dto.FacePicFileName) {
                $facePic.attr("src", dto.FacePicFileName);
            } else {
                $facePic.removeAttr("src");
            }
            if (dto.ContractPicFileName) {
                $contractPic.attr("src", dto.ContractPicFileName);
            } else {
                $contractPic.removeAttr("src");
            }
        } else {
            $identityPic.removeAttr("src");
            $identityBackPic.removeAttr("src");
            $facePic.removeAttr("src");
            $contractPic.removeAttr("src");
        }
    };

    that.get = function(dto) {
        if (!dto) {
            dto = {};
        }
        dto.FacePicId = $facePicId.val();
        dto.FacePicFileName = $facePicFileName.val();
        dto.IdentityPicId = $identityPicId.val();
        dto.IdentityPicFileName = $identityPicFileName.val();
        dto.IdentityBackPicId = $identityBackPicId.val();
        dto.IdentityBackPicFileName = $identityBackPicFileName.val();
        dto.ContractPicId = $contractPicId.val();
        dto.ContractPicFileName = $contractPicFileName.val();
        return dto;
    };

    return that;
})(jQuery);