using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameHistoryWebApp.Models;
using GameHistoryWebApp.Data;

namespace GameHistoryWebApp.Controllers
{
    public class GameHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameHistoryModels
        public async Task<IActionResult> Index()
        {
            return _context.GameHistoryModel != null ?
                        View(await _context.GameHistoryModel.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.GameHistoryModel'  is null.");
        }

        // GET: GameHistoryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameHistoryModel == null)
            {
                return NotFound();
            }

            var gameHistoryModel = await _context.GameHistoryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameHistoryModel == null)
            {
                return NotFound();
            }

            return View(gameHistoryModel);
        }

        // GET: GameHistoryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameHistoryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameName,YearRelease,AgeRating,GameGenre")] GameHistoryModel gameHistoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameHistoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameHistoryModel);
        }
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View(View("Index", await _context.GameHistoryModel.ToListAsync()));
        }

        // GET: GameHistoryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameHistoryModel == null)
            {
                return NotFound();
            }

            var gameHistoryModel = await _context.GameHistoryModel.FindAsync(id);
            if (gameHistoryModel == null)
            {
                return NotFound();
            }
            return View(gameHistoryModel);
        }

        // POST: GameHistoryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameName,YearRelease,AgeRating,GameGenre")] GameHistoryModel gameHistoryModel)
        {
            if (id != gameHistoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameHistoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameHistoryModelExists(gameHistoryModel.Id))
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
            return View(gameHistoryModel);
        }

        // GET: GameHistoryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameHistoryModel == null)
            {
                return NotFound();
            }

            var gameHistoryModel = await _context.GameHistoryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameHistoryModel == null)
            {
                return NotFound();
            }

            return View(gameHistoryModel);
        }

        // POST: GameHistoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameHistoryModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GameHistoryModel'  is null.");
            }
            var gameHistoryModel = await _context.GameHistoryModel.FindAsync(id);
            if (gameHistoryModel != null)
            {
                _context.GameHistoryModel.Remove(gameHistoryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameHistoryModelExists(int id)
        {
            return (_context.GameHistoryModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
