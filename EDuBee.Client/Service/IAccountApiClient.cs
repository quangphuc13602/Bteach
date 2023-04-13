using EDuBee.Classes;
using EDuBee.Client.Models;
using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Client.Service
{
    public interface IAccountApiClient
    {
        Task<string> Login(LoginRequest request);

        bool Register(RegisterAccount registerAccount);
        Task<UserAccount> GetAccountByUserName(string username);

        List<ProvinceView> GetProvinces();
    }
}
