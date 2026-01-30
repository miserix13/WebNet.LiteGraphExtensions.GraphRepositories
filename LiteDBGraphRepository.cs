using System;
using LiteDB;
using LiteGraph.GraphRepositories.Interfaces;
using WebNet.LiteGraphExtensions.GraphRepositories.Implementations.LiteDB;

namespace WebNet.LiteGraphExtensions.GraphRepositories
{
    /// <summary>
    /// LiteDB-based graph repository implementation.
    /// Provides document-oriented NoSQL storage with BSON serialization and LINQ query support.
    /// </summary>
    public class LiteDBGraphRepository : LiteGraph.GraphRepositories.GraphRepositoryBase
    {
        private readonly LiteDatabase _database;
        private readonly string _connectionString;
        private bool _disposed;

        /// <summary>
        /// Initialize a new LiteDB graph repository.
        /// </summary>
        /// <param name="connectionString">LiteDB connection string (e.g., "mydata.db" or "Filename=mydata.db;Connection=shared")</param>
        public LiteDBGraphRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string cannot be null or empty", nameof(connectionString));

            _connectionString = connectionString;
            _database = new LiteDatabase(_connectionString);

            // Initialize all interface implementations
            Admin = new AdminMethods(this);
            Tenant = new TenantMethods(this);
            User = new UserMethods(this);
            Credential = new CredentialMethods(this);
            Label = new LabelMethods(this);
            Tag = new TagMethods(this);
            Vector = new VectorMethods(this);
            Graph = new GraphMethods(this);
            Node = new NodeMethods(this);
            Edge = new EdgeMethods(this);
            Batch = new BatchMethods(this);
            VectorIndex = new VectorIndexMethods(this);
        }

        /// <summary>
        /// Admin methods interface implementation.
        /// </summary>
        public override IAdminMethods Admin { get; }

        /// <summary>
        /// Tenant methods interface implementation.
        /// </summary>
        public override ITenantMethods Tenant { get; }

        /// <summary>
        /// User methods interface implementation.
        /// </summary>
        public override IUserMethods User { get; }

        /// <summary>
        /// Credential methods interface implementation.
        /// </summary>
        public override ICredentialMethods Credential { get; }

        /// <summary>
        /// Label methods interface implementation.
        /// </summary>
        public override ILabelMethods Label { get; }

        /// <summary>
        /// Tag methods interface implementation.
        /// </summary>
        public override ITagMethods Tag { get; }

        /// <summary>
        /// Vector methods interface implementation.
        /// </summary>
        public override IVectorMethods Vector { get; }

        /// <summary>
        /// Graph methods interface implementation.
        /// </summary>
        public override IGraphMethods Graph { get; }

        /// <summary>
        /// Node methods interface implementation.
        /// </summary>
        public override INodeMethods Node { get; }

        /// <summary>
        /// Edge methods interface implementation.
        /// </summary>
        public override IEdgeMethods Edge { get; }

        /// <summary>
        /// Batch methods interface implementation.
        /// </summary>
        public override IBatchMethods Batch { get; }

        /// <summary>
        /// Vector index methods interface implementation.
        /// </summary>
        public override IVectorIndexMethods VectorIndex { get; }

        /// <summary>
        /// Initialize the repository.
        /// Collections are automatically created when first accessed.
        /// Creates indexes for commonly queried fields.
        /// </summary>
        public override void InitializeRepository()
        {
            // Create indexes for performance
            var tenants = _database.GetCollection<LiteGraph.TenantMetadata>("tenants");
            tenants.EnsureIndex(x => x.GUID, true);
            tenants.EnsureIndex(x => x.Name);

            var graphs = _database.GetCollection<LiteGraph.Graph>("graphs");
            graphs.EnsureIndex(x => x.GUID, true);
            graphs.EnsureIndex(x => x.TenantGUID);

            var nodes = _database.GetCollection<LiteGraph.Node>("nodes");
            nodes.EnsureIndex(x => x.GUID, true);
            nodes.EnsureIndex(x => x.GraphGUID);
            nodes.EnsureIndex(x => x.TenantGUID);

            var edges = _database.GetCollection<LiteGraph.Edge>("edges");
            edges.EnsureIndex(x => x.GUID, true);
            edges.EnsureIndex(x => x.GraphGUID);
            edges.EnsureIndex(x => x.From);
            edges.EnsureIndex(x => x.To);

            var users = _database.GetCollection<LiteGraph.UserMaster>("users");
            users.EnsureIndex(x => x.GUID, true);
            users.EnsureIndex(x => x.Email);

            var credentials = _database.GetCollection<LiteGraph.Credential>("credentials");
            credentials.EnsureIndex(x => x.GUID, true);

            var labels = _database.GetCollection<LiteGraph.LabelMetadata>("labels");
            labels.EnsureIndex(x => x.GUID, true);

            var tags = _database.GetCollection<LiteGraph.TagMetadata>("tags");
            tags.EnsureIndex(x => x.GUID, true);

            var vectors = _database.GetCollection<LiteGraph.VectorMetadata>("vectors");
            vectors.EnsureIndex(x => x.GUID, true);
        }

        /// <summary>
        /// Flush database changes to disk.
        /// </summary>
        public override void Flush()
        {
            _database.Checkpoint();
        }

        /// <summary>
        /// Get the LiteDB database instance.
        /// </summary>
        public LiteDatabase GetDatabase() => _database;

        /// <summary>
        /// Dispose the repository.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _database?.Dispose();
                _disposed = true;
            }
        }
    }
}
