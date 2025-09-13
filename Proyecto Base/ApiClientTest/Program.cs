using ApiClientLibrary.Services;
using ApiClientLibrary.Models;
using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Newtonsoft.Json;

F1_ConfiguracionInicial apiClient = new F1_ConfiguracionInicial();
F2_PreparacionFabricacion apiClientPreparacion = new F2_PreparacionFabricacion();
F3_Pruebas apiClientPruebas = new F3_Pruebas();
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
Console.Write("Selecciona una opción (1-22): ");

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
            nombre = "micro-ohmetro digital ",
            numeroSerie = "TUG098722",
            fechaCalibracion = DateTime.Parse("2025-09-11T17:32:28.749Z"),
            fechaVencimientoCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            urlArchivo = "http://10.44.6.50/sid_capacitacion/swagger/index.html",
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
            numero = "K311D-24-E/4951",
            fechaEmision = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            fechaVencimiento = DateTime.Parse("2025-10-09T17:32:28.749Z"),
            urlArchivo = "http://10.44.6.50/sid_capacitacion/swagger/index.html",
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
            urlArchivo = "http://10.44.6.50/sid_capacitacion/swagger/index.html",
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

    case "11":
        var resultadoPruebasResponse = await apiClientPruebas.RegistrarResultadoPruebas(new ResultadoPruebasDTO
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
        var resultadoTerminaPruebaExpedienteResponse = await apiClientPruebas.TerminaPruebaExpediente(new TerminaPruebaExpedienteDTO
        {
            Expediente = "MI-EXP-CIDEC-2025",

        });
        Console.WriteLine($"Respuesta del expediente prueba: {resultadoTerminaPruebaExpedienteResponse}");
        respuesta += resultadoTerminaPruebaExpedienteResponse;
        break;

    case "13":
        var instrumentoActResponse = await apiClient.ActualizarInstrumento(new InstrumentoDTO
        {
            id = "68c06579c55c585f0beafe44",
            nombre = "Vernier V-022",
            numeroSerie = "V-022",
            fechaCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            fechaVencimientoCalibracion = DateTime.Parse("2025-09-09T17:32:28.749Z"),
            urlArchivo = "https://www.cenam.mx/publicaciones/descargas/PDFFiles/usodecertificados.pdf",
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
        var responsePrototipo = await apiClient.ConsultarPrototiop();

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
            var Productos = JsonConvert.DeserializeObject<List<ProductosDTO>>(jsonProducto);

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
                Console.WriteLine($"Pruebas: {producto.Pruebas}");
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

    

    default:
        Console.WriteLine("Opción no válida. Intenta de nuevo.");
        break;
}

Console.WriteLine("Proceso finalizado.");
