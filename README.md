# WebNet.LiteGraphExtensions.GraphRepositories

Graph repository implementations for the LiteGraph library, providing persistent storage backends for graph data structures.

## Quick Start

```csharp
// Option 1: DuckDB (SQL-based, best for analytics)
var duckDb = new DuckDBGraphRepository("Data Source=mydb.duckdb");
duckDb.InitializeRepository();

// Option 2: FastDB (NoSQL, best for performance)
var fastDb = new FastDBGraphRepository("./mydb.fastdb", 
    new FastDBOptions { Serializer = SerializerType.MessagePack_Contract });
fastDb.InitializeRepository();

// Option 3: LiteDB (NoSQL, best for flexibility)
var liteDb = new LiteDBGraphRepository("mydata.db");
liteDb.InitializeRepository();

// Use any repository through the same LiteGraph interfaces
var tenant = await repository.Tenant.Create(new TenantMetadata 
{ 
    GUID = Guid.NewGuid(),
    Name = "My Tenant" 
});
```

## Overview

This library provides concrete implementations of the LiteGraph `GraphRepositoryBase` abstract class, enabling you to store and query graph data using various database backends.

## Comparison Table

| Feature | DuckDBGraphRepository | FastDBGraphRepository | LiteDBGraphRepository |
|---------|----------------------|----------------------|----------------------|
| **Storage Type** | SQL (Columnar) | NoSQL (Key-Value Collections) | NoSQL (Document/BSON) |
| **Best For** | Analytics, Complex Queries | Simple CRUD, High Performance | General Purpose, Flexible Queries |
| **ACID Compliance** | ✅ Full | ⚠️ Limited | ✅ Full |
| **Schema Required** | ✅ Yes | ❌ No | ❌ No |
| **Backup Support** | ✅ Native | ⚠️ Manual | ⚠️ Pending |
| **In-Memory Mode** | ✅ Yes | ❌ No | ✅ Yes |
| **Serialization** | SQL | MessagePack/JSON/Binary | BSON |
| **File Size** | Large | Small | Medium |
| **Query Performance** | Excellent (SQL) | Very Fast (Direct Key Access) | Good (LINQ with Indexes) |
| **Setup Complexity** | Medium | Low | Low |
| **LINQ Support** | ❌ No | ❌ No | ✅ Full |
| **Encryption** | ❌ No | ❌ No | ✅ Yes |
| **Cross-Platform** | ✅ Yes | ✅ Yes | ✅ Yes |

## When to Use Each Implementation

- **DuckDBGraphRepository**: Choose when you need complex analytical queries, reporting, or data warehousing capabilities. Best for read-heavy workloads with complex joins and aggregations.

- **FastDBGraphRepository**: Choose when you need lightweight embedded storage with simple key-based access patterns. Best for write-heavy workloads, caching, or when storage size is a concern.

- **LiteDBGraphRepository**: Choose when you need a balance of features - document flexibility, LINQ queries, ACID transactions, and optional encryption. Best for general-purpose applications requiring flexible schema and good query performance.

## Available Implementations

### DuckDBGraphRepository

A high-performance graph repository implementation using DuckDB, an in-process SQL OLAP database optimized for analytical queries.

#### Features

- **Full ACID Compliance**: Transactional support with DuckDB's built-in ACID guarantees
- **Schema Management**: Automatic database schema initialization with foreign keys and indexes
- **Backup Support**: Native backup functionality via DuckDB's EXPORT DATABASE
- **Columnar Storage**: Efficient storage for large-scale graph analytics
- **In-Memory or Persistent**: Supports both file-based and in-memory databases

#### Usage

```csharp
using WebNet.LiteGraphExtensions.GraphRepositories;

// Create repository with file-based storage
var repository = new DuckDBGraphRepository("Data Source=mydb.duckdb");

// Initialize the database schema
repository.InitializeRepository();

// Use the repository through LiteGraph interfaces
var tenant = await repository.Tenant.Create(new TenantMetadata 
{ 
    GUID = Guid.NewGuid(),
    Name = "My Tenant" 
});

var graph = await repository.Graph.Create(new Graph
{
    GUID = Guid.NewGuid(),
    TenantGUID = tenant.GUID,
    Name = "My Graph"
});

// Flush changes to disk
repository.Flush();

// Backup database
await repository.Admin.Backup("./backup");

// Dispose when done
repository.Dispose();
```

#### Connection Strings

DuckDB supports standard ADO.NET connection string format:

- **File-based**: `Data Source=path/to/database.duckdb`
- **In-memory**: `Data Source=:memory:`
- **Read-only**: `Data Source=database.duckdb;Read Only=true`

#### Database Schema

The DuckDB implementation creates the following tables:

- **tenants** - Tenant metadata
- **graphs** - Graph definitions
- **nodes** - Graph nodes with properties
- **edges** - Graph edges connecting nodes
- **labels** - Labels for graphs, nodes, and edges
- **tags** - Key-value tags for graphs, nodes, and edges
- **vectors** - Vector embeddings for similarity search
- **users** - User accounts and authentication
- **credentials** - API credentials for programmatic access

