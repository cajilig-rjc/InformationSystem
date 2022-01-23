#nullable disable
using InformationSystem.Data;
using InformationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.Controllers
{
    [Authorize]
    public class CasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cases.ToListAsync());
        }

        // GET: Cases/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Case = await _context.Cases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Case == null)
            {
                return NotFound();
            }

            return View(Case);
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,DateOfBirth,ContactNumber,Status,CityOrProvince,Municipality,Barangay,PurokOrSitio,Address")] Cases Case)
        {
            if (ModelState.IsValid)
            {
                Case.Id = Guid.NewGuid();
                _context.Add(Case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Case);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Case = await _context.Cases.FindAsync(id);
            if (Case == null)
            {
                return NotFound();
            }
            return View(Case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FullName,DateOfBirth,ContactNumber,Status,CityOrProvince,Municipality,Barangay,PurokOrSitio,Address")] Cases Case)
        {
            if (id != Case.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(Case.Id))
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
            return View(Case);
        }

        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Case = await _context.Cases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Case == null)
            {
                return NotFound();
            }

            return View(Case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Case = await _context.Cases.FindAsync(id);
            _context.Cases.Remove(Case);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseExists(Guid id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
