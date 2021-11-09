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
            CharacterViewModel model = new()
            {
                SuperHero = result.Result
            };

            if (!result.Result.Response.Equals("error"))
            {
                return View(model);
            }
            else
            {                
                HttpContext.Response.StatusCode = 404;
                return Redirect("~/Views/Shared/404.cshtml");
            }            
        }
    }
}
