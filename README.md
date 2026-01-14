# About This Project

This project contains the public site for [https://api.xunit.net/](https://api.xunit.net/).

To open an issue for this project, please visit the [core xUnit.net project issue tracker](https://github.com/xunit/xunit/issues).

## Building and Contribution

This site is built with DocFX. We use a C#-based build system.

### Build prerequisites

In order to successfully view the content locally, you will need the following pre-requisites:

* [.NET SDK 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
* [Docker](https://docs.docker.com/engine/install/) to host nginx for serving built content locally

We have verified this works using both Windows and Linux.

### Building and serving

To build the static content for the site, run `./build`. This will run DocFX to convert the Markdown and YAML files into static content, under a top-level `_site` folder.

To serve the `_site` folder locally, you can run `./build serve` which will launch nginx in a Docker container, and serve the content [locally on port 4001](http://127.0.0.1:4001/).

_Important note: You must rebuild the site manually when making changes either to the site or the metadata. The nginx container merely serves whatever lives in `/_site`._

### Editing the site pages

The site content lives in [`/site`](https://github.com/xunit/api.xunit.net/tree/main/site).

Text editors/IDEs which understand site hierarchy and linking while editing Markdown are strongly encouraged to open the `/site` folder and not the root folder when editing content, so that the editor understands where the content root lives. _For example, if you're using VSCode, you should run `code site` and not `code .` from the root of the repo._

### Adding metadata for a new xUnit.net version

The [`/metadata`](https://github.com/xunit/api.xunit.net/tree/main/metadata) folder contains the versions of metadata created by `dotnet docfx metadata` during xUnit.net's CI process.

* Download the `docfx` artifact from the appropriate GitHub Actions build, and unzip it into a new folder under `/metadata` that aligns with the version of the assemblies (i.e., the metadata for the `2.0.1` packages for xUnit.net v3 lives under `/metadata/v3/2.0.1`).

* Update the `branch: main` lines in the `.yml` files in the metadata with git hashes. Look for `repo: https://github.com/xunit/xunit` and `repo: https://github.com/xunit/assert.xunit`, as you will need different commit hashes for each repo.

* Create `/site/v3/{version}/index.md` (copy the previous version's `index.md` and update it to add any new significant APIs).

* Update [`/site/v3/index.md`](https://github.com/xunit/api.xunit.net/tree/main/site/v3/index.md) to point to the new version.

* Update [`/site/index.md`](https://github.com/xunit/api.xunit.net/tree/main/site/index.md) to point to the new version.

* Update [`/site/toc.yml`](https://github.com/xunit/api.xunit.net/tree/main/site/toc.yml) to add an entry for the new version.

* Update [the `/site/toc.yml` file for https://xunit.net](https://github.com/xunit/xunit.net/tree/main/site/toc.yml) to add an entry for the new version. (This will need to be cloned and pushed separately.)

Now you should be able to build the site and view the new API version.

# About xUnit.net

xUnit.net is a free, open source, community-focused unit testing tool for C#, F#, and Visual Basic.

xUnit.net works with the [.NET SDK](https://dotnet.microsoft.com/download) command line tools, [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/), [JetBrains Rider](https://www.jetbrains.com/rider/), [NCrunch](https://www.ncrunch.net/), and any development environment compatible with [Microsoft Testing Platform](https://learn.microsoft.com/dotnet/core/testing/microsoft-testing-platform-intro) (xUnit.net v3) or [VSTest](https://github.com/microsoft/vstest) (all versions of xUnit.net).

xUnit.net is part of the [.NET Foundation](https://www.dotnetfoundation.org/) and operates under their [code of conduct](https://www.dotnetfoundation.org/code-of-conduct). It is licensed under [Apache 2](https://opensource.org/licenses/Apache-2.0) (an OSI approved license). The project is [governed](https://xunit.net/governance) by a Project Lead.

For project documentation, please visit the [xUnit.net project home](https://xunit.net/).

* _New to xUnit.net? Get started with the [.NET SDK](https://xunit.net/docs/getting-started/v3/getting-started)._
* _Need some help building the source? See [BUILDING.md](https://github.com/xunit/xunit/tree/main/BUILDING.md)._
* _Want to contribute to the project? See [CONTRIBUTING.md](https://github.com/xunit/.github/tree/main/CONTRIBUTING.md)._
* _Want to contribute to the assertion library? See the [suggested contribution workflow](https://github.com/xunit/assert.xunit/tree/main/README.md#suggested-contribution-workflow) in the assertion library project, as it is slightly more complex due to code being spread across two GitHub repositories._

## Latest Builds

|                             | Latest stable                                                                                                                            | Latest CI ([how to use](https://xunit.net/docs/using-ci-builds))                                                                                                                       | Build status
| --------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------
| `xunit.v3`                  | [![](https://img.shields.io/nuget/v/xunit.v3.svg?logo=nuget)](https://www.nuget.org/packages/xunit.v3)                                   | [![](https://img.shields.io/feedz/vpre/xunit/xunit/xunit.v3?logo=nuget&color=f58142)](https://feedz.io/org/xunit/repository/xunit/packages/xunit.v3)                                   | [![](https://img.shields.io/endpoint.svg?url=https://actions-badge.atrox.dev/xunit/xunit/badge%3Fref%3Dmain&amp;label=build)](https://actions-badge.atrox.dev/xunit/xunit/goto?ref=main)
| `xunit`                     | [![](https://img.shields.io/nuget/v/xunit.svg?logo=nuget)](https://www.nuget.org/packages/xunit)                                         | [![](https://img.shields.io/feedz/vpre/xunit/xunit/xunit?logo=nuget&color=f58142)](https://feedz.io/org/xunit/repository/xunit/packages/xunit)                                         | [![](https://img.shields.io/endpoint.svg?url=https://actions-badge.atrox.dev/xunit/xunit/badge%3Fref%3Dv2&amp;label=build)](https://actions-badge.atrox.dev/xunit/xunit/goto?ref=v2)
| `xunit.analyzers`           | [![](https://img.shields.io/nuget/v/xunit.analyzers.svg?logo=nuget)](https://www.nuget.org/packages/xunit.analyzers)                     | [![](https://img.shields.io/feedz/vpre/xunit/xunit/xunit.analyzers?logo=nuget&color=f58142)](https://feedz.io/org/xunit/repository/xunit/packages/xunit.analyzers)                     | [![](https://img.shields.io/endpoint.svg?url=https://actions-badge.atrox.dev/xunit/xunit.analyzers/badge%3Fref%3Dmain&amp;label=build)](https://actions-badge.atrox.dev/xunit/xunit.analyzers/goto?ref=main)
| `xunit.runner.visualstudio` | [![](https://img.shields.io/nuget/v/xunit.runner.visualstudio.svg?logo=nuget)](https://www.nuget.org/packages/xunit.runner.visualstudio) | [![](https://img.shields.io/feedz/vpre/xunit/xunit/xunit.runner.visualstudio?logo=nuget&color=f58142)](https://feedz.io/org/xunit/repository/xunit/packages/xunit.runner.visualstudio) | [![](https://img.shields.io/endpoint.svg?url=https://actions-badge.atrox.dev/xunit/visualstudio.xunit/badge%3Fref%3Dmain&amp;label=build)](https://actions-badge.atrox.dev/xunit/visualstudio.xunit/goto?ref=main)

*For complete CI package lists, please visit the [feedz.io package search](https://feedz.io/org/xunit/repository/xunit/search). A free login is required.*

## Sponsors

Help support this project by becoming a sponsor through [GitHub Sponsors](https://github.com/sponsors/xunit).
