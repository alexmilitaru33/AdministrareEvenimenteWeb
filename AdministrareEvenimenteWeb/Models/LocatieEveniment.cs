using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class LocatieEveniment
    {
        public LocatieEveniment()
        {
            Gestionares = new HashSet<Gestionare>();
        }

        public int IdLocatieEveniment { get; set; }
        public string NumeLocatie { get; set; } = null!;
        public string Judet { get; set; } = null!;
        public string Localitate { get; set; } = null!;
        public string Strada { get; set; } = null!;
        public decimal Numar { get; set; }

        public virtual ICollection<Gestionare> Gestionares { get; set; }
    }
}
