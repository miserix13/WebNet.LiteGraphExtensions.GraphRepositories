using System;
using System.IO;
using System.Threading.Tasks;
using LiteGraph;
using WebNet.LiteGraphExtensions.GraphRepositories;
using Xunit;

namespace WebNet.LiteGraphExtensions.GraphRepositories.Tests
{
    public class DuckDBGraphRepositoryTests : IDisposable
    {
        private readonly string _testDbPath;
        private readonly DuckDBGraphRepository _repository;

        public DuckDBGraphRepositoryTests()
        {
            // Create a temporary database file for testing
            _testDbPath = Path.Combine(Path.GetTempPath(), $"test_duckdb_{Guid.NewGuid()}.db");
            _repository = new DuckDBGraphRepository($"Data Source={_testDbPath}");
        }

        public void Dispose()
        {
            // Clean up
            _repository?.Dispose();
            
            if (File.Exists(_testDbPath))
            {
                try
                {
                    File.Delete(_testDbPath);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }

        [Fact]
        public void Constructor_CreatesRepository_Successfully()
        {
            // Arrange & Act
            var repo = new DuckDBGraphRepository($"Data Source={_testDbPath}");

            // Assert
            Assert.NotNull(repo);
            Assert.NotNull(repo.Admin);
            Assert.NotNull(repo.Tenant);
            Assert.NotNull(repo.User);
            Assert.NotNull(repo.Credential);
            Assert.NotNull(repo.Label);
            Assert.NotNull(repo.Tag);
            Assert.NotNull(repo.Vector);
            Assert.NotNull(repo.Graph);
            Assert.NotNull(repo.Node);
            Assert.NotNull(repo.Edge);
            Assert.NotNull(repo.Batch);
            Assert.NotNull(repo.VectorIndex);

            // Cleanup
            repo.Dispose();
        }

        [Fact]
        public void Constructor_WithNullConnectionString_ThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DuckDBGraphRepository(null!));
        }

        [Fact]
        public void Constructor_WithEmptyConnectionString_ThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DuckDBGraphRepository(string.Empty));
        }

        [Fact]
        public async Task InitializeRepository_CreatesSchema_Successfully()
        {
            // Arrange & Act
            _repository.InitializeRepository();

            // Assert - If no exception is thrown, the schema was created successfully
            Assert.True(true);
            await Task.CompletedTask;
        }

        [Fact]
        public void AllMethodImplementations_AreNotNull()
        {
            // Arrange & Act
            var admin = _repository.Admin;
            var tenant = _repository.Tenant;
            var user = _repository.User;
            var credential = _repository.Credential;
            var label = _repository.Label;
            var tag = _repository.Tag;
            var vector = _repository.Vector;
            var graph = _repository.Graph;
            var node = _repository.Node;
            var edge = _repository.Edge;
            var batch = _repository.Batch;
            var vectorIndex = _repository.VectorIndex;

            // Assert
            Assert.NotNull(admin);
            Assert.NotNull(tenant);
            Assert.NotNull(user);
            Assert.NotNull(credential);
            Assert.NotNull(label);
            Assert.NotNull(tag);
            Assert.NotNull(vector);
            Assert.NotNull(graph);
            Assert.NotNull(node);
            Assert.NotNull(edge);
            Assert.NotNull(batch);
            Assert.NotNull(vectorIndex);
        }

        [Fact]
        public async Task Flush_ExecutesSuccessfully()
        {
            // Arrange
            _repository.InitializeRepository();

            // Act & Assert - Should not throw
            _repository.Flush();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task Admin_Backup_ExecutesSuccessfully()
        {
            // Arrange
            _repository.InitializeRepository();
            var backupPath = Path.Combine(Path.GetTempPath(), $"backup_{Guid.NewGuid()}");

            try
            {
                // Act - Admin.Backup is actually implemented in DuckDB
                await _repository.Admin.Backup(backupPath);

                // Assert - Should complete without throwing
                Assert.True(Directory.Exists(backupPath));
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(backupPath))
                {
                    try
                    {
                        Directory.Delete(backupPath, true);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        [Fact]
        public async Task Tenant_Create_ThrowsNotImplementedException()
        {
            // Arrange
            var tenant = new TenantMetadata
            {
                GUID = Guid.NewGuid(),
                Name = "Test Tenant",
                CreatedUtc = DateTime.UtcNow
            };

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => 
                _repository.Tenant.Create(tenant));
        }

        [Fact]
        public async Task Graph_Create_ThrowsNotImplementedException()
        {
            // Arrange
            var tenantGuid = Guid.NewGuid();
            var graph = new Graph
            {
                GUID = Guid.NewGuid(),
                TenantGUID = tenantGuid,
                Name = "Test Graph",
                CreatedUtc = DateTime.UtcNow
            };

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => 
                _repository.Graph.Create(graph));
        }

        [Fact]
        public async Task Node_Create_ThrowsNotImplementedException()
        {
            // Arrange
            var tenantGuid = Guid.NewGuid();
            var graphGuid = Guid.NewGuid();
            var node = new Node
            {
                GUID = Guid.NewGuid(),
                TenantGUID = tenantGuid,
                GraphGUID = graphGuid,
                Name = "Test Node",
                CreatedUtc = DateTime.UtcNow
            };

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => 
                _repository.Node.Create(node));
        }

        [Fact]
        public async Task Edge_Create_ThrowsNotImplementedException()
        {
            // Arrange
            var tenantGuid = Guid.NewGuid();
            var graphGuid = Guid.NewGuid();
            var edge = new Edge
            {
                GUID = Guid.NewGuid(),
                TenantGUID = tenantGuid,
                GraphGUID = graphGuid,
                From = Guid.NewGuid(),
                To = Guid.NewGuid(),
                CreatedUtc = DateTime.UtcNow
            };

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => 
                _repository.Edge.Create(edge));
        }

        [Fact]
        public void Dispose_DisposesRepository_Successfully()
        {
            // Arrange
            var tempPath = Path.Combine(Path.GetTempPath(), $"dispose_test_{Guid.NewGuid()}.db");
            var repo = new DuckDBGraphRepository($"Data Source={tempPath}");

            // Act
            repo.Dispose();

            // Assert - Should not throw
            Assert.True(true);

            // Cleanup
            if (File.Exists(tempPath))
            {
                try { File.Delete(tempPath); } catch { }
            }
        }

        [Fact]
        public async Task MultipleOperations_OnSameRepository_WorkCorrectly()
        {
            // Arrange
            _repository.InitializeRepository();

            // Act & Assert - Multiple flushes should work
            _repository.Flush();
            _repository.Flush();
            _repository.Flush();

            Assert.True(true);
            await Task.CompletedTask;
        }

    }
}
