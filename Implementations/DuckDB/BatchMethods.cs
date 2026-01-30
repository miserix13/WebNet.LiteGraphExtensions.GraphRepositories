using System;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations
{
    /// <summary>
    /// Batch methods for DuckDB.
    /// </summary>
    public class BatchMethods : IBatchMethods
    {
        private readonly DuckDBGraphRepository _repo;

        public BatchMethods(DuckDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<ExistenceResult> Existence(Guid tenantGuid, Guid graphGuid, ExistenceRequest req, CancellationToken token = default)
        {
            throw new NotImplementedException("BatchMethods.Existence not yet implemented for DuckDB");
        }
    }
}
