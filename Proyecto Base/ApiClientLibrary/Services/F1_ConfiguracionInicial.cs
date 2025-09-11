using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F1_ConfiguracionInicial
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F1_ConfiguracionInicial/";
        public F1_ConfiguracionInicial()
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

        /// <summary>
        /// Permite cambiar manualmente el token de autorización (ej. para pruebas).
        /// </summary>
        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> RegistrarEstadoSID(EstadoSIDDTO estado)
        {
            var json = JsonSerializer.Serialize(estado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("EstadoSID", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarInstrumento(InstrumentoDTO instrumento)
        {
            var json = JsonSerializer.Serialize(instrumento);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Instrumento", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarPrototipos(PrototiposDTO prototipo)
        {
            var json = JsonSerializer.Serialize(prototipo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Prototipo", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarNorma(NormaDTO norma)
        {
            var json = JsonSerializer.Serialize(norma);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Norma", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarPruebas(PruebaDTO prueba)
        {
            var json = JsonSerializer.Serialize(prueba);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Prueba", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarValorReferencia(ValorRefDTO valorRef)
        {
            var json = JsonSerializer.Serialize(valorRef);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("ValorReferencia", content);
            return response;
        }
        

        public async Task<HttpResponseMessage> RegistrarProductos(ProductosDTO productos)
        {
            var json = JsonSerializer.Serialize(productos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Producto", content);
            return response;
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

        public async Task<HttpResponseMessage> RegistrarResultadoPruebas(ResultadoPruebasDTO resultadoPruebas)
        {
            var json = JsonSerializer.Serialize(resultadoPruebas);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AgregaResultadoPrueba", content);
            return response;
        }

        public async Task<HttpResponseMessage> TerminaPruebaExpediente(TerminaPruebaExpedienteDTO terminaPruebaExpediente)
        {
            var json = JsonSerializer.Serialize(terminaPruebaExpediente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("TerminaPruebasExpediente", content);
            return response;
        }
        

        public async Task<HttpResponseMessage> ConsultarNormas()
        {
            var response = await _httpClient.GetAsync("Norma");
            return response;
        }

        public async Task<HttpResponseMessage> ConsultarInstrumento()
        {
            var response = await _httpClient.GetAsync("Instrumento");
            return response;
        }

        public async Task<HttpResponseMessage> ConsultarPruebas()
        {
            var response = await _httpClient.GetAsync("Prueba");
            return response;
        }


        public async Task<HttpResponseMessage> ConsultarPrototiop()
        {
            var response = await _httpClient.GetAsync("Prototipo");
            return response;
        }

        public async Task<HttpResponseMessage> ActualizarInstrumento(InstrumentoDTO instrumento)
        {
            var json = JsonSerializer.Serialize(instrumento);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("InstrumentoDTO", content);
            return response;
        }
    }
}
