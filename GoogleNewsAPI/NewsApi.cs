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
        public static async Task<JArray > GetNews(string search)
        {
            //var url = new Uri($"http://news.google.com/news?output=rss");
            var url = new Uri($"http://news.google.com/news?q={search}&output=rss");
            using (var client = new HttpClient() { })
            {
                HttpRequestMessage request = new(HttpMethod.Get, url.OriginalString);
                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("Host", url.Host);

                // Return a XML object from google
                string res = await (await client.SendAsync(request)).Content.ReadAsStringAsync();
                XElement xResult = XElement.Parse(res);

                // Convert the XElement object to a JSON string
                // use in jsonConvert of newtonsoft for convert to json in perfectly
                var ret = JObject.Parse(JsonConvert.SerializeXNode(xResult));

                var a = ret?["rss"]?["channel"]?["item"];
                return (JArray)(ret?["rss"]?["channel"]?["item"] ?? JArray.Parse("[]"));
            }
        }
    }
}