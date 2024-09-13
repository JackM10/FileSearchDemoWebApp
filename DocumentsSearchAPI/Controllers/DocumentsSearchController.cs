using DocumentsSearchBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DocumentsSearchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsSearchController : ControllerBase
    {
        private readonly ILogger<DocumentsSearchController> _logger;
        private readonly IDocumentsSearchService _documentsSearchService;

        public DocumentsSearchController(
            ILogger<DocumentsSearchController> logger,
            IDocumentsSearchService documentsSearchService)
        {
            _logger = logger;
            _documentsSearchService = documentsSearchService;
        }

        [HttpGet]
        public async Task<IEnumerable<IFormFile>> Get([FromQuery][Required] string q)
        {
            _logger.LogInformation("Query {q} was provided for docs scan", q);

            return await _documentsSearchService.SearchFiles(q);
        }
    }
}
