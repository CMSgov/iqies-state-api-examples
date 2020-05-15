# Project Title

Simple PowerShell script example for iQIES State API.

## Getting Started

In this example, we're reading our query from a file to make it easier to tweak, however, you can loop over files within a folder using the same method.

### Built with: 
* [Invoke-RestMethod] - PowerShell module that performs REST Requests

### Prerequisites

- [x] No additional prerequisites

### Running this script

1. Set the [STATE_API_KEY] and [SERVICE_URI] Environment variable
You need to set the STATE_API_KEY key within your local environment variables

*NOTE: It is best practice NOT to save sensitive information within code files (ex: API Keys). In this script we read these values from a local environment variable.*
```
Line 9: $headers.Add("apikey", [System.Environment]::GetEnvironmentVariable("STATE_API_KEY", "User")) 
...
```
Windows (PowerShell): 
```
PS > [System.Environment]::SetEnvironmentVariable("STATE_API_KEY", "YOURAPIKEY", "User"))
```
Windows (CMD / setx.exe): 
```
c:\ > setx STATE_API_KEY "YOURAPIKEY"
```
Mac OS X (terminal):
```
export STATE_API_KEY=YOURAPIKEY
```
Linux (shell):
```
export STATE_API_KEY=YOURAPIKEY
```

2. Read your "JSON-wrapped" i.e. iQIES formatted SQL query payload from a file

*NOTE: $PSScriptRoot only works when this is run as a script, if you're running this via ISE, you will need to update the file path manually.*

```
Line 12: $body = Get-Content -Path "$PSScriptRoot\..\examples\input_samples\json_format\example1.json" -Raw
...
```

3. Write your response as JSON to console and to file

*NOTE: Update the output file/directory if you wish to save these somewhere other than the root of this file.*

```
Line 20: $response.result | ConvertTo-Json | Out-File -FilePath "$PSScriptRoot\..\output.json"
...
```

