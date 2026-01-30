using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Implementations.LiteDB
{
    /// <summary>
    /// Admin methods for LiteDB.
    /// </summary>
    public class AdminMethods : IAdminMethods
    {
        private readonly LiteDBGraphRepository _repo;

        public AdminMethods(LiteDBGraphRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task Backup(string outputFilename, CancellationToken token = default)
        {
            throw new NotImplementedException("AdminMethods.Backup not yet implemented for LiteDB");
        }
    }
}

