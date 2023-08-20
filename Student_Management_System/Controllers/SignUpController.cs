using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using Student_Management_System.View_Model;

namespace Student_Management_System.Controllers
{
    public class SignUpController : Controller
    {
        private readonly MyDbContext _context;

        public SignUpController(MyDbContext context)
        {
            _context = context;
        }

        // GET: SignUp
        public async Task<IActionResult> Index()
        {
              return _context.Signups != null ? 
                          View(await _context.Signups.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Signups'  is null.");
        }

        // GET: SignUp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Signups == null)
            {
                return NotFound();
            }

            var signUp = await _context.Signups
                .FirstOrDefaultAsync(m => m.ID == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // GET: SignUp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignUp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,username,password,email,phonenum,createdDate")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signUp);
        }

        // GET: SignUp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Signups == null)
            {
                return NotFound();
            }

            var signUp = await _context.Signups.FindAsync(id);
            if (signUp == null)
            {
                return NotFound();
            }
            return View(signUp);
        }

        // POST: SignUp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,username,password,email,phonenum,createdDate")] SignUp signUp)
        {
            if (id != signUp.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignUpExists(signUp.ID))
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
            return View(signUp);
        }

        // GET: SignUp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Signups == null)
            {
                return NotFound();
            }

            var signUp = await _context.Signups
                .FirstOrDefaultAsync(m => m.ID == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // POST: SignUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Signups == null)
            {
                return Problem("Entity set 'MyDbContext.Signups'  is null.");
            }
            var signUp = await _context.Signups.FindAsync(id);
            if (signUp != null)
            {
                _context.Signups.Remove(signUp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignUpExists(int id)
        {
          return (_context.Signups?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
