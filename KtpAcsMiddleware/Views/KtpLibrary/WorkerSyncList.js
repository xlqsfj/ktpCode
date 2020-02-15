$(document).ready(function() {
    var $activeMenuulName = $("#activeMenuulName");
    var $teamId = $("#teamId");
    var $searchText = $("#searchText");
    var $syncState = $("#syncState");
    var $searchButton = $("#searchButton");
    var $grid = $("#list");
    var gridPager = "#listPager";

    var gridUrl = function() {
        $.ajaxSetup({ cache: false });
        var listUrl = "../KtpLibraryApi/GetWorkerSyncList?keywords={keywords}&teamId={teamId}&state={state}";
        listUrl = listUrl.replace("{teamId}", $teamId.val());
        listUrl = listUrl.replace("{keywords}", $searchText.val());
        listUrl = listUrl.replace("{state}", $syncState.val());
        return listUrl;
    };

    var reloadGrid = function() {
        $grid.clearGridData();
        $grid.setGridParam({ url: gridUrl() });
        $grid.trigger("reloadGrid");
    };

    var initializeGrid = function() {
        var colNames = ["姓名", "证件号", "最近操作", "当前状态", "最近返回值", "最近返回信息", "手机号码"];
        var colModel = [
            { name: "name", index: "name", width: 60, sortable: false },
            { name: "name", index: "name", width: 100, sortable: false },
            { name: "name", index: "name", width: 60, sortable: false },
            { name: "name", index: "name", width: 70, sortable: false },
            { name: "name", index: "name", width: 70, sortable: false },
            { name: "name", index: "name", width: 100, sortable: false },
            { name: "name", index: "name", width: 70, sortable: false }
        ];
        var url = gridUrl();
        angel.jqGrid.setGridUrl(url);
        angel.jqGrid.setGridSortorder("");
        angel.jqGrid.setGridCompleteHandler(function() {
            $('a[name="selectItem"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                angel.openWnd("../TeamWorker/TeamWorkerDetail?id=" + itemId);
            });
            $('a[name="resetSyncStateBtn"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                var itemName = $(this).attr("itemName");
                var typeText = $(this).attr("typeText");
                var initNewStatusMsg = "确认要设置<{itemName}>状态为新{typeText}吗?"
                    .replace("{itemName}", itemName).replace("{typeText}", typeText);
                angel.confirm(initNewStatusMsg,
                    function() {
                        angel.ajaxPost("../KtpLibraryApi/PutWorkerSyncInitNewStatus",
                            { id: itemId },
                            function(data) {
                                var result = $.parseJSON(data);
                                if (result.result == 0) {
                                    angel.alert("设置成功", function() { reloadGrid(); });
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

    $(window).bind("resize", function() { angel.jqGrid.initializeGridWidth($grid); });

    initializeGrid();
});