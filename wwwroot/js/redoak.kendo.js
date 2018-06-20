$(function () {
    var kendo = window.kendo,
        ui = kendo.ui,
        Widget = ui.Widget;

    var RedoakGrid = Widget.extend({
        dataSource: null,
        detailInit: null,//2016/08/24 Darren 新增
        refresh: true,//2016/09/01 Darren 新增
        pageable: true,
        selectable: true,
        dbClickEnable: true,
        checkOptions: {
            enable: false,
            key:"",
            initialCheckValue: false
        },
        sortable: {
            mode: 'multiple',
            allowUnsort: true
        },
        init: function (element, options) {
            var that = this;
            // close paging
            if (options.dataSource.options.pageable === false) {
                that.pageable = options.dataSource.options.pageable;
            }
            // pageable裡可以做很多設定，在這裡面新增
            else {
                that.pageable = {
                    refresh: true,
                    pageSizes: [5, 10, 15, "all"]
                }
            }
            Widget.fn.init.call(that, element, options);
            if (that.checkOptions.enable) {
                that.checkOptions = options.checkOptions;
                options.columns.unshift({
                    field: "CheckRow",
                    title: "(kendo.format(input id='{0}CheckAll' Redoak-Control='Grid' type='checkbox' class='checkbox' , element.id))",
                    width: 40,
                    template: "kendo.format(input Grid-ID='{0}' Redoak-Control='Grid' type='checkbox' class='checkbox' , element.id)",
                    attribute: "{ style:thitext-aligncenter; }",
                    sortable: false
                });
            }

            if (!$.isEmptyObject(options.selectable)) {
                that.selectable = options.selectable;
            }
            if (!$.isEmptyObject(options.sortable)) {
                that.sortable = options.sortable;
            }
            if (!$.isEmptyObject(options.dataSource)) {
                //因為Schema 無法後來再指給他,只好重新new 一個DataSource起來重塞
                //這個做法式為了讓共用更好操作,使用者無需再自行設定Schema
                //trigger KendoGridRequest Model Binding
                that.dataSource = new kendo.data.DataSource({
                    schema: {
                        //取出資料陣列
                        data: function (d) { return d.data; },
                        //取出資料總筆數(計算頁數用)
                        total: function (d) { return d.total; }
                    },
                    pageSize: options.dataSource.options.pageSize,
                    serverPaging: options.dataSource.options.serverPaging,
                    serverSorting: options.dataSource.options.serverSorting
                });
                that.dataSource.transport = options.dataSource.transport;
                that.dataSource.transport.parameterMap = function (data, type) {
                    if (type === "read") {
                        //trigger KendoGridRequest Model Binding
                        //data.KendoGridRequest = null;
                        return data;
                    }
                };
            }

            this._initWidget(element, that, options);
        },
        _initWidget: function (element, that, options) {
            Base._GridSelRows[element.id] = null;
            var grid = $('#' + element.id).kendoGrid({
                pageable: that.pageable,
                columns: options.columns,
                dataSource: that.dataSource,
                sortable: that.sortable,
                resizable: true,
                allowCopy: true,
                scrollable: options.scrollable,
                groupable: options.groupable,
                selectable: that.selectable,
                detailInit: options.detailInit,
                dataBinding: function (e) {
                    var src = e.sender.dataSource;
                    record = (src._page - 1) * src._pageSize;
                },
                change: function (e) {
                    //點擊資料列事件
                    var selectedRows = e.sender.select();
                    //console.log(selectedRows);
                    var selectedDataItems = [];
                    for (var i = 0; i < selectedRows.length; i++) {
                        var dataItem = e.sender.dataItem(selectedRows[i]);
                        selectedDataItems.push(dataItem);
                    };
                    Base._GridSelRows[element.id] = selectedDataItems;

                    if ($.isFunction(options.OnChangeCallback)) {
                        options.OnChangeCallback(e);
                    }
                },
                dataBound: function (e) {
                    //把相關參數傳入
                    that.dataBound(that, element);
                    //dataBound 擴充事件
                    if ($.isFunction(that.options.dataBound)) {
                        that.options.dataBound(e);
                    }

                    //double click check
                    if ($.isFunction(options.dbClickCallBack)) {
                        that.element.find('tbody tr').on('dblclick', options.dbClickCallBack);
                    }
                },
            }).data("kendoGrid");

            if (options.toolTip) {
                //Tooltip
                $('#' + element.id).kendoTooltip({
                    filter: "td[style*='white-space:nowrap']",
                    autoHide: true,
                    position: "top",
                    width: "200px",
                    content: function (e) {
                        var content = e.target.text();
                        return content;
                    }
                }).data("kendoTooltip");
            }

            ////row select
            grid.table.on("click", "input[Redoak-Control='Grid']", function (e) {
                //Grid Checkbox click 事件
                that.onGridCheck(this, that, element);
            });

            //Select All
            grid.thead.on("click", "input[Redoak-Control='Grid']", function () {
                var isSelectAll = this.checked;

                $(kendo.format('input[Grid-ID="{0}"]', element.id)).each(function (i, item) {
                    if (isSelectAll) {
                        if (item.checked && isSelectAll) {
                        } else {
                            $(item).click();
                        }
                    } else {
                        if (item.checked) {
                            $(item).click();
                        }
                    }
                });
            });

        },
        dataBound: function (that, element) {
            //沒資料塞一列顯示"查無資料"
            var grid = $("#" + element.id).data("kendoGrid");
            if (grid.dataSource.view().length === 0) {
                var colCount = that.options.columns.length;
                $("#" + element.id).find('.k-grid-content tbody').append('<tr class="kendo-data-row"><td colspan="' +
                    colCount +
                    '" style="text-align:center"><b>查無資料!</b></td></tr>');
            }
        },
        options: {
            name: "RedoakGrid"
        },
        Refresh: function() {
            this.dataSource.read();
        }
    });
    ui.plugin(RedoakGrid);
})