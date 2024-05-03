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
    public class SalesReportsController : Controller
    {
        private readonly DBContext _context;

        public SalesReportsController(DBContext context)
        {
            _context = context;
        }

        // GET: SalesReports
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.SalesReport.Include(s => s.Product);
            return View(await dBContext.ToListAsync());
        }

        // GET: SalesReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReport
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SalesReportId == id);
            if (salesReport == null)
            {
                return NotFound();
            }

            return View(salesReport);
        }

        // GET: SalesReports/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName");
            return View();
        }

        // POST: SalesReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesReportId,InitialDate,EndDate,ProductId,SalesTotal,SalesRevenue")] SalesReport salesReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", salesReport.ProductId);
            return View(salesReport);
        }

        // GET: SalesReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReport.FindAsync(id);
            if (salesReport == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", salesReport.ProductId);
            return View(salesReport);
        }

        // POST: SalesReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesReportId,InitialDate,EndDate,ProductId,SalesTotal,SalesRevenue")] SalesReport salesReport)
        {
            if (id != salesReport.SalesReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesReportExists(salesReport.SalesReportId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", salesReport.ProductId);
            return View(salesReport);
        }

        // GET: SalesReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReport
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SalesReportId == id);
            if (salesReport == null)
            {
                return NotFound();
            }

            return View(salesReport);
        }

        // POST: SalesReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesReport = await _context.SalesReport.FindAsync(id);
            if (salesReport != null)
            {
                _context.SalesReport.Remove(salesReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesReportExists(int id)
        {
            return _context.SalesReport.Any(e => e.SalesReportId == id);
        }
    }
}
