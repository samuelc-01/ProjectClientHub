using Microsoft.AspNetCore.Mvc;
using ProjectClientHub.API.UsesCases.Clients.Register;
using ProjectClientHub.Communication.Requests;
using ProjectClientHub.Communication.Responses;

namespace ProjectClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson),StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ResponseErrorMessagesJson(ex.Message));
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("Erro desconhecido"));
            }
        }






















        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
