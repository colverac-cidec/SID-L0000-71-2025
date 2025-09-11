using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{

    public class NormaDTO
    {
        public string id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string edicion { get; set; }
        public string estatus { get; set; }
        public bool esCFE { get; set; }
        public DateTime fechaRegistro { get; set; } = DateTime.Now;
    }



}
