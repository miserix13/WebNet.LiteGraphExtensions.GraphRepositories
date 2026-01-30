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
    /// Tenant methods for FastDB.
    /// </summary>
    public class TenantMethods : ITenantMethods
    {
        private readonly FastDBGraphRepository _repo;

        public TenantMethods(FastDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<TenantMetadata> Create(TenantMetadata tenant, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.Create not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TenantMetadata> ReadMany(EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TenantMethods.ReadMany not yet implemented for FastDB");
        }

        public Task<TenantMetadata> ReadByGuid(Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.ReadByGuid not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<TenantMetadata> ReadByGuids(List<Guid> guids, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("TenantMethods.ReadByGuids not yet implemented for FastDB");
        }

        public Task<EnumerationResult<TenantMetadata>> Enumerate(EnumerationRequest query, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.Enumerate not yet implemented for FastDB");
        }

        public Task<int> GetRecordCount(EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.GetRecordCount not yet implemented for FastDB");
        }

        public Task<TenantMetadata> Update(TenantMetadata tenant, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.Update not yet implemented for FastDB");
        }

        public Task DeleteByGuid(Guid guid, bool deleteTenantData = false, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.DeleteByGuid not yet implemented for FastDB");
        }

        public Task<bool> ExistsByGuid(Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.ExistsByGuid not yet implemented for FastDB");
        }

        public Task<bool> ExistsByName(string name, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.ExistsByName not yet implemented for FastDB");
        }

        public Task<TenantMetadata> ReadByName(string name, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.ReadByName not yet implemented for FastDB");
        }

        public Task<TenantStatistics> GetStatistics(Guid tenantGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.GetStatistics not yet implemented for FastDB");
        }

        public Task<Dictionary<Guid, TenantStatistics>> GetStatistics(CancellationToken token = default)
        {
            throw new NotImplementedException("TenantMethods.GetStatistics (all) not yet implemented for FastDB");
        }
    }
}
