using System;
using System.Collections.Generic;

namespace EFCore.MigrationReverse
{
    public partial class Batalhas
    {
        public Batalhas()
        {
            HeroisBatalhas = new HashSet<HeroisBatalhas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }

        public virtual ICollection<HeroisBatalhas> HeroisBatalhas { get; set; }
    }
}
