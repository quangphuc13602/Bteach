$('#btn-register').click(function (ev) {
            ev.preventDefault();
            var username = $('#username_register').val();
            var password = $('#password_register').val();
            var fullName = $('#fullName').val();
            var phoneNumber = $('#phoneNumber').val();
            var email = $('#email').val();

            var urlLogin = 'https://localhost:5001/api/Account/Register';
            console.log(username, password, fullName, phoneNumber, email, urlLogin);

            $.ajax({
                url: urlLogin,
                type: 'POST',
                data: {
                    UserName: username,
                    PassWord: password,
                    FullName: fullName,
                    PhoneNumber: phoneNumber,
                    Email:email

                },
                success: function (res) {
                    // if (res == 1) {
                    //     location = "http://localhost:5500/index.html";
                    // }
                    // if (res == -1) {
                    //     //error = 'Mật khẩu không đúng';
                    // }
                    // let error = '';
                    // if (res == -2) {
                    //     error = 'Tài khoản không tồn tài';
                    // }
                    // if (res == -1) {
                    //     error = 'Mật khẩu không đúng';
                    // }

                    // let _html_error =
                    //     '<div class="alert alert-danger">' +
                    //     '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>'
                    //     + error
                    //     + '</div>';
                    // $('#error').html(_html_error);

                    console.log(res)
                }
            });
        });