using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Application.Categories
{
    public class ManageCategory : IManageCategory
    {
        private readonly EDUBEE1Context _context;
        public ManageCategory(EDUBEE1Context context)
        {
            _context = context;
        }
        public List<Category> GetListCategories(string cate)
        {
            if (cate == null)
                return _context.Category.Where(x => x.Cate == null).ToList();
            return _context.Category.Where(x => x.Cate == int.Parse(cate)).ToList();
        }
    }
}
