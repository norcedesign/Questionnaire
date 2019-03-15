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
    public class IndexModel : PageModel
    {
        private readonly Questionnaire.Models.SurveyContext _context;

        public IndexModel(Questionnaire.Models.SurveyContext context)
        {
            _context = context;
        }

        public IList<Entite> Entite { get;set; }

        public async Task OnGetAsync()
        {
            Entite = await _context.Entite.ToListAsync();
        }
    }
}
