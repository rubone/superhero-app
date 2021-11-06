using SuperHeroApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroApp.Services
{
    public interface ISuperHeroeService
    {
        Task<SearchResult> SearchSuperHero(string filter);
    }
}
