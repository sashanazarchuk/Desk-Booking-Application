using BookingServer.Application.Exceptions;
using BookingServer.Application.Interfaces.AI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingServer.Application.Services
{
    public class AIService : IAIService
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly string _apiKey;
        private readonly IPromptReaderService _promptReader;

        public AIService(HttpClient httpClient, IConfiguration configuration, IPromptReaderService promptReader)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["AI:ApiUrl"]!;
            _apiKey = configuration["AI:ApiKey"]!;
            _promptReader = promptReader;
        }


        public async Task<string> GetResponseAsync(string userMessage, CancellationToken cancellationToken)
        {
            var systemPrompt = await _promptReader.GetSystemPromptAsync(cancellationToken);
            var dynamicPrompt = await _promptReader.GenerateDynamicPromptAsync(cancellationToken);

            var today = DateTime.Now.ToString("dd-MM-yyyy");

            var combinedSystemPrompt = $"Today's local date is: {today}\n  {systemPrompt}\n  Here is the current data from the database, use it for your answers:\r\n:\n{dynamicPrompt}";

            Console.WriteLine(dynamicPrompt);

            // Forming the request body in JSON format as expected by OpenRouter
            var requestBody = new
            {
                model = "deepseek/deepseek-chat-v3-0324:free",
                messages = new[]
                {
                    new { role = "system", content = combinedSystemPrompt },
                    new { role = "user",   content = userMessage }
                }
            };

            // Forming HTTP POST request 
            var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl)
            {
                // Serialize the request body
                Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
            };

            // Add an authorization header with an API key
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");


            // Sending a request
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                // Можна зробити повідомлення коротшим, наприклад:
                throw new BusinessException($"AI API error: {response.StatusCode}");
            }


            // Check if the response is successful. If not, we will generate an exception.
            response.EnsureSuccessStatusCode();


            // Reading the response as a JSON string
            var json = await response.Content.ReadAsStringAsync();

            //Parsing
            using var doc = JsonDocument.Parse(json);

            //Get the model's response text (in the correct field)
            var chatResponse = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

            // Return the answer, trimming the spaces
            return chatResponse?.Trim() ?? "Empty answer.";


        }
    }
}
