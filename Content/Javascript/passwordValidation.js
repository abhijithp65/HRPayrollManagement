$(document).ready(function () {
    $('#Password, #ConfirmPassword').on('keyup', function () {
        var password = $('#Password').val();
        var confirmPassword = $('#ConfirmPassword').val();

        if (password === confirmPassword) {
            $('#passwordMatchMessage').html('Passwords match.').css('color', 'green');
        } else {
            $('#passwordMatchMessage').html('Passwords do not match.').css('color', 'red');
        }
    });
});
