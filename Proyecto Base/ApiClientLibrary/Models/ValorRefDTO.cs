using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ValorRefDTO
    {
        public string id { get; set; }
        public string idProducto { get; set; }
        public string idPrueba { get; set; }
        public decimal valor { get; set; }
        public decimal valor2 { get; set; }
        public string unidad { get; set; }
        public string comparacion { get; set; }
        public DateTime fechaRegistro { get; set; } = DateTime.Now;

    }
}
