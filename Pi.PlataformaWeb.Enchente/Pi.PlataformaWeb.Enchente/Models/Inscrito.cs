using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.PlataformaWeb.Enchente.Models
{
    public class Inscrito
    {
        public Guid InscritoID { get; set; }

        public string Nome { get; set; }
        public string Celular { get; set; }

        public string PushEndpoint { get; set; }
        public string PushP256DH { get; set; }
        public string PushAuth { get; set; }
    }
}
