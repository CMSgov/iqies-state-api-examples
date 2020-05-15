#!/usr/bin/python
# -*- coding: utf-8 -*-
# 


"""Simple Python 3.8.0 Client (requests-driven) script example for iQIES State API.

In this example, we're reading our query from a file to make it easier to tweak, however, you can loop over files within a folder using the same method.

Libraries: 
- Requests 
- JSON encoder/decoder

See README.md for Install instructions
"""

import requests
import json
import os
# UPDATE THESE VALUES
iqiesAPIKey = os.environ.get('YOUR_API_KEY') # Update [YOUR_API_KEY] env variable with your assigned key
env = os.environ.get('ENVIRONMENT-ENDPOINT')
url = env + os.environ.get('API_PATH')

# read your JSON-wrapped SQL query payload from a file
with open('reg_where_regltn_set_id.json') as iqies_query:
  payload = json.load(iqies_query)
  
headers = {
  'apikey': iqiesAPIKey,
  'Content-Type': 'application/json'
}

response = requests.request("POST", url, headers=headers, data = payload)

# function to write your response as JSON to console and to file
def jprint(obj):
    text = json.dumps(obj, sort_keys=True, indent=4)
    print(text)

    with open('query_result.json', 'w') as iqies_query_results:
      json.dump(obj, iqies_query_results, sort_keys=True, indent=4)

jprint(response.json())
