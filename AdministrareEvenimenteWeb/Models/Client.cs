using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Client
    {
        public Client()
        {
            Contracts = new HashSet<Contract>();
            Eveniments = new HashSet<Eveniment>();
        }

        public int IdClient { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefon { get; set; } = null!;

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Eveniment> Eveniments { get; set; }
    }
}
