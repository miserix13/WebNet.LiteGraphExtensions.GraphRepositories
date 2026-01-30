using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.FastDB
{
    /// <summary>
    /// Admin methods for FastDB.
    /// </summary>
    public class AdminMethods : IAdminMethods
    {
        private readonly FastDBGraphRepository _repo;

        public AdminMethods(FastDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task Backup(string outputFilename, CancellationToken token = default)
        {
            throw new NotImplementedException("AdminMethods.Backup not yet implemented for FastDB");
        }
    }
}
