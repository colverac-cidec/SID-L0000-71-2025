using ApiClientLibrary.Services;
using ApiClientLibrary.Models;
using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Serialization;
using System.Reflection.Emit;
using System.Collections.Generic;


F1_ConfiguracionInicial apiClient = new F1_ConfiguracionInicial();
F2_PreparacionFabricacion apiClientPreparacion = new F2_PreparacionFabricacion();
F3_Pruebas apiClientPruebas = new F3_Pruebas();
F4_Liberacion apiClientLiberacion = new F4_Liberacion();
string respuesta = "";

Console.WriteLine("¿Qué operación POST deseas realizar?");
Console.WriteLine("1. Registrar EstadoSID");//1
Console.WriteLine("2. Registrar Instrumento");//1
Console.WriteLine("3. Registrar Prototipo");//1
Console.WriteLine("4. Registrar Valor de referencia");//1
Console.WriteLine("5. Registrar Producto");//1
Console.WriteLine("6. Registrar Norma");//1
Console.WriteLine("7. Registrar Prueba");//1
Console.WriteLine("8. Registrar Contrato"); //2
Console.WriteLine("9. Registrar Orden Fabricación");//2
Console.WriteLine("10. Registrar expediente de pruebas");//2
Console.WriteLine("11. Registrar Resultado de pruebas");//3
Console.WriteLine("12. Termina expediente prueba");//3
Console.WriteLine("13. Actualizar los instrumentos");//1
Console.WriteLine("14. Consulta las normas");//1
Console.WriteLine("15. Consulta los instrumentos");//1
Console.WriteLine("16. Consulta pruebas");//1
Console.WriteLine("17. Consulta prototipos");//1
Console.WriteLine("18. Consulta Valor de Referencias");//1
Console.WriteLine("19. Consulta Productos");//1
Console.WriteLine("20. Consulta Contratos");//2
Console.WriteLine("21. Consulta Orden de fabricación");//2
Console.WriteLine("22. Consulta expediente de pruebas");//2
Console.WriteLine("--Este ultimo es el examne completo--");//2
Console.WriteLine("25. Registra Examen completo");//2
Console.Write("Selecciona una opción (1-25): ");

string opcion = Console.ReadLine();

var IdsInstrumentos = new List<string>();
var IdNorma = new List<string>();
var IdPrototipo = new List<string>();
var IdsPruebas = new List<string>();
var IdProducto = new List<string>();
var IdsValoresReferencia = new List<string>();
var IdContratoCFE = new List<string>();
var IdContratoParticualar = new List<string>();
var IdOrdenesFab = new List<string>();
var IdExpediente = new List<string>();

var claExpediente = "EXP-2025-01984";

