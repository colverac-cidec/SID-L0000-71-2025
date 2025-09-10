using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ProductosDTO
    {
        public string id { get; set; }
        public string codigoFabricante { get; set; }
        public string descripcion { get; set; }
        public string descripcionCorta { get; set; }
        public string tipoFabricacion { get; set; }
        public string unidad { get; set; }
        public string norma { get; set; }
        public string prototipo { get; set; }
        public string estatus { get; set; }
        public DateTime fechaRegistro { get; set; } = DateTime.Now;
        public List<string> Pruebas { get; set; }
    }
}
