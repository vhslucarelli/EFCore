using System;
using System.Collections.Generic;

namespace EFCore.MigrationReverse
{
    public partial class IdentidadiesSecretas
    {
        public int Id { get; set; }
        public int NomeReal { get; set; }
        public int HeroiId { get; set; }

        public virtual Herois Heroi { get; set; }
    }
}
