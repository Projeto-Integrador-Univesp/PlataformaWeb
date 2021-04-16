using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.Models
{
    public class EnchenteData
    {
        public Guid EnchenteDataId { get; set; }
        public bool TeveEnchente { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
