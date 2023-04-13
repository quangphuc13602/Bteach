using EDuBee.Classes;
using EDuBee.Client.Models;
using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EDuBee.Client.Service
{
    public class ManageDocumentApiClient : IManageDocumentApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ManageDocumentApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<CategoryView> GetCategories()
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://localhost:5002");
            var response = client.GetAsync($"/api/Categories").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            List<CategoryView> listCategories = JsonSerializer.Deserialize<List<CategoryView>>(jsonData);
            return listCategories;
        }

        public List<DocumentView> GetDocument(int? cate=null)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://localhost:5002");
            var response =  client.GetAsync($"api/Document?cate={cate}").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            List<DocumentView> listDocument = JsonSerializer.Deserialize<List<DocumentView>>(jsonData);
            return listDocument;
        }

        public List<DocumentView> GetDocument()
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://localhost:5002");
            var response = client.GetAsync($"/api/Document").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            List<DocumentView> listDocument = JsonSerializer.Deserialize<List<DocumentView>>(jsonData);
            return listDocument;
        }

        public List<EDuBee.Models.Attribute> GetListAttribute(string name)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5002");
            var response = client.GetAsync($"/api/Document/Attribute?name={name}").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            List<EDuBee.Models.Attribute> listDocument = JsonSerializer.Deserialize<List<EDuBee.Models.Attribute>>(jsonData);
            return listDocument;
        }

        public async Task<int> UplodaDocument(FileDocument fileDocument)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(fileDocument);
            var httpContent = new StringContent(json, Encoding.UTF8, "multipart/form-data");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5002");
            var response = await client.PostAsync("/api/Account/Login", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return int.Parse(token);
        }
    }
}
