angel.jqGrid = (function() {
    $.jgrid.defaults.styleUI = "Bootstrap";
    var gridUrl;
    var gridAddFunction;
    var gridMultiselect = false;
    var gridDatatype = "json";
    var gridSortname = null;
    var sortorder = "asc"; //desc
    var greidHeight = $(window).height() * 0.6;
    var gridWidth = 0;
    var gridAutowidth = true; //false
    var gridRowNum = 15;
    var gridRowList = [15, 20, 30];
    var gridAddtext = ""; //添加;
    var gridRownumbers = false;
    var gridCompleteHandler = function() {
    };
    var gridSelectRowHandler = function() {
    };

    var that = {};

    that.initializeGridWidth = function(gridElement, width) {
        var gridElementId = gridElement.attr("id");
        var gviewElement = $("#gview_" + gridElementId);
        if (!width) {
            width = $(".jqGrid_wrapper").width() - 2;
        }
        gridElement.setGridWidth(width);
        $(".ui-jqgrid-htable", gviewElement).width($(".ui-jqgrid-hdiv", gviewElement).width() - 1);
        $(".ui-jqgrid-btable", gviewElement).width($(".ui-jqgrid-hdiv", gviewElement).width());
        //$('.ui-jqgrid-title', gviewElement).css('color', '#F5F5F5');
        $(".ui-jqgrid-title", gviewElement).css("color", "white");
    };

    that.setGridUrl = function(url) {
        gridUrl = url;
    };

    that.setGridDatatype = function(value) {
        gridDatatype = value;
    };

    that.setGridSortname = function(value) {
        gridSortname = value;
    };

    that.setGridSortorder = function(value) {
        sortorder = value;
    };

    that.setMultiselect = function() {
        gridMultiselect = true;
    };

    that.setGridAddfunc = function(addFunction) {
        gridAddFunction = addFunction;
    };

    that.setGridAddtext = function(value) {
        gridAddtext = value;
    };

    that.setGridRownumbers = function(value) {
        gridRownumbers = value;
    };

    that.setGridHeight = function(value) {
        greidHeight = value;
    };

    that.setGridWidth = function(value) {
        gridWidth = value;
    };

    that.setGridAutowidth = function(value) {
        gridAutowidth = value;
    };

    that.setGridRowNum = function(value) {
        gridRowNum = value;
    };

    that.setGridRowList = function(value) {
        gridRowList = value;
    };

    that.setGridCompleteHandler = function(value) {
        if ($.isFunction(value)) {
            gridCompleteHandler = value;
        }
    };

    that.setSelectRowHandler = function(value) {
        if ($.isFunction(value)) {
            gridSelectRowHandler = value;
        }
    };

    that.initialize = function($element, gridPager, gridColNames, gridColModel, gridCaption) {
        $element.jqGrid({
            url: gridUrl,
            datatype: gridDatatype,
            colNames: gridColNames,
            colModel: gridColModel,
            caption: gridCaption,
            hidegrid: false,
            sortname: gridSortname,
            sortorder: sortorder,
            shrinkToFit: true, //false
            pager: gridPager,
            rowNum: gridRowNum,
            rowList: gridRowList,
            viewrecords: true,
            rownumbers: gridRownumbers,
            multiselect: gridMultiselect,
            height: greidHeight,
            width: gridWidth,
            autowidth: gridAutowidth,
            gridComplete: gridCompleteHandler,
            onSelectRow: gridSelectRowHandler
        });

        var pager = {
            refresh: true,
            search: false,
            edit: false,
            add: false,
            del: false
        };

        if (gridAddFunction) {
            pager.add = true;
            pager.addfunc = gridAddFunction;
            pager.addtext = gridAddtext;
        }
        $element.jqGrid("navGrid", gridPager, pager, { height: 200, reloadAfterSubmit: true });
    };

    return that;
})(jQuery);