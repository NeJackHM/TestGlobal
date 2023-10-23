using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient.Message;
using TestGlobal.Application.Features.Clients.Commands.DeleteClient.Messages;
using TestGlobal.Application.Features.Clients.Commands.UpdateClient.Messages;
using TestGlobal.Application.Features.Clients.Queries.GetClient.Messages;

namespace TestGlobal.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cpf}", Name = "GetClient")]
        public async Task<IActionResult> GetById(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return BadRequest();

            var response = await _mediator.Send(new GetClientRequest { Cpf = cpf });
            return Ok(response);
        }

        [HttpPost(Name = "CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] CreateAndValidateClientRequest request)
        {
            if (request == null)
                return BadRequest();

            if (request.Cpf.IsNullOrEmpty())
                return BadRequest("Cannot permit cpf null or empty");

            var response = await _mediator.Send(request);
            if (!response.Success)
                return BadRequest("An error ocurred during the process.");


            return Ok(response);
        }

        [HttpPut(Name = "UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest request)
        {
            if (request == null)
                return BadRequest();

            if (request.Cpf.IsNullOrEmpty())
                return BadRequest("Cannot permit cpf null or empty");

            var response = await _mediator.Send(request);
            if (!response.Success)
                return BadRequest("An error ocurred during the process.");

            return Ok(response);
        }

        [HttpDelete(Name = "DeleteClient")]
        public async Task<IActionResult> DeleteClient([FromBody] DeleteClientRequest request)
        {
            if (string.IsNullOrEmpty(request.Cpf))
                return BadRequest("Cannot permit cpf null or empty");

            var response = await _mediator.Send(request);
            if (!response.Success)
                return BadRequest("An error ocurred during the process.");

            return Ok(response);
        }
    }
}
