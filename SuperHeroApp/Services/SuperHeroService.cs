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

        public Task<SearchResult> SearchSuperHero(string filter)
        {
            var client = new HttpClient();

            string searchEndpoint = _configuration.GetSection("SuperHeroAPI").GetSection("Endpoints").GetSection("Search").Value;

            client.BaseAddress = new Uri(_baseAddress);

            var response = client.GetAsync($"{searchEndpoint}/{filter}");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<SearchResult>();
                readTask.Wait();

                return Task.FromResult(readTask.Result);
            }
            else
            {
                return null;
            }
        }

        public Task<SuperHero> GetSuperHero(int id)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_baseAddress);

            var response = client.GetAsync(id.ToString());
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var superHero = result.Content.ReadAsAsync<SuperHero>();
                superHero.Wait();

                return Task.FromResult(superHero.Result);
            }
            else
            {
                return null;
            }
        }
    }
}
