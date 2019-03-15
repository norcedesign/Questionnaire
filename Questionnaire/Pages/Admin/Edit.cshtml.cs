using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;

namespace Questionnaire.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;
       

        public EditModel(Questionnaire.Models.SurveyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Question Question { get; set; }

        public List<SelectListItem> TypeRep { get; set; }
        public List<Option> Options { get; set; }
        [BindProperty]
        public Option uneOption { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TypeRep = new List<SelectListItem> {
                new SelectListItem { Value = "Text", Text = "Texte" },
                new SelectListItem { Value = "Num", Text = "Numérique" },
                new SelectListItem { Value = "Option", Text = "Choix unique" },
                new SelectListItem { Value = "Multi", Text = "Choix multiple" }
            };

            Question = await _context.Question.Include(q=>q.Option).SingleOrDefaultAsync(m => m.QuestionId == id);
            Options = Question.Option.ToList();

            if (Question == null)
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

            
            _context.Attach(Question).State = EntityState.Modified;

            try
            {
                if (uneOption.Label!= null)
                {
                    uneOption.QuestionId = Question.QuestionId;
                    _context.Option.Add(uneOption);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(Question.QuestionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

          //  return RedirectToPage("./Index");
            return RedirectToPage("/Admin/Details", new { id = Question.QuestionId.ToString() });
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.QuestionId == id);
        }
    }
}
