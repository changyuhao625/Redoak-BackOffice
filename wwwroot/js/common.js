
var Base = {
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
    Success: function (title, message, autoClose) {

        var data = {
            title: 'Success'
        };



        if (title) {
            data.title = title;
        }

        if (message) {
            data.content = message;
        }

        $.dialog(data);
        if (autoClose) {
            setTimeout(
                function () {
                    $('div.jconfirm-closeIcon')[0].click();
                }, 1000);
        }
    }

    //Success: function (title, message, buttons, autoClose) {

    //    var data = {
    //        title: 'Success',
    //        buttons: {}
    //    };
    //    if (buttons) {
    //        data.buttons = buttons;
    //    }

    //    if (autoClose) {
    //        data.autoClose = true;
    //    }

    //    if (title) {
    //        data.title = title;
    //    }

    //    if (message) {
    //        data.content = message;
    //    }

    //    $.confirm(data);
    //}
};

$(function () {
})