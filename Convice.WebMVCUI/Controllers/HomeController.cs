using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Convice.Business.Abstract;
using Convice.Business.Concrete;
using Convice.Entities;
using Microsoft.AspNetCore.Mvc;
using Convice.WebMVCUI.Models;
using DataAccess.Concrete.EF;

namespace Convice.WebMVCUI.Controllers
{
    public class HomeController : Controller
    {
        private IContentService _contentManager;

        public HomeController(IContentService contentManager)
        {
            _contentManager = contentManager;
        }


        public ActionResult Index()
        {
            
            _contentManager.Add(new Content()
            {
                ContentType = "video",
                CategoryId = 1,
                Link = "youtube.com",
                Platform = "youtube",
                isEnabled = true
            });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
