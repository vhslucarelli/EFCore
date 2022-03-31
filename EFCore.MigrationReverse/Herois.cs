using System;
using System.Collections.Generic;

namespace EFCore.MigrationReverse
{
    public partial class Herois
    {
        public Herois()
        {
            Armas = new HashSet<Armas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int BatalhaId { get; set; }

        public virtual IdentidadiesSecretas IdentidadiesSecretas { get; set; }
        public virtual ICollection<Armas> Armas { get; set; }
    }
}
