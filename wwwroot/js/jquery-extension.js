$(function () {
    $(document).ajaxStart(function () {
        $.blockUI();
    });

    $(document).ajaxComplete(function () {
        $.unblockUI();
    });

    $(document).ajaxError(function () {
        $.unblockUI();
    });

})

//jconfirm.defaults = {
//    defaultButtons: {
        
//    },
//    autoClose: true
//};