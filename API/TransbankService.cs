using Transbank.Webpay.WebpayPlus;  // Asegúrate de usar las clases correctas de Transbank
using Transbank.Webpay.WebpayPlus.Responses; // Para la respuesta de la transacción
using Transbank.Common;
using System.Threading.Tasks;
using System;
using Transbank.Webpay.Common;

namespace API.Services
{
    public class TransbankService
    {
        private readonly Transaction _transaction;

        // Constructor del servicio
        public TransbankService()
        {
            // Configura las opciones de Transbank con las credenciales de prueba
            var options = new Options(
                "597055555541", // Tu comercio o rut de Transbank
                "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", // Tu llave privada
                WebpayIntegrationType.Test  // Configura el tipo de integración (Test o Producción)
            );

            // Inicializa la clase Transaction con las opciones
            _transaction = new Transaction(options);
        }

        // Método que crea la transacción con Transbank
        public async Task<CreateResponse> CreateTransactionAsync()
        {
            try
            {
                var random = new Random();
                string buyOrder = random.Next(999999999).ToString();
                string sessionId = random.Next(999999999).ToString();
                decimal amount = random.Next(1000, 999999);

                // Configura la URL de retorno (la URL a la que Transbank redirige después de la transacción)
                string returnUrl = "https://tusitio.com/return"; // Cambia esta URL por la correcta

                // Crea la transacción
                var result = _transaction.Create(buyOrder, sessionId, amount, returnUrl);

                // Retorna el resultado de la transacción, que contiene la URL para redirigir al usuario
                return result;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al crear la transacción: {ex.Message}", ex);
            }
        }
    }
}
