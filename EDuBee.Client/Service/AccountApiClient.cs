using EDuBee.Classes;
using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using EDuBee.Client.Models;

namespace EDuBee.Client.Service
{
    public class AccountApiClient : IAccountApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountApiClient(IHttpClientFactory  httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserAccount> GetAccountByUserName(string username)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5002");
            var response = client.GetAsync("/api/Account/GetUser?username="+username).Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            UserAccount user = JsonSerializer.Deserialize<UserAccount>(jsonData);
            return user;
        }

        public List<ProvinceView> GetProvinces()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5002");
            var response = client.GetAsync("/api/Address/Province").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            List<ProvinceView> provinces = JsonSerializer.Deserialize<List<ProvinceView>>(jsonData);
            return provinces;
        }

        public async Task<string> Login(LoginRequest request )
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5002");
            var response = await client.PostAsync("/api/Account/Login", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        public bool Register(RegisterAccount registerAccount)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5002");
            var response = client.GetAsync("/api/Account/Register").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            bool result = JsonSerializer.Deserialize<bool>(jsonData);
            return result;
        }
    }
}
