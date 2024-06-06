using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DIadocHttp
{
    internal class HttpMethods
    {
        public string DiadocAuth(string diadocToken, string login, string password)
        {
            var postData = new PostData
            {
                diadocToken = diadocToken,
                login = login,
                password = password
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://diadoc-api.kontur.ru/V3/Authenticate");

            var json = JsonSerializer.Serialize(postData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync("posts", content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var postResponse = JsonSerializer.Deserialize<PostResponse>(responseContent);
                Console.WriteLine("Diadoc AuthToken: " + postResponse);
                return "";
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return "";
            }
        }
    }
}
