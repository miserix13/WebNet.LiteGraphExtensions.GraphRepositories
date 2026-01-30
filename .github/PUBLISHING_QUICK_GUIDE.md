# Quick Publishing Guide

## 🚀 Quick Start

1. **One-time setup**: Add your NuGet API key to repository secrets
   ```
   Settings → Secrets and variables → Actions → New repository secret
   Name: NUGET_API_KEY
   Value: [Your NuGet API key from nuget.org]
   ```

2. **Publish a new version**:
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

That's it! The GitHub Action will automatically build, test, and publish.

## 📋 Checklist Before Publishing

- [ ] All tests pass locally (`dotnet test`)
- [ ] Version number follows semantic versioning
- [ ] CHANGELOG updated (if applicable)
- [ ] README is up to date
- [ ] No breaking changes without major version bump

## 🔢 Version Numbers

- `v1.0.0` → First stable release
- `v1.1.0` → New features added
- `v1.1.1` → Bug fixes
- `v2.0.0` → Breaking changes

## 📦 What Gets Published

- NuGet package (`.nupkg`)
- Debug symbols (`.snupkg`)
- README included in package
- All three implementations: DuckDB, FastDB, LiteDB

## 🔗 Links

- **NuGet.org**: https://www.nuget.org/packages/WebNet.LiteGraphExtensions.GraphRepositories
- **GitHub Releases**: Check the Releases tab for all versions
- **Full Documentation**: See [PUBLISHING.md](PUBLISHING.md)

## ⚡ Manual Trigger

If you need to publish without creating a tag:
1. Go to Actions tab
2. Select "Publish NuGet Package"
3. Click "Run workflow"
4. Enter version (e.g., `1.0.1`)
5. Click "Run workflow"
