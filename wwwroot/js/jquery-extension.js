$(function () {
    $(document).ajaxStart(function () {
        $.blockUI();
    });

    $(document).ajaxComplete(function () {
        $.unblockUI();
    });

    $(document).ajaxError(function (event, jqxhr, settings, thrownError) {
        $.unblockUI();
        Base.Error(null,jqxhr.responseText);
        //Base.Error(thrownError, jqxhr.responseText, false);
    });

    $.fn.serilizeFromJSON = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    }
})