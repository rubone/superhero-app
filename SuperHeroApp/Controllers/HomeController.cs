﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperHeroApp.Entities;
using SuperHeroApp.Models;
using SuperHeroApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SuperHeroApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISuperHeroService _superHeroService;

        public HomeController(ILogger<HomeController> logger, ISuperHeroService superHeroService)
        {
            _logger = logger;
            _superHeroService = superHeroService;
        }

        public IActionResult Index()
        {
            SearchViewModel model = new()
            {
                SearchResult = new SearchResult()
            };
            model.SearchResult.Results = new List<SuperHero>();
            return View(model);
        }

        [HttpGet]
        public IActionResult Index(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                var result = _superHeroService.SearchSuperHero(filter);
                SearchViewModel model = new()
                {
                    Filter = filter,
                    SearchResult = result.Result
                };
                return View(model);
            }
            else
            {
                SearchViewModel model = new()
                {
                    SearchResult = new SearchResult()
                };
                model.SearchResult.Results = new List<SuperHero>();
                return View(model);
            }
        }            
            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";           
            if (code == 404)
            {
                return View("~/Views/Shared/404.cshtml");
            }
            else
            {
                return View("~/Views/Shared/HandleError.cshtml");
            }            
        }
    }
}
