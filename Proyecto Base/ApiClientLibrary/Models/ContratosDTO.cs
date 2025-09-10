using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ContratosDTO
    {

        [JsonPropertyName("$Tipo")]
        public string Tipo { get; set; }

        public string id { get; set; }
        public string tipoContrato { get; set; }
        public string noContrato { get; set; }
        public string estatus { get; set; }
        public List<DetalleContratoDTO> detalleContratoDTO { get; set; }
        public DateTime fechaEntregaCFE { get; set; }
    }

    public class DetalleContratoDTO
    {
        public string partidaContrato { get; set; }
        public string descripcionAviso { get; set; }
        public int cantidad { get; set; }
        public string unidad { get; set; }
        public decimal importeTotal { get; set; }
    }
}
