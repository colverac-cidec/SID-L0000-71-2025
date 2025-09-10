using ApiClientLibrary.Services;
using ApiClientLibrary.Models;
using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Newtonsoft.Json;

F1_ConfiguracionInicial apiClient = new F1_ConfiguracionInicial();
string respuesta = "";

Console.WriteLine("¿Qué operación POST deseas realizar?");
Console.WriteLine("1. Registrar EstadoSID");
Console.WriteLine("2. Registrar Instrumento");
Console.WriteLine("3. Registrar Prototipo");
Console.WriteLine("4. Registrar Valor de referencia");
Console.WriteLine("5. Registrar Producto");
Console.WriteLine("6. Registrar Norma");
Console.WriteLine("7. Registrar Prueba");
Console.WriteLine("8. Registrar Contrato");
Console.WriteLine("9. Registrar Orden Fabricación");
Console.WriteLine("10. Registrar expediente de pruebas");
Console.WriteLine("11. Registrar Resultado de pruebas");
Console.WriteLine("12. Termina expediente prueba");
Console.WriteLine("13. Consulta las normas");
Console.Write("Selecciona una opción (1-13): ");

string opcion = Console.ReadLine();

switch (opcion)
{
    case "1":
        var estadoResponse = await apiClient.RegistrarEstadoSID(new EstadoSIDDTO
        {
            Estado = "EN_PRUEBAS",
        });
        Console.WriteLine($"Respuesta EstadoSID: {estadoResponse}");
        respuesta += estadoResponse;
        break;

    case "2":
        var instrumentoResponse = await apiClient.RegistrarInstrumento(new InstrumentoDTO
        {
            id = "",
            nombre = "Vernier V-022",
            numeroSerie = "V-022",
            fechaCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            fechaVencimientoCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            urlArchivo = "https://www.cenam.mx/publicaciones/descargas/PDFFiles/usodecertificados.pdf",
            mD5 = "",
            estatus = "VIGENTE", 

        });
        Console.WriteLine($"Respuesta Instrumento: {instrumentoResponse}");
        respuesta += instrumentoResponse;
        break;


    case "3":
        var prototipoResponse = await apiClient.RegistrarPrototipos(new PrototiposDTO
        {
            id = "",
            numero = "Vernier V-022",
            fechaEmision = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            fechaVencimiento = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            urlArchivo = "https://www.cenam.mx/publicaciones/descargas/PDFFiles/usodecertificados.pdf",
            mD5 = "",
            estatus = "VIGENTE",
        });
        Console.WriteLine($"Respuesta Instrumento: {prototipoResponse}");
        respuesta += prototipoResponse;
        break;

    case "4":
        var valorReferenciaResponse = await apiClient.RegistrarValorReferencia(new ValorRefDTO
        {
            id = "",
            idProducto = "68c06ed2c55c585f0beafeb5",
            idPrueba = "68c06badc55c585f0beafe95",
            valor = 0,
            valor2 = 0,
            unidad = "adimensional",
            comparacion = "NO_COMPARAR",


        });
        Console.WriteLine($"Respuesta Valor referencia: {valorReferenciaResponse}");
        respuesta += valorReferenciaResponse;
        break;

    case "5":
        var productosResponse = await apiClient.RegistrarProductos(new ProductosDTO
        {
            id = "",
            codigoFabricante = "J117",
            descripcion = "CABLE CU (350) - XLP-5-133",
            descripcionCorta = "VENTILADOR P/TRANSFORMADOR",
            tipoFabricacion = "LOTE",
            unidad = "m",
            norma = "68c06a36c55c585f0beafe79",
            prototipo = "68c06930c55c585f0beafe6a",
            estatus = "ACTIVO",
            Pruebas = new List<string>
           {
               "68c06badc55c585f0beafe95",
               "68c06c53c55c585f0beafea1"
           }


        });
        Console.WriteLine($"Respuesta producto: {productosResponse}");
        respuesta += productosResponse;
        break;

    case "6":
        var normaResponse = await apiClient.RegistrarNorma(new NormaDTO
        {
            id = "",
            clave = "E0000-04",
            nombre = "CONDUCTORES DUPLEX",
            edicion = "SEPTIEMBRE 2011",
            estatus = "VIGENTE",
            esCFE = true,
        });
        Console.WriteLine($"Respuesta Norma: {normaResponse}");
        respuesta += normaResponse;
        break;

    case "7":
        var pruebaResponse = await apiClient.RegistrarPruebas(new PruebaDTO
        {
            id = "",
            nombre = "Pruebas de alta tensión",
            estatus = "ACTIVA",
            tipoPrueba = "ACEPTACION",
            tipoResultado = "VALOR_REFERENCIA",
        });
        Console.WriteLine($"Respuesta Prueba: {pruebaResponse}");
        respuesta += pruebaResponse;
        break;

    case "8":
        var contratosResponse = await apiClient.RegistrarContratos(new ContratosDTO
        {
            Tipo = "ContratoParticular",
            id = "",
            tipoContrato = "ContratoParticular",
            noContrato = "6875686",
            estatus = "ACTIVO", 
            detalleContratoDTO = new List<DetalleContratoDTO>
        {
            new DetalleContratoDTO
            {
                partidaContrato = "1",
                descripcionAviso = "CABLE MULTIPLE AAC-AAC (1+1)6",
                cantidad = 10,
                unidad = "m",
                importeTotal = 0
            },
            new DetalleContratoDTO
            {
                partidaContrato = "2",
                descripcionAviso = "CABLE MULTIPLE AAC-AAC (1+1)6",
                cantidad = 5,
                unidad = "m",
                importeTotal = 0
            }
        },
            fechaEntregaCFE = DateTime.Parse("2025-09-09T17:32:28.749Z"),
        });
        Console.WriteLine($"Respuesta Prueba: {contratosResponse}");
        respuesta += contratosResponse;
        break;

    case "9":
        var ordenFabricacionResponse = await apiClient.RegistrarOrdenFabricacion(new OrdenFabricacionDTO
        {
            id = "",
            claveOrdenFabricacion = "110300023842",
            loteFabricacion = "LT-CA-33",
            idProducto = "68c06ed2c55c585f0beafeb5",
            detalleFabricacion = new List<DetalleFabricacionDTO>

        {
            new DetalleFabricacionDTO
            {
                contratoId = "68c08693c55c585f0beaff05",
                tipoContrato = "ContratoCFE",
                partidaContratoId = "1",
                descripcionPartida = "Cable de potencia monopolar al (0/1)",
                unidad = "m",
                cantidadOriginalContrato = 5000,
                cantidadAFabricar = 5000
            },
            new DetalleFabricacionDTO
            {
                contratoId = "68c08836c55c585f0beaff1a",
                tipoContrato = "ContratoParticular",
                partidaContratoId = "1",
                descripcionPartida = "Cable de potencia monopolar al (0/1)",
                unidad = "m",
                cantidadOriginalContrato = 1000,
                cantidadAFabricar = 1000
            }
  
        }
        });
        Console.WriteLine($"Respuesta Ordenes de fabricacion: {ordenFabricacionResponse}");
        respuesta += ordenFabricacionResponse;
        break;

    case "10":
        var expedientePruebasResponse = await apiClient.RegistrarExpedientePruebas(new ExpedientePruebaDTO
        {
            id = "68c198379d5906a9d9911d6a",
            claveExpediente = "MI-EXP-CIDEC-2025",
            ordenFabricacion = "68c08fe3c55c585f0beaff37",
            cantidadMuestras = 2,
            maximoRechazos = 4,
            muestras = new List<string> { "TRAMO1", "TRAMO2" }

        });
        Console.WriteLine($"Respuesta del expediente prueba: {expedientePruebasResponse}");
        respuesta += expedientePruebasResponse;
        break;

    case "11":
        var resultadoPruebasResponse = await apiClient.RegistrarResultadoPruebas(new ResultadoPruebasDTO
        {
            expediente = "68c198379d5906a9d9911d6a",
            muestra = "MI-EXP-CIDEC-2025",
            idPrueba = "68c06badc55c585f0beafe95",
            idValorReferencia = "68c07104c55c585f0beafeda",
            fechaPrueba = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            operadorPrueba = "COLVERAC",
            idInstrumentoMedicion = "68c06579c55c585f0beafe44",
            valorMedido = 0,
            resultado = "SATISFACTORIO",
            numeroIntento =1,



        });
        Console.WriteLine($"Respuesta del expediente prueba: {resultadoPruebasResponse}");
        respuesta += resultadoPruebasResponse;
        break;

    case "12":
        var resultadoTerminaPruebaExpedienteResponse = await apiClient.TerminaPruebaExpediente(new TerminaPruebaExpedienteDTO
        {
            Expediente = "MI-EXP-CIDEC-2025",

        });
        Console.WriteLine($"Respuesta del expediente prueba: {resultadoTerminaPruebaExpedienteResponse}");
        respuesta += resultadoTerminaPruebaExpedienteResponse;
        break;

    case "13":
        var responseNormas = await apiClient.ConsultarNormas();

        if (responseNormas.IsSuccessStatusCode)
        {
            var jsonNormas = await responseNormas.Content.ReadAsStringAsync();
            var normas = JsonConvert.DeserializeObject<List<NormaDTO>>(jsonNormas);

            Console.WriteLine("Normas encontradas:");
            foreach (var norma in normas)
            {
                Console.WriteLine($"ID: {norma.id}");
                Console.WriteLine($"Clave: {norma.clave}");
                Console.WriteLine($"Nombre: {norma.nombre}");
                Console.WriteLine($"Edición: {norma.edicion}");
                Console.WriteLine($"Estatus: {norma.estatus}");
                Console.WriteLine($"Es CFE: {norma.esCFE}");
                Console.WriteLine($"Fecha Registro: {norma.fechaRegistro}");
                Console.WriteLine(new string('-', 40));
            }

            respuesta += $"Se consultaron {normas.Count} normas.";
        }
        else
        {
            Console.WriteLine("Error al consultar normas.");
            respuesta += "Error al consultar normas.";
        }

        break;





    default:
        Console.WriteLine("Opción no válida. Intenta de nuevo.");
        break;
}

Console.WriteLine("Proceso finalizado.");
