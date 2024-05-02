using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperVendas.Data;
using SuperVendas.Models;

namespace SuperVendas.Controllers
{
    public class AccessLevelsController : Controller
    {
        private readonly DBContext _context;

        public AccessLevelsController(DBContext context)
        {
            _context = context;
        }

        // GET: AccessLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccessLevel.ToListAsync());
        }

        // GET: AccessLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessLevel = await _context.AccessLevel
                .FirstOrDefaultAsync(m => m.AccessLevelId == id);
            if (accessLevel == null)
            {
                return NotFound();
            }

            return View(accessLevel);
        }

        // GET: AccessLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccessLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccessLevelId,AccessLevelName,AccessLevelType")] AccessLevel accessLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accessLevel);
        }

        // GET: AccessLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessLevel = await _context.AccessLevel.FindAsync(id);
            if (accessLevel == null)
            {
                return NotFound();
            }
            return View(accessLevel);
        }

        // POST: AccessLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccessLevelId,AccessLevelName,AccessLevelType")] AccessLevel accessLevel)
        {
            if (id != accessLevel.AccessLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessLevelExists(accessLevel.AccessLevelId))
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
            return View(accessLevel);
        }

        // GET: AccessLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessLevel = await _context.AccessLevel
                .FirstOrDefaultAsync(m => m.AccessLevelId == id);
            if (accessLevel == null)
            {
                return NotFound();
            }

            return View(accessLevel);
        }

        // POST: AccessLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessLevel = await _context.AccessLevel.FindAsync(id);
            if (accessLevel != null)
            {
                _context.AccessLevel.Remove(accessLevel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessLevelExists(int id)
        {
            return _context.AccessLevel.Any(e => e.AccessLevelId == id);
        }
    }
}
