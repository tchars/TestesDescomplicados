using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TestesDescomplicados.UseCases.Software.AdicionarLinhas;
using TestesDescomplicados.UseCases.Software.Criar;

namespace TestesDescomplicados.Web.Controllers.Software.v1;

[ApiController]
[Route("api/v1/software")]
public class SoftwareController(IMediator mediator) 
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CriarSoftware([FromBody] CriarSoftwareRequest request)
    {
        var response = await _mediator.Send(request);

        if (response is null)
            return UnprocessableEntity(response);

        var locationUri = $"localhost/api/v1/software/{response.IdUnico}";
        return Created(locationUri, response);
    }

    [HttpPost("adicionar-linhas")]
    public async Task<IActionResult> AdicionarLinhasAoSoftware([FromBody] AdicionarLinhasAoSoftwareRequest request)
    {
        var response = await _mediator.Send(request);

        if (response is null)
            return UnprocessableEntity(response);

        return Ok(response);
    }
}
