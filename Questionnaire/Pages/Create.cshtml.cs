using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Questionnaire.Models;

namespace Questionnaire.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;

        public CreateModel(Questionnaire.Models.SurveyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entite Entite { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entite.Add(Entite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}