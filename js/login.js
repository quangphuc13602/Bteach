$('#btn-login').click(function(ev){
    ev.preventDefault();
    var email = $('#lemail').val();
    var pass = $('#lpassword').val();
    var urlLogin = 'https://localhost:5001/api/Account/Login';
    console.log(email, pass, urlLogin);

    $.ajax({
        url: urlLogin,
        type:'POST',
        data:{
            username:email,
            password:pass,

        },
        success:function(res){
            if(res == 1){
                location = "http://localhost:5500/index.html";
            }
            if(res == -1){
                //error = 'Mật khẩu không đúng';
            }
            let error = '';
            if(res == -2){
                error = 'Tài khoản không tồn tài';
            }
            if(res == -1){
                error = 'Mật khẩu không đúng';
            }
            
                let _html_error = 
                '<div class="alert alert-danger">'+
                '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>'
                +error
                +'</div>';
                $('#error').html(_html_error);
                
            console.log(res)
        }
    });
});



