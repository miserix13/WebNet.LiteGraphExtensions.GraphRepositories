using System;
using DuckDB.NET.Data;
using LiteGraph.GraphRepositories.Interfaces;

namespace WebNet.LiteGraphExtensions.GraphRepositories
{
    /// <summary>
    /// DuckDB Graph Repository implementation.
    /// Provides graph storage and retrieval using DuckDB as the backend.
    /// </summary>
    public class DuckDBGraphRepository : LiteGraph.GraphRepositories.GraphRepositoryBase
    {
        #region Public-Members

        /// <summary>
        /// Admin methods.
        /// </summary>
        public override IAdminMethods Admin { get; }

        /// <summary>
        /// Tenant methods.
        /// </summary>
        public override ITenantMethods Tenant { get; }

        /// <summary>
        /// User methods.
        /// </summary>
        public override IUserMethods User { get; }

        /// <summary>
        /// Credential methods.
        /// </summary>
        public override ICredentialMethods Credential { get; }

        /// <summary>
        /// Label methods.
        /// </summary>
        public override ILabelMethods Label { get; }

        /// <summary>
        /// Tag methods.
        /// </summary>
        public override ITagMethods Tag { get; }

        /// <summary>
        /// Vector methods.
        /// </summary>
        public override IVectorMethods Vector { get; }

        /// <summary>
        /// Graph methods.
        /// </summary>
        public override IGraphMethods Graph { get; }

        /// <summary>
        /// Node methods.
        /// </summary>
        public override INodeMethods Node { get; }

        /// <summary>
        /// Edge methods.
        /// </summary>
        public override IEdgeMethods Edge { get; }

        /// <summary>
        /// Batch methods.
        /// </summary>
        public override IBatchMethods Batch { get; }

        /// <summary>
        /// Vector index methods.
        /// </summary>
        public override IVectorIndexMethods VectorIndex { get; }

        #endregion

        #region Private-Members

        private readonly string _connectionString;
        private readonly DuckDBConnection _connection;

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Initialize the DuckDB graph repository.
        /// </summary>
        /// <param name="connectionString">DuckDB connection string.</param>
        public DuckDBGraphRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
            _connection = new DuckDBConnection(connectionString);
            _connection.Open();

            // Initialize implementation classes
            Admin = new Implementations.AdminMethods(this);
            Tenant = new Implementations.TenantMethods(this);
            User = new Implementations.UserMethods(this);
            Credential = new Implementations.CredentialMethods(this);
            Label = new Implementations.LabelMethods(this);
            Tag = new Implementations.TagMethods(this);
            Vector = new Implementations.VectorMethods(this);
            Graph = new Implementations.GraphMethods(this);
            Node = new Implementations.NodeMethods(this);
            Edge = new Implementations.EdgeMethods(this);
            Batch = new Implementations.BatchMethods(this);
            VectorIndex = new Implementations.VectorIndexMethods(this);

            InitializeRepository();
        }

        #endregion

        #region Public-Methods

