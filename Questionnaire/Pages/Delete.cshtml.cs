using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;

namespace Questionnaire.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;

        public DeleteModel(Questionnaire.Models.SurveyContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entite = await _context.Entite.FindAsync(id);

            if (Entite != null)
            {
                _context.Entite.Remove(Entite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
