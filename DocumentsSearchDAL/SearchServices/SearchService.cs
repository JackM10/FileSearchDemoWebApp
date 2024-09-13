using Dapper;
using System.Data.SqlClient;
using Z.Dapper.Plus;

namespace DocumentsSearchDAL.SearchServices
{
    public class SearchService : ISearchService
    {
        public async Task<IEnumerable<string>> SearchFiles(string query)
        {
            using (var connection = new SqlConnection(Config.DOCUMENTS_DB_CONNECTION_STRING))
            {
                var sql = $"SELECT * FROM FileNames WHERE FileName like '%{query}%'";
 
                var result = await connection.QueryAsync<string>(sql);

                return result;
            }
        }

        public Task UpdateSearchStorage(IEnumerable<string> fileNames)
        {
            using (var connection = new SqlConnection(Config.DOCUMENTS_DB_CONNECTION_STRING))
            {
                var dataToUpsert = fileNames.Select(d => new FileNames { FileName = d });
                connection.BulkMerge<FileNames>(dataToUpsert);
            }

            return Task.CompletedTask;
        }
    }
}
