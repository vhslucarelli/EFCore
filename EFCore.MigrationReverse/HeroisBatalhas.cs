using System;
using System.Collections.Generic;

namespace EFCore.MigrationReverse
{
    public partial class HeroisBatalhas
    {
        public HeroisBatalhas()
        {
            InverseHeroiBatalha = new HashSet<HeroisBatalhas>();
        }

        public int HeroiId { get; set; }
        public int BatalhaId { get; set; }
        public int? HeroiBatalhaBatalhaId { get; set; }
        public int? HeroiBatalhaHeroiId { get; set; }

        public virtual Batalhas Batalha { get; set; }
        public virtual HeroisBatalhas HeroiBatalha { get; set; }
        public virtual ICollection<HeroisBatalhas> InverseHeroiBatalha { get; set; }
    }
}