All tables include appropriate foreign keys, indexes, and constraints for data integrity.

#### Implementation Status

The DuckDB repository provides:
- ✅ **Admin Methods**: Backup operations implemented
- ✅ **Connection Management**: Full lifecycle support with proper disposal
- ✅ **Schema Initialization**: Automatic table creation with relationships
- ⚠️ **CRUD Operations**: Interface methods defined, implementation in progress

Note: Most CRUD operations currently throw `NotImplementedException` and require implementation based on your specific use case.

### FastDBGraphRepository

A lightweight, embedded graph repository implementation using Stellar.FastDB, a high-performance NoSQL database with collection-based storage.

#### Features

- **Embedded NoSQL**: No separate database server required
- **Collection-Based**: Each entity type stored in its own typed collection
- **MessagePack Serialization**: 40% storage reduction with high-performance binary serialization
- **Simple API**: Direct key-value access patterns
- **Auto-Persistence**: Automatic flushing to disk
- **Lightweight**: Minimal dependencies and memory footprint

#### Usage

```csharp
using WebNet.LiteGraphExtensions.GraphRepositories;
using Stellar.Collections;

// Create repository with file-based storage
var options = new FastDBOptions
{
    Serializer = SerializerType.MessagePack_Contract
};
var repository = new FastDBGraphRepository("./mydb.fastdb", options);

// Collections are automatically created on first access
repository.InitializeRepository();

// Use the repository through LiteGraph interfaces
var tenant = await repository.Tenant.Create(new TenantMetadata 
{ 
    GUID = Guid.NewGuid(),
    Name = "My Tenant" 
});

var graph = await repository.Graph.Create(new Graph
{
    GUID = Guid.NewGuid(),
    TenantGUID = tenant.GUID,
    Name = "My Graph"
});

// Flush happens automatically, but can be called explicitly
repository.Flush();

// Dispose when done
repository.Dispose();
```

#### Configuration Options

FastDB supports various serialization formats:

- **MessagePack_Contract** (recommended): 40% smaller, requires `[DataContract]` attributes
- **MessagePack**: General MessagePack without contracts
- **Json**: Human-readable JSON format
- **Binary**: .NET binary serialization

#### Data Storage

The FastDB implementation stores data in typed collections:

- **TenantMetadata** - Tenant metadata (keyed by GUID)
- **Graph** - Graph definitions (keyed by GUID)
- **Node** - Graph nodes with properties (keyed by GUID)
- **Edge** - Graph edges connecting nodes (keyed by GUID)
- **LabelMetadata** - Labels for graphs, nodes, and edges (keyed by GUID)
- **TagMetadata** - Key-value tags for graphs, nodes, and edges (keyed by GUID)
- **VectorMetadata** - Vector embeddings for similarity search (keyed by GUID)
- **UserMaster** - User accounts and authentication (keyed by GUID)
- **Credential** - API credentials for programmatic access (keyed by GUID)

Collections are automatically created when first accessed, with no schema definition required.

#### Implementation Status

The FastDB repository provides:
- ✅ **Collection Management**: Automatic collection creation and initialization
- ✅ **Resource Management**: Proper disposal and cleanup
- ✅ **Serialization**: MessagePack optimization for storage efficiency
- ⚠️ **CRUD Operations**: Interface methods defined, implementation in progress

Note: Most CRUD operations currently throw `NotImplementedException` and require implementation based on your specific use case.

### LiteDBGraphRepository

A versatile document-oriented graph repository implementation using LiteDB, a lightweight NoSQL embedded database for .NET with MongoDB-like features.

#### Features

- **Document Storage**: Schema-less BSON document storage
- **LINQ Queries**: Full LINQ support for querying collections
- **Indexes**: Automatic index creation for performance optimization
- **ACID Transactions**: Full ACID compliance with transaction support
- **File-Based or In-Memory**: Supports both persistent and memory-only databases
- **Embedded**: No separate database server required
- **Cross-Platform**: Works on Windows, Linux, and macOS

#### Usage

```csharp
using WebNet.LiteGraphExtensions.GraphRepositories;

// Create repository with file-based storage
var repository = new LiteDBGraphRepository("mydata.db");

// Or use connection string for advanced options
var repository = new LiteDBGraphRepository("Filename=mydata.db;Connection=shared");

// Initialize and create indexes
repository.InitializeRepository();

// Use the repository through LiteGraph interfaces
var tenant = await repository.Tenant.Create(new TenantMetadata 
{ 
    GUID = Guid.NewGuid(),
    Name = "My Tenant" 
});

var graph = await repository.Graph.Create(new Graph
{
    GUID = Guid.NewGuid(),
    TenantGUID = tenant.GUID,
    Name = "My Graph"
});

// Flush changes to disk (checkpoint)
repository.Flush();

// Dispose when done
repository.Dispose();
```

#### Connection Strings

LiteDB supports various connection string options:

