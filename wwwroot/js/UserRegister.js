﻿$(function () {
    
    var UserRegisterButton = $("#registrationModal button[name='Register']").click(onUserRegisterClick);
    function onUserRegisterClick() {
     
        var URL = "/UserAuth/RegisterUser";
        var antiForgeryToken = $("#registrationModal input[name='__RequestVerificationToken']").val();
        var Email = $('#registrationModal input[name="Email"]').val();
        var Password = $('#registrationModal input[name="Password"]').val();
        var FirstName = $('#registrationModal input[name="FirstName"]').val();
        var LastName = $('#registrationModal input[name="LastName"]').val();
        var Address = $('#registrationModal input[name="Address"]').val();
        var PostCode = $('#registrationModal input[name="PostCode"]').val();
      

        var userInput = {
            Email: Email,
            Password: Password,
            FirstName: FirstName,
            LastName: LastName,
            Address: Address,
            PostCode: PostCode,
            __RequestVerificationToken: antiForgeryToken

        };

        $.ajax({
            type:"POST",
            url:URL,
            data:userInput,
            success:function (data) {
                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == "true";
                if (hasErrors) {
                    $('#registrationModal').html(data);
                    UserRegisterButton = $("#registrationModal button[name='Register']").click(onUserRegisterClick);
                    //var form = $("#UserLoginForm");
                    //$(form).removeData("validator");
                    //$(form).removeData("unobtrusiveValidation");
                    //$.validator.unobstrusive.parse(form);
                } else {
                    location.href = "/Home/Index";
                    
                }
            },

            error: function (xhr, ajaxOptions, thrownerror) {
                console.error(thrownerror + "\r\n" + xhr.statusText);
            }
        });
    }

});