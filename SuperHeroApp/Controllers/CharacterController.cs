using Microsoft.AspNetCore.Mvc;
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
            var identify = Id;
            return View();
        }
    }
}
