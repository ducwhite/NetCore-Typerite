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
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Posts
        public async Task<IActionResult> Index()
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    var applicationDbContext = _context.Posts.Include(p => p.Authors).Include(p => p.Categories);
                    return View(await applicationDbContext.ToListAsync());
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

        // GET: Admin/Posts/Details/5
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

                    var posts = await _context.Posts
                        .Include(p => p.Authors)
                        .Include(p => p.Categories)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (posts == null)
                    {
                        return NotFound();
                    }

                    return View(posts);
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

        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FullName");
                    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category");
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

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Ingredient,Image,Description,Created,Background,AuthorId,CategoryId")] Posts posts)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(posts);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FullName", posts.AuthorId);
                    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category", posts.CategoryId);
                    return View(posts);
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

        // GET: Admin/Posts/Edit/5
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

                    var posts = await _context.Posts.FindAsync(id);
                    if (posts == null)
                    {
                        return NotFound();
                    }
                    ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FullName", posts.AuthorId);
                    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category", posts.CategoryId);
                    return View(posts);
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

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Ingredient,Image,Description,Created,Background,AuthorId,CategoryId")] Posts posts)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    if (id != posts.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(posts);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!PostsExists(posts.Id))
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
                    ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FullName", posts.AuthorId);
                    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category", posts.CategoryId);
                    return View(posts);
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

        // GET: Admin/Posts/Delete/5
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

                    var posts = await _context.Posts
                        .Include(p => p.Authors)
                        .Include(p => p.Categories)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (posts == null)
                    {
                        return NotFound();
                    }

                    return View(posts);
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

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    var posts = await _context.Posts.FindAsync(id);
                    _context.Posts.Remove(posts);
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

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
