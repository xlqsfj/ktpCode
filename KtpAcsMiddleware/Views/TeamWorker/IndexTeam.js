$(document).ready(function() {
    var $teamId = $("#teamId");
    //var $activeMenuulName = $("#activeMenuulName");
    //var $removeTeamButton = $("#removeTeamButton");
    var $addTeamButton = $("#addTeamButton");
    var $editTeamButton = $("#editTeamButton");

    $addTeamButton.click(function() {
        angel.teamMgmtControl.show(null,
            function() {
                var newItem = angel.teamMgmtControl.newItem();
                angel.ajaxPost("../Team/PostTeam",
                    { dto: newItem },
                    function(data) {
                        var result = $.parseJSON(data);
                        if (result.result == 0) {
                            angel.alert("新建成功", function() { angel.reloadPage() });
                        } else {
                            angel.alert(result.resultValue);
                        }
                    });
            });
        return false;
    });

    $editTeamButton.click(function() {
        if (!$teamId.val()) {
            angel.alert("当前没有选中的班组");
            return false;
        }
        var teamId = $teamId.val();
        $.getJSON("../Team/GetTeam?id=" + teamId,
            function(result) {
                angel.teamMgmtControl.show(result,
                    function() {
                        var newItem = angel.teamMgmtControl.newItem();
                        newItem.Id = teamId;
                        angel.ajaxPost("../Team/PutTeam",
                            { dto: newItem, dtoId: teamId },
                            function(data) {
                                var result = $.parseJSON(data);
                                if (result.result == 0) {
                                    angel.alert("更新成功", function() { angel.reloadPage(); });
                                } else {
                                    angel.alert(result.resultValue);
                                }
                            });
                    });
            });
        return false;
    });

    //$removeTeamButton.click(function() {
    //    if (!$teamId.val()) {
    //        angel.alert("当前没有选中的班组");
    //        return false;
    //    }
    //    var delMsg = "确认要删除<{itemName}>吗?".replace("{itemName}", $activeMenuulName.text());
    //    angel.confirm(delMsg,
    //        function() {
    //            angel.ajaxPost("../Team/DelTeam",
    //                { id: $teamId.val() },
    //                function(data) {
    //                    var result = $.parseJSON(data);
    //                    if (result.result == 0) {
    //                        angel.alert("删除成功", function() { angel.reloadPage(); });
    //                    } else {
    //                        angel.alert(result.resultValue);
    //                    }
    //                });
    //        });
    //    return false;
    //});
});