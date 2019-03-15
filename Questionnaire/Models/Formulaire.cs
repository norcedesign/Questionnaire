using System;
using System.Collections.Generic;

namespace Questionnaire.Models
{
    public partial class Formulaire
    {
        public Formulaire()
        {
            QuestionFormulaire = new HashSet<QuestionFormulaire>();
            Reponse = new HashSet<Reponse>();
        }

        public int FormId { get; set; }
        public string Titre { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public ICollection<QuestionFormulaire> QuestionFormulaire { get; set; }
        public ICollection<Reponse> Reponse { get; set; }
    }
}
