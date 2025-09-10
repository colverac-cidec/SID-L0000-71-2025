using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ResultadoPruebasDTO
    {

        public string expediente { get; set; }         // ID del expediente de pruebas
        public string muestra { get; set; }            // Nombre o identificador de la muestra
        public string idPrueba { get; set; }
        public string idValorReferencia { get; set; }
        public DateTime fechaPrueba { get; set; }
        public string operadorPrueba { get; set; }
        public string idInstrumentoMedicion { get; set; }
        public decimal valorMedido { get; set; }
        public string resultado { get; set; }
        public int numeroIntento { get; set; }

    }
}
