using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Angajat
    {
        public int IdAngajat { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public int IdSediu { get; set; }
        public int IdServicii { get; set; }

        public virtual Sediu IdSediuNavigation { get; set; } = null!;
        public virtual Servicii IdServiciiNavigation { get; set; } = null!;
    }
}
