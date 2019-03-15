using System;
using System.Collections.Generic;

namespace Questionnaire.Models
{
    public partial class Option
    {
        public Option()
        {
            Reponse = new HashSet<Reponse>();
        }

        public int OptionId { get; set; }
        public int? QuestionId { get; set; }
        public string Label { get; set; }
        public int? Ordre { get; set; }

        public Question Question { get; set; }
        public ICollection<Reponse> Reponse { get; set; }
    }
}
