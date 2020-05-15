import requests
import json
import csv 
import os
from pathlib import Path

# Load our values in from the env variables - update these as needed.
SERVICE_URI = os.environ.get('SERVICE_URI')
API_KEY = os.environ.get('STATE_API_KEY')

if(SERVICE_URI is None or len(SERVICE_URI) == 0 or API_KEY is None or len(API_KEY) == 0):
  print('Environment variables SERVICE_URI and/or API_KEY are not set. Please set the local environment variables to proceed.')
else:
  p = Path()
  example_jsons = p.resolve().parent / 'examples/input_samples/json_format/example1.json' # <--- changes this to load different query examples

  # read your JSON-wrapped SQL query payload from a file
  with open(example_jsons, 'r') as iqies_query:
    payload = str(json.loads(iqies_query.read())).replace("'", '\"')

  headers = {
    'apikey': API_KEY, 
    'Content-Type': 'application/json'
  }

  response = requests.request("POST", SERVICE_URI, headers=headers, data = payload)

  query_output = response.json().get('result', {})  

  if(query_output):
    ### WRITE TO CONSOLE ###
    print(json.dumps(query_output,indent=4))

    ### WRITE TO JSON FILE ###
    with open('output.json', 'w') as iqies_query_results:
        json.dump(query_output, iqies_query_results, sort_keys=True, indent=4)
        print('JSON File has been created')

    ### WRITE TO CSV FILE ###

    # open a file for writing 
    with open('output.csv', 'w') as data_file:
        # create the csv writer object 
        csv_writer = csv.writer(data_file)
        csv_writer.writerow(query_output[0].keys()) # Write the keys to the headers row
        for a in query_output: 
            csv_writer.writerow(a.values()) # Writing data of CSV file 
        print('CSV File has been created')