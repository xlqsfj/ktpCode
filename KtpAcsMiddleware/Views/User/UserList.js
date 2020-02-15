$(document).ready(function() {
    var $searchText = $("#searchText");
    var $userStatus = $("#userStatus");
    var $searchButton = $("#searchButton");
    var $createButton = $("#createButton");
    var $grid = $("#userList");
    var gridPager = "#userListPager";

    var gridUrl = function() {
        var listUrl = "GetUserList?keywords={keywords}&userStatus={userStatus}";
        listUrl = listUrl.replace("{keywords}", $searchText.val());
        listUrl = listUrl.replace("{userStatus}", $userStatus.val());
        return listUrl;
    };

    var initializeGrid = function() {
        var colNames = ["姓名", "登录名", "邮箱", "手机", "修改时间", "创建时间"];
        var colModel = [
            { name: "name", index: "name", width: 80, sortable: false },
            { name: "account", index: "account", width: 80, sortable: false },
            { name: "mail", index: "mail", width: 100, sortable: false },
            { name: "mobile", index: "mobile", width: 100, sortable: false },
            { name: "modifiedTime", index: "modifiedTime", width: 80, sortable: false },
            { name: "createTime", index: "createTime", width: 80, sortable: false }
        ];
        var url = gridUrl();
        angel.jqGrid.setGridUrl(url);
        angel.jqGrid.setGridSortorder("");
        angel.jqGrid.setGridCompleteHandler(function() {
            $('a[name="selectItem"]', $grid).click(function() {
                window.location.href = "UserDetail?id=" + $(this).attr("itemId");
            });
        });
        angel.jqGrid.initialize($grid, gridPager, colNames, colModel, null);
        angel.jqGrid.initializeGridWidth($grid);
    };

    $searchButton.click(function() {
        $grid.clearGridData();
        $grid.setGridParam({ url: gridUrl() });
        $grid.trigger("reloadGrid");
    });

    $createButton.click(function() {
        window.location.href = "UserDetail";
    });

    $(window).bind("resize", function() { angel.jqGrid.initializeGridWidth($grid); });

    initializeGrid();
});