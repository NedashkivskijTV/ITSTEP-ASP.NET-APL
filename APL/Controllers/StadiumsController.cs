using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APL;
using APL.Models;

namespace APL.Controllers
{
    public class StadiumsController : Controller
    {
        private readonly AplDbContext _context;

        public StadiumsController(AplDbContext context)
        {
            _context = context;
        }

        // GET: Stadiums
        public async Task<IActionResult> Index()
        {
            var aplDbContext = _context.Stadiums
                .Include(s => s.Town)
                .OrderBy(ss => ss.Town.TownName)
                .ThenBy(sss => sss.StadiumName);
            return View(await aplDbContext.ToListAsync());
        }

        // GET: Stadiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums
                .Include(s => s.Town)
                .FirstOrDefaultAsync(m => m.StadiumId == id);
            if (stadium == null)
            {
                return NotFound();
            }

            return View(stadium);
        }

        // GET: Stadiums/Create
        public IActionResult Create()
        {
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName");
            return View();
        }

        // POST: Stadiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StadiumId,StadiumName,StadiumDescription,TownId")] Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stadium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName", stadium.TownId);
            return View(stadium);
        }

        // GET: Stadiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName", stadium.TownId);
            return View(stadium);
        }

        // POST: Stadiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StadiumId,StadiumName,StadiumDescription,TownId")] Stadium stadium)
        {
            if (id != stadium.StadiumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stadium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StadiumExists(stadium.StadiumId))
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
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName", stadium.TownId);
            return View(stadium);
        }

        // GET: Stadiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums
                .Include(s => s.Town)
                .FirstOrDefaultAsync(m => m.StadiumId == id);
            if (stadium == null)
            {
                return NotFound();
            }

            return View(stadium);
        }

        // POST: Stadiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StadiumExists(int id)
        {
            return _context.Stadiums.Any(e => e.StadiumId == id);
        }
    }
}