        /// <summary>
        /// Initialize the repository schema.
        /// </summary>
        public override void InitializeRepository()
        {
            // Create necessary database tables and schemas for DuckDB
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"
                    -- Create tenants table
                    CREATE TABLE IF NOT EXISTS tenants (
                        guid VARCHAR PRIMARY KEY,
                        name VARCHAR NOT NULL,
                        created_utc TIMESTAMP NOT NULL,
                        data JSON
                    );

                    -- Create graphs table
                    CREATE TABLE IF NOT EXISTS graphs (
                        guid VARCHAR PRIMARY KEY,
                        tenant_guid VARCHAR NOT NULL,
                        name VARCHAR NOT NULL,
                        created_utc TIMESTAMP NOT NULL,
                        labels VARCHAR[],
                        tags JSON,
                        data JSON,
                        FOREIGN KEY (tenant_guid) REFERENCES tenants(guid)
                    );

                    -- Create nodes table
                    CREATE TABLE IF NOT EXISTS nodes (
                        guid VARCHAR PRIMARY KEY,
                        tenant_guid VARCHAR NOT NULL,
                        graph_guid VARCHAR NOT NULL,
                        name VARCHAR,
                        created_utc TIMESTAMP NOT NULL,
                        labels VARCHAR[],
                        tags JSON,
                        data JSON,
                        FOREIGN KEY (tenant_guid) REFERENCES tenants(guid),
                        FOREIGN KEY (graph_guid) REFERENCES graphs(guid)
                    );

                    -- Create edges table
                    CREATE TABLE IF NOT EXISTS edges (
                        guid VARCHAR PRIMARY KEY,
                        tenant_guid VARCHAR NOT NULL,
                        graph_guid VARCHAR NOT NULL,
                        from_node_guid VARCHAR NOT NULL,
                        to_node_guid VARCHAR NOT NULL,
                        name VARCHAR,
                        created_utc TIMESTAMP NOT NULL,
                        labels VARCHAR[],
                        tags JSON,
                        data JSON,
                        FOREIGN KEY (tenant_guid) REFERENCES tenants(guid),
                        FOREIGN KEY (graph_guid) REFERENCES graphs(guid),
                        FOREIGN KEY (from_node_guid) REFERENCES nodes(guid),
                        FOREIGN KEY (to_node_guid) REFERENCES nodes(guid)
                    );

                    -- Create labels table
                    CREATE TABLE IF NOT EXISTS labels (
                        guid VARCHAR PRIMARY KEY,
                        tenant_guid VARCHAR NOT NULL,
                        graph_guid VARCHAR,
                        name VARCHAR NOT NULL,
                        created_utc TIMESTAMP NOT NULL,
                        FOREIGN KEY (tenant_guid) REFERENCES tenants(guid)
                    );

                    -- Create users table
                    CREATE TABLE IF NOT EXISTS users (
                        guid VARCHAR PRIMARY KEY,
                        tenant_guid VARCHAR,
                        email VARCHAR NOT NULL,
                        created_utc TIMESTAMP NOT NULL,
                        data JSON
                    );

                    -- Create credentials table
                    CREATE TABLE IF NOT EXISTS credentials (
                        guid VARCHAR PRIMARY KEY,
                        user_guid VARCHAR NOT NULL,
                        credential_type VARCHAR NOT NULL,
                        credential_data JSON NOT NULL,
                        created_utc TIMESTAMP NOT NULL,
                        FOREIGN KEY (user_guid) REFERENCES users(guid)
                    );

                    -- Create vectors table
                    CREATE TABLE IF NOT EXISTS vectors (
                        guid VARCHAR PRIMARY KEY,
                        tenant_guid VARCHAR NOT NULL,
                        graph_guid VARCHAR NOT NULL,
                        node_guid VARCHAR NOT NULL,
                        embedding DOUBLE[],
                        created_utc TIMESTAMP NOT NULL,
                        metadata JSON,
                        FOREIGN KEY (tenant_guid) REFERENCES tenants(guid),
                        FOREIGN KEY (graph_guid) REFERENCES graphs(guid),
                        FOREIGN KEY (node_guid) REFERENCES nodes(guid)
                    );

                    -- Create tags table
                    CREATE TABLE IF NOT EXISTS tags (
                        guid VARCHAR PRIMARY KEY,
                        tenant_guid VARCHAR NOT NULL,
                        graph_guid VARCHAR,
                        name VARCHAR NOT NULL,
                        value VARCHAR,
                        created_utc TIMESTAMP NOT NULL,
                        FOREIGN KEY (tenant_guid) REFERENCES tenants(guid)
                    );

                    -- Create indexes
                    CREATE INDEX IF NOT EXISTS idx_graphs_tenant ON graphs(tenant_guid);
                    CREATE INDEX IF NOT EXISTS idx_nodes_graph ON nodes(graph_guid);
                    CREATE INDEX IF NOT EXISTS idx_nodes_tenant ON nodes(tenant_guid);
                    CREATE INDEX IF NOT EXISTS idx_edges_graph ON edges(graph_guid);
                    CREATE INDEX IF NOT EXISTS idx_edges_from ON edges(from_node_guid);
                    CREATE INDEX IF NOT EXISTS idx_edges_to ON edges(to_node_guid);
                    CREATE INDEX IF NOT EXISTS idx_labels_tenant ON labels(tenant_guid);
                    CREATE INDEX IF NOT EXISTS idx_vectors_node ON vectors(node_guid);
                    CREATE INDEX IF NOT EXISTS idx_tags_tenant ON tags(tenant_guid);
                ";

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Flush database contents to disk.
        /// </summary>
        public override void Flush()
        {
            // DuckDB automatically flushes to disk, but we can force a checkpoint
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CHECKPOINT;";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get the DuckDB connection.
        /// </summary>
        /// <returns>DuckDB connection.</returns>
        internal DuckDBConnection GetConnection()
        {
            return _connection;
        }

        /// <summary>
        /// Dispose the repository.
        /// </summary>
        public void Dispose()
        {
            _connection?.Dispose();
        }

        #endregion

        #region Private-Methods

        #endregion
    }
}
