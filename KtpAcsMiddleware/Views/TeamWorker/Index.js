$(document).ready(function() {
    var $activeMenuulName = $("#activeMenuulName");
    var $teamId = $("#teamId");
    var $searchText = $("#searchText");
    var $authenticationState = $("#authenticationState");
    var $searchButton = $("#searchButton");
    var $createButton = $("#createButton");
    var $editTeamButton = $("#editTeamButton");
    var $grid = $("#list");
    var gridPager = "#listPager";

    var initDisplay = function() {
        $createButton.hide();
        $editTeamButton.hide();
        if ($teamId.val()) {
            $createButton.show();
            $editTeamButton.show();
        }
    };

    var gridUrl = function() {
        $.ajaxSetup({ cache: false });
        var listUrl = "GetTeamWorkerList?teamId={teamId}&keywords={keywords}&authenticationState={authenticationState}";
        listUrl = listUrl.replace("{teamId}", $teamId.val());
        listUrl = listUrl.replace("{keywords}", $searchText.val());
        listUrl = listUrl.replace("{authenticationState}", $authenticationState.val());
        return listUrl;
    };

    var reloadGrid = function() {
        $grid.clearGridData();
        $grid.setGridParam({ url: gridUrl() });
        $grid.trigger("reloadGrid");
    };
    var initializeGrid = function() {
        var colNames = ["姓名", "证件号", "手机", "性别", "民族", "地址", "状态", "选择"];
        var colModel = [
            { name: "name", index: "name", width: 60, sortable: false },
            { name: "name", index: "name", width: 100, sortable: false },
            { name: "name", index: "name", width: 60, sortable: false },
            { name: "name", index: "name", width: 130, sortable: false },
            { name: "name", index: "name", width: 70, sortable: false },
            { name: "name", index: "name", width: 100, sortable: false },
            { name: "name", index: "name", width: 60, sortable: false },
            { name: "name", index: "name", width: 93, sortable: false }
        ];
        var url = gridUrl();
        angel.jqGrid.setGridUrl(url);
        angel.jqGrid.setGridSortorder("");
        angel.jqGrid.setGridCompleteHandler(function() {
            $('a[name="selectItem"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                angel.openWnd("TeamWorkerDetail?id=" + itemId);
            });
            $('a[name="selectBtn"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                $.getJSON("GetTeamWorker?id=" + itemId,
                    function(result) {
                        angel.teamWorkerMgmtControl.show(result,
                            function() {
                                var newItem = angel.teamWorkerMgmtControl.newItem();
                                angel.ajaxPost("PutTeamWorker",
                                    { dto: newItem, id: itemId },
                                    function(data) {
                                        var result = $.parseJSON(data);
                                        if (result.result == 0) {
                                            angel.alert("更新成功",
                                                function() {
                                                    angel.teamWorkerMgmtControl.hide();
                                                    reloadGrid();
                                                });
                                        } else {
                                            angel.alert(result.resultValue);
                                        }
                                    });
                            });
                    });
            });
            $('a[name="identityAuthenticationBtn"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                $.getJSON("GetTeamWorker?id=" + itemId,
                    function(result) {
                        angel.workerIdentityAuthenticationControl.show(result,
                            function() {
                                var newAuthentication = angel.workerIdentityAuthenticationControl.newItem();
                                angel.ajaxPost("PutWorkerAuthentication",
                                    { dto: newAuthentication, id: itemId },
                                    function(data) {
                                        var result = $.parseJSON(data);
                                        if (result.result == 0) {
                                            angel.alert("认证信息保存成功",
                                                function() {
                                                    angel.workerIdentityAuthenticationControl.hide();
                                                    reloadGrid();
                                                });
                                        } else {
                                            angel.alert(result.resultValue);
                                        }
                                    });
                            });
                    });
            });
            $('a[name="delBtn"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                var itemName = $(this).attr("itemName");
                var delMsg = "确认要删除<{itemName}>吗?".replace("{itemName}", itemName);
                angel.confirm(delMsg,
                    function() {
                        angel.ajaxPost("DelTeamWorker",
                            { id: itemId },
                            function(data) {
                                var result = $.parseJSON(data);
                                if (result.result == 0) {
                                    angel.alert("删除成功", function() { reloadGrid(); });
                                } else {
                                    angel.alert(result.resultValue);
                                }
                            });
                    });
            });
        });
        angel.jqGrid.initialize($grid, gridPager, colNames, colModel, null);
        angel.jqGrid.initializeGridWidth($grid);
    };

    $searchButton.click(function() { reloadGrid(); });

    $('a[name="teamName"]').click(function() {
        $teamId.val($(this).attr("itemid"));
        $activeMenuulName.text($(this).text());
        $searchText.val("");
        $(".tree-menu li.active").removeClass("active");
        $(this).closest("li").addClass("active");
        reloadGrid();
    });

    $createButton.click(function() {
        if (!$teamId.val()) {
            angel.alert("当前没有选中的班组");
            return false;
        }
        angel.teamWorkerMgmtControl.show(null,
            function() {
                var newItem = angel.teamWorkerMgmtControl.newItem();
                newItem.TeamId = $teamId.val();
                angel.ajaxPost("PutTeamWorker",
                    { dto: newItem, id: "" },
                    function(data) {
                        var result = $.parseJSON(data);
                        if (result.result == 0) {
                            angel.alert("新建成功",
                                function() {
                                    angel.teamWorkerMgmtControl.hide();
                                    reloadGrid();
                                });
                        } else {
                            angel.alert(result.resultValue);
                        }
                    });
            });
        return false;
    });
    initDisplay();
    $(window).bind("resize", function() { angel.jqGrid.initializeGridWidth($grid); });

    initializeGrid();
});