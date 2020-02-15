$(document).ready(function() {
    var $refreshAllDeviceFaceLibraryButton = $("#refreshAllDeviceFaceLibraryButton");
    var $activeMenuulName = $("#activeMenuulName");
    var $refreshDeviceFaceLibraryButton = $("#refreshDeviceFaceLibraryButton");
    var $deviceId = $("#deviceId");
    var $searchText = $("#searchText");
    var $state = $("#state");
    var $searchButton = $("#searchButton");
    var $grid = $("#list");
    var gridPager = "#listPager";

    var gridUrl = function() {
        var listUrl = "../FaceDeviceDeleted/GetWorkerList?deviceId={deviceId}&keywords={keywords}&state={state}";
        listUrl = listUrl.replace("{deviceId}", $deviceId.val());
        listUrl = listUrl.replace("{keywords}", $searchText.val());
        listUrl = listUrl.replace("{state}", $state.val());
        return listUrl;
    };

    var reloadGrid = function() {
        $grid.clearGridData();
        $grid.setGridParam({ url: gridUrl() });
        $grid.trigger("reloadGrid");
    };
    var initializeGrid = function() {
        var colNames = ["姓名", "证件号", "手机", "性别", "民族", "地址", "状态"];
        var colModel = [
            { name: "name", index: "name", width: 80, sortable: false },
            { name: "name", index: "name", width: 100, sortable: false },
            { name: "name", index: "name", width: 90, sortable: false },
            { name: "name", index: "name", width: 80, sortable: false },
            { name: "name", index: "name", width: 80, sortable: false },
            { name: "name", index: "name", width: 160, sortable: false },
            { name: "name", index: "name", width: 80, sortable: false }
        ];
        var url = gridUrl();
        angel.jqGrid.setGridUrl(url);
        angel.jqGrid.setGridSortorder("");
        angel.jqGrid.setGridCompleteHandler(function() {
            $('a[name="selectItem"]', $grid).click(function() {
                var wokerId = $(this).attr("wokerId");
                angel.openWnd("../TeamWorker/TeamWorkerDetail?id=" + wokerId);
            });
            $('a[name="initNewDelStatusBtn"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                var itemName = $(this).attr("itemName");
                var initNewStatusMsg = "确认要设置<{itemName}>状态为新删除吗?".replace("{itemName}", itemName);
                angel.confirm(initNewStatusMsg,
                    function() {
                        angel.ajaxPost("../FaceRecognition/PutDeviceWorkerInitNewDelStatus",
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

    $('a[name="deviceCode"]').click(function() {
        $deviceId.val($(this).attr("itemid"));
        $activeMenuulName.text($(this).text());
        $searchText.val("");
        $(".tree-menu li.active").removeClass("active");
        $(this).closest("li").addClass("active");
        reloadGrid();
    });

    $refreshDeviceFaceLibraryButton.click(function() {
        if (!$deviceId.val()) {
            angel.alert("当前没有选中的设备");
            return false;
        }
        angel.alert("正在通知设备...");
        $.getJSON("../FaceDevice/GetDevice?id=" + $deviceId.val(),
            function(result) {
                if (result.IpAddress) {
                    var durl = "http://" + result.IpAddress + ":8080/?action=2";
                    angel.ajaxGet(durl,
                        function() {
                            angel.alert("发送通知完成");
                        },
                        function(xmlHttpRequest, textStatus, errorThrown) {
                            var msg = "出现错误:";
                            msg = msg + " xmlHttpRequest.status=" + xmlHttpRequest.status;
                            msg = msg + " xmlHttpRequest.readyState=" + xmlHttpRequest.readyState;
                            msg = msg + " textStatus=" + textStatus;
                            msg = msg + " errorThrown=" + errorThrown;
                            angel.alert(msg);
                        });
                }
            });
        return false;
    });

    $refreshAllDeviceFaceLibraryButton.click(function() {
        angel.alert("正在通知设备...");
        $.getJSON("../FaceDevice/PutAllDeviceSyncFaces",
            function(result) {
                if (result.result == 0) {
                    angel.alert("发送通知完成");
                } else {
                    angel.alert(result.resultValue);
                }
            });
        return false;
    });

    $(window).bind("resize", function() { angel.jqGrid.initializeGridWidth($grid); });

    initializeGrid();
});