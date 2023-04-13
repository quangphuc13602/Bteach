using EDuBee.Classes;
using EDuBee.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attribute = EDuBee.Models.Attribute;

namespace EDuBee.Application.Documents
{
    public interface IManageDocument
    {
        List<Document> GetDocuments(string cate, bool? status);

        Task<int> UplodaDocument(FileDocument file);

        Task<Document> EditDocument(int idDocument, EditDoc document);

        bool DeleteDocument(int idDocument);

        List<Document> Get_8_Documents(int cate, int n);

        List<Attribute> GetListAttribute(string name);

    }
}
