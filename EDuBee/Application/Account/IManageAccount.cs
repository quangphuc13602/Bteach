using EDuBee.Classes;
using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDuBee.Application.Account
{
    public interface IManageAccount
    {
        UserAccount GetUSerAccountByUserName(string username);

        bool CheckEmail(string username, string email);

        bool ResetPassword(string username, string password);

        bool Register(RegisterAccount registerAccount);

    }
}
