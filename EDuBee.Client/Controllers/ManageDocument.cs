using EDuBee.Client.Models;
using EDuBee.Client.Service;
using EDuBee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Client.Controllers
{
    public class ManageDocument : Controller
    {
        private readonly IManageDocumentApiClient _manageDocumentApiClient;
        public ManageDocument(IManageDocumentApiClient manageDocumentApiClient)
        {
            _manageDocumentApiClient = manageDocumentApiClient;
        }
        public IActionResult Index(int categogyID)
        {
            var listCate = _manageDocumentApiClient.GetCategories();
            ViewBag.categogyID = new SelectList(listCate, "idcategory", "name");
            List<DocumentView> listDocument = new List<DocumentView>();
            if (categogyID != 0)
            {
                listDocument = _manageDocumentApiClient.GetDocument(categogyID);
            }
            else
            {
                listDocument = _manageDocumentApiClient.GetDocument();
            }
            return View(listDocument);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Subject = _manageDocumentApiClient.GetListAttribute("Mon");
            var Books = _manageDocumentApiClient.GetListAttribute("Bo sach");
            var Class = _manageDocumentApiClient.GetListAttribute("Lop");
            //ViewBag.Subject = SelectList(Subject,"")

            return View();
        }
    }
}
