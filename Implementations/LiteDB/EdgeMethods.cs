using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ExpressionTree;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.LiteDB{
    /// <summary>
    /// Edge methods for LiteDB.
    /// </summary>
    public class EdgeMethods : IEdgeMethods
    {
        private readonly LiteDBGraphRepository _repo;

        public EdgeMethods(LiteDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<Edge> Create(Edge edge, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.Create not yet implemented for LiteDB");
        }

        public Task<List<Edge>> CreateMany(Guid tenantGuid, Guid graphGuid, List<Edge> edges, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.CreateMany not yet implemented for LiteDB");
        }

        public IAsyncEnumerable<Edge> ReadAllInTenant(Guid tenantGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.ReadAllInTenant not yet implemented for LiteDB");
        }

        public IAsyncEnumerable<Edge> ReadAllInGraph(Guid tenantGuid, Guid graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.ReadAllInGraph not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> ReadMany(Guid tenantGuid, Guid graphGuid, string? name = null, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.ReadMany not yet implemented for LiteDB");
        }

        public Task<Edge> ReadFirst(Guid tenantGuid, Guid graphGuid, string? name = null, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.ReadFirst not yet implemented for LiteDB");
        }

        public Task<Edge> ReadByGuid(Guid tenantGuid, Guid edgeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.ReadByGuid not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> ReadByGuids(Guid tenantGuid, List<Guid> guids, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.ReadByGuids not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> GetEdgesFromNode(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.GetEdgesFromNode not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> GetEdgesToNode(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.GetEdgesToNode not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> GetEdgesBetweenNodes(Guid tenantGuid, Guid graphGuid, Guid fromNodeGuid, Guid toNodeGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.GetEdgesBetweenNodes not yet implemented for LiteDB");
        }

        public Task<int> GetRecordCount(Guid? tenantGuid, Guid? graphGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? filter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.GetRecordCount not yet implemented for LiteDB");
        }

        public Task<Edge> Update(Edge edge, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.Update not yet implemented for LiteDB");
        }

        public Task DeleteByGuid(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.DeleteByGuid not yet implemented for LiteDB");
        }

        public Task DeleteAllInTenant(Guid tenantGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.DeleteAllInTenant not yet implemented for LiteDB");
        }

        public Task DeleteAllInGraph(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.DeleteAllInGraph not yet implemented for LiteDB");
        }
        public async IAsyncEnumerable<Edge> ReadNodeEdges(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.ReadNodeEdges not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> ReadEdgesFromNode(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.ReadEdgesFromNode not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> ReadEdgesToNode(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.ReadEdgesToNode not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<Edge> ReadEdgesBetweenNodes(Guid tenantGuid, Guid graphGuid, Guid fromNodeGuid, Guid toNodeGuid, List<string>? labels = null, NameValueCollection? tags = null, Expr? edgeFilter = null, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("EdgeMethods.ReadEdgesBetweenNodes not yet implemented for LiteDB");
        }

        public Task<EnumerationResult<Edge>> Enumerate(EnumerationRequest query, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.Enumerate not yet implemented for LiteDB");
        }

        public Task DeleteNodeEdges(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.DeleteNodeEdges not yet implemented for LiteDB");
        }

        public Task DeleteNodeEdges(Guid tenantGuid, Guid graphGuid, List<Guid> nodeGuids, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.DeleteNodeEdges (multiple nodes) not yet implemented for LiteDB");
        }

        public Task DeleteMany(Guid tenantGuid, Guid graphGuid, List<Guid> edgeGuids, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.DeleteMany not yet implemented for LiteDB");
        }
        public Task DeleteByNodeGuid(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.DeleteByNodeGuid not yet implemented for LiteDB");
        }

        public Task<bool> ExistsByGuid(Guid tenantGuid, Guid edgeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("EdgeMethods.ExistsByGuid not yet implemented for LiteDB");
        }
    }
}

