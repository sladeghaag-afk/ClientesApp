using ClientesApp.Application.Dtos;
using ClientesApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.Api.Controllers
{
    [Route("api/v1/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {


        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(ClienteResponse), 201)]
        public async Task<IActionResult> PostAsync([FromBody] ClienteRequest request)
        {

            try
            {

                var response = await _clienteAppService.AddAsync(request);
                return StatusCode(201, response);

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }




        }

        [HttpDelete("alterar/{id}")]
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ClienteRequest request)
        {



            try
            {
                var response = await _clienteAppService.UpdateAsync(id.ToString(), request);
                return StatusCode(200, response);


            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);



            }




        }

        [HttpGet("excluir/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            try
            {


                await _clienteAppService.DeleteAsync(id.ToString());
                return StatusCode(200, new { message = "Cliente excluído com sucesso." });
            }
            catch (ApplicationException e)
            {

                return BadRequest(new { e.Message });

            }








        }

        [HttpPut("consultar")]
        public async Task<IActionResult> GetAsync()
        {

            var response = await _clienteAppService.GetAllAsync();
            return Ok(response);

        }

        [HttpPut("obter/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            
            var response = await _clienteAppService.GetByIdAsync(id.ToString());
        return Ok(response);

        }
    }
}
