using EDuBee.Application.Account;
using EDuBee.Application.MD5;
using EDuBee.Application.SendMail;
using EDuBee.Classes;
using EDuBee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly EDUBEE1Context _context;
        private readonly IManageAccount _manageAccount;
        private readonly IMailService _mailService;
        private static int _code;
        private static string _username;

        public AccountController(EDUBEE1Context context, IManageAccount manageAccount, IMailService mailService)
        {
            _context = context;
            _manageAccount = manageAccount;
            _mailService = mailService;
        }
        [HttpGet("GetUser")]
        public IActionResult getAccount(string username)
        {
            var rs = _manageAccount.GetUSerAccountByUserName(username);
            return Ok(rs);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var account = _manageAccount.GetUSerAccountByUserName(request.UserName);
            if (account == null)
                return Ok(-2);
            if(account.Password != request.PassWord.ToMD5())
                return Ok(-1);
            if (account.Idrole == 2)
                return Ok(1);
            return Ok(0);
        }

        [HttpPost("SendCode")]
        public async Task<IActionResult> SendCode([FromForm] string username, [FromForm] string email)
        {
            _username = username;
            var checkMail = _manageAccount.CheckEmail(username, email);
            if (!checkMail)
                return Ok($"Tài khoản {username} không có email là {email}");
            Random random = new Random();
            _code = random.Next(100000, 999999);
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = email;
            mailRequest.Subject = "Mã đặt lại mật khẩu";
            mailRequest.Body = _code.ToString();
            await _mailService.SenEmailAsync(mailRequest);
            return Ok();
        }

        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromForm] string password, [FromForm] string confirmPassword, [FromForm] string code)
        {
            var c = _code;
            if (!password.Equals(confirmPassword))
                return Ok("Mật khẩu xác nhận không khớp");
            if(_code.ToString()!=code)
                return Ok("Mã xác nhận không đúng");
            _manageAccount.ResetPassword(_username, password);
            return Ok();
        }

        [HttpPost("Register")]
        public IActionResult Register([FromForm] RegisterAccount registerAccount)
        {
            var result = _manageAccount.Register(registerAccount);
            if (!result)
                return Ok($"Tài khoản {registerAccount.UserName} đã tồn tại");
            return Ok();
        }
    }
}
