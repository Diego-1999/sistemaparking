using Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text.Json;


namespace MiSistema.Negocio
{
    public class ParkingService
    {
        private readonly ApiClient _apiClient;

        public ParkingService(ApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public async Task ProcesarDatosAsync()
        {
            string url = "https://jsonplaceholder.typicode.com/posts/1";
            string jsonData = await _apiClient.GetAsync(url);

            if (!string.IsNullOrEmpty(jsonData))
            {
                Console.WriteLine("✅ Conexión exitosa. Datos recibidos:");
                Console.WriteLine(jsonData);
            }
            else
            {
                Console.WriteLine("❌ No se recibieron datos. Puede que la conexión haya fallado.");
            }

            var objeto = JsonSerializer.Deserialize<Post>(jsonData);

            if (objeto != null)
            {
                Console.WriteLine($"Título procesado: {objeto.Title}");
            }
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}

namespace SistemaParking.Negocio
{
    public class ParkingService
    {
        private readonly ApiClient _apiClient;

        public ParkingService(ApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        // Ejemplo de método de negocio que obtiene datos de un servicio externo
        public async Task ProcesarDatosAsync()
        {
            string url = "https://jsonplaceholder.typicode.com/posts/1"; // Endpoint de prueba
            string jsonData = await _apiClient.GetAsync(url);

            // Aquí aplicas reglas de negocio sobre los datos
            var objeto = JsonSerializer.Deserialize<Post>(jsonData);

            // Ejemplo: validación de negocio
            if (string.IsNullOrWhiteSpace(objeto.Title))
            {
                throw new Exception("El título del post no puede estar vacío según las reglas de negocio.");
            }

            Console.WriteLine($"Título procesado: {objeto.Title}");
        }
    }

    // Clase auxiliar para deserializar el JSON
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }

}

