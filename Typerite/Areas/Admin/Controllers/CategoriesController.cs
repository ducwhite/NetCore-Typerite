using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Typerite.Data;
using Typerite.Extensions;
using Typerite.Models;

namespace Typerite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    return View(await _context.Categories.ToListAsync());
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }     
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var categories = await _context.Categories
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (categories == null)
                    {
                        return NotFound();
                    }

                    return View(categories);
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category")] Categories categories)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(categories);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(categories);
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

           
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var categories = await _context.Categories.FindAsync(id);
                    if (categories == null)
                    {
                        return NotFound();
                    }
                    return View(categories);
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category")] Categories categories)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (id != categories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categories);
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var categories = await _context.Categories
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (categories == null)
                    {
                        return NotFound();
                    }

                    return View(categories);
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


            
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    var categories = await _context.Categories.FindAsync(id);
                    _context.Categories.Remove(categories);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

           
        }

        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
