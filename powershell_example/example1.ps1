# Set the API endpoint
$uri = [System.Environment]::GetEnvironmentVariable("SERVICE_URI", "User")

# Setup any headers needed, including the APIKEY
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Accept", "application/json")
$headers.Add("Content-Type", "application/json")
## UPDATE THIS VALUE -- vvvvvvvvvv --
$headers.Add("apikey", [System.Environment]::GetEnvironmentVariable("STATE_API_KEY", "User")) ## <-- UPDATE THIS VALUE

#Read in the request payload from a json file. Make sure to use 'Raw'
$body = Get-Content -Path "$PSScriptRoot\..\examples\input_samples\json_format\example1.json" -Raw
#$body = '{ "sql": {"select": "*","from`": "provider.prvdr"},"replacements": {} }'

$response = Invoke-RestMethod $uri -Method 'POST' -Headers $headers -Body $body
# Write the output to the console
$response.result | Format-Table 

# Write the output to a json file
$response.result | ConvertTo-Json | Out-File -FilePath "$PSScriptRoot\..\output.json"

# Write the output to a CSV file
$response.result | ConvertTo-Csv -NoTypeInformation | Out-File -FilePath "$PSScriptRoot\..\output.csv"
