using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;

namespace Questionnaire.Pages
{
    public class EditModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;

        public EditModel(Questionnaire.Models.SurveyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entite Entite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entite = await _context.Entite.SingleOrDefaultAsync(m => m.EntiteId == id);

            if (Entite == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Entite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntiteExists(Entite.EntiteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EntiteExists(int id)
        {
            return _context.Entite.Any(e => e.EntiteId == id);
        }
    }
}
