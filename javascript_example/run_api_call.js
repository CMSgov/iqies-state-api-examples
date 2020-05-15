const fs = require('fs');
const path = require("path")
const csv_converter = require('json-2-csv')
const fetch = require('node-fetch');

global.fetch = fetch
global.Headers = fetch.Headers;

const SERVICE_URI = process.env.SERVICE_URI;// <----- UPDATE THIS VALUE IN YOUR ENV VARIABLES
const API_KEY = process.env.STATE_API_KEY;// <----- UPDATE THIS VALUE IN YOUR ENV VARIABLES

const example_jsons = path.resolve(__dirname, "../examples/input_samples/json_format/example1.json"); // <----- UPDATE THIS VALUE for various example jsons

if (!SERVICE_URI || SERVICE_URI === "" || !API_KEY || API_KEY === "") {
  console.log("Environment variables SERVICE_URI and/or API_KEY are not set. Please set the local environment variables to proceed.");
} else {
  fs.readFile(example_jsons, (err, data) => { 
    if (err) throw err; 
  
    var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");
      myHeaders.append("apikey", API_KEY); 
      myHeaders.append("Accept", "application/json");  
   
    var raw = JSON.stringify(JSON.parse(data));
    var requestOptions = {
      method: 'POST',
      headers: myHeaders,
      body: raw
    };
    fetch(SERVICE_URI, requestOptions)
      .then(response => response.text())
      .then(result => {
        // raw console output
        if(JSON.parse(result).result) {
          var output_response = JSON.parse(result).result;
          console.log(output_response);
  
          var jsonpath = './output.json';
          var csvpath ='./output.csv';
          // write to json file
          fs.writeFile(jsonpath, JSON.stringify(output_response,null,2), (err) => {
            if (err) throw err;
            console.log("JSON File has been created");
          });          
          // write to csv file
          csv_converter.json2csv(output_response, (err, csv) => {
            if (err) throw err;
            fs.writeFile(csvpath, csv, (err) => {
              if (err) {
                console.error(err);
                return;
              }
              console.log("CSV File has been created");
            });
          });
        } else {
          console.log(result);
        }
      }).catch(error => console.log('error', error));
  });
}

