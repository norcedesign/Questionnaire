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
    public class DetailsModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;

        public DetailsModel(Questionnaire.Models.SurveyContext context)
        {
            _context = context;
        }

        public Entite Entite { get; set; }
        public List­­<Question> LesQuestions { get; set; }
        public List <Reponse> LesReponses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entite = await _context.Entite.Include(x => x.Reponse).SingleOrDefaultAsync(m => m.EntiteId == id);
            LesQuestions = await _context.Question.Include(x => x.Option).ToListAsync();

            if (Entite == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
