$(document).ready(function() {
    var $refreshAllDeviceFaceLibraryButton = $("#refreshAllDeviceFaceLibraryButton");
    var $activeMenuulName = $("#activeMenuulName");
    var $removeDeviceButton = $("#removeDeviceButton");
    var $addDeviceButton = $("#addDeviceButton");
    var $editDeviceButton = $("#editDeviceButton");
    var $initDeviceWorkerNewStateButton = $("#initDeviceWorkerNewStateButton");
    var $refreshDeviceFaceLibraryButton = $("#refreshDeviceFaceLibraryButton");
    var $deviceId = $("#deviceId");
    var $searchText = $("#searchText");
    var $state = $("#state");
    var $searchButton = $("#searchButton");
    var $addWorkerButton = $("#addWorkerButton");
    var $grid = $("#list");
    var gridPager = "#listPager";

    var gridUrl = function() {
        var listUrl = "GetDeviceWorkerList?deviceId={deviceId}&keywords={keywords}&state={state}";
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
        var colNames = ["姓名", "证件号", "手机", "性别", "民族", "地址", "状态", "返回值"];
        var colModel = [
            { name: "name", index: "name", width: 80, sortable: false },
            { name: "name", index: "name", width: 120, sortable: false },
            { name: "name", index: "name", width: 90, sortable: false },
            { name: "name", index: "name", width: 60, sortable: false },
            { name: "name", index: "name", width: 90, sortable: false },
            { name: "name", index: "name", width: 160, sortable: false },
            { name: "name", index: "name", width: 90, sortable: false },
            { name: "name", index: "name", width: 90, sortable: false }
        ];
        var url = gridUrl();
        angel.jqGrid.setGridUrl(url);
        angel.jqGrid.setGridSortorder("");
        angel.jqGrid.setGridCompleteHandler(function() {
            $('a[name="selectItem"]', $grid).click(function() {
                var wokerId = $(this).attr("wokerId");
                angel.openWnd("../TeamWorker/TeamWorkerDetail?id=" + wokerId);
            });
            $('a[name="initNewStatusBtn"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                var itemName = $(this).attr("itemName");
                var initNewStatusMsg = "确认要设置<{itemName}>状态为新添加吗?".replace("{itemName}", itemName);
                angel.confirm(initNewStatusMsg,
                    function() {
                        angel.ajaxPost("PutDeviceWorkerInitNewStatus",
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
            $('a[name="initNewDelStatusBtn"]', $grid).click(function() {
                var itemId = $(this).attr("itemId");
                var itemName = $(this).attr("itemName");
                var initNewStatusMsg = "确认要设置<{itemName}>状态为新删除吗?".replace("{itemName}", itemName);
                angel.confirm(initNewStatusMsg,
                    function() {
                        angel.ajaxPost("PutDeviceWorkerInitNewDelStatus",
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

    $addDeviceButton.click(function() {
        angel.deviceMgmtControl.show(null,
            function() {
                var newItem = angel.deviceMgmtControl.newItem();
                angel.ajaxPost("../FaceDevice/PostDevice",
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

    $editDeviceButton.click(function() {
        if (!$deviceId.val()) {
            angel.alert("当前没有选中的设备");
            return false;
        }
        var deviceId = $deviceId.val();
        $.getJSON("../FaceDevice/GetDevice?id=" + deviceId,
            function(result) {
                angel.deviceMgmtControl.show(result,
                    function() {
                        var putDeviceDto = angel.deviceMgmtControl.newItem();
                        putDeviceDto.Id = deviceId;
                        angel.ajaxPost("../FaceDevice/PutDevice",
                            { dto: putDeviceDto, dtoId: deviceId },
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

    $removeDeviceButton.click(function() {
        if (!$deviceId.val()) {
            angel.alert("当前没有选中的设备");
            return false;
        }
        var delMsg = "确认要删除<{itemName}>吗?".replace("{itemName}", $activeMenuulName.text());
        angel.confirm(delMsg,
            function() {
                angel.ajaxPost("../FaceDevice/DelDevice",
                    { id: $deviceId.val() },
                    function(data) {
                        var result = $.parseJSON(data);
                        if (result.result == 0) {
                            angel.alert("删除成功", function() { angel.reloadPage(); });
                        } else {
                            angel.alert(result.resultValue);
                        }
                    });
            });
        return false;
    });

    $initDeviceWorkerNewStateButton.click(function() {
        if (!$deviceId.val()) {
            angel.alert("当前没有选中的设备");
            return false;
        }
        angel.confirm("确认要将当前设备所有预添加或添加失败的数据都设为新添加吗?",
            function() {
                angel.ajaxPost("../FaceDevice/PutDeviceUnSyncAddWorkersToNewState?deviceId=" + $deviceId.val(),
                    { id: $deviceId.val() },
                    function(data) {
                        var result = $.parseJSON(data);
                        if (result.result == 0) {
                            angel.alert("设置成功", function() { reloadGrid(); });
                        } else {
                            angel.alert(result.resultValue);
                        }
                    });
            });
        return false;
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

    $addWorkerButton.click(function() {
        angel.workerSelectControl.show(function(worker) {
            angel.ajaxPost("PostDeviceWorker",
                { workerId: worker.Id, deviceId: $deviceId.val() },
                function(data) {
                    var result = $.parseJSON(data);
                    if (result.result == 0) {
                        angel.alert("添加成功", function() { reloadGrid(); });
                    } else {
                        angel.alert(result.resultValue);
                    }
                });
        });
    });

    $(window).bind("resize", function() { angel.jqGrid.initializeGridWidth($grid); });

    initializeGrid();
});