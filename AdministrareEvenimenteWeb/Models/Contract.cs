using System;
using System.Collections.Generic;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class Contract
    {
        public int IdContract { get; set; }
        public int IdClient { get; set; }
        public int IdServicii { get; set; }

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Servicii IdServiciiNavigation { get; set; } = null!;
    }
}
