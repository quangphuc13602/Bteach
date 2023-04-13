using EDuBee.Application.Documents;
using EDuBee.Classes;
using EDuBee.Models;
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
    public class DocumentController : ControllerBase
    {
        private readonly IManageDocument _manageDocument;
        public DocumentController(IManageDocument manageDocument)
        {
            _manageDocument = manageDocument;
        }
        [HttpGet]
        public IActionResult GetDocument([FromQuery] string cate, bool? status)
        {
            var rs = _manageDocument.GetDocuments(cate, status);
            return Ok(rs);
        }

        //lấy 8 bài mới nhất
        [HttpGet("Document_New")]
        public IActionResult GetDocumentNew([FromQuery] string cate)
        {
            var rs = _manageDocument.GetDocuments(cate,true);
            rs.OrderByDescending(x=>x.CreateDate);
            return Ok(rs);
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm] FileDocument file)
        {
            int id = await _manageDocument.UplodaDocument(file);
            return Ok();
        }

        [HttpPut("EditDocument")]
        public async Task<IActionResult> EditDocument([FromForm] int idDocument, [FromForm] EditDoc editDoc)
        {
            Document document = await _manageDocument.EditDocument(idDocument, editDoc);
            return Ok(document);
        }

        [HttpDelete("DeleteDocument")]
        public IActionResult DeleteDocument(int idDocument)
        {
            var rs = _manageDocument.DeleteDocument(idDocument);
            return Ok(rs);
        }

        [HttpGet("8_Document")]
        public IActionResult _8_Document(int cate)
        {
            return Ok(_manageDocument.Get_8_Documents(cate, 8));
        }

        [HttpGet("Attribute")]
        public IActionResult GetAttribute(string name)
        {
            var rs = _manageDocument.GetListAttribute(name);
            return Ok(rs);
        }
    }
}
