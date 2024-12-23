using API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace API.Controllers
{
    // Controlador en la API que reenvía la solicitud a Transbank
    [ApiController]
    [Route("Transbank")]
    public class WebpayController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WebpayController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Este es el endpoint que tu Blazor WebAssembly llamará
        [HttpPost("CreateTransaction")]
        public async Task<IActionResult> CreateTransaction()
        {
            var transactionData = new
            {
                buy_order = "ordenCompra12345678",
                session_id = "sesion1234557545",
                amount = 10000,
                return_url = "http://www.comercio.cl/webpay/retorno"
            };
            // La URL del API de Transbank para crear una transacción
            string apiUrl = "https://webpay3gint.transbank.cl/rswebpaytransaction/api/webpay/v1.2/transactions";

            // Claves de la API de Transbank
            string apiKeyId = "597055555532";
            string apiKeySecret = "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C";

            // Preparamos el contenido JSON
            var content = new StringContent(JsonConvert.SerializeObject(transactionData), Encoding.UTF8, "application/json");

            // Añadimos las cabeceras de la API de Transbank
            content.Headers.Add("Tbk-Api-Key-Id", apiKeyId);
            content.Headers.Add("Tbk-Api-Key-Secret", apiKeySecret);

            // Realizamos la solicitud POST al API de Transbank
            var response = await _httpClient.PostAsync(apiUrl, content);

            // Verificamos si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData); // Retornamos la respuesta de Transbank al frontend
            }
            else
            {
                // En caso de error, retornamos el código de error y un mensaje
                return StatusCode((int)response.StatusCode, "Error en la transacción");
            }
        }       
    }
}