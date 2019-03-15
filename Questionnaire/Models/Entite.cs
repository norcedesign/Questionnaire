using System;
using System.Collections.Generic;

namespace Questionnaire.Models
{
    public partial class Entite
    {
        public Entite()
        {
            Reponse = new HashSet<Reponse>();
        }

        public int EntiteId { get; set; }
        public int? FormId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateCompletion { get; set; }

        public ICollection<Reponse> Reponse { get; set; }
    }
}
