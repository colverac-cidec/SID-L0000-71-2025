using ApiClientLibrary.Services;
using ApiClientLibrary.Models;
using System;
using System.Net.NetworkInformation;

F1_ConfiguracionInicial apiClient = new F1_ConfiguracionInicial();
string respuesta = "";

Console.WriteLine("¿Qué operación POST deseas realizar?");
Console.WriteLine("1. Registrar EstadoSID");
Console.WriteLine("2. Registrar Norma");
Console.WriteLine("3. Registrar Prueba");
Console.WriteLine("4. Registrar Producto");
Console.Write("Selecciona una opción (1-4): ");
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

    case "3":
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

    case "4":
        var productosResponse = await apiClient.RegistrarProductos(new ProductosDTO
        {
            id = "",
            codigoFabricante = "J117",
            descripcion = "CABLE CU (350) - XLP-5-133",
            descripcionCorta = "VENTILADOR P/TRANSFORMADOR",
            tipoFabricacion = "LOTE",
            unidad = "m",
            norma =  "68c06a36c55c585f0beafe79",
            prototipo = "68c06930c55c585f0beafe6a",
            estatus = "ACTIVO",
            Pruebas = new List<string>
           {
               "68c06badc55c585f0beafe95",
               "68c06c53c55c585f0beafea1"
           }


        });
        Console.WriteLine($"Respuesta Prueba: {productosResponse}");
        respuesta += productosResponse;
        break;

    default:
        Console.WriteLine("Opción no válida. Intenta de nuevo.");
        break;
}

Console.WriteLine("Proceso finalizado.");
