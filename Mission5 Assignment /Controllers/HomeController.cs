using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie.Models;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieApplicationContext MovieContext { get; set; }
        //Constructor


        public HomeController(MovieApplicationContext SomeName)
        {
            
            MovieContext = SomeName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieApplication()
        {
            ViewBag.Categories = MovieContext.Category.ToList();
           
            return View();
        }
        [HttpPost]
        public IActionResult MovieApplication(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(ar);
                MovieContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = MovieContext.Category.ToList();
                return View();
            }
        }

        [HttpGet]
        public IActionResult List ()
        {
            var applications = MovieContext.NewResponses
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = MovieContext.Category.ToList();

            var application = MovieContext.NewResponses.Single(x => x.ApplicationId == applicationid);
             
            return View("MovieApplication", application);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse Movie)
        {
            MovieContext.Update(Movie);
            MovieContext.SaveChanges();

            return RedirectToAction("List");

        }
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = MovieContext.NewResponses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            MovieContext.NewResponses.Remove(ar);
            MovieContext.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
