using System;
using System.Collections.Generic;

namespace Questionnaire.Models
{
    public partial class Reponse
    {
        public int ReponseId { get; set; }
        public int FormId { get; set; }
        public int EntiteId { get; set; }
        public int QuestionId { get; set; }
        public int? OptionId { get; set; }
        public string Texte { get; set; }

        public Entite Entite { get; set; }
        public Formulaire Form { get; set; }
        public Option Question { get; set; }
        public Question QuestionNavigation { get; set; }
    }
}
