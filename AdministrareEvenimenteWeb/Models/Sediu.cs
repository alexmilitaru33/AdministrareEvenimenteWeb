using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Sediu
    {
        public Sediu()
        {
            Angajats = new HashSet<Angajat>();
        }

        public int IdSediu { get; set; }
        public string Judet { get; set; } = null!;
        public string Localitate { get; set; } = null!;
        public string? Strada { get; set; }
        public int Numar { get; set; }

        public virtual ICollection<Angajat> Angajats { get; set; }
    }
}
