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

### LiteDBGraphRepository

*(Documentation pending)*

### FastDBGraphRepository

*(Documentation pending)*

## Installation

```bash
dotnet add package WebNet.LiteGraphExtensions.GraphRepositories
```

## Requirements

- .NET 10.0 or later
- LiteGraph 5.0.2
- DuckDB.NET.Data.Full 1.4.3 (for DuckDB implementation)

## Testing

The library includes comprehensive unit tests:

```bash
dotnet test
```

All 13 tests validate:
- Repository construction and initialization
- Connection string validation
- Schema creation
- Method implementation instantiation
- Resource disposal
- Backup functionality

## Contributing

Contributions are welcome! Please ensure all tests pass before submitting pull requests.

## License

See [LICENSE.txt](LICENSE.txt) for details.