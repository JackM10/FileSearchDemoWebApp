namespace DocumentsSearchDAL.SearchServices
{
    public interface ISearchService
    {
        Task UpdateSearchStorage(IEnumerable<string> fileNames);
        Task<IEnumerable<string>> SearchFiles(string query);
    }
}
