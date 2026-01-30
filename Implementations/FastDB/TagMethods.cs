using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.FastDB
{
    /// <summary>
    /// Tag methods for FastDB.
    /// </summary>
    public class TagMethods : ITagMethods
    {
        private readonly FastDBGraphRepository _repo;

        public TagMethods(FastDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<TagMetadata> Create(TagMetadata tag, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.Create not yet implemented for FastDB");
        }

        public Task<List<TagMetadata>> CreateMany(Guid tenantGuid, List<TagMetadata> tags, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.CreateMany not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TagMetadata> ReadAllInTenant(Guid tenantGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TagMethods.ReadAllInTenant not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TagMetadata> ReadAllInGraph(Guid tenantGuid, Guid graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TagMethods.ReadAllInGraph not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TagMetadata> ReadMany(Guid tenantGuid, Guid? graphGuid, Guid? nodeGuid, Guid? edgeGuid, string key, string value, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TagMethods.ReadMany not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TagMetadata> ReadManyGraph(Guid tenantGuid, Guid graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TagMethods.ReadManyGraph not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TagMetadata> ReadManyNode(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TagMethods.ReadManyNode not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TagMetadata> ReadManyEdge(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TagMethods.ReadManyEdge not yet implemented for FastDB");
        }

        public Task<TagMetadata> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.ReadByGuid not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TagMetadata> ReadByGuids(Guid tenantGuid, List<Guid> guids, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TagMethods.ReadByGuids not yet implemented for FastDB");
        }

        public Task<EnumerationResult<TagMetadata>> Enumerate(EnumerationRequest query, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.Enumerate not yet implemented for FastDB");
        }

        public Task<int> GetRecordCount(Guid? tenantGuid, Guid? graphGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.GetRecordCount not yet implemented for FastDB");
        }

        public Task<TagMetadata> Update(TagMetadata tag, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.Update not yet implemented for FastDB");
        }

        public Task DeleteMany(Guid tenantGuid, Guid? graphGuid, List<Guid> nodeGuids, List<Guid> edgeGuids, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteMany not yet implemented for FastDB");
        }

        public Task DeleteMany(Guid tenantGuid, List<Guid> guids, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteMany (by guids) not yet implemented for FastDB");
        }

        public Task DeleteAllInTenant(Guid tenantGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteAllInTenant not yet implemented for FastDB");
        }

        public Task DeleteAllInGraph(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteAllInGraph not yet implemented for FastDB");
        }

        public Task DeleteGraphTags(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteGraphTags not yet implemented for FastDB");
        }

        public Task DeleteNodeTags(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteNodeTags not yet implemented for FastDB");
        }

        public Task DeleteEdgeTags(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteEdgeTags not yet implemented for FastDB");
        }

        public Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.DeleteByGuid not yet implemented for FastDB");
        }

        public Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("TagMethods.ExistsByGuid not yet implemented for FastDB");
        }
    }
}

