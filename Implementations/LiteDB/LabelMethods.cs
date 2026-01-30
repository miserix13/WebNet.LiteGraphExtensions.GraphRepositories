using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.LiteDB{
    /// <summary>
    /// Label methods for LiteDB.
    /// </summary>
    public class LabelMethods : ILabelMethods
    {
        private readonly LiteDBGraphRepository _repo;

        public LabelMethods(LiteDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<LabelMetadata> Create(LabelMetadata label, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.Create not yet implemented for LiteDB");
        }

        public Task<List<LabelMetadata>> CreateMany(Guid tenantGuid, List<LabelMetadata> labels, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.CreateMany not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<LabelMetadata> ReadAllInTenant(Guid tenantGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("LabelMethods.ReadAllInTenant not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<LabelMetadata> ReadAllInGraph(Guid tenantGuid, Guid graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("LabelMethods.ReadAllInGraph not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<LabelMetadata> ReadMany(Guid tenantGuid, Guid? graphGuid, Guid? nodeGuid, Guid? edgeGuid, string name, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("LabelMethods.ReadMany not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<LabelMetadata> ReadManyGraph(Guid tenantGuid, Guid graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("LabelMethods.ReadManyGraph not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<LabelMetadata> ReadManyNode(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("LabelMethods.ReadManyNode not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<LabelMetadata> ReadManyEdge(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("LabelMethods.ReadManyEdge not yet implemented for LiteDB");
        }

        public Task<LabelMetadata> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.ReadByGuid not yet implemented for LiteDB");
        }

        public async IAsyncEnumerable<LabelMetadata> ReadByGuids(Guid tenantGuid, List<Guid> guids, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("LabelMethods.ReadByGuids not yet implemented for LiteDB");
        }

        public Task<EnumerationResult<LabelMetadata>> Enumerate(EnumerationRequest query, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.Enumerate not yet implemented for LiteDB");
        }

        public Task<int> GetRecordCount(Guid? tenantGuid, Guid? graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.GetRecordCount not yet implemented for LiteDB");
        }

        public Task<LabelMetadata> Update(LabelMetadata label, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.Update not yet implemented for LiteDB");
        }

        public Task DeleteMany(Guid tenantGuid, Guid? graphGuid, List<Guid> nodeGuids, List<Guid> edgeGuids, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteMany not yet implemented for LiteDB");
        }

        public Task DeleteMany(Guid tenantGuid, List<Guid> guids, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteMany (by guids) not yet implemented for LiteDB");
        }

        public Task DeleteAllInTenant(Guid tenantGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteAllInTenant not yet implemented for LiteDB");
        }

        public Task DeleteAllInGraph(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteAllInGraph not yet implemented for LiteDB");
        }

        public Task DeleteGraphLabels(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteGraphLabels not yet implemented for LiteDB");
        }

        public Task DeleteNodeLabels(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteNodeLabels not yet implemented for LiteDB");
        }

        public Task DeleteEdgeLabels(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteEdgeLabels not yet implemented for LiteDB");
        }

        public Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.DeleteByGuid not yet implemented for LiteDB");
        }

        public Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("LabelMethods.ExistsByGuid not yet implemented for LiteDB");
        }
    }
}

