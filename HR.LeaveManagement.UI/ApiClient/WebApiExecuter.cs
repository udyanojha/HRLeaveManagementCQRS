using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HR.LeaveManagement.UI.ApiClient
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private readonly string _baseUrl;
        public HttpClient _httpClient;
        protected readonly ILocalStorageService _localStorage;

        public WebApiExecuter() // string baseUrl, HttpClient httpClient
        {
            //_baseUrl = baseUrl;
            //_httpClient = httpClient;

            _baseUrl = "https://localhost:7276";
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            return await _httpClient.GetFromJsonAsync<T>(GetUrl(uri));
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
            var response = await _httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task InvokePut<T>(string uri, T obj)
        {
            var response = await _httpClient.PutAsJsonAsync(GetUrl(uri), obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task InvokeDelete(string uri)
        {
            var response = await _httpClient.DeleteAsync(GetUrl(uri));
            response.EnsureSuccessStatusCode();
        }

        private string GetUrl(string uri)
        {
            return $"{_baseUrl}/{uri}";
        }

        // Not using RN
        public async Task AddBearerToken(ILocalStorageService _localStorage)
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }

       
    }
}
