using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F3_Pruebas
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F3_Pruebas/";

        public F3_Pruebas()
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

        public async Task<HttpResponseMessage> PruebasNoSatisfactorias(string Expediente)
        {
            var response = await _httpClient.GetAsync("PruebasNoSatisfactorias" + "/" + Expediente);
            return response;
        }

    }
}
