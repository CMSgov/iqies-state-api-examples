using System;
using System.IO;
using RestSharp;
using ChoETL;
using Newtonsoft.Json.Linq;
using RestSharp.Serializers.NewtonsoftJson;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {

                // Create a new RestClient, pull in the URI value from an environment variable
                var client = new RestClient(Environment.GetEnvironmentVariable("SERVICE_URI", EnvironmentVariableTarget.User))
                {
                    Timeout = -1
                };
                client.UseNewtonsoftJson();
                // Create a new RestRequest, and specify it as a POST 
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");

                request.AddHeader("apikey",Environment.GetEnvironmentVariable("STATE_API_KEY", EnvironmentVariableTarget.User));  // Set the API key in the header value

                request.AddHeader("Content-Type", "application/json");  // Set the Content-Type appropriately 

                String payload = File.ReadAllText(@"../../../../examples/input_samples/json_format/example1.json"); // Read the json query from the example1.json file - update this path if needed.
                
                request.AddParameter("application/json", payload, ParameterType.RequestBody);
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                IRestResponse response = client.Execute(request);

                // Check that our response was valid.
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // By default, the returned object contains the json in the 'result' value, we need to extract it.
                    var jsonOutput = JObject.Parse(response.Content)["result"].ToString();


                    // Once you have the data, you can output it in many formats, as listed below:

                    // Write the output directly to the console (mostly for debugging)
                    Console.WriteLine(jsonOutput);
                    Console.ReadLine(); //Pause the output terminal (hack)

                    // Write the raw json out to a file "output.json"
                    File.WriteAllText(@"output.json", jsonOutput);

                    // Write the output to a csv file "output.csv" - an easy way is to use a 3rd party libary ChoETL
                    // https://github.com/Cinchoo/ChoETL
                    // There are ways to do it with much fewer dependencies, like converting Datatable to CSV, but
                    // JSON.NET is still the best library for reading/serializing json in .NET (which ChoETL uses).

                    System.Text.StringBuilder json = new System.Text.StringBuilder(jsonOutput);
                    using (var r = new ChoJSONReader(json))
                    {
                        using (var w = new ChoCSVWriter(@"output.csv").WithFirstLineHeader())
                        {
                            w.Write(r);
                        }
                    }
                }
                else 
                { 
                    Console.WriteLine(String.Format("{0} : {1}", response.StatusCode, response.StatusDescription));
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Something went wrong: {0}",  ex.Message));
                Console.ReadLine();
            }
        }
    }
}
