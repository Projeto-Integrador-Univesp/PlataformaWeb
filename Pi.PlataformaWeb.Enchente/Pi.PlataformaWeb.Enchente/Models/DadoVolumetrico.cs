using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.Models
{
    public class DadoVolumetrico
    {
        public Guid DadoVolumetricoId { get; set; }

        public Decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
