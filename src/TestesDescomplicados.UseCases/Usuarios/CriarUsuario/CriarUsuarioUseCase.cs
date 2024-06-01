using MediatR;
using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;
using TestesDescomplicados.Infra.Repositories;

namespace TestesDescomplicados.UseCases.Usuarios.CriarUsuario;

public sealed class CriarUsuarioUseCase(IUsuarioRepository usuarioRepository) 
    : IRequestHandler<CriarUsuarioRequest, CriarUsuarioResponse?>
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public async Task<CriarUsuarioResponse?> Handle(CriarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var novoUsuario = Usuario.Criar(request.Nome, request.Email, request.TipoUsuario);

        if (novoUsuario is null)
            return default;

        if (!await _usuarioRepository.SalvarUsuarioAsync(novoUsuario))
            return default;

        return new CriarUsuarioResponse(novoUsuario.Id, novoUsuario.IdUnico, novoUsuario.Nome, novoUsuario.Email);
    }
}
