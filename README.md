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

To serve the `_site` folder locally, you can run `./build serve` which will launch nginx in a Docker container, and serve the content [locally on port 4000](http://localhost:4000/).

_Important note: You must rebuild the site manually when making changes either to the site or the metadata. The nginx container merely serves whatever lives in `/_site`._

### Editing the site pages

The site content lives in [`/site`](https://github.com/xunit/api.xunit.net/tree/main/site).

Text editors/IDEs which understand site hierarchy and linking while editing Markdown are strongly encouraged to open the `/site` folder and not the root folder when editing content, so that the editor understands where the content root lives. _For example, if you're using VSCode, you should run `code site` and not `code .` from the root of the repo._

### Adding metadata for a new xUnit.net version

The [`/metadata`](https://github.com/xunit/api.xunit.net/tree/main/metadata) folder contains the versions of metadata created by `dotnet docfx metadata` during xUnit.net's CI process.

* Download the `docfx` artifact from the appropriate GitHub Actions build, and unzip it into a new folder under `/metadata` that aligns with the version of the assemblies (i.e., the metadata for the `2.0.1` packages for xUnit.net v3 lives under `/metadata/v3/2.0.1`).

* Update [`/site/toc.yml`](https://github.com/xunit/api.xunit.net/tree/main/site/toc.yml) to add an entry for the new version.

* Create an `index.md` under the `site` tree at the appropriate location for the version. Look at the existing tree and inside one of the existing `index.md` files for an example.

Now you should be able to build the site and view the new API version.

# About xUnit.net

[<img align="right" src="https://xunit.net/images/dotnet-fdn-logo.png" width="100" />](https://www.dotnetfoundation.org/)

xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the [.NET Foundation](https://www.dotnetfoundation.org/), and operates under their [code of conduct](https://dotnetfoundation.org/about/policies/code-of-conduct). It is licensed under [Apache 2](https://opensource.org/licenses/Apache-2.0) (an OSI approved license).

For project documentation, please visit the [xUnit.net project home](https://xunit.net/).
