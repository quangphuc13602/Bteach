using EDuBee.Application.Common;
using EDuBee.Classes;
using EDuBee.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EDuBee.Application.Documents
{
    public class ManageDocument : IManageDocument
    {
        private readonly EDUBEE1Context _context;
        private readonly IStorageService _storageService;

        public ManageDocument(EDUBEE1Context context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Document FindById(int idDocument)
        {
            var rs = _context.Document.Find(idDocument);
            if (rs == null)
                return null;
            return rs;
        }

        public bool DeleteDocument(int idDocument)
        {
            Document document = _context.Document.Find(idDocument);
            if (document == null)
                return false;
            _context.Document.Remove(document);
            _context.SaveChanges();
            return true;
        }

        public async Task<Document> EditDocument(int idDocument, EditDoc document)
        {
            Document oldDoc = _context.Document.Find(idDocument);
            if (document == null)
                return null;
            oldDoc.Name = document.Name;
            oldDoc.Price = document.Price;
            oldDoc.Idattribute = document.Idattribute;
            oldDoc.Idcategory = document.Idcategory;
            if (document.DocFile != null && document.FileImage != null)
            {
                oldDoc.File = await this.SaveFile(document.DocFile);
                oldDoc.Image = await this.SaveFile(document.FileImage);
            }
            _context.SaveChanges();
            return oldDoc;
        }

        public List<Document> GetDocuments(string cate, bool? status)
        {
            List<Document> listDocument = new List<Document>();
            if (cate == null)
            {
                listDocument = _context.Document.ToList();
            }
            else
            {
                List<int> listSubCate = _context.Category.Where(x => x.Cate == int.Parse(cate)).Select(x => x.Idcategory).ToList();
                listSubCate.Add(int.Parse(cate));
                foreach (var i in listSubCate)
                {
                    var listDoc = _context.Document.Where(x => x.Idcategory == i).ToList();
                    listDocument.AddRange(listDoc);
                }
            }
            
            if (status == null)
                return listDocument;
            else
                return listDocument.Where(x=>x.Status == status).ToList();
        }

        public async Task<int> UplodaDocument(FileDocument fileDocument)
        {
            Document document = new Document();
            if(fileDocument.DocFile != null && fileDocument.FileImage != null)
            {
                document.File = await this.SaveFile(fileDocument.DocFile);
                document.Image = await this.SaveFile(fileDocument.FileImage);
                document.Name = fileDocument.Name;
                document.Price = fileDocument.Price;
                document.Idcategory = fileDocument.Idcategory;
                document.Idattribute = fileDocument.Idattribute;
            }
            _context.Document.Add(document);
            await _context.SaveChangesAsync();
            return document.Iddocument;
        }

       

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public List<Document> Get_8_Documents(int cate, int n)
        {
            List<Document> documents = GetDocuments(cate.ToString(),true);
            documents = documents.OrderByDescending(x =>x.CreateDate).ToList();
            var d = documents;
            List<Document> listDoc = new List<Document>();
            int index = 1;
            foreach(Document doc in documents)
            {
                if (index > n)
                    break;
                listDoc.Add(doc);
                index++;

            }
            return listDoc;
        }

        public List<Models.Attribute> GetListAttribute(string name)
        {
            return _context.Attribute.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
        }
    }
}
