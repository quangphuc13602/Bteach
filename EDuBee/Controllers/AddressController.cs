using EDuBee.Application.Address;
using EDuBee.Classes;
using EDuBee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EDuBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IManageAddress _manageAddress;
        private static List<Province> ListTinhThanh;
        public AddressController(IHttpClientFactory httpClientFactory, IManageAddress manageAddress)
        {
            _httpClientFactory = httpClientFactory;
            _manageAddress = manageAddress;
        }
        [HttpGet("Province")]
        public IActionResult GetProvince()
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://api.mysupership.vn");
            var response = client.GetAsync("v1/partner/areas/province").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            ResultCallApiProvince resultCallApiTinhThanh = JsonSerializer.Deserialize<ResultCallApiProvince>(jsonData);

            ListTinhThanh = new List<Province>();
            foreach (var tt in resultCallApiTinhThanh.results)
            {
                Province tinhThanh = new Province();
                tinhThanh.Idprovince = int.Parse(tt.code);
                tinhThanh.Name = tt.name;
                ListTinhThanh.Add(tinhThanh);
            }
            return Ok(ListTinhThanh);
        }
        
        [HttpGet("District")]
        public List<District> GetDistrict([FromQuery] int IdProvince)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://api.mysupership.vn");
            var response = client.GetAsync("v1/partner/areas/district?province="+IdProvince).Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            ResultCallApiDistrict resultCallApiQuanHuyen = JsonSerializer.Deserialize<ResultCallApiDistrict>(jsonData);

            List<District> ListDistrict = new List<District>();
            foreach (var qh in resultCallApiQuanHuyen.results)
            {
                District quanHuyen = new District();
                quanHuyen.Iddistrict = int.Parse(qh.code);
                quanHuyen.Name = qh.name;
                quanHuyen.Idprovince = IdProvince;
                ListDistrict.Add(quanHuyen);
            }
            return ListDistrict;
        }
        
        [HttpGet("Ward")]
        public List<Ward> GetWard([FromQuery] int IdDistrict)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://api.mysupership.vn");
            var response = client.GetAsync("v1/partner/areas/commune?district=" + IdDistrict).Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            ResultCallApiWard resultCallApiWard = JsonSerializer.Deserialize<ResultCallApiWard>(jsonData);

            List<Ward> ListWard = new List<Ward>();
            foreach (var px in resultCallApiWard.results)
            {
                Ward ward = new Ward();
                ward.Idward = int.Parse(px.code);
                ward.Name = px.name;
                ward.Iddistrict = IdDistrict;
                ListWard.Add(ward);
            }
            return ListWard;
        }

        [HttpPost("InsertProvince")]
        public IActionResult InsertProvince()
        {
            _manageAddress.CreateProvince(ListTinhThanh);
            return Ok();

        }

        [HttpPost("InsertDistrict")]
        public IActionResult InsertDistrict()
        {
            foreach(var province in ListTinhThanh)
            {
                List<District> ListDistrict = new List<District>();
                ListDistrict = GetDistrict(province.Idprovince);
                _manageAddress.CreateDistrict(ListDistrict);
            }
            return Ok();
        }

        [HttpPost("InsertWard")]
        public IActionResult InsertWard()
        {
            var ListDistrict = _manageAddress.GetDistricts();
            foreach(var district in ListDistrict)
            {
                List<Ward> ListWard = new List<Ward>();
                ListWard = GetWard(district.Iddistrict);
                _manageAddress.CreateWard(ListWard);
            }
            return Ok();
        }

        [HttpGet("GetDistrictByIdProvince")]
        public IActionResult GetDistrictByIdProvince([FromQuery] int IdProvince)
        {
            var rs = _manageAddress.GetDistrictsByIdProvince(IdProvince);
            return Ok(rs);
        }
        [HttpGet("GetProvince")]
        public IActionResult GetListProvince()
        {
            var rs = _manageAddress.GetProvince();
            return Ok(rs);
        }
        [HttpGet("GetWard")]
        public IActionResult GetWardByIdDistrict([FromQuery] int IdDistrict)
        {
            var rs = _manageAddress.GetWardByIdDistrict(IdDistrict);
            return Ok(rs);
        }
    }
}
