using Microsoft.AspNetCore.Http;

namespace DocumentsSearchDAL.FileServices
{
    public class FileService : IFileService
    {
        public Task<IEnumerable<IFormFile>> GetFiles(IEnumerable<string> fileNames)
        {
            var result = new List<IFormFile>();
            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(Config.WORKING_DIRECTORY_ABSOLUTE_PATH, fileName);
                using (var stream = File.OpenRead(filePath))
                {
                    var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "application/txt"
                    };

                    result.Add(file);
                }
            }

            return Task.FromResult(result.AsEnumerable());
        }

        public Task<IEnumerable<string>> ScanDocuments() =>
            Task.FromResult(Directory.GetFiles(Config.WORKING_DIRECTORY_ABSOLUTE_PATH, "*.txt", SearchOption.AllDirectories).Select(p => Path.GetFileName(p)));
    }
}
