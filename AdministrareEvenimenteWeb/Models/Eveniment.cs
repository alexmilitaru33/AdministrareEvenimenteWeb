using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Eveniment
    {
        public Eveniment()
        {
            Gestionares = new HashSet<Gestionare>();
        }

        public int IdEveniment { get; set; }
        public string NumeEveniment { get; set; } = null!;
        public DateTime DataOraInceperii { get; set; }
        public DateTime DataOraIncheierii { get; set; }
        public int IdClient { get; set; }

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual ICollection<Gestionare> Gestionares { get; set; }
    }
}
