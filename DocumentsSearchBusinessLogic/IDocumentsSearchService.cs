using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsSearchBusinessLogic
{
    public interface IDocumentsSearchService
    {
        Task<IEnumerable<IFormFile>> SearchFiles(string query);
    }
}
