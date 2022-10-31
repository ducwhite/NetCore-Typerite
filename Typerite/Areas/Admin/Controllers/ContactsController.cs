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
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Contacts
        public async Task<IActionResult> Index()
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    return View(await _context.Contacts.ToListAsync());
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

        // GET: Admin/Contacts/Details/5
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

                    var contacts = await _context.Contacts
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (contacts == null)
                    {
                        return NotFound();
                    }

                    return View(contacts);
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


        // GET: Admin/Contacts/Delete/5
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

                    var contacts = await _context.Contacts
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (contacts == null)
                    {
                        return NotFound();
                    }

                    return View(contacts);
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

        // POST: Admin/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login") != null)
            {
                var login = SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login");
                if (login.Count() > 0)
                {
                    var contacts = await _context.Contacts.FindAsync(id);
                    _context.Contacts.Remove(contacts);
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

        private bool ContactsExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
