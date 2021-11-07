using Microsoft.AspNetCore.Mvc;
using SuperHeroApp.Services;

namespace SuperHeroApp.Controllers
{
    [Route("[controller]")]
    public class CharacterController : Controller
    {

        private readonly ISuperHeroeService _superHeroeService;

        public CharacterController(ISuperHeroeService superHeroeService)
        {
            _superHeroeService = superHeroeService;
        }

        [Route("{id}")]
        public IActionResult Index(int Id)
        {
            var identify = Id;
            return View();
        }
    }
}
