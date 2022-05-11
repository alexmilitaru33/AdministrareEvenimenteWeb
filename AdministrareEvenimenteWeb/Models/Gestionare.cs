using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Gestionare
    {
        public int IdGestionare { get; set; }
        public int IdEveniment { get; set; }
        public int IdLocatieEveniment { get; set; }

        public virtual Eveniment IdEvenimentNavigation { get; set; } = null!;
        public virtual LocatieEveniment IdLocatieEvenimentNavigation { get; set; } = null!;
    }
}
