Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports ChoETL

Module Module1

    Sub Main()
        ' Create new Task.
        ' ... Use AddressOf to reference a method.
        Dim t As Task = New Task(AddressOf PostDataAsync)
        ' Start the task.
        t.Start()
        ' Print a message as the page downloads.
        Console.WriteLine("Retrieving data...")
        Console.ReadLine()
    End Sub

    Async Sub PostDataAsync()
        ' Read the State API Endpoint URI from the User Environment Variable
        Dim baseApi As String = Environment.GetEnvironmentVariable("SERVICE_URI", EnvironmentVariableTarget.User)

        ' Use HttpClient in Using-statement.
        ' ... Use GetAsync to get the page data.
        Using client As HttpClient = New HttpClient()
            client.BaseAddress = New Uri(baseApi)
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))
            ' Read the STATE_API_KEY from the User Environment Variable
            client.DefaultRequestHeaders.Add("apikey", Environment.GetEnvironmentVariable("STATE_API_KEY", EnvironmentVariableTarget.User))  ' <--- SET THIS VALUE

            'Dim jsonString As String = "{'sql': {'select': 'prvdr_id, lgl_name, ccn','from': 'provider.prvdr'},'replacements': {} }"
            Dim jsonString As String = File.ReadAllText("..\..\..\..\examples\input_samples\json_format\example1.json").Trim()

            Dim content As New Net.Http.StringContent(jsonString, System.Text.Encoding.UTF8, "application/json")
            Using response As HttpResponseMessage = Await client.PostAsync("", content)

                ' Get contents of page as a String.
                Dim result As String = Await response.Content.ReadAsStringAsync()
                Dim json As String = JObject.Parse(result)("result").ToString

                ' If data exists, print a substring.
                If result IsNot Nothing And result.Length > 1 Then
                    ' Output results to the console
                    Console.WriteLine(result)

                    ' Output results to a raw json file
                    File.WriteAllText("output.json", json)

                    ' Output a csv file
                    Dim sbJson As StringBuilder = New StringBuilder(json)
                    Using r As New ChoJSONReader(sbJson)
                        Dim w As New ChoCSVWriter("output.csv")
                        Try
                            w.WithFirstLineHeader()
                            w.Write(r)
                        Finally
                            If w IsNot Nothing Then
                                w.Dispose()
                            End If
                        End Try
                    End Using
                End If
            End Using
        End Using
    End Sub

End Module
