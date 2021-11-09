using SuperHeroApp.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperHeroApp.Services
{
    public interface ISuperHeroService
    {
        Task<SearchResult> SearchSuperHero(string filter, HttpMessageHandler httpMessageHandler = null);

        Task<SuperHero> GetSuperHero(int id);
    }
}
