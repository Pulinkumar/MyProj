$(document).ready(function () {
    $(document).bind('ajaxStart', function () {
        $("#ErrorMsg").removeClass("val");
        $("#ErrorMsg").empty();
        $('#ContentPlaceHolder1_updProgress').show();
    }).bind('ajaxStop', function () {
        $('#ContentPlaceHolder1_updProgress').hide();
    });

    $("#txtEmail,#txtRTEmail").bind("cut copy paste", function (event) {
        return false;
    });
});

$(document).ajaxError(function (e, xhr) {
    if (xhr.status == 401) {
        window.location.href = $('#ErrorURL').val();
    } else {
        window.location.href = $('#ErrorURL').val();
    }
});
