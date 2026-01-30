using System;
using LiteGraph;
using Stellar.Collections;

namespace WebNet.LiteGraphExtensions.GraphRepositories
{
    /// <summary>
    /// FastDB Graph Repository implementation.
    /// Provides high-performance graph storage using Stellar.FastDB with MessagePack serialization.
    /// FastDB is a key-value collection-based embedded database (~100x faster than similar products).
    /// </summary>
    /// <remarks>
    /// FastDB uses collection-based storage (similar to ConcurrentDictionary) with built-in persistence.
    /// It supports MessagePack serialization for optimal storage footprint and performance.
    /// Note: Implementation pending - LiteGraph interface requires additional parameters in method signatures.
    /// </remarks>
    public class FastDBGraphRepository : LiteGraph.GraphRepositories.GraphRepositoryBase
    {
        #region Public-Members

        /// <summary>
        /// Admin methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.IAdminMethods Admin { get; }

        /// <summary>
        /// Tenant methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.ITenantMethods Tenant { get; }

        /// <summary>
        /// User methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.IUserMethods User { get; }

        /// <summary>
        /// Credential methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.ICredentialMethods Credential { get; }

        /// <summary>
        /// Label methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.ILabelMethods Label { get; }

        /// <summary>
        /// Tag methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.ITagMethods Tag { get; }

        /// <summary>
        /// Vector methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.IVectorMethods Vector { get; }

        /// <summary>
        /// Graph methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.IGraphMethods Graph { get; }

        /// <summary>
        /// Node methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.INodeMethods Node { get; }

        /// <summary>
        /// Edge methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.IEdgeMethods Edge { get; }

        /// <summary>
        /// Batch methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.IBatchMethods Batch { get; }

        /// <summary>
        /// Vector index methods.
        /// </summary>
        public override LiteGraph.GraphRepositories.Interfaces.IVectorIndexMethods VectorIndex { get; }

        #endregion

        #region Private-Members

        private readonly FastDB _database;
        private readonly FastDBOptions _options;

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Initialize the FastDB graph repository with default options.
        /// </summary>
        /// <param name="databasePath">Path to the FastDB database directory.</param>
        public FastDBGraphRepository(string databasePath)
            : this(databasePath, new FastDBOptions())
        {
        }

        /// <summary>
        /// Initialize the FastDB graph repository with custom options.
        /// </summary>
        /// <param name="databasePath">Path to the FastDB database directory.</param>
        /// <param name="options">FastDB options for compression, encryption, serialization, etc.</param>
        public FastDBGraphRepository(string databasePath, FastDBOptions options)
        {
            if (string.IsNullOrEmpty(databasePath))
                throw new ArgumentNullException(nameof(databasePath));

            // Configure options for optimal graph storage
            // Note: FastDBOptions properties are init-only, so we need to create a new instance
            _options = options ?? new FastDBOptions
            {
                Serializer = SerializerType.MessagePack_Contract  // Use MessagePack for compact storage (can reduce size by ~40%)
            };

            _database = new FastDB(_options);

            // Initialize implementation classes
            Admin = new Implementations.FastDB.AdminMethods(this);
            Tenant = new Implementations.FastDB.TenantMethods(this);
            User = new Implementations.FastDB.UserMethods(this);
            Credential = new Implementations.FastDB.CredentialMethods(this);
            Label = new Implementations.FastDB.LabelMethods(this);
            Tag = new Implementations.FastDB.TagMethods(this);
            Vector = new Implementations.FastDB.VectorMethods(this);
            Graph = new Implementations.FastDB.GraphMethods(this);
            Node = new Implementations.FastDB.NodeMethods(this);
            Edge = new Implementations.FastDB.EdgeMethods(this);
            Batch = new Implementations.FastDB.BatchMethods(this);
            VectorIndex = new Implementations.FastDB.VectorIndexMethods(this);
        }

        #endregion

        #region Public-Methods

        /// <summary>
        /// Initialize the repository schema.
        /// Collections are created when first used via GetCollection<TKey, TValue>()
        /// </summary>
        public override void InitializeRepository()
        {
            // FastDB automatically creates collections on first access
            // No explicit initialization needed
        }

        /// <summary>
        /// Flush database contents to disk.
        /// </summary>
        public override void Flush()
        {
            // FastDB collections are automatically flushed
            // The database handles persistence internally
        }
        /// <summary>
        /// Get the FastDB database instance.
        /// </summary>
        /// <returns>FastDB database instance.</returns>
        internal FastDB GetDatabase()
        {
            return _database;
        }

        /// <summary>
        /// Dispose the repository and close database connection.
        /// </summary>
        public void Dispose()
        {
            _database?.Close();
        }

        #endregion

        #region Private-Methods

        #endregion
    }
}
