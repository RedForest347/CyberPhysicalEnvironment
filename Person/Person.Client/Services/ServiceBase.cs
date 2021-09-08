using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Person.Domain;
using Person;
using System.Text;

namespace Person.Client
{
    /// <summary>
    /// пример создания сервиса:
    ///     public class AgentService : ServiceBase<AgentDTO>
    ///     {
    ///         public AgentService(HttpClient client) : base(client, "api/agent")
    ///         {
    /// 
    ///         }
    ///     }
    ///     
    /// также, необходимо произвести инициализацию сервиса в Startup:
    ///     services.AddHttpClient<AgentService>("Agent client", client =>
    ///     {
    ///         client.BaseAddress = new Uri("https://localhost:5002");
    ///     });
    /// </summary>
    /// <typeparam name="T">для какого класса создается сервис</typeparam>



    //T - это лава (DTO)
    public class ServiceBase<T> where T : class
    {
        private HttpClient _httpClient;
        private string baseUri;

        public ServiceBase(HttpClient client, string baseUri)
        {
            _httpClient = client;
            this.baseUri = baseUri;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(baseUri);
            response.EnsureSuccessStatusCode();

            using Stream responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<T>>(responseContent);
        }


        public virtual async Task<T> GetOnIdAsync(Guid id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{baseUri}/{id}");
            response.EnsureSuccessStatusCode();

            using Stream responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseContent);
        }

        public virtual async Task<HttpResponseMessage> PutAsync(Guid id, T DTO)
        {
            string json = JsonSerializer.Serialize(DTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"{baseUri}/{id}", content);
        }

        public virtual async Task<HttpResponseMessage> PostAsync(T DTO)
        {
            string json = JsonSerializer.Serialize(DTO);
            Console.WriteLine(json);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(baseUri, content);

        }

        public virtual async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            return await _httpClient.DeleteAsync($"{baseUri}/{id}");
        }


    }
}
