namespace DocumentsSearchDAL.SearchServices
{
    public interface ISearchService
    {
        /// <summary>
        /// Update data storage with the file names provided in the input
        /// It use merge operation, so existing in DB file names wouldn't dublicate
        /// </summary>
        /// <param name="fileNames">file names to store (just a file name, not absolute path as it may changes)</param>
        Task UpdateSearchStorage(IEnumerable<string> fileNames);

        /// <summary>
        /// Search for a match of file names in data storage
        /// </summary>
        /// <param name="query">file name to search</param>
        /// <returns>list of file names, which contains provided in the query string</returns>
        Task<IEnumerable<string>> SearchFiles(string query);
    }
}
