using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;

namespace Questionnaire.Controllers
{
    public class EntitesController : Controller
    {
        private readonly SurveyContext _context;

        public EntitesController(SurveyContext context)
        {
            _context = context;
        }

        // GET: Entites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entite.ToListAsync());
        }

        // GET: Entites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entite = await _context.Entite
                .SingleOrDefaultAsync(m => m.EntiteId == id);
            if (entite == null)
            {
                return NotFound();
            }

            return View(entite);
        }

        // GET: Entites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntiteId,FormId,FirstName,LastName,CompanyName,Phone,Email,Address,City,Country,PostalCode,DateCompletion")] Entite entite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entite);
        }

        // GET: Entites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entite = await _context.Entite.SingleOrDefaultAsync(m => m.EntiteId == id);
            if (entite == null)
            {
                return NotFound();
            }
            return View(entite);
        }

        // POST: Entites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntiteId,FormId,FirstName,LastName,CompanyName,Phone,Email,Address,City,Country,PostalCode,DateCompletion")] Entite entite)
        {
            if (id != entite.EntiteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntiteExists(entite.EntiteId))
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
            return View(entite);
        }

        // GET: Entites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entite = await _context.Entite
                .SingleOrDefaultAsync(m => m.EntiteId == id);
            if (entite == null)
            {
                return NotFound();
            }

            return View(entite);
        }

        // POST: Entites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entite = await _context.Entite.SingleOrDefaultAsync(m => m.EntiteId == id);
            _context.Entite.Remove(entite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntiteExists(int id)
        {
            return _context.Entite.Any(e => e.EntiteId == id);
        }
    }
}
