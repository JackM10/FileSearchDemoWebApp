using Microsoft.AspNetCore.Http;

namespace DocumentsSearchBusinessLogic
{
    public interface IDocumentsSearchService
    {
        /// <summary>
        /// Search for the document and receive files which's name match to the input params
        /// </summary>
        /// <param name="query">name of the files to search</param>
        /// <returns>files, names of which contains query</returns>
        Task<IEnumerable<IFormFile>> SearchFiles(string query);
    }
}
