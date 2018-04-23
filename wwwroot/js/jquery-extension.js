$(function () {
    $(document).ajaxStart(function () {

        $.blockUI();

        //$.blockUI({
        //    message: '<div class="sk-folding-cube">< div class= "sk-cube1 sk-cube" ></div><div class="sk-cube2 sk-cube"></div><div class="sk-cube4 sk-cube"></div><div class="sk-cube3 sk-cube"></div></div><div class="sk-folding-cube">< div class= "sk-cube1 sk-cube" ></div><div class="sk-cube2 sk-cube"></div><div class="sk-cube4 sk-cube"></div><div class="sk-cube3 sk-cube"></div></div>'});
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