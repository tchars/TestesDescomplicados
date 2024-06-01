using MediatR;
using TestesDescomplicados.Infra.Repositories;

namespace TestesDescomplicados.UseCases.Usuarios.BuscarTodos;

public sealed class BuscarTodosUsuariosUseCase(IUsuarioRepository usuarioRepository) 
    : IRequestHandler<BuscarTodosUsuariosRequest, BuscarTodosUsuariosResponse>
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public async Task<BuscarTodosUsuariosResponse> Handle(BuscarTodosUsuariosRequest request, CancellationToken cancellationToken)
    {
        var todosRegistros = await _usuarioRepository.BuscarTodosAsync();

        List<UsuarioDto> response = [];        
        foreach (var registro in todosRegistros)
        {
            response.Add(new UsuarioDto (registro.Id, registro.IdUnico, registro.Email, registro.Nome ));
        }

        return new BuscarTodosUsuariosResponse(response);
    }
}
