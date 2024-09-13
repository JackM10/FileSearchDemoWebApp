using Microsoft.AspNetCore.Http;

namespace DocumentsSearchDAL.FileServices
{
    public interface IFileService
    {
        /// <summary>
        /// This function is used to scan configured directory for txt files and update DB with actual data
        /// </summary>
        /// <returns>Returns paths to txt files in configured directory</returns>
        Task<IEnumerable<string>> ScanDocuments();

        /// <summary>
        /// Function to get files
        /// </summary>
        /// <param name="paths">File names of the files</param>
        /// <returns>Returns collection of files which match provided paths</returns>
        Task<IEnumerable<IFormFile>> GetFiles(IEnumerable<string> fileNames);
    }
}
