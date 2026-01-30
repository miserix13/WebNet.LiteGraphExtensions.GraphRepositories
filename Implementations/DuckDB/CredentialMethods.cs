using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations
{
    /// <summary>
    /// Credential methods for DuckDB.
    /// </summary>
    public class CredentialMethods : ICredentialMethods
    {
        private readonly DuckDBGraphRepository _repo;

        public CredentialMethods(DuckDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<Credential> Create(Credential credential, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.Create not yet implemented for DuckDB");
        }

        public async IAsyncEnumerable<Credential> ReadAllInTenant(Guid tenantGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("CredentialMethods.ReadAllInTenant not yet implemented for DuckDB");
        }

        public async IAsyncEnumerable<Credential> ReadMany(Guid? tenantGuid, Guid? userGuid, string bearerToken, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, int skip = 0, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("CredentialMethods.ReadMany not yet implemented for DuckDB");
        }

        public Task<Credential> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.ReadByGuid not yet implemented for DuckDB");
        }

        public async IAsyncEnumerable<Credential> ReadByGuids(Guid tenantGuid, List<Guid> guids, [EnumeratorCancellation] CancellationToken token = default)
        { yield break; throw new NotImplementedException("CredentialMethods.ReadByGuids not yet implemented for DuckDB");
        }

        public Task<Credential> ReadByBearerToken(string bearerToken, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.ReadByBearerToken not yet implemented for DuckDB");
        }

        public Task<EnumerationResult<Credential>> Enumerate(EnumerationRequest query, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.Enumerate not yet implemented for DuckDB");
        }

        public Task<int> GetRecordCount(Guid? tenantGuid, Guid? userGuid, EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending, Guid? markerGuid = null, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.GetRecordCount not yet implemented for DuckDB");
        }

        public Task<Credential> Update(Credential cred, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.Update not yet implemented for DuckDB");
        }

        public Task DeleteAllInTenant(Guid tenantGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.DeleteAllInTenant not yet implemented for DuckDB");
        }

        public Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.DeleteByGuid not yet implemented for DuckDB");
        }

        public Task DeleteByUser(Guid tenantGuid, Guid userGuid, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.DeleteByUser not yet implemented for DuckDB");
        }

        public Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            throw new NotImplementedException("CredentialMethods.ExistsByGuid not yet implemented for DuckDB");
        }
    }
}
