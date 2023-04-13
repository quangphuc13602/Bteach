using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Application.Categories
{
    public interface IManageCategory
    {
        List<Category> GetListCategories(string cate);
    }
}
