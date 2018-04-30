$(function() {
    $(document).ajaxStart(function() {
        $.blockUI();
    });

    $(document).ajaxComplete(function() {
        $.unblockUI();
    });

    $(document).ajaxError(function(event, jqxhr, settings, thrownError) {
        $.unblockUI();
        Base.Error(thrownError, jqxhr.responseText, false);
    });

})