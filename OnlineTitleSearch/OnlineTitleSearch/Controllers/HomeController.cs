using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineTitleSearch.Models;
using OnlineTitleSearch.Query;

namespace OnlineTitleSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchQuery _searchQuery;
        public HomeController(ISearchQuery searchQuery)
        {
            _searchQuery = searchQuery;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new SearchQueryModel());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Online Keyword search application.";

            return View();
        }


        [HttpPost]
        public IActionResult Index(SearchQueryModel query)
        {
            if (!ModelState.IsValid)
            {
                return View(query);
            }
           query.Result = _searchQuery.GetSearchPosition(query);


            return View(query);
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
