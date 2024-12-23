using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

public class TransbankService
{
    private static HttpClient _httpClient;

    public TransbankService()
    {

    }
    public static async Task CreateTransaction()
    {
        // Configurar el HttpClient con BaseAddress
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:7000/") // Base address de la API
        };

        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        // Preparamos los datos que vamos a enviar
        var transactionData = new
        {
            buy_order = "ordenCompra12345678",
            session_id = "sesion1234557545",
            amount = 10000,
            return_url = "http://www.comercio.cl/webpay/retorno"
        };

        try
        {
            // Aquí usamos la URL relativa ya que el BaseAddress ya está configurado
            var response = await _httpClient.PostAsync("Transbank/CreateTransaction", null);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Respuesta de Transbank: {responseData}");
            }
            else
            {
                Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al realizar la transacción: {ex.Message}");
        }
    }    

    // Función personalizada para validar certificados
    private static bool CustomCertificateValidation(
        HttpRequestMessage requestMessage,
        X509Certificate2 certificate,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors)
    {
        // Aquí puedes realizar la validación personalizada. Por ejemplo:
        // Si quieres aceptar todos los certificados, solo devuelve true
        return true;  // Esto es solo para pruebas. No hacerlo en producción.
    }
}
