using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClienteController : ControllerBase
    {
        // Un endpoint GET simple que devuelve un mensaje
        [HttpPost("TEST")]
        public async Task<IActionResult> CreateTransaction()
        {
            return Ok("¡Hola desde el servicio básico!");
        }
    }
}
