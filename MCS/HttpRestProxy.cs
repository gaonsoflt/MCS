using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using MCS.Model;

namespace MCS
{
    class HttpRestProxy
    {
        private HttpClient client;
        private string URI = "http://localhost:8080";

        public HttpRestProxy()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(URI);
        }

        public HttpRestProxy(string uri)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
        }

        public async Task<T> GetAsync<T>(string requestUri) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync(requestUri);
            
            return serializer.ReadObject(await streamTask) as T;
        }
    }
}
