using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Application.Address
{
    public class ManageAddress : IManageAddress
    {
        private readonly EDUBEE1Context _context;
        public ManageAddress(EDUBEE1Context context)
        {
            _context = context;
        }

        public void CreateDistrict(List<District> districts)
        {
            foreach (var district in districts)
            {
                _context.District.Add(district);
                _context.SaveChanges();
            }
        }

        public void CreateProvince(List<Province> provinces)
        {
            foreach(var province in provinces)
            {
                _context.Province.Add(province);
                _context.SaveChanges();
            }
        }

        public void CreateWard(List<Ward> wards)
        {
            foreach (var ward in wards)
            {
                _context.Ward.Add(ward);
                _context.SaveChanges();
            }
        }

        public List<District> GetDistricts()
        {
            return _context.District.ToList();
        }

        public List<District> GetDistrictsByIdProvince(int IdProvince)
        {
            return _context.District.Where(x => x.Idprovince == IdProvince).ToList();
        }

        public List<Province> GetProvince()
        {
            return _context.Province.ToList();
        }

        public List<Ward> GetWardByIdDistrict(int IdDistrict)
        {
            return _context.Ward.Where(x => x.Iddistrict == IdDistrict).ToList();
        }
    }
}
