using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.Models
{
    public class EnchenteData
    {
        public Guid EnchenteDataId { get; set; }
        public bool TeveEnchente { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }
    }
}