- **Simple file**: `"mydata.db"`
- **With options**: `"Filename=mydata.db;Connection=shared"`
- **In-memory**: `"Filename=:memory:"`
- **Temporary**: `"Filename=:temp:"`
- **Read-only**: `"Filename=mydata.db;ReadOnly=true"`
- **Encrypted**: `"Filename=mydata.db;Password=mypassword"`

#### Data Storage

The LiteDB implementation stores data in BSON document collections:

- **tenants** - Tenant metadata (indexed by GUID and Name)
- **graphs** - Graph definitions (indexed by GUID and TenantGUID)
- **nodes** - Graph nodes with properties (indexed by GUID, GraphGUID, TenantGUID)
- **edges** - Graph edges connecting nodes (indexed by GUID, GraphGUID, From, To)
- **labels** - Labels for graphs, nodes, and edges (indexed by GUID)
- **tags** - Key-value tags for graphs, nodes, and edges (indexed by GUID)
- **vectors** - Vector embeddings for similarity search (indexed by GUID)
- **users** - User accounts and authentication (indexed by GUID and Email)
- **credentials** - API credentials for programmatic access (indexed by GUID)

Indexes are automatically created during initialization for optimal query performance.

#### Implementation Status

The LiteDB repository provides:
- ✅ **Collection Management**: Automatic collection and index creation
- ✅ **Connection Management**: Full lifecycle support with proper disposal
- ✅ **Index Optimization**: Strategic indexes on commonly queried fields
- ⚠️ **CRUD Operations**: Interface methods defined, implementation in progress

Note: Most CRUD operations currently throw `NotImplementedException` and require implementation based on your specific use case.

## Architecture

All repository implementations follow a common pattern:

```
GraphRepositoryBase (abstract)
├── DuckDBGraphRepository
│   ├── AdminMethods (IAdminMethods)
│   ├── TenantMethods (ITenantMethods)
│   ├── UserMethods (IUserMethods)
│   ├── CredentialMethods (ICredentialMethods)
│   ├── LabelMethods (ILabelMethods)
│   ├── TagMethods (ITagMethods)
│   ├── VectorMethods (IVectorMethods)
│   ├── GraphMethods (IGraphMethods)
│   ├── NodeMethods (INodeMethods)
│   ├── EdgeMethods (IEdgeMethods)
│   ├── BatchMethods (IBatchMethods)
│   └── VectorIndexMethods (IVectorIndexMethods)
│
├── FastDBGraphRepository
│   └── (same interface structure)
│
└── LiteDBGraphRepository
    └── (same interface structure)
```

Each implementation provides the same 12 interface implementations, ensuring consistent API across all storage backends.

## Performance Considerations

### DuckDB
- Optimized for analytical queries and aggregations
- Best performance with columnar data access patterns
- In-memory mode provides fastest query execution
- Batch inserts significantly faster than individual inserts
- Consider using COPY statements for bulk data loading

### FastDB
- Ultra-fast key-based lookups (O(1) complexity)
- MessagePack serialization reduces I/O overhead
- Best for single-entity CRUD operations
- Limited support for complex queries across collections
- Auto-flush may impact write-heavy workload performance

### LiteDB
- Excellent LINQ query performance with proper indexing
- BSON serialization balances size and speed
- Document-oriented design allows flexible schema evolution
- In-memory mode suitable for testing and caching
- Index maintenance overhead on write operations
- Single-file database simplifies deployment and backup

## Installation

```bash
dotnet add package WebNet.LiteGraphExtensions.GraphRepositories
```

## Requirements

- .NET 10.0 or later
- LiteGraph 5.0.2
- DuckDB.NET.Data.Full 1.4.3 (for DuckDB implementation)
- Stellar.FastDB 1.1.1 (for FastDB implementation)
- LiteDB 5.0.21 (for LiteDB implementation)

## Testing

The library includes comprehensive unit tests for all implementations:

```bash
dotnet test
```

Test coverage includes:
- **DuckDB**: 13 tests validating SQL-based storage, schema creation, and backup
- **FastDB**: 11 tests validating collection-based storage and resource management
- **LiteDB**: 14 tests validating document storage, indexing, and LINQ support

All 38 tests validate:
- Repository construction and initialization
- Connection/path validation
- Schema/collection creation
- Method implementation instantiation
- Resource disposal
- Implementation-specific features (backup, serialization, indexing, etc.)

## Roadmap

### Current Status (v1.0)
- ✅ DuckDB implementation with SQL storage
- ✅ FastDB implementation with NoSQL collections
- ✅ LiteDB implementation with document storage
- ✅ 38 passing unit tests
- ✅ Basic repository lifecycle management

### Planned Features
- 🔄 Complete CRUD operation implementations for all entities
- 🔄 Advanced query support (filtering, pagination, sorting)
- 🔄 Transaction support across repositories
- 🔄 Migration tools between storage backends
- 🔄 Performance benchmarking suite
- 🔄 Vector similarity search implementation
- 🔄 Graph traversal algorithms
- 🔄 Full backup/restore implementations

## Contributing

Contributions are welcome! Please ensure all tests pass before submitting pull requests.

## License

See [LICENSE.txt](LICENSE.txt) for details.