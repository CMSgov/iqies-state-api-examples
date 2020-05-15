# iQIES State API Examples

# Overview

The iQIES State API service bridges the gap between a state&#39;s data needs and the iQIES system. By supporting standards-based data formats and protocols, the iQIES State API connects state systems (clients) to iQIES (server) to support state-specific applications and reporting demands.

## API Basics

The iQIES State API service builds upon RESTful API standards thus you can choose to consume the iQIES API with any client once you&#39;ve generated an API key. You can choose to use a RESTful client such as Postman, Insomnia, Swagger or modify your ODBC driver for State API Service using an SDK such as OpenAccess SDK.

In addition, you may wish to modify or write new applications to consume the RESTful response. This repository provides a few basic examples on how to do just that.

The following programming language examples have been provided:
* C# (.NET v4.7x)
* VB .NET (.NET v4.7x)
* PowerShell
* Python (v3.x)
* Java
* Javascript (Node)
* Shell (curl)
* Shell (wget)

## Example Usage

Each example resides in it's own directory. Simply do a git clone on this repository, and navigate to the language you wish to utilize.
``` 
git clone https://github.com/CMSGov/iqies-state-api-examples 
```

Each language example will have additional instructions on who to run each, within their own directory.
Example:
```
python_eample/README.md 
```
...will contain instructions on how to run the Python example.

### NOTE
All examples provided here are just that, 'examples'. Please follow all best practices when implementing any of the examples within a Production environment. It is always advised to have your code reviewed by an expert.

## State API Use Cases

The core use case of the iQIES API is to support applications created and run by a state&#39;s Departments of Health that currently depends on data retrieved from a direct ODBC/Oracle TNS client connections to state-level ASPEN Oracle databases. Please utilize the iQIES State API User Guide for additional information on API usage.

# Public domain

This project is in the public domain within the United States, and copyright and related rights in the work worldwide are waived through the [CC0 1.0 Universal public domain dedication](LICENSE).

All contributions to this project will be released under the CC0 dedication. By submitting a pull request, you are agreeing to comply with this waiver of copyright interest.
