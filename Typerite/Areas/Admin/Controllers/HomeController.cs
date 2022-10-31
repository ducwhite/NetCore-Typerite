using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Typerite.Data;
using Typerite.Extensions;
using Typerite.Models;

namespace Typerite.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalPost = _context.Posts.Count();
            ViewBag.TotalCategory = _context.Categories.Count();
            ViewBag.TotalAuthor = _context.Authors.Count();
            ViewBag.TotalContact = _context.Contacts.Count();

            //if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            //{
            //    var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
            //    if (login.Count() > 0)
            //    {
            //        return View(login);
            //    }

            //    else
            //    {
            //        return RedirectToAction("Index", "Login");
            //    }

            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}

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
