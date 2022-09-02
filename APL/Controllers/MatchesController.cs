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
    public class MatchesController : Controller
    {
        private readonly AplDbContext _context;

        public MatchesController(AplDbContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            ViewBag.clubs = new List<Club>(_context.clubs.ToList()); // отримання списку клубів
            var aplDbContext = _context.Matches.Include(m => m.Stadium).Include(m => m.Town);
            return View(await aplDbContext
                .OrderByDescending(m => m.MatchDate)
                .ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Stadium)
                .Include(m => m.Town)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            ViewBag.homeClub = _context.clubs.Find(_context.Matches.Find(id).HomeClubId).ClubName;  // створено для відображення HOME клуба
            ViewBag.homeClubCrest = _context.clubs.Find(_context.Matches.Find(id).HomeClubId).ClubCrest;  // створено для відображення емблеми HOME клуба
            ViewBag.awayClub = _context.clubs.Find(_context.Matches.Find(id).AwayClubId).ClubName;  // створено для відображення Away клуба
            ViewBag.awayClubCrest = _context.clubs.Find(_context.Matches.Find(id).AwayClubId).ClubCrest;  // створено для відображення емблеми Away клуба
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewBag.clubs = new SelectList(_context.clubs.ToList(), "Id", "ClubName"); // додано для отримання списку клубів (dropdown - вибір команд, що грають вдома або на виїзді)
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "StadiumId", "StadiumName");
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchId,MatchDate,HomeClubId,AwayClubId,TownId,StadiumId,MatchResult,MatchDescription,MatchIsOver")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.clubs = new SelectList(_context.clubs.ToList(), "Id", "ClubName");
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "StadiumId", "StadiumName", match.StadiumId);
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName", match.TownId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "StadiumId", "StadiumName", match.StadiumId);
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName", match.TownId);
            ViewBag.clubs = new SelectList(_context.clubs.ToList(), "Id", "ClubName"); // додано для отримання списку клубів (dropdown - вибір команд, що грають вдома або на виїзді)
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchId,MatchDate,HomeClubId,AwayClubId,TownId,StadiumId,MatchResult,MatchDescription,MatchIsOver")] Match match)
        {
            if (id != match.MatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.MatchId))
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
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "StadiumId", "StadiumName", match.StadiumId);
            ViewData["TownId"] = new SelectList(_context.Towns, "TownId", "TownName", match.TownId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Stadium)
                .Include(m => m.Town)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            ViewBag.homeClub = _context.clubs.Find(_context.Matches.Find(id).HomeClubId).ClubName;  // створено для відображення HOME клуба
            ViewBag.homeClubCrest = _context.clubs.Find(_context.Matches.Find(id).HomeClubId).ClubCrest;  // створено для відображення емблеми HOME клуба
            ViewBag.awayClub = _context.clubs.Find(_context.Matches.Find(id).AwayClubId).ClubName;  // створено для відображення Away клуба
            ViewBag.awayClubCrest = _context.clubs.Find(_context.Matches.Find(id).AwayClubId).ClubCrest;  // створено для відображення емблеми Away клуба
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.MatchId == id);
        }


        [HttpGet]
        public JsonResult GetArenaFromTown(string id)
        {
            // дебаг !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (!String.IsNullOrEmpty(id))
            {
                var arenas = _context.Stadiums.Where(s => s.Town.TownId == Int32.Parse(id)).ToList();
                //var arenas = new SelectList(_db.Stadiums.Where(s => s.Town.TownId == Int32.Parse(town)).ToList(), "StadiumId", "StadiumName");
                return Json(arenas);
            }
            return Json("Error");
        }


        [HttpGet]
        public IActionResult ClubStatistics(int requestStatus) // requestStatus - 0-весь списток, 1-поточний рік, 2-поточний місяць
        {
            ViewBag.test = requestStatus;
            return View(); // 
        }


    }
}
