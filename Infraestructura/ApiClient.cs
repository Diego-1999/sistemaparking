using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    //clase para llevar y traer paquetes por internet
     public class ApiClient
    {
        
        private readonly HttpClient _httpClient;

        // Constructor
        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.Timeout = TimeSpan.FromSeconds(30); // Se Configura el tiempo que tiene que durar
        }

        //metodo que se encarga de traer los paquetes
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
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("La solicitud excedió el tiempo de espera configurado.");
            }
        }

        // Método POST con contenido JSON para llevar los paquetes
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
