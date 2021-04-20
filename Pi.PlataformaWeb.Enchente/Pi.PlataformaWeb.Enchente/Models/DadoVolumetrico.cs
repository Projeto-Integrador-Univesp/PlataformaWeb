using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.Models
{
    public class DadoVolumetrico
    {
        public Guid DadoVolumetricoId { get; set; }

        public Decimal Valor { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }
    }
}
