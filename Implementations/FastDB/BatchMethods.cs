using System;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.FastDB
{
    /// <summary>
    /// Batch methods for FastDB.
    /// </summary>
    public class BatchMethods : IBatchMethods
    {
        private readonly FastDBGraphRepository _repo;

        public BatchMethods(FastDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<ExistenceResult> Existence(Guid tenantGuid, Guid graphGuid, ExistenceRequest req, CancellationToken token = default)
        {
            throw new NotImplementedException("BatchMethods.Existence not yet implemented for FastDB");
        }
    }
}

