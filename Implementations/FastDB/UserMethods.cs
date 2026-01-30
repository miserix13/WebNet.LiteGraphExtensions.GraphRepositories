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
    /// User methods for FastDB.
    /// </summary>
    public class UserMethods : IUserMethods
    {
        private readonly FastDBGraphRepository _repo;

        public UserMethods(FastDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<UserMaster> Create(UserMaster user, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.Create not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<UserMaster> ReadAllInTenant(Guid tenantGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("UserMethods.ReadAllInTenant not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<UserMaster> ReadMany(Guid? tenantGuid, string email, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("UserMethods.ReadMany not yet implemented for FastDB");
        }

        public Task<UserMaster> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.ReadByGuid not yet implemented for FastDB");
        }

        public async IAsyncEnumerable<UserMaster> ReadByGuids(Guid tenantGuid, List<Guid> guids, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("UserMethods.ReadByGuids not yet implemented for FastDB");
        }

        public Task<List<TenantMetadata>> ReadTenantsByEmail(string email, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.ReadTenantsByEmail not yet implemented for FastDB");
        }

        public Task<UserMaster> ReadByEmail(Guid tenantGuid, string email, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.ReadByEmail not yet implemented for FastDB");
        }

        public Task<EnumerationResult<UserMaster>> Enumerate(EnumerationRequest query, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.Enumerate not yet implemented for FastDB");
        }

        public Task<int> GetRecordCount(Guid? tenantGuid, string email, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.GetRecordCount not yet implemented for FastDB");
        }

        public Task<int> GetRecordCount(Guid? tenantGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.GetRecordCount (simple) not yet implemented for FastDB");
        }

        public Task<UserMaster> Update(UserMaster user, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.Update not yet implemented for FastDB");
        }

        public Task DeleteAllInTenant(Guid tenantGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.DeleteAllInTenant not yet implemented for FastDB");
        }

        public Task<bool> ExistsByGuid(Guid tenantGuid, Guid userGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.ExistsByGuid not yet implemented for FastDB");
        }

        public Task<bool> ExistsByEmail(Guid tenantGuid, string email, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.ExistsByEmail not yet implemented for FastDB");
        }

        public Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("UserMethods.DeleteByGuid not yet implemented for FastDB");
        }
    }
}

