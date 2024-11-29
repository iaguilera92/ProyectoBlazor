using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Transbank.Webpay.TransaccionCompleta.Responses;

public class TransbankApiService
{
    private readonly HttpClient _httpClient;

    // Constructor que inyecta HttpClient
    public TransbankApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Método para llamar al controlador API y crear la transacción
    public async Task<CreateResponse> CreateTransactionAsync()
    {
        try
        {
            // Realiza la solicitud HTTP POST a tu API para crear la transacción
            var response = await _httpClient.PostAsJsonAsync("api/transbank/create", new { });

            if (response.IsSuccessStatusCode)
            {
                // Procesa la respuesta de la API
                var result = await response.Content.ReadFromJsonAsync<CreateResponse>();
                return result;
            }
            else
            {
                // Maneja el error de la API
                throw new Exception($"Error en la transacción: {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al llamar a la API: {ex.Message}");
        }
    }
}
