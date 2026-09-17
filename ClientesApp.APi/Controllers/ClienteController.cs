using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.Api.Controllers
{
    [Route("api/v1/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IActionResult> PostAsync()
        {
            return Ok();
        }

        [HttpDelete("alterar")]
        public async Task<IActionResult> PutAsync()
        {
            return Ok();
        }

        [HttpGet("excluir")]
        public async Task<IActionResult> DeleteAsync()
        {
            return Ok();
        }

        [HttpPut("consultar")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok();
        }

        [HttpPut("obter")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok();
        }
    }
}
