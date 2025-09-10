using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class InstrumentoDTO
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string numeroSerie { get; set; }
        public DateTime fechaCalibracion { get; set; }
        public DateTime fechaVencimientoCalibracion { get; set; }
        public string urlArchivo { get; set; }
        public string mD5 { get; set; }
        public string estatus { get; set; }
        public DateTime fechaRegistro { get; set; } = DateTime.Now;
    }
}
