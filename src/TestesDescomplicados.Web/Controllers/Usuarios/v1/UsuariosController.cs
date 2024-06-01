using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestesDescomplicados.UseCases.Usuarios.CriarUsuario;

namespace TestesDescomplicados.Web.Controllers.Usuarios.v1;

[AllowAnonymous]
[ApiController]
[Route("api/v1/usuarios")]
public class UsuariosController(IMediator mediator) 
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CriarUsuarioAsync([FromBody] CriarUsuarioRequest request)
    {
        var response = await _mediator.Send(request);

        if (response is null)
            return UnprocessableEntity(response);

        return Ok(response);
    }
}
