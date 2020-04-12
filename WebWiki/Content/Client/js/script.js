$(document).ready(function () {

    $('#workUser>div').css("display", "none");
    $('#infoUser').css("display", "block");

    $('#formUser div').hover(function (event) {
        $(this).css("cursor", "pointer");
    });

    $('#menuUser div').hover(function (event) {
        $(this).css("cursor", "pointer");
    });

    $('#menuUser div').click(function (e) {
        $('#menuUser div').css({ "color": "black", "font-weight": "400" });
        $(this).css({ "color": "#800000", "font-weight": "700" });
        $('#workUser>div').css("display", "none");
    });

    $('#menuInfo').click(function (e) {
        $('#infoUser').css("display", "block");
    });

    $('#menuPwd').click(function (e) {
        $('#changePwd').css("display", "block");
    });

    $('#menuInfoes').click(function (e) {
        $('#infoes').css("display", "block");
    });

    $('#menuNotify').click(function (e) {
        $('#notifies').css("display", "block");
    });

    $('#rePwdUser').focusout(function (e) {
        if ($('#rePwdUser').val() != $('#pwdUser').val()) {
            $('#ErrorPwd').css("display", "block");
            $('#btnSignUp').prop("disabled", true);
        } else {
            $('#ErrorPwd').css("display", "none");
            $('#btnSignUp').prop("disabled", false);
        }
    });

    $('#rePwdRegister').focusout(function(e){
        if ($('#rePwdRegister').val() != $('#pwdRegister').val()) {
            $('#ErrorPwdRegister').css("display", "block");
            $('#btnRegister').prop("disabled", true);
        } else {
            $('#ErrorPwdRegister').css("display", "none");
            $('#btnRegister').prop("disabled", false);
        }
    });
    $('#valueSearch').keyup(function () {
        if ($('#valueSearch').val() == "") {
            $('#fieldSearch').css("display", "none");
        } else {          
            $.post("/Client/SearchAjax", { valueSearch: $('#valueSearch').val() }).done(function (data) {
                var dt = jQuery.parseJSON(data);
                $('#fieldSearch').css("display", "block");
                $('#gridSearch').html("");
                dt.forEach(function (i) {
                    var newitem = document.createElement("a");
                    $(newitem).attr({
                        'href': '/Client/InfoDetail?idInfo=' + i.MaTT
                    });
                    $('#gridSearch').append($(newitem).text(i.ChuDeTT));
                    //document.getElementById("gridSearch").innerHTML += '<a href="" data-id=' + i.MaTT + '>' + i.ChuDeTT + '</a >';
                });
            });
        }
    });
    
});