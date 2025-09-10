using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ExpedientePruebaDTO
    {
        public string id { get; set; }
        public string claveExpediente { get; set; }
        public string ordenFabricacion { get; set; }
        public int cantidadMuestras { get; set; }
        public int maximoRechazos { get; set; }
        public List<string> muestras { get; set; }

    }
}
