using System;
using System.Collections.Generic;

namespace Questionnaire.Models
{
    public partial class QuestionFormulaire
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int QuestionId { get; set; }
        public int? Ordre { get; set; }

        public Formulaire Form { get; set; }
        public Question Question { get; set; }
    }
}
