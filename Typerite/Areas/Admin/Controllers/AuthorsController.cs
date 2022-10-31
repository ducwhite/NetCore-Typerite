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
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Authors
        public async Task<IActionResult> Index()
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    return View(await _context.Authors.ToListAsync());
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

        // GET: Admin/Authors/Details/5
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

                    var authors = await _context.Authors
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (authors == null)
                    {
                        return NotFound();
                    }

                    return View(authors);
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

        // GET: Admin/Authors/Create
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

        // POST: Admin/Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,UserName,Password")] Authors authors)
        {

            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(authors);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(authors);
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

        // GET: Admin/Authors/Edit/5
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

                    var authors = await _context.Authors.FindAsync(id);
                    if (authors == null)
                    {
                        return NotFound();
                    }
                    return View(authors);
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

        // POST: Admin/Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,UserName,Password")] Authors authors)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (id != authors.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(authors);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!AuthorsExists(authors.Id))
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
                    return View(authors);
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

        // GET: Admin/Authors/Delete/5
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

                    var authors = await _context.Authors
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (authors == null)
                    {
                        return NotFound();
                    }

                    return View(authors);
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

        // POST: Admin/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    var authors = await _context.Authors.FindAsync(id);
                    _context.Authors.Remove(authors);
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

        private bool AuthorsExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
