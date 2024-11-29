using API.Services;
using Microsoft.AspNetCore.Mvc;
using Transbank.Webpay.WebpayPlus.Responses;  // Asegúrate de usar las clases correctas de Transbank

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransbankController : ControllerBase
    {
        private readonly TransbankService _transbankService;

        public TransbankController(TransbankService transbankService)
        {
            _transbankService = transbankService;
        }

        // Endpoint para crear la transacción
        [HttpPost("create")]
        public async Task<IActionResult> CreateTransaction()
        {
            try
            {
                var result = await _transbankService.CreateTransactionAsync();
                return Ok(result);  // Retorna el resultado de la transacción
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la transacción: {ex.Message}");
            }
        }
    }
}
