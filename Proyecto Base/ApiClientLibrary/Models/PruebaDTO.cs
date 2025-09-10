using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class PruebaDTO
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string tipoPrueba { get; set; }
        public string tipoResultado { get; set; }
        public DateTime fechaRegistro { get; set; } = DateTime.Now;
    }

  
}
