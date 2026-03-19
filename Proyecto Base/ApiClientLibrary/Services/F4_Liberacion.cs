using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F4_Liberacion
    { 
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F4_Liberacion/";

        public F4_Liberacion()
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


        public async Task<HttpResponseMessage> PrevioAvisosPrueba(string strExpedientePruebas)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await _httpClient.GetAsync("PrevioAvisosPrueba/" + strExpedientePruebas);

            return response;
        }

        public async Task<HttpResponseMessage> CrearAvisoDePrueba(string strExpedientePruebas)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("CrearAvisoPrueba/" + strExpedientePruebas, content);

            return response;
        }

    }
}
