using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Servicii
    {
        public Servicii()
        {
            Administreazas = new HashSet<Administreaza>();
            Angajats = new HashSet<Angajat>();
            Contracts = new HashSet<Contract>();
        }

        public int IdServicii { get; set; }
        public string NumeServiciu { get; set; } = null!;
        public int PretServiciu { get; set; }

        public virtual ICollection<Administreaza> Administreazas { get; set; }
        public virtual ICollection<Angajat> Angajats { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
