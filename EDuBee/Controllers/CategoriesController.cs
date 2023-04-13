using EDuBee.Application.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IManageCategory _manageCategory;
        public CategoriesController(IManageCategory manageCategory)
        {
            _manageCategory = manageCategory;
        }

        [HttpGet]
        public IActionResult GetCategory([FromQuery] string cate)
        {
            var rs = _manageCategory.GetListCategories(cate);
            return Ok(rs);
        }
    }
}
