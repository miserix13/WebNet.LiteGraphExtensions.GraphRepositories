using System;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations
{
    /// <summary>
    /// Admin methods for DuckDB.
    /// </summary>
    public class AdminMethods : IAdminMethods
    {
        private readonly DuckDBGraphRepository _repo;

        public AdminMethods(DuckDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task Backup(string outputFilename, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();
            
            using (var command = _repo.GetConnection().CreateCommand())
            {
                command.CommandText = $"EXPORT DATABASE '{outputFilename}';";
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