string consecutivo = "6";


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


        // Lista de instrumentos a registrar
        var instrumentosList = new List<InstrumentoDTO>
{
    new InstrumentoDTO
    {
        id = "",
        nombre = "micro-ohmetro digital-1",
        numeroSerie = "TUG0987220",
        fechaCalibracion = DateTime.Parse("2025-09-11T17:32:28.749Z"),
        fechaVencimientoCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
        urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
        mD5 = "",
        estatus = "VIGENTE"
    },
    new InstrumentoDTO
    {
        id = "",
        nombre = "multímetro digital",
        numeroSerie = "ABC123456",
        fechaCalibracion = DateTime.Parse("2025-08-01T10:00:00Z"),
        fechaVencimientoCalibracion = DateTime.Parse("2026-08-01T10:00:00Z"),
        urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
        mD5 = "",
        estatus = "VIGENTE"
    }
    // Puedes agregar más instrumentos aquí
};

        string respuestaIns = "";

        foreach (var instrumento in instrumentosList)
        {
            var instrumentoResponse = await apiClient.RegistrarInstrumento(instrumento);
            Console.WriteLine($"Respuesta Instrumento: {instrumentoResponse}");
            respuestaIns += instrumentoResponse;
        }




        //var instrumentoResponse = await apiClient.RegistrarInstrumento(new InstrumentoDTO
        //{
        //    id = "",
        //    nombre = "micro-ohmetro digital ",
        //    numeroSerie = "TUG098722",
        //    fechaCalibracion = DateTime.Parse("2025-09-11T17:32:28.749Z"),
        //    fechaVencimientoCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
        //    urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
        //    mD5 = "",
        //    estatus = "VIGENTE", 

        //});
        //Console.WriteLine($"Respuesta Instrumento: {instrumentoResponse}");
        //respuesta += instrumentoResponse;
        break;


    case "3":
        var prototipoResponse = await apiClient.RegistrarPrototipos(new PrototiposDTO
        {
            id = "",
            numero = "K311D-24-E/4951",
            fechaEmision = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            fechaVencimiento = DateTime.Parse("2025-10-09T17:32:28.749Z"),
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
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
            idPrueba = "68c2fd605006ea4012083890",
            valor = 0,
            valor2 = 0,
            unidad = "No aplica",
            comparacion = "NO_COMPARAR",


        });
        Console.WriteLine($"Respuesta Valor referencia: {valorReferenciaResponse}");
        respuesta += valorReferenciaResponse;
        break;

    case "5":
        var productosResponse = await apiClient.RegistrarProductos(new ProductosDTO
        {
            id = "",
            codigoFabricante = "J007",
            descripcion = "CABLE DE COBRE SEMIDURO DESNUDO CCN 1/0 AWG 7H",
            descripcionCorta = "CABLE CU 1/0",
            tipoFabricacion = "LOTE",
            unidad = "m",
            norma = "68c317cddc75889685df3aba",
            prototipo = "68c3182ddc75889685df3abd",
            estatus = "ACTIVO",
            Pruebas = new List<string>
           {
               "68c318b7dc75889685df3ac2",
               "68c318c4dc75889685df3ac3",
               "68c318e3dc75889685df3ac4"
           }


        });
        Console.WriteLine($"Respuesta producto: {productosResponse}");
        respuesta += productosResponse;
        break;

    case "6":
        var normaResponse = await apiClient.RegistrarNorma(new NormaDTO
        {
            id = "",
            clave = "CFE E0000-32",
            nombre = "ALAMBRE Y CABLE DE COBRE SEMIDURO DESNUDO",
            edicion = "2020",
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
            //nombre = "Resistividad volumetrica a 20°C",
            //nombre = "Valor nominal de masa",
            nombre = "inspeccion Visual",
            estatus = "ACTIVA",
            tipoPrueba = "ACEPTACION",
            tipoResultado = "VALOR_REFERENCIA",
        });
        Console.WriteLine($"Respuesta Prueba: {pruebaResponse}");
        respuesta += pruebaResponse;
        break;

    case "8":
        var contratosResponse = await apiClientPreparacion.RegistrarContratos(new ContratosDTO
        {
            Tipo = "ContratoCFE",
            id = "",
            tipoContrato = "ContratoCFE",
            noContrato = "9100026917",
            estatus = "ACTIVO",
            detalleContrato = new List<DetalleContratoDTO>

        {   
            new DetalleContratoDTO
            {
                partidaContrato = "838",
                descripcionAviso = "CABLE DE COBRE SEMIDURO DESNUDO CCN 1/0 AWG 7H",
                areaDestinoCFE = "CFE",
                cantidad = 1,
                unidad = "m",
                importeTotal = 282055
            },
            new DetalleContratoDTO
            {
                partidaContrato = "864",
                descripcionAviso = "CABLE DE COBRE SEMIDURO DESNUDO CCN 1/0 AWG 7H",
                cantidad = 2,
                unidad = "m",
                importeTotal = 302055
            }
        },
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
            mD5 = "",
            fechaEntregaCFE = DateTime.Parse("2025-09-11T17:32:28.749Z"),
        });
        Console.WriteLine($"Respuesta Prueba: {contratosResponse}");
        respuesta += contratosResponse;
        break;

    case "9":
        var ordenFabricacionResponse = await apiClientPreparacion.RegistrarOrdenFabricacion(new OrdenFabricacionDTO
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
        var expedientePruebasResponse = await apiClientPreparacion.RegistrarExpedientePruebas(new ExpedientePruebaDTO
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

   /* case "11":
        var resultadoPruebasResponse = await apiClientPruebas.RegistrarResultadoPruebas(new ResultadoPruebasDTO
        {
            //expediente = "68c198379d5906a9d9911d6a",
            //muestra = "MI-EXP-CIDEC-2025",
            idPrueba = "68c06badc55c585f0beafe95",
            idValorReferencia = "68c07104c55c585f0beafeda",
            fechaPrueba = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            operadorPrueba = "COLVERAC",
            idInstrumentoMedicion = "68c06579c55c585f0beafe44",
            valorMedido = "0",
            resultado = "SATISFACTORIO",
            numeroIntento =1,



        });
        Console.WriteLine($"Respuesta del expediente prueba: {resultadoPruebasResponse}");
        respuesta += resultadoPruebasResponse;
        break;*/

   /* case "12":
        var resultadoTerminaPruebaExpedienteResponse = await apiClientPruebas.TerminaPruebaExpediente("")
        {
            Expediente = "MI-EXP-CIDEC-2025",

        });
        Console.WriteLine($"Respuesta del expediente prueba: {resultadoTerminaPruebaExpedienteResponse}");
        respuesta += resultadoTerminaPruebaExpedienteResponse;
        break;*/
    case "13":
        var instrumentoActResponse = await apiClient.ActualizarInstrumento(new InstrumentoDTO
        {
            id = "68c06579c55c585f0beafe44",
            nombre = "Vernier V-022",
            numeroSerie = "V-022",
            fechaCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            fechaVencimientoCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
            mD5 = "",
            estatus = "VIGENTE",

        });
        Console.WriteLine($"Respuesta Instrumento: {instrumentoActResponse}");
        respuesta += instrumentoActResponse;
        break;

    case "14":
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

    case "15":
        var responseIntrumentos = await apiClient.ConsultarInstrumento();

        if (responseIntrumentos.IsSuccessStatusCode)
        {
            var jsonInstrumento = await responseIntrumentos.Content.ReadAsStringAsync();
            var instrumentos = JsonConvert.DeserializeObject<List<InstrumentoDTO>>(jsonInstrumento);

            Console.WriteLine("Instrumentos encontradas:");
            foreach (var instrumento in instrumentos)
            {
                Console.WriteLine($"ID: {instrumento.id}");
                Console.WriteLine($"nombre: {instrumento.nombre}");
                Console.WriteLine($"numeroSerie: {instrumento.numeroSerie}");
                Console.WriteLine($"fechaCalibracion: {instrumento.fechaCalibracion}");
                Console.WriteLine($"fechaVencimientoCalibracion: {instrumento.fechaVencimientoCalibracion}");
                Console.WriteLine($"urlArchivo: {instrumento.urlArchivo}");
                Console.WriteLine($"mD5: {instrumento.mD5}");
                Console.WriteLine($"estatus: {instrumento.estatus}");
                Console.WriteLine($"Fecha Registro: {instrumento.fechaRegistro}");
                Console.WriteLine(new string('-', 40));
            }

            respuesta += $"Se consultaron {instrumentos.Count} normas.";


        }
        else
        {
            Console.WriteLine("Error al consultar instrumentos.");
            respuesta += "Error al consultar instrumentos.";
        }

 

        break;



    case "16":
        var responsePruebas = await apiClient.ConsultarPruebas();

        if (responsePruebas.IsSuccessStatusCode)
        {
            var jsonPruebas = await responsePruebas.Content.ReadAsStringAsync();
            var Pruebas = JsonConvert.DeserializeObject<List<PruebaDTO>>(jsonPruebas);

            Console.WriteLine("Pruebas encontradas:");
            foreach (var prueba in Pruebas)
            {
                Console.WriteLine($"ID: {prueba.id}");
                Console.WriteLine($"Nombre: {prueba.nombre}");
                Console.WriteLine($"estatus: {prueba.estatus}");
                Console.WriteLine($"TipoPrueba: {prueba.tipoPrueba}");
                Console.WriteLine($"TipoRes: {prueba.tipoResultado}");
                Console.WriteLine($"FechaReg: {prueba.fechaRegistro}");
                Console.WriteLine(new string('-', 40));
            }

            respuesta += $"Se consultaron {Pruebas.Count} pruebas.";
        }
        else
        {
            Console.WriteLine("Error al consultar pruebas.");
            respuesta += "Error al consultar pruebas.";
        }

        break;

    case "17":
        var responsePrototipo = await apiClient.ConsultarPrototipo();

        if (responsePrototipo.IsSuccessStatusCode)
        {
            var jsonPrototipo = await responsePrototipo.Content.ReadAsStringAsync();
            var Prototipos = JsonConvert.DeserializeObject<List<PrototiposDTO>>(jsonPrototipo);

            Console.WriteLine("Prototipos encontradas:");
            foreach (var protipo in Prototipos)
            {
                Console.WriteLine($"ID: {protipo.id}");
                Console.WriteLine($"numero: {protipo.numero}");
                Console.WriteLine($"fechaEmision: {protipo.fechaEmision}");
                Console.WriteLine($"fechaVencimiento: {protipo.fechaVencimiento}");
                Console.WriteLine($"urlArchivo: {protipo.urlArchivo}");
                Console.WriteLine($"mD5: {protipo.mD5}");
                Console.WriteLine($"estatus: {protipo.estatus}");
                Console.WriteLine($"Fecha Registro: {protipo.fechaRegistro}");
                Console.WriteLine(new string('-', 40));
            }

            respuesta += $"Se consultaron {Prototipos.Count} protipo.";
        }
        else
        {
            Console.WriteLine("Error al consultar protipo.");
            respuesta += "Error al consultar protipo.";
        }

        break;

    case "18":
        var responseValorReferencia = await apiClient.ConsultarValorReferencia();

        if (responseValorReferencia.IsSuccessStatusCode)
        {
            var jsonValorReferencia = await responseValorReferencia.Content.ReadAsStringAsync();
            var ValorReferencias = JsonConvert.DeserializeObject<List<ValorRefDTO>>(jsonValorReferencia);

            Console.WriteLine("Valor de referencias encontradas:");
            foreach (var valRef in ValorReferencias)
            {
                Console.WriteLine($"ID: {valRef.id}");
                Console.WriteLine($"numero: {valRef.idProducto}");
                Console.WriteLine($"fechaEmision: {valRef.idPrueba}");
                Console.WriteLine($"fechaVencimiento: {valRef.valor}");
                Console.WriteLine($"urlArchivo: {valRef.valor2}");
                Console.WriteLine($"mD5: {valRef.unidad}");
                Console.WriteLine($"estatus: {valRef.comparacion}");
                Console.WriteLine($"Fecha Registro: {valRef.fechaRegistro}");
                Console.WriteLine(new string('-', 40));
            }

            respuesta += $"Se consultaron {ValorReferencias.Count} ValorRef.";
        }
        else
        {
            Console.WriteLine("Error al consultar valorRef.");
            respuesta += "Error al consultar valorRef.";
        }

        break;

    case "19":
        var responseProducto = await apiClient.ConsultarProducto();

        if (responseProducto.IsSuccessStatusCode)
        {
            var jsonProducto = await responseProducto.Content.ReadAsStringAsync();
            var Productos = JsonConvert.DeserializeObject<List<ProductosConsultaDTO>>(jsonProducto);

            Console.WriteLine("Productos encontradas:");
            foreach (var producto in Productos)
            {
                Console.WriteLine($"ID: {producto.id}");
                Console.WriteLine($"codigoFabricante: {producto.codigoFabricante}");
                Console.WriteLine($"descripcion: {producto.descripcion}");
                Console.WriteLine($"descripcionCorta: {producto.descripcionCorta}");
                Console.WriteLine($"tipoFabricacion: {producto.tipoFabricacion}");
                Console.WriteLine($"unidad: {producto.unidad}");
                Console.WriteLine($"norma: {producto.norma}");
                Console.WriteLine($"prototipo: {producto.prototipo}");
                Console.WriteLine($"estatus: {producto.estatus}");
                Console.WriteLine($"Fecha Registro: {producto.fechaRegistro}");
                //Console.WriteLine($"Pruebas: {producto.Pruebas}");
                Console.WriteLine(new string('-', 40));
            }

            respuesta += $"Se consultaron {Productos.Count} Productos.";
        }
        else
        {
            Console.WriteLine("Error al consultar Productos.");
            respuesta += "Error al consultar Productos.";
        }

        break;

    case "20":
        var responseContratos= await apiClientPreparacion.ConsultarContratos();
        //var responseContratos = await apiClient.ConsultarContratos(pageNumber: 1, pageSize: 10);

        if (responseContratos.IsSuccessStatusCode)
        {
            var jsonContratos = await responseContratos.Content.ReadAsStringAsync();
            var contratosResponse2 = JsonConvert.DeserializeObject<ContratosResponseDTO>(jsonContratos);
            var Contratos = contratosResponse2.contratos;

            Console.WriteLine("Contratos encontradas:");
            foreach (var contrato in Contratos)
            {
                Console.WriteLine($"Tipo: {contrato.Tipo}");
                Console.WriteLine($"ID: {contrato.id}");
                Console.WriteLine($"Tipo de Contrato: {contrato.tipoContrato}");
                Console.WriteLine($"Número de Contrato: {contrato.noContrato}");
                Console.WriteLine($"Estatus: {contrato.estatus}");
                Console.WriteLine($"Fecha de Entrega CFE: {contrato.fechaEntregaCFE}");
                Console.WriteLine($"URL Archivo: {contrato.urlArchivo}");
                Console.WriteLine($"MD5: {contrato.mD5}");

                Console.WriteLine("Detalle del contrato:");
                foreach (var detalle in contrato.detalleContrato)
                {
                    Console.WriteLine($"  Partida: {detalle.partidaContrato}");
                    Console.WriteLine($"  Descripción: {detalle.descripcionAviso}");
                    Console.WriteLine($"  Cantidad: {detalle.cantidad}");
                    Console.WriteLine($"  Unidad: {detalle.unidad}");
                    Console.WriteLine($"  Importe Total: {detalle.importeTotal}");
                    Console.WriteLine(new string('-', 30));
                }

                Console.WriteLine(new string('-', 40));

            }

            respuesta += $"Se consultaron {contratosResponse2} Contratos.";
        }
        else
        {
            Console.WriteLine("Error al consultar contratos.");
            respuesta += "Error al consultar contratos.";
        }

        break;

    case "21":
        var responseOrdenFabricacion = await apiClientPreparacion.ConsultarOrdenFabricacion("68c08fe3c55c585f0beaff37");
        //var responseContratos = await apiClient.ConsultarContratos(pageNumber: 1, pageSize: 10);

        if (responseOrdenFabricacion.IsSuccessStatusCode)
        {
            var jsonOrdenFabricacion = await responseOrdenFabricacion.Content.ReadAsStringAsync();
            var OrdenFabricacion = JsonConvert.DeserializeObject<List<OrdenFabricacionDTO>>(jsonOrdenFabricacion);
            //var OrdenFabricacion = JsonConvert.DeserializeObject<OrdenFabricacionDTO>(jsonContratos);
            //var Contratos = contratosResponse2.contratos;

            Console.WriteLine("Contratos encontradas:");
            foreach (var orden in OrdenFabricacion)
            {
   
                Console.WriteLine($"ID: {orden.id}");
                Console.WriteLine($"claveOrdenFabricacion: {orden.claveOrdenFabricacion}");
                Console.WriteLine($"loteFabricacion: {orden.loteFabricacion}");
                Console.WriteLine($"idProducto: {orden.idProducto}");


                Console.WriteLine("Detalle del contrato:");
                foreach (var detalle in orden.detalleFabricacion)
                {
                    Console.WriteLine($"  Partida: {detalle.contratoId}");
                    Console.WriteLine($"  Descripción: {detalle.tipoContrato}");
                    Console.WriteLine($"  Cantidad: {detalle.partidaContratoId}");
                    Console.WriteLine($"  Unidad: {detalle.descripcionPartida}");
                    Console.WriteLine($"  Importe Total: {detalle.unidad}");
                    Console.WriteLine($"  Unidad: {detalle.cantidadOriginalContrato}");
                    Console.WriteLine($"  Importe Total: {detalle.cantidadAFabricar}");
                    Console.WriteLine(new string('-', 30));
                }

                Console.WriteLine(new string('-', 40));

            }

            respuesta += $"Se consultaron {OrdenFabricacion} Orden de fabricación.";
        }
        else
        {
            Console.WriteLine("Error al consultar Orden de fabricación.");
            respuesta += "Error al consultar Orden de fabricación.";
        }

        break;

    case "22":
        var responseExpedientePruebas = await apiClientPreparacion.ConsultarExpedientePruebas("68c198379d5906a9d9911d6a");
        //var responseContratos = await apiClient.ConsultarContratos(pageNumber: 1, pageSize: 10);

        if (responseExpedientePruebas.IsSuccessStatusCode)
        {
            var jsonOrdenFabricacion = await responseExpedientePruebas.Content.ReadAsStringAsync();
            var Expedientespruebas = JsonConvert.DeserializeObject<List<ExpedientePruebaDTO>>(jsonOrdenFabricacion);
            //var OrdenFabricacion = JsonConvert.DeserializeObject<OrdenFabricacionDTO>(jsonContratos);
            //var Contratos = contratosResponse2.contratos;

            Console.WriteLine("Expedientes pruebas:");
            foreach (var expe in Expedientespruebas)
            {

                Console.WriteLine($"ID: {expe.id}");
                Console.WriteLine($"claveExpediente: {expe.claveExpediente}");
                Console.WriteLine($"ordenFabricacion: {expe.ordenFabricacion}");
                Console.WriteLine($"cantidadMuestras: {expe.cantidadMuestras}");
                Console.WriteLine($"maximoRechazos: {expe.maximoRechazos}");
                Console.WriteLine($"muestras: {expe.muestras}");

                Console.WriteLine(new string('-', 40));

            }

            respuesta += $"Se consultaron {Expedientespruebas} expedientes pruebas.";
        }
        else
        {
            Console.WriteLine("Error al consultar expedientes pruebas.");
            respuesta += "Error al consultar expedientes pruebas.";
        }

        break;

    case "25":


         //Llamamos a la lógica de otros cases
        AgregaInstrumentos();
        AgregaNorma();
        AgregaPrototipo();
        AgregaPruebas();
        AgregaProducto();
        AgregaValoresDeReferencia();
        AgregaContratoCFE();
        AgregaContratoParticualar();
        AgregaOrdenDeFabricacion();
        AgregaExpedientes();    
        AgregaResultadoPrueba();
        ValidaExpediente();
        TerminaExpediente();
        PrevioAvisosPrueba();
        CreaElAvisoDePruebas();
        break;
        

    default:
        Console.WriteLine("Opción no válida. Intenta de nuevo.");
        break;
}




//Agrega Instrumento
void AgregaInstrumentos()
{
    Console.WriteLine("Ejecutando lógica del case 2");
    var instrumentos = new List<InstrumentoDTO>
    {
        new InstrumentoDTO
        {
            id = "",
            nombre = "Micrómetro digital alta precisión",
            numeroSerie = "MD-992381",
            fechaCalibracion = DateTime.Parse("2026-02-11T17:32:28.749Z"),
            fechaVencimientoCalibracion = DateTime.Parse("2026-10-09T17:32:28.749Z"),
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
            mD5 = "",
            estatus = "VIGENTE"
        },
        new InstrumentoDTO
        {
            id = "",
            nombre = "Cámara termográfica industrial",
            numeroSerie = "CT-556781",
            fechaCalibracion = DateTime.Parse("2026-02-01T10:00:00Z"),
            fechaVencimientoCalibracion = DateTime.Parse("2026-10-01T10:00:00Z"),
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
            mD5 = "",
            estatus = "VIGENTE"
        },
        new InstrumentoDTO
        {
            id = "",
            nombre = "Resistencia eléctrica (Puente Kelvin)",
            numeroSerie = "ABC123457",
            fechaCalibracion = DateTime.Parse("2026-02-01T10:00:00Z"),
            fechaVencimientoCalibracion = DateTime.Parse("2026-10-01T10:00:00Z"),
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
            mD5 = "",
            estatus = "VIGENTE"
        }

        // Puedes agregar más instrumentos aquí
    };

        string respuestaIns = "";
        int cont = 0;

        foreach (var instrumento in instrumentos)
        {
            var instrumentoResponse = apiClient.RegistrarInstrumento(instrumento).Result;
            Console.WriteLine($"Respuesta Instrumento: {instrumentoResponse}");
            respuestaIns += instrumentoResponse;
        cont++;
        }


    var responseInstrumentos = apiClient.ConsultarInstrumento().Result;
    var jsonInstrumento = responseInstrumentos.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    var LosIdinstrumentos = JsonConvert.DeserializeObject<List<InstrumentoDTO>>(jsonInstrumento);


    IdsInstrumentos = LosIdinstrumentos.TakeLast(cont).Select(i => i.id).ToList();
    //IdsInstrumentos = instrumentos.TakeLast(cont).Select(i => i.id).ToList();


    Console.WriteLine("Últimos IDsIntrumentos:");
    foreach (var id in IdsInstrumentos)
    {
        Console.WriteLine($"IdIntrumentos: {id}");
    }


}

void AgregaNorma()
{

    var normas = new List<NormaDTO>
    {
        new NormaDTO
        {
            id = "",
            clave = "CFE E1234-78",
            nombre = "CFE E1234-78",
            edicion = "2024",
            estatus = "VIGENTE",
            esCFE = true,
        }

     };

    string respuestaIns = "";
    int cont = 0;

    foreach (var norma in normas)
    {
        var normaResponse = apiClient.RegistrarNorma(norma);
        Console.WriteLine($"Respuesta norma: {normaResponse}");
        respuestaIns += normaResponse;
        cont++;
    }

    var responseNorma = apiClient.ConsultarNormas().Result;
    var jsonNorma = responseNorma.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    var LasNormas = JsonConvert.DeserializeObject<List<NormaDTO>>(jsonNorma);

    IdNorma = LasNormas.TakeLast(cont).Select(i => i.id).ToList();

    //IdNorma = normas.TakeLast(cont).Select(i => i.id).ToList();

    Console.WriteLine("Últimos IDs Normas:");
    foreach (var id in IdNorma)
    {
        Console.WriteLine($"IdNormas: {id}");
    }
}
void AgregaPrototipo()
{

    var prototipos = new List<PrototiposDTO>
    {
        new PrototiposDTO
        {
            id = "",
            numero = "ZX-88L-MOD/2024" + consecutivo,
            fechaEmision = DateTime.Parse("2026-02-09T17:32:28.749Z"),
            fechaVencimiento = DateTime.Parse("2026-10-09T17:32:28.749Z"),
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
            mD5 = "",
            estatus = "VIGENTE",
        }

     };

    string respuestaProt = "";
    int cont = 0;

    foreach (var prototipo in prototipos)
    {
        var prototipoResponse = apiClient.RegistrarPrototipos(prototipo).Result;
        Console.WriteLine($"Respuesta prototipo: {prototipoResponse}");
        respuestaProt += prototipoResponse;
        cont++;
    }

    var responsePrototipos = apiClient.ConsultarPrototipo().Result;
    var jsonPrototipo = responsePrototipos.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    var LosPrototipos = JsonConvert.DeserializeObject<List<PrototiposDTO>>(jsonPrototipo);

    IdPrototipo = LosPrototipos.TakeLast(cont).Select(i => i.id).ToList();
    //IdPrototipo = prototipos.TakeLast(cont).Select(i => i.id).ToList();

    Console.WriteLine("Últimos IDsPrototipos:");
    foreach (var id in IdPrototipo)
    {
        Console.WriteLine($"IdPrototipo: {id}");
    }

}

void AgregaPruebas()
{
    
    var pruebas = new List<PruebaDTO>
    {
        new PruebaDTO
        {
            id = "",
            nombre = "Resistencia eléctrica del conductor (ohm/km)", // "inspeccion Visual",
            estatus = "ACTIVA",
            tipoPrueba = "ACEPTACION",
            tipoResultado = "VALOR_REFERENCIA",
        },
        new PruebaDTO
        {
            id = "",
            nombre = "Espesor de aislamiento (mm)", // "Valor nominal de masa",
            estatus = "ACTIVA",
            tipoPrueba = "ACEPTACION",
            tipoResultado = "VALOR_REFERENCIA",
        },

        new PruebaDTO
        {
            id = "",
            nombre = "Temperatura máxima en carga (°C)", // "Resistividad volumetrica a 20°C",
            estatus = "ACTIVA",
            tipoPrueba = "ACEPTACION",
            tipoResultado = "VALOR_REFERENCIA",
        }
    };

    string respuestaIns = "";
    int cont = 0;
    foreach (var prueba in pruebas)
    {
        var pruebaResponse = apiClient.RegistrarPruebas(prueba).Result;
        Console.WriteLine($"Respuesta Prueba: {pruebaResponse}");
        respuestaIns += pruebaResponse;
        cont++;
    }

    var responsePruebas = apiClient.ConsultarPruebas().Result;
    var jsonPruebas = responsePruebas.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    var LasPruebas = JsonConvert.DeserializeObject<List<PruebaDTO>>(jsonPruebas);

    IdsPruebas = LasPruebas.TakeLast(cont).Select(i => i.id).ToList();
    //IdsPruebas = pruebas.TakeLast(cont).Select(i => i.id).ToList();

    Console.WriteLine("Últimos IDsPruebas:");
    foreach (var id in IdsPruebas)
    {
        Console.WriteLine($"IdPruebas: {id}");
    }

}

void AgregaProducto()
{

    // Lista de productos
    /*IdNorma.Add("6928d1a70c4622cb379589a8");
    IdPrototipo.Add("6928d2c30c4622cb379589a9");
    IdsPruebas.Add("6928d2fc0c4622cb379589aa");
    IdsPruebas.Add("6928d2ff0c4622cb379589ab");
    IdsPruebas.Add("6928d3010c4622cb379589ac");*/


    var productos = new List<ProductosDTO>

    {
        new ProductosDTO
        {
            id = "",
            codigoFabricante = "J007" + consecutivo,
            descripcion = "CABLE DE COBRE TIPO THHN 1/0 AWG",
            descripcionCorta = "CABLE THW AWG 12",
            tipoFabricacion = "LOTE",
            unidad = "kg",  // segun como este en las partidas///////////////////
            norma = IdNorma[0], // "68c317cddc75889685df3aba",
            prototipo = IdPrototipo[0],// "68c3182ddc75889685df3abd",
            estatus = "ACTIVO",
            Pruebas = new List<string>() // Inicializamos vacío
        }
    };


    // Ahora llenamos la propiedad Pruebas con foreach
    foreach (var pruebaId in IdsPruebas)
    {
        productos[0].Pruebas.Add(pruebaId);
    }

    // Mostrar el resultado
    foreach (var producto in productos)
    {
        Console.WriteLine($"Producto: {producto.codigoFabricante}");
        Console.WriteLine("Pruebas:");
        foreach (var prueba in producto.Pruebas)
        {
            Console.WriteLine($" - {prueba}");
        }

    }


    string respuestaProdc = "";
    int cont = 0;

    foreach (var producto in productos)
    {
        var productoResponse = apiClient.RegistrarProductos(producto).Result;
        Console.WriteLine($"Respuesta produto: {productoResponse}");
        respuestaProdc += productoResponse;
        cont++;
    }


    var responseProductos = apiClient.ConsultarProducto().Result;
    var jsonProducto = responseProductos.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    var LosProductos = JsonConvert.DeserializeObject<List<ProductosConsultaDTO>>(jsonProducto);

    IdProducto = LosProductos.TakeLast(cont).Select(i => i.id).ToList();
    //IdProducto = productos.TakeLast(cont).Select(i => i.id).ToList();

    Console.WriteLine("Últimos IDsProductos:");
    foreach (var id in IdProducto)
    {
        Console.WriteLine($"IdsProductos: {id}");
    } 

}

void AgregaValoresDeReferencia()
{
    /*IdsInstrumentos.Add("6928d13e0c4622cb379589a6");
    IdsInstrumentos.Add("6928d1650c4622cb379589a7");
    IdNorma.Add("6928d1a70c4622cb379589a8");
    IdPrototipo.Add("6928d2c30c4622cb379589a9");
    IdsPruebas.Add("6928d2fc0c4622cb379589aa");
    IdsPruebas.Add("6928d2ff0c4622cb379589ab");
    IdsPruebas.Add("6928d3010c4622cb379589ac");
    IdProducto.Add("6928e9d50c4622cb37958a09");*/

    var valoresReferencia = new List<ValorRefDTO>();       

    valoresReferencia.Add(new ValorRefDTO
    {
        id = "",
        idProducto = IdProducto[0], // Primer producto            
        idPrueba = IdsPruebas[0],   // Aquí asignamos el idPrueba del ciclo            
        valor = 0,
        valor2 = (decimal)0.30,
        unidad = "ohm/km",
        comparacion = "RANGO"

    });


    valoresReferencia.Add(new ValorRefDTO
    {
        id = "",
        idProducto = IdProducto[0], // Primer producto            
        idPrueba = IdsPruebas[1],   // Aquí asignamos el idPrueba del ciclo            
        valor = (decimal)1.12,
        valor2 = (decimal)1.40,
        unidad = "mm",
        comparacion = "RANGO"

    });

    valoresReferencia.Add(new ValorRefDTO
    {
        id = "",
        idProducto = IdProducto[0], // Primer producto            
        idPrueba = IdsPruebas[2],   // Aquí asignamos el idPrueba del ciclo            
        valor = 0,
        valor2 = 90,
        unidad = "°C",
        comparacion = "RANGO"

    });

    // Ahora llamamos al API para cada valorReferencia    
    string respuestaValorRef = "";  
    int cont = 0;
    foreach (var valorRef in valoresReferencia)    
    {    
        var valorRefResponse = apiClient.RegistrarValorReferencia(valorRef).Result;        
        Console.WriteLine($"Respuesta Prueba: {valorRefResponse}");

        respuestaValorRef += valorRefResponse;
        cont++;

        // Guardamos el ID que nos regrese la API (suponiendo que actualiza valorRef.id)        
        IdsValoresReferencia.Add(valorRef.id);        
        respuestaValorRef += valorRefResponse;        
    }
    // Mostrar los IDs generados
    // 
    var responseValoresRef = apiClient.ConsultarValorReferencia().Result;
    var jsonValoreRef = responseValoresRef.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    var LosValoresRef = JsonConvert.DeserializeObject<List<ValorRefDTO>>(jsonValoreRef);

    IdsValoresReferencia = LosValoresRef.TakeLast(cont).Select(i => i.id).ToList();    
    
    foreach (var id in IdsValoresReferencia)    
    {
        Console.WriteLine($"IdValoresRef: {id}");
    }

    
}

void AgregaContratoCFE()
{
    /*IdsInstrumentos.Add("6928d13e0c4622cb379589a6");
    IdsInstrumentos.Add("6928d1650c4622cb379589a7");
    IdNorma.Add("6928d1a70c4622cb379589a8");
    IdPrototipo.Add("6928d2c30c4622cb379589a9");
    IdsPruebas.Add("6928d2fc0c4622cb379589aa");
    IdsPruebas.Add("6928d2ff0c4622cb379589ab");
    IdsPruebas.Add("6928d3010c4622cb379589ac");
    IdProducto.Add("6928e9d50c4622cb37958a09");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0a");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0b");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0c");*/

    var contratosCFE = new List<ContratosDTO>
    {
        new ContratosDTO
        {
            Tipo = "ContratoCFE",
            id = "",
            tipoContrato = "ContratoCFE",
            noContrato = "88001295" + consecutivo,
            estatus = "ACTIVO",
            detalleContrato = new List<DetalleContratoDTO>

            {
                new DetalleContratoDTO
                {
                    partidaContrato = "115",
                    descripcionAviso = "CABLE THHN-CU 1/0 AWG",
                    areaDestinoCFE = "CFE",
                    cantidad = 620,
                    unidad = "kg",
                    importeTotal = 210800
                },
                new DetalleContratoDTO
                {
                    partidaContrato = "231",
                    descripcionAviso = "CABLE THHN-CU 1/0 AWG",
                    areaDestinoCFE = "CFE",
                    cantidad = 850,
                    unidad = "kg",
                    importeTotal = 289500
                }
            },
            urlArchivo = "https://www.uv.es/fragar/html/pdf/html11.pdf",
            mD5 = "",
            fechaEntregaCFE = DateTime.Parse("2026-09-11T17:32:28.749Z"),
        }

     };

    string respuestaContrato = "";
    int cont = 0;

    foreach (var contrato in contratosCFE)
    {
        var contratoResponse = apiClientPreparacion.RegistrarContratos(contrato).Result;

        var jsonContrato = contratoResponse.Content.ReadAsStringAsync().Result;
        // Deserializamos al tipo correcto (por ejemplo, OrdenFabricacionDTO)
        //var responseContratosCFE = JsonConvert.DeserializeObject<ContratosDTO>(jsonContrato);
        IdContratoCFE.Add(jsonContrato);

        Console.WriteLine($"Respuesta contrato: {contratoResponse}");
        respuestaContrato += contratoResponse;
        cont++;
    }

    //var responseContratosCFE = apiClientPreparacion.ConsultarContratos().Result;
    //var jsonContratosCFE = responseContratosCFE.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    //var LosContratos = JsonConvert.DeserializeObject<List<ContratosDTO>>(jsonContratosCFE);

    //IdContratoCFE = LosContratos.TakeLast(cont).Select(i => i.id).ToList();
    //IdContratoCFE = contratosCFE.TakeLast(cont).Select(i => i.id).ToList();

    Console.WriteLine("Últimos IDs Contratos:");
    foreach (var id in IdContratoCFE)
    {
        Console.WriteLine($"IdContratoCFE: {id}");
    }

}


void AgregaContratoParticualar()
{
    /*IdsInstrumentos.Add("6928d13e0c4622cb379589a6");
    IdsInstrumentos.Add("6928d1650c4622cb379589a7");
    IdNorma.Add("6928d1a70c4622cb379589a8");
    IdPrototipo.Add("6928d2c30c4622cb379589a9");
    IdsPruebas.Add("6928d2fc0c4622cb379589aa");
    IdsPruebas.Add("6928d2ff0c4622cb379589ab");
    IdsPruebas.Add("6928d3010c4622cb379589ac");
    IdProducto.Add("6928e9d50c4622cb37958a09");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0a");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0b");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0c");
    IdContratoCFE.Add("6928f36f0c4622cb37958a55");*/

    var contratosParticualar = new List<ContratosDTO>
    {
        new ContratosDTO
        {
            Tipo = "ContratoParticular",
            id = "",
            tipoContrato = "ContratoParticular",
            noContrato = "9100026917" + consecutivo,
            estatus = "ACTIVO",
            detalleContrato = new List<DetalleContratoDTO>

            {
                new DetalleContratoDTO
                {
                    partidaContrato = "1",
                    descripcionAviso = "CABLE THHN-CU 1/0 AWG",
                    cantidad = 1320,
                    unidad = "kg",
                    importeTotal = 282055
                }
            }
        }

     };

    string respuestaContrato = "";
    int cont = 0;

    foreach (var contrato in contratosParticualar)
    {
        var contratoResponse = apiClientPreparacion.RegistrarContratos(contrato).Result;

        var jsonContrato = contratoResponse.Content.ReadAsStringAsync().Result;
        IdContratoParticualar.Add(jsonContrato);
        Console.WriteLine($"Respuesta contrato: {contratoResponse}");
        respuestaContrato += contratoResponse;
        cont++;
    }

    //var responseContratosPart = apiClientPreparacion.ConsultarContratos().Result;
    //var jsonContratosPart = responseContratosPart.Content.ReadAsStringAsync().Result; // ✅ Aquí usamos Content
    //var LosContratos = JsonConvert.DeserializeObject<List<ContratosDTO>>(jsonContratosPart);

    //IdContratoParticualar = LosContratos.TakeLast(cont).Select(i => i.id).ToList();
    //IdContratoParticualar = contratosParticualar.TakeLast(cont).Select(i => i.id).ToList();

    Console.WriteLine("Últimos IDs ContratosParticular:");
    foreach (var id in IdContratoParticualar)
    {
        Console.WriteLine($"IdContratoParticular: {id}");
    }

}

void AgregaOrdenDeFabricacion()
{



    var OrdenesFabricacion = new List<OrdenFabricacionDTO>
    {
        new OrdenFabricacionDTO
        {
            id = "",
            claveOrdenFabricacion = "OF-2025-CFE-7781" + consecutivo,
            loteFabricacion = "CU00988123" + consecutivo,
            idProducto = IdProducto[0], //  "68c06ed2c55c585f0beafeb5",
            detalleFabricacion = new List<DetalleFabricacionDTO>

            {
                new DetalleFabricacionDTO
                {
                    contratoId = IdContratoCFE[0],// "68c08693c55c585f0beaff05",
                    tipoContrato = "ContratoCFE",
                    partidaContratoId = "115",
                    descripcionPartida = "CABLE THHN-CU 1/0 AWG",
                    unidad = "kg",
                    cantidadOriginalContrato = 620,
                    cantidadAFabricar = 620
                },
                new DetalleFabricacionDTO
                {
                    contratoId = IdContratoCFE[0],// "68c08693c55c585f0beaff05",
                    tipoContrato = "ContratoCFE",
                    partidaContratoId = "231",
                    descripcionPartida = "CABLE THHN-CU 1/0 AWG",
                    unidad = "kg",
                    cantidadOriginalContrato = 850,
                    cantidadAFabricar = 850
                },
                new DetalleFabricacionDTO
                {
                    contratoId = IdContratoParticualar[0], // "68c08836c55c585f0beaff1a",
                    tipoContrato = "ContratoParticular",
                    partidaContratoId = "1",
                    descripcionPartida = "CABLE THHN-CU 1/0 AWG",
                    unidad = "kg",
                    cantidadOriginalContrato = 1320,
                    cantidadAFabricar = 1320
                }

            }
        }

     };

    //string respuestaOrdenFab = "";
    int cont = 0;

    foreach (var orden in OrdenesFabricacion)
    {
        var OrdenesResponse = apiClientPreparacion.RegistrarOrdenFabricacion(orden).Result;

        var jsonOrden = OrdenesResponse.Content.ReadAsStringAsync().Result;
        // Deserializamos al tipo correcto (por ejemplo, OrdenFabricacionDTO)
        //var respuestaOrdenFab = JsonConvert.DeserializeObject<OrdenFabricacionConsultaDTO>(jsonOrden);


        // Deserializamos como lista
        var ordenes = JsonConvert.DeserializeObject<List<OrdenFabricacionDTO>>(jsonOrden);

        // Obtener el primer ID (o todos)
        var idOrden = ordenes[0].id;

        //Console.WriteLine($"ID de la orden: {idOrden}");

        // Si quieres todos los IDs:
        IdOrdenesFab.Add(idOrden); // ✅ Correcto
        //IdOrdenesFab = idOrden;// ordenes.Select(o => o.id).ToList();


        //IdOrdenesFab.Add(jsonOrden);
        Console.WriteLine($"Respuesta ordenes de fabricacion: {OrdenesResponse}");
        //respuestaOrdenFab += OrdenesResponse;
        cont++;
    }

    Console.WriteLine("Últimos IDs Ordenes fab:");
    foreach (var id in IdOrdenesFab)
    {
        Console.WriteLine($"IdOrdenFab: {id}");
    }

}

void AgregaExpedientes()
{
    /*IdsInstrumentos.Add("6928d13e0c4622cb379589a6");
    IdsInstrumentos.Add("6928d1650c4622cb379589a7");
    IdNorma.Add("6928d1a70c4622cb379589a8");
    IdPrototipo.Add("6928d2c30c4622cb379589a9");
    IdsPruebas.Add("6928d2fc0c4622cb379589aa");
    IdsPruebas.Add("6928d2ff0c4622cb379589ab");
    IdsPruebas.Add("6928d3010c4622cb379589ac");
    IdProducto.Add("6928e9d50c4622cb37958a09");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0a");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0b");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0c");
    IdContratoCFE.Add("6928f36f0c4622cb37958a55");
    IdContratoParticualar.Add("6928f71e0c4622cb37958a58");
    IdOrdenesFab.Add("6929b0189302f09173dfa48e");*/

    var expedintes = new List<ExpedientePruebaDTO>
    {
        new ExpedientePruebaDTO
        {
        id = "",
        claveExpediente = claExpediente + consecutivo,
        ordenFabricacion = IdOrdenesFab[0], // "68c08fe3c55c585f0beaff37",
        cantidadMuestras = 3,
        maximoRechazos = 1,
        muestras = new List<string> { "C-01987-01", "C-01987-02", "C-01987-03" }
        }

     };

    //string respuestaExpediente = "";
    int cont = 0;

    foreach (var expediente in expedintes)
    {
        var expedienteResponse = apiClientPreparacion.RegistrarExpedientePruebas(expediente).Result;
        var jsonExpediente = expedienteResponse.Content.ReadAsStringAsync().Result;

        var expedienteList = JsonConvert.DeserializeObject<List<ExpedientePruebaConsultaDTO>>(jsonExpediente);

        var idEpe = expedienteList[0].id;
        IdExpediente.Add(idEpe);
 
        //var respuestaExpediente = JsonConvert.DeserializeObject<ContratosResponseDTO>(jsonExpediente);

        //IdExpediente.Add(respuestaExpediente.id);
        Console.WriteLine($"Respuesta ordenes de fabricacion: {expedienteResponse}");
    }

    //IdExpediente = expedintes.TakeLast(cont).Select(i => i.id).ToList();

    Console.WriteLine("Últimos IDs Expedientes:");
    foreach (var id in IdExpediente)
    {
        Console.WriteLine($"IdExpediente: {id}");
    }

}

void AgregaResultadoPrueba()
{
    /*IdsInstrumentos.Add("6928d13e0c4622cb379589a6");
    IdsInstrumentos.Add("6928d1650c4622cb379589a7");
    IdNorma.Add("6928d1a70c4622cb379589a8");
    IdPrototipo.Add("6928d2c30c4622cb379589a9");
    IdsPruebas.Add("6928d2fc0c4622cb379589aa");
    IdsPruebas.Add("6928d2ff0c4622cb379589ab");
    IdsPruebas.Add("6928d3010c4622cb379589ac");
    IdProducto.Add("6928e9d50c4622cb37958a09");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0a");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0b");
    IdsValoresReferencia.Add("6928e9e70c4622cb37958a0c");
    IdContratoCFE.Add("6928f36f0c4622cb37958a55");
    IdContratoParticualar.Add("6928f71e0c4622cb37958a58");
    IdOrdenesFab.Add("6929b0189302f09173dfa48e");
    IdExpediente.Add("6929d2159302f09173dfa49d");*/
    var muestra = new List<string>();
    muestra.Add("C-01987-01");
    muestra.Add("C-01987-02");
    muestra.Add("C-01987-03");


    var claveExpe = new List<string>();
    claveExpe.Add(claExpediente);


    //var ResultadosPruebas = new List<ResultadoPruebasDTO>
    //{

    //Muestra C-01987-01
    //Resistividad electrica    
    ResultadoPruebasDTO Restultado = new ResultadoPruebasDTO        
    {     
        //
        idPrueba = IdsPruebas[0],// "68c06badc55c585f0beafe95",            
        idValorReferencia = IdsValoresReferencia[0], // "68c07104c55c585f0beafeda",        
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),  
        operadorPrueba = "COLVERAC",        
        idInstrumentoMedicion = IdsInstrumentos[2], // "68c06579c55c585f0beafe44",        
        valorMedido = "0.28",        
        resultado = "SATISFACTORIO",        
        numeroIntento = 1,        
    };
    
    var resultadoPrueResponse = apiClientPruebas.RegistrarResultadoPruebas(Restultado, claveExpe[0] + consecutivo, muestra[0]).Result;

    Console.WriteLine($"Respuesta Respuesta: {resultadoPrueResponse}");

    //Espesor aislamiento
    ResultadoPruebasDTO Restultado2 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[1],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[1], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[0], // "68c06579c55c585f0beafe44",
        valorMedido = "1.20",
        resultado = "SATISFACTORIO",
        numeroIntento = 1,
    };
    var resultadoPrueResponse2 = apiClientPruebas.RegistrarResultadoPruebas(Restultado2, claveExpe[0] + consecutivo, muestra[0]).Result;
    Console.WriteLine($"Respuesta Respuesta 2: {resultadoPrueResponse2}");

    //Temperatura maxima
    ResultadoPruebasDTO Restultado3 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[2],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[2], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[1], // "68c06579c55c585f0beafe44",
        valorMedido = "85",
        resultado = "SATISFACTORIO",
        numeroIntento = 1,
    };

    ////////////////

    var resultadoPrueResponse3 = apiClientPruebas.RegistrarResultadoPruebas(Restultado3, claveExpe[0] + consecutivo, muestra[0]).Result;
    Console.WriteLine($"Respuesta Respuesta 3: {resultadoPrueResponse3}");

    //Muestra C-01987-02
    //Resistividad electrica 
    ResultadoPruebasDTO Restultado4 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[0],// "68c06badc55c585f0beafe95",            
        idValorReferencia = IdsValoresReferencia[0], // "68c07104c55c585f0beafeda",        
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[2], // "68c06579c55c585f0beafe44",        
        valorMedido = "0.35",
        resultado = "NO SATISFACTORIO",
        numeroIntento = 1,
    };

    var resultadoPrueResponse4 = apiClientPruebas.RegistrarResultadoPruebas(Restultado4, claveExpe[0] + consecutivo, muestra[1]).Result;
    Console.WriteLine($"Respuesta Respuesta 4: {resultadoPrueResponse4}");

    //Resistividad electrica 
    ResultadoPruebasDTO Restultado5 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[0],// "68c06badc55c585f0beafe95",            
        idValorReferencia = IdsValoresReferencia[0], // "68c07104c55c585f0beafeda",        
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[2], // "68c06579c55c585f0beafe44",        
        valorMedido = "0.31",
        resultado = "NO SATISFACTORIO",
        numeroIntento = 2,
    };

    var resultadoPrueResponse5 = apiClientPruebas.RegistrarResultadoPruebas(Restultado5, claveExpe[0] + consecutivo, muestra[1]).Result;
    Console.WriteLine($"Respuesta Respuesta 5: {resultadoPrueResponse5}");

    //Resistividad electrica 
    ResultadoPruebasDTO Restultado6 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[0],// "68c06badc55c585f0beafe95",            
        idValorReferencia = IdsValoresReferencia[0], // "68c07104c55c585f0beafeda",        
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[2], // "68c06579c55c585f0beafe44",        
        valorMedido = "0.29",
        resultado = "SATISFACTORIO",
        numeroIntento = 3,
    };

    var resultadoPrueResponse6 = apiClientPruebas.RegistrarResultadoPruebas(Restultado6, claveExpe[0] + consecutivo, muestra[1]).Result;
    Console.WriteLine($"Respuesta Respuesta 6: {resultadoPrueResponse6}");

    //Espesor aislamiento
    ResultadoPruebasDTO Restultado7 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[1],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[1], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[0], // "68c06579c55c585f0beafe44",
        valorMedido = "1.42",
        resultado = "NO SATISFACTORIO",
        numeroIntento = 1,
    };

    var resultadoPrueResponse7 = apiClientPruebas.RegistrarResultadoPruebas(Restultado7, claveExpe[0] + consecutivo, muestra[1]).Result;
    Console.WriteLine($"Respuesta Respuesta 7: {resultadoPrueResponse7}");

    
    //Espesor aislamiento
    ResultadoPruebasDTO Restultado8 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[1],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[1], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[0], // "68c06579c55c585f0beafe44",
        valorMedido = "1.33",
        resultado = "SATISFACTORIO",
        numeroIntento = 2,
    };

    var resultadoPrueResponse8 = apiClientPruebas.RegistrarResultadoPruebas(Restultado8, claveExpe[0] + consecutivo, muestra[1]).Result;
    Console.WriteLine($"Respuesta Respuesta 8: {resultadoPrueResponse8}");

   
    //Temperatura maxima
    ResultadoPruebasDTO Restultado9 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[2],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[2], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[1], // "68c06579c55c585f0beafe44",
        valorMedido = "88",
        resultado = "SATISFACTORIO",
        numeroIntento = 1,
    };

    var resultadoPrueResponse9 = apiClientPruebas.RegistrarResultadoPruebas(Restultado9, claveExpe[0] + consecutivo, muestra[1]).Result;
    Console.WriteLine($"Respuesta Respuesta 9: {resultadoPrueResponse9}");

    //Muestra c-01987-03
    //Resistencia eléctrica
    ResultadoPruebasDTO Restultado10 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[0],// "68c06badc55c585f0beafe95",            
        idValorReferencia = IdsValoresReferencia[0], // "68c07104c55c585f0beafeda",        
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[2], // "68c06579c55c585f0beafe44",        
        valorMedido = "0.27",
        resultado = "SATISFACTORIO",
        numeroIntento = 1,
    };

    var resultadoPrueResponse10 = apiClientPruebas.RegistrarResultadoPruebas(Restultado10, claveExpe[0] + consecutivo, muestra[2]).Result;
    Console.WriteLine($"Respuesta Respuesta 10: {resultadoPrueResponse10}");

    //Espesor aislamiento
    ResultadoPruebasDTO Restultado11 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[1],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[1], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[0], // "68c06579c55c585f0beafe44",
        valorMedido = "1.10",
        resultado = "NO SATISFACTORIO",
        numeroIntento = 1,
    };

    var resultadoPrueResponse11 = apiClientPruebas.RegistrarResultadoPruebas(Restultado11, claveExpe[0] + consecutivo, muestra[2]).Result;
    Console.WriteLine($"Respuesta Respuesta 11: {resultadoPrueResponse11}");

    //Espesor aislamiento
    ResultadoPruebasDTO Restultado12 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[1],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[1], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[0], // "68c06579c55c585f0beafe44",
        valorMedido = "1.18",
        resultado = "SATISFACTORIO",
        numeroIntento = 2,
    };

    var resultadoPrueResponse12 = apiClientPruebas.RegistrarResultadoPruebas(Restultado12, claveExpe[0] + consecutivo, muestra[2]).Result;
    Console.WriteLine($"Respuesta Respuesta 12: {resultadoPrueResponse12}");


    //Temperatura maxima
    ResultadoPruebasDTO Restultado13 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[2],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[2], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[1], // "68c06579c55c585f0beafe44",
        valorMedido = "92",
        resultado = "NO SATISFACTORIO",
        numeroIntento = 1,
    };

    var resultadoPrueResponse13 = apiClientPruebas.RegistrarResultadoPruebas(Restultado13, claveExpe[0] + consecutivo, muestra[2]).Result;
    Console.WriteLine($"Respuesta Respuesta 13: {resultadoPrueResponse13}");

    //Temperatura maxima
    ResultadoPruebasDTO Restultado14 = new ResultadoPruebasDTO
    {
        idPrueba = IdsPruebas[2],// "68c06badc55c585f0beafe95",
        idValorReferencia = IdsValoresReferencia[2], // "68c07104c55c585f0beafeda",
        fechaPrueba = DateTime.Parse("2026-03-09T17:32:28.749Z"),
        operadorPrueba = "COLVERAC",
        idInstrumentoMedicion = IdsInstrumentos[1], // "68c06579c55c585f0beafe44",
        valorMedido = "89",
        resultado = "SATISFACTORIO",
        numeroIntento = 2,
    };

    var resultadoPrueResponse14 = apiClientPruebas.RegistrarResultadoPruebas(Restultado14, claveExpe[0] + consecutivo, muestra[2]).Result;
    Console.WriteLine($"Respuesta Respuesta 14: {resultadoPrueResponse14}");

    // Puedes agregar más instrumentos aquí
}

