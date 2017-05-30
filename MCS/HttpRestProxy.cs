using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using MCS.Model;
using System.Reflection;
using Newtonsoft.Json;

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

        /// <summary>
        /// Get StringContent converted object for Post, Put(HttpContent)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static StringContent ConvertStringContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public async Task<T> GetAsync<T>(string requestUri) where T : class
        {
            Console.WriteLine("[GET] HttpRequest: " + client.BaseAddress + requestUri);
            var serializer = new DataContractJsonSerializer(typeof(T));
            
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            //var streamTask = client.GetStreamAsync(requestUri);
            //return serializer.ReadObject(await streamTask) as T;
            HttpResponseMessage response = await client.GetAsync(requestUri);
            Console.WriteLine ("[GET] HttpResponseMessage: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as T;
            }
            return null;
        }

        public async Task<T> PostAsync<T>(string requestUri, HttpContent content) where T : class
        {
            Console.WriteLine("[POST] HttpRequest: " + client.BaseAddress + requestUri);
            var serializer = new DataContractJsonSerializer(typeof(T));

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            HttpResponseMessage response = await client.PostAsync(requestUri, content);
            Console.WriteLine("[POST] HttpResponseMessage: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as T;
            }
            return null;
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            Console.WriteLine("[POST] HttpRequest: " + client.BaseAddress + requestUri);

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            HttpResponseMessage response = await client.PostAsync(requestUri, content);
            Console.WriteLine("[POST] HttpResponseMessage: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        public async Task<T> PutAsync<T>(string requestUri, HttpContent content) where T : class
        {
            Console.WriteLine("[PUT] HttpRequest: " + client.BaseAddress + requestUri);
            var serializer = new DataContractJsonSerializer(typeof(T));

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            HttpResponseMessage response = await client.PutAsync(requestUri, content);
            Console.WriteLine("[PUT] HttpResponseMessage: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as T;
            }
            return null;
        }

        public async Task<T> DeleteAsync<T>(string requestUri) where T : class
        {
            Console.WriteLine("[DELETE] HttpRequest: " + client.BaseAddress + requestUri);
            var serializer = new DataContractJsonSerializer(typeof(T));

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            HttpResponseMessage response = await client.DeleteAsync(requestUri);
            Console.WriteLine("[DELETE] HttpResponseMessage: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as T;
            }
            return null;
        }
    }
}
