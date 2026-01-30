# Publishing to NuGet

This repository includes a GitHub Action workflow that automatically builds, tests, and publishes the NuGet package.

## Prerequisites

1. **NuGet API Key**: You need to create an API key from [NuGet.org](https://www.nuget.org/account/apikeys)
2. **GitHub Secret**: Add your NuGet API key as a repository secret:
   - Go to repository Settings → Secrets and variables → Actions
   - Click "New repository secret"
   - Name: `NUGET_API_KEY`
   - Value: Your NuGet API key

## Publishing Methods

### Method 1: Automatic Publishing via Git Tags (Recommended)

The workflow automatically triggers when you push a version tag:

```bash
# Create and push a version tag
git tag v1.0.0
git push origin v1.0.0

# Or create with annotation
git tag -a v1.0.0 -m "Release version 1.0.0"
git push origin v1.0.0
```

The workflow will:
- Extract version from the tag (e.g., `v1.0.0` → `1.0.0`)
- Build and test the project
- Create NuGet package with the version
- Publish to NuGet.org
- Create a GitHub Release with the package attached

### Method 2: Manual Publishing via GitHub UI

You can manually trigger the workflow from GitHub:

1. Go to repository → Actions → "Publish NuGet Package"
2. Click "Run workflow"
3. Enter the version number (e.g., `1.0.1`)
4. Click "Run workflow"

## Version Numbering

Follow [Semantic Versioning](https://semver.org/):
- **MAJOR.MINOR.PATCH** (e.g., 1.2.3)
- **MAJOR**: Breaking changes
- **MINOR**: New features (backward compatible)
- **PATCH**: Bug fixes (backward compatible)

Examples:
- `v1.0.0` - Initial release
- `v1.1.0` - Added new feature
- `v1.1.1` - Bug fix
- `v2.0.0` - Breaking changes

## Testing Before Publishing

Always test the package build locally before publishing:

```bash
# Build the project
dotnet build --configuration Release

# Run tests
dotnet test --configuration Release

# Create package (without publishing)
dotnet pack --configuration Release --output ./artifacts

# Inspect the package
unzip -l ./artifacts/WebNet.LiteGraphExtensions.GraphRepositories.*.nupkg
```

## Workflow Details

The GitHub Action workflow (`publish-nuget.yml`) performs these steps:

1. **Checkout**: Gets the repository code
2. **Setup .NET**: Installs .NET 10.0
3. **Extract Version**: Gets version from tag or input
4. **Restore**: Restores NuGet dependencies
5. **Build**: Builds in Release configuration
6. **Test**: Runs all unit tests
7. **Pack**: Creates NuGet package with metadata
8. **Publish**: Pushes to NuGet.org
9. **Artifacts**: Uploads package to GitHub
10. **Release**: Creates GitHub release (for tag pushes)

## Package Metadata

The package includes:
- **PackageId**: WebNet.LiteGraphExtensions.GraphRepositories
- **Title**: LiteGraph Repository Extensions
- **Description**: Full implementation descriptions
- **Tags**: litegraph, graph, database, repository, duckdb, fastdb, litedb
- **License**: MIT
- **README**: Included in package
- **Symbols**: Debug symbols included (.snupkg)

## Troubleshooting

### Build Fails
- Ensure all tests pass locally
- Check .NET version compatibility
- Verify all dependencies are restored

### Authentication Fails
- Verify `NUGET_API_KEY` secret is set correctly
- Check API key hasn't expired on NuGet.org
- Ensure API key has "Push" permissions

### Version Already Exists
- NuGet doesn't allow overwriting versions
- Increment the version number
- Delete the tag and recreate with new version

### Package Not Appearing
- NuGet indexing can take 10-15 minutes
- Check workflow logs for errors
- Verify package passed validation

## Updating Package

To publish an update:

```bash
# Make your changes
git add .
git commit -m "Your changes"
git push

# Create new version tag
git tag v1.0.1
git push origin v1.0.1
```

## Rolling Back

If you need to unlist a version:

1. Go to [NuGet.org](https://www.nuget.org/)
2. Find your package
3. Select the version
4. Click "Unlist"

Note: Unlisted packages can still be installed if version is specified explicitly.

## GitHub Release

Each tagged release creates a GitHub Release with:
- Release notes (auto-generated from commits)
- NuGet package (.nupkg) attached
- Symbols package (.snupkg) attached

View releases at: `https://github.com/YOUR_USERNAME/WebNet.LiteGraphExtensions.GraphRepositories/releases`
