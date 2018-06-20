
var Base = {
    _GridSelRows: [],
    SendAjax: function (para) {
        var data = {};

        if (para.data !== undefined) {
            data = para.data;
        }

        $.ajax({
            type: "POST",
            url: para.url,
            data: data,
            success: function (result) {
                if (typeof para.callback === "function") {
                    para.callback(result);
                }
            },
            error: function (result) {
                if (typeof para.callbackError === "function") {
                    para.callbackError(result);
                }
            },
            dataType: para.dataType
        });
    },
    Get: function (para) {
        var data = {};

        if (para.data !== undefined) {
            data = para.data;
        }

        $.get(para.url, data).done(function (result) {
            if (typeof para.callback === "function") {
                para.callback(result);
            }
        }).fail(function (result) {
            if (typeof para.callbackError === "function") {
                para.callbackError(result);
            }
        });
    },
    Success: function (title, message, autoClose, callback) {

        var data = {
            title: "Success"
        };


        if (title) {
            data.title = title;
        }

        if (message) {
            data.content = message;
        }

        $.confirm({
            title: data.title,
            content: message,
            type: "green",
            typeAnimated: true,
            buttons: {
                OK: function () {
                    if (typeof callback === "function") {
                        callback();
                    }
                }
            }
        });

        if (autoClose) {
            setTimeout(
                function () {
                    $("div.jconfirm-closeIcon")[0].click();
                },
                1000);
        }
    },
    Error: function (title, message, autoClose) {

        var data = {
            title: "Error"
        };

        if (title) {
            data.title = title;
        }

        if (message) {
            data.content = message;
        }

        $.confirm({
            title: data.title,
            content: message,
            type: "red",
            typeAnimated: true,
            buttons: {
                OK: function () { }
            }
        });

        if (autoClose) {
            setTimeout(
                function () {
                    $("div.jconfirm-closeIcon")[0].click();
                },
                1000);
        }
    }
};

$(function () {
});