using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
     public class ApiClient
    {
        private readonly HttpClient _httpClient;

        // Constructor: puedes inyectar HttpClient desde fuera 
        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.Timeout = TimeSpan.FromSeconds(30); // Configuración de timeout
        }

        // Método genérico para GET
        public async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Aquí puedes loguear el error o lanzar una excepción personalizada
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("La solicitud excedió el tiempo de espera configurado.");
            }
        }

        // Método genérico para POST con contenido JSON
        public async Task<string> PostAsync(string url, HttpContent content)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error en POST: {ex.Message}", ex);
            }
        }

    }
}
