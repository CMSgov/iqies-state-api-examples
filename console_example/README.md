# iQIES State API REST Example cURL & wget

Simple command examples for iQIES State API.

## Getting Started

In this example, we're reading our query from a file to make it easier to tweak, however, you can loop over files within a folder using the same method.

### Run with: 
* [cURL](https://curl.haxx.se/) - curl is used in command lines or scripts to transfer data

OR
* [wget](https://www.gnu.org/software/wget/) - GNU Wget is a free software package for retrieving files using HTTP, HTTPS, FTP and FTPS the most widely-used Internet protocols.

### Prerequisites

- [ ] cURL is pre-installed on most Linux, Mac OS X and [up-to-date](https://techcommunity.microsoft.com/t5/containers/tar-and-curl-come-to-windows/ba-p/382409) Windows 10 systems

- [ ] wget is pre-installed on most Linux * Mac OS X systems

### Setting the environment variables ###

Refer: [How to set environment variables](../docs/set_env_variables.md)

### Running this code

#### cURL ####

```
curl -X POST $SERVICE_URI -H "accept: application/json" -H "apikey: $STATE_API_KEY" -H "Content-Type: application/json" -d @../examples/input_samples/json_format/example1.json


```

#### wget ####

```
wget --method POST \
  --timeout=0 \
  --header 'Accept: application/json' \
  --header 'apikey: $STATE_API_KEY' \
  --header 'Content-Type: application/json' \
  --body-data '{ "sql": { "select": "*", "from": "provider.prvdr" }, "replacements": {} }' \
   '$SERVICE_URI'
```


