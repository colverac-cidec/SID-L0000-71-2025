using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F2_PreparacionFabricacion
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F2_PreparacionFabricacion/";

        public async Task<HttpResponseMessage> ConsultarContratos()
        {

            int pageNumber = 1; // o el número de página que necesites
            int pageSize = 20;  // o el tamaño de página que desees

            var response = await _httpClient.GetAsync($"Contratos?pageNumber={pageNumber}&pageSize={pageSize}");
            //var response = await _httpClient.GetAsync("Contratos");
            return response;
        }

        public F2_PreparacionFabricacion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{_configuration["ApiSettings:BaseUrl"]}{_basePath}")
            };

            var token = _configuration["ApiSettings:Token"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<HttpResponseMessage> RegistrarContratos(ContratosDTO contratos)
        {
            var json = JsonSerializer.Serialize(contratos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Contratos", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarOrdenFabricacion(OrdenFabricacionDTO ordenFabricacion)
        {
            var json = JsonSerializer.Serialize(ordenFabricacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("OrdenFabricacion", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarExpedientePruebas(ExpedientePruebaDTO expedientePrueba)
        {
            var json = JsonSerializer.Serialize(expedientePrueba);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("ExpedientePruebas", content);
            return response;
        }

        public async Task<HttpResponseMessage> ConsultarOrdenFabricacion(string OrdenDeFabricacion)
        {
            var response = await _httpClient.GetAsync("OrdenFabricacion"+"/" + OrdenDeFabricacion);
 
            return response;
        }

        public async Task<HttpResponseMessage> ConsultarExpedientePruebas(string expediente)
        {
            var response = await _httpClient.GetAsync("ExpedientePruebas" + "/" + expediente);

            return response;
        }


    }
}
