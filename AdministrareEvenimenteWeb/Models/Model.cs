using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Model
    {
        public Model()
        {
            Administreazas = new HashSet<Administreaza>();
        }

        public int IdModel { get; set; }
        public string Model1 { get; set; } = null!;
        public string Culoare { get; set; } = null!;

        public virtual ICollection<Administreaza> Administreazas { get; set; }
    }
}
