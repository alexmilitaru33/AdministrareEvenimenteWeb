using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Administreaza
    {
        public int IdAdministreaza { get; set; }
        public int IdServicii { get; set; }
        public int? IdModel { get; set; }

        public virtual Model? IdModelNavigation { get; set; }
        public virtual Servicii IdServiciiNavigation { get; set; } = null!;
    }
}
