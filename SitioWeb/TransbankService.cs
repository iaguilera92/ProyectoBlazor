using Entidades;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Text;

public class TransbankService
{
    private static HttpClient httpClient = new HttpClient();

    public TransbankService()
    {
        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    }
    public static async Task<TransactionResponse> CreateTransaction(TransactionDataTo transactionData)
    {
        var transactionResponse = new TransactionResponse();
        try
        {
            string url = "http://localhost:7000/Transbank/CreateTransaction"; // URL de tu servicio, ajusta según corresponda

            var jsonContent = JsonConvert.SerializeObject(transactionData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Realizar la solicitud POST al servicio WebpayController
            var response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(responseData);
                return transactionResponse;
            }
            else
            {
                return new TransactionResponse
                {
                    Error = true,
                    ErrorMessage = $"Error en la solicitud: {response.ReasonPhrase}"
                };
            }
        }
        catch (Exception ex)
        {
            return new TransactionResponse
            {
                Error = true,
                ErrorMessage = $"Excepción: {ex.Message}"
            };
        }
    }
    private static RestResponse ConsumoServicio(string jsonEntrada, string requestPath, RestClient client)
    {
        try
        {
            var request = new RestRequest(requestPath, Method.Post); // Definimos el tipo de solicitud

            // Añadimos el cuerpo de la solicitud (el JSON)
            request.AddJsonBody(jsonEntrada);  // Usamos AddJsonBody para pasar el JSON como cuerpo

            // Configuramos las cabeceras si es necesario
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Tbk-Api-Key-Id", "tu_api_key_id"); // Agrega las cabeceras necesarias para la API
            request.AddHeader("Tbk-Api-Key-Secret", "tu_api_key_secret");

            request.RequestFormat = DataFormat.Json; // Establecemos el formato de la solicitud como JSON

            // Ejecutamos la solicitud y obtenemos la respuesta
            return client.Execute(request);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al consumir el servicio: {ex.Message}", ex);
        }
    }


    public static async Task CreateTransaction()
    {
        // Configurar el HttpClient con BaseAddress
        httpClient = new HttpClient
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
            var response = await httpClient.PostAsync("Transbank/CreateTransaction", null);

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
}
