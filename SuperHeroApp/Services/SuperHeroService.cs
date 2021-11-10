using Microsoft.Extensions.Configuration;
using SuperHeroApp.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperHeroApp.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        protected readonly IConfiguration _configuration;

        private readonly string _baseUrl;

        private readonly string _token;

        private readonly string _baseAddress;

        public SuperHeroService(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("SuperHeroAPI").GetSection("BaseURL").Value;
            _token = _configuration.GetSection("SuperHeroAPI").GetSection("Token").Value;
            _baseAddress = $"{_baseUrl}/{_token}/";
        }

        public async Task<SearchResult> SearchSuperHero(string filter, HttpMessageHandler httpMessageHandler = null)
        {
            HttpClient client;

            if (httpMessageHandler == null)
            {
                client = new HttpClient();
            }
            else
            {
                client = new HttpClient(httpMessageHandler);
            }            

            string searchEndpoint = _configuration.GetSection("SuperHeroAPI").GetSection("Endpoints").GetSection("Search").Value;

            client.BaseAddress = new Uri(_baseAddress);

            var result = await client.GetAsync($"{searchEndpoint}/{filter}");            

            if (result.IsSuccessStatusCode)
            {                
                return await result.Content.ReadAsAsync<SearchResult>();
            }
            else
            {
                return null;
            }
        }

        public async Task<SuperHero> GetSuperHero(int id, HttpMessageHandler httpMessageHandler = null)
        {
            HttpClient client;

            if (httpMessageHandler == null)
            {
                client = new HttpClient();
            }
            else
            {
                client = new HttpClient(httpMessageHandler);
            }

            client.BaseAddress = new Uri(_baseAddress);

            var result = await client.GetAsync(id.ToString());
            
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<SuperHero>();                
            }
            else
            {
                return null;
            }
        }
    }
}
