using Microsoft.AspNetCore.Mvc;
using SuperHeroApp.Models;
using SuperHeroApp.Services;

namespace SuperHeroApp.Controllers
{
    [Route("[controller]")]
    public class CharacterController : Controller
    {

        private readonly ISuperHeroService _superHeroService;

        public CharacterController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [Route("{id}")]
        public IActionResult Index(int Id)
        {            
            var result = _superHeroService.GetSuperHero(Id);
            CharacterViewModel model = new CharacterViewModel();
            model.SuperHero = result.Result;

            return View(model);
        }
    }
}
