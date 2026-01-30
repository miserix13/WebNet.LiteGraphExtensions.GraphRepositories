# WebNet.LiteGraphExtensions.GraphRepositories

Graph repository implementations for the LiteGraph library, providing persistent storage backends for graph data structures.

## Overview

This library provides concrete implementations of the LiteGraph `GraphRepositoryBase` abstract class, enabling you to store and query graph data using various database backends.

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

*(Documentation pending)*

## Installation

```bash
dotnet add package WebNet.LiteGraphExtensions.GraphRepositories
```

## Requirements

- .NET 10.0 or later
- LiteGraph 5.0.2
- DuckDB.NET.Data.Full 1.4.3 (for DuckDB implementation)
- Stellar.FastDB 1.1.1 (for FastDB implementation)

## Testing

The library includes comprehensive unit tests for all implementations:

```bash
dotnet test
```

Test coverage includes:
- **DuckDB**: 13 tests validating SQL-based storage, schema creation, and backup
- **FastDB**: 11 tests validating collection-based storage and resource management

All 24 tests validate:
- Repository construction and initialization
- Connection/path validation
- Schema/collection creation
- Method implementation instantiation
- Resource disposal
- Implementation-specific features (backup, serialization, etc.)

## Contributing

Contributions are welcome! Please ensure all tests pass before submitting pull requests.

## License

See [LICENSE.txt](LICENSE.txt) for details.