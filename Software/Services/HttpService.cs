using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Software.Services
{
    internal static class HttpService
    {

        private const string _baseUrl  = "http://localhost:5218/api/v1/";
        private static HttpClient Client { get => new() { BaseAddress = new Uri(_baseUrl) }; }

        public  static async Task<T> Get<T>(string url) {

            var response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(resultat)
                ?? throw new FormatException($"Erreur Http : {_baseUrl + url}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<TResponse> Post<TResponse, TRequestData>(string url, TRequestData data)
        {

            var requestContent = SerializeToJsonStringContent(data!);

            var response = await Client.PostAsync(url, requestContent);
            if(response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(resultat)
               ?? throw new FormatException($"Erreur Http : {_baseUrl + url}");
            }

            throw new Exception(response.ReasonPhrase);

        }

        public static async Task<TResponse> Put<TResponse, TRequestData>(string url, TRequestData data)
        {

            var requestContent = SerializeToJsonStringContent(data!);

            var response = await Client.PutAsync(url, requestContent);
            if (response.IsSuccessStatusCode)
            {
                return await HandleSuccessfulResponse<TResponse>(response, url);
            }

            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<TResponse> Delete<TResponse>(string url)
        {
            var response  = await Client.DeleteAsync(url);
            if( response.IsSuccessStatusCode)
            {
                return await HandleSuccessfulResponse<TResponse>(response, url);
            }

            throw new Exception(response.ReasonPhrase);

        }


        private static async Task<TResponse> HandleSuccessfulResponse<TResponse>(HttpResponseMessage response,string url)
        {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(resultat) ?? throw new FormatException($"Erreur Http: {_baseUrl + url}");
        }

        private static  StringContent SerializeToJsonStringContent(object data)
        {
            var dataJson = JsonConvert.SerializeObject(data);

            return new StringContent(dataJson, Encoding.UTF8, "application/json");

        }

    }
}