void ValidaExpediente()
{
    var responseValidarExpediente = apiClientPruebas.ValidarExpedientePruebas(claExpediente + consecutivo).Result;
    Console.WriteLine($"Valida expediente: {responseValidarExpediente}");
}

void TerminaExpediente()
{
    var responseTerminaExpediente = apiClientPruebas.TerminaPruebaExpediente(claExpediente + consecutivo).Result;
    Console.WriteLine($"Valida expediente: {responseTerminaExpediente}");
}

void PrevioAvisosPrueba()
{
    var responseCreaAvisoDePruebas = apiClientLiberacion.PrevioAvisosPrueba(claExpediente + consecutivo).Result;
    Console.WriteLine($"Crea previo aviso de pruebas: {responseCreaAvisoDePruebas}");


    // Leer el body como string
    var body = responseCreaAvisoDePruebas.Content.ReadAsStringAsync().Result;


    // Dar formato JSON
    var formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(body), Formatting.Indented);

    // Imprimir el JSON formateado
    Console.WriteLine(formattedJson);


}


void CreaElAvisoDePruebas()
{
    var responseCreaAvisoDePruebas = apiClientLiberacion.CrearAvisoDePrueba(claExpediente + consecutivo).Result;
    Console.WriteLine($"Crea el aviso de pruebas expediente: {responseCreaAvisoDePruebas}");

}








/*var resultadoPruebasResponse = apiClientPruebas.RegistrarResultadoPruebas(new ResultadoPruebasDTO
{
    expediente = IdExpediente[0], // "68c198379d5906a9d9911d6a",
    muestra = "MI-EXP-CIDEC-2025",
    idPrueba = "68c06badc55c585f0beafe95",
    idValorReferencia = "68c07104c55c585f0beafeda",
    fechaPrueba = DateTime.Parse("2025-09-09T17:32:28.749Z"),
    operadorPrueba = "COLVERAC",
    idInstrumentoMedicion = "68c06579c55c585f0beafe44",
    valorMedido = 0,
    resultado = "SATISFACTORIO",
    numeroIntento = 1,



});
Console.WriteLine($"Respuesta del expediente prueba: {resultadoPruebasResponse}");
respuesta += resultadoPruebasResponse;*/









Console.WriteLine("Proceso finalizado.");
