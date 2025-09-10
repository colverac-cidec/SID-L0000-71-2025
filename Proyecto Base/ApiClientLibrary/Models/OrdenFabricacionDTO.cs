using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{

    public class OrdenFabricacionDTO
    {
        public string id { get; set; }
        public string claveOrdenFabricacion { get; set; }
        public string loteFabricacion { get; set; }
        public string idProducto { get; set; }
        public List<DetalleFabricacionDTO> detalleFabricacion { get; set; }
    }

    public class DetalleFabricacionDTO
    {
        public string contratoId { get; set; }
        public string tipoContrato { get; set; }
        public string partidaContratoId { get; set; }
        public string descripcionPartida { get; set; }
        public string unidad { get; set; }
        public int cantidadOriginalContrato { get; set; }
        public int cantidadAFabricar { get; set; }
    }

}
