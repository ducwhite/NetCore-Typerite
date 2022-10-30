using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Typerite.Data;
using Typerite.Models;

namespace Typerite.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(int id, string searchPharse, int pageNumber=1)
        {
            //var applicationDbContext = _context.Posts.Include(p => p.Authors).Include(p => p.Categories);
            //return View(await applicationDbContext.ToListAsync());
            var id2 = id > 0 ? id : -1;
            var cat = _context.Categories.ToList();
            ViewBag.ListByCat = cat;
            //var applicationDbContext = _context.Posts.Include(p => p.Authors).Include(p => p.Categories); 
            var applicationDbContext = _context.Posts.Include(p => p.Authors).Include(p => p.Categories);

            if (id2 != -1)
            {
                return View(await PaginatedList<Posts>.CreateAsync(applicationDbContext.Where(p => p.CategoryId == id2), pageNumber, 3));

            }

            if (searchPharse == null)
            {
                return View(await PaginatedList<Posts>.CreateAsync(applicationDbContext, pageNumber, 3));
            }
            else
            {
                return View(await PaginatedList<Posts>.CreateAsync(applicationDbContext.Where(p => p.Title.Contains(searchPharse)), pageNumber, 3));
   
            }
            
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
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

            List<Posts> List3 = new List<Posts>();
            foreach (var item in _context.Posts.OrderByDescending(u => u.Id).Take(3))
            {
                List3.Add(item);
            }

            ViewBag.Last3 = List3;
            ViewBag.Category = _context.Categories.ToList();

            return View(posts);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FullName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Created,Background,AuthorId,CategoryId")] Posts posts)
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

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Created,Background,AuthorId,CategoryId")] Posts posts)
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

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Search(string searchPharse)
        //{
        //    var applicationDbContext = _context.Posts.Include(p => p.Authors).Include(p => p.Categories);
        //    return View("Index", await applicationDbContext.Where(p => p.Title.Contains(searchPharse)).ToListAsync());
        //}

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
