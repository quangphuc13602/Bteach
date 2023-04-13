using EDuBee.Classes;
using EDuBee.Client.Models;
using EDuBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attribute = EDuBee.Models.Attribute;

namespace EDuBee.Client.Service
{
    public interface IManageDocumentApiClient
    {
        List<DocumentView> GetDocument(int? cate);
        List<DocumentView> GetDocument();
        List<CategoryView> GetCategories();

        Task<int> UplodaDocument(FileDocument fileDocument);
        List<Attribute> GetListAttribute(string name);
    }
}
