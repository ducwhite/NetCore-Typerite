using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Typerite.Data;
using Typerite.Extensions;
using Typerite.Models;

namespace Typerite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            ViewBag.error = "";
            var at = _context.Authors.ToList();
            var data = _context.Authors.Where(p => p.UserName == username && p.Password == password).ToList();
            if (data.Count() > 0)
            {
                List<Login> author = new List<Login>();
                author.Add(new Login { authorss = at.Find(p => p.UserName == username) });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Login", author);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewBag.error = "Đăng nhập thất bại";
                return View("Index");

            }
        }
    }
}
