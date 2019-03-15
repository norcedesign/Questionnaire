using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;

namespace Questionnaire.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;

        public DetailsModel(Questionnaire.Models.SurveyContext context)
        {
            _context = context;
        }

        public Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == id);

            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
