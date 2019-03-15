using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Models
{
    public partial class Question
    {
        public Question()
        {
            Option = new HashSet<Option>();
            QuestionFormulaire = new HashSet<QuestionFormulaire>();
            Reponse = new HashSet<Reponse>();
        }

        public int QuestionId { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string Type { get; set; }
        public int Ordre { get; set; }

        public ICollection<Option> Option { get; set; }
        public ICollection<QuestionFormulaire> QuestionFormulaire { get; set; }
        public ICollection<Reponse> Reponse { get; set; }
    }
}
