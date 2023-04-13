using EDuBee.Application.MD5;
using EDuBee.Classes;
using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDuBee.Application.Account
{
    class ManageAccount : IManageAccount
    {
        private readonly EDUBEE1Context _context;
        public ManageAccount(EDUBEE1Context context)
        {
            _context = context;
        }

        public bool CheckEmail(string username, string email)
        {
            var account = GetUSerAccountByUserName(username);
            if (account.Email.Equals(email))
                return true;
            return false;
        }

        public UserAccount GetUSerAccountByUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;
            return _context.UserAccount.Where(x => x.UserName == username).FirstOrDefault();
        }

        public bool Register(RegisterAccount registerAccount)
        {
            var account = GetUSerAccountByUserName(registerAccount.UserName);
            if (account != null)
                return false;

            UserAccount userAccount = new UserAccount();
            userAccount.UserName = registerAccount.UserName;
            userAccount.Password = registerAccount.Password;
            userAccount.FullName = registerAccount.FullName;
            userAccount.Email = registerAccount.Email;
            userAccount.Phonenumber = registerAccount.Phonenumber;
            userAccount.Idrole = 1;
            userAccount.Idschool = registerAccount.Idschool;
            _context.UserAccount.Add(userAccount);
            _context.SaveChanges();
            return true;
        }

        public bool ResetPassword(string username, string password)
        {
            var account = GetUSerAccountByUserName(username);
            account.Password = password.ToMD5();
            _context.SaveChanges();
            return true;

        }
    }
}
