using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class PrototiposDTO
    {
        public string id { get; set; }
        public string numero { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string urlArchivo { get; set; }
        public string mD5 { get; set; }
        public string estatus { get; set; }
        public DateTime fechaRegistro { get; set; } = DateTime.Now;

    }
}
