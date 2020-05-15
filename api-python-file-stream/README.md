# Project Title

Simple Python 3.8.0 Client (requests-driven) script example for iQIES State API.

## Getting Started

In this example, we're reading our query from a file to make it easier to tweak, however, you can loop over files within a folder using the same method.

### Built with: 
* [pip](https://pypi.org/project/pip/) - pip is the package installer for Python
* [Requests](https://pypi.org/project/requests/2.7.0/) - Python Apache2 Licensed HTTP library
* [JSON](https://docs.python.org/3/library/json.html) -  Python 3.8.x JSON encoder and decoder

### Prerequisites

- [ ] To use this script you need to install the libraries above.

pip - [download here](https://bootstrap.pypa.io/get-pip.py) or use curl:

```
curl https://bootstrap.pypa.io/get-pip.py -o get-pip.py
```

Then run the following command in the folder where you have downloaded get-pip.py:

```
python get-pip.py
```

- [ ] Installing the requests library

With pip installed run this in your terminal:

```
$ pip install requests
```

- [x] JSON is [built into Python](https://docs.python.org/3/library/json.html) and is part of the standard library.

### Running this script

1. Replace [YOUR_API_KEY] with your assigned key

```
Line 22: iqiesAPIKey = '[YOUR_API_KEY]'
...
```

2. Read your "JSON-wrapped" i.e. iQIES formatted SQL query payload from a file

```
Line 27: with open('reg_where_regltn_set_id.json') as iqies_query:
...
```

3. Write your response as JSON to console and to file

```
Line 42: with open('query_result.json', 'w') as iqies_query_results:
...
```

