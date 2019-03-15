using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Questionnaire.Models;

namespace Questionnaire.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;
        public List<SelectListItem> TypeRep { get; set; }
        public CreateModel(Questionnaire.Models.SurveyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            TypeRep = new List<SelectListItem> {
                new SelectListItem { Value = "Text", Text = "Texte" },
                new SelectListItem { Value = "Num", Text = "Numérique" },
                new SelectListItem { Value = "Option", Text = "Choix unique" },
                new SelectListItem { Value = "Multi", Text = "Choix multiple" }
            };
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Question.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}