using System;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.LiteDB{
    /// <summary>
    /// Batch methods for LiteDB.
    /// </summary>
    public class BatchMethods : IBatchMethods
    {
        private readonly LiteDBGraphRepository _repo;

        public BatchMethods(LiteDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<ExistenceResult> Existence(Guid tenantGuid, Guid graphGuid, ExistenceRequest req, CancellationToken token = default)
        {
            throw new NotImplementedException("BatchMethods.Existence not yet implemented for LiteDB");
        }
    }
}

