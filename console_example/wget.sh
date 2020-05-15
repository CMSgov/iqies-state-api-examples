wget --no-check-certificate --quiet \
  --method POST \
  --timeout=0 \
  --header 'Accept: application/json' \
  --header 'apikey: $STATE_API_KEY' \
  --header 'Content-Type: application/json' \
  --body-file @../examples/input_samples/json_format/example1.json