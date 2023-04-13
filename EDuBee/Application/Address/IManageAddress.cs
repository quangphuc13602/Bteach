using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Application.Address
{
    public interface IManageAddress
    {
        void CreateProvince(List<Province> provinces);
        void CreateDistrict(List<District> districts);
        List<District> GetDistrictsByIdProvince(int IdProvince);
        List<District> GetDistricts();
        List<Province> GetProvince();
        List<Ward> GetWardByIdDistrict(int IdDistrict);
        void CreateWard(List<Ward> wards);
    }
}
