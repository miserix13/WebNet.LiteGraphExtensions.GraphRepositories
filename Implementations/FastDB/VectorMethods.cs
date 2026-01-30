using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ExpressionTree;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.FastDB
{
    /// <summary>
    /// Vector methods for FastDB.
    /// </summary>
    public class VectorMethods : IVectorMethods
    {
        private readonly FastDBGraphRepository _repo;

        public VectorMethods(FastDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<VectorMetadata> Create(VectorMetadata vector, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.Create not yet implemented for FastDB");
        }

        public Task<List<VectorMetadata>> CreateMany(Guid tenantGuid, List<VectorMetadata> vectors, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.CreateMany not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorMetadata> ReadAllInTenant(Guid tenantGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.ReadAllInTenant not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorMetadata> ReadAllInGraph(Guid tenantGuid, Guid graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.ReadAllInGraph not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorMetadata> ReadMany(Guid tenantGuid, Guid? graphGuid, Guid? nodeGuid, Guid? edgeGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.ReadMany not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorMetadata> ReadManyGraph(Guid tenantGuid, Guid graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.ReadManyGraph not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorMetadata> ReadManyNode(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.ReadManyNode not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorMetadata> ReadManyEdge(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.ReadManyEdge not yet implemented for FastDB");
        }

        public Task<VectorMetadata> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.ReadByGuid not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorMetadata> ReadByGuids(Guid tenantGuid, List<Guid> guids, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.ReadByGuids not yet implemented for FastDB");
        }

        public Task<EnumerationResult<VectorMetadata>> Enumerate(EnumerationRequest query, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.Enumerate not yet implemented for FastDB");
        }

        public Task<int> GetRecordCount(Guid? tenantGuid, Guid? graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.GetRecordCount not yet implemented for FastDB");
        }

        public Task<VectorMetadata> Update(VectorMetadata vector, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.Update not yet implemented for FastDB");
        }

        public Task DeleteMany(Guid tenantGuid, Guid? graphGuid, List<Guid> nodeGuids, List<Guid> edgeGuids, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteMany not yet implemented for FastDB");
        }

        public Task DeleteMany(Guid tenantGuid, List<Guid> guids, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteMany (by guids) not yet implemented for FastDB");
        }

        public Task DeleteAllInTenant(Guid tenantGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteAllInTenant not yet implemented for FastDB");
        }

        public Task DeleteAllInGraph(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteAllInGraph not yet implemented for FastDB");
        }

        public Task DeleteGraphVectors(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteGraphVectors not yet implemented for FastDB");
        }

        public Task DeleteNodeVectors(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteNodeVectors not yet implemented for FastDB");
        }

        public Task DeleteEdgeVectors(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteEdgeVectors not yet implemented for FastDB");
        }

        public Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.ExistsByGuid not yet implemented for FastDB");
        }

        public Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("VectorMethods.DeleteByGuid not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorSearchResult> SearchGraph(VectorSearchTypeEnum searchType, List<float> vector, Guid graphGuid, List<string> labels, NameValueCollection tags, Expr filter, int? maxResults = null, float? minimumSimilarityScore = null, float? maximumDistance = null, float? maximumManhattanDistance = null, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.SearchGraph not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorSearchResult> SearchNode(VectorSearchTypeEnum searchType, List<float> vector, Guid graphGuid, Guid nodeGuid, List<string> labels, NameValueCollection tags, Expr filter, int? maxResults = null, float? minimumSimilarityScore = null, float? maximumDistance = null, float? maximumManhattanDistance = null, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.SearchNode not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<VectorSearchResult> SearchEdge(VectorSearchTypeEnum searchType, List<float> vector, Guid graphGuid, Guid edgeGuid, List<string> labels, NameValueCollection tags, Expr filter, int? maxResults = null, float? minimumSimilarityScore = null, float? maximumDistance = null, float? maximumManhattanDistance = null, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("VectorMethods.SearchEdge not yet implemented for FastDB");
        }
    }
}

