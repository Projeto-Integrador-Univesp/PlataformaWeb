using Pi.PlataformaWeb.Enchente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<DadoVolumetrico> DadosVolumetricos { get; set; }
        public IEnumerable<EnchenteData> Enchentes { get; set; }
    }
}
