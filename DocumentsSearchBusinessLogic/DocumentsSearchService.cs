using DocumentsSearchDAL.FileServices;
using DocumentsSearchDAL.SearchServices;
using Microsoft.AspNetCore.Http;

namespace DocumentsSearchBusinessLogic
{
    public class DocumentsSearchService : IDocumentsSearchService
    {
        private readonly IFileService _fileService;
        private readonly ISearchService _searchService;

        public DocumentsSearchService(IFileService documentsService, ISearchService searchService)
        {
            _fileService = documentsService;
            _searchService = searchService;
        }

        public async Task<IEnumerable<IFormFile>> SearchFiles(string query)
        {
            var txtFilesInWorkingDirectory = await _fileService.ScanDocuments();
            await _searchService.UpdateSearchStorage(txtFilesInWorkingDirectory);
            var matchedFiles = await _searchService.SearchFiles(query);
            var result = await _fileService.GetFiles(matchedFiles);

            return result;
        }
    }
}
