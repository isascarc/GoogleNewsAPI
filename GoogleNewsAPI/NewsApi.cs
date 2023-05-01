using System;
using System.Net.Http;
using System.Xml.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleNewsAPI
{
    public static class NewsApi
    {
        public static async Task<JArray> GetNews(string search, string country = "US", string lang = "en")
        {
            string url = $"http://news.google.com/rss?gl={country}&hl={lang}-{country}&ceid={country}:{lang}";
            if (!string.IsNullOrEmpty(search))
                url += $"&q={search}";

            var uri = new Uri(url);

            HttpRequestMessage request = new(HttpMethod.Get, uri.OriginalString);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Host", uri.Host);

            using (var client = new HttpClient() { })
            {
                // Return a XML object from google
                var response = await client.SendAsync(request);
                string res = await response.Content.ReadAsStringAsync();
                XElement xResult = XElement.Parse(res);

                // Convert the XElement object to a JSON string
                var ret = JObject.Parse(JsonConvert.SerializeXNode(xResult));

                var a = ret?["rss"]?["channel"]?["item"];
                return (JArray)(ret?["rss"]?["channel"]?["item"] ?? JArray.Parse("[]"));
            }
        }
    }
}