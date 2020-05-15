# iQIES State API REST Example in VB .Net

Simple VB .NET v4.7.2 Client (HttpClient) code example for iQIES State API.

## Getting Started

In this example, we're reading our query from a file to make it easier to tweak, however, you can loop over files within a folder using the same method.

### Built with: 
* [Visual Studio 2019](https://visualstudio.microsoft.com/) - Visual Studio is the primary IDE for building .NET Application (non-Core)
* [HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8) - Built into the .NET Framework, provides base class for HTTP requests and response resources
* [Newtonsoft.JSON](https://www.newtonsoft.com/json) -  High-performance JSON framework for .NET
* [ChoETL](https://github.com/Cinchoo/ChoETL) - ETL Framework for .NET (Parser / Writer for CSV, Flat, Xml, JSON, Key-Value formatted files) 

### Prerequisites

- [ ] To use this application you need to install the dependencies above.

Visual Studio (Community works fine) - [download here](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) and install.

- [ ] Installing the 3rd Party Dependencies (RestSharp, Newtonsoft.JSON, ChoETL)

There are multiple ways to install the dependencies, but [NuGet Restore](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore) is the simplest:

```
nuget restore StateApiExamples_csharp.sln
```

### Running this code

1. Set [YOUR_API_KEY] with your assigned key

PowerShell:
```
PS > [System.Environment]::SetEnvironmentVariable("STATE_API_KEY", "<YOURAPIKEY>", "User")
...
```

2. Compile & Run the program from Visual Studio

