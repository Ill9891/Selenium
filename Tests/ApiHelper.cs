using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests
{
    public class ApiHelper
    {
        public static async Task TestGetRequest()
        {
            var apiUrl = "https://jsonplaceholder.typicode.com/todos/1";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var todo = DeserializeJson<Todo>(content);

                        Console.WriteLine("API Response:");
                        Console.WriteLine(content);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        public static async Task TestPostRequest()
        {
            string apiUrl = "https://jsonplaceholder.typicode.com/posts";

            var postObject = new Todo
            {
                Completed = true,
                Id = 101,
                Title = "test",
                UserId = 101
            };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Convert the post object to JSON
                    string jsonPayload = JsonSerializer.Serialize(postObject);

                    // Create a StringContent with the JSON payload
                    StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("API Response:");
                        Console.WriteLine(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        static T DeserializeJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
