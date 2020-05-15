package java_example;

import java.io.FileWriter;
import java.io.IOException;

import com.squareup.okhttp.MediaType;
import com.squareup.okhttp.OkHttpClient;
import com.squareup.okhttp.Request;
import com.squareup.okhttp.RequestBody;
import com.squareup.okhttp.Response;
import org.json.JSONObject;
import org.json.CDL;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.stream.Stream;

public class PostExample {
    public static void main(String[] args) throws Exception {

        String SERVICE_URI = System.getenv("SERVICE_URI");
        String API_KEY = System.getenv("STATE_API_KEY");
        
        if(isNullOrEmpty(SERVICE_URI) || isNullOrEmpty(API_KEY)) {
            System.out.println("Environment variables SERVICE_URI and/or API_KEY are not set. Please set the local environment variables to proceed.");
        } else {
            OkHttpClient client = new OkHttpClient();
            MediaType mediaType = MediaType.parse("application/json");
            try {
                RequestBody body = RequestBody.create(mediaType, readFromFile("./../examples/input_samples/json_format/example1.json")); // <----- UPDATE THIS VALUE for various example jsons
                Request request = new Request.Builder()
                    .url(SERVICE_URI)
                    .method("POST", body)
                    .addHeader("Content-Type", "application/json")
                    .addHeader("apikey", API_KEY)
                    .build();
                Response response = client.newCall(request).execute();

                JSONObject jsonObj = new JSONObject(response.body().string());
                if (jsonObj.has("result")) {
                    String strJSONResult = jsonObj.getJSONArray("result").toString(4);
                    // Writing to console
                    System.out.println(strJSONResult);
                    // Writing to JSON file
                    try (FileWriter jsonFile = new FileWriter("output.json")) {
                        jsonFile.write(strJSONResult);
                        System.out.println("Data has been Successfully Written to JSON file");
                    } catch (Exception e) {
                        System.out.println("An error occurred with writing the JSON file");
                    }
                    // Writing to CSV file
                    try(FileWriter csvFile = new FileWriter("output.csv")) {
                        String csv = CDL.toString(jsonObj.getJSONArray("result"));
                        csvFile.write(csv);
                        csvFile.flush(); 
                        System.out.println("Data has been Successfully Written to CSV file");
                    } catch (Exception e) {
                        System.out.println("An error occurred with writing the CSV file");
                    }
                }
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }            
        }
    }
    private static String readFromFile(String filePath) 
    {
        StringBuilder contentBuilder = new StringBuilder();
        try (Stream<String> stream = Files.lines( Paths.get(filePath), StandardCharsets.UTF_8)) 
        {
            stream.forEach(s -> contentBuilder.append(s).append(System.lineSeparator()));
        }
        catch (IOException e) 
        {
            System.out.println(e.getMessage());
        }
        return contentBuilder.toString();
    }
    private static boolean isNullOrEmpty(String str) {
        if(str != null && !str.isEmpty())
            return false;
        return true;
    }    
}