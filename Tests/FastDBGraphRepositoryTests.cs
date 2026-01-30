using System;
using System.IO;
using System.Threading.Tasks;
using Stellar.Collections;
using Xunit;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Tests
{
    /// <summary>
    /// Tests for the FastDB graph repository implementation.
    /// </summary>
    public class FastDBGraphRepositoryTests : IDisposable
    {
        private readonly string _testDbPath;
        private readonly FastDBGraphRepository _repository;

        public FastDBGraphRepositoryTests()
        {
            _testDbPath = Path.Combine(Path.GetTempPath(), $"test_fastdb_{Guid.NewGuid()}.db");
            
            var options = new FastDBOptions
            {
                Serializer = SerializerType.MessagePack_Contract
            };
            
            _repository = new FastDBGraphRepository(_testDbPath, options);
        }

        [Fact]
        public void Constructor_WithPath_CreatesRepository()
        {
            Assert.NotNull(_repository);
            Assert.NotNull(_repository.Admin);
            Assert.NotNull(_repository.Tenant);
            Assert.NotNull(_repository.User);
            Assert.NotNull(_repository.Credential);
            Assert.NotNull(_repository.Label);
            Assert.NotNull(_repository.Tag);
            Assert.NotNull(_repository.Vector);
            Assert.NotNull(_repository.Graph);
            Assert.NotNull(_repository.Node);
            Assert.NotNull(_repository.Edge);
            Assert.NotNull(_repository.Batch);
            Assert.NotNull(_repository.VectorIndex);
        }

        [Fact]
        public void InitializeRepository_DoesNotThrow()
        {
            _repository.InitializeRepository();
        }

        [Fact]
        public void Flush_DoesNotThrow()
        {
            _repository.Flush();
        }

        [Fact]
        public async Task AdminMethods_Backup_ThrowsNotImplementedException()
        {
            await Assert.ThrowsAsync<NotImplementedException>(
                async () => await _repository.Admin.Backup("backup.db"));
        }

        [Fact]
        public async Task TenantMethods_Create_ThrowsNotImplementedException()
        {
            var tenant = new LiteGraph.TenantMetadata
            {
                GUID = Guid.NewGuid(),
                Name = "Test Tenant"
            };
            
            await Assert.ThrowsAsync<NotImplementedException>(
                async () => await _repository.Tenant.Create(tenant));
        }

        [Fact]
        public async Task TenantMethods_ReadByGuid_ThrowsNotImplementedException()
        {
            await Assert.ThrowsAsync<NotImplementedException>(
                async () => await _repository.Tenant.ReadByGuid(Guid.NewGuid()));
        }

        [Fact]
        public async Task UserMethods_Create_ThrowsNotImplementedException()
        {
            var user = new LiteGraph.UserMaster
            {
                GUID = Guid.NewGuid(),
                Email = "test@example.com"
            };
            
            await Assert.ThrowsAsync<NotImplementedException>(
                async () => await _repository.User.Create(user));
        }

        [Fact]
        public async Task GraphMethods_Create_ThrowsNotImplementedException()
        {
            var graph = new LiteGraph.Graph
            {
                GUID = Guid.NewGuid(),
                TenantGUID = Guid.NewGuid(),
                Name = "Test Graph"
            };
            
            await Assert.ThrowsAsync<NotImplementedException>(
                async () => await _repository.Graph.Create(graph));
        }

        [Fact]
        public async Task NodeMethods_Create_ThrowsNotImplementedException()
        {
            var node = new LiteGraph.Node
            {
                GUID = Guid.NewGuid(),
                TenantGUID = Guid.NewGuid(),
                GraphGUID = Guid.NewGuid(),
                Name = "Test Node"
            };
            
            await Assert.ThrowsAsync<NotImplementedException>(
                async () => await _repository.Node.Create(node));
        }

        [Fact]
        public async Task EdgeMethods_Create_ThrowsNotImplementedException()
        {
            var edge = new LiteGraph.Edge
            {
                GUID = Guid.NewGuid(),
                TenantGUID = Guid.NewGuid(),
                GraphGUID = Guid.NewGuid(),
                From = Guid.NewGuid(),
                To = Guid.NewGuid()
            };
            
            await Assert.ThrowsAsync<NotImplementedException>(
                async () => await _repository.Edge.Create(edge));
        }

        [Fact]
        public void Dispose_DoesNotThrow()
        {
            _repository.Dispose();
        }

        public void Dispose()
        {
            try
            {
                _repository?.Dispose();
            }
            catch
            {
                // Ignore disposal errors in tests
            }

            try
            {
                if (File.Exists(_testDbPath))
                    File.Delete(_testDbPath);
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
    }
}
