#!/bin/sh

# UPDATE THESE VALUES
APIKEY=$STATE_API_KEY # <-- These need to be set in your ENV VARIABLES first
URL=$SERVICE_URI  # <-- These need to be set in your ENV VARIABLES first

# Easy to read
#curl -X POST $URL \
#  -H "accept: application/json" \
#  -H "apikey: $APIKEY" \
#  -H "Content-Type: application/json" \
#  -data @../examples/input_samples/json_format/example1.json


## ONE LINER FOR COPY / PASTE
curl -X POST $SERVICE_URI -H "accept: application/json" -H "apikey: $STATE_API_KEY" -H "Content-Type: application/json" -d @../examples/input_samples/json_format/example1.json

