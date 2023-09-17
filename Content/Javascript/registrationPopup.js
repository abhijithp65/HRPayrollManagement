$(document).ready(function () {
    if (registrationSuccess === true) {
     
        $("#registrationSuccessDialog").dialog({
            modal: true,
            buttons: {
                "Sign In": function () {
                  
                    window.location.href = '/Account/SignIn';
                },
                "OK": function () {
                    
                    $('#registrationForm input[type="text"]').val('');
                    $('#registrationForm input[type="password"]').val('');
                    $('#registrationForm input[type="radio"]').prop('checked', false);
                    $('#registrationForm input[type="checkbox"]').prop('checked', false);
                    $('#registrationForm select').val('');
                    $('#registrationForm textarea').val('');

                    $(this).dialog("close");
                }
            }
        });
    }
});
