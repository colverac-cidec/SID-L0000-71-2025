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

        public async Task<HttpResponseMessage> RegistrarResultadoPruebas(ResultadoPruebasDTO resultadoPruebas, string ClaveExpedinete, string Muestra)
        {
            var json = JsonSerializer.Serialize(resultadoPruebas);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string url = $"AgregaResultadoPrueba?expediente={Uri.EscapeDataString(ClaveExpedinete)}&muestra={Uri.EscapeDataString(Muestra)}";
            var response = await _httpClient.PutAsync(url, content);
            return response;

            //var response = await _httpClient.PutAsync("AgregaResultadoPrueba", content);
            //return response;
        }

        public async Task<HttpResponseMessage> ValidarExpedientePruebas(string strExpedientePruebas)
        {
            using var httpClient = new HttpClient();
            var response = await _httpClient.GetAsync("ValidacionExpediente/" + strExpedientePruebas);
            return response;
        }

        public async Task<HttpResponseMessage> TerminaPruebaExpediente(string strExpedientePruebas)
        {
            var json = JsonSerializer.Serialize(strExpedientePruebas);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("TerminarPruebasExpediente/" + strExpedientePruebas, content);
            return response;
        }

        public async Task<HttpResponseMessage> ConsulaExpediente(string strExpedientePruebas)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("ConsulaExpediente/" + strExpedientePruebas, content);

            return response;
        }

    }
}
