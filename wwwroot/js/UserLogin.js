$(function () {
    
    var UserLoginButton = $("#loginModal button[name='login']").click(onUserLoginClick);
    function onUserLoginClick() {
        //alert();
        var URL = "UserAuth/Login";
        var antiForgeryToken = $("#loginModal input[name='__RequestVerificationToken']").val();
        var Email = $('#loginModal input[name="Email"]').val();
        var Password = $('#loginModal input[name="Password"]').val();
        var RememberMe = $('#loginModal input[name="RememberMe"]').prop('checked');

        var userInput = {
            Email: Email,
            Password: Password,
            RememberMe: RememberMe,
            __RequestVerificationToken: antiForgeryToken

        };

        $.ajax({
            type:"POST",
            url:URL,
            data:userInput,
            success:function (data) {
                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='LoginInvalid']").val() == "true";
                if (hasErrors) {
                    $('#loginModal').html(data);
                    UserLoginButton = $("#loginModal button[name='login']").click(onUserLoginClick);
                    //var form = $("#UserLoginForm");
                    //$(form).removeData("validator");
                    //$(form).removeData("unobtrusiveValidation");
                    //$.validator.unobstrusive.parse(form);
                } else {
                    location.href = "Home/Index";
                    
                }
            },

            error: function (xhr, ajaxOptions, thrownerror) {
                console.error(thrownerror + "\r\n" + xhr.statusText);
            }
        });
    }

});